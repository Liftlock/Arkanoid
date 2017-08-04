using UnityEngine;

public class BrickController : MonoBehaviour {

	private int m_hitsToKill;
    private int m_points;
    private int m_numberOfHits;
	private bool m_havePowerUp = false;
	public GameObject m_powerUp; 

	

	void Start () {
        m_numberOfHits = 0;
		m_hitsToKill = 1;
    }

	// Breaking Things 
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ball"){
        	m_numberOfHits++;
 
        	if (m_numberOfHits == m_hitsToKill) {
				if(m_havePowerUp) {
					//Debug.Log("Attempting to activate " + m_powerUp.name);
					m_powerUp.GetComponent<PowerUpController>().Activate();
				} 
            	Destroy(this.gameObject);
        	}
    	}
	}

	// Adding PowerUps 
	public void AddPowerUp(GameObject powerUp) {
		m_powerUp = powerUp; 
		m_havePowerUp = true;
	}
	
}
