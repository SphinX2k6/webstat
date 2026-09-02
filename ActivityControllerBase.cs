using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001724 RID: 5924
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public abstract class ActivityControllerBase<T> : ControllerBase<T>, IActivityControllerBase where T : class, new()
{
	// Token: 0x0600A4D1 RID: 42193 RVA: 0x002B8FB8 File Offset: 0x002B71B8
	public override bool Init()
	{
		bool result = this.OnInit();
		this.OnRegisterNetEvent();
		this.OnAddEvents();
		return result;
	}

	// Token: 0x0600A4D2 RID: 42194 RVA: 0x002B8FCC File Offset: 0x002B71CC
	public override bool Clear()
	{
		this.OnUnRegisterNetEvent();
		this.OnRemoveEvents();
		return base.Clear();
	}

	// Token: 0x0600A4D3 RID: 42195 RVA: 0x002B8FE0 File Offset: 0x002B71E0
	public string GetActivityResource(ActivityBaseData data)
	{
		string resourceId = this.OnGetActivityResource(data);
		return ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
	}

	// Token: 0x0600A4D4 RID: 42196 RVA: 0x002B9000 File Offset: 0x002B7200
	public ActivitySubViewBase CreateSubPageComponent(ActivityBaseData data)
	{
		return this.OnCreateSubPageComponent(data);
	}

	// Token: 0x0600A4D5 RID: 42197 RVA: 0x002B9009 File Offset: 0x002B7209
	public void OpenView(ActivityBaseData data)
	{
		this.OnOpenView(data);
	}

	// Token: 0x0600A4D6 RID: 42198 RVA: 0x002B9014 File Offset: 0x002B7214
	[NullableContext(0)]
	public UniTask<bool> OpenViewByViewName(EUiViewName viewName, int activityId = 0)
	{
		ActivityControllerBase<T>.<OpenViewByViewName>d__5 <OpenViewByViewName>d__;
		<OpenViewByViewName>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenViewByViewName>d__.<>4__this = this;
		<OpenViewByViewName>d__.viewName = viewName;
		<OpenViewByViewName>d__.activityId = activityId;
		<OpenViewByViewName>d__.<>1__state = -1;
		<OpenViewByViewName>d__.<>t__builder.Start<ActivityControllerBase<T>.<OpenViewByViewName>d__5>(ref <OpenViewByViewName>d__);
		return <OpenViewByViewName>d__.<>t__builder.Task;
	}

	// Token: 0x0600A4D7 RID: 42199 RVA: 0x002B9067 File Offset: 0x002B7267
	public ActivityBaseData CreateActivityData(ActivityData data)
	{
		ActivityBaseData activityBaseData = this.OnCreateActivityData(data);
		activityBaseData.Init(data);
		return activityBaseData;
	}

	// Token: 0x0600A4D8 RID: 42200 RVA: 0x002B9077 File Offset: 0x002B7277
	public bool GetIsOpeningActivityRelativeView()
	{
		return this.OnGetIsOpeningActivityRelativeView();
	}

	// Token: 0x0600A4D9 RID: 42201 RVA: 0x002B907F File Offset: 0x002B727F
	protected virtual void OnRegisterNetEvent()
	{
	}

	// Token: 0x0600A4DA RID: 42202 RVA: 0x002B9081 File Offset: 0x002B7281
	protected virtual void OnUnRegisterNetEvent()
	{
	}

	// Token: 0x0600A4DB RID: 42203 RVA: 0x002B9083 File Offset: 0x002B7283
	protected virtual void OnAddEvents()
	{
	}

	// Token: 0x0600A4DC RID: 42204 RVA: 0x002B9085 File Offset: 0x002B7285
	protected virtual void OnRemoveEvents()
	{
	}

	// Token: 0x0600A4DD RID: 42205 RVA: 0x002B9087 File Offset: 0x002B7287
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0600A4DE RID: 42206 RVA: 0x002B908A File Offset: 0x002B728A
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x0600A4DF RID: 42207
	protected abstract void OnOpenView(ActivityBaseData data);

	// Token: 0x0600A4E0 RID: 42208
	protected abstract string OnGetActivityResource(ActivityBaseData data);

	// Token: 0x0600A4E1 RID: 42209
	protected abstract ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data);

	// Token: 0x0600A4E2 RID: 42210
	protected abstract ActivityBaseData OnCreateActivityData(ActivityData data);

	// Token: 0x0600A4E3 RID: 42211
	protected abstract bool OnGetIsOpeningActivityRelativeView();

	// Token: 0x0600A4E4 RID: 42212 RVA: 0x002B9090 File Offset: 0x002B7290
	[NullableContext(0)]
	protected virtual UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
	{
		ActivityControllerBase<T>.<OnOpenSubView>d__19 <OnOpenSubView>d__;
		<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OnOpenSubView>d__.<>1__state = -1;
		<OnOpenSubView>d__.<>t__builder.Start<ActivityControllerBase<T>.<OnOpenSubView>d__19>(ref <OnOpenSubView>d__);
		return <OnOpenSubView>d__.<>t__builder.Task;
	}

	// Token: 0x0600A4E5 RID: 42213 RVA: 0x002B90CB File Offset: 0x002B72CB
	public virtual bool GetActivityLevelUnlockState(int levelId)
	{
		return true;
	}

	// Token: 0x0600A4E6 RID: 42214 RVA: 0x002B90CE File Offset: 0x002B72CE
	public virtual bool GetActivityMapMarkState(int markId)
	{
		return false;
	}

	// Token: 0x0600A4E7 RID: 42215 RVA: 0x002B90D1 File Offset: 0x002B72D1
	public virtual void OnActivityFirstUnlock(ActivityBaseData data)
	{
	}

	// Token: 0x0600A4E8 RID: 42216 RVA: 0x002B90D4 File Offset: 0x002B72D4
	public virtual void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		if (data.LocalConfig != null && data.LocalConfig.Value.ShowUnlockTip)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityUnlockTipView, data, null);
		}
	}
}
