using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F57 RID: 20311
	public class SkipToTaskView : SkipToMoonChasingBase
	{
		// Token: 0x06034612 RID: 214546 RVA: 0x00D1BFCC File Offset: 0x00D1A1CC
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
			moonChasingMainViewModel2.SkipTarget = EMoonChasingSkipDefine.Task;
			moonChasingMainViewModel2.TaskType = EMoonChasingTaskType.MainLine;
			moonChasingMainViewModel2.IsLastTask = true;
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RewardMainView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.RewardMainView, null);
			}
		}
	}
}
