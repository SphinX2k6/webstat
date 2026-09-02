using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020030A8 RID: 12456
[NullableContext(1)]
public interface IVehicleInputInfo
{
	// Token: 0x17002286 RID: 8838
	// (get) Token: 0x06019AAE RID: 105134
	// (set) Token: 0x06019AAF RID: 105135
	string InputClassPath { get; set; }

	// Token: 0x17002287 RID: 8839
	// (get) Token: 0x06019AB0 RID: 105136
	// (set) Token: 0x06019AB1 RID: 105137
	ABaseCharacter Owner { get; set; }
}
