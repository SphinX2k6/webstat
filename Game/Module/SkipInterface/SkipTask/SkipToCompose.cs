using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F40 RID: 20288
	public class SkipToCompose : SkipTask
	{
		// Token: 0x060345E2 RID: 214498 RVA: 0x00D1B35C File Offset: 0x00D1955C
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			string text = (string)data[1];
			string text2 = (string)data[2];
			int num = (data.Length > 3 && data[3] != null) ? ((int)data[3]) : 0;
			int num2 = int.Parse(s);
			int num3 = (text != null) ? int.Parse(text) : 0;
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ComposeCarryOnView))
			{
				Singleton<EventSystem>.Instance.Emit<EComposeListType, int>(EEventName.ComposeSwitchType, (EComposeListType)num2, num);
				if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ItemTipsView))
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.ItemTipsView, null);
				}
				return;
			}
			ComposeViewOpenData composeViewOpenData = new ComposeViewOpenData();
			composeViewOpenData.Type = (EComposeListType)num2;
			composeViewOpenData.SkipSourceView = ModelBase<ComposeModel>.Instance.ComposeSkipSourceView;
			if (ModelBase<ComposeModel>.Instance.ComposeSelectItem != null)
			{
				composeViewOpenData.SelectData = ModelBase<ComposeModel>.Instance.ComposeSelectItem;
			}
			else if (num != 0)
			{
				composeViewOpenData.SelectData = new SelectedData
				{
					ItemId = num,
					IncId = 0,
					Count = 0,
					SelectedCount = 0
				};
			}
			else if (num3 != 0)
			{
				composeViewOpenData.SelectData = new SelectedData
				{
					ItemId = num3,
					IncId = 0,
					Count = 0,
					SelectedCount = 0
				};
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ComposeCarryOnView, composeViewOpenData, null);
			ModelBase<ComposeModel>.Instance.ComposeSelectItem = null;
			ModelBase<ComposeModel>.Instance.ComposeSkipSourceView = null;
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ItemTipsView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ItemTipsView, null);
			}
			base.Finish();
		}
	}
}
