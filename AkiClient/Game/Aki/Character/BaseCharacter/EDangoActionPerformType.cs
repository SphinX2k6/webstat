using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041FB RID: 16891
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EDangoActionPerformType.EDangoActionPerformType")]
	public enum EDangoActionPerformType : byte
	{
		// Token: 0x040190D4 RID: 102612
		原地跳跃,
		// Token: 0x040190D5 RID: 102613
		比赛胜利,
		// Token: 0x040190D6 RID: 102614
		欢呼,
		// Token: 0x040190D7 RID: 102615
		成功,
		// Token: 0x040190D8 RID: 102616
		失败,
		// Token: 0x040190D9 RID: 102617
		原地欢呼,
		// Token: 0x040190DA RID: 102618
		EDangoActionPerformType_MAX
	}
}
