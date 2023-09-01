using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchPad : MonoBehaviour
{
    [SerializeField] Button fireButton;
    [SerializeField] Slider powerSlider;

    private void OnCollisionEnter(Collision collision)
    {
        fireButton.gameObject.SetActive(true);
        powerSlider.gameObject.SetActive(true);
    }
}
