using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C9E RID: 7326
[NullableContext(2)]
[Nullable(0)]
public class FriendApplyView : UiTickViewBase
{
	// Token: 0x0600D6B8 RID: 54968 RVA: 0x00394FA7 File Offset: 0x003931A7
	[NullableContext(1)]
	public FriendApplyView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D6B9 RID: 54969 RVA: 0x00394FB0 File Offset: 0x003931B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
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

	// Token: 0x0600D6BA RID: 54970 RVA: 0x00395161 File Offset: 0x00393361
	protected override void OnStart()
	{
		this.ToBeAddedPlayerIdList = (this.OpenParam as List<int>);
		this.CountDown = base.GetText(5);
		this.CountDownBar = base.GetSprite(6);
		this.ResetTime();
		this.RefreshView();
	}

	// Token: 0x0600D6BB RID: 54971 RVA: 0x0039519A File Offset: 0x0039339A
	protected override void OnBeforeDestroy()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FriendMultipleApplyView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FriendMultipleApplyView, null);
		}
	}

	// Token: 0x0600D6BC RID: 54972 RVA: 0x003951C0 File Offset: 0x003933C0
	protected override void OnTick(float delta)
	{
		List<FriendApplyData> applyViewDataList = ModelBase<FriendModel>.Instance.GetApplyViewDataList(this.ToBeAddedPlayerIdList);
		if (applyViewDataList.Count == 0 || applyViewDataList[0].ApplyTimeLeftTime < 0.0)
		{
			if (!this.HaveClosed)
			{
				base.CloseMe(null);
				this.HaveClosed = true;
			}
			return;
		}
		this.CountDown.SetText(Singleton<TimeUtil>.Instance.GetCoolDown(applyViewDataList[0].ApplyTimeLeftTime), true);
		this.CountDownBar.SetFillAmount((float)(applyViewDataList[0].ApplyTimeLeftTime / (double)ModelBase<FriendModel>.Instance.ApplyCdTime));
	}

	// Token: 0x0600D6BD RID: 54973 RVA: 0x0039525A File Offset: 0x0039345A
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshFriendApplicationRedDot, new Action(this.CallServerNotifyFriendApply));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.FriendOnMultiItemAction, new Action<int>(this.HandleFriendOnMultiItemAction));
	}

	// Token: 0x0600D6BE RID: 54974 RVA: 0x00395294 File Offset: 0x00393494
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshFriendApplicationRedDot, new Action(this.CallServerNotifyFriendApply));
		Singleton<EventSystem>.Instance.Remove(EEventName.FriendOnMultiItemAction, new Action<int>(this.HandleFriendOnMultiItemAction));
	}

	// Token: 0x0600D6BF RID: 54975 RVA: 0x003952D0 File Offset: 0x003934D0
	private void ResetTime()
	{
		List<FriendApplyData> applyViewDataList = ModelBase<FriendModel>.Instance.GetApplyViewDataList(this.ToBeAddedPlayerIdList);
		if (applyViewDataList.Count == 0)
		{
			return;
		}
		foreach (FriendApplyData friendApplyData in applyViewDataList)
		{
			friendApplyData.ApplyTimeLeftTime = Singleton<TimeUtil>.Instance.GetServerTime();
		}
	}

	// Token: 0x0600D6C0 RID: 54976 RVA: 0x00395340 File Offset: 0x00393540
	private void RefreshView()
	{
		List<FriendApplyData> applyViewDataList = ModelBase<FriendModel>.Instance.GetApplyViewDataList(this.ToBeAddedPlayerIdList);
		if (applyViewDataList.Count == 0)
		{
			base.Hide(null);
			return;
		}
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(4);
		UUIText text = base.GetText(7);
		if (applyViewDataList.Count == 1)
		{
			item.SetUIActive(true);
			item2.SetUIActive(false);
			Singleton<LguiUtil>.Instance.SetLocalText(text, "TowerDefence_friendOnly", Array.Empty<object>());
			UUIButtonComponent button = base.GetButton(8);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(true);
			}
		}
		else
		{
			item.SetUIActive(false);
			item2.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(text, "TowerDefence_friendMore", new <>z__ReadOnlySingleElementList<object>(applyViewDataList.Count));
			UUIButtonComponent button2 = base.GetButton(8);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(false);
			}
		}
		FriendApplyData friendApplyData = applyViewDataList[0];
		FriendData applyPlayerData = friendApplyData.ApplyPlayerData;
		base.GetText(1).SetText(applyPlayerData.PlayerName, true);
		this.CountDown.SetText(Singleton<TimeUtil>.Instance.GetCoolDown(friendApplyData.ApplyTimeLeftTime), true);
		this.CountDownBar.SetFillAmount((float)(friendApplyData.ApplyTimeLeftTime / (double)ModelBase<FriendModel>.Instance.ApplyCdTime));
		RoleInfo? roleInfo;
		string text2 = (ConfigBase<RoleConfig>.Instance.GetRoleConfig(applyPlayerData.PlayerHeadPhoto) != null) ? roleInfo.GetValueOrDefault().Card : null;
		if (!string.IsNullOrEmpty(text2))
		{
			base.SetTextureByPath(text2, base.GetTexture(0), null, null);
		}
		UUIButtonComponent button3 = base.GetButton(8);
		if (button3 == null)
		{
			return;
		}
		button3.RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x0600D6C1 RID: 54977 RVA: 0x003954FC File Offset: 0x003936FC
	private void OnClickHandleBtn()
	{
		List<FriendApplyData> applyViewDataList = ModelBase<FriendModel>.Instance.GetApplyViewDataList(this.ToBeAddedPlayerIdList);
		if (applyViewDataList.Count < 1)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FriendMultipleApplyView, null);
			return;
		}
		if (applyViewDataList.Count == 1)
		{
			FriendData applyPlayerData = applyViewDataList[0].ApplyPlayerData;
			ControllerBase<FriendController>.Instance.RequestFriendApplyHandle(new List<int>
			{
				applyPlayerData.PlayerId
			}, FriendApplyOperator.Approve);
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FriendMultipleApplyView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FriendMultipleApplyView, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FriendMultipleApplyView, applyViewDataList, null);
	}

	// Token: 0x0600D6C2 RID: 54978 RVA: 0x0039559C File Offset: 0x0039379C
	private void OnClickCancelBtn()
	{
		List<FriendApplyData> applyViewDataList = ModelBase<FriendModel>.Instance.GetApplyViewDataList(this.ToBeAddedPlayerIdList);
		if (applyViewDataList.Count < 1)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineMultipleApplyView, null);
			return;
		}
		List<int> list = new List<int>();
		foreach (FriendApplyData friendApplyData in applyViewDataList)
		{
			FriendData applyPlayerData = friendApplyData.ApplyPlayerData;
			if (applyPlayerData != null)
			{
				list.Add(applyPlayerData.PlayerId);
			}
		}
		ControllerBase<FriendController>.Instance.RequestFriendApplyHandle(list, FriendApplyOperator.Reject);
	}

	// Token: 0x0600D6C3 RID: 54979 RVA: 0x00395634 File Offset: 0x00393834
	private void CallServerNotifyFriendApply()
	{
		this.ResetTime();
		this.RefreshView();
	}

	// Token: 0x0600D6C4 RID: 54980 RVA: 0x00395644 File Offset: 0x00393844
	private void HandleFriendOnMultiItemAction(int playerId)
	{
		if (this.ToBeAddedPlayerIdList == null)
		{
			return;
		}
		int num = this.ToBeAddedPlayerIdList.IndexOf(playerId);
		if (num != -1)
		{
			this.ToBeAddedPlayerIdList.RemoveAt(num);
		}
		this.RefreshView();
	}

	// Token: 0x040065D9 RID: 26073
	private UUIText CountDown;

	// Token: 0x040065DA RID: 26074
	private UUISprite CountDownBar;

	// Token: 0x040065DB RID: 26075
	private bool HaveClosed;

	// Token: 0x040065DC RID: 26076
	private List<int> ToBeAddedPlayerIdList;

	// Token: 0x02007FF4 RID: 32756
	[NullableContext(0)]
	private class EFriendApplyView
	{
		// Token: 0x0402B897 RID: 178327
		public const int RoleTexture = 0;

		// Token: 0x0402B898 RID: 178328
		public const int PlayerName = 1;

		// Token: 0x0402B899 RID: 178329
		public const int HandleBtn = 2;

		// Token: 0x0402B89A RID: 178330
		public const int ApplySprite = 3;

		// Token: 0x0402B89B RID: 178331
		public const int MoreSprite = 4;

		// Token: 0x0402B89C RID: 178332
		public const int CountDown = 5;

		// Token: 0x0402B89D RID: 178333
		public const int CountDownProgressBar = 6;

		// Token: 0x0402B89E RID: 178334
		public const int MultipleApplyText = 7;

		// Token: 0x0402B89F RID: 178335
		public const int CancelBtn = 8;
	}
}
