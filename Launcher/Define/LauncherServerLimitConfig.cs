using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x02004662 RID: 18018
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherServerLimitConfig
	{
		// Token: 0x170080B3 RID: 32947
		// (get) Token: 0x0602EFDE RID: 192478 RVA: 0x00B2238E File Offset: 0x00B2058E
		// (set) Token: 0x0602EFDF RID: 192479 RVA: 0x00B22396 File Offset: 0x00B20596
		public string CountryCodes { get; private set; }

		// Token: 0x0602EFE0 RID: 192480 RVA: 0x00B2239F File Offset: 0x00B2059F
		public LauncherServerLimitConfig(string countryCodes)
		{
			this.CountryCodes = countryCodes;
		}

		// Token: 0x0602EFE1 RID: 192481 RVA: 0x00B223AE File Offset: 0x00B205AE
		public static string GetTableName()
		{
			return "ServerLimit";
		}

		// Token: 0x0602EFE2 RID: 192482 RVA: 0x00B223B8 File Offset: 0x00B205B8
		public static LauncherServerLimitConfig Parse(UKuroSqliteResultSet rs)
		{
			string countryCodes = null;
			if (!rs.GetString("CountryCodes", ref countryCodes))
			{
				return null;
			}
			return new LauncherServerLimitConfig(countryCodes);
		}

		// Token: 0x0401AC36 RID: 109622
		private const string TableName = "ServerLimit";
	}
}
