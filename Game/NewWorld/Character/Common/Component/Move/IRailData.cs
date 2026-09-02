using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004931 RID: 18737
	[NullableContext(2)]
	public interface IRailData
	{
		// Token: 0x17008380 RID: 33664
		// (get) Token: 0x06030FE0 RID: 200672
		// (set) Token: 0x06030FE1 RID: 200673
		int RailSplineEntityId { get; set; }

		// Token: 0x17008381 RID: 33665
		// (get) Token: 0x06030FE2 RID: 200674
		// (set) Token: 0x06030FE3 RID: 200675
		float? SlideSpeed { get; set; }

		// Token: 0x17008382 RID: 33666
		// (get) Token: 0x06030FE4 RID: 200676
		// (set) Token: 0x06030FE5 RID: 200677
		float? UpSpeed { get; set; }

		// Token: 0x17008383 RID: 33667
		// (get) Token: 0x06030FE6 RID: 200678
		// (set) Token: 0x06030FE7 RID: 200679
		float? DownSpeed { get; set; }

		// Token: 0x17008384 RID: 33668
		// (get) Token: 0x06030FE8 RID: 200680
		// (set) Token: 0x06030FE9 RID: 200681
		[Nullable(new byte[]
		{
			2,
			1
		})]
		IExchangeSlideRailConfig[] ExchangeRailConfigs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008385 RID: 33669
		// (get) Token: 0x06030FEA RID: 200682
		// (set) Token: 0x06030FEB RID: 200683
		ISlopeSlidePerform SlidePerformConfig { get; set; }
	}
}
