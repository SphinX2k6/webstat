using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D66 RID: 15718
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/ERoleBodyPartName.ERoleBodyPartName")]
	public enum ERoleBodyPartName : byte
	{
		// Token: 0x04013D37 RID: 81207
		Skel_Hair,
		// Token: 0x04013D38 RID: 81208
		Skel_Face,
		// Token: 0x04013D39 RID: 81209
		Skel_Body_Up,
		// Token: 0x04013D3A RID: 81210
		Skel_Body_Down,
		// Token: 0x04013D3B RID: 81211
		Skel_Body,
		// Token: 0x04013D3C RID: 81212
		CharacterMesh,
		// Token: 0x04013D3D RID: 81213
		WeaponCase,
		// Token: 0x04013D3E RID: 81214
		OtherCase,
		// Token: 0x04013D3F RID: 81215
		ERoleBodyPartName_MAX
	}
}
