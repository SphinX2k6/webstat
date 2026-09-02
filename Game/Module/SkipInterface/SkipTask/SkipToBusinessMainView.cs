using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F3D RID: 20285
	public class SkipToBusinessMainView : SkipToMoonChasingBase
	{
		// Token: 0x060345DC RID: 214492 RVA: 0x00D1B224 File Offset: 0x00D19424
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
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.MoonChasingMainView);
			MoonChasingMainViewModel moonChasingMainViewModel2;
			if (viewByName != null)
			{
				MoonChasingMainViewModel moonChasingMainViewModel = viewByName.OpenParam as MoonChasingMainViewModel;
				if (moonChasingMainViewModel != null)
				{
					moonChasingMainViewModel2 = moonChasingMainViewModel;
					goto IL_4A;
				}
			}
			moonChasingMainViewModel2 = new MoonChasingMainViewModel();
			IL_4A:
			moonChasingMainViewModel2.SkipTarget = EMoonChasingSkipDefine.Business;
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RewardMainView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.RewardMainView, null);
			}
		}
	}
}
