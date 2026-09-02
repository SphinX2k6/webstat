using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020031B8 RID: 12728
[NullableContext(1)]
[Nullable(0)]
public class InterestActionLookAt : InterestActionBase
{
	// Token: 0x170023DF RID: 9183
	// (get) Token: 0x0601A655 RID: 108117 RVA: 0x007C8CC2 File Offset: 0x007C6EC2
	public override EInterestActionType Type
	{
		get
		{
			return EInterestActionType.LookAt;
		}
	}

	// Token: 0x170023E0 RID: 9184
	// (get) Token: 0x0601A656 RID: 108118 RVA: 0x007C8CC5 File Offset: 0x007C6EC5
	public override bool IsExclusive
	{
		get
		{
			return true;
		}
	}

	// Token: 0x0601A657 RID: 108119 RVA: 0x007C8CC8 File Offset: 0x007C6EC8
	public override void OnEnter(Entity entity, InterestItemBase item)
	{
		CommonNpcPerformComponent component = entity.GetComponent<CommonNpcPerformComponent>();
		if (component == null)
		{
			return;
		}
		OneOf<BaseActorComponent, Vector, AActor>? lookAtTarget = this.GetLookAtTarget(item);
		if (lookAtTarget == null)
		{
			return;
		}
		component.SightTarget(lookAtTarget, EStareActionType.InterestEvent);
	}

	// Token: 0x0601A658 RID: 108120 RVA: 0x007C8CFC File Offset: 0x007C6EFC
	public override void OnLeave(Entity entity, InterestItemBase item)
	{
		CommonNpcPerformComponent component = entity.GetComponent<CommonNpcPerformComponent>();
		if (component == null)
		{
			return;
		}
		component.SightTarget(null, EStareActionType.InterestEvent);
	}

	// Token: 0x0601A659 RID: 108121 RVA: 0x007C8D24 File Offset: 0x007C6F24
	public override int GetPriority(Entity entity, InterestItemBase item)
	{
		BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
		if (component == null)
		{
			return int.MaxValue;
		}
		if (!item.GetLocation(InterestActionBase.TmpVector1))
		{
			return int.MaxValue;
		}
		return (int)Vector.DistSquared(component.ActorLocationProxy, InterestActionBase.TmpVector1);
	}

	// Token: 0x0601A65A RID: 108122 RVA: 0x007C8D68 File Offset: 0x007C6F68
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})]
	private OneOf<BaseActorComponent, Vector, AActor>? GetLookAtTarget(InterestItemBase item)
	{
		EInterestItemType type = item.Type;
		if (type == EInterestItemType.Entity)
		{
			Entity entity = ((InterestItemEntity)item).GetEntity();
			return new OneOf<BaseActorComponent, Vector, AActor>?((entity != null) ? entity.GetComponent<BaseActorComponent>() : null);
		}
		if (type == EInterestItemType.Position)
		{
			return new OneOf<BaseActorComponent, Vector, AActor>?(((InterestItemPosition)item).Position);
		}
		return null;
	}
}
