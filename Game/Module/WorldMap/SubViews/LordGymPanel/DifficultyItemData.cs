using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.LordGymPanel
{
	// Token: 0x02004BA8 RID: 19368
	[NullableContext(1)]
	[Nullable(0)]
	public class DifficultyItemData : IDifficultyItemData
	{
		// Token: 0x170086EC RID: 34540
		// (get) Token: 0x060328FF RID: 207103 RVA: 0x00CA8790 File Offset: 0x00CA6990
		// (set) Token: 0x06032900 RID: 207104 RVA: 0x00CA8798 File Offset: 0x00CA6998
		public string NameTextId { get; set; } = "";

		// Token: 0x170086ED RID: 34541
		// (get) Token: 0x06032901 RID: 207105 RVA: 0x00CA87A1 File Offset: 0x00CA69A1
		// (set) Token: 0x06032902 RID: 207106 RVA: 0x00CA87A9 File Offset: 0x00CA69A9
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public object[] NameTextArg { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170086EE RID: 34542
		// (get) Token: 0x06032903 RID: 207107 RVA: 0x00CA87B2 File Offset: 0x00CA69B2
		// (set) Token: 0x06032904 RID: 207108 RVA: 0x00CA87BA File Offset: 0x00CA69BA
		public List<ELordGymDifficultyState> StateList { get; set; }
	}
}
