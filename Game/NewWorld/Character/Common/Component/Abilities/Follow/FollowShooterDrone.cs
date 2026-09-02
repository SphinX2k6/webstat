using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.FollowShooter;
using AkiClient.Game.Aki.Data.Fight.Struct;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x0200496A RID: 18794
	[NullableContext(1)]
	[Nullable(0)]
	public class FollowShooterDrone
	{
		// Token: 0x06031256 RID: 201302 RVA: 0x00C3D3E8 File Offset: 0x00C3B5E8
		private static void ExecuteExecutor(TFollowShooterExecutor executor, Entity entity, FName targetName, SLockOnFollowShooter lockOnFollowShooter, SLockOnFollowShooterAutoAim lockOnFollowShooterAutoAim)
		{
			BaseActorComponent baseActorComponent = entity.CheckGetComponent<BaseActorComponent>();
			AActor aactor = (baseActorComponent != null) ? baseActorComponent.Owner : null;
			if (aactor == null)
			{
				return;
			}
			foreach (USceneComponent usceneComponent in aactor.GetComponentsByTag(USceneComponent.StaticClass(), targetName).Cast<USceneComponent>())
			{
				if (usceneComponent.IsValid())
				{
					executor(entity, usceneComponent, lockOnFollowShooter, lockOnFollowShooterAutoAim);
				}
			}
		}

		// Token: 0x06031257 RID: 201303 RVA: 0x00C3D468 File Offset: 0x00C3B668
		private static void TryShoot(Entity entity, AActor target, float angleDiff, Dictionary<string, double> lastAutoShootTime, SLockOnFollowShooter lockOnFollowShooter, SLockOnFollowShooterAutoAim lockOnFollowShooterAutoAim)
		{
			FName shouldAimAtLockOnTargetName = lockOnFollowShooterAutoAim.ShouldAimAtLockOnTargetName;
			bool flag = false;
			EntityHandle entityByActor = ActorUtils.GetEntityByActor(target, false);
			if (entityByActor != null && entityByActor.Valid)
			{
				WorldEntity entity2 = entityByActor.Entity;
				if (entity2 != null && entity2.Valid)
				{
					BaseTagComponent baseTagComponent = entityByActor.Entity.CheckGetComponent<BaseTagComponent>();
					if (baseTagComponent == null)
					{
						return;
					}
					foreach (FGameplayTag tag in lockOnFollowShooter.AutoShootGameplayTagContainer.GameplayTags)
					{
						if (baseTagComponent.HasTag(tag.TagId()))
						{
							flag = true;
							break;
						}
					}
				}
			}
			if (!flag)
			{
				return;
			}
			BaseSkillComponent component = entity.GetComponent<BaseSkillComponent>();
			if (component == null)
			{
				return;
			}
			string key = shouldAimAtLockOnTargetName.ToString();
			if (!lastAutoShootTime.ContainsKey(key))
			{
				lastAutoShootTime.Add(key, -1.0);
			}
			if (angleDiff <= lockOnFollowShooterAutoAim.AutoShootAngle && Singleton<Time>.Instance.Now - lastAutoShootTime[key] >= (double)lockOnFollowShooterAutoAim.AutoShootGapTime)
			{
				lastAutoShootTime[key] = Singleton<Time>.Instance.Now;
				component.BeginSkillAsync(lockOnFollowShooterAutoAim.AutoShootSkillId, null).Forget<bool>();
			}
		}

		// Token: 0x06031258 RID: 201304 RVA: 0x00C3D598 File Offset: 0x00C3B798
		public static bool ShouldUpdateRotationToAimAtLockOnTarget(SLockOnFollowShooterAutoAim lockOnFollowShooterAutoAim, object actorOrEntityId)
		{
			EntityHandle entityHandle = null;
			if (actorOrEntityId is int)
			{
				entityHandle = ModelBase<CreatureModel>.Instance.GetEntityById((int)actorOrEntityId);
			}
			else if (actorOrEntityId is AActor)
			{
				entityHandle = ActorUtils.GetEntityByActor((AActor)actorOrEntityId, false);
			}
			BaseTagComponent baseTagComponent;
			if (entityHandle == null)
			{
				baseTagComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				baseTagComponent = ((entity != null) ? entity.CheckGetComponent<BaseTagComponent>() : null);
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if (baseTagComponent2 == null)
			{
				return false;
			}
			for (int i = 0; i < lockOnFollowShooterAutoAim.StopUpdateRotationWhileHasTags.GameplayTags.Num(); i++)
			{
				FGameplayTag tag = lockOnFollowShooterAutoAim.StopUpdateRotationWhileHasTags.GameplayTags.Get(i);
				if (baseTagComponent2.HasTag(tag.TagId()))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06031259 RID: 201305 RVA: 0x00C3D634 File Offset: 0x00C3B834
		private static void UpdateTransformByStrategy(float deltaTime, FollowShooterAimTarget aimTarget, [Nullable(2)] AActor targetForShoot, [Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<string, double> lastAutoShootTime, Entity entity, USceneComponent sceneComponent, SLockOnFollowShooter lockOnFollowShooter, SLockOnFollowShooterAutoAim lockOnFollowShooterAutoAim)
		{
			if (!FollowShooterDrone.ShouldUpdateRotationToAimAtLockOnTarget(lockOnFollowShooterAutoAim, entity.Id))
			{
				return;
			}
			IFollowShooterAttachStrategy followShooterAttachStrategy = FollowShooterAttachStrategies.getFollowShooterAttachStrategy(FollowShooterAttachStrategies.getSceneComponentAttachStrategy(sceneComponent));
			IUpdateRotationParams @params = new UpdateRotationParams
			{
				DeltaTimeMs = deltaTime,
				RotationInterpSpeed = lockOnFollowShooterAutoAim.RotationInterpSpeed,
				RotateOffset = lockOnFollowShooterAutoAim.RotateOffset,
				AimTarget = aimTarget
			};
			float? num = followShooterAttachStrategy.UpdateTransform(sceneComponent, @params);
			if (num != null && targetForShoot != null && lastAutoShootTime != null)
			{
				FollowShooterDrone.TryShoot(entity, targetForShoot, num.Value, lastAutoShootTime, lockOnFollowShooter, lockOnFollowShooterAutoAim);
			}
		}

		// Token: 0x0603125A RID: 201306 RVA: 0x00C3D6C0 File Offset: 0x00C3B8C0
		private unsafe static void AllOwnerSceneComponentExecute(Entity entity, BP_FollowShooterConfig_C followShooterConfig, TFollowShooterExecutor executor)
		{
			if (followShooterConfig == null || !followShooterConfig.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "AllOwnerSceneComponentExecute 参数错误";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("FollowShooterConfig", followShooterConfig);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Executor", executor);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			foreach (SLockOnFollowShooterAutoAim slockOnFollowShooterAutoAim in followShooterConfig.LockOnConfig.ArrayAutoAimConfig)
			{
				FollowShooterDrone.ExecuteExecutor(executor, entity, slockOnFollowShooterAutoAim.ShouldAimAtLockOnTargetName, followShooterConfig.LockOnConfig, slockOnFollowShooterAutoAim);
			}
		}

		// Token: 0x0603125B RID: 201307 RVA: 0x00C3D7A8 File Offset: 0x00C3B9A8
		public unsafe static void SpecificOwnerSceneComponentExecute(Entity entity, BP_FollowShooterConfig_C followShooterConfig, FName targetName, TFollowShooterExecutor executor)
		{
			if (followShooterConfig == null || !entity.Valid || FNameUtil.IsNothing(targetName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "SpecificOwnerSceneComponentExecute 参数错误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("FollowShooterConfig", followShooterConfig);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entity", entity.Id);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			foreach (SLockOnFollowShooterAutoAim slockOnFollowShooterAutoAim in followShooterConfig.LockOnConfig.ArrayAutoAimConfig)
			{
				if (!(targetName != slockOnFollowShooterAutoAim.ShouldAimAtLockOnTargetName))
				{
					FollowShooterDrone.ExecuteExecutor(executor, entity, targetName, followShooterConfig.LockOnConfig, slockOnFollowShooterAutoAim);
				}
			}
		}

		// Token: 0x0603125C RID: 201308 RVA: 0x00C3D884 File Offset: 0x00C3BA84
		public unsafe static void AttachToByConfig(USceneComponent targetComponent, int tagId, Entity entity, USceneComponent sceneComponent, SLockOnFollowShooter lockOnFollowShooter, SLockOnFollowShooterAutoAim lockOnFollowShooterAutoAim)
		{
			FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(tagId);
			if (gameplayTagById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "AttachToByConfig 参数错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TagId", tagId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			SLockOnFollowShooterAttachmentRule slockOnFollowShooterAttachmentRule = lockOnFollowShooterAutoAim.MapAttachToFollowingWhileHasTag.Get(gameplayTagById.Value);
			if (slockOnFollowShooterAttachmentRule == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Character;
				ELogAuthor author2 = ELogAuthor.XDW;
				string message2 = "AttachToByConfig 参数错误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TagId", tagId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AttachmentRule", slockOnFollowShooterAttachmentRule);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			foreach (IFollowShooterAttachStrategy followShooterAttachStrategy in FollowShooterAttachStrategies.getAllFollowShooterAttachStrategies())
			{
				followShooterAttachStrategy.OnDetach(sceneComponent, slockOnFollowShooterAttachmentRule);
			}
			FollowShooterAttachStrategies.getFollowShooterAttachStrategy(slockOnFollowShooterAttachmentRule.AttachStrategy).OnAttach(sceneComponent, slockOnFollowShooterAttachmentRule, targetComponent);
			FollowShooterAttachStrategies.setSceneComponentAttachStrategy(sceneComponent, slockOnFollowShooterAttachmentRule.AttachStrategy);
		}

		// Token: 0x0603125D RID: 201309 RVA: 0x00C3D9B4 File Offset: 0x00C3BBB4
		public static void ClearStrategyStatesForOwner(Entity entity, BP_FollowShooterConfig_C followShooterConfig)
		{
			TFollowShooterExecutor executor;
			if ((executor = FollowShooterDrone.<>O.<0>__ClearStrategyStateExecutor) == null)
			{
				executor = (FollowShooterDrone.<>O.<0>__ClearStrategyStateExecutor = new TFollowShooterExecutor(FollowShooterDrone.ClearStrategyStateExecutor));
			}
			FollowShooterDrone.AllOwnerSceneComponentExecute(entity, followShooterConfig, executor);
		}

		// Token: 0x0603125E RID: 201310 RVA: 0x00C3D9D8 File Offset: 0x00C3BBD8
		private static void ClearStrategyStateExecutor(Entity entity, USceneComponent sceneComponent, SLockOnFollowShooter lockOnFollowShooter, SLockOnFollowShooterAutoAim lockOnFollowShooterAutoAim)
		{
			FollowShooterAttachStrategies.clearFollowShooterAttachStrategiesStateForSceneComponent(sceneComponent);
		}

		// Token: 0x0603125F RID: 201311 RVA: 0x00C3D9E0 File Offset: 0x00C3BBE0
		public static void SetHiddenInGame(bool newHidden, Entity entity, USceneComponent sceneComponent, SLockOnFollowShooter lockOnFollowShooter, SLockOnFollowShooterAutoAim lockOnFollowShooterAutoAim)
		{
			sceneComponent.SetHiddenInGame(newHidden, true);
		}

		// Token: 0x06031260 RID: 201312 RVA: 0x00C3D9EC File Offset: 0x00C3BBEC
		public static void UpdateTransformToAimAtLockOnTarget(Entity entity, AActor target, Dictionary<string, double> lastAutoShootTime, BP_FollowShooterConfig_C followShooterConfig, float deltaTime)
		{
			FVectorDouble? lockOnTargetLocation = LockOnUtils.GetLockOnTargetLocation(target);
			if (lockOnTargetLocation == null)
			{
				return;
			}
			LockOnAimTarget aimTarget = new LockOnAimTarget(lockOnTargetLocation.Value);
			FollowShooterDrone.AllOwnerSceneComponentExecute(entity, followShooterConfig, delegate(Entity entity1, USceneComponent sceneComponent, SLockOnFollowShooter lockOnFollowShooter, SLockOnFollowShooterAutoAim lockOnFollowShooterAutoAim)
			{
				FollowShooterDrone.UpdateTransformByStrategy(deltaTime, aimTarget, target, lastAutoShootTime, entity1, sceneComponent, lockOnFollowShooter, lockOnFollowShooterAutoAim);
			});
		}

		// Token: 0x06031261 RID: 201313 RVA: 0x00C3DA50 File Offset: 0x00C3BC50
		public static void UpdateTransformToCameraForward(Entity entity, FVector up, BP_FollowShooterConfig_C followShooterConfig, float deltaTime)
		{
			float cameraForwardDistance = (followShooterConfig != null) ? followShooterConfig.LockOnConfig.CameraForwardDistance : 0f;
			CameraAimTarget aimTarget = new CameraAimTarget(cameraForwardDistance, up);
			FollowShooterDrone.AllOwnerSceneComponentExecute(entity, followShooterConfig, delegate(Entity entity1, USceneComponent sceneComponent, SLockOnFollowShooter lockOnFollowShooter, SLockOnFollowShooterAutoAim lockOnFollowShooterAutoAim)
			{
				FollowShooterDrone.UpdateTransformByStrategy(deltaTime, aimTarget, null, null, entity1, sceneComponent, lockOnFollowShooter, lockOnFollowShooterAutoAim);
			});
		}

		// Token: 0x06031262 RID: 201314 RVA: 0x00C3DAA0 File Offset: 0x00C3BCA0
		public static UniTask AsyncStartShootAtTargets(int entityId, BP_FollowShooterConfig_C followShooterConfig, List<Vector> targets, [Nullable(2)] UPrimaryDataAsset deadEyeFollowShooterConfig, float selfCenterTimeDilation)
		{
			FollowShooterDrone.<AsyncStartShootAtTargets>d__13 <AsyncStartShootAtTargets>d__;
			<AsyncStartShootAtTargets>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AsyncStartShootAtTargets>d__.entityId = entityId;
			<AsyncStartShootAtTargets>d__.followShooterConfig = followShooterConfig;
			<AsyncStartShootAtTargets>d__.targets = targets;
			<AsyncStartShootAtTargets>d__.deadEyeFollowShooterConfig = deadEyeFollowShooterConfig;
			<AsyncStartShootAtTargets>d__.selfCenterTimeDilation = selfCenterTimeDilation;
			<AsyncStartShootAtTargets>d__.<>1__state = -1;
			<AsyncStartShootAtTargets>d__.<>t__builder.Start<FollowShooterDrone.<AsyncStartShootAtTargets>d__13>(ref <AsyncStartShootAtTargets>d__);
			return <AsyncStartShootAtTargets>d__.<>t__builder.Task;
		}

		// Token: 0x0401C4BB RID: 115899
		private static readonly int deadEyeTag = GameplayTagDefine.EGameplayTagId["关卡.Common.表现.死眼跳台.瞄准锁定"];

		// Token: 0x0200A9E0 RID: 43488
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04034912 RID: 215314
			[Nullable(0)]
			public static TFollowShooterExecutor <0>__ClearStrategyStateExecutor;
		}
	}
}
