using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Summon;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

// Token: 0x02001B40 RID: 6976
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EditFormationController : UiControllerBase<EditFormationController>
{
	// Token: 0x0600C9A6 RID: 51622 RVA: 0x00358FF0 File Offset: 0x003571F0
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600C9A7 RID: 51623 RVA: 0x00359050 File Offset: 0x00357250
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600C9A8 RID: 51624 RVA: 0x003590AE File Offset: 0x003572AE
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<UpdateFormationNotify>(ENotifyMessageId.UpdateFormationNotify, new Action<UpdateFormationNotify, Net.CallbackStatus>(this.UpdateFormationNotify));
	}

	// Token: 0x0600C9A9 RID: 51625 RVA: 0x003590CC File Offset: 0x003572CC
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.UpdateFormationNotify);
	}

	// Token: 0x0600C9AA RID: 51626 RVA: 0x003590DE File Offset: 0x003572DE
	protected override void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.EditFormationView, new Func<EUiViewName, object, bool>(this.CanOpenView), "EditFormationController");
	}

	// Token: 0x0600C9AB RID: 51627 RVA: 0x00359100 File Offset: 0x00357300
	protected override void OnRemoveOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.EditFormationView, new Func<EUiViewName, object, bool>(this.CanOpenView));
	}

	// Token: 0x0600C9AC RID: 51628 RVA: 0x00359120 File Offset: 0x00357320
	public bool CanOpenView(EUiViewName viewName, object parameter)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10007))
		{
			Singleton<Log>.Instance.Warn(ELogModule.Formation, ELogAuthor.LJQ, "打开编队按钮时，未满足开启条件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (ModelBase<FunctionModel>.Instance.IsLockByBehaviorTree(10007))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamForbitState", Array.Empty<object>());
			return false;
		}
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		if (instance.IsPhantomTeam)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Formation, ELogAuthor.CH, "打开编队按钮时，当前编队为声骸编队，无法打开", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterFormationTip", Array.Empty<object>());
			return false;
		}
		EntityHandle getCurrentEntity = instance.GetCurrentEntity;
		if (getCurrentEntity == null || !getCurrentEntity.Valid)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Formation, ELogAuthor.LJQ, "打开编队按钮时，当前实体不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		if (instance.GetCurrentGroupLivingState(playerId) == ETeamLivingState.Dead)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Formation, ELogAuthor.LYY, "打开编队按钮时，当前编队已死亡", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		BaseTagComponent component = getCurrentEntity.Entity.GetComponent<BaseTagComponent>();
		if (component == null || !component.Valid)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Formation, ELogAuthor.LJQ, "打开编队按钮时，当前实体的 TagComponent 不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		CharacterBuffComponent component2 = getCurrentEntity.Entity.GetComponent<CharacterBuffComponent>();
		if (component2 == null || !component2.Valid)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Formation, ELogAuthor.LJQ, "打开编队按钮时，当前实体的 CharacterBuffComponent 不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		RoleDriveVehicleComponent component3 = getCurrentEntity.Entity.GetComponent<RoleDriveVehicleComponent>();
		if (component3 != null && component3.IsOnVehicle)
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "打开编队按钮时，当前角色在载具上", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamForbitState", Array.Empty<object>());
			return false;
		}
		if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "打开编队按钮时，有试用角色无法打开", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamForbitState", Array.Empty<object>());
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleTeamLimit", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"]))
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "打开编队按钮时，当前角色正在水中", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamForbitState", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.溺水"]))
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "打开编队按钮时，当前角色正在播放溺水", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamForbitState", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]))
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "打开编队按钮时，当前角色处于空中", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamForbitState", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]))
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "打开编队按钮时，当前角色在战斗中", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ForbiddenActionInFight", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"]))
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "打开编队按钮时，当前角色处于攀爬中", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamForbitState", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]))
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.YZH, "打开编队按钮时，当前角色不能切人", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamForbitState", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.幻象变身中"]))
		{
			EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(getCurrentEntity.Entity, ESummonType.ConcomitantVision, 1);
			if (summonedEntity != null)
			{
				BaseTagComponent component4 = summonedEntity.Entity.GetComponent<BaseTagComponent>();
				if (component4 != null && component4.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]))
				{
					Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "打开编队按钮时，当前角色为声骸变身状态且处于空中", default(ReadOnlySpan<ValueTuple<string, object>>));
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamForbitState", Array.Empty<object>());
					return false;
				}
			}
		}
		if (component2.GetBuffTotalStackById(90003001L, false) > 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.ZFJ, "打开编队按钮时，当前角色在电梯中", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamForbitState", Array.Empty<object>());
			return false;
		}
		CharacterWalkOnWaterComponent component5 = getCurrentEntity.Entity.GetComponent<CharacterWalkOnWaterComponent>();
		if (component5 != null && component5.WalkOnWaterStage > EWalkOnWaterStage.None)
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.WLJ, "打开编队按钮时，当前角色在水面上行走", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamForbitState", Array.Empty<object>());
			return false;
		}
		if (instance.CurrentGroupType.GetValueOrDefault() != ETeamGroupType.Battle)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Formation, ELogAuthor.LYY, "打开编队按钮时，在非战斗编队中无法打开", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return true;
	}

	// Token: 0x0600C9AD RID: 51629 RVA: 0x0035963F File Offset: 0x0035783F
	public void OpenEditFormationView(object param = null)
	{
		if (this.CanOpenView(EUiViewName.EditFormationView, null) && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.EditFormationView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.EditFormationView, param, null);
		}
	}

	// Token: 0x0600C9AE RID: 51630 RVA: 0x00359671 File Offset: 0x00357871
	private void OnDataDone()
	{
		this.GetFormationDataRequest();
	}

	// Token: 0x0600C9AF RID: 51631 RVA: 0x0035967C File Offset: 0x0035787C
	[NullableContext(1)]
	private void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
	{
		SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
		int? num = (getCurrentTeamItem != null) ? new int?(getCurrentTeamItem.GetConfigId) : null;
		if (num != null)
		{
			EditFormationData getCurrentFormationData = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData;
			if (getCurrentFormationData == null)
			{
				return;
			}
			getCurrentFormationData.SetCurrentRole(num.Value);
		}
	}

	// Token: 0x0600C9B0 RID: 51632 RVA: 0x003596D4 File Offset: 0x003578D4
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.EditFormationView && this.CacheFormationNotify != null)
		{
			RepeatedField<PlayerFightFormations> playersFormations = this.CacheFormationNotify.PlayersFormations;
			ModelBase<EditFormationModel>.Instance.UpdatePlayerFormations(playersFormations);
			this.CacheFormationNotify = null;
		}
	}

	// Token: 0x0600C9B1 RID: 51633 RVA: 0x00359714 File Offset: 0x00357914
	public void RefreshMainRoleInfo()
	{
		ModelBase<EditFormationModel>.Instance.ChangeEditedMainRole();
	}

	// Token: 0x0600C9B2 RID: 51634 RVA: 0x00359720 File Offset: 0x00357920
	public void GetFormationDataRequest()
	{
		Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LYY, "请求所有编队数据", default(ReadOnlySpan<ValueTuple<string, object>>));
		GetFormationDataRequest message = new GetFormationDataRequest();
		Singleton<Net>.Instance.Call<GetFormationDataResponse>(ERequestMessageId.GetFormationDataRequest, message, null, 0);
	}

	// Token: 0x0600C9B3 RID: 51635 RVA: 0x00359764 File Offset: 0x00357964
	[NullableContext(0)]
	public UniTask<bool> EditFormationRequest(int currentFormationId)
	{
		EditFormationController.<EditFormationRequest>d__15 <EditFormationRequest>d__;
		<EditFormationRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<EditFormationRequest>d__.<>4__this = this;
		<EditFormationRequest>d__.currentFormationId = currentFormationId;
		<EditFormationRequest>d__.<>1__state = -1;
		<EditFormationRequest>d__.<>t__builder.Start<EditFormationController.<EditFormationRequest>d__15>(ref <EditFormationRequest>d__);
		return <EditFormationRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600C9B4 RID: 51636 RVA: 0x003597B0 File Offset: 0x003579B0
	[NullableContext(0)]
	public UniTask<bool> UpdateFormationRequest(int formationId, bool isCurrent, [Nullable(1)] List<int> roleIdList, int currentRole)
	{
		EditFormationController.<UpdateFormationRequest>d__16 <UpdateFormationRequest>d__;
		<UpdateFormationRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<UpdateFormationRequest>d__.formationId = formationId;
		<UpdateFormationRequest>d__.isCurrent = isCurrent;
		<UpdateFormationRequest>d__.roleIdList = roleIdList;
		<UpdateFormationRequest>d__.currentRole = currentRole;
		<UpdateFormationRequest>d__.<>1__state = -1;
		<UpdateFormationRequest>d__.<>t__builder.Start<EditFormationController.<UpdateFormationRequest>d__16>(ref <UpdateFormationRequest>d__);
		return <UpdateFormationRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600C9B5 RID: 51637 RVA: 0x0035980C File Offset: 0x00357A0C
	[NullableContext(0)]
	public UniTask<bool> UpdateFightRoleRequest()
	{
		EditFormationController.<UpdateFightRoleRequest>d__17 <UpdateFightRoleRequest>d__;
		<UpdateFightRoleRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<UpdateFightRoleRequest>d__.<>1__state = -1;
		<UpdateFightRoleRequest>d__.<>t__builder.Start<EditFormationController.<UpdateFightRoleRequest>d__17>(ref <UpdateFightRoleRequest>d__);
		return <UpdateFightRoleRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600C9B6 RID: 51638 RVA: 0x00359848 File Offset: 0x00357A48
	private void UpdateFormationNotify(UpdateFormationNotify notify, Net.CallbackStatus status)
	{
		RepeatedField<PlayerFightFormations> playersFormations = notify.PlayersFormations;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Formation;
		ELogAuthor author = ELogAuthor.LYY;
		string message = "更新背包编队";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("formations", playersFormations);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ModelBase<OnlineModel>.Instance.RefreshWorldTeamRoleInfo(playersFormations);
		if (ModelBase<GameModeModel>.Instance.IsMulti && Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.EditFormationView))
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LYY, "更新背包编队时联机打开界面中，进行缓存", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CacheFormationNotify = notify;
			return;
		}
		ModelBase<EditFormationModel>.Instance.UpdatePlayerFormations(playersFormations);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshOnlineTeamList);
		this.CheckFormationAllowOnline();
		this.TryUpdateSpecialTrialRole();
	}

	// Token: 0x0600C9B7 RID: 51639 RVA: 0x003598F8 File Offset: 0x00357AF8
	private void TryUpdateSpecialTrialRole()
	{
		if (!ModelBase<EditFormationModel>.Instance.IsFormationHasSpecialTrialRole())
		{
			return;
		}
		foreach (int roleId in ModelBase<EditFormationModel>.Instance.GetFormationAllSpecialTrialRole())
		{
			ModelBase<TrialRoleModel>.Instance.SetTrialRoleVisibility(roleId, true);
		}
	}

	// Token: 0x0600C9B8 RID: 51640 RVA: 0x0035993C File Offset: 0x00357B3C
	private void CheckFormationAllowOnline()
	{
		bool enable = ModelBase<EditFormationModel>.Instance.IsCurFormationHasSpecialTrialRole();
		ModelBase<OnlineModel>.Instance.DisableOnline(EDisableOnlineType.TrialRole, enable, 0, 0);
	}

	// Token: 0x0400607D RID: 24701
	[Nullable(1)]
	private const string ForbiddenStatTips = "EditBattleTeamForbitState";

	// Token: 0x0400607E RID: 24702
	private UpdateFormationNotify CacheFormationNotify;
}
