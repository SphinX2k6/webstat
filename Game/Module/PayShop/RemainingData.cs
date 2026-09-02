using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PayShop
{
	// Token: 0x020056B2 RID: 22194
	[NullableContext(1)]
	[Nullable(0)]
	public class RemainingData : IRemainingData
	{
		// Token: 0x170090A2 RID: 37026
		// (get) Token: 0x060387C8 RID: 231368 RVA: 0x00E4FD96 File Offset: 0x00E4DF96
		// (set) Token: 0x060387C9 RID: 231369 RVA: 0x00E4FD9E File Offset: 0x00E4DF9E
		public string TextId { get; set; }

		// Token: 0x170090A3 RID: 37027
		// (get) Token: 0x060387CA RID: 231370 RVA: 0x00E4FDA7 File Offset: 0x00E4DFA7
		// (set) Token: 0x060387CB RID: 231371 RVA: 0x00E4FDAF File Offset: 0x00E4DFAF
		public int Count { get; set; }

		// Token: 0x060387CC RID: 231372 RVA: 0x00E4FDB8 File Offset: 0x00E4DFB8
		public RemainingData(string textId, int count)
		{
			this.TextId = textId;
			this.Count = count;
		}
	}
}
