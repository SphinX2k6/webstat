using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041D5 RID: 16853
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EAimViewState.EAimViewState")]
	public enum EAimViewState : byte
	{
		// Token: 0x04018FC8 RID: 102344
		瞄准154身高,
		// Token: 0x04018FC9 RID: 102345
		瞄准180身高,
		// Token: 0x04018FCA RID: 102346
		寂寞小姐身高,
		// Token: 0x04018FCB RID: 102347
		露帕瞄准,
		// Token: 0x04018FCC RID: 102348
		Rebecca瞄准,
		// Token: 0x04018FCD RID: 102349
		EAimViewState_MAX
	}
}
