using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002E7F RID: 11903
[NullableContext(1)]
public interface IBuffModifierData
{
	// Token: 0x170020F9 RID: 8441
	// (get) Token: 0x06018763 RID: 100195
	EAttributeType AttributeId { get; }

	// Token: 0x170020FA RID: 8442
	// (get) Token: 0x06018764 RID: 100196
	float[] Value1 { get; }

	// Token: 0x170020FB RID: 8443
	// (get) Token: 0x06018765 RID: 100197
	float[] Value2 { get; }

	// Token: 0x170020FC RID: 8444
	// (get) Token: 0x06018766 RID: 100198
	int[] CalculationPolicy { get; }
}
