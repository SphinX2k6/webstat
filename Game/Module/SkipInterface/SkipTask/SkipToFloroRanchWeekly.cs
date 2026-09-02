using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F4A RID: 20298
	public class SkipToFloroRanchWeekly : SkipTask
	{
		// Token: 0x060345F6 RID: 214518 RVA: 0x00D1BB4E File Offset: 0x00D19D4E
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchWeeklyMainView, null, null);
			base.Finish();
		}
	}
}
