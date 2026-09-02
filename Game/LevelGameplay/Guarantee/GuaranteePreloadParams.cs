using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.Guarantee
{
	// Token: 0x02006E6A RID: 28266
	public class GuaranteePreloadParams : ActionParams, IGuaranteePreloadParams
	{
		// Token: 0x1700A398 RID: 41880
		// (get) Token: 0x0604496D RID: 280941 RVA: 0x011D4C9F File Offset: 0x011D2E9F
		// (set) Token: 0x0604496E RID: 280942 RVA: 0x011D4CA7 File Offset: 0x011D2EA7
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> Mp4Names { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
