using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    private PlayerController playerController;
    public  Slider SliderLifePlayer;

    // Start is called before the first frame update
    void Start()
    {
        this.playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        this.SliderLifePlayer.maxValue = playerController.life;
        this.updateLifeBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLifeBar(){
        this.SliderLifePlayer.value = this.playerController.life;       
    }
}
