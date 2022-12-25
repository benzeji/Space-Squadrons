using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float timeTillDestroy;
    
    public void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }
}
