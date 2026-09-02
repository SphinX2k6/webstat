using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.ItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FEA RID: 8170
public class InfluenceRewardItem : UiPanelBase
{
	// Token: 0x0600F6A3 RID: 63139 RVA: 0x004387B3 File Offset: 0x004369B3
	[NullableContext(1)]
	public InfluenceRewardItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600F6A4 RID: 63140 RVA: 0x004387C8 File Offset: 0x004369C8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F6A5 RID: 63141 RVA: 0x00438831 File Offset: 0x00436A31
	protected override void OnStart()
	{
		this.Layout = new GenericLayoutNew<CommonItemSimpleGridExFinish>(base.GetLayoutBase(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CommonItemSimpleGridExFinish>(this.InitItem), null);
	}

	// Token: 0x0600F6A6 RID: 63142 RVA: 0x00438854 File Offset: 0x00436A54
	[NullableContext(1)]
	private ILayoutItem<CommonItemSimpleGridExFinish> InitItem(object data, UUIItem uiItem, int index)
	{
		CommonItemSimpleGridExFinish commonItemSimpleGridExFinish = new CommonItemSimpleGridExFinish(uiItem.GetOwner());
		ValueTuple<int, int> valueTuple = (ValueTuple<int, int>)data;
		int item = valueTuple.Item1;
		int item2 = valueTuple.Item2;
		commonItemSimpleGridExFinish.RefreshItem(item, item2);
		commonItemSimpleGridExFinish.SetReceived(this.IsReceived);
		return new LayoutItem<CommonItemSimpleGridExFinish>
		{
			Key = index,
			Value = commonItemSimpleGridExFinish
		};
	}

	// Token: 0x0600F6A7 RID: 63143 RVA: 0x004388AC File Offset: 0x00436AAC
	protected override void OnBeforeDestroy()
	{
		this.Layout.ClearChildren();
		this.Layout = null;
	}

	// Token: 0x0600F6A8 RID: 63144 RVA: 0x004388C0 File Offset: 0x00436AC0
	public void UpdateItem(IntPair rewardData, bool isReceived)
	{
		this.IsReceived = isReceived;
		this.SetRewardTitle(rewardData.Item1);
		List<ValueTuple<int, int>> rewardList = ModelBase<InfluenceReputationModel>.Instance.GetRewardList(rewardData.Item2);
		this.Layout.RebuildLayoutByDataNew<ValueTuple<int, int>>(rewardList, null);
	}

	// Token: 0x0600F6A9 RID: 63145 RVA: 0x00438908 File Offset: 0x00436B08
	private void SetRewardTitle(int reputationValue)
	{
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "ReputationReceive", new <>z__ReadOnlySingleElementList<object>(reputationValue));
	}

	// Token: 0x0600F6AA RID: 63146 RVA: 0x00438938 File Offset: 0x00436B38
	public void SetAllReceivedTitle()
	{
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "ReputationAllReceived", Array.Empty<object>());
	}

	// Token: 0x0400772C RID: 30508
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<CommonItemSimpleGridExFinish> Layout;

	// Token: 0x0400772D RID: 30509
	private bool IsReceived;

	// Token: 0x02008368 RID: 33640
	private enum EInfluenceRewardItem
	{
		// Token: 0x0402C927 RID: 182567
		Title,
		// Token: 0x0402C928 RID: 182568
		Layout
	}
}
