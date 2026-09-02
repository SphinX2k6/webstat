using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using AkiClient.Game.Aki.Character.Vehicle.Motor.Data;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.NewWorld.Vehicle.Motorcycle;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200329A RID: 12954
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleInputComponent : VehicleInputComponent
{
	// Token: 0x170024E7 RID: 9447
	// (get) Token: 0x0601B217 RID: 111127 RVA: 0x00823CD7 File Offset: 0x00821ED7
	// (set) Token: 0x0601B218 RID: 111128 RVA: 0x00823CE0 File Offset: 0x00821EE0
	protected bool InSprint
	{
		get
		{
			return this.InSprintInternal;
		}
		set
		{
			if (this.InSprintInternal == value)
			{
				return;
			}
			this.InSprintInternal = value;
			BaseTagComponent tagComp = this.TagComp;
			int value2 = (tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"])) ? GameplayTagDefine.EGameplayTagId["载具.摩托.移动.翱翔冲刺.玩家输入"] : GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冲刺.玩家输入"];
			if (value)
			{
				this.TagComp.AddTag(new int?(value2));
				return;
			}
			this.TagComp.RemoveTag(new int?(value2));
		}
	}

	// Token: 0x0601B219 RID: 111129 RVA: 0x00823D6C File Offset: 0x00821F6C
	protected void BanSprint(int tagId, bool isTagExist)
	{
		BaseVehiclePerformComponent performComp = this.PerformComp;
		BaseTagComponent baseTagComponent;
		if (performComp == null)
		{
			baseTagComponent = null;
		}
		else
		{
			Entity driver = performComp.Driver;
			baseTagComponent = ((driver != null) ? driver.GetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		bool bannedSprint;
		if (baseTagComponent2 == null || !baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.功能开关.禁用氮气"]))
		{
			BaseTagComponent tagComp = this.TagComp;
			bannedSprint = (tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用氮气"]));
		}
		else
		{
			bannedSprint = true;
		}
		this.BannedSprint = bannedSprint;
		this.RefreshSprint();
	}

	// Token: 0x0601B21A RID: 111130 RVA: 0x00823DE4 File Offset: 0x00821FE4
	protected void RefreshSprint()
	{
		bool flag = this.CheckNitroBoostPress();
		bool flag2;
		if ((this.PressingSprint || flag) && !this.BannedSprint)
		{
			BaseTagComponent tagComp = this.TagComp;
			flag2 = ((tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.新版漂移"])) || !this.InBackBraking);
		}
		else
		{
			flag2 = false;
		}
		bool flag3 = flag2;
		MotorcycleAudioComponent audioComp = this.AudioComp;
		if (audioComp != null)
		{
			audioComp.MotorNitroAccelerationFailure(this.BannedSprint, flag3, this.PressingSprint);
		}
		this.InSprint = flag3;
	}

	// Token: 0x170024E8 RID: 9448
	// (get) Token: 0x0601B21B RID: 111131 RVA: 0x00823E62 File Offset: 0x00822062
	// (set) Token: 0x0601B21C RID: 111132 RVA: 0x00823E6A File Offset: 0x0082206A
	protected bool InBackBraking
	{
		get
		{
			return this.InBackBrakingInternal;
		}
		set
		{
			if (this.InBackBrakingInternal == value)
			{
				return;
			}
			this.InBackBrakingInternal = value;
			this.MoveComp.BackBraking = value;
		}
	}

	// Token: 0x0601B21D RID: 111133 RVA: 0x00823E8C File Offset: 0x0082208C
	protected void BanDrift(int tagId, bool isTagExist)
	{
		BaseVehiclePerformComponent performComp = this.PerformComp;
		BaseTagComponent baseTagComponent;
		if (performComp == null)
		{
			baseTagComponent = null;
		}
		else
		{
			Entity driver = performComp.Driver;
			baseTagComponent = ((driver != null) ? driver.GetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		bool bannedBackBraking;
		if (baseTagComponent2 == null || !baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.功能开关.禁用漂移"]))
		{
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp == null || !tagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用漂移"]))
			{
				BaseTagComponent tagComp2 = this.TagComp;
				bannedBackBraking = (tagComp2 != null && tagComp2.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"]));
				goto IL_81;
			}
		}
		bannedBackBraking = true;
		IL_81:
		this.BannedBackBraking = bannedBackBraking;
		this.RefreshBackBraking();
	}

	// Token: 0x0601B21E RID: 111134 RVA: 0x00823F28 File Offset: 0x00822128
	protected void OnSoarChanged(int tagId, bool tagExist)
	{
		if (!this.InSprint)
		{
			return;
		}
		if (tagExist)
		{
			this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冲刺.玩家输入"]));
			this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.翱翔冲刺.玩家输入"]));
			return;
		}
		this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.翱翔冲刺.玩家输入"]));
		this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冲刺.玩家输入"]));
	}

	// Token: 0x0601B21F RID: 111135 RVA: 0x00823FC0 File Offset: 0x008221C0
	protected void RefreshBackBraking()
	{
		this.InBackBraking = (this.PressingBackBraking && !this.BannedBackBraking);
		this.RefreshSprint();
	}

	// Token: 0x0601B220 RID: 111136 RVA: 0x00823FE2 File Offset: 0x008221E2
	protected override void OnEnterOrLeaveVehicle(VehiclePassengerInfo info, bool enter)
	{
		base.OnEnterOrLeaveVehicle(info, enter);
		if (!info.IsDriver)
		{
			return;
		}
		this.IsDriving = enter;
		if (enter)
		{
			this.EnterVehicle(info);
		}
		else
		{
			this.LeaveVehicle(info);
		}
		this.BanSprint(0, false);
		this.BanDrift(0, false);
	}

	// Token: 0x0601B221 RID: 111137 RVA: 0x00824020 File Offset: 0x00822220
	private void EnterVehicle(VehiclePassengerInfo info)
	{
		Entity passengerEntity = info.PassengerEntity;
		BaseTagComponent baseTagComponent = (passengerEntity != null) ? passengerEntity.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent != null)
		{
			baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.功能开关.禁用氮气"]), new BaseTagComponent.TTagSwitchedCallback(this.BanSprint), null);
		}
		if (baseTagComponent != null)
		{
			baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.功能开关.禁用漂移"]), new BaseTagComponent.TTagSwitchedCallback(this.BanDrift), null);
		}
		Singleton<EventSystem>.Instance.AddWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
		if (baseTagComponent != null)
		{
			Singleton<EventSystem>.Instance.AddWithTarget<int, int, bool>(baseTagComponent.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
			Singleton<EventSystem>.Instance.AddWithTarget(baseTagComponent.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
		}
		Singleton<EventSystem>.Instance.Add<string>(EEventName.ForceReleaseInput, new Action<string>(this.OnForceReleaseInput));
	}

	// Token: 0x0601B222 RID: 111138 RVA: 0x00824118 File Offset: 0x00822318
	private void LeaveVehicle(VehiclePassengerInfo info)
	{
		Entity passengerEntity = info.PassengerEntity;
		BaseTagComponent baseTagComponent = (passengerEntity != null) ? passengerEntity.GetComponent<BaseTagComponent>() : null;
		this.PressingBackBraking = false;
		this.PressingSprint = false;
		this.InSprint = false;
		this.InBackBraking = false;
		if (baseTagComponent != null)
		{
			baseTagComponent.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.功能开关.禁用氮气"], new BaseTagComponent.TTagSwitchedCallback(this.BanSprint));
		}
		if (baseTagComponent != null)
		{
			baseTagComponent.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.功能开关.禁用漂移"], new BaseTagComponent.TTagSwitchedCallback(this.BanDrift));
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
		if (baseTagComponent != null)
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, bool>(baseTagComponent.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
			Singleton<EventSystem>.Instance.RemoveWithTarget(baseTagComponent.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
		}
		Singleton<EventSystem>.Instance.Remove<string>(EEventName.ForceReleaseInput, new Action<string>(this.OnForceReleaseInput));
	}

	// Token: 0x0601B223 RID: 111139 RVA: 0x0082421C File Offset: 0x0082241C
	protected override bool OnStart()
	{
		base.OnStart();
		this.MoveComp = base.Entity.GetComponent<MotorcycleMoveComponent>();
		this.AudioComp = base.Entity.GetComponent<MotorcycleAudioComponent>();
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null)
		{
			tagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用氮气"]), new BaseTagComponent.TTagSwitchedCallback(this.BanSprint), null);
		}
		BaseTagComponent tagComp2 = this.TagComp;
		if (tagComp2 != null)
		{
			tagComp2.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用漂移"]), new BaseTagComponent.TTagSwitchedCallback(this.BanDrift), null);
		}
		BaseTagComponent tagComp3 = this.TagComp;
		if (tagComp3 != null)
		{
			tagComp3.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"]), new BaseTagComponent.TTagSwitchedCallback(this.BanDrift), null);
		}
		BaseTagComponent tagComp4 = this.TagComp;
		if (tagComp4 != null)
		{
			tagComp4.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"]), new BaseTagComponent.TTagSwitchedCallback(this.OnSoarChanged), null);
		}
		BaseTagComponent tagComp5 = this.TagComp;
		if (tagComp5 != null)
		{
			tagComp5.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.油门维持"]), new BaseTagComponent.TTagSwitchedCallback(this.HoldThrottleChange), null);
		}
		BaseTagComponent tagComp6 = this.TagComp;
		if (tagComp6 != null)
		{
			tagComp6.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.氮气维持"]), new BaseTagComponent.TTagSwitchedCallback(this.NitroBoostChange), null);
		}
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnViewShow));
		this.InitInputAssistConfig();
		this.InitCommandActionMap();
		float? floatConfig = ConfigCommonParamById.GetFloatConfig("MotorJoyStickAngle1");
		this.MotorJoyStickAngle1 = ((floatConfig != null) ? ((double)floatConfig.GetValueOrDefault()) : this.MotorJoyStickAngle1);
		floatConfig = ConfigCommonParamById.GetFloatConfig("MotorJoyStickAngle2");
		this.MotorJoyStickAngle2 = ((floatConfig != null) ? ((double)floatConfig.GetValueOrDefault()) : this.MotorJoyStickAngle2);
		return true;
	}

	// Token: 0x0601B224 RID: 111140 RVA: 0x00824400 File Offset: 0x00822600
	protected override bool OnEnd()
	{
		base.OnEnd();
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null)
		{
			tagComp.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用氮气"], new BaseTagComponent.TTagSwitchedCallback(this.BanSprint));
		}
		BaseTagComponent tagComp2 = this.TagComp;
		if (tagComp2 != null)
		{
			tagComp2.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用漂移"], new BaseTagComponent.TTagSwitchedCallback(this.BanDrift));
		}
		BaseTagComponent tagComp3 = this.TagComp;
		if (tagComp3 != null)
		{
			tagComp3.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"], new BaseTagComponent.TTagSwitchedCallback(this.BanDrift));
		}
		BaseTagComponent tagComp4 = this.TagComp;
		if (tagComp4 != null)
		{
			tagComp4.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"], new BaseTagComponent.TTagSwitchedCallback(this.OnSoarChanged));
		}
		BaseTagComponent tagComp5 = this.TagComp;
		if (tagComp5 != null)
		{
			tagComp5.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.油门维持"], new BaseTagComponent.TTagSwitchedCallback(this.HoldThrottleChange));
		}
		BaseTagComponent tagComp6 = this.TagComp;
		if (tagComp6 != null)
		{
			tagComp6.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.氮气维持"], new BaseTagComponent.TTagSwitchedCallback(this.NitroBoostChange));
		}
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnViewShow));
		return true;
	}

	// Token: 0x0601B225 RID: 111141 RVA: 0x00824535 File Offset: 0x00822735
	protected override void OnDisable(string reason)
	{
		this.AirRotateInput = 0.0;
	}

	// Token: 0x0601B226 RID: 111142 RVA: 0x00824548 File Offset: 0x00822748
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		if (!this.MoveVectorCache.IsNearlyZero(9.999999747378752E-05) || this.InSprint || this.InBackBraking)
		{
			this.LastInputSeconds = Singleton<Time>.Instance.NowSeconds;
		}
		this.UpdateAssistedInput((double)delta);
	}

	// Token: 0x0601B227 RID: 111143 RVA: 0x0082459C File Offset: 0x0082279C
	protected override void UpdateVehicleInputDirectAndFacing()
	{
		OneOf<CharacterActorComponent, VehicleActorComponent> value = this.ActorComp.Value;
		MotorcycleActorComponent motorcycleActorComponent = value.Match<VehicleActorComponent>(([Nullable(1)] CharacterActorComponent t1) => null, ([Nullable(1)] VehicleActorComponent t2) => t2) as MotorcycleActorComponent;
		if (Singleton<Info>.Instance.IsInTouch())
		{
			base.GetMoveVector(this.MotorInputCache);
			this.InputAdjustedTouch(this.MotorInputCache);
			motorcycleActorComponent.SetAirRotateInput(this.MotorInputCache);
		}
		else
		{
			base.GetMoveVector(this.MotorInputCache);
			this.MotorInputCache.X = Singleton<MathUtils>.Instance.Clamp(this.MotorInputCache.X, -1.0, 1.0);
			this.MotorInputCache.Y = Singleton<MathUtils>.Instance.Clamp(this.MotorInputCache.Y, -1.0, 1.0);
			motorcycleActorComponent.SetAirRotateInput(this.MotorInputCache);
		}
		if (Singleton<Info>.Instance.IsPcInputModel() && !Singleton<Info>.Instance.IsInTouch() && !Singleton<Info>.Instance.IsInGamepad() && this.MoveComp.MotorSubState != EMotorSubState.Soaring)
		{
			this.TmpVector1.DeepCopy(motorcycleActorComponent.AirRotateInputProxy);
			this.TmpVector1.X = Math.Min(0.0, this.TmpVector1.X) + this.AirRotateInput;
			motorcycleActorComponent.SetAirRotateInput(this.TmpVector1);
		}
		if (this.MoveComp.MotorSubState == EMotorSubState.Soaring && Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.MotorFlyControlMode, true, true).GetValueOrDefault() == 1)
		{
			this.TmpVector1.DeepCopy(motorcycleActorComponent.AirRotateInputProxy);
			this.TmpVector1.X = -this.TmpVector1.X;
			motorcycleActorComponent.SetAirRotateInput(this.TmpVector1);
		}
		this.PlayerMotorInput.DeepCopy(this.MotorInputCache);
		MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo = this.HoldThrottleInfo1;
		if (holdThrottleInfo == null || !holdThrottleInfo.UpdateAutoState())
		{
			MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo = this.NitroBoostInfo1;
			if (nitroBoostInfo == null || !nitroBoostInfo.UpdateAutoState())
			{
				goto IL_22A;
			}
		}
		this.MotorInputCache.X = 1.0;
		IL_22A:
		if (this.CheckAssistDrift())
		{
			if (!this.PressingBackBraking)
			{
				MotorcycleMoveComponent moveComp = this.MoveComp;
				if (moveComp == null || !moveComp.DriftingState)
				{
					goto IL_262;
				}
			}
			this.MotorInputCache.X = 1.0;
		}
		IL_262:
		value = this.ActorComp.Value;
		value.Switch(delegate(CharacterActorComponent t1)
		{
			t1.SetInputDirect(this.MotorInputCache, false);
		}, delegate(VehicleActorComponent t2)
		{
			t2.SetInputDirect(this.MotorInputCache, false);
		});
		this.SetInputFacingFromInputDirect(true);
	}

	// Token: 0x0601B228 RID: 111144 RVA: 0x00824840 File Offset: 0x00822A40
	protected override void SetInputFacingFromInputDirect(bool clearWhenNoInput = true)
	{
		this.ActorComp.Value.Switch(delegate(CharacterActorComponent t1)
		{
			t1.SetInputFacing(t1.ActorForwardProxy, false);
		}, delegate(VehicleActorComponent t2)
		{
			t2.SetInputFacing(t2.ActorForwardProxy, false);
		});
	}

	// Token: 0x0601B229 RID: 111145 RVA: 0x008248A0 File Offset: 0x00822AA0
	protected void InputAdjustedTouch(global::Vector outInputDirect)
	{
		if (ModelBase<BattleUiModel>.Instance.MotorcycleData.GetIsRoundJoystick())
		{
			if (this.MoveComp.MotorSubState != EMotorSubState.Soaring)
			{
				this.PrevIsPositive = MotorcycleInputComponent.ConvertPolarInput(this.MoveVectorCache, this.TmpVector1, this.MotorJoyStickAngle1, this.MotorJoyStickAngle2, this.PrevIsPositive);
			}
			else
			{
				MotorcycleInputComponent.ConvertCycleInputToSquared(this.MotorInputCache, this.TmpVector1);
			}
		}
		else
		{
			this.TmpVector1.X = Singleton<MathUtils>.Instance.Clamp(this.MotorInputCache.X, -1.0, 1.0);
			this.TmpVector1.Y = Singleton<MathUtils>.Instance.Clamp(this.MotorInputCache.Y, -1.0, 1.0);
		}
		BaseVehiclePerformComponent performComp = this.PerformComp;
		bool flag;
		if (performComp == null)
		{
			flag = false;
		}
		else
		{
			Entity driver = performComp.Driver;
			bool? flag2;
			if (driver == null)
			{
				flag2 = null;
			}
			else
			{
				BaseTagComponent component = driver.GetComponent<BaseTagComponent>();
				flag2 = ((component != null) ? new bool?(component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.功能开关.禁用刹车"])) : null);
			}
			bool? flag3 = flag2;
			flag = flag3.GetValueOrDefault();
		}
		if (!flag)
		{
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp == null || !tagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用刹车"]))
			{
				goto IL_160;
			}
		}
		this.TmpVector1.X = Math.Max(0.0, this.TmpVector1.X);
		IL_160:
		outInputDirect.DeepCopy(this.TmpVector1);
	}

	// Token: 0x0601B22A RID: 111146 RVA: 0x00824A1C File Offset: 0x00822C1C
	public override void ExecuteInputCommand(InputCommand inputCommand, string context)
	{
		SInputCommand command = inputCommand.Command;
		byte b = command.CommandType;
		switch (b)
		{
		case 1:
			this.ExecuteSkill(command);
			return;
		case 2:
			this.ExecuteJump(command);
			return;
		case 3:
			break;
		case 4:
			this.ExecuteSprint(command);
			return;
		default:
			if (b != 8)
			{
				return;
			}
			this.ExecuteSwitchWalk(command);
			break;
		}
	}

	// Token: 0x0601B22B RID: 111147 RVA: 0x00824A78 File Offset: 0x00822C78
	protected override void ExecuteSprint(SInputCommand command)
	{
		this.PressingSprint = (command.IntValue != 0);
		this.RefreshSprint();
	}

	// Token: 0x0601B22C RID: 111148 RVA: 0x00824A8F File Offset: 0x00822C8F
	protected override void ExecuteJump(SInputCommand command)
	{
		this.PressingBackBraking = (command.IntValue != 0);
		this.RefreshBackBraking();
		if (command.IntValue != 0)
		{
			MotorcycleMoveComponent moveComp = this.MoveComp;
			if (moveComp == null)
			{
				return;
			}
			moveComp.SwitchAirMode();
		}
	}

	// Token: 0x0601B22D RID: 111149 RVA: 0x00824AC0 File Offset: 0x00822CC0
	protected override void ExecuteSkill(SInputCommand command)
	{
		this.LastInputSeconds = Singleton<Time>.Instance.NowSeconds;
		if (command.IntValue == 210012)
		{
			BaseVehiclePerformComponent component = base.Entity.GetComponent<BaseVehiclePerformComponent>();
			if (((component != null) ? component.Driver : null) != null)
			{
				component.TryLeave(component.Driver, ELeaveVehicleType.Launch);
				return;
			}
		}
		else
		{
			this.BeginSkill(command.IntValue);
		}
	}

	// Token: 0x0601B22E RID: 111150 RVA: 0x00824B1F File Offset: 0x00822D1F
	protected void ExecuteSwitchWalk(SInputCommand command)
	{
		this.AirRotateInput = (command.IntValue != 0);
	}

	// Token: 0x0601B22F RID: 111151 RVA: 0x00824B31 File Offset: 0x00822D31
	private void BeginSkill(int skillId)
	{
		base.Entity.GetComponent<BaseSkillComponent>().BeginSkill(skillId, new SkillParam
		{
			Reason = "MotorInputComponent.ExecuteSkill"
		});
	}

	// Token: 0x0601B230 RID: 111152 RVA: 0x00824B55 File Offset: 0x00822D55
	public void ForceRefreshBraking()
	{
		this.InBackBraking = !this.InBackBraking;
		this.InBackBraking = !this.InBackBraking;
		this.RefreshSprint();
	}

	// Token: 0x0601B231 RID: 111153 RVA: 0x00824B7B File Offset: 0x00822D7B
	protected void OnAddBlockAction(AkiClient.Game.Aki.Character.Input.Enum.EInputAction inputAction)
	{
		if (inputAction == AkiClient.Game.Aki.Character.Input.Enum.EInputAction.跳跃)
		{
			if (this.PressingBackBraking)
			{
				this.PressingBackBraking = false;
				this.RefreshBackBraking();
				return;
			}
		}
		else if (inputAction == AkiClient.Game.Aki.Character.Input.Enum.EInputAction.闪避 && this.PressingSprint)
		{
			this.PressingSprint = false;
			this.RefreshSprint();
		}
	}

	// Token: 0x0601B232 RID: 111154 RVA: 0x00824BB0 File Offset: 0x00822DB0
	protected override bool IsEnableExecuteCommandImmediately()
	{
		return true;
	}

	// Token: 0x0601B233 RID: 111155 RVA: 0x00824BB4 File Offset: 0x00822DB4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	protected override List<InputCommand> GetImmediateInputCommands(List<InputCommand> inputCommands)
	{
		if (inputCommands.Count == 0)
		{
			return null;
		}
		this.CommandIndexMap.Clear();
		this.CommandPriorityMap.Clear();
		List<InputCommand> list = new List<InputCommand>();
		int num = -1;
		foreach (InputCommand inputCommand in inputCommands)
		{
			TEnumAsByte<ECommandType> commandType = inputCommand.Command.CommandType;
			int index;
			if (this.CommandIndexMap.TryGetValue(commandType, out index))
			{
				int valueOrDefault = this.QueryCommandPriority(inputCommand.Command).GetValueOrDefault(-1);
				int num2;
				if (valueOrDefault > (this.CommandPriorityMap.TryGetValue(commandType, out num2) ? num2 : -1))
				{
					list[index] = inputCommand;
					this.CommandPriorityMap[commandType] = valueOrDefault;
				}
			}
			else
			{
				int valueOrDefault2 = this.QueryCommandPriority(inputCommand.Command).GetValueOrDefault(-1);
				if (valueOrDefault2 > -1)
				{
					list.Add(inputCommand);
					num = (this.CommandIndexMap[commandType] = num + 1);
					this.CommandPriorityMap[commandType] = valueOrDefault2;
				}
			}
		}
		return list;
	}

	// Token: 0x0601B234 RID: 111156 RVA: 0x00824CF4 File Offset: 0x00822EF4
	protected override int QuerySkillPriority(int skillId)
	{
		return 2;
	}

	// Token: 0x0601B235 RID: 111157 RVA: 0x00824CF8 File Offset: 0x00822EF8
	protected override int? QueryCommandPriority(SInputCommand command)
	{
		AkiClient.Game.Aki.Character.Input.Enum.EInputAction action;
		if (this.CommandActionMap.TryGetValue(command.CommandType, out action))
		{
			string actionNameByInputAction = ModelBase<InputModel>.Instance.GetInputData(EInputDataType.NormalWorldMotor).GetActionNameByInputAction(action);
			if (actionNameByInputAction != null)
			{
				bool flag = ModelBase<InputDistributeModel>.Instance.IsActionInPress(actionNameByInputAction);
				if (command.IntValue == 1 && flag)
				{
					return new int?(1);
				}
				if (command.IntValue == 0)
				{
					return new int?(1);
				}
				return new int?(-1);
			}
		}
		return null;
	}

	// Token: 0x0601B236 RID: 111158 RVA: 0x00824D78 File Offset: 0x00822F78
	private void InitCommandActionMap()
	{
		this.CommandActionMap[ECommandType.Jump] = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.跳跃;
		this.CommandActionMap[ECommandType.Sprint] = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.闪避;
		this.CommandActionMap[ECommandType.SwitchWalk] = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.走跑切换;
	}

	// Token: 0x0601B237 RID: 111159 RVA: 0x00824DA1 File Offset: 0x00822FA1
	private void InitInputAssistConfig()
	{
		Singleton<ResourceSystem>.Instance.LoadTypeAsync("BP_MotorAssistInputConfig_C", delegate
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<BP_MotorAssistInputConfig_C>("/Game/Aki/Character/Vehicle/Motor/Data/DA/DA_MotorAssistInputConfig.DA_MotorAssistInputConfig", delegate([Nullable(2)] BP_MotorAssistInputConfig_C result, string _)
			{
				if (result == null || this.TagComp == null)
				{
					return;
				}
				this.DebugAssistDrift = result.DebugAssistDrift;
				this.HoldThrottleInfo1 = new MotorcycleInputComponent.HoldThrottleInfo(this.TagComp, GameplayTagDefine.EGameplayTagId["载具.摩托.移动.油门维持"]);
				this.HoldThrottleInfo1.InitConfig(result);
				this.NitroBoostInfo1 = new MotorcycleInputComponent.NitroBoostInfo(this.TagComp, GameplayTagDefine.EGameplayTagId["载具.摩托.移动.氮气维持"]);
				this.NitroBoostInfo1.InitConfig(result);
			}, 100, "js_undefined");
		}, "js_undefined");
	}

	// Token: 0x0601B238 RID: 111160 RVA: 0x00824DC3 File Offset: 0x00822FC3
	private bool CheckAssistDrift()
	{
		return ModelBase<BattleUiModel>.Instance.MotorcycleData.DriftAcceleratorSettingEnable || this.DebugAssistDrift;
	}

	// Token: 0x0601B239 RID: 111161 RVA: 0x00824DE0 File Offset: 0x00822FE0
	[NullableContext(2)]
	private void ResetAssistInput(string context = null, bool nitro = true, bool throttle = true)
	{
		if (nitro)
		{
			MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo = this.NitroBoostInfo1;
			if (nitroBoostInfo != null && nitroBoostInfo.UpdateAutoState())
			{
				MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo2 = this.NitroBoostInfo1;
				if (nitroBoostInfo2 != null)
				{
					nitroBoostInfo2.ResetAutoState(context);
				}
			}
			else
			{
				MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo3 = this.NitroBoostInfo1;
				if (nitroBoostInfo3 != null)
				{
					nitroBoostInfo3.ClearTimeAccumulation();
				}
			}
		}
		if (throttle)
		{
			MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo = this.HoldThrottleInfo1;
			if (holdThrottleInfo != null && holdThrottleInfo.UpdateAutoState())
			{
				MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo2 = this.HoldThrottleInfo1;
				if (holdThrottleInfo2 == null)
				{
					return;
				}
				holdThrottleInfo2.ResetAutoState(context);
				return;
			}
			else
			{
				MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo3 = this.HoldThrottleInfo1;
				if (holdThrottleInfo3 == null)
				{
					return;
				}
				holdThrottleInfo3.ClearTimeAccumulation();
			}
		}
	}

	// Token: 0x0601B23A RID: 111162 RVA: 0x00824E62 File Offset: 0x00823062
	private void UpdateAssistedInput(double delta)
	{
		if (!this.IsDriving)
		{
			this.ResetAssistInput("角色离开载具", true, true);
			return;
		}
		this.UpdateNitroBoost(delta);
		this.UpdateHoldThrottle(delta);
	}

	// Token: 0x0601B23B RID: 111163 RVA: 0x00824E88 File Offset: 0x00823088
	private void UpdateNitroBoost(double delta)
	{
		MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo = this.NitroBoostInfo1;
		bool? flag = (nitroBoostInfo != null) ? new bool?(nitroBoostInfo.GetSettingEnable()) : null;
		bool flag2 = !this.BannedSprint && !this.InBackBraking;
		bool flag3 = this.PlayerMotorInput.X >= 0.0;
		BaseTagComponent tagComp = this.TagComp;
		bool flag4 = tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"]);
		bool flag5 = flag.GetValueOrDefault() && flag2 && (flag4 || flag3) && this.IsDriving;
		MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo2 = this.NitroBoostInfo1;
		if (((nitroBoostInfo2 != null) ? new bool?(nitroBoostInfo2.UpdateAutoState()) : null).GetValueOrDefault())
		{
			if (!flag5)
			{
				this.ResetAssistInput("氮气维持，不在冲刺或刹车", true, false);
				return;
			}
		}
		else
		{
			MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo3 = this.NitroBoostInfo1;
			bool? flag6 = (nitroBoostInfo3 != null) ? new bool?(nitroBoostInfo3.IsIgnoreInput()) : null;
			if (this.InSprint && flag5 && !flag6.GetValueOrDefault())
			{
				MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo4 = this.NitroBoostInfo1;
				if (nitroBoostInfo4 != null)
				{
					nitroBoostInfo4.AddTimeAccumulation(delta);
				}
				MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo5 = this.NitroBoostInfo1;
				if (((nitroBoostInfo5 != null) ? new bool?(nitroBoostInfo5.CheckTimeDuration()) : null).GetValueOrDefault())
				{
					MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo6 = this.NitroBoostInfo1;
					if (nitroBoostInfo6 != null)
					{
						nitroBoostInfo6.SetStartEnter(true);
					}
					MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo7 = this.NitroBoostInfo1;
					if (nitroBoostInfo7 == null)
					{
						return;
					}
					nitroBoostInfo7.SetAutoState(true);
					return;
				}
			}
			else
			{
				if (!this.PressingSprint && flag6.GetValueOrDefault())
				{
					MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo8 = this.NitroBoostInfo1;
					if (nitroBoostInfo8 != null)
					{
						nitroBoostInfo8.SetIgnoreInput(false);
					}
				}
				MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo9 = this.NitroBoostInfo1;
				if (nitroBoostInfo9 == null)
				{
					return;
				}
				nitroBoostInfo9.ClearTimeAccumulation();
			}
		}
	}

	// Token: 0x0601B23C RID: 111164 RVA: 0x0082502C File Offset: 0x0082322C
	private void UpdateHoldThrottle(double delta)
	{
		MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo = this.HoldThrottleInfo1;
		bool? flag = (holdThrottleInfo != null) ? new bool?(holdThrottleInfo.GetSettingEnable()) : null;
		bool flag2 = this.MoveComp.Speed > 0f;
		bool flag3 = this.PlayerMotorInput.X > 0.0;
		bool flag4 = flag.GetValueOrDefault() && flag2 && flag3 && this.IsDriving;
		bool isRoundJoystick = ModelBase<BattleUiModel>.Instance.MotorcycleData.GetIsRoundJoystick();
		MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo2 = this.HoldThrottleInfo1;
		if (!((holdThrottleInfo2 != null) ? new bool?(holdThrottleInfo2.UpdateAutoState()) : null).GetValueOrDefault())
		{
			MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo3 = this.HoldThrottleInfo1;
			bool? flag5 = (holdThrottleInfo3 != null) ? new bool?(holdThrottleInfo3.IsIgnoreInput()) : null;
			if (flag4 && !flag5.GetValueOrDefault())
			{
				MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo4 = this.HoldThrottleInfo1;
				if (holdThrottleInfo4 != null)
				{
					holdThrottleInfo4.AddTimeAccumulation(delta);
				}
				MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo5 = this.HoldThrottleInfo1;
				if (((holdThrottleInfo5 != null) ? new bool?(holdThrottleInfo5.CheckTimeDuration()) : null).GetValueOrDefault())
				{
					MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo6 = this.HoldThrottleInfo1;
					if (holdThrottleInfo6 != null)
					{
						holdThrottleInfo6.SetStartEnter(true);
					}
					MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo7 = this.HoldThrottleInfo1;
					if (holdThrottleInfo7 == null)
					{
						return;
					}
					holdThrottleInfo7.SetAutoState(true);
					return;
				}
			}
			else
			{
				if (!flag3 && flag5.GetValueOrDefault())
				{
					MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo8 = this.HoldThrottleInfo1;
					if (holdThrottleInfo8 != null)
					{
						holdThrottleInfo8.SetIgnoreInput(false);
					}
				}
				MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo9 = this.HoldThrottleInfo1;
				if (holdThrottleInfo9 == null)
				{
					return;
				}
				holdThrottleInfo9.ClearTimeAccumulation();
			}
			return;
		}
		MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo10 = this.HoldThrottleInfo1;
		bool? flag6 = (holdThrottleInfo10 != null) ? new bool?(holdThrottleInfo10.IsStartEnter()) : null;
		if (this.PlayerMotorInput.X < 0.0)
		{
			this.ResetAssistInput("油门维持，不在移动或刹车", true, true);
			return;
		}
		if (this.PlayerMotorInput.X != 0.0 || !flag6.GetValueOrDefault())
		{
			if (!flag6.GetValueOrDefault() && flag3 && !isRoundJoystick)
			{
				this.ResetAssistInput("给了新的油门，退出油门维持", true, true);
				MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo11 = this.HoldThrottleInfo1;
				if (holdThrottleInfo11 == null)
				{
					return;
				}
				holdThrottleInfo11.SetIgnoreInput(true);
			}
			return;
		}
		MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo12 = this.HoldThrottleInfo1;
		if (holdThrottleInfo12 == null)
		{
			return;
		}
		holdThrottleInfo12.SetStartEnter(false);
	}

	// Token: 0x0601B23D RID: 111165 RVA: 0x00825240 File Offset: 0x00823440
	private bool CheckNitroBoostPress()
	{
		MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo = this.NitroBoostInfo1;
		bool flag = nitroBoostInfo != null && nitroBoostInfo.UpdateAutoState();
		if (flag)
		{
			if (this.PressingSprint)
			{
				MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo2 = this.NitroBoostInfo1;
				if (nitroBoostInfo2 == null || !nitroBoostInfo2.IsStartEnter())
				{
					this.ResetAssistInput("氮气维持被新输入打断", true, false);
					MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo3 = this.NitroBoostInfo1;
					if (nitroBoostInfo3 != null)
					{
						nitroBoostInfo3.SetIgnoreInput(true);
					}
					return false;
				}
			}
			if (!this.PressingSprint)
			{
				MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo4 = this.NitroBoostInfo1;
				if (nitroBoostInfo4 != null)
				{
					nitroBoostInfo4.SetStartEnter(false);
				}
			}
		}
		return flag;
	}

	// Token: 0x0601B23E RID: 111166 RVA: 0x008252BE File Offset: 0x008234BE
	private void HoldThrottleChange(int tagId, bool tagExist)
	{
	}

	// Token: 0x0601B23F RID: 111167 RVA: 0x008252C0 File Offset: 0x008234C0
	protected void NitroBoostChange(int tagId, bool tagExist)
	{
		this.RefreshSprint();
	}

	// Token: 0x0601B240 RID: 111168 RVA: 0x008252C8 File Offset: 0x008234C8
	private void OnCharUseSkill(int charId, int skillId, bool isAutonomousProxy)
	{
		MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo = this.NitroBoostInfo1;
		if (nitroBoostInfo == null || !nitroBoostInfo.CheckPermitSkill(skillId))
		{
			this.ResetAssistInput("氮气维持，使用了技能" + skillId.ToString(), true, false);
		}
		MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo = this.HoldThrottleInfo1;
		if (holdThrottleInfo == null || !holdThrottleInfo.CheckPermitSkill(skillId))
		{
			this.ResetAssistInput("油门维持，使用了技能" + skillId.ToString(), false, true);
		}
	}

	// Token: 0x0601B241 RID: 111169 RVA: 0x00825337 File Offset: 0x00823537
	private void OnRoleDead()
	{
		this.ResetAssistInput("角色死亡", true, true);
	}

	// Token: 0x0601B242 RID: 111170 RVA: 0x00825348 File Offset: 0x00823548
	private void OnForceReleaseInput(string reason)
	{
		if (this.PressingSprint)
		{
			AkiClient.Game.Aki.Character.Input.Enum.EInputAction einputAction;
			string text = this.CommandActionMap.TryGetValue(ECommandType.Sprint, out einputAction) ? einputAction.ToString() : null;
			if (text != null)
			{
				ControllerBase<InputDistributeController>.Instance.InputAction(text, false);
			}
		}
		if (this.PressingBackBraking)
		{
			AkiClient.Game.Aki.Character.Input.Enum.EInputAction einputAction2;
			string text2 = this.CommandActionMap.TryGetValue(ECommandType.Jump, out einputAction2) ? einputAction2.ToString() : null;
			if (text2 != null)
			{
				ControllerBase<InputDistributeController>.Instance.InputAction(text2, false);
			}
		}
	}

	// Token: 0x0601B243 RID: 111171 RVA: 0x008253C8 File Offset: 0x008235C8
	private void OnViewShow(EUiViewName viewName, int _)
	{
		UiShow? uiShowConfig = ConfigBase<UiViewConfig>.Instance.GetUiShowConfig(viewName);
		if (uiShowConfig != null && !uiShowConfig.Value.AllowAutoMotor)
		{
			this.ResetAssistInput("打开了UI" + viewName, true, true);
		}
	}

	// Token: 0x0601B244 RID: 111172 RVA: 0x00825413 File Offset: 0x00823613
	[NullableContext(2)]
	public MotorcycleInputComponent.NitroBoostInfo GetNitroBoostInfo()
	{
		return this.NitroBoostInfo1;
	}

	// Token: 0x0601B245 RID: 111173 RVA: 0x0082541B File Offset: 0x0082361B
	[NullableContext(2)]
	public MotorcycleInputComponent.HoldThrottleInfo GetHoldThrottleInfo()
	{
		return this.HoldThrottleInfo1;
	}

	// Token: 0x0601B246 RID: 111174 RVA: 0x00825423 File Offset: 0x00823623
	[NullableContext(2)]
	public void ExternalResetAssistInput(string context = null, bool nitro = true, bool throttle = true)
	{
		this.ResetAssistInput(context, nitro, throttle);
	}

	// Token: 0x0601B247 RID: 111175 RVA: 0x00825430 File Offset: 0x00823630
	public static void ConvertCycleInputToSquared(global::Vector inInput, global::Vector outInput)
	{
		double num = inInput.Size();
		if (num <= 0.0001)
		{
			outInput.DeepCopy(inInput);
			return;
		}
		inInput.Multiply(num / Math.Max(Math.Abs(inInput.X), Math.Abs(inInput.Y)), outInput);
	}

	// Token: 0x0601B248 RID: 111176 RVA: 0x00825480 File Offset: 0x00823680
	public static bool ConvertPolarInput(global::Vector inInput, global::Vector outInput, double positiveLimit, double negativeLimit, bool prevIsPositive)
	{
		if (inInput.IsNearlyZero(9.999999747378752E-05))
		{
			outInput.Reset();
			return true;
		}
		double value = Rotator.NormalizeAxis(Math.Atan2(inInput.Y, inInput.X) * 57.295780181884766);
		double num = Math.Abs(value);
		double num2 = (double)Math.Sign(value);
		if (num < positiveLimit)
		{
			outInput.X = inInput.Size();
			outInput.Y = num2 * (num / positiveLimit);
			return true;
		}
		if (num < negativeLimit)
		{
			outInput.X = inInput.Size() * (double)(prevIsPositive ? 1 : -1);
			outInput.Y = num2;
			return prevIsPositive;
		}
		outInput.X = -inInput.Size();
		outInput.Y = num2 * ((180.0 - num) / (180.0 - negativeLimit));
		return false;
	}

	// Token: 0x0601B249 RID: 111177 RVA: 0x00825544 File Offset: 0x00823744
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		MotorcycleInputComponent motorcycleInputComponent = (MotorcycleInputComponent)componentTemplate;
		if (base.CanResetComponentProperty("IsDriving"))
		{
			this.IsDriving = motorcycleInputComponent.IsDriving;
		}
		if (base.CanResetComponentProperty("PlayerMotorInput") && motorcycleInputComponent.PlayerMotorInput != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.PlayerMotorInput), "PlayerMotorInput"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("NitroBoostInfo1"))
		{
			if (motorcycleInputComponent.NitroBoostInfo1 == null)
			{
				this.NitroBoostInfo1 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MotorcycleInputComponent.NitroBoostInfo>(this.NitroBoostInfo1), "NitroBoostInfo1"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HoldThrottleInfo1"))
		{
			if (motorcycleInputComponent.HoldThrottleInfo1 == null)
			{
				this.HoldThrottleInfo1 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MotorcycleInputComponent.HoldThrottleInfo>(this.HoldThrottleInfo1), "HoldThrottleInfo1"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (motorcycleInputComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MotorcycleMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AudioComp"))
		{
			if (motorcycleInputComponent.AudioComp == null)
			{
				this.AudioComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MotorcycleAudioComponent>(this.AudioComp), "AudioComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LastInputSeconds"))
		{
			this.LastInputSeconds = motorcycleInputComponent.LastInputSeconds;
		}
		if (base.CanResetComponentProperty("TmpVector1"))
		{
			if (motorcycleInputComponent.TmpVector1 == null)
			{
				this.TmpVector1 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector1), "TmpVector1"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MotorInputCache"))
		{
			if (motorcycleInputComponent.MotorInputCache == null)
			{
				this.MotorInputCache = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.MotorInputCache), "MotorInputCache"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PressingBackBraking"))
		{
			this.PressingBackBraking = motorcycleInputComponent.PressingBackBraking;
		}
		if (base.CanResetComponentProperty("PressingSprint"))
		{
			this.PressingSprint = motorcycleInputComponent.PressingSprint;
		}
		if (base.CanResetComponentProperty("InSprintInternal"))
		{
			this.InSprintInternal = motorcycleInputComponent.InSprintInternal;
		}
		if (base.CanResetComponentProperty("BannedSprint"))
		{
			this.BannedSprint = motorcycleInputComponent.BannedSprint;
		}
		if (base.CanResetComponentProperty("InBackBrakingInternal"))
		{
			this.InBackBrakingInternal = motorcycleInputComponent.InBackBrakingInternal;
		}
		if (base.CanResetComponentProperty("BannedBackBraking"))
		{
			this.BannedBackBraking = motorcycleInputComponent.BannedBackBraking;
		}
		if (base.CanResetComponentProperty("MotorJoyStickAngle1"))
		{
			this.MotorJoyStickAngle1 = motorcycleInputComponent.MotorJoyStickAngle1;
		}
		if (base.CanResetComponentProperty("MotorJoyStickAngle2"))
		{
			this.MotorJoyStickAngle2 = motorcycleInputComponent.MotorJoyStickAngle2;
		}
		if (base.CanResetComponentProperty("PrevIsPositive"))
		{
			this.PrevIsPositive = motorcycleInputComponent.PrevIsPositive;
		}
		if (base.CanResetComponentProperty("AirRotateInput"))
		{
			this.AirRotateInput = motorcycleInputComponent.AirRotateInput;
		}
		if (base.CanResetComponentProperty("CommandIndexMap") && motorcycleInputComponent.CommandIndexMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<ECommandType, int>>(this.CommandIndexMap), "CommandIndexMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CommandPriorityMap") && motorcycleInputComponent.CommandPriorityMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<ECommandType, int>>(this.CommandPriorityMap), "CommandPriorityMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CommandActionMap") && motorcycleInputComponent.CommandActionMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<ECommandType, AkiClient.Game.Aki.Character.Input.Enum.EInputAction>>(this.CommandActionMap), "CommandActionMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("DebugAssistDrift"))
		{
			this.DebugAssistDrift = motorcycleInputComponent.DebugAssistDrift;
		}
		return true;
	}

	// Token: 0x0400DCD5 RID: 56533
	private const string ASSIST_INPUT_DATA_ASSET_PATH = "/Game/Aki/Character/Vehicle/Motor/Data/DA/DA_MotorAssistInputConfig.DA_MotorAssistInputConfig";

	// Token: 0x0400DCD6 RID: 56534
	private bool IsDriving;

	// Token: 0x0400DCD7 RID: 56535
	private readonly global::Vector PlayerMotorInput = global::Vector.Create();

	// Token: 0x0400DCD8 RID: 56536
	[Nullable(2)]
	private MotorcycleInputComponent.NitroBoostInfo NitroBoostInfo1;

	// Token: 0x0400DCD9 RID: 56537
	[Nullable(2)]
	private MotorcycleInputComponent.HoldThrottleInfo HoldThrottleInfo1;

	// Token: 0x0400DCDA RID: 56538
	[Nullable(2)]
	protected MotorcycleMoveComponent MoveComp;

	// Token: 0x0400DCDB RID: 56539
	[Nullable(2)]
	protected MotorcycleAudioComponent AudioComp;

	// Token: 0x0400DCDC RID: 56540
	public double LastInputSeconds;

	// Token: 0x0400DCDD RID: 56541
	protected global::Vector TmpVector1 = global::Vector.Create();

	// Token: 0x0400DCDE RID: 56542
	protected global::Vector MotorInputCache = global::Vector.Create();

	// Token: 0x0400DCDF RID: 56543
	protected bool PressingBackBraking;

	// Token: 0x0400DCE0 RID: 56544
	protected bool PressingSprint;

	// Token: 0x0400DCE1 RID: 56545
	protected bool InSprintInternal;

	// Token: 0x0400DCE2 RID: 56546
	private bool BannedSprint;

	// Token: 0x0400DCE3 RID: 56547
	protected bool InBackBrakingInternal;

	// Token: 0x0400DCE4 RID: 56548
	private bool BannedBackBraking;

	// Token: 0x0400DCE5 RID: 56549
	private double MotorJoyStickAngle1 = 60.0;

	// Token: 0x0400DCE6 RID: 56550
	private double MotorJoyStickAngle2 = 120.0;

	// Token: 0x0400DCE7 RID: 56551
	private bool PrevIsPositive = true;

	// Token: 0x0400DCE8 RID: 56552
	public double AirRotateInput;

	// Token: 0x0400DCE9 RID: 56553
	private readonly Dictionary<ECommandType, int> CommandIndexMap = new Dictionary<ECommandType, int>();

	// Token: 0x0400DCEA RID: 56554
	private readonly Dictionary<ECommandType, int> CommandPriorityMap = new Dictionary<ECommandType, int>();

	// Token: 0x0400DCEB RID: 56555
	private readonly Dictionary<ECommandType, AkiClient.Game.Aki.Character.Input.Enum.EInputAction> CommandActionMap = new Dictionary<ECommandType, AkiClient.Game.Aki.Character.Input.Enum.EInputAction>();

	// Token: 0x0400DCEC RID: 56556
	private bool DebugAssistDrift;

	// Token: 0x02009462 RID: 37986
	[Nullable(0)]
	public class AssistedInputInfo
	{
		// Token: 0x0604A353 RID: 303955 RVA: 0x0141A91C File Offset: 0x01418B1C
		public AssistedInputInfo(BaseTagComponent tagComp, int gameplayTag)
		{
			this.GameplayTag = gameplayTag;
			this.TagComp = tagComp;
		}

		// Token: 0x0604A354 RID: 303956 RVA: 0x0141A96D File Offset: 0x01418B6D
		public virtual void InitConfig(BP_MotorAssistInputConfig_C asset)
		{
		}

		// Token: 0x0604A355 RID: 303957 RVA: 0x0141A96F File Offset: 0x01418B6F
		public virtual bool UpdateAutoState()
		{
			return false;
		}

		// Token: 0x0604A356 RID: 303958 RVA: 0x0141A972 File Offset: 0x01418B72
		public void SetAutoState(bool value)
		{
			if (value == this.LastState)
			{
				return;
			}
			this.LastState = value;
			this.UpdateAutoTag(value);
		}

		// Token: 0x0604A357 RID: 303959 RVA: 0x0141A98C File Offset: 0x01418B8C
		public void AddTimeAccumulation(double delta)
		{
			if (!this.CheckForbiddenTag())
			{
				this.ClearTimeAccumulation();
				return;
			}
			this.CurrentTime += delta;
		}

		// Token: 0x0604A358 RID: 303960 RVA: 0x0141A9AB File Offset: 0x01418BAB
		public void ClearTimeAccumulation()
		{
			this.CurrentTime = 0.0;
		}

		// Token: 0x0604A359 RID: 303961 RVA: 0x0141A9BC File Offset: 0x01418BBC
		[NullableContext(2)]
		public void ResetAutoState(string context = null)
		{
			this.ClearTimeAccumulation();
			this.SetAutoState(false);
		}

		// Token: 0x0604A35A RID: 303962 RVA: 0x0141A9CD File Offset: 0x01418BCD
		public bool CheckTimeDuration()
		{
			return this.CurrentTime > this.Duration;
		}

		// Token: 0x0604A35B RID: 303963 RVA: 0x0141A9DD File Offset: 0x01418BDD
		public double GetCurrentTime()
		{
			return this.CurrentTime;
		}

		// Token: 0x0604A35C RID: 303964 RVA: 0x0141A9E5 File Offset: 0x01418BE5
		public double GetDuration()
		{
			return this.Duration;
		}

		// Token: 0x0604A35D RID: 303965 RVA: 0x0141A9F0 File Offset: 0x01418BF0
		private bool CheckForbiddenTag()
		{
			if (this.TagList != null && this.TagList.Count > 0)
			{
				foreach (int tagId in this.TagList)
				{
					BaseTagComponent tagComp = this.TagComp;
					if (tagComp != null && tagComp.HasTag(tagId))
					{
						return false;
					}
				}
				return true;
			}
			return true;
		}

		// Token: 0x0604A35E RID: 303966 RVA: 0x0141AA70 File Offset: 0x01418C70
		public bool CheckPermitSkill(int skillId)
		{
			return this.SkillList.Contains((long)skillId);
		}

		// Token: 0x0604A35F RID: 303967 RVA: 0x0141AA7F File Offset: 0x01418C7F
		public bool IsStartEnter()
		{
			return this.StartEnter;
		}

		// Token: 0x0604A360 RID: 303968 RVA: 0x0141AA87 File Offset: 0x01418C87
		public void SetStartEnter(bool value)
		{
			this.StartEnter = value;
		}

		// Token: 0x0604A361 RID: 303969 RVA: 0x0141AA90 File Offset: 0x01418C90
		public bool IsIgnoreInput()
		{
			return this.IgnoreInput;
		}

		// Token: 0x0604A362 RID: 303970 RVA: 0x0141AA98 File Offset: 0x01418C98
		public void SetIgnoreInput(bool value)
		{
			this.IgnoreInput = value;
		}

		// Token: 0x0604A363 RID: 303971 RVA: 0x0141AAA1 File Offset: 0x01418CA1
		protected bool CheckGameplayTag()
		{
			BaseTagComponent tagComp = this.TagComp;
			return tagComp != null && tagComp.HasTag(this.GameplayTag) && this.CheckForbiddenTag();
		}

		// Token: 0x0604A364 RID: 303972 RVA: 0x0141AAC8 File Offset: 0x01418CC8
		protected void UpdateAutoTag(bool value)
		{
			if (value)
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp == null || !tagComp.HasTag(this.GameplayTag))
				{
					BaseTagComponent tagComp2 = this.TagComp;
					if (tagComp2 != null)
					{
						tagComp2.AddTag(new int?(this.GameplayTag));
					}
				}
			}
			if (!value)
			{
				BaseTagComponent tagComp3 = this.TagComp;
				if (tagComp3 != null && tagComp3.HasTag(this.GameplayTag))
				{
					BaseTagComponent tagComp4 = this.TagComp;
					if (tagComp4 == null)
					{
						return;
					}
					tagComp4.RemoveTag(new int?(this.GameplayTag));
				}
			}
		}

		// Token: 0x040313D2 RID: 201682
		protected bool LastState;

		// Token: 0x040313D3 RID: 201683
		protected double CurrentTime;

		// Token: 0x040313D4 RID: 201684
		private bool StartEnter;

		// Token: 0x040313D5 RID: 201685
		private bool IgnoreInput;

		// Token: 0x040313D6 RID: 201686
		protected double Duration = 3.402823466E+38;

		// Token: 0x040313D7 RID: 201687
		protected readonly List<int> TagList = new List<int>();

		// Token: 0x040313D8 RID: 201688
		protected readonly List<long> SkillList = new List<long>();

		// Token: 0x040313D9 RID: 201689
		protected string DebugText = "";

		// Token: 0x040313DA RID: 201690
		[Nullable(2)]
		protected BaseTagComponent TagComp;

		// Token: 0x040313DB RID: 201691
		protected int GameplayTag;
	}

	// Token: 0x02009463 RID: 37987
	[Nullable(0)]
	public class NitroBoostInfo : MotorcycleInputComponent.AssistedInputInfo
	{
		// Token: 0x0604A365 RID: 303973 RVA: 0x0141AB4A File Offset: 0x01418D4A
		public NitroBoostInfo(BaseTagComponent tagComp, int gameplayTag) : base(tagComp, gameplayTag)
		{
			this.DebugText = "氮气维持";
		}

		// Token: 0x0604A366 RID: 303974 RVA: 0x0141AB60 File Offset: 0x01418D60
		public override bool UpdateAutoState()
		{
			bool flag = this.GetSettingEnable() && base.CheckGameplayTag();
			if (this.LastState && !flag)
			{
				base.ResetAutoState("不满足默认条件");
			}
			return flag;
		}

		// Token: 0x0604A367 RID: 303975 RVA: 0x0141AB96 File Offset: 0x01418D96
		public bool GetSettingEnable()
		{
			return ModelBase<BattleUiModel>.Instance.MotorcycleData.AutoNitrogenSettingEnable || this.DebugEnable;
		}

		// Token: 0x0604A368 RID: 303976 RVA: 0x0141ABB4 File Offset: 0x01418DB4
		public override void InitConfig(BP_MotorAssistInputConfig_C asset)
		{
			this.Duration = (double)asset.NitroBoostTime;
			this.DebugEnable = asset.DebugNitroBoost;
			for (int i = 0; i < asset.ForbidNitroBoostTag.GameplayTags.Num(); i++)
			{
				this.TagList.Add(asset.ForbidNitroBoostTag.GameplayTags.Get(i).TagId());
			}
			for (int j = 0; j < asset.NitroBoostSkill.Num(); j++)
			{
				this.SkillList.Add((long)asset.NitroBoostSkill.Get(j));
			}
		}

		// Token: 0x040313DC RID: 201692
		private bool DebugEnable;
	}

	// Token: 0x02009464 RID: 37988
	[Nullable(0)]
	public class HoldThrottleInfo : MotorcycleInputComponent.AssistedInputInfo
	{
		// Token: 0x0604A369 RID: 303977 RVA: 0x0141AC44 File Offset: 0x01418E44
		public HoldThrottleInfo(BaseTagComponent tagComp, int gameplayTag) : base(tagComp, gameplayTag)
		{
			this.DebugText = "油门维持";
		}

		// Token: 0x0604A36A RID: 303978 RVA: 0x0141AC5C File Offset: 0x01418E5C
		public override bool UpdateAutoState()
		{
			bool flag = this.GetSettingEnable() && base.CheckGameplayTag();
			if (this.LastState && !flag)
			{
				base.ResetAutoState("不满足默认条件");
			}
			return flag;
		}

		// Token: 0x0604A36B RID: 303979 RVA: 0x0141AC92 File Offset: 0x01418E92
		public bool GetSettingEnable()
		{
			return ModelBase<BattleUiModel>.Instance.MotorcycleData.AutoAcceleratorSettingEnable || this.DebugEnable;
		}

		// Token: 0x0604A36C RID: 303980 RVA: 0x0141ACB0 File Offset: 0x01418EB0
		public override void InitConfig(BP_MotorAssistInputConfig_C asset)
		{
			this.Duration = (double)asset.HoldThrottleTime;
			this.DebugEnable = asset.DebugHoldThrottle;
			for (int i = 0; i < asset.ForbidHoldThrottleTag.GameplayTags.Num(); i++)
			{
				this.TagList.Add(asset.ForbidHoldThrottleTag.GameplayTags.Get(i).TagId());
			}
			for (int j = 0; j < asset.HoldThrottleSkill.Num(); j++)
			{
				this.SkillList.Add((long)asset.HoldThrottleSkill.Get(j));
			}
		}

		// Token: 0x040313DD RID: 201693
		private bool DebugEnable;
	}
}
