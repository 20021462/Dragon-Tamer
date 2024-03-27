using UnityEngine.Events;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 10, 0));
    }
}
