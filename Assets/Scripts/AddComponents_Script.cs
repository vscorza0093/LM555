using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddComponents_Script : MonoBehaviour
{
    public GameObject emptyPlaceHolderObj;

    private GameController gameController;

    public GameObject resistor;

    public string objectTag;
    public int slotPlaceHolderNumber;
    public GameObject slotPlaceHolderObj;

    [SerializeField]
    private GameObject[] ledLights;
    [SerializeField]
    private GameObject[] prefabObj;
    [SerializeField]
    private Material[] prefabMaterial;
    [SerializeField]
    private Material[] prefabLEDMaterial;
    [SerializeField]
    private GameObject ledMenu;
    [SerializeField]
    private GameObject[] otherLEDMenu;
    [SerializeField]
    private GameObject[] resistorMenu;
    [SerializeField]
    private Text[] menu2Text;
    [SerializeField]
    private GameObject[] otherResistorMenu;
    [SerializeField]
    private GameObject capacitorMenu;
    [SerializeField]
    private GameObject[] otherCapacitorMenu;

    public Text slotText;

    private bool ledMenuIsOpen = false;

    private bool firstResistorMenuIsOpen = false;

    public static bool slotIsOcupied = false;
    public static bool correctComponent = false;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
    }
    private void Update()
    {
        if (slotPlaceHolderObj != null)
        {
            slotIsOcupied = true;   
            if (slotPlaceHolderObj.gameObject.tag == objectTag)
            {
                correctComponent = true;

                if (slotPlaceHolderNumber == 2)
                {
                    gameController.rightComponent[1] = true;
                    GameController._Capacitor = true;
                    GameController.capacitorValue = slotPlaceHolderObj.GetComponent<Capacitor>().value;
                }

                if (slotPlaceHolderNumber  == 5)
                {
                    gameController.rightComponent[4] = true;
                    GameController.r1 = true;
                    GameController.r1Value = slotPlaceHolderObj.GetComponent<Resistor>().value;
                }

                if (slotPlaceHolderNumber == 6)
                {
                    gameController.rightComponent[5] = true;
                    GameController.r2 = true;
                    GameController.r2Value = slotPlaceHolderObj.GetComponent<Resistor>().value;
                }

                if (slotPlaceHolderNumber == 4)
                {
                    gameController.rightComponent[3] = true;
                    GameController.rLEDValue = slotPlaceHolderObj.GetComponent<Resistor>().value;
                    GameController.rLED = true;
                }
            }
            else
            {
                correctComponent = false;
            }     
        }
        else slotIsOcupied = false;
    }


    // Resistor menu behavior
    public void AddResistor()
    {
        if (slotPlaceHolderObj == null)
        {
            if (GameController.resistorsInBoard < 3)
            {
            slotPlaceHolderObj = Instantiate(emptyPlaceHolderObj);
                if (!firstResistorMenuIsOpen)
                {                  
                    firstResistorMenuIsOpen = true;
                    resistorMenu[0].SetActive(true);
                }
            }
            else Debug.Log("Max resistors added");
        }

        else Debug.Log("Slot ocupado");
    }

    public void DefineResistor100ohms()
    {  
        DefineResistorMaterial(100);
        firstResistorMenuIsOpen = false;
        resistorMenu[0].SetActive(false);
    }

    public void DefineResistor1kohms()
    { 
        DefineResistorMaterial(1000);
        firstResistorMenuIsOpen = false;
        resistorMenu[0].SetActive(false);
    }

    public void DefineResistor10kohms()
    {    
        DefineResistorMaterial(10000);
        firstResistorMenuIsOpen = false;
        resistorMenu[0].SetActive(false);
    }

    public void DefineResistor100kohms()
    {     
        DefineResistorMaterial(100000);
        firstResistorMenuIsOpen = false;
        resistorMenu[0].SetActive(false);
    }

    public void DefineResistor470kohms()
    {       
        DefineResistorMaterial(470000);
        firstResistorMenuIsOpen = false;
        resistorMenu[0].SetActive(false);
    }

    public void DefineResistor1Mohms()
    {      
        DefineResistorMaterial(1000000);
        firstResistorMenuIsOpen = false;
        resistorMenu[0].SetActive(false);
    }
    public void DefineResistorMaterial(int v)
    {
        Destroy(slotPlaceHolderObj.gameObject);
        slotPlaceHolderObj = Instantiate(prefabObj[0].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);

        if (v == 100) slotPlaceHolderObj.GetComponent<MeshRenderer>().material = prefabMaterial[0];
        else if (v == 1000) slotPlaceHolderObj.GetComponent<MeshRenderer>().material = prefabMaterial[1];
        else if (v == 10000) slotPlaceHolderObj.GetComponent<MeshRenderer>().material = prefabMaterial[2];
        else if (v == 100000) slotPlaceHolderObj.GetComponent<MeshRenderer>().material = prefabMaterial[3];
        else if (v == 470000) slotPlaceHolderObj.GetComponent<MeshRenderer>().material = prefabMaterial[4];
        else if (v == 1000000) slotPlaceHolderObj.GetComponent<MeshRenderer>().material = prefabMaterial[5];

        if (slotPlaceHolderNumber == 5) //R1
        {
            slotPlaceHolderObj.gameObject.tag = "R1";
            gameController.rightComponent[4] = true;
            GameController.r1 = true;
        }

        else if (slotPlaceHolderNumber == 6) //R2
        {
            slotPlaceHolderObj.gameObject.tag = "R2";
            gameController.rightComponent[5] = true;
            GameController.r2 = true;
        }

        else if (slotPlaceHolderNumber == 4) //RLED
        {
            slotPlaceHolderObj.gameObject.tag = "RLED";
            gameController.rightComponent[3] = true;
            GameController.rLED = true;
        }

        slotText.enabled = false;
        slotPlaceHolderObj.GetComponent<Resistor>().value = v;
        GameController.resistorsInBoard++;
    }

    // LED menu behavior
    public void AddLED()
    {
        if (slotPlaceHolderObj == null && !GameController._LED && GameController.ledInBoard == 0)
        {
            slotPlaceHolderObj = Instantiate(emptyPlaceHolderObj);
            if (!ledMenuIsOpen)
            {
                slotText.enabled = false;
                ledMenuIsOpen = true;
                ledMenu.SetActive(true);
            }
        }
        else Debug.Log("Slot ocupado");
    }

    public void LEDColorBlue()
    {
        Destroy(slotPlaceHolderObj.gameObject);
        slotPlaceHolderObj = Instantiate(prefabObj[1].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);
        slotPlaceHolderObj.GetComponent<MeshRenderer>().material = prefabLEDMaterial[1];
        ledLights[0] = GameObject.FindGameObjectWithTag("light1");
        ledLights[0].GetComponentInChildren<Light>().color = new Color32(0, 0, 255, 255);
        ledLights[1] = GameObject.FindGameObjectWithTag("light2");
        ledLights[1].GetComponentInChildren<Light>().color = new Color32(0, 0, 255, 255);
        ledLights[0].SetActive(false);
        ledLights[1].SetActive(false);
        if (slotPlaceHolderNumber == 3)
        {
            gameController.rightComponent[2] = true;
        }
        GameController._LED = true;
        GameController.ledInBoard++;
        ledMenuIsOpen = false;
        ledMenu.SetActive(false);
    }
    public void LEDColorGreen()
    {
        Destroy(slotPlaceHolderObj.gameObject);
        slotPlaceHolderObj = Instantiate(prefabObj[1].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);
        slotPlaceHolderObj.GetComponent<MeshRenderer>().material = prefabLEDMaterial[3];
        ledLights[0] = GameObject.FindGameObjectWithTag("light1");
        ledLights[0].GetComponentInChildren<Light>().color = new Color32(0, 255, 0, 255);
        ledLights[1] = GameObject.FindGameObjectWithTag("light2");
        ledLights[1].GetComponentInChildren<Light>().color = new Color32(0, 255, 0, 255);
        ledLights[0].SetActive(false);
        ledLights[1].SetActive(false);
        if (slotPlaceHolderNumber == 3)
        {
            gameController.rightComponent[2] = true;
        }
        GameController._LED = true;
        GameController.ledInBoard++;
        ledMenuIsOpen = false;
        ledMenu.SetActive(false);
    }


    public void LEDColorRed()
    {
        Destroy(slotPlaceHolderObj.gameObject);
        slotPlaceHolderObj = Instantiate(prefabObj[1].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);
        slotPlaceHolderObj.GetComponent<MeshRenderer>().material = prefabLEDMaterial[4];
        slotPlaceHolderObj.GetComponentInChildren<Light>().color = new Color32(255, 0, 0, 255);
        ledLights[0] = GameObject.FindGameObjectWithTag("light1");
        ledLights[0].GetComponentInChildren<Light>().color = new Color32(255, 0, 0, 255);
        ledLights[1] = GameObject.FindGameObjectWithTag("light2");
        ledLights[1].GetComponentInChildren<Light>().color = new Color32(255, 0, 0, 255);
        ledLights[0].SetActive(false);
        ledLights[1].SetActive(false);
        if (slotPlaceHolderNumber == 3)
        {
            gameController.rightComponent[2] = true;
        }
        GameController._LED = true;
        GameController.ledInBoard++;
        ledMenuIsOpen = false;
        ledMenu.SetActive(false);
    }

    public void LEDColorWhite()
    {
        Destroy(slotPlaceHolderObj.gameObject);
        slotPlaceHolderObj = Instantiate(prefabObj[1].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);
        slotPlaceHolderObj.GetComponent<MeshRenderer>().material = prefabLEDMaterial[2];
        slotPlaceHolderObj.GetComponentInChildren<Light>().color = new Color32(255, 255, 255, 255);
        ledLights[0] = GameObject.FindGameObjectWithTag("light1");
        ledLights[0].GetComponentInChildren<Light>().color = new Color32(255, 255, 255, 255);
        ledLights[1] = GameObject.FindGameObjectWithTag("light2");
        ledLights[1].GetComponentInChildren<Light>().color = new Color32(255, 255, 255, 255);
        ledLights[0].SetActive(false);
        ledLights[1].SetActive(false);
        if (slotPlaceHolderNumber == 3)
        {
            gameController.rightComponent[2] = true;
        }
        GameController._LED = true;
        GameController.ledInBoard++;
        ledMenuIsOpen = false;
        ledMenu.SetActive(false);
    }

    public void LEDColorYellow()
    {
        Destroy(slotPlaceHolderObj.gameObject);
        slotPlaceHolderObj = Instantiate(prefabObj[1].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);
        slotPlaceHolderObj.GetComponent<MeshRenderer>().material = prefabLEDMaterial[0];
        slotPlaceHolderObj.GetComponentInChildren<Light>().color = new Color32(255, 255, 0, 255);
        ledLights[0] = GameObject.FindGameObjectWithTag("light1");
        ledLights[0].GetComponentInChildren<Light>().color = new Color32(255, 255, 0, 255);
        ledLights[1] = GameObject.FindGameObjectWithTag("light2");
        ledLights[1].GetComponentInChildren<Light>().color = new Color32(255, 255, 0, 255);
        ledLights[0].SetActive(false);
        ledLights[1].SetActive(false);
        if (slotPlaceHolderNumber == 3)
        {
            gameController.rightComponent[2] = true;
        }
        GameController._LED = true;
        GameController.ledInBoard++;
        ledMenuIsOpen = false;
        ledMenu.SetActive(false);
    }

    // Capacitor menu behavior
    public void AddCapacitor()
    {
        if (slotPlaceHolderObj == null && !GameController._Capacitor && GameController.capacitorInBoard == 0)
        {
            slotPlaceHolderObj = Instantiate(emptyPlaceHolderObj);
            GameController._Capacitor = true;
            GameController.capacitorInBoard++;
            slotText.enabled = false;
            capacitorMenu.SetActive(true);
            if (slotPlaceHolderNumber == 2)
            {
                gameController.rightComponent[1] = true;
            }
        }
        else
        {
            Debug.Log("Slot ocupado");
        }
    }
    public void DefineCapacitor1uF()
    {
        Destroy(slotPlaceHolderObj.gameObject);
        slotPlaceHolderObj = Instantiate(prefabObj[2].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);
        capacitorMenu.SetActive(true);
        slotPlaceHolderObj.GetComponent<Capacitor>().value = 0.000001f;
        capacitorMenu.SetActive(false);
    }

    public void DefineCapacitor10uF()
    {
        Destroy(slotPlaceHolderObj.gameObject);
        slotPlaceHolderObj = Instantiate(prefabObj[2].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);
        capacitorMenu.SetActive(true);
        slotPlaceHolderObj.GetComponent<Capacitor>().value = 0.00001f;
        capacitorMenu.SetActive(false);
    }

    public void DefineCapacitor33uF()
    {
        Destroy(slotPlaceHolderObj.gameObject);
        slotPlaceHolderObj = Instantiate(prefabObj[2].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);
        capacitorMenu.SetActive(true);
        slotPlaceHolderObj.GetComponent<Capacitor>().value = 0.000033f;
        capacitorMenu.SetActive(false);
    }

    public void DefineCapacitor100uf()
    {
        Destroy(slotPlaceHolderObj.gameObject);
        slotPlaceHolderObj = Instantiate(prefabObj[2].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);
        capacitorMenu.SetActive(true);
        slotPlaceHolderObj.GetComponent<Capacitor>().value = 0.0001f;
        capacitorMenu.SetActive(false);
    }

    public void DefineCapacitor470uf()
    {
        Destroy(slotPlaceHolderObj.gameObject);
        slotPlaceHolderObj = Instantiate(prefabObj[2].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);
        capacitorMenu.SetActive(true);
        slotPlaceHolderObj.GetComponent<Capacitor>().value = 0.00047f;
        capacitorMenu.SetActive(false);
    }

    public void DefineCapacitor1000uF()
    {
        Destroy(slotPlaceHolderObj.gameObject);
        slotPlaceHolderObj = Instantiate(prefabObj[2].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);
        capacitorMenu.SetActive(true);
        slotPlaceHolderObj.GetComponent<Capacitor>().value = 0.001f;
        capacitorMenu.SetActive(false);
    }


    // LM555 menu behavior
    public void Add555()
    {
        if (slotPlaceHolderObj == null && !GameController._LM555 && GameController.lm555InBoard == 0)
        {
            slotPlaceHolderObj = Instantiate(prefabObj[3].gameObject, this.transform.position, this.transform.rotation, this.transform.parent);
            GameController._LM555 = true;
            GameController.lm555InBoard++;
            slotText.enabled = false;
            if (slotPlaceHolderNumber == 1)
            {
                gameController.rightComponent[0] = true;
            }
        }
        else Debug.Log("Slot ocupado");
    }
  

    // Other functions
    public void RemoveComponent()
    {
        if (slotPlaceHolderObj != null && slotPlaceHolderObj.gameObject.tag != "emptyObject")
        {
            if (slotPlaceHolderObj.gameObject.tag == "Resistor" || slotPlaceHolderObj.gameObject.tag == "R1" || slotPlaceHolderObj.gameObject.tag == "R2" || slotPlaceHolderObj.gameObject.tag == "RLED")
            {
                if (slotPlaceHolderNumber == 4) //RLED
                {
                    gameController.resistorsObjs[2] = emptyPlaceHolderObj;
                    gameController.rightComponent[3] = false;
                }

                else if (slotPlaceHolderNumber == 5) //R1
                {
                    gameController.resistorsObjs[0] = emptyPlaceHolderObj;
                    gameController.rightComponent[4] = false;
                }

                else if (slotPlaceHolderNumber == 6) //R2
                {
                    gameController.resistorsObjs[1] = emptyPlaceHolderObj;
                    gameController.rightComponent[5] = false;
                }
                slotPlaceHolderObj.GetComponent<Resistor>().value = 0;
                GameController.resistorsInBoard--;
            }
            else if (slotPlaceHolderObj.gameObject.tag == "LED")
            {
                gameController.rightComponent[2] = false;
                GameController.ledInBoard--;
            }
            else if (slotPlaceHolderObj.gameObject.tag == "Capacitor")
            {
                gameController.rightComponent[1] = false;
                gameController.capacitorObj = null;
                slotPlaceHolderObj.GetComponent<Capacitor>().value = 0;
                GameController.capacitorInBoard--;    
            }
            else if (slotPlaceHolderObj.gameObject.tag == "LM555")
            {
                gameController.rightComponent[0] = false;
                GameController.lm555InBoard--;
            }
            Destroy(slotPlaceHolderObj.gameObject);
            slotText.enabled = true;
        }
    }

    //Change name to --> CloseResistorMenu <--
    public void CloseThisMenu()
    {
        firstResistorMenuIsOpen = false;
        resistorMenu[0].SetActive(false);
        resistorMenu[1].SetActive(false);
    }
}
