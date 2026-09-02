using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F54 RID: 20308
	public class SkipToQuestMultiLineView : SkipTask
	{
		// Token: 0x0603460C RID: 214540 RVA: 0x00D1BEAB File Offset: 0x00D1A0AB
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			base.Finish();
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.QuestMultiLineView))
			{
				ControllerBase<QuestMultiLineController>.Instance.OpenQuestMultiLineView(0, false, false);
			}
		}
	}
}
