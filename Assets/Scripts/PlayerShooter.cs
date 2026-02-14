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
         Shoot.started += Shoot_started;
    }

    private void OnDisable()
    {
        Shoot.started -= Shoot_started;
    }
    private void Shoot_started(InputAction.CallbackContext ContextObj)
    {
        GameObject bullet = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(BulletSpawn.forward * BulletForce, ForceMode.Impulse);
        Destroy(bullet, 1.5f);
    }
    
}
