using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject m_player; 

	public int m_numberOfLives; 

	public Text m_scoreText; 

	public int m_score; 


	void Start() {
		m_numberOfLives = 3;
	}


	void Update() {

		m_scoreText.text = m_score.ToString();
	}


	




}
