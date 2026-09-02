using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D65 RID: 15717
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/ENpcSetupType.ENpcSetupType")]
	public enum ENpcSetupType : byte
	{
		// Token: 0x04013D33 RID: 81203
		NpcSetupType1,
		// Token: 0x04013D34 RID: 81204
		NpcSetupType2,
		// Token: 0x04013D35 RID: 81205
		ENpcSetupType_MAX
	}
}
