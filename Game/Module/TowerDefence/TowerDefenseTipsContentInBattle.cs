using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EBB RID: 20155
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseTipsContentInBattle : ITowerDefenseTipsContentInBattle
	{
		// Token: 0x17008991 RID: 35217
		// (get) Token: 0x06034130 RID: 213296 RVA: 0x00D049BB File Offset: 0x00D02BBB
		// (set) Token: 0x06034131 RID: 213297 RVA: 0x00D049C3 File Offset: 0x00D02BC3
		public string TitleTextId { get; set; }

		// Token: 0x17008992 RID: 35218
		// (get) Token: 0x06034132 RID: 213298 RVA: 0x00D049CC File Offset: 0x00D02BCC
		// (set) Token: 0x06034133 RID: 213299 RVA: 0x00D049D4 File Offset: 0x00D02BD4
		public string PhantomTextId { get; set; }

		// Token: 0x17008993 RID: 35219
		// (get) Token: 0x06034134 RID: 213300 RVA: 0x00D049DD File Offset: 0x00D02BDD
		// (set) Token: 0x06034135 RID: 213301 RVA: 0x00D049E5 File Offset: 0x00D02BE5
		public int Level { get; set; }

		// Token: 0x17008994 RID: 35220
		// (get) Token: 0x06034136 RID: 213302 RVA: 0x00D049EE File Offset: 0x00D02BEE
		// (set) Token: 0x06034137 RID: 213303 RVA: 0x00D049F6 File Offset: 0x00D02BF6
		public string DescTextId { get; set; }

		// Token: 0x17008995 RID: 35221
		// (get) Token: 0x06034138 RID: 213304 RVA: 0x00D049FF File Offset: 0x00D02BFF
		// (set) Token: 0x06034139 RID: 213305 RVA: 0x00D04A07 File Offset: 0x00D02C07
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> DescArgs { [return: Nullable(new byte[]
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
