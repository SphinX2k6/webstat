using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.Vision
{
	// Token: 0x02003F8A RID: 16266
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/Vision/EVisionCucurbitType.EVisionCucurbitType")]
	public enum EVisionCucurbitType : byte
	{
		// Token: 0x0401579F RID: 87967
		无,
		// Token: 0x040157A0 RID: 87968
		辅助_近_,
		// Token: 0x040157A1 RID: 87969
		辅助_远_,
		// Token: 0x040157A2 RID: 87970
		远程,
		// Token: 0x040157A3 RID: 87971
		近战_正面_,
		// Token: 0x040157A4 RID: 87972
		近战_背刺_,
		// Token: 0x040157A5 RID: 87973
		EVisionCucurbitType_MAX
	}
}
