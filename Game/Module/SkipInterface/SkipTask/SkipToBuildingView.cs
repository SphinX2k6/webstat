using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F3C RID: 20284
	public class SkipToBuildingView : SkipToMoonChasingBase
	{
		// Token: 0x060345DA RID: 214490 RVA: 0x00D1B174 File Offset: 0x00D19374
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			string text = (string)data[1];
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
					goto IL_56;
				}
			}
			moonChasingMainViewModel2 = new MoonChasingMainViewModel();
			IL_56:
			moonChasingMainViewModel2.SkipTarget = EMoonChasingSkipDefine.Build;
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RewardMainView))
			{
				if (text != "0")
				{
					ControllerBase<MoonChasingController>.Instance.OpenBuildingTipsInfoView(int.Parse(text));
				}
				Singleton<UiManager>.Instance.CloseView(EUiViewName.RewardMainView, null);
			}
		}

		// Token: 0x0401E312 RID: 123666
		[Nullable(1)]
		private const string ZERO_STRING = "0";
	}
}
