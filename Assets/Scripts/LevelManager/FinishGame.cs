using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    [SerializeField] GameObject chestClosed;
    [SerializeField] GameObject chestOpen;
    [SerializeField] List<ParticleSystem> winEffect = new List<ParticleSystem> ();

    private void Start()
    {
        OnInit();
    }
    private void OnInit()
    {
        chestClosed.SetActive(true);
        chestOpen.SetActive(false);
        StopEffect();
    }
    private void PlayEffect()
    {
        foreach (ParticleSystem p in winEffect)
        {
            p.Play();
        }
    }
    private void StopEffect()
    {
        foreach (ParticleSystem p in winEffect)
        {
            p.Stop();
        }
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerBrick.instance.ClearStack();
            LevelManager.instance.Finish();
            WinUI.instance.ActiveWinPanel();
            PlayEffect();
            chestClosed.SetActive(false);
            chestOpen.SetActive(true);
        }
    }
}
