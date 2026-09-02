using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F32 RID: 20274
	public class SkipTaskQuestByType : SkipTask
	{
		// Token: 0x060345C5 RID: 214469 RVA: 0x00D1AB40 File Offset: 0x00D18D40
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			int num = int.Parse((string)data[0]);
			if (num < 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, null, null);
				return;
			}
			Quest firstShowQuestByType = ModelBase<QuestNewModel>.Instance.GetFirstShowQuestByType(num);
			int? num2 = (firstShowQuestByType != null) ? new int?(firstShowQuestByType.Id) : null;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, num2, null);
			base.Finish();
		}
	}
}
