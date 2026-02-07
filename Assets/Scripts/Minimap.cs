using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
 
    void Update()
    {
        transform.position = new Vector3(PlayerTransform.position.x, transform.position.y, PlayerTransform.position.z);
    }
}
