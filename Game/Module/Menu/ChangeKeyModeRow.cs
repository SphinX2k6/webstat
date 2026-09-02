using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x0200575F RID: 22367
	[NullableContext(1)]
	[Nullable(0)]
	public class ChangeKeyModeRow : IChangeKeyModeRow
	{
		// Token: 0x17009178 RID: 37240
		// (get) Token: 0x06038EC5 RID: 233157 RVA: 0x00E6C7FE File Offset: 0x00E6A9FE
		// (set) Token: 0x06038EC6 RID: 233158 RVA: 0x00E6C806 File Offset: 0x00E6AA06
		public string RowSpriteResourceId { get; set; } = "";

		// Token: 0x17009179 RID: 37241
		// (get) Token: 0x06038EC7 RID: 233159 RVA: 0x00E6C80F File Offset: 0x00E6AA0F
		// (set) Token: 0x06038EC8 RID: 233160 RVA: 0x00E6C817 File Offset: 0x00E6AA17
		public string DescriptionA { get; set; } = "";

		// Token: 0x1700917A RID: 37242
		// (get) Token: 0x06038EC9 RID: 233161 RVA: 0x00E6C820 File Offset: 0x00E6AA20
		// (set) Token: 0x06038ECA RID: 233162 RVA: 0x00E6C828 File Offset: 0x00E6AA28
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public object[] DescriptionParametersA { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700917B RID: 37243
		// (get) Token: 0x06038ECB RID: 233163 RVA: 0x00E6C831 File Offset: 0x00E6AA31
		// (set) Token: 0x06038ECC RID: 233164 RVA: 0x00E6C839 File Offset: 0x00E6AA39
		public string DescriptionB { get; set; } = "";

		// Token: 0x1700917C RID: 37244
		// (get) Token: 0x06038ECD RID: 233165 RVA: 0x00E6C842 File Offset: 0x00E6AA42
		// (set) Token: 0x06038ECE RID: 233166 RVA: 0x00E6C84A File Offset: 0x00E6AA4A
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public object[] DescriptionParametersB { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
