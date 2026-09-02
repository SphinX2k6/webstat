using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001368 RID: 4968
public class Theme26UnlockTipView : UiViewBase, IUiViewResource
{
	// Token: 0x06008838 RID: 34872 RVA: 0x0023EF4D File Offset: 0x0023D14D
	[NullableContext(1)]
	public Theme26UnlockTipView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008839 RID: 34873 RVA: 0x0023EF56 File Offset: 0x0023D156
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600883A RID: 34874 RVA: 0x0023EF60 File Offset: 0x0023D160
	[NullableContext(1)]
	public string GetExtraResourceId([Nullable(2)] object param = null)
	{
		ActivityLongShanData activityLongShanData = param as ActivityLongShanData;
		return ControllerBase<ActivityLongShanController>.Instance.GetActivityUiConfig(activityLongShanData.Id).OpenTipId;
	}
}
