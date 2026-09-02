using System;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x020061A7 RID: 24999
	public class PeriodicActivityCommonData : IPeriodicActivityCommonData
	{
		// Token: 0x17009B3A RID: 39738
		// (get) Token: 0x0603F1EC RID: 258540 RVA: 0x0102F73E File Offset: 0x0102D93E
		// (set) Token: 0x0603F1ED RID: 258541 RVA: 0x0102F746 File Offset: 0x0102D946
		public int ActivityId { get; set; }

		// Token: 0x17009B3B RID: 39739
		// (get) Token: 0x0603F1EE RID: 258542 RVA: 0x0102F74F File Offset: 0x0102D94F
		// (set) Token: 0x0603F1EF RID: 258543 RVA: 0x0102F757 File Offset: 0x0102D957
		public int Round { get; set; }
	}
}
