using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F62 RID: 12130
[NullableContext(1)]
[Nullable(0)]
public abstract class ModifierCalculator : SnapModifyBuffEffect
{
	// Token: 0x06018CAF RID: 101551 RVA: 0x00702810 File Offset: 0x00700A10
	protected ModifierCalculator(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018CB0 RID: 101552 RVA: 0x00702832 File Offset: 0x00700A32
	private float GetAttrValueWithThreshold(SnapshotPayload snapshots, EAttributeType attrId, EAttributeRefType attributeType, ESnapAttributeSourceType targetType)
	{
		if (this.AttributeThreshold > 0f)
		{
			return Math.Max(base.GetAttrValue(snapshots, attrId, attributeType, targetType) - this.AttributeThreshold, 0f);
		}
		return base.GetAttrValue(snapshots, attrId, attributeType, targetType);
	}

	// Token: 0x06018CB1 RID: 101553 RVA: 0x0070286C File Offset: 0x00700A6C
	protected float CalculateValue(SnapshotPayload snapshots)
	{
		float num = this.RefParam1;
		if (this.StackParam.Length != 0 && this.StackParam[0] == 1L)
		{
			float num2 = num;
			IActiveBuff buff = base.Buff;
			num = num2 * (float)((buff != null) ? buff.StackCount : 1);
		}
		else if (this.StackParam.Length != 0 && this.StackParam[0] == 2L)
		{
			BaseDamageComponent baseDamageComponent = (this.StackParam[1] == 0L) ? snapshots.Attacker : snapshots.Target;
			float num3 = num;
			int? num4;
			if (baseDamageComponent == null)
			{
				num4 = null;
			}
			else
			{
				CharacterBuffComponent ownerBuffComponent = baseDamageComponent.OwnerBuffComponent;
				num4 = ((ownerBuffComponent != null) ? new int?(ownerBuffComponent.GetBuffTotalStackById(this.StackParam[2], false)) : null);
			}
			int? num5 = num4;
			num = num3 * (float)num5.GetValueOrDefault(1);
		}
		float refParam = this.RefParam2;
		float num6 = 0f;
		switch (this.CalculationPolicy)
		{
		case ESnapCalculateType.Add:
			num6 = num;
			break;
		case ESnapCalculateType.AddPerTenThousand:
		{
			float num7 = num * 0.0001f;
			num6 = this.GetAttrValueWithThreshold(snapshots, this.RefAttrId, this.RefValueType, this.RefTargetType) * num7;
			break;
		}
		case ESnapCalculateType.AddAttributeMultiPerTenThousand:
		{
			float num8 = num * 0.0001f;
			num6 = this.GetAttrValueWithThreshold(snapshots, this.RefAttrId, this.RefValueType, this.RefTargetType) * num8 + refParam;
			break;
		}
		}
		if (this.ModifierMax > 0f && num6 > this.ModifierMax)
		{
			num6 = this.ModifierMax;
		}
		return num6;
	}

	// Token: 0x0400C150 RID: 49488
	public ESnapCalculateType CalculationPolicy;

	// Token: 0x0400C151 RID: 49489
	public EAttributeType RefAttrId;

	// Token: 0x0400C152 RID: 49490
	public EAttributeRefType RefValueType;

	// Token: 0x0400C153 RID: 49491
	public long[] StackParam = new long[0];

	// Token: 0x0400C154 RID: 49492
	public ESnapAttributeSourceType RefTargetType = ESnapAttributeSourceType.Attacker;

	// Token: 0x0400C155 RID: 49493
	public float AttributeThreshold;

	// Token: 0x0400C156 RID: 49494
	public float ModifierMax;

	// Token: 0x0400C157 RID: 49495
	public float RefParam1;

	// Token: 0x0400C158 RID: 49496
	public float RefParam2;
}
