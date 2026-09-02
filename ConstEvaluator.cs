using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E22 RID: 3618
public class ConstEvaluator : IModifyParamEvaluator
{
	// Token: 0x060055A0 RID: 21920 RVA: 0x000E1892 File Offset: 0x000DFA92
	public ConstEvaluator(float value)
	{
	}

	// Token: 0x060055A1 RID: 21921 RVA: 0x000E18A1 File Offset: 0x000DFAA1
	public float GetValue(float t)
	{
		return this.<value>P;
	}

	// Token: 0x04001AEA RID: 6890
	[CompilerGenerated]
	private float <value>P = value;
}
