using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.KeySetting;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Ui;

// Token: 0x02002087 RID: 8327
[NullableContext(2)]
[Nullable(0)]
public class KeySettingPanelBase : UiPanelBase
{
	// Token: 0x0600FDAF RID: 64943 RVA: 0x00459918 File Offset: 0x00457B18
	public KeySettingPanelBase(EKeySettingExclusiveType exclusiveType = EKeySettingExclusiveType.None)
	{
		this.ExclusiveType = exclusiveType;
	}

	// Token: 0x0600FDB0 RID: 64944 RVA: 0x00459928 File Offset: 0x00457B28
	protected override void OnStartImplement()
	{
		KeySettingViewModel.InitData(this.ExclusiveType);
		KeySettingViewModel.OnViewStart();
		KeySettingViewModel.AddOnWaitKeySettingDelegate(new Action<KeySettingRowData, IKeySettingItem>(this.DelegateOnWaitKeySetting));
		KeySettingViewModel.AddOnBeforeBeginEditKeyDelegate(new Action(this.DelegateOnBeforeBeginEditKey));
		KeySettingViewModel.AddOnBeginEditKeyDelegate(new Action(this.DelegateOnBeginEditKey));
		KeySettingViewModel.AddOnFinishEditKeyDelegate(new Action(this.DelegateOnFinishEditKey));
		KeySettingViewModel.AddOnKeySelectedDelegate(new Action<KeySettingRowData>(this.DelegateOnKeySelected));
		KeySettingViewModel.AddOnKeyChangeDelegate(new Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(this.DelegateOnKeyChange));
		KeySettingViewModel.AddOnKeyHoverDelegate(new Action<KeySettingRowData>(this.DelegateOnKeyHover));
		KeySettingViewModel.AddOnKeyUnHoverDelegate(new Action<KeySettingRowData>(this.DelegateOnKeyUnHover));
	}

	// Token: 0x0600FDB1 RID: 64945 RVA: 0x004599D0 File Offset: 0x00457BD0
	protected override void OnBeforeDestroyImplement()
	{
		KeySettingViewModel.RemoveOnWaitKeySettingDelegate(new Action<KeySettingRowData, IKeySettingItem>(this.DelegateOnWaitKeySetting));
		KeySettingViewModel.RemoveOnBeforeBeginEditKeyDelegate(new Action(this.DelegateOnBeforeBeginEditKey));
		KeySettingViewModel.RemoveOnBeginEditKeyDelegate(new Action(this.DelegateOnBeginEditKey));
		KeySettingViewModel.RemoveOnFinishEditKeyDelegate(new Action(this.DelegateOnFinishEditKey));
		KeySettingViewModel.RemoveOnKeySelectedDelegate(new Action<KeySettingRowData>(this.DelegateOnKeySelected));
		KeySettingViewModel.RemoveOnKeyChangeDelegate(new Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(this.DelegateOnKeyChange));
		KeySettingViewModel.RemoveOnKeyHoverDelegate(new Action<KeySettingRowData>(this.DelegateOnKeyHover));
		KeySettingViewModel.RemoveOnKeyUnHoverDelegate(new Action<KeySettingRowData>(this.DelegateOnKeyUnHover));
		KeySettingViewModel.OnViewDestroy();
	}

	// Token: 0x0600FDB2 RID: 64946 RVA: 0x00459A6A File Offset: 0x00457C6A
	protected virtual void OnWaitKeySetting()
	{
	}

	// Token: 0x0600FDB3 RID: 64947 RVA: 0x00459A6C File Offset: 0x00457C6C
	protected virtual void OnBeforeBeginEditKey()
	{
	}

	// Token: 0x0600FDB4 RID: 64948 RVA: 0x00459A6E File Offset: 0x00457C6E
	protected virtual void OnBeginEditKey()
	{
	}

	// Token: 0x0600FDB5 RID: 64949 RVA: 0x00459A70 File Offset: 0x00457C70
	protected virtual void OnFinishEditKey()
	{
	}

	// Token: 0x0600FDB6 RID: 64950 RVA: 0x00459A72 File Offset: 0x00457C72
	[NullableContext(1)]
	protected virtual void OnKeyChange(KeySettingRowData data, CSharpScript.Game.Module.Menu.EInputControllerType type)
	{
	}

	// Token: 0x0600FDB7 RID: 64951 RVA: 0x00459A74 File Offset: 0x00457C74
	protected virtual void OnKeySelected(KeySettingRowData data)
	{
	}

	// Token: 0x0600FDB8 RID: 64952 RVA: 0x00459A76 File Offset: 0x00457C76
	protected virtual void OnKeyHover(KeySettingRowData data)
	{
	}

	// Token: 0x0600FDB9 RID: 64953 RVA: 0x00459A78 File Offset: 0x00457C78
	protected virtual void OnKeyUnHover(KeySettingRowData data)
	{
	}

	// Token: 0x0600FDBA RID: 64954 RVA: 0x00459A7A File Offset: 0x00457C7A
	[NullableContext(1)]
	private void DelegateOnWaitKeySetting(KeySettingRowData data, IKeySettingItem item)
	{
		this.OnWaitKeySetting();
	}

	// Token: 0x0600FDBB RID: 64955 RVA: 0x00459A82 File Offset: 0x00457C82
	private void DelegateOnBeforeBeginEditKey()
	{
		this.OnBeforeBeginEditKey();
	}

	// Token: 0x0600FDBC RID: 64956 RVA: 0x00459A8A File Offset: 0x00457C8A
	private void DelegateOnBeginEditKey()
	{
		this.OnBeginEditKey();
	}

	// Token: 0x0600FDBD RID: 64957 RVA: 0x00459A92 File Offset: 0x00457C92
	private void DelegateOnFinishEditKey()
	{
		this.OnFinishEditKey();
	}

	// Token: 0x0600FDBE RID: 64958 RVA: 0x00459A9A File Offset: 0x00457C9A
	[NullableContext(1)]
	private void DelegateOnKeyChange(KeySettingRowData data, CSharpScript.Game.Module.Menu.EInputControllerType type)
	{
		this.OnKeyChange(data, type);
	}

	// Token: 0x0600FDBF RID: 64959 RVA: 0x00459AA4 File Offset: 0x00457CA4
	private void DelegateOnKeySelected(KeySettingRowData data)
	{
		this.OnKeySelected(data);
	}

	// Token: 0x0600FDC0 RID: 64960 RVA: 0x00459AAD File Offset: 0x00457CAD
	private void DelegateOnKeyHover(KeySettingRowData data)
	{
		this.OnKeyHover(data);
	}

	// Token: 0x0600FDC1 RID: 64961 RVA: 0x00459AB6 File Offset: 0x00457CB6
	private void DelegateOnKeyUnHover(KeySettingRowData data)
	{
		this.OnKeyUnHover(data);
	}

	// Token: 0x040079BD RID: 31165
	private readonly EKeySettingExclusiveType ExclusiveType;
}
