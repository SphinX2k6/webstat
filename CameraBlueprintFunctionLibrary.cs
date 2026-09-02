using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Data.Camera.CameraDebugTool;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DFE RID: 3582
[UClass("/Game/Aki/TypeScript/Game/Camera/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Camera/CameraBlueprintFunctionLibrary.CameraBlueprintFunctionLibrary_C")]
public class CameraBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x0600536C RID: 21356 RVA: 0x000C467F File Offset: 0x000C287F
	static CameraBlueprintFunctionLibrary()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CameraBlueprintFunctionLibrary.CreateStaticDefaultValue), new Action(CameraBlueprintFunctionLibrary.ResetStaticDefaultValue));
	}

	// Token: 0x170005A8 RID: 1448
	// (get) Token: 0x0600536D RID: 21357 RVA: 0x000C469E File Offset: 0x000C289E
	[Nullable(1)]
	private static Vector TmpVector
	{
		[NullableContext(1)]
		get
		{
			if (CameraBlueprintFunctionLibrary._tmpVectorInternal == null)
			{
				CameraBlueprintFunctionLibrary._tmpVectorInternal = Vector.Create();
			}
			return CameraBlueprintFunctionLibrary._tmpVectorInternal;
		}
	}

	// Token: 0x170005A9 RID: 1449
	// (get) Token: 0x0600536E RID: 21358 RVA: 0x000C46B6 File Offset: 0x000C28B6
	[Nullable(1)]
	private static Quat TmpQuat
	{
		[NullableContext(1)]
		get
		{
			if (CameraBlueprintFunctionLibrary._tmpQuatInternal == null)
			{
				CameraBlueprintFunctionLibrary._tmpQuatInternal = Quat.Create(0f, 0f, 0f, 1f);
			}
			return CameraBlueprintFunctionLibrary._tmpQuatInternal;
		}
	}

	// Token: 0x170005AA RID: 1450
	// (get) Token: 0x0600536F RID: 21359 RVA: 0x000C46E2 File Offset: 0x000C28E2
	[Nullable(1)]
	private static Vector2D TmpVector2D1
	{
		[NullableContext(1)]
		get
		{
			if (CameraBlueprintFunctionLibrary._tmpVector2D1Internal == null)
			{
				CameraBlueprintFunctionLibrary._tmpVector2D1Internal = Vector2D.Create();
			}
			return CameraBlueprintFunctionLibrary._tmpVector2D1Internal;
		}
	}

	// Token: 0x170005AB RID: 1451
	// (get) Token: 0x06005370 RID: 21360 RVA: 0x000C46FA File Offset: 0x000C28FA
	[Nullable(1)]
	private static Vector2D TmpVector2D2
	{
		[NullableContext(1)]
		get
		{
			if (CameraBlueprintFunctionLibrary._tmpVector2D2Internal == null)
			{
				CameraBlueprintFunctionLibrary._tmpVector2D2Internal = Vector2D.Create();
			}
			return CameraBlueprintFunctionLibrary._tmpVector2D2Internal;
		}
	}

	// Token: 0x06005371 RID: 21361 RVA: 0x000C4712 File Offset: 0x000C2912
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void OnPossess(APawn pawn)
	{
		ControllerBase<CameraController>.Instance.OnPossess(pawn, "MainCamera");
	}

	// Token: 0x06005372 RID: 21362 RVA: 0x000C4724 File Offset: 0x000C2924
	[UFunction(EFunctionFlags.FUNC_None)]
	public static ECustomCameraMode GetCameraMode()
	{
		return ControllerBase<CameraController>.Instance.MainModel.CameraMode.Value;
	}

	// Token: 0x06005373 RID: 21363 RVA: 0x000C4748 File Offset: 0x000C2948
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static ALevelSequenceActor GetSequenceCameraActor()
	{
		return ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.PlayerComponent.GetCurrentLevelSequenceActor();
	}

	// Token: 0x06005374 RID: 21364 RVA: 0x000C4764 File Offset: 0x000C2964
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EnterCameraMode(ECustomCameraMode cameraMode, float blendTime, TEnumAsByte<UnrealEngine.EViewTargetBlendFunction> blendFunction, float blendExp)
	{
		TEnumAsByte<UnrealEngine.EViewTargetBlendFunction> tenumAsByte = blendFunction;
		if (tenumAsByte == UnrealEngine.EViewTargetBlendFunction.VTBlend_CurveAsset)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Camera, ELogAuthor.ZJL, "EnterCameraMode暂时不支持CurveAsset作为BlendFunction，已自动回退到Linear", default(ReadOnlySpan<ValueTuple<string, object>>));
			tenumAsByte = UnrealEngine.EViewTargetBlendFunction.VTBlend_Linear;
		}
		ControllerBase<CameraController>.Instance.EnterCameraMode(cameraMode, blendTime, tenumAsByte, blendExp, null, false, "MainCamera", null);
	}

	// Token: 0x06005375 RID: 21365 RVA: 0x000C47C0 File Offset: 0x000C29C0
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ExitCameraMode(ECustomCameraMode cameraMode, float blendTime, TEnumAsByte<UnrealEngine.EViewTargetBlendFunction> blendFunction, float blendExp)
	{
		TEnumAsByte<UnrealEngine.EViewTargetBlendFunction> tenumAsByte = blendFunction;
		if (tenumAsByte == UnrealEngine.EViewTargetBlendFunction.VTBlend_CurveAsset)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Camera, ELogAuthor.ZJL, "ExitCameraMode暂时不支持CurveAsset作为BlendFunction，已自动回退到Linear", default(ReadOnlySpan<ValueTuple<string, object>>));
			tenumAsByte = UnrealEngine.EViewTargetBlendFunction.VTBlend_Linear;
		}
		ControllerBase<CameraController>.Instance.ExitCameraMode(cameraMode, blendTime, tenumAsByte, blendExp, null, "MainCamera", null);
	}

	// Token: 0x06005376 RID: 21366 RVA: 0x000C481B File Offset: 0x000C2A1B
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetCameraRotation(FRotator rotator)
	{
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.SetRotation(rotator);
	}

	// Token: 0x06005377 RID: 21367 RVA: 0x000C4837 File Offset: 0x000C2A37
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool IsTargetSocketLocationValid()
	{
		return ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.IsTargetLocationValid;
	}

	// Token: 0x06005378 RID: 21368 RVA: 0x000C4852 File Offset: 0x000C2A52
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVectorDouble GetTargetSocketLocation()
	{
		return ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.TargetLocation.ToUeVector(false);
	}

	// Token: 0x06005379 RID: 21369 RVA: 0x000C4873 File Offset: 0x000C2A73
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVectorDouble GetFightCameraLocation()
	{
		return ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraLocation.ToUeVector(false);
	}

	// Token: 0x0600537A RID: 21370 RVA: 0x000C4894 File Offset: 0x000C2A94
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FRotator GetFightCameraRotation()
	{
		return ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraRotation.ToUeRotator();
	}

	// Token: 0x0600537B RID: 21371 RVA: 0x000C48B4 File Offset: 0x000C2AB4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVector GetFightCameraForward(int index)
	{
		return ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraForward.ToUeVectorOld();
	}

	// Token: 0x0600537C RID: 21372 RVA: 0x000C48D4 File Offset: 0x000C2AD4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static ACameraActor GetFightCameraActor()
	{
		return ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraActor;
	}

	// Token: 0x0600537D RID: 21373 RVA: 0x000C48EF File Offset: 0x000C2AEF
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetFightCameraFollow(bool follow)
	{
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.IsFollowing = follow;
	}

	// Token: 0x0600537E RID: 21374 RVA: 0x000C490C File Offset: 0x000C2B0C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ApplyCameraModify(FGameplayTag tag, float duration, float blendInTime, float blendOutTime, float breakBlendOutTime, SCameraModifier_Settings cameraModifySettings, UAnimMontage montage, SBaseCurve blendInCurve, SBaseCurve blendOutCurve, string cameraAttachSocket, int entityId, ECameraAnsEffectiveClientType cameraEffectiveClientType, ref TArray<SCameraModifier_Condition> cameraModifierConditions)
	{
		if (!CameraUtility.CheckApplyCameraModifyCondition(ModelBase<CreatureModel>.Instance.GetEntityById(entityId), cameraModifySettings, cameraEffectiveClientType, cameraModifierConditions))
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ApplyCameraModify(new FGameplayTag?(tag), duration, blendInTime, blendOutTime, cameraModifySettings, montage, breakBlendOutTime, blendInCurve, blendOutCurve, default(OneOf<TsBaseCharacter, TsBaseVehicle>), cameraAttachSocket, default(OneOf<TsBaseCharacter, TsBaseVehicle>));
	}

	// Token: 0x0600537F RID: 21375 RVA: 0x000C4975 File Offset: 0x000C2B75
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ForceStopCameraModify(bool withFadeOut)
	{
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ForceStopModify(withFadeOut);
	}

	// Token: 0x06005380 RID: 21376 RVA: 0x000C4994 File Offset: 0x000C2B94
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ApplyCameraGuide(FVector lookAt, float fadeInTime, float stayTime, float fadeOutTime, bool lockCameraInput, FVector endPosition, float fov, bool ignoreAdjustYaw, bool staticCamera)
	{
		if (CameraBlueprintFunctionLibrary._cacheLookAtVector == null)
		{
			CameraBlueprintFunctionLibrary._cacheLookAtVector = Vector.Create();
		}
		if (CameraBlueprintFunctionLibrary._cacheLookAtVector1 == null)
		{
			CameraBlueprintFunctionLibrary._cacheLookAtVector1 = Vector.Create();
		}
		CameraBlueprintFunctionLibrary._cacheLookAtVector.FromUeVector(lookAt);
		Vector endPosition2 = null;
		if (!endPosition.IsNearlyZero(0.0001f))
		{
			CameraBlueprintFunctionLibrary._cacheLookAtVector1.FromUeVector(endPosition);
			endPosition2 = CameraBlueprintFunctionLibrary._cacheLookAtVector1;
		}
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ApplyCameraGuide(CameraBlueprintFunctionLibrary._cacheLookAtVector, fadeInTime, stayTime, fadeOutTime, lockCameraInput, endPosition2, (fov == 0f) ? null : new float?(fov), ignoreAdjustYaw, staticCamera, 0f, false, null, false);
	}

	// Token: 0x06005381 RID: 21377 RVA: 0x000C4A3C File Offset: 0x000C2C3C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ExitCameraGuide()
	{
		Singleton<global::Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraLookAt] ExitCameraGuide", default(ReadOnlySpan<ValueTuple<string, object>>));
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ExitCameraGuide();
	}

	// Token: 0x06005382 RID: 21378 RVA: 0x000C4A80 File Offset: 0x000C2C80
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EnterCameraExplore(int id, FVector lookAt1, FVector lookAt2, float prepTime, float fadeDistance, float armLengthMin, float armLengthMax)
	{
		FVectorDouble value = UKismetMathLibrary.Conv_VectorToVectorDouble(lookAt1);
		FVectorDouble value2 = UKismetMathLibrary.Conv_VectorToVectorDouble(lookAt2);
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.EnterCameraExplore(id, new FVectorDouble?(value), new FVectorDouble?(value2), prepTime, fadeDistance, armLengthMin, armLengthMax);
	}

	// Token: 0x06005383 RID: 21379 RVA: 0x000C4AC8 File Offset: 0x000C2CC8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ExitCameraExplore(int id)
	{
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ExitCameraExplore(id);
	}

	// Token: 0x06005384 RID: 21380 RVA: 0x000C4AE4 File Offset: 0x000C2CE4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool PlayCameraSequence(ESequenceCameraAnsEffectiveClientType 生效客户端, int entityId, SSequenceCamera_Settings settings, bool resetLockOnCamera, FRotator additiveRotation, string cameraAttachSocket, string cameraDetectSocket, FVector extraSphereLocation, float extraDetectSphereRadius, bool isShowExtraSphere, bool isIgnoreCharacterCollision, bool disableMovementInput, bool disableLookAtInput, bool disableMotionBlur)
	{
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
		if (entityById == null)
		{
			return false;
		}
		WorldEntity entity = entityById.Entity;
		TsBaseCharacter tsBaseCharacter;
		if (entity == null)
		{
			tsBaseCharacter = null;
		}
		else
		{
			CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
			tsBaseCharacter = ((component != null) ? component.Actor : null);
		}
		TsBaseCharacter tsBaseCharacter2 = tsBaseCharacter;
		if (tsBaseCharacter2 == null)
		{
			return false;
		}
		if (!CameraUtility.CheckCameraSequenceCondition(tsBaseCharacter2, 生效客户端))
		{
			return false;
		}
		WorldEntity entity2 = entityById.Entity;
		BaseSkillComponent baseSkillComponent = (entity2 != null) ? entity2.GetComponent<BaseSkillComponent>() : null;
		Skill skill = (baseSkillComponent != null) ? baseSkillComponent.CurrentSkill : null;
		int? skillEntityId = (skill != null) ? new int?(entityId) : null;
		int? num = (skill != null) ? new int?(skill.SkillId) : null;
		long? skillId = (num != null) ? new long?((long)num.GetValueOrDefault()) : null;
		return ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.PlayerComponent.PlayCameraSequence(settings, resetLockOnCamera, additiveRotation, tsBaseCharacter2, StringUtils.IsEmpty(cameraAttachSocket) ? FNameUtil.EMPTY : FNameUtil.GetDynamicFName(cameraAttachSocket).Value, StringUtils.IsEmpty(cameraDetectSocket) ? FNameUtil.EMPTY : FNameUtil.GetDynamicFName(cameraDetectSocket).Value, extraSphereLocation, extraDetectSphereRadius, isShowExtraSphere, isIgnoreCharacterCollision, disableMovementInput, disableLookAtInput, disableMotionBlur, false, null, skillEntityId, skillId);
	}

	// Token: 0x06005385 RID: 21381 RVA: 0x000C4C14 File Offset: 0x000C2E14
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static ACameraActor GetWidgetCameraActor()
	{
		return ControllerBase<CameraController>.Instance.MainModel.WidgetCamera.DisplayComponent.CineCamera;
	}

	// Token: 0x06005386 RID: 21382 RVA: 0x000C4C30 File Offset: 0x000C2E30
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetWidgetCameraBlendParams(float blendTime, TEnumAsByte<UnrealEngine.EViewTargetBlendFunction> blendFunction, float blendExp, bool blendLocation, bool isRelativeLocation, bool overrideLocation, FVector newLocation, bool blendRotation, bool isRelativeRotation, bool overrideRotation, FRotator newRotation)
	{
		FVectorDouble newLocation2 = UKismetMathLibrary.Conv_VectorToVectorDouble(newLocation);
		ControllerBase<CameraController>.Instance.MainModel.WidgetCamera.BlendComponent.SetBlendParams(blendTime, blendFunction, (byte)blendExp, blendLocation, isRelativeLocation, overrideLocation, newLocation2, blendRotation, isRelativeRotation, overrideRotation, newRotation);
	}

	// Token: 0x06005387 RID: 21383 RVA: 0x000C4C75 File Offset: 0x000C2E75
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void PlayCameraOrbital(ULevelSequence levelSequence, FVector startLocation, FVector endLocation, float blendInTime, float blendOutTime)
	{
		ControllerBase<CameraController>.Instance.MainModel.OrbitalCamera.PlayerComponent.PlayCameraOrbital(levelSequence, startLocation, endLocation, blendInTime, blendOutTime);
	}

	// Token: 0x06005388 RID: 21384 RVA: 0x000C4C96 File Offset: 0x000C2E96
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void StopCameraOrbital()
	{
		ControllerBase<CameraController>.Instance.MainModel.OrbitalCamera.PlayerComponent.StopCameraOrbital();
	}

	// Token: 0x06005389 RID: 21385 RVA: 0x000C4CB1 File Offset: 0x000C2EB1
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ResetFightCameraPitchAndArmLength()
	{
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ResetArmLengthAndRotation(Rotator.ZeroRotator);
	}

	// Token: 0x0600538A RID: 21386 RVA: 0x000C4CD4 File Offset: 0x000C2ED4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EnterSequenceDialogue(AActor target)
	{
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraDialogueController.EnterSequenceDialogue(Vector.Create(target.D_K2_GetActorLocation()), false, null, null);
	}

	// Token: 0x0600538B RID: 21387 RVA: 0x000C4D22 File Offset: 0x000C2F22
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ExitSequenceDialogue()
	{
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraDialogueController.ExitSequenceDialogue();
	}

	// Token: 0x0600538C RID: 21388 RVA: 0x000C4D42 File Offset: 0x000C2F42
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ReloadCameraConfig()
	{
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.LoadConfig();
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraConfigController.LoadConfig();
	}

	// Token: 0x0600538D RID: 21389 RVA: 0x000C4D7B File Offset: 0x000C2F7B
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetAimAssistMode(EAimAssistMode mode)
	{
		ControllerBase<CameraController>.Instance.MainModel.SetAimAssistMode(mode);
	}

	// Token: 0x0600538E RID: 21390 RVA: 0x000C4D90 File Offset: 0x000C2F90
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool IsRoleOnCameraRight()
	{
		BaseActorComponent component = Global.BaseCharacter.GetEntityNoBlueprint().GetComponent<BaseActorComponent>();
		FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
		logicComponent.CameraRotation.Quaternion(CameraBlueprintFunctionLibrary.TmpQuat);
		CameraBlueprintFunctionLibrary.TmpQuat.RotateVector(Vector.RightVectorProxy, CameraBlueprintFunctionLibrary.TmpVector);
		return component.ActorLocationProxy.DotProduct(CameraBlueprintFunctionLibrary.TmpVector) - logicComponent.CameraLocation.DotProduct(CameraBlueprintFunctionLibrary.TmpVector) > 0.0;
	}

	// Token: 0x0600538F RID: 21391 RVA: 0x000C4E11 File Offset: 0x000C3011
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetCameraDebugToolEnabled(bool inEnable)
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolEnabled = inEnable;
	}

	// Token: 0x06005390 RID: 21392 RVA: 0x000C4E2B File Offset: 0x000C302B
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SwitchCameraDebugRotatorEnabled()
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawRotator = !ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawRotator;
	}

	// Token: 0x06005391 RID: 21393 RVA: 0x000C4E56 File Offset: 0x000C3056
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SwitchCameraDebugToolDrawCameraCollision()
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawCameraCollision = !ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawCameraCollision;
	}

	// Token: 0x06005392 RID: 21394 RVA: 0x000C4E81 File Offset: 0x000C3081
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SwitchCameraDebugToolDrawSpringArm()
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawSpringArm = !ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawSpringArm;
	}

	// Token: 0x06005393 RID: 21395 RVA: 0x000C4EAC File Offset: 0x000C30AC
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SwitchCameraDebugToolDrawFocusTargetLine()
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawFocusTargetLine = !ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawFocusTargetLine;
	}

	// Token: 0x06005394 RID: 21396 RVA: 0x000C4ED7 File Offset: 0x000C30D7
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SwitchCameraDebugToolDrawSpringArmEdgeRange()
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawSpringArmEdgeRange = !ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawSpringArmEdgeRange;
	}

	// Token: 0x06005395 RID: 21397 RVA: 0x000C4F02 File Offset: 0x000C3102
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SwitchCameraDebugToolDrawLockCameraMoveLine()
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawLockCameraMoveLine = !ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawLockCameraMoveLine;
	}

	// Token: 0x06005396 RID: 21398 RVA: 0x000C4F2D File Offset: 0x000C312D
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SwitchCameraDebugToolDrawSettlementCamera()
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawSettlementCamera = !ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawSettlementCamera;
	}

	// Token: 0x06005397 RID: 21399 RVA: 0x000C4F58 File Offset: 0x000C3158
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SwitchCameraDebugToolDrawCameraZone()
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawCameraZone = !ControllerBase<CameraController>.Instance.MainModel.CameraDebugToolDrawCameraZone;
	}

	// Token: 0x06005398 RID: 21400 RVA: 0x000C4F83 File Offset: 0x000C3183
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TMap<string, string> GetDebugDesiredCameraProps()
	{
		return new TMap<string, string>();
	}

	// Token: 0x06005399 RID: 21401 RVA: 0x000C4F8A File Offset: 0x000C318A
	[NullableContext(1)]
	public static Dictionary<string, object> GetDebugCameraPropsRaw()
	{
		return new Dictionary<string, object>();
	}

	// Token: 0x0600539A RID: 21402 RVA: 0x000C4F91 File Offset: 0x000C3191
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TArray<SCameraDebugTool_SubCameraModification> GetSubCameraModifications()
	{
		return new TArray<SCameraDebugTool_SubCameraModification>();
	}

	// Token: 0x0600539B RID: 21403 RVA: 0x000C4F98 File Offset: 0x000C3198
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TArray<SCameraDebugTool_ControllerModification> GetControllerModifications()
	{
		return new TArray<SCameraDebugTool_ControllerModification>();
	}

	// Token: 0x0600539C RID: 21404 RVA: 0x000C4F9F File Offset: 0x000C319F
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SCameraDebugTool_CameraModeInfo GetCamereModeInfo()
	{
		return new SCameraDebugTool_CameraModeInfo();
	}

	// Token: 0x0600539D RID: 21405 RVA: 0x000C4FA6 File Offset: 0x000C31A6
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void PlaySettlementCamera()
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		if (fightCamera == null)
		{
			return;
		}
		FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
		if (logicComponent == null)
		{
			return;
		}
		logicComponent.PlaySettlementCamera(EDynamicSettlementType.Battle);
	}

	// Token: 0x0600539E RID: 21406 RVA: 0x000C4FD4 File Offset: 0x000C31D4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool GetIsCameraTargetInScreen()
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		return fightCameraLogicComponent != null && fightCameraLogicComponent.IsTargetLocationValid && fightCameraLogicComponent.CheckPositionInScreen(fightCameraLogicComponent.TargetLocation, fightCameraLogicComponent.CameraAdjustController.CheckInScreenMinX, fightCameraLogicComponent.CameraAdjustController.CheckInScreenMaxX, fightCameraLogicComponent.CameraAdjustController.CheckInScreenMinY, fightCameraLogicComponent.CameraAdjustController.CheckInScreenMaxY);
	}

	// Token: 0x0600539F RID: 21407 RVA: 0x000C5048 File Offset: 0x000C3248
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static ACameraActor EnterSpecialGameplayCamera(int gameplayId)
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		if (fightCamera == null)
		{
			return null;
		}
		FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
		if (logicComponent == null)
		{
			return null;
		}
		return logicComponent.EnterSpecialGameplayCamera(gameplayId);
	}

	// Token: 0x060053A0 RID: 21408 RVA: 0x000C5070 File Offset: 0x000C3270
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ExitSpecialGameplayCamera()
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		if (fightCamera == null)
		{
			return;
		}
		FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
		if (logicComponent == null)
		{
			return;
		}
		logicComponent.ExitSpecialGameplayCamera();
	}

	// Token: 0x060053A1 RID: 21409 RVA: 0x000C5095 File Offset: 0x000C3295
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ExitSpecialGameplayCamera2()
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		if (fightCamera == null)
		{
			return;
		}
		FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
		if (logicComponent == null)
		{
			return;
		}
		logicComponent.ExitSpecialGameplayCamera();
	}

	// Token: 0x060053A2 RID: 21410 RVA: 0x000C50BA File Offset: 0x000C32BA
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetAimAssistModeByKey(string key, EAimAssistMode mode)
	{
		ControllerBase<CameraController>.Instance.MainModel.SetAimAssistModeWithKey(key, mode);
	}

	// Token: 0x060053A3 RID: 21411 RVA: 0x000C50CD File Offset: 0x000C32CD
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ClearAimAssistModeByKey(string key)
	{
		ControllerBase<CameraController>.Instance.MainModel.ClearAimAssistModeWithKey(key);
	}

	// Token: 0x060053A4 RID: 21412 RVA: 0x000C50DF File Offset: 0x000C32DF
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetSequenceCameraCollisionState(bool bEnable)
	{
		SequenceCamera sequenceCamera = ControllerBase<CameraController>.Instance.MainModel.SequenceCamera;
		if (sequenceCamera == null)
		{
			return;
		}
		SequenceCameraPlayerComponent playerComponent = sequenceCamera.PlayerComponent;
		if (playerComponent == null)
		{
			return;
		}
		playerComponent.SetCameraCollisionState(bEnable);
	}

	// Token: 0x060053A5 RID: 21413 RVA: 0x000C5108 File Offset: 0x000C3308
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetXRayState(bool isEnable)
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		CameraCollision cameraCollision;
		if (fightCamera == null)
		{
			cameraCollision = null;
		}
		else
		{
			FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
			cameraCollision = ((logicComponent != null) ? logicComponent.CameraCollision : null);
		}
		CameraCollision cameraCollision2 = cameraCollision;
		if (cameraCollision2 != null)
		{
			cameraCollision2.IsPlayerXRayEnable = isEnable;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "CameraBlueprintFunctionLibrary SetXRayState";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("isEnable", isEnable);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x060053A6 RID: 21414 RVA: 0x000C5174 File Offset: 0x000C3374
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static int EnableCameraSpecificLockTarget(int entityId, float priority)
	{
		int num = ControllerBase<CameraController>.Instance.MainModel.EnableCameraSpecificLockEntity(entityId, (int)priority);
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Camera;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "CameraBlueprintFunctionLibrary EnableCameraSpecificLockTarget";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityId", entityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("priority", priority);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("id", num);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		return num;
	}

	// Token: 0x060053A7 RID: 21415 RVA: 0x000C5210 File Offset: 0x000C3410
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static int EnableCameraSpecificLockLocation(FVectorDouble location, float priority)
	{
		Vector vector = Vector.Create(location);
		int num = ControllerBase<CameraController>.Instance.MainModel.EnableCameraSpecificLockLocation(vector, (int)priority);
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Camera;
		ELogAuthor author = ELogAuthor.LYY;
		string message = "CameraBlueprintFunctionLibrary EnableCameraSpecificLockLocation";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("location", vector);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("priority", priority);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("id", num);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		return num;
	}

	// Token: 0x060053A8 RID: 21416 RVA: 0x000C52B4 File Offset: 0x000C34B4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void DisableCameraSpecificLockOnTarget(int id)
	{
		ControllerBase<CameraController>.Instance.MainModel.DisableCameraSpecificLockTarget(id);
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Camera;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "CameraBlueprintFunctionLibrary DisableCameraSpecificLockOnTarget";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060053A9 RID: 21417 RVA: 0x000C52FD File Offset: 0x000C34FD
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool IsCameraSpecificLockEnable()
	{
		return ControllerBase<CameraController>.Instance.MainModel.GetCameraSpecificLockTarget() != null;
	}

	// Token: 0x060053AA RID: 21418 RVA: 0x000C5314 File Offset: 0x000C3514
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int GetCameraSpecificLockEntityId()
	{
		CameraSpecificLockTarget cameraSpecificLockTarget = ControllerBase<CameraController>.Instance.MainModel.GetCameraSpecificLockTarget();
		if (cameraSpecificLockTarget == null || cameraSpecificLockTarget.Type != ECameraSpecificLockType.Entity)
		{
			return -1;
		}
		return ((CameraSpecificLockEntity)cameraSpecificLockTarget).EntityId;
	}

	// Token: 0x060053AB RID: 21419 RVA: 0x000C534C File Offset: 0x000C354C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int EnableSoftLockCamera()
	{
		CameraController instance = ControllerBase<CameraController>.Instance;
		if (((instance != null) ? instance.MainModel : null) == null)
		{
			return -1;
		}
		int num = ControllerBase<CameraController>.Instance.MainModel.EnableSoftLock("Bp EnableSoftLockCamera");
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Camera;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "CameraBlueprintFunctionLibrary EnableSoftLockCamera";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("handle", num);
		instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return num;
	}

	// Token: 0x060053AC RID: 21420 RVA: 0x000C53B0 File Offset: 0x000C35B0
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void DisableSoftLockCamera(int handle)
	{
		CameraController instance = ControllerBase<CameraController>.Instance;
		if (((instance != null) ? instance.MainModel : null) == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.DisableSoftLock(handle, "Bp DisableSoftLockCamera");
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Camera;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "CameraBlueprintFunctionLibrary DisableSoftLockCamera";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("handle", handle);
		instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060053AD RID: 21421 RVA: 0x000C5414 File Offset: 0x000C3614
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetCameraGravityMode(ECameraGravityMode gravityMode, FVectorDouble gravityDirect)
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
		{
			return;
		}
		CameraBlueprintFunctionLibrary.TmpVector.DeepCopy(gravityDirect);
		fightCameraLogicComponent.SetCameraGravityMode(gravityMode, CameraBlueprintFunctionLibrary.TmpVector);
	}

	// Token: 0x060053AE RID: 21422 RVA: 0x000C5468 File Offset: 0x000C3668
	[UFunction(EFunctionFlags.FUNC_None)]
	public static ECameraGravityMode GetCameraGravityMode()
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
		{
			return ECameraGravityMode.None;
		}
		return fightCameraLogicComponent.GravityMode;
	}

	// Token: 0x060053AF RID: 21423 RVA: 0x000C54AC File Offset: 0x000C36AC
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVectorDouble GetCameraGravityDirect()
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
		{
			return Vector.DownVectorDouble;
		}
		return fightCameraLogicComponent.GravityDirect.ToUeVector(false);
	}

	// Token: 0x060053B0 RID: 21424 RVA: 0x000C54F8 File Offset: 0x000C36F8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVectorDouble GetCameraGravityUp()
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
		{
			return Vector.UpVectorDouble;
		}
		return fightCameraLogicComponent.GravityUp.ToUeVector(false);
	}

	// Token: 0x060053B1 RID: 21425 RVA: 0x000C5544 File Offset: 0x000C3744
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FRotator GetCameraRotationInGravity()
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
		{
			return Rotator.ZeroRotator;
		}
		return fightCameraLogicComponent.CameraRotationInGravity.ToUeRotator();
	}

	// Token: 0x060053B2 RID: 21426 RVA: 0x000C5590 File Offset: 0x000C3790
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVectorDouble GetPlayerLocationInGravity()
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
		{
			return Vector.ZeroVectorDouble;
		}
		return fightCameraLogicComponent.PlayerLocationInGravity.ToUeVector(false);
	}

	// Token: 0x060053B3 RID: 21427 RVA: 0x000C55DC File Offset: 0x000C37DC
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FRotator GetPlayerRotatorInGravity()
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
		{
			return Rotator.ZeroRotator;
		}
		return fightCameraLogicComponent.PlayerRotatorInGravity.ToUeRotator();
	}

	// Token: 0x060053B4 RID: 21428 RVA: 0x000C5627 File Offset: 0x000C3827
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetUiCameraDebugToolEnabled(bool enabled)
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.MainModel.UiCameraDebugToolEnabled = enabled;
	}

	// Token: 0x060053B5 RID: 21429 RVA: 0x000C5644 File Offset: 0x000C3844
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SwitchUiCameraDtSync()
	{
		UiCameraDebugTool uiCameraDebugTool = Singleton<UiCameraAnimationManager>.Instance.UiCameraDebugTool;
		if (uiCameraDebugTool.GetDtSyncEnabled())
		{
			uiCameraDebugTool.EndDtSync();
			return;
		}
		uiCameraDebugTool.StartDtSync();
	}

	// Token: 0x060053B6 RID: 21430 RVA: 0x000C5671 File Offset: 0x000C3871
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TMap<string, string> GetDebugToolUiCameraProps()
	{
		return new TMap<string, string>();
	}

	// Token: 0x060053B7 RID: 21431 RVA: 0x000C5678 File Offset: 0x000C3878
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SwitchUiCameraArmLengthSync()
	{
		UiCameraDebugTool uiCameraDebugTool = Singleton<UiCameraAnimationManager>.Instance.UiCameraDebugTool;
		if (uiCameraDebugTool.GetArmLengthSyncEnabled())
		{
			uiCameraDebugTool.EndArmLengthSync();
			return;
		}
		uiCameraDebugTool.StartArmLengthSync();
	}

	// Token: 0x060053B8 RID: 21432 RVA: 0x000C56A8 File Offset: 0x000C38A8
	[NullableContext(1)]
	[Conditional("DEBUG")]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void OnDebugToolUiCameraArmLengthInputChanged(string armLengthStr)
	{
		UiCameraDebugTool uiCameraDebugTool = Singleton<UiCameraAnimationManager>.Instance.UiCameraDebugTool;
		if (uiCameraDebugTool.GetArmLengthSyncEnabled())
		{
			float num = float.Parse(armLengthStr);
			if (num > 0f)
			{
				uiCameraDebugTool.ArmLengthSync(num);
			}
		}
	}

	// Token: 0x060053B9 RID: 21433 RVA: 0x000C56E0 File Offset: 0x000C38E0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void InitSeparateCamera(string cameraName, FVector2D initLocation, FVector2D initSize, bool enableScissorOffset)
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		if (ControllerBase<CameraController>.Instance.GetSeparateCameraModel(cameraName) == null)
		{
			return;
		}
		CameraBlueprintFunctionLibrary.TmpVector2D1.FromUeVector2D(initLocation);
		CameraBlueprintFunctionLibrary.TmpVector2D2.FromUeVector2D(initSize);
		if (cameraName != "MainCamera")
		{
			CameraModelInstance separateCameraModel = ControllerBase<CameraController>.Instance.GetSeparateCameraModel("MainCamera");
			CameraBlueprintFunctionLibrary.TmpVector2D1.X = Singleton<MathUtils>.Instance.Clamp(separateCameraModel.SeparateCameraLayout.CurrentViewSize.X, 0.0, 1.0);
			CameraBlueprintFunctionLibrary.TmpVector2D2.X = Singleton<MathUtils>.Instance.Clamp(1.0 - separateCameraModel.SeparateCameraLayout.CurrentViewSize.X, 0.0, 1.0);
		}
		ControllerBase<CameraController>.Instance.InitSeparateCamera(cameraName, CameraBlueprintFunctionLibrary.TmpVector2D1, CameraBlueprintFunctionLibrary.TmpVector2D2, enableScissorOffset, false);
	}

	// Token: 0x060053BA RID: 21434 RVA: 0x000C57D4 File Offset: 0x000C39D4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void FadeSeparateCamera(string cameraName, float fadeTime, FVector2D targetViewLocation, FVector2D targetViewSize, bool enableScissorOffset, [Nullable(2)] UCurveFloat curve)
	{
		if (ModelBase<CameraModel>.Instance == null)
		{
			return;
		}
		if (ControllerBase<CameraController>.Instance.GetSeparateCameraModel(cameraName) == null)
		{
			return;
		}
		CameraBlueprintFunctionLibrary.TmpVector2D1.FromUeVector2D(targetViewLocation);
		CameraBlueprintFunctionLibrary.TmpVector2D2.FromUeVector2D(targetViewSize);
		ControllerBase<CameraController>.Instance.FadeSeparateCamera(cameraName, fadeTime, CameraBlueprintFunctionLibrary.TmpVector2D1, CameraBlueprintFunctionLibrary.TmpVector2D2, enableScissorOffset, curve, null, false);
	}

	// Token: 0x060053BB RID: 21435 RVA: 0x000C5833 File Offset: 0x000C3A33
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x060053BC RID: 21436 RVA: 0x000C5835 File Offset: 0x000C3A35
	public static void ResetStaticDefaultValue()
	{
		CameraBlueprintFunctionLibrary._tmpQuatInternal = null;
		CameraBlueprintFunctionLibrary._cacheLookAtVector = null;
		CameraBlueprintFunctionLibrary._cacheLookAtVector1 = null;
		CameraBlueprintFunctionLibrary._tmpVectorInternal = null;
		CameraBlueprintFunctionLibrary._tmpVector2D1Internal = null;
		CameraBlueprintFunctionLibrary._tmpVector2D2Internal = null;
	}

	// Token: 0x060053BD RID: 21437 RVA: 0x000C585C File Offset: 0x000C3A5C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetOcclusionDitherState(bool isEnable)
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		CameraCollision cameraCollision;
		if (fightCamera == null)
		{
			cameraCollision = null;
		}
		else
		{
			FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
			cameraCollision = ((logicComponent != null) ? logicComponent.CameraCollision : null);
		}
		CameraCollision cameraCollision2 = cameraCollision;
		if (cameraCollision2 != null)
		{
			cameraCollision2.IsActiveOcclusionDither = isEnable;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "CameraBlueprintFunctionLibrary SetOcclusionDitherState";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("isEnable", isEnable);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x060053BE RID: 21438 RVA: 0x000C58C7 File Offset: 0x000C3AC7
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (CameraBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Camera/CameraBlueprintFunctionLibrary.CameraBlueprintFunctionLibrary_C");
		}
		return CameraBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x060053BF RID: 21439 RVA: 0x000C58EC File Offset: 0x000C3AEC
	public CameraBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(CameraBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060053C0 RID: 21440 RVA: 0x000C5914 File Offset: 0x000C3B14
	[NullableContext(1)]
	public CameraBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CameraBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060053C1 RID: 21441 RVA: 0x000C5947 File Offset: 0x000C3B47
	protected CameraBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060053C2 RID: 21442 RVA: 0x000C5950 File Offset: 0x000C3B50
	protected unsafe static void __CPPCALL_OnPossess_Implementation(CameraBlueprintFunctionLibrary.__OnPossess_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.OnPossess(BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->pawn));
	}

	// Token: 0x060053C3 RID: 21443 RVA: 0x000C5962 File Offset: 0x000C3B62
	protected unsafe static void __CPPCALL_GetCameraMode_Implementation(CameraBlueprintFunctionLibrary.__GetCameraMode_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)CameraBlueprintFunctionLibrary.GetCameraMode();
	}

	// Token: 0x060053C4 RID: 21444 RVA: 0x000C5971 File Offset: 0x000C3B71
	protected unsafe static void __CPPCALL_GetSequenceCameraActor_Implementation(CameraBlueprintFunctionLibrary.__GetSequenceCameraActor_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		ALevelSequenceActor sequenceCameraActor = CameraBlueprintFunctionLibrary.GetSequenceCameraActor();
		ptr = ((sequenceCameraActor != null) ? sequenceCameraActor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060053C5 RID: 21445 RVA: 0x000C598D File Offset: 0x000C3B8D
	protected unsafe static void __CPPCALL_EnterCameraMode_Implementation(CameraBlueprintFunctionLibrary.__EnterCameraMode_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.EnterCameraMode((ECustomCameraMode)__Params->cameraMode, __Params->blendTime, __Params->blendFunction, __Params->blendExp);
	}

	// Token: 0x060053C6 RID: 21446 RVA: 0x000C59AC File Offset: 0x000C3BAC
	protected unsafe static void __CPPCALL_ExitCameraMode_Implementation(CameraBlueprintFunctionLibrary.__ExitCameraMode_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.ExitCameraMode((ECustomCameraMode)__Params->cameraMode, __Params->blendTime, __Params->blendFunction, __Params->blendExp);
	}

	// Token: 0x060053C7 RID: 21447 RVA: 0x000C59CB File Offset: 0x000C3BCB
	protected unsafe static void __CPPCALL_SetCameraRotation_Implementation(CameraBlueprintFunctionLibrary.__SetCameraRotation_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.SetCameraRotation(__Params->rotator);
	}

	// Token: 0x060053C8 RID: 21448 RVA: 0x000C59D8 File Offset: 0x000C3BD8
	protected unsafe static void __CPPCALL_IsTargetSocketLocationValid_Implementation(CameraBlueprintFunctionLibrary.__IsTargetSocketLocationValid_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.IsTargetSocketLocationValid();
	}

	// Token: 0x060053C9 RID: 21449 RVA: 0x000C59E5 File Offset: 0x000C3BE5
	protected unsafe static void __CPPCALL_GetTargetSocketLocation_Implementation(CameraBlueprintFunctionLibrary.__GetTargetSocketLocation_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.GetTargetSocketLocation();
	}

	// Token: 0x060053CA RID: 21450 RVA: 0x000C59F2 File Offset: 0x000C3BF2
	protected unsafe static void __CPPCALL_GetFightCameraLocation_Implementation(CameraBlueprintFunctionLibrary.__GetFightCameraLocation_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.GetFightCameraLocation();
	}

	// Token: 0x060053CB RID: 21451 RVA: 0x000C59FF File Offset: 0x000C3BFF
	protected unsafe static void __CPPCALL_GetFightCameraRotation_Implementation(CameraBlueprintFunctionLibrary.__GetFightCameraRotation_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.GetFightCameraRotation();
	}

	// Token: 0x060053CC RID: 21452 RVA: 0x000C5A0C File Offset: 0x000C3C0C
	protected unsafe static void __CPPCALL_GetFightCameraForward_Implementation(CameraBlueprintFunctionLibrary.__GetFightCameraForward_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.GetFightCameraForward(__Params->index);
	}

	// Token: 0x060053CD RID: 21453 RVA: 0x000C5A1F File Offset: 0x000C3C1F
	protected unsafe static void __CPPCALL_GetFightCameraActor_Implementation(CameraBlueprintFunctionLibrary.__GetFightCameraActor_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		ACameraActor fightCameraActor = CameraBlueprintFunctionLibrary.GetFightCameraActor();
		ptr = ((fightCameraActor != null) ? fightCameraActor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060053CE RID: 21454 RVA: 0x000C5A3B File Offset: 0x000C3C3B
	protected unsafe static void __CPPCALL_SetFightCameraFollow_Implementation(CameraBlueprintFunctionLibrary.__SetFightCameraFollow_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.SetFightCameraFollow(__Params->follow);
	}

	// Token: 0x060053CF RID: 21455 RVA: 0x000C5A48 File Offset: 0x000C3C48
	protected unsafe static void __CPPCALL_ApplyCameraModify_Implementation(CameraBlueprintFunctionLibrary.__ApplyCameraModify_FunctionParams* __Params)
	{
		SCameraModifier_Settings cameraModifySettings = new SCameraModifier_Settings(&__Params->cameraModifySettings, true, true);
		UAnimMontage orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimMontage>(__Params->montage);
		SBaseCurve blendInCurve = new SBaseCurve(&__Params->blendInCurve, true, true);
		SBaseCurve blendOutCurve = new SBaseCurve(&__Params->blendOutCurve, true, true);
		string cameraAttachSocket = FString.ToString((void*)(&__Params->cameraAttachSocket));
		ECameraAnsEffectiveClientType cameraEffectiveClientType = (ECameraAnsEffectiveClientType)__Params->cameraEffectiveClientType;
		TArray<SCameraModifier_Condition> tarray = new TArray<SCameraModifier_Condition>(&__Params->cameraModifierConditions, true, true);
		CameraBlueprintFunctionLibrary.ApplyCameraModify(__Params->tag, __Params->duration, __Params->blendInTime, __Params->blendOutTime, __Params->breakBlendOutTime, cameraModifySettings, orCreateUObjectByNativePointer, blendInCurve, blendOutCurve, cameraAttachSocket, __Params->entityId, cameraEffectiveClientType, ref tarray);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->cameraModifierConditions, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060053D0 RID: 21456 RVA: 0x000C5B03 File Offset: 0x000C3D03
	protected unsafe static void __CPPCALL_ForceStopCameraModify_Implementation(CameraBlueprintFunctionLibrary.__ForceStopCameraModify_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.ForceStopCameraModify(__Params->withFadeOut);
	}

	// Token: 0x060053D1 RID: 21457 RVA: 0x000C5B10 File Offset: 0x000C3D10
	protected unsafe static void __CPPCALL_ApplyCameraGuide_Implementation(CameraBlueprintFunctionLibrary.__ApplyCameraGuide_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.ApplyCameraGuide(__Params->lookAt, __Params->fadeInTime, __Params->stayTime, __Params->fadeOutTime, __Params->lockCameraInput, __Params->endPosition, __Params->fov, __Params->ignoreAdjustYaw, __Params->staticCamera);
	}

	// Token: 0x060053D2 RID: 21458 RVA: 0x000C5B58 File Offset: 0x000C3D58
	protected unsafe static void __CPPCALL_ExitCameraGuide_Implementation(CameraBlueprintFunctionLibrary.__ExitCameraGuide_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.ExitCameraGuide();
	}

	// Token: 0x060053D3 RID: 21459 RVA: 0x000C5B5F File Offset: 0x000C3D5F
	protected unsafe static void __CPPCALL_EnterCameraExplore_Implementation(CameraBlueprintFunctionLibrary.__EnterCameraExplore_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.EnterCameraExplore(__Params->id, __Params->lookAt1, __Params->lookAt2, __Params->prepTime, __Params->fadeDistance, __Params->armLengthMin, __Params->armLengthMax);
	}

	// Token: 0x060053D4 RID: 21460 RVA: 0x000C5B90 File Offset: 0x000C3D90
	protected unsafe static void __CPPCALL_ExitCameraExplore_Implementation(CameraBlueprintFunctionLibrary.__ExitCameraExplore_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.ExitCameraExplore(__Params->id);
	}

	// Token: 0x060053D5 RID: 21461 RVA: 0x000C5BA0 File Offset: 0x000C3DA0
	protected unsafe static void __CPPCALL_PlayCameraSequence_Implementation(CameraBlueprintFunctionLibrary.__PlayCameraSequence_FunctionParams* __Params)
	{
		ESequenceCameraAnsEffectiveClientType 生效客户端 = (ESequenceCameraAnsEffectiveClientType)__Params->生效客户端;
		SSequenceCamera_Settings settings = new SSequenceCamera_Settings(&__Params->settings, true, true);
		string cameraAttachSocket = FString.ToString((void*)(&__Params->cameraAttachSocket));
		string cameraDetectSocket = FString.ToString((void*)(&__Params->cameraDetectSocket));
		__Params->__Result = CameraBlueprintFunctionLibrary.PlayCameraSequence(生效客户端, __Params->entityId, settings, __Params->resetLockOnCamera, __Params->additiveRotation, cameraAttachSocket, cameraDetectSocket, __Params->extraSphereLocation, __Params->extraDetectSphereRadius, __Params->isShowExtraSphere, __Params->isIgnoreCharacterCollision, __Params->disableMovementInput, __Params->disableLookAtInput, __Params->disableMotionBlur);
	}

	// Token: 0x060053D6 RID: 21462 RVA: 0x000C5C28 File Offset: 0x000C3E28
	protected unsafe static void __CPPCALL_GetWidgetCameraActor_Implementation(CameraBlueprintFunctionLibrary.__GetWidgetCameraActor_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		ACameraActor widgetCameraActor = CameraBlueprintFunctionLibrary.GetWidgetCameraActor();
		ptr = ((widgetCameraActor != null) ? widgetCameraActor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060053D7 RID: 21463 RVA: 0x000C5C44 File Offset: 0x000C3E44
	protected unsafe static void __CPPCALL_SetWidgetCameraBlendParams_Implementation(CameraBlueprintFunctionLibrary.__SetWidgetCameraBlendParams_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.SetWidgetCameraBlendParams(__Params->blendTime, __Params->blendFunction, __Params->blendExp, __Params->blendLocation, __Params->isRelativeLocation, __Params->overrideLocation, __Params->newLocation, __Params->blendRotation, __Params->isRelativeRotation, __Params->overrideRotation, __Params->newRotation);
	}

	// Token: 0x060053D8 RID: 21464 RVA: 0x000C5C98 File Offset: 0x000C3E98
	protected unsafe static void __CPPCALL_PlayCameraOrbital_Implementation(CameraBlueprintFunctionLibrary.__PlayCameraOrbital_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.PlayCameraOrbital(BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->levelSequence), __Params->startLocation, __Params->endLocation, __Params->blendInTime, __Params->blendOutTime);
	}

	// Token: 0x060053D9 RID: 21465 RVA: 0x000C5CC2 File Offset: 0x000C3EC2
	protected unsafe static void __CPPCALL_StopCameraOrbital_Implementation(CameraBlueprintFunctionLibrary.__StopCameraOrbital_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.StopCameraOrbital();
	}

	// Token: 0x060053DA RID: 21466 RVA: 0x000C5CC9 File Offset: 0x000C3EC9
	protected unsafe static void __CPPCALL_ResetFightCameraPitchAndArmLength_Implementation(CameraBlueprintFunctionLibrary.__ResetFightCameraPitchAndArmLength_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.ResetFightCameraPitchAndArmLength();
	}

	// Token: 0x060053DB RID: 21467 RVA: 0x000C5CD0 File Offset: 0x000C3ED0
	protected unsafe static void __CPPCALL_EnterSequenceDialogue_Implementation(CameraBlueprintFunctionLibrary.__EnterSequenceDialogue_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.EnterSequenceDialogue(BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->target));
	}

	// Token: 0x060053DC RID: 21468 RVA: 0x000C5CE2 File Offset: 0x000C3EE2
	protected unsafe static void __CPPCALL_ExitSequenceDialogue_Implementation(CameraBlueprintFunctionLibrary.__ExitSequenceDialogue_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.ExitSequenceDialogue();
	}

	// Token: 0x060053DD RID: 21469 RVA: 0x000C5CE9 File Offset: 0x000C3EE9
	protected unsafe static void __CPPCALL_ReloadCameraConfig_Implementation(CameraBlueprintFunctionLibrary.__ReloadCameraConfig_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.ReloadCameraConfig();
	}

	// Token: 0x060053DE RID: 21470 RVA: 0x000C5CF0 File Offset: 0x000C3EF0
	protected unsafe static void __CPPCALL_SetAimAssistMode_Implementation(CameraBlueprintFunctionLibrary.__SetAimAssistMode_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.SetAimAssistMode((EAimAssistMode)__Params->mode);
	}

	// Token: 0x060053DF RID: 21471 RVA: 0x000C5CFD File Offset: 0x000C3EFD
	protected unsafe static void __CPPCALL_IsRoleOnCameraRight_Implementation(CameraBlueprintFunctionLibrary.__IsRoleOnCameraRight_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.IsRoleOnCameraRight();
	}

	// Token: 0x060053E0 RID: 21472 RVA: 0x000C5D0A File Offset: 0x000C3F0A
	protected unsafe static void __CPPCALL_SetCameraDebugToolEnabled_Implementation(CameraBlueprintFunctionLibrary.__SetCameraDebugToolEnabled_FunctionParams* __Params)
	{
	}

	// Token: 0x060053E1 RID: 21473 RVA: 0x000C5D0C File Offset: 0x000C3F0C
	protected unsafe static void __CPPCALL_SwitchCameraDebugRotatorEnabled_Implementation(CameraBlueprintFunctionLibrary.__SwitchCameraDebugRotatorEnabled_FunctionParams* __Params)
	{
	}

	// Token: 0x060053E2 RID: 21474 RVA: 0x000C5D0E File Offset: 0x000C3F0E
	protected unsafe static void __CPPCALL_SwitchCameraDebugToolDrawCameraCollision_Implementation(CameraBlueprintFunctionLibrary.__SwitchCameraDebugToolDrawCameraCollision_FunctionParams* __Params)
	{
	}

	// Token: 0x060053E3 RID: 21475 RVA: 0x000C5D10 File Offset: 0x000C3F10
	protected unsafe static void __CPPCALL_SwitchCameraDebugToolDrawSpringArm_Implementation(CameraBlueprintFunctionLibrary.__SwitchCameraDebugToolDrawSpringArm_FunctionParams* __Params)
	{
	}

	// Token: 0x060053E4 RID: 21476 RVA: 0x000C5D12 File Offset: 0x000C3F12
	protected unsafe static void __CPPCALL_SwitchCameraDebugToolDrawFocusTargetLine_Implementation(CameraBlueprintFunctionLibrary.__SwitchCameraDebugToolDrawFocusTargetLine_FunctionParams* __Params)
	{
	}

	// Token: 0x060053E5 RID: 21477 RVA: 0x000C5D14 File Offset: 0x000C3F14
	protected unsafe static void __CPPCALL_SwitchCameraDebugToolDrawSpringArmEdgeRange_Implementation(CameraBlueprintFunctionLibrary.__SwitchCameraDebugToolDrawSpringArmEdgeRange_FunctionParams* __Params)
	{
	}

	// Token: 0x060053E6 RID: 21478 RVA: 0x000C5D16 File Offset: 0x000C3F16
	protected unsafe static void __CPPCALL_SwitchCameraDebugToolDrawLockCameraMoveLine_Implementation(CameraBlueprintFunctionLibrary.__SwitchCameraDebugToolDrawLockCameraMoveLine_FunctionParams* __Params)
	{
	}

	// Token: 0x060053E7 RID: 21479 RVA: 0x000C5D18 File Offset: 0x000C3F18
	protected unsafe static void __CPPCALL_SwitchCameraDebugToolDrawSettlementCamera_Implementation(CameraBlueprintFunctionLibrary.__SwitchCameraDebugToolDrawSettlementCamera_FunctionParams* __Params)
	{
	}

	// Token: 0x060053E8 RID: 21480 RVA: 0x000C5D1A File Offset: 0x000C3F1A
	protected unsafe static void __CPPCALL_SwitchCameraDebugToolDrawCameraZone_Implementation(CameraBlueprintFunctionLibrary.__SwitchCameraDebugToolDrawCameraZone_FunctionParams* __Params)
	{
	}

	// Token: 0x060053E9 RID: 21481 RVA: 0x000C5D1C File Offset: 0x000C3F1C
	protected unsafe static void __CPPCALL_GetDebugDesiredCameraProps_Implementation(CameraBlueprintFunctionLibrary.__GetDebugDesiredCameraProps_FunctionParams* __Params)
	{
		TMap<string, string> debugDesiredCameraProps = CameraBlueprintFunctionLibrary.GetDebugDesiredCameraProps();
		if (debugDesiredCameraProps == null)
		{
			return;
		}
		debugDesiredCameraProps.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x060053EA RID: 21482 RVA: 0x000C5D48 File Offset: 0x000C3F48
	protected unsafe static void __CPPCALL_GetSubCameraModifications_Implementation(CameraBlueprintFunctionLibrary.__GetSubCameraModifications_FunctionParams* __Params)
	{
		TArray<SCameraDebugTool_SubCameraModification> subCameraModifications = CameraBlueprintFunctionLibrary.GetSubCameraModifications();
		if (subCameraModifications == null)
		{
			return;
		}
		subCameraModifications.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x060053EB RID: 21483 RVA: 0x000C5D74 File Offset: 0x000C3F74
	protected unsafe static void __CPPCALL_GetControllerModifications_Implementation(CameraBlueprintFunctionLibrary.__GetControllerModifications_FunctionParams* __Params)
	{
		TArray<SCameraDebugTool_ControllerModification> controllerModifications = CameraBlueprintFunctionLibrary.GetControllerModifications();
		if (controllerModifications == null)
		{
			return;
		}
		controllerModifications.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x060053EC RID: 21484 RVA: 0x000C5DA0 File Offset: 0x000C3FA0
	protected unsafe static void __CPPCALL_GetCamereModeInfo_Implementation(CameraBlueprintFunctionLibrary.__GetCamereModeInfo_FunctionParams* __Params)
	{
		UScriptStructStackOnlyPtr nativeUStructPtr = SCameraDebugTool_CameraModeInfo.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SCameraDebugTool_CameraModeInfo camereModeInfo = CameraBlueprintFunctionLibrary.GetCamereModeInfo();
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (camereModeInfo != null) ? camereModeInfo.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x060053ED RID: 21485 RVA: 0x000C5DC7 File Offset: 0x000C3FC7
	protected unsafe static void __CPPCALL_PlaySettlementCamera_Implementation(CameraBlueprintFunctionLibrary.__PlaySettlementCamera_FunctionParams* __Params)
	{
	}

	// Token: 0x060053EE RID: 21486 RVA: 0x000C5DC9 File Offset: 0x000C3FC9
	protected unsafe static void __CPPCALL_GetIsCameraTargetInScreen_Implementation(CameraBlueprintFunctionLibrary.__GetIsCameraTargetInScreen_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.GetIsCameraTargetInScreen();
	}

	// Token: 0x060053EF RID: 21487 RVA: 0x000C5DD6 File Offset: 0x000C3FD6
	protected unsafe static void __CPPCALL_EnterSpecialGameplayCamera_Implementation(CameraBlueprintFunctionLibrary.__EnterSpecialGameplayCamera_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		ACameraActor acameraActor = CameraBlueprintFunctionLibrary.EnterSpecialGameplayCamera(__Params->gameplayId);
		ptr = ((acameraActor != null) ? acameraActor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060053F0 RID: 21488 RVA: 0x000C5DF8 File Offset: 0x000C3FF8
	protected unsafe static void __CPPCALL_ExitSpecialGameplayCamera_Implementation(CameraBlueprintFunctionLibrary.__ExitSpecialGameplayCamera_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.ExitSpecialGameplayCamera();
	}

	// Token: 0x060053F1 RID: 21489 RVA: 0x000C5DFF File Offset: 0x000C3FFF
	protected unsafe static void __CPPCALL_ExitSpecialGameplayCamera2_Implementation(CameraBlueprintFunctionLibrary.__ExitSpecialGameplayCamera2_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.ExitSpecialGameplayCamera2();
	}

	// Token: 0x060053F2 RID: 21490 RVA: 0x000C5E08 File Offset: 0x000C4008
	protected unsafe static void __CPPCALL_SetAimAssistModeByKey_Implementation(CameraBlueprintFunctionLibrary.__SetAimAssistModeByKey_FunctionParams* __Params)
	{
		string key = FString.ToString((void*)(&__Params->key));
		EAimAssistMode mode = (EAimAssistMode)__Params->mode;
		CameraBlueprintFunctionLibrary.SetAimAssistModeByKey(key, mode);
	}

	// Token: 0x060053F3 RID: 21491 RVA: 0x000C5E2E File Offset: 0x000C402E
	protected unsafe static void __CPPCALL_ClearAimAssistModeByKey_Implementation(CameraBlueprintFunctionLibrary.__ClearAimAssistModeByKey_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.ClearAimAssistModeByKey(FString.ToString((void*)(&__Params->key)));
	}

	// Token: 0x060053F4 RID: 21492 RVA: 0x000C5E41 File Offset: 0x000C4041
	protected unsafe static void __CPPCALL_SetSequenceCameraCollisionState_Implementation(CameraBlueprintFunctionLibrary.__SetSequenceCameraCollisionState_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.SetSequenceCameraCollisionState(__Params->bEnable);
	}

	// Token: 0x060053F5 RID: 21493 RVA: 0x000C5E4E File Offset: 0x000C404E
	protected unsafe static void __CPPCALL_SetXRayState_Implementation(CameraBlueprintFunctionLibrary.__SetXRayState_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.SetXRayState(__Params->isEnable);
	}

	// Token: 0x060053F6 RID: 21494 RVA: 0x000C5E5B File Offset: 0x000C405B
	protected unsafe static void __CPPCALL_EnableCameraSpecificLockTarget_Implementation(CameraBlueprintFunctionLibrary.__EnableCameraSpecificLockTarget_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.EnableCameraSpecificLockTarget(__Params->entityId, __Params->priority);
	}

	// Token: 0x060053F7 RID: 21495 RVA: 0x000C5E74 File Offset: 0x000C4074
	protected unsafe static void __CPPCALL_EnableCameraSpecificLockLocation_Implementation(CameraBlueprintFunctionLibrary.__EnableCameraSpecificLockLocation_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.EnableCameraSpecificLockLocation(__Params->location, __Params->priority);
	}

	// Token: 0x060053F8 RID: 21496 RVA: 0x000C5E8D File Offset: 0x000C408D
	protected unsafe static void __CPPCALL_DisableCameraSpecificLockOnTarget_Implementation(CameraBlueprintFunctionLibrary.__DisableCameraSpecificLockOnTarget_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.DisableCameraSpecificLockOnTarget(__Params->id);
	}

	// Token: 0x060053F9 RID: 21497 RVA: 0x000C5E9A File Offset: 0x000C409A
	protected unsafe static void __CPPCALL_IsCameraSpecificLockEnable_Implementation(CameraBlueprintFunctionLibrary.__IsCameraSpecificLockEnable_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.IsCameraSpecificLockEnable();
	}

	// Token: 0x060053FA RID: 21498 RVA: 0x000C5EA7 File Offset: 0x000C40A7
	protected unsafe static void __CPPCALL_GetCameraSpecificLockEntityId_Implementation(CameraBlueprintFunctionLibrary.__GetCameraSpecificLockEntityId_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.GetCameraSpecificLockEntityId();
	}

	// Token: 0x060053FB RID: 21499 RVA: 0x000C5EB4 File Offset: 0x000C40B4
	protected unsafe static void __CPPCALL_EnableSoftLockCamera_Implementation(CameraBlueprintFunctionLibrary.__EnableSoftLockCamera_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.EnableSoftLockCamera();
	}

	// Token: 0x060053FC RID: 21500 RVA: 0x000C5EC1 File Offset: 0x000C40C1
	protected unsafe static void __CPPCALL_DisableSoftLockCamera_Implementation(CameraBlueprintFunctionLibrary.__DisableSoftLockCamera_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.DisableSoftLockCamera(__Params->handle);
	}

	// Token: 0x060053FD RID: 21501 RVA: 0x000C5ECE File Offset: 0x000C40CE
	protected unsafe static void __CPPCALL_SetCameraGravityMode_Implementation(CameraBlueprintFunctionLibrary.__SetCameraGravityMode_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.SetCameraGravityMode((ECameraGravityMode)__Params->gravityMode, __Params->gravityDirect);
	}

	// Token: 0x060053FE RID: 21502 RVA: 0x000C5EE1 File Offset: 0x000C40E1
	protected unsafe static void __CPPCALL_GetCameraGravityMode_Implementation(CameraBlueprintFunctionLibrary.__GetCameraGravityMode_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)CameraBlueprintFunctionLibrary.GetCameraGravityMode();
	}

	// Token: 0x060053FF RID: 21503 RVA: 0x000C5EF0 File Offset: 0x000C40F0
	protected unsafe static void __CPPCALL_GetCameraGravityDirect_Implementation(CameraBlueprintFunctionLibrary.__GetCameraGravityDirect_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.GetCameraGravityDirect();
	}

	// Token: 0x06005400 RID: 21504 RVA: 0x000C5EFD File Offset: 0x000C40FD
	protected unsafe static void __CPPCALL_GetCameraGravityUp_Implementation(CameraBlueprintFunctionLibrary.__GetCameraGravityUp_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.GetCameraGravityUp();
	}

	// Token: 0x06005401 RID: 21505 RVA: 0x000C5F0A File Offset: 0x000C410A
	protected unsafe static void __CPPCALL_GetCameraRotationInGravity_Implementation(CameraBlueprintFunctionLibrary.__GetCameraRotationInGravity_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.GetCameraRotationInGravity();
	}

	// Token: 0x06005402 RID: 21506 RVA: 0x000C5F17 File Offset: 0x000C4117
	protected unsafe static void __CPPCALL_GetPlayerLocationInGravity_Implementation(CameraBlueprintFunctionLibrary.__GetPlayerLocationInGravity_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.GetPlayerLocationInGravity();
	}

	// Token: 0x06005403 RID: 21507 RVA: 0x000C5F24 File Offset: 0x000C4124
	protected unsafe static void __CPPCALL_GetPlayerRotatorInGravity_Implementation(CameraBlueprintFunctionLibrary.__GetPlayerRotatorInGravity_FunctionParams* __Params)
	{
		__Params->__Result = CameraBlueprintFunctionLibrary.GetPlayerRotatorInGravity();
	}

	// Token: 0x06005404 RID: 21508 RVA: 0x000C5F31 File Offset: 0x000C4131
	protected unsafe static void __CPPCALL_SetUiCameraDebugToolEnabled_Implementation(CameraBlueprintFunctionLibrary.__SetUiCameraDebugToolEnabled_FunctionParams* __Params)
	{
	}

	// Token: 0x06005405 RID: 21509 RVA: 0x000C5F33 File Offset: 0x000C4133
	protected unsafe static void __CPPCALL_SwitchUiCameraDtSync_Implementation(CameraBlueprintFunctionLibrary.__SwitchUiCameraDtSync_FunctionParams* __Params)
	{
	}

	// Token: 0x06005406 RID: 21510 RVA: 0x000C5F38 File Offset: 0x000C4138
	protected unsafe static void __CPPCALL_GetDebugToolUiCameraProps_Implementation(CameraBlueprintFunctionLibrary.__GetDebugToolUiCameraProps_FunctionParams* __Params)
	{
		TMap<string, string> debugToolUiCameraProps = CameraBlueprintFunctionLibrary.GetDebugToolUiCameraProps();
		if (debugToolUiCameraProps == null)
		{
			return;
		}
		debugToolUiCameraProps.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x06005407 RID: 21511 RVA: 0x000C5F64 File Offset: 0x000C4164
	protected unsafe static void __CPPCALL_SwitchUiCameraArmLengthSync_Implementation(CameraBlueprintFunctionLibrary.__SwitchUiCameraArmLengthSync_FunctionParams* __Params)
	{
	}

	// Token: 0x06005408 RID: 21512 RVA: 0x000C5F66 File Offset: 0x000C4166
	protected unsafe static void __CPPCALL_OnDebugToolUiCameraArmLengthInputChanged_Implementation(CameraBlueprintFunctionLibrary.__OnDebugToolUiCameraArmLengthInputChanged_FunctionParams* __Params)
	{
		FString.ToString((void*)(&__Params->armLengthStr));
	}

	// Token: 0x06005409 RID: 21513 RVA: 0x000C5F75 File Offset: 0x000C4175
	protected unsafe static void __CPPCALL_InitSeparateCamera_Implementation(CameraBlueprintFunctionLibrary.__InitSeparateCamera_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.InitSeparateCamera(FString.ToString((void*)(&__Params->cameraName)), __Params->initLocation, __Params->initSize, __Params->enableScissorOffset);
	}

	// Token: 0x0600540A RID: 21514 RVA: 0x000C5F9C File Offset: 0x000C419C
	protected unsafe static void __CPPCALL_FadeSeparateCamera_Implementation(CameraBlueprintFunctionLibrary.__FadeSeparateCamera_FunctionParams* __Params)
	{
		string cameraName = FString.ToString((void*)(&__Params->cameraName));
		UCurveFloat orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UCurveFloat>(__Params->curve);
		CameraBlueprintFunctionLibrary.FadeSeparateCamera(cameraName, __Params->fadeTime, __Params->targetViewLocation, __Params->targetViewSize, __Params->enableScissorOffset, orCreateUObjectByNativePointer);
	}

	// Token: 0x0600540B RID: 21515 RVA: 0x000C5FDF File Offset: 0x000C41DF
	protected unsafe static void __CPPCALL_SetOcclusionDitherState_Implementation(CameraBlueprintFunctionLibrary.__SetOcclusionDitherState_FunctionParams* __Params)
	{
		CameraBlueprintFunctionLibrary.SetOcclusionDitherState(__Params->isEnable);
	}

	// Token: 0x040018BE RID: 6334
	[Nullable(2)]
	private static Vector _cacheLookAtVector;

	// Token: 0x040018BF RID: 6335
	[Nullable(2)]
	private static Vector _cacheLookAtVector1;

	// Token: 0x040018C0 RID: 6336
	[Nullable(2)]
	private static Vector _tmpVectorInternal;

	// Token: 0x040018C1 RID: 6337
	[Nullable(2)]
	private static Quat _tmpQuatInternal;

	// Token: 0x040018C2 RID: 6338
	[Nullable(2)]
	private static Vector2D _tmpVector2D1Internal;

	// Token: 0x040018C3 RID: 6339
	[Nullable(2)]
	private static Vector2D _tmpVector2D2Internal;

	// Token: 0x040018C4 RID: 6340
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Camera/CameraBlueprintFunctionLibrary.CameraBlueprintFunctionLibrary_C";

	// Token: 0x040018C5 RID: 6341
	private static IntPtr _ClassPtr;

	// Token: 0x040018C6 RID: 6342
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0200721F RID: 29215
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __OnPossess_FunctionParams
	{
		// Token: 0x04027A68 RID: 162408
		[FieldOffset(0)]
		public IntPtr pawn;

		// Token: 0x04027A69 RID: 162409
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007220 RID: 29216
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetCameraMode_FunctionParams
	{
		// Token: 0x04027A6A RID: 162410
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027A6B RID: 162411
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x02007221 RID: 29217
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetSequenceCameraActor_FunctionParams
	{
		// Token: 0x04027A6C RID: 162412
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027A6D RID: 162413
		[FieldOffset(8)]
		public IntPtr __Result;
	}

	// Token: 0x02007222 RID: 29218
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __EnterCameraMode_FunctionParams
	{
		// Token: 0x04027A6E RID: 162414
		[FieldOffset(0)]
		public byte cameraMode;

		// Token: 0x04027A6F RID: 162415
		[FieldOffset(4)]
		public float blendTime;

		// Token: 0x04027A70 RID: 162416
		[FieldOffset(8)]
		public TEnumAsByte<UnrealEngine.EViewTargetBlendFunction> blendFunction;

		// Token: 0x04027A71 RID: 162417
		[FieldOffset(12)]
		public float blendExp;

		// Token: 0x04027A72 RID: 162418
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007223 RID: 29219
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ExitCameraMode_FunctionParams
	{
		// Token: 0x04027A73 RID: 162419
		[FieldOffset(0)]
		public byte cameraMode;

		// Token: 0x04027A74 RID: 162420
		[FieldOffset(4)]
		public float blendTime;

		// Token: 0x04027A75 RID: 162421
		[FieldOffset(8)]
		public TEnumAsByte<UnrealEngine.EViewTargetBlendFunction> blendFunction;

		// Token: 0x04027A76 RID: 162422
		[FieldOffset(12)]
		public float blendExp;

		// Token: 0x04027A77 RID: 162423
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007224 RID: 29220
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetCameraRotation_FunctionParams
	{
		// Token: 0x04027A78 RID: 162424
		[FieldOffset(0)]
		public FRotator rotator;

		// Token: 0x04027A79 RID: 162425
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007225 RID: 29221
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __IsTargetSocketLocationValid_FunctionParams
	{
		// Token: 0x04027A7A RID: 162426
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027A7B RID: 162427
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x02007226 RID: 29222
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetTargetSocketLocation_FunctionParams
	{
		// Token: 0x04027A7C RID: 162428
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027A7D RID: 162429
		[FieldOffset(8)]
		public FVectorDouble __Result;
	}

	// Token: 0x02007227 RID: 29223
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetFightCameraLocation_FunctionParams
	{
		// Token: 0x04027A7E RID: 162430
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027A7F RID: 162431
		[FieldOffset(8)]
		public FVectorDouble __Result;
	}

	// Token: 0x02007228 RID: 29224
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetFightCameraRotation_FunctionParams
	{
		// Token: 0x04027A80 RID: 162432
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027A81 RID: 162433
		[FieldOffset(8)]
		public FRotator __Result;
	}

	// Token: 0x02007229 RID: 29225
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetFightCameraForward_FunctionParams
	{
		// Token: 0x04027A82 RID: 162434
		[FieldOffset(0)]
		public int index;

		// Token: 0x04027A83 RID: 162435
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04027A84 RID: 162436
		[FieldOffset(16)]
		public FVector __Result;
	}

	// Token: 0x0200722A RID: 29226
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetFightCameraActor_FunctionParams
	{
		// Token: 0x04027A85 RID: 162437
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027A86 RID: 162438
		[FieldOffset(8)]
		public IntPtr __Result;
	}

	// Token: 0x0200722B RID: 29227
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetFightCameraFollow_FunctionParams
	{
		// Token: 0x04027A87 RID: 162439
		[FieldOffset(0)]
		public bool follow;

		// Token: 0x04027A88 RID: 162440
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200722C RID: 29228
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 480)]
	protected ref struct __ApplyCameraModify_FunctionParams
	{
		// Token: 0x04027A89 RID: 162441
		[FieldOffset(0)]
		public FGameplayTag tag;

		// Token: 0x04027A8A RID: 162442
		[FieldOffset(12)]
		public float duration;

		// Token: 0x04027A8B RID: 162443
		[FieldOffset(16)]
		public float blendInTime;

		// Token: 0x04027A8C RID: 162444
		[FieldOffset(20)]
		public float blendOutTime;

		// Token: 0x04027A8D RID: 162445
		[FieldOffset(24)]
		public float breakBlendOutTime;

		// Token: 0x04027A8E RID: 162446
		[FieldOffset(32)]
		public byte cameraModifySettings;

		// Token: 0x04027A8F RID: 162447
		[FieldOffset(392)]
		public IntPtr montage;

		// Token: 0x04027A90 RID: 162448
		[FieldOffset(400)]
		public byte blendInCurve;

		// Token: 0x04027A91 RID: 162449
		[FieldOffset(416)]
		public byte blendOutCurve;

		// Token: 0x04027A92 RID: 162450
		[FieldOffset(432)]
		public FString cameraAttachSocket;

		// Token: 0x04027A93 RID: 162451
		[FieldOffset(448)]
		public int entityId;

		// Token: 0x04027A94 RID: 162452
		[FieldOffset(452)]
		public byte cameraEffectiveClientType;

		// Token: 0x04027A95 RID: 162453
		[FieldOffset(456)]
		public byte cameraModifierConditions;

		// Token: 0x04027A96 RID: 162454
		[FieldOffset(472)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200722D RID: 29229
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ForceStopCameraModify_FunctionParams
	{
		// Token: 0x04027A97 RID: 162455
		[FieldOffset(0)]
		public bool withFadeOut;

		// Token: 0x04027A98 RID: 162456
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200722E RID: 29230
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __ApplyCameraGuide_FunctionParams
	{
		// Token: 0x04027A99 RID: 162457
		[FieldOffset(0)]
		public FVector lookAt;

		// Token: 0x04027A9A RID: 162458
		[FieldOffset(12)]
		public float fadeInTime;

		// Token: 0x04027A9B RID: 162459
		[FieldOffset(16)]
		public float stayTime;

		// Token: 0x04027A9C RID: 162460
		[FieldOffset(20)]
		public float fadeOutTime;

		// Token: 0x04027A9D RID: 162461
		[FieldOffset(24)]
		public bool lockCameraInput;

		// Token: 0x04027A9E RID: 162462
		[FieldOffset(28)]
		public FVector endPosition;

		// Token: 0x04027A9F RID: 162463
		[FieldOffset(40)]
		public float fov;

		// Token: 0x04027AA0 RID: 162464
		[FieldOffset(44)]
		public bool ignoreAdjustYaw;

		// Token: 0x04027AA1 RID: 162465
		[FieldOffset(45)]
		public bool staticCamera;

		// Token: 0x04027AA2 RID: 162466
		[FieldOffset(48)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200722F RID: 29231
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ExitCameraGuide_FunctionParams
	{
		// Token: 0x04027AA3 RID: 162467
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007230 RID: 29232
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __EnterCameraExplore_FunctionParams
	{
		// Token: 0x04027AA4 RID: 162468
		[FieldOffset(0)]
		public int id;

		// Token: 0x04027AA5 RID: 162469
		[FieldOffset(4)]
		public FVector lookAt1;

		// Token: 0x04027AA6 RID: 162470
		[FieldOffset(16)]
		public FVector lookAt2;

		// Token: 0x04027AA7 RID: 162471
		[FieldOffset(28)]
		public float prepTime;

		// Token: 0x04027AA8 RID: 162472
		[FieldOffset(32)]
		public float fadeDistance;

		// Token: 0x04027AA9 RID: 162473
		[FieldOffset(36)]
		public float armLengthMin;

		// Token: 0x04027AAA RID: 162474
		[FieldOffset(40)]
		public float armLengthMax;

		// Token: 0x04027AAB RID: 162475
		[FieldOffset(48)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007231 RID: 29233
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ExitCameraExplore_FunctionParams
	{
		// Token: 0x04027AAC RID: 162476
		[FieldOffset(0)]
		public int id;

		// Token: 0x04027AAD RID: 162477
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007232 RID: 29234
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 168)]
	protected ref struct __PlayCameraSequence_FunctionParams
	{
		// Token: 0x04027AAE RID: 162478
		[FieldOffset(0)]
		public byte 生效客户端;

		// Token: 0x04027AAF RID: 162479
		[FieldOffset(4)]
		public int entityId;

		// Token: 0x04027AB0 RID: 162480
		[FieldOffset(8)]
		public byte settings;

		// Token: 0x04027AB1 RID: 162481
		[FieldOffset(80)]
		public bool resetLockOnCamera;

		// Token: 0x04027AB2 RID: 162482
		[FieldOffset(84)]
		public FRotator additiveRotation;

		// Token: 0x04027AB3 RID: 162483
		[FieldOffset(96)]
		public FString cameraAttachSocket;

		// Token: 0x04027AB4 RID: 162484
		[FieldOffset(112)]
		public FString cameraDetectSocket;

		// Token: 0x04027AB5 RID: 162485
		[FieldOffset(128)]
		public FVector extraSphereLocation;

		// Token: 0x04027AB6 RID: 162486
		[FieldOffset(140)]
		public float extraDetectSphereRadius;

		// Token: 0x04027AB7 RID: 162487
		[FieldOffset(144)]
		public bool isShowExtraSphere;

		// Token: 0x04027AB8 RID: 162488
		[FieldOffset(145)]
		public bool isIgnoreCharacterCollision;

		// Token: 0x04027AB9 RID: 162489
		[FieldOffset(146)]
		public bool disableMovementInput;

		// Token: 0x04027ABA RID: 162490
		[FieldOffset(147)]
		public bool disableLookAtInput;

		// Token: 0x04027ABB RID: 162491
		[FieldOffset(148)]
		public bool disableMotionBlur;

		// Token: 0x04027ABC RID: 162492
		[FieldOffset(152)]
		public IntPtr __WorldContext;

		// Token: 0x04027ABD RID: 162493
		[FieldOffset(160)]
		public bool __Result;
	}

	// Token: 0x02007233 RID: 29235
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetWidgetCameraActor_FunctionParams
	{
		// Token: 0x04027ABE RID: 162494
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027ABF RID: 162495
		[FieldOffset(8)]
		public IntPtr __Result;
	}

	// Token: 0x02007234 RID: 29236
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __SetWidgetCameraBlendParams_FunctionParams
	{
		// Token: 0x04027AC0 RID: 162496
		[FieldOffset(0)]
		public float blendTime;

		// Token: 0x04027AC1 RID: 162497
		[FieldOffset(4)]
		public TEnumAsByte<UnrealEngine.EViewTargetBlendFunction> blendFunction;

		// Token: 0x04027AC2 RID: 162498
		[FieldOffset(8)]
		public float blendExp;

		// Token: 0x04027AC3 RID: 162499
		[FieldOffset(12)]
		public bool blendLocation;

		// Token: 0x04027AC4 RID: 162500
		[FieldOffset(13)]
		public bool isRelativeLocation;

		// Token: 0x04027AC5 RID: 162501
		[FieldOffset(14)]
		public bool overrideLocation;

		// Token: 0x04027AC6 RID: 162502
		[FieldOffset(16)]
		public FVector newLocation;

		// Token: 0x04027AC7 RID: 162503
		[FieldOffset(28)]
		public bool blendRotation;

		// Token: 0x04027AC8 RID: 162504
		[FieldOffset(29)]
		public bool isRelativeRotation;

		// Token: 0x04027AC9 RID: 162505
		[FieldOffset(30)]
		public bool overrideRotation;

		// Token: 0x04027ACA RID: 162506
		[FieldOffset(32)]
		public FRotator newRotation;

		// Token: 0x04027ACB RID: 162507
		[FieldOffset(48)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007235 RID: 29237
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __PlayCameraOrbital_FunctionParams
	{
		// Token: 0x04027ACC RID: 162508
		[FieldOffset(0)]
		public IntPtr levelSequence;

		// Token: 0x04027ACD RID: 162509
		[FieldOffset(8)]
		public FVector startLocation;

		// Token: 0x04027ACE RID: 162510
		[FieldOffset(20)]
		public FVector endLocation;

		// Token: 0x04027ACF RID: 162511
		[FieldOffset(32)]
		public float blendInTime;

		// Token: 0x04027AD0 RID: 162512
		[FieldOffset(36)]
		public float blendOutTime;

		// Token: 0x04027AD1 RID: 162513
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007236 RID: 29238
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __StopCameraOrbital_FunctionParams
	{
		// Token: 0x04027AD2 RID: 162514
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007237 RID: 29239
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ResetFightCameraPitchAndArmLength_FunctionParams
	{
		// Token: 0x04027AD3 RID: 162515
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007238 RID: 29240
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EnterSequenceDialogue_FunctionParams
	{
		// Token: 0x04027AD4 RID: 162516
		[FieldOffset(0)]
		public IntPtr target;

		// Token: 0x04027AD5 RID: 162517
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007239 RID: 29241
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ExitSequenceDialogue_FunctionParams
	{
		// Token: 0x04027AD6 RID: 162518
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200723A RID: 29242
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ReloadCameraConfig_FunctionParams
	{
		// Token: 0x04027AD7 RID: 162519
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200723B RID: 29243
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetAimAssistMode_FunctionParams
	{
		// Token: 0x04027AD8 RID: 162520
		[FieldOffset(0)]
		public byte mode;

		// Token: 0x04027AD9 RID: 162521
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200723C RID: 29244
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __IsRoleOnCameraRight_FunctionParams
	{
		// Token: 0x04027ADA RID: 162522
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027ADB RID: 162523
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x0200723D RID: 29245
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetCameraDebugToolEnabled_FunctionParams
	{
		// Token: 0x04027ADC RID: 162524
		[FieldOffset(0)]
		public bool inEnable;

		// Token: 0x04027ADD RID: 162525
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200723E RID: 29246
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SwitchCameraDebugRotatorEnabled_FunctionParams
	{
		// Token: 0x04027ADE RID: 162526
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200723F RID: 29247
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SwitchCameraDebugToolDrawCameraCollision_FunctionParams
	{
		// Token: 0x04027ADF RID: 162527
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007240 RID: 29248
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SwitchCameraDebugToolDrawSpringArm_FunctionParams
	{
		// Token: 0x04027AE0 RID: 162528
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007241 RID: 29249
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SwitchCameraDebugToolDrawFocusTargetLine_FunctionParams
	{
		// Token: 0x04027AE1 RID: 162529
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007242 RID: 29250
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SwitchCameraDebugToolDrawSpringArmEdgeRange_FunctionParams
	{
		// Token: 0x04027AE2 RID: 162530
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007243 RID: 29251
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SwitchCameraDebugToolDrawLockCameraMoveLine_FunctionParams
	{
		// Token: 0x04027AE3 RID: 162531
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007244 RID: 29252
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SwitchCameraDebugToolDrawSettlementCamera_FunctionParams
	{
		// Token: 0x04027AE4 RID: 162532
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007245 RID: 29253
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SwitchCameraDebugToolDrawCameraZone_FunctionParams
	{
		// Token: 0x04027AE5 RID: 162533
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007246 RID: 29254
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 72)]
	protected ref struct __GetDebugDesiredCameraProps_FunctionParams
	{
		// Token: 0x04027AE6 RID: 162534
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027AE7 RID: 162535
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x02007247 RID: 29255
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetSubCameraModifications_FunctionParams
	{
		// Token: 0x04027AE8 RID: 162536
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027AE9 RID: 162537
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x02007248 RID: 29256
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetControllerModifications_FunctionParams
	{
		// Token: 0x04027AEA RID: 162538
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027AEB RID: 162539
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x02007249 RID: 29257
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 144)]
	protected ref struct __GetCamereModeInfo_FunctionParams
	{
		// Token: 0x04027AEC RID: 162540
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027AED RID: 162541
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x0200724A RID: 29258
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __PlaySettlementCamera_FunctionParams
	{
		// Token: 0x04027AEE RID: 162542
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200724B RID: 29259
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetIsCameraTargetInScreen_FunctionParams
	{
		// Token: 0x04027AEF RID: 162543
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027AF0 RID: 162544
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x0200724C RID: 29260
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __EnterSpecialGameplayCamera_FunctionParams
	{
		// Token: 0x04027AF1 RID: 162545
		[FieldOffset(0)]
		public int gameplayId;

		// Token: 0x04027AF2 RID: 162546
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04027AF3 RID: 162547
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x0200724D RID: 29261
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ExitSpecialGameplayCamera_FunctionParams
	{
		// Token: 0x04027AF4 RID: 162548
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200724E RID: 29262
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ExitSpecialGameplayCamera2_FunctionParams
	{
		// Token: 0x04027AF5 RID: 162549
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200724F RID: 29263
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SetAimAssistModeByKey_FunctionParams
	{
		// Token: 0x04027AF6 RID: 162550
		[FieldOffset(0)]
		public FString key;

		// Token: 0x04027AF7 RID: 162551
		[FieldOffset(16)]
		public byte mode;

		// Token: 0x04027AF8 RID: 162552
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007250 RID: 29264
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ClearAimAssistModeByKey_FunctionParams
	{
		// Token: 0x04027AF9 RID: 162553
		[FieldOffset(0)]
		public FString key;

		// Token: 0x04027AFA RID: 162554
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007251 RID: 29265
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetSequenceCameraCollisionState_FunctionParams
	{
		// Token: 0x04027AFB RID: 162555
		[FieldOffset(0)]
		public bool bEnable;

		// Token: 0x04027AFC RID: 162556
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007252 RID: 29266
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetXRayState_FunctionParams
	{
		// Token: 0x04027AFD RID: 162557
		[FieldOffset(0)]
		public bool isEnable;

		// Token: 0x04027AFE RID: 162558
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007253 RID: 29267
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __EnableCameraSpecificLockTarget_FunctionParams
	{
		// Token: 0x04027AFF RID: 162559
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04027B00 RID: 162560
		[FieldOffset(4)]
		public float priority;

		// Token: 0x04027B01 RID: 162561
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04027B02 RID: 162562
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x02007254 RID: 29268
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __EnableCameraSpecificLockLocation_FunctionParams
	{
		// Token: 0x04027B03 RID: 162563
		[FieldOffset(0)]
		public FVectorDouble location;

		// Token: 0x04027B04 RID: 162564
		[FieldOffset(24)]
		public float priority;

		// Token: 0x04027B05 RID: 162565
		[FieldOffset(32)]
		public IntPtr __WorldContext;

		// Token: 0x04027B06 RID: 162566
		[FieldOffset(40)]
		public int __Result;
	}

	// Token: 0x02007255 RID: 29269
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DisableCameraSpecificLockOnTarget_FunctionParams
	{
		// Token: 0x04027B07 RID: 162567
		[FieldOffset(0)]
		public int id;

		// Token: 0x04027B08 RID: 162568
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007256 RID: 29270
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __IsCameraSpecificLockEnable_FunctionParams
	{
		// Token: 0x04027B09 RID: 162569
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027B0A RID: 162570
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x02007257 RID: 29271
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetCameraSpecificLockEntityId_FunctionParams
	{
		// Token: 0x04027B0B RID: 162571
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027B0C RID: 162572
		[FieldOffset(8)]
		public int __Result;
	}

	// Token: 0x02007258 RID: 29272
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EnableSoftLockCamera_FunctionParams
	{
		// Token: 0x04027B0D RID: 162573
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027B0E RID: 162574
		[FieldOffset(8)]
		public int __Result;
	}

	// Token: 0x02007259 RID: 29273
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DisableSoftLockCamera_FunctionParams
	{
		// Token: 0x04027B0F RID: 162575
		[FieldOffset(0)]
		public int handle;

		// Token: 0x04027B10 RID: 162576
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200725A RID: 29274
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetCameraGravityMode_FunctionParams
	{
		// Token: 0x04027B11 RID: 162577
		[FieldOffset(0)]
		public byte gravityMode;

		// Token: 0x04027B12 RID: 162578
		[FieldOffset(8)]
		public FVectorDouble gravityDirect;

		// Token: 0x04027B13 RID: 162579
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200725B RID: 29275
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetCameraGravityMode_FunctionParams
	{
		// Token: 0x04027B14 RID: 162580
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027B15 RID: 162581
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x0200725C RID: 29276
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetCameraGravityDirect_FunctionParams
	{
		// Token: 0x04027B16 RID: 162582
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027B17 RID: 162583
		[FieldOffset(8)]
		public FVectorDouble __Result;
	}

	// Token: 0x0200725D RID: 29277
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetCameraGravityUp_FunctionParams
	{
		// Token: 0x04027B18 RID: 162584
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027B19 RID: 162585
		[FieldOffset(8)]
		public FVectorDouble __Result;
	}

	// Token: 0x0200725E RID: 29278
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCameraRotationInGravity_FunctionParams
	{
		// Token: 0x04027B1A RID: 162586
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027B1B RID: 162587
		[FieldOffset(8)]
		public FRotator __Result;
	}

	// Token: 0x0200725F RID: 29279
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetPlayerLocationInGravity_FunctionParams
	{
		// Token: 0x04027B1C RID: 162588
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027B1D RID: 162589
		[FieldOffset(8)]
		public FVectorDouble __Result;
	}

	// Token: 0x02007260 RID: 29280
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetPlayerRotatorInGravity_FunctionParams
	{
		// Token: 0x04027B1E RID: 162590
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027B1F RID: 162591
		[FieldOffset(8)]
		public FRotator __Result;
	}

	// Token: 0x02007261 RID: 29281
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetUiCameraDebugToolEnabled_FunctionParams
	{
		// Token: 0x04027B20 RID: 162592
		[FieldOffset(0)]
		public bool enabled;

		// Token: 0x04027B21 RID: 162593
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007262 RID: 29282
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SwitchUiCameraDtSync_FunctionParams
	{
		// Token: 0x04027B22 RID: 162594
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007263 RID: 29283
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 72)]
	protected ref struct __GetDebugToolUiCameraProps_FunctionParams
	{
		// Token: 0x04027B23 RID: 162595
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027B24 RID: 162596
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x02007264 RID: 29284
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SwitchUiCameraArmLengthSync_FunctionParams
	{
		// Token: 0x04027B25 RID: 162597
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007265 RID: 29285
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __OnDebugToolUiCameraArmLengthInputChanged_FunctionParams
	{
		// Token: 0x04027B26 RID: 162598
		[FieldOffset(0)]
		public FString armLengthStr;

		// Token: 0x04027B27 RID: 162599
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007266 RID: 29286
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __InitSeparateCamera_FunctionParams
	{
		// Token: 0x04027B28 RID: 162600
		[FieldOffset(0)]
		public FString cameraName;

		// Token: 0x04027B29 RID: 162601
		[FieldOffset(16)]
		public FVector2D initLocation;

		// Token: 0x04027B2A RID: 162602
		[FieldOffset(24)]
		public FVector2D initSize;

		// Token: 0x04027B2B RID: 162603
		[FieldOffset(32)]
		public bool enableScissorOffset;

		// Token: 0x04027B2C RID: 162604
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007267 RID: 29287
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __FadeSeparateCamera_FunctionParams
	{
		// Token: 0x04027B2D RID: 162605
		[FieldOffset(0)]
		public FString cameraName;

		// Token: 0x04027B2E RID: 162606
		[FieldOffset(16)]
		public float fadeTime;

		// Token: 0x04027B2F RID: 162607
		[FieldOffset(20)]
		public FVector2D targetViewLocation;

		// Token: 0x04027B30 RID: 162608
		[FieldOffset(28)]
		public FVector2D targetViewSize;

		// Token: 0x04027B31 RID: 162609
		[FieldOffset(36)]
		public bool enableScissorOffset;

		// Token: 0x04027B32 RID: 162610
		[FieldOffset(40)]
		public IntPtr curve;

		// Token: 0x04027B33 RID: 162611
		[FieldOffset(48)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02007268 RID: 29288
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetOcclusionDitherState_FunctionParams
	{
		// Token: 0x04027B34 RID: 162612
		[FieldOffset(0)]
		public bool isEnable;

		// Token: 0x04027B35 RID: 162613
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}
}
