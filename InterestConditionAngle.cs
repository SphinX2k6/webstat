using System;
using System.Runtime.CompilerServices;

// Token: 0x020031BD RID: 12733
[NullableContext(1)]
[Nullable(0)]
public class InterestConditionAngle : InterestConditionBase
{
	// Token: 0x170023E5 RID: 9189
	// (get) Token: 0x0601A66E RID: 108142 RVA: 0x007C8F25 File Offset: 0x007C7125
	public override EInterestConditionType Type
	{
		get
		{
			return EInterestConditionType.Angle;
		}
	}

	// Token: 0x0601A66F RID: 108143 RVA: 0x007C8F28 File Offset: 0x007C7128
	public override bool CheckCondition(Entity entity, InterestItemBase item)
	{
		BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
		if (component == null)
		{
			return false;
		}
		Vector location = this.GetLocation(item);
		if (location == null)
		{
			return false;
		}
		location.Subtraction(component.ActorLocationProxy, InterestConditionBase.TmpVector1);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(component, InterestConditionBase.TmpVector1);
		InterestConditionBase.TmpVector1.Normalize(9.99999993922529E-09);
		return Singleton<MathUtils>.Instance.GetAngleByVectorDot(InterestConditionBase.TmpVector1, component.ActorForwardProxy) < (double)this.MaxAngle;
	}

	// Token: 0x0601A670 RID: 108144 RVA: 0x007C8FA4 File Offset: 0x007C71A4
	[return: Nullable(2)]
	private Vector GetLocation(InterestItemBase item)
	{
		EInterestItemType type = item.Type;
		if (type != EInterestItemType.Entity)
		{
			if (type == EInterestItemType.Position)
			{
				return ((InterestItemPosition)item).Position;
			}
			return null;
		}
		else
		{
			Entity entity = ((InterestItemEntity)item).GetEntity();
			BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
			if (baseActorComponent == null)
			{
				return null;
			}
			return baseActorComponent.ActorLocationProxy;
		}
	}

	// Token: 0x0400D50B RID: 54539
	public float MaxAngle;
}
