using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F10 RID: 12048
[NullableContext(1)]
[Nullable(0)]
public class RequireAndLimits
{
	// Token: 0x0400C00F RID: 49167
	public ERequirementsCheckType CheckType;

	// Token: 0x0400C010 RID: 49168
	public IRequirement[] Requirements = new IRequirement[0];

	// Token: 0x0400C011 RID: 49169
	public EffectLimits Limits = new EffectLimits();
}
