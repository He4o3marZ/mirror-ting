using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject[] item;
    GameObject currentitem;
    public GameObject ItemHolder;
    void Start()
    {
        currentitem = item[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentitem.SetActive(false);
            currentitem = item[0];
            currentitem.SetActive(true);
            item[0].transform.position = ItemHolder.transform.position;
            item[0].transform.rotation = ItemHolder.transform.rotation;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentitem.SetActive(false);
            currentitem = item[1];
            currentitem.SetActive(true);
            item[1].transform.position = ItemHolder.transform.position;
            item[1].transform.rotation = ItemHolder.transform.rotation;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentitem.SetActive(false);
            currentitem = item[2];
            currentitem.SetActive(true);
            item[2].transform.position = ItemHolder.transform.position;
            item[2].transform.rotation = ItemHolder.transform.rotation;
        }
    }
}
