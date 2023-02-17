﻿using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Descriptors
{
	[CreateAssetMenu(fileName = "UiControlButtonDescriptorCollection", menuName = "Descriptors/Collections/UiControlButton", order = 0)]
	public class UiControlButtonDescriptorCollection : ScriptableObject
	{
		public List<UiControlButtonDescriptor> Descriptors;
		
		public UiControlButtonDescriptor RequireDescriptor(ControlButton button)
		{
			return Descriptors.Find(descriptor => descriptor.Button == button);
		}
	}
}
