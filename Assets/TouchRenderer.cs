using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class will record and draw a line in 3D space based on the position of the touch controller
// Left and Right touch controllers are tracked separately


public class TouchRenderer : MonoBehaviour {

	public GameObject m_LeftHand;
	public GameObject m_RightHand;

    public LineRenderer m_RightLineRenderer;
    public LineRenderer m_LeftLineRenderer;

	public int m_UpdateEveryNFrames = 5;
	private int m_FrameNumber = 0;

    // Use this for initialization
    void Start() {
		
    }

    void Update() {
		m_FrameNumber = m_FrameNumber % m_UpdateEveryNFrames;

		if (OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.1f) {
			m_RightLineRenderer.numPositions = 0;
		}

		if (m_FrameNumber == 0 && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0.1f) {
			Vector3 rightTouchPosition = m_RightHand.transform.position;
			Vector3[] positions = new Vector3[m_RightLineRenderer.numPositions];
			m_RightLineRenderer.GetPositions(positions);
			int numPositions = positions.Length;
			Vector3[] newPostions = new Vector3[numPositions + 1];
			positions.CopyTo (newPostions, 0);
			newPostions [numPositions] = rightTouchPosition;
			m_RightLineRenderer.numPositions = numPositions + 1;
			m_RightLineRenderer.SetPositions (newPostions);
        }

		if (OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > 0.1f) {
			m_LeftLineRenderer.numPositions = 0;
		}

        // if the left grip button is down, draw a line
		if (m_FrameNumber == 0 && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0.1f) {
			Vector3 leftTouchPosition = m_LeftHand.transform.position;
			Vector3[] positions = new Vector3[m_LeftLineRenderer.numPositions];
			m_LeftLineRenderer.GetPositions(positions);
			int numPositions = positions.Length;
			Vector3[] newPostions = new Vector3[numPositions + 1];
			positions.CopyTo (newPostions, 0);
			newPostions [numPositions] = leftTouchPosition;
			m_LeftLineRenderer.numPositions = numPositions + 1;
			m_LeftLineRenderer.SetPositions (newPostions);
        }

		m_FrameNumber++;
    }
}
