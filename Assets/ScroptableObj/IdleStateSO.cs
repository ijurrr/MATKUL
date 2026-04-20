using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Idle")]
public class IdleStateSO : StateSO
{
    public StateSO chaseState;

    public override void Enter(EnemyController enemy)
    {
        Debug.Log("Idle");
    }

    public override void Execute(EnemyController enemy)
    {
        if (enemy.DistanceToPlayer() < enemy.chaseRange)
        {
            enemy.ChangeState(chaseState);
        }
    }

    public override void Exit(EnemyController enemy) { }
}