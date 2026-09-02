using System;
using CSharpScript.Core.Common;

// Token: 0x02002234 RID: 8756
[EnumExtensions]
public enum EMapExploreToolCheckTipId
{
	// Token: 0x0400820D RID: 33293
	[EnumStringMember("OnylHostUse")]
	NotHost,
	// Token: 0x0400820E RID: 33294
	[EnumStringMember("ExploreStateError")]
	NotOnGround,
	// Token: 0x0400820F RID: 33295
	[EnumStringMember("ExplorePositionError")]
	IllegalExploreToolUsingPos,
	// Token: 0x04008210 RID: 33296
	[EnumStringMember("ExploreFighting")]
	InFight,
	// Token: 0x04008211 RID: 33297
	[EnumStringMember("ExploreUnauthorized")]
	NotHaveCountryAccess,
	// Token: 0x04008212 RID: 33298
	[EnumStringMember("ExploreActivating")]
	ToolActivating,
	// Token: 0x04008213 RID: 33299
	[EnumStringMember("ExploreShengXiaCollectAll")]
	SoundBoxAllCollected,
	// Token: 0x04008214 RID: 33300
	[EnumStringMember("Exolore_ShengXiaNoDetect")]
	Exolore_ShengXiaNoDetect,
	// Token: 0x04008215 RID: 33301
	[EnumStringMember("ExploreTeleporterItemLack")]
	TempTeleporterCostNotEnough,
	// Token: 0x04008216 RID: 33302
	[EnumStringMember("ExploreShengXiaItemLack")]
	SoundBoxDetectorCostNotEnough,
	// Token: 0x04008217 RID: 33303
	[EnumStringMember("ShengXiaDetectTip")]
	SoundBoxUseReachLimit,
	// Token: 0x04008218 RID: 33304
	[EnumStringMember("ExploreTeleporterBan")]
	TempTeleporterPlacementBanned,
	// Token: 0x04008219 RID: 33305
	[EnumStringMember("ErrorCode_2200054_Text")]
	AbnormalGravityCannotAddTemporary
}
