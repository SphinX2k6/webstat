using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;

// Token: 0x02002C44 RID: 11332
[NullableContext(2)]
[Nullable(0)]
public class UiCameraComponent
{
	// Token: 0x06016B2A RID: 92970 RVA: 0x0064D5C9 File Offset: 0x0064B7C9
	public UiCameraComponent()
	{
		this.TickHandleId = -1;
	}

	// Token: 0x06016B2B RID: 92971 RVA: 0x0064D5D8 File Offset: 0x0064B7D8
	[NullableContext(1)]
	public void Initialize(UiCamera ownerUiCamera)
	{
		this.OwnerUiCamera = ownerUiCamera;
		this.CameraActor = this.OwnerUiCamera.GetCameraActor();
		this.CameraActor.SetTickableWhenPaused(true);
		this.CineCameraComponent = this.OwnerUiCamera.GetCineCameraComponent();
		UCineCameraComponent cineCameraComponent = this.CineCameraComponent;
		if (cineCameraComponent != null)
		{
			cineCameraComponent.SetTickableWhenPaused(true);
		}
		this.OnInitialize();
	}

	// Token: 0x06016B2C RID: 92972 RVA: 0x0064D632 File Offset: 0x0064B832
	public void Destroy()
	{
		this.CameraActor = null;
		this.CineCameraComponent = null;
		this.Deactivate();
		this.OnDestroy();
	}

	// Token: 0x06016B2D RID: 92973 RVA: 0x0064D650 File Offset: 0x0064B850
	public void Activate()
	{
		if (this.IsActivate)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiCamera;
		ELogAuthor author = ELogAuthor.BB;
		string message = "激活相机组件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", base.GetType().Name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.OnAddEvents();
		this.OnActivate();
		this.IsActivate = true;
	}

	// Token: 0x06016B2E RID: 92974 RVA: 0x0064D6AC File Offset: 0x0064B8AC
	public void Deactivate()
	{
		if (!this.IsActivate)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiCamera;
		ELogAuthor author = ELogAuthor.BB;
		string message = "休眠相机组件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", base.GetType().Name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.RemoveTick();
		this.OnRemoveEvents();
		this.OnDeactivate();
		this.IsActivate = false;
	}

	// Token: 0x06016B2F RID: 92975 RVA: 0x0064D70C File Offset: 0x0064B90C
	public void EnableTick()
	{
		if (this.TickHandleId != -1)
		{
			return;
		}
		this.TickHandleId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.Tick), base.GetType().Name, ETickingGroup.TG_PrePhysics, true, 0, true).Id;
	}

	// Token: 0x06016B30 RID: 92976 RVA: 0x0064D748 File Offset: 0x0064B948
	public void ResumeTick()
	{
		if (this.TickHandleId == -1)
		{
			return;
		}
		Singleton<TickSystem>.Instance.Resume(this.TickHandleId);
	}

	// Token: 0x06016B31 RID: 92977 RVA: 0x0064D765 File Offset: 0x0064B965
	public void PauseTick()
	{
		if (this.TickHandleId == -1)
		{
			return;
		}
		Singleton<TickSystem>.Instance.Pause(this.TickHandleId);
	}

	// Token: 0x06016B32 RID: 92978 RVA: 0x0064D782 File Offset: 0x0064B982
	public void RemoveTick()
	{
		if (this.TickHandleId == -1)
		{
			return;
		}
		Singleton<TickSystem>.Instance.Remove(this.TickHandleId);
		this.TickHandleId = -1;
	}

	// Token: 0x06016B33 RID: 92979 RVA: 0x0064D7A6 File Offset: 0x0064B9A6
	private void Tick(float delta)
	{
		this.OnTick(delta);
	}

	// Token: 0x06016B34 RID: 92980 RVA: 0x0064D7AF File Offset: 0x0064B9AF
	protected virtual void OnInitialize()
	{
	}

	// Token: 0x06016B35 RID: 92981 RVA: 0x0064D7B1 File Offset: 0x0064B9B1
	protected virtual void OnDestroy()
	{
	}

	// Token: 0x06016B36 RID: 92982 RVA: 0x0064D7B3 File Offset: 0x0064B9B3
	protected virtual void OnActivate()
	{
	}

	// Token: 0x06016B37 RID: 92983 RVA: 0x0064D7B5 File Offset: 0x0064B9B5
	protected virtual void OnDeactivate()
	{
	}

	// Token: 0x06016B38 RID: 92984 RVA: 0x0064D7B7 File Offset: 0x0064B9B7
	protected virtual void OnAddEvents()
	{
	}

	// Token: 0x06016B39 RID: 92985 RVA: 0x0064D7B9 File Offset: 0x0064B9B9
	protected virtual void OnRemoveEvents()
	{
	}

	// Token: 0x06016B3A RID: 92986 RVA: 0x0064D7BB File Offset: 0x0064B9BB
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x06016B3B RID: 92987 RVA: 0x0064D7BD File Offset: 0x0064B9BD
	public bool GetIsActivate()
	{
		return this.IsActivate;
	}

	// Token: 0x06016B3C RID: 92988 RVA: 0x0064D7C5 File Offset: 0x0064B9C5
	[NullableContext(1)]
	protected UiCameraStructure GetCameraStructure()
	{
		return this.OwnerUiCamera.GetStructure();
	}

	// Token: 0x0400AEFE RID: 44798
	protected UiCamera OwnerUiCamera;

	// Token: 0x0400AEFF RID: 44799
	protected BP_CineCamera_C CameraActor;

	// Token: 0x0400AF00 RID: 44800
	protected UCineCameraComponent CineCameraComponent;

	// Token: 0x0400AF01 RID: 44801
	private int TickHandleId;

	// Token: 0x0400AF02 RID: 44802
	private bool IsActivate;
}
