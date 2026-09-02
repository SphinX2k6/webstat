using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020031C5 RID: 12741
[NullableContext(2)]
[Nullable(0)]
public class NpcSightController
{
	// Token: 0x0601A69F RID: 108191 RVA: 0x007CA600 File Offset: 0x007C8800
	[NullableContext(1)]
	public NpcSightController(Entity entity)
	{
		this.Entity = entity;
		this.ActorComp = this.Entity.GetComponent<BaseCharacterComponent>();
		this.AnimComp = this.Entity.GetComponent<BaseAnimationComponent>();
		this.CharacterAnimComp = this.Entity.GetComponent<CharacterAnimationComponent>();
		this.PerformComp = this.Entity.GetComponent<CommonNpcPerformComponent>();
	}

	// Token: 0x0601A6A0 RID: 108192 RVA: 0x007CA690 File Offset: 0x007C8890
	public void Init()
	{
		CommonNpcPerformComponent performComp = this.PerformComp;
		if (performComp == null)
		{
			return;
		}
		performComp.HandleCachedStareAction();
	}

	// Token: 0x0601A6A1 RID: 108193 RVA: 0x007CA6A4 File Offset: 0x007C88A4
	public void ChangeSightTarget([Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})] OneOf<BaseActorComponent, Vector, AActor>? target, EStareActionType context)
	{
		if (target != null && target.Value.HasValue)
		{
			StareActionInfo stareActionInfo;
			if (!this.StareActionStackMap.TryGetValue(context, out stareActionInfo))
			{
				stareActionInfo = new StareActionInfo();
				this.StareActionStackMap[context] = stareActionInfo;
			}
			if (target.Value.IsT1)
			{
				BaseActorComponent asT = target.Value.AsT1;
				if (stareActionInfo.TargetItem == asT)
				{
					return;
				}
				stareActionInfo.TargetItem = asT;
				stareActionInfo.TargetActor = null;
				stareActionInfo.TargetLocation.Reset();
				stareActionInfo.IsDirty = true;
			}
			else if (target.Value.IsT2)
			{
				Vector asT2 = target.Value.AsT2;
				if (stareActionInfo.TargetLocation.Equals(asT2, 9.999999747378752E-05))
				{
					return;
				}
				stareActionInfo.TargetLocation = asT2;
				stareActionInfo.TargetItem = null;
				stareActionInfo.TargetActor = null;
				stareActionInfo.IsDirty = true;
			}
			else if (target.Value.IsT3)
			{
				AActor asT3 = target.Value.AsT3;
				if (stareActionInfo.TargetActor == asT3)
				{
					return;
				}
				stareActionInfo.TargetActor = asT3;
				stareActionInfo.TargetLocation.Reset();
				stareActionInfo.TargetItem = null;
				stareActionInfo.IsDirty = true;
			}
			this.TarActionType = Math.Max(this.TarActionType, (int)context);
			this.RefreshTargetType();
			this.RefreshSight(false);
			stareActionInfo.IsDirty = false;
			return;
		}
		StareActionInfo stareActionInfo2;
		if (!this.StareActionStackMap.TryGetValue(context, out stareActionInfo2) || !stareActionInfo2.IsValid())
		{
			return;
		}
		stareActionInfo2.ClearInfo();
		this.RefreshTargetType();
		this.RefreshSight(false);
	}

	// Token: 0x0601A6A2 RID: 108194 RVA: 0x007CA839 File Offset: 0x007C8A39
	public void DelaySetBlendSpaceLookAt(bool enable)
	{
		if (this.CharacterAnimComp == null || this.CharacterAnimComp.EnableBlendSpaceLookAt == enable)
		{
			this.ClearDelayedBlendSpaceLookAt();
			return;
		}
		this.PendingBlendSpaceLookAt = (enable ? NpcSightController.EBlendSpacePendingState.On : NpcSightController.EBlendSpacePendingState.Off);
		this.BlendSpaceLookAtDelayTarget = this.GetCurrentSightTarget();
	}

	// Token: 0x0601A6A3 RID: 108195 RVA: 0x007CA874 File Offset: 0x007C8A74
	[NullableContext(1)]
	public unsafe void EnableSightChange(bool enable, string reason)
	{
		if (enable != this.DisableSightTarget)
		{
			return;
		}
		this.DisableSightTarget = !enable;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.YJX;
		string message = "[NpcSightController] 设置启用视线目标";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
		string item = "PbDataId";
		BaseCharacterComponent actorComp = this.ActorComp;
		ptr = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Enable", enable);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Reason", reason);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		if (enable)
		{
			this.RefreshTargetType();
			this.RefreshSight(true);
			return;
		}
		this.TryApplyDelayedBlendSpaceLookAt(null);
		BaseAnimationComponent animComp = this.AnimComp;
		if (animComp == null)
		{
			return;
		}
		animComp.SetSightTargetItem(null);
	}

	// Token: 0x0601A6A4 RID: 108196 RVA: 0x007CA964 File Offset: 0x007C8B64
	public unsafe void LockSightChange(EStareActionType type, bool bLock)
	{
		if (!bLock)
		{
			if (!this.LockedStareActionTypeSet.Contains(type))
			{
				return;
			}
			this.LockedStareActionTypeSet.Remove(type);
		}
		else
		{
			if (this.LockedStareActionTypeSet.Contains(type))
			{
				return;
			}
			this.LockedStareActionTypeSet.Add(type);
			this.LockActionType = Math.Max(this.LockActionType, (int)type);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.YJX;
		string message = "[NpcSightController] 锁定注视级别";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
		string item = "PbDataId";
		BaseCharacterComponent actorComp = this.ActorComp;
		ptr = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LockType", StareActionTypeHelper.GetActionTypeName((EStareActionType)this.CurActionType));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Lock", bLock);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		this.RefreshTargetLockType();
		this.RefreshSight(true);
	}

	// Token: 0x0601A6A5 RID: 108197 RVA: 0x007CAA74 File Offset: 0x007C8C74
	protected void RefreshSight(bool bForce = false)
	{
		if (this.AnimComp == null)
		{
			return;
		}
		StareActionInfo stareActionInfo;
		if (!bForce && this.CurActionType == this.TarActionType && (!this.StareActionStackMap.TryGetValue((EStareActionType)this.TarActionType, out stareActionInfo) || !stareActionInfo.IsDirty))
		{
			return;
		}
		this.CurActionType = this.TarActionType;
		if (this.TarActionType == -1 || this.TarActionType < this.LockActionType)
		{
			this.TryApplyDelayedBlendSpaceLookAt(null);
			this.AnimComp.SetSightTargetItem(null);
			return;
		}
		StareActionInfo stareActionInfo2 = this.StareActionStackMap[(EStareActionType)this.TarActionType];
		if (stareActionInfo2.TargetItem != null)
		{
			this.TryApplyDelayedBlendSpaceLookAt(new OneOf<BaseActorComponent, Vector, AActor>?(stareActionInfo2.TargetItem));
			this.AnimComp.SetSightTargetItem(stareActionInfo2.TargetItem);
			return;
		}
		if (stareActionInfo2.TargetActor != null)
		{
			this.TryApplyDelayedBlendSpaceLookAt(new OneOf<BaseActorComponent, Vector, AActor>?(stareActionInfo2.TargetActor));
			this.AnimComp.SetSightTargetActor(stareActionInfo2.TargetActor);
			return;
		}
		this.TryApplyDelayedBlendSpaceLookAt(new OneOf<BaseActorComponent, Vector, AActor>?(stareActionInfo2.TargetLocation));
		this.AnimComp.SetSightTargetPoint(stareActionInfo2.TargetLocation);
	}

	// Token: 0x0601A6A6 RID: 108198 RVA: 0x007CAB94 File Offset: 0x007C8D94
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})]
	private OneOf<BaseActorComponent, Vector, AActor>? GetCurrentSightTarget()
	{
		BaseAnimationComponent animComp = this.AnimComp;
		BaseActorComponent baseActorComponent = (animComp != null) ? animComp.GetSightTargetItem() : null;
		if (baseActorComponent != null)
		{
			return new OneOf<BaseActorComponent, Vector, AActor>?(baseActorComponent);
		}
		BaseAnimationComponent animComp2 = this.AnimComp;
		Vector vector = (animComp2 != null) ? animComp2.GetSightTargetPoint() : null;
		if (vector != null)
		{
			return new OneOf<BaseActorComponent, Vector, AActor>?(Vector.Create(vector));
		}
		BaseAnimationComponent animComp3 = this.AnimComp;
		return new OneOf<BaseActorComponent, Vector, AActor>?((animComp3 != null) ? animComp3.GetSightTargetActor() : null);
	}

	// Token: 0x0601A6A7 RID: 108199 RVA: 0x007CAC08 File Offset: 0x007C8E08
	private bool IsSightTargetEqual([Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})] OneOf<BaseActorComponent, Vector, AActor>? left, [Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})] OneOf<BaseActorComponent, Vector, AActor>? right)
	{
		bool flag = left == null || (left.Value.IsT1 && left.Value.AsT1.Entity == null);
		bool flag2 = right == null || (right.Value.IsT1 && right.Value.AsT1.Entity == null);
		if (flag || flag2)
		{
			return flag && flag2;
		}
		if (left.Value.IsT1 && right.Value.IsT1)
		{
			return left.Value.AsT1.Entity.Id == right.Value.AsT1.Entity.Id;
		}
		if (left.Value.IsT2 && right.Value.IsT2)
		{
			return left.Value.AsT2.Equals(right.Value.AsT2, 9.999999747378752E-05);
		}
		return left.Value.Equals(right.Value);
	}

	// Token: 0x0601A6A8 RID: 108200 RVA: 0x007CAD4C File Offset: 0x007C8F4C
	private void TryApplyDelayedBlendSpaceLookAt([Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})] OneOf<BaseActorComponent, Vector, AActor>? target)
	{
		if (this.PendingBlendSpaceLookAt == NpcSightController.EBlendSpacePendingState.None || this.CharacterAnimComp == null)
		{
			return;
		}
		if (this.IsSightTargetEqual(this.BlendSpaceLookAtDelayTarget, target))
		{
			return;
		}
		bool flag = this.PendingBlendSpaceLookAt == NpcSightController.EBlendSpacePendingState.On;
		this.ClearDelayedBlendSpaceLookAt();
		if (this.CharacterAnimComp.EnableBlendSpaceLookAt != flag)
		{
			this.CharacterAnimComp.SetBlendSpaceLookAt(flag);
		}
	}

	// Token: 0x0601A6A9 RID: 108201 RVA: 0x007CADA5 File Offset: 0x007C8FA5
	private void ClearDelayedBlendSpaceLookAt()
	{
		this.PendingBlendSpaceLookAt = NpcSightController.EBlendSpacePendingState.None;
		this.BlendSpaceLookAtDelayTarget = null;
	}

	// Token: 0x0601A6AA RID: 108202 RVA: 0x007CADBC File Offset: 0x007C8FBC
	protected void RefreshTargetType()
	{
		StareActionInfo stareActionInfo;
		while (this.TarActionType >= 0 && (!this.StareActionStackMap.TryGetValue((EStareActionType)this.TarActionType, out stareActionInfo) || !stareActionInfo.IsValid()))
		{
			this.TarActionType--;
		}
	}

	// Token: 0x0601A6AB RID: 108203 RVA: 0x007CADFF File Offset: 0x007C8FFF
	protected void RefreshTargetLockType()
	{
		while (this.LockActionType >= 0 && !this.LockedStareActionTypeSet.Contains((EStareActionType)this.LockActionType))
		{
			this.LockActionType--;
		}
	}

	// Token: 0x0400D532 RID: 54578
	protected Entity Entity;

	// Token: 0x0400D533 RID: 54579
	protected BaseCharacterComponent ActorComp;

	// Token: 0x0400D534 RID: 54580
	protected BaseAnimationComponent AnimComp;

	// Token: 0x0400D535 RID: 54581
	protected CharacterAnimationComponent CharacterAnimComp;

	// Token: 0x0400D536 RID: 54582
	protected CommonNpcPerformComponent PerformComp;

	// Token: 0x0400D537 RID: 54583
	[Nullable(1)]
	protected Dictionary<EStareActionType, StareActionInfo> StareActionStackMap = new Dictionary<EStareActionType, StareActionInfo>();

	// Token: 0x0400D538 RID: 54584
	protected int TarActionType = -1;

	// Token: 0x0400D539 RID: 54585
	protected int CurActionType = -1;

	// Token: 0x0400D53A RID: 54586
	[Nullable(1)]
	protected HashSet<EStareActionType> LockedStareActionTypeSet = new HashSet<EStareActionType>();

	// Token: 0x0400D53B RID: 54587
	protected int LockActionType = -1;

	// Token: 0x0400D53C RID: 54588
	protected bool DisableSightTarget;

	// Token: 0x0400D53D RID: 54589
	private NpcSightController.EBlendSpacePendingState PendingBlendSpaceLookAt = NpcSightController.EBlendSpacePendingState.None;

	// Token: 0x0400D53E RID: 54590
	[Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})]
	private OneOf<BaseActorComponent, Vector, AActor>? BlendSpaceLookAtDelayTarget;

	// Token: 0x020093FC RID: 37884
	[NullableContext(0)]
	private enum EBlendSpacePendingState
	{
		// Token: 0x040312E0 RID: 201440
		On,
		// Token: 0x040312E1 RID: 201441
		Off,
		// Token: 0x040312E2 RID: 201442
		None
	}
}
