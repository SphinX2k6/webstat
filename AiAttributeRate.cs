using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Monster.Common;

// Token: 0x02000CF1 RID: 3313
public class AiAttributeRate
{
	// Token: 0x060041FF RID: 16895 RVA: 0x000717A8 File Offset: 0x0006F9A8
	public AiAttributeRate(SAiAttributeRate aiAttributeRate)
	{
		this.Denominator = (EAttributeType)aiAttributeRate.Denominator;
		this.Numerator = (EAttributeType)aiAttributeRate.Numerator;
		this.Range = new TsFloatRange(aiAttributeRate.Range.LowerBound.Type == 0, aiAttributeRate.Range.LowerBound.Value, aiAttributeRate.Range.UpperBound.Value);
	}

	// Token: 0x04001047 RID: 4167
	public EAttributeType Denominator;

	// Token: 0x04001048 RID: 4168
	public EAttributeType Numerator;

	// Token: 0x04001049 RID: 4169
	[Nullable(1)]
	public TsFloatRange Range;
}
