using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Item
{
	// Token: 0x02005B73 RID: 23411
	internal class ItemSelectRewardItemData
	{
		// Token: 0x040215E8 RID: 136680
		public int Index;

		// Token: 0x040215E9 RID: 136681
		public int ItemId;

		// Token: 0x040215EA RID: 136682
		public bool SelectState;

		// Token: 0x040215EB RID: 136683
		[Nullable(2)]
		public ResonantChainOptionLimitInfo LimitInfo;

		// Token: 0x040215EC RID: 136684
		[Nullable(1)]
		public Action<int> OnClickToggleCallBack = delegate(int _)
		{
		};
	}
}
