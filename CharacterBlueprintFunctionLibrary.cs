using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Data.Fight.Struct;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002E2C RID: 11820
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/CharacterBlueprintFunctionLibrary.CharacterBlueprintFunctionLibrary_C")]
public class CharacterBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06017EFF RID: 98047 RVA: 0x006B4CA1 File Offset: 0x006B2EA1
	static CharacterBlueprintFunctionLibrary()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterBlueprintFunctionLibrary.CreateStaticDefaultValue), new Action(CharacterBlueprintFunctionLibrary.ResetStaticDefaultValue));
	}

	// Token: 0x06017F00 RID: 98048 RVA: 0x006B4CC0 File Offset: 0x006B2EC0
	public static void CreateStaticDefaultValue()
	{
		CharacterBlueprintFunctionLibrary._entityTimeDilation = default(SEntityTimeDilation);
	}

	// Token: 0x06017F01 RID: 98049 RVA: 0x006B4CCD File Offset: 0x006B2ECD
	public static void ResetStaticDefaultValue()
	{
		CharacterBlueprintFunctionLibrary._entityTimeDilation = default(SEntityTimeDilation);
		CharacterBlueprintFunctionLibrary.ResumeTimeHandle = null;
	}

	// Token: 0x06017F02 RID: 98050 RVA: 0x006B4CE0 File Offset: 0x006B2EE0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetPartCollisionSwitch(TsBaseCharacter character, string compName, bool isBlockPawn, bool isBulletDetect, bool isBlockCamera, bool isActiveOcclusionDither)
	{
		if (character.IsValid())
		{
			CharacterActorComponent characterActorComponent = character.CharacterActorComponent;
			if (characterActorComponent != null && characterActorComponent.Valid)
			{
				character.CharacterActorComponent.SetPartCollisionSwitch(compName, isBlockPawn, isBulletDetect, isBlockCamera, isActiveOcclusionDither, false);
				return;
			}
		}
		Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.HCW, "传入的character为空", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06017F03 RID: 98051 RVA: 0x006B4D3C File Offset: 0x006B2F3C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ResetPartCollisionSwitch(TsBaseCharacter character, string compName)
	{
		CharacterActorComponent characterActorComponent = character.CharacterActorComponent;
		SPartHitEffect partConf = characterActorComponent.GetPartConf(compName);
		if (partConf != null)
		{
			characterActorComponent.SetPartCollisionSwitch(compName, partConf.IsBlockPawn, partConf.IsBulletDetect, partConf.IsBlockCamera, partConf.IsActiveOcclusionDither, false);
		}
	}

	// Token: 0x06017F04 RID: 98052 RVA: 0x006B4D84 File Offset: 0x006B2F84
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TsBaseCharacter GetCharacterActorByEntityId(int id)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (entity == null || !entity.Valid)
		{
			return null;
		}
		CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
		return ((component != null) ? component.Owner : null) as TsBaseCharacter;
	}

	// Token: 0x06017F05 RID: 98053 RVA: 0x006B4DC1 File Offset: 0x006B2FC1
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void CharacterOperationRecord(bool open)
	{
		CharacterStatisticsComponent.OperationRecord(open);
		if (open)
		{
			CharacterGasDebugComponent.BeginRecord();
			return;
		}
		CharacterGasDebugComponent.EndRecord();
	}

	// Token: 0x06017F06 RID: 98054 RVA: 0x006B4DD8 File Offset: 0x006B2FD8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool GetStatisticsOpen()
	{
		return CharacterStatisticsComponent.OpenOperationRecord;
	}

	// Token: 0x06017F07 RID: 98055 RVA: 0x006B4DE0 File Offset: 0x006B2FE0
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool SaveCharacterOperationRecord()
	{
		CharacterGasDebugComponent.EndRecord();
		string text = CharacterStatisticsComponent.ExportRecord();
		return text != null && (UKuroStaticLibrary.SaveStringToFile(text, UBlueprintPathsLibrary.ProjectSavedDir() + "Statistics/FightDataRecord/OperationRecord.csv", true) && CharacterBlueprintFunctionLibrary.SaveCharacterStatisticsData());
	}

	// Token: 0x06017F08 RID: 98056 RVA: 0x006B4E20 File Offset: 0x006B3020
	public static bool SaveCharacterStatisticsData()
	{
		string text = CharacterStatisticsComponent.ExportStatisticsByAttackType();
		string text2 = CharacterStatisticsComponent.ExportStatisticsBySkillType();
		bool flag = text.Length == 0;
		bool flag2 = text2.Length == 0;
		if (flag || flag2)
		{
			return false;
		}
		string str = UBlueprintPathsLibrary.ProjectSavedDir();
		bool flag3 = UKuroStaticLibrary.SaveStringToFile(text, str + "Statistics/FightDataRecord/DamageStatisticsRecord_B.csv", true);
		bool flag4 = UKuroStaticLibrary.SaveStringToFile(text2, str + "Statistics/FightDataRecord/DamageStatisticsRecord_A.csv", true);
		return flag3 && flag4;
	}

	// Token: 0x06017F09 RID: 98057 RVA: 0x006B4E86 File Offset: 0x006B3086
	[UFunction(EFunctionFlags.FUNC_None)]
	public static float GetOperationRecordCount()
	{
		return (float)CharacterStatisticsComponent.OperationRecordCount();
	}

	// Token: 0x06017F0A RID: 98058 RVA: 0x006B4E8E File Offset: 0x006B308E
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void CleanupOperationRecord()
	{
		CharacterStatisticsComponent.CleanupOperationRecord();
		CharacterStatisticsComponent.CleanupRecordData();
		CharacterGasDebugComponent.CleanupRecord();
	}

	// Token: 0x06017F0B RID: 98059 RVA: 0x006B4E9F File Offset: 0x006B309F
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetHalfLengthRecord(float sideLenHalf)
	{
		CharacterStatisticsComponent.HalfLengthRecordSquared = Math.Pow((double)sideLenHalf, 2.0);
	}

	// Token: 0x06017F0C RID: 98060 RVA: 0x006B4EB8 File Offset: 0x006B30B8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetCombatStarted(bool started, int attackerIndex, int targetIndex, bool isDamage, bool isCure, bool isSkillUsed, bool isState, bool isKill, bool isReborn)
	{
		List<ECombatDataType> list = new List<ECombatDataType>();
		if (isDamage)
		{
			list.Add(ECombatDataType.Damage);
		}
		if (isCure)
		{
			list.Add(ECombatDataType.Heal);
		}
		if (isSkillUsed)
		{
			list.Add(ECombatDataType.SkillUsed);
		}
		if (isState)
		{
			list.Add(ECombatDataType.State);
		}
		if (isKill)
		{
			list.Add(ECombatDataType.Kill);
		}
		if (isReborn)
		{
			list.Add(ECombatDataType.Revive);
		}
		CharacterStatisticsComponent.SetCombatStarted(started, list, attackerIndex, targetIndex);
	}

	// Token: 0x06017F0D RID: 98061 RVA: 0x006B4F18 File Offset: 0x006B3118
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetTypeOpen(bool isDamage, bool isCure, bool isSkillUsed, bool isState, bool isKill, bool isReborn)
	{
		List<ECombatDataType> list = new List<ECombatDataType>();
		if (isDamage)
		{
			list.Add(ECombatDataType.Damage);
		}
		if (isCure)
		{
			list.Add(ECombatDataType.Heal);
		}
		if (isSkillUsed)
		{
			list.Add(ECombatDataType.SkillUsed);
		}
		if (isState)
		{
			list.Add(ECombatDataType.State);
		}
		if (isKill)
		{
			list.Add(ECombatDataType.Kill);
		}
		if (isReborn)
		{
			list.Add(ECombatDataType.Revive);
		}
		CharacterStatisticsComponent.SetTypeOpen(list);
	}

	// Token: 0x06017F0E RID: 98062 RVA: 0x006B4F6F File Offset: 0x006B316F
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TArray<string> GetAttackerCombatEntities()
	{
		return CharacterStatisticsComponent.GetAttackerCombatEntities();
	}

	// Token: 0x06017F0F RID: 98063 RVA: 0x006B4F76 File Offset: 0x006B3176
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TArray<string> GetTargetCombatEntities()
	{
		return CharacterStatisticsComponent.GetTargetCombatEntities();
	}

	// Token: 0x06017F10 RID: 98064 RVA: 0x006B4F7D File Offset: 0x006B317D
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetCurrentAttacker(int index)
	{
		CharacterStatisticsComponent.SetCurrentAttacker(index);
	}

	// Token: 0x06017F11 RID: 98065 RVA: 0x006B4F85 File Offset: 0x006B3185
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetCurrentTarget(int index)
	{
		CharacterStatisticsComponent.SetCurrentTarget(index);
	}

	// Token: 0x06017F12 RID: 98066 RVA: 0x006B4F8D File Offset: 0x006B318D
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool GetItemsReset()
	{
		return CharacterStatisticsComponent.ItemReset;
	}

	// Token: 0x06017F13 RID: 98067 RVA: 0x006B4F94 File Offset: 0x006B3194
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void OnItemsResetFinished()
	{
		CharacterStatisticsComponent.OnItemsResetFinished();
	}

	// Token: 0x06017F14 RID: 98068 RVA: 0x006B4F9B File Offset: 0x006B319B
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TArray<string> GetSubItemsListView(int startIndex, int length)
	{
		return CharacterStatisticsComponent.GetSubItemsListView(startIndex, length);
	}

	// Token: 0x06017F15 RID: 98069 RVA: 0x006B4FA4 File Offset: 0x006B31A4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int GetItemListViewCount()
	{
		return CharacterStatisticsComponent.GetItemListViewCount();
	}

	// Token: 0x06017F16 RID: 98070 RVA: 0x006B4FAB File Offset: 0x006B31AB
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void TestLeaveSplineMove(TsBaseCharacter actor)
	{
		actor.GetEntityNoBlueprint().GetComponent<CharacterSplineMoveComponent>().EndSplineMove(1);
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ExitCameraSpline();
	}

	// Token: 0x06017F17 RID: 98071 RVA: 0x006B4FD8 File Offset: 0x006B31D8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FTransformDouble GetBaseCharacterTransform()
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
		if (characterActorComponent != null)
		{
			return characterActorComponent.ActorTransform;
		}
		return Singleton<MathUtils>.Instance.DefaultTransformDouble;
	}

	// Token: 0x06017F18 RID: 98072 RVA: 0x006B500C File Offset: 0x006B320C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetActorExtraSkeletalMeshComponent(int entityId, USkeletalMeshComponent skeletalMeshComponent)
	{
		EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(entityId);
		if (handle == null)
		{
			return;
		}
		WorldEntity entity = handle.Entity;
		CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
		if (characterActorComponent == null)
		{
			return;
		}
		characterActorComponent.AddExtraSkeletalMeshComponent(skeletalMeshComponent);
	}

	// Token: 0x06017F19 RID: 98073 RVA: 0x006B5048 File Offset: 0x006B3248
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool CanCharacterMonsterOrSummonedDisplayEffect(TsBaseCharacter owner)
	{
		if (owner == null)
		{
			return true;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(owner.EntityId);
		return entityById == null || !entityById.Valid || CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(entityById);
	}

	// Token: 0x06017F1A RID: 98074 RVA: 0x006B508C File Offset: 0x006B328C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void DetachFromHost(int id, bool isDetachFollower, bool isRecursion)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (entity == null || !entity.Valid)
		{
			return;
		}
		CharacterAttachComponent component = entity.GetComponent<CharacterAttachComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		component.DetachFromHost(isDetachFollower, isRecursion, true, null);
	}

	// Token: 0x06017F1B RID: 98075 RVA: 0x006B50D6 File Offset: 0x006B32D6
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVectorDouble GetCharacterGravityDirect()
	{
		GravityUtils instance = Singleton<GravityUtils>.Instance;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		return instance.GetGravityDirectForActor((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null).ToUeVector(false);
	}

	// Token: 0x06017F1C RID: 98076 RVA: 0x006B50F9 File Offset: 0x006B32F9
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVectorDouble GetCharacterGravityUp()
	{
		GravityUtils instance = Singleton<GravityUtils>.Instance;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		return instance.GetGravityUpForActor((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null).ToUeVector(false);
	}

	// Token: 0x06017F1D RID: 98077 RVA: 0x006B511C File Offset: 0x006B331C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetGravityDirect(int entityId, FVectorDouble gravityDirect)
	{
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
		if (entityById == null || !entityById.Valid)
		{
			return;
		}
		BaseGravityComponent component = entityById.Entity.GetComponent<BaseGravityComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		component.SetGravityByPriority(0, gravityDirect, true, -1f, false);
	}

	// Token: 0x06017F1E RID: 98078 RVA: 0x006B5170 File Offset: 0x006B3370
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static void EnableSelfCentered(ESelfCenteredMode selfCenteredMode, float timeDilation, float duration)
	{
		if (CharacterBlueprintFunctionLibrary.ResumeTimeHandle != null && CharacterBlueprintFunctionLibrary.ResumeTimeHandle.Valid())
		{
			TimerSystem.Instance.Remove(CharacterBlueprintFunctionLibrary.ResumeTimeHandle);
			CharacterBlueprintFunctionLibrary.ResumeTimeHandle = null;
		}
		float interval = duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond * timeDilation;
		ControllerBase<CharacterController>.Instance.EnterSelfCenteredMode(selfCenteredMode, timeDilation, duration);
		if (interval > 0f)
		{
			CharacterBlueprintFunctionLibrary.ResumeTimeHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.TimeDilation;
				ELogAuthor author2 = ELogAuthor.LJM;
				string message2 = "EnableSelfCentered StopTimerSystem";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("selfCenteredMode", selfCenteredMode);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("timeDilation", timeDilation);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("interval(ms)", interval);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3);
				string item2 = "timerHandle.Id";
				TimerHandle resumeTimeHandle2 = CharacterBlueprintFunctionLibrary.ResumeTimeHandle;
				ptr2 = new ValueTuple<string, object>(item2, (resumeTimeHandle2 != null) ? new int?(resumeTimeHandle2.Id) : null);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
				if (selfCenteredMode == ESelfCenteredMode.Skill)
				{
					ControllerBase<CharacterController>.Instance.ExitSkillSelfCenteredMode();
				}
				else
				{
					ControllerBase<CharacterController>.Instance.ExitSelfCenteredMode(selfCenteredMode);
				}
				if (CharacterBlueprintFunctionLibrary.ResumeTimeHandle != null && CharacterBlueprintFunctionLibrary.ResumeTimeHandle.Valid())
				{
					TimerSystem.Instance.Remove(CharacterBlueprintFunctionLibrary.ResumeTimeHandle);
					CharacterBlueprintFunctionLibrary.ResumeTimeHandle = null;
				}
			}, (float)((int)interval), null, null, true, 1f);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TimeDilation;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "EnableSelfCentered EnableTimerSystem";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("timeDilation", timeDilation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("selfCenteredMode", selfCenteredMode);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("interval(ms)", interval);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
			string item = "timerHandle.Id";
			TimerHandle resumeTimeHandle = CharacterBlueprintFunctionLibrary.ResumeTimeHandle;
			ptr = new ValueTuple<string, object>(item, (resumeTimeHandle != null) ? new int?(resumeTimeHandle.Id) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
	}

	// Token: 0x06017F1F RID: 98079 RVA: 0x006B52EC File Offset: 0x006B34EC
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void DisableSelfCentered(ESelfCenteredMode selfCenteredMode)
	{
		ControllerBase<CharacterController>.Instance.ExitSelfCenteredMode(selfCenteredMode);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.TimeDilation;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "DisableSelfCentered";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("selfCenteredMode", selfCenteredMode);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06017F20 RID: 98080 RVA: 0x006B5333 File Offset: 0x006B3533
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool IsAnySelfCenteredModeEnabled()
	{
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		return instance != null && instance.EnabledSelfCentered;
	}

	// Token: 0x06017F21 RID: 98081 RVA: 0x006B5345 File Offset: 0x006B3545
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool IsSelfCenteredModeEnabled(ESelfCenteredMode selfCenteredMode)
	{
		return ControllerBase<CharacterController>.Instance.IsSelfCenteredModeEnabled(selfCenteredMode);
	}

	// Token: 0x06017F22 RID: 98082 RVA: 0x006B5354 File Offset: 0x006B3554
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SEntityTimeDilation GetEntityForeverTimeDilation(int entityId)
	{
		CharacterBlueprintFunctionLibrary._entityTimeDilation.SourceType = -1;
		PawnTimeScaleComponent component = Singleton<EntitySystem>.Instance.GetComponent<PawnTimeScaleComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return CharacterBlueprintFunctionLibrary._entityTimeDilation;
		}
		ForeverTimeScale topForeverTimeScaleConfig = component.GetTopForeverTimeScaleConfig(null);
		if (topForeverTimeScaleConfig == null)
		{
			return CharacterBlueprintFunctionLibrary._entityTimeDilation;
		}
		CharacterBlueprintFunctionLibrary._entityTimeDilation.SourceType = (int)topForeverTimeScaleConfig.SourceType;
		CharacterBlueprintFunctionLibrary._entityTimeDilation.TimeDilation = topForeverTimeScaleConfig.TimeDilation;
		return CharacterBlueprintFunctionLibrary._entityTimeDilation;
	}

	// Token: 0x06017F23 RID: 98083 RVA: 0x006B53C7 File Offset: 0x006B35C7
	[UFunction(EFunctionFlags.FUNC_None)]
	public static ESelfCenteredMode GetSelfCenteredMode()
	{
		return ModelBase<CharacterModel>.Instance.SelfCenteredMode;
	}

	// Token: 0x06017F24 RID: 98084 RVA: 0x006B53D3 File Offset: 0x006B35D3
	[UFunction(EFunctionFlags.FUNC_None)]
	public static float GetSelfCenteredTimeDilation()
	{
		return ModelBase<CharacterModel>.Instance.SelfCenteredTimeDilation;
	}

	// Token: 0x06017F25 RID: 98085 RVA: 0x006B53DF File Offset: 0x006B35DF
	[UFunction(EFunctionFlags.FUNC_None)]
	public static float GetInverseSelfCenteredTimeDilation()
	{
		return ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation;
	}

	// Token: 0x06017F26 RID: 98086 RVA: 0x006B53EC File Offset: 0x006B35EC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetPlanarReflectionShowPlayers(UPlanarReflectionComponent comp)
	{
		foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(false))
		{
			EntityHandle entityHandle = sceneTeamItem.EntityHandle;
			object obj;
			if (entityHandle == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				if (entity == null)
				{
					obj = null;
				}
				else
				{
					CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
					obj = ((component != null) ? component.Owner : null);
				}
			}
			TsBaseCharacter tsBaseCharacter = obj as TsBaseCharacter;
			if (tsBaseCharacter != null)
			{
				comp.ShowOnlyActors.Add(tsBaseCharacter);
			}
		}
	}

	// Token: 0x06017F27 RID: 98087 RVA: 0x006B547C File Offset: 0x006B367C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetCharacterDirectlySightLockEnableState(int id, bool bEnable)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (entity == null || !entity.Valid)
		{
			return;
		}
		CharacterAnimationComponent component = entity.GetComponent<CharacterAnimationComponent>();
		if (component == null)
		{
			return;
		}
		component.SetDirectlySightEnableState(bEnable, "通过蓝图接口设置");
	}

	// Token: 0x06017F28 RID: 98088 RVA: 0x006B54B8 File Offset: 0x006B36B8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetCharacterSightLockBoneLimit(int id, float yawMin = -23f, float yawMax = 23f, float pitchMin = -10f, float pitchMax = 13f, float assistLimit = 5f, FVector sightDirectInSightBone = default(FVector), FVector upAxisInSightBone = default(FVector))
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (entity == null || !entity.Valid)
		{
			return;
		}
		CharacterAnimationComponent component = entity.GetComponent<CharacterAnimationComponent>();
		if (component == null)
		{
			return;
		}
		component.SetSightBoneLimit(yawMin, yawMax, pitchMin, pitchMax, assistLimit, sightDirectInSightBone, upAxisInSightBone);
	}

	// Token: 0x06017F29 RID: 98089 RVA: 0x006B54F8 File Offset: 0x006B36F8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void RestoreSightLockBoneLimit(int id)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (entity == null || !entity.Valid)
		{
			return;
		}
		CharacterAnimationComponent component = entity.GetComponent<CharacterAnimationComponent>();
		if (component == null)
		{
			return;
		}
		component.RestoreSightBoneLimit();
	}

	// Token: 0x06017F2A RID: 98090 RVA: 0x006B5530 File Offset: 0x006B3730
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetCharacterMovementModeInfo(int id)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (entity == null || !entity.Valid)
		{
			return "";
		}
		CharacterMoveComponent component = entity.GetComponent<CharacterMoveComponent>();
		UCharacterMovementComponent ucharacterMovementComponent = (component != null) ? component.CharacterMovement : null;
		if (ucharacterMovementComponent == null || !ucharacterMovementComponent.IsValid())
		{
			return "";
		}
		CharacterUnifiedStateComponent component2 = entity.GetComponent<CharacterUnifiedStateComponent>();
		if (component2 == null || !component2.Valid)
		{
			return "";
		}
		return "Mode: " + ucharacterMovementComponent.MovementMode.ToString() + ", CustomMode: " + CharacterUtils.GetCustomMovementModeName((int)ucharacterMovementComponent.CustomMovementMode);
	}

	// Token: 0x06017F2B RID: 98091 RVA: 0x006B55CC File Offset: 0x006B37CC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetCharacterMovementStateInfo(int id)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (!(((entity != null) ? new bool?(entity.Valid) : null) ?? false))
		{
			return "";
		}
		CharacterMoveComponent component = entity.GetComponent<CharacterMoveComponent>();
		UCharacterMovementComponent ucharacterMovementComponent = (component != null) ? component.CharacterMovement : null;
		if (ucharacterMovementComponent == null || !ucharacterMovementComponent.IsValid())
		{
			return "";
		}
		CharacterUnifiedStateComponent component2 = entity.GetComponent<CharacterUnifiedStateComponent>();
		if (component2 == null || !component2.Valid)
		{
			return "";
		}
		return "PositionState: " + component2.PositionState.ToString() + ", MoveState: " + component2.MoveState.ToString();
	}

	// Token: 0x06017F2C RID: 98092 RVA: 0x006B5690 File Offset: 0x006B3890
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetVehicleMovementModeInfo(int id)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (entity == null || !entity.Valid)
		{
			return "";
		}
		VehicleMoveComponent component = entity.GetComponent<VehicleMoveComponent>();
		UKuroVehicleMovementComponent ukuroVehicleMovementComponent = (component != null) ? component.VehicleMovement : null;
		if (component == null || !component.Valid || ukuroVehicleMovementComponent == null || !ukuroVehicleMovementComponent.IsValid())
		{
			return "";
		}
		return "Mode: " + CharacterUtils.GetVehicleMovementModeName(ukuroVehicleMovementComponent.MovementMode) + ", ";
	}

	// Token: 0x06017F2D RID: 98093 RVA: 0x006B570C File Offset: 0x006B390C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetVehicleMovementStateInfo(int id)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (entity == null || !entity.Valid)
		{
			return "";
		}
		VehicleMoveComponent component = entity.GetComponent<VehicleMoveComponent>();
		if (component == null || !component.Valid || component.VehicleMovement == null || !component.VehicleMovement.IsValid())
		{
			return "";
		}
		string text = "";
		MotorcycleMoveComponent motorcycleMoveComponent = component as MotorcycleMoveComponent;
		if (motorcycleMoveComponent != null)
		{
			text = ", Drifting: " + (motorcycleMoveComponent.DriftingState ? "true" : "false");
		}
		return string.Concat(new string[]
		{
			"IsMoving: ",
			component.IsMoving ? "true" : "false",
			", IsStandardGravity: ",
			component.IsStandardGravity ? "true" : "false",
			text
		});
	}

	// Token: 0x06017F2E RID: 98094 RVA: 0x006B57DF File Offset: 0x006B39DF
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (CharacterBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/CharacterBlueprintFunctionLibrary.CharacterBlueprintFunctionLibrary_C");
		}
		return CharacterBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x06017F2F RID: 98095 RVA: 0x006B5804 File Offset: 0x006B3A04
	public CharacterBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(CharacterBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017F30 RID: 98096 RVA: 0x006B582C File Offset: 0x006B3A2C
	[NullableContext(1)]
	public CharacterBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CharacterBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017F31 RID: 98097 RVA: 0x006B585F File Offset: 0x006B3A5F
	protected CharacterBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06017F32 RID: 98098 RVA: 0x006B5868 File Offset: 0x006B3A68
	protected unsafe static void __CPPCALL_SetPartCollisionSwitch_Implementation(CharacterBlueprintFunctionLibrary.__SetPartCollisionSwitch_FunctionParams* __Params)
	{
		TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->character);
		string compName = FString.ToString((void*)(&__Params->compName));
		CharacterBlueprintFunctionLibrary.SetPartCollisionSwitch(orCreateUObjectByNativePointer, compName, __Params->isBlockPawn, __Params->isBulletDetect, __Params->isBlockCamera, __Params->isActiveOcclusionDither);
	}

	// Token: 0x06017F33 RID: 98099 RVA: 0x006B58AC File Offset: 0x006B3AAC
	protected unsafe static void __CPPCALL_ResetPartCollisionSwitch_Implementation(CharacterBlueprintFunctionLibrary.__ResetPartCollisionSwitch_FunctionParams* __Params)
	{
		TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->character);
		string compName = FString.ToString((void*)(&__Params->compName));
		CharacterBlueprintFunctionLibrary.ResetPartCollisionSwitch(orCreateUObjectByNativePointer, compName);
	}

	// Token: 0x06017F34 RID: 98100 RVA: 0x006B58D7 File Offset: 0x006B3AD7
	protected unsafe static void __CPPCALL_GetCharacterActorByEntityId_Implementation(CharacterBlueprintFunctionLibrary.__GetCharacterActorByEntityId_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		TsBaseCharacter characterActorByEntityId = CharacterBlueprintFunctionLibrary.GetCharacterActorByEntityId(__Params->id);
		ptr = ((characterActorByEntityId != null) ? characterActorByEntityId.NativePtr : ((IntPtr)0));
	}

	// Token: 0x06017F35 RID: 98101 RVA: 0x006B58F9 File Offset: 0x006B3AF9
	protected unsafe static void __CPPCALL_CharacterOperationRecord_Implementation(CharacterBlueprintFunctionLibrary.__CharacterOperationRecord_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.CharacterOperationRecord(__Params->open);
	}

	// Token: 0x06017F36 RID: 98102 RVA: 0x006B5906 File Offset: 0x006B3B06
	protected unsafe static void __CPPCALL_GetStatisticsOpen_Implementation(CharacterBlueprintFunctionLibrary.__GetStatisticsOpen_FunctionParams* __Params)
	{
		__Params->__Result = CharacterBlueprintFunctionLibrary.GetStatisticsOpen();
	}

	// Token: 0x06017F37 RID: 98103 RVA: 0x006B5913 File Offset: 0x006B3B13
	protected unsafe static void __CPPCALL_SaveCharacterOperationRecord_Implementation(CharacterBlueprintFunctionLibrary.__SaveCharacterOperationRecord_FunctionParams* __Params)
	{
		__Params->__Result = CharacterBlueprintFunctionLibrary.SaveCharacterOperationRecord();
	}

	// Token: 0x06017F38 RID: 98104 RVA: 0x006B5920 File Offset: 0x006B3B20
	protected unsafe static void __CPPCALL_GetOperationRecordCount_Implementation(CharacterBlueprintFunctionLibrary.__GetOperationRecordCount_FunctionParams* __Params)
	{
		__Params->__Result = CharacterBlueprintFunctionLibrary.GetOperationRecordCount();
	}

	// Token: 0x06017F39 RID: 98105 RVA: 0x006B592D File Offset: 0x006B3B2D
	protected unsafe static void __CPPCALL_CleanupOperationRecord_Implementation(CharacterBlueprintFunctionLibrary.__CleanupOperationRecord_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.CleanupOperationRecord();
	}

	// Token: 0x06017F3A RID: 98106 RVA: 0x006B5934 File Offset: 0x006B3B34
	protected unsafe static void __CPPCALL_SetHalfLengthRecord_Implementation(CharacterBlueprintFunctionLibrary.__SetHalfLengthRecord_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.SetHalfLengthRecord(__Params->sideLenHalf);
	}

	// Token: 0x06017F3B RID: 98107 RVA: 0x006B5944 File Offset: 0x006B3B44
	protected unsafe static void __CPPCALL_SetCombatStarted_Implementation(CharacterBlueprintFunctionLibrary.__SetCombatStarted_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.SetCombatStarted(__Params->started, __Params->attackerIndex, __Params->targetIndex, __Params->isDamage, __Params->isCure, __Params->isSkillUsed, __Params->isState, __Params->isKill, __Params->isReborn);
	}

	// Token: 0x06017F3C RID: 98108 RVA: 0x006B598C File Offset: 0x006B3B8C
	protected unsafe static void __CPPCALL_SetTypeOpen_Implementation(CharacterBlueprintFunctionLibrary.__SetTypeOpen_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.SetTypeOpen(__Params->isDamage, __Params->isCure, __Params->isSkillUsed, __Params->isState, __Params->isKill, __Params->isReborn);
	}

	// Token: 0x06017F3D RID: 98109 RVA: 0x006B59B8 File Offset: 0x006B3BB8
	protected unsafe static void __CPPCALL_GetAttackerCombatEntities_Implementation(CharacterBlueprintFunctionLibrary.__GetAttackerCombatEntities_FunctionParams* __Params)
	{
		TArray<string> attackerCombatEntities = CharacterBlueprintFunctionLibrary.GetAttackerCombatEntities();
		if (attackerCombatEntities == null)
		{
			return;
		}
		attackerCombatEntities.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x06017F3E RID: 98110 RVA: 0x006B59E4 File Offset: 0x006B3BE4
	protected unsafe static void __CPPCALL_GetTargetCombatEntities_Implementation(CharacterBlueprintFunctionLibrary.__GetTargetCombatEntities_FunctionParams* __Params)
	{
		TArray<string> targetCombatEntities = CharacterBlueprintFunctionLibrary.GetTargetCombatEntities();
		if (targetCombatEntities == null)
		{
			return;
		}
		targetCombatEntities.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x06017F3F RID: 98111 RVA: 0x006B5A10 File Offset: 0x006B3C10
	protected unsafe static void __CPPCALL_SetCurrentAttacker_Implementation(CharacterBlueprintFunctionLibrary.__SetCurrentAttacker_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.SetCurrentAttacker(__Params->index);
	}

	// Token: 0x06017F40 RID: 98112 RVA: 0x006B5A1D File Offset: 0x006B3C1D
	protected unsafe static void __CPPCALL_SetCurrentTarget_Implementation(CharacterBlueprintFunctionLibrary.__SetCurrentTarget_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.SetCurrentTarget(__Params->index);
	}

	// Token: 0x06017F41 RID: 98113 RVA: 0x006B5A2A File Offset: 0x006B3C2A
	protected unsafe static void __CPPCALL_GetItemsReset_Implementation(CharacterBlueprintFunctionLibrary.__GetItemsReset_FunctionParams* __Params)
	{
		__Params->__Result = CharacterBlueprintFunctionLibrary.GetItemsReset();
	}

	// Token: 0x06017F42 RID: 98114 RVA: 0x006B5A37 File Offset: 0x006B3C37
	protected unsafe static void __CPPCALL_OnItemsResetFinished_Implementation(CharacterBlueprintFunctionLibrary.__OnItemsResetFinished_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.OnItemsResetFinished();
	}

	// Token: 0x06017F43 RID: 98115 RVA: 0x006B5A40 File Offset: 0x006B3C40
	protected unsafe static void __CPPCALL_GetSubItemsListView_Implementation(CharacterBlueprintFunctionLibrary.__GetSubItemsListView_FunctionParams* __Params)
	{
		TArray<string> subItemsListView = CharacterBlueprintFunctionLibrary.GetSubItemsListView(__Params->startIndex, __Params->length);
		if (subItemsListView == null)
		{
			return;
		}
		subItemsListView.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x06017F44 RID: 98116 RVA: 0x006B5A78 File Offset: 0x006B3C78
	protected unsafe static void __CPPCALL_GetItemListViewCount_Implementation(CharacterBlueprintFunctionLibrary.__GetItemListViewCount_FunctionParams* __Params)
	{
		__Params->__Result = CharacterBlueprintFunctionLibrary.GetItemListViewCount();
	}

	// Token: 0x06017F45 RID: 98117 RVA: 0x006B5A85 File Offset: 0x006B3C85
	protected unsafe static void __CPPCALL_TestLeaveSplineMove_Implementation(CharacterBlueprintFunctionLibrary.__TestLeaveSplineMove_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.TestLeaveSplineMove(BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->actor));
	}

	// Token: 0x06017F46 RID: 98118 RVA: 0x006B5A97 File Offset: 0x006B3C97
	protected unsafe static void __CPPCALL_GetBaseCharacterTransform_Implementation(CharacterBlueprintFunctionLibrary.__GetBaseCharacterTransform_FunctionParams* __Params)
	{
		__Params->__Result = CharacterBlueprintFunctionLibrary.GetBaseCharacterTransform();
	}

	// Token: 0x06017F47 RID: 98119 RVA: 0x006B5AA4 File Offset: 0x006B3CA4
	protected unsafe static void __CPPCALL_SetActorExtraSkeletalMeshComponent_Implementation(CharacterBlueprintFunctionLibrary.__SetActorExtraSkeletalMeshComponent_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->skeletalMeshComponent);
		CharacterBlueprintFunctionLibrary.SetActorExtraSkeletalMeshComponent(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x06017F48 RID: 98120 RVA: 0x006B5ACC File Offset: 0x006B3CCC
	protected unsafe static void __CPPCALL_CanCharacterMonsterOrSummonedDisplayEffect_Implementation(CharacterBlueprintFunctionLibrary.__CanCharacterMonsterOrSummonedDisplayEffect_FunctionParams* __Params)
	{
		TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->owner);
		__Params->__Result = CharacterBlueprintFunctionLibrary.CanCharacterMonsterOrSummonedDisplayEffect(orCreateUObjectByNativePointer);
	}

	// Token: 0x06017F49 RID: 98121 RVA: 0x006B5AF1 File Offset: 0x006B3CF1
	protected unsafe static void __CPPCALL_DetachFromHost_Implementation(CharacterBlueprintFunctionLibrary.__DetachFromHost_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.DetachFromHost(__Params->id, __Params->isDetachFollower, __Params->isRecursion);
	}

	// Token: 0x06017F4A RID: 98122 RVA: 0x006B5B0A File Offset: 0x006B3D0A
	protected unsafe static void __CPPCALL_GetCharacterGravityDirect_Implementation(CharacterBlueprintFunctionLibrary.__GetCharacterGravityDirect_FunctionParams* __Params)
	{
		__Params->__Result = CharacterBlueprintFunctionLibrary.GetCharacterGravityDirect();
	}

	// Token: 0x06017F4B RID: 98123 RVA: 0x006B5B17 File Offset: 0x006B3D17
	protected unsafe static void __CPPCALL_GetCharacterGravityUp_Implementation(CharacterBlueprintFunctionLibrary.__GetCharacterGravityUp_FunctionParams* __Params)
	{
		__Params->__Result = CharacterBlueprintFunctionLibrary.GetCharacterGravityUp();
	}

	// Token: 0x06017F4C RID: 98124 RVA: 0x006B5B24 File Offset: 0x006B3D24
	protected unsafe static void __CPPCALL_SetGravityDirect_Implementation(CharacterBlueprintFunctionLibrary.__SetGravityDirect_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.SetGravityDirect(__Params->entityId, __Params->gravityDirect);
	}

	// Token: 0x06017F4D RID: 98125 RVA: 0x006B5B37 File Offset: 0x006B3D37
	protected unsafe static void __CPPCALL_EnableSelfCentered_Implementation(CharacterBlueprintFunctionLibrary.__EnableSelfCentered_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.EnableSelfCentered((ESelfCenteredMode)__Params->selfCenteredMode, __Params->timeDilation, __Params->duration);
	}

	// Token: 0x06017F4E RID: 98126 RVA: 0x006B5B50 File Offset: 0x006B3D50
	protected unsafe static void __CPPCALL_DisableSelfCentered_Implementation(CharacterBlueprintFunctionLibrary.__DisableSelfCentered_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.DisableSelfCentered((ESelfCenteredMode)__Params->selfCenteredMode);
	}

	// Token: 0x06017F4F RID: 98127 RVA: 0x006B5B5D File Offset: 0x006B3D5D
	protected unsafe static void __CPPCALL_IsAnySelfCenteredModeEnabled_Implementation(CharacterBlueprintFunctionLibrary.__IsAnySelfCenteredModeEnabled_FunctionParams* __Params)
	{
		__Params->__Result = CharacterBlueprintFunctionLibrary.IsAnySelfCenteredModeEnabled();
	}

	// Token: 0x06017F50 RID: 98128 RVA: 0x006B5B6C File Offset: 0x006B3D6C
	protected unsafe static void __CPPCALL_IsSelfCenteredModeEnabled_Implementation(CharacterBlueprintFunctionLibrary.__IsSelfCenteredModeEnabled_FunctionParams* __Params)
	{
		ESelfCenteredMode selfCenteredMode = (ESelfCenteredMode)__Params->selfCenteredMode;
		__Params->__Result = CharacterBlueprintFunctionLibrary.IsSelfCenteredModeEnabled(selfCenteredMode);
	}

	// Token: 0x06017F51 RID: 98129 RVA: 0x006B5B8C File Offset: 0x006B3D8C
	protected unsafe static void __CPPCALL_GetEntityForeverTimeDilation_Implementation(CharacterBlueprintFunctionLibrary.__GetEntityForeverTimeDilation_FunctionParams* __Params)
	{
		__Params->__Result = CharacterBlueprintFunctionLibrary.GetEntityForeverTimeDilation(__Params->entityId);
	}

	// Token: 0x06017F52 RID: 98130 RVA: 0x006B5B9F File Offset: 0x006B3D9F
	protected unsafe static void __CPPCALL_GetSelfCenteredMode_Implementation(CharacterBlueprintFunctionLibrary.__GetSelfCenteredMode_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)CharacterBlueprintFunctionLibrary.GetSelfCenteredMode();
	}

	// Token: 0x06017F53 RID: 98131 RVA: 0x006B5BAE File Offset: 0x006B3DAE
	protected unsafe static void __CPPCALL_GetSelfCenteredTimeDilation_Implementation(CharacterBlueprintFunctionLibrary.__GetSelfCenteredTimeDilation_FunctionParams* __Params)
	{
		__Params->__Result = CharacterBlueprintFunctionLibrary.GetSelfCenteredTimeDilation();
	}

	// Token: 0x06017F54 RID: 98132 RVA: 0x006B5BBB File Offset: 0x006B3DBB
	protected unsafe static void __CPPCALL_GetInverseSelfCenteredTimeDilation_Implementation(CharacterBlueprintFunctionLibrary.__GetInverseSelfCenteredTimeDilation_FunctionParams* __Params)
	{
		__Params->__Result = CharacterBlueprintFunctionLibrary.GetInverseSelfCenteredTimeDilation();
	}

	// Token: 0x06017F55 RID: 98133 RVA: 0x006B5BC8 File Offset: 0x006B3DC8
	protected unsafe static void __CPPCALL_SetPlanarReflectionShowPlayers_Implementation(CharacterBlueprintFunctionLibrary.__SetPlanarReflectionShowPlayers_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.SetPlanarReflectionShowPlayers(BuiltinUtils.GetOrCreateUObjectByNativePointer<UPlanarReflectionComponent>(__Params->comp));
	}

	// Token: 0x06017F56 RID: 98134 RVA: 0x006B5BDA File Offset: 0x006B3DDA
	protected unsafe static void __CPPCALL_SetCharacterDirectlySightLockEnableState_Implementation(CharacterBlueprintFunctionLibrary.__SetCharacterDirectlySightLockEnableState_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.SetCharacterDirectlySightLockEnableState(__Params->id, __Params->bEnable);
	}

	// Token: 0x06017F57 RID: 98135 RVA: 0x006B5BED File Offset: 0x006B3DED
	protected unsafe static void __CPPCALL_SetCharacterSightLockBoneLimit_Implementation(CharacterBlueprintFunctionLibrary.__SetCharacterSightLockBoneLimit_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.SetCharacterSightLockBoneLimit(__Params->id, __Params->yawMin, __Params->yawMax, __Params->pitchMin, __Params->pitchMax, __Params->assistLimit, __Params->sightDirectInSightBone, __Params->upAxisInSightBone);
	}

	// Token: 0x06017F58 RID: 98136 RVA: 0x006B5C24 File Offset: 0x006B3E24
	protected unsafe static void __CPPCALL_RestoreSightLockBoneLimit_Implementation(CharacterBlueprintFunctionLibrary.__RestoreSightLockBoneLimit_FunctionParams* __Params)
	{
		CharacterBlueprintFunctionLibrary.RestoreSightLockBoneLimit(__Params->id);
	}

	// Token: 0x06017F59 RID: 98137 RVA: 0x006B5C31 File Offset: 0x006B3E31
	protected unsafe static void __CPPCALL_GetCharacterMovementModeInfo_Implementation(CharacterBlueprintFunctionLibrary.__GetCharacterMovementModeInfo_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), CharacterBlueprintFunctionLibrary.GetCharacterMovementModeInfo(__Params->id));
	}

	// Token: 0x06017F5A RID: 98138 RVA: 0x006B5C4A File Offset: 0x006B3E4A
	protected unsafe static void __CPPCALL_GetCharacterMovementStateInfo_Implementation(CharacterBlueprintFunctionLibrary.__GetCharacterMovementStateInfo_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), CharacterBlueprintFunctionLibrary.GetCharacterMovementStateInfo(__Params->id));
	}

	// Token: 0x06017F5B RID: 98139 RVA: 0x006B5C63 File Offset: 0x006B3E63
	protected unsafe static void __CPPCALL_GetVehicleMovementModeInfo_Implementation(CharacterBlueprintFunctionLibrary.__GetVehicleMovementModeInfo_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), CharacterBlueprintFunctionLibrary.GetVehicleMovementModeInfo(__Params->id));
	}

	// Token: 0x06017F5C RID: 98140 RVA: 0x006B5C7C File Offset: 0x006B3E7C
	protected unsafe static void __CPPCALL_GetVehicleMovementStateInfo_Implementation(CharacterBlueprintFunctionLibrary.__GetVehicleMovementStateInfo_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), CharacterBlueprintFunctionLibrary.GetVehicleMovementStateInfo(__Params->id));
	}

	// Token: 0x0400B9F9 RID: 47609
	[Nullable(1)]
	private const string SAVE_PATH = "Statistics/FightDataRecord/";

	// Token: 0x0400B9FA RID: 47610
	private static SEntityTimeDilation _entityTimeDilation;

	// Token: 0x0400B9FB RID: 47611
	[Nullable(2)]
	private static TimerHandle ResumeTimeHandle;

	// Token: 0x0400B9FC RID: 47612
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/CharacterBlueprintFunctionLibrary.CharacterBlueprintFunctionLibrary_C";

	// Token: 0x0400B9FD RID: 47613
	private static IntPtr _ClassPtr;

	// Token: 0x0400B9FE RID: 47614
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02009086 RID: 36998
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetPartCollisionSwitch_FunctionParams
	{
		// Token: 0x0403071E RID: 198430
		[FieldOffset(0)]
		public IntPtr character;

		// Token: 0x0403071F RID: 198431
		[FieldOffset(8)]
		public FString compName;

		// Token: 0x04030720 RID: 198432
		[FieldOffset(24)]
		public bool isBlockPawn;

		// Token: 0x04030721 RID: 198433
		[FieldOffset(25)]
		public bool isBulletDetect;

		// Token: 0x04030722 RID: 198434
		[FieldOffset(26)]
		public bool isBlockCamera;

		// Token: 0x04030723 RID: 198435
		[FieldOffset(27)]
		public bool isActiveOcclusionDither;

		// Token: 0x04030724 RID: 198436
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009087 RID: 36999
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __ResetPartCollisionSwitch_FunctionParams
	{
		// Token: 0x04030725 RID: 198437
		[FieldOffset(0)]
		public IntPtr character;

		// Token: 0x04030726 RID: 198438
		[FieldOffset(8)]
		public FString compName;

		// Token: 0x04030727 RID: 198439
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009088 RID: 37000
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCharacterActorByEntityId_FunctionParams
	{
		// Token: 0x04030728 RID: 198440
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030729 RID: 198441
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403072A RID: 198442
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x02009089 RID: 37001
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __CharacterOperationRecord_FunctionParams
	{
		// Token: 0x0403072B RID: 198443
		[FieldOffset(0)]
		public bool open;

		// Token: 0x0403072C RID: 198444
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200908A RID: 37002
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetStatisticsOpen_FunctionParams
	{
		// Token: 0x0403072D RID: 198445
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x0403072E RID: 198446
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x0200908B RID: 37003
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SaveCharacterOperationRecord_FunctionParams
	{
		// Token: 0x0403072F RID: 198447
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030730 RID: 198448
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x0200908C RID: 37004
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetOperationRecordCount_FunctionParams
	{
		// Token: 0x04030731 RID: 198449
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030732 RID: 198450
		[FieldOffset(8)]
		public float __Result;
	}

	// Token: 0x0200908D RID: 37005
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __CleanupOperationRecord_FunctionParams
	{
		// Token: 0x04030733 RID: 198451
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200908E RID: 37006
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetHalfLengthRecord_FunctionParams
	{
		// Token: 0x04030734 RID: 198452
		[FieldOffset(0)]
		public float sideLenHalf;

		// Token: 0x04030735 RID: 198453
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200908F RID: 37007
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SetCombatStarted_FunctionParams
	{
		// Token: 0x04030736 RID: 198454
		[FieldOffset(0)]
		public bool started;

		// Token: 0x04030737 RID: 198455
		[FieldOffset(4)]
		public int attackerIndex;

		// Token: 0x04030738 RID: 198456
		[FieldOffset(8)]
		public int targetIndex;

		// Token: 0x04030739 RID: 198457
		[FieldOffset(12)]
		public bool isDamage;

		// Token: 0x0403073A RID: 198458
		[FieldOffset(13)]
		public bool isCure;

		// Token: 0x0403073B RID: 198459
		[FieldOffset(14)]
		public bool isSkillUsed;

		// Token: 0x0403073C RID: 198460
		[FieldOffset(15)]
		public bool isState;

		// Token: 0x0403073D RID: 198461
		[FieldOffset(16)]
		public bool isKill;

		// Token: 0x0403073E RID: 198462
		[FieldOffset(17)]
		public bool isReborn;

		// Token: 0x0403073F RID: 198463
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009090 RID: 37008
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetTypeOpen_FunctionParams
	{
		// Token: 0x04030740 RID: 198464
		[FieldOffset(0)]
		public bool isDamage;

		// Token: 0x04030741 RID: 198465
		[FieldOffset(1)]
		public bool isCure;

		// Token: 0x04030742 RID: 198466
		[FieldOffset(2)]
		public bool isSkillUsed;

		// Token: 0x04030743 RID: 198467
		[FieldOffset(3)]
		public bool isState;

		// Token: 0x04030744 RID: 198468
		[FieldOffset(4)]
		public bool isKill;

		// Token: 0x04030745 RID: 198469
		[FieldOffset(5)]
		public bool isReborn;

		// Token: 0x04030746 RID: 198470
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009091 RID: 37009
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetAttackerCombatEntities_FunctionParams
	{
		// Token: 0x04030747 RID: 198471
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030748 RID: 198472
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x02009092 RID: 37010
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetTargetCombatEntities_FunctionParams
	{
		// Token: 0x04030749 RID: 198473
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x0403074A RID: 198474
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x02009093 RID: 37011
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetCurrentAttacker_FunctionParams
	{
		// Token: 0x0403074B RID: 198475
		[FieldOffset(0)]
		public int index;

		// Token: 0x0403074C RID: 198476
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009094 RID: 37012
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetCurrentTarget_FunctionParams
	{
		// Token: 0x0403074D RID: 198477
		[FieldOffset(0)]
		public int index;

		// Token: 0x0403074E RID: 198478
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009095 RID: 37013
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetItemsReset_FunctionParams
	{
		// Token: 0x0403074F RID: 198479
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030750 RID: 198480
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x02009096 RID: 37014
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __OnItemsResetFinished_FunctionParams
	{
		// Token: 0x04030751 RID: 198481
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009097 RID: 37015
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetSubItemsListView_FunctionParams
	{
		// Token: 0x04030752 RID: 198482
		[FieldOffset(0)]
		public int startIndex;

		// Token: 0x04030753 RID: 198483
		[FieldOffset(4)]
		public int length;

		// Token: 0x04030754 RID: 198484
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030755 RID: 198485
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x02009098 RID: 37016
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetItemListViewCount_FunctionParams
	{
		// Token: 0x04030756 RID: 198486
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030757 RID: 198487
		[FieldOffset(8)]
		public int __Result;
	}

	// Token: 0x02009099 RID: 37017
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __TestLeaveSplineMove_FunctionParams
	{
		// Token: 0x04030758 RID: 198488
		[FieldOffset(0)]
		public IntPtr actor;

		// Token: 0x04030759 RID: 198489
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200909A RID: 37018
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 80)]
	protected ref struct __GetBaseCharacterTransform_FunctionParams
	{
		// Token: 0x0403075A RID: 198490
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x0403075B RID: 198491
		[FieldOffset(16)]
		public FTransformDouble __Result;
	}

	// Token: 0x0200909B RID: 37019
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetActorExtraSkeletalMeshComponent_FunctionParams
	{
		// Token: 0x0403075C RID: 198492
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403075D RID: 198493
		[FieldOffset(8)]
		public IntPtr skeletalMeshComponent;

		// Token: 0x0403075E RID: 198494
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200909C RID: 37020
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CanCharacterMonsterOrSummonedDisplayEffect_FunctionParams
	{
		// Token: 0x0403075F RID: 198495
		[FieldOffset(0)]
		public IntPtr owner;

		// Token: 0x04030760 RID: 198496
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030761 RID: 198497
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200909D RID: 37021
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DetachFromHost_FunctionParams
	{
		// Token: 0x04030762 RID: 198498
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030763 RID: 198499
		[FieldOffset(4)]
		public bool isDetachFollower;

		// Token: 0x04030764 RID: 198500
		[FieldOffset(5)]
		public bool isRecursion;

		// Token: 0x04030765 RID: 198501
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200909E RID: 37022
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetCharacterGravityDirect_FunctionParams
	{
		// Token: 0x04030766 RID: 198502
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030767 RID: 198503
		[FieldOffset(8)]
		public FVectorDouble __Result;
	}

	// Token: 0x0200909F RID: 37023
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetCharacterGravityUp_FunctionParams
	{
		// Token: 0x04030768 RID: 198504
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030769 RID: 198505
		[FieldOffset(8)]
		public FVectorDouble __Result;
	}

	// Token: 0x020090A0 RID: 37024
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetGravityDirect_FunctionParams
	{
		// Token: 0x0403076A RID: 198506
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403076B RID: 198507
		[FieldOffset(8)]
		public FVectorDouble gravityDirect;

		// Token: 0x0403076C RID: 198508
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090A1 RID: 37025
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __EnableSelfCentered_FunctionParams
	{
		// Token: 0x0403076D RID: 198509
		[FieldOffset(0)]
		public byte selfCenteredMode;

		// Token: 0x0403076E RID: 198510
		[FieldOffset(4)]
		public float timeDilation;

		// Token: 0x0403076F RID: 198511
		[FieldOffset(8)]
		public float duration;

		// Token: 0x04030770 RID: 198512
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090A2 RID: 37026
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DisableSelfCentered_FunctionParams
	{
		// Token: 0x04030771 RID: 198513
		[FieldOffset(0)]
		public byte selfCenteredMode;

		// Token: 0x04030772 RID: 198514
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090A3 RID: 37027
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __IsAnySelfCenteredModeEnabled_FunctionParams
	{
		// Token: 0x04030773 RID: 198515
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030774 RID: 198516
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x020090A4 RID: 37028
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsSelfCenteredModeEnabled_FunctionParams
	{
		// Token: 0x04030775 RID: 198517
		[FieldOffset(0)]
		public byte selfCenteredMode;

		// Token: 0x04030776 RID: 198518
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030777 RID: 198519
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020090A5 RID: 37029
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetEntityForeverTimeDilation_FunctionParams
	{
		// Token: 0x04030778 RID: 198520
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030779 RID: 198521
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403077A RID: 198522
		[FieldOffset(16)]
		public SEntityTimeDilation __Result;
	}

	// Token: 0x020090A6 RID: 37030
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetSelfCenteredMode_FunctionParams
	{
		// Token: 0x0403077B RID: 198523
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x0403077C RID: 198524
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x020090A7 RID: 37031
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetSelfCenteredTimeDilation_FunctionParams
	{
		// Token: 0x0403077D RID: 198525
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x0403077E RID: 198526
		[FieldOffset(8)]
		public float __Result;
	}

	// Token: 0x020090A8 RID: 37032
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetInverseSelfCenteredTimeDilation_FunctionParams
	{
		// Token: 0x0403077F RID: 198527
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030780 RID: 198528
		[FieldOffset(8)]
		public float __Result;
	}

	// Token: 0x020090A9 RID: 37033
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetPlanarReflectionShowPlayers_FunctionParams
	{
		// Token: 0x04030781 RID: 198529
		[FieldOffset(0)]
		public IntPtr comp;

		// Token: 0x04030782 RID: 198530
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090AA RID: 37034
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetCharacterDirectlySightLockEnableState_FunctionParams
	{
		// Token: 0x04030783 RID: 198531
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030784 RID: 198532
		[FieldOffset(4)]
		public bool bEnable;

		// Token: 0x04030785 RID: 198533
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090AB RID: 37035
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __SetCharacterSightLockBoneLimit_FunctionParams
	{
		// Token: 0x04030786 RID: 198534
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030787 RID: 198535
		[FieldOffset(4)]
		public float yawMin;

		// Token: 0x04030788 RID: 198536
		[FieldOffset(8)]
		public float yawMax;

		// Token: 0x04030789 RID: 198537
		[FieldOffset(12)]
		public float pitchMin;

		// Token: 0x0403078A RID: 198538
		[FieldOffset(16)]
		public float pitchMax;

		// Token: 0x0403078B RID: 198539
		[FieldOffset(20)]
		public float assistLimit;

		// Token: 0x0403078C RID: 198540
		[FieldOffset(24)]
		public FVector sightDirectInSightBone;

		// Token: 0x0403078D RID: 198541
		[FieldOffset(36)]
		public FVector upAxisInSightBone;

		// Token: 0x0403078E RID: 198542
		[FieldOffset(48)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090AC RID: 37036
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __RestoreSightLockBoneLimit_FunctionParams
	{
		// Token: 0x0403078F RID: 198543
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030790 RID: 198544
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090AD RID: 37037
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetCharacterMovementModeInfo_FunctionParams
	{
		// Token: 0x04030791 RID: 198545
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030792 RID: 198546
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030793 RID: 198547
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x020090AE RID: 37038
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetCharacterMovementStateInfo_FunctionParams
	{
		// Token: 0x04030794 RID: 198548
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030795 RID: 198549
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030796 RID: 198550
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x020090AF RID: 37039
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetVehicleMovementModeInfo_FunctionParams
	{
		// Token: 0x04030797 RID: 198551
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030798 RID: 198552
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030799 RID: 198553
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x020090B0 RID: 37040
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetVehicleMovementStateInfo_FunctionParams
	{
		// Token: 0x0403079A RID: 198554
		[FieldOffset(0)]
		public int id;

		// Token: 0x0403079B RID: 198555
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403079C RID: 198556
		[FieldOffset(16)]
		public FString __Result;
	}
}
