using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime
{
	// Token: 0x02003A2C RID: 14892
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/ETrailQuality.ETrailQuality")]
	public enum ETrailQuality : byte
	{
		// Token: 0x0400F1F5 RID: 61941
		ExLow,
		// Token: 0x0400F1F6 RID: 61942
		Low,
		// Token: 0x0400F1F7 RID: 61943
		Midium,
		// Token: 0x0400F1F8 RID: 61944
		High,
		// Token: 0x0400F1F9 RID: 61945
		ExHigh,
		// Token: 0x0400F1FA RID: 61946
		ETrailQuality_MAX
	}
}
