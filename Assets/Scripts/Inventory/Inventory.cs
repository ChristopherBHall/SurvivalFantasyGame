using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : MonoBehaviour {

    public int slotAmount = 24;
    public GameObject slotPrefab;
    public GameObject slotParent;
    public GameObject itemPrefab;
    
    public GameObject inventoryCanvas;
    private RigidbodyFirstPersonController fpsController;

    private ItemDatabase itemDatabase;
    private PauseManager pauseManager;


    public List<GameObject> slots = new List<GameObject>();


    public KeyCode inventoryKey = KeyCode.I;
    public bool isShown = false;

    public float defaultXSens;
    public float defaultYSens;
    


	// Use this for initialization
	private void Start () {
        CreateSlots(slotAmount);
        itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        pauseManager = GameObject.FindGameObjectWithTag("PauseManager").GetComponent<PauseManager>();
        fpsController = GameObject.FindGameObjectWithTag("Player").GetComponent<RigidbodyFirstPersonController>();
        defaultXSens = fpsController.mouseLook.XSensitivity;
        defaultYSens = fpsController.mouseLook.YSensitivity;
        inventoryCanvas.SetActive(false);


    }

    private void Update()
    {

            if (Input.GetKeyDown(KeyCode.P))
        {
            AddItem(0);
            
            
        }
        if (Input.GetKeyDown(inventoryKey) && pauseManager.isPaused == false)
        {
            
            isShown = !isShown;
            if (isShown == true)
            {
                inventoryCanvas.SetActive(true);
                fpsController.mouseLook.SetCursorLock(false);
                fpsController.mouseLook.XSensitivity = 0.0f;
                fpsController.mouseLook.YSensitivity = 0.0f;




            }
            else if (isShown == false)
            {
                fpsController.mouseLook.SetCursorLock(true);
                inventoryCanvas.SetActive(false);
                fpsController.mouseLook.XSensitivity = defaultXSens;
                fpsController.mouseLook.YSensitivity = defaultYSens;

            }

        }
    }

	
    private void CreateSlots(int slotsAmount)
    {
        for(int i = 0; i < slotsAmount; i++)
        {
            slots.Add(Instantiate(slotPrefab));
            slots[i].transform.SetParent(slotParent.transform);
            
        }
    }

    public void AddItem(int id)
    {
        if(itemDatabase == null)
        {
            itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        }
        Item itemAdd = itemDatabase.GetItemByID(id);
        for(int i = 0; i < slots.Count; i++)
        {
            if (slots[i].transform.childCount <= 0)
            {
                GameObject itemInstance = Instantiate(itemPrefab); // Create item object
                itemInstance.transform.SetParent(slots[i].transform); 
                itemInstance.transform.localPosition = Vector2.zero;
                itemPrefab.GetComponent<Image>().sprite = itemAdd.itemSprite; // set sprite
                break;
            }

        }
        
    }


}
