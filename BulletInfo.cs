using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02002E04 RID: 11780
[NullableContext(2)]
[Nullable(0)]
public class BulletInfo : IStaticVariableResetter
{
	// Token: 0x06017C86 RID: 97414 RVA: 0x006A0FE0 File Offset: 0x0069F1E0
	static BulletInfo()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BulletInfo.CreateStaticDefaultValue), new Action(BulletInfo.ResetStaticDefaultValue));
	}

	// Token: 0x1700202D RID: 8237
	// (get) Token: 0x06017C87 RID: 97415 RVA: 0x006A0FFF File Offset: 0x0069F1FF
	public int BulletEntityId
	{
		get
		{
			return this.Id;
		}
	}

	// Token: 0x1700202E RID: 8238
	// (get) Token: 0x06017C88 RID: 97416 RVA: 0x006A1007 File Offset: 0x0069F207
	public bool HasCheckedPosition
	{
		get
		{
			return this.HasCheckedPositionInternal;
		}
	}

	// Token: 0x06017C89 RID: 97417 RVA: 0x006A100F File Offset: 0x0069F20F
	public void CheckedPosition()
	{
		this.HasCheckedPositionInternal = true;
	}

	// Token: 0x1700202F RID: 8239
	// (get) Token: 0x06017C8A RID: 97418 RVA: 0x006A1018 File Offset: 0x0069F218
	[Nullable(1)]
	public BulletInitParams BulletInitParams
	{
		[NullableContext(1)]
		get
		{
			return this.InitParams;
		}
	}

	// Token: 0x17002030 RID: 8240
	// (get) Token: 0x06017C8B RID: 97419 RVA: 0x006A1020 File Offset: 0x0069F220
	public FTransformDouble? TransformCreate
	{
		get
		{
			return this.InitParams.InitialTransform;
		}
	}

	// Token: 0x17002031 RID: 8241
	// (get) Token: 0x06017C8C RID: 97420 RVA: 0x006A102D File Offset: 0x0069F22D
	public int BaseVelocityEntityId
	{
		get
		{
			return this.InitParams.BaseVelocityId;
		}
	}

	// Token: 0x17002032 RID: 8242
	// (get) Token: 0x06017C8D RID: 97421 RVA: 0x006A103A File Offset: 0x0069F23A
	[Nullable(1)]
	public string BulletRowName
	{
		[NullableContext(1)]
		get
		{
			return this.InitParams.BulletRowName;
		}
	}

	// Token: 0x06017C8E RID: 97422 RVA: 0x006A1047 File Offset: 0x0069F247
	public BaseActorComponent GetBaseVelocityTarget()
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(this.InitParams.BaseVelocityId);
		if (entity == null)
		{
			return null;
		}
		return entity.GetComponent<BaseActorComponent>();
	}

	// Token: 0x17002033 RID: 8243
	// (get) Token: 0x06017C8F RID: 97423 RVA: 0x006A1069 File Offset: 0x0069F269
	public BulletDataMain BulletDataMain
	{
		get
		{
			return this.Config;
		}
	}

	// Token: 0x17002034 RID: 8244
	// (get) Token: 0x06017C90 RID: 97424 RVA: 0x006A1071 File Offset: 0x0069F271
	public bool IsTensile
	{
		get
		{
			BulletDataMain bulletDataMain = this.BulletDataMain;
			return bulletDataMain != null && bulletDataMain.Move.FollowType == EBulletFollowType.攻击者锁定拉伸;
		}
	}

	// Token: 0x17002035 RID: 8245
	// (get) Token: 0x06017C91 RID: 97425 RVA: 0x006A108C File Offset: 0x0069F28C
	public EntityHandle BaseTransformEntity
	{
		get
		{
			if (!this.BaseTransformEntityHasInit && this.BaseTransformEntityInternal == null)
			{
				EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(this.InitParams.BaseTransformId);
				if (handle != null && handle.Valid)
				{
					this.BaseTransformEntityInternal = handle;
				}
				this.BaseTransformEntityHasInit = true;
			}
			return this.BaseTransformEntityInternal;
		}
	}

	// Token: 0x06017C92 RID: 97426 RVA: 0x006A10E0 File Offset: 0x0069F2E0
	[NullableContext(1)]
	public void SetActorLocation(global::Vector value)
	{
		if (double.IsNaN(value.X) || double.IsNaN(value.Y) || double.IsNaN(value.Z))
		{
			ControllerBase<BulletController>.Instance.DestroyBullet(this.BulletEntityId, false, EBulletDestroyReason.Normal, false);
			return;
		}
		this.LocationCache.FromUeVector(value);
		this.IsCacheLocation = true;
	}

	// Token: 0x06017C93 RID: 97427 RVA: 0x006A113C File Offset: 0x0069F33C
	[NullableContext(1)]
	public void SetActorRotation(global::Rotator value)
	{
		if (float.IsNaN(value.Pitch) || float.IsNaN(value.Yaw) || float.IsNaN(value.Roll))
		{
			ControllerBase<BulletController>.Instance.DestroyBullet(this.BulletEntityId, false, EBulletDestroyReason.Normal, false);
			return;
		}
		this.RotationCache.FromUeRotator(value);
		this.IsCacheRotation = true;
	}

	// Token: 0x06017C94 RID: 97428 RVA: 0x006A1197 File Offset: 0x0069F397
	[NullableContext(1)]
	public global::Vector GetActorLocation()
	{
		if (this.IsCacheLocation)
		{
			return this.LocationCache;
		}
		return this.ActorComponent.ActorLocationProxy;
	}

	// Token: 0x06017C95 RID: 97429 RVA: 0x006A11B3 File Offset: 0x0069F3B3
	[NullableContext(1)]
	public global::Rotator GetActorRotation()
	{
		if (this.IsCacheRotation)
		{
			return this.RotationCache;
		}
		return this.ActorComponent.ActorRotationProxy;
	}

	// Token: 0x06017C96 RID: 97430 RVA: 0x006A11CF File Offset: 0x0069F3CF
	[NullableContext(1)]
	public void GetActorForward(global::Vector outVector)
	{
		if (this.IsCacheRotation)
		{
			this.RotationCache.Vector(outVector);
			return;
		}
		outVector.FromUeVector(this.ActorComponent.ActorForwardProxy);
	}

	// Token: 0x06017C97 RID: 97431 RVA: 0x006A11F7 File Offset: 0x0069F3F7
	[NullableContext(1)]
	public void ActorRotateVector(global::Vector inVector, global::Vector outVector)
	{
		if (this.IsCacheRotation)
		{
			this.RotationCache.Quaternion(null).RotateVector(inVector, outVector);
			return;
		}
		this.ActorComponent.ActorRotationProxy.Quaternion(null).RotateVector(inVector, outVector);
	}

	// Token: 0x06017C98 RID: 97432 RVA: 0x006A122D File Offset: 0x0069F42D
	public void AddBulletLocalRotator(FRotator newRotator)
	{
		this.ApplyCacheLocationAndRotation();
		this.ActorComponent.AddBulletLocalRotator(newRotator);
	}

	// Token: 0x06017C99 RID: 97433 RVA: 0x006A1244 File Offset: 0x0069F444
	public void ApplyCacheLocationAndRotation()
	{
		if (!this.IsCacheLocation)
		{
			if (this.IsCacheRotation)
			{
				this.ActorComponent.SetActorRotation(this.RotationCache.ToUeRotator(), base.GetType().Name, false);
				this.IsCacheRotation = false;
				this.GetCollisionLocationFrame = 0;
			}
			return;
		}
		if (this.IsCacheRotation)
		{
			this.ActorComponent.SetActorLocationAndRotation(this.LocationCache.ToUeVector(false), this.RotationCache.ToUeRotator(), base.GetType().Name, false, null);
			this.IsCacheLocation = false;
			this.IsCacheRotation = false;
			this.GetCollisionLocationFrame = 0;
			return;
		}
		this.ActorComponent.SetActorLocation(this.LocationCache.ToUeVector(false), base.GetType().Name, false);
		this.IsCacheLocation = false;
		this.GetCollisionLocationFrame = 0;
	}

	// Token: 0x06017C9A RID: 97434 RVA: 0x006A131E File Offset: 0x0069F51E
	public void ClearCacheLocationAndRotation()
	{
		this.IsCacheLocation = false;
		this.IsCacheRotation = false;
	}

	// Token: 0x17002036 RID: 8246
	// (get) Token: 0x06017C9B RID: 97435 RVA: 0x006A132E File Offset: 0x0069F52E
	[Nullable(1)]
	public IReadOnlyList<int> Tags
	{
		[NullableContext(1)]
		get
		{
			return this.TagInternal;
		}
	}

	// Token: 0x06017C9C RID: 97436 RVA: 0x006A1336 File Offset: 0x0069F536
	public void AddTag(FGameplayTag tag)
	{
		this.TagInternal.Add(tag.TagId());
	}

	// Token: 0x06017C9D RID: 97437 RVA: 0x006A1349 File Offset: 0x0069F549
	public void AddTagId(int tagId)
	{
		this.TagInternal.Add(tagId);
	}

	// Token: 0x06017C9E RID: 97438 RVA: 0x006A1358 File Offset: 0x0069F558
	public bool HasTag(FGameplayTag newTag)
	{
		if (this.TagInternal.Count > 0)
		{
			using (List<int>.Enumerator enumerator = this.TagInternal.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == newTag.TagId())
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x06017C9F RID: 97439 RVA: 0x006A13C0 File Offset: 0x0069F5C0
	public bool HasTagId(int newTagId)
	{
		List<int> tagInternal = this.TagInternal;
		return tagInternal != null && tagInternal.Contains(newTagId);
	}

	// Token: 0x17002037 RID: 8247
	// (get) Token: 0x06017CA0 RID: 97440 RVA: 0x006A13D4 File Offset: 0x0069F5D4
	[Nullable(1)]
	public global::Vector CenterLocation
	{
		[NullableContext(1)]
		get
		{
			this.ActorComponent.ActorQuatProxy.RotateVector(this.CollisionInfo.CenterLocalLocation, this.CenterLocationInternal);
			this.CenterLocationInternal.AdditionEqual(this.ActorComponent.ActorLocationProxy);
			return this.CenterLocationInternal;
		}
	}

	// Token: 0x17002038 RID: 8248
	// (get) Token: 0x06017CA1 RID: 97441 RVA: 0x006A1414 File Offset: 0x0069F614
	[Nullable(1)]
	public BulletRayInfo RayInfo
	{
		[NullableContext(1)]
		get
		{
			if (this.RayInfoInternal == null)
			{
				this.RayInfoInternal = new BulletRayInfo();
			}
			return this.RayInfoInternal;
		}
	}

	// Token: 0x17002039 RID: 8249
	// (get) Token: 0x06017CA2 RID: 97442 RVA: 0x006A142F File Offset: 0x0069F62F
	public FRotator CollisionRotator
	{
		get
		{
			UPrimitiveComponent collisionComponent = this.CollisionInfo.CollisionComponent;
			if (collisionComponent == null)
			{
				return this.ActorComponent.ActorRotation;
			}
			return collisionComponent.K2_GetComponentRotation();
		}
	}

	// Token: 0x06017CA3 RID: 97443 RVA: 0x006A1454 File Offset: 0x0069F654
	[NullableContext(1)]
	public unsafe global::Vector GetCollisionLocation(bool checkInAfterTick = true)
	{
		if (checkInAfterTick && !BulletInfo.InAfterTick)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "GetCollisionLocation只能在AfterTick中使用";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BulletEntityId", this.BulletEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BulletRowName", this.BulletRowName);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return this.CollisionLocationInternal;
		}
		if (this.GetCollisionLocationFrame < Singleton<Time>.Instance.Frame)
		{
			this.GetCollisionLocationFrame = Singleton<Time>.Instance.Frame;
			if (!this.IsCollisionRelativeLocationZero && this.CollisionInfo.CollisionComponent != null)
			{
				global::Vector collisionLocationInternal = this.CollisionLocationInternal;
				FVectorDouble fvectorDouble = this.CollisionInfo.CollisionComponent.D_K2_GetComponentLocation();
				collisionLocationInternal.FromUeVector(fvectorDouble);
			}
			else
			{
				this.CollisionLocationInternal.FromUeVector(this.ActorComponent.ActorLocationProxy);
			}
		}
		return this.CollisionLocationInternal;
	}

	// Token: 0x1700203A RID: 8250
	// (get) Token: 0x06017CA4 RID: 97444 RVA: 0x006A1547 File Offset: 0x0069F747
	public int AttackerId
	{
		get
		{
			return this.AttackerIdInternal;
		}
	}

	// Token: 0x1700203B RID: 8251
	// (get) Token: 0x06017CA5 RID: 97445 RVA: 0x006A154F File Offset: 0x0069F74F
	public EntityHandle AttackerHandle
	{
		get
		{
			return this.AttackerInternal;
		}
	}

	// Token: 0x1700203C RID: 8252
	// (get) Token: 0x06017CA6 RID: 97446 RVA: 0x006A1557 File Offset: 0x0069F757
	public Entity Attacker
	{
		get
		{
			EntityHandle attackerInternal = this.AttackerInternal;
			if (attackerInternal == null)
			{
				return null;
			}
			return attackerInternal.Entity;
		}
	}

	// Token: 0x06017CA7 RID: 97447 RVA: 0x006A156A File Offset: 0x0069F76A
	private void ClearAttacker()
	{
		this.AttackerInternal = null;
		this.AttackerCreatureDataCompInternal = null;
		this.AttackerActorCompInternal = null;
		this.AttackerSkillCompInternal = null;
		this.AttackerBuffCompInternal = null;
		this.AttackerMoveCompInternal = null;
		this.AttackerAudioCompInternal = null;
		this.AttackerTagCompInternal = null;
	}

	// Token: 0x1700203D RID: 8253
	// (get) Token: 0x06017CA8 RID: 97448 RVA: 0x006A15A4 File Offset: 0x0069F7A4
	public CreatureDataComponent AttackerCreatureDataComp
	{
		get
		{
			if (this.AttackerCreatureDataCompInternal == null)
			{
				Entity attacker = this.Attacker;
				this.AttackerCreatureDataCompInternal = ((attacker != null) ? attacker.GetComponent<CreatureDataComponent>() : null);
			}
			return this.AttackerCreatureDataCompInternal;
		}
	}

	// Token: 0x1700203E RID: 8254
	// (get) Token: 0x06017CA9 RID: 97449 RVA: 0x006A15CC File Offset: 0x0069F7CC
	public BaseActorComponent AttackerActorComp
	{
		get
		{
			if (this.AttackerActorCompInternal == null)
			{
				Entity attacker = this.Attacker;
				this.AttackerActorCompInternal = ((attacker != null) ? attacker.GetComponent<BaseActorComponent>() : null);
			}
			return this.AttackerActorCompInternal;
		}
	}

	// Token: 0x1700203F RID: 8255
	// (get) Token: 0x06017CAA RID: 97450 RVA: 0x006A15F4 File Offset: 0x0069F7F4
	public BaseSkillComponent AttackerSkillComp
	{
		get
		{
			if (this.AttackerSkillCompInternal == null)
			{
				Entity attacker = this.Attacker;
				this.AttackerSkillCompInternal = ((attacker != null) ? attacker.GetComponent<BaseSkillComponent>() : null);
			}
			return this.AttackerSkillCompInternal;
		}
	}

	// Token: 0x17002040 RID: 8256
	// (get) Token: 0x06017CAB RID: 97451 RVA: 0x006A161C File Offset: 0x0069F81C
	public BaseBuffComponent AttackerBuffComp
	{
		get
		{
			if (this.AttackerBuffCompInternal == null)
			{
				Entity attacker = this.Attacker;
				this.AttackerBuffCompInternal = ((attacker != null) ? attacker.GetComponent<BaseBuffComponent>() : null);
			}
			return this.AttackerBuffCompInternal;
		}
	}

	// Token: 0x17002041 RID: 8257
	// (get) Token: 0x06017CAC RID: 97452 RVA: 0x006A1644 File Offset: 0x0069F844
	public CharacterMoveComponent AttackerMoveComp
	{
		get
		{
			if (this.AttackerMoveCompInternal == null)
			{
				Entity attacker = this.Attacker;
				this.AttackerMoveCompInternal = ((attacker != null) ? attacker.GetComponent<CharacterMoveComponent>() : null);
			}
			return this.AttackerMoveCompInternal;
		}
	}

	// Token: 0x17002042 RID: 8258
	// (get) Token: 0x06017CAD RID: 97453 RVA: 0x006A166C File Offset: 0x0069F86C
	public CharacterAudioComponent AttackerAudioComponent
	{
		get
		{
			if (this.AttackerAudioCompInternal == null)
			{
				Entity attacker = this.Attacker;
				this.AttackerAudioCompInternal = ((attacker != null) ? attacker.GetComponent<CharacterAudioComponent>() : null);
			}
			return this.AttackerAudioCompInternal;
		}
	}

	// Token: 0x17002043 RID: 8259
	// (get) Token: 0x06017CAE RID: 97454 RVA: 0x006A1694 File Offset: 0x0069F894
	public BaseTagComponent AttackerTagComponent
	{
		get
		{
			if (this.AttackerTagCompInternal == null)
			{
				Entity attacker = this.Attacker;
				this.AttackerTagCompInternal = ((attacker != null) ? attacker.GetComponent<BaseTagComponent>() : null);
			}
			return this.AttackerTagCompInternal;
		}
	}

	// Token: 0x17002044 RID: 8260
	// (get) Token: 0x06017CAF RID: 97455 RVA: 0x006A16BC File Offset: 0x0069F8BC
	public Entity Target
	{
		get
		{
			if (this.TargetIsEntityInternal)
			{
				return Singleton<EntitySystem>.Instance.Get(this.TargetId);
			}
			if (this.TargetInternal == null)
			{
				return null;
			}
			EntityHandle targetInternal = this.TargetInternal;
			if (targetInternal == null)
			{
				return null;
			}
			return targetInternal.Entity;
		}
	}

	// Token: 0x06017CB0 RID: 97456 RVA: 0x006A16F4 File Offset: 0x0069F8F4
	public void SetTargetById(int entityId)
	{
		EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(entityId);
		if (handle != null && handle.Valid)
		{
			this.RemoveTargetRemoveEvent();
			this.TargetId = entityId;
			this.TargetInternal = handle;
			this.TargetIsEntityInternal = false;
			this.TargetActorCompInternal = null;
			this.AddTargetRemoveEvent();
			return;
		}
		this.ClearTarget();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity != null && entity.Valid)
		{
			this.TargetId = entityId;
			this.TargetIsEntityInternal = true;
		}
	}

	// Token: 0x06017CB1 RID: 97457 RVA: 0x006A176E File Offset: 0x0069F96E
	public void ClearTarget()
	{
		this.RemoveTargetRemoveEvent();
		this.TargetInternal = null;
		this.TargetId = 0;
		this.TargetActorCompInternal = null;
		this.TargetIsEntityInternal = false;
	}

	// Token: 0x17002045 RID: 8261
	// (get) Token: 0x06017CB2 RID: 97458 RVA: 0x006A1794 File Offset: 0x0069F994
	public BaseActorComponent TargetActorComp
	{
		get
		{
			if (this.TargetIsEntityInternal)
			{
				return Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(this.TargetId);
			}
			if (this.TargetActorCompInternal == null)
			{
				Entity target = this.Target;
				this.TargetActorCompInternal = ((target != null) ? target.GetComponent<BaseActorComponent>() : null);
			}
			return this.TargetActorCompInternal;
		}
	}

	// Token: 0x06017CB3 RID: 97459 RVA: 0x006A17E0 File Offset: 0x0069F9E0
	public BaseActorComponent GetLockOnTargetDynamic()
	{
		EntityHandle attackerInternal = this.AttackerInternal;
		object obj;
		if (attackerInternal == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = attackerInternal.Entity;
			if (entity == null)
			{
				obj = null;
			}
			else
			{
				CharacterLockOnComponent component = entity.GetComponent<CharacterLockOnComponent>();
				obj = ((component != null) ? component.GetCurrentTarget() : null);
			}
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return null;
		}
		WorldEntity entity2 = obj2.Entity;
		if (entity2 == null)
		{
			return null;
		}
		return entity2.GetComponent<BaseActorComponent>();
	}

	// Token: 0x17002046 RID: 8262
	// (get) Token: 0x06017CB4 RID: 97460 RVA: 0x006A182D File Offset: 0x0069FA2D
	public int ParentEntityId
	{
		get
		{
			return this.InitParams.ParentId;
		}
	}

	// Token: 0x17002047 RID: 8263
	// (get) Token: 0x06017CB5 RID: 97461 RVA: 0x006A183A File Offset: 0x0069FA3A
	// (set) Token: 0x06017CB6 RID: 97462 RVA: 0x006A1850 File Offset: 0x0069FA50
	public long? ContextId
	{
		get
		{
			if (!this.ContextIdSubmitted)
			{
				this.ReportContextIdNotSubmitted();
			}
			return this.ContextIdInternal;
		}
		set
		{
			this.ContextIdInternal = value;
		}
	}

	// Token: 0x17002048 RID: 8264
	// (get) Token: 0x06017CB7 RID: 97463 RVA: 0x006A1859 File Offset: 0x0069FA59
	public long? ContextIdRaw
	{
		get
		{
			return this.ContextIdInternal;
		}
	}

	// Token: 0x06017CB8 RID: 97464 RVA: 0x006A1864 File Offset: 0x0069FA64
	private void ReportContextIdNotSubmitted()
	{
		if (!Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			return;
		}
		BulletLog.Error(true, ELogAuthor.HCW, this.Attacker, "[子弹协议时序错误] 引用 ContextId 早于 CreateBulletPush，应在 OnAfterInit 之后执行", this, default(ReadOnlySpan<ValueTuple<string, object>>));
		UWorld world = GlobalData.World;
		if (world != null)
		{
			UKismetSystemLibrary.PrintString(world, this.BulletRowName, true, false, new FLinearColor?(new FLinearColor(1f, 0f, 0f, 1f)), 20f);
		}
	}

	// Token: 0x06017CB9 RID: 97465 RVA: 0x006A18D8 File Offset: 0x0069FAD8
	[NullableContext(1)]
	public void Init(BulletInitParams initParams, BulletDataMain config)
	{
		this.InitParams = initParams;
		this.Config = config;
		this.ActionInfoList.Clear();
		this.NextActionInfoList.Clear();
		this.PersistentActionList.Clear();
		Entity owner = this.InitParams.Owner;
		this.AttackerIdInternal = ((owner != null) ? owner.Id : 0);
		this.AttackerInternal = ModelBase<CharacterModel>.Instance.GetHandle(this.AttackerIdInternal);
		this.IsInit = false;
		this.NeedDestroy = false;
		this.ShakeNumbers = 0;
		this.HitNumberAll = 0;
		this.GetCollisionLocationFrame = 0;
		this.SkillBoneName = new FName?(Singleton<BulletConstant>.Instance.HitCase);
		this.PreContextId = null;
		this.ContextId = null;
		this.ContextIdSubmitted = false;
		if (initParams.LocationOffset != null)
		{
			global::Vector bornLocationOffset = this.BornLocationOffset;
			FVector value = initParams.LocationOffset.Value;
			bornLocationOffset.FromUeVector(value);
			this.BornLocationOffset.AdditionEqual(config.Base.BornPosition);
		}
		else
		{
			this.BornLocationOffset.FromUeVector(config.Base.BornPosition);
		}
		if (Singleton<PerformanceController>.Instance.IsEntityTickPerformanceTest)
		{
			this.BornFrameCount = new long?(UKismetSystemLibrary.GetFrameCount());
		}
	}

	// Token: 0x06017CBA RID: 97466 RVA: 0x006A1A12 File Offset: 0x0069FC12
	[NullableContext(1)]
	public void InitEntity(BulletEntity entity)
	{
		this.Entity = entity;
		this.Id = entity.Id;
	}

	// Token: 0x06017CBB RID: 97467 RVA: 0x006A1A28 File Offset: 0x0069FC28
	public void Clear()
	{
		this.Id = 0;
		this.Entity = null;
		this.InitParams = null;
		this.Config = null;
		BulletActionCenter actionCenter = ControllerBase<BulletController>.Instance.GetActionCenter();
		foreach (BulletActionInfoBase actionInfo in this.ActionInfoList)
		{
			actionCenter.RecycleBulletActionInfo(actionInfo);
		}
		foreach (BulletActionInfoBase actionInfo2 in this.NextActionInfoList)
		{
			actionCenter.RecycleBulletActionInfo(actionInfo2);
		}
		foreach (BulletActionBase action in this.PersistentActionList)
		{
			actionCenter.RecycleBulletAction(action);
		}
		this.ActionInfoList.Clear();
		this.NextActionInfoList.Clear();
		this.PersistentActionList.Clear();
		this.Actor = null;
		this.ActorComponent = null;
		this.ActionLogicComponent = null;
		this.IsInit = false;
		this.HasCheckedPositionInternal = false;
		this.NeedDestroy = false;
		this.IsDestroyByCharSkillEnd = false;
		this.GenerateTime = 0f;
		this.BulletCamp = 0;
		this.BaseTransformEntityInternal = null;
		this.IsCacheLocation = false;
		this.IsCacheRotation = false;
		this.LocationCache.Reset();
		this.RotationCache.Reset();
		this.RandomInitSpeedOffset.Reset();
		this.RandomPosOffset.Reset();
		this.ShakeNumbers = 0;
		this.IsFrozen = false;
		this.FrozenTime = null;
		this.IsShield = false;
		this.InitPosition.Reset();
		this.TagInternal.Clear();
		this.CreateFrame = 0;
		this.LiveTimeAddDelta = 0f;
		this.LiveTime = 0f;
		this.IsTimeNotEnough = false;
		this.BaseSize.Reset();
		this.Size.Reset();
		this.CenterLocationInternal.Reset();
		this.CloseCollision = false;
		this.CollisionLocationInternal.Reset();
		this.GetCollisionLocationFrame = 0;
		this.IsCollisionRelativeLocationZero = false;
		this.IsCollisionRelativeRotationModify = false;
		this.AttackerIdInternal = 0;
		this.ClearAttacker();
		this.IsAutonomousProxy = false;
		this.AttackerCamp = ECamp.Player;
		this.AttackerPlayerId = 0;
		this.SkillBoneName = null;
		this.SkillLevel = 0;
		this.ClearTarget();
		this.TargetIdLast = 0;
		this.TargetIsEntityInternal = false;
		this.ParentBulletInfo = null;
		this.ChildEntityIds = null;
		this.ParentEffect = 0;
		this.NeedNotifyChildrenWhenDestroy = false;
		this.HitNumberAll = 0;
		this.EntityHitSet.Clear();
		this.EntityHitCount.Clear();
		this.CountByParent = false;
		this.TimeScaleList = null;
		this.TimeScaleMap = null;
		this.TimeScaleId = 0;
		this.SummonSkillId = 0;
		this.SummonAttackerId = 0;
		this.SummonServerEntityId = 0L;
		this.CollisionInfo.Clear();
		BulletKuroFastCollisionInfo kuroFastCollisionInfo = this.KuroFastCollisionInfo;
		if (kuroFastCollisionInfo != null)
		{
			kuroFastCollisionInfo.Clear();
		}
		this.KuroFastCollisionInfo = null;
		this.MoveInfo.Clear();
		BulletStaticFunction.DestroyEffect(this, true);
		this.EffectInfo.Clear();
		BulletAdditionInfo additionInfo = this.AdditionInfo;
		if (additionInfo != null)
		{
			additionInfo.Clear();
		}
		this.ChildInfo = null;
		this.RayInfoInternal = null;
		this.BornLocationOffset.Reset();
		this.ContextId = null;
		this.PreContextId = null;
		this.BaseTransformEntityHasInit = false;
		this.ParentIds = null;
		if (Singleton<BulletConstant>.Instance.OpenClearCheck)
		{
			BulletInfo.CheckClear(this);
		}
		this.ContextIdSubmitted = false;
	}

	// Token: 0x06017CBC RID: 97468 RVA: 0x006A1DD4 File Offset: 0x0069FFD4
	public void SwapActionInfoList()
	{
		this.ActionInfoList.Clear();
		if (this.NextActionInfoList.Count > 0)
		{
			List<BulletActionInfoBase> actionInfoList = this.ActionInfoList;
			this.ActionInfoList = this.NextActionInfoList;
			this.NextActionInfoList = actionInfoList;
		}
	}

	// Token: 0x06017CBD RID: 97469 RVA: 0x006A1E14 File Offset: 0x006A0014
	private void AddTargetRemoveEvent()
	{
		if (this.TargetInternal == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(this.TargetInternal, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnTargetRemove));
	}

	// Token: 0x06017CBE RID: 97470 RVA: 0x006A1E41 File Offset: 0x006A0041
	private void RemoveTargetRemoveEvent()
	{
		if (this.TargetInternal == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget(this.TargetInternal, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnTargetRemove));
	}

	// Token: 0x06017CBF RID: 97471 RVA: 0x006A1E6E File Offset: 0x006A006E
	[NullableContext(1)]
	private void OnTargetRemove(ERemoveEntityType eRemoveEntityType, EntityHandle entityHandle)
	{
		this.ClearTarget();
	}

	// Token: 0x06017CC0 RID: 97472 RVA: 0x006A1E78 File Offset: 0x006A0078
	[NullableContext(1)]
	private unsafe static void CheckClear(object obj)
	{
		foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
		{
			if (!(propertyInfo.Name == "ContextId") && !(propertyInfo.Name == "ContextIdRaw"))
			{
				object value = propertyInfo.GetValue(obj);
				if (value != null)
				{
					Type type = value.GetType();
					if ((!(type == typeof(int)) || (int)value != 0) && (!(type == typeof(bool)) || (bool)value))
					{
						if (value is BulletCollisionInfo || value is BulletMoveInfo || value is BulletEffectInfo)
						{
							BulletInfo.CheckClear(value);
						}
						else
						{
							global::Vector vector = value as global::Vector;
							if (vector != null)
							{
								if (!vector.IsZero())
								{
									Log instance = Singleton<Log>.Instance;
									ELogModule module = ELogModule.Bullet;
									ELogAuthor author = ELogAuthor.CFT;
									string message = "BulletInfo回收时，Vector没重置";
									ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", propertyInfo.Name);
									instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
								}
							}
							else
							{
								global::Rotator rotator = value as global::Rotator;
								if (rotator != null)
								{
									if (!rotator.IsNearlyZero())
									{
										Log instance2 = Singleton<Log>.Instance;
										ELogModule module2 = ELogModule.Bullet;
										ELogAuthor author2 = ELogAuthor.CFT;
										string message2 = "BulletInfo回收时，Rotator没重置";
										ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("key", propertyInfo.Name);
										instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
									}
								}
								else
								{
									global::Transform transform = value as global::Transform;
									if (transform != null)
									{
										if (!transform.GetLocation().IsZero() || !transform.GetScale3D().IsZero() || transform.GetRotation().X != 0f || transform.GetRotation().Y != 0f || transform.GetRotation().Z != 0f || transform.GetRotation().W != 1f)
										{
											Log instance3 = Singleton<Log>.Instance;
											ELogModule module3 = ELogModule.Bullet;
											ELogAuthor author3 = ELogAuthor.CFT;
											string message3 = "BulletInfo回收时，Transform没重置";
											ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("key", propertyInfo.Name);
											instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
										}
									}
									else
									{
										IList list = value as IList;
										if (list != null)
										{
											if (list.Count != 0)
											{
												Log instance4 = Singleton<Log>.Instance;
												ELogModule module4 = ELogModule.Bullet;
												ELogAuthor author4 = ELogAuthor.CFT;
												string message4 = "BulletInfo回收时，Array没清空";
												ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("key", propertyInfo.Name);
												instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
											}
										}
										else
										{
											IDictionary dictionary = value as IDictionary;
											if (dictionary != null)
											{
												if (dictionary.Count != 0)
												{
													Log instance5 = Singleton<Log>.Instance;
													ELogModule module5 = ELogModule.Bullet;
													ELogAuthor author5 = ELogAuthor.CFT;
													string message5 = "BulletInfo回收时，Map没清空";
													ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("key", propertyInfo.Name);
													instance5.Error(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
												}
											}
											else
											{
												ICollection collection = value as ICollection;
												if (collection != null)
												{
													if (collection.Count != 0)
													{
														Log instance6 = Singleton<Log>.Instance;
														ELogModule module6 = ELogModule.Bullet;
														ELogAuthor author6 = ELogAuthor.CFT;
														string message6 = "BulletInfo回收时，Set没清空";
														ValueTuple<string, object> valueTuple6 = new ValueTuple<string, object>("key", propertyInfo.Name);
														instance6.Error(module6, author6, message6, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple6));
													}
												}
												else
												{
													Log instance7 = Singleton<Log>.Instance;
													ELogModule module7 = ELogModule.Bullet;
													ELogAuthor author7 = ELogAuthor.CFT;
													string message7 = "BulletInfo回收时，该变量不为undefined";
													<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
													*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("type", type.Name);
													*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("key", propertyInfo.Name);
													instance7.Error(module7, author7, message7, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06017CC1 RID: 97473 RVA: 0x006A21E0 File Offset: 0x006A03E0
	public void OnTargetInValid()
	{
		switch (this.BulletDataMain.Move.TrackTarget)
		{
		case EBulletTarget.队伍角色:
		case EBulletTarget.攻击者锁定目标动态:
		case EBulletTarget.外部传入坐标:
			break;
		case EBulletTarget.技能目标:
		case EBulletTarget.攻击者锁定目标静态:
		case EBulletTarget.自定义目标:
		case EBulletTarget.子弹发射者:
		case EBulletTarget.父子弹受击者:
		case EBulletTarget.父子弹目标:
		case EBulletTarget.前台角色锁定目标:
		case EBulletTarget.技能目标前台:
			this.SetTargetById(0);
			break;
		default:
			return;
		}
	}

	// Token: 0x17002049 RID: 8265
	// (get) Token: 0x06017CC2 RID: 97474 RVA: 0x006A223A File Offset: 0x006A043A
	// (set) Token: 0x06017CC3 RID: 97475 RVA: 0x006A2242 File Offset: 0x006A0442
	public float Duration
	{
		get
		{
			return this.DurationInternal;
		}
		set
		{
			this.DurationInternal = value;
		}
	}

	// Token: 0x06017CC4 RID: 97476 RVA: 0x006A224B File Offset: 0x006A044B
	public static void CreateStaticDefaultValue()
	{
		BulletInfo.InAfterTick = false;
	}

	// Token: 0x06017CC5 RID: 97477 RVA: 0x006A2253 File Offset: 0x006A0453
	public static void ResetStaticDefaultValue()
	{
		BulletInfo.InAfterTick = false;
	}

	// Token: 0x0400B810 RID: 47120
	private int Id;

	// Token: 0x0400B811 RID: 47121
	public BulletEntity Entity;

	// Token: 0x0400B812 RID: 47122
	private bool HasCheckedPositionInternal;

	// Token: 0x0400B813 RID: 47123
	private BulletInitParams InitParams;

	// Token: 0x0400B814 RID: 47124
	private BulletDataMain Config;

	// Token: 0x0400B815 RID: 47125
	[Nullable(1)]
	public List<BulletActionInfoBase> ActionInfoList = new List<BulletActionInfoBase>();

	// Token: 0x0400B816 RID: 47126
	[Nullable(1)]
	public List<BulletActionInfoBase> NextActionInfoList = new List<BulletActionInfoBase>();

	// Token: 0x0400B817 RID: 47127
	[Nullable(1)]
	public List<BulletActionBase> PersistentActionList = new List<BulletActionBase>();

	// Token: 0x0400B818 RID: 47128
	public AActor Actor;

	// Token: 0x0400B819 RID: 47129
	public BulletActorComponent ActorComponent;

	// Token: 0x0400B81A RID: 47130
	public BulletActionLogicComponent ActionLogicComponent;

	// Token: 0x0400B81B RID: 47131
	public bool IsInit;

	// Token: 0x0400B81C RID: 47132
	public bool NeedDestroy;

	// Token: 0x0400B81D RID: 47133
	public bool IsDestroyByCharSkillEnd;

	// Token: 0x0400B81E RID: 47134
	public float GenerateTime;

	// Token: 0x0400B81F RID: 47135
	public int BulletCamp;

	// Token: 0x0400B820 RID: 47136
	public int ShakeNumbers;

	// Token: 0x0400B821 RID: 47137
	public bool IsFrozen;

	// Token: 0x0400B822 RID: 47138
	public float? FrozenTime;

	// Token: 0x0400B823 RID: 47139
	public bool IsShield;

	// Token: 0x0400B824 RID: 47140
	private EntityHandle BaseTransformEntityInternal;

	// Token: 0x0400B825 RID: 47141
	private bool BaseTransformEntityHasInit;

	// Token: 0x0400B826 RID: 47142
	[Nullable(1)]
	public readonly global::Vector RandomPosOffset = global::Vector.Create();

	// Token: 0x0400B827 RID: 47143
	[Nullable(1)]
	public readonly global::Vector RandomInitSpeedOffset = global::Vector.Create();

	// Token: 0x0400B828 RID: 47144
	private bool IsCacheLocation;

	// Token: 0x0400B829 RID: 47145
	private bool IsCacheRotation;

	// Token: 0x0400B82A RID: 47146
	[Nullable(1)]
	private readonly global::Vector LocationCache = global::Vector.Create();

	// Token: 0x0400B82B RID: 47147
	[Nullable(1)]
	private readonly global::Rotator RotationCache = global::Rotator.Create();

	// Token: 0x0400B82C RID: 47148
	[Nullable(1)]
	public readonly global::Vector InitPosition = global::Vector.Create();

	// Token: 0x0400B82D RID: 47149
	[Nullable(1)]
	private readonly List<int> TagInternal = new List<int>();

	// Token: 0x0400B82E RID: 47150
	public int CreateFrame;

	// Token: 0x0400B82F RID: 47151
	public float LiveTimeRatio = 1f;

	// Token: 0x0400B830 RID: 47152
	public float LiveTimeAddDelta;

	// Token: 0x0400B831 RID: 47153
	public float LiveTime;

	// Token: 0x0400B832 RID: 47154
	public float LiveTimeCurHit;

	// Token: 0x0400B833 RID: 47155
	public bool IsTimeNotEnough;

	// Token: 0x0400B834 RID: 47156
	[Nullable(1)]
	public readonly global::Vector BaseSize = global::Vector.Create();

	// Token: 0x0400B835 RID: 47157
	[Nullable(1)]
	public readonly global::Vector Size = global::Vector.Create();

	// Token: 0x0400B836 RID: 47158
	[Nullable(1)]
	private readonly global::Vector CenterLocationInternal = global::Vector.Create();

	// Token: 0x0400B837 RID: 47159
	private BulletRayInfo RayInfoInternal;

	// Token: 0x0400B838 RID: 47160
	public bool CloseCollision;

	// Token: 0x0400B839 RID: 47161
	[Nullable(1)]
	public BulletCollisionInfo CollisionInfo = new BulletCollisionInfo();

	// Token: 0x0400B83A RID: 47162
	public BulletKuroFastCollisionInfo KuroFastCollisionInfo;

	// Token: 0x0400B83B RID: 47163
	[Nullable(1)]
	private readonly global::Vector CollisionLocationInternal = global::Vector.Create();

	// Token: 0x0400B83C RID: 47164
	public int GetCollisionLocationFrame;

	// Token: 0x0400B83D RID: 47165
	public bool IsCollisionRelativeLocationZero;

	// Token: 0x0400B83E RID: 47166
	public bool IsCollisionRelativeRotationModify;

	// Token: 0x0400B83F RID: 47167
	public static bool InAfterTick;

	// Token: 0x0400B840 RID: 47168
	[Nullable(1)]
	public BulletMoveInfo MoveInfo = new BulletMoveInfo();

	// Token: 0x0400B841 RID: 47169
	[Nullable(1)]
	public BulletEffectInfo EffectInfo = new BulletEffectInfo();

	// Token: 0x0400B842 RID: 47170
	private int AttackerIdInternal;

	// Token: 0x0400B843 RID: 47171
	private EntityHandle AttackerInternal;

	// Token: 0x0400B844 RID: 47172
	private CreatureDataComponent AttackerCreatureDataCompInternal;

	// Token: 0x0400B845 RID: 47173
	private BaseActorComponent AttackerActorCompInternal;

	// Token: 0x0400B846 RID: 47174
	private BaseSkillComponent AttackerSkillCompInternal;

	// Token: 0x0400B847 RID: 47175
	private BaseBuffComponent AttackerBuffCompInternal;

	// Token: 0x0400B848 RID: 47176
	private CharacterMoveComponent AttackerMoveCompInternal;

	// Token: 0x0400B849 RID: 47177
	private CharacterAudioComponent AttackerAudioCompInternal;

	// Token: 0x0400B84A RID: 47178
	private BaseTagComponent AttackerTagCompInternal;

	// Token: 0x0400B84B RID: 47179
	public bool IsAutonomousProxy;

	// Token: 0x0400B84C RID: 47180
	public ECamp AttackerCamp;

	// Token: 0x0400B84D RID: 47181
	public int AttackerPlayerId;

	// Token: 0x0400B84E RID: 47182
	public FName? SkillBoneName;

	// Token: 0x0400B84F RID: 47183
	public int SkillLevel;

	// Token: 0x0400B850 RID: 47184
	public int TargetId;

	// Token: 0x0400B851 RID: 47185
	public int TargetIdLast;

	// Token: 0x0400B852 RID: 47186
	private EntityHandle TargetInternal;

	// Token: 0x0400B853 RID: 47187
	private bool TargetIsEntityInternal;

	// Token: 0x0400B854 RID: 47188
	private BaseActorComponent TargetActorCompInternal;

	// Token: 0x0400B855 RID: 47189
	public BulletInfo ParentBulletInfo;

	// Token: 0x0400B856 RID: 47190
	public List<int> ChildEntityIds;

	// Token: 0x0400B857 RID: 47191
	public BulletChildInfo ChildInfo;

	// Token: 0x0400B858 RID: 47192
	public int ParentEffect;

	// Token: 0x0400B859 RID: 47193
	public bool NeedNotifyChildrenWhenDestroy;

	// Token: 0x0400B85A RID: 47194
	public int HitNumberAll;

	// Token: 0x0400B85B RID: 47195
	[Nullable(1)]
	public readonly HashSet<int> EntityHitSet = new HashSet<int>();

	// Token: 0x0400B85C RID: 47196
	[Nullable(1)]
	public readonly Dictionary<int, int> EntityHitCount = new Dictionary<int, int>();

	// Token: 0x0400B85D RID: 47197
	public bool CountByParent;

	// Token: 0x0400B85E RID: 47198
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public PriorityQueue<TimeScale> TimeScaleList;

	// Token: 0x0400B85F RID: 47199
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, TimeScale> TimeScaleMap;

	// Token: 0x0400B860 RID: 47200
	public int TimeScaleId;

	// Token: 0x0400B861 RID: 47201
	public int SummonSkillId;

	// Token: 0x0400B862 RID: 47202
	public int SummonAttackerId;

	// Token: 0x0400B863 RID: 47203
	public long SummonServerEntityId;

	// Token: 0x0400B864 RID: 47204
	public long? BornFrameCount;

	// Token: 0x0400B865 RID: 47205
	public long? PreContextId;

	// Token: 0x0400B866 RID: 47206
	private long? ContextIdInternal;

	// Token: 0x0400B867 RID: 47207
	public bool ContextIdSubmitted;

	// Token: 0x0400B868 RID: 47208
	[Nullable(1)]
	public readonly global::Vector BornLocationOffset = global::Vector.Create();

	// Token: 0x0400B869 RID: 47209
	public BulletAdditionInfo AdditionInfo;

	// Token: 0x0400B86A RID: 47210
	private float DurationInternal;

	// Token: 0x0400B86B RID: 47211
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public HashSet<string> ParentIds;
}
