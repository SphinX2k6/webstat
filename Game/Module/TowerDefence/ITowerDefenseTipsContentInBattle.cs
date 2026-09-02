using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EBA RID: 20154
	[NullableContext(1)]
	public interface ITowerDefenseTipsContentInBattle
	{
		// Token: 0x1700898C RID: 35212
		// (get) Token: 0x06034126 RID: 213286
		// (set) Token: 0x06034127 RID: 213287
		string TitleTextId { get; set; }

		// Token: 0x1700898D RID: 35213
		// (get) Token: 0x06034128 RID: 213288
		// (set) Token: 0x06034129 RID: 213289
		string PhantomTextId { get; set; }

		// Token: 0x1700898E RID: 35214
		// (get) Token: 0x0603412A RID: 213290
		// (set) Token: 0x0603412B RID: 213291
		int Level { get; set; }

		// Token: 0x1700898F RID: 35215
		// (get) Token: 0x0603412C RID: 213292
		// (set) Token: 0x0603412D RID: 213293
		string DescTextId { get; set; }

		// Token: 0x17008990 RID: 35216
		// (get) Token: 0x0603412E RID: 213294
		// (set) Token: 0x0603412F RID: 213295
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<string> DescArgs { [return: Nullable(new byte[]
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
