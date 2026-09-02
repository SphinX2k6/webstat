using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Library
{
	// Token: 0x02003C61 RID: 15457
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Library/EObjectFlags.EObjectFlags")]
	public enum EObjectFlags : byte
	{
		// Token: 0x040123DB RID: 74715
		RF_Public,
		// Token: 0x040123DC RID: 74716
		RF_Standalone,
		// Token: 0x040123DD RID: 74717
		RF_MarkAsNative,
		// Token: 0x040123DE RID: 74718
		RF_Transactional,
		// Token: 0x040123DF RID: 74719
		RF_ClassDefaultObject,
		// Token: 0x040123E0 RID: 74720
		RF_ArchetypeObject,
		// Token: 0x040123E1 RID: 74721
		RF_Transient,
		// Token: 0x040123E2 RID: 74722
		RF_MarkAsRootSet,
		// Token: 0x040123E3 RID: 74723
		RF_TagGarbageTemp,
		// Token: 0x040123E4 RID: 74724
		RF_NeedInitialization,
		// Token: 0x040123E5 RID: 74725
		RF_NeedLoad,
		// Token: 0x040123E6 RID: 74726
		RF_KeepForCooker,
		// Token: 0x040123E7 RID: 74727
		RF_NeedPostLoad,
		// Token: 0x040123E8 RID: 74728
		RF_NeedPostLoadSubobjects,
		// Token: 0x040123E9 RID: 74729
		RF_NewerVersionExists,
		// Token: 0x040123EA RID: 74730
		RF_BeginDestroyed,
		// Token: 0x040123EB RID: 74731
		RF_FinishDestroyed,
		// Token: 0x040123EC RID: 74732
		RF_BeingRegenerated,
		// Token: 0x040123ED RID: 74733
		RF_DefaultSubObject,
		// Token: 0x040123EE RID: 74734
		RF_WasLoaded,
		// Token: 0x040123EF RID: 74735
		RF_TextExportTransient,
		// Token: 0x040123F0 RID: 74736
		RF_LoadCompleted,
		// Token: 0x040123F1 RID: 74737
		RF_InheritableComponentTemplate,
		// Token: 0x040123F2 RID: 74738
		RF_DuplicateTransient,
		// Token: 0x040123F3 RID: 74739
		RF_StrongRefOnFrame,
		// Token: 0x040123F4 RID: 74740
		RF_NonPIEDuplicateTransient,
		// Token: 0x040123F5 RID: 74741
		RF_Dynamic,
		// Token: 0x040123F6 RID: 74742
		RF_WillBeLoaded,
		// Token: 0x040123F7 RID: 74743
		RF_HasExternalPackage,
		// Token: 0x040123F8 RID: 74744
		EObjectFlags_MAX
	}
}
