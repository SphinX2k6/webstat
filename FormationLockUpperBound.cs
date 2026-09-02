using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F2B RID: 12075
[NullableContext(1)]
[Nullable(0)]
public class FormationLockUpperBound : BuffEffect
{
	// Token: 0x06018B87 RID: 101255 RVA: 0x006FBCFB File Offset: 0x006F9EFB
	public FormationLockUpperBound(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B88 RID: 101256 RVA: 0x006FBD14 File Offset: 0x006F9F14
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

	// Token: 0x06018B89 RID: 101257 RVA: 0x006FBD94 File Offset: 0x006F9F94
	public override void OnCreated()
	{
		if (this.AttributeId != (EFormationAttributeId)(-1))
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			if (ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority())
			{
				ControllerBase<FormationAttributeController>.Instance.AddBoundsLocker(this.AttributeId, new BoundsLocker
				{
					LockUpperBounds = true,
					LockLowerBounds = false,
					UpperPercent = this.Percent * 0.0001f,
					UpperOffset = this.Offset,
					LowerPercent = 0f,
					LowerOffset = 0f
				}, this.ActiveHandleId);
			}
		}
	}

	// Token: 0x06018B8A RID: 101258 RVA: 0x006FBE1C File Offset: 0x006FA01C
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018B8B RID: 101259 RVA: 0x006FBE1F File Offset: 0x006FA01F
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

	// Token: 0x0400C08F RID: 49295
	protected EFormationAttributeId AttributeId = (EFormationAttributeId)(-1);

	// Token: 0x0400C090 RID: 49296
	protected float Offset;

	// Token: 0x0400C091 RID: 49297
	protected float Percent;
}
