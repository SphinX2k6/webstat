using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F24 RID: 20260
	public class SkipTaskAdventureGuide : SkipTask
	{
		// Token: 0x06034599 RID: 214425 RVA: 0x00D19D38 File Offset: 0x00D17F38
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			string value = (string)data[1];
			EUiTabViewName euiTabViewName = new EUiTabViewName(value);
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.AdventureGuideView) && ModelBase<AdventureGuideModel>.Instance.CurrentGuideTabName == euiTabViewName)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("IsInView", Array.Empty<object>());
				base.Finish();
				return;
			}
			int num = int.Parse(s);
			if (euiTabViewName == EUiTabViewName.NewSoundAreaView && !ModelBase<AdventureGuideModel>.Instance.CheckTargetDungeonTypeCanShow((EDungeonType)num))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotOpen", Array.Empty<object>());
				return;
			}
			ControllerBase<AdventureGuideController>.Instance.OpenGuideView(new EUiTabViewName?(euiTabViewName), new int?(num), delegate(bool success, int viewId)
			{
				base.Finish();
			});
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.AdventureGuideView))
			{
				base.Finish();
			}
		}
	}
}
