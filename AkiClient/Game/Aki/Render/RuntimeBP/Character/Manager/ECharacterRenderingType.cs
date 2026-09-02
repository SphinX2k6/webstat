using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager
{
	// Token: 0x02003D90 RID: 15760
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Manager/ECharacterRenderingType.ECharacterRenderingType")]
	public enum ECharacterRenderingType : byte
	{
		// Token: 0x04013FD4 RID: 81876
		LocalPlayer,
		// Token: 0x04013FD5 RID: 81877
		RemotePlayer,
		// Token: 0x04013FD6 RID: 81878
		Monster,
		// Token: 0x04013FD7 RID: 81879
		Npc,
		// Token: 0x04013FD8 RID: 81880
		Pet,
		// Token: 0x04013FD9 RID: 81881
		UI,
		// Token: 0x04013FDA RID: 81882
		Sequence,
		// Token: 0x04013FDB RID: 81883
		Default,
		// Token: 0x04013FDC RID: 81884
		Effect,
		// Token: 0x04013FDD RID: 81885
		Error,
		// Token: 0x04013FDE RID: 81886
		ECharacterRenderingType_MAX
	}
}
