using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002880 RID: 10368
[NullableContext(2)]
[Nullable(0)]
public class CostContentItem : UiPanelBase
{
	// Token: 0x0601485F RID: 84063 RVA: 0x005B1C48 File Offset: 0x005AFE48
	[NullableContext(1)]
	public CostContentItem(RoleBreakPreviewViewModel vm)
	{
		this.BoundViewModel = vm;
	}

	// Token: 0x06014860 RID: 84064 RVA: 0x005B1C58 File Offset: 0x005AFE58
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x06014861 RID: 84065 RVA: 0x005B1CB2 File Offset: 0x005AFEB2
	protected override void OnStart()
	{
		this.BoundViewModel.BindCostContentItem(this);
		this.BoundViewModel.HandleCostContentItemOnStart();
	}

	// Token: 0x06014862 RID: 84066 RVA: 0x005B1CCB File Offset: 0x005AFECB
	protected override void OnBeforeDestroy()
	{
		this.BoundViewModel.UnbindCostContentItem();
		this.BoundViewModel = null;
	}

	// Token: 0x06014863 RID: 84067 RVA: 0x005B1CE0 File Offset: 0x005AFEE0
	public void RefreshTitle(string value)
	{
		string newText = (!string.IsNullOrEmpty(value)) ? value : "";
		base.GetText(0).SetText(newText, true);
	}

	// Token: 0x06014864 RID: 84068 RVA: 0x005B1D0C File Offset: 0x005AFF0C
	public void RefreshCostNumber(string value)
	{
		string newText = (!string.IsNullOrEmpty(value)) ? value : "";
		base.GetText(1).SetText(newText, true);
	}

	// Token: 0x06014865 RID: 84069 RVA: 0x005B1D38 File Offset: 0x005AFF38
	public void RefreshMoneyIcon(EItemId value)
	{
		base.SetItemIcon(base.GetTexture(2), (int)value, null, null);
	}

	// Token: 0x04009EB9 RID: 40633
	private RoleBreakPreviewViewModel BoundViewModel;

	// Token: 0x02008BDB RID: 35803
	[NullableContext(0)]
	private enum ECostContentItemComponent
	{
		// Token: 0x0402F1F7 RID: 193015
		Title,
		// Token: 0x0402F1F8 RID: 193016
		CostNumber,
		// Token: 0x0402F1F9 RID: 193017
		MoneyIcon
	}
}
