using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002D8C RID: 11660
[NullableContext(1)]
[Nullable(0)]
public class BulletActionInitMove : BulletActionBase
{
	// Token: 0x06017828 RID: 96296 RVA: 0x0068575D File Offset: 0x0068395D
	public BulletActionInitMove(EBulletAction type) : base(type)
	{
	}

	// Token: 0x17001F01 RID: 7937
	// (get) Token: 0x06017829 RID: 96297 RVA: 0x00685766 File Offset: 0x00683966
	[Nullable(2)]
	private USkeletalMeshComponent AttackerMeshComp
	{
		[NullableContext(2)]
		get
		{
			if (!this.AttackerMeshCompInit)
			{
				this.AttackerMeshCompInit = true;
				this.AttackerMeshCompInternal = this.FindSkeletalMeshComponent(this.AttackerActorComp, this.Data.Move.SkeletonComponentName);
			}
			return this.AttackerMeshCompInternal;
		}
	}

	// Token: 0x17001F02 RID: 7938
	// (get) Token: 0x0601782A RID: 96298 RVA: 0x0068579F File Offset: 0x0068399F
	// (set) Token: 0x0601782B RID: 96299 RVA: 0x006857C0 File Offset: 0x006839C0
	[Nullable(2)]
	private BaseActorComponent AttackerActorComp
	{
		[NullableContext(2)]
		get
		{
			if (this.AttackerActorCompInternal == null)
			{
				this.AttackerActorCompInternal = this.BulletInfo.AttackerActorComp;
			}
			return this.AttackerActorCompInternal;
		}
		[NullableContext(2)]
		set
		{
			if (this.AttackerActorCompInternal == value)
			{
				return;
			}
			this.AttackerActorCompInternal = value;
			this.AttackerMeshCompInit = false;
			this.AttackerMeshCompInternal = null;
		}
	}

	// Token: 0x0601782C RID: 96300 RVA: 0x006857E1 File Offset: 0x006839E1
	public override void Clear()
	{
		base.Clear();
		this.Data = null;
		this.AttackerMeshCompInit = false;
		this.AttackerMeshCompInternal = null;
		this.AttackerActorCompInternal = null;
		this.BaseLocationOutLimit = false;
	}

	// Token: 0x0601782D RID: 96301 RVA: 0x0068580C File Offset: 0x00683A0C
	protected override void OnExecute()
	{
		BulletInitParams bulletInitParams = this.BulletInfo.BulletInitParams;
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		this.Data = bulletDataMain;
		BulletDataMove move = bulletDataMain.Move;
		BulletDataObstacle obstacle = bulletDataMain.Obstacle;
		BulletMoveInfo moveInfo = this.BulletInfo.MoveInfo;
		moveInfo.BulletSpeedRatio = 1f;
		BaseSkillComponent attackerSkillComp = this.BulletInfo.AttackerSkillComp;
		BaseActorComponent targetActorComp = this.BulletInfo.TargetActorComp;
		if (targetActorComp != null && targetActorComp.Valid && attackerSkillComp != null && attackerSkillComp.Valid && (this.BulletInfo.BulletInitParams.CreateSource == EBulletCreateSource.Skill || attackerSkillComp.CurrentSkill != null) && attackerSkillComp.SkillTargetSocket != "")
		{
			this.BulletInfo.SkillBoneName = FNameUtil.GetDynamicFName(attackerSkillComp.SkillTargetSocket);
		}
		moveInfo.BulletSpeed = move.Speed;
		moveInfo.ObstaclesOffset.FromUeVector(obstacle.Center);
		this.OnStartBaseLocation();
		this.OnStartSpeedRotator();
		BulletDataBase @base = bulletDataMain.Base;
		BulletDataAimed aimed = bulletDataMain.Aimed;
		if (!@base.StickGround && aimed.AimedCtrlDir)
		{
			if (bulletInitParams.FromRemote)
			{
				Rotator beginSpeedRotator = moveInfo.BeginSpeedRotator;
				FRotator frotator = bulletInitParams.InitialTransform.Value.Rotator();
				beginSpeedRotator.FromUeRotator(frotator);
			}
			else
			{
				this.BulletAimedToward(moveInfo.BeginSpeedRotator);
			}
			this.BulletInfo.SetActorRotation(moveInfo.BeginSpeedRotator);
		}
		CharacterMoveComponent attackerMoveComp = this.BulletInfo.AttackerMoveComp;
		bool flag = attackerMoveComp == null || attackerMoveComp.IsStandardGravity;
		if (flag)
		{
			this.OnStartStickGroundStandard();
		}
		else
		{
			this.OnStartStickGround();
		}
		this.OnStartAround();
		if (flag)
		{
			this.OnStartParabolaStandard();
		}
		else
		{
			this.OnStartParabola();
		}
		this.OnStartMovingPlatform();
		if (move.TrackParams.Length != 0)
		{
			Vector vector = move.TrackParams[0];
			moveInfo.MinFollowHeight = vector.Y;
			moveInfo.SpeedFollowTarget = vector.X;
			if (vector.Z > 0.0)
			{
				moveInfo.FollowTargetBottom = false;
			}
		}
		moveInfo.LastFramePosition.FromUeVector(this.BulletInfo.GetActorLocation());
		moveInfo.FollowBoneBulletRotator.FromUeRotator(this.BulletInfo.GetActorRotation());
		this.BulletInfo.ApplyCacheLocationAndRotation();
	}

	// Token: 0x0601782E RID: 96302 RVA: 0x00685A34 File Offset: 0x00683C34
	[return: Nullable(2)]
	private USkeletalMeshComponent FindSkeletalMeshComponent(BaseActorComponent characterActor, string nameComponent)
	{
		if (nameComponent != "None")
		{
			AActor owner = characterActor.Owner;
			TArray<UActorComponent> tarray = (owner != null) ? owner.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass()) : null;
			int num = (tarray != null) ? tarray.Num() : 0;
			for (int i = 0; i < num; i++)
			{
				UActorComponent uactorComponent = tarray.Get(i);
				if (uactorComponent != null && uactorComponent.IsValid() && uactorComponent.GetName() == nameComponent)
				{
					return uactorComponent as USkeletalMeshComponent;
				}
			}
		}
		return characterActor.SkeletalMesh;
	}

	// Token: 0x0601782F RID: 96303 RVA: 0x00685AB4 File Offset: 0x00683CB4
	private void OnStartAttachToBone(BaseActorComponent target)
	{
		BulletDataMove move = this.Data.Move;
		if (move.FollowType == EBulletFollowType.跟随骨骼)
		{
			BulletInfo bulletInfo = this.BulletInfo;
			USkeletalMeshComponent parent = this.FindSkeletalMeshComponent((target != null && target.Valid) ? target : bulletInfo.AttackerActorComp, move.SkeletonComponentName);
			if (move.IsLockScale)
			{
				bulletInfo.Actor.RootComponent.SetAbsolute(false, false, true);
			}
			bulletInfo.ApplyCacheLocationAndRotation();
			bulletInfo.ActorComponent.SetAttachToComponent(parent, move.BoneName, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, true);
			bulletInfo.InitPosition.FromUeVector(bulletInfo.ActorComponent.ActorLocationProxy);
			return;
		}
		if (move.FollowType == EBulletFollowType.跟随骨骼位置旋转)
		{
			BulletInfo bulletInfo2 = this.BulletInfo;
			USkeletalMeshComponent parent2 = this.FindSkeletalMeshComponent((target != null && target.Valid) ? target : bulletInfo2.AttackerActorComp, move.SkeletonComponentName);
			if (move.IsLockScale)
			{
				bulletInfo2.Actor.RootComponent.SetAbsolute(false, false, true);
			}
			bulletInfo2.ApplyCacheLocationAndRotation();
			bulletInfo2.ActorComponent.SetAttachToComponent(parent2, move.BoneName, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, true);
			FHitResult fhitResult = new FHitResult();
			bulletInfo2.Actor.D_K2_SetActorRelativeLocation(bulletInfo2.BornLocationOffset.ToUeVector(false), false, ref fhitResult, false);
			FHitResult fhitResult2 = new FHitResult();
			bulletInfo2.Actor.K2_SetActorRelativeRotation(Rotator.ZeroRotator, false, ref fhitResult2, true);
			bulletInfo2.InitPosition.FromUeVector(bulletInfo2.ActorComponent.ActorLocationProxy);
		}
	}

	// Token: 0x06017830 RID: 96304 RVA: 0x00685C0C File Offset: 0x00683E0C
	private void OnStartBaseLocation()
	{
		BulletInfo bulletInfo = this.BulletInfo;
		switch (this.Data.Base.BornPositionStandard)
		{
		case EPositionStandard.发射者位置:
			this.OnStartBaseLocationOwner(bulletInfo.AttackerActorComp);
			break;
		case EPositionStandard.技能目标位置:
		{
			EntityHandle baseTransformEntity = bulletInfo.BaseTransformEntity;
			BaseActorComponent actorComp;
			if (baseTransformEntity == null)
			{
				actorComp = null;
			}
			else
			{
				WorldEntity entity = baseTransformEntity.Entity;
				actorComp = ((entity != null) ? entity.GetComponent<BaseActorComponent>() : null);
			}
			this.OnStartBaseLocationSkillTarget(actorComp, false);
			break;
		}
		case EPositionStandard.世界位置:
			this.OnStartStandardLocation(Singleton<MathUtils>.Instance.DefaultTransformProxy);
			break;
		case EPositionStandard.父子弹或外部位置:
			this.OnStartBaseLocationParent(bulletInfo);
			break;
		case EPositionStandard.攻击者锁定目标位置:
		case EPositionStandard.自定义目标:
		case EPositionStandard.父子弹受击者:
		case EPositionStandard.父子弹目标:
		case EPositionStandard.前台角色锁定目标:
		case EPositionStandard.伴生物:
			this.OnStartBaseLocationByEntity(bulletInfo.BaseTransformEntity, false);
			break;
		case EPositionStandard.队伍角色:
			this.OnStartBaseLocationCurrentRole();
			break;
		case EPositionStandard.伴生物位置和朝向:
			this.OnStartBaseLocationByEntity(bulletInfo.BaseTransformEntity, true);
			break;
		case EPositionStandard.技能目标位置和朝向:
		{
			EntityHandle baseTransformEntity2 = bulletInfo.BaseTransformEntity;
			BaseActorComponent actorComp2;
			if (baseTransformEntity2 == null)
			{
				actorComp2 = null;
			}
			else
			{
				WorldEntity entity2 = baseTransformEntity2.Entity;
				actorComp2 = ((entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null);
			}
			this.OnStartBaseLocationSkillTarget(actorComp2, true);
			break;
		}
		}
		if (Singleton<BulletConstant>.Instance.OpenMoveLog)
		{
			bool gasDebug = false;
			ELogAuthor author = ELogAuthor.HCW;
			Entity owner = null;
			string message = "BulletActionInitMove OnStartBaseLocation";
			BulletInfo bulletInfo2 = this.BulletInfo;
			string item = "Location";
			BulletInfo bulletInfo3 = this.BulletInfo;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (bulletInfo3 != null) ? bulletInfo3.GetActorLocation() : null);
			BulletLog.Info(gasDebug, author, owner, message, bulletInfo2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x06017831 RID: 96305 RVA: 0x00685D53 File Offset: 0x00683F53
	private void OnStartBaseLocationOwner(BaseActorComponent attackerActorComp)
	{
		this.OnStartStandardLocation(null);
		this.OnStartAttachToBone(attackerActorComp);
	}

	// Token: 0x06017832 RID: 96306 RVA: 0x00685D64 File Offset: 0x00683F64
	[NullableContext(2)]
	private void OnStartBaseLocationSkillTarget(BaseActorComponent actorComp, bool baseOnTargetActor)
	{
		Transform tempTransform = BulletMoveInfo.TempTransform1;
		this.InitPositionTarget(actorComp, tempTransform, false, baseOnTargetActor);
		this.OnStartStandardLocation(tempTransform);
		if (((actorComp != null) ? actorComp.Owner : null) is ABaseCharacter)
		{
			this.OnStartAttachToBone(actorComp);
		}
	}

	// Token: 0x06017833 RID: 96307 RVA: 0x00685DA4 File Offset: 0x00683FA4
	[NullableContext(2)]
	private void OnStartBaseLocationByEntity(EntityHandle baseTransformEntity, bool baseOnTarget = false)
	{
		Transform tempTransform = BulletMoveInfo.TempTransform1;
		BaseActorComponent baseActorComponent;
		if (baseTransformEntity == null)
		{
			baseActorComponent = null;
		}
		else
		{
			WorldEntity entity = baseTransformEntity.Entity;
			baseActorComponent = ((entity != null) ? entity.GetComponent<BaseActorComponent>() : null);
		}
		BaseActorComponent baseActorComponent2 = baseActorComponent;
		if (((baseActorComponent2 != null) ? baseActorComponent2.Owner : null) is ABaseCharacter)
		{
			this.InitPositionTarget(baseActorComponent2, tempTransform, baseOnTarget, false);
			this.AttackerActorComp = baseActorComponent2;
			if (baseOnTarget)
			{
				this.OnStartStandardLocationBaseOnTarget(tempTransform);
			}
			else
			{
				this.OnStartStandardLocation(tempTransform);
			}
			this.OnStartAttachToBone(baseActorComponent2);
			return;
		}
		this.InitPositionTarget(baseActorComponent2, tempTransform, false, false);
		this.OnStartStandardLocation(tempTransform);
	}

	// Token: 0x06017834 RID: 96308 RVA: 0x00685E20 File Offset: 0x00684020
	private void OnStartBaseLocationParent(BulletInfo bulletInfo)
	{
		if (this.Data.Move.FollowType == EBulletFollowType.跟随父子弹特效骨骼)
		{
			this.OnAttachParentEffectSkeleton(bulletInfo);
			return;
		}
		Transform tempTransform = BulletMoveInfo.TempTransform1;
		BulletInitParams bulletInitParams = bulletInfo.BulletInitParams;
		BulletDataBase @base = this.Data.Base;
		Vector vector = BulletPool.CreateVector(false);
		Transform transform = tempTransform;
		FTransformDouble value = bulletInitParams.InitialTransform.Value;
		transform.FromUeTransform(value);
		vector.FromUeVector(tempTransform.GetLocation());
		if (vector.Equals(Vector.ZeroVectorProxy, 9.999999747378752E-05))
		{
			this.OnStartStandardLocation(tempTransform);
		}
		else
		{
			if (!bulletInfo.BulletInitParams.FromRemote)
			{
				Vector bornPositionRandom = @base.BornPositionRandom;
				Vector vector2 = BulletPool.CreateVector(true);
				if (!bornPositionRandom.Equals(Vector.ZeroVectorProxy, 9.999999747378752E-05))
				{
					vector2.X = (double)this.GetRandom((float)bornPositionRandom.X);
					vector2.Y = (double)this.GetRandom((float)bornPositionRandom.Y);
					vector2.Z = (double)this.GetRandom((float)bornPositionRandom.Z);
				}
				if (!bulletInfo.BornLocationOffset.Equals(Vector.ZeroVectorProxy, 9.999999747378752E-05))
				{
					vector2.AdditionEqual(bulletInfo.BornLocationOffset);
				}
				if (!vector2.Equals(Vector.ZeroVectorProxy, 9.999999747378752E-05))
				{
					tempTransform.TransformPosition(vector2, vector);
				}
				BulletPool.RecycleVector(vector2);
			}
			bulletInfo.SetActorLocation(vector);
			bulletInfo.InitPosition.FromUeVector(vector);
		}
		BulletPool.RecycleVector(vector);
	}

	// Token: 0x06017835 RID: 96309 RVA: 0x00685F90 File Offset: 0x00684190
	private unsafe void OnAttachParentEffectSkeleton(BulletInfo bulletInfo)
	{
		BulletEntity bulletEntityById = ModelBase<BulletModel>.Instance.GetBulletEntityById(bulletInfo.ParentEntityId);
		if (bulletEntityById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Temp;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "子弹为跟随父子弹特效骨骼，但是找不到父子弹";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", bulletInfo.BulletEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BulletRowName", bulletInfo.BulletRowName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ParentEntityId", bulletInfo.ParentEntityId);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.OnStartStandardLocation(null);
			return;
		}
		BulletInfo bulletInfo2 = bulletEntityById.GetBulletInfo();
		bulletInfo.ParentEffect = bulletInfo2.EffectInfo.Effect;
		AActor sureEffectActor = Singleton<EffectSystem>.Instance.GetSureEffectActor(bulletInfo.ParentEffect);
		if (sureEffectActor != null)
		{
			if (BulletUtil.AttachParentEffectSkeleton(bulletInfo, sureEffectActor, bulletInfo.ParentEffect))
			{
				bulletInfo.InitPosition.FromUeVector(bulletInfo.ActorComponent.ActorLocationProxy);
				return;
			}
		}
		else
		{
			Vector lastFramePosition = bulletInfo2.MoveInfo.LastFramePosition;
			bulletInfo.SetActorLocation(lastFramePosition);
			bulletInfo.InitPosition.FromUeVector(lastFramePosition);
			ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo, EBulletAction.Child);
		}
	}

	// Token: 0x06017836 RID: 96310 RVA: 0x006860C0 File Offset: 0x006842C0
	private void OnStartBaseLocationCurrentRole()
	{
		CharacterActorComponent currentRole = BulletUtil.GetCurrentRole(this.BulletInfo);
		Transform tempTransform = BulletMoveInfo.TempTransform1;
		Transform transform = tempTransform;
		FTransformDouble actorTransform = currentRole.ActorTransform;
		transform.FromUeTransform(actorTransform);
		this.AttackerActorComp = currentRole;
		this.OnStartStandardLocation(tempTransform);
		this.OnStartAttachToBone(currentRole);
	}

	// Token: 0x06017837 RID: 96311 RVA: 0x00686104 File Offset: 0x00684304
	private void OnStartStandardLocationBaseOnTarget(Transform standardTransform)
	{
		BulletInfo bulletInfo = this.BulletInfo;
		BulletDataBase @base = this.Data.Base;
		Vector vector = BulletPool.CreateVector(false);
		Vector bornPositionRandom = @base.BornPositionRandom;
		if (bornPositionRandom.Equality(Vector.ZeroVectorProxy))
		{
			vector.FromUeVector(bulletInfo.BornLocationOffset);
		}
		else
		{
			if (bulletInfo.BulletInitParams.FromRemote)
			{
				vector.FromUeVector(bulletInfo.RandomPosOffset);
			}
			else
			{
				vector.X = (double)this.GetRandom((float)bornPositionRandom.X);
				vector.Y = (double)this.GetRandom((float)bornPositionRandom.Y);
				vector.Z = (double)this.GetRandom((float)bornPositionRandom.Z);
				bulletInfo.RandomPosOffset.FromUeVector(vector);
			}
			vector.AdditionEqual(bulletInfo.BornLocationOffset);
		}
		Vector vector2 = BulletPool.CreateVector(false);
		standardTransform.TransformPosition(vector, vector2);
		bulletInfo.SetActorLocation(vector2);
		bulletInfo.InitPosition.FromUeVector(vector2);
		BulletPool.RecycleVector(vector);
		BulletPool.RecycleVector(vector2);
	}

	// Token: 0x06017838 RID: 96312 RVA: 0x006861EC File Offset: 0x006843EC
	[NullableContext(2)]
	private void OnStartStandardLocation(Transform standardTransform)
	{
		BulletInfo bulletInfo = this.BulletInfo;
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		BulletDataBase @base = this.Data.Base;
		BulletDataMove move = this.Data.Move;
		Vector bornPositionRandom = @base.BornPositionRandom;
		BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
		Vector vector = BulletPool.CreateVector(false);
		if (bornPositionRandom.Equality(Vector.ZeroVectorProxy))
		{
			vector.FromUeVector(bulletInfo.BornLocationOffset);
		}
		else
		{
			if (bulletInfo.BulletInitParams.FromRemote)
			{
				vector.FromUeVector(bulletInfo.RandomPosOffset);
			}
			else
			{
				vector.X = (double)this.GetRandom((float)bornPositionRandom.X);
				vector.Y = (double)this.GetRandom((float)bornPositionRandom.Y);
				vector.Z = (double)this.GetRandom((float)bornPositionRandom.Z);
				bulletInfo.RandomPosOffset.FromUeVector(vector);
			}
			vector.AdditionEqual(bulletInfo.BornLocationOffset);
		}
		Vector vector2 = BulletPool.CreateVector(false);
		Vector vector3 = BulletPool.CreateVector(false);
		if (FNameUtil.IsNothing(move.BoneName) || this.AttackerMeshComp == null)
		{
			if (@base.BornPositionStandard == EPositionStandard.发射者位置)
			{
				vector.Z -= (double)attackerActorComp.ScaledHalfHeight;
			}
			if (standardTransform == null)
			{
				Transform tempTransform = BulletMoveInfo.TempTransform1;
				tempTransform.SetRotation(attackerActorComp.ActorQuatProxy);
				tempTransform.SetLocation(attackerActorComp.ActorLocationProxy);
				tempTransform.SetScale3D(attackerActorComp.ActorScaleProxy);
				tempTransform.TransformPosition(vector, vector2);
			}
			else
			{
				standardTransform.TransformPosition(vector, vector2);
			}
		}
		else
		{
			Transform socketTransform = moveInfo.SocketTransform;
			FTransformDouble ftransformDouble = this.AttackerMeshComp.D_GetSocketTransform(move.BoneName, ERelativeTransformSpace.RTS_World);
			socketTransform.FromUeTransform(ftransformDouble);
			vector2.FromUeVector(moveInfo.SocketTransform.GetLocation());
			attackerActorComp.ActorQuatProxy.RotateVector(vector, vector3);
			vector2.AdditionEqual(vector3);
		}
		bulletInfo.SetActorLocation(vector2);
		bulletInfo.InitPosition.FromUeVector(vector2);
		BulletPool.RecycleVector(vector);
		BulletPool.RecycleVector(vector2);
		BulletPool.RecycleVector(vector3);
	}

	// Token: 0x06017839 RID: 96313 RVA: 0x006863D0 File Offset: 0x006845D0
	private void InitPositionTarget([Nullable(2)] BaseActorComponent target, Transform outTransform, bool baseOnTarget = false, bool baseOnTargetActor = false)
	{
		BulletInfo bulletInfo = this.BulletInfo;
		BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
		if (target != null && target.Valid)
		{
			if (baseOnTargetActor)
			{
				FTransformDouble actorTransform = target.ActorTransform;
				outTransform.FromUeTransform(actorTransform);
			}
			else
			{
				FTransformDouble socketTransform = target.GetSocketTransform(bulletInfo.SkillBoneName ?? FName.NAME_None);
				outTransform.SetRotation(socketTransform.GetRotation());
				outTransform.SetLocation(socketTransform.GetLocation());
				outTransform.SetScale3D(Vector.OneVectorProxy);
			}
			Vector vector = BulletPool.CreateVector(false);
			vector.FromUeVector(outTransform.GetLocation());
			this.ClampDistance(vector);
			outTransform.SetLocation(vector);
			BulletPool.RecycleVector(vector);
		}
		else
		{
			if (baseOnTarget)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Bullet;
				ELogAuthor author = ELogAuthor.HCW;
				string message = "出生位置需要完全基于目标, 但是目标不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("子弹ID", bulletInfo.BulletRowName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			outTransform.Reset();
			Vector vector2 = BulletPool.CreateVector(false);
			Vector vector3 = vector2;
			FVectorDouble actorLocation = attackerActorComp.ActorLocation;
			vector3.FromUeVector(actorLocation);
			this.ClampDistance(vector2);
			outTransform.SetLocation(vector2);
			BulletPool.RecycleVector(vector2);
		}
		if (!baseOnTarget && !baseOnTargetActor)
		{
			outTransform.SetRotation(attackerActorComp.ActorQuatProxy);
		}
	}

	// Token: 0x0601783A RID: 96314 RVA: 0x00686510 File Offset: 0x00684710
	private void ClampDistance(Vector standardLocation)
	{
		BulletInfo bulletInfo = this.BulletInfo;
		BulletDataBase @base = bulletInfo.BulletDataMain.Base;
		this.BaseLocationOutLimit = false;
		double num = @base.BornDistLimit.Y;
		if (num <= 0.0)
		{
			num = 15000.0;
		}
		Vector actorLocationProxy = bulletInfo.AttackerActorComp.ActorLocationProxy;
		Vector vector = BulletPool.CreateVector(false);
		vector.FromUeVector(standardLocation);
		double num2 = Vector.Dist(vector, actorLocationProxy);
		if (num2 > num)
		{
			this.BaseLocationOutLimit = true;
			vector.SubtractionEqual(actorLocationProxy);
			vector.Normalize(9.99999993922529E-09);
			vector.MultiplyEqual(num);
			vector.Addition(actorLocationProxy, standardLocation);
		}
		else
		{
			double x = @base.BornDistLimit.X;
			Entity target = bulletInfo.Target;
			if (target != null && target.Valid)
			{
				if (num2 < x)
				{
					this.BaseLocationOutLimit = true;
					vector.SubtractionEqual(actorLocationProxy);
					vector.Normalize(9.99999993922529E-09);
					vector.MultiplyEqual(x);
					vector.Addition(actorLocationProxy, standardLocation);
				}
			}
			else
			{
				double z = @base.BornDistLimit.Z;
				if (z > 0.0)
				{
					this.BaseLocationOutLimit = true;
					Vector vector2 = vector;
					FVectorDouble actorForward = bulletInfo.AttackerActorComp.ActorForward;
					vector2.FromUeVector(actorForward);
					vector.MultiplyEqual(z);
					vector.Addition(actorLocationProxy, standardLocation);
				}
			}
		}
		BulletPool.RecycleVector(vector);
	}

	// Token: 0x0601783B RID: 96315 RVA: 0x00686670 File Offset: 0x00684870
	private void BulletAimedToward(Rotator outRotator)
	{
		BulletInfo bulletInfo = this.BulletInfo;
		BulletDataAimed aimed = this.BulletInfo.BulletDataMain.Aimed;
		APlayerCameraManager characterCameraManager = Global.CharacterCameraManager;
		Vector vector = BulletPool.CreateVector(false);
		Vector vector2 = BulletPool.CreateVector(false);
		Vector vector3 = BulletPool.CreateVector(false);
		Vector vector4 = BulletPool.CreateVector(false);
		Vector vector5 = vector;
		FVectorDouble fvectorDouble = characterCameraManager.D_GetCameraLocation();
		vector5.FromUeVector(fvectorDouble);
		Vector vector6 = vector2;
		FVector fvector = characterCameraManager.GetActorForwardVector();
		vector6.FromUeVector(fvector);
		vector2.MultiplyEqual((double)aimed.DistLimit);
		vector2.AdditionEqual(vector);
		if (bulletInfo.MoveInfo.AimedLineTraceElement == null)
		{
			bulletInfo.MoveInfo.AimedLineTraceElement = BulletTraceElementPool.GetTraceLineElement(ModelBase<BulletModel>.Instance.ObjectTypeTakeAim, bulletInfo.AttackerId, bulletInfo.CollisionInfo.IgnoreQueries);
		}
		UTraceLineElement aimedLineTraceElement = bulletInfo.MoveInfo.AimedLineTraceElement;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(aimedLineTraceElement, vector.ToUeVectorOld());
		Singleton<TraceElementCommon>.Instance.SetEndLocation(aimedLineTraceElement, vector2);
		bool flag = Singleton<TraceElementCommon>.Instance.LineTrace(aimedLineTraceElement, "BulletMoveAimedToward");
		int num = -1;
		if (flag)
		{
			UKuroHitResult hitResult = aimedLineTraceElement.HitResult;
			int hitCount = hitResult.GetHitCount();
			Vector vector7 = BulletPool.CreateVector(false);
			Vector vector8 = BulletPool.CreateVector(false);
			Vector vector9 = vector8;
			fvector = characterCameraManager.GetActorForwardVector();
			vector9.FromUeVector(fvector);
			for (int i = 0; i < hitCount; i++)
			{
				if (Singleton<BulletConstant>.Instance.OpenMoveLog)
				{
					hitResult.Actors.Get(i);
				}
				TWeakObjectPtr<UPrimitiveComponent> tweakObjectPtr = hitResult.Components.Get(i);
				UPrimitiveComponent uprimitiveComponent = tweakObjectPtr.Get();
				FName b = (uprimitiveComponent != null && uprimitiveComponent.IsValid()) ? tweakObjectPtr.Get().GetCollisionProfileName() : new FName();
				if (Singleton<BulletConstant>.Instance.ProfileNameWater != b)
				{
					Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, i, vector3);
					vector7.FromUeVector(vector3);
					vector7.SubtractionEqual(bulletInfo.GetActorLocation());
					vector7.Normalize(9.99999993922529E-09);
					if (Vector.DotProduct(vector8, vector7) > 0.0)
					{
						TArray<TWeakObjectPtr<AActor>> actors = hitResult.Actors;
						TWeakObjectPtr<AActor>? tweakObjectPtr2 = (actors != null) ? new TWeakObjectPtr<AActor>?(actors.Get(i)) : null;
						if (tweakObjectPtr2 != null && tweakObjectPtr2.GetValueOrDefault().IsValid(false, false))
						{
							TWeakObjectPtr<AActor>? tweakObjectPtr3 = tweakObjectPtr2;
							EntityHandle entityByActor = ActorUtils.GetEntityByActor((tweakObjectPtr3 != null) ? tweakObjectPtr3.GetValueOrDefault() : null, false);
							CharacterActorComponent characterActorComponent;
							if (entityByActor == null)
							{
								characterActorComponent = null;
							}
							else
							{
								WorldEntity entity = entityByActor.Entity;
								characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
							}
							CharacterActorComponent characterActorComponent2 = characterActorComponent;
							if (characterActorComponent2 == null || BulletUtil.AttackedCondition(bulletInfo, characterActorComponent2))
							{
								num = i;
								break;
							}
						}
					}
				}
			}
			BulletPool.RecycleVector(vector7);
			BulletPool.RecycleVector(vector8);
		}
		if (Singleton<BulletConstant>.Instance.OpenMoveLog)
		{
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, (num < 0) ? vector2.ToUeVector(false) : vector3.ToUeVector(false), 10f, 10, new FLinearColor?(ColorUtils.LinearGreen), 10f, 0f);
		}
		vector4.FromUeVector(bulletInfo.GetActorLocation());
		Vector vector10 = (num < 0) ? vector2 : vector3;
		vector4.SubtractionEqual(vector10);
		vector4.MultiplyEqual(-1.0);
		fvector = bulletInfo.GetActorLocation().ToUeVectorOld();
		FVector fvector2 = vector10.ToUeVectorOld();
		FRotator frotator = UKismetMathLibrary.FindLookAtRotation(fvector, fvector2);
		outRotator.FromUeRotator(frotator);
		BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
		Vector vector11 = (attackerActorComp != null) ? attackerActorComp.ActorForwardProxy : null;
		if (vector11 != null)
		{
			vector11.Normalize(9.999999747378752E-05);
		}
		vector4.Normalize(9.999999747378752E-05);
		BulletPool.RecycleVector(vector);
		BulletPool.RecycleVector(vector2);
		BulletPool.RecycleVector(vector3);
		BulletPool.RecycleVector(vector4);
	}

	// Token: 0x0601783C RID: 96316 RVA: 0x00686A1C File Offset: 0x00684C1C
	private void OnStartSpeedRotator()
	{
		BulletDataAimed aimed = this.Data.Aimed;
		BulletDataMove move = this.Data.Move;
		if (aimed.AimedCtrlDir || move.FollowType == EBulletFollowType.跟随骨骼位置旋转 || move.Trajectory == EMoveTrajectory.角度限制抛物线子弹 || move.Trajectory == EMoveTrajectory.时间限制抛物线子弹)
		{
			return;
		}
		BulletInfo bulletInfo = this.BulletInfo;
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		BulletDataBase @base = this.Data.Base;
		this.GetBeginSpeedRotator(moveInfo.BeginSpeedRotator);
		Rotator rotator = BulletPool.CreateRotator(false);
		if (!move.InitVelocityRot.IsNearlyZero())
		{
			rotator.FromUeRotator(moveInfo.BeginSpeedRotator);
			Singleton<MathUtils>.Instance.ComposeRotator(move.InitVelocityRot, rotator, moveInfo.BeginSpeedRotator);
		}
		FRotator? beginRotatorOffset = bulletInfo.BulletInitParams.BeginRotatorOffset;
		if (beginRotatorOffset != null)
		{
			Rotator rotator2 = BulletPool.CreateRotator(false);
			Rotator rotator3 = rotator2;
			FRotator value = beginRotatorOffset.Value;
			rotator3.FromUeRotator(value);
			rotator.FromUeRotator(moveInfo.BeginSpeedRotator);
			Singleton<MathUtils>.Instance.ComposeRotator(rotator2, rotator, moveInfo.BeginSpeedRotator);
			BulletPool.RecycleRotator(rotator2);
		}
		if (@base.StickGround && !@base.IgnoreGradient)
		{
			BulletPool.RecycleRotator(rotator);
			return;
		}
		if (!@base.Rotator.IsNearlyZero())
		{
			bulletInfo.IsCollisionRelativeRotationModify = true;
		}
		if (!move.InitVelocityDirRandom.IsZero())
		{
			this.RandomBeginSpeedRotator(moveInfo.BeginSpeedRotator, move.InitVelocityDirRandom);
		}
		BulletUtil.ClampBeginRotator(bulletInfo);
		bulletInfo.SetActorRotation(moveInfo.BeginSpeedRotator);
		BulletPool.RecycleRotator(rotator);
		bool gasDebug = false;
		ELogAuthor author = ELogAuthor.HCW;
		Entity owner = null;
		string message = "BulletActionInitMove OnStartSpeedRotator";
		BulletInfo bulletInfo2 = this.BulletInfo;
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Rot", bulletInfo.GetActorRotation());
		BulletLog.Info(gasDebug, author, owner, message, bulletInfo2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601783D RID: 96317 RVA: 0x00686BAC File Offset: 0x00684DAC
	private void RandomBeginSpeedRotator(Rotator beginRotator, Vector randomConfig)
	{
		if (randomConfig.X > 0.0)
		{
			Vector vector = BulletPool.CreateVector(false);
			if (this.BulletInfo.BulletInitParams.FromRemote)
			{
				vector.FromUeVector(this.BulletInfo.RandomInitSpeedOffset);
			}
			else
			{
				FVector fvector = UKismetMathLibrary.RandomUnitVectorInConeInDegrees(Vector.ForwardVector, (float)randomConfig.X);
				vector.FromUeVector(fvector);
				this.BulletInfo.RandomInitSpeedOffset.FromUeVector(vector);
			}
			beginRotator.Quaternion(null).RotateVector(vector, vector);
			Singleton<MathUtils>.Instance.VectorToRotator(vector, beginRotator);
			BulletPool.RecycleVector(vector);
			return;
		}
		if (randomConfig.Y > 0.0 || randomConfig.Z > 0.0)
		{
			Rotator rotator = BulletPool.CreateRotator(false);
			BulletInfo bulletInfo = this.BulletInfo;
			if (bulletInfo != null && bulletInfo.BulletInitParams.FromRemote)
			{
				rotator.Set((float)this.BulletInfo.RandomInitSpeedOffset.Y, (float)this.BulletInfo.RandomInitSpeedOffset.Z, 0f);
			}
			else
			{
				float random = this.GetRandom((float)randomConfig.Y);
				float random2 = this.GetRandom((float)randomConfig.Z);
				rotator.Set(random, random2, 0f);
				this.BulletInfo.RandomInitSpeedOffset.Set(0.0, (double)random, (double)random2);
			}
			Rotator rotator2 = BulletPool.CreateRotator(false);
			rotator2.FromUeRotator(beginRotator);
			Singleton<MathUtils>.Instance.ComposeRotator(rotator, rotator2, beginRotator);
			BulletPool.RecycleRotator(rotator);
			BulletPool.RecycleRotator(rotator2);
		}
	}

	// Token: 0x0601783E RID: 96318 RVA: 0x00686D2A File Offset: 0x00684F2A
	private float GetRandom(float inValue)
	{
		if (inValue == 0f)
		{
			return 0f;
		}
		return (float)(new Random().NextDouble() * (double)inValue);
	}

	// Token: 0x0601783F RID: 96319 RVA: 0x00686D48 File Offset: 0x00684F48
	private void GetBeginSpeedRotator(Rotator outRotator)
	{
		FVectorDouble? fvectorDouble = null;
		BulletInfo bulletInfo = this.BulletInfo;
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		BulletDataMove move = this.Data.Move;
		string initVelocityDirParam = move.InitVelocityDirParam;
		switch (move.InitVelocityDirStandard)
		{
		case EInitialVelocityDirection.默认:
		{
			if (FNameUtil.IsEmpty(new FName?(move.BoneName)) || move.FollowType == EBulletFollowType.跟随骨骼)
			{
				outRotator.FromUeRotator(bulletInfo.AttackerActorComp.ActorRotationProxy);
				return;
			}
			moveInfo.SocketTransform.GetRotation().Rotator(outRotator);
			Vector followSkeletonRotLimit = move.FollowSkeletonRotLimit;
			Rotator actorRotation = bulletInfo.GetActorRotation();
			if (followSkeletonRotLimit.X >= 1.0)
			{
				outRotator.Roll = actorRotation.Roll;
			}
			if (followSkeletonRotLimit.Y >= 1.0)
			{
				outRotator.Pitch = actorRotation.Pitch;
			}
			if (followSkeletonRotLimit.Z >= 1.0)
			{
				outRotator.Yaw = bulletInfo.AttackerActorComp.ActorRotationProxy.Yaw;
			}
			return;
		}
		case EInitialVelocityDirection.面向目标:
		{
			fvectorDouble = BulletUtil.GetTargetLocation(bulletInfo.TargetActorComp, (!StringUtils.IsNothing(initVelocityDirParam)) ? (FNameUtil.GetDynamicFName(initVelocityDirParam) ?? FName.NAME_None) : (bulletInfo.SkillBoneName ?? FName.NAME_None), bulletInfo);
			if (fvectorDouble == null)
			{
				outRotator.FromUeRotator(bulletInfo.AttackerActorComp.ActorRotationProxy);
				return;
			}
			CharacterMoveComponent attackerMoveComp = bulletInfo.AttackerMoveComp;
			FRotator frotator;
			if (attackerMoveComp != null && !attackerMoveComp.IsStandardGravity)
			{
				Vector actorLocation = bulletInfo.GetActorLocation();
				FVectorDouble value = fvectorDouble.Value;
				bool initVelocityKeepUp = move.InitVelocityKeepUp;
				CharacterMoveComponent attackerMoveComp2 = bulletInfo.AttackerMoveComp;
				frotator = BulletUtil.FindLookAtRotDouble(actorLocation, value, initVelocityKeepUp, (attackerMoveComp2 != null) ? attackerMoveComp2.GravityUp.ToUeVector(false) : Vector.UpVectorDouble);
			}
			else
			{
				frotator = BulletUtil.FindLookAtRotDoubleStandard(bulletInfo.GetActorLocation(), fvectorDouble.Value, move.InitVelocityKeepUp);
			}
			FRotator frotator2 = frotator;
			outRotator.FromUeRotator(frotator2);
			return;
		}
		case EInitialVelocityDirection.面向发射者:
		{
			BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
			if (attackerActorComp != null)
			{
				fvectorDouble = new FVectorDouble?(attackerActorComp.GetSocketLocation(FNameUtil.GetDynamicFName(initVelocityDirParam) ?? FName.NAME_None));
				CharacterMoveComponent attackerMoveComp3 = bulletInfo.AttackerMoveComp;
				FRotator frotator3;
				if (attackerMoveComp3 != null && !attackerMoveComp3.IsStandardGravity)
				{
					Vector actorLocation2 = bulletInfo.GetActorLocation();
					FVectorDouble value2 = fvectorDouble.Value;
					bool initVelocityKeepUp2 = move.InitVelocityKeepUp;
					CharacterMoveComponent attackerMoveComp4 = bulletInfo.AttackerMoveComp;
					frotator3 = BulletUtil.FindLookAtRotDouble(actorLocation2, value2, initVelocityKeepUp2, (attackerMoveComp4 != null) ? attackerMoveComp4.GravityUp.ToUeVector(false) : Vector.UpVectorDouble);
				}
				else
				{
					frotator3 = BulletUtil.FindLookAtRotDoubleStandard(bulletInfo.GetActorLocation(), fvectorDouble.Value, move.InitVelocityKeepUp);
				}
				FRotator frotator2 = frotator3;
				outRotator.FromUeRotator(frotator2);
				return;
			}
			break;
		}
		case EInitialVelocityDirection.父子弹方向:
		{
			FRotator frotator4 = bulletInfo.TransformCreate.Value.Rotator();
			if (!Rotator.ZeroRotatorProxy.Equals2(frotator4, 0.0001f))
			{
				outRotator.FromUeRotator(frotator4);
				return;
			}
			break;
		}
		case EInitialVelocityDirection.跟随骨骼默认朝向:
			outRotator.FromUeRotator(bulletInfo.GetActorRotation());
			return;
		case EInitialVelocityDirection.面向发射者锁定目标:
		case EInitialVelocityDirection.面向自定义目标:
		case EInitialVelocityDirection.父子弹受击者:
		case EInitialVelocityDirection.父子弹目标:
		case EInitialVelocityDirection.前台角色锁定目标:
		case EInitialVelocityDirection.伴生物:
		{
			BaseActorComponent baseVelocityTarget = bulletInfo.GetBaseVelocityTarget();
			if (baseVelocityTarget != null && baseVelocityTarget.Valid)
			{
				fvectorDouble = new FVectorDouble?(baseVelocityTarget.GetSocketLocation(FNameUtil.GetDynamicFName(initVelocityDirParam) ?? FName.NAME_None));
				CharacterMoveComponent attackerMoveComp5 = bulletInfo.AttackerMoveComp;
				FRotator frotator5;
				if (attackerMoveComp5 != null && !attackerMoveComp5.IsStandardGravity)
				{
					Vector actorLocation3 = bulletInfo.GetActorLocation();
					FVectorDouble value3 = fvectorDouble.Value;
					bool initVelocityKeepUp3 = move.InitVelocityKeepUp;
					CharacterMoveComponent attackerMoveComp6 = bulletInfo.AttackerMoveComp;
					frotator5 = BulletUtil.FindLookAtRotDouble(actorLocation3, value3, initVelocityKeepUp3, (attackerMoveComp6 != null) ? attackerMoveComp6.GravityUp.ToUeVector(false) : Vector.UpVectorDouble);
				}
				else
				{
					frotator5 = BulletUtil.FindLookAtRotDoubleStandard(bulletInfo.GetActorLocation(), fvectorDouble.Value, move.InitVelocityKeepUp);
				}
				FRotator frotator2 = frotator5;
				outRotator.FromUeRotator(frotator2);
				return;
			}
			outRotator.FromUeRotator(bulletInfo.AttackerActorComp.ActorRotationProxy);
			return;
		}
		case EInitialVelocityDirection.队伍角色:
		{
			CharacterActorComponent currentRole = BulletUtil.GetCurrentRole(this.BulletInfo);
			if (currentRole != null && currentRole.Valid)
			{
				fvectorDouble = new FVectorDouble?(currentRole.GetSocketLocation(FNameUtil.GetDynamicFName(initVelocityDirParam) ?? FName.NAME_None));
				CharacterMoveComponent attackerMoveComp7 = bulletInfo.AttackerMoveComp;
				FRotator frotator6;
				if (attackerMoveComp7 != null && !attackerMoveComp7.IsStandardGravity)
				{
					Vector actorLocation4 = bulletInfo.GetActorLocation();
					FVectorDouble value4 = fvectorDouble.Value;
					bool initVelocityKeepUp4 = move.InitVelocityKeepUp;
					CharacterMoveComponent attackerMoveComp8 = bulletInfo.AttackerMoveComp;
					frotator6 = BulletUtil.FindLookAtRotDouble(actorLocation4, value4, initVelocityKeepUp4, (attackerMoveComp8 != null) ? attackerMoveComp8.GravityUp.ToUeVector(false) : Vector.UpVectorDouble);
				}
				else
				{
					frotator6 = BulletUtil.FindLookAtRotDoubleStandard(bulletInfo.GetActorLocation(), fvectorDouble.Value, move.InitVelocityKeepUp);
				}
				FRotator frotator2 = frotator6;
				outRotator.FromUeRotator(frotator2);
				return;
			}
			outRotator.FromUeRotator(bulletInfo.AttackerActorComp.ActorRotationProxy);
			return;
		}
		case EInitialVelocityDirection.伴生物朝向:
		{
			BaseActorComponent baseVelocityTarget2 = bulletInfo.GetBaseVelocityTarget();
			if (baseVelocityTarget2 != null && baseVelocityTarget2.Valid)
			{
				outRotator.FromUeRotator(baseVelocityTarget2.ActorRotationProxy);
				return;
			}
			outRotator.FromUeRotator(bulletInfo.AttackerActorComp.ActorRotationProxy);
			return;
		}
		case EInitialVelocityDirection.世界旋转:
			if (bulletInfo.TransformCreate != null)
			{
				FRotator frotator2 = bulletInfo.TransformCreate.Value.Rotator();
				outRotator.FromUeRotator(frotator2);
				return;
			}
			break;
		case EInitialVelocityDirection.跟随技能目标旋转:
		{
			BaseActorComponent baseVelocityTarget3 = bulletInfo.GetBaseVelocityTarget();
			if (baseVelocityTarget3 != null && baseVelocityTarget3.Valid)
			{
				FRotator frotator2 = baseVelocityTarget3.ActorRotation;
				outRotator.FromUeRotator(frotator2);
				return;
			}
			break;
		}
		}
		outRotator.FromUeRotator(Rotator.ZeroRotatorProxy);
	}

	// Token: 0x06017840 RID: 96320 RVA: 0x00687284 File Offset: 0x00685484
	private unsafe void OnStartAround()
	{
		BulletInfo bulletInfo = this.BulletInfo;
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		BulletDataMove move = bulletInfo.BulletDataMain.Move;
		if (move.Trajectory != EMoveTrajectory.围绕中心旋转)
		{
			return;
		}
		Vector[] trackParams = move.TrackParams;
		int num = trackParams.Length;
		Vector vector = trackParams[0];
		Vector vector2 = (num > 1) ? trackParams[1] : null;
		Vector vector3 = BulletPool.CreateVector(false);
		float num2 = 0f;
		CharacterMoveComponent attackerMoveComp = bulletInfo.AttackerMoveComp;
		bool flag = attackerMoveComp == null || attackerMoveComp.IsStandardGravity;
		if (move.TrackTarget == EBulletTarget.空 || move.TrackTarget == EBulletTarget.外部传入坐标)
		{
			CharacterActorComponent currentRole = BulletUtil.GetCurrentRole(bulletInfo);
			if (currentRole == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Bullet;
				ELogAuthor author = ELogAuthor.HCW;
				string message = "围绕中心旋转子弹获取不到当前玩家控制的角色";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", bulletInfo.BulletEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Attacker", bulletInfo.AttackerActorComp.Owner);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				ControllerBase<BulletController>.Instance.DestroyBullet(bulletInfo.BulletEntityId, false, EBulletDestroyReason.Normal, false);
				BulletPool.RecycleVector(vector3);
				return;
			}
			moveInfo.RoundCenter.FromUeVector(bulletInfo.InitPosition);
			if (vector2 != null)
			{
				BulletUtil.AroundBulletAxisAndBeginVector(vector, vector2, moveInfo.RoundOnceAxis, vector3, currentRole, flag ? null : bulletInfo.AttackerMoveComp.GravityUp);
			}
			else
			{
				num2 = currentRole.ActorRotation.Yaw;
				vector3.FromUeVector(Vector.ForwardVectorProxy);
			}
		}
		else
		{
			BaseActorComponent targetActorComp = bulletInfo.TargetActorComp;
			if (targetActorComp != null && targetActorComp.Valid)
			{
				this.RoundBulletInitTarget(targetActorComp);
				if (vector2 != null)
				{
					BulletUtil.AroundBulletAxisAndBeginVector(vector, vector2, moveInfo.RoundOnceAxis, vector3, targetActorComp, flag ? null : bulletInfo.AttackerMoveComp.GravityUp);
				}
				else
				{
					num2 = targetActorComp.ActorRotation.Yaw;
					Vector vector4 = vector3;
					FVectorDouble actorForward = targetActorComp.ActorForward;
					vector4.FromUeVector(actorForward);
				}
			}
			else
			{
				moveInfo.RoundCenter.FromUeVector(bulletInfo.InitPosition);
				if (vector2 != null)
				{
					BulletUtil.AroundBulletAxisAndBeginVector(vector, vector2, moveInfo.RoundOnceAxis, vector3, null, flag ? null : bulletInfo.AttackerMoveComp.GravityUp);
				}
				else
				{
					vector3.FromUeVector(Vector.ForwardVectorProxy);
				}
			}
		}
		Vector vector5 = BulletPool.CreateVector(false);
		if (num > 1)
		{
			vector3.RotateAngleAxis(vector.Y, moveInfo.RoundOnceAxis, vector5);
			vector5.MultiplyEqual(vector.X);
			vector5.AdditionEqual(moveInfo.RoundCenter);
			bulletInfo.SetActorLocation(vector5);
		}
		else
		{
			CharacterMoveComponent attackerMoveComp2 = bulletInfo.AttackerMoveComp;
			flag = (attackerMoveComp2 == null || attackerMoveComp2.IsStandardGravity);
			if (flag)
			{
				vector3.RotateAngleAxis(vector.Y, Vector.UpVectorProxy, vector5);
				double num3 = vector.Z * 0.01745329238474369;
				vector5.Z = (double)(-(double)MathF.Sin((float)(((double)num2 + vector.Y) * 0.01745329238474369)) * MathF.Tan((float)num3));
				vector5.Normalize(9.99999993922529E-09);
				vector5.MultiplyEqual(vector.X);
				vector5.AdditionEqual(moveInfo.RoundCenter);
				bulletInfo.SetActorLocation(vector5);
				moveInfo.RoundOnceAxis.Set(0.0, (double)MathF.Sin((float)num3), (double)MathF.Cos((float)num3));
			}
			else
			{
				Vector gravityUp = bulletInfo.AttackerMoveComp.GravityUp;
				vector3.RotateAngleAxis(vector.Y, gravityUp, vector5);
				vector5.Normalize(9.99999993922529E-09);
				vector5.MultiplyEqual(vector.X);
				vector5.AdditionEqual(moveInfo.RoundCenter);
				bulletInfo.SetActorLocation(vector5);
				Vector vector6 = BulletPool.CreateVector(false);
				Vector.CrossProduct(gravityUp, Vector.ForwardVectorProxy, vector6);
				Vector.Lerp(gravityUp, vector6, (double)((float)(Singleton<MathUtils>.Instance.Clamp(vector.Z, 0.0, 90.0) / 90.0)), moveInfo.RoundOnceAxis);
				BulletPool.RecycleVector(vector6);
			}
		}
		moveInfo.AroundAngle = (float)vector.Y;
		BulletPool.RecycleVector(vector3);
		BulletPool.RecycleVector(vector5);
	}

	// Token: 0x06017841 RID: 96321 RVA: 0x00687698 File Offset: 0x00685898
	private void RoundBulletInitTarget(BaseActorComponent target)
	{
		BulletInfo bulletInfo = this.BulletInfo;
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		bulletInfo.ClearCacheLocationAndRotation();
		bulletInfo.ActorComponent.SetActorTransform(target.ActorTransform, "unknown", true, null);
		Vector roundCenter = moveInfo.RoundCenter;
		FTransformDouble actorTransform = target.ActorTransform;
		FVectorDouble fvectorDouble = bulletInfo.BornLocationOffset.ToUeVector(false);
		FVectorDouble fvectorDouble2 = actorTransform.TransformPosition(fvectorDouble);
		roundCenter.FromUeVector(fvectorDouble2);
		Vector roundCenterLastLocation = moveInfo.RoundCenterLastLocation;
		fvectorDouble = target.ActorLocation;
		roundCenterLastLocation.FromUeVector(fvectorDouble);
	}

	// Token: 0x06017842 RID: 96322 RVA: 0x00687718 File Offset: 0x00685918
	private void OnStartParabola()
	{
		BulletDataMove move = this.Data.Move;
		EMoveTrajectory trajectory = move.Trajectory;
		bool flag = trajectory == EMoveTrajectory.时间限制抛物线子弹;
		bool flag2 = trajectory == EMoveTrajectory.角度限制抛物线子弹;
		if (!flag && !flag2)
		{
			return;
		}
		Vector[] trackParams = move.TrackParams;
		if (trackParams == null || trackParams.Length < 2)
		{
			return;
		}
		BulletInfo bulletInfo = this.BulletInfo;
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		double num = 0.0;
		bool flag3 = false;
		double num2 = 0.0;
		Vector vector2;
		double inB;
		if (flag)
		{
			int num3 = 2;
			int num4 = 3;
			Vector vector = (trackParams.Length > num3) ? trackParams[num3] : null;
			vector2 = ((trackParams.Length > num4) ? trackParams[num4] : null);
			inB = trackParams[0].X;
			if (vector != null)
			{
				num = vector.X;
				flag3 = (vector.Z > 0.0);
				num2 = vector.Y;
			}
		}
		else
		{
			int num5 = 1;
			int num6 = 2;
			Vector vector3 = (trackParams.Length > num5) ? trackParams[num5] : null;
			vector2 = ((trackParams.Length > num6) ? trackParams[num6] : null);
			if (vector3 != null)
			{
				num = vector3.Y;
			}
			inB = ((vector2 != null) ? vector2.Y : trackParams[0].X);
		}
		moveInfo.GravityMoveRotator.Reset();
		BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
		BaseActorComponent targetActorComp = bulletInfo.TargetActorComp;
		BaseActorComponent baseActorComponent = (targetActorComp != null && targetActorComp.Valid) ? bulletInfo.TargetActorComp : null;
		Vector vector4 = BulletPool.CreateVector(false);
		FName? dynamicFName = FNameUtil.GetDynamicFName(move.TrackTargetBlackboardKey);
		FVectorDouble? targetLocation = BulletUtil.GetTargetLocation(baseActorComponent, FNameUtil.IsNothing(dynamicFName) ? (bulletInfo.SkillBoneName ?? FName.NAME_None) : dynamicFName.Value, bulletInfo);
		CharacterMoveComponent attackerMoveComp = bulletInfo.AttackerMoveComp;
		Vector vector5 = ((attackerMoveComp != null) ? attackerMoveComp.GravityUp : null) ?? Vector.UpVectorProxy;
		if (targetLocation != null)
		{
			if (baseActorComponent != null && baseActorComponent.Valid && baseActorComponent is CharacterActorComponent)
			{
				Vector vector6 = vector4;
				FVectorDouble value = targetLocation.Value;
				vector6.FromUeVector(value);
				double num7 = 0.0;
				if (num != 0.0)
				{
					num7 = (double)((CharacterActorComponent)baseActorComponent).Actor.CapsuleComponent.CapsuleHalfHeight * num;
				}
				if (flag3)
				{
					Entity entity = baseActorComponent.Entity;
					CharacterMoveComponent characterMoveComponent = (entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null;
					if (characterMoveComponent != null)
					{
						num7 -= (double)characterMoveComponent.GetHeightAboveGround(500f);
					}
				}
				Entity target = bulletInfo.Target;
				BaseMoveComponent baseMoveComponent = (target != null) ? target.GetComponent<BaseMoveComponent>() : null;
				Vector vector7 = BulletPool.CreateVector(false);
				vector7.FromUeVector(((baseMoveComponent != null) ? baseMoveComponent.GravityUp : null) ?? Vector.UpVectorProxy);
				vector7.MultiplyEqual(num7);
				vector4.AdditionEqual(vector7);
				BulletPool.RecycleVector(vector7);
			}
			else
			{
				Vector vector8 = vector4;
				FVectorDouble value = targetLocation.Value;
				vector8.FromUeVector(value);
			}
			Vector vector9 = BulletPool.CreateVector(false);
			switch (move.DestOffsetForward)
			{
			case EBulletDestOffset.发射者朝向:
				vector9.FromUeVector(bulletInfo.AttackerActorComp.ActorForwardProxy);
				break;
			case EBulletDestOffset.目标朝向:
				vector9.FromUeVector(baseActorComponent.ActorForwardProxy);
				break;
			case EBulletDestOffset.发射者向目标点:
			{
				Vector vector10 = BulletPool.CreateVector(false);
				vector4.Subtraction(bulletInfo.AttackerActorComp.ActorLocationProxy, vector10);
				vector10.Normalize(9.99999993922529E-09);
				Vector.VectorPlaneProject(vector10, vector5, vector9);
				BulletPool.RecycleVector(vector10);
				vector9.Normalize(9.99999993922529E-09);
				break;
			}
			}
			Vector vector11 = BulletPool.CreateVector(true);
			double x = move.DestOffset.X;
			double y = move.DestOffset.Y;
			double z = move.DestOffset.Z;
			if (y != 0.0)
			{
				Vector vector12 = BulletPool.CreateVector(false);
				Vector.CrossProduct(vector5, vector9, vector12);
				vector12.MultiplyEqual(y);
				vector11.AdditionEqual(vector12);
				BulletPool.RecycleVector(vector12);
			}
			if (x != 0.0)
			{
				vector9.MultiplyEqual(x);
				vector11.AdditionEqual(vector9);
			}
			if (z != 0.0)
			{
				Vector vector13 = BulletPool.CreateVector(false);
				vector13.FromUeVector(vector5);
				vector13.MultiplyEqual(z);
				vector11.AdditionEqual(vector13);
				BulletPool.RecycleVector(vector13);
			}
			vector4.AdditionEqual(vector11);
			BulletPool.RecycleVector(vector11);
			BulletPool.RecycleVector(vector9);
		}
		else
		{
			vector4.FromUeVector(attackerActorComp.ActorForwardProxy);
			vector4.MultiplyEqual(inB);
			vector4.AdditionEqual(attackerActorComp.ActorLocationProxy);
		}
		Vector vector14 = BulletPool.CreateVector(false);
		vector4.Subtraction(bulletInfo.GetActorLocation(), vector14);
		vector14.Normalize(9.99999993922529E-09);
		Rotator gravityMoveRotator = moveInfo.GravityMoveRotator;
		Vector.VectorPlaneProject(vector14, vector5, bulletInfo.MoveInfo.GravityMoveForward);
		Singleton<MathUtils>.Instance.LookRotationUpFirst(bulletInfo.MoveInfo.GravityMoveForward, vector5, gravityMoveRotator);
		BulletPool.RecycleVector(vector14);
		Vector vector15 = trackParams[0];
		if (flag)
		{
			Vector vector16 = trackParams[1];
			double num8 = (vector16.Z > 0.0) ? vector16.Z : 1.0;
			moveInfo.Gravity = ((vector15.Z != 0.0) ? ((float)vector15.Z) : -1000f);
			Vector vector17 = BulletPool.CreateVector(false);
			vector4.Subtraction(bulletInfo.GetActorLocation(), vector17);
			double num9 = Vector.DotProduct(vector17, bulletInfo.MoveInfo.GravityMoveForward);
			num9 += num2;
			num9 = Math.Max(num9, vector15.X);
			num9 = Math.Min(num9, vector15.Y);
			moveInfo.BulletSpeed2D = (float)(num9 / num8);
			double num10 = Vector.DotProduct(vector17, vector5);
			num10 = Math.Max(num10, vector16.X);
			num10 = Math.Min(num10, vector16.Y);
			BulletPool.RecycleVector(vector17);
			moveInfo.BulletSpeedZ = (float)(num10 / num8 - 0.5 * (double)moveInfo.Gravity * num8);
			moveInfo.BulletSpeed = MathF.Sqrt(MathF.Pow(moveInfo.BulletSpeed2D, 2f) + MathF.Pow(moveInfo.BulletSpeedZ, 2f));
		}
		else
		{
			double x2 = trackParams[1].X;
			moveInfo.Gravity = ((vector15.Z != 0.0) ? ((float)vector15.Z) : -1000f);
			Vector vector18 = BulletPool.CreateVector(false);
			vector4.Subtraction(bulletInfo.GetActorLocation(), vector18);
			double num11 = Vector.DotProduct(vector18, bulletInfo.MoveInfo.GravityMoveForward);
			double num12 = Vector.DotProduct(vector18, vector5);
			BulletPool.RecycleVector(vector18);
			moveInfo.BulletSpeed2D = MathF.Sqrt(MathF.Abs((float)(num11 * num11 * (double)moveInfo.Gravity / (2.0 * num12 - 2.0 * Math.Tan(x2 * 0.01745329238474369) * num11))));
			moveInfo.BulletSpeedZ = (float)(Math.Tan(x2 * 0.01745329238474369) * (double)moveInfo.BulletSpeed2D);
			moveInfo.BulletSpeed = MathF.Sqrt(MathF.Pow(moveInfo.BulletSpeed2D, 2f) + MathF.Pow(moveInfo.BulletSpeedZ, 2f));
			moveInfo.BulletSpeed = Math.Max((float)vector15.X, moveInfo.BulletSpeed);
			moveInfo.BulletSpeed = Math.Min((float)vector15.Y, moveInfo.BulletSpeed);
			moveInfo.BulletSpeedZ = (float)(Math.Sin(x2 * 0.01745329238474369) * (double)moveInfo.BulletSpeed);
			moveInfo.BulletSpeed2D = (float)(Math.Cos(x2 * 0.01745329238474369) * (double)moveInfo.BulletSpeed);
		}
		if (!move.InitVelocityRot.IsNearlyZero())
		{
			Rotator rotator = BulletPool.CreateRotator(false);
			rotator.FromUeRotator(gravityMoveRotator);
			Singleton<MathUtils>.Instance.ComposeRotator(move.InitVelocityRot, rotator, gravityMoveRotator);
			BulletPool.RecycleRotator(rotator);
		}
		if (vector2 != null && (vector2.X == 1.0 || vector2.X == 2.0))
		{
			bulletInfo.SetActorRotation(gravityMoveRotator);
			moveInfo.ActorRotateParabola = (vector2.X == 2.0);
		}
		BulletPool.RecycleVector(vector4);
	}

	// Token: 0x06017843 RID: 96323 RVA: 0x00687F50 File Offset: 0x00686150
	private void OnStartParabolaStandard()
	{
		BulletDataMove move = this.Data.Move;
		EMoveTrajectory trajectory = move.Trajectory;
		bool flag = trajectory == EMoveTrajectory.时间限制抛物线子弹;
		bool flag2 = trajectory == EMoveTrajectory.角度限制抛物线子弹;
		if (!flag && !flag2)
		{
			return;
		}
		Vector[] trackParams = move.TrackParams;
		if (trackParams == null || trackParams.Length < 2)
		{
			return;
		}
		BulletInfo bulletInfo = this.BulletInfo;
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		double num = 0.0;
		bool flag3 = false;
		double num2 = 0.0;
		double num3 = 0.0;
		Vector vector2;
		if (flag)
		{
			int num4 = 2;
			int num5 = 3;
			Vector vector = (trackParams.Length > num4) ? trackParams[num4] : null;
			vector2 = ((trackParams.Length > num5) ? trackParams[num5] : null);
			num3 = trackParams[0].X;
			if (vector != null)
			{
				num = vector.X;
				flag3 = (vector.Z > 0.0);
				num2 = vector.Y;
			}
		}
		else
		{
			int num6 = 1;
			int num7 = 2;
			Vector vector3 = (trackParams.Length > num6) ? trackParams[num6] : null;
			vector2 = ((trackParams.Length > num7) ? trackParams[num7] : null);
			if (vector2 != null)
			{
				num3 = vector2.Y;
			}
			if (num3 <= 0.0)
			{
				num3 = trackParams[0].X;
			}
			if (vector3 != null)
			{
				num = vector3.Y;
			}
		}
		moveInfo.GravityMoveRotator.Reset();
		BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
		BaseActorComponent targetActorComp = bulletInfo.TargetActorComp;
		BaseActorComponent baseActorComponent = (targetActorComp != null && targetActorComp.Valid) ? bulletInfo.TargetActorComp : null;
		Vector vector4 = BulletPool.CreateVector(false);
		FName? dynamicFName = FNameUtil.GetDynamicFName(move.TrackTargetBlackboardKey);
		FVectorDouble? targetLocation = BulletUtil.GetTargetLocation(baseActorComponent, FNameUtil.IsNothing(dynamicFName) ? (bulletInfo.SkillBoneName ?? FName.NAME_None) : dynamicFName.Value, bulletInfo);
		if (targetLocation != null)
		{
			if (baseActorComponent != null && baseActorComponent.Valid && baseActorComponent is CharacterActorComponent)
			{
				Vector vector5 = vector4;
				FVectorDouble value = targetLocation.Value;
				vector5.FromUeVector(value);
				if (num != 0.0)
				{
					vector4.Z += (double)((CharacterActorComponent)baseActorComponent).Actor.CapsuleComponent.CapsuleHalfHeight * num;
				}
				if (flag3)
				{
					Entity entity = baseActorComponent.Entity;
					CharacterMoveComponent characterMoveComponent = (entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null;
					if (characterMoveComponent != null)
					{
						vector4.Z -= (double)characterMoveComponent.GetHeightAboveGround(500f);
					}
				}
			}
			else
			{
				Vector vector6 = vector4;
				FVectorDouble value = targetLocation.Value;
				vector6.FromUeVector(value);
			}
			Vector vector7 = BulletPool.CreateVector(true);
			Vector vector8 = BulletPool.CreateVector(false);
			switch (move.DestOffsetForward)
			{
			case EBulletDestOffset.发射者朝向:
				vector8.FromUeVector(bulletInfo.AttackerActorComp.ActorForwardProxy);
				break;
			case EBulletDestOffset.目标朝向:
				vector8.FromUeVector(baseActorComponent.ActorForwardProxy);
				break;
			case EBulletDestOffset.发射者向目标点:
				vector4.Subtraction(bulletInfo.AttackerActorComp.ActorLocationProxy, vector8);
				vector8.Z = 0.0;
				vector8.Normalize(9.99999993922529E-09);
				break;
			}
			double x = move.DestOffset.X;
			double y = move.DestOffset.Y;
			double z = move.DestOffset.Z;
			if (y != 0.0)
			{
				Vector vector9 = BulletPool.CreateVector(false);
				Vector.CrossProduct(Vector.UpVectorProxy, vector8, vector9);
				vector9.MultiplyEqual(y);
				vector7.AdditionEqual(vector9);
				BulletPool.RecycleVector(vector9);
			}
			if (x != 0.0)
			{
				vector8.MultiplyEqual(x);
				vector7.AdditionEqual(vector8);
			}
			if (z != 0.0)
			{
				Vector vector10 = BulletPool.CreateVector(false);
				vector10.FromUeVector(Vector.UpVectorProxy);
				vector10.MultiplyEqual(z);
				vector7.AdditionEqual(vector10);
				BulletPool.RecycleVector(vector10);
			}
			vector4.AdditionEqual(vector7);
			BulletPool.RecycleVector(vector7);
			BulletPool.RecycleVector(vector8);
		}
		else
		{
			vector4.FromUeVector(attackerActorComp.ActorForwardProxy);
			vector4.MultiplyEqual(num3);
			vector4.AdditionEqual(attackerActorComp.ActorLocationProxy);
		}
		Vector vector11 = trackParams[0];
		double num11;
		if (flag)
		{
			Vector vector12 = trackParams[1];
			double num8 = (vector12.Z > 0.0) ? vector12.Z : 1.0;
			moveInfo.Gravity = ((vector11.Z != 0.0) ? ((float)vector11.Z) : -1000f);
			double num9 = Vector.Dist2D(vector4, bulletInfo.GetActorLocation());
			num9 += num2;
			num9 = Math.Max(num9, vector11.X);
			num9 = Math.Min(num9, vector11.Y);
			moveInfo.BulletSpeed2D = (float)(num9 / num8);
			double num10 = vector4.Z - bulletInfo.GetActorLocation().Z;
			num10 = Math.Max(num10, vector12.X);
			num10 = Math.Min(num10, vector12.Y);
			moveInfo.BulletSpeedZ = (float)(num10 / num8 - 0.5 * (double)moveInfo.Gravity * num8);
			moveInfo.BulletSpeed = MathF.Sqrt(MathF.Pow(moveInfo.BulletSpeed2D, 2f) + MathF.Pow(moveInfo.BulletSpeedZ, 2f));
			num11 = Math.Atan((double)(moveInfo.BulletSpeedZ / moveInfo.BulletSpeed2D)) * 57.295780181884766;
		}
		else
		{
			num11 = trackParams[1].X;
			moveInfo.Gravity = ((vector11.Z != 0.0) ? ((float)vector11.Z) : -1000f);
			double num12 = Vector.Dist2D(vector4, bulletInfo.GetActorLocation());
			double num13 = vector4.Z - bulletInfo.GetActorLocation().Z;
			moveInfo.BulletSpeed2D = MathF.Sqrt(MathF.Abs((float)(num12 * num12 * (double)moveInfo.Gravity / (2.0 * num13 - 2.0 * Math.Tan(num11 * 0.01745329238474369) * num12))));
			moveInfo.BulletSpeedZ = (float)(Math.Tan(num11 * 0.01745329238474369) * (double)moveInfo.BulletSpeed2D);
			moveInfo.BulletSpeed = MathF.Sqrt(MathF.Pow(moveInfo.BulletSpeed2D, 2f) + MathF.Pow(moveInfo.BulletSpeedZ, 2f));
			moveInfo.BulletSpeed = Math.Max((float)vector11.X, moveInfo.BulletSpeed);
			moveInfo.BulletSpeed = Math.Min((float)vector11.Y, moveInfo.BulletSpeed);
			moveInfo.BulletSpeedZ = (float)(Math.Sin(num11 * 0.01745329238474369) * (double)moveInfo.BulletSpeed);
			moveInfo.BulletSpeed2D = (float)(Math.Cos(num11 * 0.01745329238474369) * (double)moveInfo.BulletSpeed);
		}
		Rotator gravityMoveRotator = moveInfo.GravityMoveRotator;
		Vector vector13 = BulletPool.CreateVector(false);
		vector4.Subtraction(bulletInfo.GetActorLocation(), vector13);
		vector13.Normalize(9.99999993922529E-09);
		Singleton<MathUtils>.Instance.LookRotationUpFirst(vector13, Vector.UpVectorProxy, gravityMoveRotator);
		BulletPool.RecycleVector(vector13);
		gravityMoveRotator.Pitch = (float)num11;
		if (!move.InitVelocityRot.IsNearlyZero())
		{
			Rotator rotator = BulletPool.CreateRotator(false);
			rotator.FromUeRotator(gravityMoveRotator);
			Singleton<MathUtils>.Instance.ComposeRotator(move.InitVelocityRot, rotator, gravityMoveRotator);
			BulletPool.RecycleRotator(rotator);
		}
		if (vector2 != null && (vector2.X == 1.0 || vector2.X == 2.0))
		{
			bulletInfo.SetActorRotation(gravityMoveRotator);
			moveInfo.ActorRotateParabola = (vector2.X == 2.0);
		}
		BulletPool.RecycleVector(vector4);
	}

	// Token: 0x06017844 RID: 96324 RVA: 0x006886FC File Offset: 0x006868FC
	private unsafe void OnStartMovingPlatform()
	{
		BulletInfo bulletInfo = this.BulletInfo;
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		CharacterMoveComponent attackerMoveComp = bulletInfo.AttackerMoveComp;
		BulletDataMove move = this.Data.Move;
		EBulletFollowType followType = move.FollowType;
		if (followType == EBulletFollowType.跟随骨骼 || followType == EBulletFollowType.跟随骨骼位置旋转)
		{
			bulletInfo.ActorComponent.NeedDetach = true;
			if (Singleton<BulletConstant>.Instance.OpenMoveLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Bullet;
				ELogAuthor author = ELogAuthor.HCW;
				string message = "BulletActionInitMove OnStartMovingPlatform";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Bullet", this.BulletInfo.BulletRowName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("followType", followType.ToString());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("NeedDetach", this.BulletInfo.ActorComponent.NeedDetach);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
		}
		if (attackerMoveComp == null || !attackerMoveComp.HasBaseMovement || this.Data.Base.NotFollowMovePlatform)
		{
			return;
		}
		if (move.Speed == 0f)
		{
			if (!bulletInfo.ActorComponent.NeedDetach)
			{
				bulletInfo.ApplyCacheLocationAndRotation();
				BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
				ABaseCharacter abaseCharacter = ((attackerActorComp != null) ? attackerActorComp.Owner : null) as ABaseCharacter;
				if (abaseCharacter != null)
				{
					bulletInfo.ActorComponent.SetAttachToComponent(abaseCharacter.BasedMovement.MovementBase, FNameUtil.NONE, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false);
					if (!bulletInfo.ActorComponent.NeedDetach)
					{
						bulletInfo.ActorComponent.NeedDetachForBaseMovement = true;
					}
					bulletInfo.ActorComponent.NeedDetach = true;
					if (Singleton<BulletConstant>.Instance.OpenMoveLog)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Bullet;
						ELogAuthor author2 = ELogAuthor.HCW;
						string message2 = "BulletActionInitMove OnStartMovingPlatform";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Bullet", this.BulletInfo.BulletRowName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("BaseMovement", abaseCharacter.BasedMovement.MovementBase);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("NeedDetach", this.BulletInfo.ActorComponent.NeedDetach);
						instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
						return;
					}
				}
			}
		}
		else
		{
			moveInfo.IsOnBaseMovement = true;
			FVectorDouble? deltaBaseMovementSpeed = attackerMoveComp.DeltaBaseMovementSpeed;
			if (deltaBaseMovementSpeed != null)
			{
				Vector lastBaseMovementSpeed = moveInfo.LastBaseMovementSpeed;
				FVectorDouble value = deltaBaseMovementSpeed.Value;
				lastBaseMovementSpeed.FromUeVector(value);
			}
		}
	}

	// Token: 0x06017845 RID: 96325 RVA: 0x00688974 File Offset: 0x00686B74
	private void OnStartStickGround()
	{
		BulletInfo bulletInfo = this.BulletInfo;
		BulletDataBase @base = this.Data.Base;
		if (!@base.StickGround)
		{
			return;
		}
		Vector vector = BulletPool.CreateVector(false);
		Vector vector2 = BulletPool.CreateVector(false);
		if (BulletMoveInfo.StickGroundLineTrace == null)
		{
			BulletMoveInfo.StickGroundLineTrace = BulletTraceElementPool.NewTraceElementByTraceChannel<UTraceLineElement>(KuroTraceTypeQuery.IkGround, false);
		}
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			bool flag = ModelBase<BulletModel>.Instance.ShowBulletTrace(this.BulletInfo.Attacker.Id);
			EDrawDebugTrace drawDebugTrace = flag ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None;
			BulletMoveInfo.StickGroundLineTrace.SetDrawDebugTrace(drawDebugTrace);
			if (flag)
			{
				Singleton<TraceElementCommon>.Instance.SetTraceColor(BulletMoveInfo.StickGroundLineTrace, ColorUtils.LinearGreen);
				Singleton<TraceElementCommon>.Instance.SetTraceHitColor(BulletMoveInfo.StickGroundLineTrace, ColorUtils.LinearRed);
			}
		}
		UTraceLineElement stickGroundLineTrace = BulletMoveInfo.StickGroundLineTrace;
		EntityHandle baseTransformEntity = bulletInfo.BaseTransformEntity;
		CharacterActorComponent characterActorComponent;
		if (baseTransformEntity == null)
		{
			characterActorComponent = null;
		}
		else
		{
			WorldEntity entity = baseTransformEntity.Entity;
			characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
		}
		CharacterActorComponent characterActorComponent2 = characterActorComponent;
		vector2.FromUeVector(bulletInfo.GetActorLocation());
		bool flag2 = characterActorComponent2 != null && characterActorComponent2.Valid && !this.BaseLocationOutLimit;
		Vector vector3 = BulletPool.CreateVector(false);
		CharacterMoveComponent attackerMoveComp = bulletInfo.AttackerMoveComp;
		Vector vector4 = ((attackerMoveComp != null) ? attackerMoveComp.GravityUp : null) ?? Vector.UpVectorProxy;
		Vector vector5 = BulletPool.CreateVector(false);
		if (!flag2)
		{
			vector4.Multiply(500.0, vector5);
			vector2.AdditionEqual(vector5);
			vector3.FromUeVector(bulletInfo.GetActorLocation());
		}
		else
		{
			Vector vector6 = vector3;
			FVectorDouble socketLocation = characterActorComponent2.GetSocketLocation(bulletInfo.SkillBoneName ?? FName.NAME_None);
			vector6.FromUeVector(socketLocation);
		}
		double x = vector2.X;
		double y = vector2.Y;
		double z = vector2.Z;
		stickGroundLineTrace.SetStartLocation(x, y, z);
		vector4.Multiply((double)(@base.StickTraceLen + 500f), vector5);
		vector2.SubtractionEqual(vector5);
		double x2 = vector2.X;
		double y2 = vector2.Y;
		double z2 = vector2.Z;
		BulletPool.RecycleVector(vector2);
		stickGroundLineTrace.SetEndLocation(x2, y2, z2);
		bool flag3 = Singleton<TraceElementCommon>.Instance.LineTrace(stickGroundLineTrace, "BulletMoveStickGround");
		UKuroHitResult hitResult = stickGroundLineTrace.HitResult;
		bool flag4 = false;
		double num = double.MaxValue;
		Vector vector7 = BulletPool.CreateVector(false);
		if (flag3)
		{
			int hitCount = hitResult.GetHitCount();
			if (hitCount > 0)
			{
				Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, 0, vector7);
				num = Vector.DistSquared(vector7, vector3);
				int index = 0;
				flag4 = true;
				for (int i = 1; i < hitCount; i++)
				{
					Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, i, vector7);
					double num2 = Vector.DistSquared(vector7, vector3);
					if (num > num2)
					{
						num = num2;
						index = i;
					}
				}
				Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, index, vector);
				bulletInfo.SetActorLocation(vector);
				if (!@base.IgnoreGradient)
				{
					Singleton<TraceElementCommon>.Instance.GetImpactNormal(hitResult, index, vector);
				}
			}
		}
		if (@base.StickWater)
		{
			if (BulletMoveInfo.StickWaterLineTrace == null)
			{
				BulletMoveInfo.StickWaterLineTrace = BulletTraceElementPool.NewTraceElementByTraceChannel<UTraceLineElement>(KuroTraceTypeQuery.Water, false);
			}
			UTraceLineElement stickWaterLineTrace = BulletMoveInfo.StickWaterLineTrace;
			stickWaterLineTrace.SetStartLocation(x, y, z);
			stickWaterLineTrace.SetEndLocation(x2, y2, z2);
			if (Singleton<TraceElementCommon>.Instance.LineTrace(stickWaterLineTrace, "BulletMoveStickWater"))
			{
				UKuroHitResult hitResult2 = stickWaterLineTrace.HitResult;
				int hitCount2 = hitResult2.GetHitCount();
				if (hitCount2 > 0)
				{
					int num3 = -1;
					flag4 = true;
					for (int j = 0; j < hitCount2; j++)
					{
						Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult2, j, vector7);
						double num4 = Vector.DistSquared(vector7, vector3);
						if (num > num4)
						{
							num = num4;
							num3 = j;
						}
					}
					if (num3 > -1)
					{
						Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult2, num3, vector);
						bulletInfo.SetActorLocation(vector);
						if (!@base.IgnoreGradient)
						{
							Singleton<TraceElementCommon>.Instance.GetImpactNormal(hitResult2, num3, vector);
						}
					}
				}
			}
		}
		BulletPool.RecycleVector(vector3);
		BulletPool.RecycleVector(vector7);
		if (flag4)
		{
			if (@base.IgnoreGradient)
			{
				vector.FromUeVector(vector4);
			}
		}
		else
		{
			vector5.FromUeVector(vector4);
			if (characterActorComponent2 != null && characterActorComponent2.Valid)
			{
				vector5.MultiplyEqual((double)characterActorComponent2.ScaledHalfHeight);
				characterActorComponent2.ActorLocationProxy.Subtraction(vector5, vector);
			}
			else
			{
				vector5.MultiplyEqual(bulletInfo.Size.Z);
				bulletInfo.GetActorLocation().Subtraction(vector5, vector);
			}
			bulletInfo.SetActorLocation(vector);
			vector.FromUeVector(vector4);
		}
		if (!@base.IgnoreGradient)
		{
			Rotator rotator = BulletPool.CreateRotator(false);
			Singleton<MathUtils>.Instance.LookRotationUpFirst(Vector.ForwardVectorProxy, vector, rotator);
			bulletInfo.SetActorRotation(rotator);
			if (bulletInfo.AttackerActorComp.ActorRotationProxy.Yaw != 0f)
			{
				rotator.Set(0f, bulletInfo.AttackerActorComp.ActorRotationProxy.Yaw, 0f);
				bulletInfo.AddBulletLocalRotator(rotator.ToUeRotator());
			}
			BulletPool.RecycleRotator(rotator);
		}
		BulletPool.RecycleVector(vector5);
		BulletPool.RecycleVector(vector);
	}

	// Token: 0x06017846 RID: 96326 RVA: 0x00688E30 File Offset: 0x00687030
	private void OnStartStickGroundStandard()
	{
		BulletInfo bulletInfo = this.BulletInfo;
		BulletDataBase @base = this.Data.Base;
		if (!@base.StickGround)
		{
			return;
		}
		Vector vector = BulletPool.CreateVector(false);
		Vector vector2 = BulletPool.CreateVector(false);
		if (BulletMoveInfo.StickGroundLineTrace == null)
		{
			BulletMoveInfo.StickGroundLineTrace = BulletTraceElementPool.NewTraceElementByTraceChannel<UTraceLineElement>(KuroTraceTypeQuery.IkGround, false);
		}
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			bool flag = ModelBase<BulletModel>.Instance.ShowBulletTrace(this.BulletInfo.Attacker.Id);
			EDrawDebugTrace drawDebugTrace = flag ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None;
			BulletMoveInfo.StickGroundLineTrace.SetDrawDebugTrace(drawDebugTrace);
			if (flag)
			{
				Singleton<TraceElementCommon>.Instance.SetTraceColor(BulletMoveInfo.StickGroundLineTrace, ColorUtils.LinearGreen);
				Singleton<TraceElementCommon>.Instance.SetTraceHitColor(BulletMoveInfo.StickGroundLineTrace, ColorUtils.LinearRed);
			}
		}
		UTraceLineElement stickGroundLineTrace = BulletMoveInfo.StickGroundLineTrace;
		EntityHandle baseTransformEntity = bulletInfo.BaseTransformEntity;
		CharacterActorComponent characterActorComponent;
		if (baseTransformEntity == null)
		{
			characterActorComponent = null;
		}
		else
		{
			WorldEntity entity = baseTransformEntity.Entity;
			characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
		}
		CharacterActorComponent characterActorComponent2 = characterActorComponent;
		vector2.FromUeVector(bulletInfo.GetActorLocation());
		double z;
		if (characterActorComponent2 == null || !characterActorComponent2.Valid || this.BaseLocationOutLimit)
		{
			vector2.Z += 500.0;
			z = bulletInfo.GetActorLocation().Z;
		}
		else
		{
			z = characterActorComponent2.GetSocketLocation(bulletInfo.SkillBoneName ?? FName.NAME_None).Z;
		}
		double x = vector2.X;
		double y = vector2.Y;
		double z2 = vector2.Z;
		stickGroundLineTrace.SetStartLocation(x, y, z2);
		vector2.Z -= (double)(@base.StickTraceLen + 500f);
		double x2 = vector2.X;
		double y2 = vector2.Y;
		double z3 = vector2.Z;
		stickGroundLineTrace.SetEndLocation(x2, y2, z3);
		bool flag2 = Singleton<TraceElementCommon>.Instance.LineTrace(stickGroundLineTrace, "BulletMoveStickGround");
		UKuroHitResult hitResult = stickGroundLineTrace.HitResult;
		bool flag3 = false;
		double num = double.MaxValue;
		if (flag2)
		{
			int hitCount = hitResult.GetHitCount();
			if (hitCount > 0)
			{
				num = Math.Abs((double)hitResult.LocationZ_Array.Get(0) - z);
				int index = 0;
				flag3 = true;
				for (int i = 1; i < hitCount; i++)
				{
					double num2 = Math.Abs((double)hitResult.LocationZ_Array.Get(i) - z);
					if (num > num2)
					{
						num = num2;
						index = i;
					}
				}
				Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, index, vector);
				bulletInfo.SetActorLocation(vector);
				if (!@base.IgnoreGradient)
				{
					Singleton<TraceElementCommon>.Instance.GetImpactNormal(hitResult, index, vector);
				}
			}
		}
		if (@base.StickWater)
		{
			if (BulletMoveInfo.StickWaterLineTrace == null)
			{
				BulletMoveInfo.StickWaterLineTrace = BulletTraceElementPool.NewTraceElementByTraceChannel<UTraceLineElement>(KuroTraceTypeQuery.Water, false);
			}
			UTraceLineElement stickWaterLineTrace = BulletMoveInfo.StickWaterLineTrace;
			stickWaterLineTrace.SetStartLocation(x, y, z2);
			stickWaterLineTrace.SetEndLocation(x2, y2, z3);
			if (Singleton<TraceElementCommon>.Instance.LineTrace(stickWaterLineTrace, "BulletMoveStickWater"))
			{
				UKuroHitResult hitResult2 = stickWaterLineTrace.HitResult;
				int hitCount2 = hitResult2.GetHitCount();
				if (hitCount2 > 0)
				{
					int num3 = -1;
					flag3 = true;
					for (int j = 0; j < hitCount2; j++)
					{
						double num4 = Math.Abs((double)hitResult2.LocationZ_Array.Get(j) - z);
						if (num > num4)
						{
							num = num4;
							num3 = j;
						}
					}
					if (num3 > -1)
					{
						Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult2, num3, vector);
						bulletInfo.SetActorLocation(vector);
						if (!@base.IgnoreGradient)
						{
							Singleton<TraceElementCommon>.Instance.GetImpactNormal(hitResult2, num3, vector);
						}
					}
				}
			}
		}
		if (flag3)
		{
			if (@base.IgnoreGradient)
			{
				vector.FromUeVector(Vector.UpVectorProxy);
			}
		}
		else
		{
			if (characterActorComponent2 != null && characterActorComponent2.Valid)
			{
				vector.FromUeVector(characterActorComponent2.ActorLocationProxy);
				vector.Z -= (double)characterActorComponent2.ScaledHalfHeight;
			}
			else
			{
				vector.FromUeVector(bulletInfo.GetActorLocation());
				vector.Z -= bulletInfo.Size.Z;
			}
			bulletInfo.SetActorLocation(vector);
			vector.FromUeVector(Vector.UpVectorProxy);
		}
		Rotator rotator = BulletPool.CreateRotator(false);
		if (!@base.IgnoreGradient)
		{
			Singleton<MathUtils>.Instance.LookRotationUpFirst(Vector.ForwardVectorProxy, vector, rotator);
			bulletInfo.SetActorRotation(rotator);
			if (bulletInfo.AttackerActorComp.ActorRotationProxy.Yaw != 0f)
			{
				rotator.Set(0f, bulletInfo.AttackerActorComp.ActorRotationProxy.Yaw, 0f);
				bulletInfo.AddBulletLocalRotator(rotator.ToUeRotator());
			}
		}
		BulletPool.RecycleVector(vector);
		BulletPool.RecycleVector(vector2);
		BulletPool.RecycleRotator(rotator);
	}

	// Token: 0x0400B465 RID: 46181
	private const float DEFAULT_GRAVITY = -1000f;

	// Token: 0x0400B466 RID: 46182
	private const float DEFAULT_UP_DISTANCE = 500f;

	// Token: 0x0400B467 RID: 46183
	private const string PROFILE_AIMED_TOWARD = "BulletMoveAimedToward";

	// Token: 0x0400B468 RID: 46184
	private const string PROFILE_STICK_GROUND = "BulletMoveStickGround";

	// Token: 0x0400B469 RID: 46185
	private const string PROFILE_STICK_WATER = "BulletMoveStickWater";

	// Token: 0x0400B46A RID: 46186
	private const float MAX_CLAMPED_DIST = 15000f;

	// Token: 0x0400B46B RID: 46187
	[StaticVariableRuleIgnore]
	private static readonly Stat BulletInitMoveBase = Stat.Create("BulletInitMoveBase", "", "");

	// Token: 0x0400B46C RID: 46188
	[StaticVariableRuleIgnore]
	private static readonly Stat BulletInitMoveSpecial = Stat.Create("BulletInitMoveSpecial", "", "");

	// Token: 0x0400B46D RID: 46189
	[Nullable(2)]
	private BulletDataMain Data;

	// Token: 0x0400B46E RID: 46190
	private bool AttackerMeshCompInit;

	// Token: 0x0400B46F RID: 46191
	[Nullable(2)]
	private USkeletalMeshComponent AttackerMeshCompInternal;

	// Token: 0x0400B470 RID: 46192
	[Nullable(2)]
	private BaseActorComponent AttackerActorCompInternal;

	// Token: 0x0400B471 RID: 46193
	private bool BaseLocationOutLimit;
}
