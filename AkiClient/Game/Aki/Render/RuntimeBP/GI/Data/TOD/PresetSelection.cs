using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CD5 RID: 15573
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/PresetSelection.PresetSelection")]
	public enum PresetSelection : byte
	{
		// Token: 0x040131E2 RID: 78306
		BlueprintDefaults,
		// Token: 0x040131E3 RID: 78307
		Selected,
		// Token: 0x040131E4 RID: 78308
		RandomOnList,
		// Token: 0x040131E5 RID: 78309
		NextPresetOnList,
		// Token: 0x040131E6 RID: 78310
		CustomFunction,
		// Token: 0x040131E7 RID: 78311
		PresetSelection_MAX
	}
}
