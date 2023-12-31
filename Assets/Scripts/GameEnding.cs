using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public GameObject player;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    float m_Timer;
    bool m_HasAudioPlayed; //오디오가 한 번만 플레이 되도록.
    public float displayImageDuration = 1f;
    public float fadeDuration =1f;

    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player){
            m_IsPlayerAtExit=true;
        }

    }

    public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if(m_IsPlayerAtExit){
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }else if(m_IsPlayerCaught)
        {
        EndLevel (caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
            
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene (0);
            }
            else
            {
                Application.Quit ();
            }
        }
    }
}
