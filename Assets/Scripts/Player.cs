using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction Died;
    public event UnityAction EnteredTheDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstackle obstackle))
        {
            Died?.Invoke();
        }
        if (collision.gameObject.TryGetComponent(out Door door))
        {
            EnteredTheDoor?.Invoke();
        }
    }
}
