using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F6F RID: 12143
[NullableContext(1)]
[Nullable(0)]
public class ModifyFormationAttributeExecution : PeriodExecution
{
	// Token: 0x06018CF6 RID: 101622 RVA: 0x00703BFE File Offset: 0x00701DFE
	public ModifyFormationAttributeExecution(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018CF7 RID: 101623 RVA: 0x00703C08 File Offset: 0x00701E08
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.AttributeId = ((extraEffectParameters_ != null && extraEffectParameters_.Length != 0) ? int.Parse(extraEffectParameters_[0]) : 0);
		this.Rate = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters1, this.Level, 0f) * 0.0001f;
		this.Value = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters2, this.Level, 0f);
		this.Overlay = (extraEffectParameters_ != null && extraEffectParameters_.Length > 1 && int.Parse(extraEffectParameters_[1]) == 1);
	}

	// Token: 0x06018CF8 RID: 101624 RVA: 0x00703C90 File Offset: 0x00701E90
	[return: Nullable(2)]
	public override object OnExecute(params object[] args)
	{
		EFormationAttributeId attributeId = (EFormationAttributeId)this.AttributeId;
		float max = ControllerBase<FormationAttributeController>.Instance.GetMax(attributeId);
		if (this.Overlay)
		{
			ControllerBase<FormationAttributeController>.Instance.SetValue(attributeId, max * this.Rate + this.Value);
		}
		else
		{
			ControllerBase<FormationAttributeController>.Instance.AddValue(attributeId, max * this.Rate + this.Value);
		}
		return null;
	}

	// Token: 0x0400C174 RID: 49524
	public int AttributeId;

	// Token: 0x0400C175 RID: 49525
	public float Rate;

	// Token: 0x0400C176 RID: 49526
	public float Value;

	// Token: 0x0400C177 RID: 49527
	public bool Overlay;
}
