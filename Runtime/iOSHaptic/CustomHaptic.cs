using UnityEngine;

public class CustomHaptic : GT_Singleton<CustomHaptic>
{
    public GameObject offLine;
    public UnityEngine.UI.Toggle hapticToggle;

    // ReSharper disable once InconsistentNaming
    private static bool isHaptic = true;

    public override void Awake()
    {
        base.Awake();
        Read_Haptic_Data();
        Set_UI_Items();
    }

    public void HapticButton_Click()
    {
        if (hapticToggle != null)
            isHaptic = !hapticToggle.isOn;
        Write_Haptic_Data();
        if (offLine != null)
            offLine.SetActive(!isHaptic);
    }

    public static void Trigger_Success()
    {
        if (!isHaptic)
            return;
#if UNITY_IOS
		HapticManager.TriggerNotificationSuccess ();
#endif
    }

    public void Trigger_SelectionChange()
    {
        if (!isHaptic)
            return;
#if UNITY_IOS
		HapticManager.TriggerSelectionChange ();
#endif
    }

    public static void Trigger_Error()
    {
        if (!isHaptic)
            return;
#if UNITY_IOS
		HapticManager.TriggerNotificationError ();
#endif
    }

    public static void Trigger_Light()
    {
        if (!isHaptic)
            return;
#if UNITY_IOS
		HapticManager.TriggerImpactLight ();
#endif
    }

    public static void Trigger_Medium()
    {
        if (!isHaptic)
            return;
#if UNITY_IOS
		HapticManager.TriggerImpactMedium ();
#endif
    }

    public static void Trigger_Heavy()
    {
        if (!isHaptic)
            return;
#if UNITY_IOS
		HapticManager.TriggerImpactHeavy ();
#endif
    }

    private void Set_UI_Items()
    {
        if (hapticToggle != null)
            hapticToggle.isOn = !isHaptic;

        HapticButton_Click();
    }

    private static void Read_Haptic_Data()
    {
        isHaptic = ((PlayerPrefs.GetInt("isHaptic", 1)) == 1) ? true : false;
    }

    private static void Write_Haptic_Data()
    {
        PlayerPrefs.SetInt("isHaptic", isHaptic ? 1 : 0);
    }
}