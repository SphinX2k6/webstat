using System;
using System.Runtime.CompilerServices;

// Token: 0x020022B8 RID: 8888
[NullableContext(1)]
public interface IMotorTechNodeListData
{
	// Token: 0x170014D8 RID: 5336
	// (get) Token: 0x06010CAC RID: 68780
	// (set) Token: 0x06010CAD RID: 68781
	int[] TopIds { get; set; }

	// Token: 0x170014D9 RID: 5337
	// (get) Token: 0x06010CAE RID: 68782
	// (set) Token: 0x06010CAF RID: 68783
	int[] BottomIds { get; set; }

	// Token: 0x170014DA RID: 5338
	// (get) Token: 0x06010CB0 RID: 68784
	// (set) Token: 0x06010CB1 RID: 68785
	int MiddleId { get; set; }
}
