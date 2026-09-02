using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Core.Config
{
	// Token: 0x02007145 RID: 28997
	public static class ConfigStatementLibSync
	{
		// Token: 0x06046355 RID: 287573 RVA: 0x01270FB8 File Offset: 0x0126F1B8
		[NullableContext(1)]
		public static int CreateStatement(string dbPath, string command)
		{
			FName fname = new FName(dbPath);
			return UKuroPrepareStatementLib.GetOrCreateStatement(fname, command);
		}

		// Token: 0x06046356 RID: 287574 RVA: 0x01270FD4 File Offset: 0x0126F1D4
		public static void CloseAllConnection()
		{
			UKuroPrepareStatementLib.CloseAllConnection();
		}

		// Token: 0x040275BA RID: 161210
		private const bool USE_CROSS_LANGUAGE_DB_CONNECT = true;
	}
}
