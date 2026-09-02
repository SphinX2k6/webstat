using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F30 RID: 20272
	public class SkipTaskPayShopToSpecifyTab : SkipTask
	{
		// Token: 0x060345C1 RID: 214465 RVA: 0x00D1A9EC File Offset: 0x00D18BEC
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			string s2 = (string)data[1];
			if (data.Length > 2)
			{
				string text = (string)data[2];
			}
			base.Finish();
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PayShopRootView))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("IsInView", Array.Empty<object>());
				return;
			}
			PayShopViewData payShopViewData = new PayShopViewData();
			payShopViewData.PayShopId = (PayShopDefine.EPayShopTabType)int.Parse(s);
			payShopViewData.SwitchId = new int?(int.Parse(s2));
			ControllerBase<PayShopController>.Instance.OpenPayShopView(payShopViewData, null);
		}
	}
}
