using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinkShipHelper : MonoBehaviour
{
    Animator m_animator;
    public Camera c;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }


    public void sink()
    {
        c.transform.parent = null;
        m_animator.enabled = true;
        m_animator.SetTrigger("sink");
        StartCoroutine(ExecuteAfterTime(10));


    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("PostDeath");
    }
}
