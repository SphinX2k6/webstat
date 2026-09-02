using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using CSharpScript.Core.Utils.LockingHandler;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02000E2E RID: 3630
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(true)]
public class CameraModifyController : CameraControllerBase<EFightCameraModify>, ICanGetConfigMapValue
{
	// Token: 0x170005B9 RID: 1465
	// (get) Token: 0x060055B4 RID: 21940 RVA: 0x000E1FD0 File Offset: 0x000E01D0
	private bool ModifyArmRotation
	{
		get
		{
			return this.ModifyArmRotationPitch || this.ModifyArmRotationYaw || this.ModifyArmRotationRoll;
		}
	}

	// Token: 0x170005BA RID: 1466
	// (get) Token: 0x060055B5 RID: 21941 RVA: 0x000E1FEA File Offset: 0x000E01EA
	// (set) Token: 0x060055B6 RID: 21942 RVA: 0x000E1FF2 File Offset: 0x000E01F2
	protected bool IsAiming
	{
		get
		{
			return this.IsAimingInternal;
		}
		set
		{
			if (this.IsAimingInternal == value)
			{
				return;
			}
			this.IsAimingInternal = value;
			if (this.IsAimingInternal)
			{
				base.Lock(this);
				return;
			}
			base.Unlock(this);
		}
	}

	// Token: 0x060055B7 RID: 21943 RVA: 0x000E201C File Offset: 0x000E021C
	public CameraModifyController(FightCameraLogicComponent camera) : base(camera)
	{
		this.OnAllMontageInstancesEnded = new Action(this.OnAllMontageInstancesEndedHandler);
		this.OnMontageEnded = new Action<UAnimMontage, bool>(this.OnMontageEndedHandler);
		this.OnMontageStarted = new Action<UAnimMontage>(this.OnMontageStartedHandler);
		this.OnLookAtEntityDead = new Action<int>(this.OnLookAtEntityDeadHandler);
		this.OnVisionMorphEnd = new Action<EntityHandle, EntityHandle>(this.OnVisionMorphEndHandler);
		this.OnPlayCameraLevelSequence = new Action<ULevelSequence, AActor, ALevelSequenceActor, FTransformDouble, bool, bool, string>(this.OnPlayCameraLevelSequenceHandler);
		this.OnCharBeforeUseSkill = new Action<int, int, bool>(this.OnCharBeforeUseSkillHandler);
	}

	// Token: 0x060055B8 RID: 21944 RVA: 0x000E2215 File Offset: 0x000E0415
	private void OnAllMontageInstancesEndedHandler()
	{
		if (this.ModifyMontage != null)
		{
			UAnimMontage modifyMontage = this.ModifyMontage;
			UAnimInstance modifyAnimInstance = this.ModifyAnimInstance;
			if (modifyMontage != ((modifyAnimInstance != null) ? modifyAnimInstance.GetCurrentActiveMontage() : null))
			{
				this.EndModify(true, true, null);
			}
		}
	}

	// Token: 0x060055B9 RID: 21945 RVA: 0x000E2242 File Offset: 0x000E0442
	[NullableContext(2)]
	private void OnMontageEndedHandler(UAnimMontage montage, bool interrupt)
	{
		if (this.ModifyMontage != null)
		{
			UAnimMontage modifyMontage = this.ModifyMontage;
			UAnimInstance modifyAnimInstance = this.ModifyAnimInstance;
			if (modifyMontage != ((modifyAnimInstance != null) ? modifyAnimInstance.GetCurrentActiveMontage() : null))
			{
				this.EndModify(true, true, null);
			}
		}
	}

	// Token: 0x060055BA RID: 21946 RVA: 0x000E226F File Offset: 0x000E046F
	[NullableContext(2)]
	private void OnMontageStartedHandler(UAnimMontage montage)
	{
		if (this.ModifyMontage != null && this.ModifyMontage != montage)
		{
			this.EndModify(true, true, null);
		}
	}

	// Token: 0x060055BB RID: 21947 RVA: 0x000E228C File Offset: 0x000E048C
	private void OnLookAtEntityDeadHandler(int id)
	{
		if (!this.LookAtActor.HasValue)
		{
			return;
		}
		if (id != (this.LookAtActor.IsT1 ? this.LookAtActor.AsT1.EntityId : this.LookAtActor.AsT2.EntityId))
		{
			return;
		}
		this.EndModify(true, false, null);
	}

	// Token: 0x060055BC RID: 21948 RVA: 0x000E22E3 File Offset: 0x000E04E3
	[NullableContext(2)]
	private void OnVisionMorphEndHandler(EntityHandle roleEntityHandle, EntityHandle visionEntityHandle)
	{
		if (visionEntityHandle == null || !visionEntityHandle.Valid || visionEntityHandle.Entity != this.LookAtEntity)
		{
			return;
		}
		this.EndModify(true, true, null);
	}

	// Token: 0x060055BD RID: 21949 RVA: 0x000E2310 File Offset: 0x000E0510
	private void OnPlayCameraLevelSequenceHandler(ULevelSequence levelSequence, AActor role, ALevelSequenceActor sequenceActor, FTransformDouble startTrans, bool playResult, bool isStopModify, string cameraName)
	{
		CameraModelInstance cameraModel = base.CameraModel;
		if (cameraName != ((cameraModel != null) ? cameraModel.CameraName : null))
		{
			return;
		}
		if (!playResult || !isStopModify)
		{
			return;
		}
		if (this.IsModified && this.AnimOwner.HasValue && (this.AnimOwner.IsT1 ? this.AnimOwner.AsT1.IsValid() : this.AnimOwner.AsT2.IsValid()) && CameraUtility.CheckFormationControlState(ModelBase<CharacterModel>.Instance.GetHandle(this.AnimOwner.IsT1 ? this.AnimOwner.AsT1.EntityId : this.AnimOwner.AsT2.EntityId), true, false))
		{
			this.EndModify(true, true, null);
		}
		this.EndModifyFadeOut(true);
	}

	// Token: 0x060055BE RID: 21950 RVA: 0x000E23E0 File Offset: 0x000E05E0
	private void OnCharBeforeUseSkillHandler(int entityId, int skillId, bool isAutonomousProxy)
	{
		if (!isAutonomousProxy)
		{
			return;
		}
		if (!this.IsModified)
		{
			return;
		}
		foreach (ResetFinalArmLengthToDynamicValueData resetFinalArmLengthToDynamicValueData in this.ModifySettings.ResetFinalArmLengthToDynamicValueList)
		{
			if (resetFinalArmLengthToDynamicValueData.ArmLengthDynamicValueType == ECameraModifier_Settings_ArmLengthDynamicValueType.技能Id && resetFinalArmLengthToDynamicValueData.SkillId == skillId)
			{
				this.ModifyEndContext.Clear();
				this.ModifyEndContext.ArmLengthDynamicValueType = ECameraModifier_Settings_ArmLengthDynamicValueType.技能Id;
				this.ModifyEndContext.SkillId = skillId;
				this.EndModify(true, true, this.ModifyEndContext);
				break;
			}
		}
	}

	// Token: 0x060055BF RID: 21951 RVA: 0x000E2484 File Offset: 0x000E0684
	public override string Name()
	{
		return "ModifyController";
	}

	// Token: 0x060055C0 RID: 21952 RVA: 0x000E248B File Offset: 0x000E068B
	protected override void OnInit()
	{
		base.SetConfigMap(EFightCameraModify.臂长还原过渡速度, "ModifyArmLengthLagSpeed");
		base.SetConfigMap(EFightCameraModify.臂偏移还原过渡速度, "ModifyCameraOffsetLagSpeed");
		base.SetConfigMap(EFightCameraModify.旋转还原过渡速度, "ModifyArmRotationLagSpeed");
		base.SetConfigMap(EFightCameraModify.Fov还原过渡速度, "ModifyFovLagSpeed");
		base.SetConfigMap(EFightCameraModify.臂偏移原点还原过渡速度, "ModifyArmOffsetLagSpeed");
	}

	// Token: 0x060055C1 RID: 21953 RVA: 0x000E24C9 File Offset: 0x000E06C9
	protected override void OnDisable()
	{
		if (this.IsModified)
		{
			this.EndModify(true, false, null);
		}
		if (this.IsModifyFadeOut)
		{
			this.EndModifyFadeOut(false);
		}
	}

	// Token: 0x060055C2 RID: 21954 RVA: 0x000E24EB File Offset: 0x000E06EB
	protected override void UpdateInternal(float deltaTime)
	{
		this.IsAiming = this.Camera.ContainsTag(GameplayTagDefine.EGameplayTagId["行为状态.方向状态.瞄准方向"], false);
		if (this.IsAiming)
		{
			return;
		}
		this.UpdateModifyFadeOut(deltaTime);
		this.UpdateModifiers(deltaTime);
	}

	// Token: 0x060055C3 RID: 21955 RVA: 0x000E2525 File Offset: 0x000E0725
	protected override void UpdateDeactivateInternal(float deltaTime)
	{
		this.IsAiming = this.Camera.ContainsTag(GameplayTagDefine.EGameplayTagId["行为状态.方向状态.瞄准方向"], false);
		if (this.IsAiming)
		{
			return;
		}
		this.UpdateModifyFadeOut(deltaTime);
	}

	// Token: 0x060055C4 RID: 21956 RVA: 0x000E2558 File Offset: 0x000E0758
	protected override void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		CameraModify modifySettings = this.ModifySettings;
		if (modifySettings != null && modifySettings.IsSwitchModifier)
		{
			return;
		}
		this.EndModify(true, true, null);
	}

	// Token: 0x170005BB RID: 1467
	// (get) Token: 0x060055C5 RID: 21957 RVA: 0x000E2578 File Offset: 0x000E0778
	public override bool IsActivate
	{
		get
		{
			if (!base.IsActivate)
			{
				CameraModify modifySettings = this.ModifySettings;
				return modifySettings != null && modifySettings.IsForcePlayModify && !this.Camera.ContainsTag(CameraModifyController.BanForcePlayModify, false);
			}
			return true;
		}
	}

	// Token: 0x170005BC RID: 1468
	// (get) Token: 0x060055C6 RID: 21958 RVA: 0x000E25AE File Offset: 0x000E07AE
	public bool IsModified
	{
		get
		{
			return this.ModifySettings != null;
		}
	}

	// Token: 0x060055C7 RID: 21959 RVA: 0x000E25BC File Offset: 0x000E07BC
	public unsafe int ApplyCameraModify(FGameplayTag? tag, float duration, float blendInTime, float blendOutTime, float breakBlendOutTime, SCameraModifier_Settings settings, [Nullable(2)] UAnimSequenceBase anim, [Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<CurveBase, SBaseCurve> blendInCurve, [Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<CurveBase, SBaseCurve> blendOutCurve, [Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<TsBaseCharacter, TsBaseVehicle> newLookAtActor, string lookAtActorSocket, [Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<TsBaseCharacter, TsBaseVehicle> animOwner)
	{
		if (!base.IsActivate && (!settings.IsForcePlayModify || this.Camera.ContainsTag(CameraModifyController.BanForcePlayModify, false)))
		{
			return -1;
		}
		if (this.IsCameraModifyLocked())
		{
			return -1;
		}
		if (tag != null && tag.Value.TagName != FName.NAME_None && !this.Camera.ContainsTag(tag.Value.TagId(), false))
		{
			return -1;
		}
		if (settings.Priority < this.Priority)
		{
			return -1;
		}
		this.ModifyInstance++;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Camera;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "ApplyCameraModify";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("tag", (tag != null) ? new FName?(tag.GetValueOrDefault().TagName) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("montage", anim);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ArmLengthAddition", settings.CameraOffsetAdditional);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ModifyInstance", this.ModifyInstance);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		bool flag = this.IsModified || this.IsModifyFadeOut;
		if (this.IsDebugCurveEval && flag)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Camera;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "[CurveEval][Interrupt] 新 Modify 打断旧 Modify";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
			string item = "prevModifyName";
			CameraModify modifySettings = this.ModifySettings;
			ptr = new ValueTuple<string, object>(item, ((modifySettings != null) ? modifySettings.Name : null) ?? "FadeOut");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("newModifyName", settings.ModifySettingsAdditional.Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("isModified", this.IsModified);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("isModifyFadeOut", this.IsModifyFadeOut);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
		}
		bool flag2;
		if (this.IsModified)
		{
			if (!this.ModifyArmLength)
			{
				CameraModify modifySettings2 = this.ModifySettings;
				flag2 = (modifySettings2 != null && modifySettings2.IsModifiedArmLength);
			}
			else
			{
				flag2 = true;
			}
		}
		else
		{
			flag2 = false;
		}
		bool flag3 = flag2;
		bool flag4;
		if (this.IsModified)
		{
			if (!this.ModifyArmOffset)
			{
				CameraModify modifySettings3 = this.ModifySettings;
				flag4 = (modifySettings3 != null && modifySettings3.IsModifiedArmOffset);
			}
			else
			{
				flag4 = true;
			}
		}
		else
		{
			flag4 = false;
		}
		bool modifyArmOffset = flag4;
		bool isBreakPreviousPlayerLocationModify = flag && this.ModifyPlayerLocation;
		bool flag5;
		if (this.IsModified)
		{
			if (!this.ModifyFov)
			{
				CameraModify modifySettings4 = this.ModifySettings;
				flag5 = (modifySettings4 != null && modifySettings4.IsModifiedCameraFov);
			}
			else
			{
				flag5 = true;
			}
		}
		else
		{
			flag5 = false;
		}
		bool flag6 = flag5;
		bool flag7;
		if (this.IsModified)
		{
			if (!this.ModifyCameraOffset)
			{
				CameraModify modifySettings5 = this.ModifySettings;
				flag7 = (modifySettings5 != null && modifySettings5.IsModifiedCameraOffset);
			}
			else
			{
				flag7 = true;
			}
		}
		else
		{
			flag7 = false;
		}
		bool flag8 = flag7;
		this.EndModify(!flag, false, null);
		this.IsBreakPreviousPlayerLocationModify = isBreakPreviousPlayerLocationModify;
		this.Priority = settings.Priority;
		if (tag != null && tag.Value.TagName != FName.NAME_None)
		{
			this.ModifyTag = tag;
		}
		this.Camera.CameraAdjustController.Lock(this);
		this.Camera.CameraGuideController.Lock(this);
		this.Camera.CopyVirtualCamera(this.StartVirtualCamera, this.Camera.CurrentCamera, false);
		if (!flag)
		{
			this.Camera.CopyVirtualCamera(this.FirstStartVirtualCamera, this.StartVirtualCamera, false);
		}
		this.ModifyDuration = duration;
		this.ModifyBlendInTime = blendInTime;
		this.ModifyBlendOutTime = blendOutTime;
		this.ModifyFadeOutTime = breakBlendOutTime;
		this.ModifyBlendInCurve = (blendInCurve.IsT1 ? blendInCurve.AsT1 : CurveUtils.CreateCurveByStruct(blendInCurve.IsT2 ? blendInCurve.AsT2 : null));
		this.ModifyBlendOutCurve = (blendOutCurve.IsT1 ? blendOutCurve.AsT1 : CurveUtils.CreateCurveByStruct(blendOutCurve.IsT2 ? blendOutCurve.AsT2 : null));
		this.ModifyElapsedTime = 0f;
		this.ModifySettings = new CameraModify(settings);
		this.Camera.SetSuppressClearRoll(ESuppressClearRollFlag.CameraModify);
		this.ModifyAnimSequence = anim;
		this.AnimOwner = animOwner;
		if (this.ModifySettings.StopModifyOnMontageEnd)
		{
			UAnimMontage uanimMontage = anim as UAnimMontage;
			if (uanimMontage != null)
			{
				this.ModifyMontage = uanimMontage;
				this.ModifyAnimInstance = this.GetModifyAnimInstance(newLookAtActor, animOwner);
				UAnimInstance modifyAnimInstance = this.ModifyAnimInstance;
				if (modifyAnimInstance != null)
				{
					modifyAnimInstance.OnMontageStarted.Add(this.OnMontageStarted);
				}
				UAnimInstance modifyAnimInstance2 = this.ModifyAnimInstance;
				if (modifyAnimInstance2 != null)
				{
					modifyAnimInstance2.OnMontageEnded.Add(this.OnMontageEnded);
				}
				UAnimInstance modifyAnimInstance3 = this.ModifyAnimInstance;
				if (modifyAnimInstance3 != null)
				{
					modifyAnimInstance3.OnAllMontageInstancesEnded.Add(this.OnAllMontageInstancesEnded);
				}
			}
		}
		this.ModifyArmLength = (flag3 || !Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.ModifySettings.ArmLengthAdditional, 0.0, null));
		this.ModifyArmOffset = modifyArmOffset;
		this.ModifyCameraOffset = (flag8 || !this.ModifySettings.CameraOffsetAdditional.IsNearlyZero(0.0001));
		this.ModifyArmRotationPitch = !Singleton<MathUtils>.Instance.IsNearlyZero((double)this.ModifySettings.ArmRotationAdditional.Pitch, new double?(0.0001));
		this.ModifyArmRotationYaw = !Singleton<MathUtils>.Instance.IsNearlyZero((double)this.ModifySettings.ArmRotationAdditional.Yaw, new double?(0.0001));
		this.ModifyArmRotationRoll = !Singleton<MathUtils>.Instance.IsNearlyZero((double)this.ModifySettings.ArmRotationAdditional.Roll, new double?(0.0001));
		this.ModifyPlayerLocation = newLookAtActor.HasValue;
		this.LookAtActor = newLookAtActor;
		this.LookAtEntity = (newLookAtActor.HasValue ? (newLookAtActor.IsT1 ? newLookAtActor.AsT1.GetEntityNoBlueprint() : newLookAtActor.AsT2.GetEntityNoBlueprint()) : null);
		this.LookAtActorSocket = lookAtActorSocket;
		if (this.ModifyPlayerLocation)
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.CharOnRoleDead, this.OnLookAtEntityDead);
		}
		Entity lookAtEntity = this.LookAtEntity;
		if (lookAtEntity != null && lookAtEntity.Valid && this.LookAtEntityIsVision())
		{
			Singleton<EventSystem>.Instance.AddWithTarget<EntityHandle, EntityHandle>(this.LookAtEntity, EEventName.VisionMorphEnd, this.OnVisionMorphEnd);
		}
		this.StartAutoCameraArmLengthAddition = this.Camera.CameraAutoController.CurrentAutoCameraArmLengthAddition;
		this.StartAutoCameraArmOffset.DeepCopy(this.Camera.CameraAutoController.CurrentAutoCameraArmOffset);
		this.ModifyFov = (flag6 || this.ModifySettings.IsModifiedCameraFov);
		this.ModifyLens = this.ModifySettings.IsModifiedCameraLens;
		if (this.ModifySettings.OverrideCameraInput)
		{
			if (this.ModifyArmRotationPitch || (this.ModifySettings.IsModifiedArmRotation && this.ModifySettings.IsModifiedArmRotationPitch))
			{
				this.Camera.CameraInputController.LockArmRotationPitch(this);
			}
			if (this.ModifyArmRotationYaw || (this.ModifySettings.IsModifiedArmRotation && this.ModifySettings.IsModifiedArmRotationYaw))
			{
				this.Camera.CameraInputController.LockArmRotationYaw(this);
			}
			if (this.ModifyArmLength || this.ModifySettings.IsModifiedArmLength)
			{
				this.Camera.CameraInputController.LockArmLength(this);
			}
		}
		if (this.ModifySettings.IsLockInput)
		{
			this.Camera.CameraInputController.Lock(this);
		}
		if (this.ModifyArmRotation || this.ModifySettings.IsModifiedArmRotation)
		{
			this.Camera.CameraInputController.ResetCameraInput();
		}
		this.MaxAngleFixQuat.Reset();
		this.FirstModifyArmRotationPitch = true;
		this.FirstModifyArmRotationYaw = true;
		this.FirstModifyArmRotationRoll = true;
		this.BlendOutData.Reset();
		if (!Singleton<EventSystem>.Instance.Has<ULevelSequence, AActor, ALevelSequenceActor, FTransformDouble, bool, bool, string>(EEventName.PlayCameraLevelSequence, this.OnPlayCameraLevelSequence))
		{
			Singleton<EventSystem>.Instance.Add<ULevelSequence, AActor, ALevelSequenceActor, FTransformDouble, bool, bool, string>(EEventName.PlayCameraLevelSequence, this.OnPlayCameraLevelSequence);
		}
		if (!Singleton<EventSystem>.Instance.Has<int, int, bool>(EEventName.CharBeforeSkill, this.OnCharBeforeUseSkill))
		{
			Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.CharBeforeSkill, this.OnCharBeforeUseSkill);
		}
		return this.ModifyInstance;
	}

	// Token: 0x060055C8 RID: 21960 RVA: 0x000E2DE4 File Offset: 0x000E0FE4
	private void UpdateModifiers(float deltaSeconds)
	{
		if (!this.IsModified)
		{
			return;
		}
		this.ModifyElapsedTime += deltaSeconds;
		if (this.ModifyTag != null && !this.IsModifyBlendingOut)
		{
			if (this.Camera.ContainsTag(this.ModifyTag.Value.TagId(), false))
			{
				if (this.ModifyElapsedTime > this.ModifyBlendInTime)
				{
					this.ModifyElapsedTime = this.ModifyBlendInTime;
				}
			}
			else if (this.ModifyElapsedTime < this.ModifyBlendInTime + this.ModifyDuration)
			{
				this.EndModify(true, true, null);
				return;
			}
		}
		float blendInTimeRatio = 0f;
		EBlendState? eblendState;
		float num;
		float num2;
		if (this.ModifyElapsedTime < this.ModifyBlendInTime)
		{
			eblendState = new EBlendState?(EBlendState.BlendIn);
			blendInTimeRatio = this.ModifyElapsedTime / this.ModifyBlendInTime;
			num = ((this.ModifyBlendInTime > 0f) ? this.ModifyBlendInCurve.GetCurrentValue(this.ModifyElapsedTime / this.ModifyBlendInTime) : 1f);
			num2 = ((this.ModifyBlendInTime > 0f) ? this.ModifyBlendInCurve.GetOffsetRate((this.ModifyElapsedTime - deltaSeconds) / this.ModifyBlendInTime, deltaSeconds / this.ModifyBlendInTime) : 1f);
		}
		else if (this.ModifyElapsedTime < this.ModifyBlendInTime + this.ModifyDuration)
		{
			eblendState = new EBlendState?(EBlendState.Loop);
			num = 1f;
			num2 = 1f;
		}
		else
		{
			eblendState = new EBlendState?(EBlendState.BlendOut);
			float num3 = this.ModifyElapsedTime - this.ModifyBlendInTime - this.ModifyDuration;
			num = ((this.ModifyBlendOutTime > 0f) ? this.ModifyBlendOutCurve.GetCurrentValue(num3 / this.ModifyBlendOutTime) : 1f);
			num2 = ((this.ModifyBlendOutTime > 0f) ? this.ModifyBlendOutCurve.GetOffsetRate((num3 - deltaSeconds) / this.ModifyBlendOutTime, deltaSeconds / this.ModifyBlendOutTime) : 1f);
			this.Priority = 0;
		}
		this.CurrentBlendState = eblendState.Value;
		this.UpdateHasInput();
		this.UpdatePlayerLocationModifier(eblendState.Value, num, num2);
		this.UpdateArmLocationModifier(eblendState.Value, num, num2);
		this.UpdateArmLengthModifier(eblendState.Value, num, blendInTimeRatio);
		this.UpdateArmOffsetModifier(eblendState.Value, num, blendInTimeRatio);
		this.UpdateCameraOffsetModifier(eblendState.Value, num, blendInTimeRatio);
		this.UpdateArmRotationModifier(eblendState.Value, num, blendInTimeRatio);
		this.UpdateFovModifier(eblendState.Value, num, blendInTimeRatio);
		this.UpdateLensModifier(eblendState.Value, num, blendInTimeRatio);
		if (this.ModifyElapsedTime > this.ModifyBlendInTime + this.ModifyDuration + this.ModifyBlendOutTime)
		{
			this.EndModify(true, false, null);
			return;
		}
		if (this.ModifySettings.StopModifyOnZoomInput && (this.ModifyArmLength || this.ModifySettings.IsModifiedArmLength) && this.HasZoomInput())
		{
			this.EndModify(true, true, null);
		}
	}

	// Token: 0x060055C9 RID: 21961 RVA: 0x000E309C File Offset: 0x000E129C
	private void UpdatePlayerLocationModifier(EBlendState state, float alpha, float _)
	{
		if (!this.ModifyPlayerLocation)
		{
			return;
		}
		USkeletalMeshComponent uskeletalMeshComponent = this.LookAtActor.HasValue ? (this.LookAtActor.IsT1 ? this.LookAtActor.AsT1.Mesh : this.LookAtActor.AsT2.Mesh) : null;
		if (uskeletalMeshComponent == null || !uskeletalMeshComponent.IsValid())
		{
			this.EndModify(true, false, null);
			return;
		}
		Vector targetLocation = this.TargetLocation;
		FVectorDouble fvectorDouble = uskeletalMeshComponent.D_GetSocketLocation(FNameUtil.GetDynamicFName(this.LookAtActorSocket) ?? FName.NAME_None);
		targetLocation.FromUeVector(fvectorDouble);
		switch (state)
		{
		case EBlendState.BlendIn:
			this.TmpVector.DeepCopy(this.IsBreakPreviousPlayerLocationModify ? this.TmpPlayerLocation : this.Camera.PlayerLocation);
			Vector.Lerp(this.TmpVector, this.TargetLocation, (double)alpha, this.Camera.PlayerLocation);
			this.TmpPlayerLocation.DeepCopy(this.Camera.PlayerLocation);
			this.ModifyPlayerLocation = true;
			return;
		case EBlendState.Loop:
			this.Camera.PlayerLocation.DeepCopy(this.TargetLocation);
			this.TmpPlayerLocation.DeepCopy(this.Camera.PlayerLocation);
			this.ModifyPlayerLocation = true;
			return;
		case EBlendState.BlendOut:
			Vector.Lerp(this.TmpPlayerLocation, this.Camera.PlayerLocation, (double)alpha, this.Camera.PlayerLocation);
			this.TmpPlayerLocation.DeepCopy(this.Camera.PlayerLocation);
			this.ModifyPlayerLocation = true;
			return;
		default:
			this.ModifyPlayerLocation = false;
			return;
		}
	}

	// Token: 0x060055CA RID: 21962 RVA: 0x000E3238 File Offset: 0x000E1438
	private void UpdateArmLocationModifier(EBlendState state, float _, float alphaOffsetRate)
	{
		if (!this.ModifySettings.IsLerpArmLocation)
		{
			return;
		}
		if (state != EBlendState.BlendIn)
		{
			if (state != EBlendState.BlendOut)
			{
				this.Camera.DesiredCamera.ArmLocation.DeepCopy(this.Camera.PlayerLocation);
				this.Camera.CameraAutoController.CurrentAutoCameraArmOffset.Set(0.0, 0.0, 0.0);
			}
			else
			{
				Vector.Lerp(this.Camera.CurrentCamera.ArmLocation, this.Camera.TmpArmLocation, (double)alphaOffsetRate, this.Camera.DesiredCamera.ArmLocation);
				Vector.Lerp(Vector.Create(0.0, 0.0, 0.0), this.StartAutoCameraArmOffset, (double)alphaOffsetRate, this.Camera.CameraAutoController.CurrentAutoCameraArmOffset);
			}
		}
		else
		{
			Vector.Lerp(this.Camera.CurrentCamera.ArmLocation, this.Camera.PlayerLocation, (double)alphaOffsetRate, this.Camera.DesiredCamera.ArmLocation);
			Vector.Lerp(this.StartAutoCameraArmOffset, Vector.Create(0.0, 0.0, 0.0), (double)alphaOffsetRate, this.Camera.CameraAutoController.CurrentAutoCameraArmOffset);
		}
		this.Camera.IsModifiedArmLocation = true;
	}

	// Token: 0x060055CB RID: 21963 RVA: 0x000E33A4 File Offset: 0x000E15A4
	private unsafe void UpdateArmLengthModifier(EBlendState state, float alpha, float blendInTimeRatio)
	{
		if (!this.ModifySettings.IsModifiedArmLength && !this.ModifyArmLength)
		{
			return;
		}
		float num = alpha;
		float armLengthWithSetting = this.Camera.GetArmLengthWithSetting(this.Camera.CurrentCamera);
		float num2;
		if (this.ModifySettings.IsModifiedArmLength)
		{
			num2 = this.ModifySettings.ArmLength / armLengthWithSetting;
		}
		else
		{
			num2 = this.Camera.GetArmLengthWithSettingAndZoom(this.FirstStartVirtualCamera, true) / armLengthWithSetting;
		}
		if (this.ModifyArmLength)
		{
			num2 += this.ModifySettings.ArmLengthAdditional / armLengthWithSetting;
			num2 = Math.Max(num2, this.Camera.CurrentCamera.MinArmLength / armLengthWithSetting);
		}
		switch (state)
		{
		case EBlendState.BlendIn:
			if (this.ModifySettings.IsUseArmLengthFloatCurve)
			{
				num = this.ModifySettings.ArmLengthFloatCurve.GetCurrentValue(blendInTimeRatio);
			}
			this.Camera.DesiredCamera.ZoomModifier = Singleton<MathUtils>.Instance.Lerp(this.StartVirtualCamera.ZoomModifier, num2, num);
			if (this.ModifySettings.IsModifiedArmLength)
			{
				this.Camera.CameraAutoController.CurrentAutoCameraArmLengthAddition = Singleton<MathUtils>.Instance.Lerp(this.StartAutoCameraArmLengthAddition, 0f, num);
			}
			break;
		case EBlendState.Loop:
			this.Camera.DesiredCamera.ZoomModifier = num2;
			if (this.ModifySettings.IsModifiedArmLength)
			{
				this.Camera.CameraAutoController.CurrentAutoCameraArmLengthAddition = 0f;
			}
			break;
		case EBlendState.BlendOut:
			this.Camera.DesiredCamera.ZoomModifier = Singleton<MathUtils>.Instance.Lerp(num2, Singleton<MathUtils>.Instance.Clamp(this.GetFinalZoomModifierArmLength(null), this.Camera.CurrentCamera.MinArmLength, this.Camera.CurrentCamera.MaxArmLength) / this.Camera.GetArmLengthWithSetting(this.Camera.CurrentCamera), alpha);
			if (this.ModifySettings.IsModifiedArmLength)
			{
				this.Camera.CameraAutoController.CurrentAutoCameraArmLengthAddition = Singleton<MathUtils>.Instance.Lerp(0f, this.StartAutoCameraArmLengthAddition, alpha);
			}
			break;
		}
		this.Camera.IsModifiedArmLength = true;
		this.Camera.IsModifiedZoomModifier = true;
		if ((double)this.Camera.DesiredCamera.ZoomModifier <= 1E-08 && this.EnableDebugModifyZoomModifier)
		{
			this.EnableDebugModifyZoomModifier = false;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[DebugZoomModifier UpdateArmLengthModifier]";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("state", state);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DesiredCamera.ZoomModifier", this.Camera.DesiredCamera.ZoomModifier);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("this.StartVirtualCamera.ZoomModifier", this.StartVirtualCamera.ZoomModifier);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("targetZoomModifier", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("ratio", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Anim", this.ModifyAnimSequence);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("CameraConfigTags", this.Camera.CameraConfigController.GetCameraConfigTagsContent());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
		}
	}

	// Token: 0x060055CC RID: 21964 RVA: 0x000E370C File Offset: 0x000E190C
	private void UpdateArmOffsetModifier(EBlendState state, float alpha, float blendInTimeRatio)
	{
		if (!this.ModifySettings.IsModifiedArmOffset && !this.ModifyArmOffset)
		{
			return;
		}
		this.TmpTargetArmOffset.DeepCopy(this.ModifySettings.ArmOffset);
		float num = alpha;
		switch (state)
		{
		case EBlendState.BlendIn:
			if (this.ModifySettings.IsUseArmOffsetFloatCurve)
			{
				num = this.ModifySettings.ArmOffsetFloatCurve.GetCurrentValue(blendInTimeRatio);
			}
			Vector.Lerp(this.StartVirtualCamera.ArmOffset, this.TmpTargetArmOffset, (double)num, this.Camera.DesiredCamera.ArmOffset);
			break;
		case EBlendState.Loop:
			this.Camera.DesiredCamera.ArmOffset.DeepCopy(this.TmpTargetArmOffset);
			break;
		case EBlendState.BlendOut:
		{
			Vector to = Vector.Create((double)this.Camera.ArmOffsetX, (double)this.Camera.ArmOffsetY, (double)this.Camera.ArmOffsetZ);
			Vector.Lerp(this.TmpTargetArmOffset, to, (double)num, this.Camera.DesiredCamera.ArmOffset);
			break;
		}
		}
		this.Camera.IsModifiedCameraOffset = true;
	}

	// Token: 0x060055CD RID: 21965 RVA: 0x000E381C File Offset: 0x000E1A1C
	private unsafe void UpdateCameraOffsetModifier(EBlendState state, float alpha, float blendInTimeRatio)
	{
		if (!this.ModifySettings.IsModifiedCameraOffset && !this.ModifyCameraOffset)
		{
			return;
		}
		Vector vector = Vector.Create();
		if (this.ModifySettings.IsModifiedCameraOffset)
		{
			FVector value = this.ModifySettings.CameraOffsetEval.GetValue(this.ModifyElapsedTime);
			float num = this.ModifySettings.IsModifiedCameraOffsetX ? value.X : this.Camera.CameraOffsetX;
			float num2 = this.ModifySettings.IsModifiedCameraOffsetY ? value.Y : this.Camera.CameraOffsetY;
			float num3 = this.ModifySettings.IsModifiedCameraOffsetZ ? value.Z : this.Camera.CameraOffsetZ;
			vector.Set((double)num, (double)num2, (double)num3);
		}
		else
		{
			vector.X = (double)this.Camera.CameraOffsetX;
			vector.Y = (double)this.Camera.CameraOffsetY;
			vector.Z = (double)this.Camera.CameraOffsetZ;
		}
		if (this.ModifyCameraOffset)
		{
			FVector value2 = this.ModifySettings.CameraOffsetAdditionalEval.GetValue(this.ModifyElapsedTime);
			vector.X += (double)value2.X;
			vector.Y += (double)value2.Y;
			vector.Z += (double)value2.Z;
		}
		if (this.IsDebugCurveEval)
		{
			Vector cameraOffset = this.Camera.DesiredCamera.CameraOffset;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[CurveEval][CameraOffset]";
			<>y__InlineArray9<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray9<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("state", state);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("t", this.ModifyElapsedTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("alpha", alpha);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("targetX", vector.X);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("targetY", vector.Y);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("targetZ", vector.Z);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("desiredX", cameraOffset.X);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("desiredY", cameraOffset.Y);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 8) = new ValueTuple<string, object>("desiredZ", cameraOffset.Z);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 9));
		}
		float num4 = alpha;
		switch (state)
		{
		case EBlendState.BlendIn:
			if (this.ModifySettings.IsUseCameraOffsetFloatCurve)
			{
				num4 = this.ModifySettings.CameraOffsetFloatCurve.GetCurrentValue(blendInTimeRatio);
			}
			Vector.Lerp(this.StartVirtualCamera.CameraOffset, vector, (double)num4, this.Camera.DesiredCamera.CameraOffset);
			break;
		case EBlendState.Loop:
			this.Camera.DesiredCamera.CameraOffset.DeepCopy(vector);
			break;
		case EBlendState.BlendOut:
		{
			this.BlendOutData.SetBlendOutCameraOffset(vector);
			Vector to = Vector.Create((double)this.Camera.CameraOffsetX, (double)this.Camera.CameraOffsetY, (double)this.Camera.CameraOffsetZ);
			Vector.Lerp(this.BlendOutData.CameraOffset, to, (double)num4, this.Camera.DesiredCamera.CameraOffset);
			break;
		}
		}
		this.Camera.IsModifiedCameraOffset = true;
	}

	// Token: 0x060055CE RID: 21966 RVA: 0x000E3BC4 File Offset: 0x000E1DC4
	private void UpdateArmRotationModifier(EBlendState state, float alpha, float blendInTimeRatio)
	{
		this.TempTargetArmRotator.FromUeRotator(this.Camera.PlayerRotator);
		if (this.ModifyPlayerLocation && this.LookAtActor.HasValue)
		{
			OneOf<TsBaseCharacter, TsBaseVehicle> lookAtActor = this.LookAtActor;
			if (lookAtActor.IsT1)
			{
				TsBaseCharacter asT = lookAtActor.AsT1;
				if (asT != null)
				{
					CharacterActorComponent characterActorComponent = asT.CharacterActorComponent;
					if (characterActorComponent != null && characterActorComponent.Valid)
					{
						this.TempTargetArmRotator.FromUeRotator(this.LookAtActor.AsT1.CharacterActorComponent.ActorRotationProxy);
						goto IL_D0;
					}
				}
			}
			lookAtActor = this.LookAtActor;
			if (lookAtActor.IsT2)
			{
				TsBaseVehicle asT2 = lookAtActor.AsT2;
				if (asT2 != null)
				{
					VehicleActorComponent vehicleActorComponent = asT2.VehicleActorComponent;
					if (vehicleActorComponent != null && vehicleActorComponent.Valid)
					{
						this.TempTargetArmRotator.FromUeRotator(this.LookAtActor.AsT2.VehicleActorComponent.ActorRotationProxy);
					}
				}
			}
		}
		IL_D0:
		if (this.Camera.IsInNormalGravityMode())
		{
			this.TmpFinalRotator.DeepCopy(this.GetFinalArmRotation());
		}
		else
		{
			this.TmpFinalRotator.DeepCopy(this.GetFinalArmQuaternion());
		}
		this.TempTargetArmRotator.Quaternion(this.TmpQuat);
		this.Camera.GravityInverseQuat.Multiply(this.TmpQuat, this.TmpQuat2);
		this.TmpQuat2.Rotator(this.TmpRotator);
		this.TempTargetArmRotator.DeepCopy(this.TmpRotator);
		Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.TmpFinalRotator, this.Camera.GravityInverseQuat, this.TmpFinalRotatorInGravity);
		this.UpdateArmRotationPitchModifier(state, alpha, blendInTimeRatio, this.TempTargetArmRotator.Pitch, this.TmpFinalRotatorInGravity.Pitch);
		this.UpdateArmRotationYawModifier(state, alpha, blendInTimeRatio, this.TempTargetArmRotator.Yaw, this.TmpFinalRotatorInGravity.Yaw);
		this.UpdateArmRotationRollModifier(state, alpha, blendInTimeRatio, this.TempTargetArmRotator.Roll, this.TmpFinalRotatorInGravity.Roll);
	}

	// Token: 0x060055CF RID: 21967 RVA: 0x000E3DA4 File Offset: 0x000E1FA4
	private void UpdateArmRotationPitchModifier(EBlendState state, float alpha, float blendIntTimeRatio, float tempTargetArmRotatorPitch, float finalPitch)
	{
		if (this.Camera.IsModifiedArmRotationPitch || ((!this.ModifySettings.IsModifiedArmRotation || !this.ModifySettings.IsModifiedArmRotationPitch) && !this.ModifyArmRotationPitch) || (!this.ModifySettings.IsLockInput && this.HasInput))
		{
			return;
		}
		if (this.Camera.IsInNormalGravityMode())
		{
			this.TargetArmRotatorPitch = this.StartVirtualCamera.ArmRotation.Pitch;
		}
		else
		{
			this.TargetArmRotatorPitch = Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.StartVirtualCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator).Pitch;
		}
		this.PreparePitchTarget(tempTargetArmRotatorPitch);
		if (this.ModifyArmRotationPitch)
		{
			this.TargetArmRotatorPitch += this.GetTargetRotatorAdditional(ECameraRotationAxis.Pitch);
		}
		this.Camera.IsModifiedArmRotationPitch = (this.ModifySettings.IsModifiedArmRotationPitch || this.ModifyArmRotationPitch);
		float alpha2 = alpha;
		this.TmpRotator.DeepCopy(this.Camera.DesiredCamera.ArmRotation);
		this.TmpRotator.Quaternion(this.TmpQuat);
		switch (state)
		{
		case EBlendState.BlendIn:
		{
			if (this.ModifySettings.IsUseArmRotationFloatCurve)
			{
				alpha2 = this.ModifySettings.ArmRotationFloatCurve.GetCurrentValue(blendIntTimeRatio);
			}
			if (this.Camera.IsInNormalGravityMode())
			{
				this.Camera.DesiredCamera.ArmRotation.Pitch = Rotator.AxisLerp(this.StartVirtualCamera.ArmRotation.Pitch, this.TargetArmRotatorPitch, alpha2);
				return;
			}
			float pitch = Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.StartVirtualCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator).Pitch;
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
			this.TmpRotator2.Pitch = Rotator.AxisLerp(pitch, this.TargetArmRotatorPitch, alpha2);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
			return;
		}
		case EBlendState.Loop:
			if (this.Camera.IsInNormalGravityMode())
			{
				this.Camera.DesiredCamera.ArmRotation.Pitch = this.TargetArmRotatorPitch;
				return;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
			this.TmpRotator2.Pitch = this.TargetArmRotatorPitch;
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
			return;
		case EBlendState.BlendOut:
			this.BlendOutData.SetBlendOutArmRotationPitch(this.TargetArmRotatorPitch);
			if (this.Camera.IsInNormalGravityMode())
			{
				this.Camera.DesiredCamera.ArmRotation.Pitch = Rotator.AxisLerp(this.BlendOutData.ArmRotationPitch, finalPitch, alpha2);
				return;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
			this.TmpRotator2.Pitch = Rotator.AxisLerp(this.BlendOutData.ArmRotationPitch, finalPitch, alpha2);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
			return;
		default:
			return;
		}
	}

	// Token: 0x060055D0 RID: 21968 RVA: 0x000E4120 File Offset: 0x000E2320
	private void UpdateArmRotationYawModifier(EBlendState state, float alpha, float blendIntTimeRatio, float tempTargetArmRotatorYaw, float finalYaw)
	{
		if (this.Camera.IsModifiedArmRotationYaw || ((!this.ModifySettings.IsModifiedArmRotation || !this.ModifySettings.IsModifiedArmRotationYaw) && !this.ModifyArmRotationYaw) || (!this.ModifySettings.IsLockInput && this.HasInput))
		{
			return;
		}
		if (this.Camera.IsInNormalGravityMode())
		{
			this.TargetArmRotatorYaw = this.StartVirtualCamera.ArmRotation.Yaw;
		}
		else
		{
			this.TargetArmRotatorYaw = Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.StartVirtualCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator).Yaw;
		}
		this.PrepareYawTarget(tempTargetArmRotatorYaw);
		if (this.ModifyArmRotationYaw)
		{
			this.TargetArmRotatorYaw += this.GetTargetRotatorAdditional(ECameraRotationAxis.Yaw);
		}
		this.Camera.IsModifiedArmRotationYaw = (this.ModifySettings.IsModifiedArmRotationYaw || this.ModifyArmRotationYaw);
		float alpha2 = alpha;
		switch (state)
		{
		case EBlendState.BlendIn:
		{
			if (this.ModifySettings.IsUseArmRotationFloatCurve)
			{
				alpha2 = this.ModifySettings.ArmRotationFloatCurve.GetCurrentValue(blendIntTimeRatio);
			}
			if (this.Camera.IsInNormalGravityMode())
			{
				this.Camera.DesiredCamera.ArmRotation.Yaw = Rotator.AxisLerp(this.StartVirtualCamera.ArmRotation.Yaw, this.TargetArmRotatorYaw, alpha2);
				return;
			}
			float yaw = Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.StartVirtualCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator).Yaw;
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
			this.TmpRotator2.Yaw = Rotator.AxisLerp(yaw, this.TargetArmRotatorYaw, alpha2);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
			return;
		}
		case EBlendState.Loop:
			if (this.Camera.IsInNormalGravityMode())
			{
				this.Camera.DesiredCamera.ArmRotation.Yaw = this.TargetArmRotatorYaw;
				return;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
			this.TmpRotator2.Yaw = this.TargetArmRotatorYaw;
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
			return;
		case EBlendState.BlendOut:
			this.BlendOutData.SetBlendOutArmRotationYaw(this.TargetArmRotatorYaw);
			if (this.Camera.IsInNormalGravityMode())
			{
				this.Camera.DesiredCamera.ArmRotation.Yaw = Rotator.AxisLerp(this.BlendOutData.ArmRotationYaw, finalYaw, alpha2);
				return;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
			this.TmpRotator2.Yaw = Rotator.AxisLerp(this.BlendOutData.ArmRotationYaw, finalYaw, alpha2);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
			return;
		default:
			return;
		}
	}

	// Token: 0x060055D1 RID: 21969 RVA: 0x000E4470 File Offset: 0x000E2670
	private void UpdateArmRotationRollModifier(EBlendState state, float alpha, float blendIntTimeRatio, float tempTargetArmRotatorRoll, float finalRoll)
	{
		if (this.Camera.IsModifiedArmRotationRoll || ((!this.ModifySettings.IsModifiedArmRotation || !this.ModifySettings.IsModifiedArmRotationRoll) && !this.ModifyArmRotationRoll))
		{
			return;
		}
		if (this.Camera.IsInNormalGravityMode())
		{
			this.TargetArmRotatorRoll = this.StartVirtualCamera.ArmRotation.Roll;
		}
		else
		{
			this.TargetArmRotatorRoll = Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.StartVirtualCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator).Roll;
		}
		this.PrepareRollTarget(tempTargetArmRotatorRoll);
		if (this.ModifyArmRotationRoll)
		{
			this.TargetArmRotatorRoll += this.GetTargetRotatorAdditional(ECameraRotationAxis.Roll);
		}
		this.Camera.IsModifiedArmRotationRoll = (this.ModifySettings.IsModifiedArmRotationRoll || this.ModifyArmRotationRoll);
		float alpha2 = alpha;
		switch (state)
		{
		case EBlendState.BlendIn:
		{
			if (this.ModifySettings.IsUseArmRotationFloatCurve)
			{
				alpha2 = this.ModifySettings.ArmRotationFloatCurve.GetCurrentValue(blendIntTimeRatio);
			}
			if (this.Camera.IsInNormalGravityMode())
			{
				this.Camera.DesiredCamera.ArmRotation.Roll = Rotator.AxisLerp(this.StartVirtualCamera.ArmRotation.Roll, this.TargetArmRotatorRoll, alpha2);
				return;
			}
			float roll = Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.StartVirtualCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator).Roll;
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
			this.TmpRotator2.Roll = Rotator.AxisLerp(roll, this.TargetArmRotatorRoll, alpha2);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
			return;
		}
		case EBlendState.Loop:
			if (this.Camera.IsInNormalGravityMode())
			{
				this.Camera.DesiredCamera.ArmRotation.Roll = this.TargetArmRotatorRoll;
				return;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
			this.TmpRotator2.Roll = this.TargetArmRotatorRoll;
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
			return;
		case EBlendState.BlendOut:
			this.BlendOutData.SetBlendOutArmRotationRoll(this.TargetArmRotatorRoll);
			if (this.Camera.IsInNormalGravityMode())
			{
				this.Camera.DesiredCamera.ArmRotation.Roll = Rotator.AxisLerp(this.BlendOutData.ArmRotationRoll, finalRoll, alpha2);
				return;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
			this.TmpRotator2.Roll = Rotator.AxisLerp(this.BlendOutData.ArmRotationRoll, finalRoll, alpha2);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
			return;
		default:
			return;
		}
	}

	// Token: 0x060055D2 RID: 21970 RVA: 0x000E47AC File Offset: 0x000E29AC
	private void UpdateHasInput()
	{
		CharacterInputComponent characterInputComponent = this.Camera.CharacterInputComponent;
		if (characterInputComponent == null || !characterInputComponent.Valid)
		{
			return;
		}
		ValueTuple<float, float> cameraInput = this.Camera.CharacterInputComponent.GetCameraInput();
		float item = cameraInput.Item1;
		float item2 = cameraInput.Item2;
		if ((double)Math.Abs(item) > 0.0001 || (double)Math.Abs(item2) > 0.0001)
		{
			this.HasInput = true;
		}
	}

	// Token: 0x060055D3 RID: 21971 RVA: 0x000E4820 File Offset: 0x000E2A20
	private bool HasZoomInput()
	{
		CharacterInputComponent characterInputComponent = this.Camera.CharacterInputComponent;
		return characterInputComponent != null && characterInputComponent.Valid && !Singleton<MathUtils>.Instance.IsNearlyZero((double)this.Camera.CharacterInputComponent.GetZoomInput(), new double?(0.0001));
	}

	// Token: 0x060055D4 RID: 21972 RVA: 0x000E4878 File Offset: 0x000E2A78
	private Rotator GetFinalArmRotation()
	{
		if (this.ModifySettings.ResetFinalArmRotation)
		{
			if (this.ModifySettings.IsResetFinalArmRotationToSpecificPitch)
			{
				this.TmpFinalRotator.Pitch = this.ModifySettings.ResetFinalArmRotationToSpecificPitch;
			}
			else
			{
				this.TmpFinalRotator.Pitch = this.Camera.DesiredCamera.ArmRotation.Pitch;
			}
			if (this.ModifySettings.IsResetFinalArmRotationToSpecificYaw)
			{
				CameraUtility.GetCameraCharacterRotation(this.TmpRotator);
				this.TmpFinalRotator.Yaw = this.TmpRotator.Yaw + this.ModifySettings.ResetFinalArmRotationToSpecificYaw;
			}
			else
			{
				this.TmpFinalRotator.Yaw = this.Camera.DesiredCamera.ArmRotation.Yaw;
			}
			this.TmpFinalRotator.Roll = 0f;
			return this.TmpFinalRotator;
		}
		return this.FirstStartVirtualCamera.ArmRotation;
	}

	// Token: 0x060055D5 RID: 21973 RVA: 0x000E4958 File Offset: 0x000E2B58
	private Rotator GetFinalArmQuaternion()
	{
		this.TmpFinalRotator.Reset();
		this.TmpRotator.Reset();
		if (this.ModifySettings.ResetFinalArmRotation)
		{
			if (!this.ModifySettings.IsResetFinalArmRotationToSpecificPitch)
			{
				this.TmpFinalRotator.Pitch = this.Camera.DesiredCamera.ArmRotation.Pitch;
			}
			if (!this.ModifySettings.IsResetFinalArmRotationToSpecificYaw)
			{
				this.TmpFinalRotator.Yaw = this.Camera.DesiredCamera.ArmRotation.Yaw;
			}
			this.TmpFinalRotator.Roll = 0f;
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.TmpFinalRotator, this.Camera.GravityInverseQuat, this.TmpRotator2);
			if (this.ModifySettings.IsResetFinalArmRotationToSpecificPitch)
			{
				this.TmpRotator2.Pitch = this.ModifySettings.ResetFinalArmRotationToSpecificPitch;
			}
			if (this.ModifySettings.IsResetFinalArmRotationToSpecificYaw)
			{
				CameraUtility.GetCameraCharacterRotation(this.TmpRotator3);
				Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.TmpRotator3, this.Camera.GravityInverseQuat, this.TmpRotator4);
				this.TmpRotator2.Yaw = this.TmpRotator4.Yaw + this.ModifySettings.ResetFinalArmRotationToSpecificYaw;
			}
			this.TmpRotator2.Roll = 0f;
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.TmpFinalRotator);
			return this.TmpFinalRotator;
		}
		return this.FirstStartVirtualCamera.ArmRotation;
	}

	// Token: 0x060055D6 RID: 21974 RVA: 0x000E4ADA File Offset: 0x000E2CDA
	private float GetFinalArmLength()
	{
		if (this.ModifySettings.ResetFinalArmLength)
		{
			return this.Camera.DesiredCamera.ArmLength;
		}
		return this.FirstStartVirtualCamera.ArmLength;
	}

	// Token: 0x060055D7 RID: 21975 RVA: 0x000E4B08 File Offset: 0x000E2D08
	[NullableContext(2)]
	private float GetFinalZoomModifierArmLength(ModifyEndContext modifyEndContext = null)
	{
		if (modifyEndContext != null)
		{
			foreach (ResetFinalArmLengthToDynamicValueData resetFinalArmLengthToDynamicValueData in this.ModifySettings.ResetFinalArmLengthToDynamicValueList)
			{
				if (modifyEndContext.ArmLengthDynamicValueType == ECameraModifier_Settings_ArmLengthDynamicValueType.技能Id && resetFinalArmLengthToDynamicValueData.ArmLengthDynamicValueType == modifyEndContext.ArmLengthDynamicValueType && resetFinalArmLengthToDynamicValueData.SkillId == modifyEndContext.SkillId)
				{
					return resetFinalArmLengthToDynamicValueData.ArmLength;
				}
			}
		}
		if (this.ModifySettings.ResetFinalArmLength && this.ModifySettings.IsModifiedArmLength)
		{
			return Singleton<MathUtils>.Instance.Clamp(this.ModifySettings.IsResetFinalArmLengthToSpecificValue ? this.ModifySettings.ResetFinalArmLengthToSpecificValue : (this.ModifySettings.ArmLength + (this.ModifyArmLength ? this.ModifySettings.ArmLengthAdditional : 0f)), this.Camera.CurrentCamera.MinArmLength, this.Camera.CurrentCamera.MaxArmLength);
		}
		return Singleton<MathUtils>.Instance.Clamp(this.FirstStartVirtualCamera.ZoomModifier * this.Camera.GetArmLengthWithSetting(this.FirstStartVirtualCamera), this.Camera.CurrentCamera.MinArmLength, this.Camera.CurrentCamera.MaxArmLength);
	}

	// Token: 0x060055D8 RID: 21976 RVA: 0x000E4C5C File Offset: 0x000E2E5C
	private void UpdateFovModifier(EBlendState state, float alpha, float blendInTimeRatio)
	{
		if (!this.ModifyFov)
		{
			return;
		}
		float alpha2 = alpha;
		float num = this.ModifySettings.IsModifiedCameraFov ? this.ModifySettings.CameraFov : this.FirstStartVirtualCamera.Fov;
		switch (state)
		{
		case EBlendState.BlendIn:
			if (this.ModifySettings.IsUseFovFloatCurve)
			{
				alpha2 = this.ModifySettings.FovFloatCurve.GetCurrentValue(blendInTimeRatio);
			}
			this.Camera.DesiredCamera.Fov = Singleton<MathUtils>.Instance.Lerp(this.StartVirtualCamera.Fov, num, alpha2);
			break;
		case EBlendState.Loop:
			this.Camera.DesiredCamera.Fov = num;
			break;
		case EBlendState.BlendOut:
			this.Camera.DesiredCamera.Fov = Singleton<MathUtils>.Instance.Lerp(num, this.Camera.Fov, alpha2);
			break;
		}
		this.Camera.IsModifiedFov = true;
	}

	// Token: 0x060055D9 RID: 21977 RVA: 0x000E4D44 File Offset: 0x000E2F44
	private void UpdateLensModifier(EBlendState state, float alpha, float blendInTimeRatio)
	{
		if (!this.ModifyLens)
		{
			return;
		}
		float alpha2 = alpha;
		float? fStop = null;
		float value = 0f;
		SCameraModifier_Lens cameraLens = this.ModifySettings.CameraLens;
		switch (state)
		{
		case EBlendState.BlendIn:
			if (this.ModifySettings.IsUseLensFloatCurve)
			{
				alpha2 = this.ModifySettings.LensFloatCurve.GetCurrentValue(blendInTimeRatio);
			}
			fStop = new float?(Singleton<MathUtils>.Instance.Lerp(cameraLens.StartFStop, cameraLens.EndFStop, alpha2));
			value = Singleton<MathUtils>.Instance.Lerp(cameraLens.RadialBlurStartIntensity, cameraLens.RadialBlurEndIntensity, alpha2);
			break;
		case EBlendState.Loop:
			fStop = new float?(cameraLens.EndFStop);
			value = cameraLens.RadialBlurEndIntensity;
			break;
		case EBlendState.BlendOut:
			fStop = new float?(Singleton<MathUtils>.Instance.Lerp(cameraLens.EndFStop, cameraLens.StartFStop, alpha2));
			value = Singleton<MathUtils>.Instance.Lerp(cameraLens.RadialBlurEndIntensity, cameraLens.RadialBlurStartIntensity, alpha2);
			break;
		}
		this.Camera.ApplyDepthOfField(fStop, null, null, null);
		this.Camera.ApplyRadialBlur(new float?(value), new FVector2D?(cameraLens.RadialBlurCenter), new float?(cameraLens.RadialBlurRadius), new float?(cameraLens.RadialBlurHardness), new int?((int)cameraLens.RadialBlurPassNumber), new int?((int)cameraLens.RadialBlurSampleNumber));
	}

	// Token: 0x060055DA RID: 21978 RVA: 0x000E4EA8 File Offset: 0x000E30A8
	[NullableContext(2)]
	public void EndModify(bool withFadeOut, bool useFadeOutTime, ModifyEndContext modifyEndContext = null)
	{
		if (!this.IsModified)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Camera;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "EndModify";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("withFadeOut", withFadeOut);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.Priority = 0;
		this.Camera.CameraAdjustController.Unlock(this);
		this.Camera.CameraGuideController.Unlock(this);
		if (this.ModifySettings.OverrideCameraInput)
		{
			if (this.ModifyArmRotationPitch || (this.ModifySettings.IsModifiedArmRotation && this.ModifySettings.IsModifiedArmRotationPitch))
			{
				this.Camera.CameraInputController.UnlockArmRotationPitch(this);
			}
			if (this.ModifyArmRotationYaw || (this.ModifySettings.IsModifiedArmRotation && this.ModifySettings.IsModifiedArmRotationYaw))
			{
				this.Camera.CameraInputController.UnlockArmRotationYaw(this);
			}
			if (this.ModifyArmLength || this.ModifySettings.IsModifiedArmLength)
			{
				this.Camera.CameraInputController.UnlockArmLength(this);
			}
		}
		if (withFadeOut)
		{
			this.StartModifyFadeOut(useFadeOutTime, modifyEndContext);
		}
		else
		{
			this.EndModifyFadeOut(false);
		}
		this.ModifyMontage = null;
		this.ModifyAnimSequence = null;
		this.AnimOwner.Clear();
		UAnimInstance modifyAnimInstance = this.ModifyAnimInstance;
		if (modifyAnimInstance != null && modifyAnimInstance.IsValid())
		{
			this.ModifyAnimInstance.OnMontageStarted.Remove(this.OnMontageStarted);
			this.ModifyAnimInstance.OnMontageEnded.Remove(this.OnMontageEnded);
			this.ModifyAnimInstance.OnAllMontageInstancesEnded.Remove(this.OnAllMontageInstancesEnded);
			this.ModifyAnimInstance = null;
		}
		this.ModifyArmLength = false;
		this.ModifyArmOffset = false;
		if (this.ModifySettings.IsModifiedCameraOffset || this.ModifyCameraOffset)
		{
			this.ModifyCameraOffset = false;
		}
		if (this.ModifyArmRotation)
		{
			this.ModifyArmRotationPitch = false;
			this.ModifyArmRotationYaw = false;
			this.ModifyArmRotationRoll = false;
		}
		if (this.ModifyFov)
		{
			this.ModifyFov = false;
		}
		if (this.ModifyTag != null)
		{
			this.ModifyTag = null;
			this.IsModifyBlendingOut = false;
		}
		if (this.ModifyLens)
		{
			this.ModifyLens = false;
			this.Camera.ExitDepthOfField();
			this.Camera.ExitRadialBlur();
		}
		this.HasInput = false;
		this.ModifySettings = null;
		this.Camera.CameraInputController.Unlock(this);
		if (this.LookAtActor.HasValue)
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.CharOnRoleDead, this.OnLookAtEntityDead);
		}
		this.LookAtActor.Clear();
		Entity lookAtEntity = this.LookAtEntity;
		if (lookAtEntity != null && lookAtEntity.Valid && this.LookAtEntityIsVision())
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<EntityHandle, EntityHandle>(this.LookAtEntity, EEventName.VisionMorphEnd, this.OnVisionMorphEnd);
		}
		this.LookAtEntity = null;
		this.ModifyPlayerLocation = false;
		this.IsBreakPreviousPlayerLocationModify = false;
	}

	// Token: 0x060055DB RID: 21979 RVA: 0x000E5170 File Offset: 0x000E3370
	[NullableContext(2)]
	private void StartModifyFadeOut(bool useFadeOutTime = false, ModifyEndContext modifyEndContext = null)
	{
		this.ModifyFadeOutData.ModifyArmLength = (this.ModifySettings.IsModifiedArmLength || this.ModifyArmLength);
		if (this.ModifyFadeOutData.ModifyArmLength)
		{
			this.ModifyFadeOutData.StartArmLength = this.Camera.CurrentCamera.ArmLength;
			this.ModifyFadeOutData.ArmLength = this.GetFinalArmLength();
		}
		this.ModifyFadeOutData.ModifyZoomModifier = this.ModifyFadeOutData.ModifyArmLength;
		if (this.ModifyFadeOutData.ModifyZoomModifier)
		{
			this.ModifyFadeOutData.StartFinalArmLength = this.Camera.GetArmLengthWithSettingAndZoom(this.Camera.CurrentCamera, false);
			this.ModifyFadeOutData.FinalArmLength = this.GetFinalZoomModifierArmLength(modifyEndContext);
		}
		this.ModifyFadeOutData.ModifyArmOffset = (this.ModifySettings.IsModifiedArmOffset || this.ModifyArmOffset);
		if (this.ModifyFadeOutData.ModifyArmOffset)
		{
			this.ModifyFadeOutData.StartArmOffset = this.Camera.CurrentCamera.ArmOffset;
			this.ModifyFadeOutData.ArmOffset.DeepCopy(this.FirstStartVirtualCamera.ArmOffset);
		}
		Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.CurrentCamera.ArmRotation, this.Camera.GravityInverseQuat, this.FadeOutStartRotator);
		if (this.Camera.IsInNormalGravityMode())
		{
			this.TmpFinalRotator.DeepCopy(this.GetFinalArmRotation());
		}
		else
		{
			this.TmpFinalRotator.DeepCopy(this.GetFinalArmQuaternion());
		}
		Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.TmpFinalRotator, this.Camera.GravityInverseQuat, this.TmpFinalRotatorInGravity);
		this.ModifyFadeOutData.ModifyArmRotationPitch = ((this.ModifyArmRotationPitch || (this.ModifySettings.IsModifiedArmRotation && this.ModifySettings.IsModifiedArmRotationPitch)) && (this.ModifySettings.IsLockInput || !this.HasInput));
		if (this.ModifyFadeOutData.ModifyArmRotationPitch)
		{
			this.ModifyFadeOutData.StartArmRotationPitch = this.FadeOutStartRotator.Pitch;
			this.ModifyFadeOutData.ArmRotationPitch = this.TmpFinalRotatorInGravity.Pitch;
		}
		this.ModifyFadeOutData.ModifyArmRotationYaw = ((this.ModifyArmRotationYaw || (this.ModifySettings.IsModifiedArmRotation && this.ModifySettings.IsModifiedArmRotationYaw)) && (this.ModifySettings.IsLockInput || !this.HasInput));
		if (this.ModifyFadeOutData.ModifyArmRotationYaw)
		{
			this.ModifyFadeOutData.StartArmRotationYaw = this.FadeOutStartRotator.Yaw;
			this.ModifyFadeOutData.ArmRotationYaw = this.TmpFinalRotatorInGravity.Yaw;
		}
		this.ModifyFadeOutData.ModifyArmRotationRoll = ((this.ModifyArmRotationRoll || (this.ModifySettings.IsModifiedArmRotation && this.ModifySettings.IsModifiedArmRotationRoll)) && !Singleton<MathUtils>.Instance.IsNearlyZero((double)this.Camera.DesiredCamera.ArmRotation.Roll, new double?(0.0001)));
		if (this.ModifyFadeOutData.ModifyArmRotationRoll)
		{
			this.ModifyFadeOutData.StartArmRotationRoll = this.FadeOutStartRotator.Roll;
			this.ModifyFadeOutData.ArmRotationRoll = 0f;
		}
		this.ModifyFadeOutData.ModifyCameraOffset = (this.ModifySettings.IsModifiedCameraOffset || this.ModifyCameraOffset);
		if (this.ModifyFadeOutData.ModifyCameraOffset)
		{
			this.ModifyFadeOutData.StartCameraOffset.DeepCopy(this.Camera.CurrentCamera.CameraOffset);
		}
		this.ModifyFadeOutData.ModifyFov = this.ModifyFov;
		if (this.ModifyFadeOutData.ModifyFov)
		{
			this.ModifyFadeOutData.StartFov = this.Camera.CurrentCamera.Fov;
			this.ModifyFadeOutData.Fov = this.Camera.Fov;
		}
		this.ModifyFadeOutData.ModifyPlayerLocation = this.ModifyPlayerLocation;
		if (this.ModifyFadeOutData.ModifyPlayerLocation)
		{
			this.ModifyFadeOutData.StartPlayerLocation.DeepCopy(this.Camera.PlayerLocation);
			this.ModifyFadeOutData.PlayerLocation.DeepCopy(this.TmpPlayerLocation);
		}
		this.ModifyFadeOutData.ElapsedTime = 0f;
		this.ModifyFadeOutData.FadeOutTotalTime = this.ModifyFadeOutTime;
		this.ModifyFadeOutData.UseFadeOutTimeLerp = useFadeOutTime;
		this.ModifyFadeOutData.BlendOutCurve = this.ModifyBlendOutCurve;
		this.IsModifyFadeOut = (this.ModifyFadeOutData.ModifyArmLength || this.ModifyFadeOutData.ModifyArmOffset || this.ModifyFadeOutData.ModifyArmRotationPitch || this.ModifyFadeOutData.ModifyArmRotationYaw || this.ModifyFadeOutData.ModifyArmRotationRoll || this.ModifyFadeOutData.ModifyCameraOffset || this.ModifyFadeOutData.ModifyFov || this.ModifyFadeOutData.ModifyPlayerLocation);
		if (!this.IsModifyFadeOut)
		{
			this.Camera.ClearSuppressClearRoll(ESuppressClearRollFlag.CameraModify);
		}
	}

	// Token: 0x060055DC RID: 21980 RVA: 0x000E5658 File Offset: 0x000E3858
	public void EndModifyFadeOut(bool isRestoreToFinalValue = false)
	{
		if (isRestoreToFinalValue)
		{
			CameraFadeOutData modifyFadeOutData = this.ModifyFadeOutData;
			VirtualCamera desiredCamera = this.Camera.DesiredCamera;
			if (modifyFadeOutData.ModifyZoomModifier)
			{
				desiredCamera.ZoomModifier = modifyFadeOutData.FinalArmLength / this.Camera.GetArmLengthWithSetting(this.Camera.CurrentCamera);
				this.Camera.IsModifiedZoomModifier = true;
				this.Camera.IsModifiedArmLength = true;
			}
			if (modifyFadeOutData.ModifyArmOffset)
			{
				desiredCamera.ArmOffset = modifyFadeOutData.ArmOffset;
				this.Camera.IsModifiedArmOffset = true;
			}
			if (modifyFadeOutData.ModifyCameraOffset)
			{
				desiredCamera.CameraOffset.X = (double)this.Camera.CameraOffsetX;
				desiredCamera.CameraOffset.Y = (double)this.Camera.CameraOffsetY;
				desiredCamera.CameraOffset.Z = (double)this.Camera.CameraOffsetZ;
				this.Camera.IsModifiedCameraOffset = true;
			}
			if (modifyFadeOutData.ModifyArmRotationPitch)
			{
				if (this.Camera.IsInNormalGravityMode())
				{
					desiredCamera.ArmRotation.Pitch = modifyFadeOutData.ArmRotationPitch;
				}
				else
				{
					Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
					this.TmpRotator2.Pitch = modifyFadeOutData.ArmRotationPitch;
					Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
				}
			}
			if (modifyFadeOutData.ModifyArmRotationYaw)
			{
				if (this.Camera.IsInNormalGravityMode())
				{
					desiredCamera.ArmRotation.Yaw = modifyFadeOutData.ArmRotationYaw;
				}
				else
				{
					Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
					this.TmpRotator2.Yaw = modifyFadeOutData.ArmRotationYaw;
					Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
				}
			}
			if (modifyFadeOutData.ModifyArmRotationRoll)
			{
				if (this.Camera.IsInNormalGravityMode())
				{
					desiredCamera.ArmRotation.Roll = modifyFadeOutData.ArmRotationRoll;
				}
				else
				{
					Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
					this.TmpRotator2.Roll = modifyFadeOutData.ArmRotationRoll;
					Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
				}
			}
			if (modifyFadeOutData.ModifyFov)
			{
				desiredCamera.Fov = modifyFadeOutData.Fov;
				this.Camera.IsModifiedFov = true;
			}
		}
		this.IsModifyFadeOut = false;
		this.Camera.ClearSuppressClearRoll(ESuppressClearRollFlag.CameraModify);
		this.ModifyFadeOutData.ModifyArmLength = false;
		this.ModifyFadeOutData.ModifyArmOffset = false;
		this.ModifyFadeOutData.ModifyArmRotationPitch = false;
		this.ModifyFadeOutData.ModifyArmRotationYaw = false;
		this.ModifyFadeOutData.ModifyArmRotationRoll = false;
		this.ModifyFadeOutData.ModifyCameraOffset = false;
		this.ModifyFadeOutData.ModifyFov = false;
		this.ModifyFadeOutData.ModifyPlayerLocation = false;
		this.ModifyFadeOutData.BlendOutCurve = null;
		if (Singleton<EventSystem>.Instance.Has<ULevelSequence, AActor, ALevelSequenceActor, FTransformDouble, bool, bool, string>(EEventName.PlayCameraLevelSequence, this.OnPlayCameraLevelSequence))
		{
			Singleton<EventSystem>.Instance.Remove<ULevelSequence, AActor, ALevelSequenceActor, FTransformDouble, bool, bool, string>(EEventName.PlayCameraLevelSequence, this.OnPlayCameraLevelSequence);
		}
		if (Singleton<EventSystem>.Instance.Has<int, int, bool>(EEventName.CharBeforeSkill, this.OnCharBeforeUseSkill))
		{
			Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.CharBeforeSkill, this.OnCharBeforeUseSkill);
		}
	}

	// Token: 0x060055DD RID: 21981 RVA: 0x000E59EC File Offset: 0x000E3BEC
	private unsafe void UpdateModifyFadeOut(float deltaTime)
	{
		if (!this.IsModifyFadeOut)
		{
			return;
		}
		CameraFadeOutData modifyFadeOutData = this.ModifyFadeOutData;
		VirtualCamera currentCamera = this.Camera.CurrentCamera;
		VirtualCamera desiredCamera = this.Camera.DesiredCamera;
		this.ModifyFadeOutData.ElapsedTime += deltaTime;
		float alpha = (modifyFadeOutData.FadeOutTotalTime <= 0f) ? 1f : ((modifyFadeOutData.BlendOutCurve != null) ? modifyFadeOutData.BlendOutCurve.GetCurrentValue(modifyFadeOutData.ElapsedTime / modifyFadeOutData.FadeOutTotalTime) : Singleton<MathUtils>.Instance.Clamp(modifyFadeOutData.ElapsedTime / modifyFadeOutData.FadeOutTotalTime, 0f, 1f));
		if (modifyFadeOutData.ModifyZoomModifier)
		{
			if (this.Camera.IsModifiedZoomModifier)
			{
				modifyFadeOutData.ModifyZoomModifier = false;
				modifyFadeOutData.ModifyArmLength = false;
			}
			else
			{
				modifyFadeOutData.FinalArmLength = Singleton<MathUtils>.Instance.Clamp(modifyFadeOutData.FinalArmLength, this.Camera.CurrentCamera.MinArmLength, this.Camera.CurrentCamera.MaxArmLength);
				modifyFadeOutData.ModifyArmLength = false;
				CameraFadeOutData cameraFadeOutData = modifyFadeOutData;
				float item;
				if (!modifyFadeOutData.UseFadeOutTimeLerp)
				{
					ValueTuple<bool, float> valueTuple = this.FloatInterpTo(this.Camera.GetArmLengthWithSettingAndZoom(this.Camera.CurrentCamera, false), modifyFadeOutData.FinalArmLength, deltaTime, this.ModifyArmLengthLagSpeed, 1f);
					cameraFadeOutData.ModifyZoomModifier = valueTuple.Item1;
					item = valueTuple.Item2;
				}
				else
				{
					ValueTuple<bool, float> valueTuple = this.FloatLerp(modifyFadeOutData.StartFinalArmLength, modifyFadeOutData.FinalArmLength, alpha, 0.0001f);
					cameraFadeOutData.ModifyZoomModifier = valueTuple.Item1;
					item = valueTuple.Item2;
				}
				desiredCamera.ZoomModifier = item / this.Camera.GetArmLengthWithSetting(this.Camera.CurrentCamera);
				this.Camera.IsModifiedZoomModifier = true;
				this.Camera.IsModifiedArmLength = true;
				if ((double)this.Camera.DesiredCamera.ZoomModifier <= 1E-08 && this.EnableDebugFadeOutZoomModifier)
				{
					this.EnableDebugFadeOutZoomModifier = false;
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Camera;
					ELogAuthor author = ELogAuthor.LJM;
					string message = "[DebugZoomModifier UpdateModifyFadeOut]";
					<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DesiredCamera.ZoomModifier", this.Camera.DesiredCamera.ZoomModifier);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("finalArmLength", item);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ArmLength", this.Camera.GetArmLengthWithSetting(this.Camera.CurrentCamera));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Anim", this.ModifyAnimSequence);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("CameraConfigTags", this.Camera.CameraConfigController.GetCameraConfigTagsContent());
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
				}
			}
		}
		if (modifyFadeOutData.ModifyArmOffset)
		{
			if (this.Camera.IsModifiedArmOffset)
			{
				modifyFadeOutData.ModifyArmOffset = false;
			}
			else
			{
				CameraFadeOutData cameraFadeOutData = modifyFadeOutData;
				VirtualCamera virtualCamera = desiredCamera;
				if (!modifyFadeOutData.UseFadeOutTimeLerp)
				{
					ValueTuple<bool, Vector> valueTuple2 = this.VectorInterpTo(currentCamera.ArmOffset, modifyFadeOutData.ArmOffset, deltaTime, this.ModifyArmOffsetLagSpeed, 1f);
					cameraFadeOutData.ModifyArmOffset = valueTuple2.Item1;
					virtualCamera.ArmOffset = valueTuple2.Item2;
				}
				else
				{
					ValueTuple<bool, Vector> valueTuple2 = this.VectorLerp(modifyFadeOutData.StartArmOffset, modifyFadeOutData.ArmOffset, alpha, 1f);
					cameraFadeOutData.ModifyArmOffset = valueTuple2.Item1;
					virtualCamera.ArmOffset = valueTuple2.Item2;
				}
				this.Camera.IsModifiedArmOffset = true;
			}
		}
		if (modifyFadeOutData.ModifyCameraOffset)
		{
			if (this.Camera.IsModifiedCameraOffset)
			{
				modifyFadeOutData.ModifyCameraOffset = false;
			}
			else
			{
				modifyFadeOutData.CameraOffset.X = (double)this.Camera.CameraOffsetX;
				modifyFadeOutData.CameraOffset.Y = (double)this.Camera.CameraOffsetY;
				modifyFadeOutData.CameraOffset.Z = (double)this.Camera.CameraOffsetZ;
				CameraFadeOutData cameraFadeOutData = modifyFadeOutData;
				VirtualCamera virtualCamera = desiredCamera;
				if (!modifyFadeOutData.UseFadeOutTimeLerp)
				{
					ValueTuple<bool, Vector> valueTuple2 = this.VectorInterpTo(currentCamera.CameraOffset, modifyFadeOutData.CameraOffset, deltaTime, this.ModifyCameraOffsetLagSpeed, 1f);
					cameraFadeOutData.ModifyCameraOffset = valueTuple2.Item1;
					virtualCamera.CameraOffset = valueTuple2.Item2;
				}
				else
				{
					ValueTuple<bool, Vector> valueTuple2 = this.VectorLerp(modifyFadeOutData.StartCameraOffset, modifyFadeOutData.CameraOffset, alpha, 1f);
					cameraFadeOutData.ModifyCameraOffset = valueTuple2.Item1;
					virtualCamera.CameraOffset = valueTuple2.Item2;
				}
				this.Camera.IsModifiedCameraOffset = true;
			}
		}
		this.UpdateHasInput();
		Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.CurrentCamera.ArmRotation, this.Camera.GravityInverseQuat, this.FadeOutStartRotator);
		if (modifyFadeOutData.ModifyArmRotationPitch)
		{
			if (this.Camera.IsModifiedArmRotationPitch || this.HasInput)
			{
				modifyFadeOutData.ModifyArmRotationPitch = false;
			}
			else if (this.Camera.IsInNormalGravityMode())
			{
				CameraFadeOutData cameraFadeOutData = modifyFadeOutData;
				Rotator armRotation = desiredCamera.ArmRotation;
				if (!modifyFadeOutData.UseFadeOutTimeLerp)
				{
					ValueTuple<bool, float> valueTuple = this.RotationAxisInterpTo(currentCamera.ArmRotation.Pitch, modifyFadeOutData.ArmRotationPitch, deltaTime, this.ModifyArmRotationLagSpeed, 1f);
					cameraFadeOutData.ModifyArmRotationPitch = valueTuple.Item1;
					armRotation.Pitch = valueTuple.Item2;
				}
				else
				{
					ValueTuple<bool, float> valueTuple = this.RotationAxisLerp(modifyFadeOutData.StartArmRotationPitch, modifyFadeOutData.ArmRotationPitch, alpha, 1f);
					cameraFadeOutData.ModifyArmRotationPitch = valueTuple.Item1;
					armRotation.Pitch = valueTuple.Item2;
				}
			}
			else
			{
				CameraFadeOutData cameraFadeOutData = modifyFadeOutData;
				float item2;
				if (!modifyFadeOutData.UseFadeOutTimeLerp)
				{
					ValueTuple<bool, float> valueTuple = this.RotationAxisInterpTo(this.FadeOutStartRotator.Pitch, modifyFadeOutData.ArmRotationPitch, deltaTime, this.ModifyArmRotationLagSpeed, 1f);
					cameraFadeOutData.ModifyArmRotationPitch = valueTuple.Item1;
					item2 = valueTuple.Item2;
				}
				else
				{
					ValueTuple<bool, float> valueTuple = this.RotationAxisLerp(modifyFadeOutData.StartArmRotationPitch, modifyFadeOutData.ArmRotationPitch, alpha, 1f);
					cameraFadeOutData.ModifyArmRotationPitch = valueTuple.Item1;
					item2 = valueTuple.Item2;
				}
				Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
				this.TmpRotator2.Pitch = item2;
				Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
			}
		}
		if (modifyFadeOutData.ModifyArmRotationYaw)
		{
			if (this.Camera.IsModifiedArmRotationYaw || this.HasInput)
			{
				modifyFadeOutData.ModifyArmRotationYaw = false;
			}
			else if (this.Camera.IsInNormalGravityMode())
			{
				CameraFadeOutData cameraFadeOutData = modifyFadeOutData;
				Rotator armRotation = desiredCamera.ArmRotation;
				if (!modifyFadeOutData.UseFadeOutTimeLerp)
				{
					ValueTuple<bool, float> valueTuple = this.RotationAxisInterpTo(currentCamera.ArmRotation.Yaw, modifyFadeOutData.ArmRotationYaw, deltaTime, this.ModifyArmRotationLagSpeed, 1f);
					cameraFadeOutData.ModifyArmRotationYaw = valueTuple.Item1;
					armRotation.Yaw = valueTuple.Item2;
				}
				else
				{
					ValueTuple<bool, float> valueTuple = this.RotationAxisLerp(modifyFadeOutData.StartArmRotationYaw, modifyFadeOutData.ArmRotationYaw, alpha, 1f);
					cameraFadeOutData.ModifyArmRotationYaw = valueTuple.Item1;
					armRotation.Yaw = valueTuple.Item2;
				}
			}
			else
			{
				CameraFadeOutData cameraFadeOutData = modifyFadeOutData;
				float item3;
				if (!modifyFadeOutData.UseFadeOutTimeLerp)
				{
					ValueTuple<bool, float> valueTuple = this.RotationAxisInterpTo(this.FadeOutStartRotator.Yaw, modifyFadeOutData.ArmRotationYaw, deltaTime, this.ModifyArmRotationLagSpeed, 1f);
					cameraFadeOutData.ModifyArmRotationYaw = valueTuple.Item1;
					item3 = valueTuple.Item2;
				}
				else
				{
					ValueTuple<bool, float> valueTuple = this.RotationAxisLerp(modifyFadeOutData.StartArmRotationYaw, modifyFadeOutData.ArmRotationYaw, alpha, 1f);
					cameraFadeOutData.ModifyArmRotationYaw = valueTuple.Item1;
					item3 = valueTuple.Item2;
				}
				Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
				this.TmpRotator2.Yaw = item3;
				Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
			}
		}
		if (modifyFadeOutData.ModifyArmRotationRoll)
		{
			if (this.Camera.IsModifiedArmRotationRoll)
			{
				modifyFadeOutData.ModifyArmRotationRoll = false;
			}
			else if (this.Camera.IsInNormalGravityMode())
			{
				CameraFadeOutData cameraFadeOutData = modifyFadeOutData;
				Rotator armRotation = desiredCamera.ArmRotation;
				if (!modifyFadeOutData.UseFadeOutTimeLerp)
				{
					ValueTuple<bool, float> valueTuple = this.RotationAxisInterpTo(currentCamera.ArmRotation.Roll, modifyFadeOutData.ArmRotationRoll, deltaTime, this.ModifyArmRotationLagSpeed, 1f);
					cameraFadeOutData.ModifyArmRotationRoll = valueTuple.Item1;
					armRotation.Roll = valueTuple.Item2;
				}
				else
				{
					ValueTuple<bool, float> valueTuple = this.RotationAxisLerp(modifyFadeOutData.StartArmRotationRoll, modifyFadeOutData.ArmRotationRoll, alpha, 1f);
					cameraFadeOutData.ModifyArmRotationRoll = valueTuple.Item1;
					armRotation.Roll = valueTuple.Item2;
				}
			}
			else
			{
				CameraFadeOutData cameraFadeOutData = modifyFadeOutData;
				float item4;
				if (!modifyFadeOutData.UseFadeOutTimeLerp)
				{
					ValueTuple<bool, float> valueTuple = this.RotationAxisInterpTo(this.FadeOutStartRotator.Roll, modifyFadeOutData.ArmRotationRoll, deltaTime, this.ModifyArmRotationLagSpeed, 1f);
					cameraFadeOutData.ModifyArmRotationRoll = valueTuple.Item1;
					item4 = valueTuple.Item2;
				}
				else
				{
					ValueTuple<bool, float> valueTuple = this.RotationAxisLerp(modifyFadeOutData.StartArmRotationRoll, modifyFadeOutData.ArmRotationRoll, alpha, 1f);
					cameraFadeOutData.ModifyArmRotationRoll = valueTuple.Item1;
					item4 = valueTuple.Item2;
				}
				Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator2);
				this.TmpRotator2.Roll = item4;
				Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.Camera.GravityQuat, this.Camera.DesiredCamera.ArmRotation);
			}
		}
		if (this.IsDebugCurveEval)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Camera;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "[CurveEval][FadeOut] Modify FadeOut";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray6<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("desiredX", desiredCamera.CameraOffset.X);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("desiredY", desiredCamera.CameraOffset.Y);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("desiredZ", desiredCamera.CameraOffset.Z);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("desiredPitch", desiredCamera.ArmRotation.Pitch);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("desiredYaw", desiredCamera.ArmRotation.Yaw);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 5) = new ValueTuple<string, object>("desiredRoll", desiredCamera.ArmRotation.Roll);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 6));
		}
		if (modifyFadeOutData.ModifyFov)
		{
			if (this.Camera.IsModifiedFov)
			{
				modifyFadeOutData.ModifyFov = false;
			}
			else
			{
				CameraFadeOutData cameraFadeOutData = modifyFadeOutData;
				VirtualCamera virtualCamera = desiredCamera;
				if (!modifyFadeOutData.UseFadeOutTimeLerp)
				{
					ValueTuple<bool, float> valueTuple = this.FloatInterpTo(currentCamera.Fov, modifyFadeOutData.Fov, deltaTime, this.ModifyFovLagSpeed, 1f);
					cameraFadeOutData.ModifyFov = valueTuple.Item1;
					virtualCamera.Fov = valueTuple.Item2;
				}
				else
				{
					ValueTuple<bool, float> valueTuple = this.FloatLerp(modifyFadeOutData.StartFov, modifyFadeOutData.Fov, alpha, 1f);
					cameraFadeOutData.ModifyFov = valueTuple.Item1;
					virtualCamera.Fov = valueTuple.Item2;
				}
				this.Camera.IsModifiedFov = true;
			}
		}
		if (modifyFadeOutData.ModifyPlayerLocation)
		{
			CameraFadeOutData cameraFadeOutData = modifyFadeOutData;
			CameraFadeOutData cameraFadeOutData2 = modifyFadeOutData;
			if (!modifyFadeOutData.UseFadeOutTimeLerp)
			{
				ValueTuple<bool, Vector> valueTuple2 = this.VectorInterpTo(modifyFadeOutData.PlayerLocation, this.Camera.PlayerLocation, deltaTime, this.ModifyCameraOffsetLagSpeed, 1f);
				cameraFadeOutData.ModifyPlayerLocation = valueTuple2.Item1;
				cameraFadeOutData2.PlayerLocation = valueTuple2.Item2;
			}
			else
			{
				ValueTuple<bool, Vector> valueTuple2 = this.VectorLerp(modifyFadeOutData.PlayerLocation, this.Camera.PlayerLocation, alpha, 1f);
				cameraFadeOutData.ModifyPlayerLocation = valueTuple2.Item1;
				cameraFadeOutData2.PlayerLocation = valueTuple2.Item2;
			}
			this.Camera.PlayerLocation.DeepCopy(modifyFadeOutData.PlayerLocation);
		}
		if (modifyFadeOutData.UseFadeOutTimeLerp && modifyFadeOutData.ElapsedTime > modifyFadeOutData.FadeOutTotalTime)
		{
			this.IsModifyFadeOut = false;
			this.EndModifyFadeOut(false);
			return;
		}
		this.IsModifyFadeOut = (modifyFadeOutData.ModifyArmLength || modifyFadeOutData.ModifyArmOffset || modifyFadeOutData.ModifyZoomModifier || modifyFadeOutData.ModifyCameraOffset || modifyFadeOutData.ModifyArmRotationPitch || modifyFadeOutData.ModifyArmRotationYaw || modifyFadeOutData.ModifyArmRotationRoll || modifyFadeOutData.ModifyFov || modifyFadeOutData.ModifyPlayerLocation);
		if (!this.IsModifyFadeOut)
		{
			this.Camera.ClearSuppressClearRoll(ESuppressClearRollFlag.CameraModify);
		}
	}

	// Token: 0x060055DE RID: 21982 RVA: 0x000E66AC File Offset: 0x000E48AC
	[NullableContext(2)]
	private UAnimInstance GetModifyAnimInstance([Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<TsBaseCharacter, TsBaseVehicle> newLookAtActor, [Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<TsBaseCharacter, TsBaseVehicle> montageOwner)
	{
		Entity entity = null;
		if (newLookAtActor.HasValue)
		{
			if (newLookAtActor.IsT1)
			{
				entity = newLookAtActor.AsT1.GetEntityNoBlueprint();
			}
			else if (newLookAtActor.IsT2)
			{
				entity = newLookAtActor.AsT2.GetEntityNoBlueprint();
			}
		}
		else
		{
			Entity entity2 = montageOwner.HasValue ? (montageOwner.IsT1 ? montageOwner.AsT1.GetEntityNoBlueprint() : montageOwner.AsT2.GetEntityNoBlueprint()) : null;
			CreatureDataComponent creatureDataComponent = (entity2 != null) ? entity2.GetComponent<CreatureDataComponent>() : null;
			if ((creatureDataComponent != null && creatureDataComponent.IsVision()) || (creatureDataComponent != null && creatureDataComponent.IsMonster()))
			{
				entity = (montageOwner.IsT1 ? montageOwner.AsT1.GetEntityNoBlueprint() : montageOwner.AsT2.GetEntityNoBlueprint());
			}
			else
			{
				entity = this.Camera.CharacterEntityHandle.Entity;
			}
		}
		if (entity == null)
		{
			return null;
		}
		CharacterAnimationComponent component = entity.GetComponent<CharacterAnimationComponent>();
		if (component == null)
		{
			return null;
		}
		return component.MainAnimInstance;
	}

	// Token: 0x060055DF RID: 21983 RVA: 0x000E679C File Offset: 0x000E499C
	private bool LookAtEntityIsVision()
	{
		Entity lookAtEntity = this.LookAtEntity;
		CreatureDataComponent creatureDataComponent = (lookAtEntity != null) ? lookAtEntity.GetComponent<CreatureDataComponent>() : null;
		return creatureDataComponent != null && creatureDataComponent.Valid && creatureDataComponent.IsVision();
	}

	// Token: 0x060055E0 RID: 21984 RVA: 0x000E67D8 File Offset: 0x000E49D8
	[NullableContext(0)]
	public ValueTuple<bool, float> FloatInterpTo(float current, float target, float deltaTime, float interpSpeed, float nearValue)
	{
		double num = Singleton<MathUtils>.Instance.InterpTo((double)current, (double)target, (double)deltaTime, (double)interpSpeed);
		if (Math.Abs(current - target) < nearValue)
		{
			return new ValueTuple<bool, float>(false, target);
		}
		return new ValueTuple<bool, float>(true, (float)num);
	}

	// Token: 0x060055E1 RID: 21985 RVA: 0x000E6818 File Offset: 0x000E4A18
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<bool, Vector> VectorInterpTo(Vector current, Vector target, float deltaTime, float interpSpeed, float nearValue)
	{
		Vector vector = Vector.Create();
		Singleton<MathUtils>.Instance.VectorInterpTo(current, target, (double)deltaTime, (double)interpSpeed, vector);
		Vector vector2 = Vector.Create();
		current.Subtraction(target, vector2);
		if (vector2.GetAbsMax() < (double)nearValue)
		{
			vector.DeepCopy(target);
			return new ValueTuple<bool, Vector>(false, vector);
		}
		return new ValueTuple<bool, Vector>(true, vector);
	}

	// Token: 0x060055E2 RID: 21986 RVA: 0x000E6870 File Offset: 0x000E4A70
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<bool, Rotator> RotationInterpTo(Rotator current, Rotator target, float deltaTime, float interpSpeed, float nearValue)
	{
		Rotator rotator = Rotator.Create();
		Singleton<MathUtils>.Instance.RotatorInterpTo(current, target, (double)deltaTime, (double)interpSpeed, rotator);
		if (current.Equals(target, nearValue))
		{
			rotator.DeepCopy(target);
			return new ValueTuple<bool, Rotator>(false, rotator);
		}
		return new ValueTuple<bool, Rotator>(true, rotator);
	}

	// Token: 0x060055E3 RID: 21987 RVA: 0x000E68B8 File Offset: 0x000E4AB8
	[NullableContext(0)]
	public ValueTuple<bool, float> RotationAxisInterpTo(float current, float target, float deltaTime, float interpSpeed, float nearValue)
	{
		float item = Singleton<MathUtils>.Instance.RotatorAxisInterpTo(current, target, deltaTime, interpSpeed);
		if (Singleton<MathUtils>.Instance.IsAngleNearEqual((double)current, (double)target, (double)nearValue))
		{
			return new ValueTuple<bool, float>(false, item);
		}
		return new ValueTuple<bool, float>(true, item);
	}

	// Token: 0x060055E4 RID: 21988 RVA: 0x000E68F8 File Offset: 0x000E4AF8
	[NullableContext(0)]
	public ValueTuple<bool, float> FloatLerp(float current, float target, float alpha, float nearValue)
	{
		float item = Singleton<MathUtils>.Instance.Lerp(current, target, alpha);
		if (Math.Abs(current - target) < nearValue)
		{
			return new ValueTuple<bool, float>(false, target);
		}
		return new ValueTuple<bool, float>(true, item);
	}

	// Token: 0x060055E5 RID: 21989 RVA: 0x000E6930 File Offset: 0x000E4B30
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<bool, Vector> VectorLerp(Vector current, Vector target, float alpha, float nearValue)
	{
		Vector vector = Vector.Create();
		Vector.Lerp(current, target, (double)alpha, vector);
		if (current.Equals(target, (double)nearValue))
		{
			vector.DeepCopy(target);
			return new ValueTuple<bool, Vector>(false, vector);
		}
		return new ValueTuple<bool, Vector>(true, vector);
	}

	// Token: 0x060055E6 RID: 21990 RVA: 0x000E6970 File Offset: 0x000E4B70
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<bool, Rotator> RotationLerp(Rotator current, Rotator target, float alpha, float nearValue)
	{
		Rotator rotator = Rotator.Create();
		Rotator.Lerp(current, target, alpha, rotator);
		if (current.Equals(target, nearValue))
		{
			rotator.DeepCopy(target);
			return new ValueTuple<bool, Rotator>(false, rotator);
		}
		return new ValueTuple<bool, Rotator>(true, rotator);
	}

	// Token: 0x060055E7 RID: 21991 RVA: 0x000E69B0 File Offset: 0x000E4BB0
	[NullableContext(0)]
	public ValueTuple<bool, float> RotationAxisLerp(float current, float target, float alpha, float nearValue)
	{
		float item = Rotator.AxisLerp(current, target, alpha);
		if (Singleton<MathUtils>.Instance.IsAngleNearEqual((double)current, (double)target, (double)nearValue))
		{
			return new ValueTuple<bool, float>(false, item);
		}
		return new ValueTuple<bool, float>(true, item);
	}

	// Token: 0x060055E8 RID: 21992 RVA: 0x000E69E8 File Offset: 0x000E4BE8
	public void StopCameraModify(UAnimSequenceBase anim, int modifyInstance)
	{
		if (this.ModifyAnimSequence != anim || this.ModifyInstance != modifyInstance)
		{
			return;
		}
		this.EndModify(true, true, null);
	}

	// Token: 0x060055E9 RID: 21993 RVA: 0x000E6A06 File Offset: 0x000E4C06
	public void ForceStopModify(bool withFadeOut)
	{
		if (this.IsModified)
		{
			this.EndModify(withFadeOut, withFadeOut, null);
			return;
		}
		if (!withFadeOut && this.IsModifyFadeOut)
		{
			this.EndModifyFadeOut(false);
		}
	}

	// Token: 0x060055EA RID: 21994 RVA: 0x000E6A2C File Offset: 0x000E4C2C
	public float GetTargetRotatorAdditional(ECameraRotationAxis axis)
	{
		switch (axis)
		{
		case ECameraRotationAxis.Pitch:
			if (!this.ModifyArmRotationPitch)
			{
				return 0f;
			}
			return this.ModifySettings.ArmRotationAdditionalPitchEval.GetValue(this.ModifyElapsedTime);
		case ECameraRotationAxis.Yaw:
			if (!this.ModifyArmRotationYaw)
			{
				return 0f;
			}
			return this.ModifySettings.ArmRotationAdditionalYawEval.GetValue(this.ModifyElapsedTime);
		case ECameraRotationAxis.Roll:
			if (!this.ModifyArmRotationRoll)
			{
				return 0f;
			}
			return this.ModifySettings.ArmRotationAdditionalRollEval.GetValue(this.ModifyElapsedTime);
		default:
			return 0f;
		}
	}

	// Token: 0x060055EB RID: 21995 RVA: 0x000E6AC4 File Offset: 0x000E4CC4
	private unsafe void PreparePitchTarget(float tempTargetArmRotatorPitch)
	{
		if (!this.ModifySettings.IsModifiedArmRotationPitch)
		{
			return;
		}
		if (this.FirstModifyArmRotationPitch)
		{
			this.StartTargetArmRotator.Pitch = tempTargetArmRotatorPitch;
			this.FirstModifyArmRotationPitch = false;
		}
		this.TargetArmRotatorPitch = this.StartTargetArmRotator.Pitch + this.ModifySettings.ArmRotationPitchEval.GetValue(this.ModifyElapsedTime);
		if (this.IsDebugCurveEval)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[CurveEval][Rotation][Pitch]";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("t", this.ModifyElapsedTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("evalValue", this.ModifySettings.ArmRotationPitchEval.GetValue(this.ModifyElapsedTime));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("startPitch", this.StartTargetArmRotator.Pitch);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("targetPitch", this.TargetArmRotatorPitch);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
	}

	// Token: 0x060055EC RID: 21996 RVA: 0x000E6BF0 File Offset: 0x000E4DF0
	private unsafe void PrepareYawTarget(float tempTargetArmRotatorYaw)
	{
		if (!this.ModifySettings.IsModifiedArmRotationYaw)
		{
			return;
		}
		if (this.FirstModifyArmRotationYaw)
		{
			this.StartTargetArmRotator.Yaw = tempTargetArmRotatorYaw;
			this.FirstModifyArmRotationYaw = false;
		}
		this.TargetArmRotatorYaw = this.StartTargetArmRotator.Yaw + this.ModifySettings.ArmRotationYawEval.GetValue(this.ModifyElapsedTime);
		if (this.IsDebugCurveEval)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[CurveEval][Rotation][Yaw]";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("t", this.ModifyElapsedTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("evalValue", this.ModifySettings.ArmRotationYawEval.GetValue(this.ModifyElapsedTime));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("startYaw", this.StartTargetArmRotator.Yaw);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("targetYaw", this.TargetArmRotatorYaw);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
	}

	// Token: 0x060055ED RID: 21997 RVA: 0x000E6D1C File Offset: 0x000E4F1C
	private unsafe void PrepareRollTarget(float tempTargetArmRotatorRoll)
	{
		if (!this.ModifySettings.IsModifiedArmRotationRoll)
		{
			return;
		}
		if (this.FirstModifyArmRotationRoll)
		{
			this.StartTargetArmRotator.Roll = tempTargetArmRotatorRoll;
			this.FirstModifyArmRotationRoll = false;
		}
		this.TargetArmRotatorRoll = this.StartTargetArmRotator.Roll + this.ModifySettings.ArmRotationRollEval.GetValue(this.ModifyElapsedTime);
		if (this.IsDebugCurveEval)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[CurveEval][Rotation][Roll]";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("t", this.ModifyElapsedTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("evalValue", this.ModifySettings.ArmRotationRollEval.GetValue(this.ModifyElapsedTime));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("startRoll", this.StartTargetArmRotator.Roll);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("targetRoll", this.TargetArmRotatorRoll);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
	}

	// Token: 0x060055EE RID: 21998 RVA: 0x000E6E45 File Offset: 0x000E5045
	public override string GetConfigMapValue(int key)
	{
		return base.GetConfigMapValue((EFightCameraModify)key);
	}

	// Token: 0x060055EF RID: 21999 RVA: 0x000E6E4F File Offset: 0x000E504F
	public void LockCameraModify(EModifyInternalLockReason lockType, bool isFadeOut, bool isEndFadeOut)
	{
		this.ModifyLockHandler.Lock(lockType);
		if (this.IsModified && isFadeOut)
		{
			this.EndModify(true, true, null);
		}
		if (this.IsModifyFadeOut && isEndFadeOut)
		{
			this.EndModifyFadeOut(false);
		}
	}

	// Token: 0x060055F0 RID: 22000 RVA: 0x000E6E81 File Offset: 0x000E5081
	public void UnlockCameraModify(EModifyInternalLockReason lockType)
	{
		this.ModifyLockHandler.Unlock(lockType);
	}

	// Token: 0x060055F1 RID: 22001 RVA: 0x000E6E8F File Offset: 0x000E508F
	public bool IsCameraModifyLocked()
	{
		return !this.ModifyLockHandler.IsUnlocked();
	}

	// Token: 0x060055F2 RID: 22002 RVA: 0x000E6EA0 File Offset: 0x000E50A0
	[NullableContext(0)]
	public override bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 7:
				if (key == "TmpQuat")
				{
					value = this.TmpQuat;
					return true;
				}
				break;
			case 8:
			{
				char c = key[0];
				if (c <= 'I')
				{
					if (c != 'H')
					{
						if (c == 'I')
						{
							if (key == "IsAiming")
							{
								value = this.IsAiming;
								return true;
							}
						}
					}
					else if (key == "HasInput")
					{
						value = this.HasInput;
						return true;
					}
				}
				else if (c != 'P')
				{
					if (c == 'T')
					{
						if (key == "TmpQuat2")
						{
							value = this.TmpQuat2;
							return true;
						}
					}
				}
				else if (key == "Priority")
				{
					value = this.Priority;
					return true;
				}
				break;
			}
			case 9:
			{
				char c = key[6];
				if (c <= 'T')
				{
					if (c != 'F')
					{
						if (c == 'T')
						{
							if (key == "ModifyTag")
							{
								value = this.ModifyTag;
								return true;
							}
						}
					}
					else if (key == "ModifyFov")
					{
						value = this.ModifyFov;
						return true;
					}
				}
				else if (c != 'n')
				{
					if (c == 't')
					{
						if (key == "TmpVector")
						{
							value = this.TmpVector;
							return true;
						}
					}
				}
				else if (key == "AnimOwner")
				{
					value = this.AnimOwner;
					return true;
				}
				break;
			}
			case 10:
			{
				char c = key[2];
				if (c <= 'M')
				{
					if (c != 'A')
					{
						if (c == 'M')
						{
							if (key == "IsModified")
							{
								value = this.IsModified;
								return true;
							}
						}
					}
					else if (key == "IsActivate")
					{
						value = this.IsActivate;
						return true;
					}
				}
				else if (c != 'd')
				{
					if (c == 'p')
					{
						if (key == "TmpRotator")
						{
							value = this.TmpRotator;
							return true;
						}
					}
				}
				else if (key == "ModifyLens")
				{
					value = this.ModifyLens;
					return true;
				}
				break;
			}
			case 11:
			{
				char c = key[10];
				switch (c)
				{
				case '2':
					if (key == "TmpRotator2")
					{
						value = this.TmpRotator2;
						return true;
					}
					break;
				case '3':
					if (key == "TmpRotator3")
					{
						value = this.TmpRotator3;
						return true;
					}
					break;
				case '4':
					if (key == "TmpRotator4")
					{
						value = this.TmpRotator4;
						return true;
					}
					break;
				default:
					if (c == 'r')
					{
						if (key == "LookAtActor")
						{
							value = this.LookAtActor;
							return true;
						}
					}
					break;
				}
				break;
			}
			case 12:
			{
				char c = key[0];
				if (c != 'B')
				{
					if (c == 'L')
					{
						if (key == "LookAtEntity")
						{
							value = this.LookAtEntity;
							return true;
						}
					}
				}
				else if (key == "BlendOutData")
				{
					value = this.BlendOutData;
					return true;
				}
				break;
			}
			case 13:
				if (key == "ModifyMontage")
				{
					value = this.ModifyMontage;
					return true;
				}
				break;
			case 14:
			{
				char c = key[6];
				if (c <= 'I')
				{
					if (c != 'D')
					{
						if (c == 'I')
						{
							if (key == "ModifyInstance")
							{
								value = this.ModifyInstance;
								return true;
							}
						}
					}
					else if (key == "ModifyDuration")
					{
						value = this.ModifyDuration;
						return true;
					}
				}
				else if (c != 'L')
				{
					if (c != 'S')
					{
						if (c == 'a')
						{
							if (key == "OnMontageEnded")
							{
								value = this.OnMontageEnded;
								return true;
							}
						}
					}
					else if (key == "ModifySettings")
					{
						value = this.ModifySettings;
						return true;
					}
				}
				else if (key == "TargetLocation")
				{
					value = this.TargetLocation;
					return true;
				}
				break;
			}
			case 15:
			{
				char c = key[9];
				if (c <= 'O')
				{
					if (c != 'L')
					{
						if (c == 'O')
						{
							if (key == "ModifyArmOffset")
							{
								value = this.ModifyArmOffset;
								return true;
							}
						}
					}
					else if (key == "ModifyArmLength")
					{
						value = this.ModifyArmLength;
						return true;
					}
				}
				else if (c != 'a')
				{
					if (c != 'i')
					{
						if (c == 'o')
						{
							if (key == "TmpFinalRotator")
							{
								value = this.TmpFinalRotator;
								return true;
							}
						}
					}
					else if (key == "MaxAngleFixQuat")
					{
						value = this.MaxAngleFixQuat;
						return true;
					}
				}
				else if (key == "IsModifyFadeOut")
				{
					value = this.IsModifyFadeOut;
					return true;
				}
				break;
			}
			case 16:
			{
				char c = key[2];
				if (c <= 'D')
				{
					if (c != 'A')
					{
						if (c == 'D')
						{
							if (key == "IsDebugCurveEval")
							{
								value = this.IsDebugCurveEval;
								return true;
							}
						}
					}
					else if (key == "IsAimingInternal")
					{
						value = this.IsAimingInternal;
						return true;
					}
				}
				else if (c != 'M')
				{
					if (c != 'V')
					{
						if (c == 'd')
						{
							if (key == "ModifyEndContext")
							{
								value = this.ModifyEndContext;
								return true;
							}
						}
					}
					else if (key == "OnVisionMorphEnd")
					{
						value = this.OnVisionMorphEnd;
						return true;
					}
				}
				else if (key == "OnMontageStarted")
				{
					value = this.OnMontageStarted;
					return true;
				}
				break;
			}
			case 17:
			{
				char c = key[8];
				if (c <= 'l')
				{
					switch (c)
					{
					case 'a':
						if (key == "ModifyElapsedTime")
						{
							value = this.ModifyElapsedTime;
							return true;
						}
						break;
					case 'b':
						break;
					case 'c':
						if (key == "ModifyLockHandler")
						{
							value = this.ModifyLockHandler;
							return true;
						}
						break;
					case 'd':
						if (key == "ModifyFadeOutTime")
						{
							value = this.ModifyFadeOutTime;
							return true;
						}
						if (key == "ModifyFadeOutData")
						{
							value = this.ModifyFadeOutData;
							return true;
						}
						break;
					case 'e':
						if (key == "ModifyBlendInTime")
						{
							value = this.ModifyBlendInTime;
							return true;
						}
						break;
					default:
						if (c == 'l')
						{
							if (key == "CurrentBlendState")
							{
								value = this.CurrentBlendState;
								return true;
							}
						}
						break;
					}
				}
				else if (c != 'm')
				{
					switch (c)
					{
					case 'r':
						if (key == "TmpPlayerLocation")
						{
							value = this.TmpPlayerLocation;
							return true;
						}
						break;
					case 't':
						if (key == "LookAtActorSocket")
						{
							value = this.LookAtActorSocket;
							return true;
						}
						break;
					case 'v':
						if (key == "ModifyFovLagSpeed")
						{
							value = this.ModifyFovLagSpeed;
							return true;
						}
						break;
					}
				}
				else if (key == "ModifyArmRotation")
				{
					value = this.ModifyArmRotation;
					return true;
				}
				break;
			}
			case 18:
			{
				char c = key[11];
				if (c <= 'O')
				{
					if (c != 'I')
					{
						if (c == 'O')
						{
							if (key == "ModifyBlendOutTime")
							{
								value = this.ModifyBlendOutTime;
								return true;
							}
						}
					}
					else if (key == "ModifyBlendInCurve")
					{
						value = this.ModifyBlendInCurve;
						return true;
					}
				}
				else if (c != 'a')
				{
					if (c != 'e')
					{
						switch (c)
						{
						case 'i':
							if (key == "OnLookAtEntityDead")
							{
								value = this.OnLookAtEntityDead;
								return true;
							}
							break;
						case 'l':
							if (key == "StartVirtualCamera")
							{
								value = this.StartVirtualCamera;
								return true;
							}
							break;
						case 'm':
							if (key == "TmpTargetArmOffset")
							{
								value = this.TmpTargetArmOffset;
								return true;
							}
							break;
						case 'n':
							if (key == "ModifyAnimInstance")
							{
								value = this.ModifyAnimInstance;
								return true;
							}
							break;
						}
					}
					else if (key == "ModifyAnimSequence")
					{
						value = this.ModifyAnimSequence;
						return true;
					}
				}
				else if (key == "ModifyCameraOffset")
				{
					value = this.ModifyCameraOffset;
					return true;
				}
				break;
			}
			case 19:
			{
				char c = key[0];
				if (c <= 'I')
				{
					if (c != 'F')
					{
						if (c == 'I')
						{
							if (key == "IsModifyBlendingOut")
							{
								value = this.IsModifyBlendingOut;
								return true;
							}
						}
					}
					else if (key == "FadeOutStartRotator")
					{
						value = this.FadeOutStartRotator;
						return true;
					}
				}
				else if (c != 'M')
				{
					if (c == 'T')
					{
						if (key == "TargetArmRotatorYaw")
						{
							value = this.TargetArmRotatorYaw;
							return true;
						}
					}
				}
				else if (key == "ModifyBlendOutCurve")
				{
					value = this.ModifyBlendOutCurve;
					return true;
				}
				break;
			}
			case 20:
			{
				char c = key[15];
				if (c <= 'a')
				{
					if (c != 'S')
					{
						if (c == 'a')
						{
							if (key == "ModifyPlayerLocation")
							{
								value = this.ModifyPlayerLocation;
								return true;
							}
						}
					}
					else if (key == "OnCharBeforeUseSkill")
					{
						value = this.OnCharBeforeUseSkill;
						return true;
					}
				}
				else if (c != 'o')
				{
					if (c != 'r')
					{
						if (c == 't')
						{
							if (key == "TempTargetArmRotator")
							{
								value = this.TempTargetArmRotator;
								return true;
							}
						}
					}
					else if (key == "TargetArmRotatorRoll")
					{
						value = this.TargetArmRotatorRoll;
						return true;
					}
				}
				else if (key == "ModifyArmRotationYaw")
				{
					value = this.ModifyArmRotationYaw;
					return true;
				}
				break;
			}
			case 21:
			{
				char c = key[0];
				if (c != 'M')
				{
					if (c != 'S')
					{
						if (c == 'T')
						{
							if (key == "TargetArmRotatorPitch")
							{
								value = this.TargetArmRotatorPitch;
								return true;
							}
						}
					}
					else if (key == "StartTargetArmRotator")
					{
						value = this.StartTargetArmRotator;
						return true;
					}
				}
				else if (key == "ModifyArmRotationRoll")
				{
					value = this.ModifyArmRotationRoll;
					return true;
				}
				break;
			}
			case 22:
				if (key == "ModifyArmRotationPitch")
				{
					value = this.ModifyArmRotationPitch;
					return true;
				}
				break;
			case 23:
			{
				char c = key[9];
				if (c != 'L')
				{
					if (c != 'O')
					{
						if (c == 't')
						{
							if (key == "FirstStartVirtualCamera")
							{
								value = this.FirstStartVirtualCamera;
								return true;
							}
						}
					}
					else if (key == "ModifyArmOffsetLagSpeed")
					{
						value = this.ModifyArmOffsetLagSpeed;
						return true;
					}
				}
				else if (key == "ModifyArmLengthLagSpeed")
				{
					value = this.ModifyArmLengthLagSpeed;
					return true;
				}
				break;
			}
			case 24:
			{
				char c = key[0];
				if (c != 'S')
				{
					if (c == 'T')
					{
						if (key == "TmpFinalRotatorInGravity")
						{
							value = this.TmpFinalRotatorInGravity;
							return true;
						}
					}
				}
				else if (key == "StartAutoCameraArmOffset")
				{
					value = this.StartAutoCameraArmOffset;
					return true;
				}
				break;
			}
			case 25:
			{
				char c = key[0];
				if (c != 'F')
				{
					if (c != 'M')
					{
						if (c == 'O')
						{
							if (key == "OnPlayCameraLevelSequence")
							{
								value = this.OnPlayCameraLevelSequence;
								return true;
							}
						}
					}
					else if (key == "ModifyArmRotationLagSpeed")
					{
						value = this.ModifyArmRotationLagSpeed;
						return true;
					}
				}
				else if (key == "FirstModifyArmRotationYaw")
				{
					value = this.FirstModifyArmRotationYaw;
					return true;
				}
				break;
			}
			case 26:
			{
				char c = key[0];
				if (c != 'F')
				{
					if (c != 'M')
					{
						if (c == 'O')
						{
							if (key == "OnAllMontageInstancesEnded")
							{
								value = this.OnAllMontageInstancesEnded;
								return true;
							}
						}
					}
					else if (key == "ModifyCameraOffsetLagSpeed")
					{
						value = this.ModifyCameraOffsetLagSpeed;
						return true;
					}
				}
				else if (key == "FirstModifyArmRotationRoll")
				{
					value = this.FirstModifyArmRotationRoll;
					return true;
				}
				break;
			}
			case 27:
				if (key == "FirstModifyArmRotationPitch")
				{
					value = this.FirstModifyArmRotationPitch;
					return true;
				}
				break;
			case 29:
				if (key == "EnableDebugModifyZoomModifier")
				{
					value = this.EnableDebugModifyZoomModifier;
					return true;
				}
				break;
			case 30:
				if (key == "EnableDebugFadeOutZoomModifier")
				{
					value = this.EnableDebugFadeOutZoomModifier;
					return true;
				}
				break;
			case 32:
				if (key == "StartAutoCameraArmLengthAddition")
				{
					value = this.StartAutoCameraArmLengthAddition;
					return true;
				}
				break;
			case 35:
				if (key == "IsBreakPreviousPlayerLocationModify")
				{
					value = this.IsBreakPreviousPlayerLocationModify;
					return true;
				}
				break;
			}
		}
		return base.TryGetMember(key, out value);
	}

	// Token: 0x060055F3 RID: 22003 RVA: 0x000E7D98 File Offset: 0x000E5F98
	[NullableContext(0)]
	public override void SetMember(string key, object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 8:
			{
				char c = key[0];
				if (c != 'H')
				{
					if (c != 'I')
					{
						if (c == 'P')
						{
							if (key == "Priority")
							{
								int num2;
								if (value is double)
								{
									double num = (double)value;
									num2 = (int)num;
								}
								else if (value is float)
								{
									float num3 = (float)value;
									num2 = (int)num3;
								}
								else if (value is int)
								{
									int num4 = (int)value;
									num2 = num4;
								}
								else if (value is long)
								{
									long num5 = (long)value;
									num2 = (int)num5;
								}
								else
								{
									num2 = (int)value;
								}
								this.Priority = num2;
								return;
							}
						}
					}
					else if (key == "IsAiming")
					{
						this.IsAiming = (bool)value;
						return;
					}
				}
				else if (key == "HasInput")
				{
					this.HasInput = (bool)value;
					return;
				}
				break;
			}
			case 9:
			{
				char c = key[6];
				if (c != 'F')
				{
					if (c != 'T')
					{
						if (c == 'n')
						{
							if (key == "AnimOwner")
							{
								this.AnimOwner = (OneOf<TsBaseCharacter, TsBaseVehicle>)value;
								return;
							}
						}
					}
					else if (key == "ModifyTag")
					{
						this.ModifyTag = (FGameplayTag?)value;
						return;
					}
				}
				else if (key == "ModifyFov")
				{
					this.ModifyFov = (bool)value;
					return;
				}
				break;
			}
			case 10:
				if (key == "ModifyLens")
				{
					this.ModifyLens = (bool)value;
					return;
				}
				break;
			case 11:
				if (key == "LookAtActor")
				{
					this.LookAtActor = (OneOf<TsBaseCharacter, TsBaseVehicle>)value;
					return;
				}
				break;
			case 12:
				if (key == "LookAtEntity")
				{
					this.LookAtEntity = (Entity)value;
					return;
				}
				break;
			case 13:
				if (key == "ModifyMontage")
				{
					this.ModifyMontage = (UAnimMontage)value;
					return;
				}
				break;
			case 14:
			{
				char c = key[6];
				if (c != 'D')
				{
					if (c != 'I')
					{
						if (c == 'S')
						{
							if (key == "ModifySettings")
							{
								this.ModifySettings = (CameraModify)value;
								return;
							}
						}
					}
					else if (key == "ModifyInstance")
					{
						int num2;
						if (value is double)
						{
							double num6 = (double)value;
							num2 = (int)num6;
						}
						else if (value is float)
						{
							float num7 = (float)value;
							num2 = (int)num7;
						}
						else if (value is int)
						{
							int num8 = (int)value;
							num2 = num8;
						}
						else if (value is long)
						{
							long num9 = (long)value;
							num2 = (int)num9;
						}
						else
						{
							num2 = (int)value;
						}
						this.ModifyInstance = num2;
						return;
					}
				}
				else if (key == "ModifyDuration")
				{
					float num11;
					if (value is double)
					{
						double num10 = (double)value;
						num11 = (float)num10;
					}
					else if (value is float)
					{
						float num12 = (float)value;
						num11 = num12;
					}
					else if (value is int)
					{
						int num13 = (int)value;
						num11 = (float)num13;
					}
					else if (value is long)
					{
						long num14 = (long)value;
						num11 = (float)num14;
					}
					else
					{
						num11 = (float)value;
					}
					this.ModifyDuration = num11;
					return;
				}
				break;
			}
			case 15:
			{
				char c = key[9];
				if (c != 'L')
				{
					if (c != 'O')
					{
						if (c == 'a')
						{
							if (key == "IsModifyFadeOut")
							{
								this.IsModifyFadeOut = (bool)value;
								return;
							}
						}
					}
					else if (key == "ModifyArmOffset")
					{
						this.ModifyArmOffset = (bool)value;
						return;
					}
				}
				else if (key == "ModifyArmLength")
				{
					this.ModifyArmLength = (bool)value;
					return;
				}
				break;
			}
			case 16:
			{
				char c = key[2];
				if (c != 'A')
				{
					if (c == 'D')
					{
						if (key == "IsDebugCurveEval")
						{
							this.IsDebugCurveEval = (bool)value;
							return;
						}
					}
				}
				else if (key == "IsAimingInternal")
				{
					this.IsAimingInternal = (bool)value;
					return;
				}
				break;
			}
			case 17:
			{
				char c = key[8];
				if (c <= 'l')
				{
					switch (c)
					{
					case 'a':
						if (key == "ModifyElapsedTime")
						{
							float num11;
							if (value is double)
							{
								double num15 = (double)value;
								num11 = (float)num15;
							}
							else if (value is float)
							{
								float num16 = (float)value;
								num11 = num16;
							}
							else if (value is int)
							{
								int num17 = (int)value;
								num11 = (float)num17;
							}
							else if (value is long)
							{
								long num18 = (long)value;
								num11 = (float)num18;
							}
							else
							{
								num11 = (float)value;
							}
							this.ModifyElapsedTime = num11;
							return;
						}
						break;
					case 'b':
					case 'c':
						break;
					case 'd':
						if (key == "ModifyFadeOutTime")
						{
							float num11;
							if (value is double)
							{
								double num19 = (double)value;
								num11 = (float)num19;
							}
							else if (value is float)
							{
								float num20 = (float)value;
								num11 = num20;
							}
							else if (value is int)
							{
								int num21 = (int)value;
								num11 = (float)num21;
							}
							else if (value is long)
							{
								long num22 = (long)value;
								num11 = (float)num22;
							}
							else
							{
								num11 = (float)value;
							}
							this.ModifyFadeOutTime = num11;
							return;
						}
						break;
					case 'e':
						if (key == "ModifyBlendInTime")
						{
							float num11;
							if (value is double)
							{
								double num23 = (double)value;
								num11 = (float)num23;
							}
							else if (value is float)
							{
								float num24 = (float)value;
								num11 = num24;
							}
							else if (value is int)
							{
								int num25 = (int)value;
								num11 = (float)num25;
							}
							else if (value is long)
							{
								long num26 = (long)value;
								num11 = (float)num26;
							}
							else
							{
								num11 = (float)value;
							}
							this.ModifyBlendInTime = num11;
							return;
						}
						break;
					default:
						if (c == 'l')
						{
							if (key == "CurrentBlendState")
							{
								this.CurrentBlendState = (EBlendState)value;
								return;
							}
						}
						break;
					}
				}
				else if (c != 't')
				{
					if (c == 'v')
					{
						if (key == "ModifyFovLagSpeed")
						{
							float num11;
							if (value is double)
							{
								double num27 = (double)value;
								num11 = (float)num27;
							}
							else if (value is float)
							{
								float num28 = (float)value;
								num11 = num28;
							}
							else if (value is int)
							{
								int num29 = (int)value;
								num11 = (float)num29;
							}
							else if (value is long)
							{
								long num30 = (long)value;
								num11 = (float)num30;
							}
							else
							{
								num11 = (float)value;
							}
							this.ModifyFovLagSpeed = num11;
							return;
						}
					}
				}
				else if (key == "LookAtActorSocket")
				{
					this.LookAtActorSocket = (string)value;
					return;
				}
				break;
			}
			case 18:
			{
				char c = key[11];
				if (c <= 'O')
				{
					if (c != 'I')
					{
						if (c == 'O')
						{
							if (key == "ModifyBlendOutTime")
							{
								float num11;
								if (value is double)
								{
									double num31 = (double)value;
									num11 = (float)num31;
								}
								else if (value is float)
								{
									float num32 = (float)value;
									num11 = num32;
								}
								else if (value is int)
								{
									int num33 = (int)value;
									num11 = (float)num33;
								}
								else if (value is long)
								{
									long num34 = (long)value;
									num11 = (float)num34;
								}
								else
								{
									num11 = (float)value;
								}
								this.ModifyBlendOutTime = num11;
								return;
							}
						}
					}
					else if (key == "ModifyBlendInCurve")
					{
						this.ModifyBlendInCurve = (CurveBase)value;
						return;
					}
				}
				else if (c != 'a')
				{
					if (c != 'e')
					{
						if (c == 'n')
						{
							if (key == "ModifyAnimInstance")
							{
								this.ModifyAnimInstance = (UAnimInstance)value;
								return;
							}
						}
					}
					else if (key == "ModifyAnimSequence")
					{
						this.ModifyAnimSequence = (UAnimSequenceBase)value;
						return;
					}
				}
				else if (key == "ModifyCameraOffset")
				{
					this.ModifyCameraOffset = (bool)value;
					return;
				}
				break;
			}
			case 19:
			{
				char c = key[0];
				if (c != 'I')
				{
					if (c != 'M')
					{
						if (c == 'T')
						{
							if (key == "TargetArmRotatorYaw")
							{
								float num11;
								if (value is double)
								{
									double num35 = (double)value;
									num11 = (float)num35;
								}
								else if (value is float)
								{
									float num36 = (float)value;
									num11 = num36;
								}
								else if (value is int)
								{
									int num37 = (int)value;
									num11 = (float)num37;
								}
								else if (value is long)
								{
									long num38 = (long)value;
									num11 = (float)num38;
								}
								else
								{
									num11 = (float)value;
								}
								this.TargetArmRotatorYaw = num11;
								return;
							}
						}
					}
					else if (key == "ModifyBlendOutCurve")
					{
						this.ModifyBlendOutCurve = (CurveBase)value;
						return;
					}
				}
				else if (key == "IsModifyBlendingOut")
				{
					this.IsModifyBlendingOut = (bool)value;
					return;
				}
				break;
			}
			case 20:
			{
				char c = key[14];
				if (c != 'c')
				{
					if (c != 'i')
					{
						if (c == 'o')
						{
							if (key == "TargetArmRotatorRoll")
							{
								float num11;
								if (value is double)
								{
									double num39 = (double)value;
									num11 = (float)num39;
								}
								else if (value is float)
								{
									float num40 = (float)value;
									num11 = num40;
								}
								else if (value is int)
								{
									int num41 = (int)value;
									num11 = (float)num41;
								}
								else if (value is long)
								{
									long num42 = (long)value;
									num11 = (float)num42;
								}
								else
								{
									num11 = (float)value;
								}
								this.TargetArmRotatorRoll = num11;
								return;
							}
						}
					}
					else if (key == "ModifyArmRotationYaw")
					{
						this.ModifyArmRotationYaw = (bool)value;
						return;
					}
				}
				else if (key == "ModifyPlayerLocation")
				{
					this.ModifyPlayerLocation = (bool)value;
					return;
				}
				break;
			}
			case 21:
			{
				char c = key[0];
				if (c != 'M')
				{
					if (c == 'T')
					{
						if (key == "TargetArmRotatorPitch")
						{
							float num11;
							if (value is double)
							{
								double num43 = (double)value;
								num11 = (float)num43;
							}
							else if (value is float)
							{
								float num44 = (float)value;
								num11 = num44;
							}
							else if (value is int)
							{
								int num45 = (int)value;
								num11 = (float)num45;
							}
							else if (value is long)
							{
								long num46 = (long)value;
								num11 = (float)num46;
							}
							else
							{
								num11 = (float)value;
							}
							this.TargetArmRotatorPitch = num11;
							return;
						}
					}
				}
				else if (key == "ModifyArmRotationRoll")
				{
					this.ModifyArmRotationRoll = (bool)value;
					return;
				}
				break;
			}
			case 22:
				if (key == "ModifyArmRotationPitch")
				{
					this.ModifyArmRotationPitch = (bool)value;
					return;
				}
				break;
			case 23:
			{
				char c = key[9];
				if (c != 'L')
				{
					if (c == 'O')
					{
						if (key == "ModifyArmOffsetLagSpeed")
						{
							float num11;
							if (value is double)
							{
								double num47 = (double)value;
								num11 = (float)num47;
							}
							else if (value is float)
							{
								float num48 = (float)value;
								num11 = num48;
							}
							else if (value is int)
							{
								int num49 = (int)value;
								num11 = (float)num49;
							}
							else if (value is long)
							{
								long num50 = (long)value;
								num11 = (float)num50;
							}
							else
							{
								num11 = (float)value;
							}
							this.ModifyArmOffsetLagSpeed = num11;
							return;
						}
					}
				}
				else if (key == "ModifyArmLengthLagSpeed")
				{
					float num11;
					if (value is double)
					{
						double num51 = (double)value;
						num11 = (float)num51;
					}
					else if (value is float)
					{
						float num52 = (float)value;
						num11 = num52;
					}
					else if (value is int)
					{
						int num53 = (int)value;
						num11 = (float)num53;
					}
					else if (value is long)
					{
						long num54 = (long)value;
						num11 = (float)num54;
					}
					else
					{
						num11 = (float)value;
					}
					this.ModifyArmLengthLagSpeed = num11;
					return;
				}
				break;
			}
			case 25:
			{
				char c = key[0];
				if (c != 'F')
				{
					if (c == 'M')
					{
						if (key == "ModifyArmRotationLagSpeed")
						{
							float num11;
							if (value is double)
							{
								double num55 = (double)value;
								num11 = (float)num55;
							}
							else if (value is float)
							{
								float num56 = (float)value;
								num11 = num56;
							}
							else if (value is int)
							{
								int num57 = (int)value;
								num11 = (float)num57;
							}
							else if (value is long)
							{
								long num58 = (long)value;
								num11 = (float)num58;
							}
							else
							{
								num11 = (float)value;
							}
							this.ModifyArmRotationLagSpeed = num11;
							return;
						}
					}
				}
				else if (key == "FirstModifyArmRotationYaw")
				{
					this.FirstModifyArmRotationYaw = (bool)value;
					return;
				}
				break;
			}
			case 26:
			{
				char c = key[0];
				if (c != 'F')
				{
					if (c == 'M')
					{
						if (key == "ModifyCameraOffsetLagSpeed")
						{
							float num11;
							if (value is double)
							{
								double num59 = (double)value;
								num11 = (float)num59;
							}
							else if (value is float)
							{
								float num60 = (float)value;
								num11 = num60;
							}
							else if (value is int)
							{
								int num61 = (int)value;
								num11 = (float)num61;
							}
							else if (value is long)
							{
								long num62 = (long)value;
								num11 = (float)num62;
							}
							else
							{
								num11 = (float)value;
							}
							this.ModifyCameraOffsetLagSpeed = num11;
							return;
						}
					}
				}
				else if (key == "FirstModifyArmRotationRoll")
				{
					this.FirstModifyArmRotationRoll = (bool)value;
					return;
				}
				break;
			}
			case 27:
				if (key == "FirstModifyArmRotationPitch")
				{
					this.FirstModifyArmRotationPitch = (bool)value;
					return;
				}
				break;
			case 29:
				if (key == "EnableDebugModifyZoomModifier")
				{
					this.EnableDebugModifyZoomModifier = (bool)value;
					return;
				}
				break;
			case 30:
				if (key == "EnableDebugFadeOutZoomModifier")
				{
					this.EnableDebugFadeOutZoomModifier = (bool)value;
					return;
				}
				break;
			case 32:
				if (key == "StartAutoCameraArmLengthAddition")
				{
					float num11;
					if (value is double)
					{
						double num63 = (double)value;
						num11 = (float)num63;
					}
					else if (value is float)
					{
						float num64 = (float)value;
						num11 = num64;
					}
					else if (value is int)
					{
						int num65 = (int)value;
						num11 = (float)num65;
					}
					else if (value is long)
					{
						long num66 = (long)value;
						num11 = (float)num66;
					}
					else
					{
						num11 = (float)value;
					}
					this.StartAutoCameraArmLengthAddition = num11;
					return;
				}
				break;
			case 35:
				if (key == "IsBreakPreviousPlayerLocationModify")
				{
					this.IsBreakPreviousPlayerLocationModify = (bool)value;
					return;
				}
				break;
			}
		}
		base.SetMember(key, value);
	}

	// Token: 0x060055F4 RID: 22004 RVA: 0x000E8D25 File Offset: 0x000E6F25
	[NullableContext(0)]
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraModifyController.<MemberIter>d__149 <MemberIter>d__ = new CameraModifyController.<MemberIter>d__149(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x04001B5C RID: 7004
	private const int MODIFY_SMALL_LENGTH = 1;

	// Token: 0x04001B5D RID: 7005
	private const int INVALID_MODIFY_INSTANCE = -1;

	// Token: 0x04001B5E RID: 7006
	[StaticVariableRuleIgnore]
	private static readonly int BanForcePlayModify = GameplayTagDefine.EGameplayTagId["功能.通用镜头.屏蔽modify强制生效"];

	// Token: 0x04001B5F RID: 7007
	public float ModifyArmLengthLagSpeed;

	// Token: 0x04001B60 RID: 7008
	public float ModifyArmOffsetLagSpeed;

	// Token: 0x04001B61 RID: 7009
	public float ModifyCameraOffsetLagSpeed;

	// Token: 0x04001B62 RID: 7010
	public float ModifyArmRotationLagSpeed;

	// Token: 0x04001B63 RID: 7011
	public float ModifyFovLagSpeed;

	// Token: 0x04001B64 RID: 7012
	public int ModifyInstance;

	// Token: 0x04001B65 RID: 7013
	private float ModifyElapsedTime;

	// Token: 0x04001B66 RID: 7014
	private FGameplayTag? ModifyTag;

	// Token: 0x04001B67 RID: 7015
	private float ModifyDuration;

	// Token: 0x04001B68 RID: 7016
	private float ModifyBlendInTime;

	// Token: 0x04001B69 RID: 7017
	private float ModifyBlendOutTime;

	// Token: 0x04001B6A RID: 7018
	private float ModifyFadeOutTime;

	// Token: 0x04001B6B RID: 7019
	private bool IsBreakPreviousPlayerLocationModify;

	// Token: 0x04001B6C RID: 7020
	[Nullable(2)]
	private CurveBase ModifyBlendInCurve;

	// Token: 0x04001B6D RID: 7021
	[Nullable(2)]
	private CurveBase ModifyBlendOutCurve;

	// Token: 0x04001B6E RID: 7022
	private bool IsModifyBlendingOut;

	// Token: 0x04001B6F RID: 7023
	public bool IsModifyFadeOut;

	// Token: 0x04001B70 RID: 7024
	public EBlendState CurrentBlendState;

	// Token: 0x04001B71 RID: 7025
	public readonly CameraFadeOutData ModifyFadeOutData = new CameraFadeOutData();

	// Token: 0x04001B72 RID: 7026
	[Nullable(2)]
	public CameraModify ModifySettings;

	// Token: 0x04001B73 RID: 7027
	[Nullable(2)]
	private UAnimSequenceBase ModifyAnimSequence;

	// Token: 0x04001B74 RID: 7028
	[Nullable(2)]
	public UAnimMontage ModifyMontage;

	// Token: 0x04001B75 RID: 7029
	[Nullable(2)]
	private UAnimInstance ModifyAnimInstance;

	// Token: 0x04001B76 RID: 7030
	public bool ModifyArmLength;

	// Token: 0x04001B77 RID: 7031
	public bool ModifyArmOffset;

	// Token: 0x04001B78 RID: 7032
	private bool ModifyCameraOffset;

	// Token: 0x04001B79 RID: 7033
	private bool ModifyArmRotationPitch;

	// Token: 0x04001B7A RID: 7034
	private bool ModifyArmRotationYaw;

	// Token: 0x04001B7B RID: 7035
	private bool ModifyArmRotationRoll;

	// Token: 0x04001B7C RID: 7036
	private bool ModifyPlayerLocation;

	// Token: 0x04001B7D RID: 7037
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private OneOf<TsBaseCharacter, TsBaseVehicle> AnimOwner;

	// Token: 0x04001B7E RID: 7038
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private OneOf<TsBaseCharacter, TsBaseVehicle> LookAtActor;

	// Token: 0x04001B7F RID: 7039
	[Nullable(2)]
	private Entity LookAtEntity;

	// Token: 0x04001B80 RID: 7040
	private string LookAtActorSocket = "";

	// Token: 0x04001B81 RID: 7041
	private readonly Vector TargetLocation = Vector.Create();

	// Token: 0x04001B82 RID: 7042
	private readonly Vector TmpPlayerLocation = Vector.Create();

	// Token: 0x04001B83 RID: 7043
	private bool ModifyFov;

	// Token: 0x04001B84 RID: 7044
	private bool ModifyLens;

	// Token: 0x04001B85 RID: 7045
	private bool HasInput;

	// Token: 0x04001B86 RID: 7046
	private bool FirstModifyArmRotationPitch = true;

	// Token: 0x04001B87 RID: 7047
	private bool FirstModifyArmRotationYaw = true;

	// Token: 0x04001B88 RID: 7048
	private bool FirstModifyArmRotationRoll = true;

	// Token: 0x04001B89 RID: 7049
	private readonly Quat MaxAngleFixQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001B8A RID: 7050
	private float TargetArmRotatorPitch;

	// Token: 0x04001B8B RID: 7051
	private float TargetArmRotatorYaw;

	// Token: 0x04001B8C RID: 7052
	private float TargetArmRotatorRoll;

	// Token: 0x04001B8D RID: 7053
	private readonly ModifyEndContext ModifyEndContext = new ModifyEndContext();

	// Token: 0x04001B8E RID: 7054
	private readonly Rotator TempTargetArmRotator = Rotator.Create();

	// Token: 0x04001B8F RID: 7055
	private readonly Rotator StartTargetArmRotator = Rotator.Create();

	// Token: 0x04001B90 RID: 7056
	private readonly Rotator FadeOutStartRotator = Rotator.Create();

	// Token: 0x04001B91 RID: 7057
	private readonly Vector TmpTargetArmOffset = Vector.Create();

	// Token: 0x04001B92 RID: 7058
	private readonly Rotator TmpFinalRotator = Rotator.Create();

	// Token: 0x04001B93 RID: 7059
	private readonly Rotator TmpFinalRotatorInGravity = Rotator.Create();

	// Token: 0x04001B94 RID: 7060
	private readonly VirtualCamera FirstStartVirtualCamera = new VirtualCamera();

	// Token: 0x04001B95 RID: 7061
	private readonly VirtualCamera StartVirtualCamera = new VirtualCamera();

	// Token: 0x04001B96 RID: 7062
	private float StartAutoCameraArmLengthAddition;

	// Token: 0x04001B97 RID: 7063
	private readonly Vector StartAutoCameraArmOffset = Vector.Create();

	// Token: 0x04001B98 RID: 7064
	private readonly Rotator TmpRotator = Rotator.Create();

	// Token: 0x04001B99 RID: 7065
	private readonly Rotator TmpRotator2 = Rotator.Create();

	// Token: 0x04001B9A RID: 7066
	private readonly Rotator TmpRotator3 = Rotator.Create();

	// Token: 0x04001B9B RID: 7067
	private readonly Rotator TmpRotator4 = Rotator.Create();

	// Token: 0x04001B9C RID: 7068
	private readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001B9D RID: 7069
	private readonly Quat TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001B9E RID: 7070
	private readonly Vector TmpVector = Vector.Create();

	// Token: 0x04001B9F RID: 7071
	private bool EnableDebugModifyZoomModifier = true;

	// Token: 0x04001BA0 RID: 7072
	private bool EnableDebugFadeOutZoomModifier = true;

	// Token: 0x04001BA1 RID: 7073
	public bool IsDebugCurveEval;

	// Token: 0x04001BA2 RID: 7074
	private readonly CameraBlendOutData BlendOutData = new CameraBlendOutData();

	// Token: 0x04001BA3 RID: 7075
	private readonly Action OnAllMontageInstancesEnded;

	// Token: 0x04001BA4 RID: 7076
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly Action<UAnimMontage, bool> OnMontageEnded;

	// Token: 0x04001BA5 RID: 7077
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly Action<UAnimMontage> OnMontageStarted;

	// Token: 0x04001BA6 RID: 7078
	private readonly Action<int> OnLookAtEntityDead;

	// Token: 0x04001BA7 RID: 7079
	[Nullable(new byte[]
	{
		1,
		2,
		2
	})]
	private readonly Action<EntityHandle, EntityHandle> OnVisionMorphEnd;

	// Token: 0x04001BA8 RID: 7080
	private readonly Action<ULevelSequence, AActor, ALevelSequenceActor, FTransformDouble, bool, bool, string> OnPlayCameraLevelSequence;

	// Token: 0x04001BA9 RID: 7081
	private readonly Action<int, int, bool> OnCharBeforeUseSkill;

	// Token: 0x04001BAA RID: 7082
	private bool IsAimingInternal;

	// Token: 0x04001BAB RID: 7083
	private readonly UniqueLockingHandler<EModifyInternalLockReason> ModifyLockHandler = new UniqueLockingHandler<EModifyInternalLockReason>();

	// Token: 0x04001BAC RID: 7084
	private int Priority;
}
