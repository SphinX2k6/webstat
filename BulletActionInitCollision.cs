using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Core.Common;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002D8A RID: 11658
[NullableContext(1)]
[Nullable(0)]
public class BulletActionInitCollision : BulletActionBase
{
	// Token: 0x06017813 RID: 96275 RVA: 0x0068448D File Offset: 0x0068268D
	public BulletActionInitCollision(EBulletAction type) : base(type)
	{
	}

	// Token: 0x06017814 RID: 96276 RVA: 0x00684496 File Offset: 0x00682696
	public override void Clear()
	{
		base.Clear();
		this.CollisionInfo = null;
	}

	// Token: 0x06017815 RID: 96277 RVA: 0x006844A8 File Offset: 0x006826A8
	protected unsafe override void OnExecute()
	{
		this.CollisionInfo = this.BulletInfo.CollisionInfo;
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		this.CollisionInfo.StageInterval = 1;
		this.CollisionInfo.AllowedEnergy = true;
		this.CollisionInfo.AllowedAddEnergyBuff = true;
		float num = bulletDataMain.Base.CollisionActiveDelay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		this.CollisionInfo.ActiveDelayMs = ((num > 0f) ? num : 0f);
		this.CollisionInfo.ActiveLengthMs = bulletDataMain.Base.CollisionActiveDuration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		this.CollisionInfo.IsPassDelay = (this.CollisionInfo.ActiveDelayMs <= 0f);
		this.CollisionInfo.IntervalMs = bulletDataMain.Base.Interval * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		BulletAdditionInfo additionInfo = this.BulletInfo.AdditionInfo;
		if (additionInfo != null && additionInfo.Valid)
		{
			this.CollisionInfo.IntervalMs *= additionInfo.IntervalScale;
		}
		this.CollisionInfo.IsProcessOpen = this.CollisionInfo.IsPassDelay;
		this.CollisionInfo.FinalScale.FromUeVector(bulletDataMain.Scale.SizeScale);
		this.InitPreResolvedDamageIds(bulletDataMain.Base.DamageId, bulletDataMain.Base.MultiDamageId);
		this.CollisionInfo.SetDamageIdByOriginal(bulletDataMain.Base.DamageId);
		this.CollisionInfo.BeHitEffect = bulletDataMain.Base.BeHitEffect;
		this.CollisionInfo.WeaknessBeHitEffect = bulletDataMain.Base.HitEffectWeakness;
		BulletCollisionInfo collisionInfo = this.CollisionInfo;
		bool needHitObstacles;
		if (!bulletDataMain.Logic.DestroyOnHitObstacle)
		{
			BulletChildInfo childInfo = this.BulletInfo.ChildInfo;
			if ((childInfo == null || !childInfo.HaveSpecialChildrenBullet) && !bulletDataMain.Render.EffectOnHit.ContainsKey(EBulletHitEffect.碰撞障碍物触发))
			{
				needHitObstacles = this.BulletInfo.ActionLogicComponent.ObstaclesDetect;
				goto IL_1E8;
			}
		}
		needHitObstacles = true;
		IL_1E8:
		collisionInfo.NeedHitObstacles = needHitObstacles;
		if (Singleton<Info>.Instance.IsPlayInEditor && this.CollisionInfo.NeedHitObstacles && bulletDataMain.Base.IsOversizeForTrace)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Bullet;
			Entity entity = null;
			string message = "子弹尺寸过大，不会开启射线检测, 请用子弹检测工具查看具体原因";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BulletId", this.BulletInfo.BulletRowName);
			instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.InitCollisionByShape(bulletDataMain.Base.Shape, this.BulletInfo.BaseSize);
		if (!this.BulletInfo.CloseCollision && bulletDataMain.Base.Shape != EBulletShape.Ray)
		{
			this.UpdateCollisionLocationAndExtend();
			if (this.BulletInfo.IsCollisionRelativeRotationModify)
			{
				FHitResult fhitResult = new FHitResult();
				if (this.CollisionInfo.CollisionComponent != null)
				{
					this.CollisionInfo.CollisionComponent.K2_SetRelativeRotation(bulletDataMain.Base.Rotator.ToUeRotator(), false, ref fhitResult, true);
				}
				else if (this.CollisionInfo.RegionComponent != null)
				{
					this.CollisionInfo.RegionComponent.K2_SetRelativeRotation(bulletDataMain.Base.Rotator.ToUeRotator(), false, ref fhitResult, true);
				}
			}
			this.CollisionInfo.HasObstaclesCollision = (bulletDataMain.Obstacle.Radius > 0f);
			this.EnableCollision();
		}
		else
		{
			this.BulletInfo.IsCollisionRelativeLocationZero = true;
		}
		this.CollisionInfo.LastFramePosition.FromUeVector(this.BulletInfo.GetCollisionLocation(false));
		if (Singleton<BulletConstant>.Instance.OpenMoveLog)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message2 = "BulletActionInitCollision";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Bullet";
			BulletInfo bulletInfo = this.BulletInfo;
			ptr = new ValueTuple<string, object>(item, (bulletInfo != null) ? bulletInfo.BulletRowName : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Location", this.CollisionInfo.LastFramePosition);
			instance2.Info(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		if (this.CollisionInfo.ActiveDelayMs <= 0f)
		{
			this.CollisionInfo.IsStartup = true;
		}
	}

	// Token: 0x06017816 RID: 96278 RVA: 0x00684898 File Offset: 0x00682A98
	[NullableContext(2)]
	private void InitPreResolvedDamageIds(long damageId, long[] multiDamageId)
	{
		Entity attacker = this.BulletInfo.Attacker;
		this.TryRecordPreResolvedDamageId(damageId, attacker);
		if (multiDamageId == null)
		{
			return;
		}
		foreach (long damageId2 in multiDamageId)
		{
			this.TryRecordPreResolvedDamageId(damageId2, attacker);
		}
	}

	// Token: 0x06017817 RID: 96279 RVA: 0x006848DC File Offset: 0x00682ADC
	private void TryRecordPreResolvedDamageId(long damageId, Entity attacker)
	{
		if (damageId <= 0L || !ControllerBase<ExpressionTreeController>.Instance.ShouldPreResolveDamageIdByExecutionTiming(damageId))
		{
			return;
		}
		long effectDamageId = ControllerBase<ExpressionTreeController>.Instance.GetEffectDamageId(damageId, attacker);
		this.CollisionInfo.RecordPreResolvedDamageId(damageId, effectDamageId);
	}

	// Token: 0x06017818 RID: 96280 RVA: 0x00684918 File Offset: 0x00682B18
	private void InitCollisionByShape(EBulletShape shape, Vector size)
	{
		switch (shape)
		{
		case EBulletShape.Cube:
			this.InitCollisionCube();
			return;
		case EBulletShape.Sphere:
			this.InitCollisionSphere();
			return;
		case EBulletShape.Sector:
			this.InitCollisionSector();
			return;
		case EBulletShape.Cylinder:
			this.InitCollisionCylinder();
			return;
		case EBulletShape.Ray:
			this.InitCollisionRay();
			return;
		case EBulletShape.Other:
			break;
		case EBulletShape.BigCube:
			this.InitCollisionBigShape(UKuroRegionBoxComponent.StaticClass());
			this.BulletInfo.CloseCollision = (size.X <= 0.0 || size.Y <= 0.0 || size.Z <= 0.0);
			return;
		case EBulletShape.BigSphere:
			this.BulletInfo.CloseCollision = (size.X <= 0.0);
			return;
		case EBulletShape.BigSector:
			this.InitCollisionBigShape(UKuroRegionSectorComponent.StaticClass());
			this.BulletInfo.CloseCollision = (size.X <= 0.0 || size.Z <= 0.0);
			return;
		case EBulletShape.BigCylinder:
			this.InitCollisionBigShape(UKuroRegionCylinderComponent.StaticClass());
			this.BulletInfo.CloseCollision = (size.X <= 0.0 || size.Z <= 0.0);
			break;
		default:
			return;
		}
	}

	// Token: 0x06017819 RID: 96281 RVA: 0x00684A64 File Offset: 0x00682C64
	private void InitCollisionCube()
	{
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		AActor actor = this.BulletInfo.Actor;
		Vector baseSize = this.BulletInfo.BaseSize;
		UActorComponent uactorComponent2;
		UActorComponent uactorComponent = uactorComponent2 = actor.GetComponentByClass(UBoxComponent.StaticClass());
		if (uactorComponent == null)
		{
			uactorComponent2 = actor.AddComponentByClass(UBoxComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, true, default(FName));
		}
		this.BulletInfo.CloseCollision = (baseSize.X <= 0.0 || baseSize.Y <= 0.0 || baseSize.Z <= 0.0);
		UBoxComponent uboxComponent = uactorComponent2 as UBoxComponent;
		this.CollisionInfo.CollisionComponent = uboxComponent;
		if (ModelBase<BulletModel>.Instance.ShowBulletCollision(this.BulletInfo.Attacker.Id))
		{
			uboxComponent.LineThickness = 5f;
			uboxComponent.ShapeColor = ColorUtils.ColorYellow;
		}
		uboxComponent.SetCollisionProfileName(bulletDataMain.Logic.ProfileName, true);
		this.SetCollisionIgnoreChannels(uboxComponent);
		if (uactorComponent == null)
		{
			if (GlobalData.IsPlayInEditor && Singleton<BulletConstant>.Instance.CollisionCompVisibleInEditor)
			{
				this.CollisionInfo.CollisionComponent.CreationMethod = EComponentCreationMethod.Instance;
			}
			actor.FinishAddComponent(uboxComponent, false, Singleton<MathUtils>.Instance.DefaultTransform);
		}
	}

	// Token: 0x0601781A RID: 96282 RVA: 0x00684BAC File Offset: 0x00682DAC
	private void InitCollisionSphere()
	{
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		AActor actor = this.BulletInfo.Actor;
		Vector baseSize = this.BulletInfo.BaseSize;
		UActorComponent uactorComponent2;
		UActorComponent uactorComponent = uactorComponent2 = actor.GetComponentByClass(USphereComponent.StaticClass());
		if (uactorComponent == null)
		{
			uactorComponent2 = actor.AddComponentByClass(USphereComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, true, default(FName));
		}
		this.BulletInfo.CloseCollision = (baseSize.X <= 0.0);
		USphereComponent usphereComponent = uactorComponent2 as USphereComponent;
		this.CollisionInfo.CollisionComponent = usphereComponent;
		usphereComponent.SetCollisionProfileName(bulletDataMain.Logic.ProfileName, true);
		this.SetCollisionIgnoreChannels(usphereComponent);
		if (uactorComponent == null)
		{
			if (GlobalData.IsPlayInEditor && Singleton<BulletConstant>.Instance.CollisionCompVisibleInEditor)
			{
				this.CollisionInfo.CollisionComponent.CreationMethod = EComponentCreationMethod.Instance;
			}
			actor.FinishAddComponent(usphereComponent, false, Singleton<MathUtils>.Instance.DefaultTransform);
		}
	}

	// Token: 0x0601781B RID: 96283 RVA: 0x00684C9C File Offset: 0x00682E9C
	private void InitCollisionSector()
	{
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		AActor actor = this.BulletInfo.Actor;
		Vector baseSize = this.BulletInfo.BaseSize;
		this.BulletInfo.CloseCollision = (baseSize.X <= 0.0 || baseSize.Z <= 0.0);
		UActorComponent uactorComponent2;
		UActorComponent uactorComponent = uactorComponent2 = actor.GetComponentByClass(UBoxComponent.StaticClass());
		if (uactorComponent == null)
		{
			uactorComponent2 = actor.AddComponentByClass(UBoxComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, true, default(FName));
		}
		UBoxComponent uboxComponent = uactorComponent2 as UBoxComponent;
		this.CollisionInfo.CollisionComponent = uboxComponent;
		if (ModelBase<BulletModel>.Instance.ShowBulletCollision(this.BulletInfo.Attacker.Id))
		{
			uboxComponent.LineThickness = 2f;
			uboxComponent.ShapeColor = ColorUtils.ColorYellow;
		}
		uboxComponent.SetCollisionProfileName(bulletDataMain.Logic.ProfileName, true);
		this.SetCollisionIgnoreChannels(uboxComponent);
		if (uactorComponent == null)
		{
			if (GlobalData.IsPlayInEditor && Singleton<BulletConstant>.Instance.CollisionCompVisibleInEditor)
			{
				this.CollisionInfo.CollisionComponent.CreationMethod = EComponentCreationMethod.Instance;
			}
			actor.FinishAddComponent(uboxComponent, false, Singleton<MathUtils>.Instance.DefaultTransform);
		}
	}

	// Token: 0x0601781C RID: 96284 RVA: 0x00684DD0 File Offset: 0x00682FD0
	private void InitCollisionCylinder()
	{
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		AActor actor = this.BulletInfo.Actor;
		Vector baseSize = this.BulletInfo.BaseSize;
		this.BulletInfo.CloseCollision = (baseSize.X <= 0.0 || baseSize.Z <= 0.0);
		UActorComponent uactorComponent2;
		UActorComponent uactorComponent = uactorComponent2 = actor.GetComponentByClass(UBoxComponent.StaticClass());
		if (uactorComponent == null)
		{
			uactorComponent2 = actor.AddComponentByClass(UBoxComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, true, default(FName));
		}
		UBoxComponent uboxComponent = uactorComponent2 as UBoxComponent;
		this.CollisionInfo.CollisionComponent = uboxComponent;
		if (ModelBase<BulletModel>.Instance.ShowBulletCollision(this.BulletInfo.Attacker.Id))
		{
			uboxComponent.LineThickness = 2f;
			uboxComponent.ShapeColor = ColorUtils.ColorYellow;
		}
		uboxComponent.SetCollisionProfileName(bulletDataMain.Logic.ProfileName, true);
		this.SetCollisionIgnoreChannels(uboxComponent);
		if (uactorComponent == null)
		{
			if (GlobalData.IsPlayInEditor && Singleton<BulletConstant>.Instance.CollisionCompVisibleInEditor)
			{
				this.CollisionInfo.CollisionComponent.CreationMethod = EComponentCreationMethod.Instance;
			}
			actor.FinishAddComponent(uboxComponent, false, Singleton<MathUtils>.Instance.DefaultTransform);
		}
	}

	// Token: 0x0601781D RID: 96285 RVA: 0x00684F04 File Offset: 0x00683104
	private void InitCollisionRay()
	{
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		BulletRayInfo rayInfo = this.BulletInfo.RayInfo;
		rayInfo.Speed = (double)((float)(this.BulletInfo.Size.X / (double)Singleton<TimeUtil>.Instance.InverseMillisecond));
		rayInfo.BlockByCharacter = (bulletDataMain.Base.SpecialParams.GetValueOrDefault(EBulletBaseSpecificParam.角色阻挡激光) != "f");
	}

	// Token: 0x0601781E RID: 96286 RVA: 0x00684F6C File Offset: 0x0068316C
	private void InitCollisionBigShape(UClassStackOnlyPtr regionShapeComponentClass)
	{
		AActor actor = this.BulletInfo.Actor;
		bool flag = GlobalData.IsPlayInEditor && Singleton<BulletConstant>.Instance.CollisionCompVisibleInEditor;
		UKuroRegionDetectComponent ukuroRegionDetectComponent = actor.GetComponentByClass(UKuroRegionDetectComponent.StaticClass()) as UKuroRegionDetectComponent;
		UKuroRegionDetectComponent ukuroRegionDetectComponent2;
		if ((ukuroRegionDetectComponent2 = ukuroRegionDetectComponent) == null)
		{
			ukuroRegionDetectComponent2 = (actor.AddComponentByClass(UKuroRegionDetectComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, flag, default(FName)) as UKuroRegionDetectComponent);
		}
		UKuroRegionDetectComponent ukuroRegionDetectComponent3 = ukuroRegionDetectComponent2;
		this.CollisionInfo.RegionDetectComponent = ukuroRegionDetectComponent3;
		UKuroRegionShapeComponent ukuroRegionShapeComponent = actor.GetComponentByClass(regionShapeComponentClass) as UKuroRegionShapeComponent;
		UKuroRegionShapeComponent ukuroRegionShapeComponent2;
		if ((ukuroRegionShapeComponent2 = ukuroRegionShapeComponent) == null)
		{
			ukuroRegionShapeComponent2 = (actor.AddComponentByClass(regionShapeComponentClass, false, Singleton<MathUtils>.Instance.DefaultTransform, flag, default(FName)) as UKuroRegionShapeComponent);
		}
		UKuroRegionShapeComponent ukuroRegionShapeComponent3 = ukuroRegionShapeComponent2;
		this.CollisionInfo.RegionComponent = ukuroRegionShapeComponent3;
		ukuroRegionDetectComponent3.RegionMap.Add(Singleton<BulletConstant>.Instance.RegionKey, ukuroRegionShapeComponent3);
		if (flag)
		{
			if (ukuroRegionDetectComponent == null)
			{
				ukuroRegionDetectComponent3.CreationMethod = EComponentCreationMethod.Instance;
				actor.FinishAddComponent(ukuroRegionDetectComponent3, false, Singleton<MathUtils>.Instance.DefaultTransform);
			}
			if (ukuroRegionShapeComponent == null)
			{
				ukuroRegionShapeComponent3.CreationMethod = EComponentCreationMethod.Instance;
				actor.FinishAddComponent(ukuroRegionShapeComponent3, false, Singleton<MathUtils>.Instance.DefaultTransform);
			}
		}
	}

	// Token: 0x0601781F RID: 96287 RVA: 0x00685094 File Offset: 0x00683294
	private void UpdateCollisionLocationAndExtend()
	{
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		UPrimitiveComponent collisionComponent = this.CollisionInfo.CollisionComponent;
		UKuroRegionShapeComponent regionComponent = this.CollisionInfo.RegionComponent;
		Vector centerLocalLocation = this.CollisionInfo.CenterLocalLocation;
		centerLocalLocation.FromUeVector(bulletDataMain.Base.CenterOffset);
		if (bulletDataMain.Base.Shape == EBulletShape.BigSphere)
		{
			if (!centerLocalLocation.IsZero())
			{
				Singleton<Log>.Instance.Warn(ELogModule.Bullet, ELogAuthor.CFT, "出于性能考虑，大球体的中心位置偏移不会生效", default(ReadOnlySpan<ValueTuple<string, object>>));
				centerLocalLocation.Reset();
			}
			this.BulletInfo.IsCollisionRelativeLocationZero = true;
			return;
		}
		Vector size = this.BulletInfo.Size;
		if (bulletDataMain.Base.Shape != EBulletShape.Sector)
		{
			if (!centerLocalLocation.IsZero())
			{
				FHitResult fhitResult = new FHitResult();
				if (collisionComponent != null)
				{
					collisionComponent.D_K2_SetRelativeLocation(centerLocalLocation.ToUeVector(false), false, ref fhitResult, true);
				}
				else if (regionComponent != null)
				{
					regionComponent.D_K2_SetRelativeLocation(centerLocalLocation.ToUeVector(false), false, ref fhitResult, true);
				}
			}
			else
			{
				this.BulletInfo.IsCollisionRelativeLocationZero = true;
			}
		}
		else if (size.Y >= 360.0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "扇形子弹的角度超过360！请使用柱形";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ID", this.BulletInfo.BulletRowName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			size.Y = 360.0;
		}
		else if (size.Y <= 0.0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Bullet;
			ELogAuthor author2 = ELogAuthor.CFT;
			string message2 = "扇形子弹的角度小于0！请检查";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ID", this.BulletInfo.BulletRowName);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			size.Y = 90.0;
		}
		if (collisionComponent != null)
		{
			BulletCollisionUtil.UpdateCollisionExtend(bulletDataMain.Base.Shape, collisionComponent, size, centerLocalLocation, bulletDataMain.Base.Rotator);
			return;
		}
		if (regionComponent != null)
		{
			BulletCollisionUtil.UpdateRegionExtend(bulletDataMain.Base.Shape, regionComponent, size);
		}
	}

	// Token: 0x06017820 RID: 96288 RVA: 0x0068527C File Offset: 0x0068347C
	private void EnableCollision()
	{
		this.BulletInfo.Actor.SetActorHiddenInGame(false);
		BulletCollisionInfo collisionInfo = this.CollisionInfo;
		UPrimitiveComponent uprimitiveComponent = (collisionInfo != null) ? collisionInfo.CollisionComponent : null;
		if (uprimitiveComponent == null)
		{
			return;
		}
		uprimitiveComponent.bAsyncOverlap = true;
		uprimitiveComponent.bKuroOverlapNotify = false;
		uprimitiveComponent.bReceivedAsyncOverlapResult = false;
		bool needHitObstacles = this.CollisionInfo.NeedHitObstacles;
		bool isOversizeForTrace = this.BulletInfo.BulletDataMain.Base.IsOversizeForTrace;
		bool flag;
		if (this.CollisionInfo.HasObstaclesCollision)
		{
			flag = (!isOversizeForTrace && this.BulletInfo.ActorComponent.NeedDetach && !this.BulletInfo.ActorComponent.NeedDetachForBaseMovement);
		}
		else if (needHitObstacles)
		{
			flag = !isOversizeForTrace;
		}
		else
		{
			flag = (!isOversizeForTrace && this.BulletInfo.ActorComponent.NeedDetach && !this.BulletInfo.ActorComponent.NeedDetachForBaseMovement);
		}
		if (flag)
		{
			uprimitiveComponent.SetCollisionProfileName(Singleton<BulletConstant>.Instance.ProfileNameOnlyBullet, true);
		}
		this.BulletInfo.Actor.SetActorEnableCollision(true);
		this.CheckNeedKuroFastCollision();
	}

	// Token: 0x06017821 RID: 96289 RVA: 0x00685388 File Offset: 0x00683588
	private void CheckNeedKuroFastCollision()
	{
		UKuroFastCollisionAlgorithm kuroFastCollisionAlgorithm = BulletPatternComponent.GetKuroFastCollisionAlgorithm();
		if (kuroFastCollisionAlgorithm == null)
		{
			return;
		}
		BaseTagComponent attackerTagComponent = this.BulletInfo.AttackerTagComponent;
		if (attackerTagComponent == null)
		{
			return;
		}
		bool flag = false;
		BulletDataLogic logic = this.BulletInfo.BulletDataMain.Logic;
		if (!logic.CanCounterAttack)
		{
			return;
		}
		EBulletType type = logic.Type;
		if (type == EBulletType.近战攻击子弹)
		{
			flag = attackerTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["子弹.KuroBullet.开启近战子弹交互"]);
		}
		else if (type == EBulletType.远程子弹)
		{
			flag = attackerTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["子弹.KuroBullet.开启远程子弹交互"]);
		}
		if (flag)
		{
			BulletKuroFastCollisionInfo bulletKuroFastCollisionInfo = new BulletKuroFastCollisionInfo();
			bulletKuroFastCollisionInfo.RegisterCollision(this.BulletInfo, kuroFastCollisionAlgorithm);
			this.BulletInfo.KuroFastCollisionInfo = bulletKuroFastCollisionInfo;
		}
	}

	// Token: 0x06017822 RID: 96290 RVA: 0x00685430 File Offset: 0x00683630
	protected void SetCollisionIgnoreChannels(UPrimitiveComponent primitiveComponent)
	{
		foreach (ECollisionChannel channel in this.CollisionInfo.IgnoreChannels)
		{
			primitiveComponent.SetCollisionResponseToChannel(channel, ECollisionResponse.ECR_Ignore);
		}
	}

	// Token: 0x0400B45D RID: 46173
	[Nullable(2)]
	protected BulletCollisionInfo CollisionInfo;
}
