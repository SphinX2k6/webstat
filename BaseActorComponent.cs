using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200321D RID: 12829
[NullableContext(1)]
[Nullable(0)]
public class BaseActorComponent : EntityComponent
{
	// Token: 0x17002409 RID: 9225
	// (get) Token: 0x0601AA7B RID: 109179 RVA: 0x007EDA20 File Offset: 0x007EBC20
	public float ScaledRadius
	{
		get
		{
			return (float)((double)this.RadiusInternal * this.ActorScaleProxy.X);
		}
	}

	// Token: 0x1700240A RID: 9226
	// (get) Token: 0x0601AA7C RID: 109180 RVA: 0x007EDA36 File Offset: 0x007EBC36
	public float Radius
	{
		get
		{
			return this.RadiusInternal;
		}
	}

	// Token: 0x1700240B RID: 9227
	// (get) Token: 0x0601AA7D RID: 109181 RVA: 0x007EDA3E File Offset: 0x007EBC3E
	public float ScaledHalfHeight
	{
		get
		{
			return (float)((double)this.HalfHeightInternal * this.ActorScaleProxy.Z);
		}
	}

	// Token: 0x1700240C RID: 9228
	// (get) Token: 0x0601AA7E RID: 109182 RVA: 0x007EDA54 File Offset: 0x007EBC54
	public float HalfHeight
	{
		get
		{
			return this.HalfHeightInternal;
		}
	}

	// Token: 0x1700240D RID: 9229
	// (get) Token: 0x0601AA7F RID: 109183 RVA: 0x007EDA5C File Offset: 0x007EBC5C
	public float DefaultRadius
	{
		get
		{
			return this.DefaultRadiusInternal;
		}
	}

	// Token: 0x1700240E RID: 9230
	// (get) Token: 0x0601AA80 RID: 109184 RVA: 0x007EDA64 File Offset: 0x007EBC64
	public float DefaultHalfHeight
	{
		get
		{
			return this.DefaultHalfHeightInternal;
		}
	}

	// Token: 0x0601AA81 RID: 109185 RVA: 0x007EDA6C File Offset: 0x007EBC6C
	protected virtual void InitSizeInternal()
	{
	}

	// Token: 0x1700240F RID: 9231
	// (get) Token: 0x0601AA82 RID: 109186 RVA: 0x007EDA6E File Offset: 0x007EBC6E
	public bool IsAutonomousProxy
	{
		get
		{
			return this.LogicAutonomous;
		}
	}

	// Token: 0x17002410 RID: 9232
	// (get) Token: 0x0601AA83 RID: 109187 RVA: 0x007EDA76 File Offset: 0x007EBC76
	public bool IsMoveAutonomousProxy
	{
		get
		{
			return this.MoveAutonomous;
		}
	}

	// Token: 0x0601AA84 RID: 109188 RVA: 0x007EDA80 File Offset: 0x007EBC80
	[NullableContext(2)]
	protected override bool OnCreate(IEntityArgs args = null)
	{
		this.DisableActorHandle = new DisableEntityHandle("SetActorHiddenInGame");
		this.DisableCollisionHandle = new DisableEntityHandle("SetActorEnableCollision");
		base.AddUnResetProperty(new string[]
		{
			"DisableActorHandle",
			"DisableCollisionHandle",
			"DisableTickHandle"
		});
		return true;
	}

	// Token: 0x0601AA85 RID: 109189 RVA: 0x007EDAD4 File Offset: 0x007EBCD4
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		this.CachedActorForward.Set(1.0, 0.0, 0.0);
		this.CachedActorRight.Set(0.0, 1.0, 0.0);
		this.CachedActorUp.Set(0.0, 0.0, 1.0);
		return true;
	}

	// Token: 0x0601AA86 RID: 109190 RVA: 0x007EDB54 File Offset: 0x007EBD54
	protected override bool OnStart()
	{
		this.MoveComp = base.Entity.GetComponent<BaseMoveComponent>();
		this.VehicleMoveComp = base.Entity.GetComponent<VehicleMoveComponent>();
		this.Handle = ModelBase<CreatureModel>.Instance.GetEntityById(base.Entity.Id);
		return true;
	}

	// Token: 0x0601AA87 RID: 109191 RVA: 0x007EDB94 File Offset: 0x007EBD94
	protected override void OnActivate()
	{
		this.ActorInternal.Kuro_SetRole(this.MoveAutonomous ? EKuroNetRole.KURO_ROLE_AutonomousProxy : EKuroNetRole.KURO_ROLE_SimulatedProxy);
		this.LastActorLocation.DeepCopy(this.ActorLocationProxy);
		this.LastActorRotation.DeepCopy(this.ActorRotationProxy);
		this.ActorInternal.SetActorHiddenInGame(!this.DisableActorHandle.Empty);
		this.ActorInternal.SetActorEnableCollision(this.DisableCollisionHandle.Empty);
	}

	// Token: 0x0601AA88 RID: 109192 RVA: 0x007EDC09 File Offset: 0x007EBE09
	protected override bool OnEnd()
	{
		this.ClearDebugLocationCube();
		return true;
	}

	// Token: 0x0601AA89 RID: 109193 RVA: 0x007EDC12 File Offset: 0x007EBE12
	public virtual void SetAutonomous(bool logicAutonomous, bool? moveAutonomous = null)
	{
		this.LogicAutonomous = logicAutonomous;
		this.SetMoveAutonomous(moveAutonomous.GetValueOrDefault(logicAutonomous), "切换逻辑主控");
	}

	// Token: 0x0601AA8A RID: 109194 RVA: 0x007EDC2E File Offset: 0x007EBE2E
	protected virtual void SetMoveAutonomous(bool moveAutonomous, string reason = "")
	{
		this.MoveAutonomous = moveAutonomous;
		AActor actorInternal = this.ActorInternal;
		if (actorInternal == null)
		{
			return;
		}
		actorInternal.Kuro_SetRole(this.MoveAutonomous ? EKuroNetRole.KURO_ROLE_AutonomousProxy : EKuroNetRole.KURO_ROLE_SimulatedProxy);
	}

	// Token: 0x0601AA8B RID: 109195 RVA: 0x007EDC53 File Offset: 0x007EBE53
	public virtual void SetMoveControlled(bool controlled, double maxControlTime = 2.0, string reason = "")
	{
		this.SetMoveAutonomous(controlled, reason);
	}

	// Token: 0x0601AA8C RID: 109196 RVA: 0x007EDC5D File Offset: 0x007EBE5D
	public virtual void ResetMoveControlled(string reason = "")
	{
		this.SetMoveAutonomous(this.IsAutonomousProxy, reason);
	}

	// Token: 0x0601AA8D RID: 109197 RVA: 0x007EDC6C File Offset: 0x007EBE6C
	protected bool InitCreatureData()
	{
		this.CreatureDataInternal = base.Entity.GetComponent<CreatureDataComponent>();
		CreatureDataComponent creatureDataInternal = this.CreatureDataInternal;
		if (creatureDataInternal == null || !creatureDataInternal.Valid)
		{
			Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.LFJW, "creature数据加载失败。", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return true;
	}

	// Token: 0x17002411 RID: 9233
	// (get) Token: 0x0601AA8E RID: 109198 RVA: 0x007EDCBF File Offset: 0x007EBEBF
	public CreatureDataComponent CreatureData
	{
		get
		{
			return this.CreatureDataInternal;
		}
	}

	// Token: 0x17002412 RID: 9234
	// (get) Token: 0x0601AA8F RID: 109199 RVA: 0x007EDCC7 File Offset: 0x007EBEC7
	public FQuat ActorQuat
	{
		get
		{
			return this.ActorQuatProxy.ToUeQuat();
		}
	}

	// Token: 0x17002413 RID: 9235
	// (get) Token: 0x0601AA90 RID: 109200 RVA: 0x007EDCD4 File Offset: 0x007EBED4
	public Quat ActorQuatProxy
	{
		get
		{
			if (this.CachedRotationTime < Singleton<Time>.Instance.Frame)
			{
				AActor actorInternal = this.ActorInternal;
				if (actorInternal != null && actorInternal.IsValid())
				{
					this.CachedRotationTime = Singleton<Time>.Instance.Frame;
					global::Rotator cachedActorRotation = this.CachedActorRotation;
					FRotator frotator = this.ActorInternal.K2_GetActorRotation();
					cachedActorRotation.DeepCopy(frotator);
					this.CachedActorRotation.Quaternion(this.CachedActorQuat);
				}
			}
			return this.CachedActorQuat;
		}
	}

	// Token: 0x17002414 RID: 9236
	// (get) Token: 0x0601AA91 RID: 109201 RVA: 0x007EDD48 File Offset: 0x007EBF48
	public global::Rotator ActorRotationProxy
	{
		get
		{
			if (this.CachedRotationTime < Singleton<Time>.Instance.Frame)
			{
				AActor actorInternal = this.ActorInternal;
				if (actorInternal != null && actorInternal.IsValid())
				{
					this.CachedRotationTime = Singleton<Time>.Instance.Frame;
					global::Rotator cachedActorRotation = this.CachedActorRotation;
					FRotator frotator = this.ActorInternal.K2_GetActorRotation();
					cachedActorRotation.DeepCopy(frotator);
					this.CachedActorRotation.Quaternion(this.CachedActorQuat);
				}
			}
			return this.CachedActorRotation;
		}
	}

	// Token: 0x17002415 RID: 9237
	// (get) Token: 0x0601AA92 RID: 109202 RVA: 0x007EDDBC File Offset: 0x007EBFBC
	public FRotator ActorRotation
	{
		get
		{
			return this.ActorRotationProxy.ToUeRotator();
		}
	}

	// Token: 0x17002416 RID: 9238
	// (get) Token: 0x0601AA93 RID: 109203 RVA: 0x007EDDCC File Offset: 0x007EBFCC
	public global::Vector ActorScaleProxy
	{
		get
		{
			if (this.CachedScaleTime <= 0)
			{
				AActor actorInternal = this.ActorInternal;
				if (actorInternal != null && actorInternal.IsValid())
				{
					this.CachedScaleTime = 1;
					global::Vector cachedActorScale = this.CachedActorScale;
					FVectorDouble fvectorDouble = this.ActorInternal.D_GetActorScale3D();
					cachedActorScale.FromUeVector(fvectorDouble);
				}
			}
			return this.CachedActorScale;
		}
	}

	// Token: 0x17002417 RID: 9239
	// (get) Token: 0x0601AA94 RID: 109204 RVA: 0x007EDE1C File Offset: 0x007EC01C
	public FVectorDouble ActorScale
	{
		get
		{
			return this.ActorScaleProxy.ToUeVector(false);
		}
	}

	// Token: 0x17002418 RID: 9240
	// (get) Token: 0x0601AA95 RID: 109205 RVA: 0x007EDE2C File Offset: 0x007EC02C
	public FTransformDouble? ActorTransformOrNull
	{
		get
		{
			if (this.CachedTransformTime < Singleton<Time>.Instance.Frame)
			{
				AActor actorInternal = this.ActorInternal;
				if (actorInternal != null && actorInternal.IsValid())
				{
					this.CachedTransformTime = Singleton<Time>.Instance.Frame;
					this.CachedActorTransform = new FTransformDouble?(this.ActorInternal.D_GetTransform());
				}
			}
			return this.CachedActorTransform;
		}
	}

	// Token: 0x17002419 RID: 9241
	// (get) Token: 0x0601AA96 RID: 109206 RVA: 0x007EDE8C File Offset: 0x007EC08C
	public FTransformDouble ActorTransform
	{
		get
		{
			FTransformDouble? actorTransformOrNull = this.ActorTransformOrNull;
			if (actorTransformOrNull == null)
			{
				return new FTransformDouble();
			}
			return actorTransformOrNull.GetValueOrDefault();
		}
	}

	// Token: 0x1700241A RID: 9242
	// (get) Token: 0x0601AA97 RID: 109207 RVA: 0x007EDEB6 File Offset: 0x007EC0B6
	public FVectorDouble ActorLocation
	{
		get
		{
			return this.ActorLocationProxy.ToUeVector(false);
		}
	}

	// Token: 0x1700241B RID: 9243
	// (get) Token: 0x0601AA98 RID: 109208 RVA: 0x007EDEC4 File Offset: 0x007EC0C4
	public virtual global::Vector ActorLocationProxy
	{
		get
		{
			if (this.IsChangingLocation)
			{
				return this.CachedDesiredActorLocation;
			}
			if (this.CachedLocationTime < Singleton<Time>.Instance.Frame)
			{
				AActor actorInternal = this.ActorInternal;
				if (actorInternal != null && actorInternal.IsValid())
				{
					this.CachedLocationTime = Singleton<Time>.Instance.Frame;
					global::Vector cachedActorLocation = this.CachedActorLocation;
					FVectorDouble fvectorDouble = this.ActorInternal.D_K2_GetActorLocation();
					cachedActorLocation.FromUeVector(fvectorDouble);
				}
			}
			return this.CachedActorLocation;
		}
	}

	// Token: 0x0601AA99 RID: 109209 RVA: 0x007EDF35 File Offset: 0x007EC135
	[Conditional("NO_SUPPORT")]
	protected void SetCachedActorLocationWritable(bool canWrite)
	{
		bool isPlayInEditor = GlobalData.IsPlayInEditor;
	}

	// Token: 0x1700241C RID: 9244
	// (get) Token: 0x0601AA9A RID: 109210 RVA: 0x007EDF3D File Offset: 0x007EC13D
	public global::Vector ActorLocationProxyNoUpdate
	{
		get
		{
			if (this.CachedLocationTime <= 0)
			{
				return this.ActorLocationProxy;
			}
			return this.CachedActorLocation;
		}
	}

	// Token: 0x1700241D RID: 9245
	// (get) Token: 0x0601AA9B RID: 109211 RVA: 0x007EDF55 File Offset: 0x007EC155
	public global::Vector ActorForwardProxy
	{
		get
		{
			if (this.CachedForwardTime < Singleton<Time>.Instance.Frame)
			{
				this.CachedForwardTime = Singleton<Time>.Instance.Frame;
				this.ActorQuatProxy.RotateVector(global::Vector.ForwardVectorProxy, this.CachedActorForward);
			}
			return this.CachedActorForward;
		}
	}

	// Token: 0x1700241E RID: 9246
	// (get) Token: 0x0601AA9C RID: 109212 RVA: 0x007EDF95 File Offset: 0x007EC195
	public FVectorDouble ActorRight
	{
		get
		{
			return this.ActorRightProxy.ToUeVector(false);
		}
	}

	// Token: 0x1700241F RID: 9247
	// (get) Token: 0x0601AA9D RID: 109213 RVA: 0x007EDFA3 File Offset: 0x007EC1A3
	public global::Vector ActorRightProxy
	{
		get
		{
			if (this.CachedRightTime < Singleton<Time>.Instance.Frame)
			{
				this.CachedRightTime = Singleton<Time>.Instance.Frame;
				this.ActorQuatProxy.RotateVector(global::Vector.RightVectorProxy, this.CachedActorRight);
			}
			return this.CachedActorRight;
		}
	}

	// Token: 0x17002420 RID: 9248
	// (get) Token: 0x0601AA9E RID: 109214 RVA: 0x007EDFE3 File Offset: 0x007EC1E3
	public FVectorDouble ActorForward
	{
		get
		{
			return this.ActorForwardProxy.ToUeVector(false);
		}
	}

	// Token: 0x17002421 RID: 9249
	// (get) Token: 0x0601AA9F RID: 109215 RVA: 0x007EDFF1 File Offset: 0x007EC1F1
	public global::Vector ActorUpProxy
	{
		get
		{
			if (this.CachedUpTime < Singleton<Time>.Instance.Frame)
			{
				this.CachedUpTime = Singleton<Time>.Instance.Frame;
				this.ActorQuatProxy.RotateVector(global::Vector.UpVectorProxy, this.CachedActorUp);
			}
			return this.CachedActorUp;
		}
	}

	// Token: 0x17002422 RID: 9250
	// (get) Token: 0x0601AAA0 RID: 109216 RVA: 0x007EE031 File Offset: 0x007EC231
	public FVectorDouble ActorUp
	{
		get
		{
			return this.ActorUpProxy.ToUeVector(false);
		}
	}

	// Token: 0x17002423 RID: 9251
	// (get) Token: 0x0601AAA1 RID: 109217 RVA: 0x007EE040 File Offset: 0x007EC240
	public virtual global::Vector ActorGravityDirectProxy
	{
		get
		{
			if (this.CachedGravityDirectTime < Singleton<Time>.Instance.Frame)
			{
				this.CachedGravityDirectTime = Singleton<Time>.Instance.Frame;
				if (this.VehicleMoveComp != null)
				{
					this.CachedActorGravityDirect.DeepCopy(this.VehicleMoveComp.GravityDirect);
				}
				else if (this.MoveComp != null)
				{
					this.CachedActorGravityDirect.DeepCopy(this.MoveComp.GravityDirect);
				}
				else
				{
					Aki.Protocol.Vector initGravityDirection = this.CreatureData.GetInitGravityDirection();
					if (initGravityDirection != null)
					{
						this.CachedActorGravityDirect.FromConfigVector(initGravityDirection);
					}
				}
			}
			return this.CachedActorGravityDirect;
		}
	}

	// Token: 0x17002424 RID: 9252
	// (get) Token: 0x0601AAA2 RID: 109218 RVA: 0x007EE0D0 File Offset: 0x007EC2D0
	public FVectorDouble ActorGravityDirection
	{
		get
		{
			return this.ActorGravityDirectProxy.ToUeVector(false);
		}
	}

	// Token: 0x17002425 RID: 9253
	// (get) Token: 0x0601AAA3 RID: 109219 RVA: 0x007EE0DE File Offset: 0x007EC2DE
	public bool ActorInitNotStandardGravity
	{
		get
		{
			if (this.CachedActorInitNotStandardGravity == null)
			{
				this.InitCacheGravityRotation();
			}
			return this.CachedActorInitNotStandardGravity.Value;
		}
	}

	// Token: 0x17002426 RID: 9254
	// (get) Token: 0x0601AAA4 RID: 109220 RVA: 0x007EE0FE File Offset: 0x007EC2FE
	public global::Rotator ActorInitGravityRotationProxy
	{
		get
		{
			if (this.CachedActorInitGravityRotation == null)
			{
				this.InitCacheGravityRotation();
			}
			return this.CachedActorInitGravityRotation;
		}
	}

	// Token: 0x17002427 RID: 9255
	// (get) Token: 0x0601AAA5 RID: 109221 RVA: 0x007EE114 File Offset: 0x007EC314
	public FRotator ActorInitGravityRotation
	{
		get
		{
			if (this.CachedActorInitGravityRotation == null)
			{
				this.InitCacheGravityRotation();
			}
			return this.CachedActorInitGravityRotation.ToUeRotator();
		}
	}

	// Token: 0x0601AAA6 RID: 109222 RVA: 0x007EE130 File Offset: 0x007EC330
	private void InitCacheGravityRotation()
	{
		Aki.Protocol.Vector initGravityDirection = this.CreatureData.GetInitGravityDirection();
		if (initGravityDirection != null)
		{
			global::Vector vector = global::Vector.Create();
			vector.FromConfigVector(initGravityDirection);
			if (vector.Normalize(9.99999993922529E-09) && !Singleton<MathUtils>.Instance.IsNearlyEqual((double)initGravityDirection.Z, -1.0, null))
			{
				global::Vector vector2 = global::Vector.Create();
				Quat quat = Quat.Create(0f, 0f, 0f, 1f);
				vector.UnaryNegation(vector2);
				if (Math.Abs(vector2.DotProduct(global::Vector.ForwardVectorProxy)) < 0.9999)
				{
					Singleton<MathUtils>.Instance.LookRotationUpFirst(global::Vector.ForwardVectorProxy, vector2, quat);
				}
				else
				{
					Singleton<MathUtils>.Instance.LookRotationUpFirst(global::Vector.UpVectorProxy, vector2, quat);
				}
				this.CachedActorInitNotStandardGravity = new bool?(true);
				this.CachedActorInitGravityRotation = quat.Rotator(null);
				return;
			}
		}
		this.CachedActorInitNotStandardGravity = new bool?(false);
		this.CachedActorInitGravityRotation = global::Rotator.Create(0f, 0f, 0f);
	}

	// Token: 0x0601AAA7 RID: 109223 RVA: 0x007EE242 File Offset: 0x007EC442
	public virtual float GetRadius()
	{
		return 0f;
	}

	// Token: 0x17002428 RID: 9256
	// (get) Token: 0x0601AAA8 RID: 109224 RVA: 0x007EE249 File Offset: 0x007EC449
	[Nullable(2)]
	public AActor Owner
	{
		[NullableContext(2)]
		get
		{
			AActor actorInternal = this.ActorInternal;
			if (actorInternal == null || !actorInternal.IsValid())
			{
				return null;
			}
			return this.ActorInternal;
		}
	}

	// Token: 0x17002429 RID: 9257
	// (get) Token: 0x0601AAA9 RID: 109225 RVA: 0x007EE26C File Offset: 0x007EC46C
	[Obsolete("非安全获取速度，需要提前校验ActorInternal, 或者使用SafeActorVelocityProxy")]
	public global::Vector ActorVelocityProxy
	{
		get
		{
			if (this.CachedVelocityTime < Singleton<Time>.Instance.Frame)
			{
				this.CachedVelocityTime = Singleton<Time>.Instance.Frame;
				global::Vector cachedActorVelocity = this.CachedActorVelocity;
				FVectorDouble fvectorDouble = this.ActorInternal.D_GetVelocity();
				cachedActorVelocity.DeepCopy(fvectorDouble);
			}
			return this.CachedActorVelocity;
		}
	}

	// Token: 0x1700242A RID: 9258
	// (get) Token: 0x0601AAAA RID: 109226 RVA: 0x007EE2BA File Offset: 0x007EC4BA
	public FVector ActorVelocity
	{
		get
		{
			return this.ActorVelocityProxy.ToUeVectorOld();
		}
	}

	// Token: 0x1700242B RID: 9259
	// (get) Token: 0x0601AAAB RID: 109227 RVA: 0x007EE2C7 File Offset: 0x007EC4C7
	[Nullable(2)]
	public global::Vector SafeActorVelocityProxy
	{
		[NullableContext(2)]
		get
		{
			AActor actorInternal = this.ActorInternal;
			if (actorInternal == null || !actorInternal.IsValid())
			{
				return null;
			}
			return this.ActorVelocityProxy;
		}
	}

	// Token: 0x1700242C RID: 9260
	// (get) Token: 0x0601AAAC RID: 109228 RVA: 0x007EE2E8 File Offset: 0x007EC4E8
	[Nullable(2)]
	public virtual USkeletalMeshComponent SkeletalMesh
	{
		[NullableContext(2)]
		get
		{
			return null;
		}
	}

	// Token: 0x0601AAAD RID: 109229 RVA: 0x007EE2EB File Offset: 0x007EC4EB
	public virtual bool HasMesh()
	{
		return false;
	}

	// Token: 0x0601AAAE RID: 109230 RVA: 0x007EE2EE File Offset: 0x007EC4EE
	protected virtual void OnTeleport()
	{
		this.LastActorLocation.DeepCopy(this.ActorLocationProxy);
		this.LastActorRotation.DeepCopy(this.ActorRotationProxy);
	}

	// Token: 0x0601AAAF RID: 109231 RVA: 0x007EE314 File Offset: 0x007EC514
	public unsafe virtual bool SetActorLocation(FVectorDouble value, string context = "unknown", bool sweep = true)
	{
		if (!Singleton<MathUtils>.Instance.IsValidVector(value, 100000000))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "SetActorLocation的value无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("value", value);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData = this.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData != null) ? new long?(creatureData.GetCreatureDataId()) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		bool result = false;
		AActor actorInternal = this.ActorInternal;
		if (actorInternal != null && actorInternal.IsValid())
		{
			this.CachedDesiredActorLocation.FromUeVector(value);
			this.IsChangingLocation = true;
			result = this.ActorInternal.D_K2_SetActorLocation(value, sweep, ref WorldGlobal.SweepHitResult, true);
			this.IsChangingLocation = false;
			this.CheckIsForbidSettingLocAndRot(true, false, true);
			if (this.DebugMovementComp != null)
			{
				this.DebugMovementComp.MarkDebugRecord(context + ".SetActorLocation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
			}
		}
		this.ResetLocationCachedTime();
		this.OnTeleport();
		AActor actorInternal2 = this.ActorInternal;
		if (actorInternal2 != null && actorInternal2.IsValid() && ModelBase<SundryModel>.Instance.SceneCheckOn)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Test;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "[SetActorLocation]";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("location:", value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("owner", this.Owner);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		}
		return result;
	}

	// Token: 0x0601AAB0 RID: 109232 RVA: 0x007EE4B4 File Offset: 0x007EC6B4
	public unsafe virtual bool SetActorLocationNoTeleport(FVectorDouble value, string context = "unknown", bool sweep = true)
	{
		if (!Singleton<MathUtils>.Instance.IsValidVector(value, 100000000))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "SetActorLocation的value无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("value", value);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData = this.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData != null) ? new long?(creatureData.GetCreatureDataId()) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		bool result = false;
		AActor actorInternal = this.ActorInternal;
		if (actorInternal != null && actorInternal.IsValid())
		{
			this.CachedDesiredActorLocation.FromUeVector(value);
			this.IsChangingLocation = true;
			result = this.ActorInternal.D_K2_SetActorLocation(value, sweep, ref WorldGlobal.SweepHitResult, true);
			this.IsChangingLocation = false;
			this.CheckIsForbidSettingLocAndRot(true, false, true);
			if (this.DebugMovementComp != null)
			{
				this.DebugMovementComp.MarkDebugRecord(context + ".SetActorLocation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
			}
		}
		this.ResetLocationCachedTime();
		AActor actorInternal2 = this.ActorInternal;
		if (actorInternal2 != null && actorInternal2.IsValid() && ModelBase<SundryModel>.Instance.SceneCheckOn)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Test;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "[SetActorLocation]";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("location:", value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("owner", this.Owner);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		}
		return result;
	}

	// Token: 0x0601AAB1 RID: 109233 RVA: 0x007EE64C File Offset: 0x007EC84C
	public unsafe virtual bool TeleportTo(FVectorDouble location, FRotator rotator, string context = "unknown")
	{
		if (!Singleton<MathUtils>.Instance.IsValidVector(location, 100000000) || !Singleton<MathUtils>.Instance.IsValidRotator(rotator, 100000000))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "TeleportTo的location无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("location", location);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData = this.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData != null) ? new long?(creatureData.GetCreatureDataId()) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		bool result = false;
		AActor actorInternal = this.ActorInternal;
		if (actorInternal != null && actorInternal.IsValid())
		{
			this.CachedDesiredActorLocation.FromUeVector(location);
			this.IsChangingLocation = true;
			result = this.ActorInternal.D_K2_KuroTeleportTo(location, rotator);
			this.IsChangingLocation = false;
			this.CheckIsForbidSettingLocAndRot(true, true, true);
			if (this.DebugMovementComp != null)
			{
				this.DebugMovementComp.MarkDebugRecord(context + ".TeleportTo", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), true);
			}
		}
		this.ResetLocationCachedTime();
		this.OnTeleport();
		AActor actorInternal2 = this.ActorInternal;
		if (actorInternal2 != null && actorInternal2.IsValid() && ModelBase<SundryModel>.Instance.SceneCheckOn)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Test;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "[TeleportTo]";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("location:", location);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("owner", this.Owner);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		}
		return result;
	}

	// Token: 0x0601AAB2 RID: 109234 RVA: 0x007EE7FB File Offset: 0x007EC9FB
	public void ResetLocationCachedTime()
	{
		this.CachedTransformTime = -1;
		this.CachedLocationTime = -1;
	}

	// Token: 0x0601AAB3 RID: 109235 RVA: 0x007EE80C File Offset: 0x007ECA0C
	public virtual bool SetActorRotation(FRotator value, string context = "unknown", bool sweep = true)
	{
		bool result = false;
		AActor actorInternal = this.ActorInternal;
		if (actorInternal != null && actorInternal.IsValid())
		{
			result = this.ActorInternal.K2_KuroSetActorRotation(value, sweep, false, false);
			this.CheckIsForbidSettingLocAndRot(false, true, true);
			if (this.DebugMovementComp != null)
			{
				this.DebugMovementComp.MarkDebugRecord(context + ".SetActorRotation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
			}
		}
		this.ResetRotationCachedTime();
		return result;
	}

	// Token: 0x0601AAB4 RID: 109236 RVA: 0x007EE875 File Offset: 0x007ECA75
	public void ResetRotationCachedTime()
	{
		this.CachedTransformTime = 0;
		this.CachedRotationTime = 0;
		this.CachedUpTime = 0;
		this.CachedRightTime = 0;
		this.CachedForwardTime = 0;
	}

	// Token: 0x0601AAB5 RID: 109237 RVA: 0x007EE89C File Offset: 0x007ECA9C
	public unsafe virtual bool SetActorLocationAndRotation(FVectorDouble location, FRotator rotation, string context = "unknown", bool sweep = false, ESetRotationPriority? priority = null)
	{
		if (!Singleton<MathUtils>.Instance.IsValidVector(location, 100000000))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "SetActorLocationAndRotation的location无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("location", location);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData = this.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData != null) ? new long?(creatureData.GetCreatureDataId()) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		this.CachedDesiredActorLocation.FromUeVector(location);
		this.IsChangingLocation = true;
		bool result = this.ActorInternal.D_K2_SetActorLocationAndRotation(location, rotation, sweep, ref WorldGlobal.SweepHitResult, true);
		this.IsChangingLocation = false;
		this.ResetTransformCachedTime();
		this.OnTeleport();
		this.CheckIsForbidSettingLocAndRot(true, true, true);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".SetActorLocationAndRotation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		if (ModelBase<SundryModel>.Instance.SceneCheckOn)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Test;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "[SetActorLocationAndRotation]";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("location:", location);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("rotation:", rotation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("owner", this.Owner);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		return result;
	}

	// Token: 0x0601AAB6 RID: 109238 RVA: 0x007EEA30 File Offset: 0x007ECC30
	public unsafe virtual bool SetActorTransform(FTransformDouble value, string context = "unknown", bool sweep = true, ESetRotationPriority? priority = null)
	{
		FVectorDouble location = value.GetLocation();
		if (!Singleton<MathUtils>.Instance.IsValidVector(location, 100000000))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "SetActorTransform的value参数";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("value", value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Location", location);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData = this.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData != null) ? new long?(creatureData.GetCreatureDataId()) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		global::Vector cachedDesiredActorLocation = this.CachedDesiredActorLocation;
		FVectorDouble location2 = value.GetLocation();
		cachedDesiredActorLocation.FromUeVector(location2);
		bool result;
		if (this.ActorLocationProxy.Equals(this.CachedDesiredActorLocation, 9.999999747378752E-05))
		{
			result = this.SetActorRotation(value.GetRotation().Rotator(), context, sweep);
		}
		else
		{
			this.IsChangingLocation = true;
			result = this.ActorInternal.D_K2_SetActorTransform(value, sweep, ref WorldGlobal.SweepHitResult, true);
			this.IsChangingLocation = false;
		}
		this.CheckIsForbidSettingLocAndRot(true, true, true);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".SetActorTransform", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		this.ResetTransformCachedTime();
		this.OnTeleport();
		return result;
	}

	// Token: 0x0601AAB7 RID: 109239 RVA: 0x007EEBA8 File Offset: 0x007ECDA8
	public virtual void AddActorWorldOffset(FVectorDouble offset, string context = "unknown", bool sweep = true)
	{
		if (this.CheckIsForbidSettingLocAndRot(true, false, true))
		{
			return;
		}
		this.ActorInternal.D_K2_AddActorWorldOffset(offset, sweep, ref WorldGlobal.SweepHitResult, false);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".AddActorWorldOffset", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		this.ResetLocationCachedTime();
	}

	// Token: 0x0601AAB8 RID: 109240 RVA: 0x007EEC00 File Offset: 0x007ECE00
	public virtual void AddActorLocalOffset(FVectorDouble offset, string context = "unknown", bool sweep = true)
	{
		if (this.CheckIsForbidSettingLocAndRot(true, false, true))
		{
			return;
		}
		this.ActorInternal.D_K2_AddActorLocalOffset(offset, sweep, ref WorldGlobal.SweepHitResult, false);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".AddActorLocalOffset", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		this.ResetLocationCachedTime();
	}

	// Token: 0x0601AAB9 RID: 109241 RVA: 0x007EEC58 File Offset: 0x007ECE58
	public virtual void AddActorWorldRotation(FRotator rotation, string context = "unknown", bool sweep = false)
	{
		if (this.CheckIsForbidSettingLocAndRot(false, true, true))
		{
			return;
		}
		this.ActorInternal.K2_AddActorWorldRotation(rotation, sweep, ref WorldGlobal.SweepHitResult, false);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".AddActorWorldRotation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		this.ResetRotationCachedTime();
	}

	// Token: 0x0601AABA RID: 109242 RVA: 0x007EECB0 File Offset: 0x007ECEB0
	public virtual void AddActorLocalRotation(FRotator rotation, string context = "unknown", bool sweep = false)
	{
		if (this.CheckIsForbidSettingLocAndRot(false, true, true))
		{
			return;
		}
		this.ActorInternal.K2_AddActorLocalRotation(rotation, sweep, ref WorldGlobal.SweepHitResult, false);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".AddActorLocalRotation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		this.ResetRotationCachedTime();
	}

	// Token: 0x0601AABB RID: 109243 RVA: 0x007EED08 File Offset: 0x007ECF08
	public virtual void AddActorWorldOffsetAndQuat(FVectorDouble offset, FQuat quatOffset, string context = "unknown", bool sweep = true)
	{
		if (this.CheckIsForbidSettingLocAndRot(true, false, true))
		{
			return;
		}
		this.ActorInternal.D_K2_AddActorWorldOffset(offset, sweep, ref WorldGlobal.SweepHitResult, false);
		this.ActorInternal.K2_AddActorWorldRotation(quatOffset.Rotator(), sweep, ref WorldGlobal.SweepHitResult, false);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".AddActorWorldOffsetAndQuat", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		this.ResetTransformCachedTime();
	}

	// Token: 0x0601AABC RID: 109244 RVA: 0x007EED7C File Offset: 0x007ECF7C
	protected void ResetTransformCachedTime()
	{
		this.CachedTransformTime = 0;
		this.CachedLocationTime = 0;
		this.CachedRotationTime = 0;
		this.CachedUpTime = 0;
		this.CachedRightTime = 0;
		this.CachedForwardTime = 0;
		this.CachedGravityDirectTime = 0;
		BaseMoveComponent moveComp = this.MoveComp;
		if (moveComp == null)
		{
			return;
		}
		moveComp.ResetCharTraceHeight();
	}

	// Token: 0x0601AABD RID: 109245 RVA: 0x007EEDCC File Offset: 0x007ECFCC
	public void ResetAllCachedTime()
	{
		this.CachedTransformTime = -1;
		this.CachedLocationTime = -1;
		this.CachedRotationTime = -1;
		this.CachedUpTime = -1;
		this.CachedRightTime = -1;
		this.CachedForwardTime = -1;
		this.CachedVelocityTime = -1;
		this.CachedGravityDirectTime = -1;
		BaseMoveComponent moveComp = this.MoveComp;
		if (moveComp == null)
		{
			return;
		}
		moveComp.ResetCharTraceHeight();
	}

	// Token: 0x0601AABE RID: 109246 RVA: 0x007EEE21 File Offset: 0x007ED021
	public void ResetCachedVelocityTime()
	{
		this.CachedVelocityTime = -1;
	}

	// Token: 0x0601AABF RID: 109247 RVA: 0x007EEE2A File Offset: 0x007ED02A
	public void ResetGravityRelatedCachedTime()
	{
		this.CachedGravityDirectTime = -1;
	}

	// Token: 0x0601AAC0 RID: 109248 RVA: 0x007EEE33 File Offset: 0x007ED033
	private void SetForbidSettingLocAndRotInternal(bool forbid, EForbidSettingLocAndRotReason reason, HashSet<EForbidSettingLocAndRotReason> target)
	{
		if (forbid)
		{
			target.Add(reason);
			return;
		}
		target.Remove(reason);
	}

	// Token: 0x0601AAC1 RID: 109249 RVA: 0x007EEE4C File Offset: 0x007ED04C
	public void SetForbidSettingLocAndRot(bool forbid, EForbidSettingLocAndRotReason reason)
	{
		switch (ForbidSettingLocAndRotTypeDefines.Values[(int)reason])
		{
		case EForbidSettingLocAndRotType.Location:
			this.SetForbidSettingLocAndRotInternal(forbid, reason, this.ForbidSettingLocSet);
			return;
		case EForbidSettingLocAndRotType.Rotation:
			this.SetForbidSettingLocAndRotInternal(forbid, reason, this.ForbidSettingRotSet);
			return;
		case (EForbidSettingLocAndRotType)3:
			break;
		case EForbidSettingLocAndRotType.Both:
			this.SetForbidSettingLocAndRotInternal(forbid, reason, this.ForbidSettingLocSet);
			this.SetForbidSettingLocAndRotInternal(forbid, reason, this.ForbidSettingRotSet);
			break;
		default:
			return;
		}
	}

	// Token: 0x0601AAC2 RID: 109250 RVA: 0x007EEEB4 File Offset: 0x007ED0B4
	protected unsafe bool CheckIsForbidSettingLocAndRot(bool Loc = false, bool Rot = false, bool Debug = true)
	{
		bool flag = this.ForbidSettingRotSet.Count > 0 && Rot;
		bool flag2 = this.ForbidSettingLocSet.Count > 0 && Loc;
		if (!flag && !flag2)
		{
			return false;
		}
		if (Debug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[BaseActorComp] 检测到异常的设置位置或旋转行为";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.CreatureData.GetPbDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CreatureId", this.CreatureData.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TargetLoc", this.ActorLocationProxy);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("TargetRot", this.ActorRotationProxy);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		return true;
	}

	// Token: 0x0601AAC3 RID: 109251 RVA: 0x007EEF9C File Offset: 0x007ED19C
	[NullableContext(2)]
	protected virtual void OnSetActorActive(bool active, string reason = null)
	{
		if (active)
		{
			this.EnableActor(this.ActorHandleForEntityDisable.Value);
			this.EnableCollision(this.CollisionHandleForEntityDisable.Value);
			this.ActorHandleForEntityDisable = null;
			this.CollisionHandleForEntityDisable = null;
			return;
		}
		this.ActorHandleForEntityDisable = new int?(this.DisableActor(reason));
		this.CollisionHandleForEntityDisable = new int?(this.DisableCollision(reason));
	}

	// Token: 0x0601AAC4 RID: 109252 RVA: 0x007EF00D File Offset: 0x007ED20D
	public void SetSequenceBinding(bool inEnable)
	{
		this.IsInSequenceBinding = inEnable;
	}

	// Token: 0x0601AAC5 RID: 109253 RVA: 0x007EF016 File Offset: 0x007ED216
	public bool GetSequenceBinding()
	{
		return this.IsInSequenceBinding;
	}

	// Token: 0x0601AAC6 RID: 109254 RVA: 0x007EF020 File Offset: 0x007ED220
	public unsafe int DisableActor(string reason)
	{
		int num = this.DisableActorHandle.Disable(reason, base.GetType().Name);
		CreatureController instance = ControllerBase<CreatureController>.Instance;
		CreatureDataComponent creatureData = this.CreatureData;
		EEntityType? eentityType = (creatureData != null) ? new EEntityType?(creatureData.GetEntityType()) : null;
		if (instance.CheckEnableEntityLog((eentityType != null) ? new OneOf<EEntityType, EntityHandle>?(eentityType.GetValueOrDefault()) : null))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "DisableActor";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData2 = this.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData2 != null) ? new long?(creatureData2.GetCreatureDataId()) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item2 = "PbDataId";
			CreatureDataComponent creatureData3 = this.CreatureData;
			ptr2 = new ValueTuple<string, object>(item2, (creatureData3 != null) ? new int?(creatureData3.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Handle", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", reason);
			instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		AActor actorInternal = this.ActorInternal;
		if (actorInternal == null || !actorInternal.IsValid())
		{
			return num;
		}
		if (this.ActorInternal.bHidden)
		{
			return num;
		}
		this.ActorInternal.SetActorHiddenInGame(true);
		Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnSetActorHidden, base.Entity.Id, false);
		if (this.Handle != null)
		{
			Singleton<EventSystem>.Instance.EmitWithTarget<int, bool>(this.Handle, EEventName.OnSetActorHidden, base.Entity.Id, false);
		}
		return num;
	}

	// Token: 0x0601AAC7 RID: 109255 RVA: 0x007EF1E4 File Offset: 0x007ED3E4
	public unsafe int DisableCollision(string reason)
	{
		int num = this.DisableCollisionHandle.Disable(reason, base.GetType().Name);
		CreatureController instance = ControllerBase<CreatureController>.Instance;
		CreatureDataComponent creatureData = this.CreatureData;
		EEntityType? eentityType = (creatureData != null) ? new EEntityType?(creatureData.GetEntityType()) : null;
		if (instance.CheckEnableEntityLog((eentityType != null) ? new OneOf<EEntityType, EntityHandle>?(eentityType.GetValueOrDefault()) : null))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "DisableCollision";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData2 = this.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData2 != null) ? new long?(creatureData2.GetCreatureDataId()) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item2 = "PbDataId";
			CreatureDataComponent creatureData3 = this.CreatureData;
			ptr2 = new ValueTuple<string, object>(item2, (creatureData3 != null) ? new int?(creatureData3.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Handle", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", reason);
			instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		AActor actorInternal = this.ActorInternal;
		if (actorInternal == null || !actorInternal.IsValid())
		{
			return num;
		}
		this.ActorInternal.SetActorEnableCollision(false);
		return num;
	}

	// Token: 0x0601AAC8 RID: 109256 RVA: 0x007EF354 File Offset: 0x007ED554
	public unsafe bool EnableActor(int handle)
	{
		CreatureController instance = ControllerBase<CreatureController>.Instance;
		CreatureDataComponent creatureData = this.CreatureData;
		EEntityType? eentityType = (creatureData != null) ? new EEntityType?(creatureData.GetEntityType()) : null;
		if (instance.CheckEnableEntityLog((eentityType != null) ? new OneOf<EEntityType, EntityHandle>?(eentityType.GetValueOrDefault()) : null))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "EnableActor";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData2 = this.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData2 != null) ? new long?(creatureData2.GetCreatureDataId()) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item2 = "PbDataId";
			CreatureDataComponent creatureData3 = this.CreatureData;
			ptr2 = new ValueTuple<string, object>(item2, (creatureData3 != null) ? new int?(creatureData3.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Handle", handle);
			instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		bool flag = this.DisableActorHandle.Enable(handle, base.GetType().Name);
		if (!flag)
		{
			return flag;
		}
		AActor actorInternal = this.ActorInternal;
		if (actorInternal == null || !actorInternal.IsValid())
		{
			return flag;
		}
		if (this.ActorInternal.bHidden == !this.DisableActorHandle.Empty)
		{
			return flag;
		}
		Singleton<EventSystem>.Instance.EmitWithTarget<int, bool>(ModelBase<CharacterModel>.Instance.GetHandleByEntity(base.Entity), EEventName.OnPreSetActorHidden, base.Entity.Id, this.DisableActorHandle.Empty);
		if (base.Entity.GetComponent<UeSkeletalTickManageComponent>() != null)
		{
			TimerSystem.Instance.Next(delegate(float _)
			{
				AActor actorInternal2 = this.ActorInternal;
				if (actorInternal2 == null || !actorInternal2.IsValid())
				{
					return;
				}
				this.<EnableActor>g__SetVisible|164_0();
			}, null, null);
		}
		else
		{
			this.<EnableActor>g__SetVisible|164_0();
		}
		return flag;
	}

	// Token: 0x0601AAC9 RID: 109257 RVA: 0x007EF528 File Offset: 0x007ED728
	public unsafe bool EnableCollision(int handle)
	{
		CreatureController instance = ControllerBase<CreatureController>.Instance;
		CreatureDataComponent creatureData = this.CreatureData;
		EEntityType? eentityType = (creatureData != null) ? new EEntityType?(creatureData.GetEntityType()) : null;
		if (instance.CheckEnableEntityLog((eentityType != null) ? new OneOf<EEntityType, EntityHandle>?(eentityType.GetValueOrDefault()) : null))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "EnableCollision";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData2 = this.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData2 != null) ? new long?(creatureData2.GetCreatureDataId()) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item2 = "PbDataId";
			CreatureDataComponent creatureData3 = this.CreatureData;
			ptr2 = new ValueTuple<string, object>(item2, (creatureData3 != null) ? new int?(creatureData3.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Handle", handle);
			instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		bool flag = this.DisableCollisionHandle.Enable(handle, base.GetType().Name);
		if (!flag)
		{
			return flag;
		}
		AActor actorInternal = this.ActorInternal;
		if (actorInternal == null || !actorInternal.IsValid())
		{
			return flag;
		}
		this.ActorInternal.SetActorEnableCollision(this.DisableCollisionHandle.Empty);
		return flag;
	}

	// Token: 0x0601AACA RID: 109258 RVA: 0x007EF68E File Offset: 0x007ED88E
	public string DumpDisableActorInfo()
	{
		return this.DisableActorHandle.DumpDisableInfo();
	}

	// Token: 0x0601AACB RID: 109259 RVA: 0x007EF69B File Offset: 0x007ED89B
	public string DumpDisableCollisionInfo()
	{
		return this.DisableCollisionHandle.DumpDisableInfo();
	}

	// Token: 0x0601AACC RID: 109260 RVA: 0x007EF6A8 File Offset: 0x007ED8A8
	public string DumpDisableTickInfo()
	{
		UeActorTickManageComponent component = base.Entity.GetComponent<UeActorTickManageComponent>();
		return ((component != null) ? component.DumpDisableTickInfo() : null) ?? "";
	}

	// Token: 0x0601AACD RID: 109261 RVA: 0x007EF6CC File Offset: 0x007ED8CC
	public void SetActorVisible(bool visible, string reason)
	{
		if (!visible)
		{
			if (this.ActorHandleForCommon != null)
			{
				return;
			}
			this.ActorHandleForCommon = new int?(this.DisableActor(reason));
			return;
		}
		else
		{
			if (this.ActorHandleForCommon == null)
			{
				return;
			}
			this.EnableActor(this.ActorHandleForCommon.Value);
			this.ActorHandleForCommon = null;
			return;
		}
	}

	// Token: 0x0601AACE RID: 109262 RVA: 0x007EF72C File Offset: 0x007ED92C
	public void SetCollisionEnable(bool enable, string reason)
	{
		if (!enable)
		{
			if (this.CollisionHandleForCommon != null)
			{
				return;
			}
			this.CollisionHandleForCommon = new int?(this.DisableCollision(reason));
			return;
		}
		else
		{
			if (this.CollisionHandleForCommon == null)
			{
				return;
			}
			this.EnableCollision(this.CollisionHandleForCommon.Value);
			this.CollisionHandleForCommon = null;
			return;
		}
	}

	// Token: 0x0601AACF RID: 109263 RVA: 0x007EF78C File Offset: 0x007ED98C
	public void SetTickEnable(bool enable, string reason)
	{
		if (!enable)
		{
			if (this.TickHandleForCommon != null)
			{
				return;
			}
			UeActorTickManageComponent component = base.Entity.GetComponent<UeActorTickManageComponent>();
			this.TickHandleForCommon = ((component != null) ? new int?(component.DisableTickWithLog(reason)) : null);
			return;
		}
		else
		{
			if (this.TickHandleForCommon == null)
			{
				return;
			}
			UeActorTickManageComponent component2 = base.Entity.GetComponent<UeActorTickManageComponent>();
			if (component2 != null)
			{
				component2.EnableTickWithLog(this.TickHandleForCommon.Value, reason);
			}
			this.TickHandleForCommon = null;
			return;
		}
	}

	// Token: 0x0601AAD0 RID: 109264 RVA: 0x007EF813 File Offset: 0x007EDA13
	protected override bool OnClear()
	{
		if (this.CreatureDataInternal != null)
		{
			this.CreatureDataInternal.Reset();
			this.CreatureDataInternal = null;
		}
		this.DisableActorHandle.Clear();
		this.DisableCollisionHandle.Clear();
		this.ResetAllCachedTime();
		return true;
	}

	// Token: 0x0601AAD1 RID: 109265 RVA: 0x007EF84C File Offset: 0x007EDA4C
	public virtual FTransformDouble GetSocketTransform(FName socketName)
	{
		return this.ActorTransform;
	}

	// Token: 0x0601AAD2 RID: 109266 RVA: 0x007EF854 File Offset: 0x007EDA54
	public virtual FVectorDouble GetSocketLocation(FName socketName)
	{
		return this.ActorLocation;
	}

	// Token: 0x0601AAD3 RID: 109267 RVA: 0x007EF85C File Offset: 0x007EDA5C
	public virtual global::Vector GetWatchedPoint()
	{
		return this.ActorLocationProxy;
	}

	// Token: 0x0601AAD4 RID: 109268 RVA: 0x007EF864 File Offset: 0x007EDA64
	[return: Nullable(2)]
	public string GetReplaceEffect(string path)
	{
		return this.ReplaceEffectMap.GetValueOrDefault(path);
	}

	// Token: 0x0601AAD5 RID: 109269 RVA: 0x007EF872 File Offset: 0x007EDA72
	public void SetReplaceEffect(Dictionary<string, string> map)
	{
		this.ReplaceEffectMap = map;
	}

	// Token: 0x0601AAD6 RID: 109270 RVA: 0x007EF87B File Offset: 0x007EDA7B
	[return: Nullable(2)]
	public string GetReplaceMontage(string path)
	{
		return this.ReplaceMontageMap.GetValueOrDefault(path);
	}

	// Token: 0x0601AAD7 RID: 109271 RVA: 0x007EF88C File Offset: 0x007EDA8C
	public void SetupReplacement([Nullable(2)] SModelConfig modelConfig, EntityAssetElement entityAssetElement)
	{
		if (modelConfig != null)
		{
			string text = modelConfig.特效替换表.ToAssetPathName();
			if (!string.IsNullOrEmpty(text))
			{
				this.ReplaceEffectMap = entityAssetElement.MainAsset.SetupReplaceEffect(text);
			}
		}
		if (modelConfig != null)
		{
			string text2 = modelConfig.蒙太奇替换表.ToAssetPathName();
			if (!string.IsNullOrEmpty(text2))
			{
				this.ReplaceMontageMap = entityAssetElement.MainAsset.SetupReplaceMontage(text2);
			}
		}
	}

	// Token: 0x0601AAD8 RID: 109272 RVA: 0x007EF8F7 File Offset: 0x007EDAF7
	public static void RegisterDebugCube(AStaticMeshActor cube)
	{
		BaseActorComponent.AllDebugCubes.Add(cube);
		cube.SetActorHiddenInGame(!BaseActorComponent.AllDebugCubesVisible);
	}

	// Token: 0x0601AAD9 RID: 109273 RVA: 0x007EF913 File Offset: 0x007EDB13
	public static void UnregisterDebugCube(AStaticMeshActor cube)
	{
		BaseActorComponent.AllDebugCubes.Remove(cube);
	}

	// Token: 0x0601AADA RID: 109274 RVA: 0x007EF924 File Offset: 0x007EDB24
	public static void SetAllDebugCubesVisible(bool visible)
	{
		BaseActorComponent.AllDebugCubesVisible = visible;
		foreach (AStaticMeshActor astaticMeshActor in new List<AStaticMeshActor>(BaseActorComponent.AllDebugCubes))
		{
			if (astaticMeshActor != null && astaticMeshActor.IsValid())
			{
				astaticMeshActor.SetActorHiddenInGame(!visible);
			}
			else
			{
				BaseActorComponent.AllDebugCubes.Remove(astaticMeshActor);
			}
		}
	}

	// Token: 0x0601AADB RID: 109275 RVA: 0x007EF9A0 File Offset: 0x007EDBA0
	public static void ApplyDebugCubeMaterial(UStaticMeshComponent meshComp)
	{
		if (BaseActorComponent.DebugCubeMaterialCache == null)
		{
			BaseActorComponent.DebugCubeMaterialCache = Singleton<ResourceSystem>.Instance.Load<UMaterialInterface>("/Game/Aki/UniverseEditor/Res/M_Sphere.M_Sphere", "js_undefined");
		}
		if (BaseActorComponent.DebugCubeMaterialCache != null)
		{
			meshComp.SetMaterial(0, BaseActorComponent.DebugCubeMaterialCache);
		}
	}

	// Token: 0x0601AADC RID: 109276 RVA: 0x007EF9D8 File Offset: 0x007EDBD8
	public void ShowDebugLocationCube(bool enable)
	{
		if (!enable)
		{
			this.ClearDebugLocationCube();
			return;
		}
		if (GlobalData.IsPlayInEditor)
		{
			AActor actorInternal = this.ActorInternal;
			if (actorInternal != null && actorInternal.IsValid())
			{
				AStaticMeshActor debugPositionCube = this.DebugPositionCube;
				if (debugPositionCube == null || !debugPositionCube.IsValid())
				{
					this.DebugPositionCube = this.SpawnDebugCube(new FVectorDouble(0.6, 0.6, 0.6), new FVectorDouble(0.0, 0.0, 0.0), false);
				}
				AStaticMeshActor debugFootCube = this.DebugFootCube;
				if (debugFootCube == null || !debugFootCube.IsValid())
				{
					this.DebugFootCube = this.SpawnDebugCube(new FVectorDouble(0.3, 0.3, 0.3), new FVectorDouble(0.0, 0.0, (double)(-(double)this.ScaledHalfHeight)), false);
				}
				AStaticMeshActor debugForwardCube = this.DebugForwardCube;
				if (debugForwardCube == null || !debugForwardCube.IsValid())
				{
					this.DebugForwardCube = this.SpawnDebugCube(new FVectorDouble(1.2, 0.2, 0.2), new FVectorDouble(80.0, 0.0, 0.0), true);
				}
				return;
			}
		}
	}

	// Token: 0x0601AADD RID: 109277 RVA: 0x007EFB3C File Offset: 0x007EDD3C
	public void ClearDebugLocationCube()
	{
		AStaticMeshActor debugPositionCube = this.DebugPositionCube;
		if (debugPositionCube != null && debugPositionCube.IsValid())
		{
			BaseActorComponent.UnregisterDebugCube(this.DebugPositionCube);
			this.DebugPositionCube.K2_DestroyActor();
		}
		this.DebugPositionCube = null;
		AStaticMeshActor debugFootCube = this.DebugFootCube;
		if (debugFootCube != null && debugFootCube.IsValid())
		{
			BaseActorComponent.UnregisterDebugCube(this.DebugFootCube);
			this.DebugFootCube.K2_DestroyActor();
		}
		this.DebugFootCube = null;
		AStaticMeshActor debugForwardCube = this.DebugForwardCube;
		if (debugForwardCube != null && debugForwardCube.IsValid())
		{
			BaseActorComponent.UnregisterDebugCube(this.DebugForwardCube);
			this.DebugForwardCube.K2_DestroyActor();
		}
		this.DebugForwardCube = null;
	}

	// Token: 0x0601AADE RID: 109278 RVA: 0x007EFBDC File Offset: 0x007EDDDC
	[NullableContext(2)]
	private AStaticMeshActor SpawnDebugCube(FVectorDouble scale, FVectorDouble relativeLocation, bool followRotation)
	{
		AStaticMeshActor astaticMeshActor = Singleton<ActorSystem>.Instance.Spawn(AStaticMeshActor.StaticClass(), this.ActorTransform, null) as AStaticMeshActor;
		if (astaticMeshActor == null)
		{
			return null;
		}
		UStaticMeshComponent staticMeshComponent = astaticMeshActor.StaticMeshComponent;
		if (staticMeshComponent != null)
		{
			staticMeshComponent.SetMobility(EComponentMobility.Movable);
			staticMeshComponent.SetStaticMesh(Singleton<ResourceSystem>.Instance.Load<UStaticMesh>("/Engine/BasicShapes/Cube.Cube", "js_undefined"));
			staticMeshComponent.SetHiddenInGame(false, false);
			BaseActorComponent.ApplyDebugCubeMaterial(staticMeshComponent);
		}
		astaticMeshActor.SetActorEnableCollision(false);
		astaticMeshActor.SetActorHiddenInGame(false);
		astaticMeshActor.D_SetActorScale3D(scale);
		EAttachmentRule rotationRule = followRotation ? EAttachmentRule.SnapToTarget : EAttachmentRule.KeepWorld;
		astaticMeshActor.K2_AttachToActor(this.ActorInternal, FName.NAME_None, EAttachmentRule.SnapToTarget, rotationRule, EAttachmentRule.KeepWorld, true, true);
		astaticMeshActor.D_K2_SetActorRelativeLocation(relativeLocation, false, ref WorldGlobal.SweepHitResult, true);
		BaseActorComponent.RegisterDebugCube(astaticMeshActor);
		return astaticMeshActor;
	}

	// Token: 0x0601AADF RID: 109279 RVA: 0x007EFC8C File Offset: 0x007EDE8C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseActorComponent baseActorComponent = (BaseActorComponent)componentTemplate;
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (baseActorComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("VehicleMoveComp"))
		{
			if (baseActorComponent.VehicleMoveComp == null)
			{
				this.VehicleMoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleMoveComponent>(this.VehicleMoveComp), "VehicleMoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorInternal"))
		{
			if (baseActorComponent.ActorInternal == null)
			{
				this.ActorInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.ActorInternal), "ActorInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CachedActorTransform"))
		{
			this.CachedActorTransform = baseActorComponent.CachedActorTransform;
		}
		if (base.CanResetComponentProperty("CachedActorLocation") && baseActorComponent.CachedActorLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CachedActorLocation), "CachedActorLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CachedActorRotation") && baseActorComponent.CachedActorRotation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.CachedActorRotation), "CachedActorRotation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CachedActorScale") && baseActorComponent.CachedActorScale != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CachedActorScale), "CachedActorScale"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CachedActorQuat") && baseActorComponent.CachedActorQuat != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.CachedActorQuat), "CachedActorQuat"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CachedActorForward") && baseActorComponent.CachedActorForward != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CachedActorForward), "CachedActorForward"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CachedActorRight") && baseActorComponent.CachedActorRight != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CachedActorRight), "CachedActorRight"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CachedActorUp") && baseActorComponent.CachedActorUp != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CachedActorUp), "CachedActorUp"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CachedActorGravityDirect") && baseActorComponent.CachedActorGravityDirect != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CachedActorGravityDirect), "CachedActorGravityDirect"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CachedActorInitNotStandardGravity"))
		{
			this.CachedActorInitNotStandardGravity = baseActorComponent.CachedActorInitNotStandardGravity;
		}
		if (base.CanResetComponentProperty("CachedActorInitGravityRotation"))
		{
			if (baseActorComponent.CachedActorInitGravityRotation == null)
			{
				this.CachedActorInitGravityRotation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.CachedActorInitGravityRotation), "CachedActorInitGravityRotation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CachedLocationTime"))
		{
			this.CachedLocationTime = baseActorComponent.CachedLocationTime;
		}
		if (base.CanResetComponentProperty("CachedForwardTime"))
		{
			this.CachedForwardTime = baseActorComponent.CachedForwardTime;
		}
		if (base.CanResetComponentProperty("CachedScaleTime"))
		{
			this.CachedScaleTime = baseActorComponent.CachedScaleTime;
		}
		if (base.CanResetComponentProperty("CachedRotationTime"))
		{
			this.CachedRotationTime = baseActorComponent.CachedRotationTime;
		}
		if (base.CanResetComponentProperty("CachedTransformTime"))
		{
			this.CachedTransformTime = baseActorComponent.CachedTransformTime;
		}
		if (base.CanResetComponentProperty("CachedRightTime"))
		{
			this.CachedRightTime = baseActorComponent.CachedRightTime;
		}
		if (base.CanResetComponentProperty("CachedUpTime"))
		{
			this.CachedUpTime = baseActorComponent.CachedUpTime;
		}
		if (base.CanResetComponentProperty("CachedVelocityTime"))
		{
			this.CachedVelocityTime = baseActorComponent.CachedVelocityTime;
		}
		if (base.CanResetComponentProperty("CachedActorVelocity") && baseActorComponent.CachedActorVelocity != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CachedActorVelocity), "CachedActorVelocity"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CachedGravityDirectTime"))
		{
			this.CachedGravityDirectTime = baseActorComponent.CachedGravityDirectTime;
		}
		if (base.CanResetComponentProperty("CachedDesiredActorLocation") && baseActorComponent.CachedDesiredActorLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CachedDesiredActorLocation), "CachedDesiredActorLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("IsChangingLocation"))
		{
			this.IsChangingLocation = baseActorComponent.IsChangingLocation;
		}
		if (base.CanResetComponentProperty("CreatureDataInternal"))
		{
			if (baseActorComponent.CreatureDataInternal == null)
			{
				this.CreatureDataInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataInternal), "CreatureDataInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DebugMovementComp"))
		{
			if (baseActorComponent.DebugMovementComp == null)
			{
				this.DebugMovementComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ActorDebugMovementComponent>(this.DebugMovementComp), "DebugMovementComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LogicAutonomous"))
		{
			this.LogicAutonomous = baseActorComponent.LogicAutonomous;
		}
		if (base.CanResetComponentProperty("MoveAutonomous"))
		{
			this.MoveAutonomous = baseActorComponent.MoveAutonomous;
		}
		if (base.CanResetComponentProperty("IsInSequenceBinding"))
		{
			this.IsInSequenceBinding = baseActorComponent.IsInSequenceBinding;
		}
		if (base.CanResetComponentProperty("DisableActorHandle"))
		{
			if (baseActorComponent.DisableActorHandle == null)
			{
				this.DisableActorHandle = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<DisableEntityHandle>(this.DisableActorHandle), "DisableActorHandle"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DisableCollisionHandle"))
		{
			if (baseActorComponent.DisableCollisionHandle == null)
			{
				this.DisableCollisionHandle = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<DisableEntityHandle>(this.DisableCollisionHandle), "DisableCollisionHandle"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorHandleForCommon"))
		{
			this.ActorHandleForCommon = baseActorComponent.ActorHandleForCommon;
		}
		if (base.CanResetComponentProperty("CollisionHandleForCommon"))
		{
			this.CollisionHandleForCommon = baseActorComponent.CollisionHandleForCommon;
		}
		if (base.CanResetComponentProperty("TickHandleForCommon"))
		{
			this.TickHandleForCommon = baseActorComponent.TickHandleForCommon;
		}
		if (base.CanResetComponentProperty("ActorHandleForEntityDisable"))
		{
			this.ActorHandleForEntityDisable = baseActorComponent.ActorHandleForEntityDisable;
		}
		if (base.CanResetComponentProperty("CollisionHandleForEntityDisable"))
		{
			this.CollisionHandleForEntityDisable = baseActorComponent.CollisionHandleForEntityDisable;
		}
		if (base.CanResetComponentProperty("LastActorLocation"))
		{
			if (baseActorComponent.LastActorLocation == null)
			{
				this.LastActorLocation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.LastActorLocation), "LastActorLocation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LastActorRotation"))
		{
			if (baseActorComponent.LastActorRotation == null)
			{
				this.LastActorRotation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.LastActorRotation), "LastActorRotation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SimulatedVelocity"))
		{
			if (baseActorComponent.SimulatedVelocity == null)
			{
				this.SimulatedVelocity = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SimulatedVelocity), "SimulatedVelocity"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SimulatedRotYawSpeed"))
		{
			this.SimulatedRotYawSpeed = baseActorComponent.SimulatedRotYawSpeed;
		}
		if (base.CanResetComponentProperty("Handle"))
		{
			if (baseActorComponent.Handle == null)
			{
				this.Handle = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<EntityHandle>(this.Handle), "Handle"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsRoleAndCtrlByMe"))
		{
			this.IsRoleAndCtrlByMe = baseActorComponent.IsRoleAndCtrlByMe;
		}
		if (base.CanResetComponentProperty("RadiusInternal"))
		{
			this.RadiusInternal = baseActorComponent.RadiusInternal;
		}
		if (base.CanResetComponentProperty("HalfHeightInternal"))
		{
			this.HalfHeightInternal = baseActorComponent.HalfHeightInternal;
		}
		if (base.CanResetComponentProperty("DefaultRadiusInternal"))
		{
			this.DefaultRadiusInternal = baseActorComponent.DefaultRadiusInternal;
		}
		if (base.CanResetComponentProperty("DefaultHalfHeightInternal"))
		{
			this.DefaultHalfHeightInternal = baseActorComponent.DefaultHalfHeightInternal;
		}
		if (base.CanResetComponentProperty("ForbidSettingLocSet") && baseActorComponent.ForbidSettingLocSet != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<EForbidSettingLocAndRotReason>(this.ForbidSettingLocSet), "ForbidSettingLocSet"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ForbidSettingRotSet") && baseActorComponent.ForbidSettingRotSet != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<EForbidSettingLocAndRotReason>(this.ForbidSettingRotSet), "ForbidSettingRotSet"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("OwnedBasePlatform"))
		{
			if (baseActorComponent.OwnedBasePlatform == null)
			{
				this.OwnedBasePlatform = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BasePlatform>(this.OwnedBasePlatform), "OwnedBasePlatform"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ReplaceEffectMap"))
		{
			if (baseActorComponent.ReplaceEffectMap == null)
			{
				this.ReplaceEffectMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, string>>(this.ReplaceEffectMap), "ReplaceEffectMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ReplaceMontageMap"))
		{
			if (baseActorComponent.ReplaceMontageMap == null)
			{
				this.ReplaceMontageMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, string>>(this.ReplaceMontageMap), "ReplaceMontageMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DebugPositionCube"))
		{
			if (baseActorComponent.DebugPositionCube == null)
			{
				this.DebugPositionCube = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AStaticMeshActor>(this.DebugPositionCube), "DebugPositionCube"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DebugFootCube"))
		{
			if (baseActorComponent.DebugFootCube == null)
			{
				this.DebugFootCube = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AStaticMeshActor>(this.DebugFootCube), "DebugFootCube"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DebugForwardCube"))
		{
			if (baseActorComponent.DebugForwardCube == null)
			{
				this.DebugForwardCube = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AStaticMeshActor>(this.DebugForwardCube), "DebugForwardCube"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0601AAE2 RID: 109282 RVA: 0x007F073C File Offset: 0x007EE93C
	[CompilerGenerated]
	private void <EnableActor>g__SetVisible|164_0()
	{
		bool empty = this.DisableActorHandle.Empty;
		this.ActorInternal.SetActorHiddenInGame(!empty);
		Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnSetActorHidden, base.Entity.Id, empty);
		if (this.Handle != null)
		{
			Singleton<EventSystem>.Instance.EmitWithTarget<int, bool>(this.Handle, EEventName.OnSetActorHidden, base.Entity.Id, empty);
		}
	}

	// Token: 0x0400D7DD RID: 55261
	[Nullable(2)]
	public BaseMoveComponent MoveComp;

	// Token: 0x0400D7DE RID: 55262
	[Nullable(2)]
	public VehicleMoveComponent VehicleMoveComp;

	// Token: 0x0400D7DF RID: 55263
	[Nullable(2)]
	protected AActor ActorInternal;

	// Token: 0x0400D7E0 RID: 55264
	protected FTransformDouble? CachedActorTransform;

	// Token: 0x0400D7E1 RID: 55265
	protected readonly global::Vector CachedActorLocation = global::Vector.Create();

	// Token: 0x0400D7E2 RID: 55266
	protected readonly global::Rotator CachedActorRotation = global::Rotator.Create(0f, 0f, 0f);

	// Token: 0x0400D7E3 RID: 55267
	protected readonly global::Vector CachedActorScale = global::Vector.Create();

	// Token: 0x0400D7E4 RID: 55268
	protected readonly Quat CachedActorQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400D7E5 RID: 55269
	protected readonly global::Vector CachedActorForward = global::Vector.Create(1.0, 0.0, 0.0);

	// Token: 0x0400D7E6 RID: 55270
	protected readonly global::Vector CachedActorRight = global::Vector.Create(0.0, 1.0, 0.0);

	// Token: 0x0400D7E7 RID: 55271
	protected readonly global::Vector CachedActorUp = global::Vector.Create(0.0, 0.0, 1.0);

	// Token: 0x0400D7E8 RID: 55272
	protected readonly global::Vector CachedActorGravityDirect = global::Vector.Create(0.0, 0.0, -1.0);

	// Token: 0x0400D7E9 RID: 55273
	protected bool? CachedActorInitNotStandardGravity;

	// Token: 0x0400D7EA RID: 55274
	[Nullable(2)]
	protected global::Rotator CachedActorInitGravityRotation;

	// Token: 0x0400D7EB RID: 55275
	protected int CachedLocationTime = -1;

	// Token: 0x0400D7EC RID: 55276
	protected int CachedForwardTime = -1;

	// Token: 0x0400D7ED RID: 55277
	protected int CachedScaleTime = -1;

	// Token: 0x0400D7EE RID: 55278
	protected int CachedRotationTime = -1;

	// Token: 0x0400D7EF RID: 55279
	protected int CachedTransformTime = -1;

	// Token: 0x0400D7F0 RID: 55280
	protected int CachedRightTime = -1;

	// Token: 0x0400D7F1 RID: 55281
	protected int CachedUpTime = -1;

	// Token: 0x0400D7F2 RID: 55282
	protected int CachedVelocityTime = -1;

	// Token: 0x0400D7F3 RID: 55283
	protected readonly global::Vector CachedActorVelocity = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400D7F4 RID: 55284
	protected int CachedGravityDirectTime = -1;

	// Token: 0x0400D7F5 RID: 55285
	protected readonly global::Vector CachedDesiredActorLocation = global::Vector.Create();

	// Token: 0x0400D7F6 RID: 55286
	protected bool IsChangingLocation;

	// Token: 0x0400D7F7 RID: 55287
	[Nullable(2)]
	protected CreatureDataComponent CreatureDataInternal;

	// Token: 0x0400D7F8 RID: 55288
	[Nullable(2)]
	public ActorDebugMovementComponent DebugMovementComp;

	// Token: 0x0400D7F9 RID: 55289
	private bool LogicAutonomous = true;

	// Token: 0x0400D7FA RID: 55290
	private bool MoveAutonomous = true;

	// Token: 0x0400D7FB RID: 55291
	protected bool IsInSequenceBinding;

	// Token: 0x0400D7FC RID: 55292
	[Nullable(2)]
	public DisableEntityHandle DisableActorHandle;

	// Token: 0x0400D7FD RID: 55293
	[Nullable(2)]
	public DisableEntityHandle DisableCollisionHandle;

	// Token: 0x0400D7FE RID: 55294
	private int? ActorHandleForCommon;

	// Token: 0x0400D7FF RID: 55295
	private int? CollisionHandleForCommon;

	// Token: 0x0400D800 RID: 55296
	private int? TickHandleForCommon;

	// Token: 0x0400D801 RID: 55297
	private int? ActorHandleForEntityDisable;

	// Token: 0x0400D802 RID: 55298
	private int? CollisionHandleForEntityDisable;

	// Token: 0x0400D803 RID: 55299
	public global::Vector LastActorLocation = global::Vector.Create();

	// Token: 0x0400D804 RID: 55300
	public global::Rotator LastActorRotation = global::Rotator.Create();

	// Token: 0x0400D805 RID: 55301
	public global::Vector SimulatedVelocity = global::Vector.Create();

	// Token: 0x0400D806 RID: 55302
	public float SimulatedRotYawSpeed;

	// Token: 0x0400D807 RID: 55303
	[Nullable(2)]
	private EntityHandle Handle;

	// Token: 0x0400D808 RID: 55304
	public bool IsRoleAndCtrlByMe;

	// Token: 0x0400D809 RID: 55305
	protected float RadiusInternal;

	// Token: 0x0400D80A RID: 55306
	protected float HalfHeightInternal;

	// Token: 0x0400D80B RID: 55307
	protected float DefaultRadiusInternal;

	// Token: 0x0400D80C RID: 55308
	protected float DefaultHalfHeightInternal;

	// Token: 0x0400D80D RID: 55309
	private readonly HashSet<EForbidSettingLocAndRotReason> ForbidSettingLocSet = new HashSet<EForbidSettingLocAndRotReason>();

	// Token: 0x0400D80E RID: 55310
	private readonly HashSet<EForbidSettingLocAndRotReason> ForbidSettingRotSet = new HashSet<EForbidSettingLocAndRotReason>();

	// Token: 0x0400D80F RID: 55311
	[Nullable(2)]
	public BasePlatform OwnedBasePlatform;

	// Token: 0x0400D810 RID: 55312
	public Dictionary<string, string> ReplaceEffectMap = new Dictionary<string, string>();

	// Token: 0x0400D811 RID: 55313
	public Dictionary<string, string> ReplaceMontageMap = new Dictionary<string, string>();

	// Token: 0x0400D812 RID: 55314
	[StaticVariableRuleIgnore]
	private static readonly HashSet<AStaticMeshActor> AllDebugCubes = new HashSet<AStaticMeshActor>();

	// Token: 0x0400D813 RID: 55315
	[StaticVariableRuleIgnore]
	private static bool AllDebugCubesVisible = false;

	// Token: 0x0400D814 RID: 55316
	[Nullable(2)]
	[StaticVariableRuleIgnore]
	private static UMaterialInterface DebugCubeMaterialCache = null;

	// Token: 0x0400D815 RID: 55317
	[Nullable(2)]
	private AStaticMeshActor DebugPositionCube;

	// Token: 0x0400D816 RID: 55318
	[Nullable(2)]
	private AStaticMeshActor DebugFootCube;

	// Token: 0x0400D817 RID: 55319
	[Nullable(2)]
	private AStaticMeshActor DebugForwardCube;
}
