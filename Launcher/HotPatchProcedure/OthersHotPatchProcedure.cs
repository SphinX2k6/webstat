using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;

namespace CSharpScript.Launcher.HotPatchProcedure
{
	// Token: 0x02004600 RID: 17920
	public class OthersHotPatchProcedure : BaseHotPatchProcedure
	{
		// Token: 0x0602EE13 RID: 192019 RVA: 0x00B1A296 File Offset: 0x00B18496
		[NullableContext(1)]
		public OthersHotPatchProcedure(AppPathMisc pathMisc, HotFixManager viewMgr) : base(pathMisc, viewMgr)
		{
		}
	}
}
