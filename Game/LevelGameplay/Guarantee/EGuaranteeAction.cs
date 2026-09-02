using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.LevelGamePlay.Guarantee
{
	// Token: 0x02006E63 RID: 28259
	[EnumExtensions]
	public enum EGuaranteeAction
	{
		// Token: 0x040262D8 RID: 156376
		[EnumStringMember("EnablePlayerMoveControl")]
		EnablePlayerMoveControl,
		// Token: 0x040262D9 RID: 156377
		[EnumStringMember("ExitOrbitalCamera")]
		ExitOrbitalCamera,
		// Token: 0x040262DA RID: 156378
		[EnumStringMember("RestorePlayerCameraAdjustment")]
		RestorePlayerCameraAdjustment,
		// Token: 0x040262DB RID: 156379
		[EnumStringMember("UnLimitPlayerOperation")]
		UnLimitPlayerOperation,
		// Token: 0x040262DC RID: 156380
		[EnumStringMember("ActionBlackScreenFadeOut")]
		ActionBlackScreenFadeOut,
		// Token: 0x040262DD RID: 156381
		[EnumStringMember("DisableSplineMoveModel")]
		DisableSplineMoveModel,
		// Token: 0x040262DE RID: 156382
		[EnumStringMember("StopEffect")]
		StopEffect,
		// Token: 0x040262DF RID: 156383
		[EnumStringMember("Preload")]
		Preload,
		// Token: 0x040262E0 RID: 156384
		[EnumStringMember("DisableKey4Func")]
		DisableKey4Func,
		// Token: 0x040262E1 RID: 156385
		[EnumStringMember("ActionExitMovieMode")]
		ActionExitMovieMode,
		// Token: 0x040262E2 RID: 156386
		[EnumStringMember("StopGamepadShake")]
		StopGamepadShake
	}
}
