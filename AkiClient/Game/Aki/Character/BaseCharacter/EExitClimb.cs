using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004201 RID: 16897
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EExitClimb.EExitClimb")]
	public enum EExitClimb : byte
	{
		// Token: 0x040190F9 RID: 102649
		跳下退出,
		// Token: 0x040190FA RID: 102650
		入水退出,
		// Token: 0x040190FB RID: 102651
		到顶退出,
		// Token: 0x040190FC RID: 102652
		到底退出,
		// Token: 0x040190FD RID: 102653
		蹬墙退出,
		// Token: 0x040190FE RID: 102654
		未知方式,
		// Token: 0x040190FF RID: 102655
		跑墙退出,
		// Token: 0x04019100 RID: 102656
		地面登上,
		// Token: 0x04019101 RID: 102657
		冲刺跨越远,
		// Token: 0x04019102 RID: 102658
		冲刺跨越近,
		// Token: 0x04019103 RID: 102659
		反斜登顶,
		// Token: 0x04019104 RID: 102660
		EExitClimb_MAX
	}
}
