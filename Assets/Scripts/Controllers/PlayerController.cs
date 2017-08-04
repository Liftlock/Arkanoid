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
		
		/*
			Powerups

			Laser: 
				Collect the red capsule to transform the Vaus into its Laser-firing configuration. 
				In this form, you can fire lasers at the top of the screen by pushing the fire button. 
				Lasers can be used against every brick except Gold bricks, and against enemies. 
				Silver bricks can only be destroyed by lasers when they are hit the required number of times.

			Expand: 
				Collect the blue capsule to extend the width of the Vaus.

			Catch: 
				Collect the green capsule to gain the catch ability. When the ball hits the Vaus, it will stick to the surface. 
				Press the Fire button to release the ball. The ball will automatically release after a certain period of time has passed.

			Slow: 
				Collect the orange capsule to slow the velocity at which the ball moves. 
				Collecting multiple orange capsules will have a cumulative effect and the ball velocity can become extremely slow. 
				However, the ball velocity will gradually increase as it bounces and destroys bricks. 
				The velocity may sometimes suddenly increase with little warning.

			Break: 
				Collect the violet capsule to create a "break out" exit on the right side of the stage. 
				Passing through this exit will cause you to advance to the next stage immediately, as well as earn a 10,000 point bonus.

			Disruption:
				Collect the cyan capsule to cause the ball to split into three instances of itself. 
				All three balls can be kept aloft. There is no penalty for losing the first two balls. 
				No colored capsules will fall as long as there is more than one ball in play. 
				This is the only power up that, while in effect, prevents other power ups from falling.

			Life: 
				Collect the gray capsule to earn an extra Vaus.
		 */




		switch(thePower) {
			case SuperPower.DISRUPT: 
				GameObject dBall; 
				Debug.Log("Disruption");
				Vector3 ballPos = m_ball.transform.position;
				

				//m_ballIsActive = false;
			//m_ballPosition.x = m_playerObject.transform.position.x;
			//m_ballPosition.z = -0.95f;

				dBall = Instantiate(m_ball, ballPos, Quaternion.identity);
				//dBall.GetComponent<BallController>().MakeActive();

				dBall = Instantiate(m_ball, ballPos, Quaternion.identity);
				//dBall.GetComponent<BallController>().MakeActive();
				
				break;
		}
	}

	public void HaveBall() {
		m_haveBall = true;
	}

}
