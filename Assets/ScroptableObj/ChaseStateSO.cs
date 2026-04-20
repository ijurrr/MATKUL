using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Chase")]
public class ChaseStateSO : StateSO
{
    public StateSO idleState;
    public StateSO attackState;

    public override void Enter(EnemyController enemy)
    {
        Debug.Log("Chase");
    }

    public override void Execute(EnemyController enemy)
    {
        enemy.transform.position = Vector2.MoveTowards(
            enemy.transform.position,
            enemy.player.position,
            enemy.speed * Time.deltaTime
        );

        float distance = enemy.DistanceToPlayer();

        if (distance < enemy.attackRange)
            enemy.ChangeState(attackState);

        else if (distance > enemy.chaseRange)
            enemy.ChangeState(idleState);
    }

    public override void Exit(EnemyController enemy) { }
}