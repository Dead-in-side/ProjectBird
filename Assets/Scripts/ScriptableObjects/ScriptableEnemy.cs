using UnityEngine;


[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy/Create new Bird")]
public class ScriptableEnemy : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float MinDelay { get; private set; } = 2;
    [field: SerializeField] public float MaxDelay { get; private set; } = 6;
}