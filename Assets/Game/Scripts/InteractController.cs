using MalbersAnimations;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    public void Interact(string trigger)
    {
        GameManager.Instance.SendTrigger(trigger);
    }
}
