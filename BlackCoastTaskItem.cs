using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001270 RID: 4720
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BlackCoastTaskItem : GridProxyAbstract<BlackCoastTaskData>
{
	// Token: 0x06007E06 RID: 32262 RVA: 0x00214600 File Offset: 0x00212800
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickJump));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickGetButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007E07 RID: 32263 RVA: 0x0021476E File Offset: 0x0021296E
	protected override void OnStart()
	{
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(6), new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
	}

	// Token: 0x06007E08 RID: 32264 RVA: 0x00214791 File Offset: 0x00212991
	private CommonItemSmallItemGrid CreatePropItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06007E09 RID: 32265 RVA: 0x00214798 File Offset: 0x00212998
	public override void Refresh(BlackCoastTaskData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RewardScrollView.RefreshByData(data.RewardList, null, false);
		bool uiactive = data.Status == EActivityTaskState.FinishedAndClaimed;
		bool uiactive2 = data.Status == EActivityTaskState.FinishedAndUnclaimed;
		bool flag = data.Status == EActivityTaskState.Active;
		base.GetButton(1).RootUIComp.Get().SetUIActive(uiactive2);
		base.GetItem(3).SetUIActive(uiactive);
		base.GetItem(2).SetUIActive(flag && data.JumpId == 0);
		base.GetButton(0).RootUIComp.Get().SetUIActive(flag && data.JumpId > 0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), data.TitleTextId, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "BlackCoastTheme_TaskProgress", new <>z__ReadOnlyArray<object>(new object[]
		{
			data.Current,
			data.Target
		}));
	}

	// Token: 0x06007E0A RID: 32266 RVA: 0x002148A0 File Offset: 0x00212AA0
	private void OnClickJump()
	{
		SkipTaskManager.RunByConfigId(this.Data.JumpId, null);
	}

	// Token: 0x06007E0B RID: 32267 RVA: 0x002148B3 File Offset: 0x00212AB3
	private void OnClickGetButton()
	{
		Action<int> receiveDelegate = this.Data.ReceiveDelegate;
		if (receiveDelegate == null)
		{
			return;
		}
		receiveDelegate(this.Data.TaskId);
	}

	// Token: 0x04003C81 RID: 15489
	private BlackCoastTaskData Data;

	// Token: 0x04003C82 RID: 15490
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x020075EC RID: 30188
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028AAB RID: 166571
		public const int JumpBtn = 0;

		// Token: 0x04028AAC RID: 166572
		public const int GetBtn = 1;

		// Token: 0x04028AAD RID: 166573
		public const int DoingText = 2;

		// Token: 0x04028AAE RID: 166574
		public const int FinishItem = 3;

		// Token: 0x04028AAF RID: 166575
		public const int TxtName = 4;

		// Token: 0x04028AB0 RID: 166576
		public const int ProgressText = 5;

		// Token: 0x04028AB1 RID: 166577
		public const int RewardScroll = 6;
	}
}
