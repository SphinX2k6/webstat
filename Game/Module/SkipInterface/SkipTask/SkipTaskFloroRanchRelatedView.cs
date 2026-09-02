using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F2A RID: 20266
	public class SkipTaskFloroRanchRelatedView : SkipTask
	{
		// Token: 0x060345B1 RID: 214449 RVA: 0x00D1A4C9 File Offset: 0x00D186C9
		public SkipTaskFloroRanchRelatedView()
		{
			this.OpenView = delegate(EUiViewName viewName)
			{
				if (this.CheckViewExistAndReset(viewName))
				{
					return;
				}
				Singleton<UiManager>.Instance.OpenView(viewName, null, null);
			};
		}

		// Token: 0x060345B2 RID: 214450 RVA: 0x00D1A4E4 File Offset: 0x00D186E4
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			string text = (string)data[1];
			string text2 = (string)data[2];
			FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
			if (activityData == null || !activityData.IsUnLock())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ActivityLock", Array.Empty<object>());
				return;
			}
			switch (int.Parse(s))
			{
			case 1:
				this.OpenView(EUiViewName.FloroRanchMainView);
				break;
			case 2:
				this.OpenView(EUiViewName.FloroRanchMainView);
				this.OpenView(EUiViewName.FloroRanchTechnologyView);
				break;
			case 3:
				this.OpenView(EUiViewName.FloroRanchMainView);
				this.OpenView(EUiViewName.FloroRanchDungeonSelectView);
				break;
			case 4:
				this.OpenView(EUiViewName.FloroRanchMainView);
				this.OpenView(EUiViewName.FloroRanchHandBookView);
				break;
			}
			base.Finish();
		}

		// Token: 0x060345B3 RID: 214451 RVA: 0x00D1A5D6 File Offset: 0x00D187D6
		private bool CheckViewExistAndReset(EUiViewName viewName)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
			{
				return true;
			}
			if (Singleton<UiManager>.Instance.GetViewByName(viewName) != null)
			{
				Singleton<UiManager>.Instance.NormalResetToView(viewName, null, true);
				return true;
			}
			return false;
		}

		// Token: 0x0401E30E RID: 123662
		[Nullable(1)]
		private readonly Action<EUiViewName> OpenView;

		// Token: 0x0200AF72 RID: 44914
		private enum EFloroRanchViewDefine
		{
			// Token: 0x0403671D RID: 223005
			MainView = 1,
			// Token: 0x0403671E RID: 223006
			TechView,
			// Token: 0x0403671F RID: 223007
			SelectDungeon,
			// Token: 0x04036720 RID: 223008
			HandBook
		}
	}
}
