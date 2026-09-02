using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02001B32 RID: 6962
public class UiTabCamera : UiTabViewBehavior
{
	// Token: 0x0600C8D0 RID: 51408 RVA: 0x003536D0 File Offset: 0x003518D0
	public void SetTabData(EUiTabViewName tabViewName)
	{
		this.TabData = new UiDynamicTab?(ConfigBase<DynamicTabConfig>.Instance.GetViewTab(tabViewName));
	}

	// Token: 0x0600C8D1 RID: 51409 RVA: 0x003536ED File Offset: 0x003518ED
	public override void Init()
	{
	}

	// Token: 0x0600C8D2 RID: 51410 RVA: 0x003536F0 File Offset: 0x003518F0
	public override void Begin()
	{
		DynamicTabCamera.PlayTabUiCamera((EUiTabViewName)this.TabData.Value.ChildViewName, null);
		this.AddEvents();
	}

	// Token: 0x0600C8D3 RID: 51411 RVA: 0x00353724 File Offset: 0x00351924
	public override void ShowFromToggle()
	{
		DynamicTabCamera.PlayTabUiCamera((EUiTabViewName)this.TabData.Value.ChildViewName, this.TabData.Value.BackViewBlendName);
	}

	// Token: 0x0600C8D4 RID: 51412 RVA: 0x00353764 File Offset: 0x00351964
	public override void ShowFromView()
	{
		DynamicTabCamera.PlayTabUiCamera((EUiTabViewName)this.TabData.Value.ChildViewName, null);
	}

	// Token: 0x0600C8D5 RID: 51413 RVA: 0x0035378F File Offset: 0x0035198F
	public override void Hide()
	{
	}

	// Token: 0x0600C8D6 RID: 51414 RVA: 0x00353791 File Offset: 0x00351991
	public override void Destroy()
	{
		this.TabData = null;
		this.RemoveEvents();
	}

	// Token: 0x0600C8D7 RID: 51415 RVA: 0x003537A5 File Offset: 0x003519A5
	private void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPlayCameraAnimationFinish, new Action<UiCameraAnimationDefine.IFinishData>(this.OnPlayCameraAnimationFinish));
	}

	// Token: 0x0600C8D8 RID: 51416 RVA: 0x003537C3 File Offset: 0x003519C3
	private void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayCameraAnimationFinish, new Action<UiCameraAnimationDefine.IFinishData>(this.OnPlayCameraAnimationFinish));
	}

	// Token: 0x0600C8D9 RID: 51417 RVA: 0x003537E1 File Offset: 0x003519E1
	[NullableContext(1)]
	private void OnPlayCameraAnimationFinish(UiCameraAnimationDefine.IFinishData finishData)
	{
		DynamicTabCamera.OnPlayCameraAnimationFinished(finishData);
	}

	// Token: 0x04006049 RID: 24649
	private UiDynamicTab? TabData;
}
