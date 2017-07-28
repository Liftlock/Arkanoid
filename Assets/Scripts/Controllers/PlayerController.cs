using UnityEngine;

public class PlayerController : MonoBehaviour {

	
	private Rigidbody m_ballRB;

	public float m_speed; 
	
	private Vector3 m_playerPos;
	public GameObject m_ball;
	private bool m_haveBall; 

	

	// private enum State {}; 

	void Start() {
		m_ballRB = m_ball.GetComponent<Rigidbody>();
		m_haveBall = true;
		m_playerPos = GetComponent<Transform>().position;
	}

	void Update() {
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * m_speed)* Time.deltaTime;
        m_playerPos = new Vector3 (Mathf.Clamp (xPos, 1f, 13f), 0, -1.5f);
        transform.position = m_playerPos;

		if(Input.GetKey(KeyCode.Space) && m_haveBall) {
			m_ballRB.isKinematic = false;
			m_ball.transform.parent = null;
			Vector3 velocity = GetComponent<Rigidbody>().velocity; 
			m_ball.GetComponent<BallController>().Release();
			m_haveBall = false;
		}
	}


	public void HaveBall() {
		m_haveBall = true;
	}

}
