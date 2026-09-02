using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001367 RID: 4967
public class Theme26StageTaskView : SevenHillsStageTaskView, IUiViewResource
{
	// Token: 0x06008834 RID: 34868 RVA: 0x0023EEF0 File Offset: 0x0023D0F0
	[NullableContext(1)]
	public Theme26StageTaskView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x17000B81 RID: 2945
	// (get) Token: 0x06008835 RID: 34869 RVA: 0x0023EEF9 File Offset: 0x0023D0F9
	protected override bool IsRefreshNow
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06008836 RID: 34870 RVA: 0x0023EEFC File Offset: 0x0023D0FC
	protected override void RefreshTitleIcon()
	{
	}

	// Token: 0x06008837 RID: 34871 RVA: 0x0023EF00 File Offset: 0x0023D100
	[NullableContext(1)]
	public string GetExtraResourceId([Nullable(2)] object param = null)
	{
		object[] array = param as object[];
		if (array == null || array.Length < 2)
		{
			return "";
		}
		ActivityLongShanData activityLongShanData = array[0] as ActivityLongShanData;
		if (activityLongShanData == null)
		{
			return "";
		}
		return ControllerBase<ActivityLongShanController>.Instance.GetActivityUiConfig(activityLongShanData.Id).RewardViewId;
	}
}
