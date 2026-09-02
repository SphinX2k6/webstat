using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200155C RID: 5468
public class ActivityRegressTaskDefineData : IStaticVariableResetter
{
	// Token: 0x0600995D RID: 39261 RVA: 0x002822F7 File Offset: 0x002804F7
	static ActivityRegressTaskDefineData()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ActivityRegressTaskDefineData.CreateStaticDefaultValue), new Action(ActivityRegressTaskDefineData.ResetStaticDefaultValue));
	}

	// Token: 0x0600995E RID: 39262 RVA: 0x00282318 File Offset: 0x00280518
	public static void CreateStaticDefaultValue()
	{
		ActivityRegressTaskDefineData.taskSubViewTabDataMap = new Dictionary<EActivityRegressTaskSubViewType, ITaskSubViewTabData>
		{
			{
				EActivityRegressTaskSubViewType.MainTask,
				new ITaskSubViewTabData
				{
					TitleKey = "RecallActivity_Task_Title",
					IconName = "SP_IconCircumfluence1",
					Type = EActivityRegressTaskSubViewType.MainTask,
					RedDotName = new ERedDotName?(ERedDotName.ActivityRegressConstantTask)
				}
			},
			{
				EActivityRegressTaskSubViewType.Cultivate,
				new ITaskSubViewTabData
				{
					TitleKey = "Recall_Cultivation_Task_Title",
					IconName = "SP_IconCircumfluence2",
					Type = EActivityRegressTaskSubViewType.Cultivate,
					RedDotName = new ERedDotName?(ERedDotName.ActivityRegressCultivate)
				}
			},
			{
				EActivityRegressTaskSubViewType.DoubleDrop,
				new ITaskSubViewTabData
				{
					TitleKey = "Recall_Double_Reward_Title",
					IconName = "SP_IconCircumfluence3",
					Type = EActivityRegressTaskSubViewType.DoubleDrop,
					RedDotName = new ERedDotName?(ERedDotName.ActivityRegressDoubleDrop)
				}
			}
		};
	}

	// Token: 0x0600995F RID: 39263 RVA: 0x002823F2 File Offset: 0x002805F2
	public static void ResetStaticDefaultValue()
	{
		ActivityRegressTaskDefineData.taskSubViewTabDataMap = null;
	}

	// Token: 0x040046E0 RID: 18144
	[Nullable(2)]
	public static Dictionary<EActivityRegressTaskSubViewType, ITaskSubViewTabData> taskSubViewTabDataMap;
}
