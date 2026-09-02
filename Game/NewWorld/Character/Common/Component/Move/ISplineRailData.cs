using System;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004927 RID: 18727
	public interface ISplineRailData : IRailParam
	{
		// Token: 0x1700835B RID: 33627
		// (get) Token: 0x06030F91 RID: 200593
		// (set) Token: 0x06030F92 RID: 200594
		int DefaultNextRailId { get; set; }

		// Token: 0x1700835C RID: 33628
		// (get) Token: 0x06030F93 RID: 200595
		// (set) Token: 0x06030F94 RID: 200596
		ETriggerKey DefaultTriggerKey { get; set; }

		// Token: 0x1700835D RID: 33629
		// (get) Token: 0x06030F95 RID: 200597
		// (set) Token: 0x06030F96 RID: 200598
		int RailId { get; set; }
	}
}
