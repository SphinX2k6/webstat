using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x02004381 RID: 17281
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Audio/E_FootstepVariant.E_FootstepVariant")]
	public enum E_FootstepVariant : byte
	{
		// Token: 0x04019DB8 RID: 105912
		land,
		// Token: 0x04019DB9 RID: 105913
		run,
		// Token: 0x04019DBA RID: 105914
		runstop,
		// Token: 0x04019DBB RID: 105915
		sprint,
		// Token: 0x04019DBC RID: 105916
		sprintstop,
		// Token: 0x04019DBD RID: 105917
		walk,
		// Token: 0x04019DBE RID: 105918
		walkstop,
		// Token: 0x04019DBF RID: 105919
		turnback,
		// Token: 0x04019DC0 RID: 105920
		E_MAX
	}
}
