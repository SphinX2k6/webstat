using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004932 RID: 18738
	[NullableContext(2)]
	[Nullable(0)]
	public class RailDataImpl : IRailData
	{
		// Token: 0x17008386 RID: 33670
		// (get) Token: 0x06030FEC RID: 200684 RVA: 0x00C2BB9B File Offset: 0x00C29D9B
		// (set) Token: 0x06030FED RID: 200685 RVA: 0x00C2BBA3 File Offset: 0x00C29DA3
		public int RailSplineEntityId { get; set; }

		// Token: 0x17008387 RID: 33671
		// (get) Token: 0x06030FEE RID: 200686 RVA: 0x00C2BBAC File Offset: 0x00C29DAC
		// (set) Token: 0x06030FEF RID: 200687 RVA: 0x00C2BBB4 File Offset: 0x00C29DB4
		public float? SlideSpeed { get; set; }

		// Token: 0x17008388 RID: 33672
		// (get) Token: 0x06030FF0 RID: 200688 RVA: 0x00C2BBBD File Offset: 0x00C29DBD
		// (set) Token: 0x06030FF1 RID: 200689 RVA: 0x00C2BBC5 File Offset: 0x00C29DC5
		public float? UpSpeed { get; set; }

		// Token: 0x17008389 RID: 33673
		// (get) Token: 0x06030FF2 RID: 200690 RVA: 0x00C2BBCE File Offset: 0x00C29DCE
		// (set) Token: 0x06030FF3 RID: 200691 RVA: 0x00C2BBD6 File Offset: 0x00C29DD6
		public float? DownSpeed { get; set; }

		// Token: 0x1700838A RID: 33674
		// (get) Token: 0x06030FF4 RID: 200692 RVA: 0x00C2BBDF File Offset: 0x00C29DDF
		// (set) Token: 0x06030FF5 RID: 200693 RVA: 0x00C2BBE7 File Offset: 0x00C29DE7
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IExchangeSlideRailConfig[] ExchangeRailConfigs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700838B RID: 33675
		// (get) Token: 0x06030FF6 RID: 200694 RVA: 0x00C2BBF0 File Offset: 0x00C29DF0
		// (set) Token: 0x06030FF7 RID: 200695 RVA: 0x00C2BBF8 File Offset: 0x00C29DF8
		public ISlopeSlidePerform SlidePerformConfig { get; set; }

		// Token: 0x06030FF8 RID: 200696 RVA: 0x00C2BC04 File Offset: 0x00C29E04
		[NullableContext(1)]
		public static RailDataImpl FromSlideRailComponent(SlideRailComponent comp)
		{
			RailDataImpl railDataImpl = new RailDataImpl();
			railDataImpl.RailSplineEntityId = comp.RailSplineEntityId;
			int? num = comp.SlideSpeed;
			railDataImpl.SlideSpeed = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			num = comp.UpSpeed;
			railDataImpl.UpSpeed = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			num = comp.DownSpeed;
			railDataImpl.DownSpeed = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			List<IExchangeSlideRailConfig> exchangeRailConfigs = comp.ExchangeRailConfigs;
			railDataImpl.ExchangeRailConfigs = ((exchangeRailConfigs != null) ? exchangeRailConfigs.ToArray() : null);
			railDataImpl.SlidePerformConfig = null;
			return railDataImpl;
		}

		// Token: 0x06030FF9 RID: 200697 RVA: 0x00C2BCCC File Offset: 0x00C29ECC
		[NullableContext(1)]
		public static RailDataImpl FromSlidePerformComponent(SlidePerformComponent comp)
		{
			RailDataImpl railDataImpl = new RailDataImpl();
			railDataImpl.RailSplineEntityId = comp.RailSplineEntityId;
			int? num = comp.SlideSpeed;
			railDataImpl.SlideSpeed = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			num = comp.UpSpeed;
			railDataImpl.UpSpeed = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			num = comp.DownSpeed;
			railDataImpl.DownSpeed = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			List<IExchangeSlideRailConfig> exchangeRailConfigs = comp.ExchangeRailConfigs;
			railDataImpl.ExchangeRailConfigs = ((exchangeRailConfigs != null) ? exchangeRailConfigs.ToArray() : null);
			railDataImpl.SlidePerformConfig = comp.SlidePerformConfig;
			return railDataImpl;
		}
	}
}
