using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Entity/New Enemy")]
public class EnemyData : ScriptableObject
{
    #region HP
    [Header("HP")]
    public int Hp;
    public float Invulnerability; // cuanto tiempo es invulnerable
    #endregion

    #region Movement
    [Header("Movement")]
    public int Acceleration;
    public int Speed; // velocidad de movimiento
    #endregion

    #region Shooting
    [Header("Shooting")]
    public float Accuracy; // que tan rapido es en apuntar
    public int VisionRange;
    #endregion

    #region WeaponsData
    [Header("Weapons Data")]
    [SerializeField] public WeaponData[] WeaponList;
    #endregion
}