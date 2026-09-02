using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using AkiClient.Game.Aki.Map.UISceneLevel.UI_Scene.UI_BP;
using CSharpScript.Game;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;
using CSharpScript.Game.Module.BossPiling;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.View;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x020027B3 RID: 10163
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class RoleController : UiControllerBase<RoleController>
{
	// Token: 0x06014143 RID: 82243 RVA: 0x0059B3A4 File Offset: 0x005995A4
	protected override bool OnInit()
	{
		Singleton<InputManager>.Instance.RegisterOpenViewFunc(EUiViewName.RoleRootView, this.OpenRoleMainViewByInput);
		return true;
	}

	// Token: 0x06014144 RID: 82244 RVA: 0x0059B3BC File Offset: 0x005995BC
	[NullableContext(2)]
	public bool CanOpenView(EUiViewName viewName, object arg = null)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10001))
		{
			return false;
		}
		if (ModelBase<SceneTeamModel>.Instance.IsPhantomTeam || ModelBase<SceneTeamModel>.Instance.HasPhantomRole())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterRoleTip", Array.Empty<object>());
			return false;
		}
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		return ModelBase<SceneTeamModel>.Instance.GetCurrentGroupLivingState(playerId) != ETeamLivingState.Dead || this.CheckInDeadCanOpenInstanceDungeon();
	}

	// Token: 0x06014145 RID: 82245 RVA: 0x0059B430 File Offset: 0x00599630
	private bool CheckInDeadCanOpenInstanceDungeon()
	{
		if (ModelBase<TowerModel>.Instance.CheckInTower())
		{
			return true;
		}
		BossRushModel instance = ModelBase<BossRushModel>.Instance;
		if (((instance != null) ? new bool?(instance.CheckInBossRush()) : null).GetValueOrDefault())
		{
			return true;
		}
		ShipTowerModel instance2 = ModelBase<ShipTowerModel>.Instance;
		if (((instance2 != null) ? new bool?(instance2.CheckInBattleShipTower()) : null).GetValueOrDefault())
		{
			return true;
		}
		BabelTowerModel instance3 = ModelBase<BabelTowerModel>.Instance;
		return ((instance3 != null) ? new bool?(instance3.CheckInBattleBabelTower()) : null).GetValueOrDefault() || ControllerBase<LordGymController>.Instance.IsInLordGymDungeon() || ModelBase<BossPilingModel>.Instance.CheckIsBossPiling() || ControllerBase<AdamSmasherController>.Instance.IsInAdamSmasherDungeon();
	}

	// Token: 0x06014146 RID: 82246 RVA: 0x0059B4F4 File Offset: 0x005996F4
	[NullableContext(2)]
	public void OpenRoleMainView(ERoleAgentType agentType, int selectRoleId = 0, List<int> roleIdList = null, EUiTabViewName? openTabView = null, TOpenViewCallBack finishCallback = null)
	{
		if (roleIdList == null)
		{
			roleIdList = new List<int>();
		}
		this.OpenRoleMainViewByParam(new OpenRoleMainViewData
		{
			AgentType = agentType,
			SelectRoleId = new int?(selectRoleId),
			RoleIdList = roleIdList,
			OpenTabView = openTabView,
			FinishCallback = finishCallback,
			TeamPositionType = new ETeamPositionType?(ETeamPositionType.Normal),
			Source = new ERoleViewSource?(ERoleViewSource.Normal)
		});
	}

	// Token: 0x06014147 RID: 82247 RVA: 0x0059B558 File Offset: 0x00599758
	public void OpenRoleMainViewByParam(IOpenRoleMainViewData param)
	{
		int valueOrDefault = param.SelectRoleId.GetValueOrDefault();
		List<int> roleIdList = param.RoleIdList ?? new List<int>();
		RoleViewAgent roleViewAgent = ModelBase<RoleModel>.Instance.GetRoleViewAgent(param.AgentType);
		ETeamPositionType valueOrDefault2 = param.TeamPositionType.GetValueOrDefault();
		roleViewAgent.Init(roleIdList, valueOrDefault, param.OpenTabView, param.Source.GetValueOrDefault());
		roleViewAgent.TeamPositionType = new ETeamPositionType?(valueOrDefault2);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleRootView, roleViewAgent, param.FinishCallback);
	}

	// Token: 0x06014148 RID: 82248 RVA: 0x0059B5E5 File Offset: 0x005997E5
	public void OpenRoleViewByViewModel(EUiViewName viewName, RoleViewViewModel viewModel)
	{
		if (!this.CheckRoleCanOpenView(viewModel.RoleId, viewName))
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(viewName, viewModel, null);
	}

	// Token: 0x06014149 RID: 82249 RVA: 0x0059B604 File Offset: 0x00599804
	public void CloseAndOpenRoleViewByViewModel(EUiViewName closeViewName, EUiViewName openViewName, RoleViewViewModel viewModel)
	{
		if (!this.CheckRoleCanOpenView(viewModel.RoleId, openViewName))
		{
			return;
		}
		Singleton<UiManager>.Instance.CloseAndOpenView(closeViewName, openViewName, viewModel, null, true);
	}

	// Token: 0x0601414A RID: 82250 RVA: 0x0059B628 File Offset: 0x00599828
	private bool CheckRoleCanOpenView(int roleId, EUiViewName viewName)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (roleInstanceById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LRC;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("角色不存在: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		RoleLevelData levelData = roleInstanceById.GetLevelData();
		bool roleNeedBreakUp = levelData.GetRoleNeedBreakUp();
		bool result = !roleNeedBreakUp && !levelData.GetRoleIsMaxLevel();
		if (viewName == EUiViewName.RoleLevelUpView)
		{
			return result;
		}
		if (viewName == EUiViewName.RoleBreachView)
		{
			return roleNeedBreakUp;
		}
		if (viewName == EUiViewName.RoleBreachSuccessView || viewName == EUiViewName.WeaponReplaceView)
		{
			return true;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Role;
		ELogAuthor author2 = ELogAuthor.LRC;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
		defaultInterpolatedStringHandler.AppendLiteral("无法通过该接口打开界面: ");
		defaultInterpolatedStringHandler.AppendFormatted<EUiViewName>(viewName);
		instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}

	// Token: 0x0601414B RID: 82251 RVA: 0x0059B718 File Offset: 0x00599918
	[NullableContext(2)]
	public void CloseAndOpenRoleMainView(EUiViewName closeViewName, ERoleAgentType agentType, int selectRoleId = 0, List<int> roleIdList = null, EUiTabViewName? openTabView = null, Action<bool> finishCallback = null)
	{
		if (roleIdList == null)
		{
			roleIdList = new List<int>();
		}
		RoleViewAgent roleViewAgent = ModelBase<RoleModel>.Instance.GetRoleViewAgent(agentType);
		roleViewAgent.Init(roleIdList, selectRoleId, openTabView, ERoleViewSource.Normal);
		Singleton<UiManager>.Instance.CloseAndOpenView(closeViewName, EUiViewName.RoleRootView, roleViewAgent, finishCallback, true);
	}

	// Token: 0x0601414C RID: 82252 RVA: 0x0059B75C File Offset: 0x0059995C
	protected override void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoleRootView, new Func<EUiViewName, object, bool>(this.CanOpenView), "RoleController.CanOpenView");
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoleDevelopRootView, new Func<EUiViewName, object, bool>(this.CanOpenRoleDevelopView), "RoleController.CanOpenRoleDevelopView");
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoleDevelopSelectTargetView, new Func<EUiViewName, object, bool>(this.CanOpenRoleDevelopView), "RoleController.CanOpenRoleDevelopSelectTargetView");
	}

	// Token: 0x0601414D RID: 82253 RVA: 0x0059B7CC File Offset: 0x005999CC
	protected override void OnRemoveOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RoleRootView, new Func<EUiViewName, object, bool>(this.CanOpenView));
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RoleDevelopRootView, new Func<EUiViewName, object, bool>(this.CanOpenRoleDevelopView));
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RoleDevelopSelectTargetView, new Func<EUiViewName, object, bool>(this.CanOpenRoleDevelopView));
	}

	// Token: 0x0601414E RID: 82254 RVA: 0x0059B82C File Offset: 0x00599A2C
	public bool CheckCharacterInBattleTag(bool useIgnoreList = false)
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		return (!useIgnoreList || !RoleController.IsInIgnoreBattleTagInst()) && baseCharacter != null && baseCharacter.CharacterActorComponent.Entity.CheckGetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]);
	}

	// Token: 0x0601414F RID: 82255 RVA: 0x0059B874 File Offset: 0x00599A74
	private unsafe static bool IsInIgnoreBattleTagInst()
	{
		IReadOnlyList<int> readOnlyList = ConfigCommonParamById.GetIntArrayConfig("IgnoreInBattleTagInstSubTypeList") ?? Array.Empty<int>();
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Role;
		ELogAuthor author = ELogAuthor.TZJ;
		string message = "检查无视战斗状态的副本列表";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ignoreList", readOnlyList);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("id", instanceId);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (instanceId == 0)
		{
			return true;
		}
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		return config != null && readOnlyList.Contains(config.Value.InstSubType);
	}

	// Token: 0x06014150 RID: 82256 RVA: 0x0059B92A File Offset: 0x00599B2A
	public bool CheckCharacterInBattleTagAndShowTips(bool useIgnoreList = false)
	{
		if (ControllerBase<RoleController>.Instance.CheckCharacterInBattleTag(useIgnoreList))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ForbiddenActionInFight", Array.Empty<object>());
			return true;
		}
		return false;
	}

	// Token: 0x06014151 RID: 82257 RVA: 0x0059B950 File Offset: 0x00599B50
	public void OnSelectedRoleChange(int roleId, int roleSkinId)
	{
		TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
		this.RefreshUiSceneRoleActor(roleSystemRoleActor, roleId, roleSkinId, null);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectedRoleChanged);
	}

	// Token: 0x06014152 RID: 82258 RVA: 0x0059B984 File Offset: 0x00599B84
	public void SetRoleMorphType(TsUiSceneRoleActor roleActor, EUiModelMorphType morphType)
	{
		UiModelBase model = roleActor.Model;
		UiRoleMorphComponent uiRoleMorphComponent = (model != null) ? model.GetComponent<UiRoleMorphComponent>() : null;
		if (uiRoleMorphComponent != null && uiRoleMorphComponent.SetMorphType(morphType))
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRoleMorphTypeChanged);
		}
	}

	// Token: 0x06014153 RID: 82259 RVA: 0x0059B9C0 File Offset: 0x00599BC0
	public UniTask RefreshUiSceneRoleActorAsync(TsUiSceneRoleActor roleActor, int roleId, int roleSkinId, Action callback = null)
	{
		RoleController.<RefreshUiSceneRoleActorAsync>d__17 <RefreshUiSceneRoleActorAsync>d__;
		<RefreshUiSceneRoleActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshUiSceneRoleActorAsync>d__.<>4__this = this;
		<RefreshUiSceneRoleActorAsync>d__.roleActor = roleActor;
		<RefreshUiSceneRoleActorAsync>d__.roleId = roleId;
		<RefreshUiSceneRoleActorAsync>d__.roleSkinId = roleSkinId;
		<RefreshUiSceneRoleActorAsync>d__.callback = callback;
		<RefreshUiSceneRoleActorAsync>d__.<>1__state = -1;
		<RefreshUiSceneRoleActorAsync>d__.<>t__builder.Start<RoleController.<RefreshUiSceneRoleActorAsync>d__17>(ref <RefreshUiSceneRoleActorAsync>d__);
		return <RefreshUiSceneRoleActorAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014154 RID: 82260 RVA: 0x0059BA24 File Offset: 0x00599C24
	public void RefreshUiSceneRoleActor(TsUiSceneRoleActor roleActor, int roleId, int roleSkinId, Action callback = null)
	{
		UiModelBase model = roleActor.Model;
		UiRoleDataComponent uiRoleDataComponent = (model != null) ? model.CheckGetComponent<UiRoleDataComponent>() : null;
		if (uiRoleDataComponent != null && uiRoleDataComponent.RoleDataId == roleId && uiRoleDataComponent != null && uiRoleDataComponent.RoleSkinId == roleSkinId)
		{
			return;
		}
		Action loadFinishCallBack = delegate()
		{
			Action callback2 = callback;
			if (callback2 != null)
			{
				callback2();
			}
			UiRoleUtils.PlayRoleChangeEffect(roleActor);
		};
		UiModelBase model2 = roleActor.Model;
		UiRoleLoadComponent uiRoleLoadComponent = (model2 != null) ? model2.CheckGetComponent<UiRoleLoadComponent>() : null;
		if (uiRoleLoadComponent != null)
		{
			uiRoleLoadComponent.LoadModelByRoleDataId(roleId, roleSkinId, true, loadFinishCallBack);
		}
		if (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("BP_UIShowRoom").Value, ECollectActorType.UI) is BP_UIShowRoom_C)
		{
			Singleton<UiSceneManager>.Instance.AddUiShowRoomShowActor(roleActor, true);
		}
	}

	// Token: 0x06014155 RID: 82261 RVA: 0x0059BADA File Offset: 0x00599CDA
	public void OnSelectedRoleChangeByConfig(int roleId, int skinId, Action callback = null)
	{
		this.RefreshUiSceneRoleActorByConfigId(roleId, skinId, callback);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectedRoleChanged);
	}

	// Token: 0x06014156 RID: 82262 RVA: 0x0059BAF8 File Offset: 0x00599CF8
	public void RefreshUiSceneRoleActorByConfigId(int roleId, int skinId, Action callback = null)
	{
		TsUiSceneRoleActor uiSceneRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
		UiModelBase model = uiSceneRoleActor.Model;
		UiRoleDataComponent uiRoleDataComponent = (model != null) ? model.CheckGetComponent<UiRoleDataComponent>() : null;
		if (uiRoleDataComponent != null && uiRoleDataComponent.RoleConfigId == roleId)
		{
			return;
		}
		Action loadFinishCallBack = delegate()
		{
			Action callback2 = callback;
			if (callback2 != null)
			{
				callback2();
			}
			UiRoleUtils.PlayRoleChangeEffect(uiSceneRoleActor);
		};
		UiModelBase model2 = uiSceneRoleActor.Model;
		UiRoleLoadComponent uiRoleLoadComponent = (model2 != null) ? model2.CheckGetComponent<UiRoleLoadComponent>() : null;
		if (uiRoleLoadComponent != null)
		{
			uiRoleLoadComponent.LoadModelByRoleConfigId(roleId, skinId, true, loadFinishCallBack);
		}
		Singleton<UiSceneManager>.Instance.AddUiShowRoomShowActor(uiSceneRoleActor, true);
	}

	// Token: 0x06014157 RID: 82263 RVA: 0x0059BB90 File Offset: 0x00599D90
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<TsUiSceneRoleActor> LoadUiSceneRoleActorByConfigIdAsync(EUiModelUseWay uiModelUseWay, int roleId, int skinId)
	{
		RoleController.<LoadUiSceneRoleActorByConfigIdAsync>d__21 <LoadUiSceneRoleActorByConfigIdAsync>d__;
		<LoadUiSceneRoleActorByConfigIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<TsUiSceneRoleActor>.Create();
		<LoadUiSceneRoleActorByConfigIdAsync>d__.uiModelUseWay = uiModelUseWay;
		<LoadUiSceneRoleActorByConfigIdAsync>d__.roleId = roleId;
		<LoadUiSceneRoleActorByConfigIdAsync>d__.skinId = skinId;
		<LoadUiSceneRoleActorByConfigIdAsync>d__.<>1__state = -1;
		<LoadUiSceneRoleActorByConfigIdAsync>d__.<>t__builder.Start<RoleController.<LoadUiSceneRoleActorByConfigIdAsync>d__21>(ref <LoadUiSceneRoleActorByConfigIdAsync>d__);
		return <LoadUiSceneRoleActorByConfigIdAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014158 RID: 82264 RVA: 0x0059BBE4 File Offset: 0x00599DE4
	public void ShowUiSceneActorAndShadow(bool isShow)
	{
		TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
		UiModelBase uiModelBase = (roleSystemRoleActor != null) ? roleSystemRoleActor.Model : null;
		if (uiModelBase != null)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase, true);
		}
		BP_UIShowRoom_C bp_UIShowRoom_C = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("BP_UIShowRoom").Value, ECollectActorType.UI) as BP_UIShowRoom_C;
		if (bp_UIShowRoom_C != null)
		{
			bp_UIShowRoom_C.SetActorHiddenInGame(!isShow);
		}
	}

	// Token: 0x06014159 RID: 82265 RVA: 0x0059BC44 File Offset: 0x00599E44
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotStart, new Action(this.OnRedDotStartEvent));
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeon, new Action(this.ResetRoleTrialState));
		Singleton<EventSystem>.Instance.Add(EEventName.TextLanguageChange, new Action<string, string>(this.OnTextLanguageChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnResponseCommonItemFinished, new Action(this.OnResponseCommonItemFinished));
	}

	// Token: 0x0601415A RID: 82266 RVA: 0x0059BCE0 File Offset: 0x00599EE0
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotStart, new Action(this.OnRedDotStartEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeon, new Action(this.ResetRoleTrialState));
		Singleton<EventSystem>.Instance.Remove(EEventName.TextLanguageChange, new Action<string, string>(this.OnTextLanguageChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnResponseCommonItemFinished, new Action(this.OnResponseCommonItemFinished));
	}

	// Token: 0x0601415B RID: 82267 RVA: 0x0059BD79 File Offset: 0x00599F79
	private void OnLoadingNetDataDone()
	{
		this.SendRoleFavorListRequest();
		this.RequestRoleDevelopDependentData().Forget();
	}

	// Token: 0x0601415C RID: 82268 RVA: 0x0059BD8C File Offset: 0x00599F8C
	private void OnResponseCommonItemFinished()
	{
		RoleOrnamentModel instance = ModelBase<RoleOrnamentModel>.Instance;
		instance.SetCommonItemFinished();
		int[] array = instance.TakePendingOrnamentIdsForInit();
		if (array != null)
		{
			ControllerBase<InventoryController>.Instance.InitOrnamentItemData(array);
		}
		List<int[]> list = instance.TakeAllPendingOrnamentUnlockBatches();
		foreach (int[] ids in list)
		{
			RoleController.ProcessOrnamentUnlock(ids);
		}
		int count = list.Count;
	}

	// Token: 0x0601415D RID: 82269 RVA: 0x0059BE08 File Offset: 0x0059A008
	private void OnRedDotStartEvent()
	{
		foreach (int p in ModelBase<RoleModel>.Instance.GetRoleIdList())
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotCreateRole, p);
		}
	}

	// Token: 0x0601415E RID: 82270 RVA: 0x0059BE6C File Offset: 0x0059A06C
	private void ResetRoleTrialState()
	{
		if (!ModelBase<RoleModel>.Instance.IsInRoleTrial)
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.Role, ELogAuthor.XXJ, "切换地图,重置进入试用角色状态", default(ReadOnlySpan<ValueTuple<string, object>>));
		ModelBase<RoleModel>.Instance.RoleTrialIdList.Clear();
		ModelBase<RoleModel>.Instance.IsInRoleTrial = false;
	}

	// Token: 0x0601415F RID: 82271 RVA: 0x0059BEBC File Offset: 0x0059A0BC
	private void OnTextLanguageChange(string oldLang, string newLang)
	{
		Dictionary<int, RoleInstance> roleMap = ModelBase<RoleModel>.Instance.GetRoleMap();
		Dictionary<int, RoleRobotData> roleRobotMap = ModelBase<RoleModel>.Instance.GetRoleRobotMap();
		foreach (KeyValuePair<int, RoleInstance> keyValuePair in roleMap)
		{
			RoleInstance value = keyValuePair.Value;
			if (!ModelBase<PlayerInfoModel>.Instance.IsPlayerId(value.GetRoleId(), null))
			{
				RoleInfo roleConfig = value.GetRoleConfig();
				string roleName = ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Name);
				value.SetRoleName(roleName);
			}
		}
		foreach (KeyValuePair<int, RoleRobotData> keyValuePair2 in roleRobotMap)
		{
			RoleRobotData value2 = keyValuePair2.Value;
			RoleInfo roleConfig2 = value2.GetRoleConfig();
			string roleName2 = ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig2.Name);
			value2.SetName(roleName2);
		}
	}

	// Token: 0x06014160 RID: 82272 RVA: 0x0059BFC0 File Offset: 0x0059A1C0
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<PbGetRoleListNotify>(ENotifyMessageId.PbGetRoleListNotify, delegate(PbGetRoleListNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<RoleModel>.Instance.UpdateRoleInfoByServerData(response.RoleList.ToArray<roleInfo>());
		});
		Singleton<Net>.Instance.Register<PbRolePropsNotify>(ENotifyMessageId.PbRolePropsNotify, delegate(PbRolePropsNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<RoleModel>.Instance.RoleAttrUpdate(response.RoleId, response.BaseProp.ToArray<ArrayIntInt>(), response.AddProp.ToArray<ArrayIntInt>());
		});
		Singleton<Net>.Instance.Register<PbRoleActiveNotify>(ENotifyMessageId.PbRoleActiveNotify, delegate(PbRoleActiveNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			int roleId = response.Role.RoleId;
			ModelBase<RoleModel>.Instance.UpdateRoleInfo(response.Role);
			ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.RoleDataItem, roleId);
			ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.PersonalDataItem, roleId);
			ModelBase<PersonalModel>.Instance.SetPersonalTipState(true);
			Singleton<EventSystem>.Instance.Emit(EEventName.RoleSelectionListUpdate);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActiveRole, roleId);
		});
		Singleton<Net>.Instance.Register<PbRoleExpNotify>(ENotifyMessageId.PbRoleExpNotify, delegate(PbRoleExpNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<RoleModel>.Instance.RoleLevelUp(response.RoleId, response.Exp, response.Level);
		});
		Singleton<Net>.Instance.Register<PbRoleResonLockFinishNotify>(ENotifyMessageId.PbRoleResonLockFinishNotify, delegate(PbRoleResonLockFinishNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify != null)
			{
				ModelBase<RoleModel>.Instance.RoleResonanceLockFinish(notify);
			}
		});
		Singleton<Net>.Instance.Register<PbRoleSkillLevelNotify>(ENotifyMessageId.PbRoleSkillLevelNotify, delegate(PbRoleSkillLevelNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify != null)
			{
				ModelBase<RoleModel>.Instance.RoleSkillLevelUp(notify.RoleId, notify.SkillInfo);
			}
		});
		Singleton<Net>.Instance.Register<RoleChangeNameNotify>(ENotifyMessageId.RoleChangeNameNotify, delegate(RoleChangeNameNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify != null)
			{
				ModelBase<RoleModel>.Instance.RoleNameUpdate(notify.RoleId, notify.Name);
			}
		});
		Singleton<Net>.Instance.Register<RoleTrialOpenNotify>(ENotifyMessageId.RoleTrialOpenNotify, delegate(RoleTrialOpenNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify.ShowTips && !ModelBase<RoleModel>.Instance.IsInRoleTrial && !ModelBase<PlotModel>.Instance.InSeamlessFormation && !ModelBase<PlotModel>.Instance.InDigitalScreen && ModelBase<GameModeModel>.Instance.WorldDone)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleAdd", Array.Empty<object>());
			}
			ModelBase<TeleportModel>.Instance.SetAllowTeleportByUi(notify.EnableMapAndTeleport, "TrialRole");
			ControllerBase<InstanceDungeonController>.Instance.UpdateTrialRoleDungeonWhiteList(notify.CanEnterDungeonList.ToArray<int>());
			ModelBase<RoleModel>.Instance.RoleTrialIdList.Clear();
			foreach (int item in notify.RoleIds)
			{
				ModelBase<RoleModel>.Instance.RoleTrialIdList.Add(item);
			}
			if (!ModelBase<RoleModel>.Instance.IsInRoleTrial && ModelBase<RoleModel>.Instance.RoleTrialIdList.Count > 0)
			{
				ModelBase<RoleModel>.Instance.IsInRoleTrial = true;
				Singleton<Log>.Instance.Info(ELogModule.Role, ELogAuthor.XXJ, "进入角色试用状态", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		});
		Singleton<Net>.Instance.Register<RoleTrialCloseNotify>(ENotifyMessageId.RoleTrialCloseNotify, delegate(RoleTrialCloseNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify.ShowTips && ModelBase<RoleModel>.Instance.IsInRoleTrial && !ModelBase<PlotModel>.Instance.InSeamlessFormation && !ModelBase<PlotModel>.Instance.InDigitalScreen && ModelBase<GameModeModel>.Instance.WorldDone)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDetach", Array.Empty<object>());
			}
			ModelBase<TeleportModel>.Instance.SetAllowTeleportByUi(notify.EnableMapAndTeleport, "TrialRole");
			ControllerBase<InstanceDungeonController>.Instance.UpdateTrialRoleDungeonWhiteList(notify.CanEnterDungeonList.ToArray<int>());
			ModelBase<RoleModel>.Instance.RoleTrialIdList.Clear();
			foreach (int item in notify.RoleIds)
			{
				ModelBase<RoleModel>.Instance.RoleTrialIdList.Add(item);
			}
			if (ModelBase<RoleModel>.Instance.IsInRoleTrial && ModelBase<RoleModel>.Instance.RoleTrialIdList.Count <= 0)
			{
				ModelBase<RoleModel>.Instance.IsInRoleTrial = false;
				Singleton<Log>.Instance.Info(ELogModule.Role, ELogAuthor.XXJ, "角色试用状态结束", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		});
		Singleton<Net>.Instance.Register<RoleSkillNodeNotify>(ENotifyMessageId.RoleSkillNodeNotify, delegate(RoleSkillNodeNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify != null)
			{
				ModelBase<RoleModel>.Instance.UpdateRoleSkillNodeData(notify.RoleId, notify.SkillNodeState.ToArray<ArraySkillNode>());
			}
		});
		Singleton<Net>.Instance.Register<RoleFavorListNotify>(ENotifyMessageId.RoleFavorListNotify, delegate(RoleFavorListNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify != null)
			{
				Dictionary<int, ConditionInfo> dictionary = new Dictionary<int, ConditionInfo>();
				MapField<int, ConditionInfo> roleConditionInfoMap = notify.RoleConditionInfoMap;
				foreach (int num in roleConditionInfoMap.Keys)
				{
					int key = num;
					dictionary[key] = roleConditionInfoMap[num];
				}
				ModelBase<RoleModel>.Instance.UpdateRoleFavorCondition(dictionary);
				ModelBase<RoleModel>.Instance.UpdateRoleFavorData(notify.FavorList.ToArray<RoleFavor>());
			}
		});
		Singleton<Net>.Instance.Register<RoleFavorActiveNotify>(ENotifyMessageId.RoleFavorActiveNotify, delegate(RoleFavorActiveNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify != null)
			{
				ModelBase<RoleModel>.Instance.UpdateRoleFavorDataSingle(notify.RoleFavorInfo);
			}
		});
		Singleton<Net>.Instance.Register<RoleFavorExpTipsNotify>(ENotifyMessageId.RoleFavorExpTipsNotify, delegate(RoleFavorExpTipsNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify != null)
			{
				Singleton<EventSystem>.Instance.Emit<TItem>(EEventName.OnAddFavorItem, new TItem
				{
					ItemData = new InventoryDefine.GetItemData(notify.ItemId, 0),
					Count = notify.Count
				});
			}
		});
		Singleton<Net>.Instance.Register<RoleFavorFinishConditionNotify>(ENotifyMessageId.RoleFavorFinishConditionNotify, delegate(RoleFavorFinishConditionNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify != null)
			{
				Dictionary<int, ConditionInfo> dictionary = new Dictionary<int, ConditionInfo>();
				MapField<int, ConditionInfo> roleConditionInfoMap = notify.RoleConditionInfoMap;
				foreach (int num in roleConditionInfoMap.Keys)
				{
					int key = num;
					dictionary[key] = roleConditionInfoMap[num];
				}
				ModelBase<RoleModel>.Instance.UpdateRoleFavorCondition(dictionary);
			}
		});
		Singleton<Net>.Instance.Register<RoleFavorNewCanUnLockNotify>(ENotifyMessageId.RoleFavorNewCanUnLockNotify, delegate(RoleFavorNewCanUnLockNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify != null)
			{
				ModelBase<RoleModel>.Instance.UpdateRoleFavorNewCanUnLockId(notify);
			}
		});
		Singleton<Net>.Instance.Register<RoleFavorLevelUpdateNotify>(ENotifyMessageId.RoleFavorLevelUpdateNotify, delegate(RoleFavorLevelUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify != null)
			{
				ModelBase<RoleModel>.Instance.UpdateRoleFavorLevelAndExp(notify);
			}
		});
		Singleton<Net>.Instance.Register<RoleSkinChangeNotify>(ENotifyMessageId.RoleSkinChangeNotify, new Action<RoleSkinChangeNotify, Net.CallbackStatus>(this.OnRoleSkinChangeNotify));
		Singleton<Net>.Instance.Register<RoleConfigInfoNotify>(ENotifyMessageId.RoleConfigInfoNotify, delegate(RoleConfigInfoNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			foreach (RoleConfigInfo roleConfigInfo in notify.RoleConfigs)
			{
				this.UpdateRoleSkillBranch(roleConfigInfo.RoleId, roleConfigInfo.SkillBranch, false);
			}
		});
		Singleton<Net>.Instance.Register<RoleConfigInfoUpdateNotify>(ENotifyMessageId.RoleConfigInfoUpdateNotify, delegate(RoleConfigInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			foreach (RoleConfigInfo roleConfigInfo in notify.RoleConfigs)
			{
				this.UpdateRoleSkillBranch(roleConfigInfo.RoleId, roleConfigInfo.SkillBranch, true);
			}
		});
		Singleton<Net>.Instance.Register<RoleUpdateDevelopTargetNotify>(ENotifyMessageId.RoleUpdateDevelopTargetNotify, new Action<RoleUpdateDevelopTargetNotify, Net.CallbackStatus>(this.OnRoleUpdateDevelopTargetNotify));
		Singleton<Net>.Instance.Register<RoleDevelopConfigUpdateNotify>(ENotifyMessageId.RoleDevelopConfigUpdateNotify, new Action<RoleDevelopConfigUpdateNotify, Net.CallbackStatus>(this.OnRoleDevelopConfigUpdateNotify));
		Singleton<Net>.Instance.Register<OrnamentInfoNotify>(ENotifyMessageId.OrnamentInfoNotify, new Action<OrnamentInfoNotify, Net.CallbackStatus>(this.OnOrnamentInfoNotify));
		Singleton<Net>.Instance.Register<OrnamentUnlockNotify>(ENotifyMessageId.OrnamentUnlockNotify, new Action<OrnamentUnlockNotify, Net.CallbackStatus>(this.OnOrnamentUnlockNotify));
		Singleton<Net>.Instance.Register<EntityDressOrnamentChangeNotify>(ENotifyMessageId.EntityDressOrnamentChangeNotify, new Action<EntityDressOrnamentChangeNotify, Net.CallbackStatus>(this.OnEntityDressOrnamentChangeNotify));
		Singleton<Net>.Instance.Register<OrnamentDressInfoUpdateNotify>(ENotifyMessageId.OrnamentDressInfoUpdateNotify, new Action<OrnamentDressInfoUpdateNotify, Net.CallbackStatus>(this.OnOrnamentDressInfoUpdateNotify));
	}

	// Token: 0x06014161 RID: 82273 RVA: 0x0059C3BC File Offset: 0x0059A5BC
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PbGetRoleListNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PbRolePropsNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PbRoleActiveNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PbRoleExpNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PbRoleResonLockFinishNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PbRoleSkillLevelNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleChangeNameNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleTrialOpenNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleTrialCloseNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleSkillNodeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleFavorListNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleFavorActiveNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleFavorExpTipsNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleFavorNewCanUnLockNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleFavorLevelUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleSkinChangeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleConfigInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleConfigInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.OrnamentInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.OrnamentUnlockNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EntityDressOrnamentChangeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.OrnamentDressInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleUpdateDevelopTargetNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleDevelopConfigUpdateNotify);
	}

	// Token: 0x06014162 RID: 82274 RVA: 0x0059C549 File Offset: 0x0059A749
	public bool IsInRoleTrial()
	{
		return ModelBase<RoleModel>.Instance.IsInRoleTrial;
	}

	// Token: 0x06014163 RID: 82275 RVA: 0x0059C558 File Offset: 0x0059A758
	public void SendPbUpLevelRoleRequest(int roleId, ArrayIntInt[] itemList, Action successCallback)
	{
		if (itemList == null || itemList.Length == 0)
		{
			return;
		}
		PbUpLevelRoleRequest pbUpLevelRoleRequest = PbUpLevelRoleRequest.Create();
		pbUpLevelRoleRequest.RoleId = roleId;
		pbUpLevelRoleRequest.ItemList.Add(itemList);
		Singleton<Net>.Instance.Call<PbUpLevelRoleResponse>(ERequestMessageId.PbUpLevelRoleRequest, pbUpLevelRoleRequest, delegate(PbUpLevelRoleResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.Code == Aki.Protocol.ErrorCode.Success)
			{
				ModelBase<RoleModel>.Instance.RoleLevelUpReceiveItem(response.ItemMap.ToDictionary<int, int>());
				ModelBase<RoleModel>.Instance.RoleLevelUp(response.RoleId, response.Exp, response.Level);
				successCallback();
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, EResponseMessageId.PbUpLevelRoleResponse, null, true, true);
		}, 0);
	}

	// Token: 0x06014164 RID: 82276 RVA: 0x0059C5B0 File Offset: 0x0059A7B0
	public void SendPbOverRoleRequest(int roleId)
	{
		PbOverRoleRequest pbOverRoleRequest = PbOverRoleRequest.Create();
		pbOverRoleRequest.RoleId = roleId;
		Singleton<Net>.Instance.Call<PbOverRoleResponse>(ERequestMessageId.PbOverRoleRequest, pbOverRoleRequest, delegate(PbOverRoleResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.Code == Aki.Protocol.ErrorCode.Success)
			{
				ModelBase<RoleModel>.Instance.RoleBreakUp(response.RoleId, response.Breakthrough);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, EResponseMessageId.PbOverRoleResponse, null, true, true);
		}, 0);
	}

	// Token: 0x06014165 RID: 82277 RVA: 0x0059C5FC File Offset: 0x0059A7FC
	public void SendPbUpLevelSkillRequest(int roleId, int skillNodeId)
	{
		if (ControllerBase<RoleController>.Instance.CheckCharacterInBattleTagAndShowTips(false))
		{
			return;
		}
		if (ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId).IsTrialRole())
		{
			return;
		}
		PbUpLevelSkillRequest pbUpLevelSkillRequest = PbUpLevelSkillRequest.Create();
		pbUpLevelSkillRequest.RoleId = roleId;
		pbUpLevelSkillRequest.SkillId = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(skillNodeId).Value.SkillId;
		int lastLevel = ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(roleId, skillNodeId);
		Singleton<Net>.Instance.Call<PbUpLevelSkillResponse>(ERequestMessageId.PbUpLevelSkillRequest, pbUpLevelSkillRequest, delegate(PbUpLevelSkillResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.Code == Aki.Protocol.ErrorCode.Success)
			{
				RoleController.ShowSkillTreeLevelUpSuccessView(skillNodeId, lastLevel, roleId, null);
				ModelBase<RoleModel>.Instance.RoleSkillLevelUp(response.RoleId, response.SkillInfo);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.SkillTreeNodeLevelUp, skillNodeId);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, EResponseMessageId.PbUpLevelSkillResponse, null, true, true);
		}, 0);
	}

	// Token: 0x06014166 RID: 82278 RVA: 0x0059C6B4 File Offset: 0x0059A8B4
	public static void SendRoleSkillQuickLevelUpRequest(int roleId, int skillNodeId, int targetLevel)
	{
		if (ControllerBase<RoleController>.Instance.CheckCharacterInBattleTagAndShowTips(false))
		{
			return;
		}
		if (RoleUtils.IsTrialRole(roleId))
		{
			return;
		}
		RoleSkillQuickLevelUpRequest roleSkillQuickLevelUpRequest = RoleSkillQuickLevelUpRequest.Create();
		roleSkillQuickLevelUpRequest.RoleId = roleId;
		roleSkillQuickLevelUpRequest.SkillId = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(skillNodeId).Value.SkillId;
		roleSkillQuickLevelUpRequest.TargetLevel = targetLevel;
		int lastLevel = ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(roleId, skillNodeId);
		Singleton<Net>.Instance.Call<RoleSkillQuickLevelUpResponse>(ERequestMessageId.RoleSkillQuickLevelUpRequest, roleSkillQuickLevelUpRequest, delegate(RoleSkillQuickLevelUpResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				RoleController.ShowSkillTreeLevelUpSuccessView(skillNodeId, lastLevel, roleId, new int?(targetLevel));
				if (response.RoleInfo != null)
				{
					ModelBase<RoleModel>.Instance.UpdateRoleInfo(response.RoleInfo);
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.SkillTreeNodeLevelUp, skillNodeId);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoleSkillQuickLevelUpResponse, null, true, true);
		}, 0);
	}

	// Token: 0x06014167 RID: 82279 RVA: 0x0059C778 File Offset: 0x0059A978
	public void SendResonanceUnlockRequest(int roleId)
	{
		if (this.CheckCharacterInBattleTagAndShowTips(false))
		{
			return;
		}
		RoleInstance roleInstance = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId);
		if (roleInstance.IsTrialRole())
		{
			return;
		}
		ResonantChainUnlockRequest resonantChainUnlockRequest = ResonantChainUnlockRequest.Create();
		resonantChainUnlockRequest.RoleId = roleId;
		Singleton<Net>.Instance.Call<ResonantChainUnlockResponse>(ERequestMessageId.ResonantChainUnlockRequest, resonantChainUnlockRequest, delegate(ResonantChainUnlockResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrCode == Aki.Protocol.ErrorCode.Success)
			{
				roleInstance.GetResonanceData().SetResonantChainGroupIndex(response.ResonantChainGroupIndex);
				int index = response.ResonantChainGroupIndex - 1;
				List<ResonantChain> roleResonanceConfigList = ModelBase<RoleModel>.Instance.GetRoleResonanceConfigList(roleInstance);
				LevelUpSuccessEffectData data = new LevelUpSuccessEffectData
				{
					Title = "Text_ResonanceUnlockSuccess_Text",
					TextList = new List<SingleText>
					{
						new SingleText
						{
							TextId = roleResonanceConfigList[index].AttributesDescription,
							Params = roleResonanceConfigList[index].AttributesDescriptionParams()
						}
					}
				};
				ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessEffectView(data, null);
				Singleton<EventSystem>.Instance.Emit(EEventName.UpdateRoleResonanceDetailView);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.ResonantChainUnlockResponse, null, true, true);
		}, 0);
	}

	// Token: 0x06014168 RID: 82280 RVA: 0x0059C7E0 File Offset: 0x0059A9E0
	public void SendRoleSkillViewRequest(int roleId, int skillId, Action callBack = null)
	{
		if (ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId) == null)
		{
			ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		}
		global::SkillEffect curRoleSkillViewDataLocal = ModelBase<RoleModel>.Instance.GetCurRoleSkillViewDataLocal(roleId, skillId);
		global::SkillEffect nextRoleSkillViewDataLocal = ModelBase<RoleModel>.Instance.GetNextRoleSkillViewDataLocal(roleId, skillId);
		ModelBase<RoleModel>.Instance.UpdateRoleSkillViewData(curRoleSkillViewDataLocal, nextRoleSkillViewDataLocal, skillId);
		if (callBack != null)
		{
			callBack();
		}
	}

	// Token: 0x06014169 RID: 82281 RVA: 0x0059C837 File Offset: 0x0059AA37
	public void OpenTeamRoleSelectView(TeamRoleSelectViewData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TeamRoleSelectView, data, null);
	}

	// Token: 0x0601416A RID: 82282 RVA: 0x0059C84A File Offset: 0x0059AA4A
	public void PlayRoleMontage(EPerformanceRoleState roleState, bool reLoop = false, bool reLoopFromLoopToStart = false, bool waitLaseStateEnd = false)
	{
		TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
		object obj;
		if (roleSystemRoleActor == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = roleSystemRoleActor.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiRoleStateMachineComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2.SetState(roleState, reLoop, reLoopFromLoopToStart, waitLaseStateEnd);
	}

	// Token: 0x0601416B RID: 82283 RVA: 0x0059C880 File Offset: 0x0059AA80
	public void SendRoleActivateSkillRequest(int roleId, int skillNodeId)
	{
		if (this.CheckCharacterInBattleTagAndShowTips(false))
		{
			return;
		}
		if (ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId).IsTrialRole())
		{
			return;
		}
		RoleActivateSkillRequest roleActivateSkillRequest = RoleActivateSkillRequest.Create();
		roleActivateSkillRequest.RoleId = roleId;
		roleActivateSkillRequest.SkillNodeId = skillNodeId;
		Singleton<Net>.Instance.Call<RoleActivateSkillResponse>(ERequestMessageId.RoleActivateSkillRequest, roleActivateSkillRequest, delegate(RoleActivateSkillResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.Code == Aki.Protocol.ErrorCode.Success)
			{
				RoleController.ShowSkillTreeLevelUpSuccessView(skillNodeId, 0, roleId, null);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.SkillTreeNodeActive, skillNodeId);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, EResponseMessageId.RoleActivateSkillResponse, null, true, true);
		}, 0);
	}

	// Token: 0x0601416C RID: 82284 RVA: 0x0059C900 File Offset: 0x0059AB00
	public void SendRoleFavorListRequest()
	{
		RoleFavorListRequest message = RoleFavorListRequest.Create();
		Singleton<Net>.Instance.Call<RoleFavorListResponse>(ERequestMessageId.RoleFavorListRequest, message, delegate(RoleFavorListResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrCode == Aki.Protocol.ErrorCode.Success)
			{
				ModelBase<RoleModel>.Instance.UpdateRoleFavorData(response.FavorList.ToArray<RoleFavor>());
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.RoleFavorListResponse, null, true, true);
		}, 0);
	}

	// Token: 0x0601416D RID: 82285 RVA: 0x0059C944 File Offset: 0x0059AB44
	public UniTask SendRoleFavorListRequestAsync()
	{
		RoleController.<SendRoleFavorListRequestAsync>d__43 <SendRoleFavorListRequestAsync>d__;
		<SendRoleFavorListRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SendRoleFavorListRequestAsync>d__.<>1__state = -1;
		<SendRoleFavorListRequestAsync>d__.<>t__builder.Start<RoleController.<SendRoleFavorListRequestAsync>d__43>(ref <SendRoleFavorListRequestAsync>d__);
		return <SendRoleFavorListRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601416E RID: 82286 RVA: 0x0059C980 File Offset: 0x0059AB80
	public void SendRoleFavorUnLockRequest(FavorItemType favorItemType, int roleId, int unLockId)
	{
		RoleFavorUnLockRequest roleFavorUnLockRequest = RoleFavorUnLockRequest.Create();
		roleFavorUnLockRequest.ItemType = favorItemType;
		roleFavorUnLockRequest.RoleId = roleId;
		roleFavorUnLockRequest.UnLockId = unLockId;
		Singleton<Net>.Instance.Call<RoleFavorUnLockResponse>(ERequestMessageId.RoleFavorUnLockRequest, roleFavorUnLockRequest, delegate(RoleFavorUnLockResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			RoleFavorData favorData = ModelBase<RoleModel>.Instance.GetRoleInstanceById(response.RoleId).GetFavorData();
			if (response.ErrCode == Aki.Protocol.ErrorCode.Success)
			{
				favorData.UpdateUnlockId(response.ItemType, roleId, response.UnLockId);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.RoleFavorUnLockResponse, null, true, true);
		}, 0);
	}

	// Token: 0x0601416F RID: 82287 RVA: 0x0059C9D7 File Offset: 0x0059ABD7
	public void SendRoleActiveRequest(int roleId)
	{
	}

	// Token: 0x06014170 RID: 82288 RVA: 0x0059C9DC File Offset: 0x0059ABDC
	public bool CheckRoleTargetLevel(int level)
	{
		RoleInstance[] allRoleList = ModelBase<RoleModel>.Instance.GetAllRoleList();
		if (allRoleList == null)
		{
			return false;
		}
		int num = allRoleList.Length;
		for (int i = 0; i < num; i++)
		{
			RoleLevelData levelData = allRoleList[i].GetLevelData();
			if (levelData != null && levelData.GetLevel() > level)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06014171 RID: 82289 RVA: 0x0059CA24 File Offset: 0x0059AC24
	public bool CheckRoleSkillTargetLevel(int level)
	{
		RoleInstance[] allRoleList = ModelBase<RoleModel>.Instance.GetAllRoleList();
		if (allRoleList == null)
		{
			return false;
		}
		int num = allRoleList.Length;
		for (int i = 0; i < num; i++)
		{
			RoleSkillData skillData = allRoleList[i].GetSkillData();
			if (skillData != null)
			{
				int[] allSkillLevel = skillData.GetAllSkillLevel();
				int num2 = allSkillLevel.Length;
				for (int j = 0; j < num2; j++)
				{
					if (allSkillLevel[j] >= level)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06014172 RID: 82290 RVA: 0x0059CA88 File Offset: 0x0059AC88
	public static void ShowSkillTreeLevelUpSuccessView(int skillNodeId, int lastLevel, int roleDataId, int? targetLevel = null)
	{
		int nodeType = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(skillNodeId).Value.NodeType;
		int value = targetLevel ?? (lastLevel + 1);
		switch (nodeType)
		{
		case 1:
			ControllerBase<RoleController>.Instance.ShowInnerSkillNodeLevelUpSuccessView(skillNodeId, lastLevel, new int?(value));
			return;
		case 2:
			ControllerBase<RoleController>.Instance.ShowInnerSkillNodeLevelUpSuccessView(skillNodeId, lastLevel, new int?(value));
			return;
		case 3:
			ControllerBase<RoleController>.Instance.ShowOuterSkillNodeLevelUpSuccessView(skillNodeId, roleDataId);
			return;
		case 4:
			ControllerBase<RoleController>.Instance.ShowAttributeNodeLevelUpSuccessView(skillNodeId);
			return;
		default:
			return;
		}
	}

	// Token: 0x06014173 RID: 82291 RVA: 0x0059CB24 File Offset: 0x0059AD24
	public void ShowAttributeNodeLevelUpSuccessView(int skillNodeId)
	{
		SkillTree? skillTreeNode = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(skillNodeId);
		LevelUpSuccessEffectData data = new LevelUpSuccessEffectData
		{
			Title = "Text_ResonanceUnlockSuccess_Text",
			TextList = new List<SingleText>
			{
				new SingleText
				{
					TextId = skillTreeNode.Value.PropertyNodeDescribe,
					Params = skillTreeNode.Value.PropertyNodeParam()
				}
			}
		};
		ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessEffectView(data, null);
	}

	// Token: 0x06014174 RID: 82292 RVA: 0x0059CB9C File Offset: 0x0059AD9C
	public void ShowOuterSkillNodeLevelUpSuccessView(int skillNodeId, int roleDataId)
	{
		int skillId = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(skillNodeId).Value.SkillId;
		int upgradeSkillIdIfUpgraded = ModelBase<RoleModel>.Instance.GetUpgradeSkillIdIfUpgraded(skillId, roleDataId);
		int skillId2 = (upgradeSkillIdIfUpgraded > 0) ? upgradeSkillIdIfUpgraded : skillId;
		Aki.Config.Skill? skillConfigById = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId2);
		LevelUpSuccessEffectData data = new LevelUpSuccessEffectData
		{
			Title = "Text_ResonanceUnlockSuccess_Text",
			TextList = new List<SingleText>
			{
				new SingleText
				{
					TextId = skillConfigById.Value.SkillDescribe,
					Params = skillConfigById.Value.SkillDetailNum()
				}
			}
		};
		ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessEffectView(data, null);
	}

	// Token: 0x06014175 RID: 82293 RVA: 0x0059CC4C File Offset: 0x0059AE4C
	public void ShowInnerSkillNodeLevelUpSuccessView(int skillNodeId, int lastLevel, int? targetLevel = null)
	{
		List<IAttributeInfo> list = new List<IAttributeInfo>();
		int skillId = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(skillNodeId).Value.SkillId;
		int maxSkillLevel = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId).Value.MaxSkillLevel;
		int num = targetLevel ?? (lastLevel + 1);
		global::SkillEffect roleSkillEffect = ModelBase<RoleModel>.Instance.GetRoleSkillEffect(skillId, lastLevel);
		List<global::OneSkillEffect> list2 = (roleSkillEffect != null) ? roleSkillEffect.EffectDescList : null;
		global::SkillEffect roleSkillEffect2 = ModelBase<RoleModel>.Instance.GetRoleSkillEffect(skillId, num);
		List<global::OneSkillEffect> list3 = (roleSkillEffect2 != null) ? roleSkillEffect2.EffectDescList : null;
		if (list2 != null && list3 != null)
		{
			for (int i = 0; i < list2.Count; i++)
			{
				global::OneSkillEffect effect = list2[i];
				global::OneSkillEffect effect2 = list3[i];
				string skillAttributeNameByOneSkillEffect = ModelBase<RoleModel>.Instance.GetSkillAttributeNameByOneSkillEffect(effect);
				string skillAttributeDescriptionByOneSkillEffect = ModelBase<RoleModel>.Instance.GetSkillAttributeDescriptionByOneSkillEffect(effect);
				string skillAttributeDescriptionByOneSkillEffect2 = ModelBase<RoleModel>.Instance.GetSkillAttributeDescriptionByOneSkillEffect(effect2);
				if (skillAttributeDescriptionByOneSkillEffect != skillAttributeDescriptionByOneSkillEffect2)
				{
					AttributeInfo item = new AttributeInfo
					{
						Name = skillAttributeNameByOneSkillEffect,
						ShowArrow = new bool?(true),
						PreText = skillAttributeDescriptionByOneSkillEffect,
						CurText = skillAttributeDescriptionByOneSkillEffect2
					};
					list.Add(item);
				}
			}
		}
		bool value = num == maxSkillLevel;
		LevelUpSuccessAttributeData data = new LevelUpSuccessAttributeData
		{
			LevelInfo = new LevelInfo
			{
				PreUpgradeLv = lastLevel,
				UpgradeLv = num,
				FormatStringId = "Text_LevelShow_Text",
				IsMaxLevel = new bool?(value)
			},
			WiderScrollView = new bool?(true),
			AttributeInfo = list
		};
		ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessAttributeView(data, null);
	}

	// Token: 0x06014176 RID: 82294 RVA: 0x0059CDF4 File Offset: 0x0059AFF4
	public UniTask RobotRolePropRequest(int[] idList)
	{
		RoleController.<RobotRolePropRequest>d__52 <RobotRolePropRequest>d__;
		<RobotRolePropRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RobotRolePropRequest>d__.idList = idList;
		<RobotRolePropRequest>d__.<>1__state = -1;
		<RobotRolePropRequest>d__.<>t__builder.Start<RoleController.<RobotRolePropRequest>d__52>(ref <RobotRolePropRequest>d__);
		return <RobotRolePropRequest>d__.<>t__builder.Task;
	}

	// Token: 0x06014177 RID: 82295 RVA: 0x0059CE38 File Offset: 0x0059B038
	public void RoleSkinChangeRequest(int roleId, int skinId, bool signatureWeapon, Action<int, bool> roleSkinChangeCallBack)
	{
		RoleSkinChangeRequest roleSkinChangeRequest = Aki.Protocol.RoleSkinChangeRequest.Create();
		roleSkinChangeRequest.RoleId = roleId;
		roleSkinChangeRequest.SkinId = skinId;
		roleSkinChangeRequest.SignatureWeapon = signatureWeapon;
		Singleton<Net>.Instance.Call<RoleSkinChangeResponse>(ERequestMessageId.RoleSkinChangeRequest, roleSkinChangeRequest, delegate(RoleSkinChangeResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoleSkinChangeResponse, null, true, true);
				return;
			}
			if (signatureWeapon)
			{
				RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(skinId);
				ModelBase<WeaponSkinModel>.Instance.UpdateWeaponSkinData(roleId, roleSkinData.GetSuitWeaponSkinId());
			}
			ModelBase<RoleModel>.Instance.UpdateRoleSkinInfo(roleId, skinId);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("RoleSkinReplaceTip", Array.Empty<object>());
			roleSkinChangeCallBack(skinId, signatureWeapon);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRoleSkinChange, roleId);
		}, 0);
	}

	// Token: 0x06014178 RID: 82296 RVA: 0x0059CEB0 File Offset: 0x0059B0B0
	private void OnRoleSkinChangeNotify(RoleSkinChangeNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		int roleId = message.RoleId;
		int skinId = message.SkinId;
		ModelBase<RoleModel>.Instance.UpdateRoleSkinInfo(roleId, skinId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRoleSkinChange, roleId);
	}

	// Token: 0x06014179 RID: 82297 RVA: 0x0059CEE8 File Offset: 0x0059B0E8
	public void RoleOperateSelfBgmRequest(int roleId, bool enabled, Action successCallback = null)
	{
		RoleOperateSelfBgmRequest roleOperateSelfBgmRequest = new RoleOperateSelfBgmRequest();
		roleOperateSelfBgmRequest.RoleId = roleId;
		roleOperateSelfBgmRequest.IsOpen = enabled;
		Singleton<Net>.Instance.Call<RoleOperateSelfBgmResponse>(ERequestMessageId.RoleOperateSelfBgmRequest, roleOperateSelfBgmRequest, delegate(RoleOperateSelfBgmResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoleOperateSelfBgmResponse, null, true, true);
				return;
			}
			ModelBase<RoleModel>.Instance.UpdateRoleBackgroundMusicEnabled(roleId, enabled);
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnRoleBackgroundMusicEnabledChanged, roleId, enabled);
			Action successCallback2 = successCallback;
			if (successCallback2 == null)
			{
				return;
			}
			successCallback2();
		}, 0);
	}

	// Token: 0x0601417A RID: 82298 RVA: 0x0059CF4B File Offset: 0x0059B14B
	private void UpdateRoleSkillBranch(int roleId, int skillBranch, bool notify = true)
	{
		ModelBase<RoleModel>.Instance.SetRoleBranch(roleId, skillBranch);
		ModelBase<RoleModel>.Instance.AddRoleSkillBranchChangeRequestRecord(roleId);
		if (notify)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRoleSkillBranchChanged, roleId);
		}
	}

	// Token: 0x0601417B RID: 82299 RVA: 0x0059CF78 File Offset: 0x0059B178
	public void RequestRoleSkillBranchModify(int roleId, int skillBranch)
	{
		RoleSkillBranchModifyRequest roleSkillBranchModifyRequest = RoleSkillBranchModifyRequest.Create();
		roleSkillBranchModifyRequest.RoleId = roleId;
		roleSkillBranchModifyRequest.SkillBranch = skillBranch;
		Singleton<Net>.Instance.Call<RoleSkillBranchModifyResponse>(ERequestMessageId.RoleSkillBranchModifyRequest, roleSkillBranchModifyRequest, delegate(RoleSkillBranchModifyResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26466, null, true, true);
				return;
			}
			this.UpdateRoleSkillBranch(roleId, skillBranch, true);
			TableTextArgNew tableTextArgNew = new TableTextArgNew(ConfigBase<RoleConfig>.Instance.GetSkillBranchConfigById(skillBranch).Value.Name, Array.Empty<object>());
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(ConfigBase<RoleConfig>.Instance.GetSkillBranchSwitchSuccessKey(), new object[]
			{
				tableTextArgNew
			});
			if (ModelBase<RoleModel>.Instance.IsInGamePlayRoleEdit)
			{
				this.ModifyRoleSkillBranchInCurrentGamePlay(roleId, skillBranch, false);
			}
			if (ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamInfo() != null)
			{
				List<int> item = ModelBase<EditBattleTeamModel>.Instance.GetOwnRoleConfigIdList.Item1;
				ControllerBase<InstanceDungeonEntranceController>.Instance.MatchChangeRoleRequest(item).Forget<bool>();
			}
		}, 0);
	}

	// Token: 0x0601417C RID: 82300 RVA: 0x0059CFDC File Offset: 0x0059B1DC
	public void SynRoleSkillBranchNormalToGamePlay(int roleId, ESkillBranchCacheType type)
	{
		RoleModel instance = ModelBase<RoleModel>.Instance;
		int roleCurrentBranchId = instance.GetRoleCurrentBranchId(roleId);
		instance.SetRoleSkillBranchGamePlayCache(roleId, roleCurrentBranchId, type);
	}

	// Token: 0x0601417D RID: 82301 RVA: 0x0059D000 File Offset: 0x0059B200
	public void ModifyRoleSkillBranchInCurrentGamePlay(int roleId, int skillBranch, bool needTips = true)
	{
		ModelBase<RoleModel>.Instance.SetRoleSkillBranchGamePlayCache(roleId, skillBranch, ModelBase<RoleModel>.Instance.RoleSkillBranchCacheType);
		if (needTips)
		{
			TableTextArgNew tableTextArgNew = new TableTextArgNew(ConfigBase<RoleConfig>.Instance.GetSkillBranchConfigById(skillBranch).Value.Name, Array.Empty<object>());
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SkillBranch_Change_Temporary_Text", new object[]
			{
				tableTextArgNew
			});
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRoleSkillBranchInGamePlayChanged, roleId);
	}

	// Token: 0x0601417E RID: 82302 RVA: 0x0059D078 File Offset: 0x0059B278
	private void OnOrnamentInfoNotify(OrnamentInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		OrnamentInfo ornamentInfo = notify.OrnamentInfo;
		if (ornamentInfo == null)
		{
			return;
		}
		RepeatedField<int> unlockOrnamentIds = ornamentInfo.UnlockOrnamentIds;
		RepeatedField<OrnamentDressInfo> ornamentDressInfos = ornamentInfo.OrnamentDressInfos;
		RepeatedField<int> redPointOrnamentIds = ornamentInfo.RedPointOrnamentIds;
		ModelBase<RoleOrnamentModel>.Instance.UpdateOwnOrnament(unlockOrnamentIds.ToArray<int>());
		ModelBase<RoleOrnamentModel>.Instance.UpdateWearOrnament(ornamentDressInfos);
		ModelBase<RoleOrnamentModel>.Instance.UpdateNewlyAddedOrnament(redPointOrnamentIds.ToArray<int>());
		if (ModelBase<RoleOrnamentModel>.Instance.GetIsCommonItemFinished())
		{
			ControllerBase<InventoryController>.Instance.InitOrnamentItemData(unlockOrnamentIds.ToArray<int>());
			return;
		}
		ModelBase<RoleOrnamentModel>.Instance.SetPendingOrnamentIdsForInit(unlockOrnamentIds.ToArray<int>());
	}

	// Token: 0x0601417F RID: 82303 RVA: 0x0059D100 File Offset: 0x0059B300
	private void OnOrnamentUnlockNotify(OrnamentUnlockNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<int> unlockOrnamentIds = notify.UnlockOrnamentIds;
		if (ModelBase<RoleOrnamentModel>.Instance.GetIsCommonItemFinished())
		{
			RoleController.ProcessOrnamentUnlock(unlockOrnamentIds.ToArray<int>());
			return;
		}
		ModelBase<RoleOrnamentModel>.Instance.AddPendingOrnamentUnlockBatch(unlockOrnamentIds.ToArray<int>());
	}

	// Token: 0x06014180 RID: 82304 RVA: 0x0059D13C File Offset: 0x0059B33C
	private static void ProcessOrnamentUnlock(int[] ids)
	{
		ModelBase<RoleOrnamentModel>.Instance.UpdateOwnOrnament(ids);
		List<TItem> list = new List<TItem>();
		foreach (int num in ids)
		{
			InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(num, 0);
			list.Add(new TItem(itemData, 1));
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnOrnamentUnlock, num);
			ModelBase<RoleOrnamentModel>.Instance.SetOrnamentNewlyAcquired(num, true);
		}
		ControllerBase<InventoryController>.Instance.AddOrnamentItemData(ids);
		Singleton<EventSystem>.Instance.Emit<TItem[]>(EEventName.OnAddOrnamentItemList, list.ToArray());
	}

	// Token: 0x06014181 RID: 82305 RVA: 0x0059D1C4 File Offset: 0x0059B3C4
	private void OnOrnamentDressInfoUpdateNotify(OrnamentDressInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<OrnamentDressInfo> ornamentDressInfos = notify.OrnamentDressInfos;
		ModelBase<RoleOrnamentModel>.Instance.UpdateWearOrnament(ornamentDressInfos);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnOrnamentChange);
	}

	// Token: 0x06014182 RID: 82306 RVA: 0x0059D1F4 File Offset: 0x0059B3F4
	private void OnEntityDressOrnamentChangeNotify(EntityDressOrnamentChangeNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		long creatureDataId = Singleton<MathUtils>.Instance.LongToNumber(notify.EntityId);
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
		CharacterOutlookComponent characterOutlookComponent;
		if (entity == null)
		{
			characterOutlookComponent = null;
		}
		else
		{
			WorldEntity entity2 = entity.Entity;
			characterOutlookComponent = ((entity2 != null) ? entity2.CheckGetComponent<CharacterOutlookComponent>() : null);
		}
		CharacterOutlookComponent characterOutlookComponent2 = characterOutlookComponent;
		if (characterOutlookComponent2 == null)
		{
			return;
		}
		characterOutlookComponent2.OnEntityDressOrnamentChangeNotify(notify);
	}

	// Token: 0x06014183 RID: 82307 RVA: 0x0059D244 File Offset: 0x0059B444
	public void RequestChangeOrnamentRequest(int roleSkinId, int ornamentId, bool isDress)
	{
		int normalizedOrnamentSkinId = ModelBase<RoleOrnamentModel>.Instance.GetNormalizedOrnamentSkinId(roleSkinId);
		ChangeOrnamentRequest changeOrnamentRequest = ChangeOrnamentRequest.Create();
		changeOrnamentRequest.RoleSkinId = normalizedOrnamentSkinId;
		changeOrnamentRequest.OrnamentId = ornamentId;
		changeOrnamentRequest.IsDress = isDress;
		Singleton<Net>.Instance.Call<ChangeOrnamentResponse>(ERequestMessageId.ChangeOrnamentRequest, changeOrnamentRequest, delegate(ChangeOrnamentResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29379, null, true, true);
				return;
			}
			string textId = isDress ? "OrnamentUiText_05" : "OrnamentUiText_06";
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(textId, Array.Empty<object>());
		}, 0);
	}

	// Token: 0x06014184 RID: 82308 RVA: 0x0059D2A8 File Offset: 0x0059B4A8
	public bool CheckCanWearOrnamentAndShowTip()
	{
		BaseTagComponent component = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<BaseTagComponent>();
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]) || component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_ForbiddenActionInFight_Text", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.正常游泳"]))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_ForbiddenActionInSwimming_Text", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"]))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_ForbiddenActionInClimbing_Text", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_ForbiddenActionMidair_Text", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x06014185 RID: 82309 RVA: 0x0059D39C File Offset: 0x0059B59C
	public void OpenOrnamentPreviewView(int ornamentId, int? skinId)
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RoleOrnamentShowView))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("OrnamentUiText_08", Array.Empty<object>());
			return;
		}
		RoleOrnamentShowViewParams param = new RoleOrnamentShowViewParams
		{
			OrnamentId = ornamentId,
			SkinId = skinId
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleOrnamentShowView, param, null);
	}

	// Token: 0x06014186 RID: 82310 RVA: 0x0059D3F4 File Offset: 0x0059B5F4
	public void SkipToRoleOrnamentViewByItemId(int itemId, bool skipCameraBlend = true)
	{
		if (ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(itemId) == null)
		{
			return;
		}
		int[] roleSkinIds = ModelBase<RoleOrnamentModel>.Instance.GetRoleOrnamentData(itemId).GetRoleSkinIds();
		int? skinId = null;
		int? num = null;
		int[] array = roleSkinIds;
		int i = 0;
		while (i < array.Length)
		{
			int num2 = array[i];
			int roleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(num2).GetRoleId();
			if (!ModelBase<RoleModel>.Instance.IsMainRole(roleId))
			{
				goto IL_84;
			}
			int num3 = roleId;
			int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
			if (num3 == curSelectMainRoleId.GetValueOrDefault() & curSelectMainRoleId != null)
			{
				goto IL_84;
			}
			IL_B5:
			i++;
			continue;
			IL_84:
			RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId);
			if (roleInstanceById != null && num2 == roleInstanceById.GetRoleSkinId())
			{
				skinId = new int?(num2);
				num = new int?(roleId);
				break;
			}
			goto IL_B5;
		}
		if (num == null || skinId == null || !ModelBase<RoleModel>.Instance.IsRoleOwned(num.Value))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ConfirmBox_233_Content", Array.Empty<object>());
			return;
		}
		this.OpenRoleOrnamentView(num.Value, skinId, new int?(itemId), null, new bool?(skipCameraBlend));
	}

	// Token: 0x06014187 RID: 82311 RVA: 0x0059D51C File Offset: 0x0059B71C
	[NullableContext(2)]
	public void OpenRoleOrnamentView(int roleId, int? skinId = null, int? ornamentId = null, TOpenViewCallBack finishCallback = null, bool? skipCameraBlend = null)
	{
		WeaponDataBase weaponDataByRoleDataId = ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(roleId, true);
		if (!(weaponDataByRoleDataId is WeaponInstance))
		{
			return;
		}
		ISkinViewData param = new SkinViewData
		{
			RoleId = roleId,
			TabViewName = EUiTabViewName.RoleOrnamentTabView,
			WeaponId = ((WeaponInstance)weaponDataByRoleDataId).GetIncId().Value,
			NeedLoadRole = true,
			OrnamentSkinId = skinId,
			OrnamentId = ornamentId,
			SkipOrnamentCameraBlend = skipCameraBlend
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SkinRootView, param, finishCallback);
	}

	// Token: 0x06014188 RID: 82312 RVA: 0x0059D5A0 File Offset: 0x0059B7A0
	private void OnRoleUpdateDevelopTargetNotify(RoleUpdateDevelopTargetNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<RoleDevelopModel>.Instance.SelectPlanId = notify.PlanId;
		ModelBase<RoleDevelopModel>.Instance.SelectFirstVisionMonsterId = notify.FirstPhantomId;
		int roleId = notify.RoleId;
		int devTargetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
		if (roleId != 0 && devTargetRoleId != roleId)
		{
			RoleDevelopData roleDevelopData = ModelBase<RoleDevelopModel>.Instance.GetRoleDevelopData(roleId);
			if (roleDevelopData != null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoleProject_Tips14", new object[]
				{
					roleDevelopData.GetDevelopRoleData().GetName()
				});
			}
			else
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoleProject_Tips11", Array.Empty<object>());
			}
		}
		else if (roleId == 0 && devTargetRoleId != 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoleProject_Tips15", Array.Empty<object>());
		}
		ModelBase<RoleDevelopModel>.Instance.UpdateDevTargetRoleId(roleId);
		Singleton<EventSystem>.Instance.Emit(EEventName.RoleDevTargetRoleIdChange);
	}

	// Token: 0x06014189 RID: 82313 RVA: 0x0059D668 File Offset: 0x0059B868
	private void OnRoleDevelopConfigUpdateNotify(RoleDevelopConfigUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RoleDevelopConfigs configs = notify.Configs;
		if (configs == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RoleDev, ELogAuthor.LJS, "RoleDevelopConfigUpdateNotify Configs为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ModelBase<RoleDevelopModel>.Instance.UpdateRoleDevConfig(configs);
	}

	// Token: 0x0601418A RID: 82314 RVA: 0x0059D6AC File Offset: 0x0059B8AC
	public UniTask RequestRoleDevelopConfig()
	{
		RoleController.<RequestRoleDevelopConfig>d__72 <RequestRoleDevelopConfig>d__;
		<RequestRoleDevelopConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestRoleDevelopConfig>d__.<>1__state = -1;
		<RequestRoleDevelopConfig>d__.<>t__builder.Start<RoleController.<RequestRoleDevelopConfig>d__72>(ref <RequestRoleDevelopConfig>d__);
		return <RequestRoleDevelopConfig>d__.<>t__builder.Task;
	}

	// Token: 0x0601418B RID: 82315 RVA: 0x0059D6E8 File Offset: 0x0059B8E8
	public UniTask RequestRoleDevelopDependentData()
	{
		RoleController.<RequestRoleDevelopDependentData>d__73 <RequestRoleDevelopDependentData>d__;
		<RequestRoleDevelopDependentData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestRoleDevelopDependentData>d__.<>4__this = this;
		<RequestRoleDevelopDependentData>d__.<>1__state = -1;
		<RequestRoleDevelopDependentData>d__.<>t__builder.Start<RoleController.<RequestRoleDevelopDependentData>d__73>(ref <RequestRoleDevelopDependentData>d__);
		return <RequestRoleDevelopDependentData>d__.<>t__builder.Task;
	}

	// Token: 0x0601418C RID: 82316 RVA: 0x0059D72C File Offset: 0x0059B92C
	public void RequestRoleDevelopVisionRecommendData()
	{
		foreach (RoleDevelopData roleDevelopData in ModelBase<RoleDevelopModel>.Instance.GetNormalRoleDevelopData())
		{
			int id = roleDevelopData.GetId();
			ControllerBase<VisionRecommendController>.Instance.RequestRoleVisionRecommendData(id);
			ControllerBase<VisionRecommendController>.Instance.RequestRoleVisionRecommendAttr(id);
		}
	}

	// Token: 0x0601418D RID: 82317 RVA: 0x0059D798 File Offset: 0x0059B998
	public void RequestUpdateDevelopTarget(int roleId, ERoleDevelopUpdateTargetSource source, int? fetterGroupId = null, int? firstPhantomId = null)
	{
		RoleUpdateDevelopTargetRequest roleUpdateDevelopTargetRequest = RoleUpdateDevelopTargetRequest.Create();
		roleUpdateDevelopTargetRequest.RoleId = roleId;
		roleUpdateDevelopTargetRequest.Source = (int)source;
		roleUpdateDevelopTargetRequest.PlanId = fetterGroupId.GetValueOrDefault();
		roleUpdateDevelopTargetRequest.FirstPhantomId = firstPhantomId.GetValueOrDefault();
		Singleton<Net>.Instance.Call<RoleUpdateDevelopTargetResponse>(ERequestMessageId.RoleUpdateDevelopTargetRequest, roleUpdateDevelopTargetRequest, delegate(RoleUpdateDevelopTargetResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RoleDev;
				ELogAuthor author = ELogAuthor.WMQ;
				string message = "RoleUpdateDevelopTarget请求无响应";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("response", response);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28745, null, true, true);
			}
		}, 0);
	}

	// Token: 0x0601418E RID: 82318 RVA: 0x0059D804 File Offset: 0x0059BA04
	public static void OpenRoleDevelopView(int? roleId)
	{
		RoleDevelopRootViewData roleDevelopRootViewData = new RoleDevelopRootViewData();
		roleDevelopRootViewData.RoleId = roleId;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleDevelopRootView, roleDevelopRootViewData, null);
	}

	// Token: 0x0601418F RID: 82319 RVA: 0x0059D830 File Offset: 0x0059BA30
	public static void OpenRoleDevelopSelectTargetView(ERoleDevelopUpdateTargetSource source, int? roleId = null)
	{
		RoleDevelopSelectTargetViewData roleDevelopSelectTargetViewData = new RoleDevelopSelectTargetViewData();
		roleDevelopSelectTargetViewData.RoleId = roleId;
		roleDevelopSelectTargetViewData.Source = source;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleDevelopSelectTargetView, roleDevelopSelectTargetViewData, null);
	}

	// Token: 0x06014190 RID: 82320 RVA: 0x0059D864 File Offset: 0x0059BA64
	public void LogRoleDevelopClick(int roleId, ERoleDevelopCategoryType mainPage, ERoleDevelopLogSubPage subPage, ERoleDevelopLogItemState? itemState = null)
	{
		RoleDevLogEvent roleDevLogEvent = new RoleDevLogEvent();
		roleDevLogEvent.i_role_id = roleId;
		roleDevLogEvent.i_role_type = ((ModelBase<RoleModel>.Instance.IsRoleOwned(roleId) > false) ? 1 : 0);
		roleDevLogEvent.i_main_page = (int)mainPage;
		roleDevLogEvent.i_sub_page = (int)subPage;
		roleDevLogEvent.i_type = (int)((itemState != null) ? itemState.Value : ERoleDevelopLogItemState.Normal);
		ControllerBase<LogController>.Instance.LogRoleDevPush(roleDevLogEvent);
	}

	// Token: 0x06014191 RID: 82321 RVA: 0x0059D8C4 File Offset: 0x0059BAC4
	public void LogRoleDevelopSkillRecommendClick(int roleId, bool isActive)
	{
		RoleDevelopSkillRecommendClickLogEvent roleDevelopSkillRecommendClickLogEvent = new RoleDevelopSkillRecommendClickLogEvent();
		roleDevelopSkillRecommendClickLogEvent.i_role_id = roleId;
		roleDevelopSkillRecommendClickLogEvent.i_operation = ((isActive > false) ? 1 : 0);
		ControllerBase<LogReportController>.Instance.LogReport(roleDevelopSkillRecommendClickLogEvent);
	}

	// Token: 0x06014192 RID: 82322 RVA: 0x0059D8F3 File Offset: 0x0059BAF3
	public bool CanOpenRoleDevelopView(EUiViewName viewName, object arg = null)
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.RoleDev);
	}

	// Token: 0x06014193 RID: 82323 RVA: 0x0059D90C File Offset: 0x0059BB0C
	[NullableContext(0)]
	public UniTask<bool> RequestPlayerVoiceLanguage()
	{
		RoleController.<RequestPlayerVoiceLanguage>d__81 <RequestPlayerVoiceLanguage>d__;
		<RequestPlayerVoiceLanguage>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestPlayerVoiceLanguage>d__.<>1__state = -1;
		<RequestPlayerVoiceLanguage>d__.<>t__builder.Start<RoleController.<RequestPlayerVoiceLanguage>d__81>(ref <RequestPlayerVoiceLanguage>d__);
		return <RequestPlayerVoiceLanguage>d__.<>t__builder.Task;
	}

	// Token: 0x06014194 RID: 82324 RVA: 0x0059D948 File Offset: 0x0059BB48
	[NullableContext(0)]
	public UniTask<bool> RequestPlayerRoleVoiceSet([Nullable(1)] List<RoleVoiceSetting> roleList)
	{
		RoleController.<RequestPlayerRoleVoiceSet>d__82 <RequestPlayerRoleVoiceSet>d__;
		<RequestPlayerRoleVoiceSet>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestPlayerRoleVoiceSet>d__.roleList = roleList;
		<RequestPlayerRoleVoiceSet>d__.<>1__state = -1;
		<RequestPlayerRoleVoiceSet>d__.<>t__builder.Start<RoleController.<RequestPlayerRoleVoiceSet>d__82>(ref <RequestPlayerRoleVoiceSet>d__);
		return <RequestPlayerRoleVoiceSet>d__.<>t__builder.Task;
	}

	// Token: 0x04009C60 RID: 40032
	private readonly Action OpenRoleMainViewByInput = delegate()
	{
		ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, 0, null, null, null);
	};
}
