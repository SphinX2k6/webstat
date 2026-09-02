using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020029AA RID: 10666
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerBuffWayItem : GridProxyAbstract<IGetWayItemData>
{
	// Token: 0x06015443 RID: 87107 RVA: 0x005E4D14 File Offset: 0x005E2F14
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnWayClick))
		};
	}

	// Token: 0x06015444 RID: 87108 RVA: 0x005E4D7B File Offset: 0x005E2F7B
	[NullableContext(1)]
	public override void Refresh(IGetWayItemData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		base.GetText(1).SetText(this.ItemData.Text, true);
	}

	// Token: 0x06015445 RID: 87109 RVA: 0x005E4D9C File Offset: 0x005E2F9C
	private void OnBtnWayClick()
	{
		IGetWayItemData itemData = this.ItemData;
		if (itemData == null)
		{
			return;
		}
		Action function = itemData.Function;
		if (function == null)
		{
			return;
		}
		function();
	}

	// Token: 0x0400A400 RID: 41984
	[Nullable(2)]
	private IGetWayItemData ItemData;

	// Token: 0x02008CF7 RID: 36087
	private static class EChildType
	{
		// Token: 0x0402F6BB RID: 194235
		public const int BtnWay = 0;

		// Token: 0x0402F6BC RID: 194236
		public const int TxtWay = 1;
	}
}
