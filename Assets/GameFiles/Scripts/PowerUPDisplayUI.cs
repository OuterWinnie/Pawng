using UnityEngine;
using UnityEngine.UI;

public class PowerUPDisplayUI : MonoBehaviour
{
	public void ActivatePowerUP(Sprite icon)
	{
        //Activa la UI del PowerUP.
		GetComponent<Image>().enabled = true;
		GetComponent<Image>().sprite = icon;
	}

	public void DeactivatedPowerUP()
	{
        //Desactiva la UI del PowerUP.
		GetComponent<Image>().enabled = false;
	}
}
