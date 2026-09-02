using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.KeySetting;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Ui;

// Token: 0x02002088 RID: 8328
[NullableContext(2)]
[Nullable(0)]
public class KeySettingViewBase : UiViewBase
{
	// Token: 0x0600FDC2 RID: 64962 RVA: 0x00459ABF File Offset: 0x00457CBF
	[NullableContext(1)]
	public KeySettingViewBase(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FDC3 RID: 64963 RVA: 0x00459AC8 File Offset: 0x00457CC8
	protected override void OnStartImplementImplement()
	{
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

	// Token: 0x0600FDC4 RID: 64964 RVA: 0x00459B64 File Offset: 0x00457D64
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

	// Token: 0x0600FDC5 RID: 64965 RVA: 0x00459BFE File Offset: 0x00457DFE
	protected virtual void OnWaitKeySetting()
	{
	}

	// Token: 0x0600FDC6 RID: 64966 RVA: 0x00459C00 File Offset: 0x00457E00
	protected virtual void OnBeforeBeginEditKey()
	{
	}

	// Token: 0x0600FDC7 RID: 64967 RVA: 0x00459C02 File Offset: 0x00457E02
	protected virtual void OnBeginEditKey()
	{
	}

	// Token: 0x0600FDC8 RID: 64968 RVA: 0x00459C04 File Offset: 0x00457E04
	protected virtual void OnFinishEditKey()
	{
	}

	// Token: 0x0600FDC9 RID: 64969 RVA: 0x00459C06 File Offset: 0x00457E06
	[NullableContext(1)]
	protected virtual void OnKeyChange(KeySettingRowData data, CSharpScript.Game.Module.Menu.EInputControllerType type)
	{
	}

	// Token: 0x0600FDCA RID: 64970 RVA: 0x00459C08 File Offset: 0x00457E08
	protected virtual void OnKeySelected(KeySettingRowData data)
	{
	}

	// Token: 0x0600FDCB RID: 64971 RVA: 0x00459C0A File Offset: 0x00457E0A
	protected virtual void OnKeyHover(KeySettingRowData data)
	{
	}

	// Token: 0x0600FDCC RID: 64972 RVA: 0x00459C0C File Offset: 0x00457E0C
	protected virtual void OnKeyUnHover(KeySettingRowData data)
	{
	}

	// Token: 0x0600FDCD RID: 64973 RVA: 0x00459C0E File Offset: 0x00457E0E
	[NullableContext(1)]
	private void DelegateOnWaitKeySetting(KeySettingRowData data, IKeySettingItem item)
	{
		this.OnWaitKeySetting();
	}

	// Token: 0x0600FDCE RID: 64974 RVA: 0x00459C16 File Offset: 0x00457E16
	private void DelegateOnBeforeBeginEditKey()
	{
		this.OnBeforeBeginEditKey();
	}

	// Token: 0x0600FDCF RID: 64975 RVA: 0x00459C1E File Offset: 0x00457E1E
	private void DelegateOnBeginEditKey()
	{
		this.OnBeginEditKey();
	}

	// Token: 0x0600FDD0 RID: 64976 RVA: 0x00459C26 File Offset: 0x00457E26
	private void DelegateOnFinishEditKey()
	{
		this.OnFinishEditKey();
	}

	// Token: 0x0600FDD1 RID: 64977 RVA: 0x00459C2E File Offset: 0x00457E2E
	[NullableContext(1)]
	private void DelegateOnKeyChange(KeySettingRowData data, CSharpScript.Game.Module.Menu.EInputControllerType type)
	{
		this.OnKeyChange(data, type);
	}

	// Token: 0x0600FDD2 RID: 64978 RVA: 0x00459C38 File Offset: 0x00457E38
	private void DelegateOnKeySelected(KeySettingRowData data)
	{
		this.OnKeySelected(data);
	}

	// Token: 0x0600FDD3 RID: 64979 RVA: 0x00459C41 File Offset: 0x00457E41
	private void DelegateOnKeyHover(KeySettingRowData data)
	{
		this.OnKeyHover(data);
	}

	// Token: 0x0600FDD4 RID: 64980 RVA: 0x00459C4A File Offset: 0x00457E4A
	private void DelegateOnKeyUnHover(KeySettingRowData data)
	{
		this.OnKeyUnHover(data);
	}
}
