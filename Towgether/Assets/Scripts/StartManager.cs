using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartManager : MonoBehaviour
{

    bool started;
    [SerializeField] Image StartMenu;
    [SerializeField] Text StartText;
    [SerializeField] Image Facebook;
    [SerializeField] Image Instgram;
    [SerializeField] Image Reddit;
    [SerializeField] Image Settings;
    private void Awake()
    {
        started = false;
    }
    public void StartButton()
    {
        started = true;
        Debug.Log("Pressed");

    }
    void Update()
    {
        if (started)
        {
            Dissolve_Start_Menu();
        }   
        

    }
    void Dissolve_Start_Menu()
    {

        DissolveItem startmenu  = new DissolveItem (StartMenu, StartMenu.color, StartMenu.color.a);
        startmenu.Alphadecrease();

        DissolveItem facebook = new DissolveItem(Facebook, Facebook.color, Facebook.color.a);
        facebook.Alphadecrease();

        DissolveItem instgram = new DissolveItem(Instgram, Instgram.color, Instgram.color.a);
        instgram.Alphadecrease();

        DissolveItem reddit = new DissolveItem(Reddit, Reddit.color, Reddit.color.a);
        reddit.Alphadecrease();

        DissolveItem settings = new DissolveItem(Settings, Settings.color, Settings.color.a);
        settings.Alphadecrease();

        if (Settings.color.a <= 0)
        {
            SceneManager.LoadScene("base");
        }

    }


    public class DissolveItem
    {
        
        Image image;
        Vector4 dissolveitemVector;     
        float A_Dissolveitem;

      public  DissolveItem(Image image,Vector4 dissolveitemVector, float A_Dissolveitem)
        {
            this.A_Dissolveitem = A_Dissolveitem;
            this.dissolveitemVector = dissolveitemVector;
            this.image = image;  
        }

        public void Alphadecrease()
        {
            A_Dissolveitem = image.color.a;
            A_Dissolveitem -= Time.deltaTime;
            dissolveitemVector = new Vector4(image.color.r, image.color.g, image.color.b, A_Dissolveitem);
            image.color = dissolveitemVector;
        }

    }
    
}
