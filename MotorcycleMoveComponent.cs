using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Level.Vehicle;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x0200329C RID: 12956
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleMoveComponent : VehicleMoveComponent
{
	// Token: 0x170024E9 RID: 9449
	// (get) Token: 0x0601B24F RID: 111183 RVA: 0x008259F9 File Offset: 0x00823BF9
	// (set) Token: 0x0601B250 RID: 111184 RVA: 0x00825A04 File Offset: 0x00823C04
	private EMotorDriftModel DriftModel
	{
		get
		{
			return this.DriftModelInternal;
		}
		set
		{
			if (this.DriftModelInternal == value)
			{
				return;
			}
			if (MotorcycleMoveComponent.driftModelTagMap.ContainsKey(this.DriftModelInternal))
			{
				BaseTagComponent tagComponent = this.TagComponent;
				if (tagComponent != null)
				{
					tagComponent.RemoveTag(new int?(MotorcycleMoveComponent.driftModelTagMap[this.DriftModelInternal]));
				}
			}
			this.DriftModelInternal = value;
			if (MotorcycleMoveComponent.driftModelTagMap.ContainsKey(value))
			{
				BaseTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 == null)
				{
					return;
				}
				tagComponent2.AddTag(new int?(MotorcycleMoveComponent.driftModelTagMap[value]));
			}
		}
	}

	// Token: 0x170024EA RID: 9450
	// (get) Token: 0x0601B251 RID: 111185 RVA: 0x00825A88 File Offset: 0x00823C88
	// (set) Token: 0x0601B252 RID: 111186 RVA: 0x00825A90 File Offset: 0x00823C90
	public bool BackBraking
	{
		get
		{
			return this.BackBrakingInternal;
		}
		set
		{
			this.BackBrakingInternal = value;
		}
	}

	// Token: 0x170024EB RID: 9451
	// (get) Token: 0x0601B253 RID: 111187 RVA: 0x00825A99 File Offset: 0x00823C99
	// (set) Token: 0x0601B254 RID: 111188 RVA: 0x00825AA4 File Offset: 0x00823CA4
	public bool DriftingState
	{
		get
		{
			return this.DriftingStateInternal;
		}
		set
		{
			if (this.DriftingStateInternal == value)
			{
				return;
			}
			this.DriftingStateInternal = value;
			if (value)
			{
				this.DriftStartTime = Singleton<Time>.Instance.NowSeconds;
				this.DriftDistance = 0.0;
				this.DriftLastLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
				BaseTagComponent tagComponent = this.TagComponent;
				if (tagComponent != null)
				{
					tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.漂移"]));
				}
				if (this.DriftBuffId > 0L)
				{
					VehicleBuffComponent buffComp = this.BuffComp;
					if (buffComp == null)
					{
						return;
					}
					buffComp.AddBuff(this.DriftBuffId, new AddBuffParam
					{
						InstigatorId = this.BuffComp.CreatureDataId,
						Reason = "漂移buff"
					});
					return;
				}
			}
			else
			{
				MotorDriftLogEvent motorDriftLogEvent = new MotorDriftLogEvent();
				motorDriftLogEvent.i_drift_distance = (float)((int)Math.Round(this.DriftDistance / 100.0));
				motorDriftLogEvent.i_drift_time = (float)((int)Math.Round(Singleton<Time>.Instance.NowSeconds - this.DriftStartTime));
				ControllerBase<LogReportController>.Instance.LogReport(motorDriftLogEvent);
				BaseTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 != null)
				{
					tagComponent2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.漂移"]));
				}
				if (this.DriftBuffId > 0L)
				{
					VehicleBuffComponent buffComp2 = this.BuffComp;
					if (buffComp2 == null)
					{
						return;
					}
					buffComp2.RemoveBuff(this.DriftBuffId, -1, "漂移buff", null, null, null);
				}
			}
		}
	}

	// Token: 0x170024EC RID: 9452
	// (get) Token: 0x0601B255 RID: 111189 RVA: 0x00825C1A File Offset: 0x00823E1A
	// (set) Token: 0x0601B256 RID: 111190 RVA: 0x00825C24 File Offset: 0x00823E24
	public bool FrontBrakingState
	{
		get
		{
			return this.FrontBrakingStateInternal;
		}
		set
		{
			if (this.FrontBrakingStateInternal == value)
			{
				return;
			}
			this.FrontBrakingStateInternal = value;
			if (value)
			{
				BaseTagComponent tagComponent = this.TagComponent;
				if (tagComponent == null)
				{
					return;
				}
				tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.刹车.前轮刹"]));
				return;
			}
			else
			{
				BaseTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 == null)
				{
					return;
				}
				tagComponent2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.刹车.前轮刹"]));
				return;
			}
		}
	}

	// Token: 0x170024ED RID: 9453
	// (get) Token: 0x0601B257 RID: 111191 RVA: 0x00825C8F File Offset: 0x00823E8F
	// (set) Token: 0x0601B258 RID: 111192 RVA: 0x00825C98 File Offset: 0x00823E98
	public bool BackBrakingState
	{
		get
		{
			return this.BackBrakingStateInternal;
		}
		set
		{
			if (this.BackBrakingStateInternal == value)
			{
				return;
			}
			this.BackBrakingStateInternal = value;
			if (value)
			{
				BaseTagComponent tagComponent = this.TagComponent;
				if (tagComponent == null)
				{
					return;
				}
				tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.刹车.后轮刹"]));
				return;
			}
			else
			{
				BaseTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 == null)
				{
					return;
				}
				tagComponent2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.刹车.后轮刹"]));
				return;
			}
		}
	}

	// Token: 0x170024EE RID: 9454
	// (get) Token: 0x0601B259 RID: 111193 RVA: 0x00825D03 File Offset: 0x00823F03
	// (set) Token: 0x0601B25A RID: 111194 RVA: 0x00825D0C File Offset: 0x00823F0C
	protected bool SideSlide
	{
		get
		{
			return this.SideSlideInternal;
		}
		set
		{
			if (this.SideSlideInternal == value)
			{
				return;
			}
			this.SideSlideInternal = value;
			if (value)
			{
				BaseTagComponent tagComponent = this.TagComponent;
				if (tagComponent == null)
				{
					return;
				}
				tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.车身侧滑"]));
				return;
			}
			else
			{
				BaseTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 == null)
				{
					return;
				}
				tagComponent2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.车身侧滑"]));
				return;
			}
		}
	}

	// Token: 0x170024EF RID: 9455
	// (get) Token: 0x0601B25B RID: 111195 RVA: 0x00825D77 File Offset: 0x00823F77
	// (set) Token: 0x0601B25C RID: 111196 RVA: 0x00825D80 File Offset: 0x00823F80
	public EMotorSubState MotorSubState
	{
		get
		{
			return this.MotorSubStateInternal;
		}
		protected set
		{
			if (this.MotorSubStateInternal == value)
			{
				return;
			}
			if (this.TagComponent != null)
			{
				int num = MotorcycleMoveComponent.motorSubStateTagMap.ContainsKey(this.MotorSubStateInternal) ? MotorcycleMoveComponent.motorSubStateTagMap[this.MotorSubStateInternal] : 0;
				int num2 = MotorcycleMoveComponent.motorSubStateTagMap.ContainsKey(value) ? MotorcycleMoveComponent.motorSubStateTagMap[value] : GameplayTagDefine.EGameplayTagId["载具.摩托.状态.其他移动状态"];
				if (num != num2)
				{
					this.TagComponent.RemoveTag(new int?(num));
					this.TagComponent.AddTag(new int?(num2));
				}
			}
			Singleton<EventSystem>.Instance.EmitWithTarget<EMotorSubState, EMotorSubState>(base.Entity, EEventName.MotorSubStateModeChange, value, this.MotorSubStateInternal);
			this.MotorSubStateInternal = value;
			this.CheckAllowSoar();
		}
	}

	// Token: 0x170024F0 RID: 9456
	// (get) Token: 0x0601B25D RID: 111197 RVA: 0x00825E40 File Offset: 0x00824040
	// (set) Token: 0x0601B25E RID: 111198 RVA: 0x00825E48 File Offset: 0x00824048
	public bool AllowSoar
	{
		get
		{
			return this.AllowSoarInternal;
		}
		protected set
		{
			if (this.AllowSoarInternal == value)
			{
				return;
			}
			this.AllowSoarInternal = value;
			if (value)
			{
				BaseTagComponent tagComponent = this.TagComponent;
				if (tagComponent == null)
				{
					return;
				}
				tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.滑翔高度足够"]));
				return;
			}
			else
			{
				BaseTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 == null)
				{
					return;
				}
				tagComponent2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.滑翔高度足够"]));
				return;
			}
		}
	}

	// Token: 0x170024F1 RID: 9457
	// (get) Token: 0x0601B25F RID: 111199 RVA: 0x00825EB3 File Offset: 0x008240B3
	// (set) Token: 0x0601B260 RID: 111200 RVA: 0x00825EBC File Offset: 0x008240BC
	private bool BackingMotor
	{
		get
		{
			return this.BackingMotorInternal;
		}
		set
		{
			if (this.BackingMotorInternal == value)
			{
				return;
			}
			this.BackingMotorInternal = value;
			if (this.BackMotorBuff > 0L)
			{
				if (this.BackingMotorInternal)
				{
					VehicleBuffComponent buffComp = this.BuffComp;
					if (buffComp == null)
					{
						return;
					}
					buffComp.AddBuff(this.BackMotorBuff, new AddBuffParam
					{
						InstigatorId = this.BuffComp.CreatureDataId,
						Reason = "倒车buff"
					});
					return;
				}
				else
				{
					VehicleBuffComponent buffComp2 = this.BuffComp;
					if (buffComp2 == null)
					{
						return;
					}
					buffComp2.RemoveBuff(this.BackMotorBuff, -1, "倒车buff", null, null, null);
				}
			}
		}
	}

	// Token: 0x170024F2 RID: 9458
	// (get) Token: 0x0601B261 RID: 111201 RVA: 0x00825F5B File Offset: 0x0082415B
	// (set) Token: 0x0601B262 RID: 111202 RVA: 0x00825F64 File Offset: 0x00824164
	protected long CurrentMoveBuff
	{
		get
		{
			return this.CurrentMoveBuffInternal;
		}
		set
		{
			if (this.CurrentMoveBuffInternal == value)
			{
				return;
			}
			if (this.CurrentMoveBuffInternal > 0L)
			{
				VehicleBuffComponent buffComp = this.BuffComp;
				if (buffComp != null)
				{
					buffComp.RemoveBuff(this.CurrentMoveBuffInternal, -1, "摩托移动buff", null, null, null);
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.LCZ;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
				defaultInterpolatedStringHandler.AppendLiteral("MotorMoveBuff RemoveBuff ");
				defaultInterpolatedStringHandler.AppendFormatted<long>(this.CurrentMoveBuffInternal);
				instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.CurrentMoveBuffInternal = value;
			if (this.CurrentMoveBuffInternal > 0L)
			{
				VehicleBuffComponent buffComp2 = this.BuffComp;
				if (buffComp2 != null)
				{
					buffComp2.AddBuff(this.CurrentMoveBuffInternal, new AddBuffParam
					{
						InstigatorId = this.BuffComp.CreatureDataId,
						Reason = "摩托移动buff"
					});
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Test;
				ELogAuthor author2 = ELogAuthor.LCZ;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
				defaultInterpolatedStringHandler.AppendLiteral("MotorMoveBuff AddBuff ");
				defaultInterpolatedStringHandler.AppendFormatted<long>(this.CurrentMoveBuffInternal);
				instance2.Warn(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}
	}

	// Token: 0x0601B263 RID: 111203 RVA: 0x00826086 File Offset: 0x00824286
	public void SetIsFunctionOpenOverride(bool? @override)
	{
		this.IsFunctionOpenOverride = @override;
	}

	// Token: 0x0601B264 RID: 111204 RVA: 0x0082608F File Offset: 0x0082428F
	private bool IsSoarFunctionOpen()
	{
		if (this.IsFunctionOpenOverride != null)
		{
			return this.IsFunctionOpenOverride.Value;
		}
		return ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.MotorSoar) && !ModelBase<FunctionModel>.Instance.IsLimit(10154);
	}

	// Token: 0x0601B265 RID: 111205 RVA: 0x008260D0 File Offset: 0x008242D0
	public void OnSkill(int skillId, bool _)
	{
		VehicleActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.IsAutonomousProxy)
		{
			return;
		}
		MotorSkillLogEvent motorSkillLogEvent = new MotorSkillLogEvent();
		motorSkillLogEvent.i_skill_id = skillId.ToString();
		ControllerBase<LogReportController>.Instance.LogReport(motorSkillLogEvent);
	}

	// Token: 0x0601B266 RID: 111206 RVA: 0x00826113 File Offset: 0x00824313
	protected override void OnLeaveVehicle(VehiclePassengerInfo info, bool byChangeRole)
	{
		if (!byChangeRole)
		{
			this.SetMotorSubState(EMotorSubState.TwoWheelMoving);
		}
		base.OnLeaveVehicle(info, byChangeRole);
	}

	// Token: 0x0601B267 RID: 111207 RVA: 0x00826128 File Offset: 0x00824328
	public void OnSprintTagChange(int tagId, bool tagExist)
	{
		if (!tagExist)
		{
			this.DisableSprintTagFrame = Singleton<Time>.Instance.Frame;
			return;
		}
		if (this.DisableSprintTagFrame + 1 >= Singleton<Time>.Instance.Frame)
		{
			return;
		}
		this.DisableSprintTagFrame = Singleton<Time>.Instance.Frame;
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
				CharacterActorComponent component = driver.GetComponent<CharacterActorComponent>();
				flag2 = ((component != null) ? new bool?(component.IsRoleAndCtrlByMe) : null);
			}
			bool? flag3 = flag2;
			flag = flag3.GetValueOrDefault();
		}
		if (flag)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null || !tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.第一人称"]))
			{
				ControllerBase<CameraController>.Instance.PlayCameraShake(this.SprintCameraShake, null, null, null, true, false, "MainCamera");
				return;
			}
			ControllerBase<CameraController>.Instance.PlayForceFeedbackFromCameraShake(new TSubclassOf<UCameraShakeBase>?(this.SprintCameraShake), "MainCamera");
		}
	}

	// Token: 0x0601B268 RID: 111208 RVA: 0x00826230 File Offset: 0x00824430
	[NullableContext(2)]
	private void OnVehicleDriverChange(Entity oldDriver, Entity newDriver)
	{
		if (newDriver != null)
		{
			CharacterActorComponent component = newDriver.GetComponent<CharacterActorComponent>();
			if (((component != null) ? new bool?(component.IsRoleAndCtrlByMe) : null).GetValueOrDefault())
			{
				this.DriftModel = (EMotorDriftModel)Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.MotorDriftModel, 0, true);
				if (!Singleton<EventSystem>.Instance.Has<EFunction>(EEventName.RefreshMenuSetting, new Action<EFunction>(this.OnRefreshMenuSetting)))
				{
					Singleton<EventSystem>.Instance.Add<EFunction>(EEventName.RefreshMenuSetting, new Action<EFunction>(this.OnRefreshMenuSetting));
					return;
				}
				return;
			}
		}
		if (Singleton<EventSystem>.Instance.Has<EFunction>(EEventName.RefreshMenuSetting, new Action<EFunction>(this.OnRefreshMenuSetting)))
		{
			Singleton<EventSystem>.Instance.Remove<EFunction>(EEventName.RefreshMenuSetting, new Action<EFunction>(this.OnRefreshMenuSetting));
		}
		this.DriftModel = EMotorDriftModel.None;
	}

	// Token: 0x0601B269 RID: 111209 RVA: 0x008262FA File Offset: 0x008244FA
	private void OnRefreshMenuSetting(EFunction functionId)
	{
		if (functionId == EFunction.MotorDriftModel)
		{
			this.DriftModel = (EMotorDriftModel)Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.MotorDriftModel, 0, true);
		}
	}

	// Token: 0x0601B26A RID: 111210 RVA: 0x0082631C File Offset: 0x0082451C
	protected override bool OnStart()
	{
		bool flag = base.OnStart();
		this.BuffComp = base.Entity.GetComponent<VehicleBuffComponent>();
		UKuroVehicleMovementComponent vehicleMovement = this.VehicleMovement;
		if (vehicleMovement != null)
		{
			vehicleMovement.ResetMotorcycle();
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Movement;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "Motorcycle Move OnStart";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Result", flag);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.MotorSubState = EMotorSubState.AirMoving;
		this.PerformComp = base.Entity.GetComponent<BaseVehiclePerformComponent>();
		BaseVehiclePerformComponent performComp = this.PerformComp;
		object obj;
		if (performComp == null)
		{
			obj = null;
		}
		else
		{
			VehicleConfig config = performComp.Config;
			obj = ((config != null) ? config.Asset : null);
		}
		BP_MotorConfig_C bp_MotorConfig_C = obj as BP_MotorConfig_C;
		if (bp_MotorConfig_C == null)
		{
			return flag;
		}
		long num = (long)bp_MotorConfig_C.非加速状态buff.Num();
		this.SpeedBuffNotSprint.Clear();
		int num2 = 0;
		while ((long)num2 < num)
		{
			SFloatThresholdAndBuff sfloatThresholdAndBuff = bp_MotorConfig_C.非加速状态buff.Get(num2);
			this.SpeedBuffNotSprint.Add(new ValueTuple<float, long>(sfloatThresholdAndBuff.Threshold, sfloatThresholdAndBuff.BuffId));
			num2++;
		}
		num = (long)bp_MotorConfig_C.加速状态buff.Num();
		this.SpeedBuffSprint.Clear();
		int num3 = 0;
		while ((long)num3 < num)
		{
			SFloatThresholdAndBuff sfloatThresholdAndBuff2 = bp_MotorConfig_C.加速状态buff.Get(num3);
			this.SpeedBuffSprint.Add(new ValueTuple<float, long>(sfloatThresholdAndBuff2.Threshold, sfloatThresholdAndBuff2.BuffId));
			num3++;
		}
		num = (long)bp_MotorConfig_C.翱翔加速状态buff.Num();
		this.SpeedBuffSoarSprint.Clear();
		int num4 = 0;
		while ((long)num4 < num)
		{
			SFloatThresholdAndBuff sfloatThresholdAndBuff3 = bp_MotorConfig_C.翱翔加速状态buff.Get(num4);
			this.SpeedBuffSoarSprint.Add(new ValueTuple<float, long>(sfloatThresholdAndBuff3.Threshold, sfloatThresholdAndBuff3.BuffId));
			num4++;
		}
		this.DriftBuffId = bp_MotorConfig_C.漂移buff;
		this.BackMotorBuff = bp_MotorConfig_C.倒车buff;
		this.SprintCameraShake = bp_MotorConfig_C.冲刺震屏.Get().ToWeakClass();
		this.InitSeatTrans();
		Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(base.Entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnSkill));
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, Entity>(base.Entity, EEventName.OnVehicleDriverChange, new Action<Entity, Entity>(this.OnVehicleDriverChange));
		if (this.SprintCameraShake != null)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null)
			{
				tagComponent.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冲刺"], new BaseTagComponent.TTagSwitchedCallback(this.OnSprintTagChange), null);
			}
			BaseTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 != null)
			{
				tagComponent2.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.翱翔冲刺"], new BaseTagComponent.TTagSwitchedCallback(this.OnSprintTagChange), null);
			}
		}
		return flag;
	}

	// Token: 0x0601B26B RID: 111211 RVA: 0x008265A4 File Offset: 0x008247A4
	protected override bool OnEnd()
	{
		bool result = base.OnEnd();
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(base.Entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnSkill));
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, Entity>(base.Entity, EEventName.OnVehicleDriverChange, new Action<Entity, Entity>(this.OnVehicleDriverChange));
		if (Singleton<EventSystem>.Instance.Has<EFunction>(EEventName.RefreshMenuSetting, new Action<EFunction>(this.OnRefreshMenuSetting)))
		{
			Singleton<EventSystem>.Instance.Remove<EFunction>(EEventName.RefreshMenuSetting, new Action<EFunction>(this.OnRefreshMenuSetting));
		}
		if (this.SprintCameraShake != null)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null)
			{
				tagComponent.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冲刺"], new BaseTagComponent.TTagSwitchedCallback(this.OnSprintTagChange));
			}
			BaseTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 != null)
			{
				tagComponent2.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.翱翔冲刺"], new BaseTagComponent.TTagSwitchedCallback(this.OnSprintTagChange));
			}
		}
		this.ClearAllCacheData();
		return result;
	}

	// Token: 0x0601B26C RID: 111212 RVA: 0x00826697 File Offset: 0x00824897
	protected override void OnDisable(string reason)
	{
		base.OnDisable(reason);
		this.ClearAllCacheData();
	}

	// Token: 0x0601B26D RID: 111213 RVA: 0x008266A8 File Offset: 0x008248A8
	private void ClearAllCacheData()
	{
		this.BackingMotor = false;
		this.DriftingState = false;
		this.CurrentMoveBuff = 0L;
		if (this.CurrentBaseMovement.Count > 0)
		{
			this.CurrentBaseMovement.Clear();
			Singleton<EventSystem>.Instance.EmitWithTarget<IReadOnlySet<UPrimitiveComponent>>(base.Entity, EEventName.MotorcycleBaseMovementChanged, this.CurrentBaseMovement);
		}
	}

	// Token: 0x0601B26E RID: 111214 RVA: 0x00826700 File Offset: 0x00824900
	protected override void SetInputOrder()
	{
		VehicleActorComponent actorComp = this.ActorComp;
		UKuroVehicleMovementComponent ukuroVehicleMovementComponent = (actorComp != null) ? actorComp.Actor.VehicleMovementComponent : null;
		if (ukuroVehicleMovementComponent == null)
		{
			return;
		}
		this.TmpInputDirect.DeepCopy(this.ActorComp.InputDirectProxy);
		double num = 0.0;
		double num2 = this.BackBraking > false;
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冲刺"]))
		{
			this.TmpInputDirect.X = 1.0;
		}
		if (this.MotorSubState == EMotorSubState.Soaring)
		{
			num = 0.0;
			num2 = 0.0;
		}
		else
		{
			if (this.TmpInputDirect.X < 0.0 && !this.BackingMotor)
			{
				num = -this.TmpInputDirect.X;
				this.TmpInputDirect.X = 0.0;
			}
			BaseTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 != null && tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.强制刹停"]))
			{
				this.TmpInputDirect.X = 0.0;
				num = 1.0;
				num2 = 1.0;
			}
		}
		if (num < 0.99 || num2 < 0.99)
		{
			BaseTagComponent tagComponent3 = this.TagComponent;
			if (tagComponent3 == null || !tagComponent3.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用转向"]))
			{
				goto IL_179;
			}
		}
		this.TmpInputDirect.Y = 0.0;
		IL_179:
		ukuroVehicleMovementComponent.SetMotorInput(this.TmpInputDirect.ToUeVectorOld(), (float)num, (float)num2, new FVector?((this.ActorComp as MotorcycleActorComponent).AirRotateInputProxy.ToUeVectorOld()));
	}

	// Token: 0x0601B26F RID: 111215 RVA: 0x008268B8 File Offset: 0x00824AB8
	protected override void OnTick(float delta)
	{
		VehicleActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.IsMoveAutonomousProxy)
		{
			return;
		}
		this.TmpInputDirect.DeepCopy(this.ActorComp.InputDirectProxy);
		if (this.TmpInputDirect.X >= 0.0)
		{
			this.BackInputTime = 0.0;
			this.BackingMotor = false;
		}
		else if (this.BackBraking)
		{
			this.BackInputTime = 0.0;
			this.BackingMotor = false;
		}
		else if (this.BackInputTime < 100.0)
		{
			double num = this.ActorComp.ActorVelocityProxy.DotProduct(this.ActorComp.ActorForwardProxy);
			if (Math.Abs(this.ActorComp.ActorVelocityProxy.DotProduct(this.ActorComp.ActorRightProxy)) > 500.0 || num > 200.0)
			{
				this.BackInputTime = 0.0;
			}
			else
			{
				this.BackInputTime += (double)((long)Singleton<Time>.Instance.DeltaTime);
			}
			this.BackingMotor = (this.BackInputTime >= 100.0);
		}
		else
		{
			this.BackingMotor = true;
		}
		base.OnTick(delta);
		this.UpdateMoveState();
		this.UpdateMoveBuff();
		this.UpdateBaseMovement();
		this.CheckAllowSoar();
	}

	// Token: 0x0601B270 RID: 111216 RVA: 0x00826A20 File Offset: 0x00824C20
	public override void MoveAlongPath(IMoveVehicleConfig config)
	{
		MotorcyclePathMoveTask mainTask = ControllerBase<VehiclePathMoveController>.Instance.CreateMotorcycleMoveTaskFromSplineId(base.Entity, config.SplineId);
		MotorcyclePathMoveTask mainTask2 = mainTask;
		if (mainTask2 == null || !mainTask2.IsValid())
		{
			return;
		}
		if (config.ForceToFirstPoint.GetValueOrDefault())
		{
			mainTask.NeedSync = config.NeedSync.GetValueOrDefault(true);
			mainTask.SimulateRotation = config.SimulateRotation.GetValueOrDefault(true);
			mainTask.KeepForward = config.KeepForward.GetValueOrDefault();
			mainTask.EnableDynamicGravity(config.DynamicGravity != null && config.DynamicGravity.Value);
			mainTask.OnMoveEndHandle = delegate(bool result)
			{
				if (config.OnMoveEndHandle != null)
				{
					config.OnMoveEndHandle(result);
				}
				this.DebugCurve = null;
			};
			ControllerBase<VehiclePathMoveController>.Instance.AddSplineMoveTask(mainTask);
			PathCurveInfo curveInfo = mainTask.CurveInfo;
			this.DebugCurve = ((curveInfo != null) ? curveInfo.SplineCurve : null);
			return;
		}
		int index = config.StartFromNearest.GetValueOrDefault() ? base.FindNearestNextPoint(mainTask.CurveInfo.SplineCurve) : 0;
		mainTask.JumpToPoint(index);
		mainTask.GetTransformAtSplineIndex(index, this.TmpTrans);
		IContinuesVariableSpeedMovementSpline splineConfig = mainTask.CurveInfo.SplineConfig;
		double speed = (double)((splineConfig != null && splineConfig.TransitionSpeed != null) ? ((float)mainTask.CurveInfo.SplineConfig.TransitionSpeed.Value) : (mainTask.CurveInfo.SplineCurve.GetSplineLength() / mainTask.CurveInfo.TotalTime));
		VehiclePathMoveTask vehiclePathMoveTask = ControllerBase<VehiclePathMoveController>.Instance.CreateMotorcycleMoveToTask(base.Entity, this.TmpTrans, speed);
		if (vehiclePathMoveTask == null || !vehiclePathMoveTask.IsValid())
		{
			ControllerBase<VehiclePathMoveController>.Instance.AddSplineMoveTask(mainTask);
			PathCurveInfo curveInfo2 = mainTask.CurveInfo;
			this.DebugCurve = ((curveInfo2 != null) ? curveInfo2.SplineCurve : null);
			return;
		}
		vehiclePathMoveTask.CurveInfo.SplineId = -config.SplineId;
		vehiclePathMoveTask.NeedSync = config.NeedSync.GetValueOrDefault(true);
		vehiclePathMoveTask.SimulateRotation = false;
		vehiclePathMoveTask.KeepForward = config.KeepForward.GetValueOrDefault();
		vehiclePathMoveTask.OnMoveEndHandle = delegate(bool result)
		{
			if (!result)
			{
				if (config.OnMoveEndHandle != null)
				{
					config.OnMoveEndHandle(false);
				}
				return;
			}
			ControllerBase<VehiclePathMoveController>.Instance.AddSplineMoveTask(mainTask);
			VehicleMoveComponent <>4__this = this;
			PathCurveInfo curveInfo4 = mainTask.CurveInfo;
			<>4__this.DebugCurve = ((curveInfo4 != null) ? curveInfo4.SplineCurve : null);
			if (config.OnArriveStartPointHandle != null)
			{
				config.OnArriveStartPointHandle(result);
			}
		};
		mainTask.NeedSync = config.NeedSync.GetValueOrDefault(true);
		mainTask.SimulateRotation = config.SimulateRotation.GetValueOrDefault(true);
		mainTask.KeepForward = config.KeepForward.GetValueOrDefault();
		mainTask.EnableDynamicGravity(config.DynamicGravity != null && config.DynamicGravity.Value);
		mainTask.OnMoveEndHandle = delegate(bool result)
		{
			if (config.OnMoveEndHandle != null)
			{
				config.OnMoveEndHandle(result);
			}
			this.DebugCurve = null;
		};
		ControllerBase<VehiclePathMoveController>.Instance.AddSplineMoveTask(vehiclePathMoveTask);
		PathCurveInfo curveInfo3 = vehiclePathMoveTask.CurveInfo;
		this.DebugCurve = ((curveInfo3 != null) ? curveInfo3.SplineCurve : null);
	}

	// Token: 0x0601B271 RID: 111217 RVA: 0x00826D84 File Offset: 0x00824F84
	protected void UpdateMoveBuff()
	{
		double num = (double)this.VehicleMovement.MotorAccelConfig.MaxSpeed;
		double num2 = this.ActorComp.ActorVelocityProxy.DotProduct(this.ActorComp.ActorForwardProxy) / num;
		BaseTagComponent tagComponent = this.TagComponent;
		List<ValueTuple<float, long>> list;
		if (tagComponent == null || !tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冲刺"]))
		{
			BaseTagComponent tagComponent2 = this.TagComponent;
			list = ((tagComponent2 != null && tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.翱翔冲刺"])) ? this.SpeedBuffSoarSprint : this.SpeedBuffNotSprint);
		}
		else
		{
			list = this.SpeedBuffSprint;
		}
		bool flag = false;
		foreach (ValueTuple<float, long> valueTuple in list)
		{
			float item = valueTuple.Item1;
			long item2 = valueTuple.Item2;
			if (num2 < (double)item)
			{
				this.CurrentMoveBuff = item2;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			this.CurrentMoveBuff = 0L;
		}
	}

	// Token: 0x0601B272 RID: 111218 RVA: 0x00826E84 File Offset: 0x00825084
	private void UpdateMoveState()
	{
		this.MotorSubState = this.VehicleMovement.MotorSubState;
		this.DriftingState = (this.BackBraking && this.ActorComp.InputDirectProxy.X > -1E-08 && Math.Abs(this.ActorComp.InputDirectProxy.Y) > 0.5 && (double)this.Speed > 500.0 && this.MotorSubState == EMotorSubState.TwoWheelMoving);
		if (this.DriftingState)
		{
			this.DriftDistance += global::Vector.Dist(this.ActorComp.ActorLocationProxy, this.DriftLastLocation);
			this.DriftLastLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		}
		double num = this.ActorComp.ActorVelocityProxy.DotProduct(this.ActorComp.ActorForwardProxy);
		if (!this.DriftingState && num >= 200.0)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if ((tagComponent == null || !tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.强制刹停"])) && (this.MotorSubState == EMotorSubState.TwoWheelMoving || this.MotorSubState == EMotorSubState.OneWheelMoving))
			{
				this.FrontBrakingState = (!this.BackingMotor && this.ActorComp.InputDirectProxy.X < 0.0);
				this.BackBrakingState = this.BackBraking;
				goto IL_166;
			}
		}
		this.FrontBrakingState = false;
		this.BackBrakingState = false;
		IL_166:
		double value = 0.0;
		if (this.MotorSubState == EMotorSubState.TwoWheelMoving)
		{
			value = this.ActorComp.ActorRightProxy.DotProduct(this.ActorComp.ActorVelocityProxy);
		}
		this.SideSlide = (Math.Abs(value) > 200.0);
	}

	// Token: 0x0601B273 RID: 111219 RVA: 0x00827040 File Offset: 0x00825240
	private void UpdateBaseMovement()
	{
		UKuroVehicleMovementComponent vehicleMovement = this.VehicleMovement;
		if (vehicleMovement != null)
		{
			vehicleMovement.GetBaseMovement(ref this.BaseMovementArray);
		}
		TArray<UPrimitiveComponent> baseMovementArray = this.BaseMovementArray;
		int num = baseMovementArray.Num();
		bool flag = true;
		this.NextBaseMovement.Clear();
		for (long num2 = 0L; num2 < (long)num; num2 += 1L)
		{
			UPrimitiveComponent item = baseMovementArray.Get((int)num2);
			this.NextBaseMovement.Add(item);
			flag = (flag && this.CurrentBaseMovement.Contains(item));
		}
		if (!flag || this.CurrentBaseMovement.Count != this.NextBaseMovement.Count)
		{
			HashSet<UPrimitiveComponent> nextBaseMovement = this.NextBaseMovement;
			HashSet<UPrimitiveComponent> currentBaseMovement = this.CurrentBaseMovement;
			this.CurrentBaseMovement = nextBaseMovement;
			this.NextBaseMovement = currentBaseMovement;
			this.NextBaseMovement.Clear();
			Singleton<EventSystem>.Instance.EmitWithTarget<IReadOnlySet<UPrimitiveComponent>>(base.Entity, EEventName.MotorcycleBaseMovementChanged, this.CurrentBaseMovement);
		}
	}

	// Token: 0x0601B274 RID: 111220 RVA: 0x00827124 File Offset: 0x00825324
	private void InitSeatTrans()
	{
		IReadOnlyList<float> floatArrayConfig = ConfigCommonParamById.GetFloatArrayConfig("MotorGetOnSeatTrans");
		if (floatArrayConfig != null && floatArrayConfig.Count >= 9)
		{
			global::Vector location = global::Vector.Create((double)floatArrayConfig[0], (double)floatArrayConfig[1], (double)floatArrayConfig[2]);
			Rotator rotator = Rotator.Create(floatArrayConfig[3], floatArrayConfig[4], floatArrayConfig[5]);
			global::Vector scale3D = global::Vector.Create((double)floatArrayConfig[6], (double)floatArrayConfig[7], (double)floatArrayConfig[8]);
			this.DefaultSeatTrans.SetLocation(location);
			this.DefaultSeatTrans.SetRotation(rotator.Quaternion(null));
			this.DefaultSeatTrans.SetScale3D(scale3D);
		}
	}

	// Token: 0x0601B275 RID: 111221 RVA: 0x008271D0 File Offset: 0x008253D0
	[NullableContext(2)]
	public unsafe Transform GetMotorcycleSummonTrans(int entityId, FTransform? trans = null)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "SummonAndRideMotorcycle Error. No ActorComp.";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActorEntityId", entityId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		FTransform ftransform = trans ?? this.DefaultSeatTrans.ToUeTransformOld();
		MotorcycleMoveComponent.tmpTrans.FromUeTransform(ftransform);
		MotorcycleMoveComponent.leftTurn90.Multiply(MotorcycleMoveComponent.tmpTrans.GetRotation(), MotorcycleMoveComponent.tmpQuat2);
		MotorcycleMoveComponent.tmpQuat2.Inverse(MotorcycleMoveComponent.tmpQuat);
		component.ActorQuatProxy.Multiply(MotorcycleMoveComponent.tmpQuat, MotorcycleMoveComponent.tmpQuat2);
		MotorcycleMoveComponent.tmpTrans.SetRotation(MotorcycleMoveComponent.tmpQuat2);
		MotorcycleMoveComponent.leftTurn90.RotateVector(MotorcycleMoveComponent.tmpTrans.GetLocation(), MotorcycleMoveComponent.tmpVector);
		MotorcycleMoveComponent.tmpVector.Z += (double)(component.HalfHeight - 45f);
		MotorcycleMoveComponent.tmpQuat2.RotateVector(MotorcycleMoveComponent.tmpVector, MotorcycleMoveComponent.tmpVector);
		component.ActorLocationProxy.Subtraction(MotorcycleMoveComponent.tmpVector, MotorcycleMoveComponent.tmpVector);
		MotorcycleMoveComponent.tmpTrans.SetLocation(MotorcycleMoveComponent.tmpVector);
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		UTraceBaseElement utraceBaseElement = actorTrace;
		UKuroVehicleMovementComponent vehicleMovement = this.VehicleMovement;
		utraceBaseElement.WorldContextObject = ((vehicleMovement != null) ? vehicleMovement.GetOwner() : null);
		actorTrace.Radius = 5f;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, component.ActorLocationProxy);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, MotorcycleMoveComponent.tmpVector);
		if (Singleton<TraceElementCommon>.Instance.ShapeTrace(component.Actor.CapsuleComponent, actorTrace, "SummonAndRideMotorcycle", "SummonAndRideMotorcycle"))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Vehicle;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "SummonAndRideMotorcycle  Error. Block.";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", component.Actor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("tmpTrans", MotorcycleMoveComponent.tmpTrans);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		UKuroVehicleMovementComponent vehicleMovement2 = this.VehicleMovement;
		bool? flag = (vehicleMovement2 != null) ? new bool?(vehicleMovement2.IsValidTransform(MotorcycleMoveComponent.tmpTrans.ToUeTransform(), null)) : null;
		if (flag == null || !flag.Value)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Vehicle;
			ELogAuthor author3 = ELogAuthor.LCZ;
			string message3 = "SummonAndRideMotorcycle Error. Not ValidTrans.";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Actor", component.Actor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("tmpTrans", MotorcycleMoveComponent.tmpTrans);
			instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return null;
		}
		return MotorcycleMoveComponent.tmpTrans;
	}

	// Token: 0x0601B276 RID: 111222 RVA: 0x00827483 File Offset: 0x00825683
	protected override void UpdateUeMovementDisableState(float delta)
	{
		if (this.CurrentBaseMovement.Count > 0)
		{
			this.StopMoveContinuousTime = 0f;
			base.EnableUeMovementTick("CurrentBaseMovement不为空");
			return;
		}
		base.UpdateUeMovementDisableState(delta);
	}

	// Token: 0x0601B277 RID: 111223 RVA: 0x008274B4 File Offset: 0x008256B4
	protected void CheckAllowSoar()
	{
		if (this.MotorSubState == EMotorSubState.Soaring)
		{
			this.AllowSoar = true;
			return;
		}
		if (this.IsSoarFunctionOpen())
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null || !tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用翱翔"]))
			{
				if (this.MotorSubState != EMotorSubState.AirMoving)
				{
					this.AllowSoar = false;
					return;
				}
				if (Singleton<Time>.Instance.Now < this.NextCheckAllowTime)
				{
					this.LastCheckAllowHeightPosition.Subtraction(this.ActorComp.ActorLocationProxy, this.TmpVector);
					if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TmpVector) < 100.0)
					{
						return;
					}
				}
				this.NextCheckAllowTime = Singleton<Time>.Instance.Now + 200.0;
				this.LastCheckAllowHeightPosition.DeepCopy(this.ActorComp.ActorLocationProxy);
				this.AllowSoar = (base.GetHeightAboveGround(900f) > 800f);
				return;
			}
		}
		this.AllowSoar = false;
	}

	// Token: 0x0601B278 RID: 111224 RVA: 0x008275AF File Offset: 0x008257AF
	public override void SetMotorSubState(EMotorSubState subState)
	{
		base.SetMotorSubState(subState);
		this.MotorSubState = this.VehicleMovement.MotorSubState;
	}

	// Token: 0x0601B279 RID: 111225 RVA: 0x008275CC File Offset: 0x008257CC
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		MotorcycleMoveComponent motorcycleMoveComponent = (MotorcycleMoveComponent)componentTemplate;
		if (base.CanResetComponentProperty("BuffComp"))
		{
			if (motorcycleMoveComponent.BuffComp == null)
			{
				this.BuffComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleBuffComponent>(this.BuffComp), "BuffComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PerformComp"))
		{
			if (motorcycleMoveComponent.PerformComp == null)
			{
				this.PerformComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseVehiclePerformComponent>(this.PerformComp), "PerformComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TmpInputDirect") && motorcycleMoveComponent.TmpInputDirect != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpInputDirect), "TmpInputDirect"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("DefaultSeatTrans") && motorcycleMoveComponent.DefaultSeatTrans != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Transform>(this.DefaultSeatTrans), "DefaultSeatTrans"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("BaseMovementArray"))
		{
			if (motorcycleMoveComponent.BaseMovementArray == null)
			{
				this.BaseMovementArray = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UPrimitiveComponent>(this.BaseMovementArray), "BaseMovementArray"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurrentBaseMovement"))
		{
			if (motorcycleMoveComponent.CurrentBaseMovement == null)
			{
				this.CurrentBaseMovement = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UPrimitiveComponent>(this.CurrentBaseMovement), "CurrentBaseMovement"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("NextBaseMovement"))
		{
			if (motorcycleMoveComponent.NextBaseMovement == null)
			{
				this.NextBaseMovement = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UPrimitiveComponent>(this.NextBaseMovement), "NextBaseMovement"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DriftModelInternal"))
		{
			this.DriftModelInternal = motorcycleMoveComponent.DriftModelInternal;
		}
		if (base.CanResetComponentProperty("BackInputTime"))
		{
			this.BackInputTime = motorcycleMoveComponent.BackInputTime;
		}
		if (base.CanResetComponentProperty("BackBrakingInternal"))
		{
			this.BackBrakingInternal = motorcycleMoveComponent.BackBrakingInternal;
		}
		if (base.CanResetComponentProperty("DriftingStateInternal"))
		{
			this.DriftingStateInternal = motorcycleMoveComponent.DriftingStateInternal;
		}
		if (base.CanResetComponentProperty("DriftDistance"))
		{
			this.DriftDistance = motorcycleMoveComponent.DriftDistance;
		}
		if (base.CanResetComponentProperty("DriftStartTime"))
		{
			this.DriftStartTime = motorcycleMoveComponent.DriftStartTime;
		}
		if (base.CanResetComponentProperty("DriftLastLocation") && motorcycleMoveComponent.DriftLastLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.DriftLastLocation), "DriftLastLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("FrontBrakingStateInternal"))
		{
			this.FrontBrakingStateInternal = motorcycleMoveComponent.FrontBrakingStateInternal;
		}
		if (base.CanResetComponentProperty("BackBrakingStateInternal"))
		{
			this.BackBrakingStateInternal = motorcycleMoveComponent.BackBrakingStateInternal;
		}
		if (base.CanResetComponentProperty("SideSlideInternal"))
		{
			this.SideSlideInternal = motorcycleMoveComponent.SideSlideInternal;
		}
		if (base.CanResetComponentProperty("MotorSubStateInternal"))
		{
			this.MotorSubStateInternal = motorcycleMoveComponent.MotorSubStateInternal;
		}
		if (base.CanResetComponentProperty("NextCheckAllowTime"))
		{
			this.NextCheckAllowTime = motorcycleMoveComponent.NextCheckAllowTime;
		}
		if (base.CanResetComponentProperty("LastCheckAllowHeightPosition") && motorcycleMoveComponent.LastCheckAllowHeightPosition != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.LastCheckAllowHeightPosition), "LastCheckAllowHeightPosition"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("AllowSoarInternal"))
		{
			this.AllowSoarInternal = motorcycleMoveComponent.AllowSoarInternal;
		}
		if (base.CanResetComponentProperty("DriftBuffId"))
		{
			this.DriftBuffId = motorcycleMoveComponent.DriftBuffId;
		}
		if (base.CanResetComponentProperty("BackMotorBuff"))
		{
			this.BackMotorBuff = motorcycleMoveComponent.BackMotorBuff;
		}
		if (base.CanResetComponentProperty("BackingMotorInternal"))
		{
			this.BackingMotorInternal = motorcycleMoveComponent.BackingMotorInternal;
		}
		if (base.CanResetComponentProperty("SpeedBuffNotSprint") && motorcycleMoveComponent.SpeedBuffNotSprint != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ValueTuple<float, long>>>(this.SpeedBuffNotSprint), "SpeedBuffNotSprint"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SpeedBuffSprint") && motorcycleMoveComponent.SpeedBuffSprint != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ValueTuple<float, long>>>(this.SpeedBuffSprint), "SpeedBuffSprint"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SpeedBuffSoarSprint") && motorcycleMoveComponent.SpeedBuffSoarSprint != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ValueTuple<float, long>>>(this.SpeedBuffSoarSprint), "SpeedBuffSoarSprint"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CurrentMoveBuffInternal"))
		{
			this.CurrentMoveBuffInternal = motorcycleMoveComponent.CurrentMoveBuffInternal;
		}
		if (base.CanResetComponentProperty("SprintCameraShake"))
		{
			if (motorcycleMoveComponent.SprintCameraShake == null)
			{
				this.SprintCameraShake = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UClass>(this.SprintCameraShake), "SprintCameraShake"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsFunctionOpenOverride"))
		{
			this.IsFunctionOpenOverride = motorcycleMoveComponent.IsFunctionOpenOverride;
		}
		if (base.CanResetComponentProperty("DisableSprintTagFrame"))
		{
			this.DisableSprintTagFrame = motorcycleMoveComponent.DisableSprintTagFrame;
		}
		return (!base.CanResetComponentProperty("Stat0") || motorcycleMoveComponent.Stat0 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.Stat0), "Stat0")) && (!base.CanResetComponentProperty("Stat1") || motorcycleMoveComponent.Stat1 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.Stat1), "Stat1")) && (!base.CanResetComponentProperty("Stat2") || motorcycleMoveComponent.Stat2 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.Stat2), "Stat2")) && (!base.CanResetComponentProperty("Stat3") || motorcycleMoveComponent.Stat3 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.Stat3), "Stat3")) && (!base.CanResetComponentProperty("Stat4") || motorcycleMoveComponent.Stat4 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.Stat4), "Stat4"));
	}

	// Token: 0x0400DCF0 RID: 56560
	private const float BRAKE_FORWARD_SPEED_THRESHOLD = 200f;

	// Token: 0x0400DCF1 RID: 56561
	private const float BRAKE_RIGHT_SPEED_THRESHOLD = 500f;

	// Token: 0x0400DCF2 RID: 56562
	private const float BACK_TIME_THRESHOLD = 100f;

	// Token: 0x0400DCF3 RID: 56563
	private const float SIDE_SLIDE_SPEED_THRESHOLD = 200f;

	// Token: 0x0400DCF4 RID: 56564
	private const double DRIFT_INPUT_X_THRESHOLD = -1E-08;

	// Token: 0x0400DCF5 RID: 56565
	private const double DRIFT_INPUT_Y_THRESHOLD = 0.5;

	// Token: 0x0400DCF6 RID: 56566
	private const double DRIFT_SPEED_THRESHOLD = 500.0;

	// Token: 0x0400DCF7 RID: 56567
	private const float CHECK_ALLOW_SOAR_PERIOD = 200f;

	// Token: 0x0400DCF8 RID: 56568
	private const float CHECK_ALLOW_SOAR_HEIGHT_THRESHOLD = 100f;

	// Token: 0x0400DCF9 RID: 56569
	private const float ALLOW_SOAR_HEIGHT = 800f;

	// Token: 0x0400DCFA RID: 56570
	[StaticVariableRuleIgnore]
	private static readonly Transform tmpTrans = Transform.Create();

	// Token: 0x0400DCFB RID: 56571
	[StaticVariableRuleIgnore]
	private static readonly Quat tmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400DCFC RID: 56572
	[StaticVariableRuleIgnore]
	private static readonly Quat tmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400DCFD RID: 56573
	[StaticVariableRuleIgnore]
	private static readonly global::Vector tmpVector = global::Vector.Create();

	// Token: 0x0400DCFE RID: 56574
	[StaticVariableRuleIgnore]
	private static readonly Quat leftTurn90 = Rotator.Create(0f, -90f, 0f).Quaternion(null);

	// Token: 0x0400DCFF RID: 56575
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<EMotorDriftModel, int> driftModelTagMap = new Dictionary<EMotorDriftModel, int>
	{
		{
			EMotorDriftModel.KartingMode,
			GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.新版漂移"]
		}
	};

	// Token: 0x0400DD00 RID: 56576
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<EMotorSubState, int> motorSubStateTagMap = new Dictionary<EMotorSubState, int>
	{
		{
			EMotorSubState.Stop,
			GameplayTagDefine.EGameplayTagId["载具.摩托.状态.地面.待机状态"]
		},
		{
			EMotorSubState.OneWheelMoving,
			GameplayTagDefine.EGameplayTagId["载具.摩托.状态.地面.独轮"]
		},
		{
			EMotorSubState.TwoWheelMoving,
			GameplayTagDefine.EGameplayTagId["载具.摩托.状态.地面.双轮"]
		},
		{
			EMotorSubState.BrakingTurn,
			GameplayTagDefine.EGameplayTagId["载具.摩托.状态.地面.烧胎"]
		},
		{
			EMotorSubState.AirMoving,
			GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.普通"]
		},
		{
			EMotorSubState.Soaring,
			GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"]
		}
	};

	// Token: 0x0400DD01 RID: 56577
	[Nullable(2)]
	private VehicleBuffComponent BuffComp;

	// Token: 0x0400DD02 RID: 56578
	[Nullable(2)]
	private BaseVehiclePerformComponent PerformComp;

	// Token: 0x0400DD03 RID: 56579
	private readonly global::Vector TmpInputDirect = global::Vector.Create();

	// Token: 0x0400DD04 RID: 56580
	private readonly Transform DefaultSeatTrans = Transform.Create();

	// Token: 0x0400DD05 RID: 56581
	private TArray<UPrimitiveComponent> BaseMovementArray = new TArray<UPrimitiveComponent>();

	// Token: 0x0400DD06 RID: 56582
	private HashSet<UPrimitiveComponent> CurrentBaseMovement = new HashSet<UPrimitiveComponent>();

	// Token: 0x0400DD07 RID: 56583
	private HashSet<UPrimitiveComponent> NextBaseMovement = new HashSet<UPrimitiveComponent>();

	// Token: 0x0400DD08 RID: 56584
	private EMotorDriftModel DriftModelInternal;

	// Token: 0x0400DD09 RID: 56585
	private double BackInputTime;

	// Token: 0x0400DD0A RID: 56586
	private bool BackBrakingInternal;

	// Token: 0x0400DD0B RID: 56587
	private bool DriftingStateInternal;

	// Token: 0x0400DD0C RID: 56588
	private double DriftDistance;

	// Token: 0x0400DD0D RID: 56589
	private double DriftStartTime;

	// Token: 0x0400DD0E RID: 56590
	private readonly global::Vector DriftLastLocation = global::Vector.Create();

	// Token: 0x0400DD0F RID: 56591
	private bool FrontBrakingStateInternal;

	// Token: 0x0400DD10 RID: 56592
	private bool BackBrakingStateInternal;

	// Token: 0x0400DD11 RID: 56593
	private bool SideSlideInternal;

	// Token: 0x0400DD12 RID: 56594
	private EMotorSubState MotorSubStateInternal = EMotorSubState.TwoWheelMoving;

	// Token: 0x0400DD13 RID: 56595
	private double NextCheckAllowTime;

	// Token: 0x0400DD14 RID: 56596
	private readonly global::Vector LastCheckAllowHeightPosition = global::Vector.Create();

	// Token: 0x0400DD15 RID: 56597
	private bool AllowSoarInternal;

	// Token: 0x0400DD16 RID: 56598
	private long DriftBuffId;

	// Token: 0x0400DD17 RID: 56599
	private long BackMotorBuff;

	// Token: 0x0400DD18 RID: 56600
	private bool BackingMotorInternal;

	// Token: 0x0400DD19 RID: 56601
	[Nullable(new byte[]
	{
		1,
		0
	})]
	private readonly List<ValueTuple<float, long>> SpeedBuffNotSprint = new List<ValueTuple<float, long>>();

	// Token: 0x0400DD1A RID: 56602
	[Nullable(new byte[]
	{
		1,
		0
	})]
	private readonly List<ValueTuple<float, long>> SpeedBuffSprint = new List<ValueTuple<float, long>>();

	// Token: 0x0400DD1B RID: 56603
	[Nullable(new byte[]
	{
		1,
		0
	})]
	private readonly List<ValueTuple<float, long>> SpeedBuffSoarSprint = new List<ValueTuple<float, long>>();

	// Token: 0x0400DD1C RID: 56604
	private long CurrentMoveBuffInternal;

	// Token: 0x0400DD1D RID: 56605
	[Nullable(2)]
	private UClass SprintCameraShake;

	// Token: 0x0400DD1E RID: 56606
	private bool? IsFunctionOpenOverride;

	// Token: 0x0400DD1F RID: 56607
	private int DisableSprintTagFrame;

	// Token: 0x0400DD20 RID: 56608
	[StaticVariableRuleIgnore]
	private readonly Stat Stat0 = Stat.Create("BackingMotor", "", "");

	// Token: 0x0400DD21 RID: 56609
	[StaticVariableRuleIgnore]
	private readonly Stat Stat1 = Stat.Create("super.OnTick", "", "");

	// Token: 0x0400DD22 RID: 56610
	[StaticVariableRuleIgnore]
	private readonly Stat Stat2 = Stat.Create("UpdateMoveState", "", "");

	// Token: 0x0400DD23 RID: 56611
	[StaticVariableRuleIgnore]
	private readonly Stat Stat3 = Stat.Create("UpdateMoveBuff", "", "");

	// Token: 0x0400DD24 RID: 56612
	[StaticVariableRuleIgnore]
	private readonly Stat Stat4 = Stat.Create("UpdateBaseMovement", "", "");
}
