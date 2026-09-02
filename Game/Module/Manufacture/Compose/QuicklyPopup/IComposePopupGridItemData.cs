using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup
{
	// Token: 0x020059D4 RID: 22996
	[NullableContext(1)]
	[Nullable(0)]
	public class IComposePopupGridItemData
	{
		// Token: 0x170094AA RID: 38058
		// (get) Token: 0x0603A42A RID: 238634 RVA: 0x00EC490C File Offset: 0x00EC2B0C
		// (set) Token: 0x0603A42B RID: 238635 RVA: 0x00EC4914 File Offset: 0x00EC2B14
		public ISelectedData Item { get; set; }

		// Token: 0x170094AB RID: 38059
		// (get) Token: 0x0603A42C RID: 238636 RVA: 0x00EC491D File Offset: 0x00EC2B1D
		// (set) Token: 0x0603A42D RID: 238637 RVA: 0x00EC4925 File Offset: 0x00EC2B25
		public EGridState State { get; set; }

		// Token: 0x170094AC RID: 38060
		// (get) Token: 0x0603A42E RID: 238638 RVA: 0x00EC492E File Offset: 0x00EC2B2E
		// (set) Token: 0x0603A42F RID: 238639 RVA: 0x00EC4936 File Offset: 0x00EC2B36
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ISelectedData> ComposeList { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170094AD RID: 38061
		// (get) Token: 0x0603A430 RID: 238640 RVA: 0x00EC493F File Offset: 0x00EC2B3F
		// (set) Token: 0x0603A431 RID: 238641 RVA: 0x00EC4947 File Offset: 0x00EC2B47
		public int? UsedCount { get; set; }
	}
}
