using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    
    public void LeftArrow()
    {
        _obj.transform.Rotate(Vector3.forward, 30f);
    }
    
    public void RightArrow()
    {
        _obj.transform.Rotate(Vector3.back, 30f);
    }
}
