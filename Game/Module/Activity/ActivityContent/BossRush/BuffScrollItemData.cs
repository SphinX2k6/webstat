using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069BB RID: 27067
	internal class BuffScrollItemData
	{
		// Token: 0x0402565D RID: 153181
		public int BuffId;

		// Token: 0x0402565E RID: 153182
		public bool ChangeAble = true;

		// Token: 0x0402565F RID: 153183
		public BossRushBuffSelectionStatus State;

		// Token: 0x04025660 RID: 153184
		public bool Selected;

		// Token: 0x04025661 RID: 153185
		public bool SelectedAtStart;

		// Token: 0x04025662 RID: 153186
		[Nullable(1)]
		public Action<BuffScrollItemData> OnClickToggle = delegate(BuffScrollItemData data)
		{
		};

		// Token: 0x04025663 RID: 153187
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<BuffScrollItemData, bool> CheckClickAble;
	}
}
