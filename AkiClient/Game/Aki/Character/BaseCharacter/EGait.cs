using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004206 RID: 16902
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EGait.EGait")]
	public enum EGait : byte
	{
		// Token: 0x0401911F RID: 102687
		Walking,
		// Token: 0x04019120 RID: 102688
		Running,
		// Token: 0x04019121 RID: 102689
		Sprinting,
		// Token: 0x04019122 RID: 102690
		Stand,
		// Token: 0x04019123 RID: 102691
		EGait_MAX
	}
}
