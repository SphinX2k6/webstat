using System;
using System.Collections.Generic;
using Aki.Protocol;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020025E0 RID: 9696
public class PhotographTab : UiPanelBase
{
	// Token: 0x06012F7C RID: 77692 RVA: 0x0053EF07 File Offset: 0x0053D107
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06012F7D RID: 77693 RVA: 0x0053EF2A File Offset: 0x0053D12A
	protected override void OnBeforeShow()
	{
		this.RefreshRedDot();
	}

	// Token: 0x06012F7E RID: 77694 RVA: 0x0053EF34 File Offset: 0x0053D134
	public void RefreshRedDot()
	{
		ServerStorageBoolean serverStorageBoolean = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FilterRedPoint) as ServerStorageBoolean;
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(serverStorageBoolean.Get().GetValueOrDefault(true));
	}

	// Token: 0x02008954 RID: 35156
	private enum EChildType
	{
		// Token: 0x0402E569 RID: 189801
		RedDot = 1
	}
}
