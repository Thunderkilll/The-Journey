using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIVisual : MonoBehaviour
{
    
    private Image healthBarImage;
    private HealthBarSystem healthBarSystem;
    
    // Start is called before the first frame update
    private void Awake()
    {
        healthBarImage = transform.Find("HealthBar").GetComponent<Image>();
    }
    void Start()
    {
        //setHealth(healthNormalized); //80%
        HealthBarSystem healthBarSystem = new HealthBarSystem();
     
        SetHealthBarSystem(healthBarSystem);
        
    }
   public void SetHealth(float healthNormalized)
    {
        healthBarImage.fillAmount = healthNormalized;
    }

    public void SetHealthBarSystem(HealthBarSystem healthBarSystem)
    {
        this.healthBarSystem = healthBarSystem;
        healthBarSystem.OnHealthChange += HealthBarSystem_OnHealthChanged;
    }
    private void HealthBarSystem_OnHealthChanged(object sender , System.EventArgs e)
    {
        //healthBarchanged 
        SetHealth(healthBarSystem.GetHealthNormalized());
    }
    public HealthBarUIVisual()
    {

    }
}
