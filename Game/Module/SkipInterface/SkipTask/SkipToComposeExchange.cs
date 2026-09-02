using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F41 RID: 20289
	public class SkipToComposeExchange : SkipTask
	{
		// Token: 0x060345E4 RID: 214500 RVA: 0x00D1B4E8 File Offset: 0x00D196E8
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string text = (string)data[0];
			string text2 = (string)data[1];
			string text3 = (string)data[2];
			int p = (int)data[3];
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ComposeCarryOnView))
			{
				Singleton<EventSystem>.Instance.Emit<EComposeListType, int>(EEventName.ComposeSwitchType, EComposeListType.Exchange, p);
				if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ItemTipsView))
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.ItemTipsView, null);
				}
				return;
			}
			ComposeViewOpenData composeViewOpenData = new ComposeViewOpenData();
			composeViewOpenData.Type = EComposeListType.Exchange;
			composeViewOpenData.SelectData = ModelBase<ComposeModel>.Instance.ComposeSelectItem;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ComposeCarryOnView, composeViewOpenData, null);
			ModelBase<ComposeModel>.Instance.ComposeSelectItem = null;
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ItemTipsView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ItemTipsView, null);
			}
			base.Finish();
		}
	}
}
