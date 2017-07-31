using UnityEngine;

public class PlayerController : MonoBehaviour {

	
	private Rigidbody m_ballRB;

	public float m_speed; 
	private Vector3 m_playerPos;
	public GameObject m_ball;
	private bool m_haveBall; 


	/* 
		Standard Vaus 
		-------------
		LeftTip Pos; -0.5, 0, 0
		LeftEnd Pos: -0.6, 0, 0
		Center Scale: 0.5, 0.75, 0.5 
		RightEnd Pos: 0.6, 0, 0
		RightTip Pos 0.5, 0, 0

		Collider Height: 1.8
	

		Extended Vaus
		-------------
		LeftTip Pos; -0.75, 0, 0
		LeftEnd Pos: -0.85, 0, 0
		Center Scale 0.5, 1, 0.5
		RightEnd Pos: 0.85, 0, 0
		RightTip Pos 0.75, 0, 0
		

		Collider Height: 2.3 

	 */




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

	public void Grow() {
		/*  Extended Vaus
			-------------
			LeftTip Pos; -0.75, 0, 0
			LeftEnd Pos: -0.85, 0, 0
			Center Scale 0.5, 1, 0.5
			RightEnd Pos: 0.85, 0, 0
			RightTip Pos 0.75, 0, 0
			Collider Height: 2.3 
		*/ 

		bool growing = true; 
		while (growing) {
			


			growing = false;
		}


	}

	public void Shrink() {
		/*  Standard Vaus 
			-------------
			LeftTip Pos; -0.5, 0, 0
			LeftEnd Pos: -0.6, 0, 0
			Center Scale: 0.5, 0.75, 0.5 
			RightEnd Pos: 0.6, 0, 0
			RightTip Pos 0.5, 0, 0
			Collider Height: 1.8
		 */




	}

	public void AddSuperPower(SuperPower thePower){
		switch(thePower) {

		}
	}

	public void HaveBall() {
		m_haveBall = true;
	}

}
