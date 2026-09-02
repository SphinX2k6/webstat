using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F31 RID: 20273
	public class SkipTaskQuest : SkipTask
	{
		// Token: 0x060345C3 RID: 214467 RVA: 0x00D1AA80 File Offset: 0x00D18C80
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			object obj = data[0];
			string text = (data.Length > 1) ? ((string)data[1]) : null;
			int num = 0;
			if (obj is int)
			{
				int num2 = (int)obj;
				num = num2;
			}
			else
			{
				string text2 = obj as string;
				if (text2 != null)
				{
					num = (string.IsNullOrEmpty(text2) ? 0 : int.Parse(text2));
				}
			}
			bool flag = false;
			if (num != 0)
			{
				Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(num);
				if (quest != null && quest.CanShowInUiPanel())
				{
					flag = true;
				}
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, num, null);
			if (!flag && text != "0")
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(text, Array.Empty<object>());
			}
			base.Finish();
		}

		// Token: 0x0401E30F RID: 123663
		[Nullable(1)]
		private const string DEFAULT_PARAM = "0";
	}
}
