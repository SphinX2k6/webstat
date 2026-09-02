using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent
{
	// Token: 0x0200661A RID: 26138
	public class PinballItemGridLockComponent : PinballItemGridComponentBase
	{
		// Token: 0x06041515 RID: 267541 RVA: 0x010C0F69 File Offset: 0x010BF169
		[NullableContext(2)]
		protected override string OnGetResourceId()
		{
			return "UiItem_ItemBaseLocked";
		}

		// Token: 0x06041516 RID: 267542 RVA: 0x010C0F70 File Offset: 0x010BF170
		[NullableContext(1)]
		protected override void OnRefresh(params object[] args)
		{
			bool active = (bool)args[0];
			this.SetActive(active);
		}
	}
}
