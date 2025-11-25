using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemName
{
    Axe,
    Bow,
    Wood_red,
    Wood_black,
    Wood_white,
    Wood_brown,
    Feathers, //long vu
    Divine_Rice_Pot // nieu com than
}
public class Item : MonoBehaviour
{
    public ItemName name;
    public int quantity = 1;
    public Sprite img;
    public Transform pointSpawn;
    public GameObject itemPrefab;
    public int CountBreak;
    private void Start()
    {
        CountBreak = Random.Range(3, 7);
    }
    public void Spawn()
    {
        transform.parent.gameObject.SetActive(false);
        int leg = Random.Range(2, 5);
        for (int i =0; i< leg; i++)
        {
            GameObject obj = Instantiate(itemPrefab);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(Random.insideUnitSphere * 3f, ForceMode.Impulse);
            obj.transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            obj.transform.position = pointSpawn.position;
            Item it = obj.GetComponent<Item>();
            it.name = name; 
        }
    }
    public bool isWeapons()
    {
        return name == ItemName.Axe || name == ItemName.Bow;
    }
}
