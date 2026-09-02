using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F2C RID: 12076
[NullableContext(1)]
[Nullable(0)]
public class FormationLockLowerBound : BuffEffect
{
	// Token: 0x06018B8C RID: 101260 RVA: 0x006FBE55 File Offset: 0x006FA055
	public FormationLockLowerBound(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B8D RID: 101261 RVA: 0x006FBE6C File Offset: 0x006FA06C
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length == 0)
		{
			return;
		}
		this.AttributeId = (EFormationAttributeId)int.Parse(extraEffectParameters_[0]);
		this.Percent = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters1, this.Level, 0f);
		this.Offset = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters2, this.Level, 0f);
		if (extraEffectParameters_.Length > 2 && !string.IsNullOrEmpty(extraEffectParameters_[2]))
		{
			this.Percent = float.Parse(extraEffectParameters_[2]);
		}
	}

	// Token: 0x06018B8E RID: 101262 RVA: 0x006FBEEC File Offset: 0x006FA0EC
	public override void OnCreated()
	{
		if (this.AttributeId != (EFormationAttributeId)(-1))
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			if (ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority())
			{
				ControllerBase<FormationAttributeController>.Instance.AddBoundsLocker(this.AttributeId, new BoundsLocker
				{
					LockUpperBounds = false,
					LockLowerBounds = true,
					UpperPercent = 0f,
					UpperOffset = 0f,
					LowerPercent = this.Percent * 0.0001f,
					LowerOffset = this.Offset
				}, this.ActiveHandleId);
			}
		}
	}

	// Token: 0x06018B8F RID: 101263 RVA: 0x006FBF74 File Offset: 0x006FA174
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018B90 RID: 101264 RVA: 0x006FBF77 File Offset: 0x006FA177
	public override void OnRemoved(bool bPremature)
	{
		if (this.AttributeId != (EFormationAttributeId)(-1))
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			if (ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority())
			{
				ControllerBase<FormationAttributeController>.Instance.RemoveBoundsLocker(this.AttributeId, this.ActiveHandleId);
			}
		}
	}

	// Token: 0x0400C092 RID: 49298
	protected EFormationAttributeId AttributeId = (EFormationAttributeId)(-1);

	// Token: 0x0400C093 RID: 49299
	protected float Offset;

	// Token: 0x0400C094 RID: 49300
	protected float Percent;
}
