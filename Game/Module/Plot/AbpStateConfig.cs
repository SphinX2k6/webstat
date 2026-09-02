using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200536E RID: 21358
	[NullableContext(1)]
	[Nullable(0)]
	public class AbpStateConfig : IAbpStateConfig
	{
		// Token: 0x17008D81 RID: 36225
		// (get) Token: 0x0603674A RID: 223050 RVA: 0x00DBCC81 File Offset: 0x00DBAE81
		// (set) Token: 0x0603674B RID: 223051 RVA: 0x00DBCC89 File Offset: 0x00DBAE89
		public string Abp { get; set; }

		// Token: 0x17008D82 RID: 36226
		// (get) Token: 0x0603674C RID: 223052 RVA: 0x00DBCC92 File Offset: 0x00DBAE92
		// (set) Token: 0x0603674D RID: 223053 RVA: 0x00DBCC9A File Offset: 0x00DBAE9A
		public string State1 { get; set; }

		// Token: 0x17008D83 RID: 36227
		// (get) Token: 0x0603674E RID: 223054 RVA: 0x00DBCCA3 File Offset: 0x00DBAEA3
		// (set) Token: 0x0603674F RID: 223055 RVA: 0x00DBCCAB File Offset: 0x00DBAEAB
		public string State2 { get; set; }
	}
}
