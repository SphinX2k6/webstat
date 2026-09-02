using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink
{
	// Token: 0x02006704 RID: 26372
	public class MotorDecalLinkRewardViewDotItem : GridProxyAbstract<bool>
	{
		// Token: 0x06041CFD RID: 269565 RVA: 0x010E2D3A File Offset: 0x010E0F3A
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem))
			};
		}

		// Token: 0x06041CFE RID: 269566 RVA: 0x010E2D5D File Offset: 0x010E0F5D
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
