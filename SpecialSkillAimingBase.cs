using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003141 RID: 12609
[NullableContext(1)]
[Nullable(0)]
public abstract class SpecialSkillAimingBase : SpecialSkillBase
{
	// Token: 0x17002370 RID: 9072
	// (get) Token: 0x0601A197 RID: 106903
	protected abstract int AimingTagId { get; }

	// Token: 0x17002371 RID: 9073
	// (get) Token: 0x0601A198 RID: 106904
	protected abstract EEventName SwitchLockTargetEventName { get; }

	// Token: 0x0601A199 RID: 106905 RVA: 0x007A8452 File Offset: 0x007A6652
	protected SpecialSkillAimingBase(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A19A RID: 106906 RVA: 0x007A8494 File Offset: 0x007A6694
	public override void OnStart()
	{
		this.ActorComp = this.SpecialSkillComponent.Entity.GetComponent<CharacterActorComponent>();
		this.TagComp = this.SpecialSkillComponent.Entity.GetComponent<BaseTagComponent>();
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.IsAutonomousProxy)
		{
			this.LockOnTarget = new AimingLockOnInfo();
			BaseTagComponent tagComp = this.TagComp;
			this.TagTask = ((tagComp != null) ? tagComp.ListenForTagAddOrRemove(new int?(this.AimingTagId), delegate(int tagId, bool tagExist)
			{
				this.OnAimingTagChanged(tagExist);
			}, null) : null);
			this.OnAimingTagChanged(this.TagComp.HasTag(this.AimingTagId));
		}
	}

	// Token: 0x0601A19B RID: 106907 RVA: 0x007A8533 File Offset: 0x007A6733
	public override void OnEnd()
	{
		this.ClearLockOnTarget();
		ITagTask tagTask = this.TagTask;
		if (tagTask != null)
		{
			tagTask.EndTask();
		}
		if (this.EnableLockOn)
		{
			this.EnableLockOn = false;
			this.OnAimingEnd();
		}
	}

	// Token: 0x0601A19C RID: 106908 RVA: 0x007A8564 File Offset: 0x007A6764
	public override void OnTick(float delta)
	{
		if (!this.EnableLockOn)
		{
			return;
		}
		if (this.TimeCount == 0f)
		{
			this.LockOn();
		}
		this.TimeCount += delta;
		if (this.TimeCount > (float)this.GapTime)
		{
			this.TimeCount = 0f;
		}
	}

	// Token: 0x0601A19D RID: 106909 RVA: 0x007A85B5 File Offset: 0x007A67B5
	protected virtual void OnAimingStart()
	{
	}

	// Token: 0x0601A19E RID: 106910 RVA: 0x007A85B7 File Offset: 0x007A67B7
	protected virtual void OnAimingEnd()
	{
		this.TimeCount = 0f;
	}

	// Token: 0x0601A19F RID: 106911
	protected abstract void DoOnTargetLocked(EntityHandle target, string socketName);

	// Token: 0x0601A1A0 RID: 106912
	protected abstract void DoOnTargetUnlocked(EntityHandle target, string socketName);

	// Token: 0x0601A1A1 RID: 106913
	protected abstract void LockOn();

	// Token: 0x0601A1A2 RID: 106914 RVA: 0x007A85C4 File Offset: 0x007A67C4
	protected void OnTargetLocked(EntityHandle target, string socketName)
	{
		this.DoOnTargetLocked(target, socketName);
	}

	// Token: 0x0601A1A3 RID: 106915 RVA: 0x007A85CE File Offset: 0x007A67CE
	protected void OnTargetUnlocked(EntityHandle target, string socketName)
	{
		this.DoOnTargetUnlocked(target, socketName);
	}

	// Token: 0x0601A1A4 RID: 106916 RVA: 0x007A85D8 File Offset: 0x007A67D8
	private void OnAimingTagChanged(bool tagExist)
	{
		if (this.EnableLockOn == tagExist)
		{
			return;
		}
		this.ClearLockOnTarget();
		this.EnableLockOn = tagExist;
		this.TimeCount = 0f;
		if (tagExist)
		{
			this.OnAimingStart();
			return;
		}
		this.OnAimingEnd();
	}

	// Token: 0x0601A1A5 RID: 106917 RVA: 0x007A860C File Offset: 0x007A680C
	private void ClearLockOnTarget()
	{
		AimingLockOnInfo lockOnTarget = this.LockOnTarget;
		if (((lockOnTarget != null) ? lockOnTarget.Target : null) == null)
		{
			return;
		}
		this.OnTargetUnlocked(this.LockOnTarget.Target, this.LockOnTarget.SocketName);
		this.LockOnTarget.Reset();
		Singleton<EventSystem>.Instance.Emit<EntityHandle, string>(this.SwitchLockTargetEventName, null, "");
	}

	// Token: 0x0601A1A6 RID: 106918 RVA: 0x007A866C File Offset: 0x007A686C
	protected void LockOnCircle(int distance, int radius)
	{
		this.LockOnShape(distance, delegate(Vector2D screenPos)
		{
			double num = screenPos.Size();
			if (num > (double)radius)
			{
				return double.MaxValue;
			}
			return num;
		});
	}

	// Token: 0x0601A1A7 RID: 106919 RVA: 0x007A869C File Offset: 0x007A689C
	protected void LockOnRect(int distance, int halfWidth, int halfHeight)
	{
		this.LockOnShape(distance, delegate(Vector2D screenPos)
		{
			double num = Math.Abs(screenPos.X);
			double num2 = Math.Abs(screenPos.Y);
			if (num > (double)halfWidth || num2 > (double)halfHeight)
			{
				return double.MaxValue;
			}
			return screenPos.Size();
		});
	}

	// Token: 0x0601A1A8 RID: 106920 RVA: 0x007A86D0 File Offset: 0x007A68D0
	private void LockOnShape(int distance, Func<Vector2D, double> getShapeScore)
	{
		List<EntityHandle> list = new List<EntityHandle>();
		ModelBase<CreatureModel>.Instance.GetEntitiesInRange((float)distance, EEntityTypeQuery.Character, list, true, false);
		ECamp camp = this.ActorComp.Actor.Camp;
		AimingCandidate aimingCandidate = null;
		HashSet<EntityHandle> hashSet = new HashSet<EntityHandle>();
		foreach (EntityHandle entityHandle in list)
		{
			if (LockOnUtils.IsValidLockOnTarget(entityHandle, null, null, false))
			{
				WorldEntity entity = entityHandle.Entity;
				if (((entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null) != null)
				{
					BaseCharacterComponent component = entityHandle.Entity.GetComponent<BaseCharacterComponent>();
					if (component != null && CampUtils.GetCampRelationship(component.Actor.Camp, camp) == ERelation.Enemy)
					{
						CreatureDataComponent component2 = entityHandle.Entity.GetComponent<CreatureDataComponent>();
						if (((component2 != null) ? new EEntityType?(component2.GetEntityType()) : null).GetValueOrDefault() == EEntityType.Monster)
						{
							hashSet.Add(entityHandle);
							CharacterActorComponent component3 = entityHandle.Entity.GetComponent<CharacterActorComponent>();
							Dictionary<string, UPrimitiveComponent> dictionary = (component3 != null) ? component3.GetMapPartCollision() : null;
							if (component3 != null && component3.LockOnParts.Count > 0)
							{
								using (Dictionary<string, LockOnPart>.Enumerator enumerator2 = component3.LockOnParts.GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										KeyValuePair<string, LockOnPart> keyValuePair = enumerator2.Current;
										LockOnPart value = keyValuePair.Value;
										if (value.SoftLockValid)
										{
											AimingCandidate aimingCandidate2 = this.CheckLockOnPoint(entityHandle, "", value.BoneNameString, getShapeScore);
											if (aimingCandidate2 != null && (aimingCandidate == null || aimingCandidate2.Score < aimingCandidate.Score))
											{
												aimingCandidate = aimingCandidate2;
											}
										}
									}
									continue;
								}
							}
							if (dictionary != null && dictionary.Count > 0)
							{
								using (Dictionary<string, UPrimitiveComponent>.Enumerator enumerator3 = dictionary.GetEnumerator())
								{
									while (enumerator3.MoveNext())
									{
										KeyValuePair<string, UPrimitiveComponent> keyValuePair2 = enumerator3.Current;
										string key = keyValuePair2.Key;
										AimingCandidate aimingCandidate3 = this.CheckLockOnPoint(entityHandle, key, "", getShapeScore);
										if (aimingCandidate3 != null && (aimingCandidate == null || aimingCandidate3.Score < aimingCandidate.Score))
										{
											aimingCandidate = aimingCandidate3;
										}
									}
									continue;
								}
							}
							AimingCandidate aimingCandidate4 = this.CheckLockOnPoint(entityHandle, "", "", getShapeScore);
							if (aimingCandidate4 != null && (aimingCandidate == null || aimingCandidate4.Score < aimingCandidate.Score))
							{
								aimingCandidate = aimingCandidate4;
							}
						}
					}
				}
			}
		}
		EntityHandle entityHandle2 = (aimingCandidate != null) ? aimingCandidate.Handle : null;
		string text = ((aimingCandidate != null) ? aimingCandidate.SocketName : null) ?? "";
		if (aimingCandidate != null)
		{
			this.TmpActorLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			AActor owner = aimingCandidate.Handle.Entity.GetComponent<BaseActorComponent>().Owner;
			AActor aactor = this.TraceDetectBlock(this.TmpActorLocation, aimingCandidate.TargetLocation, owner);
			if (aactor != null)
			{
				EntityHandle entityHandle3 = this.FindHandleByActor(aactor, hashSet);
				if (entityHandle3 != null)
				{
					entityHandle2 = entityHandle3;
					text = "";
				}
			}
		}
		if (entityHandle2 != this.LockOnTarget.Target || text != this.LockOnTarget.SocketName)
		{
			if (this.LockOnTarget.Target != null)
			{
				this.OnTargetUnlocked(this.LockOnTarget.Target, this.LockOnTarget.SocketName);
			}
			if (entityHandle2 != null)
			{
				this.OnTargetLocked(entityHandle2, text);
			}
			this.LockOnTarget.Target = entityHandle2;
			this.LockOnTarget.SocketName = text;
			Singleton<EventSystem>.Instance.Emit<EntityHandle, string>(this.SwitchLockTargetEventName, entityHandle2, text);
		}
	}

	// Token: 0x0601A1A9 RID: 106921 RVA: 0x007A8A80 File Offset: 0x007A6C80
	[return: Nullable(2)]
	protected AimingCandidate CheckLockOnPoint(EntityHandle handle, string partName, string socketName, Func<Vector2D, double> getShapeScore)
	{
		global::Vector lockOnPointLocation = this.GetLockOnPointLocation(handle, partName, socketName);
		if (lockOnPointLocation == null)
		{
			return null;
		}
		if (!HudUnitUtils.PositionUtil.ProjectWorldToScreen(lockOnPointLocation.ToUeVector(false), this.ScreenPos))
		{
			return null;
		}
		double num = getShapeScore(this.ScreenPos);
		if (num == 1.7976931348623157E+308)
		{
			return null;
		}
		WorldEntity entity = handle.Entity;
		AActor aactor;
		if (entity == null)
		{
			aactor = null;
		}
		else
		{
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			aactor = ((component != null) ? component.Owner : null);
		}
		AActor aactor2 = aactor;
		if (aactor2 != null && aactor2.IsValid() && !aactor2.WasRecentlyRenderedOnScreen(0.1f))
		{
			return null;
		}
		global::Vector targetLocation = global::Vector.Create(lockOnPointLocation);
		return new AimingCandidate
		{
			Handle = handle,
			SocketName = socketName,
			Score = num,
			TargetLocation = targetLocation
		};
	}

	// Token: 0x0601A1AA RID: 106922 RVA: 0x007A8B34 File Offset: 0x007A6D34
	[return: Nullable(2)]
	private AActor TraceDetectBlock(global::Vector from, global::Vector to, [Nullable(2)] AActor targetActor)
	{
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.索敌无视遮挡"]))
		{
			return null;
		}
		if (this.AimingLineTrace == null)
		{
			this.AimingLineTrace = UE.NewObject<UTraceLineElement>(null, null, EObjectFlags.RF_NoFlags);
			this.AimingLineTrace.bIsSingle = true;
			this.AimingLineTrace.bIgnoreSelf = true;
			this.AimingLineTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnMonster);
		}
		UTraceLineElement aimingLineTrace = this.AimingLineTrace;
		aimingLineTrace.WorldContextObject = this.ActorComp.Owner;
		aimingLineTrace.SetDrawDebugTrace(EDrawDebugTrace.ForOneFrame);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(aimingLineTrace, from);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(aimingLineTrace, to);
		if (!Singleton<TraceElementCommon>.Instance.LineTrace(aimingLineTrace, "SpecialSkillAimingBase_TraceDetectBlock") || !aimingLineTrace.HitResult.bBlockingHit)
		{
			return null;
		}
		TWeakObjectPtr<AActor> weak = aimingLineTrace.HitResult.Actors.Get(0);
		AActor aactor = ModelBase<CreatureModel>.Instance.GetEntityActorByChildActor(weak) ?? weak;
		if (aactor == targetActor)
		{
			return null;
		}
		return aactor;
	}

	// Token: 0x0601A1AB RID: 106923 RVA: 0x007A8C34 File Offset: 0x007A6E34
	[return: Nullable(2)]
	private EntityHandle FindHandleByActor(AActor hitActor, HashSet<EntityHandle> validHandles)
	{
		foreach (EntityHandle entityHandle in validHandles)
		{
			WorldEntity entity = entityHandle.Entity;
			BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
			if (((baseActorComponent != null) ? baseActorComponent.Owner : null) == hitActor)
			{
				return entityHandle;
			}
		}
		return null;
	}

	// Token: 0x0601A1AC RID: 106924 RVA: 0x007A8CA4 File Offset: 0x007A6EA4
	[return: Nullable(2)]
	private global::Vector GetLockOnPointLocation(EntityHandle handle, string partName, string socketName)
	{
		if (!string.IsNullOrEmpty(socketName))
		{
			this.GetBoneLocation(handle, socketName, this.TmpBoneLocation);
			return this.TmpBoneLocation;
		}
		if (!string.IsNullOrEmpty(partName))
		{
			WorldEntity entity = handle.Entity;
			CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
			if (characterActorComponent != null)
			{
				global::Vector tmpBoneLocation = this.TmpBoneLocation;
				FVectorDouble boneLocation = characterActorComponent.GetBoneLocation(partName);
				tmpBoneLocation.FromUeVector(boneLocation);
				return this.TmpBoneLocation;
			}
		}
		WorldEntity entity2 = handle.Entity;
		BaseActorComponent baseActorComponent = (entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null;
		if (baseActorComponent == null)
		{
			return null;
		}
		return baseActorComponent.ActorLocationProxy;
	}

	// Token: 0x0601A1AD RID: 106925 RVA: 0x007A8D28 File Offset: 0x007A6F28
	protected void GetBoneLocation(EntityHandle target, string boneName, global::Vector @out)
	{
		if (target.Entity == null)
		{
			@out.Reset();
			return;
		}
		FTransformDouble? targetSocketTransform = SkillUtils.GetTargetSocketTransform(target.Entity, boneName, ERelativeTransformSpace.RTS_World, "瞄准特殊技能", ESocketTransformDefault.BaseActor);
		if (targetSocketTransform != null)
		{
			FVectorDouble location = targetSocketTransform.Value.GetLocation();
			@out.FromUeVector(location);
			return;
		}
		@out.Reset();
	}

	// Token: 0x0400D176 RID: 53622
	private const string PROFILE_KEY = "SpecialSkillAimingBase_TraceDetectBlock";

	// Token: 0x0400D177 RID: 53623
	protected readonly int GapTime = 200;

	// Token: 0x0400D178 RID: 53624
	protected readonly int Distance = 5000;

	// Token: 0x0400D179 RID: 53625
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400D17A RID: 53626
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400D17B RID: 53627
	[Nullable(2)]
	private ITagTask TagTask;

	// Token: 0x0400D17C RID: 53628
	private bool EnableLockOn;

	// Token: 0x0400D17D RID: 53629
	[Nullable(2)]
	private AimingLockOnInfo LockOnTarget;

	// Token: 0x0400D17E RID: 53630
	private float TimeCount;

	// Token: 0x0400D17F RID: 53631
	private readonly Vector2D ScreenPos = new Vector2D();

	// Token: 0x0400D180 RID: 53632
	private readonly global::Vector TmpBoneLocation = global::Vector.Create();

	// Token: 0x0400D181 RID: 53633
	private readonly global::Vector TmpActorLocation = global::Vector.Create();

	// Token: 0x0400D182 RID: 53634
	[Nullable(2)]
	private UTraceLineElement AimingLineTrace;
}
