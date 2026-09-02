using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020030A9 RID: 12457
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VehicleInputInfo : IVehicleInputInfo
{
	// Token: 0x17002288 RID: 8840
	// (get) Token: 0x06019AB2 RID: 105138 RVA: 0x0077680B File Offset: 0x00774A0B
	// (set) Token: 0x06019AB3 RID: 105139 RVA: 0x00776813 File Offset: 0x00774A13
	[RequiredMember]
	public string InputClassPath { get; set; }

	// Token: 0x17002289 RID: 8841
	// (get) Token: 0x06019AB4 RID: 105140 RVA: 0x0077681C File Offset: 0x00774A1C
	// (set) Token: 0x06019AB5 RID: 105141 RVA: 0x00776824 File Offset: 0x00774A24
	[RequiredMember]
	public ABaseCharacter Owner { get; set; }

	// Token: 0x06019AB6 RID: 105142 RVA: 0x0077682D File Offset: 0x00774A2D
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VehicleInputInfo()
	{
	}
}
