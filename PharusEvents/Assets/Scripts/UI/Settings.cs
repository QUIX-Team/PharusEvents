using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private static string JOSH = "josh";
    private static string SUZIE = "suzie";

    void Start()
    {
        if(!PlayerPrefs.HasKey("avatar"))
        {
            PlayerPrefs.SetString("avatar",JOSH);
        }
    }
    public void AvatarJosh()
    {
        PlayerPrefs.SetString("avatar",JOSH);
    }
    public void AvatarSuzie()
    {
        PlayerPrefs.SetString("avatar",SUZIE);
    }

    public void GariphicsLow()
    {
        QualitySettings.SetQualityLevel(1);
    }
     public void GariphicsMed()
    {
        QualitySettings.SetQualityLevel(2);
    }
     public void GariphicsHigh()
    {
        QualitySettings.SetQualityLevel(3);
    }
}
