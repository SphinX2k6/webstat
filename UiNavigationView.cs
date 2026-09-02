using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002CCD RID: 11469
public class UiNavigationView : UiPanelBase
{
	// Token: 0x060171B6 RID: 94646 RVA: 0x00667250 File Offset: 0x00665450
	protected override void OnBeforeShowImplement()
	{
		this.InitData();
	}

	// Token: 0x060171B7 RID: 94647 RVA: 0x00667258 File Offset: 0x00665458
	protected override void OnAfterShowImplement()
	{
		this.AfterActive();
	}

	// Token: 0x060171B8 RID: 94648 RVA: 0x00667260 File Offset: 0x00665460
	protected bool FindDefault()
	{
		return true;
	}

	// Token: 0x060171B9 RID: 94649 RVA: 0x00667263 File Offset: 0x00665463
	protected virtual void AfterActive()
	{
	}

	// Token: 0x060171BA RID: 94650 RVA: 0x00667265 File Offset: 0x00665465
	protected override void OnBeforeDestroyImplement()
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem != null && rootItem.IsValid())
		{
			this.SetActive(false);
		}
	}

	// Token: 0x060171BB RID: 94651 RVA: 0x00667282 File Offset: 0x00665482
	private void InitData()
	{
		this.ViewName = base.GetRootItem().GetDisplayName();
	}

	// Token: 0x0400B1CE RID: 45518
	[Nullable(1)]
	protected string ViewName;
}
