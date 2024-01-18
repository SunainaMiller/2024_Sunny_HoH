using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VideoIntroBehaviour : MonoBehaviour
{
    [SerializeField] VideoPlayer vidPlayer;
    public GameObject panel;
    public Animator panelAnimator;
    public int waitTime;
    //Animation panelAnim;

    void Start()
    {
        vidPlayer.loopPointReached += IntroFinished;
        panel.SetActive(false);
        StartCoroutine(WaitCoroutine());
        Cursor.visible = false;
    }
    void IntroFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        panel.SetActive(true);
        panelAnimator.Play("PanelFade");
    }
}
