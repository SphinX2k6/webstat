using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200287F RID: 10367
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class LevelLayoutGrid : GridProxyAbstract<ILevelLayoutGridData>
{
	// Token: 0x06014859 RID: 84057 RVA: 0x005B1AAB File Offset: 0x005AFCAB
	public LevelLayoutGrid(RoleBreakPreviewViewModel vm)
	{
		this.BoundViewModel = vm;
	}

	// Token: 0x0601485A RID: 84058 RVA: 0x005B1ABA File Offset: 0x005AFCBA
	private void Dispose()
	{
		this.BoundViewModel = null;
	}

	// Token: 0x0601485B RID: 84059 RVA: 0x005B1AC4 File Offset: 0x005AFCC4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickToggle))
		};
	}

	// Token: 0x0601485C RID: 84060 RVA: 0x005B1B84 File Offset: 0x005AFD84
	public override void Refresh(ILevelLayoutGridData data, bool isSelected, int gridIndex)
	{
		base.GridIndex = gridIndex;
		bool isAvailable = data.IsAvailable;
		string text = data.LevelContent.ToString();
		base.GetItem(0).SetUIActive(!isAvailable);
		base.GetText(1).SetText(isAvailable ? "" : text, true);
		base.GetItem(2).SetUIActive(isAvailable);
		base.GetText(3).SetText(isAvailable ? text : "", true);
		base.GetItem(4).SetUIActive(gridIndex != 0);
		base.GetExtendToggle(5).SetToggleState(data.IsChosen ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0601485D RID: 84061 RVA: 0x005B1C27 File Offset: 0x005AFE27
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		this.Dispose();
	}

	// Token: 0x0601485E RID: 84062 RVA: 0x005B1C35 File Offset: 0x005AFE35
	private void OnClickToggle()
	{
		this.BoundViewModel.HandleItemOnClickToggle(base.GridIndex);
	}

	// Token: 0x04009EB8 RID: 40632
	[Nullable(2)]
	private RoleBreakPreviewViewModel BoundViewModel;

	// Token: 0x02008BDA RID: 35802
	[NullableContext(0)]
	private enum ELevelLayoutGridComponent
	{
		// Token: 0x0402F1F0 RID: 193008
		DarkItem,
		// Token: 0x0402F1F1 RID: 193009
		DarkText,
		// Token: 0x0402F1F2 RID: 193010
		LightItem,
		// Token: 0x0402F1F3 RID: 193011
		LightText,
		// Token: 0x0402F1F4 RID: 193012
		LeftLine,
		// Token: 0x0402F1F5 RID: 193013
		Toggle
	}
}
