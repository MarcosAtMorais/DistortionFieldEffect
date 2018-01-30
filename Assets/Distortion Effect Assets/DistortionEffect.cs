using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortionEffect : MonoBehaviour {

    [SerializeField] float m_fadeDuration = 0.01f;
    [SerializeField] float m_scalingFactor = 0.01f;
    [SerializeField] float m_alphaStart = 1.0f;
    [SerializeField] float m_alphaEnd = 0.0f;
    public bool m_useMaterialAlpha = false;

    private float alphaDiff;
    private float startTime;
    private bool isFading = false;
    private Renderer rend;
    private Color fadeColor;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();

        fadeColor = rend.material.color;

        if (!m_useMaterialAlpha)
        {
            fadeColor.a = m_alphaStart;
        }
        else
        {
            m_alphaStart = fadeColor.a;
        }

        rend.material.color = fadeColor;
        alphaDiff = m_alphaStart - m_alphaEnd;

	}
	
	// Update is called once per frame
	void Update () {

        transform.localScale += new Vector3(m_scalingFactor, m_scalingFactor, transform.localScale.z);
        fadeAlpha();

	}

    private void fadeAlphaUsing(float alphaFactor) {
        
    }

    private void fadeAlpha() {
        if (isFading)
        {
            var elapsedTime = Time.time - startTime;

            if (elapsedTime <= m_fadeDuration)
            {
                var fadeProgress = elapsedTime / m_fadeDuration;
                var alphaChange = fadeProgress * alphaDiff;
                fadeColor.a = m_alphaStart - alphaChange;
                rend.material.color = fadeColor;
            }
            else
            {
                fadeColor.a = m_alphaEnd;
                rend.material.color = fadeColor;
                isFading = false;
                Destroy(gameObject);
            }
        }
    }

}
