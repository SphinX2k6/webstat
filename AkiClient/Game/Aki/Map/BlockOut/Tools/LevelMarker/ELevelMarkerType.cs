using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Map.BlockOut.Tools.LevelMarker
{
	// Token: 0x02003DB8 RID: 15800
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Map/BlockOut/Tools/LevelMarker/ELevelMarkerType.ELevelMarkerType")]
	public enum ELevelMarkerType : byte
	{
		// Token: 0x040142B6 RID: 82614
		LevelMarker_Function,
		// Token: 0x040142B7 RID: 82615
		LevelMarker_Quest,
		// Token: 0x040142B8 RID: 82616
		LevelMarker_Atmosphere,
		// Token: 0x040142B9 RID: 82617
		ELevelMarkerType_MAX
	}
}
