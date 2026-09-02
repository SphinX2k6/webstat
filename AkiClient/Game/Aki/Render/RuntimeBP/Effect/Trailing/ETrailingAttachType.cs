using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Trailing
{
	// Token: 0x02003D26 RID: 15654
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Trailing/ETrailingAttachType.ETrailingAttachType")]
	public enum ETrailingAttachType : byte
	{
		// Token: 0x0401391B RID: 80155
		Actors,
		// Token: 0x0401391C RID: 80156
		Bones,
		// Token: 0x0401391D RID: 80157
		Transforms,
		// Token: 0x0401391E RID: 80158
		ETrailingAttachType_MAX
	}
}
