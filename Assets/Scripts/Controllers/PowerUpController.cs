using UnityEngine;


public enum SuperPower { BREAK, CATCH, DISRUPT, ENLARGE, LASER, LIFE, SLOW }; 

/*
	Red Capsule     with Letter "L" - Laser: FF0000
	Blue Capsule    with Letter "E" - Enlarge: 
	Cyan Capsule    with Letter "D" - Disruption: 
	Green Capsule   with Letter "C" - Catch: 05FF00
	Orange Capsule  with letter "S" - Slow:
	Magenta Capsule with letter "B" - Break:
	Grey Capsule 	with letter "P" - Extra life (Vaus)
 */

public class PowerUpController : MonoBehaviour {

	public bool m_active = false; 
	private float m_speed = -1.0f;
	private float m_rotateSpeed = -300f;
	private SuperPower m_powerUpType;

	void Update () {
		
		
		if(m_active) {
			 transform.Rotate(0, m_rotateSpeed * Time.deltaTime, 0);
			transform.position += new Vector3(0, 0, m_speed * Time.deltaTime); 

		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			// pickup aquired .. .send the details to the player
			other.gameObject.GetComponent<PlayerController>().AddSuperPower(m_powerUpType);
			Destroy(this.gameObject);
		}

		// if(other.tag == "Ball" && m_active) {
		// 	// oh crackers ... we destroyed a perfectly good powerup 
		// 	Destroy(this.gameObject);
		// }
	}


	public void Activate(){
		m_active = true;
	} 

	public void SetSuperPower(Texture pickupType) {

		Debug.Log("Texture " + pickupType.name + " found");

		switch(pickupType.name) {
			case "Break":
				m_powerUpType = SuperPower.BREAK;
				break;
			case "Catch":
				m_powerUpType = SuperPower.CATCH;
				break;
			case "Disrupt":
				m_powerUpType = SuperPower.DISRUPT;
				break;
			case "Enlarge":
				m_powerUpType = SuperPower.ENLARGE;
				break;
			case "Laser": 
				m_powerUpType = SuperPower.LASER;
				break;
			case "Life":
				m_powerUpType = SuperPower.LIFE;
				break;
			case "Slow": 
				m_powerUpType = SuperPower.SLOW;
				break;
		}
		// set the texture 
		GetComponent<Renderer>().material.mainTexture = pickupType;
	}
	



}
