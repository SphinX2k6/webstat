using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200259C RID: 9628
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class PhotographQuickController : ControllerBase<PhotographQuickController>
{
	// Token: 0x17001798 RID: 6040
	// (get) Token: 0x06012C2B RID: 76843 RVA: 0x0052D33B File Offset: 0x0052B53B
	public PhotographQuickModel Model
	{
		get
		{
			return ModelBase<PhotographQuickModel>.Instance;
		}
	}

	// Token: 0x06012C2C RID: 76844 RVA: 0x0052D342 File Offset: 0x0052B542
	protected override bool OnInit()
	{
		this.OnAddEvents();
		return true;
	}

	// Token: 0x06012C2D RID: 76845 RVA: 0x0052D34B File Offset: 0x0052B54B
	protected override bool OnLeaveLevel()
	{
		this.Reset();
		return true;
	}

	// Token: 0x06012C2E RID: 76846 RVA: 0x0052D354 File Offset: 0x0052B554
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		return true;
	}

	// Token: 0x06012C2F RID: 76847 RVA: 0x0052D360 File Offset: 0x0052B560
	protected void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.CharOnRoleDead, new Action<int>(this.OnRoleDead));
		Singleton<EventSystem>.Instance.Add<FGameplayTag>(EEventName.CheckClientEvent, new Action<FGameplayTag>(this.OnCheckClientEvent));
		ControllerBase<InputDistributeController>.Instance.BindAxis("UiLookUp", new TInputHandle<float>(this.OnInputUiLookUp));
		ControllerBase<InputDistributeController>.Instance.BindAxis("UiTurn", new TInputHandle<float>(this.OnInputUiTurn));
	}

	// Token: 0x06012C30 RID: 76848 RVA: 0x0052D3F8 File Offset: 0x0052B5F8
	protected void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.CharOnRoleDead, new Action<int>(this.OnRoleDead));
		Singleton<EventSystem>.Instance.Remove(EEventName.CheckClientEvent, new Action<FGameplayTag>(this.OnCheckClientEvent));
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiLookUp", new TInputHandle<float>(this.OnInputUiLookUp));
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiTurn", new TInputHandle<float>(this.OnInputUiTurn));
	}

	// Token: 0x06012C31 RID: 76849 RVA: 0x0052D490 File Offset: 0x0052B690
	private void OnInputUiLookUp(string axisName, float value, InputIdentification _)
	{
		if (value == 0f)
		{
			return;
		}
		PhotoCameraHandler handler = this.Model.GetHandler();
		if (handler == null)
		{
			return;
		}
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PhotoSaveView))
		{
			return;
		}
		handler.AddPitchInput(-value);
	}

	// Token: 0x06012C32 RID: 76850 RVA: 0x0052D4E0 File Offset: 0x0052B6E0
	private void OnInputUiTurn(string axisName, float value, InputIdentification _)
	{
		if (value == 0f)
		{
			return;
		}
		PhotoCameraHandler handler = this.Model.GetHandler();
		if (handler == null)
		{
			return;
		}
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PhotoSaveView))
		{
			return;
		}
		handler.AddYawInput(value);
	}

	// Token: 0x06012C33 RID: 76851 RVA: 0x0052D52C File Offset: 0x0052B72C
	protected override void OnTick(float delta)
	{
		if (this.Model.GetHandler() == null)
		{
			return;
		}
		this.Model.GetHandler().ApplyCameraDelta();
	}

	// Token: 0x06012C34 RID: 76852 RVA: 0x0052D54C File Offset: 0x0052B74C
	private void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
	{
		this.Close(false);
	}

	// Token: 0x06012C35 RID: 76853 RVA: 0x0052D555 File Offset: 0x0052B755
	private void OnRoleDead(int charId)
	{
		this.Close(false);
	}

	// Token: 0x06012C36 RID: 76854 RVA: 0x0052D55E File Offset: 0x0052B75E
	public void Close(bool bCloseFromSavePhoto = false)
	{
		this.Model.ClearHandler();
	}

	// Token: 0x06012C37 RID: 76855 RVA: 0x0052D56B File Offset: 0x0052B76B
	public void Reset()
	{
		this.Model.ClearHandler();
	}

	// Token: 0x06012C38 RID: 76856 RVA: 0x0052D578 File Offset: 0x0052B778
	public void SetFov(float v)
	{
		PhotoCameraHandler handler = this.Model.GetHandler();
		if (handler == null)
		{
			return;
		}
		handler.SetFov(v);
	}

	// Token: 0x06012C39 RID: 76857 RVA: 0x0052D590 File Offset: 0x0052B790
	public void InitHandlerForCaptureCollect()
	{
		this.Model.InitHandlerForCaptureCollect();
	}

	// Token: 0x06012C3A RID: 76858 RVA: 0x0052D5A0 File Offset: 0x0052B7A0
	private void OnCheckClientEvent(FGameplayTag tag)
	{
		int num = tag.TagId();
		if (num == GameplayTagDefine.EGameplayTagId["功能.功能制作.拍照.拍照并收集物品.开启"])
		{
			if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.CaptureCollectView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.CaptureCollectView, null, null);
				return;
			}
		}
		else if (num == GameplayTagDefine.EGameplayTagId["功能.功能制作.拍照.拍照并收集物品.关闭"] && Singleton<UiManager>.Instance.IsViewShow(EUiViewName.CaptureCollectView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.CaptureCollectView, null);
		}
	}
}
