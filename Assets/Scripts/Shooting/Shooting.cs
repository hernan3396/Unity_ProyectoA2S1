using UnityEngine;

// lo intente hacer medio generico
// para que todo lo que dispares 
// use solo este script llamando
// al metodo Shoot;
public class Shooting : MonoBehaviour
{
    public enum BulletType
    {
        BULLETPOOL,
        ROCKETPOOL,
        NONE
    }

    private PoolManager[] _pools = new PoolManager[2]; // este numero es la cantidad de armas que tenes (que disparan)

    private void Start()
    {
        _pools[(int)BulletType.BULLETPOOL] = GameManager.GetInstance.GetBulletPool;
        _pools[(int)BulletType.ROCKETPOOL] = GameManager.GetInstance.GetRocketPool;
    }

    public void Shoot(int bulletType, Vector3 bulletPos, Vector3 direction, int bulletSpeed)
    {
        GameObject bullet = _pools[bulletType].GetPooledObject(); // obtiene una bala de la pool
        if (!bullet) return;

        // posiciona la bala
        bullet.transform.position = bulletPos;
        bullet.SetActive(true);

        // impulsa la bala
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode.Impulse);
    }
}