using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Item
{
	// Token: 0x02005B7C RID: 23420
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemConvertTipsParam
	{
		// Token: 0x04021609 RID: 136713
		public TItem? BeforeItemData;

		// Token: 0x0402160A RID: 136714
		public TItem? AfterItemData;

		// Token: 0x0402160B RID: 136715
		public string ShowText = "";

		// Token: 0x0402160C RID: 136716
		public Action OnCancelCallBack = delegate()
		{
		};

		// Token: 0x0402160D RID: 136717
		public Action OnConfirmCallBack = delegate()
		{
		};
	}
}
