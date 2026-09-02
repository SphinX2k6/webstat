using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F2D RID: 12077
[NullableContext(1)]
[Nullable(0)]
public class ModifyFormationAttributeMax : BuffEffect
{
	// Token: 0x06018B91 RID: 101265 RVA: 0x006FBFAD File Offset: 0x006FA1AD
	public ModifyFormationAttributeMax(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B92 RID: 101266 RVA: 0x006FBFC4 File Offset: 0x006FA1C4
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
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
		defaultInterpolatedStringHandler.AppendLiteral("buff");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActiveHandleId);
		this.ModifierKey = defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06018B93 RID: 101267 RVA: 0x006FC058 File Offset: 0x006FA258
	public override void OnCreated()
	{
		if (this.AttributeId != (EFormationAttributeId)(-1))
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			if (ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority())
			{
				ControllerBase<FormationAttributeController>.Instance.AddMaxModifier(this.ModifierKey, this.AttributeId, this.Percent, this.Offset);
			}
		}
	}

	// Token: 0x06018B94 RID: 101268 RVA: 0x006FC0A4 File Offset: 0x006FA2A4
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018B95 RID: 101269 RVA: 0x006FC0A7 File Offset: 0x006FA2A7
	public override void OnRemoved(bool bPremature)
	{
		if (this.AttributeId != (EFormationAttributeId)(-1))
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			if (ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority())
			{
				ControllerBase<FormationAttributeController>.Instance.RemoveMaxModifier(this.ModifierKey, this.AttributeId);
			}
		}
	}

	// Token: 0x0400C095 RID: 49301
	protected EFormationAttributeId AttributeId = (EFormationAttributeId)(-1);

	// Token: 0x0400C096 RID: 49302
	protected float Offset;

	// Token: 0x0400C097 RID: 49303
	protected float Percent;

	// Token: 0x0400C098 RID: 49304
	[Nullable(2)]
	protected string ModifierKey;
}
