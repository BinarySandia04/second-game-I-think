using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubitoclone : MonoBehaviour {

    public GameObject cubitoGenerator;
    public GameObject cubito;

    private bool started = false;

    public void GenerarCubito()
    {
        if (!started) StartCoroutine(generation());
    }

    IEnumerator generation()
    {
        for (int i = 0; i < 10000; i++){
            Instantiate(cubito, cubitoGenerator.transform);
            yield return new WaitForSeconds(0.2f);
        }
    }

}
