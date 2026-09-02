using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x02001723 RID: 5923
[NullableContext(1)]
public interface IActivityControllerBase
{
	// Token: 0x0600A4C5 RID: 42181
	bool Init();

	// Token: 0x0600A4C6 RID: 42182
	bool Clear();

	// Token: 0x0600A4C7 RID: 42183
	string GetActivityResource(ActivityBaseData data);

	// Token: 0x0600A4C8 RID: 42184
	ActivitySubViewBase CreateSubPageComponent(ActivityBaseData data);

	// Token: 0x0600A4C9 RID: 42185
	void OpenView(ActivityBaseData data);

	// Token: 0x0600A4CA RID: 42186
	[NullableContext(0)]
	UniTask<bool> OpenViewByViewName(EUiViewName viewName, int activityId = 0);

	// Token: 0x0600A4CB RID: 42187
	ActivityBaseData CreateActivityData(ActivityData data);

	// Token: 0x0600A4CC RID: 42188
	bool GetIsOpeningActivityRelativeView();

	// Token: 0x0600A4CD RID: 42189
	bool GetActivityLevelUnlockState(int levelId);

	// Token: 0x0600A4CE RID: 42190
	bool GetActivityMapMarkState(int markId);

	// Token: 0x0600A4CF RID: 42191
	void OnActivityFirstUnlock(ActivityBaseData data);

	// Token: 0x0600A4D0 RID: 42192
	void OnShowActivityFirstUnlockView(ActivityBaseData data);
}
