using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scalability
{
	// Token: 0x02003D39 RID: 15673
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Scalability/ENiagaraScalabilityType.ENiagaraScalabilityType")]
	public enum ENiagaraScalabilityType : byte
	{
		// Token: 0x04013A93 RID: 80531
		None,
		// Token: 0x04013A94 RID: 80532
		Normal,
		// Token: 0x04013A95 RID: 80533
		Scene,
		// Token: 0x04013A96 RID: 80534
		FarSkill,
		// Token: 0x04013A97 RID: 80535
		Importance,
		// Token: 0x04013A98 RID: 80536
		ENiagaraScalabilityType_MAX
	}
}
