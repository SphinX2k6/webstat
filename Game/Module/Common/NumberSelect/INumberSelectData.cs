using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Common.NumberSelect
{
	// Token: 0x02005E50 RID: 24144
	[NullableContext(1)]
	[Nullable(0)]
	public class INumberSelectData
	{
		// Token: 0x17009940 RID: 39232
		// (get) Token: 0x0603CC12 RID: 248850 RVA: 0x00F6D677 File Offset: 0x00F6B877
		// (set) Token: 0x0603CC13 RID: 248851 RVA: 0x00F6D67F File Offset: 0x00F6B87F
		public int MaxNumber { get; set; }

		// Token: 0x17009941 RID: 39233
		// (get) Token: 0x0603CC14 RID: 248852 RVA: 0x00F6D688 File Offset: 0x00F6B888
		// (set) Token: 0x0603CC15 RID: 248853 RVA: 0x00F6D690 File Offset: 0x00F6B890
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<int, TableTextArgNew> GetExchangeTableText { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009942 RID: 39234
		// (get) Token: 0x0603CC16 RID: 248854 RVA: 0x00F6D699 File Offset: 0x00F6B899
		// (set) Token: 0x0603CC17 RID: 248855 RVA: 0x00F6D6A1 File Offset: 0x00F6B8A1
		public Action<int> ValueChangeFunction { get; set; }
	}
}
