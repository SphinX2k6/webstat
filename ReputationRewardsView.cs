using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FEE RID: 8174
public class ReputationRewardsView : UiViewBase
{
	// Token: 0x0600F6C4 RID: 63172 RVA: 0x0043911A File Offset: 0x0043731A
	[NullableContext(1)]
	public ReputationRewardsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F6C5 RID: 63173 RVA: 0x00439124 File Offset: 0x00437324
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F6C6 RID: 63174 RVA: 0x0043916C File Offset: 0x0043736C
	protected override void OnBeforeCreate()
	{
		int id = (int)this.OpenParam;
		this.Influence = ModelBase<InfluenceReputationModel>.Instance.GetInfluenceInstance(id);
	}

	// Token: 0x0600F6C7 RID: 63175 RVA: 0x00439196 File Offset: 0x00437396
	protected override void OnStart()
	{
		this.ScrollView = new GenericScrollView<InfluenceRewardItem>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<InfluenceRewardItem>(this.InitItem), null);
	}

	// Token: 0x0600F6C8 RID: 63176 RVA: 0x004391B8 File Offset: 0x004373B8
	[NullableContext(1)]
	private ILayoutItem<InfluenceRewardItem> InitItem(object data, UUIItem uiItem, int index)
	{
		InfluenceRewardItem influenceRewardItem = new InfluenceRewardItem(uiItem);
		bool isReceived = this.Influence.RewardIndex >= index;
		influenceRewardItem.UpdateItem((IntPair)data, isReceived);
		return new LayoutItem<InfluenceRewardItem>
		{
			Key = index,
			Value = influenceRewardItem
		};
	}

	// Token: 0x0600F6C9 RID: 63177 RVA: 0x00439204 File Offset: 0x00437404
	protected override void OnAfterShow()
	{
		this.ScrollView.RefreshByData<IntPair>(this.Influence.GetReward().ToList<IntPair>(), null);
	}

	// Token: 0x0600F6CA RID: 63178 RVA: 0x00439235 File Offset: 0x00437435
	protected override void OnBeforeDestroy()
	{
		this.ScrollView.ClearChildren();
		this.ScrollView = null;
	}

	// Token: 0x04007735 RID: 30517
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<InfluenceRewardItem> ScrollView;

	// Token: 0x04007736 RID: 30518
	[Nullable(2)]
	private InfluenceInstance Influence;

	// Token: 0x0200836C RID: 33644
	private enum EReputationRewardsView
	{
		// Token: 0x0402C93E RID: 182590
		ScrollView
	}
}
