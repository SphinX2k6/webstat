using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;
using CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B3F RID: 6975
[NullableContext(1)]
[Nullable(0)]
public class EditBattleTeamView : UiTickViewBase, IUiViewResource
{
	// Token: 0x0600C95F RID: 51551 RVA: 0x00355F5F File Offset: 0x0035415F
	public EditBattleTeamView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C960 RID: 51552 RVA: 0x00355F98 File Offset: 0x00354198
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(15, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUISprite)),
			new ValueTuple<int, Type>(18, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUISpriteTransition)),
			new ValueTuple<int, Type>(26, typeof(UUISpriteTransition)),
			new ValueTuple<int, Type>(27, typeof(UUISpriteTransition)),
			new ValueTuple<int, Type>(28, typeof(UUIItem)),
			new ValueTuple<int, Type>(29, typeof(UUIItem)),
			new ValueTuple<int, Type>(30, typeof(UUIItem)),
			new ValueTuple<int, Type>(31, typeof(UUIItem)),
			new ValueTuple<int, Type>(32, typeof(UUISprite)),
			new ValueTuple<int, Type>(33, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnEnterButtonClicked)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnCloseButtonClicked)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnAddPlayerButtonClicked)),
			new ValueTuple<int, Delegate>(7, new Action(this.OnInviteButtonClicked)),
			new ValueTuple<int, Delegate>(14, new Action(this.OnClickTowerDetailsBtn)),
			new ValueTuple<int, Delegate>(15, new Action(this.OnClickTowerRecommendBtn)),
			new ValueTuple<int, Delegate>(18, new Action(this.OnClickExitSkill)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickChat)),
			new ValueTuple<int, Delegate>(20, new Action(this.OnClickQuickSelect))
		};
	}

	// Token: 0x0600C961 RID: 51553 RVA: 0x0035639C File Offset: 0x0035459C
	public string GetExtraResourceId([Nullable(2)] object param = null)
	{
		int? getInstanceDungeonId = ModelBase<EditBattleTeamModel>.Instance.GetInstanceDungeonId;
		if (getInstanceDungeonId != null)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(getInstanceDungeonId.Value);
			if (config != null && config.Value.InstSubType == 33)
			{
				return "UiView_CelebrationBattleTeam";
			}
		}
		return "UiView_BattleTeam";
	}

	// Token: 0x0600C962 RID: 51554 RVA: 0x003563F8 File Offset: 0x003545F8
	protected override UniTask OnBeforeStartAsync()
	{
		EditBattleTeamView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<EditBattleTeamView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C963 RID: 51555 RVA: 0x0035643C File Offset: 0x0035463C
	private void RefreshQuickSelectButton()
	{
		UUIButtonComponent button = base.GetButton(20);
		if (button != null)
		{
			int? getInstanceDungeonId = ModelBase<EditBattleTeamModel>.Instance.GetInstanceDungeonId;
			if (getInstanceDungeonId != null)
			{
				InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(getInstanceDungeonId.Value);
				if (config != null && config.Value.InstSubType == 33)
				{
					button.RootUIComp.Get().SetUIActive(false);
					return;
				}
			}
			button.RootUIComp.Get().SetUIActive(!ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon);
		}
	}

	// Token: 0x0600C964 RID: 51556 RVA: 0x003564D0 File Offset: 0x003546D0
	protected override void OnBeforeDestroy()
	{
		for (int i = 0; i < this.EditBattleRoleSlots.Count; i++)
		{
			this.EditBattleRoleSlots[i].Destroy(null);
		}
		this.EditBattleRoleSlots.Clear();
		for (int j = 0; j < this.ElementList.Count; j++)
		{
			this.ElementList[j].Destroy(null);
		}
		this.ElementList.Clear();
		ModelBase<InstanceDungeonEntranceModel>.Instance.SetEditBattleTeamMatching(false);
		InstanceDungeonModel instance = ModelBase<InstanceDungeonModel>.Instance;
		MatchTeamInfo matchTeamInfo = (instance != null) ? instance.GetMatchTeamInfo() : null;
		if (matchTeamInfo != null && matchTeamInfo.TeamState != MatchTeamState.EnterInstStart)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveMatchTeamRequest().Forget<bool>();
		}
		bool flag = ModelBase<TowerModel>.Instance.CheckInTower();
		if (!ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon && !flag)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.RevertEntranceFlowStep();
			ModelBase<EditBattleTeamModel>.Instance.SetInstanceDungeonId(null);
		}
		ControllerBase<InstanceDungeonEntranceController>.Instance.OnEditBattleViewClose();
		if (ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter)
		{
			ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = false;
		}
		ModelBase<EditBattleTeamModel>.Instance.CanUseSpecialTrialRole = false;
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		this.RemoveEvents();
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		this.IsTabInit = false;
		if (ModelBase<EditBattleTeamModel>.Instance.IsFormTeleportAction)
		{
			ModelBase<EditBattleTeamModel>.Instance.IsFormTeleportAction = false;
			ControllerBase<InstanceDungeonController>.Instance.TeleportDungeonRequest(new List<int>(), false);
		}
		ModelBase<EditBattleTeamModel>.Instance.FastReturnDungeonContext = null;
		ControllerBase<FormationDragController>.Instance.ClearDragData();
		ModelBase<InstanceDungeonModel>.Instance.ClearInstanceEnterContentText();
	}

	// Token: 0x0600C965 RID: 51557 RVA: 0x00356665 File Offset: 0x00354865
	protected override void OnBeforeShow()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineInstanceMatchTips))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineInstanceMatchTips, null);
		}
		UUIItem item = base.GetItem(31);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(ModelBase<MultiMotorModel>.Instance.CheckInMultiMotorEditFormationState());
	}

	// Token: 0x0600C966 RID: 51558 RVA: 0x003566A4 File Offset: 0x003548A4
	protected override void OnStart()
	{
		if (this.TabComponent != null)
		{
			int index = ModelBase<EditFormationModel>.Instance.GetCurrentFormationId.Value - 1;
			this.TabComponent.SelectToggleByIndex(index, false);
			this.TabComponent.ScrollToToggleByIndex(index);
			this.TabComponent.GetTabItemByIndex(index).ShowTeamBattleTips();
			this.TabComponent.SetCanChange((int _) => ControllerBase<FormationDragController>.Instance.DraggingIndex <= 0);
		}
	}

	// Token: 0x0600C967 RID: 51559 RVA: 0x00356724 File Offset: 0x00354924
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 1)
		{
			return null;
		}
		string text = configParams[0];
		if (text.IndexOf("FirstSelf") >= 0)
		{
			EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
			int i = 0;
			while (i < 3)
			{
				EditBattleRoleSlotData roleSlotData = instance.GetRoleSlotData(i + 1);
				bool? flag;
				if (roleSlotData == null)
				{
					flag = null;
				}
				else
				{
					EditBattleRoleData getRoleData = roleSlotData.GetRoleData;
					flag = ((getRoleData != null) ? new bool?(getRoleData.IsSelf) : null);
				}
				bool? flag2 = flag;
				if (flag2.GetValueOrDefault())
				{
					FormationRoleSlot formationRoleSlot = this.EditBattleRoleSlots[i];
					if (formationRoleSlot == null)
					{
						return null;
					}
					return formationRoleSlot.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
				else
				{
					i++;
				}
			}
		}
		if (text.IndexOf("FirstDangoSlot") < 0)
		{
			return null;
		}
		FormationRoleSlot formationRoleSlot2 = this.EditBattleRoleSlots.ElementAtOrDefault(0);
		if (formationRoleSlot2 == null)
		{
			return null;
		}
		return formationRoleSlot2.GetGuideUiItemAndUiItemForShowEx(configParams);
	}

	// Token: 0x0600C968 RID: 51560 RVA: 0x003567E0 File Offset: 0x003549E0
	private void InitViewParam()
	{
		IEditBattleTeamViewParam editBattleTeamViewParam = this.OpenParam as IEditBattleTeamViewParam;
		bool isMultiInstanceDungeon = ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon;
		this.CanUseSpecialTrailRole = ((editBattleTeamViewParam == null || editBattleTeamViewParam.CanUseSpecialTrailRole) && !isMultiInstanceDungeon);
		ModelBase<EditBattleTeamModel>.Instance.CanUseSpecialTrialRole = this.CanUseSpecialTrailRole;
	}

	// Token: 0x0600C969 RID: 51561 RVA: 0x00356830 File Offset: 0x00354A30
	private void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, new Action<ERefreshEditBattleRoleSlotDataReason>(this.OnRefreshEditBattleRoleSlotData));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.OnRefreshEditBattleRoleReady, new Action<int, bool>(this.OnRefreshEditBattleRoleReady));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRefreshPlayerUiState, new Action<int>(this.OnRefreshPlayerUiState));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ScenePlayerLeaveScene, new Action<int>(this.ScenePlayerLeaveScene));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.MatchTeamFlagChange, new Action<bool>(this.MatchTeamFlagChange));
		Singleton<EventSystem>.Instance.Add<ChatRowData>(EEventName.OnPushChatRowData, new Action<ChatRowData>(this.OnPushChatRowData));
		Singleton<EventSystem>.Instance.Add(EEventName.TowerDefensePhantomChanged, new Action(this.HandleTowerDefenceOnConfirmPhantom));
		Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<int, int[]>>(EEventName.OnAbyssDangoSelect, new Action<IReadOnlyDictionary<int, int[]>>(this.HandleAbyssConfirm));
	}

	// Token: 0x0600C96A RID: 51562 RVA: 0x00356920 File Offset: 0x00354B20
	private void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, new Action<ERefreshEditBattleRoleSlotDataReason>(this.OnRefreshEditBattleRoleSlotData));
		Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.OnRefreshEditBattleRoleReady, new Action<int, bool>(this.OnRefreshEditBattleRoleReady));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRefreshPlayerUiState, new Action<int>(this.OnRefreshPlayerUiState));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.ScenePlayerLeaveScene, new Action<int>(this.ScenePlayerLeaveScene));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.MatchTeamFlagChange, new Action<bool>(this.MatchTeamFlagChange));
		Singleton<EventSystem>.Instance.Remove<ChatRowData>(EEventName.OnPushChatRowData, new Action<ChatRowData>(this.OnPushChatRowData));
		Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefensePhantomChanged, new Action(this.HandleTowerDefenceOnConfirmPhantom));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssDangoSelect, new Action<IReadOnlyDictionary<int, int[]>>(this.HandleAbyssConfirm));
	}

	// Token: 0x0600C96B RID: 51563 RVA: 0x00356A10 File Offset: 0x00354C10
	protected override void OnTick(float delta)
	{
		for (int i = 0; i < this.EditBattleRoleSlots.Count; i++)
		{
			FormationRoleView formationRoleView = this.EditBattleRoleSlots[i] as FormationRoleView;
			if (formationRoleView != null)
			{
				formationRoleView.OnTick(delta);
			}
		}
	}

	// Token: 0x0600C96C RID: 51564 RVA: 0x00356A4F File Offset: 0x00354C4F
	private void OnRefreshEditBattleRoleSlotData(ERefreshEditBattleRoleSlotDataReason reason)
	{
		this.RefreshAllEditBattleRoleSlots(null);
		this.RefreshEnterButton();
		this.RefreshEnterButtonEnable();
		this.UpdateRecommendLevel();
	}

	// Token: 0x0600C96D RID: 51565 RVA: 0x00356A6C File Offset: 0x00354C6C
	private void OpenTeamSelectView(int position)
	{
		TeamRoleSelectViewData teamOpenViewData = this.GetTeamOpenViewData(position);
		if (teamOpenViewData == null || Singleton<UiManager>.Instance.IsViewShow(EUiViewName.TeamRoleSelectView))
		{
			return;
		}
		if (ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon)
		{
			ControllerBase<OnlineController>.Instance.MatchChangePlayerUiStateRequest(EMatchPlayerUiState.Selecting);
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TeamRoleSelectView, teamOpenViewData, null);
	}

	// Token: 0x0600C96E RID: 51566 RVA: 0x00356AC0 File Offset: 0x00354CC0
	public EFilterSortGroupId GetUseWay()
	{
		EFilterSortGroupId result = EFilterSortGroupId.EditBattleTeam;
		if (ModelBase<TowerModel>.Instance.IsOpenFloorFormation())
		{
			result = EFilterSortGroupId.TowerFormation;
		}
		else if (ModelBase<WeeklyRogueModel>.Instance.IsWeeklyRogueOpen())
		{
			result = EFilterSortGroupId.WeeklyRogueEditFormation;
		}
		return result;
	}

	// Token: 0x0600C96F RID: 51567 RVA: 0x00356AF0 File Offset: 0x00354CF0
	[NullableContext(2)]
	private TeamRoleSelectViewData GetTeamOpenViewData(int position)
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		RoleDataBase[] roleList = instance.GetRoleList();
		List<RoleDataBase> roleList2 = (roleList != null) ? new List<RoleDataBase>(roleList) : new List<RoleDataBase>();
		EditBattleRoleSlotData roleSlotData = instance.GetRoleSlotData(position);
		int? num;
		if (roleSlotData == null)
		{
			num = null;
		}
		else
		{
			EditBattleRoleData getRoleData = roleSlotData.GetRoleData;
			num = ((getRoleData != null) ? new int?(getRoleData.ConfigId) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		TeamRoleSelectViewData teamRoleSelectViewData = new TeamRoleSelectViewData(this.GetUseWay(), valueOrDefault, roleList2, new Action<int>(this.OnEnsureFormation), new Action(this.OnCloseSelectedRoleView), new int?(position), null);
		teamRoleSelectViewData.SetGetConfirmButtonEnableFunction(new Func<int, bool>(this.GetConfirmButtonEnableFunction));
		teamRoleSelectViewData.SetGetConfirmButtonTextFunction(new Func<int, string>(this.GetConfirmButtonTextFunction));
		teamRoleSelectViewData.SetHideFinishCallBack(new Action(this.OnRoleSelectionHideFinished));
		if (ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon)
		{
			teamRoleSelectViewData.SetOtherTeamSlotData(new List<EditBattleRoleSlotData>(instance.GetAllRoleSlotData));
		}
		teamRoleSelectViewData.SetConfirmCheckFunction(new Func<int, bool>(this.ConfirmCheckFunction));
		teamRoleSelectViewData.IsNeedRevive = new Func<int, bool>(this.IsNeedReviveFunction);
		teamRoleSelectViewData.CanJoinTeam = new Func<int, bool>(this.CanJoinTeam);
		teamRoleSelectViewData.CanUseSpecialTrialRole = this.CanUseSpecialTrailRole;
		List<int> list = new List<int>();
		EditBattleRoleSlotData[] getAllRoleSlotData = instance.GetAllRoleSlotData;
		for (int i = 0; i < getAllRoleSlotData.Length; i++)
		{
			EditBattleRoleData getRoleData2 = getAllRoleSlotData[i].GetRoleData;
			if (getRoleData2 != null && (!instance.IsMultiInstanceDungeon || getRoleData2.PlayerId == ModelBase<CreatureModel>.Instance.GetPlayerId()))
			{
				list.Add(getRoleData2.ConfigId);
			}
		}
		teamRoleSelectViewData.FormationRoleList = list.ToArray();
		return teamRoleSelectViewData;
	}

	// Token: 0x0600C970 RID: 51568 RVA: 0x00356C9C File Offset: 0x00354E9C
	private bool CanJoinTeam(int roleId)
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		return (!RoleUtils.IsSpecialTrialRole(roleId) || this.CanUseSpecialTrailRole) && !instance.IsInEditBattleTeam(roleId, false) && instance.CanAddRoleToEditTeam(roleId);
	}

	// Token: 0x0600C971 RID: 51569 RVA: 0x00356CD4 File Offset: 0x00354ED4
	private bool IsNeedReviveFunction(int roleId)
	{
		return this.IsNeedRevive(roleId);
	}

	// Token: 0x0600C972 RID: 51570 RVA: 0x00356CE0 File Offset: 0x00354EE0
	private bool ConfirmCheckFunction(int roleId)
	{
		if (this.IsNeedRevive(roleId))
		{
			ControllerBase<BuffItemControl>.Instance.TryUseResurrectionItem(roleId);
			return false;
		}
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		EditBattleRoleSlotData getCurrentEditRoleSlotData = instance.GetCurrentEditRoleSlotData;
		int editResultType = (int)this.GetEditResultType(roleId);
		int parentRolePositionInEditBattleTeam = instance.GetParentRolePositionInEditBattleTeam(roleId);
		if (editResultType != 2 && parentRolePositionInEditBattleTeam != -1 && parentRolePositionInEditBattleTeam != getCurrentEditRoleSlotData.GetPosition)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("SameRole", Array.Empty<object>());
			return false;
		}
		if (instance.IsMultiInstanceDungeon && getCurrentEditRoleSlotData != null)
		{
			int? num = getCurrentEditRoleSlotData.GetRoleConfigId;
			if (num.GetValueOrDefault() == roleId & num != null)
			{
				EditBattleTeamModel editBattleTeamModel = instance;
				int? num2;
				if (getCurrentEditRoleSlotData == null)
				{
					num2 = null;
				}
				else
				{
					EditBattleRoleData getRoleData = getCurrentEditRoleSlotData.GetRoleData;
					num2 = ((getRoleData != null) ? new int?(getRoleData.PlayerId) : null);
				}
				num = num2;
				if (editBattleTeamModel.GetPlayerRoleNumber(new int?(num.GetValueOrDefault())) < 2)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("BattleTeamCanNotDownAllRole", Array.Empty<object>());
					return false;
				}
			}
		}
		if (this.CanUseSpecialTrailRole)
		{
			int value = getCurrentEditRoleSlotData.GetPosition - 1;
			int[] selfRoleSlotDataRoleIdList = instance.SelfRoleSlotDataRoleIdList;
			if (RoleUtils.HasMultiTrialRole(roleId, selfRoleSlotDataRoleIdList, new int?(value)))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamMultiTrialRole", Array.Empty<object>());
				return false;
			}
			if (RoleUtils.HasSameRole(roleId, selfRoleSlotDataRoleIdList, new int?(value)))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamSameRole", Array.Empty<object>());
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600C973 RID: 51571 RVA: 0x00356E38 File Offset: 0x00355038
	private void ScenePlayerLeaveScene(int playerId)
	{
		this.RefreshEnterButton();
	}

	// Token: 0x0600C974 RID: 51572 RVA: 0x00356E40 File Offset: 0x00355040
	private void MatchTeamFlagChange(bool isMatching)
	{
		this.RefreshEnterButton();
		this.RefreshEnterButtonEnable();
		this.RefreshMatch(isMatching);
	}

	// Token: 0x0600C975 RID: 51573 RVA: 0x00356E58 File Offset: 0x00355058
	private void RefreshMatch(bool isMatching)
	{
		if (!isMatching)
		{
			for (int i = 0; i < this.EditBattleRoleSlots.Count; i++)
			{
				FormationRoleView formationRoleView = this.EditBattleRoleSlots[i] as FormationRoleView;
				if (formationRoleView != null)
				{
					formationRoleView.IsDragDisabled = false;
					formationRoleView.SetMatchState(false);
				}
			}
			return;
		}
		for (int j = 0; j < this.EditBattleRoleSlots.Count; j++)
		{
			FormationRoleView formationRoleView2 = this.EditBattleRoleSlots[j] as FormationRoleView;
			if (formationRoleView2 != null)
			{
				formationRoleView2.IsDragDisabled = true;
			}
		}
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		EditBattleRoleSlotData[] getAllRoleSlotData = instance.GetAllRoleSlotData;
		List<FormationRoleView> list = new List<FormationRoleView>();
		int valueOrDefault = instance.GetLeaderPlayerId.GetValueOrDefault();
		bool flag = false;
		for (int k = 1; k <= 4; k++)
		{
			EditBattleRoleSlotData editBattleRoleSlotData = getAllRoleSlotData[k - 1];
			FormationRoleView formationRoleView3 = this.GetFormationRoleView(k);
			if (editBattleRoleSlotData != null && formationRoleView3 != null)
			{
				EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
				if (getRoleData == null)
				{
					list.Add(formationRoleView3);
				}
				else if (getRoleData.PlayerId == valueOrDefault)
				{
					if (flag)
					{
						list.Add(formationRoleView3);
					}
					else
					{
						flag = true;
					}
				}
			}
		}
		int needMatchSize = ModelBase<InstanceDungeonModel>.Instance.GetNeedMatchSize();
		InstanceDungeonEntranceModel entranceModel = ModelBase<InstanceDungeonEntranceModel>.Instance;
		int matchingTime = entranceModel.MatchingTime;
		for (int l = 0; l < needMatchSize; l++)
		{
			int num = list.Count - 1;
			FormationRoleView formationRoleView4 = null;
			if (num >= 0)
			{
				formationRoleView4 = list[num];
				list.RemoveAt(num);
			}
			if (formationRoleView4 != null)
			{
				formationRoleView4.SetMatchState(true);
			}
			if (formationRoleView4 != null)
			{
				formationRoleView4.SetMatchTime(matchingTime);
			}
		}
		Func<bool> onStopTimer = () => !entranceModel.EditBattleTeamMatching;
		entranceModel.MatchingTime = 0;
		entranceModel.OnStopTimer = onStopTimer;
		ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchTimer(new Action(this.MatchHandle));
	}

	// Token: 0x0600C976 RID: 51574 RVA: 0x0035701C File Offset: 0x0035521C
	private void OnPushChatRowData(ChatRowData chatRowData)
	{
		int valueOrDefault = chatRowData.TargetPlayerId.GetValueOrDefault();
		if (ModelBase<FriendModel>.Instance.HasBlockedPlayer(valueOrDefault))
		{
			return;
		}
		if (!chatRowData.IsVisible)
		{
			return;
		}
		bool flag = chatRowData.ContentChatRoomType == EChatRoomType.Private;
		string text = chatRowData.SenderPlayerName;
		if (flag)
		{
			FriendData friendById = ModelBase<FriendModel>.Instance.GetFriendById(valueOrDefault);
			if (friendById != null)
			{
				text = friendById.PlayerName;
			}
		}
		if (!this.IsShowChatInfo)
		{
			base.GetItem(9).SetUIActive(true);
			this.LevelSequencePlayer.PlayLevelSequenceByName("NoticeIn", false, null, false);
			this.IsShowChatInfo = true;
		}
		this.LevelSequencePlayer.PlayLevelSequenceByName("NewMassageIn", false, null, false);
		UUIText text2 = base.GetText(10);
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int senderPlayerId = chatRowData.SenderPlayerId;
		bool flag2 = id.GetValueOrDefault() == senderPlayerId & id != null;
		string textStringId = null;
		string text3 = chatRowData.Content;
		if (chatRowData.ContentType == ChatContentType.Text)
		{
			if (flag)
			{
				textStringId = (flag2 ? "Text_TalkToFriend_Text" : "Text_FriendTalkToMe_Text");
			}
			else
			{
				textStringId = "Text_TeamTalk_Text";
			}
		}
		else if (chatRowData.ContentType == ChatContentType.Emoji)
		{
			int num = int.Parse(chatRowData.Content ?? "0");
			ChatExpression? expressionConfig = ConfigBase<ChatConfig>.Instance.GetExpressionConfig(num);
			if (expressionConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Formation;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "表情缺少配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("表情Id", num);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, expressionConfig.Value.Name, Array.Empty<object>());
			text3 = text2.GetText();
			if (flag)
			{
				textStringId = (flag2 ? "Text_TalkToFriend_Text_Match" : "Text_FriendTalkToMe_Text_Match");
			}
			else
			{
				textStringId = "Text_TeamTalk_Text_Match";
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, textStringId, new <>z__ReadOnlyArray<object>(new object[]
		{
			text,
			text3
		}));
	}

	// Token: 0x0600C977 RID: 51575 RVA: 0x00357207 File Offset: 0x00355407
	private void HandleAbyssConfirm(IReadOnlyDictionary<int, int[]> dataMap)
	{
		this.RefreshEnterButtonEnable();
	}

	// Token: 0x0600C978 RID: 51576 RVA: 0x0035720F File Offset: 0x0035540F
	private void HandleTowerDefenceOnConfirmPhantom()
	{
		this.RefreshEnterButtonEnable();
	}

	// Token: 0x0600C979 RID: 51577 RVA: 0x00357218 File Offset: 0x00355418
	private void MatchHandle()
	{
		int matchingTime = ModelBase<InstanceDungeonEntranceModel>.Instance.MatchingTime;
		for (int i = 0; i < this.EditBattleRoleSlots.Count; i++)
		{
			FormationRoleView formationRoleView = this.EditBattleRoleSlots[i] as FormationRoleView;
			if (formationRoleView != null)
			{
				formationRoleView.SetMatchTime(matchingTime);
			}
		}
	}

	// Token: 0x0600C97A RID: 51578 RVA: 0x00357262 File Offset: 0x00355462
	private void OnRefreshEditBattleRoleReady(int position, bool bReady)
	{
		this.RefreshEnterButton();
		this.RefreshEnterButtonEnable();
	}

	// Token: 0x0600C97B RID: 51579 RVA: 0x00357270 File Offset: 0x00355470
	private void OnRefreshPlayerUiState(int playerId)
	{
		MatchTeamInfo matchTeamInfo = ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamInfo();
		int num = (matchTeamInfo != null) ? matchTeamInfo.HostId : 0;
		for (int i = 0; i < this.EditBattleRoleSlots.Count; i++)
		{
			FormationRoleView formationRoleView = this.EditBattleRoleSlots[i] as FormationRoleView;
			if (formationRoleView != null)
			{
				if (formationRoleView.GetPlayerId() == playerId)
				{
					formationRoleView.RefreshPrepareState();
				}
				else if (playerId == num)
				{
					formationRoleView.RefreshPrepareState();
				}
			}
		}
	}

	// Token: 0x0600C97C RID: 51580 RVA: 0x003572DC File Offset: 0x003554DC
	private unsafe void OnEnterButtonClicked()
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		bool getLeaderIsSelf = instance.GetLeaderIsSelf;
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int getOwnRoleCountInRoleSlot = instance.GetOwnRoleCountInRoleSlot;
		if (getOwnRoleCountInRoleSlot == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NoRole", Array.Empty<object>());
			return;
		}
		if (!instance.IsInLimitRoleCount(getOwnRoleCountInRoleSlot))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("LimitCount", Array.Empty<object>());
			return;
		}
		if (instance.IsMultiInstanceDungeon)
		{
			if (getLeaderIsSelf)
			{
				if (ModelBase<InstanceDungeonEntranceModel>.Instance.EditBattleTeamMatching)
				{
					ModelBase<InstanceDungeonEntranceModel>.Instance.SetEditBattleTeamMatching(false);
					this.RefreshEnterButton();
					ControllerBase<InstanceDungeonEntranceController>.Instance.SetMatchTeamMatchFlagRequest(ModelBase<InstanceDungeonEntranceModel>.Instance.EditBattleTeamMatching).Forget<bool>();
					return;
				}
				if (!instance.GetIsAllReady)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NoReady", Array.Empty<object>());
					return;
				}
				if (instance.HasSameRole && !ControllerBase<TowerDefenseController>.Instance.CheckInUiFlow() && !ModelBase<DangoAbyssModel>.Instance.CheckInAbyssEditFormationState() && !ModelBase<MultiMotorModel>.Instance.CheckInMultiMotorEditFormationState())
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("SameRole", Array.Empty<object>());
					return;
				}
				if (!instance.GetAllRoleCanAddToTeam().Item1)
				{
					string localTextNew = ConfigMultiTextLang.GetLocalTextNew(instance.GetCurrentFightFormation.Value.Content, null);
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(localTextNew);
					return;
				}
				if (instance.IsAllRoleDie)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("AllRoleDie", Array.Empty<object>());
					return;
				}
				if (ModelBase<InstanceDungeonModel>.Instance.MatchingPlayerCount() > 2)
				{
					this.TeamLeaderEnterMatchInstRequest();
					return;
				}
				if (ModelBase<EditBattleTeamModel>.Instance.IsMatchingTeamLackConfirmBoxCanEnterInstance)
				{
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MatchingTeamLack);
					confirmBoxDataNew.FunctionMap[2] = new Action(this.TeamLeaderEnterMatchInstRequest);
					ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
					return;
				}
				ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.MatchingTeamLackButNoEnter);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
				return;
			}
			else
			{
				bool getSelfIsReady = instance.GetSelfIsReady;
				if (!getSelfIsReady && instance.HasSameRole && !ControllerBase<TowerDefenseController>.Instance.CheckInUiFlow() && !ModelBase<DangoAbyssModel>.Instance.CheckInAbyssEditFormationState() && !ModelBase<MultiMotorModel>.Instance.CheckInMultiMotorEditFormationState())
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("SameRole", Array.Empty<object>());
					return;
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Formation;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "[EditBattleTeam]玩家{PlayerId} 请求准备游戏,是否准备:{SelfIsReady}";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("{PlayerId}", id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("{SelfIsReady}", !getSelfIsReady);
				instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				ControllerBase<InstanceDungeonEntranceController>.Instance.MatchChangeReadyRequest(!getSelfIsReady).Forget<bool>();
				return;
			}
		}
		else
		{
			if (!instance.GetIsAllReady)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NoReady", Array.Empty<object>());
				return;
			}
			if (instance.HasSameRole)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("SameRole", Array.Empty<object>());
				return;
			}
			if (!ControllerBase<LordGymController>.Instance.IsInLordGymDungeon() && !ModelBase<TowerModel>.Instance.IsOpenFloorFormation() && instance.IsAllRoleDie)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("AllRoleDie", Array.Empty<object>());
				return;
			}
			if (!instance.GetAllRoleCanAddToTeam().Item1)
			{
				string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(instance.GetCurrentFightFormation.Value.Content, null);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(localTextNew2);
				return;
			}
			if (ModelBase<TowerModel>.Instance.IsOpenFloorFormation())
			{
				ControllerBase<TowerController>.Instance.TowerStartRequest(ModelBase<TowerModel>.Instance.CurrentSelectFloor, ModelBase<EditBattleTeamModel>.Instance.GetOwnRoleConfigIdList.Item1.ToList<int>(), true).Forget();
				return;
			}
			if (ModelBase<WeeklyRogueModel>.Instance.IsWeeklyRogueOpen())
			{
				WeeklyRogueController weeklyRogueController = ActivityManager.GetActivityController(ActivityType.RogueWeekly) as WeeklyRogueController;
				List<int> item = ModelBase<EditBattleTeamModel>.Instance.GetOwnRoleConfigIdList.Item1;
				if (weeklyRogueController == null)
				{
					return;
				}
				weeklyRogueController.RogueWeeklyStartRequest(item.ToList<int>());
				return;
			}
			else
			{
				if (!this.CanUseSpecialTrailRole && instance.HasSpecialTrialRole)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamForbidTrialRole", Array.Empty<object>());
					return;
				}
				this.EnterButtonSoloBegin();
				return;
			}
		}
	}

	// Token: 0x0600C97D RID: 51581 RVA: 0x003576B4 File Offset: 0x003558B4
	private void EnterButtonSoloBegin()
	{
		if (ModelBase<EditBattleTeamModel>.Instance.NeedEntrance)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.ContinueEntranceFlow();
			return;
		}
		ModelBase<EditBattleTeamModel>.Instance.NeedEntrance = true;
		List<int> item = ModelBase<EditBattleTeamModel>.Instance.GetOwnRoleConfigIdList.Item1;
		if (ModelBase<EditBattleTeamModel>.Instance.IsFormTeleportAction)
		{
			ModelBase<EditBattleTeamModel>.Instance.IsFormTeleportAction = false;
			ControllerBase<InstanceDungeonController>.Instance.TeleportDungeonRequest(item, true);
			return;
		}
		FastReturnDungeonContext fastReturnDungeonContext = ModelBase<EditBattleTeamModel>.Instance.FastReturnDungeonContext;
		if (fastReturnDungeonContext != null)
		{
			ModelBase<EditBattleTeamModel>.Instance.FastReturnDungeonContext = null;
			ControllerBase<GeneralLogicTreeController>.Instance.RequestFastReturnDungeon(fastReturnDungeonContext.TreeIncId, fastReturnDungeonContext.NodeId, fastReturnDungeonContext.IsContinue, item, delegate(bool _)
			{
			});
			return;
		}
		ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId, item, ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceId, 0, ModelBase<InstanceDungeonEntranceModel>.Instance.TransitionOption, ModelBase<TowerDefenseModel>.Instance.GetProtocolPhantomIdList(item)).Forget<bool>();
	}

	// Token: 0x0600C97E RID: 51582 RVA: 0x003577A8 File Offset: 0x003559A8
	private void OnRoleSelectionHideFinished()
	{
		this.SetCloseButtonVisible(true);
		this.RefreshAllEditBattleRoleSlots(null);
		if (ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon && ModelBase<EditBattleTeamModel>.Instance.GetLeaderPlayerId != null)
		{
			ControllerBase<OnlineController>.Instance.MatchChangePlayerUiStateRequest(ModelBase<InstanceDungeonEntranceModel>.Instance.EditBattleTeamMatching ? EMatchPlayerUiState.Matching : EMatchPlayerUiState.Wait);
		}
	}

	// Token: 0x0600C97F RID: 51583 RVA: 0x00357800 File Offset: 0x00355A00
	private void OnCloseButtonClicked()
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		if (!instance.IsMultiInstanceDungeon)
		{
			bool flag = ModelBase<TowerModel>.Instance.CheckInTower();
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TowerFloorView);
			if (flag && viewByName == null)
			{
				TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(ModelBase<TowerModel>.Instance.CurrentSelectFloor);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerFloorView, towerInfo.Value.AreaNum, null);
			}
			ControllerBase<EditBattleTeamController>.Instance.ExitEditBattleTeam(true);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(instance.GetLeaderIsSelf ? EConfirmBoxConfigId.EditBattleTeamDisband : EConfirmBoxConfigId.EditBattleTeamExit);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<EditBattleTeamController>.Instance.ExitEditBattleTeam(true);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600C980 RID: 51584 RVA: 0x003578CC File Offset: 0x00355ACC
	private void TeamLeaderEnterMatchInstRequest()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Formation;
		ELogAuthor author = ELogAuthor.LYY;
		string message = "[EditBattleTeam]队长{PlayerId} 请求进入副本";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("{PlayerId}", ModelBase<PlayerInfoModel>.Instance.GetId());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ControllerBase<InstanceDungeonEntranceController>.Instance.EnterMatchInstRequest().ContinueWith(delegate(bool bSuccess)
		{
			if (bSuccess)
			{
				ControllerBase<EditBattleTeamController>.Instance.CloseEditBattleTeamView();
			}
		}).Forget();
	}

	// Token: 0x0600C981 RID: 51585 RVA: 0x00357941 File Offset: 0x00355B41
	private void OnAddPlayerButtonClicked()
	{
		ModelBase<InstanceDungeonEntranceModel>.Instance.SetEditBattleTeamMatching(true);
		ControllerBase<InstanceDungeonEntranceController>.Instance.SetMatchTeamMatchFlagRequest(ModelBase<InstanceDungeonEntranceModel>.Instance.EditBattleTeamMatching).Forget<bool>();
	}

	// Token: 0x0600C982 RID: 51586 RVA: 0x00357968 File Offset: 0x00355B68
	private void OnInviteButtonClicked()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if (serverTime - this.RequestTimeStamp > (double)ModelBase<OnlineModel>.Instance.ApplyCd)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.TeamMatchInviteRequest();
			this.RequestTimeStamp = serverTime;
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("HaveMatched", Array.Empty<object>());
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("MatchingInviteCd", Array.Empty<object>());
	}

	// Token: 0x0600C983 RID: 51587 RVA: 0x003579CF File Offset: 0x00355BCF
	private void OnClickTowerDetailsBtn()
	{
		if (ModelBase<EditBattleTeamModel>.Instance.IsEditBattleTeamForMowingInstance())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonMonsterPreView, ModelBase<EditBattleTeamModel>.Instance.GetInstanceDungeonId, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerFloorDetailView, null, null);
	}

	// Token: 0x0600C984 RID: 51588 RVA: 0x00357A0E File Offset: 0x00355C0E
	private void OnClickTowerRecommendBtn()
	{
		ControllerBase<TowerController>.Instance.TowerFormationRecommendRequest(ModelBase<TowerModel>.Instance.CurrentSelectFloor).ContinueWith(delegate()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerRecommendView, null, null);
		}).Forget();
	}

	// Token: 0x0600C985 RID: 51589 RVA: 0x00357A50 File Offset: 0x00355C50
	private void OnClickQuickSelect()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.QuickRoleSelectView))
		{
			return;
		}
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		List<int> list = new List<int>();
		EditBattleRoleSlotData[] getAllRoleSlotData = instance.GetAllRoleSlotData;
		for (int i = 0; i < getAllRoleSlotData.Length; i++)
		{
			EditBattleRoleData getRoleData = getAllRoleSlotData[i].GetRoleData;
			if (getRoleData != null)
			{
				list.Add(getRoleData.ConfigId);
			}
		}
		RoleDataBase[] roleList = instance.GetRoleList();
		QuickRoleSelectViewData quickRoleSelectViewData = new QuickRoleSelectViewData(this.GetUseWay(), list.ToArray(), roleList.ToList<RoleDataBase>());
		quickRoleSelectViewData.OnConfirm = new Action<int[]>(this.OnQuickSelectConfirm);
		quickRoleSelectViewData.CanConfirm = new Func<int[], bool>(this.OnQuickSelectCanConfirm);
		quickRoleSelectViewData.CanSelectRole = new Func<int, int[], bool>(this.OnQuickSelectCanSelect);
		quickRoleSelectViewData.OnBack = new Action(this.OnCloseSelectedRoleView);
		quickRoleSelectViewData.OnHideFinish = new Action(this.OnRoleSelectionHideFinished);
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

	// Token: 0x0600C986 RID: 51590 RVA: 0x00357B60 File Offset: 0x00355D60
	private void OnQuickSelectConfirm(int[] roleIdList)
	{
		this.SetCloseButtonVisible(true);
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		foreach (int num in instance.SelfRoleSlotDataRoleIdList)
		{
			bool flag = false;
			for (int j = 0; j < roleIdList.Length; j++)
			{
				if (roleIdList[j] == num)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				ModelBase<TowerDefenseModel>.Instance.ResetPhantomOwnerDataByConfigId(num);
			}
		}
		for (int k = 1; k <= 4; k++)
		{
			EditBattleRoleSlotData roleSlotData = instance.GetRoleSlotData(k);
			if (roleSlotData.IsProhibit)
			{
				roleSlotData.ResetRoleData();
			}
			else if (k > roleIdList.Length)
			{
				roleSlotData.ResetRoleData();
			}
			else
			{
				int id = roleIdList[k - 1];
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(id, true);
				EditBattleRoleData roleData = instance.CreateRoleDataFromRoleInstance(roleDataById);
				roleSlotData.SetRoleData(roleData);
			}
		}
		this.RefreshAllEditBattleRoleSlots(null);
		this.RefreshEnterButtonEnable();
	}

	// Token: 0x0600C987 RID: 51591 RVA: 0x00357C38 File Offset: 0x00355E38
	private bool OnQuickSelectCanConfirm(int[] roleIdList)
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		foreach (int num in roleIdList)
		{
			if (instance.IsTrialRole(num))
			{
				int parentId = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(num).Value.ParentId;
				for (int j = 0; j < roleIdList.Length; j++)
				{
					if (parentId == roleIdList[j])
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("SameRole", Array.Empty<object>());
						return false;
					}
				}
			}
		}
		return true;
	}

	// Token: 0x0600C988 RID: 51592 RVA: 0x00357CB4 File Offset: 0x00355EB4
	private bool OnQuickSelectCanSelect(int roleId, int[] roleIdList)
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

	// Token: 0x0600C989 RID: 51593 RVA: 0x00357D14 File Offset: 0x00355F14
	private void OnClickExitSkill()
	{
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ExitSkillView))
		{
			ExitSkillViewData exitSkillViewData = new ExitSkillViewData();
			for (int i = 0; i < this.EditBattleRoleSlots.Count; i++)
			{
				FormationRoleView formationRoleView = this.EditBattleRoleSlots[i] as FormationRoleView;
				exitSkillViewData.AddData(formationRoleView.GetConfigId().GetValueOrDefault(), formationRoleView.GetOnlineIndex().GetValueOrDefault(1), formationRoleView.GetPlayer().GetValueOrDefault());
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ExitSkillView, exitSkillViewData, null);
		}
	}

	// Token: 0x0600C98A RID: 51594 RVA: 0x00357DA2 File Offset: 0x00355FA2
	private void OnClickChat()
	{
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ChatView))
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ChatView, null, null);
	}

	// Token: 0x0600C98B RID: 51595 RVA: 0x00357DC8 File Offset: 0x00355FC8
	public void RefreshEnterButton()
	{
		UUIText text = base.GetText(5);
		UUIItem uuiitem = base.GetButton(6).RootUIComp.Get();
		UUIItem uuiitem2 = base.GetButton(7).RootUIComp.Get();
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		if (!instance.IsMultiInstanceDungeon)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "MatchingButtonLeader", Array.Empty<object>());
			uuiitem.SetUIActive(false);
			uuiitem2.SetUIActive(false);
			return;
		}
		if (!ModelBase<InstanceDungeonModel>.Instance.IsMatchTeamHost())
		{
			string textTableId = instance.GetSelfIsReady ? "MatchingButtonMemberCancel" : "MatchingButtonMember";
			Singleton<LguiUtil>.Instance.SetLocalText(text, textTableId, Array.Empty<object>());
			uuiitem.SetUIActive(false);
			uuiitem2.SetUIActive(false);
			return;
		}
		bool editBattleTeamMatching = ModelBase<InstanceDungeonEntranceModel>.Instance.EditBattleTeamMatching;
		string textTableId2 = editBattleTeamMatching ? "EditBattleTeamCancelMatch" : "MatchingButtonLeader";
		Singleton<LguiUtil>.Instance.SetLocalText(text, textTableId2, Array.Empty<object>());
		bool uiactive = ModelBase<InstanceDungeonModel>.Instance.IsTeamNotFull() && !editBattleTeamMatching;
		uuiitem.SetUIActive(uiactive);
		bool uiactive2 = !ModelBase<InstanceDungeonModel>.Instance.IsAllPlayerInMatchTeam();
		uuiitem2.SetUIActive(uiactive2);
	}

	// Token: 0x0600C98C RID: 51596 RVA: 0x00357EE4 File Offset: 0x003560E4
	private UniTask CreateAllEditBattleRoleSlotsAsync()
	{
		EditBattleTeamView.<CreateAllEditBattleRoleSlotsAsync>d__56 <CreateAllEditBattleRoleSlotsAsync>d__;
		<CreateAllEditBattleRoleSlotsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateAllEditBattleRoleSlotsAsync>d__.<>4__this = this;
		<CreateAllEditBattleRoleSlotsAsync>d__.<>1__state = -1;
		<CreateAllEditBattleRoleSlotsAsync>d__.<>t__builder.Start<EditBattleTeamView.<CreateAllEditBattleRoleSlotsAsync>d__56>(ref <CreateAllEditBattleRoleSlotsAsync>d__);
		return <CreateAllEditBattleRoleSlotsAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C98D RID: 51597 RVA: 0x00357F28 File Offset: 0x00356128
	private UniTask NewEditBattleRoleSlot(UUIItem rootItem, int position)
	{
		EditBattleTeamView.<NewEditBattleRoleSlot>d__57 <NewEditBattleRoleSlot>d__;
		<NewEditBattleRoleSlot>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewEditBattleRoleSlot>d__.<>4__this = this;
		<NewEditBattleRoleSlot>d__.rootItem = rootItem;
		<NewEditBattleRoleSlot>d__.position = position;
		<NewEditBattleRoleSlot>d__.<>1__state = -1;
		<NewEditBattleRoleSlot>d__.<>t__builder.Start<EditBattleTeamView.<NewEditBattleRoleSlot>d__57>(ref <NewEditBattleRoleSlot>d__);
		return <NewEditBattleRoleSlot>d__.<>t__builder.Task;
	}

	// Token: 0x0600C98E RID: 51598 RVA: 0x00357F7C File Offset: 0x0035617C
	[NullableContext(2)]
	private void RefreshAllEditBattleRoleSlots(int[] refreshPosition = null)
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		instance.RefreshAllEmptySlotData();
		UUIItem uuiitem = base.GetButton(18).RootUIComp.Get();
		EditBattleRoleSlotData[] getAllRoleSlotData = instance.GetAllRoleSlotData;
		if (getAllRoleSlotData == null || getAllRoleSlotData.Length == 0)
		{
			uuiitem.SetUIActive(false);
			return;
		}
		bool uiactive = false;
		for (int i = 0; i < getAllRoleSlotData.Length; i++)
		{
			if (getAllRoleSlotData[i].GetRoleData != null)
			{
				uiactive = true;
				break;
			}
		}
		uuiitem.SetUIActive(uiactive);
		for (int j = 1; j <= 4; j++)
		{
			EditBattleRoleSlotData editBattleRoleSlotData = getAllRoleSlotData[j - 1];
			if (editBattleRoleSlotData != null)
			{
				FormationRoleView formationRoleView = this.GetFormationRoleView(j);
				if (formationRoleView != null)
				{
					if (editBattleRoleSlotData.IsProhibit)
					{
						this.RefreshRoleView(j, 0, 0, 0, "", 0, 0);
						formationRoleView.SetCanAddRole(false);
					}
					else
					{
						if (refreshPosition != null)
						{
							bool flag = false;
							for (int k = 0; k < refreshPosition.Length; k++)
							{
								if (refreshPosition[k] == j)
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								goto IL_1C2;
							}
						}
						formationRoleView.SetCanAddRole(true);
						bool isMultiInstanceDungeon = ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon;
						EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
						if (getRoleData != null)
						{
							int configId = getRoleData.ConfigId;
							int level = getRoleData.Level;
							int skinId = getRoleData.SkinId;
							string roleName = ModelBase<RoleModel>.Instance.GetRoleName(configId, null);
							if (!isMultiInstanceDungeon)
							{
								this.RefreshRoleView(j, configId, skinId, level, roleName ?? "", 0, getRoleData.PlayerId);
							}
							else
							{
								this.RefreshRoleView(j, configId, skinId, level, getRoleData.GetName() ?? "", getRoleData.OnlineIndex.GetValueOrDefault(1), getRoleData.PlayerId);
								this.RefreshFormationRoleViewPlayStationItem(j, getRoleData.ThirdPartyOnlineId);
								formationRoleView.RefreshPrepareState();
							}
						}
						else
						{
							this.RefreshRoleView(j, 0, 0, 0, "", 0, 0);
							if (isMultiInstanceDungeon)
							{
								formationRoleView.RefreshPrepareState();
							}
						}
					}
				}
			}
			IL_1C2:;
		}
		bool editBattleTeamMatching = ModelBase<InstanceDungeonEntranceModel>.Instance.EditBattleTeamMatching;
		this.RefreshMatch(editBattleTeamMatching);
		this.UpdateRecommendLevel();
	}

	// Token: 0x0600C98F RID: 51599 RVA: 0x00358171 File Offset: 0x00356371
	[NullableContext(2)]
	private void RefreshFormationRoleViewPlayStationItem(int position, string onlineId)
	{
		FormationRoleView formationRoleView = this.GetFormationRoleView(position);
		if (formationRoleView == null)
		{
			return;
		}
		formationRoleView.RefreshThirdPartyItem(onlineId);
	}

	// Token: 0x0600C990 RID: 51600 RVA: 0x00358188 File Offset: 0x00356388
	private void RefreshRoleView(int position, int roleId = 0, int skinId = 0, int level = 0, string name = "", int onlineIndex = 0, int playerId = 0)
	{
		int num = position - 1;
		FormationRoleView formationRoleView = this.GetFormationRoleView(position);
		if (formationRoleView == null)
		{
			return;
		}
		UUISpriteTransition uiSpriteTransition = base.GetUiSpriteTransition(this.ExitSkillIconList[num]);
		string path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_TeamRoleSkillNone");
		if (roleId == 0)
		{
			formationRoleView.ResetRole();
		}
		else
		{
			formationRoleView.Refresh(roleId, skinId, level, name, onlineIndex, playerId, "", this.CanUseSpecialTrailRole);
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

	// Token: 0x0600C991 RID: 51601 RVA: 0x0035828C File Offset: 0x0035648C
	private void RefreshEnterButtonEnable()
	{
		this.RefreshTowerDefenceWarningTips();
		UUIButtonComponent button = base.GetButton(4);
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		if (instance.IsMultiInstanceDungeon && ModelBase<InstanceDungeonModel>.Instance.IsMatchTeamHost())
		{
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.EditBattleTeamMatching)
			{
				button.SetSelfInteractive(true);
				return;
			}
			if (!instance.GetIsAllReady)
			{
				Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LYY, "[EditBattleTeam] 有玩家未准备", default(ReadOnlySpan<ValueTuple<string, object>>));
				button.SetSelfInteractive(false);
				return;
			}
			if (ControllerBase<TowerDefenseController>.Instance.CheckInUiFlow() && !ControllerBase<TowerDefenseController>.Instance.CheckAllPhantomsReady())
			{
				Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.WZ, "[EditBattleTeam] 塔防队伍声骸数不足", default(ReadOnlySpan<ValueTuple<string, object>>));
				button.SetSelfInteractive(false);
				return;
			}
			if (ModelBase<DangoAbyssModel>.Instance.CheckInAbyssEditFormationState() && !ModelBase<DangoAbyssModel>.Instance.CheckAllDangoReady())
			{
				Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.YZY, "[EditBattleTeam] 团子深渊队伍团子数不足", default(ReadOnlySpan<ValueTuple<string, object>>));
				button.SetSelfInteractive(false);
				return;
			}
			button.SetSelfInteractive(true);
			return;
		}
		else
		{
			if (!ControllerBase<LordGymController>.Instance.IsInLordGymDungeon() && !ModelBase<TowerModel>.Instance.IsOpenFloorFormation() && instance.IsAllRoleDie)
			{
				Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LYY, "[EditBattleTeam] 全角色已死亡", default(ReadOnlySpan<ValueTuple<string, object>>));
				button.SetSelfInteractive(false);
				return;
			}
			if (!instance.GetAllRoleCanAddToTeam().Item1)
			{
				Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LYY, "[EditBattleTeam] 未通过副本条件检测", default(ReadOnlySpan<ValueTuple<string, object>>));
				button.SetSelfInteractive(false);
				return;
			}
			int roleCountInRoleSlot = instance.GetRoleCountInRoleSlot();
			if ((instance.IsMultiInstanceDungeon || ControllerBase<TowerDefenseController>.Instance.CheckInUiFlow()) && !instance.IsInLimitRoleCount(roleCountInRoleSlot))
			{
				Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LYY, "[EditBattleTeam] 角色人数不符合要求", default(ReadOnlySpan<ValueTuple<string, object>>));
				button.SetSelfInteractive(false);
				return;
			}
			if (ControllerBase<TowerDefenseController>.Instance.CheckInUiFlow() && !ControllerBase<TowerDefenseController>.Instance.CheckAllPhantomsReady())
			{
				Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.WZ, "[EditBattleTeam] 塔防队伍声骸数不足", default(ReadOnlySpan<ValueTuple<string, object>>));
				button.SetSelfInteractive(false);
				return;
			}
			if (ModelBase<DangoAbyssModel>.Instance.CheckInAbyssEditFormationState() && !ModelBase<DangoAbyssModel>.Instance.CheckAllDangoReady())
			{
				Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.YZY, "[EditBattleTeam] 团子深渊队伍团子数不足", default(ReadOnlySpan<ValueTuple<string, object>>));
				button.SetSelfInteractive(false);
				return;
			}
			button.SetSelfInteractive(true);
			return;
		}
	}

	// Token: 0x0600C992 RID: 51602 RVA: 0x003584C4 File Offset: 0x003566C4
	private void RefreshTowerDefenceWarningTips()
	{
		UUISprite sprite = base.GetSprite(32);
		if (sprite == null)
		{
			return;
		}
		if (!ControllerBase<TowerDefenseController>.Instance.CheckInUiFlow())
		{
			sprite.SetUIActive(false);
			return;
		}
		bool flag = ControllerBase<TowerDefenseController>.Instance.CheckNeedSurvivalWarning();
		sprite.SetUIActive(flag);
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(33), "TowerDefence_Survive_WarnText", Array.Empty<object>());
		}
		this.UpdateRecommendLevel();
	}

	// Token: 0x0600C993 RID: 51603 RVA: 0x0035852C File Offset: 0x0035672C
	private void SetCloseButtonVisible(bool bVisible)
	{
		UUIButtonComponent button = base.GetButton(3);
		if (button == null)
		{
			return;
		}
		UUIItem uuiitem = button.RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(bVisible);
		}
	}

	// Token: 0x0600C994 RID: 51604 RVA: 0x00358560 File Offset: 0x00356760
	private void OnAddButtonClicked(int position)
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		Aki.Config.FightFormation? getCurrentFightFormation = instance.GetCurrentFightFormation;
		if (getCurrentFightFormation != null && !getCurrentFightFormation.Value.ChooseRole)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NoChangeRole", Array.Empty<object>());
			return;
		}
		instance.SetCurrentEditPosition(position);
		EditBattleRoleSlotData roleSlotData = instance.GetRoleSlotData(position);
		if (roleSlotData == null)
		{
			return;
		}
		EditBattleRoleData selectedRoleData = roleSlotData.GetRoleData;
		if (selectedRoleData != null)
		{
			if (ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon && ModelBase<InstanceDungeonModel>.Instance.IsMatchTeamHost() && !selectedRoleData.IsSelf)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MatchingKickOut);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.KickMatchTeamPlayerRequest(selectedRoleData.PlayerId).Forget<bool>();
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			if (!roleSlotData.CanEditRoleSlot)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("BattleTeamNotMyRole", Array.Empty<object>());
				return;
			}
			if (!instance.GetLeaderIsSelf && selectedRoleData.IsReady)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("BattleTeamReadyRole", Array.Empty<object>());
				return;
			}
			this.OpenTeamSelectView(position);
		}
		else
		{
			if (ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon && !ModelBase<InstanceDungeonModel>.Instance.IsMatchTeamHost())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("BattleTeamNotMyRole", Array.Empty<object>());
				return;
			}
			if (roleSlotData.IsProhibit)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("BattleTeamPositionCanNotEdit", Array.Empty<object>());
				return;
			}
			this.OpenTeamSelectView(position);
		}
		this.SetCloseButtonVisible(false);
	}

	// Token: 0x0600C995 RID: 51605 RVA: 0x003586D7 File Offset: 0x003568D7
	[NullableContext(2)]
	private FormationRoleView GetFormationRoleView(int position)
	{
		if (position > this.EditBattleRoleSlots.Count)
		{
			return null;
		}
		return this.EditBattleRoleSlots[position - 1] as FormationRoleView;
	}

	// Token: 0x0600C996 RID: 51606 RVA: 0x003586FC File Offset: 0x003568FC
	private EditBattleTeamView.EEditResultType GetEditResultType(int roleConfigId)
	{
		if (roleConfigId == 0)
		{
			return EditBattleTeamView.EEditResultType.SelectedNone;
		}
		EditBattleRoleSlotData getCurrentEditRoleSlotData = ModelBase<EditBattleTeamModel>.Instance.GetCurrentEditRoleSlotData;
		if (getCurrentEditRoleSlotData == null)
		{
			return EditBattleTeamView.EEditResultType.None;
		}
		int? getRoleConfigId = getCurrentEditRoleSlotData.GetRoleConfigId;
		if (getRoleConfigId.GetValueOrDefault() == roleConfigId & getRoleConfigId != null)
		{
			return EditBattleTeamView.EEditResultType.GoDown;
		}
		if (ModelBase<EditBattleTeamModel>.Instance.HasSameConfigIdInAnyOwnRoleSlot(roleConfigId))
		{
			return EditBattleTeamView.EEditResultType.InOtherSlot;
		}
		return EditBattleTeamView.EEditResultType.GoUp;
	}

	// Token: 0x0600C997 RID: 51607 RVA: 0x00358750 File Offset: 0x00356950
	private bool GetConfirmButtonEnableFunction(int roleConfigId)
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		EditBattleRoleData getRoleData = instance.GetCurrentEditRoleSlotData.GetRoleData;
		if (!instance.CanAddRoleToEditTeam(roleConfigId) && roleConfigId <= 100000)
		{
			return false;
		}
		switch (this.GetEditResultType(roleConfigId))
		{
		case EditBattleTeamView.EEditResultType.GoUp:
			return true;
		case EditBattleTeamView.EEditResultType.GoDown:
			return true;
		case EditBattleTeamView.EEditResultType.InOtherSlot:
			return getRoleData != null;
		default:
			return true;
		}
	}

	// Token: 0x0600C998 RID: 51608 RVA: 0x003587A8 File Offset: 0x003569A8
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
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		EditBattleRoleSlotData getCurrentEditRoleSlotData = instance.GetCurrentEditRoleSlotData;
		if (!instance.CanAddRoleToEditTeam(roleConfigId) && roleConfigId <= 100000)
		{
			return "JoinText";
		}
		switch (this.GetEditResultType(roleConfigId))
		{
		case EditBattleTeamView.EEditResultType.GoUp:
			if (!getCurrentEditRoleSlotData.HasRole)
			{
				return "JoinText";
			}
			return "ChangeText";
		case EditBattleTeamView.EEditResultType.GoDown:
			return "GoDownText";
		case EditBattleTeamView.EEditResultType.InOtherSlot:
			return "ChangeText";
		default:
			return "JoinText";
		}
	}

	// Token: 0x0600C999 RID: 51609 RVA: 0x00358830 File Offset: 0x00356A30
	private void OnEnsureFormation(int roleId)
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		EditBattleRoleSlotData getCurrentEditRoleSlotData = instance.GetCurrentEditRoleSlotData;
		EditBattleRoleData getRoleData = getCurrentEditRoleSlotData.GetRoleData;
		if (getRoleData != null && !getRoleData.IsSelf)
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LYY, "[EditBattleTeam]无法改变别的玩家的角色", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamLastRole", Array.Empty<object>());
			return;
		}
		this.SetCloseButtonVisible(true);
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		if (roleDataById == null)
		{
			return;
		}
		if (!roleDataById.IsTrialRole() && !instance.CanAddRoleToEditTeam(roleId))
		{
			return;
		}
		switch (this.GetEditResultType(roleId))
		{
		case EditBattleTeamView.EEditResultType.GoDown:
			if (getRoleData != null)
			{
				ModelBase<TowerDefenseModel>.Instance.ResetPhantomOwnerDataByConfigId(getRoleData.ConfigId);
			}
			getCurrentEditRoleSlotData.ResetRoleData();
			break;
		case EditBattleTeamView.EEditResultType.InOtherSlot:
		{
			if (getCurrentEditRoleSlotData == null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("IsInTeam", Array.Empty<object>());
				return;
			}
			EditBattleRoleSlotData slotDataByConfigId = instance.GetSlotDataByConfigId(roleId);
			if (slotDataByConfigId == null)
			{
				return;
			}
			EditBattleRoleData getRoleData2 = slotDataByConfigId.GetRoleData;
			if (getRoleData2 == null)
			{
				return;
			}
			EditBattleRoleData getRoleData3 = getCurrentEditRoleSlotData.GetRoleData;
			if (getRoleData3 == null)
			{
				slotDataByConfigId.ResetRoleData();
				return;
			}
			slotDataByConfigId.SetRoleData(getRoleData3);
			getCurrentEditRoleSlotData.SetRoleData(getRoleData2);
			break;
		}
		case EditBattleTeamView.EEditResultType.SelectedNone:
			return;
		default:
		{
			RoleDataBase roleDataById2 = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			RoleLevelData levelData = roleDataById2.GetLevelData();
			EditBattleRoleData editBattleRoleData = getCurrentEditRoleSlotData.GetRoleData;
			if (editBattleRoleData == null)
			{
				editBattleRoleData = instance.CreateRoleDataFromRoleInstance(roleDataById2);
			}
			else
			{
				ModelBase<TowerDefenseModel>.Instance.ResetPhantomOwnerDataByConfigId(editBattleRoleData.ConfigId);
			}
			editBattleRoleData.ConfigId = roleId;
			editBattleRoleData.Level = levelData.GetLevel();
			editBattleRoleData.SkinId = roleDataById2.GetRoleSkinId();
			getCurrentEditRoleSlotData.SetRoleData(editBattleRoleData);
			break;
		}
		}
		if (instance.IsMultiInstanceDungeon)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Formation;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "[EditBattleTeam]请求改变战前编队角色:RoleConfigList";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleConfigList", instance.GetOwnRoleConfigIdList);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<InstanceDungeonEntranceController>.Instance.MatchChangeRoleRequest(instance.GetOwnRoleConfigIdList.Item1).Forget<bool>();
			return;
		}
		this.RefreshEnterButtonEnable();
		Singleton<EventSystem>.Instance.Emit<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, ERefreshEditBattleRoleSlotDataReason.ClickConfirmTeam);
	}

	// Token: 0x0600C99A RID: 51610 RVA: 0x00358A31 File Offset: 0x00356C31
	private void OnCloseSelectedRoleView()
	{
		this.SetCloseButtonVisible(true);
	}

	// Token: 0x0600C99B RID: 51611 RVA: 0x00358A3C File Offset: 0x00356C3C
	private bool IfNeedHideMultiFormationTab()
	{
		int? getInstanceDungeonId = ModelBase<EditBattleTeamModel>.Instance.GetInstanceDungeonId;
		if (getInstanceDungeonId != null)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(getInstanceDungeonId.Value);
			if (config != null && config.Value.InstSubType == 33)
			{
				return true;
			}
		}
		Aki.Config.FightFormation? getCurrentFightFormation = ModelBase<EditBattleTeamModel>.Instance.GetCurrentFightFormation;
		return ModelBase<GameModeModel>.Instance.IsMulti || (getCurrentFightFormation != null && !getCurrentFightFormation.Value.ChooseRole);
	}

	// Token: 0x0600C99C RID: 51612 RVA: 0x00358AC4 File Offset: 0x00356CC4
	private UniTask CreateAllFormationButtons()
	{
		EditBattleTeamView.<CreateAllFormationButtons>d__72 <CreateAllFormationButtons>d__;
		<CreateAllFormationButtons>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateAllFormationButtons>d__.<>4__this = this;
		<CreateAllFormationButtons>d__.<>1__state = -1;
		<CreateAllFormationButtons>d__.<>t__builder.Start<EditBattleTeamView.<CreateAllFormationButtons>d__72>(ref <CreateAllFormationButtons>d__);
		return <CreateAllFormationButtons>d__.<>t__builder.Task;
	}

	// Token: 0x0600C99D RID: 51613 RVA: 0x00358B07 File Offset: 0x00356D07
	private EditFormationTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new EditFormationTabItem();
	}

	// Token: 0x0600C99E RID: 51614 RVA: 0x00358B10 File Offset: 0x00356D10
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

	// Token: 0x0600C99F RID: 51615 RVA: 0x00358B74 File Offset: 0x00356D74
	private bool IsNeedRevive(int roleConfigId)
	{
		if (ModelBase<TowerModel>.Instance.IsOpenFloorFormation())
		{
			return false;
		}
		if (ControllerBase<LordGymController>.Instance.IsInLordGymDungeon())
		{
			return false;
		}
		if (ControllerBase<AdamSmasherController>.Instance.IsInAdamSmasherDungeon())
		{
			return false;
		}
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return false;
		}
		bool flag = ModelBase<EditBattleTeamModel>.Instance.IsInEditBattleTeam(roleConfigId, false);
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleConfigId, true);
		return (roleDataById == null || !roleDataById.IsTrialRole()) && !flag && ModelBase<EditFormationModel>.Instance.IsRoleDead(roleConfigId);
	}

	// Token: 0x0600C9A0 RID: 51616 RVA: 0x00358BF4 File Offset: 0x00356DF4
	private void OnFormationButtonClicked(int index)
	{
		if (this.IsTabInit)
		{
			this.IsTabInit = false;
			return;
		}
		int num = index + 1;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Formation;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "当点击编队按钮时";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("formationId", num);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		EditBattleTeamModel instance2 = ModelBase<EditBattleTeamModel>.Instance;
		RoleModel instance3 = ModelBase<RoleModel>.Instance;
		EditFormationData formationData = ModelBase<EditFormationModel>.Instance.GetFormationData(num);
		int[] array = (formationData != null) ? formationData.GetRoleIdList : null;
		int[] selfRoleSlotDataRoleIdList = instance2.SelfRoleSlotDataRoleIdList;
		for (int i = 0; i < selfRoleSlotDataRoleIdList.Length; i++)
		{
			ModelBase<TowerDefenseModel>.Instance.ResetPhantomOwnerDataByConfigId(selfRoleSlotDataRoleIdList[i]);
		}
		for (int j = 1; j <= 4; j++)
		{
			EditBattleRoleSlotData roleSlotData = instance2.GetRoleSlotData(j);
			if (roleSlotData.IsProhibit)
			{
				roleSlotData.ResetRoleData();
			}
			else if (array == null)
			{
				roleSlotData.ResetRoleData();
			}
			else
			{
				int num2 = (j - 1 < array.Length) ? array[j - 1] : 0;
				if (num2 == 0)
				{
					roleSlotData.ResetRoleData();
				}
				else
				{
					RoleDataBase roleDataById = instance3.GetRoleDataById(num2, true);
					EditBattleRoleData roleData = instance2.CreateRoleDataFromRoleInstance(roleDataById);
					roleSlotData.SetRoleData(roleData);
				}
			}
		}
		this.RefreshAllEditBattleRoleSlots(null);
		this.RefreshEnterButtonEnable();
		Singleton<EventSystem>.Instance.Emit<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, ERefreshEditBattleRoleSlotDataReason.ChangeTeamOffline);
	}

	// Token: 0x0600C9A1 RID: 51617 RVA: 0x00358D24 File Offset: 0x00356F24
	private void RefreshTitle(bool isInTower)
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		UUIText text = base.GetText(16);
		int[] array = null;
		IEditBattleTeamViewParam editBattleTeamViewParam = this.OpenParam as IEditBattleTeamViewParam;
		if (editBattleTeamViewParam != null && editBattleTeamViewParam.IsHideTitle)
		{
			base.GetItem(28).SetUIActive(false);
			return;
		}
		if (isInTower)
		{
			int currentSelectFloor = ModelBase<TowerModel>.Instance.CurrentSelectFloor;
			TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(currentSelectFloor);
			string towerAreaName = ConfigBase<TowerClimbConfig>.Instance.GetTowerAreaName(currentSelectFloor);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), "Text_TowerAreaFloor_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				towerAreaName,
				towerInfo.Value.Floor
			}));
			array = towerInfo.Value.GetRecommendElementArray();
		}
		else
		{
			InstanceDungeon? getCurrentDungeonConfig = instance.GetCurrentDungeonConfig;
			if (getCurrentDungeonConfig != null)
			{
				string text2 = ConfigMultiTextLang.GetLocalTextNew(getCurrentDungeonConfig.Value.MapName, null) ?? "";
				array = getCurrentDungeonConfig.Value.GetRecommendElementArray();
				if (ModelBase<GameModeModel>.Instance.IsMulti)
				{
					text2 += ModelBase<OnlineModel>.Instance.GetMultiInstanceRecommendLevelText(getCurrentDungeonConfig.Value.Id);
				}
				if (text != null)
				{
					text.SetText(text2, true);
				}
			}
		}
		UUIItem item = base.GetItem(23);
		if (array == null || array.Length == 0)
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		UUIItem item2 = base.GetItem(21);
		UUIItem item3 = base.GetItem(22);
		for (int i = 0; i < array.Length; i++)
		{
			UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(item3, item2);
			MiniElementItem item4 = new MiniElementItem(array[i], uuiitem, uuiitem.GetOwner());
			this.ElementList.Add(item4);
		}
		item3.SetUIActive(false);
	}

	// Token: 0x0600C9A2 RID: 51618 RVA: 0x00358EE4 File Offset: 0x003570E4
	private void UpdateRecommendLevel()
	{
		UUIItem item = base.GetItem(24);
		int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
		if (ModelBase<TowerModel>.Instance.CurrentSelectFloor != -1 || ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon)
		{
			item.SetUIActive(false);
			return;
		}
		bool flag = ModelBase<InstanceDungeonModel>.Instance.CheckPrewarFormationAverageLowLevel(instanceId);
		item.SetUIActive(flag && this.CanShowLowLevelTips());
	}

	// Token: 0x0600C9A3 RID: 51619 RVA: 0x00358F44 File Offset: 0x00357144
	private bool CanShowLowLevelTips()
	{
		return !ControllerBase<TowerDefenseController>.Instance.CheckInUiFlow() || !ControllerBase<TowerDefenseController>.Instance.CheckNeedSurvivalWarning();
	}

	// Token: 0x0600C9A4 RID: 51620 RVA: 0x00358F64 File Offset: 0x00357164
	private void ExchangeRoleCallBack(int position1, int position2, int roleId1, int roleId2)
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		for (int i = 1; i <= 4; i++)
		{
			EditBattleRoleSlotData roleSlotData = instance.GetRoleSlotData(i);
			if (roleSlotData.IsProhibit)
			{
				roleSlotData.ResetRoleData();
			}
			else
			{
				int num = 0;
				if (i == position1)
				{
					num = roleId1;
				}
				if (i == position2)
				{
					num = roleId2;
				}
				if (num != 0)
				{
					RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
					EditBattleRoleData roleData = instance.CreateRoleDataFromRoleInstance(roleDataById);
					roleSlotData.SetRoleData(roleData);
				}
			}
		}
		this.RefreshAllEditBattleRoleSlots(new int[]
		{
			position1,
			position2
		});
	}

	// Token: 0x04006074 RID: 24692
	private readonly List<FormationRoleSlot> EditBattleRoleSlots = new List<FormationRoleSlot>();

	// Token: 0x04006075 RID: 24693
	private readonly List<MiniElementItem> ElementList = new List<MiniElementItem>();

	// Token: 0x04006076 RID: 24694
	private readonly int[] ExitSkillIconList = new int[]
	{
		25,
		26,
		27
	};

	// Token: 0x04006077 RID: 24695
	private double RequestTimeStamp;

	// Token: 0x04006078 RID: 24696
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithTitle<EditFormationTabItem> TabComponent;

	// Token: 0x04006079 RID: 24697
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400607A RID: 24698
	private bool IsShowChatInfo;

	// Token: 0x0400607B RID: 24699
	private bool IsTabInit;

	// Token: 0x0400607C RID: 24700
	private bool CanUseSpecialTrailRole;

	// Token: 0x02007E21 RID: 32289
	[NullableContext(0)]
	private class EChildComponentType
	{
		// Token: 0x0402AF49 RID: 175945
		public const int RoleSlot1 = 0;

		// Token: 0x0402AF4A RID: 175946
		public const int RoleSlot2 = 1;

		// Token: 0x0402AF4B RID: 175947
		public const int RoleSlot3 = 2;

		// Token: 0x0402AF4C RID: 175948
		public const int CloseButton = 3;

		// Token: 0x0402AF4D RID: 175949
		public const int EnterButton = 4;

		// Token: 0x0402AF4E RID: 175950
		public const int EnterButtonText = 5;

		// Token: 0x0402AF4F RID: 175951
		public const int AddPlayerButton = 6;

		// Token: 0x0402AF50 RID: 175952
		public const int InviteButton = 7;

		// Token: 0x0402AF51 RID: 175953
		public const int ChatButton = 8;

		// Token: 0x0402AF52 RID: 175954
		public const int ChatInfoItem = 9;

		// Token: 0x0402AF53 RID: 175955
		public const int ChatInfoText = 10;

		// Token: 0x0402AF54 RID: 175956
		public const int TabComponent = 11;

		// Token: 0x0402AF55 RID: 175957
		public const int TabItem = 12;

		// Token: 0x0402AF56 RID: 175958
		public const int TowerItem = 13;

		// Token: 0x0402AF57 RID: 175959
		public const int TowerDetailsBtn = 14;

		// Token: 0x0402AF58 RID: 175960
		public const int TowerRecommendBtn = 15;

		// Token: 0x0402AF59 RID: 175961
		public const int BattleTitleText = 16;

		// Token: 0x0402AF5A RID: 175962
		public const int BattleIcon = 17;

		// Token: 0x0402AF5B RID: 175963
		public const int ExitSkillButton = 18;

		// Token: 0x0402AF5C RID: 175964
		public const int TitleText = 19;

		// Token: 0x0402AF5D RID: 175965
		public const int QuickSelectButton = 20;

		// Token: 0x0402AF5E RID: 175966
		public const int ElementContent = 21;

		// Token: 0x0402AF5F RID: 175967
		public const int ElementItem = 22;

		// Token: 0x0402AF60 RID: 175968
		public const int RecommendElementItem = 23;

		// Token: 0x0402AF61 RID: 175969
		public const int LowLevelItem = 24;

		// Token: 0x0402AF62 RID: 175970
		public const int ExitSkillIcon1 = 25;

		// Token: 0x0402AF63 RID: 175971
		public const int ExitSkillIcon2 = 26;

		// Token: 0x0402AF64 RID: 175972
		public const int ExitSkillIcon3 = 27;

		// Token: 0x0402AF65 RID: 175973
		public const int TitleItem = 28;

		// Token: 0x0402AF66 RID: 175974
		public const int DragItem = 29;

		// Token: 0x0402AF67 RID: 175975
		public const int DragRoleItem = 30;

		// Token: 0x0402AF68 RID: 175976
		public const int BtnTipsItem = 31;

		// Token: 0x0402AF69 RID: 175977
		public const int WarningTipsSprite = 32;

		// Token: 0x0402AF6A RID: 175978
		public const int WarningTipsText = 33;
	}

	// Token: 0x02007E22 RID: 32290
	[NullableContext(0)]
	private enum EEditResultType
	{
		// Token: 0x0402AF6C RID: 175980
		None,
		// Token: 0x0402AF6D RID: 175981
		GoUp,
		// Token: 0x0402AF6E RID: 175982
		GoDown,
		// Token: 0x0402AF6F RID: 175983
		InOtherSlot,
		// Token: 0x0402AF70 RID: 175984
		SelectedNone
	}
}
