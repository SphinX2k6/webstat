using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data
{
	// Token: 0x02003A6A RID: 14954
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/E_SE_RootType.E_SE_RootType")]
	public enum E_SE_RootType : byte
	{
		// Token: 0x0400F732 RID: 63282
		Fight,
		// Token: 0x0400F733 RID: 63283
		Plot,
		// Token: 0x0400F734 RID: 63284
		General,
		// Token: 0x0400F735 RID: 63285
		CoverLoading,
		// Token: 0x0400F736 RID: 63286
		E_SE_MAX
	}
}
