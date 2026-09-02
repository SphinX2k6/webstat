using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002519 RID: 9497
internal class CostDistributionItem : GridProxyAbstract<int>
{
	// Token: 0x060126C8 RID: 75464 RVA: 0x00511071 File Offset: 0x0050F271
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x060126C9 RID: 75465 RVA: 0x00511094 File Offset: 0x0050F294
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.SetText(data.ToString(), true);
	}
}
