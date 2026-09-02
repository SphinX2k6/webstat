using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F37 RID: 20279
	public class SkipTaskTrackNewSoundArea : SkipTask
	{
		// Token: 0x060345CF RID: 214479 RVA: 0x00D1AE00 File Offset: 0x00D19000
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			EUiTabViewName newSoundAreaView = EUiTabViewName.NewSoundAreaView;
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.AdventureGuideView) && ModelBase<AdventureGuideModel>.Instance.CurrentGuideTabName == newSoundAreaView)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("IsInView", Array.Empty<object>());
				base.Finish();
				return;
			}
			if (newSoundAreaView == EUiTabViewName.NewSoundAreaView && !ModelBase<AdventureGuideModel>.Instance.CheckTargetDungeonTypeCanShow(EDungeonType.NoSoundArea))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotOpen", Array.Empty<object>());
				return;
			}
			AdventureGuideViewOpenData adventureGuideViewOpenData = new AdventureGuideViewOpenData();
			adventureGuideViewOpenData.OpenTabViewName = new EUiTabViewName?(newSoundAreaView);
			int num = int.Parse(s);
			SilentAreaDetection? silentAreaDetectionConfById = ConfigBase<AdventureGuideConfig>.Instance.GetSilentAreaDetectionConfById(num);
			if (silentAreaDetectionConfById == null)
			{
				return;
			}
			adventureGuideViewOpenData.OpenParam = new int?(silentAreaDetectionConfById.Value.Secondary);
			adventureGuideViewOpenData.NewSoundDetectTracingIdList = new int[]
			{
				num
			};
			ControllerBase<AdventureGuideController>.Instance.OpenGuideViewWithOpenData(adventureGuideViewOpenData, delegate(bool success, int viewId)
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
