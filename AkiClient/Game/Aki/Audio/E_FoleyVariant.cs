using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x02004380 RID: 17280
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Audio/E_FoleyVariant.E_FoleyVariant")]
	public enum E_FoleyVariant : byte
	{
		// Token: 0x04019DAE RID: 105902
		bodyfall,
		// Token: 0x04019DAF RID: 105903
		fly,
		// Token: 0x04019DB0 RID: 105904
		run,
		// Token: 0x04019DB1 RID: 105905
		sprint,
		// Token: 0x04019DB2 RID: 105906
		hard,
		// Token: 0x04019DB3 RID: 105907
		hardfast,
		// Token: 0x04019DB4 RID: 105908
		weak,
		// Token: 0x04019DB5 RID: 105909
		weakfast,
		// Token: 0x04019DB6 RID: 105910
		E_MAX
	}
}
