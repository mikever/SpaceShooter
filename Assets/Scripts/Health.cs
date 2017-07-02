using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public GameObject DeathParticlesPrefab = null;      // animation on death
    public GameObject DamageParticlesPrefab = null;     // animation on damage
    private Transform ThisTransform = null;
    public bool ShouldDestroyOnDeath = true;
    //-------------------

	// Use this for initialization
	void Start () {
        ThisTransform = GetComponent<Transform>();
	}
    //-------------------
    public float HealthPoints
    {
        get
        {
            return _HealthPoints;
        }

        set
        {
            _HealthPoints = value;

            if (_HealthPoints == 100 || _HealthPoints == 200 || _HealthPoints == 300 || _HealthPoints == 400)
            {
                Instantiate(DamageParticlesPrefab, ThisTransform.position, ThisTransform.rotation);
            }

            if (_HealthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);

                if (DeathParticlesPrefab != null)
                    Instantiate(DeathParticlesPrefab, 
                        ThisTransform.position, ThisTransform.rotation);

                if (ShouldDestroyOnDeath)
                    Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        
    }

    //-------------------
    [SerializeField]
    private float _HealthPoints = 100f;

    public void Damage()
    {
        Instantiate(DamageParticlesPrefab,
                        ThisTransform.position, ThisTransform.rotation);
    }
}
//-------------------
