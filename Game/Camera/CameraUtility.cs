using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using CSharpScript.Game.NewWorld.SceneItem.Elevator;
using CSharpScript.Game.NewWorld.SceneItem.Model;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070A3 RID: 28835
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class CameraUtility : IStaticVariableResetter
	{
		// Token: 0x06045E2B RID: 286251 RVA: 0x0124DB3C File Offset: 0x0124BD3C
		static CameraUtility()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CameraUtility.CreateStaticDefaultValue), new Action(CameraUtility.ResetStaticDefaultValue));
		}

		// Token: 0x06045E2C RID: 286252 RVA: 0x0124DC60 File Offset: 0x0124BE60
		[NullableContext(2)]
		public static void GetSocketLocation(AActor character, FName? socketName, [Nullable(1)] global::Vector outVector, EntityHandle handle = null)
		{
			AActor aactor;
			EntityHandle entityHandle;
			if (character == null)
			{
				if (handle == null || !handle.Valid)
				{
					outVector.Reset();
					return;
				}
				BaseActorComponent component = handle.Entity.GetComponent<BaseActorComponent>();
				aactor = ((component != null) ? component.Owner : null);
				if (aactor == null)
				{
					outVector.Reset();
					return;
				}
				entityHandle = handle;
			}
			else
			{
				aactor = character;
				entityHandle = ((handle == null || !handle.Valid) ? ActorUtils.GetEntityByActor(character, true) : handle);
			}
			if (!CameraUtility.IsTsActor(entityHandle))
			{
				if (entityHandle.Valid)
				{
					outVector.DeepCopy(entityHandle.Entity.GetComponent<BaseActorComponent>().ActorLocationProxy);
				}
				return;
			}
			TsBaseCharacter tsBaseCharacter = aactor as TsBaseCharacter;
			if (tsBaseCharacter.Mesh != null && ((socketName != null) ? socketName.GetValueOrDefault().ToString() : null) != null)
			{
				FVectorDouble fvectorDouble = tsBaseCharacter.Mesh.D_GetSocketLocation(socketName.Value);
				outVector.FromUeVector(fvectorDouble);
				return;
			}
			entityHandle.Entity.GetComponent<CharacterAnimationComponent>().GetCameraPosition(outVector);
		}

		// Token: 0x06045E2D RID: 286253 RVA: 0x0124DD54 File Offset: 0x0124BF54
		[NullableContext(2)]
		private static bool IsTsActor(EntityHandle handle)
		{
			if (handle == null || !handle.Valid)
			{
				return false;
			}
			EEntityType entityType = handle.Entity.GetComponent<CreatureDataComponent>().GetEntityType();
			return entityType <= EEntityType.Monster || entityType == EEntityType.Vision;
		}

		// Token: 0x06045E2E RID: 286254 RVA: 0x0124DD99 File Offset: 0x0124BF99
		[NullableContext(2)]
		public static FTransformDouble GetRootTransform(ACharacter character)
		{
			if (((character != null) ? character.Mesh : null) == null)
			{
				return new FTransformDouble();
			}
			return character.Mesh.D_GetSocketTransform(CameraUtility.Root, ERelativeTransformSpace.RTS_World);
		}

		// Token: 0x06045E2F RID: 286255 RVA: 0x0124DDC0 File Offset: 0x0124BFC0
		public static bool TargetCanBeSelect(BaseActorComponent actorComp)
		{
			if (!actorComp.Valid || !actorComp.Active)
			{
				return false;
			}
			BaseTagComponent component = actorComp.Entity.GetComponent<BaseTagComponent>();
			return component == null || (!component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]) && !component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.隐身.不可锁定"]));
		}

		// Token: 0x06045E30 RID: 286256 RVA: 0x0124DE24 File Offset: 0x0124C024
		[NullableContext(2)]
		public static EntityHandle GetCameraTargetEntityHandle()
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid)
			{
				return null;
			}
			EntityHandle characterEntityHandle = logicComponent.CharacterEntityHandle;
			if (characterEntityHandle == null || !characterEntityHandle.Valid)
			{
				return null;
			}
			return characterEntityHandle;
		}

		// Token: 0x06045E31 RID: 286257 RVA: 0x0124DE6C File Offset: 0x0124C06C
		[NullableContext(2)]
		public static EntityHandle GetCameraLockOnTargetEntityHandle()
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid)
			{
				return null;
			}
			EntityHandle targetEntity = logicComponent.TargetEntity;
			if (targetEntity == null || !targetEntity.Valid)
			{
				return null;
			}
			return targetEntity;
		}

		// Token: 0x06045E32 RID: 286258 RVA: 0x0124DEB4 File Offset: 0x0124C0B4
		public static void GetCameraCharacterRotation(global::Rotator outR)
		{
			outR.Reset();
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
			if (fightCameraLogicComponent != null && fightCameraLogicComponent.Valid)
			{
				TsBaseCharacter character = fightCameraLogicComponent.Character;
				if (((character != null) ? character.CharacterActorComponent : null) != null)
				{
					outR.DeepCopy(fightCameraLogicComponent.Character.CharacterActorComponent.ActorRotationProxy);
					return;
				}
			}
		}

		// Token: 0x06045E33 RID: 286259 RVA: 0x0124DF20 File Offset: 0x0124C120
		public static float GetPlayerTargetAndCameraYawOffset()
		{
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
			if (fightCameraLogicComponent != null && fightCameraLogicComponent.Valid)
			{
				EntityHandle targetEntity = fightCameraLogicComponent.TargetEntity;
				if (targetEntity != null && targetEntity.Valid)
				{
					TsBaseCharacter character = fightCameraLogicComponent.Character;
					if (((character != null) ? character.CharacterActorComponent : null) != null)
					{
						CameraUtility.GetSocketLocation(null, fightCameraLogicComponent.TargetSocketName, CameraUtility.TempVector, fightCameraLogicComponent.TargetEntity);
						CameraUtility.TempVector.SubtractionEqual(fightCameraLogicComponent.Character.CharacterActorComponent.ActorLocationProxy);
						CameraUtility.GetVectorInGravity(CameraUtility.TempVector, CameraUtility.TempVector);
						float num = (float)CameraUtility.TempVector.HeadingAngle() * 57.29578f;
						global::Rotator tempRotator = CameraUtility.TempRotator;
						FRotator cameraRotation = Global.CharacterCameraManager.GetCameraRotation();
						tempRotator.DeepCopy(cameraRotation);
						float yawInGravity = CameraUtility.GetYawInGravity(CameraUtility.TempRotator);
						return Singleton<MathUtils>.Instance.WrapAngle(num - yawInGravity);
					}
				}
			}
			return 0f;
		}

		// Token: 0x06045E34 RID: 286260 RVA: 0x0124E010 File Offset: 0x0124C210
		public static float GetPlayerAndCameraYawOffset()
		{
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
			if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
			{
				return 0f;
			}
			global::Rotator tempRotator = CameraUtility.TempRotator;
			FRotator cameraRotation = Global.CharacterCameraManager.GetCameraRotation();
			tempRotator.DeepCopy(cameraRotation);
			float yawInGravity = CameraUtility.GetYawInGravity(CameraUtility.TempRotator);
			return Singleton<MathUtils>.Instance.WrapAngle(fightCameraLogicComponent.PlayerRotatorInGravity.Yaw - yawInGravity);
		}

		// Token: 0x06045E35 RID: 286261 RVA: 0x0124E08C File Offset: 0x0124C28C
		public static global::Rotator GetCameraDefaultFocusRotator()
		{
			float? floatConfig = ConfigCommonParamById.GetFloatConfig("InitialCameraPitch");
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
			if (fightCameraLogicComponent != null && fightCameraLogicComponent.Valid)
			{
				TsBaseCharacter character = fightCameraLogicComponent.Character;
				if (character != null && character.IsValid())
				{
					TsBaseCharacter character2 = fightCameraLogicComponent.Character;
					if (((character2 != null) ? character2.CharacterActorComponent : null) != null)
					{
						BaseTagComponent component = fightCameraLogicComponent.Character.CharacterActorComponent.Entity.GetComponent<BaseTagComponent>();
						if (component == null || !component.Valid || component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.被抓取"]))
						{
							CameraUtility.TempRotator.Reset();
							CameraUtility.SetPitchInGravity(CameraUtility.TempRotator, (double)floatConfig.Value, CameraUtility.TempRotator);
							return CameraUtility.TempRotator;
						}
						if (fightCameraLogicComponent.IsInNormalGravityMode())
						{
							FVector fvector = fightCameraLogicComponent.Character.CharacterActorComponent.ActorRotation.Euler();
							CameraUtility.TempRotator.Pitch = floatConfig.Value;
							CameraUtility.TempRotator.Yaw = fvector.Z;
							CameraUtility.TempRotator.Roll = fvector.X;
						}
						else
						{
							CameraUtility.SetPitchInGravity(fightCameraLogicComponent.Character.CharacterActorComponent.ActorRotationProxy, (double)floatConfig.Value, CameraUtility.TempRotator);
						}
						return CameraUtility.TempRotator;
					}
				}
			}
			CameraUtility.TempRotator.Pitch = floatConfig.Value;
			CameraUtility.TempRotator.Yaw = 0f;
			CameraUtility.TempRotator.Roll = 0f;
			return CameraUtility.TempRotator;
		}

		// Token: 0x06045E36 RID: 286262 RVA: 0x0124E214 File Offset: 0x0124C414
		public static FRotator GetCameraDefaultFocusUeRotator()
		{
			return CameraUtility.GetCameraDefaultFocusRotator().ToUeRotator();
		}

		// Token: 0x06045E37 RID: 286263 RVA: 0x0124E220 File Offset: 0x0124C420
		[NullableContext(2)]
		public static bool CheckCameraShakeCondition(EntityHandle entityHandle)
		{
			return entityHandle != null && entityHandle.Valid && CameraUtility.CheckFormationControlState(entityHandle, true, true);
		}

		// Token: 0x06045E38 RID: 286264 RVA: 0x0124E240 File Offset: 0x0124C440
		[NullableContext(2)]
		public unsafe static bool CheckCameraSequenceCondition(TsBaseCharacter owner, ESequenceCameraAnsEffectiveClientType sequenceCameraAnsEffectiveClientType = ESequenceCameraAnsEffectiveClientType.单客户端)
		{
			if (owner == null)
			{
				return false;
			}
			switch (sequenceCameraAnsEffectiveClientType)
			{
			case ESequenceCameraAnsEffectiveClientType.单客户端:
			{
				Entity entityNoBlueprint = owner.GetEntityNoBlueprint();
				CreatureDataComponent creatureDataComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CreatureDataComponent>() : null;
				if (creatureDataComponent == null || !creatureDataComponent.IsRole())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Camera;
					ELogAuthor author = ELogAuthor.LJM;
					string message = "SwitchSequenceCamera生效客户端类型`单客户端`只允许在角色身上调用";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ELogModule", ELogModule.Camera);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ELogAuthor", ELogAuthor.LJM);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return false;
				}
				return creatureDataComponent.IsCharacterMonster() || Global.BaseCharacter == owner;
			}
			case ESequenceCameraAnsEffectiveClientType.全客户端:
				return true;
			case ESequenceCameraAnsEffectiveClientType.锁定目标客户端:
			{
				Entity entityNoBlueprint2 = owner.GetEntityNoBlueprint();
				bool flag;
				if (entityNoBlueprint2 == null)
				{
					flag = true;
				}
				else
				{
					CreatureDataComponent component = entityNoBlueprint2.GetComponent<CreatureDataComponent>();
					flag = !((component != null) ? new bool?(component.IsMonster()) : null).GetValueOrDefault();
				}
				if (flag)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Camera;
					ELogAuthor author2 = ELogAuthor.LJM;
					string message2 = "SwitchSequenceCamera生效客户端类型`锁定目标客户端`只允许在怪物身上调用";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("ELogModule", ELogModule.Camera);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ELogAuthor", ELogAuthor.LJM);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					return false;
				}
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				CharacterLockOnComponent characterLockOnComponent;
				if (baseCharacter == null)
				{
					characterLockOnComponent = null;
				}
				else
				{
					Entity entityNoBlueprint3 = baseCharacter.GetEntityNoBlueprint();
					characterLockOnComponent = ((entityNoBlueprint3 != null) ? entityNoBlueprint3.GetComponent<CharacterLockOnComponent>() : null);
				}
				CharacterLockOnComponent characterLockOnComponent2 = characterLockOnComponent;
				return characterLockOnComponent2 != null && characterLockOnComponent2.Valid && characterLockOnComponent2.GetCurrentTarget() == ModelBase<CharacterModel>.Instance.GetHandle(owner.EntityId);
			}
			case ESequenceCameraAnsEffectiveClientType.仇恨目标客户端:
			{
				Entity entityNoBlueprint4 = owner.GetEntityNoBlueprint();
				bool flag2;
				if (entityNoBlueprint4 == null)
				{
					flag2 = true;
				}
				else
				{
					CreatureDataComponent component2 = entityNoBlueprint4.GetComponent<CreatureDataComponent>();
					flag2 = !((component2 != null) ? new bool?(component2.IsMonster()) : null).GetValueOrDefault();
				}
				if (flag2)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Camera;
					ELogAuthor author3 = ELogAuthor.LJM;
					string message3 = "SwitchSequenceCamera生效客户端类型`仇恨目标客户端`只允许在怪物身上调用";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("ELogModule", ELogModule.Camera);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("ELogAuthor", ELogAuthor.LJM);
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
					return false;
				}
				TsAiController tsAiController = owner.GetController() as TsAiController;
				if (tsAiController == null)
				{
					return false;
				}
				AiController aiController = tsAiController.AiController;
				EntityHandle entityHandle = (aiController != null) ? aiController.AiHateList.GetCurrentTarget() : null;
				CharacterActorComponent characterActorComponent;
				if (entityHandle == null)
				{
					characterActorComponent = null;
				}
				else
				{
					WorldEntity entity = entityHandle.Entity;
					characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
				}
				CharacterActorComponent characterActorComponent2 = characterActorComponent;
				return characterActorComponent2 != null && characterActorComponent2.Valid && characterActorComponent2.Owner is TsBaseCharacter && characterActorComponent2.IsAutonomousProxy && characterActorComponent2.Owner == Global.BaseCharacter;
			}
			case ESequenceCameraAnsEffectiveClientType.技能目标客户端:
			{
				Entity entityNoBlueprint5 = owner.GetEntityNoBlueprint();
				bool flag3;
				if (entityNoBlueprint5 == null)
				{
					flag3 = true;
				}
				else
				{
					CreatureDataComponent component3 = entityNoBlueprint5.GetComponent<CreatureDataComponent>();
					flag3 = !((component3 != null) ? new bool?(component3.IsMonster()) : null).GetValueOrDefault();
				}
				if (flag3)
				{
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.Camera;
					ELogAuthor author4 = ELogAuthor.LJM;
					string message4 = "SwitchSequenceCamera生效客户端类型`技能目标客户端`只允许在怪物身上调用";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("ELogModule", ELogModule.Camera);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("ELogAuthor", ELogAuthor.LJM);
					instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
					return false;
				}
				Entity entityNoBlueprint6 = owner.GetEntityNoBlueprint();
				CharacterSkillComponent characterSkillComponent = (entityNoBlueprint6 != null) ? entityNoBlueprint6.GetComponent<CharacterSkillComponent>() : null;
				if (characterSkillComponent == null || !characterSkillComponent.Valid)
				{
					return false;
				}
				EntityHandle skillTarget = characterSkillComponent.SkillTarget;
				CharacterModel instance5 = ModelBase<CharacterModel>.Instance;
				TsBaseCharacter baseCharacter2 = Global.BaseCharacter;
				return skillTarget == instance5.GetHandle((baseCharacter2 != null) ? baseCharacter2.EntityId : 0);
			}
			default:
				return false;
			}
		}

		// Token: 0x06045E39 RID: 286265 RVA: 0x0124E60C File Offset: 0x0124C80C
		public static bool CheckApplyCameraModifyCondition([Nullable(2)] EntityHandle entityHandle, SCameraModifier_Settings cameraModifySettings, ECameraAnsEffectiveClientType cameraEffectiveClientType = ECameraAnsEffectiveClientType.单客户端_角色为中心_, [Nullable(new byte[]
		{
			2,
			1
		})] TArray<SCameraModifier_Condition> cameraModifierConditions = null)
		{
			return entityHandle != null && entityHandle.Valid && CameraUtility.CheckFormationControlState(entityHandle, false, !cameraModifySettings.IsSwitchModifier) && CameraUtility.CheckCameraEffectiveClientType(entityHandle, cameraEffectiveClientType) && (cameraModifierConditions == null || CameraUtility.CheckCameraModifierConditions(cameraModifierConditions));
		}

		// Token: 0x06045E3A RID: 286266 RVA: 0x0124E65C File Offset: 0x0124C85C
		public static bool CheckFormationControlState(EntityHandle entityHandle, bool needLocal = false, bool needControl = false)
		{
			if (!entityHandle.Valid)
			{
				return false;
			}
			FollowShooterComponent component = entityHandle.Entity.GetComponent<FollowShooterComponent>();
			if (component != null && component.Valid)
			{
				return component.IsAutonomousProxy;
			}
			BaseVehiclePerformComponent component2 = entityHandle.Entity.GetComponent<BaseVehiclePerformComponent>();
			CreatureDataComponent component3;
			if (component2 != null && component2.Valid)
			{
				Entity driver = component2.Driver;
				if (driver != null && driver.Valid)
				{
					component3 = component2.Driver.GetComponent<CreatureDataComponent>();
					goto IL_6B;
				}
			}
			component3 = entityHandle.Entity.GetComponent<CreatureDataComponent>();
			IL_6B:
			if (component3 != null && component3.Valid)
			{
				long param = (long)((component3.IsVision() || component3.IsMonster()) ? ModelBase<CreatureModel>.Instance.GetEntityId(component3.GetSummonerId()) : component3.Entity.Id);
				SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem(param, new GetTeamItemOptions
				{
					ParamType = ETeamParamType.EntityId
				});
				if (teamItem != null && ((needLocal && !teamItem.IsMyRole()) || (needControl && !teamItem.IsControl())))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06045E3B RID: 286267 RVA: 0x0124E748 File Offset: 0x0124C948
		[NullableContext(2)]
		public static bool CheckCameraEffectiveClientType(EntityHandle entityHandle, ECameraAnsEffectiveClientType cameraEffectiveClientType)
		{
			if (entityHandle == null || !entityHandle.Valid)
			{
				return false;
			}
			CreatureDataComponent component = entityHandle.Entity.GetComponent<CreatureDataComponent>();
			if (component == null || !component.Valid)
			{
				return false;
			}
			switch (cameraEffectiveClientType)
			{
			case ECameraAnsEffectiveClientType.单客户端_角色为中心_:
			case ECameraAnsEffectiveClientType.单客户端_声骸为中心_:
			{
				int playerId = component.GetPlayerId();
				int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
				return (playerId == id.GetValueOrDefault() & id != null) && (component.IsRole() || component.IsVision());
			}
			case ECameraAnsEffectiveClientType.全客户端_角色为中心_:
			case ECameraAnsEffectiveClientType.全客户端_声骸为中心_:
			case ECameraAnsEffectiveClientType.全客户端_载具为中心_:
			case ECameraAnsEffectiveClientType.全客户端_伴生物为中心_:
				return true;
			case ECameraAnsEffectiveClientType.锁定目标客户端_怪物为中心_:
			case ECameraAnsEffectiveClientType.锁定目标客户端_角色为中心_:
			{
				if (!component.IsMonster())
				{
					return false;
				}
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				CharacterLockOnComponent characterLockOnComponent;
				if (baseCharacter == null)
				{
					characterLockOnComponent = null;
				}
				else
				{
					Entity entityNoBlueprint = baseCharacter.GetEntityNoBlueprint();
					characterLockOnComponent = ((entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterLockOnComponent>() : null);
				}
				CharacterLockOnComponent characterLockOnComponent2 = characterLockOnComponent;
				return characterLockOnComponent2 != null && characterLockOnComponent2.Valid && characterLockOnComponent2.ShowTarget == ModelBase<CharacterModel>.Instance.GetHandle(entityHandle.Id);
			}
			case ECameraAnsEffectiveClientType.仇恨目标客户端_怪物为中心_:
			case ECameraAnsEffectiveClientType.仇恨目标客户端_角色为中心_:
			{
				if (!component.IsMonster())
				{
					return false;
				}
				APawn apawn = entityHandle.Entity.GetComponent<CharacterActorComponent>().Owner as APawn;
				TsAiController tsAiController = ((apawn != null) ? apawn.GetController() : null) as TsAiController;
				if (tsAiController == null)
				{
					return false;
				}
				AiController aiController = tsAiController.AiController;
				EntityHandle entityHandle2 = (aiController != null) ? aiController.AiHateList.GetCurrentTarget() : null;
				CharacterActorComponent characterActorComponent;
				if (entityHandle2 == null)
				{
					characterActorComponent = null;
				}
				else
				{
					WorldEntity entity = entityHandle2.Entity;
					characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
				}
				CharacterActorComponent characterActorComponent2 = characterActorComponent;
				return characterActorComponent2 != null && characterActorComponent2.Valid && (characterActorComponent2 != null && characterActorComponent2.Owner is TsBaseCharacter && characterActorComponent2.IsAutonomousProxy && characterActorComponent2.Owner == Global.BaseCharacter);
			}
			case ECameraAnsEffectiveClientType.技能目标客户端_怪物为中心_:
			{
				if (!component.IsMonster())
				{
					return false;
				}
				CharacterSkillComponent component2 = entityHandle.Entity.GetComponent<CharacterSkillComponent>();
				if (component2 != null && component2.Valid)
				{
					EntityHandle skillTarget = component2.SkillTarget;
					CharacterModel instance = ModelBase<CharacterModel>.Instance;
					TsBaseCharacter baseCharacter2 = Global.BaseCharacter;
					return skillTarget == instance.GetHandle((baseCharacter2 != null) ? baseCharacter2.EntityId : 0);
				}
				return false;
			}
			case ECameraAnsEffectiveClientType.全客户端_怪物为中心_:
				return component.IsMonster();
			case ECameraAnsEffectiveClientType.单客户端_载具为中心_:
			{
				BaseVehiclePerformComponent component3 = entityHandle.Entity.GetComponent<BaseVehiclePerformComponent>();
				if (component3 != null && component3.Valid)
				{
					Entity driver = component3.Driver;
					if (driver != null && driver.Valid)
					{
						CreatureDataComponent component4 = component3.Driver.GetComponent<CreatureDataComponent>();
						if (component4 == null || !component4.Valid)
						{
							return false;
						}
						int playerId2 = component4.GetPlayerId();
						int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
						return (playerId2 == id.GetValueOrDefault() & id != null) && (component4.IsRole() || component4.IsVision());
					}
				}
				return false;
			}
			case ECameraAnsEffectiveClientType.单客户端_伴生物为中心_:
			{
				if (!component.IsConcomitantEntity)
				{
					return false;
				}
				int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(component.GetSummonerId());
				SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)entityId, new GetTeamItemOptions
				{
					ParamType = ETeamParamType.EntityId
				});
				return teamItem != null && teamItem.IsMyRole() && teamItem.IsControl();
			}
			default:
				return false;
			}
		}

		// Token: 0x06045E3C RID: 286268 RVA: 0x0124EA2F File Offset: 0x0124CC2F
		private static bool CheckCameraModifierConditions([Nullable(new byte[]
		{
			2,
			1
		})] TArray<SCameraModifier_Condition> cameraModifierConditions = null)
		{
			return cameraModifierConditions == null || CameraUtility.IsCameraModifyValidation(cameraModifierConditions);
		}

		// Token: 0x06045E3D RID: 286269 RVA: 0x0124EA3C File Offset: 0x0124CC3C
		private static bool IsCameraModifyValidation(TArray<SCameraModifier_Condition> conditionArray)
		{
			int num = conditionArray.Num();
			for (int i = 0; i < num; i++)
			{
				SCameraModifier_Condition scameraModifier_Condition = conditionArray.Get(i);
				switch (scameraModifier_Condition.ConditionType)
				{
				case ECameraModifyConditionType.角色拥有Tag:
					if (!CameraUtility.CheckSelfContainsTag(scameraModifier_Condition))
					{
						return false;
					}
					break;
				case ECameraModifyConditionType.锁定目标拥有Tag:
					if (!CameraUtility.CheckTargetContainsTag(scameraModifier_Condition))
					{
						return false;
					}
					break;
				case ECameraModifyConditionType.臂长范围:
					if (!CameraUtility.CheckCameraArmLength(scameraModifier_Condition))
					{
						return false;
					}
					break;
				case ECameraModifyConditionType.锁定目标处于镜头左边:
					if (!CameraUtility.CheckTargetCameraLeft(scameraModifier_Condition))
					{
						return false;
					}
					break;
				case ECameraModifyConditionType.与锁定目标相对高度:
					if (!CameraUtility.CheckTargetHeightDelta(scameraModifier_Condition))
					{
						return false;
					}
					break;
				case ECameraModifyConditionType.与锁定目标的相对Yaw:
					if (!CameraUtility.CheckTargetYawDelta(scameraModifier_Condition))
					{
						return false;
					}
					break;
				case ECameraModifyConditionType.当前pitch范围:
					if (!CameraUtility.CheckCameraPitch(scameraModifier_Condition))
					{
						return false;
					}
					break;
				case ECameraModifyConditionType.与锁定目标的距离:
					if (!CameraUtility.CheckTargetDistance(scameraModifier_Condition))
					{
						return false;
					}
					break;
				case ECameraModifyConditionType.范围阻挡检测:
					if (!CameraUtility.CheckTargetCollision(scameraModifier_Condition))
					{
						return false;
					}
					break;
				case ECameraModifyConditionType.相机位于锁定目标连线轴的左侧:
					if (!CameraUtility.CheckCameraTargetConnectionLeft(scameraModifier_Condition))
					{
						return false;
					}
					break;
				case ECameraModifyConditionType.相机位于锁定目标连线轴的右侧:
					if (!CameraUtility.CheckCameraTargetConnectionRight(scameraModifier_Condition))
					{
						return false;
					}
					break;
				case ECameraModifyConditionType.与角色的相对Yaw:
					if (!CameraUtility.CheckCharacterYawDelta(scameraModifier_Condition))
					{
						return false;
					}
					break;
				default:
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Camera;
					ELogAuthor author = ELogAuthor.LJM;
					string message = "未支持的相机 Modify ConditionType";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConditionType", scameraModifier_Condition.ConditionType);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return false;
				}
				}
			}
			return true;
		}

		// Token: 0x06045E3E RID: 286270 RVA: 0x0124EB6C File Offset: 0x0124CD6C
		private static bool CheckSelfContainsTag(SCameraModifier_Condition condition)
		{
			BaseTagComponent component = Global.BaseCharacter.GetEntityNoBlueprint().GetComponent<BaseTagComponent>();
			bool flag = condition.AnyTag ? component.HasAnyTag(GameplayTagUtils.ConvertFromUeContainer(condition.TagToCheck)) : component.HasAllTag(GameplayTagUtils.ConvertFromUeContainer(condition.TagToCheck));
			if (!condition.Reverse)
			{
				return flag;
			}
			return !flag;
		}

		// Token: 0x06045E3F RID: 286271 RVA: 0x0124EBC4 File Offset: 0x0124CDC4
		private static bool CheckTargetContainsTag(SCameraModifier_Condition condition)
		{
			bool flag = false;
			EntityHandle cameraLockOnTargetEntityHandle = CameraUtility.GetCameraLockOnTargetEntityHandle();
			if (cameraLockOnTargetEntityHandle != null)
			{
				BaseTagComponent component = cameraLockOnTargetEntityHandle.Entity.GetComponent<BaseTagComponent>();
				flag = (condition.AnyTag ? component.HasAnyTag(GameplayTagUtils.ConvertFromUeContainer(condition.TagToCheck)) : component.HasAllTag(GameplayTagUtils.ConvertFromUeContainer(condition.TagToCheck)));
			}
			if (!condition.Reverse)
			{
				return flag;
			}
			return !flag;
		}

		// Token: 0x06045E40 RID: 286272 RVA: 0x0124EC24 File Offset: 0x0124CE24
		private static bool CheckCameraArmLength(SCameraModifier_Condition condition)
		{
			bool flag = false;
			double fightCameraFinalDistance = ControllerBase<CameraController>.Instance.MainModel.FightCameraFinalDistance;
			if (fightCameraFinalDistance >= (double)condition.ArmLengthMin && fightCameraFinalDistance <= (double)condition.ArmLengthMax)
			{
				flag = true;
			}
			if (!condition.Reverse)
			{
				return flag;
			}
			return !flag;
		}

		// Token: 0x06045E41 RID: 286273 RVA: 0x0124EC68 File Offset: 0x0124CE68
		private static bool CheckTargetCameraLeft(SCameraModifier_Condition condition)
		{
			bool flag = false;
			EntityHandle cameraLockOnTargetEntityHandle = CameraUtility.GetCameraLockOnTargetEntityHandle();
			if (cameraLockOnTargetEntityHandle != null)
			{
				global::Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraLocation;
				global::Vector cameraForward = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraForward;
				cameraLockOnTargetEntityHandle.Entity.GetComponent<CharacterActorComponent>().ActorLocationProxy.Subtraction(cameraLocation, CameraUtility.TempVector);
				cameraForward.CrossProduct(CameraUtility.TempVector, CameraUtility.TempVector);
				if (CameraUtility.TempVector.Z < 0.0)
				{
					flag = true;
				}
			}
			if (!condition.Reverse)
			{
				return flag;
			}
			return !flag;
		}

		// Token: 0x06045E42 RID: 286274 RVA: 0x0124ED04 File Offset: 0x0124CF04
		private static bool CheckTargetHeightDelta(SCameraModifier_Condition condition)
		{
			bool flag = false;
			EntityHandle cameraLockOnTargetEntityHandle = CameraUtility.GetCameraLockOnTargetEntityHandle();
			if (cameraLockOnTargetEntityHandle != null)
			{
				ref FVectorDouble ptr = Global.BaseCharacter.CharacterActorComponent.SkeletalMesh.D_GetSocketLocation(Singleton<CharacterNameDefines>.Instance.ROOT);
				global::Vector actorLocationProxy = cameraLockOnTargetEntityHandle.Entity.GetComponent<CharacterActorComponent>().ActorLocationProxy;
				double num = Math.Abs(ptr.Z - actorLocationProxy.Z);
				if (num >= (double)condition.LockTargetDeltaZMin && num <= (double)condition.LockTargetDeltaZMax)
				{
					flag = true;
				}
			}
			if (!condition.Reverse)
			{
				return flag;
			}
			return !flag;
		}

		// Token: 0x06045E43 RID: 286275 RVA: 0x0124ED84 File Offset: 0x0124CF84
		private static bool CheckTargetYawDelta(SCameraModifier_Condition condition)
		{
			bool flag = false;
			if (CameraUtility.GetCameraLockOnTargetEntityHandle() != null)
			{
				double num = (double)Math.Abs(CameraUtility.GetPlayerTargetAndCameraYawOffset());
				if (num >= (double)condition.LockTargetDeltaYawMin && num <= (double)condition.LockTargetDeltaYawMax)
				{
					flag = true;
				}
			}
			if (!condition.Reverse)
			{
				return flag;
			}
			return !flag;
		}

		// Token: 0x06045E44 RID: 286276 RVA: 0x0124EDCC File Offset: 0x0124CFCC
		private static bool CheckCameraPitch(SCameraModifier_Condition condition)
		{
			bool flag = false;
			global::Rotator tempRotator = CameraUtility.TempRotator;
			FRotator cameraRotation = Global.CharacterCameraManager.GetCameraRotation();
			tempRotator.DeepCopy(cameraRotation);
			double num = (double)CameraUtility.GetPitchInGravity(CameraUtility.TempRotator);
			if (num >= (double)condition.LockTargetDeltaPitchMin && num <= (double)condition.LockTargetDeltaPitchMax)
			{
				flag = true;
			}
			if (!condition.Reverse)
			{
				return flag;
			}
			return !flag;
		}

		// Token: 0x06045E45 RID: 286277 RVA: 0x0124EE24 File Offset: 0x0124D024
		private static bool CheckTargetDistance(SCameraModifier_Condition condition)
		{
			bool flag = false;
			EntityHandle cameraLockOnTargetEntityHandle = CameraUtility.GetCameraLockOnTargetEntityHandle();
			if (cameraLockOnTargetEntityHandle != null)
			{
				global::Vector actorLocationProxy = Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy;
				global::Vector actorLocationProxy2 = cameraLockOnTargetEntityHandle.Entity.GetComponent<CharacterActorComponent>().ActorLocationProxy;
				CameraUtility.GetVectorInGravity(actorLocationProxy, CameraUtility.TempVector);
				CameraUtility.GetVectorInGravity(actorLocationProxy2, CameraUtility.TempVector1);
				double num = global::Vector.DistSquared2D(CameraUtility.TempVector, CameraUtility.TempVector1);
				double num2 = (double)(condition.MinLockDistance * condition.MinLockDistance);
				double num3 = (double)(condition.MaxLockDistance * condition.MaxLockDistance);
				if (num >= num2 && num <= num3)
				{
					flag = true;
				}
			}
			if (!condition.Reverse)
			{
				return flag;
			}
			return !flag;
		}

		// Token: 0x06045E46 RID: 286278 RVA: 0x0124EEC0 File Offset: 0x0124D0C0
		private static bool CheckTargetCollision(SCameraModifier_Condition condition)
		{
			bool flag = false;
			if (condition.CameraTraceRadius > 0f)
			{
				global::Rotator actorRotationProxy = Global.BaseCharacter.CharacterActorComponent.ActorRotationProxy;
				USkeletalMeshComponent skeletalMesh = Global.BaseCharacter.CharacterActorComponent.SkeletalMesh;
				FVectorDouble fvectorDouble;
				if (skeletalMesh.DoesSocketExist(condition.CameraTraceSocket))
				{
					global::Vector tempVector = CameraUtility.TempVector;
					fvectorDouble = skeletalMesh.D_GetSocketLocation(condition.CameraTraceSocket);
					tempVector.DeepCopy(fvectorDouble);
				}
				else
				{
					global::Vector tempVector2 = CameraUtility.TempVector;
					fvectorDouble = skeletalMesh.D_GetSocketLocation(CameraUtility.CameraPosition);
					tempVector2.DeepCopy(fvectorDouble);
				}
				global::Vector tempVector3 = CameraUtility.TempVector1;
				FVector cameraTraceOffset = condition.CameraTraceOffset;
				fvectorDouble = cameraTraceOffset;
				tempVector3.DeepCopy(fvectorDouble);
				actorRotationProxy.Quaternion(null).RotateVector(CameraUtility.TempVector1, CameraUtility.TempVector1);
				CameraUtility.TempVector1.AdditionEqual(CameraUtility.TempVector);
				if (CameraUtility._cameraSphereTrace == null)
				{
					CameraUtility._cameraSphereTrace = new UTraceSphereElement();
					CameraUtility._cameraSphereTrace.bIsSingle = true;
					CameraUtility._cameraSphereTrace.bTraceComplex = false;
					CameraUtility._cameraSphereTrace.bIgnoreSelf = true;
					CameraUtility._cameraSphereTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Camera);
					CameraUtility._cameraSphereTrace.WorldContextObject = GlobalData.World;
				}
				CameraUtility._cameraSphereTrace.Radius = condition.CameraTraceRadius;
				Singleton<TraceElementCommon>.Instance.SetStartLocation(CameraUtility._cameraSphereTrace, CameraUtility.TempVector1);
				Singleton<TraceElementCommon>.Instance.SetEndLocation(CameraUtility._cameraSphereTrace, CameraUtility.TempVector1);
				flag = !Singleton<TraceElementCommon>.Instance.SphereTrace(CameraUtility._cameraSphereTrace, "CameraUtility_CheckCollision_Camera");
			}
			if (!condition.Reverse)
			{
				return flag;
			}
			return !flag;
		}

		// Token: 0x06045E47 RID: 286279 RVA: 0x0124F030 File Offset: 0x0124D230
		private static bool CheckCameraTargetConnectionLeft(SCameraModifier_Condition condition)
		{
			bool flag = false;
			EntityHandle cameraTargetEntityHandle = CameraUtility.GetCameraTargetEntityHandle();
			EntityHandle cameraLockOnTargetEntityHandle = CameraUtility.GetCameraLockOnTargetEntityHandle();
			if (cameraTargetEntityHandle != null && cameraLockOnTargetEntityHandle != null)
			{
				global::Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraLocation;
				global::Vector actorLocationProxy = cameraTargetEntityHandle.Entity.GetComponent<CharacterActorComponent>().ActorLocationProxy;
				cameraLockOnTargetEntityHandle.Entity.GetComponent<CharacterActorComponent>().ActorLocationProxy.Subtraction(actorLocationProxy, CameraUtility.TempVector);
				cameraLocation.Subtraction(actorLocationProxy, CameraUtility.TempVector1);
				CameraUtility.TempVector1.CrossProduct(CameraUtility.TempVector, CameraUtility.TempVector);
				CameraUtility.GetVectorInGravity(CameraUtility.TempVector, CameraUtility.TempVector);
				if (CameraUtility.TempVector.Z > 0.0)
				{
					flag = true;
				}
			}
			if (!condition.Reverse)
			{
				return flag;
			}
			return !flag;
		}

		// Token: 0x06045E48 RID: 286280 RVA: 0x0124F0F4 File Offset: 0x0124D2F4
		private static bool CheckCameraTargetConnectionRight(SCameraModifier_Condition condition)
		{
			bool flag = false;
			EntityHandle cameraTargetEntityHandle = CameraUtility.GetCameraTargetEntityHandle();
			EntityHandle cameraLockOnTargetEntityHandle = CameraUtility.GetCameraLockOnTargetEntityHandle();
			if (cameraTargetEntityHandle != null && cameraLockOnTargetEntityHandle != null)
			{
				global::Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraLocation;
				global::Vector actorLocationProxy = cameraTargetEntityHandle.Entity.GetComponent<CharacterActorComponent>().ActorLocationProxy;
				cameraLockOnTargetEntityHandle.Entity.GetComponent<CharacterActorComponent>().ActorLocationProxy.Subtraction(actorLocationProxy, CameraUtility.TempVector);
				cameraLocation.Subtraction(actorLocationProxy, CameraUtility.TempVector1);
				CameraUtility.TempVector1.CrossProduct(CameraUtility.TempVector, CameraUtility.TempVector);
				CameraUtility.GetVectorInGravity(CameraUtility.TempVector, CameraUtility.TempVector);
				if (CameraUtility.TempVector.Z < 0.0)
				{
					flag = true;
				}
			}
			if (!condition.Reverse)
			{
				return flag;
			}
			return !flag;
		}

		// Token: 0x06045E49 RID: 286281 RVA: 0x0124F1B8 File Offset: 0x0124D3B8
		private static bool CheckCharacterYawDelta(SCameraModifier_Condition condition)
		{
			bool flag = false;
			if (CameraUtility.GetCameraTargetEntityHandle() != null)
			{
				float playerAndCameraYawOffset = CameraUtility.GetPlayerAndCameraYawOffset();
				if (playerAndCameraYawOffset >= condition.CharacterDeltaYawMin && playerAndCameraYawOffset <= condition.CharacterDeltaYawMax)
				{
					flag = true;
				}
			}
			if (!condition.Reverse)
			{
				return flag;
			}
			return !flag;
		}

		// Token: 0x06045E4A RID: 286282 RVA: 0x0124F1F8 File Offset: 0x0124D3F8
		public static bool CharacterMovementBaseIsMoving()
		{
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			UPrimitiveComponent uprimitiveComponent;
			if (fightCamera == null)
			{
				uprimitiveComponent = null;
			}
			else
			{
				FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
				if (logicComponent == null)
				{
					uprimitiveComponent = null;
				}
				else
				{
					TsBaseCharacter character = logicComponent.Character;
					uprimitiveComponent = ((character != null) ? character.BasedMovement.MovementBase : null);
				}
			}
			UPrimitiveComponent uprimitiveComponent2 = uprimitiveComponent;
			if (uprimitiveComponent2 == null || uprimitiveComponent2.Mobility != 2)
			{
				return false;
			}
			if (!uprimitiveComponent2.GetComponentVelocity().IsNearlyZero(0.0001f))
			{
				return true;
			}
			EntityHandle entityByBaseItem = ModelBase<SceneInteractionModel>.Instance.GetEntityByBaseItem(uprimitiveComponent2.GetOwner());
			GamePlayElevatorComponent gamePlayElevatorComponent = (entityByBaseItem != null) ? entityByBaseItem.Entity.GetComponent<GamePlayElevatorComponent>() : null;
			return gamePlayElevatorComponent != null && gamePlayElevatorComponent.IsMovingOrTeleporting();
		}

		// Token: 0x06045E4B RID: 286283 RVA: 0x0124F298 File Offset: 0x0124D498
		public static void SetCameraRotationWithString(string rotation)
		{
			List<string> list = new List<string>();
			foreach (object obj in Regex.Matches(rotation, "[+-]?\\d+(?<Decimal>\\.\\d*)?"))
			{
				Match match = (Match)obj;
				list.Add(match.Value);
			}
			if (list.Count < 2)
			{
				return;
			}
			CameraUtility.SetCameraRotationWithAxisString(list[0], list[1]);
		}

		// Token: 0x06045E4C RID: 286284 RVA: 0x0124F320 File Offset: 0x0124D520
		public static void SetCameraRotationWithAxisString(string pitchStr, string yawStr)
		{
			float inPitch = MathCommon.Clamp(float.Parse(pitchStr), -89.9f, 89.9f);
			float inYaw = Singleton<MathUtils>.Instance.WrapAngle(float.Parse(yawStr));
			float inRoll = 0f;
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.SetRotation(new FRotator(inPitch, inYaw, inRoll));
		}

		// Token: 0x06045E4D RID: 286285 RVA: 0x0124F37C File Offset: 0x0124D57C
		[NullableContext(2)]
		public static void ResetFocus(float time = 0.6f, CurveBase curve = null, bool canBreakByInput = true, float stayTime = 0f)
		{
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
			if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
			{
				return;
			}
			fightCameraLogicComponent.ResetCameraInput();
			fightCameraLogicComponent.PlayCameraEulerRotatorWithCurve(CameraUtility.GetCameraDefaultFocusRotator(), time, curve, canBreakByInput, stayTime);
		}

		// Token: 0x06045E4E RID: 286286 RVA: 0x0124F3CC File Offset: 0x0124D5CC
		public unsafe static void PrintRotationInNormalGravity(global::Rotator rotation, string printContent)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid)
			{
				return;
			}
			rotation.Quaternion(CameraUtility.TempQuat);
			logicComponent.GravityQuat.Multiply(CameraUtility.TempQuat, CameraUtility.TempQuat2);
			CameraUtility.TempQuat2.Rotator(CameraUtility.TempRotator);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("rotation", rotation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RotatorInNormalGravity", CameraUtility.TempRotator);
			instance.Info(module, author, printContent, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06045E4F RID: 286287 RVA: 0x0124F47C File Offset: 0x0124D67C
		public unsafe static void PrintRotationInCameraGravity(global::Rotator rotation, string printContent)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid)
			{
				return;
			}
			rotation.Quaternion(CameraUtility.TempQuat);
			logicComponent.GravityInverseQuat.Multiply(CameraUtility.TempQuat, CameraUtility.TempQuat2);
			CameraUtility.TempQuat2.Rotator(CameraUtility.TempRotator);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("rotation", rotation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RotatorInCameraGravity", CameraUtility.TempRotator);
			instance.Info(module, author, printContent, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06045E50 RID: 286288 RVA: 0x0124F52C File Offset: 0x0124D72C
		public static global::Rotator GetRotatorInGravity(global::Rotator rotator, global::Rotator outRotator)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outRotator.DeepCopy(rotator);
				return outRotator;
			}
			rotator.Quaternion(CameraUtility.TempQuat);
			logicComponent.GravityInverseQuat.Multiply(CameraUtility.TempQuat, CameraUtility.TempQuat2);
			CameraUtility.TempQuat2.Rotator(outRotator);
			return outRotator;
		}

		// Token: 0x06045E51 RID: 286289 RVA: 0x0124F598 File Offset: 0x0124D798
		public static global::Rotator SetRotatorInGravity(global::Rotator inOutRotator, global::Rotator rotator)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				inOutRotator.DeepCopy(rotator);
				return inOutRotator;
			}
			rotator.Quaternion(CameraUtility.TempQuat);
			logicComponent.GravityQuat.Multiply(CameraUtility.TempQuat, CameraUtility.TempQuat2);
			CameraUtility.TempQuat2.Rotator(inOutRotator);
			return inOutRotator;
		}

		// Token: 0x06045E52 RID: 286290 RVA: 0x0124F604 File Offset: 0x0124D804
		public static global::Rotator GetRotatorInNormal(global::Rotator rotator, global::Rotator outRotator)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outRotator.DeepCopy(rotator);
				return outRotator;
			}
			rotator.Quaternion(CameraUtility.TempQuat);
			logicComponent.GravityQuat.Multiply(CameraUtility.TempQuat, CameraUtility.TempQuat2);
			CameraUtility.TempQuat2.Rotator(outRotator);
			return outRotator;
		}

		// Token: 0x06045E53 RID: 286291 RVA: 0x0124F670 File Offset: 0x0124D870
		public static global::Vector GetVectorInGravity(global::Vector vector, global::Vector outVector)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outVector.DeepCopy(vector);
				return outVector;
			}
			logicComponent.GravityInverseQuat.RotateVector(vector, outVector);
			return outVector;
		}

		// Token: 0x06045E54 RID: 286292 RVA: 0x0124F6BC File Offset: 0x0124D8BC
		public static global::Vector GetVectorInNormal(global::Vector vector, global::Vector outVector)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outVector.DeepCopy(vector);
				return outVector;
			}
			logicComponent.GravityQuat.RotateVector(vector, outVector);
			return outVector;
		}

		// Token: 0x06045E55 RID: 286293 RVA: 0x0124F708 File Offset: 0x0124D908
		public static float GetPitchInGravity(global::Rotator rotator)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				return rotator.Pitch;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(rotator, logicComponent.GravityInverseQuat, CameraUtility.TempRotator);
			return CameraUtility.TempRotator.Pitch;
		}

		// Token: 0x06045E56 RID: 286294 RVA: 0x0124F764 File Offset: 0x0124D964
		public static global::Rotator SetPitchInGravity(global::Rotator rotator, double pitch, global::Rotator outRotator)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outRotator.DeepCopy(rotator);
				outRotator.Pitch = (float)MathCommon.Clamp(pitch, -89.9000015258789, 89.9000015258789);
				return outRotator;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(rotator, logicComponent.GravityInverseQuat, CameraUtility.TempRotator);
			CameraUtility.TempRotator.Pitch = (float)MathCommon.Clamp(pitch, -89.9000015258789, 89.9000015258789);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(CameraUtility.TempRotator, logicComponent.GravityQuat, outRotator);
			return outRotator;
		}

		// Token: 0x06045E57 RID: 286295 RVA: 0x0124F810 File Offset: 0x0124DA10
		public static global::Rotator AddPitchInGravity(global::Rotator rotator, double addPitch, global::Rotator outRotator)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outRotator.DeepCopy(rotator);
				outRotator.Pitch = (float)MathCommon.Clamp((double)outRotator.Pitch + addPitch, -89.9000015258789, 89.9000015258789);
				return outRotator;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(rotator, logicComponent.GravityInverseQuat, CameraUtility.TempRotator);
			CameraUtility.TempRotator.Pitch = (float)MathCommon.Clamp((double)CameraUtility.TempRotator.Pitch + addPitch, -89.9000015258789, 89.9000015258789);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(CameraUtility.TempRotator, logicComponent.GravityQuat, outRotator);
			return outRotator;
		}

		// Token: 0x06045E58 RID: 286296 RVA: 0x0124F8D0 File Offset: 0x0124DAD0
		public static float GetYawInGravity(global::Rotator rotator)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				return rotator.Yaw;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(rotator, logicComponent.GravityInverseQuat, CameraUtility.TempRotator);
			return CameraUtility.TempRotator.Yaw;
		}

		// Token: 0x06045E59 RID: 286297 RVA: 0x0124F92C File Offset: 0x0124DB2C
		public static global::Rotator SetYawInGravity(global::Rotator rotator, double yaw, global::Rotator outRotator)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outRotator.DeepCopy(rotator);
				outRotator.Yaw = (float)Singleton<MathUtils>.Instance.WrapAngle(yaw);
				return outRotator;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(rotator, logicComponent.GravityInverseQuat, CameraUtility.TempRotator);
			CameraUtility.TempRotator.Yaw = (float)Singleton<MathUtils>.Instance.WrapAngle(yaw);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(CameraUtility.TempRotator, logicComponent.GravityQuat, outRotator);
			return outRotator;
		}

		// Token: 0x06045E5A RID: 286298 RVA: 0x0124F9C0 File Offset: 0x0124DBC0
		public static global::Rotator AddYawInGravity(global::Rotator rotator, double addYaw, global::Rotator outRotator)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outRotator.DeepCopy(rotator);
				outRotator.Yaw = (float)Singleton<MathUtils>.Instance.WrapAngle((double)outRotator.Yaw + addYaw);
				return outRotator;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(rotator, logicComponent.GravityInverseQuat, CameraUtility.TempRotator);
			CameraUtility.TempRotator.Yaw = (float)Singleton<MathUtils>.Instance.WrapAngle((double)CameraUtility.TempRotator.Yaw + addYaw);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(CameraUtility.TempRotator, logicComponent.GravityQuat, outRotator);
			return outRotator;
		}

		// Token: 0x06045E5B RID: 286299 RVA: 0x0124FA68 File Offset: 0x0124DC68
		public static float GetRollInGravity(global::Rotator rotator)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				return rotator.Roll;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(rotator, logicComponent.GravityInverseQuat, CameraUtility.TempRotator);
			return CameraUtility.TempRotator.Roll;
		}

		// Token: 0x06045E5C RID: 286300 RVA: 0x0124FAC4 File Offset: 0x0124DCC4
		public static global::Rotator SetRollInGravity(global::Rotator rotator, double roll, global::Rotator outRotator)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outRotator.DeepCopy(rotator);
				outRotator.Roll = (float)Singleton<MathUtils>.Instance.WrapAngle(roll);
				return outRotator;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(rotator, logicComponent.GravityInverseQuat, CameraUtility.TempRotator);
			CameraUtility.TempRotator.Roll = (float)Singleton<MathUtils>.Instance.WrapAngle(roll);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(CameraUtility.TempRotator, logicComponent.GravityQuat, outRotator);
			return outRotator;
		}

		// Token: 0x06045E5D RID: 286301 RVA: 0x0124FB58 File Offset: 0x0124DD58
		public static global::Rotator AddRollInGravity(global::Rotator rotator, double addRoll, global::Rotator outRotator)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outRotator.DeepCopy(rotator);
				outRotator.Roll = (float)Singleton<MathUtils>.Instance.WrapAngle((double)outRotator.Roll + addRoll);
				return outRotator;
			}
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(rotator, logicComponent.GravityInverseQuat, CameraUtility.TempRotator);
			CameraUtility.TempRotator.Roll = (float)Singleton<MathUtils>.Instance.WrapAngle((double)CameraUtility.TempRotator.Roll + addRoll);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(CameraUtility.TempRotator, logicComponent.GravityQuat, outRotator);
			return outRotator;
		}

		// Token: 0x06045E5E RID: 286302 RVA: 0x0124FC00 File Offset: 0x0124DE00
		public static global::Vector SetXnInGravity(global::Vector vector, double x, global::Vector outVector)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outVector.DeepCopy(vector);
				outVector.X = x;
				return outVector;
			}
			Singleton<GravityUtils>.Instance.GetVectorInGravity(vector, logicComponent.GravityInverseQuat, outVector);
			outVector.X = x;
			Singleton<GravityUtils>.Instance.GetVectorInNormal(outVector, logicComponent.GravityQuat, outVector);
			return outVector;
		}

		// Token: 0x06045E5F RID: 286303 RVA: 0x0124FC70 File Offset: 0x0124DE70
		public static global::Vector SetYnInGravity(global::Vector vector, float y, global::Vector outVector)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outVector.DeepCopy(vector);
				outVector.Y = (double)y;
				return outVector;
			}
			Singleton<GravityUtils>.Instance.GetVectorInGravity(vector, logicComponent.GravityInverseQuat, outVector);
			outVector.Y = (double)y;
			Singleton<GravityUtils>.Instance.GetVectorInNormal(outVector, logicComponent.GravityQuat, outVector);
			return outVector;
		}

		// Token: 0x06045E60 RID: 286304 RVA: 0x0124FCE4 File Offset: 0x0124DEE4
		public static global::Vector SetZnInGravity(global::Vector vector, double z, global::Vector outVector)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outVector.DeepCopy(vector);
				outVector.Z = z;
				return outVector;
			}
			Singleton<GravityUtils>.Instance.GetVectorInGravity(vector, logicComponent.GravityInverseQuat, outVector);
			outVector.Z = z;
			Singleton<GravityUtils>.Instance.GetVectorInNormal(outVector, logicComponent.GravityQuat, outVector);
			return outVector;
		}

		// Token: 0x06045E61 RID: 286305 RVA: 0x0124FD54 File Offset: 0x0124DF54
		public static float GetZnInGravity(global::Vector vector)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				return (float)vector.Z;
			}
			return (float)CameraUtility.GetVectorInGravity(vector, CameraUtility.TempVector).Z;
		}

		// Token: 0x06045E62 RID: 286306 RVA: 0x0124FDA0 File Offset: 0x0124DFA0
		public static global::Vector AddZnInGravity(global::Vector vector, double addZ, global::Vector outVector)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (!logicComponent.Valid || logicComponent.IsInNormalGravityMode())
			{
				outVector.DeepCopy(vector);
				outVector.Z += addZ;
				return outVector;
			}
			outVector.DeepCopy(vector);
			Singleton<GravityUtils>.Instance.AddZnInGravity(logicComponent.GravityDirect, outVector, addZ);
			return outVector;
		}

		// Token: 0x06045E63 RID: 286307 RVA: 0x0124FE04 File Offset: 0x0124E004
		public static FName GetCameraMode(ECustomCameraMode cameraMode)
		{
			switch (cameraMode)
			{
			case ECustomCameraMode.LockOn:
				return CameraUtility.CameraModeLockOn;
			case ECustomCameraMode.Sequence:
				return CameraUtility.CameraModeSequence;
			case ECustomCameraMode.Widget:
				return CameraUtility.CameraModeWidget;
			case ECustomCameraMode.Scene:
				return CameraUtility.CameraModeScene;
			case ECustomCameraMode.Orbital:
				return CameraUtility.CameraModeOrbital;
			case ECustomCameraMode.Free:
				return CameraUtility.CameraModeFree;
			default:
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "Invalid Camera Mode";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cameraMode", cameraMode);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return CameraUtility.CameraModeDefault;
			}
			}
		}

		// Token: 0x06045E64 RID: 286308 RVA: 0x0124FE88 File Offset: 0x0124E088
		public static double GetValidPitchAngle(double limitPitchAngle, bool isMinValue)
		{
			if (!Singleton<MathUtils>.Instance.IsNearlyZero(limitPitchAngle, new double?((double)0.0001f)) && Singleton<MathUtils>.Instance.IsNearlyZero(Math.Abs(limitPitchAngle) % 90.0, new double?((double)0.0001f)))
			{
				return (double)((limitPitchAngle > 0.0) ? 89.9f : -89.9f);
			}
			if (!isMinValue)
			{
				return Math.Min(limitPitchAngle, 89.9000015258789);
			}
			return Math.Max(limitPitchAngle, -89.9000015258789);
		}

		// Token: 0x06045E65 RID: 286309 RVA: 0x0124FF10 File Offset: 0x0124E110
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x06045E66 RID: 286310 RVA: 0x0124FF12 File Offset: 0x0124E112
		public static void ResetStaticDefaultValue()
		{
			CameraUtility._cameraSphereTrace = null;
		}

		// Token: 0x04027249 RID: 160329
		private const string PROFILE_KEY = "CameraUtility_CheckCollision_Camera";

		// Token: 0x0402724A RID: 160330
		private const float RESET_FOCUS_TIME = 0.6f;

		// Token: 0x0402724B RID: 160331
		private const float PITCH_LIMIT_VALUE = 89.9f;

		// Token: 0x0402724C RID: 160332
		[StaticVariableRuleIgnore]
		public static readonly FName CameraPosition = new FName("CameraPosition");

		// Token: 0x0402724D RID: 160333
		[StaticVariableRuleIgnore]
		public static readonly FName HitCase = new FName("HitCase");

		// Token: 0x0402724E RID: 160334
		[StaticVariableRuleIgnore]
		public static readonly FName Root = new FName("Root");

		// Token: 0x0402724F RID: 160335
		[StaticVariableRuleIgnore]
		public static readonly FName CameraModeDefault = new FName("KuroDefault");

		// Token: 0x04027250 RID: 160336
		[StaticVariableRuleIgnore]
		public static readonly FName CameraModeLockOn = new FName("KuroLockOn");

		// Token: 0x04027251 RID: 160337
		[StaticVariableRuleIgnore]
		public static readonly FName CameraModeWidget = new FName("KuroWidget");

		// Token: 0x04027252 RID: 160338
		[StaticVariableRuleIgnore]
		public static readonly FName CameraModeSequence = new FName("KuroSequence");

		// Token: 0x04027253 RID: 160339
		[StaticVariableRuleIgnore]
		public static readonly FName CameraModeScene = new FName("KuroScene");

		// Token: 0x04027254 RID: 160340
		[StaticVariableRuleIgnore]
		public static readonly FName CameraModeOrbital = new FName("KuroOrbital");

		// Token: 0x04027255 RID: 160341
		[StaticVariableRuleIgnore]
		public static readonly FName CameraModeFree = new FName("KuroFree");

		// Token: 0x04027256 RID: 160342
		[StaticVariableRuleIgnore]
		private static readonly global::Vector TempVector = global::Vector.Create();

		// Token: 0x04027257 RID: 160343
		[StaticVariableRuleIgnore]
		private static readonly global::Vector TempVector1 = global::Vector.Create();

		// Token: 0x04027258 RID: 160344
		[StaticVariableRuleIgnore]
		private static readonly Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x04027259 RID: 160345
		[StaticVariableRuleIgnore]
		private static readonly Quat TempQuat2 = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x0402725A RID: 160346
		[StaticVariableRuleIgnore]
		private static readonly global::Rotator TempRotator = global::Rotator.Create();

		// Token: 0x0402725B RID: 160347
		public static readonly float CapsuleHeightRatio = 0.67f;

		// Token: 0x0402725C RID: 160348
		[Nullable(2)]
		private static UTraceSphereElement _cameraSphereTrace;
	}
}
