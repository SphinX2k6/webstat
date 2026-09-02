using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057BF RID: 22463
	[NullableContext(2)]
	[Nullable(0)]
	public class ChangeKeyModeRowData
	{
		// Token: 0x06039192 RID: 233874 RVA: 0x00E7894C File Offset: 0x00E76B4C
		[NullableContext(1)]
		public ChangeKeyModeRowData(int index, IChangeKeyModeRow changeKeyModeRow)
		{
			this.Index = index;
			this.SpriteResourceId = changeKeyModeRow.RowSpriteResourceId;
			this.DescriptionA = changeKeyModeRow.DescriptionA;
			this.DescriptionB = changeKeyModeRow.DescriptionB;
			this.DescriptionParametersA = changeKeyModeRow.DescriptionParametersA;
			this.DescriptionParametersB = changeKeyModeRow.DescriptionParametersB;
		}

		// Token: 0x04020813 RID: 133139
		public readonly int Index;

		// Token: 0x04020814 RID: 133140
		public readonly string SpriteResourceId;

		// Token: 0x04020815 RID: 133141
		public readonly string DescriptionA;

		// Token: 0x04020816 RID: 133142
		public readonly string DescriptionB;

		// Token: 0x04020817 RID: 133143
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public readonly object[] DescriptionParametersA;

		// Token: 0x04020818 RID: 133144
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public readonly object[] DescriptionParametersB;
	}
}
