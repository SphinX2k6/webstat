using System;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005E09 RID: 24073
	public class RewardData : IRewardData
	{
		// Token: 0x17009915 RID: 39189
		// (get) Token: 0x0603C945 RID: 248133 RVA: 0x00F623CC File Offset: 0x00F605CC
		// (set) Token: 0x0603C946 RID: 248134 RVA: 0x00F623D4 File Offset: 0x00F605D4
		public int RewardId { get; set; }

		// Token: 0x17009916 RID: 39190
		// (get) Token: 0x0603C947 RID: 248135 RVA: 0x00F623DD File Offset: 0x00F605DD
		// (set) Token: 0x0603C948 RID: 248136 RVA: 0x00F623E5 File Offset: 0x00F605E5
		public int Count { get; set; }

		// Token: 0x17009917 RID: 39191
		// (get) Token: 0x0603C949 RID: 248137 RVA: 0x00F623EE File Offset: 0x00F605EE
		// (set) Token: 0x0603C94A RID: 248138 RVA: 0x00F623F6 File Offset: 0x00F605F6
		public bool IsGet { get; set; }
	}
}
