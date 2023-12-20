using UnityEngine;

public class LookingRaycast : MonoBehaviour
{
    public Color defaultRayColor = Color.green; // Set the default color in the Inspector
    public Color hitRayColor = Color.red; // Set the hit color in the Inspector
    public float maxDistance = 10f;
    public float timerIncrementInterval = 1f; // Increment timer every second
    private float timer = 0f;
    private bool hitFlag = false;
    private string distractorName;

    private LineRenderer lineRenderer;

    //void Start()
    //{
        // Create a Line Renderer component and configure it
        //lineRenderer = gameObject.AddComponent<LineRenderer>();
        //lineRenderer.material = new Material(Shader.Find("Standard")); // Default material
        //lineRenderer.material.color = defaultRayColor;
        //lineRenderer.startWidth = 0.05f;
        //lineRenderer.endWidth = 0.05f;
        //lineRenderer.positionCount = 2;
    //}

    //void Update()
    //{
        //// Cast a ray in the forward direction
        //Ray ray = new Ray(transform.position, transform.forward);

        //// Create a RaycastHit variable to store information about the hit
        //RaycastHit hit;

        //// Set the starting position of the Line Renderer
        //lineRenderer.SetPosition(0, transform.position);

        //// Perform the raycast
        //if (Physics.Raycast(ray, out hit, maxDistance))
        //{
        //    // Set the end position of the Line Renderer to the hit point
        //    lineRenderer.SetPosition(1, hit.point);

        //    // Check if the ray hits a collider named "distractor"
        //    if (hit.collider.CompareTag("Distractor") || hit.collider.CompareTag("Bird"))
        //    {
        //        Debug.Log("Ray hit distractor: " + hit.collider.name);

        //        // Increment the timer based on the specified interval
        //        distractorName = hit.collider.name;
        //        timer += Time.deltaTime;
        //        hitFlag = true;

        //        // Change the color to hitRayColor
        //        lineRenderer.material.color = hitRayColor;

        //        // You can perform additional actions here based on the hit information
        //        // For example, you might access the hit.point, hit.normal, etc.
        //    }
        //    else
        //    {
        //        distractorName = "";
        //        timer = 0;
        //        hitFlag = false;

        //        // Change the color back to defaultRayColor
        //        lineRenderer.material.color = defaultRayColor;
        //    }
        //}
        //else if (hitFlag)
        //{
        //    Debug.Log("Exited distractor: " + distractorName + ", Time: " + timer);
        //    //if (timer >= 0.1)
        //    CSVWriter.Instance.WriteDistractorTime(distractorName: distractorName, distractionTime: System.Math.Round((decimal)timer, 2).ToString());
        //    CSVWriter.Instance.SaveDistractorTime(distractorName: distractorName, distractionTime: System.Math.Round((decimal)timer, 2).ToString());
        //    distractorName = "";
        //    timer = 0;
        //    hitFlag = false;

        //    // Change the color back to defaultRayColor
        //    lineRenderer.material.color = defaultRayColor;
        //}

        //// If the ray doesn't hit anything, set the end position of the Line Renderer to the end of the ray
        //if (!hitFlag)
        //    lineRenderer.SetPosition(1, ray.origin + ray.direction * maxDistance);
    //}

    void OnTriggerEnter(Collider other)
    {
        // Check if the entered collider has the "Distractor" or "Bird" tag
        if (other.CompareTag("Distractor") || other.CompareTag("Bird"))
        {
            Debug.Log("Entered distractor: " + other.name);

            // Set the end position of the Line Renderer to the position of the trigger collider
            //lineRenderer.SetPosition(1, other.transform.position);

            // Increment the timer based on the specified interval
            distractorName = other.name;
            //timer += Time.deltaTime;
            hitFlag = true;

            // Change the color to hitRayColor
            //lineRenderer.material.color = hitRayColor;

            // You can perform additional actions here based on the trigger enter information
            // For example, you might access other.transform.position, etc.
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Check if the collider in the trigger zone has the "Distractor" or "Bird" tag
        if (hitFlag && (other.CompareTag("Distractor") || other.CompareTag("Bird")))
        {
            // Increment the timer based on the specified interval during OnTriggerStay
            timer += Time.deltaTime;

            // You can perform other actions here for the duration that the GameObject stays within the trigger zone
            // For example, you might continue to update the timer or perform other actions as needed.
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the exited collider has the "Distractor" or "Bird" tag
        if (other.CompareTag("Distractor") || other.CompareTag("Bird"))
        {
            Debug.Log("Exited distractor: " + distractorName + ", Time: " + timer);

            // Save distractor time to CSV
            if (timer >= 0.1)
                CSVWriter.Instance.SaveDistractorTime(distractorName: distractorName, distractionTime: System.Math.Round((decimal)timer, 2).ToString());
            //CSVWriter.Instance.WriteDistractorTime(distractorName: distractorName, distractionTime: System.Math.Round((decimal)timer, 2).ToString());

            distractorName = "";
            timer = 0;
            hitFlag = false;

            //// Change the color back to defaultRayColor
            //lineRenderer.material.color = defaultRayColor;

            //// Set the end position of the Line Renderer to the current transform position
            //lineRenderer.SetPosition(1, transform.position);
        }
    }


}
