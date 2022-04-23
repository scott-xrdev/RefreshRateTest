using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] DebugText debugText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRefreshRatesRoutine());
    }

    IEnumerator GetRefreshRatesRoutine()
    {
        while (gameObject.activeInHierarchy)
        {
            GetRefreshRates();

            yield return new WaitForSeconds(5f);
        }
    }

    private void GetRefreshRates()
    {
        Unity.XR.Oculus.Performance.TryGetAvailableDisplayRefreshRates(out float[] rates);

        if (rates.Length < 1)
        {
            debugText.LogText("Could not get available rates");
        }

        for (int i = 0; i < rates.Length; i++)
        {
            debugText.LogText("Rate " + (i + 1) + ": " + rates[i] + " fps");
        }

        Unity.XR.Oculus.Performance.TryGetDisplayRefreshRate(out float rate);

        debugText.LogText("Current Refresh Rate: " + rate + " fps\n-----------");

    }
}
