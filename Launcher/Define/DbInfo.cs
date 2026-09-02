using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x02004659 RID: 18009
	[NullableContext(1)]
	[Nullable(0)]
	public class DbInfo
	{
		// Token: 0x170080AC RID: 32940
		// (get) Token: 0x0602EFC2 RID: 192450 RVA: 0x00B21A58 File Offset: 0x00B1FC58
		public string ConfigDbPath { get; }

		// Token: 0x170080AD RID: 32941
		// (get) Token: 0x0602EFC3 RID: 192451 RVA: 0x00B21A60 File Offset: 0x00B1FC60
		public string TextDb { get; }

		// Token: 0x0602EFC4 RID: 192452 RVA: 0x00B21A68 File Offset: 0x00B1FC68
		public DbInfo(string configDbPath, string textDb)
		{
			this.ConfigDbPath = configDbPath;
			this.TextDb = textDb;
		}
	}
}
