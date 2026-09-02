using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D0D RID: 15629
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/QuantizerMode.QuantizerMode")]
	public enum QuantizerMode : byte
	{
		// Token: 0x040137CF RID: 79823
		No_Quantizer___No_Texture_Offset,
		// Token: 0x040137D0 RID: 79824
		No_Quantizer___Texture_Offset_Manually_Set,
		// Token: 0x040137D1 RID: 79825
		No_Quantizer___Texture_Offset_Automatic___Extremes_Corrected,
		// Token: 0x040137D2 RID: 79826
		No_Quantizer___Texture_Offset_Automatic,
		// Token: 0x040137D3 RID: 79827
		Step__1_meter___Texture_Offset_Automatic,
		// Token: 0x040137D4 RID: 79828
		Step__2_meters___Texture_Offset_Automatic,
		// Token: 0x040137D5 RID: 79829
		Step__3_meters___Texture_Offset_Automatic,
		// Token: 0x040137D6 RID: 79830
		Step__4_meters___Texture_Offset_Automatic,
		// Token: 0x040137D7 RID: 79831
		Step__5_meters___Texture_Offset_Automatic,
		// Token: 0x040137D8 RID: 79832
		Step__10_meters___Texture_Offset_Automatic,
		// Token: 0x040137D9 RID: 79833
		Step__20_meters___Texture_Offset_Automatic,
		// Token: 0x040137DA RID: 79834
		Step__30_meters___Texture_Offset_Automatic,
		// Token: 0x040137DB RID: 79835
		Step__50_meters___Texture_Offset_Automatic,
		// Token: 0x040137DC RID: 79836
		Step__100_meters___Texture_Offset_Automatic,
		// Token: 0x040137DD RID: 79837
		Step__500_meters___Texture_Offset_Automatic,
		// Token: 0x040137DE RID: 79838
		QuantizerMode_MAX
	}
}
