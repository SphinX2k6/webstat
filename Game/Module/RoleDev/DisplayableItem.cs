using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005052 RID: 20562
	[NullableContext(1)]
	[Nullable(0)]
	public class DisplayableItem : IDisplayableItem
	{
		// Token: 0x17008B58 RID: 35672
		// (get) Token: 0x06034F02 RID: 216834 RVA: 0x00D46B0A File Offset: 0x00D44D0A
		// (set) Token: 0x06034F03 RID: 216835 RVA: 0x00D46B12 File Offset: 0x00D44D12
		public string DisplayName { get; set; }

		// Token: 0x17008B59 RID: 35673
		// (get) Token: 0x06034F04 RID: 216836 RVA: 0x00D46B1B File Offset: 0x00D44D1B
		// (set) Token: 0x06034F05 RID: 216837 RVA: 0x00D46B23 File Offset: 0x00D44D23
		public string DisplayIcon { get; set; }

		// Token: 0x17008B5A RID: 35674
		// (get) Token: 0x06034F06 RID: 216838 RVA: 0x00D46B2C File Offset: 0x00D44D2C
		// (set) Token: 0x06034F07 RID: 216839 RVA: 0x00D46B34 File Offset: 0x00D44D34
		public int? DisplayCount { get; set; }

		// Token: 0x17008B5B RID: 35675
		// (get) Token: 0x06034F08 RID: 216840 RVA: 0x00D46B3D File Offset: 0x00D44D3D
		// (set) Token: 0x06034F09 RID: 216841 RVA: 0x00D46B45 File Offset: 0x00D44D45
		public bool IsUnlocked { get; set; }

		// Token: 0x17008B5C RID: 35676
		// (get) Token: 0x06034F0A RID: 216842 RVA: 0x00D46B4E File Offset: 0x00D44D4E
		// (set) Token: 0x06034F0B RID: 216843 RVA: 0x00D46B56 File Offset: 0x00D44D56
		public bool IsEquipped { get; set; }

		// Token: 0x17008B5D RID: 35677
		// (get) Token: 0x06034F0C RID: 216844 RVA: 0x00D46B5F File Offset: 0x00D44D5F
		// (set) Token: 0x06034F0D RID: 216845 RVA: 0x00D46B67 File Offset: 0x00D44D67
		public int? QualityLevel { get; set; }

		// Token: 0x17008B5E RID: 35678
		// (get) Token: 0x06034F0E RID: 216846 RVA: 0x00D46B70 File Offset: 0x00D44D70
		// (set) Token: 0x06034F0F RID: 216847 RVA: 0x00D46B78 File Offset: 0x00D44D78
		public bool? IsFinished { get; set; }

		// Token: 0x17008B5F RID: 35679
		// (get) Token: 0x06034F10 RID: 216848 RVA: 0x00D46B81 File Offset: 0x00D44D81
		// (set) Token: 0x06034F11 RID: 216849 RVA: 0x00D46B89 File Offset: 0x00D44D89
		public EClickActionType ClickAction { get; set; }

		// Token: 0x17008B60 RID: 35680
		// (get) Token: 0x06034F12 RID: 216850 RVA: 0x00D46B92 File Offset: 0x00D44D92
		// (set) Token: 0x06034F13 RID: 216851 RVA: 0x00D46B9A File Offset: 0x00D44D9A
		public int? ClickParam { get; set; }
	}
}
