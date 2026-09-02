using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent
{
	// Token: 0x02006623 RID: 26147
	public class PinballItemGridUnavailableWeaponComponent : PinballItemGridComponentBase
	{
		// Token: 0x0604153E RID: 267582 RVA: 0x010C1651 File Offset: 0x010BF851
		[NullableContext(2)]
		protected override string OnGetResourceId()
		{
			return "UiItem_ItemBaseUnavailableWeapon";
		}

		// Token: 0x0604153F RID: 267583 RVA: 0x010C1658 File Offset: 0x010BF858
		[NullableContext(1)]
		protected override void OnRefresh(params object[] args)
		{
			bool active = (bool)args[0];
			this.SetActive(active);
		}
	}
}
