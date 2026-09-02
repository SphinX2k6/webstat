using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent
{
	// Token: 0x02006622 RID: 26146
	public class PinballItemGridRoleRecommendComponent : PinballItemGridComponentBase
	{
		// Token: 0x0604153B RID: 267579 RVA: 0x010C1622 File Offset: 0x010BF822
		[NullableContext(2)]
		protected override string OnGetResourceId()
		{
			return "UiItem_ItemBaseRecommend";
		}

		// Token: 0x0604153C RID: 267580 RVA: 0x010C162C File Offset: 0x010BF82C
		[NullableContext(1)]
		protected override void OnRefresh(params object[] args)
		{
			bool active = (bool)args[0];
			this.SetActive(active);
		}
	}
}
