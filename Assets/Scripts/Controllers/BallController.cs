using UnityEngine;

public class BallController : MonoBehaviour {

	private bool m_ballIsActive;
    private Vector3 m_ballPosition;
    private Vector3 m_ballInitialForce;

	public GameObject m_playerObject; 
	private Rigidbody m_RB; 


	void Start () {
		m_RB = GetComponent<Rigidbody>();
        m_ballInitialForce = new Vector3(100.0f, 0, 600.0f);
        m_ballIsActive = false;
        m_ballPosition = transform.position;
    }

	void Update() {
		if (!m_ballIsActive && m_playerObject != null){
            m_ballPosition.x = m_playerObject.transform.position.x;
            transform.position = m_ballPosition;
        }

		if (m_ballIsActive && transform.position.z < -6) {
			m_ballIsActive = false;
			m_ballPosition.x = m_playerObject.transform.position.x;
			m_ballPosition.z = -0.95f;
			transform.position = m_ballPosition;
				
			m_RB.isKinematic = true;
			m_playerObject.GetComponent<PlayerController>().HaveBall();
			// m_playerObject.SendMessage("TakeLife");
		}
	}

	public void Release() {
		if (!m_ballIsActive) {
			m_RB.isKinematic = false;
			m_RB.AddForce(m_ballInitialForce);
          	m_ballIsActive = !m_ballIsActive;
        }	
	}

	public void Stick() {
		if(m_ballIsActive) {
			m_ballIsActive = false;
			m_RB.velocity = Vector3.zero;
			m_ballPosition = m_playerObject.transform.position;
			m_ballPosition.z = 0.8f;
			m_RB.transform.position = m_ballPosition;
		}
	}

}


