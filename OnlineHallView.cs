using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002347 RID: 9031
[NullableContext(1)]
[Nullable(0)]
public class OnlineHallView : UiTickViewBase
{
	// Token: 0x060113CB RID: 70603 RVA: 0x004BC3A7 File Offset: 0x004BA5A7
	public OnlineHallView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060113CC RID: 70604 RVA: 0x004BC3B0 File Offset: 0x004BA5B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 17;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITextInputComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickPermissionBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickSearchConfirmBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnClickRefreshBtnBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060113CD RID: 70605 RVA: 0x004BC6B8 File Offset: 0x004BA8B8
	protected override UniTask OnBeforeStartAsync()
	{
		OnlineHallView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<OnlineHallView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060113CE RID: 70606 RVA: 0x004BC6FC File Offset: 0x004BA8FC
	protected override void OnStart()
	{
		this.InitTitle();
		if (ModelBase<OnlineModel>.Instance.GetIsTeamModel())
		{
			base.GetButton(15).RootUIComp.Get().SetUIActive(false);
			this.RefreshTeamList(ModelBase<OnlineModel>.Instance.GetTeamList());
		}
		else
		{
			this.RefreshHallList(ModelBase<OnlineModel>.Instance.StrangerWorld);
		}
		ModelBase<OnlineModel>.Instance.SetHallShowCanJoin(false);
		ModelBase<OnlineModel>.Instance.SetHallShowFriend(false);
		ModelBase<OnlineModel>.Instance.HallViewIsShowSearching = false;
		this.OnRefreshPermissionsSetting();
		ModelBase<FriendModel>.Instance.ShowingView = new EUiViewName?(this.ViewInfo.Name);
		bool flag = !Singleton<Info>.Instance.IsHomeConsolePlatform();
		if (flag)
		{
			this.FunctionButtonItem = new ButtonAndSpriteItem(base.GetItem(13));
			this.FunctionButtonItem.BindCallback(new Action(this.OnClickClearSearchInputBtn));
		}
		UUIItem item = base.GetItem(13);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		base.GetInputText(12).OnTextChange.Bind(new Action<string>(this.SetClearOrPaste));
		this.SetClearOrPaste(null);
		this.RefreshFilterText();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), "OnlineHallViewRefreshBtnNormal", Array.Empty<object>());
		ControllerBase<KuroSdkController>.Instance.RefreshOnlineHallActivity();
	}

	// Token: 0x060113CF RID: 70607 RVA: 0x004BC83C File Offset: 0x004BAA3C
	protected override void OnAfterShow()
	{
		this.MatchingCountDown.BindOnStopTimer(() => ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() != EInstanceMatchState.Matching);
		this.MatchingCountDown.BindOnClickBtnCancelMatching(delegate
		{
			InstanceDungeonMatchingCountDown matchingCountDown3 = this.MatchingCountDown;
			if (matchingCountDown3 != null)
			{
				matchingCountDown3.PlayAnimation("Close");
			}
			ControllerBase<InstanceDungeonEntranceController>.Instance.CancelMatchRequest();
		});
		InstanceDungeonMatchingCountDown matchingCountDown = this.MatchingCountDown;
		if (matchingCountDown != null)
		{
			matchingCountDown.BindOnAfterCloseAnimation(delegate(string sequenceName)
			{
				if (sequenceName == "Close")
				{
					InstanceDungeonMatchingCountDown matchingCountDown3 = this.MatchingCountDown;
					if (matchingCountDown3 == null)
					{
						return;
					}
					matchingCountDown3.SetUiActive(false);
				}
			});
		}
		if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Matching)
		{
			InstanceDungeonMatchingCountDown matchingCountDown2 = this.MatchingCountDown;
			if (matchingCountDown2 != null)
			{
				matchingCountDown2.PlayAnimation("Start");
			}
			this.MatchingCountDown.StartTimer();
		}
	}

	// Token: 0x060113D0 RID: 70608 RVA: 0x004BC8D5 File Offset: 0x004BAAD5
	protected override void OnBeforeDestroy()
	{
		base.GetExtendToggle(2).OnStateChange.Remove(new Action<EToggleState>(this.OnToggleFriendClicked));
		this.HallLoopScroll = null;
		this.TeamLoopScroll = null;
		this.MatchingCountDown = null;
		this.RemoveRefreshBtnHandle();
	}

	// Token: 0x060113D1 RID: 70609 RVA: 0x004BC910 File Offset: 0x004BAB10
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshPermissionsSetting, new Action(this.OnRefreshPermissionsSetting));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshWorldList, new Action(this.OnRefreshWorldList));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshOnlineTeamList, new Action(this.OnRefreshTeamList));
		Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingBegin, new Action(this.OnMatchingBegin));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnSearchWorld, new Action<int>(this.CallBackSearchWorld));
	}

	// Token: 0x060113D2 RID: 70610 RVA: 0x004BC9C8 File Offset: 0x004BABC8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshPermissionsSetting, new Action(this.OnRefreshPermissionsSetting));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshWorldList, new Action(this.OnRefreshWorldList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshOnlineTeamList, new Action(this.OnRefreshTeamList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingBegin, new Action(this.OnMatchingBegin));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSearchWorld, new Action<int>(this.CallBackSearchWorld));
	}

	// Token: 0x060113D3 RID: 70611 RVA: 0x004BCA80 File Offset: 0x004BAC80
	private void InitTitle()
	{
		if (!ModelBase<OnlineModel>.Instance.GetIsTeamModel())
		{
			base.GetExtendToggle(2).OnStateChange.Add(new Action<EToggleState>(this.OnToggleFriendClicked));
			return;
		}
		base.GetItem(8).SetUIActive(false);
		this.RefreshTeamTitleText().Forget();
		bool isMyTeam = ModelBase<OnlineModel>.Instance.GetIsMyTeam();
		UUIButtonComponent button = base.GetButton(1);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(isMyTeam);
	}

	// Token: 0x060113D4 RID: 70612 RVA: 0x004BCAFC File Offset: 0x004BACFC
	private UniTask RefreshTeamTitleText()
	{
		OnlineHallView.<RefreshTeamTitleText>d__17 <RefreshTeamTitleText>d__;
		<RefreshTeamTitleText>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTeamTitleText>d__.<>4__this = this;
		<RefreshTeamTitleText>d__.<>1__state = -1;
		<RefreshTeamTitleText>d__.<>t__builder.Start<OnlineHallView.<RefreshTeamTitleText>d__17>(ref <RefreshTeamTitleText>d__);
		return <RefreshTeamTitleText>d__.<>t__builder.Task;
	}

	// Token: 0x060113D5 RID: 70613 RVA: 0x004BCB40 File Offset: 0x004BAD40
	private void InitWorldList()
	{
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(4);
		if (!ModelBase<OnlineModel>.Instance.GetIsTeamModel())
		{
			AUIBaseActor gridActor = base.GetItem(5).GetOwner() as AUIBaseActor;
			this.HallLoopScroll = new LoopScrollView<OnlineHallItem, OnlineHallData>(loopScrollViewComponent, gridActor, new Func<OnlineHallItem>(this.ProxyCreateHallItemFunction), true);
			return;
		}
		AUIBaseActor gridActor2 = base.GetItem(5).GetOwner() as AUIBaseActor;
		this.TeamLoopScroll = new LoopScrollView<OnlineTeamItem, OnlineTeamData>(loopScrollViewComponent, gridActor2, new Func<OnlineTeamItem>(this.ProxyCreateTeamItemFunction), true);
	}

	// Token: 0x060113D6 RID: 70614 RVA: 0x004BCBBC File Offset: 0x004BADBC
	[return: Nullable(new byte[]
	{
		0,
		2,
		1
	})]
	private UniTask<List<OnlineHallData>> GetFinalHallData([Nullable(new byte[]
	{
		2,
		1
	})] IReadOnlyList<OnlineHallData> data)
	{
		OnlineHallView.<GetFinalHallData>d__19 <GetFinalHallData>d__;
		<GetFinalHallData>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<OnlineHallData>>.Create();
		<GetFinalHallData>d__.data = data;
		<GetFinalHallData>d__.<>1__state = -1;
		<GetFinalHallData>d__.<>t__builder.Start<OnlineHallView.<GetFinalHallData>d__19>(ref <GetFinalHallData>d__);
		return <GetFinalHallData>d__.<>t__builder.Task;
	}

	// Token: 0x060113D7 RID: 70615 RVA: 0x004BCBFF File Offset: 0x004BADFF
	private void RefreshHallList([Nullable(new byte[]
	{
		2,
		1
	})] IReadOnlyList<OnlineHallData> data)
	{
		this.OnRefreshHallList(data).Forget();
	}

	// Token: 0x060113D8 RID: 70616 RVA: 0x004BCC10 File Offset: 0x004BAE10
	private UniTask OnRefreshHallList([Nullable(new byte[]
	{
		2,
		1
	})] IReadOnlyList<OnlineHallData> data)
	{
		OnlineHallView.<OnRefreshHallList>d__21 <OnRefreshHallList>d__;
		<OnRefreshHallList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnRefreshHallList>d__.<>4__this = this;
		<OnRefreshHallList>d__.data = data;
		<OnRefreshHallList>d__.<>1__state = -1;
		<OnRefreshHallList>d__.<>t__builder.Start<OnlineHallView.<OnRefreshHallList>d__21>(ref <OnRefreshHallList>d__);
		return <OnRefreshHallList>d__.<>t__builder.Task;
	}

	// Token: 0x060113D9 RID: 70617 RVA: 0x004BCC5C File Offset: 0x004BAE5C
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private UniTask<List<OnlineTeamData>> GetFinalTeamData(IReadOnlyList<OnlineTeamData> data)
	{
		OnlineHallView.<GetFinalTeamData>d__22 <GetFinalTeamData>d__;
		<GetFinalTeamData>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<OnlineTeamData>>.Create();
		<GetFinalTeamData>d__.data = data;
		<GetFinalTeamData>d__.<>1__state = -1;
		<GetFinalTeamData>d__.<>t__builder.Start<OnlineHallView.<GetFinalTeamData>d__22>(ref <GetFinalTeamData>d__);
		return <GetFinalTeamData>d__.<>t__builder.Task;
	}

	// Token: 0x060113DA RID: 70618 RVA: 0x004BCCA0 File Offset: 0x004BAEA0
	private UniTask FilterHallDataAndRefresh(IReadOnlyList<OnlineTeamData> data)
	{
		OnlineHallView.<FilterHallDataAndRefresh>d__23 <FilterHallDataAndRefresh>d__;
		<FilterHallDataAndRefresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FilterHallDataAndRefresh>d__.<>4__this = this;
		<FilterHallDataAndRefresh>d__.data = data;
		<FilterHallDataAndRefresh>d__.<>1__state = -1;
		<FilterHallDataAndRefresh>d__.<>t__builder.Start<OnlineHallView.<FilterHallDataAndRefresh>d__23>(ref <FilterHallDataAndRefresh>d__);
		return <FilterHallDataAndRefresh>d__.<>t__builder.Task;
	}

	// Token: 0x060113DB RID: 70619 RVA: 0x004BCCEB File Offset: 0x004BAEEB
	private void RefreshTeamList(IReadOnlyList<OnlineTeamData> data)
	{
		this.FilterHallDataAndRefresh(data).Forget();
	}

	// Token: 0x060113DC RID: 70620 RVA: 0x004BCCF9 File Offset: 0x004BAEF9
	private void RefreshFilterText()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), ModelBase<OnlineModel>.Instance.HallViewIsShowSearching ? "Online_ResetSearch" : "Online_Search", Array.Empty<object>());
	}

	// Token: 0x060113DD RID: 70621 RVA: 0x004BCD2A File Offset: 0x004BAF2A
	private OnlineHallItem ProxyCreateHallItemFunction()
	{
		return new OnlineHallItem(this.ViewInfo.Name);
	}

	// Token: 0x060113DE RID: 70622 RVA: 0x004BCD3C File Offset: 0x004BAF3C
	private OnlineTeamItem ProxyCreateTeamItemFunction()
	{
		return new OnlineTeamItem();
	}

	// Token: 0x060113DF RID: 70623 RVA: 0x004BCD44 File Offset: 0x004BAF44
	private void OnToggleFriendClicked(EToggleState state)
	{
		ModelBase<OnlineModel>.Instance.HallViewIsShowSearching = false;
		base.GetInputText(12).SetText("", false);
		this.SetClearOrPaste(null);
		this.RefreshFilterText();
		if (state == EToggleState.ETT_Checked)
		{
			ModelBase<OnlineModel>.Instance.SetHallShowFriend(true);
			IReadOnlyList<OnlineHallData> data;
			if (!ModelBase<OnlineModel>.Instance.ShowCanJoin)
			{
				data = ModelBase<OnlineModel>.Instance.FriendWorld;
			}
			else
			{
				IReadOnlyList<OnlineHallData> readOnlyList = ModelBase<OnlineModel>.Instance.GetCanJoinFormFriend();
				data = readOnlyList;
			}
			this.RefreshHallList(data);
		}
		if (state == EToggleState.ETT_UnChecked)
		{
			ModelBase<OnlineModel>.Instance.SetHallShowFriend(false);
			IReadOnlyList<OnlineHallData> data2;
			if (!ModelBase<OnlineModel>.Instance.ShowCanJoin)
			{
				data2 = ModelBase<OnlineModel>.Instance.StrangerWorld;
			}
			else
			{
				IReadOnlyList<OnlineHallData> readOnlyList = ModelBase<OnlineModel>.Instance.GetCanJoinFormStranger();
				data2 = readOnlyList;
			}
			this.RefreshHallList(data2);
		}
	}

	// Token: 0x060113E0 RID: 70624 RVA: 0x004BCDED File Offset: 0x004BAFED
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x060113E1 RID: 70625 RVA: 0x004BCDF6 File Offset: 0x004BAFF6
	private void OnClickPermissionBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineSettingView, null, null);
	}

	// Token: 0x060113E2 RID: 70626 RVA: 0x004BCE0C File Offset: 0x004BB00C
	private void OnRefreshPermissionsSetting()
	{
		UUIText text = base.GetText(7);
		string textTableId = "PermissionsSetting_" + ((int)ModelBase<OnlineModel>.Instance.CurrentPermissionsSetting).ToString();
		Singleton<LguiUtil>.Instance.SetLocalText(text, textTableId, Array.Empty<object>());
		ControllerBase<KuroSdkController>.Instance.RefreshOnlineHallActivity();
	}

	// Token: 0x060113E3 RID: 70627 RVA: 0x004BCE59 File Offset: 0x004BB059
	private void OnRefreshWorldList()
	{
		if (base.GetExtendToggle(2).ToggleState == EToggleState.ETT_Checked)
		{
			this.RefreshHallList(ModelBase<OnlineModel>.Instance.FriendWorld);
			return;
		}
		this.RefreshHallList(ModelBase<OnlineModel>.Instance.StrangerWorld);
	}

	// Token: 0x060113E4 RID: 70628 RVA: 0x004BCE8B File Offset: 0x004BB08B
	private void OnRefreshTeamList()
	{
		this.RefreshTeamList(ModelBase<OnlineModel>.Instance.GetTeamList());
		this.InitTitle();
	}

	// Token: 0x060113E5 RID: 70629 RVA: 0x004BCEA4 File Offset: 0x004BB0A4
	private void OnMatchingChange()
	{
		EInstanceMatchState matchingState = ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState();
		if (matchingState == EInstanceMatchState.Default)
		{
			InstanceDungeonMatchingCountDown matchingCountDown = this.MatchingCountDown;
			if (matchingCountDown != null && matchingCountDown.GetActive())
			{
				InstanceDungeonMatchingCountDown matchingCountDown2 = this.MatchingCountDown;
				if (matchingCountDown2 == null)
				{
					return;
				}
				matchingCountDown2.PlayAnimation("Close");
				return;
			}
		}
		else if (matchingState == EInstanceMatchState.MatchConfirm)
		{
			InstanceDungeonMatchingCountDown matchingCountDown3 = this.MatchingCountDown;
			if (matchingCountDown3 != null && matchingCountDown3.GetActive())
			{
				InstanceDungeonMatchingCountDown matchingCountDown4 = this.MatchingCountDown;
				if (matchingCountDown4 == null)
				{
					return;
				}
				matchingCountDown4.PlayAnimation("Close");
				return;
			}
		}
		else if (matchingState == EInstanceMatchState.Matching)
		{
			InstanceDungeonMatchingCountDown matchingCountDown5 = this.MatchingCountDown;
			if (matchingCountDown5 != null)
			{
				matchingCountDown5.PlayAnimation("Start");
			}
			this.MatchingCountDown.SetMatchingTime(0);
			this.MatchingCountDown.BindOnStopTimer(() => ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() != EInstanceMatchState.Matching);
			this.MatchingCountDown.StartTimer();
		}
	}

	// Token: 0x060113E6 RID: 70630 RVA: 0x004BCF78 File Offset: 0x004BB178
	private void OnMatchingBegin()
	{
		InstanceDungeonMatchingCountDown matchingCountDown = this.MatchingCountDown;
		if (matchingCountDown != null)
		{
			matchingCountDown.PlayAnimation("Start");
		}
		this.MatchingCountDown.SetMatchingTime(0);
		this.MatchingCountDown.BindOnStopTimer(() => ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() != EInstanceMatchState.Matching);
		this.MatchingCountDown.StartTimer();
	}

	// Token: 0x060113E7 RID: 70631 RVA: 0x004BCFDC File Offset: 0x004BB1DC
	[NullableContext(2)]
	private void SetClearOrPaste(string _)
	{
		if (this.FunctionButtonItem == null)
		{
			return;
		}
		if (base.GetInputText(12).GetText() == "")
		{
			this.FunctionButtonItem.RefreshSprite("SP_Paste");
			return;
		}
		this.FunctionButtonItem.RefreshSprite("SP_Clear");
	}

	// Token: 0x060113E8 RID: 70632 RVA: 0x004BD02C File Offset: 0x004BB22C
	private void OnClickClearSearchInputBtn()
	{
		UUITextInputComponent inputText = base.GetInputText(12);
		if (inputText.GetText() == "")
		{
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				string pasteTarget = "";
				string pasteTargetRef = string.Empty;
				UKuroCloudGameWrapper.ClipBoardPaste();
				TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					ULGUIBPLibrary.ClipBoardPaste(ref pasteTargetRef);
					pasteTarget = pasteTargetRef;
					inputText.SetText(pasteTarget, false);
				}, 200f, null, null, true, 1f);
			}
			else
			{
				string empty = string.Empty;
				ULGUIBPLibrary.ClipBoardPaste(ref empty);
				string inText = empty;
				inputText.SetText(inText, false);
			}
		}
		else
		{
			inputText.SetText("", false);
		}
		this.SetClearOrPaste(null);
	}

	// Token: 0x060113E9 RID: 70633 RVA: 0x004BD0F0 File Offset: 0x004BB2F0
	private void OnClickSearchConfirmBtn()
	{
		if (ModelBase<OnlineModel>.Instance.HallViewIsShowSearching)
		{
			ModelBase<OnlineModel>.Instance.HallViewIsShowSearching = false;
			base.GetButton(15).RootUIComp.Get().SetUIActive(true);
			base.GetInputText(12).SetText("", false);
			this.SetClearOrPaste(null);
			this.RefreshFilterText();
			this.RefreshHallList((base.GetExtendToggle(2).ToggleState == EToggleState.ETT_Checked) ? ModelBase<OnlineModel>.Instance.FriendWorld : ModelBase<OnlineModel>.Instance.StrangerWorld);
			return;
		}
		string text = base.GetInputText(12).GetText();
		if (text.Length > 0)
		{
			ControllerBase<OnlineController>.Instance.LobbyQueryPlayersRequest(int.Parse(text));
			return;
		}
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("OnlineUserIdIsNull", Array.Empty<object>());
	}

	// Token: 0x060113EA RID: 70634 RVA: 0x004BD1B8 File Offset: 0x004BB3B8
	private void OnClickRefreshBtnBtn()
	{
		if (this.NextCanClickRefreshBtnLeftTime > 0)
		{
			return;
		}
		this.NextCanClickRefreshBtnLeftTime = 5;
		UUIButtonComponent refreshBtn = base.GetButton(15);
		refreshBtn.SetSelfInteractive(false);
		this.RemoveRefreshBtnHandle();
		UUIText text = base.GetText(16);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "OnlineHallViewRefreshBtnCd", new <>z__ReadOnlySingleElementList<object>(this.NextCanClickRefreshBtnLeftTime.ToString()));
		this.RefreshBtnHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.NextCanClickRefreshBtnLeftTime--;
			if (this.NextCanClickRefreshBtnLeftTime <= 0)
			{
				refreshBtn.SetSelfInteractive(true);
				this.RemoveRefreshBtnHandle();
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "OnlineHallViewRefreshBtnNormal", Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "OnlineHallViewRefreshBtnCd", new <>z__ReadOnlySingleElementList<object>(this.NextCanClickRefreshBtnLeftTime.ToString()));
		}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		ControllerBase<OnlineController>.Instance.RefreshWorldList().ContinueWith(delegate(bool isSuccess)
		{
			if (!isSuccess)
			{
				LoopScrollView<OnlineHallItem, OnlineHallData> hallLoopScroll = this.HallLoopScroll;
				if (hallLoopScroll == null)
				{
					return;
				}
				UUIInturnAnimController uiAnimController = hallLoopScroll.GetUiAnimController();
				if (uiAnimController == null)
				{
					return;
				}
				uiAnimController.Play("Start", -1, false);
			}
		}).Forget();
	}

	// Token: 0x060113EB RID: 70635 RVA: 0x004BD285 File Offset: 0x004BB485
	private void RemoveRefreshBtnHandle()
	{
		if (this.RefreshBtnHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RefreshBtnHandle);
		}
		this.RefreshBtnHandle = null;
	}

	// Token: 0x060113EC RID: 70636 RVA: 0x004BD2A8 File Offset: 0x004BB4A8
	private void CallBackSearchWorld(int i)
	{
		base.GetButton(15).RootUIComp.Get().SetUIActive(false);
		IReadOnlyList<OnlineHallData> searchResult = ModelBase<OnlineModel>.Instance.SearchResult;
		if (searchResult != null)
		{
			this.RefreshHallList(searchResult);
			ModelBase<OnlineModel>.Instance.HallViewIsShowSearching = true;
		}
		this.RefreshFilterText();
	}

	// Token: 0x0400877E RID: 34686
	private const int REFERSH_BTN_CD = 5;

	// Token: 0x0400877F RID: 34687
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<OnlineHallItem, OnlineHallData> HallLoopScroll;

	// Token: 0x04008780 RID: 34688
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<OnlineTeamItem, OnlineTeamData> TeamLoopScroll;

	// Token: 0x04008781 RID: 34689
	[Nullable(2)]
	private InstanceDungeonMatchingCountDown MatchingCountDown;

	// Token: 0x04008782 RID: 34690
	[Nullable(2)]
	private ButtonAndSpriteItem FunctionButtonItem;

	// Token: 0x04008783 RID: 34691
	private int NextCanClickRefreshBtnLeftTime;

	// Token: 0x04008784 RID: 34692
	[Nullable(2)]
	private TimerHandle RefreshBtnHandle;

	// Token: 0x02008656 RID: 34390
	[NullableContext(0)]
	private enum EOnlineHallViewComponents
	{
		// Token: 0x0402D6FA RID: 186106
		BackBtn,
		// Token: 0x0402D6FB RID: 186107
		PermissionsSettingBtn,
		// Token: 0x0402D6FC RID: 186108
		TogFriend,
		// Token: 0x0402D6FD RID: 186109
		FilterBtn,
		// Token: 0x0402D6FE RID: 186110
		OnlineWorldList,
		// Token: 0x0402D6FF RID: 186111
		OnlineWorldListItem,
		// Token: 0x0402D700 RID: 186112
		EmptyTips,
		// Token: 0x0402D701 RID: 186113
		SettingText,
		// Token: 0x0402D702 RID: 186114
		HallTopItem,
		// Token: 0x0402D703 RID: 186115
		TeamTopItem,
		// Token: 0x0402D704 RID: 186116
		TeamPlayerNumberText,
		// Token: 0x0402D705 RID: 186117
		MatchingItem,
		// Token: 0x0402D706 RID: 186118
		SearchUIDTextInput,
		// Token: 0x0402D707 RID: 186119
		UIDClearOrPasteBtn,
		// Token: 0x0402D708 RID: 186120
		FilterText,
		// Token: 0x0402D709 RID: 186121
		RefreshBtn,
		// Token: 0x0402D70A RID: 186122
		RefreshBtnText
	}
}
