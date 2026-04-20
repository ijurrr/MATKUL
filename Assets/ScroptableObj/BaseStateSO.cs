using UnityEngine;
public abstract class StateSO : ScriptableObject 
{
    public abstract void Enter(EnemyController enemy);
    public abstract void Execute(EnemyController enemy);
    public abstract void Exit(EnemyController enemy);
}