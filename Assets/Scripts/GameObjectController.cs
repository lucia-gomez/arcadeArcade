using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isFollowing = false;
    private Transform clawTransform;
    private bool grabbed = false;
    private GameObject success;
    public TextController textController;
    public float yOffsetGround = 0f;

    void Start() {
        success = transform.Find("success")?.gameObject;
        success.SetActive(false);
        GameObject textObj = GameObject.Find("restoredText");
        textController = textObj.GetComponent<TextController>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Claw") && !grabbed) {
            Debug.Log("claw grabbed");
            grabbed = true;
            isFollowing = true;
            clawTransform = other.gameObject.transform;
            Invoke("StopFollowing", 8f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing) {
            Vector3 clawPos = clawTransform.position;
            Vector3 currentPos = transform.position;
            currentPos.y = clawPos.y;
            transform.position = currentPos;
        }
    }

    void StopFollowing() {
        isFollowing = false;
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z = 0f;
        rot.y = 180f;
        rot.x = 0f;
        transform.rotation = Quaternion.Euler(rot);

        Vector3 newPosition = transform.position;
        newPosition.y = yOffsetGround;
        transform.position = newPosition;

        success.SetActive(true);
        textController.score++;
        if(textController.score >= 3) {
            textController.ActivateSelf();
        }
    }
}
