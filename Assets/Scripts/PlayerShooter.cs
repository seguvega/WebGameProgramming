using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform BulletSpawn;
    [SerializeField] private float BulletForce = 0f;//20

    private InputAction Shoot;

    private void Awake()
    {
        Shoot = InputSystem.actions.FindAction("Player/Attack");
    }

    private void OnEnable()
    {
         Shoot.started += ShootPoolBullet;
    }

    private void OnDisable()
    {
        Shoot.started -= ShootPoolBullet;
    }
    private void Shoot_started(InputAction.CallbackContext ContextObj)
    {
        GameObject bullet = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(BulletSpawn.forward * BulletForce, ForceMode.Impulse);
        Destroy(bullet, 1.5f);
    }
    
    private void ShootPoolBullet(InputAction.CallbackContext ContextObj)
    {
        Bullet bullet = BulletObjectPool.Instance.GetBullet();
        if(bullet != null)
        {
            bullet.transform.position = BulletSpawn.position;
            bullet.transform.rotation = BulletSpawn.rotation;
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(BulletSpawn.forward * BulletForce, ForceMode.Impulse);
        }
    }
}
