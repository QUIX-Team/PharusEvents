using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueManager : MonoBehaviour
{

    public static MenueManager Instance;

    [SerializeField] Menue[] menues;

    void Awake() 
    {
        Instance = this;
    }

    public void OpenMenue(string MenueName)
    {
        for(int i =0; i< menues.Length;i++)
        {
            if(menues[i].MenueName == MenueName)
            {
                OpenMenue(menues[i]);
            }
            else if(menues[i].open)
            {
                CloseMenue(menues[i]);
            }
        }
    }

    public void OpenMenue(Menue menue)
    {

        for(int i =0; i< menues.Length;i++)
        {
            if(menues[i].open)
            {
                CloseMenue(menues[i]);
            }
        }

        menue.Open();
    }

    public void CloseMenue(Menue menue)
    {
        menue.Close();
    }
}
