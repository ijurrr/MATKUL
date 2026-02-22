using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public enum Mode { Translate, Rotate, Scale }

    [Tooltip("Operation to perform on this Transform.")]
    public Mode mode = Mode.Translate;

    [Tooltip("Speed per axis (units/sec for translate/scale, degrees/sec for rotate)")]
    public Vector3 speed = new Vector3(1f, 90f, 0f);

    [Tooltip("Apply transform each frame automatically. If false, use the toggle key to apply.")]
    public bool applyContinuously = true;

    [Tooltip("If true, translate/rotate use local space; otherwise world space.")]
    public bool useLocalSpace = true;

    [Tooltip("Key to toggle active state when not applying continuously.")]
    public KeyCode toggleKey = KeyCode.Space;

    bool activeState = true;

    void Start()
    {
        activeState = true;
    }

    void Update()
    {
        if (!applyContinuously)
        {
            if (Input.GetKeyDown(toggleKey)) activeState = !activeState;
        }

        if (!applyContinuously && !activeState) return;

        Vector3 delta = speed * Time.deltaTime;

        switch (mode)
        {
            case Mode.Translate:
                transform.Translate(delta, useLocalSpace ? Space.Self : Space.World);
                break;

            case Mode.Rotate:
                transform.Rotate(delta, useLocalSpace ? Space.Self : Space.World);
                break;

            case Mode.Scale:
                Vector3 s = transform.localScale + delta;
                s.x = Mathf.Max(0.0001f, s.x);
                s.y = Mathf.Max(0.0001f, s.y);
                s.z = Mathf.Max(0.0001f, s.z);
                transform.localScale = s;
                break;
        }
    }
}
