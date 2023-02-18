using Player;
using UnityEngine;

namespace Descriptors
{
	[CreateAssetMenu(fileName = "UiControlButton", menuName = "Descriptors/UiControlButton", order = 0)]
	public class UiControlButtonDescriptor : ScriptableObject
	{
		public ControlButton Button;
		public Sprite UnpressedSprite;
		public Sprite PressedSprite;
	}
}
