using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.AudioVisualization
{
	// Token: 0x02003DA3 RID: 15779
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/AudioVisualization/EAudioVisualizationType.EAudioVisualizationType")]
	public enum EAudioVisualizationType : byte
	{
		// Token: 0x04014177 RID: 82295
		Burst,
		// Token: 0x04014178 RID: 82296
		BurstSustain,
		// Token: 0x04014179 RID: 82297
		KeepControl,
		// Token: 0x0401417A RID: 82298
		EAudioVisualizationType_MAX
	}
}
