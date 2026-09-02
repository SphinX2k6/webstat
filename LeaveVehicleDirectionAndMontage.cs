using System;
using System.Runtime.CompilerServices;

// Token: 0x020031A1 RID: 12705
[RequiredMember]
public class LeaveVehicleDirectionAndMontage
{
	// Token: 0x0601A5AA RID: 107946 RVA: 0x007C3D0C File Offset: 0x007C1F0C
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public LeaveVehicleDirectionAndMontage()
	{
	}

	// Token: 0x0400D48D RID: 54413
	[RequiredMember]
	public CommonNpcPerformComponent.EEnterVehicleDirection Direction;

	// Token: 0x0400D48E RID: 54414
	[Nullable(1)]
	[RequiredMember]
	public string Montage;
}
