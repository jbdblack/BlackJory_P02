using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] float secondsUntilDestroy = 2f;

    void Start()
    {
        Destroy(gameObject, secondsUntilDestroy);
    }


}
