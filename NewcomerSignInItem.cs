using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001461 RID: 5217
[NullableContext(1)]
[Nullable(0)]
public class NewcomerSignInItem : GridProxyAbstract<OneItemConfig>
{
	// Token: 0x06009177 RID: 37239 RVA: 0x00265D60 File Offset: 0x00263F60
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009178 RID: 37240 RVA: 0x00265F10 File Offset: 0x00264110
	protected override UniTask OnBeforeStartAsync()
	{
		NewcomerSignInItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<NewcomerSignInItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009179 RID: 37241 RVA: 0x00265F54 File Offset: 0x00264154
	private void OnClickToggle(EToggleState toggleState)
	{
		ActivitySevenDaySignData activityData = this.ActivityData;
		if (((activityData != null) ? activityData.GetRewardStateByDay(base.GridIndex) : null).GetValueOrDefault() == SignState.Unlock)
		{
			ControllerBase<ActivitySevenDaySignController>.Instance.GetRewardByDay(this.ActivityData.Id, base.GridIndex);
		}
	}

	// Token: 0x0600917A RID: 37242 RVA: 0x00265FA8 File Offset: 0x002641A8
	private void OnClickGrid()
	{
		ActivitySevenDaySignData activityData = this.ActivityData;
		if (((activityData != null) ? activityData.GetRewardStateByDay(base.GridIndex) : null).GetValueOrDefault() == SignState.Unlock)
		{
			ControllerBase<ActivitySevenDaySignController>.Instance.GetRewardByDay(this.ActivityData.Id, base.GridIndex);
			return;
		}
		ActivitySignGrandReward? activitySignGrandReward;
		this.GrandRewardConfigMap.TryGetValue(base.GridIndex + 1, out activitySignGrandReward);
		if (activitySignGrandReward != null && activitySignGrandReward.Value.PreviewType == 1)
		{
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, 0, activitySignGrandReward.Value.GetPreviewListArray().ToList<int>(), null, null);
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemId, true, null);
	}

	// Token: 0x0600917B RID: 37243 RVA: 0x0026606B File Offset: 0x0026426B
	private string GetRewardStateTextId(SignState state)
	{
		switch (state)
		{
		case SignState.Lock:
			return "NeedSign";
		case SignState.Unlock:
			return "CanGetReward";
		case SignState.IsReceive:
			return "CollectActivity_state_recived";
		default:
			return "NeedSign";
		}
	}

	// Token: 0x0600917C RID: 37244 RVA: 0x00266098 File Offset: 0x00264298
	public void SetDayText(int day)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "DayNum", new <>z__ReadOnlySingleElementList<object>(day));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "DayNum", new <>z__ReadOnlySingleElementList<object>(day));
	}

	// Token: 0x0600917D RID: 37245 RVA: 0x002660E7 File Offset: 0x002642E7
	public void SetStateText(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textId, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), textId, Array.Empty<object>());
	}

	// Token: 0x0600917E RID: 37246 RVA: 0x00266118 File Offset: 0x00264318
	public override void Refresh(OneItemConfig data, bool isSelected, int gridIndex)
	{
		if (this.ActivityData == null)
		{
			return;
		}
		base.GridIndex = gridIndex;
		ActivitySevenDaySignData activityData = this.ActivityData;
		SignState valueOrDefault = ((activityData != null) ? activityData.GetRewardStateByDay(gridIndex) : null).GetValueOrDefault();
		this.ItemId = data.ItemId;
		this.SetDayText(gridIndex + 1);
		bool flag = valueOrDefault == SignState.IsReceive;
		bool flag2 = valueOrDefault == SignState.Unlock;
		this.CanGetReward = flag2;
		this.SetStateText(this.GetRewardStateTextId(valueOrDefault));
		base.GetItem(1).SetUIActive(!flag2);
		base.GetItem(4).SetUIActive(flag2);
		base.GetItem(8).SetUIActive(flag);
		base.GetItem(9).SetUIActive(flag2);
		TItem data2 = new TItem(new InventoryDefine.GetItemData(data.ItemId, 0), data.Count);
		CommonItemSmallItemGrid grid = this.Grid;
		if (grid != null)
		{
			grid.Refresh(data2);
		}
		CommonItemSmallItemGrid grid2 = this.Grid;
		if (grid2 != null)
		{
			grid2.SetReceivableVisible(flag2);
		}
		CommonItemSmallItemGrid grid3 = this.Grid;
		if (grid3 == null)
		{
			return;
		}
		grid3.SetReceivedVisible(flag);
	}

	// Token: 0x0600917F RID: 37247 RVA: 0x00266217 File Offset: 0x00264417
	public void SetActivityData(ActivitySevenDaySignData data)
	{
		this.ActivityData = data;
	}

	// Token: 0x06009180 RID: 37248 RVA: 0x00266220 File Offset: 0x00264420
	public void SetGrandRewardConfigMap(Dictionary<int, ActivitySignGrandReward?> grandRewardConfigMap)
	{
		this.GrandRewardConfigMap = grandRewardConfigMap;
	}

	// Token: 0x0400438D RID: 17293
	private CommonItemSmallItemGrid Grid;

	// Token: 0x0400438E RID: 17294
	private ActivitySevenDaySignData ActivityData;

	// Token: 0x0400438F RID: 17295
	protected bool CanGetReward;

	// Token: 0x04004390 RID: 17296
	private int ItemId;

	// Token: 0x04004391 RID: 17297
	private Dictionary<int, ActivitySignGrandReward?> GrandRewardConfigMap;

	// Token: 0x02007860 RID: 30816
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04029670 RID: 169584
		public const int Toggle = 0;

		// Token: 0x04029671 RID: 169585
		public const int StateNormalRoot = 1;

		// Token: 0x04029672 RID: 169586
		public const int NormalDayText = 2;

		// Token: 0x04029673 RID: 169587
		public const int StateText = 3;

		// Token: 0x04029674 RID: 169588
		public const int StateGetItem = 4;

		// Token: 0x04029675 RID: 169589
		public const int GetDayText = 5;

		// Token: 0x04029676 RID: 169590
		public const int GetStateText = 6;

		// Token: 0x04029677 RID: 169591
		public const int PropItem = 7;

		// Token: 0x04029678 RID: 169592
		public const int FinishMask = 8;

		// Token: 0x04029679 RID: 169593
		public const int RedDotItem = 9;
	}
}
