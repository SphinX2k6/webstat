using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui;
using CSharpScript.Launcher.Ui.HotFix;
using UnrealEngine;

namespace CSharpScript.Game.Module.Launcher.Action
{
	// Token: 0x02004A8F RID: 19087
	public class SubPackageDownLoadMobileClearTitleItem : LaunchComponentsAction
	{
		// Token: 0x06031CD0 RID: 203984 RVA: 0x00C78F80 File Offset: 0x00C77180
		protected override void OnStart()
		{
			base.GetButton(1).OnClickCallBack.Bind(new Action(this.OnClickHelpBtn));
			base.GetItem(2).SetUIActive(false);
		}

		// Token: 0x06031CD1 RID: 203985 RVA: 0x00C78FAC File Offset: 0x00C771AC
		public void RefreshItem(int type)
		{
			this.TitleType = type;
			HotFixManager.SetLocalText(base.GetText(0), "HotFixSubPackageClearTipsTitle_" + HotFixDownSubPackageDownLoadMobileClearPopViewDefine.ClearTypeToTipsNumber[this.TitleType].ToString(), Array.Empty<string>());
		}

		// Token: 0x06031CD2 RID: 203986 RVA: 0x00C78FF4 File Offset: 0x00C771F4
		private void OnClickHelpBtn()
		{
			Singleton<LauncherLog>.Instance.Info("SubPackageDownLoadMobileClearTitleItem HelpBtn", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (this.OnClickHelpBtnCallBack != null)
			{
				this.OnClickHelpBtnCallBack(this.TitleType, base.GetButton(1).RootUIComp);
			}
		}

		// Token: 0x06031CD3 RID: 203987 RVA: 0x00C79044 File Offset: 0x00C77244
		public void SelectItem()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "SubPackageDownLoadMobileClearTitleItem SelectItem";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TitleType", this.TitleType);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.GetItem(2).SetUIActive(true);
		}

		// Token: 0x06031CD4 RID: 203988 RVA: 0x00C7908C File Offset: 0x00C7728C
		public void UnSelectItem()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "SubPackageDownLoadMobileClearTitleItem UnSelectItem";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TitleType", this.TitleType);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.GetItem(2).SetUIActive(false);
		}

		// Token: 0x06031CD5 RID: 203989 RVA: 0x00C790D4 File Offset: 0x00C772D4
		public void ClickItemOnGamePad()
		{
			Singleton<LauncherLog>.Instance.Info("SubPackageDownLoadMobileClearTitleItem HelpBtn ClickItemOnGamePad", default(ReadOnlySpan<ValueTuple<string, object>>));
			Action<int, UUIItem> onClickHelpBtnCallBack = this.OnClickHelpBtnCallBack;
			if (onClickHelpBtnCallBack == null)
			{
				return;
			}
			onClickHelpBtnCallBack(this.TitleType, base.GetButton(1).RootUIComp);
		}

		// Token: 0x0401D297 RID: 119447
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, UUIItem> OnClickHelpBtnCallBack;

		// Token: 0x0401D298 RID: 119448
		private int TitleType;

		// Token: 0x0200AAF7 RID: 43767
		private class ESubPackageDownLoadMobileClearTitleItem
		{
			// Token: 0x04035362 RID: 217954
			public const int Text = 0;

			// Token: 0x04035363 RID: 217955
			public const int HelpBtn = 1;

			// Token: 0x04035364 RID: 217956
			public const int SelectItem = 2;
		}
	}
}
