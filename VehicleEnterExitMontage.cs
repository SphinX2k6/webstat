using System;
using System.Runtime.CompilerServices;

// Token: 0x02003262 RID: 12898
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VehicleEnterExitMontage : IVehicleEnterExitMontage
{
	// Token: 0x170024BA RID: 9402
	// (get) Token: 0x0601AECD RID: 110285 RVA: 0x008076D4 File Offset: 0x008058D4
	// (set) Token: 0x0601AECE RID: 110286 RVA: 0x008076DC File Offset: 0x008058DC
	[RequiredMember]
	public string Montage { get; set; }

	// Token: 0x170024BB RID: 9403
	// (get) Token: 0x0601AECF RID: 110287 RVA: 0x008076E5 File Offset: 0x008058E5
	// (set) Token: 0x0601AED0 RID: 110288 RVA: 0x008076ED File Offset: 0x008058ED
	[RequiredMember]
	public string AdditiveMontage { get; set; }

	// Token: 0x0601AED1 RID: 110289 RVA: 0x008076F6 File Offset: 0x008058F6
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VehicleEnterExitMontage()
	{
	}
}
