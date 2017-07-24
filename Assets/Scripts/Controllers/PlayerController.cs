using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody m_RB; 
	private Rigidbody m_ballRB;

	public float m_speed; 
	private float m_vX; 
	private bool m_move; 

	private bool m_haveBall; 

	public GameObject m_ball;

	// private enum State {}; 

	void Start() {
		m_RB = GetComponent<Rigidbody>();
		m_ballRB = m_ball.GetComponent<Rigidbody>();
		m_move = false;
		m_haveBall = true;
	}

	void Update() {
		if((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow))) {
			m_vX = -m_speed;
			m_move = true;
		} else if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow))) {
			m_vX = m_speed;
			m_move = true;
		}

		if(Input.GetKey(KeyCode.Space) && m_haveBall) {
			Vector3 velocity = GetComponent<Rigidbody>().velocity; 
			m_ball.GetComponent<BallController>().Release();
			m_haveBall = false;
		}
	}


	void FixedUpdate() {		
		if(m_move) {
			m_RB.MovePosition(m_RB.position + new Vector3(m_vX, 0 , 0) * Time.deltaTime);
			if(m_haveBall) {
				m_ballRB.MovePosition(m_ballRB.position + new Vector3(m_vX, 0, 0) * Time.deltaTime);
			}
			m_move = false;
		}
		
	}

	public void HaveBall() {
		m_haveBall = true;
	}

}
