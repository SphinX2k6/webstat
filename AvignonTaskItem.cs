using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020011D0 RID: 4560
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AvignonTaskItem : GridProxyAbstract<AvignonTaskData>
{
	// Token: 0x0600784E RID: 30798 RVA: 0x001F7C0C File Offset: 0x001F5E0C
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

	// Token: 0x0600784F RID: 30799 RVA: 0x001F7D7A File Offset: 0x001F5F7A
	protected override void OnStart()
	{
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(6), new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
	}

	// Token: 0x06007850 RID: 30800 RVA: 0x001F7D9D File Offset: 0x001F5F9D
	private CommonItemSmallItemGrid CreatePropItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06007851 RID: 30801 RVA: 0x001F7DA4 File Offset: 0x001F5FA4
	public override void Refresh(AvignonTaskData data, bool isSelected, int gridIndex)
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

	// Token: 0x06007852 RID: 30802 RVA: 0x001F7EAC File Offset: 0x001F60AC
	private void OnClickJump()
	{
		SkipTaskManager.RunByConfigId(this.Data.JumpId, null);
	}

	// Token: 0x06007853 RID: 30803 RVA: 0x001F7EBF File Offset: 0x001F60BF
	private void OnClickGetButton()
	{
		Action<int> receiveDelegate = this.Data.ReceiveDelegate;
		if (receiveDelegate == null)
		{
			return;
		}
		receiveDelegate(this.Data.TaskId);
	}

	// Token: 0x04003A20 RID: 14880
	[Nullable(2)]
	private AvignonTaskData Data;

	// Token: 0x04003A21 RID: 14881
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x02007528 RID: 29992
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028712 RID: 165650
		public const int JumpBtn = 0;

		// Token: 0x04028713 RID: 165651
		public const int GetBtn = 1;

		// Token: 0x04028714 RID: 165652
		public const int DoingText = 2;

		// Token: 0x04028715 RID: 165653
		public const int FinishItem = 3;

		// Token: 0x04028716 RID: 165654
		public const int TxtName = 4;

		// Token: 0x04028717 RID: 165655
		public const int ProgressText = 5;

		// Token: 0x04028718 RID: 165656
		public const int RewardScroll = 6;
	}
}
