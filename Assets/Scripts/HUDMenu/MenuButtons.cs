using UnityEngine;


// Referenced by GUI Buttons
// This script expects to be attached to the same root level game object as the GameManager script.
public class MenuButtons : MonoBehaviour {

    private GameManager m_gm; 

    void Start() {
        m_gm = GetComponent<GameManager>(); 
    }

    public void CreditsClicked() {
         m_gm.ChangeState(GameCredits.Instance); 
    }

    public void MenuClicked() {
         m_gm.ChangeState(GameMenu.Instance); 
    }

    public void QuitClicked() {
         m_gm.ChangeState(GameOver.Instance);   
    }

    public void PauseClicked() {
         m_gm.ChangeState(GamePause.Instance); 
    }

    public void PlayClicked() {
        m_gm.ChangeState(GamePlay.Instance); 
    }

    public void SettingsClicked() {
         m_gm.ChangeState(GameSettings.Instance); 
    }

    public void CloseClicked() {
        m_gm.RevertToPreviousState();
    }

}