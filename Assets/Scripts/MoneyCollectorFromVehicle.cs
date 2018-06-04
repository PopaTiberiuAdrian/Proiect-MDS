using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollectorFromVehicle : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    private int priceOfVehicle;
    [SerializeField]
    private bool isLocked = true;
   
    private void Start()
    {
        priceOfVehicle = 1000;
        LockIconAvailability(isLocked);
    }

    public bool IsLocked()
    {
        return isLocked;
    }

    public void LockIconAvailability(bool value)
    {
        transform.Find("LockIcon").gameObject.SetActive(value);
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
    public int getPrice()
    {
        return priceOfVehicle;
    }

    public void Unlock()
    {
        isLocked = false;
        LockIconAvailability(isLocked);
    }

    void OnTriggerEnter(Collider objectCollided)
    {
        if (objectCollided.gameObject.tag == "Money")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            int moneyToAdd = objectCollided.gameObject.GetComponent<ScoreBehaviour>().getValue();
            objectCollided.gameObject.SetActive(false);
            GameObject thePlayer = GameObject.Find("Player");
            PlayerStats playerScript = thePlayer.GetComponent<PlayerStats>();
            playerScript.increaseAmountOfMoney(moneyToAdd);
        }
    }


}
