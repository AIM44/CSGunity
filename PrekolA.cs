using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AIMt;

public class PrekolA : MonoBehaviour
{
    public GameObject lLev; // объект из которого надо вычитать 
    public GameObject pPrav; // объект которым вычитают
    public bool BoolnAnd = false; // если false, то быдет вычитание. Если true, то будет пересечение обеих объектов (оператор and)
    void Update()
    {
        Mesh NewMesh = gameObject.GetComponent<MakeHole>().CSGaim(lLev, pPrav, BoolnAnd); // (объект из которого надо вычитать, объект которым вычитают, тип операции)

        lLev.GetComponent<MeshFilter>().mesh = NewMesh; // обьект из которого вычитают меняет меш на новый

        Destroy(pPrav); // удаляет объект которым вычитали
    }
}
