using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200107B RID: 4219
public class FurnitureAreaPointItem : GridProxyAbstract<bool>
{
	// Token: 0x06006DB0 RID: 28080 RVA: 0x001C845B File Offset: 0x001C665B
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle))
		};
	}

	// Token: 0x06006DB1 RID: 28081 RVA: 0x001C847E File Offset: 0x001C667E
	public override void Refresh(bool isSelected, bool isSelected2, int gridIndex)
	{
		this.IsSelected = isSelected;
		this.RefreshItemToggle();
	}

	// Token: 0x06006DB2 RID: 28082 RVA: 0x001C848D File Offset: 0x001C668D
	public void RefreshItemToggle()
	{
		base.GetExtendToggle(0).SetToggleState(this.IsSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04003409 RID: 13321
	private bool IsSelected;
}
