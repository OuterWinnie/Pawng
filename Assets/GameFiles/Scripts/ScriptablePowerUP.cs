using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/PowerUPs")]
public class ScriptablePowerUP : ScriptableObject
{
	public new string name;
	public Sprite icon;
	public bool hasSpeed;
	public bool hasDeflect;
	public bool hasPlayerSpeed;
    public bool hasBig;
}
