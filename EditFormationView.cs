using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B51 RID: 6993
[NullableContext(1)]
[Nullable(0)]
public class EditFormationView : UiTickViewBase
{
	// Token: 0x0600CA36 RID: 51766 RVA: 0x0035C0F4 File Offset: 0x0035A2F4
	public EditFormationView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600CA37 RID: 51767 RVA: 0x0035C148 File Offset: 0x0035A348
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUISpriteTransition)),
			new ValueTuple<int, Type>(11, typeof(UUISpriteTransition)),
			new ValueTuple<int, Type>(12, typeof(UUISpriteTransition)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickExitSkill)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickConfirm)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickClose)),
			new ValueTuple<int, Delegate>(9, new Action(this.OnClickQuickSelect))
		};
	}

	// Token: 0x0600CA38 RID: 51768 RVA: 0x0035C334 File Offset: 0x0035A534
	protected override void OnStart()
	{
		base.OnStart();
		ModelBase<RoleModel>.Instance.StartGamePlayRoleEdit(ESkillBranchCacheType.Normal);
	}

	// Token: 0x0600CA39 RID: 51769 RVA: 0x0035C348 File Offset: 0x0035A548
	protected override UniTask OnBeforeStartAsync()
	{
		EditFormationView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<EditFormationView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CA3A RID: 51770 RVA: 0x0035C38C File Offset: 0x0035A58C
	protected override void OnBeforeShow()
	{
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			int index = this.EditFormationId - 1;
			this.TabComponent.SelectToggleByIndex(index, false);
			this.TabComponent.ScrollToToggleByIndex(index);
			int index2 = ModelBase<EditFormationModel>.Instance.GetCurrentFormationId.Value - 1;
			this.TabComponent.GetTabItemByIndex(index2).ShowTeamBattleTips();
		}
		this.RefreshAllRoleView(this.EditFormationId, null);
		Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableFrameGeneration("EditFormationView");
	}

	// Token: 0x0600CA3B RID: 51771 RVA: 0x0035C40C File Offset: 0x0035A60C
	protected override void OnTick(float delta)
	{
		foreach (FormationRoleSlot formationRoleSlot in this.FormationRoleViewList)
		{
			(formationRoleSlot as FormationRoleView).OnTick(delta);
		}
	}

	// Token: 0x0600CA3C RID: 51772 RVA: 0x0035C464 File Offset: 0x0035A664
	protected override void OnAfterHide()
	{
		Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableFrameGeneration("EditFormationView");
	}

	// Token: 0x0600CA3D RID: 51773 RVA: 0x0035C475 File Offset: 0x0035A675
	protected override void OnAddEventListener()
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshPlayerPing, new Action<int, ENetPingState>(this.OnRefreshPlayerPing));
		}
	}

	// Token: 0x0600CA3E RID: 51774 RVA: 0x0035C49F File Offset: 0x0035A69F
	protected override void OnRemoveEventListener()
	{
		if (Singleton<EventSystem>.Instance.Has(EEventName.OnRefreshPlayerPing, new Action<int, ENetPingState>(this.OnRefreshPlayerPing)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshPlayerPing, new Action<int, ENetPingState>(this.OnRefreshPlayerPing));
		}
	}

	// Token: 0x0600CA3F RID: 51775 RVA: 0x0035C4DC File Offset: 0x0035A6DC
	protected override void OnBeforeDestroy()
	{
		foreach (FormationRoleSlot formationRoleSlot in this.FormationRoleViewList)
		{
			formationRoleSlot.Reset();
		}
		this.FormationRoleViewList.Clear();
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		this.WaitingClose = false;
		if (this.DelayLoadingTimer != null)
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.DelayLoadingTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DelayLoadingTimer);
			}
			this.DelayLoadingTimer = null;
		}
		if (this.AutoCloseTimer != null)
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.AutoCloseTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.AutoCloseTimer);
			}
			this.AutoCloseTimer = null;
		}
		ControllerBase<FormationDragController>.Instance.ClearDragData();
	}

	// Token: 0x0600CA40 RID: 51776 RVA: 0x0035C5C8 File Offset: 0x0035A7C8
	[NullableContext(2)]
	private void OnRefreshRoleView(int[] needRefreshPosition = null)
	{
		if (base.IsDestroyOrDestroying)
		{
			return;
		}
		this.RefreshConfirmButton();
		this.RefreshAllRoleView(this.EditFormationId, needRefreshPosition);
	}

	// Token: 0x0600CA41 RID: 51777 RVA: 0x0035C5E6 File Offset: 0x0035A7E6
	private void ExchangeRoleCallBack(int position1, int position2, int roleId1, int roleId2)
	{
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		instance.SetEditingRoleId(this.EditFormationId, position1, roleId1, true);
		instance.SetEditingRoleId(this.EditFormationId, position2, roleId2, true);
		this.OnRefreshRoleView(new int[]
		{
			position1,
			position2
		});
	}

	// Token: 0x0600CA42 RID: 51778 RVA: 0x0035C624 File Offset: 0x0035A824
	private void OnRefreshPlayerPing(int playerId, ENetPingState ping)
	{
		foreach (FormationRoleSlot formationRoleSlot in this.FormationRoleViewList)
		{
			FormationRoleView formationRoleView = formationRoleSlot as FormationRoleView;
			if (formationRoleView != null && formationRoleView.GetPlayerId() == playerId)
			{
				formationRoleView.RefreshPing(ping);
			}
		}
	}

	// Token: 0x0600CA43 RID: 51779 RVA: 0x0035C688 File Offset: 0x0035A888
	private void OnClickConfirm()
	{
		if (this.WaitingClose)
		{
			return;
		}
		if (!this.IsAllowClose())
		{
			return;
		}
		this.RequestOnConfirm().Forget();
		this.ShowLoading();
	}

	// Token: 0x0600CA44 RID: 51780 RVA: 0x0035C6B0 File Offset: 0x0035A8B0
	private UniTask RequestOnConfirm()
	{
		EditFormationView.<RequestOnConfirm>d__27 <RequestOnConfirm>d__;
		<RequestOnConfirm>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestOnConfirm>d__.<>4__this = this;
		<RequestOnConfirm>d__.<>1__state = -1;
		<RequestOnConfirm>d__.<>t__builder.Start<EditFormationView.<RequestOnConfirm>d__27>(ref <RequestOnConfirm>d__);
		return <RequestOnConfirm>d__.<>t__builder.Task;
	}

	// Token: 0x0600CA45 RID: 51781 RVA: 0x0035C6F4 File Offset: 0x0035A8F4
	private void ShowLoading()
	{
		if (this.DelayLoadingTimer == null)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("EditFormationViewClosing", true);
			base.GetItem(14).SetUIActive(true);
			this.DelayLoadingTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.SetCloseButtonVisible(false);
				base.GetButton(1).RootUIComp.Get().SetUIActive(false);
				base.GetItem(13).SetUIActive(true);
			}, 500f, null, null, true, 1f);
		}
		if (this.AutoCloseTimer == null)
		{
			this.AutoCloseTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer("EditFormationViewClosing", false);
				this.CloseEditFormationView();
			}, 30000f, null, null, true, 1f);
		}
	}

	// Token: 0x0600CA46 RID: 51782 RVA: 0x0035C784 File Offset: 0x0035A984
	private UniTask WaitEntityAddBeforeClose()
	{
		EditFormationView.<WaitEntityAddBeforeClose>d__29 <WaitEntityAddBeforeClose>d__;
		<WaitEntityAddBeforeClose>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitEntityAddBeforeClose>d__.<>4__this = this;
		<WaitEntityAddBeforeClose>d__.<>1__state = -1;
		<WaitEntityAddBeforeClose>d__.<>t__builder.Start<EditFormationView.<WaitEntityAddBeforeClose>d__29>(ref <WaitEntityAddBeforeClose>d__);
		return <WaitEntityAddBeforeClose>d__.<>t__builder.Task;
	}

	// Token: 0x0600CA47 RID: 51783 RVA: 0x0035C7C7 File Offset: 0x0035A9C7
	private void CloseEditFormationView()
	{
		if (this.IsResetToBattle)
		{
			Singleton<UiManager>.Instance.ResetToBattleView(null);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600CA48 RID: 51784 RVA: 0x0035C7E4 File Offset: 0x0035A9E4
	private void OnClickQuickSelect()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.QuickRoleSelectView))
		{
			return;
		}
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		List<int> list = new List<int>();
		int[] editingRoleIdList = instance.GetEditingRoleIdList(this.EditFormationId);
		if (editingRoleIdList != null)
		{
			for (int i = 0; i < editingRoleIdList.Length; i++)
			{
				list.Add(editingRoleIdList[i]);
			}
		}
		List<RoleDataBase> roleDataList = ModelBase<RoleModel>.Instance.GetRoleDataList(this.CanShowSpecialTrialRole);
		QuickRoleSelectViewData quickRoleSelectViewData = new QuickRoleSelectViewData(EFilterSortGroupId.EditFormation, list.ToArray(), roleDataList);
		quickRoleSelectViewData.CanConfirm = new Func<int[], bool>(this.CanQuickSelectConfirm);
		quickRoleSelectViewData.OnConfirm = new Action<int[]>(this.OnQuickSelectConfirm);
		quickRoleSelectViewData.OnBack = new Action(this.OnSelectBack);
		quickRoleSelectViewData.OnHideFinish = new Action(this.OnQuickSelectHideFinishCallBack);
		quickRoleSelectViewData.CanSelectRole = new Func<int, int[], bool>(this.CanSelectRole);
		quickRoleSelectViewData.CanUseSpecialTrialRole = this.CanUseSpecialTrailRole;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuickRoleSelectView, quickRoleSelectViewData, delegate(bool isSuccess, int viewId)
		{
			if (isSuccess)
			{
				base.AddChildViewById(viewId);
			}
		});
		this.SetCloseButtonVisible(false);
	}

	// Token: 0x0600CA49 RID: 51785 RVA: 0x0035C8E4 File Offset: 0x0035AAE4
	private bool CanQuickSelectConfirm(int[] roleIdList)
	{
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		int editFormationId = this.EditFormationId;
		int? getCurrentFormationId = instance.GetCurrentFormationId;
		if (!(editFormationId == getCurrentFormationId.GetValueOrDefault() & getCurrentFormationId != null))
		{
			return true;
		}
		if (roleIdList.Length == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamRoleEmpty", Array.Empty<object>());
			return false;
		}
		bool flag = true;
		for (int i = 0; i < roleIdList.Length; i++)
		{
			if (!instance.IsRoleDead(roleIdList[i]))
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditFormationAllDead", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x0600CA4A RID: 51786 RVA: 0x0035C96C File Offset: 0x0035AB6C
	private bool CanSelectRole(int roleId, int[] roleIdList)
	{
		if (RoleUtils.HasMultiTrialRole(roleId, roleIdList, null))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamMultiTrialRole", Array.Empty<object>());
			return false;
		}
		if (RoleUtils.HasSameRole(roleId, roleIdList, null))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamSameRole", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x0600CA4B RID: 51787 RVA: 0x0035C9CC File Offset: 0x0035ABCC
	private void OnQuickSelectConfirm(int[] roleIdList)
	{
		this.SetCloseButtonVisible(true);
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		for (int i = 0; i < 3; i++)
		{
			int roleId = (i < roleIdList.Length) ? roleIdList[i] : 0;
			int editPosition = i + 1;
			instance.SetEditingRoleId(this.EditFormationId, editPosition, roleId, false);
		}
	}

	// Token: 0x0600CA4C RID: 51788 RVA: 0x0035CA13 File Offset: 0x0035AC13
	private void OnClickClose()
	{
		if (this.WaitingClose)
		{
			return;
		}
		if (this.EditFormationId == this.GoBattleFormationId && !this.IsAllowClose())
		{
			return;
		}
		this.RequestOnClose().Forget();
		this.ShowLoading();
	}

	// Token: 0x0600CA4D RID: 51789 RVA: 0x0035CA48 File Offset: 0x0035AC48
	private UniTask RequestOnClose()
	{
		EditFormationView.<RequestOnClose>d__36 <RequestOnClose>d__;
		<RequestOnClose>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestOnClose>d__.<>4__this = this;
		<RequestOnClose>d__.<>1__state = -1;
		<RequestOnClose>d__.<>t__builder.Start<EditFormationView.<RequestOnClose>d__36>(ref <RequestOnClose>d__);
		return <RequestOnClose>d__.<>t__builder.Task;
	}

	// Token: 0x0600CA4E RID: 51790 RVA: 0x0035CA8C File Offset: 0x0035AC8C
	private void OnClickExitSkill()
	{
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ExitSkillView))
		{
			ExitSkillViewData exitSkillViewData = new ExitSkillViewData();
			foreach (FormationRoleSlot formationRoleSlot in this.FormationRoleViewList)
			{
				FormationRoleView formationRoleView = formationRoleSlot as FormationRoleView;
				if (formationRoleView != null)
				{
					int? configId = formationRoleView.GetConfigId();
					int? onlineIndex = formationRoleView.GetOnlineIndex();
					int playerId = formationRoleView.GetPlayerId();
					exitSkillViewData.AddData(configId.GetValueOrDefault(), onlineIndex.GetValueOrDefault(), playerId);
				}
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ExitSkillView, exitSkillViewData, null);
		}
	}

	// Token: 0x0600CA4F RID: 51791 RVA: 0x0035CB38 File Offset: 0x0035AD38
	private void OnSelectBack()
	{
		this.SetCloseButtonVisible(true);
	}

	// Token: 0x0600CA50 RID: 51792 RVA: 0x0035CB44 File Offset: 0x0035AD44
	private bool ConfirmCheckFunction(int roleId)
	{
		if (this.IsNeedRevive(roleId))
		{
			ControllerBase<BuffItemControl>.Instance.TryUseResurrectionItem(roleId);
			return false;
		}
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		bool flag = instance.IsInEditingFormation(this.EditFormationId, roleId);
		int? getCurrentFormationId = instance.GetCurrentFormationId;
		int editFormationId = this.EditFormationId;
		bool flag2 = getCurrentFormationId.GetValueOrDefault() == editFormationId & getCurrentFormationId != null;
		int[] editingRoleIdList = instance.GetEditingRoleIdList(this.EditFormationId);
		bool flag3 = editingRoleIdList != null && editingRoleIdList.Length == 1;
		if (flag2 && flag && flag3)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamRoleEmpty", Array.Empty<object>());
			return false;
		}
		int value = this.EditPosition - 1;
		if (RoleUtils.HasMultiTrialRole(roleId, editingRoleIdList, new int?(value)))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamMultiTrialRole", Array.Empty<object>());
			return false;
		}
		if (RoleUtils.HasSameRole(roleId, editingRoleIdList, new int?(value)))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamSameRole", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x0600CA51 RID: 51793 RVA: 0x0035CC2C File Offset: 0x0035AE2C
	private unsafe void OnEnsureFormation(int roleId)
	{
		this.SetCloseButtonVisible(true);
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		int editingRolePosition = instance.GetEditingRolePosition(this.EditFormationId, roleId);
		int editPosition = this.EditPosition;
		if (!instance.IsInEditingFormation(this.EditFormationId, roleId))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Formation;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "编队角色加入";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("位置", editPosition);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("roleId", roleId);
			instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			instance.SetEditingRoleId(this.EditFormationId, this.EditPosition, roleId, true);
			this.PlayJoinTeamAudio(roleId);
			return;
		}
		if (instance.GetEditingRoleId(this.EditFormationId, editPosition) == 0)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Formation;
			ELogAuthor author2 = ELogAuthor.LYY;
			string message2 = "编队角色换下";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("位置", editingRolePosition);
			instance3.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			instance.SetEditingRoleId(this.EditFormationId, editingRolePosition, 0, true);
			return;
		}
		if (editingRolePosition == editPosition)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Formation;
			ELogAuthor author3 = ELogAuthor.LYY;
			string message3 = "编队角色位置相同，换下";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("位置", editPosition);
			instance4.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			instance.SetEditingRoleId(this.EditFormationId, editPosition, 0, true);
			return;
		}
		int editingRoleId = instance.GetEditingRoleId(this.EditFormationId, editPosition);
		Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LYY, "编队角色更换", default(ReadOnlySpan<ValueTuple<string, object>>));
		instance.SetEditingRoleId(this.EditFormationId, editPosition, roleId, true);
		instance.SetEditingRoleId(this.EditFormationId, editingRolePosition, editingRoleId, true);
	}

	// Token: 0x0600CA52 RID: 51794 RVA: 0x0035CDBC File Offset: 0x0035AFBC
	private TeamRoleSelectViewData GetRoleSelectViewData()
	{
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		List<RoleDataBase> roleDataList = ModelBase<RoleModel>.Instance.GetRoleDataList(this.CanShowSpecialTrialRole);
		int editingRoleId = instance.GetEditingRoleId(this.EditFormationId, this.EditPosition);
		TeamRoleSelectViewData teamRoleSelectViewData = new TeamRoleSelectViewData(EFilterSortGroupId.EditFormation, editingRoleId, roleDataList, new Action<int>(this.OnEnsureFormation), new Action(this.OnSelectBack), new int?(this.EditPosition), null);
		teamRoleSelectViewData.SetGetConfirmButtonEnableFunction(new Func<int, bool>(this.GetConfirmButtonEnableFunction));
		teamRoleSelectViewData.SetGetConfirmButtonTextFunction(new Func<int, string>(this.GetConfirmButtonTextFunction));
		teamRoleSelectViewData.SetHideFinishCallBack(delegate
		{
			this.OnRefreshRoleView(null);
		});
		teamRoleSelectViewData.SetConfirmCheckFunction(new Func<int, bool>(this.ConfirmCheckFunction));
		teamRoleSelectViewData.IsNeedRevive = new Func<int, bool>(this.IsNeedReviveFunction);
		teamRoleSelectViewData.CanJoinTeam = new Func<int, bool>(this.CanJoinTeam);
		teamRoleSelectViewData.CanUseSpecialTrialRole = this.CanUseSpecialTrailRole;
		int[] editingRoleIdList = instance.GetEditingRoleIdList(this.EditFormationId);
		teamRoleSelectViewData.FormationRoleList = editingRoleIdList;
		return teamRoleSelectViewData;
	}

	// Token: 0x0600CA53 RID: 51795 RVA: 0x0035CEB4 File Offset: 0x0035B0B4
	private void OnQuickSelectHideFinishCallBack()
	{
		this.OnRefreshRoleView(null);
		this.SetCloseButtonVisible(true);
	}

	// Token: 0x0600CA54 RID: 51796 RVA: 0x0035CEC4 File Offset: 0x0035B0C4
	private bool CanJoinTeam(int roleId)
	{
		return !ModelBase<EditFormationModel>.Instance.IsInEditingFormation(this.EditFormationId, roleId);
	}

	// Token: 0x0600CA55 RID: 51797 RVA: 0x0035CEDA File Offset: 0x0035B0DA
	private bool IsNeedReviveFunction(int roleId)
	{
		return this.IsNeedRevive(roleId);
	}

	// Token: 0x0600CA56 RID: 51798 RVA: 0x0035CEE4 File Offset: 0x0035B0E4
	private bool GetConfirmButtonEnableFunction(int roleConfigId)
	{
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		bool flag = instance.IsInEditingFormation(this.EditFormationId, roleConfigId);
		bool editingRoleIdList = instance.GetEditingRoleIdList(this.EditFormationId) != null;
		bool result = true;
		if (editingRoleIdList && instance.GetEditingRoleId(this.EditFormationId, this.EditPosition) == 0 && flag)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600CA57 RID: 51799 RVA: 0x0035CF30 File Offset: 0x0035B130
	[NullableContext(2)]
	private string GetConfirmButtonTextFunction(int roleConfigId)
	{
		if (roleConfigId == 0)
		{
			return null;
		}
		if (this.IsNeedRevive(roleConfigId))
		{
			return "EditBattleTeamRevive";
		}
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		bool flag = instance.IsInEditingFormation(this.EditFormationId, roleConfigId);
		int editingRolePosition = instance.GetEditingRolePosition(this.EditFormationId, roleConfigId);
		if (instance.GetEditingRoleIdList(this.EditFormationId) == null)
		{
			return "JoinText";
		}
		if (instance.GetEditingRoleId(this.EditFormationId, this.EditPosition) == 0)
		{
			if (flag)
			{
				return "ChangeText";
			}
			return "JoinText";
		}
		else
		{
			if (!flag)
			{
				return "ChangeText";
			}
			if (editingRolePosition < 0)
			{
				return "JoinText";
			}
			if (editingRolePosition == this.EditPosition)
			{
				return "GoDownText";
			}
			return "ChangeText";
		}
	}

	// Token: 0x0600CA58 RID: 51800 RVA: 0x0035CFD4 File Offset: 0x0035B1D4
	private void PlayJoinTeamAudio(int roleId)
	{
		RoleModel instance = ModelBase<RoleModel>.Instance;
		RoleDataBase roleDataBase = (instance != null) ? instance.GetRoleDataById(roleId, true) : null;
		int? num = (roleDataBase != null) ? new int?(roleDataBase.GetRoleSkinId()) : null;
		if (num == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[Game.EditFormationView] 没有皮肤ID";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		AudioConfig instance3 = ConfigBase<AudioConfig>.Instance;
		RoleSkinAudio? roleSkinAudio;
		string text = (instance3 != null) ? ((instance3.GetRoleConfig(num.Value) != null) ? roleSkinAudio.GetValueOrDefault().JoinTeamEvent : null) : null;
		if (text != null)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_fx_spl_team_role_choose");
			Singleton<AudioSystem>.Instance.PostEvent(text);
		}
	}

	// Token: 0x0600CA59 RID: 51801 RVA: 0x0035D09C File Offset: 0x0035B29C
	private void SetCloseButtonVisible(bool bVisible)
	{
		UUIItem uuiitem = base.GetButton(8).GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(bVisible);
	}

	// Token: 0x0600CA5A RID: 51802 RVA: 0x0035D0D8 File Offset: 0x0035B2D8
	private UniTask CreateAllFormationButtons()
	{
		EditFormationView.<CreateAllFormationButtons>d__49 <CreateAllFormationButtons>d__;
		<CreateAllFormationButtons>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateAllFormationButtons>d__.<>4__this = this;
		<CreateAllFormationButtons>d__.<>1__state = -1;
		<CreateAllFormationButtons>d__.<>t__builder.Start<EditFormationView.<CreateAllFormationButtons>d__49>(ref <CreateAllFormationButtons>d__);
		return <CreateAllFormationButtons>d__.<>t__builder.Task;
	}

	// Token: 0x0600CA5B RID: 51803 RVA: 0x0035D11B File Offset: 0x0035B31B
	private EditFormationTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new EditFormationTabItem();
	}

	// Token: 0x0600CA5C RID: 51804 RVA: 0x0035D124 File Offset: 0x0035B324
	[NullableContext(2)]
	private CommonTabData GetCommonData(int index)
	{
		string resourceId = EditFormationDefine.FORMATION_SPRITES[index];
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		int num = index + 1;
		string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById("TeamText");
		CommonTabData commonTabData = new CommonTabData(resourcePath, new CommonTabTitleData(textContentIdById, new object[]
		{
			num
		}), null);
		commonTabData.SetSmallIcon(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_TeamTitle"));
		return commonTabData;
	}

	// Token: 0x0600CA5D RID: 51805 RVA: 0x0035D188 File Offset: 0x0035B388
	private void OnFormationButtonClicked(int index)
	{
		if (this.WaitingClose)
		{
			return;
		}
		int num = index + 1;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Test;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "当点击编队按钮时";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("formationId", num);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.RefreshAllRoleView(num, null);
		this.EditFormationId = num;
		this.RefreshConfirmButton();
	}

	// Token: 0x0600CA5E RID: 51806 RVA: 0x0035D1E4 File Offset: 0x0035B3E4
	private void RefreshConfirmButton()
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return;
		}
		int editFormationId = this.EditFormationId;
		int? getCurrentFormationId = ModelBase<EditFormationModel>.Instance.GetCurrentFormationId;
		bool flag = !(editFormationId == getCurrentFormationId.GetValueOrDefault() & getCurrentFormationId != null);
		bool flag2 = flag;
		if (flag2 && !this.CanUseSpecialTrailRole)
		{
			int[] editingRoleIdList = ModelBase<EditFormationModel>.Instance.GetEditingRoleIdList(this.EditFormationId);
			bool flag3 = false;
			if (editingRoleIdList != null)
			{
				for (int i = 0; i < editingRoleIdList.Length; i++)
				{
					if (RoleUtils.IsSpecialTrialRole(editingRoleIdList[i]))
					{
						flag3 = true;
						break;
					}
				}
			}
			flag2 = !flag3;
		}
		base.GetButton(6).SetSelfInteractive(flag2);
		string textTableId;
		if (flag)
		{
			textTableId = "EditBattleTeamFight";
		}
		else
		{
			textTableId = "EditBattleTeamFighting";
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(7), textTableId, Array.Empty<object>());
	}

	// Token: 0x0600CA5F RID: 51807 RVA: 0x0035D2AC File Offset: 0x0035B4AC
	private void OnAddRoleButtonClicked(int position)
	{
		if (this.WaitingClose)
		{
			return;
		}
		if (!ModelBase<EditFormationModel>.Instance.IsMyPosition(position))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("IsNotMyRole", Array.Empty<object>());
			return;
		}
		this.EditPosition = position;
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.TeamRoleSelectView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TeamRoleSelectView, this.GetRoleSelectViewData(), null);
		}
		this.SetCloseButtonVisible(false);
	}

	// Token: 0x0600CA60 RID: 51808 RVA: 0x0035D31C File Offset: 0x0035B51C
	[NullableContext(2)]
	private void RefreshAllRoleView(int editFormationId, int[] needRefreshPosition = null)
	{
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		UUIItem uuiitem = base.GetButton(1).RootUIComp.Get();
		if (instance.GetEditingRoleIdList(editFormationId).Length == 0)
		{
			foreach (FormationRoleSlot formationRoleSlot in this.FormationRoleViewList)
			{
				FormationRoleView formationRoleView = formationRoleSlot as FormationRoleView;
				if (formationRoleView != null)
				{
					formationRoleView.ResetRole();
				}
			}
			uuiitem.SetUIActive(false);
			return;
		}
		uuiitem.SetUIActive(true);
		bool flag = ControllerBase<GameModeController>.Instance.IsInInstance();
		int i = 1;
		while (i <= 3)
		{
			if (needRefreshPosition == null)
			{
				goto IL_B4;
			}
			bool flag2 = false;
			for (int j = 0; j < needRefreshPosition.Length; j++)
			{
				if (needRefreshPosition[j] == i)
				{
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				goto IL_B4;
			}
			IL_2BD:
			i++;
			continue;
			IL_B4:
			int onlineIndex = 0;
			if (!instance.IsMyPosition(i))
			{
				EditFormationData getCurrentFormationData = instance.GetCurrentFormationData;
				EditFormationRoleData editFormationRoleData = (getCurrentFormationData != null) ? getCurrentFormationData.GetRoleDataByPosition(i) : null;
				if (editFormationRoleData == null)
				{
					this.RefreshRoleView(i, 0, 0, 0, "", 0, 0, "");
					goto IL_2BD;
				}
				int playerId = editFormationRoleData.PlayerId;
				ScenePlayerData scenePlayerData = ModelBase<CreatureModel>.Instance.GetScenePlayerData(playerId);
				if (flag && scenePlayerData == null)
				{
					this.RefreshRoleView(i, 0, 0, 0, "", 0, 0, "");
					goto IL_2BD;
				}
				int num = editFormationRoleData.ConfigId;
				global::WorldTeamPlayerFightInfo worldTeamPlayerFightInfo = ModelBase<OnlineModel>.Instance.GetWorldTeamPlayerFightInfo(playerId);
				int roleSkinId = editFormationRoleData.RoleSkinId;
				int level = editFormationRoleData.Level;
				string name = ((worldTeamPlayerFightInfo != null) ? worldTeamPlayerFightInfo.Name : null) ?? "";
				string thirdPartyOnlineId = ((worldTeamPlayerFightInfo != null) ? worldTeamPlayerFightInfo.ThirdPartyOnlineName : null) ?? "";
				OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId);
				onlineIndex = ((currentTeamListById != null) ? currentTeamListById.PlayerNumber : 1);
				this.RefreshRoleView(i, num, roleSkinId, level, name, onlineIndex, playerId, thirdPartyOnlineId);
				goto IL_2BD;
			}
			else
			{
				RoleModel instance2 = ModelBase<RoleModel>.Instance;
				int num = instance.GetEditingRoleId(editFormationId, i);
				RoleDataBase roleDataById = instance2.GetRoleDataById(num, true);
				if (roleDataById == null)
				{
					this.RefreshRoleView(i, 0, 0, 0, "", 0, 0, "");
					goto IL_2BD;
				}
				RoleLevelData levelData = roleDataById.GetLevelData();
				int roleSkinId2 = roleDataById.GetRoleSkinId();
				int level = levelData.GetLevel();
				int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
				string thirdPartyOnlineId = ModelBase<PlayerInfoModel>.Instance.GetThirdPartyOnlineId() ?? "";
				string name;
				if (ModelBase<GameModeModel>.Instance.IsMulti)
				{
					name = (ModelBase<FunctionModel>.Instance.GetPlayerName() ?? "");
					OnlineTeamData currentTeamListById2 = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId);
					onlineIndex = ((currentTeamListById2 != null) ? currentTeamListById2.PlayerNumber : 1);
				}
				else
				{
					name = instance2.GetRoleName(num, null);
				}
				this.RefreshRoleView(i, num, roleSkinId2, level, name, onlineIndex, playerId, thirdPartyOnlineId);
				goto IL_2BD;
			}
		}
	}

	// Token: 0x0600CA61 RID: 51809 RVA: 0x0035D604 File Offset: 0x0035B804
	private void RefreshRoleView(int position, int roleId = 0, int roleSkinId = 0, int level = 0, string name = "", int onlineIndex = 0, int playerId = 0, string thirdPartyOnlineId = "")
	{
		int num = position - 1;
		FormationRoleSlot formationRoleSlot = this.FormationRoleViewList[num];
		UUISpriteTransition uiSpriteTransition = base.GetUiSpriteTransition(this.ExitSkillIconList[num]);
		string path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_TeamRoleSkillNone");
		if (roleId == 0)
		{
			FormationRoleView formationRoleView = formationRoleSlot as FormationRoleView;
			if (formationRoleView != null)
			{
				formationRoleView.ResetRole();
			}
		}
		else
		{
			FormationRoleView formationRoleView2 = formationRoleSlot as FormationRoleView;
			if (formationRoleView2 != null)
			{
				formationRoleView2.Refresh(roleId, roleSkinId, level, name, onlineIndex, playerId, thirdPartyOnlineId, this.CanUseSpecialTrailRole);
			}
			RoleInfo? roleInfo;
			int? num2 = (ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId) != null) ? new int?(roleInfo.GetValueOrDefault().SkillId) : null;
			if (num2 != null)
			{
				IReadOnlyList<Aki.Config.Skill> skillList = ConfigBase<RoleSkillConfig>.Instance.GetSkillList(num2.Value);
				if (skillList != null)
				{
					for (int i = 0; i < skillList.Count; i++)
					{
						Aki.Config.Skill skill = skillList[i];
						if (skill.SkillType == 11)
						{
							path = skill.Icon;
							break;
						}
					}
				}
			}
		}
		base.SetSpriteTransitionByPath(path, uiSpriteTransition, EUISelectableSelectionState.EUISelectableSelectionState_MAX).Forget();
	}

	// Token: 0x0600CA62 RID: 51810 RVA: 0x0035D724 File Offset: 0x0035B924
	private bool IsAllowClose()
	{
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		int[] editingRoleIdList = instance.GetEditingRoleIdList(this.EditFormationId);
		if (editingRoleIdList.Length == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamNoRole", Array.Empty<object>());
			return false;
		}
		bool flag = true;
		for (int i = 0; i < editingRoleIdList.Length; i++)
		{
			if (!instance.IsRoleDead(editingRoleIdList[i]))
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditFormationAllDead", Array.Empty<object>());
			return false;
		}
		bool flag2 = false;
		for (int j = 0; j < editingRoleIdList.Length; j++)
		{
			if (RoleUtils.IsSpecialTrialRole(editingRoleIdList[j]))
			{
				flag2 = true;
				break;
			}
		}
		return this.CanUseSpecialTrailRole || !flag2;
	}

	// Token: 0x0600CA63 RID: 51811 RVA: 0x0035D7D0 File Offset: 0x0035B9D0
	private bool IsNeedRevive(int roleConfigId)
	{
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return false;
		}
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		bool flag = instance.IsInEditingFormation(this.EditFormationId, roleConfigId);
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleConfigId, true);
		return (roleDataById == null || !roleDataById.IsTrialRole()) && !flag && instance.IsRoleDead(roleConfigId);
	}

	// Token: 0x0600CA64 RID: 51812 RVA: 0x0035D828 File Offset: 0x0035BA28
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		int num2;
		int num = int.TryParse(configParams[0], out num2) ? num2 : 0;
		if (num != 0)
		{
			FormationRoleSlot formationRoleSlot = this.FormationRoleViewList[num - 1];
			UUIItem uuiitem = (formationRoleSlot != null) ? formationRoleSlot.GetRootItem() : null;
			if (uuiitem != null)
			{
				return new UUIItem[]
				{
					uuiitem,
					uuiitem
				};
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Guide;
		ELogAuthor author = ELogAuthor.JT;
		string message = "聚焦引导extraParam项配置有误";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x040060C8 RID: 24776
	private List<FormationRoleSlot> FormationRoleViewList = new List<FormationRoleSlot>();

	// Token: 0x040060C9 RID: 24777
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithTitle<EditFormationTabItem> TabComponent;

	// Token: 0x040060CA RID: 24778
	private readonly int[] ExitSkillIconList = new int[]
	{
		10,
		11,
		12
	};

	// Token: 0x040060CB RID: 24779
	private int EditFormationId;

	// Token: 0x040060CC RID: 24780
	private int EditPosition;

	// Token: 0x040060CD RID: 24781
	private int GoBattleFormationId = -1;

	// Token: 0x040060CE RID: 24782
	private bool WaitingClose;

	// Token: 0x040060CF RID: 24783
	[Nullable(2)]
	private TimerHandle DelayLoadingTimer;

	// Token: 0x040060D0 RID: 24784
	[Nullable(2)]
	private TimerHandle AutoCloseTimer;

	// Token: 0x040060D1 RID: 24785
	private bool IsResetToBattle = true;

	// Token: 0x040060D2 RID: 24786
	private bool CanUseSpecialTrailRole = true;

	// Token: 0x040060D3 RID: 24787
	private bool CanShowSpecialTrialRole = true;

	// Token: 0x02007E34 RID: 32308
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402AFB8 RID: 176056
		public const int TabComponent = 0;

		// Token: 0x0402AFB9 RID: 176057
		public const int ExitSkillButton = 1;

		// Token: 0x0402AFBA RID: 176058
		public const int TeamRoleContentItem = 2;

		// Token: 0x0402AFBB RID: 176059
		public const int TeamRoleSlot1 = 3;

		// Token: 0x0402AFBC RID: 176060
		public const int TeamRoleSlot2 = 4;

		// Token: 0x0402AFBD RID: 176061
		public const int TeamRoleSlot3 = 5;

		// Token: 0x0402AFBE RID: 176062
		public const int ConfirmButton = 6;

		// Token: 0x0402AFBF RID: 176063
		public const int ConfirmText = 7;

		// Token: 0x0402AFC0 RID: 176064
		public const int CloseButton = 8;

		// Token: 0x0402AFC1 RID: 176065
		public const int QuickSelectButton = 9;

		// Token: 0x0402AFC2 RID: 176066
		public const int ExitSkillIcon1 = 10;

		// Token: 0x0402AFC3 RID: 176067
		public const int ExitSkillIcon2 = 11;

		// Token: 0x0402AFC4 RID: 176068
		public const int ExitSkillIcon3 = 12;

		// Token: 0x0402AFC5 RID: 176069
		public const int LoadingItem = 13;

		// Token: 0x0402AFC6 RID: 176070
		public const int DisableClickMask = 14;

		// Token: 0x0402AFC7 RID: 176071
		public const int DragItem = 15;

		// Token: 0x0402AFC8 RID: 176072
		public const int DragRoleItem = 16;
	}
}
