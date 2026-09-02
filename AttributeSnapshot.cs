using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002E50 RID: 11856
public class AttributeSnapshot : IAttributeSet
{
	// Token: 0x060184AA RID: 99498 RVA: 0x006C8D66 File Offset: 0x006C6F66
	public float GetBaseValue(EAttributeType attrId)
	{
		return this.BaseValues[(int)attrId];
	}

	// Token: 0x060184AB RID: 99499 RVA: 0x006C8D70 File Offset: 0x006C6F70
	public float GetCurrentValue(EAttributeType attrId)
	{
		return this.CurrentValues[(int)attrId];
	}

	// Token: 0x0400BAAD RID: 47789
	[Nullable(1)]
	public readonly float[] BaseValues = new float[143];

	// Token: 0x0400BAAE RID: 47790
	[Nullable(1)]
	public readonly float[] CurrentValues = new float[143];
}
