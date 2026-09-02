using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FE1 RID: 24545
	public class CodeNBase
	{
		// Token: 0x0603DC76 RID: 253046 RVA: 0x00FBDA09 File Offset: 0x00FBBC09
		[NullableContext(1)]
		public virtual Dictionary<string, int[]> GetCodeTable()
		{
			return new Dictionary<string, int[]>();
		}

		// Token: 0x0603DC77 RID: 253047 RVA: 0x00FBDA10 File Offset: 0x00FBBC10
		public virtual int SingleCodeLength()
		{
			return 0;
		}

		// Token: 0x0603DC78 RID: 253048 RVA: 0x00FBDA13 File Offset: 0x00FBBC13
		public virtual int SupportCharCount()
		{
			return this.GetCodeTable().Count;
		}
	}
}
