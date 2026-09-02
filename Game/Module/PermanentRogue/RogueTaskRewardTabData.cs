using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200565E RID: 22110
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueTaskRewardTabData
	{
		// Token: 0x0402024C RID: 131660
		public string NameTextId;

		// Token: 0x0402024D RID: 131661
		public int Index = -1;

		// Token: 0x0402024E RID: 131662
		public Action<int> ClickedCallback;

		// Token: 0x0402024F RID: 131663
		public Func<int, bool> RefreshRedDot;
	}
}
