using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F88 RID: 20360
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SkillButtonUiController : UiControllerBase<SkillButtonUiController>
	{
		// Token: 0x060348D4 RID: 215252 RVA: 0x00D2C112 File Offset: 0x00D2A312
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x060348D5 RID: 215253 RVA: 0x00D2C115 File Offset: 0x00D2A315
		protected override bool OnClear()
		{
			this.EventInterfaceMap.Clear();
			return true;
		}

		// Token: 0x060348D6 RID: 215254 RVA: 0x00D2C124 File Offset: 0x00D2A324
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnUpdateSceneTeam;
			Action handle;
			if ((handle = SkillButtonUiController.<>O.<0>__OnFormationLoaded) == null)
			{
				handle = (SkillButtonUiController.<>O.<0>__OnFormationLoaded = new Action(SkillButtonUiController.OnFormationLoaded));
			}
			instance.Add(name, handle);
			Singleton<EventSystem>.Instance.Add<global::EOperationType, global::EOperationType>(EEventName.ShowTypeChange, new Action<global::EOperationType, global::EOperationType>(this.ShowTypeChange));
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.RemoveEntity;
			Action<ERemoveEntityType, EntityHandle> handle2;
			if ((handle2 = SkillButtonUiController.<>O.<1>__OnRemoveEntity) == null)
			{
				handle2 = (SkillButtonUiController.<>O.<1>__OnRemoveEntity = new Action<ERemoveEntityType, EntityHandle>(SkillButtonUiController.OnRemoveEntity));
			}
			instance2.Add<ERemoveEntityType, EntityHandle>(name2, handle2);
			EventSystem instance3 = Singleton<EventSystem>.Instance;
			EEventName name3 = EEventName.OnMultiSkillIdChanged;
			Action<int, MultiSkillInfo, int> handle3;
			if ((handle3 = SkillButtonUiController.<>O.<2>__MultiSkillIdChanged) == null)
			{
				handle3 = (SkillButtonUiController.<>O.<2>__MultiSkillIdChanged = new Action<int, MultiSkillInfo, int>(SkillButtonUiController.MultiSkillIdChanged));
			}
			instance3.Add(name3, handle3);
			EventSystem instance4 = Singleton<EventSystem>.Instance;
			EEventName name4 = EEventName.OnMultiSkillEnable;
			Action<int, MultiSkillInfo, int> handle4;
			if ((handle4 = SkillButtonUiController.<>O.<3>__MultiSkillEnable) == null)
			{
				handle4 = (SkillButtonUiController.<>O.<3>__MultiSkillEnable = new Action<int, MultiSkillInfo, int>(SkillButtonUiController.MultiSkillEnable));
			}
			instance4.Add(name4, handle4);
			Singleton<EventSystem>.Instance.Add(EEventName.OnChangeSelectedExploreId, new Action(this.OnEquipExplorePhantomSkill));
			Singleton<EventSystem>.Instance.Add(EEventName.CharSkillCountChanged, new Action<GroupSkillCdInfo>(this.OnSkillCountChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.CharSkillRemainCdChanged, new Action<GroupSkillCdInfo>(this.OnSkillRemainCdChanged));
			EventSystem instance5 = Singleton<EventSystem>.Instance;
			EEventName name5 = EEventName.OnAimStateChanged;
			Action handle5;
			if ((handle5 = SkillButtonUiController.<>O.<4>__OnAimStateChanged) == null)
			{
				handle5 = (SkillButtonUiController.<>O.<4>__OnAimStateChanged = new Action(SkillButtonUiController.OnAimStateChanged));
			}
			instance5.Add(name5, handle5);
			EventSystem instance6 = Singleton<EventSystem>.Instance;
			EEventName name6 = EEventName.BattleUiFollowerAimStateChanged;
			Action<bool, bool> handle6;
			if ((handle6 = SkillButtonUiController.<>O.<5>__OnBattleUiFollowerAimStateChanged) == null)
			{
				handle6 = (SkillButtonUiController.<>O.<5>__OnBattleUiFollowerAimStateChanged = new Action<bool, bool>(SkillButtonUiController.OnBattleUiFollowerAimStateChanged));
			}
			instance6.Add<bool, bool>(name6, handle6);
			EventSystem instance7 = Singleton<EventSystem>.Instance;
			EEventName name7 = EEventName.OnActionKeyChanged;
			Action<string> handle7;
			if ((handle7 = SkillButtonUiController.<>O.<6>__OnActionKeyChanged) == null)
			{
				handle7 = (SkillButtonUiController.<>O.<6>__OnActionKeyChanged = new Action<string>(SkillButtonUiController.OnActionKeyChanged));
			}
			instance7.Add(name7, handle7);
			EventSystem instance8 = Singleton<EventSystem>.Instance;
			EEventName name8 = EEventName.BattleInputEnableChanged;
			Action<EInputAction, bool> handle8;
			if ((handle8 = SkillButtonUiController.<>O.<7>__OnInputEnableChanged) == null)
			{
				handle8 = (SkillButtonUiController.<>O.<7>__OnInputEnableChanged = new Action<EInputAction, bool>(SkillButtonUiController.OnInputEnableChanged));
			}
			instance8.Add<EInputAction, bool>(name8, handle8);
			EventSystem instance9 = Singleton<EventSystem>.Instance;
			EEventName name9 = EEventName.BattleInputVisibleChanged;
			Action<EInputAction, bool> handle9;
			if ((handle9 = SkillButtonUiController.<>O.<8>__OnInputVisibleChanged) == null)
			{
				handle9 = (SkillButtonUiController.<>O.<8>__OnInputVisibleChanged = new Action<EInputAction, bool>(SkillButtonUiController.OnInputVisibleChanged));
			}
			instance9.Add<EInputAction, bool>(name9, handle9);
			EventSystem instance10 = Singleton<EventSystem>.Instance;
			EEventName name10 = EEventName.BattleUiFollowerAimStateChanged;
			Action<bool, bool> handle10;
			if ((handle10 = SkillButtonUiController.<>O.<9>__OnFollowerAimStateChanged) == null)
			{
				handle10 = (SkillButtonUiController.<>O.<9>__OnFollowerAimStateChanged = new Action<bool, bool>(SkillButtonUiController.OnFollowerAimStateChanged));
			}
			instance10.Add<bool, bool>(name10, handle10);
			EventSystem instance11 = Singleton<EventSystem>.Instance;
			EEventName name11 = EEventName.OnPlayerFollowerPossessed;
			Action<EntityHandle> handle11;
			if ((handle11 = SkillButtonUiController.<>O.<10>__OnFollowShooterPossessed) == null)
			{
				handle11 = (SkillButtonUiController.<>O.<10>__OnFollowShooterPossessed = new Action<EntityHandle>(SkillButtonUiController.OnFollowShooterPossessed));
			}
			instance11.Add(name11, handle11);
			EventSystem instance12 = Singleton<EventSystem>.Instance;
			EEventName name12 = EEventName.OnPlayerFollowerUnPossessed;
			Action handle12;
			if ((handle12 = SkillButtonUiController.<>O.<11>__OnFollowShooterUnPossessed) == null)
			{
				handle12 = (SkillButtonUiController.<>O.<11>__OnFollowShooterUnPossessed = new Action(SkillButtonUiController.OnFollowShooterUnPossessed));
			}
			instance12.Add(name12, handle12);
			EventSystem instance13 = Singleton<EventSystem>.Instance;
			EEventName name13 = EEventName.OnEnterVehicle;
			Action<VehiclePassengerInfo, bool> handle13;
			if ((handle13 = SkillButtonUiController.<>O.<12>__OnEnterVehicle) == null)
			{
				handle13 = (SkillButtonUiController.<>O.<12>__OnEnterVehicle = new Action<VehiclePassengerInfo, bool>(SkillButtonUiController.OnEnterVehicle));
			}
			instance13.Add<VehiclePassengerInfo, bool>(name13, handle13);
			EventSystem instance14 = Singleton<EventSystem>.Instance;
			EEventName name14 = EEventName.OnLeaveVehicle;
			Action<VehiclePassengerInfo, bool> handle14;
			if ((handle14 = SkillButtonUiController.<>O.<13>__OnLeaveVehicle) == null)
			{
				handle14 = (SkillButtonUiController.<>O.<13>__OnLeaveVehicle = new Action<VehiclePassengerInfo, bool>(SkillButtonUiController.OnLeaveVehicle));
			}
			instance14.Add<VehiclePassengerInfo, bool>(name14, handle14);
			EventSystem instance15 = Singleton<EventSystem>.Instance;
			EEventName name15 = EEventName.OpenView;
			Action<EUiViewName, int> handle15;
			if ((handle15 = SkillButtonUiController.<>O.<14>__OnOpenView) == null)
			{
				handle15 = (SkillButtonUiController.<>O.<14>__OnOpenView = new Action<EUiViewName, int>(SkillButtonUiController.OnOpenView));
			}
			instance15.Add<EUiViewName, int>(name15, handle15);
			EventSystem instance16 = Singleton<EventSystem>.Instance;
			EEventName name16 = EEventName.CloseView;
			Action<EUiViewName, int> handle16;
			if ((handle16 = SkillButtonUiController.<>O.<15>__OnCloseView) == null)
			{
				handle16 = (SkillButtonUiController.<>O.<15>__OnCloseView = new Action<EUiViewName, int>(SkillButtonUiController.OnCloseView));
			}
			instance16.Add<EUiViewName, int>(name16, handle16);
			Singleton<EventSystem>.Instance.Add(EEventName.GuideLimitActionInput, new Action<string, bool>(this.OnGuideLimitActionInput));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnBattleUiMotorcycleStateChanged));
			EventSystem instance17 = Singleton<EventSystem>.Instance;
			EEventName name17 = EEventName.InputControllerChange;
			Action<EInputControllerType, EInputControllerType> handle17;
			if ((handle17 = SkillButtonUiController.<>O.<16>__InputControllerChange) == null)
			{
				handle17 = (SkillButtonUiController.<>O.<16>__InputControllerChange = new Action<EInputControllerType, EInputControllerType>(SkillButtonUiController.InputControllerChange));
			}
			instance17.Add<EInputControllerType, EInputControllerType>(name17, handle17);
			ControllerBase<InputDistributeController>.Instance.BindAction("组合主键", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCombineButton));
			ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputInteractButton));
		}

		// Token: 0x060348D7 RID: 215255 RVA: 0x00D2C4F4 File Offset: 0x00D2A6F4
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnUpdateSceneTeam;
			Action handle;
			if ((handle = SkillButtonUiController.<>O.<0>__OnFormationLoaded) == null)
			{
				handle = (SkillButtonUiController.<>O.<0>__OnFormationLoaded = new Action(SkillButtonUiController.OnFormationLoaded));
			}
			instance.Remove(name, handle);
			Singleton<EventSystem>.Instance.Remove(EEventName.ShowTypeChange, new Action<global::EOperationType, global::EOperationType>(this.ShowTypeChange));
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.RemoveEntity;
			Action<ERemoveEntityType, EntityHandle> handle2;
			if ((handle2 = SkillButtonUiController.<>O.<1>__OnRemoveEntity) == null)
			{
				Action<ERemoveEntityType, EntityHandle> action = SkillButtonUiController.<>O.<1>__OnRemoveEntity = new Action<ERemoveEntityType, EntityHandle>(SkillButtonUiController.OnRemoveEntity);
				handle2 = action;
			}
			instance2.Remove(name2, handle2);
			EventSystem instance3 = Singleton<EventSystem>.Instance;
			EEventName name3 = EEventName.OnMultiSkillIdChanged;
			Action<int, MultiSkillInfo, int> handle3;
			if ((handle3 = SkillButtonUiController.<>O.<2>__MultiSkillIdChanged) == null)
			{
				handle3 = (SkillButtonUiController.<>O.<2>__MultiSkillIdChanged = new Action<int, MultiSkillInfo, int>(SkillButtonUiController.MultiSkillIdChanged));
			}
			instance3.Remove(name3, handle3);
			EventSystem instance4 = Singleton<EventSystem>.Instance;
			EEventName name4 = EEventName.OnMultiSkillEnable;
			Action<int, MultiSkillInfo, int> handle4;
			if ((handle4 = SkillButtonUiController.<>O.<3>__MultiSkillEnable) == null)
			{
				handle4 = (SkillButtonUiController.<>O.<3>__MultiSkillEnable = new Action<int, MultiSkillInfo, int>(SkillButtonUiController.MultiSkillEnable));
			}
			instance4.Remove(name4, handle4);
			Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeSelectedExploreId, new Action(this.OnEquipExplorePhantomSkill));
			Singleton<EventSystem>.Instance.Remove(EEventName.CharSkillCountChanged, new Action<GroupSkillCdInfo>(this.OnSkillCountChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.CharSkillRemainCdChanged, new Action<GroupSkillCdInfo>(this.OnSkillRemainCdChanged));
			EventSystem instance5 = Singleton<EventSystem>.Instance;
			EEventName name5 = EEventName.OnAimStateChanged;
			Action handle5;
			if ((handle5 = SkillButtonUiController.<>O.<4>__OnAimStateChanged) == null)
			{
				handle5 = (SkillButtonUiController.<>O.<4>__OnAimStateChanged = new Action(SkillButtonUiController.OnAimStateChanged));
			}
			instance5.Remove(name5, handle5);
			EventSystem instance6 = Singleton<EventSystem>.Instance;
			EEventName name6 = EEventName.BattleUiFollowerAimStateChanged;
			Action<bool, bool> handle6;
			if ((handle6 = SkillButtonUiController.<>O.<5>__OnBattleUiFollowerAimStateChanged) == null)
			{
				handle6 = (SkillButtonUiController.<>O.<5>__OnBattleUiFollowerAimStateChanged = new Action<bool, bool>(SkillButtonUiController.OnBattleUiFollowerAimStateChanged));
			}
			instance6.Remove(name6, handle6);
			EventSystem instance7 = Singleton<EventSystem>.Instance;
			EEventName name7 = EEventName.OnActionKeyChanged;
			Action<string> handle7;
			if ((handle7 = SkillButtonUiController.<>O.<6>__OnActionKeyChanged) == null)
			{
				handle7 = (SkillButtonUiController.<>O.<6>__OnActionKeyChanged = new Action<string>(SkillButtonUiController.OnActionKeyChanged));
			}
			instance7.Remove(name7, handle7);
			EventSystem instance8 = Singleton<EventSystem>.Instance;
			EEventName name8 = EEventName.BattleInputEnableChanged;
			Action<EInputAction, bool> handle8;
			if ((handle8 = SkillButtonUiController.<>O.<7>__OnInputEnableChanged) == null)
			{
				handle8 = (SkillButtonUiController.<>O.<7>__OnInputEnableChanged = new Action<EInputAction, bool>(SkillButtonUiController.OnInputEnableChanged));
			}
			instance8.Remove(name8, handle8);
			EventSystem instance9 = Singleton<EventSystem>.Instance;
			EEventName name9 = EEventName.BattleInputVisibleChanged;
			Action<EInputAction, bool> handle9;
			if ((handle9 = SkillButtonUiController.<>O.<8>__OnInputVisibleChanged) == null)
			{
				handle9 = (SkillButtonUiController.<>O.<8>__OnInputVisibleChanged = new Action<EInputAction, bool>(SkillButtonUiController.OnInputVisibleChanged));
			}
			instance9.Remove(name9, handle9);
			EventSystem instance10 = Singleton<EventSystem>.Instance;
			EEventName name10 = EEventName.BattleUiFollowerAimStateChanged;
			Action<bool, bool> handle10;
			if ((handle10 = SkillButtonUiController.<>O.<9>__OnFollowerAimStateChanged) == null)
			{
				handle10 = (SkillButtonUiController.<>O.<9>__OnFollowerAimStateChanged = new Action<bool, bool>(SkillButtonUiController.OnFollowerAimStateChanged));
			}
			instance10.Remove(name10, handle10);
			EventSystem instance11 = Singleton<EventSystem>.Instance;
			EEventName name11 = EEventName.OnPlayerFollowerPossessed;
			Action<EntityHandle> handle11;
			if ((handle11 = SkillButtonUiController.<>O.<10>__OnFollowShooterPossessed) == null)
			{
				handle11 = (SkillButtonUiController.<>O.<10>__OnFollowShooterPossessed = new Action<EntityHandle>(SkillButtonUiController.OnFollowShooterPossessed));
			}
			instance11.Remove(name11, handle11);
			EventSystem instance12 = Singleton<EventSystem>.Instance;
			EEventName name12 = EEventName.OnPlayerFollowerUnPossessed;
			Action handle12;
			if ((handle12 = SkillButtonUiController.<>O.<11>__OnFollowShooterUnPossessed) == null)
			{
				handle12 = (SkillButtonUiController.<>O.<11>__OnFollowShooterUnPossessed = new Action(SkillButtonUiController.OnFollowShooterUnPossessed));
			}
			instance12.Remove(name12, handle12);
			EventSystem instance13 = Singleton<EventSystem>.Instance;
			EEventName name13 = EEventName.OnEnterVehicle;
			Action<VehiclePassengerInfo, bool> handle13;
			if ((handle13 = SkillButtonUiController.<>O.<12>__OnEnterVehicle) == null)
			{
				handle13 = (SkillButtonUiController.<>O.<12>__OnEnterVehicle = new Action<VehiclePassengerInfo, bool>(SkillButtonUiController.OnEnterVehicle));
			}
			instance13.Remove<VehiclePassengerInfo, bool>(name13, handle13);
			EventSystem instance14 = Singleton<EventSystem>.Instance;
			EEventName name14 = EEventName.OnLeaveVehicle;
			Action<VehiclePassengerInfo, bool> handle14;
			if ((handle14 = SkillButtonUiController.<>O.<13>__OnLeaveVehicle) == null)
			{
				handle14 = (SkillButtonUiController.<>O.<13>__OnLeaveVehicle = new Action<VehiclePassengerInfo, bool>(SkillButtonUiController.OnLeaveVehicle));
			}
			instance14.Remove<VehiclePassengerInfo, bool>(name14, handle14);
			EventSystem instance15 = Singleton<EventSystem>.Instance;
			EEventName name15 = EEventName.OpenView;
			Action<EUiViewName, int> handle15;
			if ((handle15 = SkillButtonUiController.<>O.<14>__OnOpenView) == null)
			{
				handle15 = (SkillButtonUiController.<>O.<14>__OnOpenView = new Action<EUiViewName, int>(SkillButtonUiController.OnOpenView));
			}
			instance15.Remove(name15, handle15);
			EventSystem instance16 = Singleton<EventSystem>.Instance;
			EEventName name16 = EEventName.CloseView;
			Action<EUiViewName, int> handle16;
			if ((handle16 = SkillButtonUiController.<>O.<15>__OnCloseView) == null)
			{
				handle16 = (SkillButtonUiController.<>O.<15>__OnCloseView = new Action<EUiViewName, int>(SkillButtonUiController.OnCloseView));
			}
			instance16.Remove(name16, handle16);
			Singleton<EventSystem>.Instance.Remove(EEventName.GuideLimitActionInput, new Action<string, bool>(this.OnGuideLimitActionInput));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnBattleUiMotorcycleStateChanged));
			EventSystem instance17 = Singleton<EventSystem>.Instance;
			EEventName name17 = EEventName.InputControllerChange;
			Action<EInputControllerType, EInputControllerType> handle17;
			if ((handle17 = SkillButtonUiController.<>O.<16>__InputControllerChange) == null)
			{
				handle17 = (SkillButtonUiController.<>O.<16>__InputControllerChange = new Action<EInputControllerType, EInputControllerType>(SkillButtonUiController.InputControllerChange));
			}
			instance17.Remove(name17, handle17);
			ControllerBase<InputDistributeController>.Instance.UnBindAction("组合主键", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCombineButton));
			ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputInteractButton));
		}

		// Token: 0x060348D8 RID: 215256 RVA: 0x00D2C8C5 File Offset: 0x00D2AAC5
		[NullableContext(2)]
		private static void MultiSkillIdChanged(int entityId, MultiSkillInfo info, int visionEntityId)
		{
			ModelBase<SkillButtonUiModel>.Instance.ExecuteMultiSkillIdChanged(entityId, info, visionEntityId);
		}

		// Token: 0x060348D9 RID: 215257 RVA: 0x00D2C8D4 File Offset: 0x00D2AAD4
		[NullableContext(2)]
		private static void MultiSkillEnable(int entityId, MultiSkillInfo info, int visionEntityId)
		{
			ModelBase<SkillButtonUiModel>.Instance.ExecuteMultiSkillEnable(entityId, info, visionEntityId);
		}

		// Token: 0x060348DA RID: 215258 RVA: 0x00D2C8E3 File Offset: 0x00D2AAE3
		private void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
		{
			SkillButtonUiController.RefreshSkillButtonData(newEntityHandle, ESkillButtonRefreshReason.ChangeRole);
		}

		// Token: 0x060348DB RID: 215259 RVA: 0x00D2C8EC File Offset: 0x00D2AAEC
		private static void OnFormationLoaded()
		{
			ModelBase<SkillButtonUiModel>.Instance.CheckAndRemoveInvalidEntityData();
			ModelBase<SkillButtonUiModel>.Instance.CreateAllSkillButtonEntityData();
		}

		// Token: 0x060348DC RID: 215260 RVA: 0x00D2C904 File Offset: 0x00D2AB04
		private void ShowTypeChange(global::EOperationType eOperationType, global::EOperationType operationType)
		{
			ModelBase<SkillButtonUiModel>.Instance.RefreshSkillButtonIndexOnOperationTypeChanged();
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null)
			{
				return;
			}
			SkillButtonUiController.RefreshSkillButtonData(getCurrentEntity, ESkillButtonRefreshReason.None);
		}

		// Token: 0x060348DD RID: 215261 RVA: 0x00D2C931 File Offset: 0x00D2AB31
		[NullableContext(2)]
		private static void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			ModelBase<SkillButtonUiModel>.Instance.OnRemoveEntity(handle);
		}

		// Token: 0x060348DE RID: 215262 RVA: 0x00D2C940 File Offset: 0x00D2AB40
		[NullableContext(2)]
		private static void RefreshSkillButtonData(EntityHandle entityHandle, ESkillButtonRefreshReason refreshReason = ESkillButtonRefreshReason.None)
		{
			bool desktopOrPad = Singleton<Info>.Instance.OperationType == global::EOperationType.Desktop;
			ModelBase<SkillButtonUiModel>.Instance.RefreshSkillButtonData(entityHandle, desktopOrPad, refreshReason);
		}

		// Token: 0x060348DF RID: 215263 RVA: 0x00D2C968 File Offset: 0x00D2AB68
		[NullableContext(2)]
		public int GetRoleId(Entity entity)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				return 0;
			}
			int roleId = component.GetRoleId();
			return ConfigBase<RoleConfig>.Instance.GetBaseRoleId(roleId);
		}

		// Token: 0x060348E0 RID: 215264 RVA: 0x00D2C993 File Offset: 0x00D2AB93
		public void AddEventInterface(ISkillButtonUiEventInterface eventInterface)
		{
			if (eventInterface == null)
			{
				return;
			}
			this.EventInterfaceMap.Add(eventInterface);
		}

		// Token: 0x060348E1 RID: 215265 RVA: 0x00D2C9A6 File Offset: 0x00D2ABA6
		public void RemoveEventInterface(ISkillButtonUiEventInterface eventInterface)
		{
			if (eventInterface == null)
			{
				return;
			}
			this.EventInterfaceMap.Remove(eventInterface);
		}

		// Token: 0x060348E2 RID: 215266 RVA: 0x00D2C9BC File Offset: 0x00D2ABBC
		private void OnEquipExplorePhantomSkill()
		{
			int currentExploreSkillId = ModelBase<RouletteModel>.Instance.CurrentExploreSkillId;
			ExploreTools? exploreConfigById = ConfigBase<RouletteConfig>.Instance.GetExploreConfigById(currentExploreSkillId);
			if (exploreConfigById == null || exploreConfigById.Value.SkillType != 5)
			{
				ModelBase<SkillButtonUiModel>.Instance.RefreshSkillButtonExplorePhantomSkillId(ESkillButtonType.幻象1);
			}
			foreach (ISkillButtonUiEventInterface skillButtonUiEventInterface in this.EventInterfaceMap)
			{
				skillButtonUiEventInterface.EquipExplorePhantomSkill();
			}
		}

		// Token: 0x060348E3 RID: 215267 RVA: 0x00D2CA4C File Offset: 0x00D2AC4C
		[NullableContext(2)]
		private void OnSkillCountChanged(GroupSkillCdInfo groupSkillCdInfo)
		{
			ModelBase<SkillButtonUiModel>.Instance.OnSkillCdChanged(groupSkillCdInfo);
			foreach (ISkillButtonUiEventInterface skillButtonUiEventInterface in this.EventInterfaceMap)
			{
				skillButtonUiEventInterface.SkillCountChanged(groupSkillCdInfo);
			}
		}

		// Token: 0x060348E4 RID: 215268 RVA: 0x00D2CAA8 File Offset: 0x00D2ACA8
		[NullableContext(2)]
		private void OnSkillRemainCdChanged(GroupSkillCdInfo groupSkillCdInfo)
		{
			ModelBase<SkillButtonUiModel>.Instance.OnSkillCdChanged(groupSkillCdInfo);
			foreach (ISkillButtonUiEventInterface skillButtonUiEventInterface in this.EventInterfaceMap)
			{
				skillButtonUiEventInterface.SkillRemainCdChanged(groupSkillCdInfo);
			}
		}

		// Token: 0x060348E5 RID: 215269 RVA: 0x00D2CB04 File Offset: 0x00D2AD04
		private static void OnBattleUiFollowerAimStateChanged(bool b, bool b1)
		{
			SkillButtonUiController.OnAimStateChanged();
		}

		// Token: 0x060348E6 RID: 215270 RVA: 0x00D2CB0B File Offset: 0x00D2AD0B
		private static void OnAimStateChanged()
		{
			ModelBase<SkillButtonUiModel>.Instance.OnAimStateChanged();
		}

		// Token: 0x060348E7 RID: 215271 RVA: 0x00D2CB17 File Offset: 0x00D2AD17
		private static void OnActionKeyChanged(string actionName)
		{
			ModelBase<SkillButtonUiModel>.Instance.OnActionKeyChanged(actionName);
		}

		// Token: 0x060348E8 RID: 215272 RVA: 0x00D2CB24 File Offset: 0x00D2AD24
		private static void OnInputEnableChanged(EInputAction inputAction, bool enable)
		{
			ModelBase<SkillButtonUiModel>.Instance.OnInputEnableChanged(inputAction, enable);
		}

		// Token: 0x060348E9 RID: 215273 RVA: 0x00D2CB32 File Offset: 0x00D2AD32
		private static void OnFollowerAimStateChanged(bool isAiming, bool b)
		{
			SkillButtonFormationData skillButtonFormationData = ModelBase<SkillButtonUiModel>.Instance.SkillButtonFormationData;
			if (skillButtonFormationData == null)
			{
				return;
			}
			skillButtonFormationData.RefreshOnFollowerAimStateChange(isAiming);
		}

		// Token: 0x060348EA RID: 215274 RVA: 0x00D2CB49 File Offset: 0x00D2AD49
		private static void OnInputVisibleChanged(EInputAction inputAction, bool visible)
		{
			ModelBase<SkillButtonUiModel>.Instance.OnInputVisibleChanged(inputAction, visible);
		}

		// Token: 0x060348EB RID: 215275 RVA: 0x00D2CB57 File Offset: 0x00D2AD57
		private static void OnFollowShooterPossessed(EntityHandle follower)
		{
			ModelBase<SkillButtonUiModel>.Instance.CreateSkillButtonFollowerEntityData(follower);
		}

		// Token: 0x060348EC RID: 215276 RVA: 0x00D2CB64 File Offset: 0x00D2AD64
		private static void OnFollowShooterUnPossessed()
		{
			ModelBase<SkillButtonUiModel>.Instance.ClearSkillButtonFollowerEntityData();
		}

		// Token: 0x060348ED RID: 215277 RVA: 0x00D2CB70 File Offset: 0x00D2AD70
		private static void OnEnterVehicle(VehiclePassengerInfo info, bool byChangeRole)
		{
			if (!info.IsRolePassenger(true))
			{
				return;
			}
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			Entity vehicleEntity = info.VehicleEntity;
			EntityHandle entityById = instance.GetEntityById((vehicleEntity != null) ? vehicleEntity.Id : 0);
			if (entityById != null && entityById.Valid)
			{
				ModelBase<SkillButtonUiModel>.Instance.CreateSkillButtonVehicleEntityData(entityById, info.VehicleType);
			}
		}

		// Token: 0x060348EE RID: 215278 RVA: 0x00D2CBC0 File Offset: 0x00D2ADC0
		private static void OnLeaveVehicle(VehiclePassengerInfo info, bool byChangeRole)
		{
			if (!info.IsRolePassenger(true))
			{
				return;
			}
			ModelBase<SkillButtonUiModel>.Instance.ClearSkillButtonVehicleEntityData();
		}

		// Token: 0x060348EF RID: 215279 RVA: 0x00D2CBD8 File Offset: 0x00D2ADD8
		private static void OnOpenView(EUiViewName viewName, int viewId)
		{
			if (viewName == EUiViewName.MenuView)
			{
				foreach (SkillButtonUiGamepadDataBase skillButtonUiGamepadDataBase in ModelBase<SkillButtonUiModel>.Instance.GamepadDataMap.Values)
				{
					skillButtonUiGamepadDataBase.AddChangeKeyReason(EGamepadChangeKeyReason.MenuView);
				}
			}
		}

		// Token: 0x060348F0 RID: 215280 RVA: 0x00D2CC40 File Offset: 0x00D2AE40
		private static void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName == EUiViewName.MenuView)
			{
				foreach (SkillButtonUiGamepadDataBase skillButtonUiGamepadDataBase in ModelBase<SkillButtonUiModel>.Instance.GamepadDataMap.Values)
				{
					skillButtonUiGamepadDataBase.RemoveChangeKeyReason(EGamepadChangeKeyReason.MenuView);
					skillButtonUiGamepadDataBase.RefreshSwitchInteractOpen(false);
				}
			}
		}

		// Token: 0x060348F1 RID: 215281 RVA: 0x00D2CCB0 File Offset: 0x00D2AEB0
		private void HandlePressCombineButton(string actionName, bool bPress)
		{
			if (actionName != "组合主键")
			{
				return;
			}
			BattleUiMotorcycleData motorcycleData = ModelBase<BattleUiModel>.Instance.MotorcycleData;
			if (motorcycleData != null && motorcycleData.LastDriving)
			{
				this.SetIsPressMotorcycleCombineButton(bPress);
				return;
			}
			this.SetIsPressCombineButton(bPress);
		}

		// Token: 0x060348F2 RID: 215282 RVA: 0x00D2CCE7 File Offset: 0x00D2AEE7
		private void OnGuideLimitActionInput(string actionName, bool bPress)
		{
			this.HandlePressCombineButton(actionName, bPress);
		}

		// Token: 0x060348F3 RID: 215283 RVA: 0x00D2CCF4 File Offset: 0x00D2AEF4
		private void OnBattleUiMotorcycleStateChanged(bool isDriving)
		{
			if (ModelBase<InputDistributeModel>.Instance.IsActionInPress("组合主键"))
			{
				if (this.StatusType == ESkillButtonStatusType.Motorcycle)
				{
					this.SetIsPressMotorcycleCombineButton(false);
					this.SetIsPressCombineButton(true);
					return;
				}
				if (this.StatusType == ESkillButtonStatusType.Normal)
				{
					this.SetIsPressCombineButton(false);
					this.SetIsPressMotorcycleCombineButton(true);
				}
			}
		}

		// Token: 0x060348F4 RID: 215284 RVA: 0x00D2CD40 File Offset: 0x00D2AF40
		private static void InputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			ModelBase<SkillButtonUiModel>.Instance.OnInputControllerChange(last, now);
		}

		// Token: 0x060348F5 RID: 215285 RVA: 0x00D2CD4E File Offset: 0x00D2AF4E
		private void OnInputCombineButton(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			this.HandlePressCombineButton(actionName, actionType == InputDistributeDefine.EActionType.Press);
		}

		// Token: 0x060348F6 RID: 215286 RVA: 0x00D2CD5B File Offset: 0x00D2AF5B
		private void SetIsPressCombineButton(bool isPress)
		{
			this.StatusType = ESkillButtonStatusType.Normal;
			SkillButtonUiGamepadDataBase gamepadDataByType = ModelBase<SkillButtonUiModel>.Instance.GetGamepadDataByType(ESkillButtonGamepadDataType.Normal);
			if (gamepadDataByType != null)
			{
				gamepadDataByType.SetIsPressCombineButton(isPress);
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleUiPressCombineButtonChanged, isPress);
		}

		// Token: 0x060348F7 RID: 215287 RVA: 0x00D2CD8C File Offset: 0x00D2AF8C
		private void SetIsPressMotorcycleCombineButton(bool isPress)
		{
			this.StatusType = ESkillButtonStatusType.Motorcycle;
			SkillButtonUiGamepadDataBase gamepadDataByType = ModelBase<SkillButtonUiModel>.Instance.GetGamepadDataByType(ESkillButtonGamepadDataType.Motorcycle);
			if (gamepadDataByType != null)
			{
				gamepadDataByType.SetIsPressCombineButton(isPress);
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleUiPressMotorcycleCombineButtonChanged, isPress);
		}

		// Token: 0x060348F8 RID: 215288 RVA: 0x00D2CDC0 File Offset: 0x00D2AFC0
		private void OnInputInteractButton(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			bool bPress = actionType == InputDistributeDefine.EActionType.Press;
			SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData == null)
			{
				return;
			}
			gamepadData.SwitchInteractData.InputInteractButton(bPress);
		}

		// Token: 0x060348F9 RID: 215289 RVA: 0x00D2CDEC File Offset: 0x00D2AFEC
		public void PlayExtraEffect(ESkillButtonType buttonType, ESkillButtonExtraEffect effectType, float duration = 0f)
		{
			SkillButtonFormationData skillButtonFormationData = ModelBase<SkillButtonUiModel>.Instance.SkillButtonFormationData;
			SkillButtonTypeFormationData skillButtonTypeFormationData = (skillButtonFormationData != null) ? skillButtonFormationData.GetSkillButtonTypeFormationData(buttonType) : null;
			if (skillButtonTypeFormationData == null)
			{
				return;
			}
			skillButtonTypeFormationData.ExtraEffect = effectType;
			skillButtonTypeFormationData.ExtraEffectDuration = duration;
			Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonExtraEffectRefresh, buttonType);
		}

		// Token: 0x0401E48C RID: 124044
		private readonly Stat ChangeRoleStat = Stat.Create("[ChangeRole]SkillButtonUiController", "", "");

		// Token: 0x0401E48D RID: 124045
		private readonly HashSet<ISkillButtonUiEventInterface> EventInterfaceMap = new HashSet<ISkillButtonUiEventInterface>();

		// Token: 0x0401E48E RID: 124046
		private ESkillButtonStatusType StatusType;

		// Token: 0x0200AF93 RID: 44947
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x040367CB RID: 223179
			[Nullable(0)]
			public static Action <0>__OnFormationLoaded;

			// Token: 0x040367CC RID: 223180
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Action<ERemoveEntityType, EntityHandle> <1>__OnRemoveEntity;

			// Token: 0x040367CD RID: 223181
			[Nullable(new byte[]
			{
				0,
				2
			})]
			public static Action<int, MultiSkillInfo, int> <2>__MultiSkillIdChanged;

			// Token: 0x040367CE RID: 223182
			[Nullable(new byte[]
			{
				0,
				2
			})]
			public static Action<int, MultiSkillInfo, int> <3>__MultiSkillEnable;

			// Token: 0x040367CF RID: 223183
			[Nullable(0)]
			public static Action <4>__OnAimStateChanged;

			// Token: 0x040367D0 RID: 223184
			[Nullable(0)]
			public static Action<bool, bool> <5>__OnBattleUiFollowerAimStateChanged;

			// Token: 0x040367D1 RID: 223185
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Action<string> <6>__OnActionKeyChanged;

			// Token: 0x040367D2 RID: 223186
			[Nullable(0)]
			public static Action<EInputAction, bool> <7>__OnInputEnableChanged;

			// Token: 0x040367D3 RID: 223187
			[Nullable(0)]
			public static Action<EInputAction, bool> <8>__OnInputVisibleChanged;

			// Token: 0x040367D4 RID: 223188
			[Nullable(0)]
			public static Action<bool, bool> <9>__OnFollowerAimStateChanged;

			// Token: 0x040367D5 RID: 223189
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Action<EntityHandle> <10>__OnFollowShooterPossessed;

			// Token: 0x040367D6 RID: 223190
			[Nullable(0)]
			public static Action <11>__OnFollowShooterUnPossessed;

			// Token: 0x040367D7 RID: 223191
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Action<VehiclePassengerInfo, bool> <12>__OnEnterVehicle;

			// Token: 0x040367D8 RID: 223192
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Action<VehiclePassengerInfo, bool> <13>__OnLeaveVehicle;

			// Token: 0x040367D9 RID: 223193
			[Nullable(0)]
			public static Action<EUiViewName, int> <14>__OnOpenView;

			// Token: 0x040367DA RID: 223194
			[Nullable(0)]
			public static Action<EUiViewName, int> <15>__OnCloseView;

			// Token: 0x040367DB RID: 223195
			[Nullable(0)]
			public static Action<EInputControllerType, EInputControllerType> <16>__InputControllerChange;
		}
	}
}
