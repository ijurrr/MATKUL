using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Attack")]
public class AttackStateSO : StateSO
{
    public StateSO chaseState;

    public override void Enter(EnemyController enemy)
    {
        Debug.Log("Attack");
    }

    public override void Execute(EnemyController enemy)
    {
        Debug.Log("Menyerang Player");

        if (enemy.DistanceToPlayer() > enemy.attackRange)
        {
            enemy.ChangeState(chaseState);
        }
    }

    public override void Exit(EnemyController enemy) { }
}