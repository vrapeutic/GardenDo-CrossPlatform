using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketCoverContro : MonoBehaviour
{
    [SerializeField]
    Animator coverAnimator;
    void Start()
    {
        if (!coverAnimator) coverAnimator = this.GetComponent<Animator>();
    }

   public void OpenTheBucket()
    {
        coverAnimator.SetBool("OpenTheCover", true);
    }
    public void CloseTheBucketCover()
    {
        coverAnimator.SetBool("CloseTheCover", true);
    }
}
