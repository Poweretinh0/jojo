using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cristais : MonoBehaviour
{
    public static int cristal;
    [SerializeField]Text numero;

    void Update()
    {
        numero.text = cristal.ToString();
    }
}
