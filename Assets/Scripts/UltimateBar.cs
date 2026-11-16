using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;

public class UltimateBar : MonoBehaviour
{
    [Header("UltimateCharge")]
    public int currentCharge = 0;
    public int maxCharge = 100;
    public bool isUltimateReady;

    [Header("XP UI")]
    public Slider chargeSlider;
    public bool useChargeSlider = true;

    [Header("Percentage UI")]
    public TextMeshProUGUI chargeText;
    public bool useChargeText = true;


    private void Start()
    {
        SetupChargeSlider();
        UpdateChargeUI();
        

    }

    public void AddCharge(int amount)
    {
        currentCharge += amount;
        if(currentCharge>=maxCharge)
        {
            currentCharge = maxCharge;
            isUltimateReady = true;
        }
    }

    public void UltimateUsed()
    {

    }

    private void SetupChargeSlider()
    {
        if (!useChargeSlider)
        {
            return;
        }

        if (chargeSlider == null) 
        {
            Debug.LogWarning("UltimateBar: No chargeSlider assinged in the Inspector");
            return;
        }

        chargeSlider.minValue = 0;

        chargeSlider.maxValue = maxCharge;

        chargeSlider.value = currentCharge;
    }

    private void UpdateChargeUI()
    {
        if (!useChargeSlider)
        {
            return;
        }

        if (chargeSlider == null) 
        {
            return;
        }

        chargeSlider.value = currentCharge;
    }





}