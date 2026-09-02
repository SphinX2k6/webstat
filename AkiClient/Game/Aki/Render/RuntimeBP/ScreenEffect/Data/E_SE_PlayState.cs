using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data
{
	// Token: 0x02003A69 RID: 14953
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/E_SE_PlayState.E_SE_PlayState")]
	public enum E_SE_PlayState : byte
	{
		// Token: 0x0400F72C RID: 63276
		Start,
		// Token: 0x0400F72D RID: 63277
		Lop,
		// Token: 0x0400F72E RID: 63278
		End,
		// Token: 0x0400F72F RID: 63279
		Over,
		// Token: 0x0400F730 RID: 63280
		E_SE_MAX
	}
}
