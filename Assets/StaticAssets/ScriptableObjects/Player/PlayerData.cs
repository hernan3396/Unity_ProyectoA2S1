using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Entity/Player Data", order = 0)]
public class PlayerData : ScriptableObject
{
    #region HP
    [Header("HP")]
    public int Hp;
    public float Invulnerability;
    #endregion

    #region Jumping
    [Header("Jumping")]
    public int GravityScale; // no esta
    public int JumpForce; // no esta
    public int JumpTime; // no esta
    #endregion

    #region Movement
    [Header("Movement")]
    public int Speed;
    #endregion

    #region CameraShake
    [Header("Camera Shake")]
    public float DamageShake;
    public float ShakeTime;
    #endregion

    #region WeaponsData
    [Header("Weapons Data")]
    public WeaponData[] WeaponList;
    #endregion
}