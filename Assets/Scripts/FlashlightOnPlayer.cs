using UnityEngine;
using System.Collections;

public class FlashlightOnPlayer : MonoBehaviour {
    public Light flashlight;
    public float power = 100.0f;
    private float maxPower = 100.0f;
    private float minPower = 0.0f;
    private float batteryCharge = 100.0f;
    public int batteryCount = 3;
    public float powerDrain = 1.0f;
    private bool usable = true;
    void Start() {

    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && usable) {
            flashlight.enabled = !flashlight.enabled;
        }
        if (flashlight.enabled) {
            power -= Time.deltaTime * powerDrain;
        }
        if (power > maxPower) {
            power = maxPower;
        }
        if (power < minPower) {
            power = minPower;
            flashlight.enabled = false;
            usable = false;
        }
        if (power > minPower) {
            usable = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && batteryCount > 0) {
            power += batteryCharge;
            batteryCount -= 1;
        }
    }
}