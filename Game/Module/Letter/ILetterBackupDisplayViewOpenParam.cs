using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Letter
{
	// Token: 0x02005A1D RID: 23069
	public interface ILetterBackupDisplayViewOpenParam
	{
		// Token: 0x170094D8 RID: 38104
		// (get) Token: 0x0603A67C RID: 239228
		// (set) Token: 0x0603A67D RID: 239229
		int LetterId { get; set; }

		// Token: 0x170094D9 RID: 38105
		// (get) Token: 0x0603A67E RID: 239230
		// (set) Token: 0x0603A67F RID: 239231
		[Nullable(new byte[]
		{
			2,
			1
		})]
		IReadOnlyList<ITalkItem> Items { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170094DA RID: 38106
		// (get) Token: 0x0603A680 RID: 239232
		// (set) Token: 0x0603A681 RID: 239233
		ELetterStyle? LetterStyle { get; set; }
	}
}
