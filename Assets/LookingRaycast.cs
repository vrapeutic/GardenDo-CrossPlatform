using UnityEngine;

public class LookingRaycast : MonoBehaviour
{
    public Color rayColor = Color.red; // Set the desired color in the Inspector
    public float maxDistance = 10f;
    public float timerIncrementInterval = 1f; // Increment timer every second
    private float timer = 0f;
    private bool hitFlag = false;
    private string distractorName;

    void Update()
    {
        // Cast a ray in the forward direction
        Ray ray = new Ray(transform.position, transform.forward);

        // Create a RaycastHit variable to store information about the hit
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Check if the ray hits a collider named "distractor"
            if (hit.collider.CompareTag("Distractor"))
            {
                Debug.Log("Ray hit distractor: " + hit.collider.name);

                // Increment the timer based on the specified interval
                distractorName = hit.collider.name;
                timer += Time.deltaTime;
                hitFlag = true;
                //if (timer >= timerIncrementInterval)
                //{
                //    Debug.Log("Timer incremented!");
                //    timer = 0f; // Reset the timer
                //}

                // You can perform additional actions here based on the hit information
                // For example, you might access the hit.point, hit.normal, etc.
            } else
            {
                distractorName = "";
                timer = 0;
                hitFlag = false;
            }
        }
        else if (hitFlag)
        {
            Debug.Log("Exited distractor: " + distractorName + ", Time: " + timer);
            //CSVWriter.Instance.WriteDistractorTime(distractorName: distractorName, distractionTime: timer.ToString());
            if (timer >= 0.1)
            CSVWriter.Instance.SaveDistractorTime(distractorName: distractorName, distractionTime: System.Math.Round((decimal)timer, 2).ToString());
            distractorName = "";
            timer = 0;
            hitFlag = false;
            // there you go. here we have object hitted on previous frame but not on this frame.
        }

        // Draw a line in the scene to visualize the ray
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, rayColor);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    // Check if the exiting collider is named "distractor"
    //    if (other.CompareTag("Distractor"))
    //    {
    //        timer = 0;
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    // Check if the exiting collider is named "distractor"
    //    if (other.CompareTag("Distractor"))
    //    {
    //        Debug.Log("Exited distractor: " + other.name + ", Time: " + timer);
    //        timer = 0;
    //    }
    //}
}

