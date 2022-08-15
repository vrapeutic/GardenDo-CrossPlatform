using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBucketPosition : MonoBehaviour
{
    [SerializeField] Transform NPC_Hands;
    [SerializeField] GameObject Bucket;
    [SerializeField] Transform targetObjectTransform;
    [SerializeField] Transform positionInCompleteCourse;
    [SerializeField] Transform positionInWateringCourse;

    Statistics stats;
    private void Start()
    {
        stats = Statistics.instane;
        if (stats.isCompleteCourse)
        {
            this.transform.position = positionInCompleteCourse.position;
        }
        else
        {
            this.transform.position = positionInWateringCourse.position;
        }
        Bucket.GetComponent<TargetTransform>().CaptureTransform(targetObjectTransform);
    }
    public void SetBucketPositionToNPCHands()
    {

        Debug.Log("NPC is grabbing the bucket");
        Bucket.transform.SetParent(NPC_Hands.transform.parent, true);
        Bucket.GetComponent<TargetTransform>().SetTransform();


        Bucket.GetComponent<BoxCollider>().enabled = true;
        Bucket.transform.SetParent(null);
    }


}
