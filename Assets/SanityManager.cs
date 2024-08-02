// SanityManager.cs
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Events;

public class SanityManager : MonoBehaviour
{
    Slider sanitySlider;
    public PostProcessProfile profile;
    Vignette vignette;
    public int SecondTime;
    float percent;
    public UnityEvent onInsane;
    public GameObject characterPlayer;

    void Start()
    {
        profile.TryGetSettings(out vignette);
        sanitySlider = GetComponent<Slider>();
        sanitySlider.maxValue = SecondTime;
        sanitySlider.value = SecondTime;
        vignette.intensity.value = 0;
        StartCoroutine(LoseSanity());
    }

    // แก้ coroutine เพื่อให้รับพารามิเตอร์สำหรับการลด sanity
    IEnumerator LoseSanity()
    {
        while (sanitySlider.value > 0)
        {
            sanitySlider.value -= 1f * Time.deltaTime;
            float newValue = (sanitySlider.value - sanitySlider.maxValue) * -1;
            percent = newValue / sanitySlider.maxValue;
            vignette.intensity.value = percent;
            yield return null;
        }
        // ค่า 10000 หน่วย = 1 นาที 20 วินาที
        // เรียกฟังก์ชันเพื่อหยุดเกม
        FreezeGame();
    }

    // เมธอดในการลด sanity ตามจำนวนที่กำหนด
    public void ReduceSanity(int amount)
    {
        sanitySlider.value -= amount;
    }

void FreezeGame()
{
    if (characterPlayer != null)
    {
        characterPlayer.SetActive(false);
    }

    // Invoke the event for going back to the main menu or handling other actions
    onInsane.Invoke();
}
}