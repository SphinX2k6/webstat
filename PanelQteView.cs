using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.UI;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200235D RID: 9053
[NullableContext(1)]
[Nullable(0)]
public class PanelQteView : UiTickViewBase
{
	// Token: 0x060114F3 RID: 70899 RVA: 0x004C34AA File Offset: 0x004C16AA
	public PanelQteView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060114F4 RID: 70900 RVA: 0x004C34D9 File Offset: 0x004C16D9
	protected override void OnRegisterComponent()
	{
		this.IsMobile = Singleton<Info>.Instance.IsInTouch();
	}

	// Token: 0x060114F5 RID: 70901 RVA: 0x004C34EB File Offset: 0x004C16EB
	protected override void OnAfterShow()
	{
		this.RefreshVisible();
	}

	// Token: 0x060114F6 RID: 70902 RVA: 0x004C34F4 File Offset: 0x004C16F4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
		Singleton<EventSystem>.Instance.Add(EEventName.DisActiveBattleView, new Action(this.OnDisActiveBattleView));
		Singleton<EventSystem>.Instance.Add(EEventName.PanelQteEnd, new Action<int, bool>(this.OnPanelQteEnd));
		if (!this.IsMobile)
		{
			Singleton<EventSystem>.Instance.Add(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		}
		ModelBase<BattleUiModel>.Instance.ChildViewData.AddCallback(EBattleUiChild.PanelQTE, new Action(this.OnVisibleChanged));
	}

	// Token: 0x060114F7 RID: 70903 RVA: 0x004C3598 File Offset: 0x004C1798
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
		Singleton<EventSystem>.Instance.Remove(EEventName.DisActiveBattleView, new Action(this.OnDisActiveBattleView));
		Singleton<EventSystem>.Instance.Remove(EEventName.PanelQteEnd, new Action<int, bool>(this.OnPanelQteEnd));
		if (!this.IsMobile)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		}
		ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveCallback(EBattleUiChild.PanelQTE, new Action(this.OnVisibleChanged));
	}

	// Token: 0x060114F8 RID: 70904 RVA: 0x004C363A File Offset: 0x004C183A
	private void OnVisibleChanged()
	{
		this.RefreshVisible();
	}

	// Token: 0x060114F9 RID: 70905 RVA: 0x004C3644 File Offset: 0x004C1844
	protected virtual void RefreshVisible()
	{
		bool childVisible = ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.PanelQTE);
		this.SetActive(childVisible);
	}

	// Token: 0x060114FA RID: 70906 RVA: 0x004C366A File Offset: 0x004C186A
	private void OnActiveBattleView()
	{
		this.IsPause = false;
	}

	// Token: 0x060114FB RID: 70907 RVA: 0x004C3673 File Offset: 0x004C1873
	private void OnDisActiveBattleView()
	{
		this.IsPause = true;
	}

	// Token: 0x060114FC RID: 70908 RVA: 0x004C367C File Offset: 0x004C187C
	private void OnPanelQteEnd(int handleId, bool isQteSuccess)
	{
		if ((int)(this.OpenParam ?? 0) != handleId)
		{
			return;
		}
		this.IsQteEnd = true;
		this.HandleQteEnd();
	}

	// Token: 0x060114FD RID: 70909 RVA: 0x004C36A4 File Offset: 0x004C18A4
	protected virtual void HandleQteEnd()
	{
	}

	// Token: 0x060114FE RID: 70910 RVA: 0x004C36A6 File Offset: 0x004C18A6
	private void InputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		this.InputControllerChangeInner();
	}

	// Token: 0x060114FF RID: 70911 RVA: 0x004C36AE File Offset: 0x004C18AE
	protected virtual void InputControllerChangeInner()
	{
	}

	// Token: 0x06011500 RID: 70912 RVA: 0x004C36B0 File Offset: 0x004C18B0
	protected override void OnTick(float delta)
	{
		if (this.IsPause)
		{
			return;
		}
		if (this.IsQteStart && !this.IsQteEnd)
		{
			ModelBase<PanelQteModel>.Instance.UpdateTime(delta);
		}
	}

	// Token: 0x06011501 RID: 70913 RVA: 0x004C36D8 File Offset: 0x004C18D8
	protected override void OnBeforeDestroy()
	{
		this.ClearCameraShake();
		this.ClearBuff();
		if (ModelBase<PanelQteModel>.Instance.IsInQte.GetValueOrDefault())
		{
			int num = (int)(this.OpenParam ?? 0);
			PanelQteContext context = ModelBase<PanelQteModel>.Instance.GetContext();
			if (num == context.QteHandleId)
			{
				ControllerBase<PanelQteController>.Instance.StopQte(num, true);
			}
		}
	}

	// Token: 0x06011502 RID: 70914 RVA: 0x004C373C File Offset: 0x004C193C
	protected void InitCameraShake(SPanelQte qteConfig)
	{
		this.CameraShakeOnInput = qteConfig.CameraShakeOnInput;
		if (this.CameraShakeOnInput)
		{
			this.LoadCameraShakeHandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(qteConfig.CameraShakeType.ToAssetPathName(), delegate([Nullable(2)] UClass shakeType, string _)
			{
				this.CameraShakeType = shakeType;
				this.LoadCameraShakeHandleId = -1;
			}, 100, this.MemoryTag);
		}
	}

	// Token: 0x06011503 RID: 70915 RVA: 0x004C378C File Offset: 0x004C198C
	protected void PlayCameraShake()
	{
		if (this.CameraShakeType != null)
		{
			Vector cameraLocation = ModelBase<CameraModel>.Instance.MainModel.CameraLocation;
			ControllerBase<CameraController>.Instance.PlayWorldCameraShake(this.CameraShakeType, new FVectorDouble?(cameraLocation.ToUeVector(false)), 0f, 500f, 1f, false, "MainCamera");
		}
	}

	// Token: 0x06011504 RID: 70916 RVA: 0x004C37E7 File Offset: 0x004C19E7
	protected void ClearCameraShake()
	{
		this.CameraShakeOnInput = false;
		this.CameraShakeType = null;
		if (this.LoadCameraShakeHandleId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadCameraShakeHandleId);
			this.LoadCameraShakeHandleId = -1;
		}
	}

	// Token: 0x06011505 RID: 70917 RVA: 0x004C3817 File Offset: 0x004C1A17
	protected void InitBuff(SPanelQte qteConfig)
	{
		this.BuffId = new long?(qteConfig.BuffOnInput);
		this.BuffCd = Math.Max(qteConfig.BuffCd * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1000f);
	}

	// Token: 0x06011506 RID: 70918 RVA: 0x004C3854 File Offset: 0x004C1A54
	protected void AddBuff()
	{
		if (this.BuffId == null || this.BuffId.Value == 0L)
		{
			return;
		}
		if (Singleton<Time>.Instance.WorldTime < this.BuffEnableTime)
		{
			return;
		}
		this.BuffEnableTime = Singleton<Time>.Instance.WorldTime + this.BuffCd;
		PanelQteContext context = ModelBase<PanelQteModel>.Instance.GetContext();
		Entity sourceEntity = context.GetSourceEntity();
		if (sourceEntity != null)
		{
			long creatureDataId = sourceEntity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
			CharacterBuffComponent component = sourceEntity.GetComponent<CharacterBuffComponent>();
			if (component == null)
			{
				return;
			}
			component.AddBuff(this.BuffId.Value, new AddBuffParam
			{
				InstigatorId = creatureDataId,
				Reason = "界面QTE输入时添加",
				PreMessageId = context.PreMessageId
			});
		}
	}

	// Token: 0x06011507 RID: 70919 RVA: 0x004C3918 File Offset: 0x004C1B18
	protected void ClearBuff()
	{
		this.BuffId = null;
	}

	// Token: 0x040087F9 RID: 34809
	protected bool IsMobile;

	// Token: 0x040087FA RID: 34810
	protected bool IsPause;

	// Token: 0x040087FB RID: 34811
	protected bool IsQteStart = true;

	// Token: 0x040087FC RID: 34812
	protected bool IsQteEnd;

	// Token: 0x040087FD RID: 34813
	protected bool CameraShakeOnInput;

	// Token: 0x040087FE RID: 34814
	protected int LoadCameraShakeHandleId = -1;

	// Token: 0x040087FF RID: 34815
	[Nullable(2)]
	protected UClass CameraShakeType;

	// Token: 0x04008800 RID: 34816
	protected long? BuffId;

	// Token: 0x04008801 RID: 34817
	protected Number BuffCd = 0;

	// Token: 0x04008802 RID: 34818
	protected Number BuffEnableTime = 0;
}
