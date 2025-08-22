using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AIMt;

public class PrekolA : MonoBehaviour
{
    public GameObject lLev; // ������ �� �������� ���� �������� 
    public GameObject pPrav; // ������ ������� ��������
    public bool BoolnAnd = false; // ���� false, �� ����� ���������. ���� true, �� ����� ����������� ����� �������� (�������� and)
    void Update()
    {
        Mesh NewMesh = gameObject.GetComponent<MakeHole>().CSGaim(lLev, pPrav, BoolnAnd); // (������ �� �������� ���� ��������, ������ ������� ��������, ��� ��������)

        lLev.GetComponent<MeshFilter>().mesh = NewMesh; // ������ �� �������� �������� ������ ��� �� �����

        Destroy(pPrav); // ������� ������ ������� ��������
    }
}
