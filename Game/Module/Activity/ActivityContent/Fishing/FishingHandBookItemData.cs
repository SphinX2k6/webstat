using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200680A RID: 26634
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingHandBookItemData : IFishingHandBookItemData
	{
		// Token: 0x1700A175 RID: 41333
		// (get) Token: 0x06042639 RID: 271929 RVA: 0x011047EF File Offset: 0x011029EF
		// (set) Token: 0x0604263A RID: 271930 RVA: 0x011047F7 File Offset: 0x011029F7
		public int Id { get; set; }

		// Token: 0x1700A176 RID: 41334
		// (get) Token: 0x0604263B RID: 271931 RVA: 0x01104800 File Offset: 0x01102A00
		// (set) Token: 0x0604263C RID: 271932 RVA: 0x01104808 File Offset: 0x01102A08
		public int Type { get; set; }

		// Token: 0x1700A177 RID: 41335
		// (get) Token: 0x0604263D RID: 271933 RVA: 0x01104811 File Offset: 0x01102A11
		// (set) Token: 0x0604263E RID: 271934 RVA: 0x01104819 File Offset: 0x01102A19
		public int Time { get; set; }

		// Token: 0x1700A178 RID: 41336
		// (get) Token: 0x0604263F RID: 271935 RVA: 0x01104822 File Offset: 0x01102A22
		// (set) Token: 0x06042640 RID: 271936 RVA: 0x0110482A File Offset: 0x01102A2A
		public List<int> Tech { get; set; }

		// Token: 0x1700A179 RID: 41337
		// (get) Token: 0x06042641 RID: 271937 RVA: 0x01104833 File Offset: 0x01102A33
		// (set) Token: 0x06042642 RID: 271938 RVA: 0x0110483B File Offset: 0x01102A3B
		public List<int> Area { get; set; }

		// Token: 0x1700A17A RID: 41338
		// (get) Token: 0x06042643 RID: 271939 RVA: 0x01104844 File Offset: 0x01102A44
		// (set) Token: 0x06042644 RID: 271940 RVA: 0x0110484C File Offset: 0x01102A4C
		public int HandBookId { get; set; }

		// Token: 0x06042645 RID: 271941 RVA: 0x01104855 File Offset: 0x01102A55
		public FishingHandBookItemData()
		{
			this.Tech = new List<int>();
			this.Area = new List<int>();
		}
	}
}
