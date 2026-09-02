using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.Input.Enum
{
	// Token: 0x020041AE RID: 16814
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/Input/Enum/EInputState.EInputState")]
	public enum EInputState : byte
	{
		// Token: 0x04018D8E RID: 101774
		None,
		// Token: 0x04018D8F RID: 101775
		Press,
		// Token: 0x04018D90 RID: 101776
		Release,
		// Token: 0x04018D91 RID: 101777
		Hold,
		// Token: 0x04018D92 RID: 101778
		EInputState_MAX
	}
}
