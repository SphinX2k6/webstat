using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.Vision.GA.Role
{
	// Token: 0x02003F8D RID: 16269
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/Vision/GA/Role/BPE_ManipulateState.BPE_ManipulateState")]
	public enum BPE_ManipulateState : byte
	{
		// Token: 0x040157C6 RID: 88006
		无,
		// Token: 0x040157C7 RID: 88007
		选取控物,
		// Token: 0x040157C8 RID: 88008
		吸取读条中,
		// Token: 0x040157C9 RID: 88009
		吸取飞行中,
		// Token: 0x040157CA RID: 88010
		控物中,
		// Token: 0x040157CB RID: 88011
		投掷物体,
		// Token: 0x040157CC RID: 88012
		BPE_MAX
	}
}
