using UnityEngine;
using UnityEngine.UI;

public class PowerUPDisplayUI : MonoBehaviour
{

    public GameObject parent;

	public void ActivatePowerUP(ScriptablePowerUP powerUP)
	{
        //Activa la UI del PowerUP.
		GetComponent<Image>().enabled = true;
		GetComponent<Image>().sprite = powerUP.icon;
	}

    public void ActivateUIChangeColor()
    {
        parent.GetComponent<Image>().color = new Color (0.823f, 0.270f, 0.274f);
    }

	public void DeactivatedPowerUP()
	{
        //Desactiva la UI del PowerUP.
		GetComponent<Image>().enabled = false;
        parent.GetComponent<Image>().color = new Color (0.513f, 0.709f, 0.509f);
	}
}
