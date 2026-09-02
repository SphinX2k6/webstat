using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x02002DBB RID: 11707
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicBulletCollisionController : BulletLogicController<LogicDataBulletCollision, BulletInfo>
{
	// Token: 0x060179CC RID: 96716 RVA: 0x00691D6D File Offset: 0x0068FF6D
	[NullableContext(1)]
	public BulletLogicBulletCollisionController(LogicDataBulletCollision logicConfig, Entity bullet) : base(logicConfig, bullet)
	{
		this.ActorComponent = bullet.GetComponent<BulletActorComponent>();
		this.BulletInfo = this.Bullet.GetBulletInfo();
	}

	// Token: 0x060179CD RID: 96717 RVA: 0x00691D94 File Offset: 0x0068FF94
	public override void BulletLogicAction(BulletInfo otherBulletInfo = null)
	{
		if (this.BulletInfo.AttackerId != otherBulletInfo.AttackerId)
		{
			return;
		}
		TArray<string> triggerBulletIds = this.LogicController.TriggerBulletIds;
		if (triggerBulletIds != null && triggerBulletIds.Num() > 0)
		{
			string bulletRowName = otherBulletInfo.BulletRowName;
			bool flag = false;
			for (int i = 0; i < triggerBulletIds.Num(); i++)
			{
				if (triggerBulletIds.Get(i) == bulletRowName)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
		}
		global::Vector actorLocationProxy = this.ActorComponent.ActorLocationProxy;
		global::Vector actorLocationProxy2 = otherBulletInfo.Entity.GetComponent<BulletActorComponent>().ActorLocationProxy;
		global::Vector vector = BulletPool.CreateVector(false);
		actorLocationProxy.Addition(actorLocationProxy2, vector);
		vector.MultiplyEqual(0.5);
		EBulletCollisionDestroyType destroyType = (EBulletCollisionDestroyType)this.LogicController.DestroyType;
		if (destroyType == EBulletCollisionDestroyType.DestroySelf || destroyType == EBulletCollisionDestroyType.DestroyBoth)
		{
			ControllerBase<BulletController>.Instance.DestroyBullet(this.BulletInfo.BulletEntityId, false, EBulletDestroyReason.Normal, false);
		}
		if (destroyType == EBulletCollisionDestroyType.DestroyOther || destroyType == EBulletCollisionDestroyType.DestroyBoth)
		{
			ControllerBase<BulletController>.Instance.DestroyBullet(otherBulletInfo.BulletEntityId, false, EBulletDestroyReason.Normal, false);
		}
		FVector b;
		FVectorDouble fvectorDouble;
		if (this.LogicController.EffectCollision != null)
		{
			TSoftObjectPtr<UObject> tsoftObjectPtr = this.LogicController.EffectCollision.As<UObject>();
			if (UKismetSystemLibrary.IsValidSoftObjectReference(tsoftObjectPtr))
			{
				global::Vector vector2 = BulletPool.CreateVector(false);
				FVector positionOffset = this.LogicController.PositionOffset;
				b = default(FVector);
				if (positionOffset != b)
				{
					vector2.Set(vector.X + (double)this.LogicController.PositionOffset.X, vector.Y + (double)this.LogicController.PositionOffset.Y, vector.Z + (double)this.LogicController.PositionOffset.Z);
				}
				else
				{
					vector2.Set(vector.X, vector.Y, vector.Z);
				}
				FRotator rotationOffset = this.LogicController.RotationOffset;
				fvectorDouble = vector2.ToUeVector(false);
				b = global::Vector.OneVectorDouble;
				FTransformDouble transform = new FTransformDouble(ref rotationOffset, ref fvectorDouble, ref b);
				BulletStaticFunction.PlayBulletEffect(this.BulletInfo.Actor, this.LogicController.EffectCollision.ToAssetPathName(), transform, this.BulletInfo, "BulletCollision");
				BulletPool.RecycleVector(vector2);
			}
		}
		if (this.LogicController.ScreenShake != null)
		{
			TSoftClassPtr<UObject> tsoftClassPtr = this.LogicController.ScreenShake.As<UObject>();
			if (UKismetSystemLibrary.IsValidSoftClassReference(tsoftClassPtr) && CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(this.BulletInfo.AttackerHandle))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(this.LogicController.ScreenShake.ToAssetPathName(), delegate([Nullable(2)] UClass shakeType, string path)
				{
					FVectorDouble value2 = Global.CharacterCameraManager.D_GetCameraLocation();
					ControllerBase<CameraController>.Instance.PlayWorldCameraShake(shakeType, new FVectorDouble?(value2), 0f, 100f, 1f, false, "MainCamera");
				}, 100, "js_undefined");
			}
		}
		if (this.LogicController.CameraModified != null)
		{
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.GetComponent<FightCameraLogicComponent>().ApplyCameraModify(null, this.LogicController.CameraModified.持续时间, this.LogicController.CameraModified.淡入时间, this.LogicController.CameraModified.淡出时间, this.LogicController.CameraModified.摄像机配置, null, 0.2f, null, null, default(OneOf<TsBaseCharacter, TsBaseVehicle>), "", default(OneOf<TsBaseCharacter, TsBaseVehicle>));
		}
		TArray<string> bulletRowName2 = this.LogicController.BulletRowName;
		int num = (bulletRowName2 != null) ? bulletRowName2.Num() : 0;
		long? contextId = this.BulletInfo.ContextId;
		FRotator rotationOffset2 = this.LogicController.RotationOffset;
		fvectorDouble = vector.ToUeVector(false);
		b = global::Vector.OneVectorDouble;
		FTransformDouble value = new FTransformDouble(ref rotationOffset2, ref fvectorDouble, ref b);
		for (int j = 0; j < num; j++)
		{
			string bulletRowName3 = this.LogicController.BulletRowName.Get(j);
			HashSet<string> parentIds = BulletUtil.CollectParentsId(this.BulletInfo);
			BulletEntity bulletEntity = ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(this.BulletInfo.Attacker, bulletRowName3, new FTransformDouble?(value), new BulletController.BulletCreateParams
			{
				SyncType = EBulletSyncType.SyncCreate,
				ParentId = this.Bullet.Id,
				SkillId = this.BulletInfo.BulletInitParams.SkillId,
				SkillContextId = this.BulletInfo.BulletInitParams.SkillContextId,
				Source = Aki.Protocol.EBulletCreateSource.CollisionSpawnSource,
				BattleContext = this.BulletInfo.BulletInitParams.BattleContext,
				ParentIds = parentIds
			}, contextId, global::EBulletCreateSource.Others);
			if (bulletEntity != null && bulletEntity.Valid)
			{
				BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
				if (bulletInfo.BulletDataMain.Render.HandOverParentEffect)
				{
					BulletStaticFunction.HandOverEffects(this.BulletInfo, bulletInfo);
				}
			}
		}
		BulletPool.RecycleVector(vector);
	}

	// Token: 0x0400B5D7 RID: 46551
	private const float OUTER_RADIUS = 100f;

	// Token: 0x0400B5D8 RID: 46552
	private readonly BulletActorComponent ActorComponent;

	// Token: 0x0400B5D9 RID: 46553
	private readonly BulletInfo BulletInfo;
}
