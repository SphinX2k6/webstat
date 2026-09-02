using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D64 RID: 15716
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/EBodyPartName.EBodyPartName")]
	public enum EBodyPartName : byte
	{
		// Token: 0x04013D2B RID: 81195
		Skel_Hair,
		// Token: 0x04013D2C RID: 81196
		Skel_Face,
		// Token: 0x04013D2D RID: 81197
		Skel_Body_Up,
		// Token: 0x04013D2E RID: 81198
		Skel_Body_Down,
		// Token: 0x04013D2F RID: 81199
		Skel_Body,
		// Token: 0x04013D30 RID: 81200
		ChildPart,
		// Token: 0x04013D31 RID: 81201
		EBodyPartName_MAX
	}
}
