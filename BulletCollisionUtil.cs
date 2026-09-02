using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using AkiClient.Game.Aki.Data.Fight.Struct;
using CSharpScript.Core;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.Audio;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002DD3 RID: 11731
[NullableContext(1)]
[Nullable(0)]
public class BulletCollisionUtil : IStaticVariableResetter
{
	// Token: 0x06017A37 RID: 96823 RVA: 0x00696078 File Offset: 0x00694278
	static BulletCollisionUtil()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BulletCollisionUtil.CreateStaticDefaultValue), new Action(BulletCollisionUtil.ResetStaticDefaultValue));
	}

	// Token: 0x06017A38 RID: 96824 RVA: 0x00696130 File Offset: 0x00694330
	public static void UpdateCollisionExtend(global::EBulletShape shape, UPrimitiveComponent collisionComponent, Vector size, Vector centerLocalLocation, Rotator compRotator)
	{
		switch (shape)
		{
		case global::EBulletShape.Cube:
			(collisionComponent as UBoxComponent).D_SetBoxExtent(size.ToUeVector(false), true);
			return;
		case global::EBulletShape.Sphere:
			(collisionComponent as USphereComponent).SetSphereRadius((float)size.X, true);
			return;
		case global::EBulletShape.Sector:
		{
			Vector sectorExtent = BulletCollisionUtil.GetSectorExtent(size, centerLocalLocation);
			UBoxComponent uboxComponent = collisionComponent as UBoxComponent;
			Vector vector = BulletPool.CreateVector(false);
			compRotator.Quaternion(null).RotateVector(BulletCollisionUtil.CollisionLocalLocation, vector);
			uboxComponent.D_K2_SetRelativeLocation(vector.ToUeVector(false), false, ref Singleton<GlobalRefCache>.Instance.HitResult, true);
			BulletPool.RecycleVector(vector);
			uboxComponent.D_SetBoxExtent(sectorExtent.ToUeVector(false), true);
			return;
		}
		case global::EBulletShape.Cylinder:
			(collisionComponent as UBoxComponent).D_SetBoxExtent(new FVectorDouble(size.X, size.X, size.Z), true);
			return;
		default:
			return;
		}
	}

	// Token: 0x06017A39 RID: 96825 RVA: 0x006961F4 File Offset: 0x006943F4
	public static void UpdateRegionExtend(global::EBulletShape shape, UKuroRegionShapeComponent regionComponent, Vector size)
	{
		switch (shape)
		{
		case global::EBulletShape.BigCube:
			(regionComponent as UKuroRegionBoxComponent).BoxExtent = size.ToUeVectorOld();
			return;
		case global::EBulletShape.BigSphere:
			(regionComponent as UKuroRegionSphereComponent).Radius = (float)size.X;
			return;
		case global::EBulletShape.BigSector:
		{
			UKuroRegionSectorComponent ukuroRegionSectorComponent = regionComponent as UKuroRegionSectorComponent;
			ukuroRegionSectorComponent.Radius = (float)size.X;
			ukuroRegionSectorComponent.HalfHeight = (float)size.Z;
			ukuroRegionSectorComponent.Angle = (float)size.Y;
			return;
		}
		case global::EBulletShape.BigCylinder:
		{
			UKuroRegionCylinderComponent ukuroRegionCylinderComponent = regionComponent as UKuroRegionCylinderComponent;
			ukuroRegionCylinderComponent.Radius = (float)size.X;
			ukuroRegionCylinderComponent.HalfHeight = (float)size.Z;
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x06017A3A RID: 96826 RVA: 0x0069628C File Offset: 0x0069448C
	public static Vector GetSectorExtent(Vector size, Vector centerLocalLocation)
	{
		BulletCollisionUtil.CollisionLocalLocation.FromUeVector(centerLocalLocation);
		Vector vector = Vector.Create();
		if (size.Y < 180.0)
		{
			BulletCollisionUtil.CollisionLocalLocation.X += size.X * 0.5;
			vector.Set(size.X * 0.5, Math.Sin(size.Y * 0.5 * 0.01745329238474369) * size.X, size.Z);
		}
		else
		{
			double num = Math.Cos(size.Y * 0.5 * 0.01745329238474369);
			BulletCollisionUtil.CollisionLocalLocation.X += size.X * (1.0 + num) * 0.5;
			vector.Set(size.X * (1.0 - num) * 0.5, size.X, size.Z);
		}
		return vector;
	}

	// Token: 0x06017A3B RID: 96827 RVA: 0x0069639C File Offset: 0x0069459C
	public static void ShowBulletDeBugDraw(BulletInfo bulletInfo)
	{
		UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.GameInstance, bulletInfo.ActorComponent.ActorLocation, 10f, 12, new FLinearColor?(ColorUtils.LinearRed), 0f, 0f);
		if (bulletInfo.Size.IsZero())
		{
			return;
		}
		global::EBulletShape shape = bulletInfo.BulletDataMain.Base.Shape;
		UPrimitiveComponent collisionComponent = bulletInfo.CollisionInfo.CollisionComponent;
		if (shape == global::EBulletShape.Cylinder)
		{
			float boundsScale = (collisionComponent as UBoxComponent).BoundsScale;
			BulletStaticFunction.DebugDrawRing((double)((float)(bulletInfo.Size.Z * (double)boundsScale)), (double)((float)((double)boundsScale * bulletInfo.Size.Y)), (double)((float)(bulletInfo.Size.X * (double)boundsScale)), bulletInfo.CenterLocation, bulletInfo.ActorComponent.ActorUpProxy);
			BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
			if (bulletDataMain == null || !bulletDataMain.Base.DebugShowProgress)
			{
				return;
			}
			Vector vector = BulletPool.CreateVector(false);
			vector.FromUeVector(bulletInfo.CenterLocation);
			vector.Z -= bulletInfo.Size.Z * (double)boundsScale;
			float num = bulletInfo.LiveTime * 0.001f;
			float num2 = Singleton<MathUtils>.Instance.Lerp((float)((double)boundsScale * bulletInfo.Size.Y), (float)(bulletInfo.Size.X * (double)boundsScale), num / bulletInfo.Duration);
			UObject gameInstance = GlobalData.GameInstance;
			FVectorDouble center = vector.ToUeVector(false);
			float radius = num2;
			int numSegments = 36;
			FLinearColor? lineColor = new FLinearColor?(ColorUtils.LinearRed);
			float duration = bulletInfo.Duration - num;
			float thickness = 3f;
			AActor actor = bulletInfo.Actor;
			FVectorDouble? yaxis = (actor != null) ? new FVectorDouble?(actor.D_GetActorRightVector()) : null;
			AActor actor2 = bulletInfo.Actor;
			UKismetSystemLibrary.D_DrawDebugCircle(gameInstance, center, radius, numSegments, lineColor, duration, thickness, yaxis, (actor2 != null) ? new FVectorDouble?(actor2.D_GetActorForwardVector()) : null, false);
			BulletPool.RecycleVector(vector);
			return;
		}
		else
		{
			if (shape == global::EBulletShape.Sector)
			{
				float boundsScale2 = (collisionComponent as UBoxComponent).BoundsScale;
				Rotator rotator = BulletPool.CreateRotator(false);
				Rotator rotator2 = rotator;
				FRotator collisionRotator = bulletInfo.CollisionRotator;
				rotator2.FromUeRotator(collisionRotator);
				BulletStaticFunction.DebugDrawSector((double)((float)(bulletInfo.Size.Z * (double)boundsScale2)), (double)((float)(bulletInfo.Size.X * (double)boundsScale2)), (double)((float)bulletInfo.Size.Y), rotator.Quaternion(null), bulletInfo.CenterLocation, bulletInfo.ActorComponent.ActorUpProxy, null, null);
				BulletDataMain bulletDataMain2 = bulletInfo.BulletDataMain;
				if (bulletDataMain2 != null && bulletDataMain2.Base.DebugShowProgress)
				{
					float num3 = bulletInfo.LiveTime * 0.001f;
					float num4 = Singleton<MathUtils>.Instance.Lerp(0f, (float)bulletInfo.Size.Y, num3 / bulletInfo.Duration);
					Vector vector2 = BulletPool.CreateVector(false);
					vector2.FromUeVector(bulletInfo.CenterLocation);
					vector2.Z -= bulletInfo.Size.Z * (double)boundsScale2;
					BulletStaticFunction.DebugDrawSector(1.0, (double)((float)(bulletInfo.Size.X * (double)boundsScale2)), (double)num4, rotator.Quaternion(null), vector2, bulletInfo.ActorComponent.ActorUpProxy, new FLinearColor?(ColorUtils.LinearRed), new float?(bulletInfo.Duration - num3));
					BulletPool.RecycleVector(vector2);
				}
				BulletPool.RecycleRotator(rotator);
				return;
			}
			if (shape == global::EBulletShape.Cube)
			{
				float boundsScale3 = (collisionComponent as UBoxComponent).BoundsScale;
				Vector vector3 = BulletPool.CreateVector(false);
				Vector vector4 = vector3;
				FVector boxExtent = (collisionComponent as UBoxComponent).BoxExtent;
				vector4.FromUeVector(boxExtent);
				vector3.MultiplyEqual((double)boundsScale3);
				UKismetSystemLibrary.D_DrawDebugBox(GlobalData.GameInstance, collisionComponent.D_K2_GetComponentLocation(), vector3.ToUeVector(false), ColorUtils.LinearYellow, collisionComponent.K2_GetComponentRotation(), 0f, 1f);
				BulletDataMain bulletDataMain3 = bulletInfo.BulletDataMain;
				if (bulletDataMain3 != null && bulletDataMain3.Base.DebugShowProgress)
				{
					Vector vector5 = BulletPool.CreateVector(false);
					float num5 = bulletInfo.LiveTime * 0.001f;
					Vector.Lerp(Vector.ZeroVectorProxy, vector3, (double)(num5 / bulletInfo.Duration), vector5);
					vector5.Z = 4.0;
					Vector vector6 = BulletPool.CreateVector(false);
					Vector vector7 = vector6;
					FVectorDouble fvectorDouble = collisionComponent.D_K2_GetComponentLocation();
					vector7.FromUeVector(fvectorDouble);
					vector6.Z -= vector3.Z + 2.0;
					UKismetSystemLibrary.D_DrawDebugBox(GlobalData.GameInstance, vector6.ToUeVector(false), vector5.ToUeVector(false), ColorUtils.LinearRed, collisionComponent.K2_GetComponentRotation(), bulletInfo.Duration - num5, 2f);
					BulletPool.RecycleVector(vector5);
					BulletPool.RecycleVector(vector6);
				}
				BulletPool.RecycleVector(vector3);
				return;
			}
			if (shape == global::EBulletShape.Sphere)
			{
				float scaledSphereRadius = (collisionComponent as USphereComponent).GetScaledSphereRadius();
				Vector vector8 = BulletPool.CreateVector(false);
				Vector vector9 = vector8;
				FVectorDouble fvectorDouble = collisionComponent.D_K2_GetComponentLocation();
				vector9.FromUeVector(fvectorDouble);
				UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.GameInstance, vector8.ToUeVector(false), scaledSphereRadius, 12, new FLinearColor?(ColorUtils.LinearGreen), 0f, 0f);
				BulletDataMain bulletDataMain4 = bulletInfo.BulletDataMain;
				if (bulletDataMain4 != null && bulletDataMain4.Base.DebugShowProgress)
				{
					float num6 = bulletInfo.LiveTime * 0.001f;
					float num7 = Singleton<MathUtils>.Instance.Lerp(0f, scaledSphereRadius, num6 / bulletInfo.Duration);
					UObject gameInstance2 = GlobalData.GameInstance;
					FVectorDouble center2 = vector8.ToUeVector(false);
					float radius2 = num7;
					int numSegments2 = 36;
					FLinearColor? lineColor2 = new FLinearColor?(ColorUtils.LinearRed);
					float duration2 = bulletInfo.Duration - num6;
					float thickness2 = 3f;
					AActor actor3 = bulletInfo.Actor;
					FVectorDouble? yaxis2 = (actor3 != null) ? new FVectorDouble?(actor3.D_GetActorRightVector()) : null;
					AActor actor4 = bulletInfo.Actor;
					UKismetSystemLibrary.D_DrawDebugCircle(gameInstance2, center2, radius2, numSegments2, lineColor2, duration2, thickness2, yaxis2, (actor4 != null) ? new FVectorDouble?(actor4.D_GetActorForwardVector()) : null, false);
				}
				BulletPool.RecycleVector(vector8);
				return;
			}
			if (shape == global::EBulletShape.BigCube)
			{
				UKuroRegionBoxComponent ukuroRegionBoxComponent = bulletInfo.CollisionInfo.RegionComponent as UKuroRegionBoxComponent;
				Vector vector10 = BulletPool.CreateVector(false);
				Vector vector11 = vector10;
				FVector boxExtent = ukuroRegionBoxComponent.BoxExtent;
				vector11.FromUeVector(boxExtent);
				UKismetSystemLibrary.D_DrawDebugBox(GlobalData.GameInstance, ukuroRegionBoxComponent.D_K2_GetComponentLocation(), vector10.ToUeVector(false), ColorUtils.LinearYellow, ukuroRegionBoxComponent.K2_GetComponentRotation(), 0f, 1f);
				BulletDataMain bulletDataMain5 = bulletInfo.BulletDataMain;
				if (bulletDataMain5 != null && bulletDataMain5.Base.DebugShowProgress)
				{
					Vector vector12 = BulletPool.CreateVector(false);
					float num8 = bulletInfo.LiveTime * 0.001f;
					Vector.Lerp(Vector.ZeroVectorProxy, vector10, (double)(num8 / bulletInfo.Duration), vector12);
					vector12.Z = 4.0;
					Vector vector13 = BulletPool.CreateVector(false);
					Vector vector14 = vector13;
					FVectorDouble fvectorDouble = ukuroRegionBoxComponent.D_K2_GetComponentLocation();
					vector14.FromUeVector(fvectorDouble);
					vector13.Z -= vector10.Z + 2.0;
					UKismetSystemLibrary.D_DrawDebugBox(GlobalData.GameInstance, vector13.ToUeVector(false), vector12.ToUeVector(false), ColorUtils.LinearRed, ukuroRegionBoxComponent.K2_GetComponentRotation(), bulletInfo.Duration - num8, 2f);
					BulletPool.RecycleVector(vector12);
					BulletPool.RecycleVector(vector13);
				}
				BulletPool.RecycleVector(vector10);
				return;
			}
			if (shape == global::EBulletShape.BigSphere)
			{
				double x = bulletInfo.Size.X;
				FVectorDouble actorLocation = bulletInfo.ActorComponent.ActorLocation;
				UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.GameInstance, actorLocation, (float)x, 12, new FLinearColor?(ColorUtils.LinearGreen), 0f, 0f);
				BulletDataMain bulletDataMain6 = bulletInfo.BulletDataMain;
				if (bulletDataMain6 != null && bulletDataMain6.Base.DebugShowProgress)
				{
					float num9 = bulletInfo.LiveTime * 0.001f;
					float num10 = Singleton<MathUtils>.Instance.Lerp(0f, (float)x, num9 / bulletInfo.Duration);
					UObject gameInstance3 = GlobalData.GameInstance;
					FVectorDouble center3 = actorLocation;
					float radius3 = num10;
					int numSegments3 = 36;
					FLinearColor? lineColor3 = new FLinearColor?(ColorUtils.LinearRed);
					float duration3 = bulletInfo.Duration - num9;
					float thickness3 = 3f;
					AActor actor5 = bulletInfo.Actor;
					FVectorDouble? yaxis3 = (actor5 != null) ? new FVectorDouble?(actor5.D_GetActorRightVector()) : null;
					AActor actor6 = bulletInfo.Actor;
					UKismetSystemLibrary.D_DrawDebugCircle(gameInstance3, center3, radius3, numSegments3, lineColor3, duration3, thickness3, yaxis3, (actor6 != null) ? new FVectorDouble?(actor6.D_GetActorForwardVector()) : null, false);
					return;
				}
			}
			else
			{
				if (shape == global::EBulletShape.BigSector)
				{
					UKuroRegionSectorComponent ukuroRegionSectorComponent = bulletInfo.CollisionInfo.RegionComponent as UKuroRegionSectorComponent;
					Rotator rotator3 = BulletPool.CreateRotator(false);
					Rotator rotator4 = rotator3;
					FRotator collisionRotator = bulletInfo.CollisionRotator;
					rotator4.FromUeRotator(collisionRotator);
					BulletStaticFunction.DebugDrawSector((double)ukuroRegionSectorComponent.HalfHeight, (double)ukuroRegionSectorComponent.Radius, (double)ukuroRegionSectorComponent.Angle, rotator3.Quaternion(null), bulletInfo.CenterLocation, bulletInfo.ActorComponent.ActorUpProxy, null, null);
					BulletDataMain bulletDataMain7 = bulletInfo.BulletDataMain;
					if (bulletDataMain7 != null && bulletDataMain7.Base.DebugShowProgress)
					{
						float num11 = bulletInfo.LiveTime * 0.001f;
						float num12 = Singleton<MathUtils>.Instance.Lerp(0f, (float)bulletInfo.Size.Y, num11 / bulletInfo.Duration);
						Vector vector15 = BulletPool.CreateVector(false);
						vector15.FromUeVector(bulletInfo.CenterLocation);
						vector15.Z -= (double)ukuroRegionSectorComponent.HalfHeight;
						BulletStaticFunction.DebugDrawSector(1.0, (double)ukuroRegionSectorComponent.Radius, (double)num12, rotator3.Quaternion(null), vector15, bulletInfo.ActorComponent.ActorUpProxy, new FLinearColor?(ColorUtils.LinearRed), new float?(bulletInfo.Duration - num11));
						BulletPool.RecycleVector(vector15);
					}
					BulletPool.RecycleRotator(rotator3);
					return;
				}
				if (shape == global::EBulletShape.BigCylinder)
				{
					UKuroRegionCylinderComponent ukuroRegionCylinderComponent = bulletInfo.CollisionInfo.RegionComponent as UKuroRegionCylinderComponent;
					BulletStaticFunction.DebugDrawRingWithRotation((double)ukuroRegionCylinderComponent.HalfHeight, 0.0, (double)ukuroRegionCylinderComponent.Radius, bulletInfo.CenterLocation, bulletInfo.ActorComponent.ActorQuat);
				}
			}
			return;
		}
	}

	// Token: 0x06017A3C RID: 96828 RVA: 0x00696CF4 File Offset: 0x00694EF4
	public static void EntityLeave(BulletInfo bulletInfo, BulletHitActorData hitActorData)
	{
		EntityHandle entityHandle = hitActorData.EntityHandle;
		if (entityHandle == null || !entityHandle.Valid)
		{
			return;
		}
		WorldEntity entity = entityHandle.Entity;
		int[] tagIdOnVictimEnter = bulletInfo.BulletDataMain.Execution.TagIdOnVictimEnter;
		if (tagIdOnVictimEnter != null)
		{
			BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
			int num = tagIdOnVictimEnter.Length;
			if (num > 0 && component != null && component.Valid)
			{
				for (int i = 0; i < num; i++)
				{
					int value = tagIdOnVictimEnter[i];
					component.RemoveTag(new int?(value));
				}
			}
		}
		if (hitActorData.Type == EBulletHitActorType.Character)
		{
			BulletCollisionInfo collisionInfo = bulletInfo.CollisionInfo;
			int num2;
			if (!collisionInfo.CharacterEntityMap.TryGetValue(entity, out num2))
			{
				return;
			}
			CharacterActorComponent component2 = entity.GetComponent<CharacterActorComponent>();
			if (component2 != null)
			{
				BulletCollisionUtil.CharacterLeaveBulletUseBuff(bulletInfo, entity, component2.IsRoleAndCtrlByMe);
				if (num2 > 0)
				{
					PawnTimeScaleComponent component3 = entity.GetComponent<PawnTimeScaleComponent>();
					if (component3 != null)
					{
						component3.RemoveTimeScale(num2);
					}
				}
			}
			collisionInfo.CharacterEntityMap.Remove(entity);
			if (bulletInfo.CollisionInfo.IntervalMs <= 0f)
			{
				collisionInfo.ObjectsHitCurrent.Remove(entity.Id);
			}
			if (collisionInfo.CharacterEntityMap.Count == 0)
			{
				collisionInfo.HaveCharacterInBullet = false;
				return;
			}
		}
		else if (hitActorData.Type == EBulletHitActorType.Bullet)
		{
			BulletEntity bulletEntityById = ModelBase<BulletModel>.Instance.GetBulletEntityById(hitActorData.BulletEntityId);
			if (bulletEntityById == null)
			{
				return;
			}
			BulletCollisionInfo collisionInfo2 = bulletInfo.CollisionInfo;
			int num3;
			if (!collisionInfo2.BulletEntityMap.TryGetValue(bulletEntityById, out num3))
			{
				return;
			}
			if (num3 > 0)
			{
				BulletUtil.RemoveTimeScale(bulletInfo, num3);
			}
			collisionInfo2.BulletEntityMap.Remove(bulletEntityById);
		}
	}

	// Token: 0x06017A3D RID: 96829 RVA: 0x00696E70 File Offset: 0x00695070
	public static void EntityEnter(BulletInfo bulletInfo, Entity entity)
	{
		int[] tagIdOnVictimEnter = bulletInfo.BulletDataMain.Execution.TagIdOnVictimEnter;
		if (tagIdOnVictimEnter != null)
		{
			BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
			int num = tagIdOnVictimEnter.Length;
			if (num > 0 && component != null && component.Valid)
			{
				for (int i = 0; i < num; i++)
				{
					int num2 = tagIdOnVictimEnter[i];
					if (!component.HasTag(num2))
					{
						component.AddTag(new int?(num2));
					}
				}
			}
		}
	}

	// Token: 0x06017A3E RID: 96830 RVA: 0x00696ED4 File Offset: 0x006950D4
	private static void CharacterLeaveBulletUseBuff(BulletInfo bulletInfo, Entity entity, bool isRoleAndCtrlByMe)
	{
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		bool flag = ((component != null) ? new bool?(component.IsRole()) : null).GetValueOrDefault() && !isRoleAndCtrlByMe;
		BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
		if (flag || bulletDataMain.Execution.GeIdApplyToVictim == null)
		{
			return;
		}
		BaseBuffComponent component2 = entity.GetComponent<BaseBuffComponent>();
		if (component2 == null)
		{
			return;
		}
		long[] geIdApplyToVictim = bulletDataMain.Execution.GeIdApplyToVictim;
		int i = 0;
		while (i < geIdApplyToVictim.Length)
		{
			long buffId = geIdApplyToVictim[i];
			BaseBuffComponent buffApplyTarget = component2.GetBuffApplyTarget(buffId, bulletInfo.AttackerCreatureDataComp.GetCreatureDataId());
			if (buffApplyTarget == null)
			{
				goto IL_9E;
			}
			buffApplyTarget.RemoveBuffRefEntityId(buffId, entity.Id);
			if (!buffApplyTarget.HasBuffRefEntityId(buffId))
			{
				goto IL_9E;
			}
			IL_C9:
			i++;
			continue;
			IL_9E:
			component2.RemoveBuff(buffId, -1, "BulletCollisionUtil.CharacterLeaveBulletUseBuff", null, null, null);
			goto IL_C9;
		}
	}

	// Token: 0x17001F9C RID: 8092
	// (get) Token: 0x06017A3F RID: 96831 RVA: 0x00696FB8 File Offset: 0x006951B8
	private static Dictionary<FName, EHitEffectType> OnHitEffectMap
	{
		get
		{
			return BulletCollisionUtil._onHitEffectMap;
		}
	}

	// Token: 0x06017A40 RID: 96832 RVA: 0x00696FC0 File Offset: 0x006951C0
	[NullableContext(2)]
	[return: Nullable(1)]
	public static Dictionary<FName, EHitEffectType> GetHitEffects([Nullable(1)] CharacterActorComponent victimActorComp, [Nullable(1)] BulletDataRender renderConf, bool isWeakness, string boneName, bool hasDamageId, bool enablePartHitAudio, CharacterHitComponent victimHitComp = null, BaseTagComponent victimTagComp = null, Entity attackEntity = null)
	{
		BulletCollisionUtil.OnHitEffectMap.Clear();
		if (victimTagComp != null && victimTagComp.HasTag(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.不接受命中特效"]))
		{
			return BulletCollisionUtil.OnHitEffectMap;
		}
		FName? srcPath;
		if (!hasDamageId)
		{
			srcPath = new FName?(BulletCollisionUtil.GetSrcEffectOnHitPath(renderConf, isWeakness, victimTagComp, attackEntity));
			if (srcPath != null && !srcPath.Value.IsNone())
			{
				BulletCollisionUtil.OnHitEffectMap[srcPath.Value] = EHitEffectType.NeedAudio;
			}
			return BulletCollisionUtil.OnHitEffectMap;
		}
		BP_ReplaceHitEffect_C bp_ReplaceHitEffect_C = (victimHitComp != null) ? victimHitComp.GetHitEffectReplaced() : null;
		srcPath = null;
		if (victimActorComp.IsPartHit && boneName != null)
		{
			SPartHitEffect partHitConf = victimActorComp.GetPartHitConf(boneName);
			if (partHitConf != null)
			{
				bool replaceBulletHitEffect = partHitConf.ReplaceBulletHitEffect;
				srcPath = new FName?(partHitConf.Effect.GetAssetPathName());
				HashSet<string> hashSet = (victimHitComp != null) ? victimHitComp.GetHitEffectReplacedIgnoreBones() : null;
				bool isIgnore = hashSet != null && hashSet.Contains(boneName);
				srcPath = BulletCollisionUtil.ReplacePartHitEffect(srcPath, (bp_ReplaceHitEffect_C != null) ? new FName?(bp_ReplaceHitEffect_C.受击特效.GetAssetPathName()) : null, isIgnore);
				if (srcPath != null && !srcPath.Value.IsNone() && !ControllerBase<EffectAudioController>.Instance.CheckSpecialInstanceDungeonEvent(srcPath.Value.ToString()))
				{
					BulletCollisionUtil.OnHitEffectMap[srcPath.Value] = EHitEffectType.OnHitEffect;
				}
				if (enablePartHitAudio)
				{
					srcPath = new FName?(partHitConf.Audio.GetAssetPathName());
					srcPath = BulletCollisionUtil.ReplacePartHitEffect(srcPath, (bp_ReplaceHitEffect_C != null) ? new FName?(bp_ReplaceHitEffect_C.受击音效.GetAssetPathName()) : null, isIgnore);
					if (srcPath != null && !srcPath.Value.IsNone() && !ControllerBase<EffectAudioController>.Instance.CheckSpecialInstanceDungeonEvent(srcPath.Value.ToString()))
					{
						BulletCollisionUtil.OnHitEffectMap[srcPath.Value] = EHitEffectType.OnHitAudio;
					}
				}
				if (replaceBulletHitEffect)
				{
					return BulletCollisionUtil.OnHitEffectMap;
				}
			}
		}
		srcPath = new FName?(BulletCollisionUtil.GetSrcEffectOnHitPath(renderConf, isWeakness, victimTagComp, attackEntity));
		srcPath = BulletCollisionUtil.ReplaceBulletHitEffect(srcPath, new FName?((bp_ReplaceHitEffect_C != null) ? bp_ReplaceHitEffect_C.命中特效.ToAssetPathName() : null));
		if (srcPath != null && !srcPath.Value.IsNone())
		{
			BulletCollisionUtil.OnHitEffectMap[srcPath.Value] = EHitEffectType.NeedAudio;
		}
		return BulletCollisionUtil.OnHitEffectMap;
	}

	// Token: 0x06017A41 RID: 96833 RVA: 0x00697224 File Offset: 0x00695424
	[NullableContext(2)]
	private static FName GetSrcEffectOnHitPath([Nullable(1)] BulletDataRender renderConf, bool isWeakness, BaseTagComponent victimTagComp = null, Entity attackEntity = null)
	{
		FName result;
		if (renderConf.EffectOnHit.TryGetValue(EBulletHitEffect.碰撞无敌单位触发, out result) && !result.IsNone() && victimTagComp != null && victimTagComp.HasTag(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌.通用无敌"]))
		{
			return result;
		}
		FName result2;
		if (renderConf.EffectOnHit.TryGetValue(EBulletHitEffect.特殊命中特效, out result2) && !result2.IsNone() && attackEntity != null)
		{
			BaseTagComponent component = attackEntity.GetComponent<BaseTagComponent>();
			if (((component != null) ? new bool?(component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.特殊子弹命中特效"])) : null).GetValueOrDefault())
			{
				return result2;
			}
		}
		FName result3;
		if (isWeakness && renderConf.EffectOnHit.TryGetValue(EBulletHitEffect.触发弱点打击特效, out result3))
		{
			return result3;
		}
		return renderConf.EffectOnHit.GetValueOrDefault(EBulletHitEffect.碰撞单位触发, default(FName));
	}

	// Token: 0x06017A42 RID: 96834 RVA: 0x006972EC File Offset: 0x006954EC
	private static FName? ReplaceBulletHitEffect(FName? srcPath, FName? replacePath)
	{
		if (srcPath == null || srcPath.Value.IsNone())
		{
			return null;
		}
		if (replacePath != null && !replacePath.Value.IsNone())
		{
			return replacePath;
		}
		return srcPath;
	}

	// Token: 0x06017A43 RID: 96835 RVA: 0x0069733C File Offset: 0x0069553C
	private static FName? ReplacePartHitEffect(FName? srcPath, FName? replacePath, bool isIgnore)
	{
		if (!isIgnore && replacePath != null && !replacePath.Value.IsNone())
		{
			return replacePath;
		}
		if (srcPath != null && !srcPath.Value.IsNone())
		{
			return srcPath;
		}
		return null;
	}

	// Token: 0x06017A44 RID: 96836 RVA: 0x00697390 File Offset: 0x00695590
	public static void PlayHitEffect(BulletInfo bulletInfo, CharacterActorComponent victimActorComp, string boneName, bool isWeakness, Vector impactPoint, Rotator hitRotator, [Nullable(2)] CharacterHitComponent victimHitComp = null)
	{
		BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
		BulletDataRender render = bulletDataMain.Render;
		bool hasDamageId = bulletInfo.CollisionInfo.DamageId > 0L;
		BaseTagComponent component = victimActorComp.Entity.GetComponent<BaseTagComponent>();
		Dictionary<FName, EHitEffectType> hitEffects = BulletCollisionUtil.GetHitEffects(victimActorComp, render, isWeakness, boneName, hasDamageId, bulletDataMain.Base.EnablePartHitAudio, victimHitComp, component, bulletInfo.Attacker);
		if (hitEffects.Count > 0)
		{
			BulletCollisionUtil.<>c__DisplayClass18_0 CS$<>8__locals1 = new BulletCollisionUtil.<>c__DisplayClass18_0();
			BulletHitEffectConf bulletHitEffectConf;
			Vector scale;
			if (render.EffectOnHitConf.TryGetValue(global::EBulletEffectOnHitType.HitCharacter, out bulletHitEffectConf) && bulletHitEffectConf != null)
			{
				if (bulletHitEffectConf.EnableHighLimit)
				{
					BulletCollisionUtil.ClampImpactPointHigh(bulletInfo, bulletHitEffectConf.HighLimit, impactPoint);
				}
				scale = bulletHitEffectConf.Scale;
			}
			else
			{
				scale = Vector.OneVectorProxy;
			}
			BulletCollisionUtil.HitEffectTransform.Set(impactPoint, hitRotator.Quaternion(null), scale);
			Entity attacker = bulletInfo.Attacker;
			Dictionary<string, Queue<int>> dictionary;
			if (attacker == null)
			{
				dictionary = null;
			}
			else
			{
				CharacterHitComponent component2 = attacker.GetComponent<CharacterHitComponent>();
				dictionary = ((component2 != null) ? component2.HitEffectMap : null);
			}
			Dictionary<string, Queue<int>> dictionary2 = dictionary;
			Entity attacker2 = bulletInfo.Attacker;
			BaseActorComponent baseActorComponent = (attacker2 != null) ? attacker2.GetComponent<BaseActorComponent>() : null;
			Entity attacker3 = bulletInfo.Attacker;
			CharacterAudioComponent characterAudioComponent = (attacker3 != null) ? attacker3.GetComponent<CharacterAudioComponent>() : null;
			CS$<>8__locals1.fromPrimaryRole = ERoleAudioPriorityType.OtherControl;
			RoleAudioComponent roleAudioComponent = characterAudioComponent as RoleAudioComponent;
			if (roleAudioComponent != null)
			{
				CS$<>8__locals1.fromPrimaryRole = roleAudioComponent.CurrentPriority;
			}
			EffectContext effectContext = HitStaticFunction.CreateEffectContext(bulletInfo.Attacker, bulletInfo.EffectInfo.DisablePostProcess);
			CS$<>8__locals1.audioOnHit = render.AudioOnHit;
			using (Dictionary<FName, EHitEffectType>.Enumerator enumerator = hitEffects.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<FName, EHitEffectType> keyValuePair = enumerator.Current;
					string text = keyValuePair.Key.ToString();
					EHitEffectType value = keyValuePair.Value;
					string text2 = ((baseActorComponent != null) ? baseActorComponent.GetReplaceEffect(text) : null) ?? text;
					if (effectContext != null && (value == EHitEffectType.OnHitAudio || value == EHitEffectType.OnHitEffect))
					{
						effectContext.HitEffectType = value;
					}
					Queue<int> queue = null;
					if (dictionary2 != null)
					{
						dictionary2.TryGetValue(text2, out queue);
					}
					int num;
					FTransformDouble? ftransformDouble;
					if (queue != null && queue.Size >= 3)
					{
						num = queue.Pop();
						if (Singleton<EffectSystem>.Instance.IsValid(num))
						{
							EffectSystem instance = Singleton<EffectSystem>.Instance;
							int id = num;
							string reason = "ReUseHitEffect";
							ftransformDouble = new FTransformDouble?(BulletCollisionUtil.HitEffectTransform.ToUeTransform());
							instance.ReplayEffect(id, reason, ftransformDouble);
							Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.SelfCentered, num, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
							queue.Push(num);
							if (value == EHitEffectType.NeedAudio)
							{
								HitStaticFunction.PlayHitAudio(ELoadEffectResult.Success, num, CS$<>8__locals1.audioOnHit, CS$<>8__locals1.fromPrimaryRole);
								continue;
							}
							continue;
						}
					}
					EffectSystem instance2 = Singleton<EffectSystem>.Instance;
					UObject world = GlobalData.World;
					ftransformDouble = new FTransformDouble?(BulletCollisionUtil.HitEffectTransform.ToUeTransform());
					num = instance2.SpawnUnloopedEffect(world, ftransformDouble, text2, "[BulletCollisionUtil.ProcessHitEffect]", effectContext, EEffectType.Fight, null, (value == EHitEffectType.NeedAudio) ? new Action<ELoadEffectResult, int>(CS$<>8__locals1.<PlayHitEffect>g__OnEffectSpawnFinish|0) : null, null, false, false);
					Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.SelfCentered, num, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
					if (dictionary2 != null)
					{
						if (!dictionary2.TryGetValue(text2, out queue))
						{
							queue = new Queue<int>(4);
							dictionary2[text2] = queue;
						}
						queue.Push(num);
					}
				}
				return;
			}
		}
		Entity attacker4 = bulletInfo.Attacker;
		bool flag;
		if (attacker4 == null)
		{
			flag = false;
		}
		else
		{
			CharacterHitComponent component3 = attacker4.GetComponent<CharacterHitComponent>();
			flag = ((component3 != null) ? new bool?(component3.ShouldOptimize) : null).GetValueOrDefault();
		}
		if (flag)
		{
			CharacterAudioComponent component4 = bulletInfo.Attacker.GetComponent<CharacterAudioComponent>();
			ERoleAudioPriorityType fromPrimaryRole = ERoleAudioPriorityType.OtherControl;
			RoleAudioComponent roleAudioComponent2 = component4 as RoleAudioComponent;
			if (roleAudioComponent2 != null)
			{
				fromPrimaryRole = roleAudioComponent2.CurrentPriority;
			}
			HitStaticFunction.PlayHitAudioByActor(victimActorComp.Actor, render.AudioOnHit, fromPrimaryRole);
		}
	}

	// Token: 0x06017A45 RID: 96837 RVA: 0x00697718 File Offset: 0x00695918
	public static void PlayHitMesh(BulletInfo bulletInfo, Entity hitEntity, FName? hitPart, Vector impactPoint, Rotator hitRotator)
	{
		FName valueOrDefault = bulletInfo.BulletDataMain.Render.EffectOnHit.GetValueOrDefault(EBulletHitEffect.命中处插箭, default(FName));
		if (valueOrDefault.IsNone())
		{
			return;
		}
		CharacterActorComponent component = hitEntity.GetComponent<CharacterActorComponent>();
		TsBaseCharacter tsBaseCharacter = ((component != null) ? component.Owner : null) as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return;
		}
		CharRenderingComponent charRenderingComponent = tsBaseCharacter.CharRenderingComponent;
		if (charRenderingComponent == null)
		{
			return;
		}
		charRenderingComponent.AddHitMeshInfoByPath(valueOrDefault.ToString(), hitPart, impactPoint, hitRotator);
	}

	// Token: 0x06017A46 RID: 96838 RVA: 0x00697790 File Offset: 0x00695990
	private static void ClampImpactPointHigh(BulletInfo bulletInfo, Vector2D limit, Vector impactPoint)
	{
		CharacterMoveComponent attackerMoveComp = bulletInfo.AttackerMoveComp;
		if (attackerMoveComp == null || attackerMoveComp.IsStandardGravity)
		{
			double z = bulletInfo.GetActorLocation().Z;
			impactPoint.Z = Singleton<MathUtils>.Instance.Clamp(impactPoint.Z, z + limit.X, z + limit.Y);
			return;
		}
		Vector actorLocation = bulletInfo.GetActorLocation();
		Vector vector = BulletPool.CreateVector(false);
		impactPoint.Subtraction(actorLocation, vector);
		CharacterMoveComponent attackerMoveComp2 = bulletInfo.AttackerMoveComp;
		Vector vector2 = ((attackerMoveComp2 != null) ? attackerMoveComp2.GravityUp : null) ?? Vector.UpVectorProxy;
		double num = vector.DotProduct(vector2);
		if (num > limit.Y)
		{
			vector.FromUeVector(vector2);
			vector.MultiplyEqual(num - limit.Y);
			impactPoint.SubtractionEqual(vector);
		}
		if (num < limit.X)
		{
			vector.FromUeVector(vector2);
			vector.MultiplyEqual(limit.X - num);
			impactPoint.AdditionEqual(vector);
		}
		BulletPool.RecycleVector(vector);
	}

	// Token: 0x06017A47 RID: 96839 RVA: 0x00697878 File Offset: 0x00695A78
	public static void PlaySceneItemHitEffect(Entity attacker, string effect, FTransformDouble transform, string audioOnHit, bool disablePostProcess)
	{
		Dictionary<string, Queue<int>> dictionary;
		if (attacker == null)
		{
			dictionary = null;
		}
		else
		{
			CharacterHitComponent component = attacker.GetComponent<CharacterHitComponent>();
			dictionary = ((component != null) ? component.HitEffectMap : null);
		}
		Dictionary<string, Queue<int>> dictionary2 = dictionary;
		Queue<int> queue = null;
		if (dictionary2 != null)
		{
			dictionary2.TryGetValue(effect, out queue);
		}
		CharacterAudioComponent characterAudioComponent = (attacker != null) ? attacker.GetComponent<CharacterAudioComponent>() : null;
		ERoleAudioPriorityType fromPrimaryRole = ERoleAudioPriorityType.OtherControl;
		RoleAudioComponent roleAudioComponent = characterAudioComponent as RoleAudioComponent;
		if (roleAudioComponent != null)
		{
			fromPrimaryRole = roleAudioComponent.CurrentPriority;
		}
		int num;
		FTransformDouble? ftransformDouble;
		if (queue != null && queue.Size >= 3)
		{
			num = queue.Pop();
			if (Singleton<EffectSystem>.Instance.IsValid(num))
			{
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				int id = num;
				string reason = "ReUseHitEffect";
				ftransformDouble = new FTransformDouble?(transform);
				instance.ReplayEffect(id, reason, ftransformDouble);
				Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.SelfCentered, num, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
				queue.Push(num);
				HitStaticFunction.PlayHitAudio(ELoadEffectResult.Success, num, audioOnHit, fromPrimaryRole);
				return;
			}
		}
		EffectContext context = HitStaticFunction.CreateEffectContext(attacker, disablePostProcess);
		EffectSystem instance2 = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		ftransformDouble = new FTransformDouble?(transform);
		num = instance2.SpawnUnloopedEffect(world, ftransformDouble, effect, "[BulletCollisionUtil.ProcessHitEffect]", context, EEffectType.Scene, null, delegate(ELoadEffectResult result, int handle)
		{
			HitStaticFunction.PlayHitAudio(result, handle, audioOnHit, fromPrimaryRole);
		}, null, false, false);
		Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.SelfCentered, num, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		if (dictionary2 != null)
		{
			if (!dictionary2.TryGetValue(effect, out queue))
			{
				queue = new Queue<int>(4);
				dictionary2[effect] = queue;
			}
			queue.Push(num);
		}
	}

	// Token: 0x06017A48 RID: 96840 RVA: 0x006979CC File Offset: 0x00695BCC
	public static void PlayVehicleHitEffect(BulletInfo bulletInfo, Vector impactPoint, Rotator hitRotator)
	{
		BulletCollisionUtil.<>c__DisplayClass22_0 CS$<>8__locals1 = new BulletCollisionUtil.<>c__DisplayClass22_0();
		BulletDataRender render = bulletInfo.BulletDataMain.Render;
		FName srcEffectOnHitPath = BulletCollisionUtil.GetSrcEffectOnHitPath(render, false, null, bulletInfo.Attacker);
		if (srcEffectOnHitPath.IsNone())
		{
			return;
		}
		BulletHitEffectConf bulletHitEffectConf;
		Vector scale;
		if (render.EffectOnHitConf.TryGetValue(global::EBulletEffectOnHitType.HitCharacter, out bulletHitEffectConf) && bulletHitEffectConf != null)
		{
			if (bulletHitEffectConf.EnableHighLimit)
			{
				BulletCollisionUtil.ClampImpactPointHigh(bulletInfo, bulletHitEffectConf.HighLimit, impactPoint);
			}
			scale = bulletHitEffectConf.Scale;
		}
		else
		{
			scale = Vector.OneVectorProxy;
		}
		BulletCollisionUtil.HitEffectTransform.Set(impactPoint, hitRotator.Quaternion(null), scale);
		Entity attacker = bulletInfo.Attacker;
		Dictionary<string, Queue<int>> dictionary;
		if (attacker == null)
		{
			dictionary = null;
		}
		else
		{
			CharacterHitComponent component = attacker.GetComponent<CharacterHitComponent>();
			dictionary = ((component != null) ? component.HitEffectMap : null);
		}
		Dictionary<string, Queue<int>> dictionary2 = dictionary;
		Entity attacker2 = bulletInfo.Attacker;
		object obj = (attacker2 != null) ? attacker2.GetComponent<BaseActorComponent>() : null;
		Entity attacker3 = bulletInfo.Attacker;
		CharacterAudioComponent characterAudioComponent = (attacker3 != null) ? attacker3.GetComponent<CharacterAudioComponent>() : null;
		CS$<>8__locals1.fromPrimaryRole = ERoleAudioPriorityType.OtherControl;
		RoleAudioComponent roleAudioComponent = characterAudioComponent as RoleAudioComponent;
		if (roleAudioComponent != null)
		{
			CS$<>8__locals1.fromPrimaryRole = roleAudioComponent.CurrentPriority;
		}
		EffectContext context = HitStaticFunction.CreateEffectContext(bulletInfo.Attacker, bulletInfo.EffectInfo.DisablePostProcess);
		CS$<>8__locals1.audioOnHit = render.AudioOnHit;
		string text = srcEffectOnHitPath.ToString();
		object obj2 = obj;
		string text2 = ((obj2 != null) ? obj2.GetReplaceEffect(text) : null) ?? text;
		Queue<int> queue = null;
		if (dictionary2 != null)
		{
			dictionary2.TryGetValue(text2, out queue);
		}
		int num;
		FTransformDouble? ftransformDouble;
		if (queue != null && queue.Size >= 3)
		{
			num = queue.Pop();
			if (Singleton<EffectSystem>.Instance.IsValid(num))
			{
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				int id = num;
				string reason = "ReUseHitEffect";
				ftransformDouble = new FTransformDouble?(BulletCollisionUtil.HitEffectTransform.ToUeTransform());
				instance.ReplayEffect(id, reason, ftransformDouble);
				Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.SelfCentered, num, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
				queue.Push(num);
				HitStaticFunction.PlayHitAudio(ELoadEffectResult.Success, num, CS$<>8__locals1.audioOnHit, CS$<>8__locals1.fromPrimaryRole);
				return;
			}
		}
		EffectSystem instance2 = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		ftransformDouble = new FTransformDouble?(BulletCollisionUtil.HitEffectTransform.ToUeTransform());
		num = instance2.SpawnUnloopedEffect(world, ftransformDouble, text2, "[BulletCollisionUtil.ProcessHitEffect]", context, EEffectType.Scene, null, new Action<ELoadEffectResult, int>(CS$<>8__locals1.<PlayVehicleHitEffect>g__OnEffectSpawnFinish|0), null, false, false);
		Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.SelfCentered, num, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		if (dictionary2 != null)
		{
			if (!dictionary2.TryGetValue(text2, out queue))
			{
				queue = new Queue<int>(4);
				dictionary2[text2] = queue;
			}
			queue.Push(num);
		}
	}

	// Token: 0x06017A49 RID: 96841 RVA: 0x00697C18 File Offset: 0x00695E18
	public static float CalcPartDistance(UPrimitiveComponent partComp, BulletInfo bulletInfo)
	{
		Vector vector = BulletPool.CreateVector(false);
		FVectorDouble fvectorDouble = partComp.D_K2_GetComponentLocation();
		vector.FromUeVector(fvectorDouble);
		Vector vector2 = BulletPool.CreateVector(false);
		vector.Subtraction(bulletInfo.CenterLocation, vector2);
		vector2.Normalize(9.99999993922529E-09);
		double num = Vector.DistSquared(vector, bulletInfo.GetActorLocation());
		BulletPool.RecycleVector(vector);
		BulletPool.RecycleVector(vector2);
		return (float)num;
	}

	// Token: 0x06017A4A RID: 96842 RVA: 0x00697C7C File Offset: 0x00695E7C
	public unsafe static void GetImpactPointCharacter(UPrimitiveComponent partComp, BulletInfo bulletInfo, Vector outPoint)
	{
		UCapsuleComponent ucapsuleComponent = partComp as UCapsuleComponent;
		if (ucapsuleComponent != null)
		{
			Vector actorLocation = bulletInfo.GetActorLocation();
			FVectorDouble fvectorDouble = partComp.D_GetUpVector();
			outPoint.FromUeVector(fvectorDouble);
			Vector partPos = BulletCollisionUtil.PartPos;
			fvectorDouble = partComp.D_K2_GetComponentLocation();
			partPos.FromUeVector(fvectorDouble);
			actorLocation.Subtraction(BulletCollisionUtil.PartPos, BulletCollisionUtil.PartToBullet);
			double num = Vector.DotProduct(BulletCollisionUtil.PartToBullet, outPoint);
			int num2 = MathF.Sign((float)num);
			double val = Math.Abs(num);
			num = Math.Min((double)ucapsuleComponent.CapsuleHalfHeight, val) * (double)num2;
			outPoint.MultiplyEqual(num);
			outPoint.AdditionEqual(BulletCollisionUtil.PartPos);
			if (ModelBase<BulletModel>.Instance.ShowBulletCollision(bulletInfo.Attacker.Id))
			{
				UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, outPoint.ToUeVector(false), 4f, 8, new FLinearColor?(ColorUtils.LinearBlue), 2f, 3f);
			}
			actorLocation.Subtraction(outPoint, BulletCollisionUtil.ProjectToBullet);
			BulletCollisionUtil.ProjectToBullet.Normalize(9.99999993922529E-09);
			BulletCollisionUtil.ProjectToBullet.MultiplyEqual((double)ucapsuleComponent.CapsuleRadius);
			outPoint.AdditionEqual(BulletCollisionUtil.ProjectToBullet);
			if (ModelBase<BulletModel>.Instance.ShowBulletCollision(bulletInfo.Attacker.Id))
			{
				UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, outPoint.ToUeVector(false), 4f, 8, new FLinearColor?(ColorUtils.LinearYellow), 2f, 3f);
			}
			bool openHitActorLog = Singleton<BulletConstant>.Instance.OpenHitActorLog;
			return;
		}
		UBoxComponent uboxComponent = partComp as UBoxComponent;
		if (uboxComponent != null)
		{
			BulletCollisionUtil.GetHitPointBoxComp(uboxComponent, bulletInfo, outPoint, null);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Bullet;
		ELogAuthor author = ELogAuthor.HCW;
		string message = "击中了其它形状组件作为部位碰撞体";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("boneName", partComp);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("actorName", (partComp != null) ? partComp.GetOwner() : null);
		instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		outPoint.FromUeVector(bulletInfo.GetActorLocation());
	}

	// Token: 0x06017A4B RID: 96843 RVA: 0x00697E64 File Offset: 0x00696064
	public unsafe static void GetHitPointBoxComp(UBoxComponent comp, BulletInfo bulletInfo, Vector outPoint, [Nullable(2)] Vector startLocation = null)
	{
		Transform transformPart = BulletCollisionUtil.TransformPart;
		FTransformDouble ftransformDouble = comp.D_K2_GetComponentToWorld();
		transformPart.FromUeTransform(ftransformDouble);
		Vector vector = startLocation ?? bulletInfo.GetActorLocation();
		BulletCollisionUtil.TransformPart.InverseTransformPosition(vector, BulletCollisionUtil.RayStartLocal);
		BulletCollisionUtil.RayDir.FromUeVector(BulletCollisionUtil.RayStartLocal);
		BulletCollisionUtil.RayDir.MultiplyEqual(-1.0);
		FVector boxExtent = comp.BoxExtent;
		float x = boxExtent.X;
		float y = boxExtent.Y;
		float z = boxExtent.Z;
		int hitPointRayWithAabb = BulletCollisionUtil.GetHitPointRayWithAabb(BulletCollisionUtil.RayStartLocal, BulletCollisionUtil.RayDir, new float[]
		{
			-x,
			-y,
			-z
		}, new float[]
		{
			x,
			y,
			z
		}, BulletCollisionUtil.OutPosLocal);
		BulletCollisionUtil.TransformPart.TransformPosition(BulletCollisionUtil.OutPosLocal, outPoint);
		if (hitPointRayWithAabb != 1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "理论上必须有一个碰撞点才对";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Bullet", bulletInfo.BulletRowName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Part", comp);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Victim", comp.GetOwner());
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		bool openHitActorLog = Singleton<BulletConstant>.Instance.OpenHitActorLog;
		if (ModelBase<BulletModel>.Instance.ShowBulletCollision(bulletInfo.Attacker.Id))
		{
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, outPoint.ToUeVector(false), 4f, 8, new FLinearColor?(ColorUtils.LinearYellow), 2f, 3f);
			UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, vector.ToUeVector(false), BulletCollisionUtil.TransformPart.GetLocation().ToUeVector(false), ColorUtils.LinearBlue, 2f, 3f);
		}
	}

	// Token: 0x06017A4C RID: 96844 RVA: 0x00698024 File Offset: 0x00696224
	private static int GetHitPointRayWithAabb(Vector p, Vector d, float[] min, float[] max, Vector q)
	{
		float num = 0f;
		float num2 = float.MaxValue;
		for (int i = 0; i < 3; i++)
		{
			if (Math.Abs(d[i]) < 5E-324)
			{
				if (p[i] < (double)min[i] || p[i] > (double)max[i])
				{
					return 0;
				}
			}
			else
			{
				double num3 = 1.0 / d[i];
				double num4 = ((double)min[i] - p[i]) * num3;
				double num5 = ((double)max[i] - p[i]) * num3;
				if (num4 > num5)
				{
					double num6 = num4;
					num4 = num5;
					num5 = num6;
				}
				if (num4 > (double)num)
				{
					num = (float)num4;
				}
				if (num5 > (double)num2)
				{
					num2 = (float)num5;
				}
				if (num > num2)
				{
					return 0;
				}
			}
		}
		d.Multiply((double)num, q);
		q.AdditionEqual(p);
		return 1;
	}

	// Token: 0x06017A4D RID: 96845 RVA: 0x006980F4 File Offset: 0x006962F4
	public static void GetImpactPointSceneItem(UPrimitiveComponent collision, BulletInfo bulletInfo, Vector outPoint)
	{
		Vector vector = BulletPool.CreateVector(false);
		Vector vector2 = vector;
		FVectorDouble fvectorDouble = collision.D_K2_GetComponentLocation();
		vector2.FromUeVector(fvectorDouble);
		Vector vector3 = BulletPool.CreateVector(false);
		float sphereRadius = collision.D_GetComponentBounds().SphereRadius;
		if ((double)Math.Abs(bulletInfo.MoveInfo.BulletSpeed) < 1E-08)
		{
			UBoxComponent uboxComponent = collision as UBoxComponent;
			if (uboxComponent != null)
			{
				BulletCollisionUtil.GetHitPointBoxComp(uboxComponent, bulletInfo, outPoint, bulletInfo.AttackerActorComp.ActorLocationProxy);
			}
			else
			{
				bulletInfo.AttackerActorComp.ActorLocationProxy.Subtraction(vector, vector3);
				vector3.Normalize(9.99999993922529E-09);
				vector3.MultiplyEqual((double)sphereRadius);
				vector3.Addition(vector, outPoint);
			}
		}
		else
		{
			outPoint.FromUeVector(bulletInfo.CollisionInfo.LastFramePosition);
		}
		BulletPool.RecycleVector(vector);
		BulletPool.RecycleVector(vector3);
		bool openHitActorLog = Singleton<BulletConstant>.Instance.OpenHitActorLog;
		if (ModelBase<BulletModel>.Instance.ShowBulletTrace(bulletInfo.Attacker.Id))
		{
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, vector.ToUeVector(false), 4f, 8, new FLinearColor?(ColorUtils.LinearBlue), 2f, 3f);
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, outPoint.ToUeVector(false), 4f, 8, new FLinearColor?(ColorUtils.LinearYellow), 2f, 3f);
		}
	}

	// Token: 0x06017A4E RID: 96846 RVA: 0x00698234 File Offset: 0x00696434
	public static void CreateStaticDefaultValue()
	{
		BulletCollisionUtil._onHitEffectMap = new Dictionary<FName, EHitEffectType>();
	}

	// Token: 0x06017A4F RID: 96847 RVA: 0x00698240 File Offset: 0x00696440
	public static void ResetStaticDefaultValue()
	{
		BulletCollisionUtil._onHitEffectMap = null;
	}

	// Token: 0x0400B639 RID: 46649
	[StaticVariableRuleIgnore]
	private static readonly Vector CollisionLocalLocation = Vector.Create();

	// Token: 0x0400B63A RID: 46650
	[Nullable(2)]
	private static Dictionary<FName, EHitEffectType> _onHitEffectMap;

	// Token: 0x0400B63B RID: 46651
	[StaticVariableRuleIgnore]
	private static readonly Stat PlayHitEffectStat = Stat.Create("PlayHitEffect", "", "");

	// Token: 0x0400B63C RID: 46652
	[StaticVariableRuleIgnore]
	private static readonly Transform HitEffectTransform = Transform.Create();

	// Token: 0x0400B63D RID: 46653
	[StaticVariableRuleIgnore]
	private static readonly Vector PartPos = Vector.Create();

	// Token: 0x0400B63E RID: 46654
	[StaticVariableRuleIgnore]
	private static readonly Vector PartToBullet = Vector.Create();

	// Token: 0x0400B63F RID: 46655
	[StaticVariableRuleIgnore]
	private static readonly Vector ProjectToBullet = Vector.Create();

	// Token: 0x0400B640 RID: 46656
	[StaticVariableRuleIgnore]
	private static readonly Transform TransformPart = Transform.Create();

	// Token: 0x0400B641 RID: 46657
	[StaticVariableRuleIgnore]
	private static readonly Vector RayStartLocal = Vector.Create();

	// Token: 0x0400B642 RID: 46658
	[StaticVariableRuleIgnore]
	private static readonly Vector RayDir = Vector.Create();

	// Token: 0x0400B643 RID: 46659
	[StaticVariableRuleIgnore]
	private static readonly Vector OutPosLocal = Vector.Create();

	// Token: 0x0400B644 RID: 46660
	[StaticVariableRuleIgnore]
	private static readonly Stat StatGetHitPointBoxComp = Stat.Create("GetHitPointBoxComp", "", "");
}
