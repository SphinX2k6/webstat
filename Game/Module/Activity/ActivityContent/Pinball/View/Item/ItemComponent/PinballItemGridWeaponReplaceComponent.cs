using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent
{
	// Token: 0x02006624 RID: 26148
	public class PinballItemGridWeaponReplaceComponent : PinballItemGridComponentBase
	{
		// Token: 0x06041541 RID: 267585 RVA: 0x010C167D File Offset: 0x010BF87D
		[NullableContext(2)]
		protected override string OnGetResourceId()
		{
			return "UiItem_ItemBaseWeaponLift";
		}

		// Token: 0x06041542 RID: 267586 RVA: 0x010C1684 File Offset: 0x010BF884
		[NullableContext(1)]
		protected override void OnRefresh(params object[] args)
		{
			bool active = (bool)args[0];
			this.SetActive(active);
		}
	}
}
