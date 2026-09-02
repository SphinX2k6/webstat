using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Skin.Skip
{
	// Token: 0x02004F70 RID: 20336
	[NullableContext(1)]
	[Nullable(0)]
	public class SkinSkipData : ISkinSkipData
	{
		// Token: 0x17008A42 RID: 35394
		// (get) Token: 0x06034723 RID: 214819 RVA: 0x00D1F622 File Offset: 0x00D1D822
		// (set) Token: 0x06034724 RID: 214820 RVA: 0x00D1F62A File Offset: 0x00D1D82A
		public int Id { get; set; }

		// Token: 0x17008A43 RID: 35395
		// (get) Token: 0x06034725 RID: 214821 RVA: 0x00D1F633 File Offset: 0x00D1D833
		// (set) Token: 0x06034726 RID: 214822 RVA: 0x00D1F63B File Offset: 0x00D1D83B
		public int ConfigId { get; set; }

		// Token: 0x17008A44 RID: 35396
		// (get) Token: 0x06034727 RID: 214823 RVA: 0x00D1F644 File Offset: 0x00D1D844
		// (set) Token: 0x06034728 RID: 214824 RVA: 0x00D1F64C File Offset: 0x00D1D84C
		public ESkinSkipType Type { get; set; }

		// Token: 0x17008A45 RID: 35397
		// (get) Token: 0x06034729 RID: 214825 RVA: 0x00D1F655 File Offset: 0x00D1D855
		// (set) Token: 0x0603472A RID: 214826 RVA: 0x00D1F65D File Offset: 0x00D1D85D
		public string Text { get; set; }

		// Token: 0x17008A46 RID: 35398
		// (get) Token: 0x0603472B RID: 214827 RVA: 0x00D1F666 File Offset: 0x00D1D866
		// (set) Token: 0x0603472C RID: 214828 RVA: 0x00D1F66E File Offset: 0x00D1D86E
		public int SortIndex { get; set; }
	}
}
