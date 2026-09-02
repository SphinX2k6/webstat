using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041DD RID: 16861
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EAttributeTarget.EAttributeTarget")]
	public enum EAttributeTarget : byte
	{
		// Token: 0x04018FF6 RID: 102390
		受击者,
		// Token: 0x04018FF7 RID: 102391
		攻击者,
		// Token: 0x04018FF8 RID: 102392
		EAttributeTarget_MAX
	}
}
