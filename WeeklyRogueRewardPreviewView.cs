using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D4E RID: 11598
public class WeeklyRogueRewardPreviewView : UiViewBase
{
	// Token: 0x0601765E RID: 95838 RVA: 0x0067CC3C File Offset: 0x0067AE3C
	[NullableContext(1)]
	public WeeklyRogueRewardPreviewView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0601765F RID: 95839 RVA: 0x0067CC48 File Offset: 0x0067AE48
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06017660 RID: 95840 RVA: 0x0067CCA4 File Offset: 0x0067AEA4
	protected override void OnStart()
	{
		this.ItemLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetGridLayout(1), new Func<CommonItemSmallItemGrid>(this.InitCommonGridItem), null, false, true);
		WeeklyRogueData activityDataNew = ModelBase<WeeklyRogueModel>.Instance.ActivityDataNew;
		if (activityDataNew == null)
		{
			return;
		}
		this.ItemLayout.RefreshByData(ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList(activityDataNew.GetCycleConfig().Value.BlackFlowerAward, new int?(activityDataNew.WorldLevel)), null, false);
	}

	// Token: 0x06017661 RID: 95841 RVA: 0x0067CD19 File Offset: 0x0067AF19
	[NullableContext(1)]
	private CommonItemSmallItemGrid InitCommonGridItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0400B393 RID: 45971
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayout<CommonItemSmallItemGrid, TItem> ItemLayout;

	// Token: 0x02009019 RID: 36889
	private enum EComponents
	{
		// Token: 0x04030586 RID: 198022
		TxtDesc,
		// Token: 0x04030587 RID: 198023
		GridLayout,
		// Token: 0x04030588 RID: 198024
		GridItem
	}
}
