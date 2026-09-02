using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;

// Token: 0x020025DD RID: 9693
public abstract class PhotographSetupBase : UiPanelBase, IPhotographSetupItem
{
	// Token: 0x06012F3E RID: 77630 RVA: 0x0053DDA6 File Offset: 0x0053BFA6
	public virtual void Initialize(EPhotoSetupValueType setupValueType)
	{
		this.SetupValueType = setupValueType;
		this.Refresh();
	}

	// Token: 0x06012F3F RID: 77631
	public abstract void Refresh();

	// Token: 0x06012F40 RID: 77632 RVA: 0x0053DDB5 File Offset: 0x0053BFB5
	public virtual void SetEnable(bool bEnable)
	{
		this.SetActive(bEnable);
	}

	// Token: 0x06012F41 RID: 77633 RVA: 0x0053DDBE File Offset: 0x0053BFBE
	public EPhotoSetupValueType GetSetupId()
	{
		return this.SetupValueType;
	}

	// Token: 0x06012F42 RID: 77634 RVA: 0x0053DDC6 File Offset: 0x0053BFC6
	public PhotoSetup? GetSetupConfig()
	{
		return this.SetupConfig;
	}

	// Token: 0x06012F43 RID: 77635 RVA: 0x0053DDCE File Offset: 0x0053BFCE
	public void Destroy()
	{
		base.Destroy(null);
	}

	// Token: 0x06012F44 RID: 77636 RVA: 0x0053DDD8 File Offset: 0x0053BFD8
	protected bool IsPhotoSetupRedDotVisible()
	{
		return this.SetupConfig != null && this.SetupConfig.GetValueOrDefault().IsShowRedDot && !(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.Photography) as ServerStorageSet).Has(this.SetupConfig.Value.Id);
	}

	// Token: 0x06012F45 RID: 77637 RVA: 0x0053DE38 File Offset: 0x0053C038
	[NullableContext(1)]
	protected void MarkPhotoSetupRedDotAsRead(Action onRead)
	{
		if (this.SetupConfig == null || !this.SetupConfig.GetValueOrDefault().IsShowRedDot)
		{
			return;
		}
		ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.Photography) as ServerStorageSet;
		if (serverStorageSet.Has(this.SetupConfig.Value.Id))
		{
			return;
		}
		serverStorageSet.Add(this.SetupConfig.Value.Id);
		onRead();
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotPhotoSetup);
	}

	// Token: 0x040093F3 RID: 37875
	protected EPhotoSetupValueType SetupValueType;

	// Token: 0x040093F4 RID: 37876
	protected PhotoSetup? SetupConfig;
}
