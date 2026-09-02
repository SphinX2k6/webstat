using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020025B5 RID: 9653
[NullableContext(1)]
public interface IPartConditionResult
{
	// Token: 0x1700179F RID: 6047
	// (get) Token: 0x06012D68 RID: 77160
	// (set) Token: 0x06012D69 RID: 77161
	bool Satisfied { get; set; }

	// Token: 0x170017A0 RID: 6048
	// (get) Token: 0x06012D6A RID: 77162
	// (set) Token: 0x06012D6B RID: 77163
	List<Vector> PartPositions { get; set; }
}
