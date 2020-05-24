// ScriptablePowerUP
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/PowerUPs")]
public class ScriptablePowerUP : ScriptableObject
{
	public new string name;

	public Sprite icon;

	public bool hasSpeed;

	public bool hasDeflect;

	public bool hasTeleport;
    public bool hasBig;
}
