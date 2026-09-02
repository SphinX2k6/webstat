using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001366 RID: 4966
public class Theme26MainView : SevenHillsMainView, IUiViewResource
{
	// Token: 0x06008830 RID: 34864 RVA: 0x0023EE8F File Offset: 0x0023D08F
	[NullableContext(1)]
	public Theme26MainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008831 RID: 34865 RVA: 0x0023EE98 File Offset: 0x0023D098
	protected override void OnClickStageItem(int stageId)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.Theme26StageTaskView, new object[]
		{
			this.ActivityBaseData,
			stageId
		}, null);
	}

	// Token: 0x06008832 RID: 34866 RVA: 0x0023EEC2 File Offset: 0x0023D0C2
	protected override void RefreshTitleIcon()
	{
	}

	// Token: 0x06008833 RID: 34867 RVA: 0x0023EEC4 File Offset: 0x0023D0C4
	[NullableContext(1)]
	public string GetExtraResourceId([Nullable(2)] object param = null)
	{
		ActivityLongShanData activityLongShanData = param as ActivityLongShanData;
		return ControllerBase<ActivityLongShanController>.Instance.GetActivityUiConfig(activityLongShanData.Id).MainViewId;
	}
}
