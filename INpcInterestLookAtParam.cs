using System;
using System.Runtime.CompilerServices;

// Token: 0x0200319B RID: 12699
[NullableContext(1)]
public interface INpcInterestLookAtParam
{
	// Token: 0x170023CC RID: 9164
	// (get) Token: 0x0601A581 RID: 107905
	// (set) Token: 0x0601A582 RID: 107906
	int TargetPbDataId { get; set; }

	// Token: 0x170023CD RID: 9165
	// (get) Token: 0x0601A583 RID: 107907
	// (set) Token: 0x0601A584 RID: 107908
	Vector TargetPosition { get; set; }

	// Token: 0x170023CE RID: 9166
	// (get) Token: 0x0601A585 RID: 107909
	// (set) Token: 0x0601A586 RID: 107910
	float MaxAngle { get; set; }

	// Token: 0x170023CF RID: 9167
	// (get) Token: 0x0601A587 RID: 107911
	// (set) Token: 0x0601A588 RID: 107912
	float MaxDistance { get; set; }
}
