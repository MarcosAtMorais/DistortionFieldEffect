using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortionEffect : MonoBehaviour {

    [SerializeField] float m_scalingFactor = 0.001f;
    [SerializeField] float m_maxLocalScale = 0.01f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(m_scalingFactor, m_scalingFactor, 0.0f);

        if (transform.localScale.x > m_maxLocalScale) {
            transform.localScale = new Vector3(
                m_scalingFactor, m_scalingFactor, transform.localScale.z);
        }
	}

}
