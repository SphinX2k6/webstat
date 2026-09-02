using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Core.Common;
using CSharpScript.Game.Utils;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02002E11 RID: 11793
[NullableContext(1)]
[Nullable(0)]
public class BulletMoveSystem : BulletSystemBase
{
	// Token: 0x06017DA3 RID: 97699 RVA: 0x006AC418 File Offset: 0x006AA618
	public unsafe override void OnTick(float delta)
	{
		OrderedDictionary<int, BulletEntity> bulletEntityMap = ModelBase<BulletModel>.Instance.GetBulletEntityMap();
		double num = 0.0;
		int count = bulletEntityMap.Count;
		int i = 0;
		while (i < count)
		{
			BulletEntity value = bulletEntityMap.GetAt(i).Value;
			if (Singleton<PerformanceController>.Instance.IsEntityTickPerformanceTest)
			{
				num = KuroTime.GetMilliseconds64();
			}
			BulletInfo bulletInfo = value.GetBulletInfo();
			float num2 = bulletInfo.Actor.CustomTimeDilation * bulletInfo.Entity.TimeDilation;
			this.DeltaTime = (float)((double)delta * Singleton<TimeUtil>.Instance.Millisecond * (double)num2);
			if (bulletInfo.NeedDestroy || !bulletInfo.IsInit || bulletInfo.IsFrozen)
			{
				goto IL_1C4;
			}
			if (BulletUtil.CheckBulletAttackerExist(bulletInfo))
			{
				try
				{
					this.UpdateLiveTime(bulletInfo, delta);
					if (!bulletInfo.BulletDataMain.Execution.MovementReplaced)
					{
						this.UpdateAdditiveAccelerate(bulletInfo);
						this.UpdateCompTurn(bulletInfo);
						this.OnTickMove(bulletInfo);
						this.OnTickAttachBulletRotator(bulletInfo);
						bulletInfo.ApplyCacheLocationAndRotation();
					}
					else
					{
						bulletInfo.ActionLogicComponent.ActionTickMovement(delta);
					}
					bulletInfo.MoveInfo.LastFramePosition.FromUeVector(bulletInfo.ActorComponent.ActorLocationProxy);
				}
				catch (Exception ex)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Bullet;
					ELogAuthor author = ELogAuthor.CFT;
					string message = "BulletMoveTick Error";
					Exception error = ex;
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BulletEntityId", bulletInfo.BulletEntityId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BulletRowName", bulletInfo.BulletRowName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("error", ex.Message);
					instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
				goto IL_1C4;
			}
			ControllerBase<BulletController>.Instance.DestroyBullet(bulletInfo.BulletEntityId, false, EBulletDestroyReason.Normal, false);
			IL_1EF:
			i++;
			continue;
			IL_1C4:
			if (Singleton<PerformanceController>.Instance.IsEntityTickPerformanceTest)
			{
				Singleton<PerformanceController>.Instance.CollectTickPerformanceInfo("Bullet", true, KuroTime.GetMilliseconds64() - num, EMeasureMode.Tick, bulletInfo.BornFrameCount);
				goto IL_1EF;
			}
			goto IL_1EF;
		}
	}

	// Token: 0x06017DA4 RID: 97700 RVA: 0x006AC634 File Offset: 0x006AA834
	private void UpdateLiveTime(BulletInfo bulletInfo, float delta)
	{
		if (bulletInfo.CreateFrame == 0 || bulletInfo.CreateFrame == Singleton<Time>.Instance.Frame)
		{
			return;
		}
		AActor actor = bulletInfo.Actor;
		float timeDilation = bulletInfo.Entity.TimeDilation;
		float num = bulletInfo.LiveTime;
		float liveTimeRatio = bulletInfo.LiveTimeRatio;
		if (liveTimeRatio > 0f)
		{
			if (actor == null || !actor.IsValid())
			{
				num += delta * timeDilation * liveTimeRatio;
			}
			else
			{
				num += delta * actor.CustomTimeDilation * timeDilation * liveTimeRatio;
			}
		}
		if (bulletInfo.Duration >= 0f)
		{
			float num2 = bulletInfo.Duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			if (num > num2)
			{
				num = num2;
			}
		}
		bulletInfo.LiveTimeAddDelta = num;
	}

	// Token: 0x06017DA5 RID: 97701 RVA: 0x006AC6E0 File Offset: 0x006AA8E0
	private void UpdateAdditiveAccelerate(BulletInfo bulletInfo)
	{
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		if (!moveInfo.BaseAdditiveAccelerate.IsZero() || moveInfo.AdditiveAccelerateCurve == null)
		{
			return;
		}
		FVector fvector = BulletStaticFunction.CompCurveVector((double)(bulletInfo.LiveTime / (float)Singleton<TimeUtil>.Instance.InverseMillisecond), (double)bulletInfo.Duration, moveInfo.AdditiveAccelerateCurve);
		moveInfo.AdditiveAccelerate.Set(moveInfo.BaseAdditiveAccelerate.X * (double)fvector.X, moveInfo.BaseAdditiveAccelerate.Y * (double)fvector.Y, moveInfo.BaseAdditiveAccelerate.Z * (double)fvector.Z);
	}

	// Token: 0x06017DA6 RID: 97702 RVA: 0x006AC774 File Offset: 0x006AA974
	private void UpdateCompTurn(BulletInfo bulletInfo)
	{
		switch (bulletInfo.BulletDataMain.Move.Trajectory)
		{
		case EMoveTrajectory.默认:
			break;
		case EMoveTrajectory.追踪子弹:
			this.TrackingBullet(bulletInfo);
			return;
		case EMoveTrajectory.限时命中子弹:
			this.TrackingBulletTimeLimit(bulletInfo);
			return;
		case EMoveTrajectory.围绕中心旋转:
			this.RoundBullet(bulletInfo);
			return;
		case EMoveTrajectory.时间限制抛物线子弹:
		case EMoveTrajectory.角度限制抛物线子弹:
		{
			CharacterMoveComponent attackerMoveComp = bulletInfo.AttackerMoveComp;
			if (attackerMoveComp == null || attackerMoveComp.IsStandardGravity)
			{
				this.GravityMoveStandard(bulletInfo);
				return;
			}
			this.GravityMove(bulletInfo);
			break;
		}
		default:
			return;
		}
	}

	// Token: 0x06017DA7 RID: 97703 RVA: 0x006AC7EC File Offset: 0x006AA9EC
	[return: Nullable(2)]
	private BaseActorComponent FindTarget(BulletInfo bulletInfo)
	{
		BaseActorComponent baseActorComponent = null;
		switch (bulletInfo.BulletDataMain.Move.TrackTarget)
		{
		case EBulletTarget.队伍角色:
			baseActorComponent = BulletUtil.GetCurrentRole(bulletInfo);
			break;
		case EBulletTarget.技能目标:
		case EBulletTarget.攻击者锁定目标静态:
		case EBulletTarget.自定义目标:
		case EBulletTarget.子弹发射者:
		case EBulletTarget.父子弹受击者:
		case EBulletTarget.父子弹目标:
		case EBulletTarget.前台角色锁定目标:
		{
			Entity target = bulletInfo.Target;
			baseActorComponent = ((target != null && target.Valid) ? bulletInfo.TargetActorComp : null);
			break;
		}
		case EBulletTarget.攻击者锁定目标动态:
		{
			if (bulletInfo.BulletInitParams.FromRemote)
			{
				return bulletInfo.TargetActorComp;
			}
			baseActorComponent = bulletInfo.GetLockOnTargetDynamic();
			int? num;
			if (baseActorComponent == null)
			{
				num = null;
			}
			else
			{
				Entity entity = baseActorComponent.Entity;
				num = ((entity != null) ? new int?(entity.Id) : null);
			}
			int? num2 = num;
			this.OnChangeTargetRequest(bulletInfo, num2.GetValueOrDefault(-1));
			break;
		}
		case EBulletTarget.技能目标前台:
			baseActorComponent = this.FindSkillTargetRoleControl(bulletInfo);
			break;
		}
		return baseActorComponent;
	}

	// Token: 0x06017DA8 RID: 97704 RVA: 0x006AC8D4 File Offset: 0x006AAAD4
	[return: Nullable(2)]
	private unsafe BaseActorComponent FindSkillTargetRoleControl(BulletInfo bulletInfo)
	{
		Entity target = bulletInfo.Target;
		if (target == null || !target.Valid)
		{
			return null;
		}
		CreatureDataComponent component = target.GetComponent<CreatureDataComponent>();
		if (component == null || !component.IsRole())
		{
			return bulletInfo.TargetActorComp;
		}
		SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)component.GetPlayerId(), new GetTeamItemOptions
		{
			ParamType = ETeamParamType.PlayerId,
			IsControl = new bool?(true)
		});
		if (teamItem != null)
		{
			EntityHandle entityHandle = teamItem.EntityHandle;
			if (entityHandle != null && entityHandle.Valid)
			{
				bulletInfo.SetTargetById(teamItem.EntityHandle.Id);
				return bulletInfo.TargetActorComp;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Bullet;
		ELogAuthor author = ELogAuthor.HCW;
		string message = "找不到技能目标的主控角色";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TeamItem", teamItem == null);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "TeamItemValid";
		bool? flag;
		if (teamItem == null)
		{
			flag = null;
		}
		else
		{
			EntityHandle entityHandle2 = teamItem.EntityHandle;
			flag = ((entityHandle2 != null) ? new bool?(entityHandle2.Valid) : null);
		}
		ptr = new ValueTuple<string, object>(item, flag);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return null;
	}

	// Token: 0x06017DA9 RID: 97705 RVA: 0x006ACA08 File Offset: 0x006AAC08
	private void FollowTargetBullet(BulletInfo bulletInfo)
	{
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		BaseActorComponent baseActorComponent = this.FindTarget(bulletInfo);
		if (baseActorComponent == null || !baseActorComponent.Valid)
		{
			return;
		}
		global::Vector vector = BulletPool.CreateVector(false);
		if (moveInfo.FollowTargetBottom)
		{
			CharacterMoveComponent component = baseActorComponent.Entity.GetComponent<CharacterMoveComponent>();
			FVectorDouble actorLocation = component.ActorComp.ActorLocation;
			float num = Math.Min((float)moveInfo.MinFollowHeight, 1200f);
			float heightAboveGround = component.GetHeightAboveGround(num);
			vector.Set(actorLocation.X, actorLocation.Y, actorLocation.Z - (double)Math.Min(heightAboveGround, num) - (double)component.ActorComp.HalfHeight);
		}
		else
		{
			BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
			string key = (bulletDataMain != null) ? bulletDataMain.Move.TrackTargetBone : null;
			FVectorDouble? targetLocation = BulletUtil.GetTargetLocation(baseActorComponent, FNameUtil.GetDynamicFName(key) ?? FNameUtil.EMPTY, bulletInfo);
			global::Vector vector2 = vector;
			FVectorDouble value = targetLocation.Value;
			vector2.FromUeVector(value);
		}
		if (moveInfo.SpeedFollowTarget < 1.0)
		{
			global::Vector.Lerp(bulletInfo.ActorComponent.ActorLocationProxy, vector, moveInfo.SpeedFollowTarget, moveInfo.LocationFollowTarget);
			bulletInfo.SetActorLocation(moveInfo.LocationFollowTarget);
		}
		else
		{
			bulletInfo.SetActorLocation(vector);
		}
		BulletPool.RecycleVector(vector);
	}

	// Token: 0x06017DAA RID: 97706 RVA: 0x006ACB4C File Offset: 0x006AAD4C
	private void TrackingBulletTimeLimit(BulletInfo bulletInfo)
	{
		FVectorDouble? targetLocation = BulletUtil.GetTargetLocation(this.FindTarget(bulletInfo), bulletInfo.SkillBoneName.Value, bulletInfo);
		if (targetLocation == null)
		{
			return;
		}
		global::Rotator rotator = global::Rotator.Create();
		global::Rotator rotator2 = rotator;
		FVectorDouble actorLocation = bulletInfo.ActorComponent.ActorLocation;
		FVectorDouble value = targetLocation.Value;
		FRotator frotator = UKismetMathLibrary.D_FindLookAtRotation(actorLocation, value);
		rotator2.FromUeRotator(frotator);
		bulletInfo.SetActorRotation(rotator);
	}

	// Token: 0x06017DAB RID: 97707 RVA: 0x006ACBB0 File Offset: 0x006AADB0
	private void TrackingBullet(BulletInfo bulletInfo)
	{
		BulletDataMove move = bulletInfo.BulletDataMain.Move;
		int num = move.TrackParams.Length;
		if (num < 1)
		{
			return;
		}
		BaseActorComponent baseActorComponent = this.FindTarget(bulletInfo);
		FVectorDouble? fvectorDouble = null;
		if (num > 1)
		{
			CharacterMoveComponent characterMoveComponent;
			if (baseActorComponent == null)
			{
				characterMoveComponent = null;
			}
			else
			{
				Entity entity = baseActorComponent.Entity;
				characterMoveComponent = ((entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null);
			}
			CharacterMoveComponent characterMoveComponent2 = characterMoveComponent;
			if (characterMoveComponent2 == null || !characterMoveComponent2.Valid)
			{
				return;
			}
			global::Vector vector = BulletPool.CreateVector(false);
			global::Vector vector2 = BulletPool.CreateVector(false);
			global::Vector inV = move.TrackParams[1];
			vector.FromUeVector(inV);
			double z = vector.Z;
			vector.Z = 0.0;
			CharacterActorComponent actorComp = characterMoveComponent2.ActorComp;
			Singleton<MathUtils>.Instance.TransformPosition(actorComp.ActorLocationProxy, actorComp.ActorRotationProxy, actorComp.ActorScaleProxy, vector, vector2);
			float heightAboveGround = characterMoveComponent2.GetHeightAboveGround(4000f);
			actorComp.ActorUpProxy.Multiply((double)(heightAboveGround + actorComp.ScaledHalfHeight) - z, vector);
			vector2.SubtractionEqual(vector);
			fvectorDouble = new FVectorDouble?(vector2.ToUeVector(false));
			if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug && ModelBase<BulletModel>.Instance.ShowBulletCollision(bulletInfo.AttackerId))
			{
				UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.GameInstance, fvectorDouble.Value, 20f, 10, new FLinearColor?(ColorUtils.LinearGreen), 2f, 4f);
			}
			BulletPool.RecycleVector(vector);
			BulletPool.RecycleVector(vector2);
		}
		else
		{
			BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
			string text = (bulletDataMain != null) ? bulletDataMain.Move.TrackTargetBone : null;
			fvectorDouble = BulletUtil.GetTargetLocation(baseActorComponent, StringUtils.IsNothing(text) ? bulletInfo.SkillBoneName.Value : FNameUtil.GetDynamicFName(text).Value, bulletInfo);
		}
		if (fvectorDouble == null)
		{
			return;
		}
		bool? flag;
		if (baseActorComponent == null)
		{
			flag = null;
		}
		else
		{
			BaseTagComponent component = baseActorComponent.Entity.GetComponent<BaseTagComponent>();
			flag = ((component != null) ? new bool?(component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"])) : null);
		}
		bool? flag2 = flag;
		if (flag2.GetValueOrDefault())
		{
			bulletInfo.OnTargetInValid();
			return;
		}
		if (move.TrackParams[0].X != 0.0)
		{
			this.TrackingBulletRotatorBySingleAngle(bulletInfo, fvectorDouble.Value);
			return;
		}
		if (move.TrackParams[0].Y != 0.0 || move.TrackParams[0].Z != 0.0)
		{
			this.TrackingBulletRotatorByTwoAngle(bulletInfo, fvectorDouble.Value);
		}
	}

	// Token: 0x06017DAC RID: 97708 RVA: 0x006ACE30 File Offset: 0x006AB030
	private void TrackingBulletRotatorBySingleAngle(BulletInfo bulletInfo, FVectorDouble targetLocation)
	{
		global::Vector vector = BulletPool.CreateVector(false);
		vector.FromUeVector(targetLocation);
		vector.SubtractionEqual(bulletInfo.ActorComponent.ActorLocationProxy);
		vector.Normalize(9.999999747378752E-05);
		double d = global::Vector.DotProduct(vector, bulletInfo.ActorComponent.ActorForwardProxy);
		double num = Singleton<MathUtils>.Instance.ClampedAcos(d) * 57.295780181884766;
		BulletPool.RecycleVector(vector);
		if (num <= 0.0)
		{
			return;
		}
		BulletDataMove move = bulletInfo.BulletDataMain.Move;
		double x = move.TrackParams[0].X;
		float val;
		if (move.TrackCurves.Length != 0)
		{
			val = (float)((double)(BulletStaticFunction.CompCurveVector((double)(bulletInfo.LiveTime / (float)Singleton<TimeUtil>.Instance.InverseMillisecond), (double)bulletInfo.Duration, move.TrackCurves[0]).X * this.DeltaTime) * x);
		}
		else
		{
			val = (float)x * this.DeltaTime;
		}
		double num2 = (double)Math.Min((float)num, val);
		FVectorDouble actorLocation = bulletInfo.ActorComponent.ActorLocation;
		FRotator frotator = UKismetMathLibrary.D_FindLookAtRotation(actorLocation, targetLocation);
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		moveInfo.TraceRotator.Set(frotator.Pitch, frotator.Yaw, bulletInfo.ActorComponent.ActorRotation.Roll);
		num = (Singleton<MathUtils>.Instance.IsNearlyZero(num, new double?((double)0.0001f)) ? 9.999999747378752E-05 : num);
		global::Rotator rotator = global::Rotator.Create();
		global::Rotator.Lerp(bulletInfo.ActorComponent.ActorRotationProxy, moveInfo.TraceRotator, (float)(num2 / num), rotator);
		bulletInfo.SetActorRotation(rotator);
	}

	// Token: 0x06017DAD RID: 97709 RVA: 0x006ACFC4 File Offset: 0x006AB1C4
	private void TrackingBulletRotatorByTwoAngle(BulletInfo bulletInfo, FVectorDouble targetLocation)
	{
		BulletDataMove move = bulletInfo.BulletDataMain.Move;
		double y = move.TrackParams[0].Y;
		double z = move.TrackParams[0].Z;
		BulletActorComponent actorComponent = bulletInfo.ActorComponent;
		FVectorDouble actorLocation = actorComponent.ActorLocation;
		FRotator frotator = UKismetMathLibrary.D_FindLookAtRotation(actorLocation, targetLocation);
		float num = frotator.Pitch - actorComponent.ActorRotationProxy.Pitch;
		float num2 = frotator.Yaw - actorComponent.ActorRotationProxy.Yaw;
		if (Math.Abs(num2) > 180f)
		{
			num2 = (360f - Math.Abs(num2)) * (float)Math.Sign(num2) * -1f;
		}
		float num3;
		if ((double)Math.Abs(num2) > z * (double)this.DeltaTime)
		{
			num3 = (float)(z * (double)this.DeltaTime * (double)Math.Sign(num2));
		}
		else
		{
			num3 = num2;
		}
		float num4;
		if (move.TrackCurves.Length != 0)
		{
			FVector fvector = BulletStaticFunction.CompCurveVector((double)(bulletInfo.LiveTime / (float)Singleton<TimeUtil>.Instance.InverseMillisecond), (double)bulletInfo.Duration, move.TrackCurves[0]);
			num3 = (float)((double)(fvector.Z * this.DeltaTime) * z * (double)Math.Sign(num2));
			num4 = (float)((double)(fvector.Y * this.DeltaTime) * y * (double)Math.Sign(num));
		}
		if ((double)Math.Abs(num) > y * (double)this.DeltaTime)
		{
			num4 = (float)(y * (double)this.DeltaTime * (double)Math.Sign(num));
		}
		else
		{
			num4 = num;
		}
		if (Math.Abs(num3) > Math.Abs(num2))
		{
			num3 = num2;
		}
		if (Math.Abs(num4) > Math.Abs(num))
		{
			num4 = num;
		}
		global::Rotator actorRotationProxy = actorComponent.ActorRotationProxy;
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		moveInfo.TraceRotator.Set(actorRotationProxy.Pitch + num4, actorRotationProxy.Yaw + num3, actorRotationProxy.Roll);
		bulletInfo.SetActorRotation(moveInfo.TraceRotator);
	}

	// Token: 0x06017DAE RID: 97710 RVA: 0x006AD1A4 File Offset: 0x006AB3A4
	private unsafe void RoundBullet(BulletInfo bulletInfo)
	{
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		BulletDataMove move = bulletInfo.BulletDataMain.Move;
		double num = move.TrackParams[0].X;
		bool flag = move.TrackCurves.Length != 0;
		if (flag)
		{
			float x = BulletStaticFunction.CompCurveVector((double)(bulletInfo.LiveTime / (float)Singleton<TimeUtil>.Instance.InverseMillisecond), (double)bulletInfo.Duration, move.TrackCurves[0]).X;
			num *= (double)(1f + x);
			if (num < 0.0)
			{
				num = 0.0;
			}
		}
		if (num <= 9.999999747378752E-05)
		{
			global::Vector vector = BulletPool.CreateVector(false);
			vector.FromUeVector(moveInfo.RoundCenter);
			if (move.TrackTarget != EBulletTarget.空 && move.TrackTarget != EBulletTarget.外部传入坐标)
			{
				BaseActorComponent baseActorComponent = this.FindTarget(bulletInfo);
				Entity entity = (baseActorComponent != null) ? baseActorComponent.Entity : null;
				if (entity != null)
				{
					global::Vector vector2 = BulletPool.CreateVector(false);
					bulletInfo.SetTargetById(entity.Id);
					this.UpdateRoundTarget(bulletInfo, bulletInfo.TargetActorComp, vector2);
					vector.AdditionEqual(vector2);
					moveInfo.RoundCenter.AdditionEqual(vector2);
					BulletPool.RecycleVector(vector2);
				}
			}
			bulletInfo.SetActorLocation(vector);
			BulletPool.RecycleVector(vector);
			return;
		}
		global::Vector vector3 = BulletPool.CreateVector(false);
		double num2 = (double)(move.Speed * this.DeltaTime * 57.29578f) / num;
		global::Vector vector4 = BulletPool.CreateVector(false);
		vector4.FromUeVector(moveInfo.RoundCenter);
		global::Vector vector5 = BulletPool.CreateVector(false);
		global::Vector vector6 = (move.TrackParams.Length > 1) ? move.TrackParams[1] : null;
		CharacterMoveComponent attackerMoveComp = bulletInfo.AttackerMoveComp;
		bool flag2 = attackerMoveComp == null || attackerMoveComp.IsStandardGravity;
		if (vector6 != null)
		{
			global::Vector traceParam = move.TrackParams[0];
			if (move.TrackTarget == EBulletTarget.空 || move.TrackTarget == EBulletTarget.外部传入坐标)
			{
				CharacterActorComponent currentRole = BulletUtil.GetCurrentRole(bulletInfo);
				if (currentRole != null && currentRole.Valid)
				{
					BulletUtil.AroundBulletAxisAndBeginVector(traceParam, vector6, moveInfo.RoundOnceAxis, vector3, currentRole, flag2 ? null : bulletInfo.AttackerMoveComp.GravityUp);
				}
				else
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Bullet;
					ELogAuthor author = ELogAuthor.HCW;
					string message = "围绕中心旋转子弹获取不到当前玩家控制的角色";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", bulletInfo.BulletRowName);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
					string item = "Attacker";
					BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
					ptr = new ValueTuple<string, object>(item, (attackerActorComp != null) ? attackerActorComp.Owner : null);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
			else
			{
				BaseActorComponent baseActorComponent2 = this.FindTarget(bulletInfo);
				if (baseActorComponent2 != null && baseActorComponent2.Valid)
				{
					BulletUtil.AroundBulletAxisAndBeginVector(traceParam, vector6, moveInfo.RoundOnceAxis, vector3, baseActorComponent2, flag2 ? null : bulletInfo.AttackerMoveComp.GravityUp);
				}
				else
				{
					BulletUtil.AroundBulletAxisAndBeginVector(traceParam, vector6, moveInfo.RoundOnceAxis, vector3, null, flag2 ? null : bulletInfo.AttackerMoveComp.GravityUp);
				}
			}
			moveInfo.AroundAngle += (float)num2;
			vector3.RotateAngleAxis((double)moveInfo.AroundAngle, moveInfo.RoundOnceAxis, vector5);
			vector5.MultiplyEqual(num);
			vector4.AdditionEqual(vector5);
			vector3.RotateAngleAxis((double)(moveInfo.AroundAngle + 90f), moveInfo.RoundOnceAxis, vector5);
			global::Rotator rotator = BulletPool.CreateRotator(false);
			Singleton<MathUtils>.Instance.LookRotationUpFirst(vector5, moveInfo.RoundOnceAxis, rotator);
			bulletInfo.SetActorRotation(rotator);
			BulletPool.RecycleRotator(rotator);
		}
		else
		{
			vector3.FromUeVector(bulletInfo.ActorComponent.ActorLocationProxy);
			vector3.SubtractionEqual(moveInfo.RoundCenter);
			if (flag)
			{
				vector3.Normalize(9.99999993922529E-09);
				vector3.MultiplyEqual(num);
			}
			vector3.RotateAngleAxis((double)((float)num2), moveInfo.RoundOnceAxis, vector5);
			vector4.AdditionEqual(vector5);
			CharacterMoveComponent attackerMoveComp2 = bulletInfo.AttackerMoveComp;
			if (attackerMoveComp2 == null || attackerMoveComp2.IsStandardGravity)
			{
				global::Rotator rotator2 = global::Rotator.Create();
				global::Rotator rotator3 = rotator2;
				FVectorDouble actorLocation = bulletInfo.ActorComponent.ActorLocation;
				FVectorDouble fvectorDouble = vector4.ToUeVector(false);
				FRotator frotator = UKismetMathLibrary.D_FindLookAtRotation(actorLocation, fvectorDouble);
				rotator3.FromUeRotator(frotator);
				bulletInfo.SetActorRotation(rotator2);
			}
			else
			{
				global::Vector vector7 = BulletPool.CreateVector(false);
				vector7.FromUeVector(bulletInfo.GetActorLocation());
				vector7.SubtractionEqual(moveInfo.RoundCenter);
				vector7.Normalize(9.99999993922529E-09);
				global::Rotator rotator4 = BulletPool.CreateRotator(false);
				Singleton<MathUtils>.Instance.LookRotationUpFirst(vector7, moveInfo.RoundOnceAxis, rotator4);
				bulletInfo.SetActorRotation(rotator4);
				BulletPool.RecycleRotator(rotator4);
				BulletPool.RecycleVector(vector7);
			}
		}
		if (move.TrackTarget != EBulletTarget.空 && move.TrackTarget != EBulletTarget.外部传入坐标)
		{
			BaseActorComponent baseActorComponent3 = this.FindTarget(bulletInfo);
			Entity entity2 = (baseActorComponent3 != null) ? baseActorComponent3.Entity : null;
			if (entity2 != null)
			{
				global::Vector vector8 = BulletPool.CreateVector(false);
				bulletInfo.SetTargetById(entity2.Id);
				this.UpdateRoundTarget(bulletInfo, bulletInfo.TargetActorComp, vector8);
				vector4.AdditionEqual(vector8);
				moveInfo.RoundCenter.AdditionEqual(vector8);
				BulletPool.RecycleVector(vector8);
			}
		}
		bulletInfo.SetActorLocation(vector4);
		BulletPool.RecycleVector(vector3);
		BulletPool.RecycleVector(vector4);
		BulletPool.RecycleVector(vector5);
	}

	// Token: 0x06017DAF RID: 97711 RVA: 0x006AD68C File Offset: 0x006AB88C
	private void UpdateRoundTarget(BulletInfo bulletInfo, BaseActorComponent target, global::Vector outVector)
	{
		global::Vector actorLocationProxy = target.ActorLocationProxy;
		outVector.FromUeVector(actorLocationProxy);
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		outVector.SubtractionEqual(moveInfo.RoundCenterLastLocation);
		moveInfo.RoundCenterLastLocation.FromUeVector(actorLocationProxy);
	}

	// Token: 0x06017DB0 RID: 97712 RVA: 0x006AD6C8 File Offset: 0x006AB8C8
	private void GravityMove(BulletInfo bulletInfo)
	{
		global::Vector[] trackParams = bulletInfo.BulletDataMain.Move.TrackParams;
		if (trackParams == null || trackParams.Length < 2)
		{
			return;
		}
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		moveInfo.BulletSpeedZ += moveInfo.Gravity * this.DeltaTime * moveInfo.BulletSpeedRatio;
		moveInfo.BulletSpeed = MathF.Sqrt(MathF.Pow(moveInfo.BulletSpeed2D, 2f) + MathF.Pow(moveInfo.BulletSpeedZ, 2f));
		global::Vector vector = BulletPool.CreateVector(false);
		global::Vector vector2 = BulletPool.CreateVector(false);
		moveInfo.GravityMoveForward.Multiply((double)moveInfo.BulletSpeed2D, vector);
		CharacterMoveComponent attackerMoveComp = bulletInfo.AttackerMoveComp;
		(((attackerMoveComp != null) ? attackerMoveComp.GravityUp : null) ?? global::Vector.UpVectorProxy).Multiply((double)moveInfo.BulletSpeedZ, vector2);
		vector.AdditionEqual(vector2);
		vector.Normalize(9.99999993922529E-09);
		global::Rotator gravityMoveRotator = moveInfo.GravityMoveRotator;
		vector.Rotation(gravityMoveRotator);
		BulletDataMove move = bulletInfo.BulletDataMain.Move;
		if (!move.InitVelocityRot.IsNearlyZero())
		{
			global::Rotator rotator = BulletPool.CreateRotator(false);
			rotator.FromUeRotator(gravityMoveRotator);
			Singleton<MathUtils>.Instance.ComposeRotator(move.InitVelocityRot, rotator, gravityMoveRotator);
			BulletPool.RecycleRotator(rotator);
		}
		BulletPool.RecycleVector(vector);
		BulletPool.RecycleVector(vector2);
		if (moveInfo.ActorRotateParabola)
		{
			bulletInfo.SetActorRotation(moveInfo.GravityMoveRotator);
		}
	}

	// Token: 0x06017DB1 RID: 97713 RVA: 0x006AD820 File Offset: 0x006ABA20
	private void GravityMoveStandard(BulletInfo bulletInfo)
	{
		global::Vector[] trackParams = bulletInfo.BulletDataMain.Move.TrackParams;
		if (trackParams != null && trackParams.Length < 2)
		{
			return;
		}
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		moveInfo.BulletSpeedZ += moveInfo.Gravity * this.DeltaTime * moveInfo.BulletSpeedRatio;
		moveInfo.BulletSpeed = MathF.Sqrt(MathF.Pow(moveInfo.BulletSpeed2D, 2f) + MathF.Pow(moveInfo.BulletSpeedZ, 2f));
		global::Rotator gravityMoveRotator = moveInfo.GravityMoveRotator;
		gravityMoveRotator.Set((float)(Math.Atan((double)(moveInfo.BulletSpeedZ / moveInfo.BulletSpeed2D)) * 57.295780181884766), gravityMoveRotator.Yaw, gravityMoveRotator.Roll);
		if (moveInfo.ActorRotateParabola)
		{
			bulletInfo.SetActorRotation(gravityMoveRotator);
		}
	}

	// Token: 0x06017DB2 RID: 97714 RVA: 0x006AD8E8 File Offset: 0x006ABAE8
	private unsafe void OnTickMove(BulletInfo bulletInfo)
	{
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		BulletDataMove move = bulletInfo.BulletDataMain.Move;
		float num;
		if (move.SpeedCurve != null)
		{
			if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug && !move.SpeedCurve.IsValid())
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Obj Refs Name=DelayBulletSpeed", null);
			}
			num = BulletStaticFunction.CompCurveFloat(bulletInfo.LiveTime * 0.001f, bulletInfo.Duration, move.SpeedCurve) * moveInfo.BulletSpeed;
		}
		else
		{
			num = moveInfo.BulletSpeed;
		}
		float num2 = bulletInfo.Duration;
		global::Vector vector = BulletPool.CreateVector(false);
		switch (move.Trajectory)
		{
		case EMoveTrajectory.追踪子弹:
			bulletInfo.GetActorForward(vector);
			vector.MultiplyEqual((double)(num * this.DeltaTime));
			break;
		case EMoveTrajectory.限时命中子弹:
		{
			if (move.TrackParams.Length != 0 && move.TrackParams[0].X > 0.0)
			{
				num2 = (float)move.TrackParams[0].X;
			}
			FVectorDouble? targetLocation = BulletUtil.GetTargetLocation(bulletInfo.TargetActorComp, bulletInfo.SkillBoneName.Value, bulletInfo);
			if (targetLocation != null)
			{
				double num3 = (double)num2 - (Singleton<Time>.Instance.WorldTime - (double)bulletInfo.GenerateTime) / (double)Singleton<TimeUtil>.Instance.InverseMillisecond;
				double num4 = Singleton<MathUtils>.Instance.IsNearlyZero(num3, new double?((double)0.0001f)) ? 9.999999747378752E-05 : num3;
				global::Vector vector2 = BulletPool.CreateVector(false);
				global::Vector vector3 = vector2;
				FVectorDouble value = targetLocation.Value;
				vector3.FromUeVector(value);
				num = (float)(global::Vector.Dist(bulletInfo.ActorComponent.ActorLocationProxy, vector2) / num4);
				BulletPool.RecycleVector(vector2);
				if (num < move.Speed)
				{
					num = move.Speed;
				}
				moveInfo.UpdateDirVector.Set((double)(num * this.DeltaTime), 0.0, 0.0);
				bulletInfo.ActorRotateVector(moveInfo.UpdateDirVector, vector);
			}
			else
			{
				num = moveInfo.BulletSpeed;
				moveInfo.BeginSpeedRotator.Vector(vector);
				vector.MultiplyEqual((double)(num * this.DeltaTime));
			}
			break;
		}
		case EMoveTrajectory.围绕中心旋转:
			BulletPool.RecycleVector(vector);
			return;
		case EMoveTrajectory.时间限制抛物线子弹:
		case EMoveTrajectory.角度限制抛物线子弹:
			moveInfo.GravityMoveRotator.Quaternion(null).RotateVector(global::Vector.ForwardVectorProxy, vector);
			vector.MultiplyEqual((double)(num * this.DeltaTime));
			break;
		case EMoveTrajectory.跟随目标:
			this.FollowTargetBullet(bulletInfo);
			BulletPool.RecycleVector(vector);
			return;
		default:
			moveInfo.BeginSpeedRotator.Vector(vector);
			vector.MultiplyEqual((double)(num * this.DeltaTime));
			break;
		}
		vector.MultiplyEqual((double)moveInfo.BulletSpeedRatio);
		if (!moveInfo.BaseAdditiveAccelerate.IsZero())
		{
			global::Vector vector4 = BulletPool.CreateVector(false);
			moveInfo.V0.Multiply((double)this.DeltaTime, vector4);
			global::Vector vector5 = BulletPool.CreateVector(false);
			moveInfo.AdditiveAccelerate.Multiply((double)(0.5f * this.DeltaTime * this.DeltaTime), vector5);
			vector4.AdditionEqual(vector5);
			vector.AdditionEqual(vector4);
			global::Vector vector6 = BulletPool.CreateVector(false);
			moveInfo.AdditiveAccelerate.Multiply((double)this.DeltaTime, vector6);
			moveInfo.V0.AdditionEqual(vector6);
			BulletPool.RecycleVector(vector4);
			BulletPool.RecycleVector(vector5);
			BulletPool.RecycleVector(vector6);
		}
		moveInfo.BulletSpeedDir.FromUeVector(vector);
		this.AddWorldOffset(bulletInfo, vector);
		if (Singleton<BulletConstant>.Instance.OpenMoveLog)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "OnTickMove";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Bullet", bulletInfo.BulletRowName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("finalDirMove", vector);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Location", bulletInfo.GetActorLocation());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		BulletPool.RecycleVector(vector);
		this.OnTickIfReached(bulletInfo, moveInfo, move.TrackTarget);
	}

	// Token: 0x06017DB3 RID: 97715 RVA: 0x006ADCD4 File Offset: 0x006ABED4
	private void OnTickIfReached(BulletInfo bulletInfo, BulletMoveInfo moveInfo, EBulletTarget trackTarget)
	{
		if (trackTarget == EBulletTarget.外部传入坐标)
		{
			EMoveTrajectory trajectory = bulletInfo.BulletDataMain.Move.Trajectory;
			if (trajectory == EMoveTrajectory.角度限制抛物线子弹 || trajectory == EMoveTrajectory.时间限制抛物线子弹)
			{
				return;
			}
			global::Vector vector = BulletPool.CreateVector(false);
			global::Vector vector2 = vector;
			FVectorDouble value = BulletUtil.GetTargetLocation(null, FNameUtil.NONE, bulletInfo).Value;
			vector2.FromUeVector(value);
			double num = moveInfo.BulletSpeedDir.SizeSquared();
			if (global::Vector.DistSquared(bulletInfo.GetActorLocation(), vector) < num)
			{
				bulletInfo.IsTimeNotEnough = true;
				if (bulletInfo != null)
				{
					bulletInfo.SetActorLocation(vector);
				}
				ControllerBase<BulletController>.Instance.DestroyBullet(bulletInfo.BulletEntityId, false, EBulletDestroyReason.Normal, false);
			}
			BulletPool.RecycleVector(vector);
		}
	}

	// Token: 0x06017DB4 RID: 97716 RVA: 0x006ADD70 File Offset: 0x006ABF70
	private void AddWorldOffset(BulletInfo bulletInfo, global::Vector dirMove)
	{
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		if (moveInfo.IsOnBaseMovement)
		{
			global::Vector vector = BulletPool.CreateVector(false);
			vector.FromUeVector(moveInfo.LastBaseMovementSpeed);
			vector.MultiplyEqual((double)this.DeltaTime);
			dirMove.AdditionEqual(vector);
			BulletPool.RecycleVector(vector);
		}
		if (!dirMove.Equals(global::Vector.ZeroVectorProxy, 9.999999747378752E-05))
		{
			global::Vector vector2 = BulletPool.CreateVector(false);
			bulletInfo.ActorComponent.ActorLocationProxy.Addition(dirMove, vector2);
			bulletInfo.SetActorLocation(vector2);
			BulletPool.RecycleVector(vector2);
		}
	}

	// Token: 0x06017DB5 RID: 97717 RVA: 0x006ADDF8 File Offset: 0x006ABFF8
	private void OnTickAttachBulletRotator(BulletInfo bulletInfo)
	{
		BulletDataMove move = bulletInfo.BulletDataMain.Move;
		EBulletFollowType followType = move.FollowType;
		if (followType != EBulletFollowType.跟随骨骼 && followType != EBulletFollowType.跟随骨骼位置旋转)
		{
			return;
		}
		global::Vector vector = BulletPool.CreateVector(false);
		vector.FromUeVector(move.FollowSkeletonRotLimit);
		if (vector.IsZero())
		{
			BulletPool.RecycleVector(vector);
			return;
		}
		BulletMoveInfo moveInfo = bulletInfo.MoveInfo;
		global::Rotator actorRotationProxy = bulletInfo.ActorComponent.ActorRotationProxy;
		if (vector.X < 1.0)
		{
			moveInfo.FollowBoneBulletRotator.Roll = actorRotationProxy.Roll;
		}
		else
		{
			moveInfo.FollowBoneBulletRotator.Roll = 0f;
		}
		if (vector.Y < 1.0)
		{
			moveInfo.FollowBoneBulletRotator.Pitch = actorRotationProxy.Pitch;
		}
		else
		{
			moveInfo.FollowBoneBulletRotator.Pitch = 0f;
		}
		if (vector.Z < 1.0)
		{
			moveInfo.FollowBoneBulletRotator.Yaw = actorRotationProxy.Yaw;
		}
		else
		{
			moveInfo.FollowBoneBulletRotator.Yaw = bulletInfo.AttackerActorComp.ActorRotationProxy.Yaw;
		}
		BulletPool.RecycleVector(vector);
		bulletInfo.SetActorRotation(moveInfo.FollowBoneBulletRotator);
	}

	// Token: 0x06017DB6 RID: 97718 RVA: 0x006ADF14 File Offset: 0x006AC114
	public unsafe void OnChangeTargetRequest(BulletInfo bulletInfo, int targetId)
	{
		if (bulletInfo.TargetIdLast == targetId)
		{
			return;
		}
		bulletInfo.SetTargetById(targetId);
		if (!ModelBase<GameModeModel>.Instance.IsMulti || bulletInfo.BulletInitParams.FromRemote)
		{
			return;
		}
		if (bulletInfo.BulletDataMain.Base.SyncType != EBulletSyncTypeTs.Remote)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "动态改变目标的子弹必须设置 基础设置.网络同步类型 为 网络同步子弹";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BulletId", bulletInfo.BulletRowName);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "Attacker";
			BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
			ptr = new ValueTuple<string, object>(item, (attackerActorComp != null) ? attackerActorComp.Owner : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		ActiveBulletHandle bulletHandleById = ModelBase<BulletModel>.Instance.GetBulletHandleById(bulletInfo.BulletEntityId);
		long creatureDataId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(targetId);
		ModifyBulletParamsPush modifyBulletParamsPush = ModifyBulletParamsPush.Create();
		modifyBulletParamsPush.ModifyBulletParams = new ModifyBulletParams
		{
			CombatCommon = null,
			Handle = bulletHandleById,
			TargetId = creatureDataId
		};
		Singleton<CombatNet>.Instance.Send(EPushMessageId.ModifyBulletParamsPush, bulletInfo.Attacker, modifyBulletParamsPush, null, null, null);
		bulletInfo.TargetIdLast = targetId;
	}

	// Token: 0x0400B90C RID: 47372
	private const float MIN_HEIGHT_FOLLOW_TARGET = 1200f;

	// Token: 0x0400B90D RID: 47373
	[StaticVariableRuleIgnore]
	private static readonly Stat TickStat = Stat.Create("BulletMoveTick", "", "");

	// Token: 0x0400B90E RID: 47374
	private float DeltaTime;
}
