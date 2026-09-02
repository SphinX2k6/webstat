using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x02002DC8 RID: 11720
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicReboundController : BulletLogicController<LogicDataRebound, BulletInfo>
{
	// Token: 0x06017A09 RID: 96777 RVA: 0x00694038 File Offset: 0x00692238
	[NullableContext(1)]
	public BulletLogicReboundController(LogicDataRebound logicConfig, Entity bullet) : base(logicConfig, bullet)
	{
		this.ActorComponent = bullet.GetComponent<BulletActorComponent>();
		this.BulletInfo = this.Bullet.GetBulletInfo();
	}

	// Token: 0x06017A0A RID: 96778 RVA: 0x0069405F File Offset: 0x0069225F
	public override void OnInit()
	{
		this.Bullet.GetBulletInfo().BulletDataMain.Execution.ReboundBitMask |= this.LogicController.ReboundBitMask;
	}

	// Token: 0x06017A0B RID: 96779 RVA: 0x00694090 File Offset: 0x00692290
	public override void BulletLogicAction(BulletInfo otherBulletInfo = null)
	{
		int reboundChannel = otherBulletInfo.BulletDataMain.Logic.ReboundChannel;
		if ((this.LogicController.ReboundBitMask & reboundChannel) <= 0)
		{
			return;
		}
		if (this.LogicController.EffectRebound != null)
		{
			TSoftObjectPtr<UObject> tsoftObjectPtr = this.LogicController.EffectRebound.As<UObject>();
			if (UKismetSystemLibrary.IsValidSoftObjectReference(tsoftObjectPtr))
			{
				Entity attacker = otherBulletInfo.Attacker;
				BaseActorComponent component = attacker.GetComponent<BaseActorComponent>();
				if (component != null)
				{
					CharacterHitComponent component2 = attacker.GetComponent<CharacterHitComponent>();
					if (component2 != null)
					{
						FVectorDouble location = UKismetMathLibrary.Conv_VectorToVectorDouble(this.LogicController.PositionOffset);
						FTransformDouble actorTransform = component.ActorTransform;
						FVectorDouble fvectorDouble = UKismetMathLibrary.D_TransformLocation(actorTransform, location);
						actorTransform = component.ActorTransform;
						FRotator frotator = UKismetMathLibrary.D_TransformRotation(actorTransform, this.LogicController.RotationOffset);
						FVector fvector = global::Vector.OneVectorDouble;
						FTransformDouble transform = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
						component2.OnReboundSuccess(this.LogicController.EffectRebound, transform, otherBulletInfo.EffectInfo.DisablePostProcess);
					}
				}
			}
		}
		if (this.LogicController.ScreenShake != null)
		{
			TSoftClassPtr<UObject> tsoftClassPtr = this.LogicController.ScreenShake.As<UObject>();
			if (UKismetSystemLibrary.IsValidSoftClassReference(tsoftClassPtr) && CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(this.BulletInfo.AttackerHandle))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(this.LogicController.ScreenShake.ToAssetPathName(), delegate([Nullable(2)] UClass shakeType, string path)
				{
					FVectorDouble value = Global.CharacterCameraManager.D_GetCameraLocation();
					ControllerBase<CameraController>.Instance.PlayWorldCameraShake(shakeType, new FVectorDouble?(value), 0f, 100f, 1f, false, "MainCamera");
				}, 100, "js_undefined");
			}
		}
		if (this.LogicController.CameraModified != null)
		{
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.GetComponent<FightCameraLogicComponent>().ApplyCameraModify(null, this.LogicController.CameraModified.持续时间, this.LogicController.CameraModified.淡入时间, this.LogicController.CameraModified.淡出时间, this.LogicController.CameraModified.摄像机配置, null, 0.2f, null, null, default(OneOf<TsBaseCharacter, TsBaseVehicle>), "", default(OneOf<TsBaseCharacter, TsBaseVehicle>));
		}
		int num = this.LogicController.BulletRowName.Num();
		long? contextId = this.BulletInfo.ContextId;
		for (int i = 0; i < num; i++)
		{
			string bulletRowName = this.LogicController.BulletRowName.Get(i);
			HashSet<string> parentIds = BulletUtil.CollectParentsId(this.BulletInfo);
			BulletEntity bulletEntity = ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(this.BulletInfo.Attacker, bulletRowName, new FTransformDouble?(this.ActorComponent.ActorTransform), new BulletController.BulletCreateParams
			{
				SyncType = EBulletSyncType.SyncCreate,
				ParentId = this.Bullet.Id,
				SkillId = this.BulletInfo.BulletInitParams.SkillId,
				SkillContextId = this.BulletInfo.BulletInitParams.SkillContextId,
				Source = Aki.Protocol.EBulletCreateSource.ReboundSource,
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
	}

	// Token: 0x0400B605 RID: 46597
	private const float OUTER_RADIUS = 100f;

	// Token: 0x0400B606 RID: 46598
	private readonly BulletActorComponent ActorComponent;

	// Token: 0x0400B607 RID: 46599
	private readonly BulletInfo BulletInfo;
}
