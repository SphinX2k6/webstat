using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F1C RID: 12060
[NullableContext(1)]
[Nullable(0)]
public class ExtraEffectDamageAugment : BuffEffect
{
	// Token: 0x06018B4A RID: 101194 RVA: 0x006F9B87 File Offset: 0x006F7D87
	public ExtraEffectDamageAugment(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B4B RID: 101195 RVA: 0x006F9B98 File Offset: 0x006F7D98
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		float[] extraEffectGrowParameters = parameters.ExtraEffectGrowParameters1;
		float[] extraEffectGrowParameters2 = parameters.ExtraEffectGrowParameters2;
		int level = this.Level;
		this.AttrId = (EAttributeType)int.Parse(extraEffectParameters_[0]);
		this.RefValueType = (EAttributeRefType)int.Parse(extraEffectParameters_[1]);
		this.RefParam1 = AbilityUtils.GetLevelValue<float>(extraEffectGrowParameters, level, 0f);
		this.RefParam2 = AbilityUtils.GetLevelValue<float>(extraEffectGrowParameters2, level, 0f);
	}

	// Token: 0x06018B4C RID: 101196 RVA: 0x006F9C04 File Offset: 0x006F7E04
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		EAttributeType attrId = this.AttrId;
		EntityHandle instigatorEntity = base.InstigatorEntity;
		BaseAttributeComponent baseAttributeComponent;
		if (instigatorEntity == null)
		{
			baseAttributeComponent = null;
		}
		else
		{
			WorldEntity entity = instigatorEntity.Entity;
			baseAttributeComponent = ((entity != null) ? entity.CheckGetComponent<BaseAttributeComponent>() : null);
		}
		BaseAttributeComponent baseAttributeComponent2 = baseAttributeComponent;
		float refParam = this.RefParam1;
		float refParam2 = this.RefParam2;
		float num = refParam * 0.0001f;
		float num2 = 0f;
		EAttributeRefType refValueType = this.RefValueType;
		if (refValueType != EAttributeRefType.BaseValue)
		{
			if (refValueType == EAttributeRefType.CurrentValue)
			{
				num2 = baseAttributeComponent2.GetCurrentValue(attrId);
			}
		}
		else
		{
			num2 = baseAttributeComponent2.GetBaseValue(attrId);
		}
		return Math.Max(num2 * num + refParam2, 0f);
	}

	// Token: 0x06018B4D RID: 101197 RVA: 0x006F9C90 File Offset: 0x006F7E90
	public static float ApplyEffects(RequirementPayload requirements, SnapshotPayload snapshots)
	{
		BaseBuffComponent ownerBuffComponent = snapshots.Attacker.OwnerBuffComponent;
		CharacterBuffComponent ownerBuffComponent2 = snapshots.Target.OwnerBuffComponent;
		float num = 0f;
		foreach (ExtraEffectDamageAugment extraEffectDamageAugment in ownerBuffComponent.BuffEffectManager.FilterById<ExtraEffectDamageAugment>(EExtraEffectId.DamageAugment, null))
		{
			if (extraEffectDamageAugment.Check(requirements, ownerBuffComponent2))
			{
				num += (float)(extraEffectDamageAugment.Execute(Array.Empty<object>()) ?? 0f);
			}
		}
		return num;
	}

	// Token: 0x0400C062 RID: 49250
	private EAttributeType AttrId;

	// Token: 0x0400C063 RID: 49251
	private float RefParam1;

	// Token: 0x0400C064 RID: 49252
	private float RefParam2;

	// Token: 0x0400C065 RID: 49253
	private EAttributeRefType RefValueType;
}
