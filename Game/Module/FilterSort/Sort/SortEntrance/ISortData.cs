using System;

namespace CSharpScript.Game.Module.FilterSort.Sort.SortEntrance
{
	// Token: 0x02005E33 RID: 24115
	public interface ISortData
	{
		// Token: 0x17009929 RID: 39209
		// (get) Token: 0x0603CAF4 RID: 248564
		// (set) Token: 0x0603CAF5 RID: 248565
		int RuleId { get; set; }

		// Token: 0x1700992A RID: 39210
		// (get) Token: 0x0603CAF6 RID: 248566
		// (set) Token: 0x0603CAF7 RID: 248567
		ESortDataType DataType { get; set; }

		// Token: 0x1700992B RID: 39211
		// (get) Token: 0x0603CAF8 RID: 248568
		// (set) Token: 0x0603CAF9 RID: 248569
		int SelectedRule { get; set; }
	}
}
