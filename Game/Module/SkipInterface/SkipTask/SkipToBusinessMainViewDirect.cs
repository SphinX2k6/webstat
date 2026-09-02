using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F3E RID: 20286
	public class SkipToBusinessMainViewDirect : SkipToMoonChasingBase
	{
		// Token: 0x060345DE RID: 214494 RVA: 0x00D1B2AC File Offset: 0x00D194AC
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			if (!base.CheckMainViewOpen())
			{
				base.SkipToMap(int.Parse(s));
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ItemTipsView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ItemTipsView, null);
			}
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BusinessMainView))
			{
				ControllerBase<MoonChasingController>.Instance.OpenBusinessMainView();
			}
		}
	}
}
