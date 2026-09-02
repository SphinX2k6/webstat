using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200238F RID: 9103
public class BattlePassUnlockView : UiViewBase
{
	// Token: 0x0601171F RID: 71455 RVA: 0x004CEDC8 File Offset: 0x004CCFC8
	[NullableContext(1)]
	public BattlePassUnlockView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011720 RID: 71456 RVA: 0x004CEDDC File Offset: 0x004CCFDC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnBtnClose));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011721 RID: 71457 RVA: 0x004CEF06 File Offset: 0x004CD106
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BattlePassMainViewHide, new Action(this.OnMainViewHide));
	}

	// Token: 0x06011722 RID: 71458 RVA: 0x004CEF24 File Offset: 0x004CD124
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BattlePassMainViewHide, new Action(this.OnMainViewHide));
	}

	// Token: 0x06011723 RID: 71459 RVA: 0x004CEF42 File Offset: 0x004CD142
	private void OnMainViewHide()
	{
		base.CloseMe(null);
	}

	// Token: 0x06011724 RID: 71460 RVA: 0x004CEF4C File Offset: 0x004CD14C
	protected override void OnStart()
	{
		EBattlePassUnlockType ebattlePassUnlockType = (EBattlePassUnlockType)this.OpenParam;
		this.RewardList = new List<TItem>();
		ConfigBase<BattlePassConfig>.Instance.GetBattlePassUnlockReward(ebattlePassUnlockType, this.RewardList);
		this.RewardGridView = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(0), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, true);
		this.RewardGridView.RefreshByData(this.RewardList, null, false);
		BattlePassUnlockPop value = ConfigBase<BattlePassConfig>.Instance.GetBattlePassUnlock((int)ebattlePassUnlockType).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.UnlockTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), value.UnlockText, Array.Empty<object>());
		base.GetItem(2).SetUIActive(ebattlePassUnlockType == EBattlePassUnlockType.Primary);
		base.GetItem(3).SetUIActive(ebattlePassUnlockType != EBattlePassUnlockType.Primary);
	}

	// Token: 0x06011725 RID: 71461 RVA: 0x004CF026 File Offset: 0x004CD226
	[NullableContext(1)]
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06011726 RID: 71462 RVA: 0x004CF030 File Offset: 0x004CD230
	protected override void OnBeforeDestroy()
	{
		this.RewardList.Clear();
		this.RewardList = null;
		this.RewardGridView = null;
		if ((EBattlePassUnlockType)this.OpenParam == EBattlePassUnlockType.Primary)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.BattlePassFirstUnlockAnime);
			return;
		}
		ControllerBase<BattlePassController>.Instance.PopHighUnlockReward();
	}

	// Token: 0x06011727 RID: 71463 RVA: 0x004CF07F File Offset: 0x004CD27F
	private void OnBtnClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x040088F3 RID: 35059
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardGridView;

	// Token: 0x040088F4 RID: 35060
	[Nullable(2)]
	private List<TItem> RewardList = new List<TItem>();

	// Token: 0x020086AD RID: 34477
	private enum EComponents
	{
		// Token: 0x0402D8CF RID: 186575
		ItemGrid,
		// Token: 0x0402D8D0 RID: 186576
		TxtTitle,
		// Token: 0x0402D8D1 RID: 186577
		PrimaryPic,
		// Token: 0x0402D8D2 RID: 186578
		HighPic,
		// Token: 0x0402D8D3 RID: 186579
		BtnClose,
		// Token: 0x0402D8D4 RID: 186580
		TxtTip
	}
}
