using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Kurotato.View.KurotatoLevelSelect;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F4D RID: 20301
	public class SkipToKurotatoLevelSelectView : SkipTask
	{
		// Token: 0x060345FC RID: 214524 RVA: 0x00D1BBA8 File Offset: 0x00D19DA8
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			base.Finish();
			int levelId = Convert.ToInt32(data[0]);
			KurotatoActivityController instance = ControllerBase<KurotatoActivityController>.Instance;
			KurotatoActivityData kurotatoActivityData = (instance != null) ? instance.GetActivityData() : null;
			KurotatoConfig instance2 = ConfigBase<KurotatoConfig>.Instance;
			KurotatoLevel? kurotatoLevel = (instance2 != null) ? instance2.GetLevelConfig(levelId) : null;
			if (kurotatoActivityData == null || kurotatoLevel == null || !kurotatoActivityData.IsStageEntranceUnLock((EKurotatoLevelMode)kurotatoLevel.Value.LevelGroup))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("KurotatoLevelLockedTip", Array.Empty<object>());
				return;
			}
			KurotatoLevelSelectViewData kurotatoLevelSelectViewData = new KurotatoLevelSelectViewData();
			kurotatoLevelSelectViewData.LevelId = levelId;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoLevelSelectView, kurotatoLevelSelectViewData, null);
		}
	}
}
