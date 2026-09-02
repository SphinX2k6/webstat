using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Role.Enum
{
	// Token: 0x02003E11 RID: 15889
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Role/Enum/EKeyBehaviorType.EKeyBehaviorType")]
	public enum EKeyBehaviorType : byte
	{
		// Token: 0x0401476E RID: 83822
		None,
		// Token: 0x0401476F RID: 83823
		按下,
		// Token: 0x04014770 RID: 83824
		抬起,
		// Token: 0x04014771 RID: 83825
		长按,
		// Token: 0x04014772 RID: 83826
		EKeyBehaviorType_MAX
	}
}
