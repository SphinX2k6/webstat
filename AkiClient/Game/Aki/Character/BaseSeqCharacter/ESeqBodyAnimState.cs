using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseSeqCharacter
{
	// Token: 0x020041BB RID: 16827
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseSeqCharacter/ESeqBodyAnimState.ESeqBodyAnimState")]
	public enum ESeqBodyAnimState : byte
	{
		// Token: 0x04018E9D RID: 102045
		站立,
		// Token: 0x04018E9E RID: 102046
		摊右手,
		// Token: 0x04018E9F RID: 102047
		右手思考,
		// Token: 0x04018EA0 RID: 102048
		右手摸前额,
		// Token: 0x04018EA1 RID: 102049
		右手放胸前,
		// Token: 0x04018EA2 RID: 102050
		左手压抱胸,
		// Token: 0x04018EA3 RID: 102051
		左手压抱胸抬手,
		// Token: 0x04018EA4 RID: 102052
		左手叉腰,
		// Token: 0x04018EA5 RID: 102053
		左手叉腰抬手,
		// Token: 0x04018EA6 RID: 102054
		双叉腰,
		// Token: 0x04018EA7 RID: 102055
		双叉腰抬右手,
		// Token: 0x04018EA8 RID: 102056
		ESeqBodyAnimState_MAX
	}
}
