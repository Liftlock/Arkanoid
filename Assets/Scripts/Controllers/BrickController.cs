using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {



	// private Color m_colorGrey = new Color32(0x53, 0x53, 0x53, 1);
	// private Color m_colorRed = new Color32(0xF9, 0x23, 0x23, 1);	
	// private Color m_colorYellow = new Color32(0xF8, 0xFF, 0x00, 1);
	// private Color m_colorLightBlue = new Color32(0x39, 0x9F, 0xFF, 1);
	// private Color m_colorMagenta = new Color32(0xF9, 0x23, 0x23, 1);
	// private Color m_colorGreen = new Color32(0x05, 0xFF, 0x00, 1);

	private int m_hitsToKill;
    private int m_points;
    private int m_numberOfHits;
	private bool m_havePowerUp = false;
	public GameObject m_powerUp; 

	void Start () {
        m_numberOfHits = 0;
		m_hitsToKill = 1;
		//m_powerUp = null;
    }

	// Breaking Things 
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ball"){
        	m_numberOfHits++;
 
        	if (m_numberOfHits == m_hitsToKill) {
	
				if(m_havePowerUp) {
					Debug.Log("Attempting to activate " + m_powerUp.name);
					m_powerUp.GetComponent<PowerUpController>().Activate();
				} 
            	Destroy(this.gameObject);
        	}
    	}
	}

	// Adding PowerUps 
	public void AddPowerUp(GameObject powerUp) {
		Debug.Log("Got " + powerUp.name);
		m_powerUp = powerUp; 
		Debug.Log("Have " + m_powerUp.name);
		m_havePowerUp = true;
	}
	
}
