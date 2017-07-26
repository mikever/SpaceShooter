using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour {

    public int pointsToAdd = 200;
    public int healthPointsToAdd = 50;

    void OnTriggerEnter(Collider Col)
    {
        Health H = Col.gameObject.GetComponent<Health>();
        Die();
        givePoints();

        // give player health boost
        if (H.HealthPoints < 100)
        {
            H.HealthPoints += healthPointsToAdd;
        }
        
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    void givePoints()
    {
        GameController.Score = GameController.Score + pointsToAdd;
    }
    

}
