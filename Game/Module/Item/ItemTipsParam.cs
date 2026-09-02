using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Item
{
	// Token: 0x02005B7B RID: 23419
	public class ItemTipsParam : UiPopViewData
	{
		// Token: 0x04021605 RID: 136709
		public int ItemId;

		// Token: 0x04021606 RID: 136710
		public int ItemUid;

		// Token: 0x04021607 RID: 136711
		[Nullable(2)]
		public object ExtraParam;

		// Token: 0x04021608 RID: 136712
		public bool CanSkip = true;
	}
}
