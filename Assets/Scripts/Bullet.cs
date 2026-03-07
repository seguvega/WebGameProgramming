using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Bullet : MonoBehaviour
{
    private float Timer = 0f;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet hit: " + collision.gameObject.name, collision.gameObject);
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            BulletObjectPool.Instance.ReturnBullet(this);
        }
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= 1.5f)
        {
            BulletObjectPool.Instance.ReturnBullet(this);
        }
    }

    private void OnEnable()
    {
        Timer = 0f;
    }
}
