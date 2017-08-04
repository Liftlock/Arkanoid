using UnityEngine;


public enum SuperPower { BREAK, CATCH, DISRUPT, ENLARGE, LASER, LIFE, SLOW }; 

/*
	Magenta Capsule with letter "B" - Break:
	Green Capsule   with Letter "C" - Catch:
	Cyan Capsule    with Letter "D" - Disruption: 
	Blue Capsule    with Letter "E" - Enlarge: 
	Red Capsule     with Letter "L" - Laser:
	Grey Capsule 	with letter "P" - Extra life (Vaus)
	Orange Capsule  with letter "S" - Slow:
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

		// Destroy PowerUp on Ball Collision 
		// if(other.tag == "Ball" && m_active) {
		// 	// oh crackers ... we destroyed a perfectly good powerup 
		// 	Destroy(this.gameObject);
		// }
	}


	public void Activate(){
		m_active = true;
	} 

	public void SetSuperPower(Texture pickupType) {

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
