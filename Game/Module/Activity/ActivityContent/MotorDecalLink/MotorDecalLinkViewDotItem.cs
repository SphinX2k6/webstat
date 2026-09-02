using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink
{
	// Token: 0x02006708 RID: 26376
	public class MotorDecalLinkViewDotItem : GridProxyAbstract<bool>
	{
		// Token: 0x06041D10 RID: 269584 RVA: 0x010E3345 File Offset: 0x010E1545
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem))
			};
		}

		// Token: 0x06041D11 RID: 269585 RVA: 0x010E3368 File Offset: 0x010E1568
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(data);
		}
	}
}
