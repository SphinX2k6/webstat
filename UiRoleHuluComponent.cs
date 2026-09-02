using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002CAB RID: 11435
[NullableContext(2)]
[Nullable(0)]
public class UiRoleHuluComponent : UiModelComponentBase, IUiModelVisible, IUiModelSetDitherEffect
{
	// Token: 0x06016F14 RID: 93972 RVA: 0x0065BE54 File Offset: 0x0065A054
	protected override void OnInit()
	{
		this.RoleDataComponent = base.Owner.CheckGetComponent<UiRoleDataComponent>();
		this.ModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.AnsControllerComponent = base.Owner.CheckGetComponent<UiModelAnsControllerComponent>();
		this.HuluHandle = SkeletalObserverManager.NewSkeletalObserver(EUiModelUseWay.HuluOnRole);
		this.SetActive(false);
	}

	// Token: 0x06016F15 RID: 93973 RVA: 0x0065BEB8 File Offset: 0x0065A0B8
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleMeshLoadComplete));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnUiRoleModelStartLoad));
		UiModelAnsControllerComponent ansControllerComponent = this.AnsControllerComponent;
		if (ansControllerComponent == null)
		{
			return;
		}
		ansControllerComponent.RegisterAnsTrigger("UiCalabashAnsContext", new Action<UiAnsContextBase>(this.OnAnsBegin), new Action<UiAnsContextBase>(this.OnAnsEnd));
	}

	// Token: 0x06016F16 RID: 93974 RVA: 0x0065BF38 File Offset: 0x0065A138
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleMeshLoadComplete));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnUiRoleModelStartLoad));
		SkeletalObserverManager.DestroySkeletalObserver(this.HuluHandle);
	}

	// Token: 0x06016F17 RID: 93975 RVA: 0x0065BF94 File Offset: 0x0065A194
	[NullableContext(1)]
	public SkeletalObserverHandle GetHuluHandle()
	{
		return this.HuluHandle;
	}

	// Token: 0x06016F18 RID: 93976 RVA: 0x0065BF9C File Offset: 0x0065A19C
	public void OnModelVisibleChange(bool visible)
	{
		if (!visible && this.CurState == EHuluState.Showing)
		{
			this.SetActive(false);
		}
		this.AwaitVisible = new bool?(visible);
	}

	// Token: 0x06016F19 RID: 93977 RVA: 0x0065BFBD File Offset: 0x0065A1BD
	private void OnUiRoleModelStartLoad()
	{
		this.Refresh();
	}

	// Token: 0x06016F1A RID: 93978 RVA: 0x0065BFC5 File Offset: 0x0065A1C5
	public void OnModelDitherEffectChange(float value)
	{
		SkeletalObserverHandle huluHandle = this.HuluHandle;
		if (huluHandle == null)
		{
			return;
		}
		UiModelBase model = huluHandle.Model;
		if (model == null)
		{
			return;
		}
		UiModelDataComponent uiModelDataComponent = model.CheckGetComponent<UiModelDataComponent>();
		if (uiModelDataComponent == null)
		{
			return;
		}
		uiModelDataComponent.SetDitherEffect(value);
	}

	// Token: 0x06016F1B RID: 93979 RVA: 0x0065BFEC File Offset: 0x0065A1EC
	public void Refresh()
	{
		UiModelBase model = this.HuluHandle.Model;
		UiHuluSkinDataComponent uiHuluSkinDataComponent = model.CheckGetComponent<UiHuluSkinDataComponent>();
		if (uiHuluSkinDataComponent != null)
		{
			uiHuluSkinDataComponent.RefreshCurrentSkinData(this.RoleDataComponent.RoleConfigId);
		}
		int modelId = uiHuluSkinDataComponent.ModelId;
		UiModelDataComponent uiModelDataComponent = model.CheckGetComponent<UiModelDataComponent>();
		int num = modelId;
		int? num2 = (uiModelDataComponent != null) ? new int?(uiModelDataComponent.ModelConfigId) : null;
		if (num == num2.GetValueOrDefault() & num2 != null)
		{
			return;
		}
		UiModelLoadComponent uiModelLoadComponent = model.CheckGetComponent<UiModelLoadComponent>();
		if (uiModelLoadComponent == null)
		{
			return;
		}
		uiModelLoadComponent.LoadModelByModelId(modelId, false, null, null);
	}

	// Token: 0x06016F1C RID: 93980 RVA: 0x0065C074 File Offset: 0x0065A274
	public void SetActive(bool isActive)
	{
		if ((isActive && this.CurState == EHuluState.Showing) || (!isActive && this.CurState == EHuluState.Hidden))
		{
			return;
		}
		SkeletalObserverHandle huluHandle = this.HuluHandle;
		object obj;
		if (huluHandle == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = huluHandle.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.SetVisible(isActive);
		}
		this.CurState = (isActive ? EHuluState.Showing : EHuluState.Hidden);
	}

	// Token: 0x06016F1D RID: 93981 RVA: 0x0065C0D4 File Offset: 0x0065A2D4
	public void StartHuluRotate()
	{
		if (this.HuluHandle != null)
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("hulu_rotate_time");
			SkeletalObserverHandle huluHandle = this.HuluHandle;
			object obj;
			if (huluHandle == null)
			{
				obj = null;
			}
			else
			{
				UiModelBase model = huluHandle.Model;
				obj = ((model != null) ? model.CheckGetComponent<UiModelRotateComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				obj2.SetRotateParam((float)intConfig.Value, ERotateAxis.Roll, false);
			}
			if (obj2 == null)
			{
				return;
			}
			obj2.StartRotate();
		}
	}

	// Token: 0x06016F1E RID: 93982 RVA: 0x0065C134 File Offset: 0x0065A334
	public void AttachHuluToRole(FName socketName = default(FName))
	{
		if (socketName == default(FName))
		{
			socketName = Singleton<CharacterNameDefines>.Instance.HULU_CASE;
		}
		this.SocketName = socketName;
		this.ExecuteAttachHuluToRole();
	}

	// Token: 0x06016F1F RID: 93983 RVA: 0x0065C16C File Offset: 0x0065A36C
	private void ExecuteAttachHuluToRole()
	{
		if (this.ModelDataComponent.GetModelLoadState() == EUiModelLoadState.LoadComplete)
		{
			USkeletalMeshComponent mainMeshComponent = this.ActorComponent.MainMeshComponent;
			SkeletalObserverHandle huluHandle = this.HuluHandle;
			object obj;
			if (huluHandle == null)
			{
				obj = null;
			}
			else
			{
				UiModelBase model = huluHandle.Model;
				obj = ((model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				AActor actor = obj2.Actor;
				if (actor != null)
				{
					actor.K2_AttachToComponent(mainMeshComponent, this.SocketName, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
				}
			}
			FHitResult fhitResult = new FHitResult();
			if (obj2 == null)
			{
				return;
			}
			AActor actor2 = obj2.Actor;
			if (actor2 == null)
			{
				return;
			}
			actor2.D_K2_SetActorRelativeTransform(Singleton<MathUtils>.Instance.DefaultTransformDouble, false, ref fhitResult, false);
		}
	}

	// Token: 0x06016F20 RID: 93984 RVA: 0x0065C1FC File Offset: 0x0065A3FC
	public void OnRoleMeshLoadComplete()
	{
		this.ExecuteAttachHuluToRole();
	}

	// Token: 0x06016F21 RID: 93985 RVA: 0x0065C204 File Offset: 0x0065A404
	[NullableContext(1)]
	public void OnAnsBegin(UiAnsContextBase ansContext)
	{
		UiCalabashAnsContext uiCalabashAnsContext = ansContext as UiCalabashAnsContext;
		bool valueOrDefault = this.AwaitVisible.GetValueOrDefault(true);
		this.SetActive(valueOrDefault);
		this.AwaitVisible = null;
		if (uiCalabashAnsContext.IsRotate)
		{
			this.StartHuluRotate();
		}
		FName socket = uiCalabashAnsContext.Socket;
		this.AttachHuluToRole(socket);
	}

	// Token: 0x06016F22 RID: 93986 RVA: 0x0065C252 File Offset: 0x0065A452
	[NullableContext(1)]
	public void OnAnsEnd(UiAnsContextBase ansContext)
	{
		SkeletalObserverHandle huluHandle = this.HuluHandle;
		object obj;
		if (huluHandle == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = huluHandle.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelRotateComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.StopRotate();
		}
		this.SetActive(false);
	}

	// Token: 0x0400B0F2 RID: 45298
	private UiModelDataComponent ModelDataComponent;

	// Token: 0x0400B0F3 RID: 45299
	private UiRoleDataComponent RoleDataComponent;

	// Token: 0x0400B0F4 RID: 45300
	private UiModelActorComponent ActorComponent;

	// Token: 0x0400B0F5 RID: 45301
	private UiModelAnsControllerComponent AnsControllerComponent;

	// Token: 0x0400B0F6 RID: 45302
	private SkeletalObserverHandle HuluHandle;

	// Token: 0x0400B0F7 RID: 45303
	private FName SocketName = Singleton<CharacterNameDefines>.Instance.HULU_SOCKET_NAME;

	// Token: 0x0400B0F8 RID: 45304
	private EHuluState CurState;

	// Token: 0x0400B0F9 RID: 45305
	private bool? AwaitVisible;
}
