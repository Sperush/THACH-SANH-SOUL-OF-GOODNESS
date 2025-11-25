using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class ItemUI
{
    public Image image;
    public TMP_Text quantity;
}
public class Inventory : MonoBehaviour
{
    public Animator animator;
    public GameObject[] Weapons;
    public GameObject BtnLoot;
    public GameObject skill;
    public GameObject openBag;
    public GameObject BtnOpenBag;
    public List<ItemUI> ItemHand = new List<ItemUI>();
    public List<ItemUI> ItemBag = new List<ItemUI>();
    public List<Item> bag = new List<Item>();
    private bool isCurrently90Degrees = false;
    private int lastIndex = -1;
    private const int HAND_SIZE = 5;
    private const int MAX_BAG = 10;
    private Item itemFocus = null;
    private List<ItemUI> GetItemList(int index)
    {
        if (index < HAND_SIZE) return ItemHand;
        return ItemBag;
    }

    private int GetUIIndex(int index)
    {
        return index < HAND_SIZE ? index : index - HAND_SIZE;
    }
    private void UpdateSkillBar(int dataIndex)
    {
        if (dataIndex != -1 && dataIndex < bag.Count && bag[dataIndex] != null && dataIndex < 5)
        {
            bool isWeapon = bag[dataIndex].isWeapons();
            int type = bag[dataIndex].name == ItemName.Axe ? 0:1;
            if (isWeapon && !skill.activeSelf)
            {
                skill.SetActive(true);
                Weapons[type].SetActive(true);
            }
            else if (!isWeapon && skill.activeSelf)
            {
                skill.SetActive(false);
                for (int i = 0; i < Weapons.Length; i++)
                {
                    Weapons[i].SetActive(false);
                }
            }
        }
        else if (skill.activeSelf)
        {
            skill.SetActive(false);
            for(int i = 0; i < Weapons.Length; i++)
            {
                Weapons[i].SetActive(false);
            }
        }
    }
    public bool AddItem(Item it)
    {
        Item item = bag.Find(i => i.name == it.name);
        if (item != null)
        {
            item.quantity += it.quantity;
        }
        else
        {
            if (bag.Count >= MAX_BAG)
            {
                Debug.Log("Túi đã đầy!");
                return false;
            }
            bag.Add(it);
        }
        if (bag.Count > HAND_SIZE && !BtnOpenBag.activeSelf) BtnOpenBag.SetActive(true);
        LoadHandBar(bag.Count > 4 ? 5 : bag.Count);
        if(openBag.activeSelf) LoadBag(true);
        return true;
    }
    public void SubItem(Item it)
    {
        Item item = bag.Find(i => i.name == it.name);
        if (item != null)
        {
            if(item.quantity < it.quantity)
            {
                Debug.Log("Vượt quá số lượng hiện có không thể thực hiện");
                return;
            }
            item.quantity -= it.quantity;
            if(item.quantity <= 0)
            {
                bag.Remove(item);
                LoadHandBar(bag.Count > HAND_SIZE ? HAND_SIZE : bag.Count);
                if (openBag.activeSelf) LoadBag(true);
            }
        }
    }
    public void ChangeStatusBag(GameObject btn)
    {
        openBag.SetActive(!openBag.activeSelf);
        if (isCurrently90Degrees) btn.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
        else btn.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
        isCurrently90Degrees = !isCurrently90Degrees;
        if (openBag.activeSelf) LoadBag(true);
    }
    public void LoadHandBar(int sz)
    {
        for(int i=0; i < 5; i++)
        {
            if (i < sz)
            {
                ItemHand[i].image.sprite = bag[i].img;
                ItemHand[i].quantity.SetText(bag[i].quantity.ToString());
            }
            ItemHand[i].image.transform.parent.gameObject.SetActive(i < sz);
        }
    }
    public void LoadBag(bool isOpen)
    {
        for (int i = 0; i < 5; i++)
        {
            int dataIndex = i + HAND_SIZE;
            ItemBag[i].image.transform.parent.gameObject.SetActive(isOpen);
            if (isOpen)
            {
                TMP_Text txt = ItemBag[i].quantity;
                if (dataIndex < bag.Count)
                {
                    ItemBag[i].image.sprite = bag[dataIndex].img;
                    txt.SetText(bag[i].quantity.ToString());
                }
                else
                {
                    ItemBag[i].image.sprite = null;
                    txt.SetText("");
                }
            }
        }
    }
    public void SelectItemBar(int index)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("AttackSkill")) return;
        if (index >= bag.Count && bag.Count < MAX_BAG)
        {
            if (lastIndex != -1) GetItemList(lastIndex)[GetUIIndex(lastIndex)].image.transform.parent.GetComponent<Image>().color = Color.white;
            lastIndex = -1;
            UpdateSkillBar(-1);
            return;
        }
        var currentList = GetItemList(index);
        var currentUIIndex = GetUIIndex(index);
        if (lastIndex != -1 && lastIndex != index && lastIndex >= 5)
        {
            bag.Swap(lastIndex, index);
            GetItemList(lastIndex)[GetUIIndex(lastIndex)].image.transform.parent.GetComponent<Image>().color = Color.white;
            currentList[currentUIIndex].image.transform.parent.GetComponent<Image>().color = Color.white;
            LoadHandBar(bag.Count > HAND_SIZE ? HAND_SIZE : bag.Count);
            LoadBag(openBag.activeSelf);
            lastIndex = -1;
        }
        else if (lastIndex == index)
        {
            currentList[currentUIIndex].image.transform.parent.GetComponent<Image>().color = Color.white;
            lastIndex = -1;
        }
        else
        {
            if (lastIndex != -1) GetItemList(lastIndex)[GetUIIndex(lastIndex)].image.transform.parent.GetComponent<Image>().color = Color.white;
            currentList[currentUIIndex].image.transform.parent.GetComponent<Image>().color = Color.red;
            lastIndex = index;
        }
        UpdateSkillBar(lastIndex);
    }
    public Item GetItem(Item it)
    {
        return bag.Find(i => i.name == it.name);
    }
    public int GetIndexItem(Item it)
    {
        return bag.FindIndex(i => i.name == it.name);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            BtnLoot.SetActive(true);
            if(itemFocus == null) itemFocus = other.GetComponent<Item>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            BtnLoot.SetActive(false);
            Item item = other.GetComponent<Item>();
            if (itemFocus != null && item == itemFocus) itemFocus = null;
        }
    }
    public void LootItem()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Gathering") || animator.GetCurrentAnimatorStateInfo(0).IsTag("AttackSkill")) return;
        if (itemFocus != null && AddItem(itemFocus))
        {
            animator.SetTrigger("IsGathering");
            itemFocus.gameObject.SetActive(false); itemFocus = null;
        }
        BtnLoot.SetActive(false);
    }
    public bool isUseWeapons()
    {
        return lastIndex != -1 && bag[lastIndex].isWeapons();
    }
}
