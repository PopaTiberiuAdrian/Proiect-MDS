using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EVP;

public class VehicleHandler : MonoBehaviour {

    [SerializeField]
    private GameObject playerCamera;

    private GameObject Vehicle;
    private bool isInVehicle = false;

    public void SetChildren(bool enableDisable)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(enableDisable);
        }
    }

    void OnTriggerStay(Collider newVehicle)
    {
        if (newVehicle.gameObject.tag == "Vehicle" && Input.GetKeyDown(KeyCode.F) && isInVehicle == false)
        {
            Vehicle = newVehicle.transform.parent.transform.parent.gameObject;
            if (Vehicle.GetComponent<MoneyCollectorFromVehicle>().IsLocked() == false)
            {
                isInVehicle = true;
                transform.parent = Vehicle.transform;
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                transform.localScale = Vector3.one;
                gameObject.GetComponent<Player>().enabled = false;
                gameObject.GetComponent<CapsuleCollider>().enabled = false;
                gameObject.GetComponent<PlayerAnimation>().enabled = false;
                gameObject.GetComponent<PlayerShoot>().enabled = false;
                gameObject.GetComponent<MoveController>().enabled = false;
                SetChildren(false);
                playerCamera.SetActive(false);
                Vehicle.transform.Find("Camera Controller").gameObject.SetActive(true);

                Vehicle.GetComponent<VehicleStandardInput>().enabled = true;
                Debug.Log("I'm attached to " + newVehicle.gameObject.name);
            }
        }
        else
            if(newVehicle.gameObject.tag == "Vehicle" && Input.GetKeyDown(KeyCode.B) && isInVehicle == false)
            {
                Vehicle = newVehicle.transform.parent.transform.parent.gameObject;
                if(Vehicle.GetComponent<MoneyCollectorFromVehicle>().getPrice() < GetComponent<PlayerStats>().getAmountOfMoney())
                {
                    GetComponent<PlayerStats>().decreaseAmountOfMoney(Vehicle.GetComponent<MoneyCollectorFromVehicle>().getPrice());
                    Vehicle.GetComponent<MoneyCollectorFromVehicle>().Unlock();
                }
            }
    }

    void Update()
    {
        if(isInVehicle == true)
        if (isInVehicle == true && Input.GetKeyDown(KeyCode.E))
        {
            Vehicle.transform.Find("Camera Controller").gameObject.SetActive(false);
            Vehicle.GetComponent<VehicleStandardInput>().enabled = false;
            gameObject.GetComponent<Player>().enabled = true;
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
            gameObject.GetComponent<PlayerAnimation>().enabled = true;
            gameObject.GetComponent<PlayerShoot>().enabled = true;
            gameObject.GetComponent<MoveController>().enabled = true;
            SetChildren(true);
            playerCamera.SetActive(true);
            transform.parent = null;
            isInVehicle = false;
        }
    }
}
