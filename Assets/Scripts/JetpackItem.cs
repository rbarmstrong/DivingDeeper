using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackItem : MonoBehaviour
{
    public int initialBoost = 1;
    public GameObject tooltip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.AcquireJetpack(initialBoost);
            }
            Destroy(gameObject);

            // pause and display tooltip
            player.PauseGame();
            tooltip.SetActive(true);
        }
    }
}