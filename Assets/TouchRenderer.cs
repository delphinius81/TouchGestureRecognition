using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class will record and draw a line in 3D space based on the position of the touch controller
// Left and Right touch controllers are tracked separately


public class TouchRenderer : MonoBehaviour {

    public LineRenderer m_RightLineRenderer;
    public LineRenderer m_LeftLineRenderer;

    // Use this for initialization
    void Start() {
		
    }

    void Update() {
        // if the right grip button is down, draw a line
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch)) {
            Vector3 rightTouchPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            // This position is in tracker space, so it needs to get converted into world space before we plop it into
            // the line renderer
        }

        // if the left grip button is down, draw a line
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch)) {
            Vector3 leftTouchPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        }
    }
}
