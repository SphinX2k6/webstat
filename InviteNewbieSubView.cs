using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001344 RID: 4932
[NullableContext(2)]
[Nullable(0)]
public class InviteNewbieSubView : ActivitySubViewBase
{
	// Token: 0x060086B9 RID: 34489 RVA: 0x002379D8 File Offset: 0x00235BD8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickCopyInviteCodeButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060086BA RID: 34490 RVA: 0x00237B02 File Offset: 0x00235D02
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string>(EEventName.InviteNewbieInviteCodeChanged, new Action<string>(this.HandleInviteNewbieInviteCodeChanged));
	}

	// Token: 0x060086BB RID: 34491 RVA: 0x00237B20 File Offset: 0x00235D20
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.InviteNewbieInviteCodeChanged, new Action<string>(this.HandleInviteNewbieInviteCodeChanged));
	}

	// Token: 0x060086BC RID: 34492 RVA: 0x00237B40 File Offset: 0x00235D40
	protected override UniTask OnBeforeStartAsync()
	{
		InviteNewbieSubView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<InviteNewbieSubView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060086BD RID: 34493 RVA: 0x00237B83 File Offset: 0x00235D83
	private void OnClickCopyInviteCodeButton()
	{
		ControllerBase<ActivityInviteNewbieController>.Instance.HandleOnCopyInviteCodeClick();
	}

	// Token: 0x060086BE RID: 34494 RVA: 0x00237B90 File Offset: 0x00235D90
	protected override void OnRefreshView()
	{
		InviteNewbieModel instance = ModelBase<InviteNewbieModel>.Instance;
		this.RefreshTimeText();
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText(instance.InviteCode, true);
		}
		this.RefreshCopyItemState();
	}

	// Token: 0x060086BF RID: 34495 RVA: 0x00237BC8 File Offset: 0x00235DC8
	protected override void OnTimer(float delta)
	{
		this.RefreshTimeText();
	}

	// Token: 0x060086C0 RID: 34496 RVA: 0x00237BD0 File Offset: 0x00235DD0
	private void RefreshTimeText()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		InviteNewbieActivityItem activityItem = this.ActivityItem;
		if (activityItem == null)
		{
			return;
		}
		activityItem.RefreshTimerTextByData(item, item2);
	}

	// Token: 0x060086C1 RID: 34497 RVA: 0x00237C04 File Offset: 0x00235E04
	private void RefreshCopyItemState()
	{
		string inviteCode = ModelBase<InviteNewbieModel>.Instance.InviteCode;
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(!StringUtils.IsEmpty(inviteCode));
		}
	}

	// Token: 0x060086C2 RID: 34498 RVA: 0x00237C36 File Offset: 0x00235E36
	[NullableContext(1)]
	private void HandleInviteNewbieInviteCodeChanged(string newCode)
	{
		UUIText text = base.GetText(3);
		if (text == null)
		{
			return;
		}
		text.SetText(newCode ?? "", true);
	}

	// Token: 0x04003FA3 RID: 16291
	private InviteNewbieActivityItem ActivityItem;

	// Token: 0x04003FA4 RID: 16292
	private InviteNewbieRewardItem RewardItem;

	// Token: 0x04003FA5 RID: 16293
	private InviteNewbieBgItem BgItem;

	// Token: 0x020076E7 RID: 30439
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04028F31 RID: 167729
		public const int ActivityRootItem = 0;

		// Token: 0x04028F32 RID: 167730
		public const int RewardRootItem = 1;

		// Token: 0x04028F33 RID: 167731
		public const int CopyInviteCodeButton = 2;

		// Token: 0x04028F34 RID: 167732
		public const int InviteCodeText = 3;

		// Token: 0x04028F35 RID: 167733
		public const int ContentRootItem = 4;

		// Token: 0x04028F36 RID: 167734
		public const int CopyItem = 5;
	}
}
