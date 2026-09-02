using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Core.Config
{
	// Token: 0x02007143 RID: 28995
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonDbData
	{
		// Token: 0x0604634D RID: 287565 RVA: 0x01270CA3 File Offset: 0x0126EEA3
		public CommonDbData(int incrementId, string dbName, string command, string culture)
		{
			this.IncrementId = incrementId;
			this.DbName = dbName;
			this.Command = command;
			this.Culture = culture;
		}

		// Token: 0x040275B4 RID: 161204
		public const int UNVALID_INCREMENT_ID = 0;

		// Token: 0x040275B5 RID: 161205
		public string DbName;

		// Token: 0x040275B6 RID: 161206
		public string Command;

		// Token: 0x040275B7 RID: 161207
		public int IncrementId;

		// Token: 0x040275B8 RID: 161208
		public string Culture;
	}
}
