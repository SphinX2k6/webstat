using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using UnrealEngine;

// Token: 0x02002348 RID: 9032
public class OnlineMatchSuccessView : UiTickViewBase
{
	// Token: 0x060113F1 RID: 70641 RVA: 0x004BD3FD File Offset: 0x004BB5FD
	[NullableContext(1)]
	public OnlineMatchSuccessView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060113F2 RID: 70642 RVA: 0x004BD420 File Offset: 0x004BB620
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickHandleBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickCancelBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060113F3 RID: 70643 RVA: 0x004BD638 File Offset: 0x004BB838
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(11);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		base.GetButton(8).GetRootComponent().SetUIActive(true);
		this.CountDown = base.GetText(5);
		this.CountDownBar = base.GetSprite(6);
		int value = ConfigCommonParamById.GetIntConfig("match_confirm_time_out_seconds").Value;
		this.CountDownNumber = (float)value;
		this.CountDownNumberMax = value;
		base.GetItem(9).SetUIActive(true);
		base.GetItem(10).SetUIActive(false);
		this.RefreshView();
	}

	// Token: 0x060113F4 RID: 70644 RVA: 0x004BD6C9 File Offset: 0x004BB8C9
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
	}

	// Token: 0x060113F5 RID: 70645 RVA: 0x004BD6E7 File Offset: 0x004BB8E7
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
	}

	// Token: 0x060113F6 RID: 70646 RVA: 0x004BD708 File Offset: 0x004BB908
	protected override void OnTick(float delta)
	{
		if (!this.IsTick)
		{
			return;
		}
		this.CountDownNumber -= delta * (float)Singleton<TimeUtil>.Instance.Millisecond;
		if (this.CountDownNumber <= 0f)
		{
			this.IsTick = false;
			base.CloseMe(null);
			return;
		}
		this.CountDown.SetText(Singleton<TimeUtil>.Instance.GetCoolDown((double)this.CountDownNumber), true);
		this.CountDownBar.SetFillAmount(this.CountDownNumber / (float)this.CountDownNumberMax);
	}

	// Token: 0x060113F7 RID: 70647 RVA: 0x004BD78C File Offset: 0x004BB98C
	private void RefreshView()
	{
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(4);
		item.SetUIActive(true);
		item2.SetUIActive(false);
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "MatchingSuccess", Array.Empty<object>());
		UUIText text2 = base.GetText(7);
		int matchingId = ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingId();
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(matchingId).Value.MapName, null);
		text2.SetText(localTextNew, true);
		this.CountDown.SetText(Singleton<TimeUtil>.Instance.GetCoolDown((double)this.CountDownNumber), true);
		this.CountDownBar.SetFillAmount(this.CountDownNumber / (float)this.CountDownNumberMax);
	}

	// Token: 0x060113F8 RID: 70648 RVA: 0x004BD848 File Offset: 0x004BBA48
	private void ShowMatchSuccess()
	{
		base.GetButton(8).GetRootComponent().SetUIActive(false);
		base.GetButton(2).GetRootComponent().SetUIActive(false);
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "MatchingTeleport", Array.Empty<object>());
		base.GetText(7).SetUIActive(false);
		this.CountDown.SetUIActive(false);
		this.CountDownBar.SetUIActive(false);
	}

	// Token: 0x060113F9 RID: 70649 RVA: 0x004BD8BC File Offset: 0x004BBABC
	private void OnMatchingChange()
	{
		EInstanceMatchState matchingState = ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState();
		if (matchingState == EInstanceMatchState.Waiting)
		{
			this.ShowMatchSuccess();
			return;
		}
		if (matchingState == EInstanceMatchState.Matching)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("MatchingOtherCancel", Array.Empty<object>());
			this.IsTick = false;
			base.CloseMe(null);
			return;
		}
		this.IsTick = false;
		base.CloseMe(null);
	}

	// Token: 0x060113FA RID: 70650 RVA: 0x004BD914 File Offset: 0x004BBB14
	private void OnClickHandleBtn()
	{
		ControllerBase<InstanceDungeonEntranceController>.Instance.MatchConfirmRequest(true);
		this.IsTick = false;
		this.ShowMatchSuccess();
	}

	// Token: 0x060113FB RID: 70651 RVA: 0x004BD92E File Offset: 0x004BBB2E
	private void OnClickCancelBtn()
	{
		ControllerBase<InstanceDungeonEntranceController>.Instance.MatchConfirmRequest(false);
		ModelBase<InstanceDungeonModel>.Instance.ResetData();
		base.CloseMe(null);
	}

	// Token: 0x04008785 RID: 34693
	private float CountDownNumber = -1f;

	// Token: 0x04008786 RID: 34694
	private int CountDownNumberMax = -1;

	// Token: 0x04008787 RID: 34695
	[Nullable(2)]
	private UUIText CountDown;

	// Token: 0x04008788 RID: 34696
	[Nullable(2)]
	private UUISprite CountDownBar;

	// Token: 0x04008789 RID: 34697
	private bool IsTick = true;

	// Token: 0x02008660 RID: 34400
	private enum EOnlineMatchSuccessView
	{
		// Token: 0x0402D731 RID: 186161
		RoleTexture,
		// Token: 0x0402D732 RID: 186162
		PlayerName,
		// Token: 0x0402D733 RID: 186163
		HandleBtn,
		// Token: 0x0402D734 RID: 186164
		ApplySprite,
		// Token: 0x0402D735 RID: 186165
		MoreSprite,
		// Token: 0x0402D736 RID: 186166
		CountDown,
		// Token: 0x0402D737 RID: 186167
		CountDownProgressBar,
		// Token: 0x0402D738 RID: 186168
		MultipleApplyText,
		// Token: 0x0402D739 RID: 186169
		CancelBtn,
		// Token: 0x0402D73A RID: 186170
		ApplyItem,
		// Token: 0x0402D73B RID: 186171
		RoleTItem,
		// Token: 0x0402D73C RID: 186172
		ProgressBarItem
	}
}
