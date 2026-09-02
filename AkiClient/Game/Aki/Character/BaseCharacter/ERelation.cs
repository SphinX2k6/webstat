using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004217 RID: 16919
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ERelation.ERelation")]
	public enum ERelation : byte
	{
		// Token: 0x0401918F RID: 102799
		None,
		// Token: 0x04019190 RID: 102800
		Friend,
		// Token: 0x04019191 RID: 102801
		Enemy,
		// Token: 0x04019192 RID: 102802
		ERelation_MAX
	}
}
