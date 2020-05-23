// PowerUPDisplayUI
using UnityEngine;
using UnityEngine.UI;

public class PowerUPDisplayUI : MonoBehaviour
{
	public void ActivatePowerUP(Sprite icon)
	{
		GetComponent<Image>().enabled = true;
		GetComponent<Image>().sprite = icon;
	}

	public void DeactivatedPowerUP()
	{
		GetComponent<Image>().enabled = false;
	}
}
