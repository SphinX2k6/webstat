using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D67 RID: 15719
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/ERoleSetupType.ERoleSetupType")]
	public enum ERoleSetupType : byte
	{
		// Token: 0x04013D41 RID: 81217
		RoleSetupType1,
		// Token: 0x04013D42 RID: 81218
		RoleSetupType2,
		// Token: 0x04013D43 RID: 81219
		RoleSetupType3,
		// Token: 0x04013D44 RID: 81220
		ERoleSetupType_MAX
	}
}
