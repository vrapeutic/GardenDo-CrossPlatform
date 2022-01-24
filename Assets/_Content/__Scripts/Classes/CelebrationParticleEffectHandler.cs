using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationParticleEffectHandler : MonoBehaviour
{
    [SerializeField]
    GameObject[] flowerCelebrationParticleEffect;
    [SerializeField]
    GameObject endGameCelebration;

    Statistics stats;
    int particleIndex = 0;
    private void Start()
    {
        stats = Statistics.instane;
    }
    public void OnFLowerFinished()
    {
        if (particleIndex < (stats.numberOfFlowers))
        {
            Debug.Log("flower finished");
            flowerCelebrationParticleEffect[particleIndex].SetActive(true);
            particleIndex++;
        }

    }
    public void OnGameFinished()
    {
        endGameCelebration.SetActive(true);
        Debug.Log("game finished");
    }
}
