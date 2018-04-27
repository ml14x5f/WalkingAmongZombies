using System.Collections;
using UnityEngine;

public class RandomPosition : MonoBehaviour {

	void Start () {
        StartCoroutine(RePositionWithDelay());
	}

    IEnumerator RePositionWithDelay()
    {
        while (true)
        {
            // change random position each 8 seconds
            SetRandomPosition();
            yield return new WaitForSeconds(8);
        }
    }

    void SetRandomPosition()
    {
        // Define area
        float x = Random.Range(-1.0f, 19.0f);
        float z = Random.Range(-13.0f, 7.0f);

        // print x and z, and keep two bits after a decimal point
        Debug.Log("X, Z: " + x.ToString("F2") + ", " + z.ToString("F2"));

        // we set y = 0 to make sure object is on the ground
        transform.position = new Vector3(x, 0.0f, z);
    }
}
