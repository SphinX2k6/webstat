using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;

// Token: 0x02001D0A RID: 7434
public class GachaSceneView : UiTickViewBase
{
	// Token: 0x0600DA5D RID: 55901 RVA: 0x003AAF44 File Offset: 0x003A9144
	[NullableContext(1)]
	public GachaSceneView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600DA5E RID: 55902 RVA: 0x003AAF4D File Offset: 0x003A914D
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.CloseGachaSceneView, new Action(this.CloseViewEvent));
		this.AfterAddEventListener();
	}

	// Token: 0x0600DA5F RID: 55903 RVA: 0x003AAF71 File Offset: 0x003A9171
	protected virtual void AfterAddEventListener()
	{
	}

	// Token: 0x0600DA60 RID: 55904 RVA: 0x003AAF73 File Offset: 0x003A9173
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseGachaSceneView, new Action(this.CloseViewEvent));
		this.AfterRemoveEventListener();
	}

	// Token: 0x0600DA61 RID: 55905 RVA: 0x003AAF97 File Offset: 0x003A9197
	protected virtual void AfterRemoveEventListener()
	{
	}

	// Token: 0x0600DA62 RID: 55906 RVA: 0x003AAF99 File Offset: 0x003A9199
	protected void CloseViewEvent()
	{
		this.BindCloseUiScene();
	}

	// Token: 0x0600DA63 RID: 55907 RVA: 0x003AAFA1 File Offset: 0x003A91A1
	protected override void OnBeforeShow()
	{
		this.OnAfterOpenUiScene();
	}

	// Token: 0x0600DA64 RID: 55908 RVA: 0x003AAFA9 File Offset: 0x003A91A9
	protected virtual void OnAfterOpenUiScene()
	{
	}

	// Token: 0x0600DA65 RID: 55909 RVA: 0x003AAFAB File Offset: 0x003A91AB
	protected override void OnStart()
	{
		ModelBase<GachaModel>.Instance.CanCloseView = false;
		this.OnAfterInitComponentsData();
	}

	// Token: 0x0600DA66 RID: 55910 RVA: 0x003AAFBE File Offset: 0x003A91BE
	private void BindCloseUiScene()
	{
		this.AfterCloseUiScene(true);
	}

	// Token: 0x0600DA67 RID: 55911 RVA: 0x003AAFC8 File Offset: 0x003A91C8
	private void AfterCloseUiScene(bool ret)
	{
		if (!ret)
		{
			return;
		}
		this.OnAfterCloseUiScene();
		ModelBase<GachaModel>.Instance.CanCloseView = true;
		if (Singleton<UiManager>.Instance.IsViewShow(this.ViewInfo.Name))
		{
			base.CloseMe(null);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.AfterCloseGachaScene);
	}

	// Token: 0x0600DA68 RID: 55912 RVA: 0x003AB018 File Offset: 0x003A9218
	protected virtual void OnAfterCloseUiScene()
	{
	}

	// Token: 0x0600DA69 RID: 55913 RVA: 0x003AB01A File Offset: 0x003A921A
	protected virtual void OnBeforeDestroyImplementImplement()
	{
	}

	// Token: 0x0600DA6A RID: 55914 RVA: 0x003AB01C File Offset: 0x003A921C
	protected override void OnBeforeDestroyImplement()
	{
		ModelBase<GachaModel>.Instance.CanCloseView = true;
		this.OnBeforeDestroyImplementImplement();
	}

	// Token: 0x0600DA6B RID: 55915 RVA: 0x003AB02F File Offset: 0x003A922F
	protected virtual void OnAfterInitComponentsData()
	{
	}

	// Token: 0x04006844 RID: 26692
	[Nullable(2)]
	protected UiCameraHandleData UiCameraHandleData;
}
