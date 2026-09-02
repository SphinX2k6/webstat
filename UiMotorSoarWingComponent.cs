using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002CA2 RID: 11426
[NullableContext(2)]
[Nullable(0)]
public class UiMotorSoarWingComponent : UiModelComponentBase
{
	// Token: 0x06016EDD RID: 93917 RVA: 0x0065B0EE File Offset: 0x006592EE
	protected override void OnInit()
	{
		this.ModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.SoarWingHandle = SkeletalObserverManager.NewSkeletalObserver(EUiModelUseWay.MotorSoarWingOnMotor);
		this.SetActive(false);
	}

	// Token: 0x06016EDE RID: 93918 RVA: 0x0065B128 File Offset: 0x00659328
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnMotorMeshLoadComplete));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnUiMotorModelStartLoad));
	}

	// Token: 0x06016EDF RID: 93919 RVA: 0x0065B17C File Offset: 0x0065937C
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnMotorMeshLoadComplete));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnUiMotorModelStartLoad));
		this.DestroySoarWingEffects();
		if (this.SoarWingHandle != null)
		{
			SkeletalObserverManager.DestroySkeletalObserver(this.SoarWingHandle);
			this.SoarWingHandle = null;
		}
	}

	// Token: 0x06016EE0 RID: 93920 RVA: 0x0065B1ED File Offset: 0x006593ED
	private bool IsMotorLoadComplete()
	{
		UiModelDataComponent modelDataComponent = this.ModelDataComponent;
		return modelDataComponent != null && modelDataComponent.GetModelLoadState() == EUiModelLoadState.LoadComplete;
	}

	// Token: 0x06016EE1 RID: 93921 RVA: 0x0065B203 File Offset: 0x00659403
	public void TrySetActive(bool isActive)
	{
		if (isActive && (!this.IsMotorLoadComplete() || !this.CanShowMotorSoarWing))
		{
			return;
		}
		this.SetActive(isActive);
	}

	// Token: 0x06016EE2 RID: 93922 RVA: 0x0065B220 File Offset: 0x00659420
	public void SetActive(bool isActive)
	{
		if ((isActive && this.CurState == ESoaringWingState.Showing) || (!isActive && this.CurState == ESoaringWingState.Hidden))
		{
			return;
		}
		SkeletalObserverHandle soarWingHandle = this.SoarWingHandle;
		object obj;
		if (soarWingHandle == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = soarWingHandle.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.SetVisible(isActive);
		}
		this.CurState = (isActive ? ESoaringWingState.Showing : ESoaringWingState.Hidden);
	}

	// Token: 0x06016EE3 RID: 93923 RVA: 0x0065B27E File Offset: 0x0065947E
	public void SetSoarWingId(int soarWingId)
	{
		this.SoarWingId = soarWingId;
	}

	// Token: 0x06016EE4 RID: 93924 RVA: 0x0065B287 File Offset: 0x00659487
	public void SetCanShowSoarWing(bool canShow)
	{
		this.CanShowMotorSoarWing = canShow;
	}

	// Token: 0x06016EE5 RID: 93925 RVA: 0x0065B290 File Offset: 0x00659490
	public void RefreshSoarWing(int soarWingId)
	{
		if (!this.CanShowMotorSoarWing)
		{
			this.SetActive(false);
			this.DestroySoarWingEffects();
			return;
		}
		this.DestroySoarWingEffects();
		SkeletalObserverHandle soarWingHandle = this.SoarWingHandle;
		UiModelBase uiModelBase = (soarWingHandle != null) ? soarWingHandle.Model : null;
		UiDecorationLoadComponent uiDecorationLoadComponent = (uiModelBase != null) ? uiModelBase.CheckGetComponent<UiDecorationLoadComponent>() : null;
		if (uiDecorationLoadComponent == null || this.ActorComponent == null)
		{
			return;
		}
		uiDecorationLoadComponent.SetAttachActorComponent(this.ActorComponent);
		uiDecorationLoadComponent.LoadModelByModelId(soarWingId, 0, false, delegate
		{
			this.TrySetActive(true);
			this.SpawnSoarWingEffects(soarWingId);
		}, null, false);
	}

	// Token: 0x06016EE6 RID: 93926 RVA: 0x0065B320 File Offset: 0x00659520
	public void RefreshCurSoarWing()
	{
		this.RefreshSoarWing(this.SoarWingId);
	}

	// Token: 0x06016EE7 RID: 93927 RVA: 0x0065B32E File Offset: 0x0065952E
	[NullableContext(1)]
	private SDecorationConfig GetSoarWingConfig(int configId)
	{
		return DataTableUtil.GetDataTableRowFromName<SDecorationConfig>(EDataTable.DecorationConfig, configId.ToString());
	}

	// Token: 0x06016EE8 RID: 93928 RVA: 0x0065B340 File Offset: 0x00659540
	private void SpawnSoarWingEffects(int soarWingId)
	{
		if (!this.CanShowMotorSoarWing || soarWingId <= 0 || this.SoarWingEffectHandleSet.Count > 0)
		{
			return;
		}
		SDecorationConfig soarWingConfig = this.GetSoarWingConfig(soarWingId);
		if (soarWingConfig.Effects.Num() <= 0)
		{
			return;
		}
		SkeletalObserverHandle soarWingHandle = this.SoarWingHandle;
		USkeletalMeshComponent uskeletalMeshComponent;
		if (soarWingHandle == null)
		{
			uskeletalMeshComponent = null;
		}
		else
		{
			UiModelBase model = soarWingHandle.Model;
			if (model == null)
			{
				uskeletalMeshComponent = null;
			}
			else
			{
				UiModelActorComponent uiModelActorComponent = model.CheckGetComponent<UiModelActorComponent>();
				uskeletalMeshComponent = ((uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null);
			}
		}
		USkeletalMeshComponent uskeletalMeshComponent2 = uskeletalMeshComponent;
		if (uskeletalMeshComponent2 == null)
		{
			return;
		}
		SkeletalObserverHandle soarWingHandle2 = this.SoarWingHandle;
		UiModelEffectComponent uiModelEffectComponent;
		if (soarWingHandle2 == null)
		{
			uiModelEffectComponent = null;
		}
		else
		{
			UiModelBase model2 = soarWingHandle2.Model;
			uiModelEffectComponent = ((model2 != null) ? model2.CheckGetComponent<UiModelEffectComponent>() : null);
		}
		UiModelEffectComponent uiModelEffectComponent2 = uiModelEffectComponent;
		if (uiModelEffectComponent2 == null)
		{
			return;
		}
		for (int i = 0; i < soarWingConfig.Effects.Num(); i++)
		{
			SDecorationConfig_Effect sdecorationConfig_Effect = soarWingConfig.Effects.Get(i);
			UiModelEffectPlayContext context = new UiModelEffectPlayContext
			{
				EffectPath = sdecorationConfig_Effect.EffectData.ToAssetPathName(),
				AttachTargetComponent = uskeletalMeshComponent2,
				Transform = Singleton<MathUtils>.Instance.DefaultTransformDouble,
				SocketName = (FNameUtil.GetDynamicFName(sdecorationConfig_Effect.EffectSocketName) ?? FNameUtil.EMPTY)
			};
			int item = uiModelEffectComponent2.PlayEffectByContext(context);
			this.SoarWingEffectHandleSet.Add(item);
		}
	}

	// Token: 0x06016EE9 RID: 93929 RVA: 0x0065B470 File Offset: 0x00659670
	private void DestroySoarWingEffects()
	{
		if (this.SoarWingEffectHandleSet.Count <= 0)
		{
			return;
		}
		SkeletalObserverHandle soarWingHandle = this.SoarWingHandle;
		UiModelEffectComponent uiModelEffectComponent;
		if (soarWingHandle == null)
		{
			uiModelEffectComponent = null;
		}
		else
		{
			UiModelBase model = soarWingHandle.Model;
			uiModelEffectComponent = ((model != null) ? model.CheckGetComponent<UiModelEffectComponent>() : null);
		}
		UiModelEffectComponent uiModelEffectComponent2 = uiModelEffectComponent;
		if (uiModelEffectComponent2 == null)
		{
			this.SoarWingEffectHandleSet.Clear();
			return;
		}
		foreach (int effectHandle in this.SoarWingEffectHandleSet)
		{
			uiModelEffectComponent2.StopEffect(effectHandle, true);
		}
		this.SoarWingEffectHandleSet.Clear();
	}

	// Token: 0x06016EEA RID: 93930 RVA: 0x0065B50C File Offset: 0x0065970C
	private void OnMotorMeshLoadComplete()
	{
		this.TrySetActive(true);
		this.SpawnSoarWingEffects(this.SoarWingId);
	}

	// Token: 0x06016EEB RID: 93931 RVA: 0x0065B521 File Offset: 0x00659721
	private void OnUiMotorModelStartLoad()
	{
		this.SetActive(false);
		this.RefreshSoarWing(this.SoarWingId);
	}

	// Token: 0x0400B0DA RID: 45274
	private UiModelDataComponent ModelDataComponent;

	// Token: 0x0400B0DB RID: 45275
	private UiModelActorComponent ActorComponent;

	// Token: 0x0400B0DC RID: 45276
	private SkeletalObserverHandle SoarWingHandle;

	// Token: 0x0400B0DD RID: 45277
	private ESoaringWingState CurState;

	// Token: 0x0400B0DE RID: 45278
	private int SoarWingId;

	// Token: 0x0400B0DF RID: 45279
	private bool CanShowMotorSoarWing;

	// Token: 0x0400B0E0 RID: 45280
	[Nullable(1)]
	private readonly HashSet<int> SoarWingEffectHandleSet = new HashSet<int>();
}
