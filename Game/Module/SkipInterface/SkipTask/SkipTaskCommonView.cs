using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F25 RID: 20261
	public class SkipTaskCommonView : SkipTask
	{
		// Token: 0x0603459C RID: 214428 RVA: 0x00D19E38 File Offset: 0x00D18038
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string text = (data.Length != 0) ? (data[0] as string) : null;
			string text2 = (data.Length > 1) ? (data[1] as string) : null;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			EUiViewName name = (EUiViewName)text;
			if (Singleton<UiConfig>.Instance.TryGetViewInfo(name) == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SkipInterface, ELogAuthor.LJ, "[SkipTaskCommonView.OnRun] 未找到界面信息，检查界面名称拼写：" + text, default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (text2 != null)
			{
				int num;
				if (int.TryParse(text2, out num))
				{
					Singleton<UiManager>.Instance.OpenView(name, num, null);
				}
				else
				{
					Singleton<UiManager>.Instance.OpenView(name, text2, null);
				}
			}
			else
			{
				Singleton<UiManager>.Instance.OpenView(name, null, null);
			}
			base.Finish();
		}
	}
}
