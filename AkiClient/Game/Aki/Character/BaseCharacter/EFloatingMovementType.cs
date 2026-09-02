using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004203 RID: 16899
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EFloatingMovementType.EFloatingMovementType")]
	public enum EFloatingMovementType : byte
	{
		// Token: 0x0401910C RID: 102668
		None,
		// Token: 0x0401910D RID: 102669
		Floating,
		// Token: 0x0401910E RID: 102670
		Rise,
		// Token: 0x0401910F RID: 102671
		Drop,
		// Token: 0x04019110 RID: 102672
		Walk,
		// Token: 0x04019111 RID: 102673
		EFloatingMovementType_MAX
	}
}
