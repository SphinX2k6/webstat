using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002024 RID: 8228
public class AccessPathPcButton : UiPanelBase
{
	// Token: 0x0600FA28 RID: 64040 RVA: 0x004483EF File Offset: 0x004465EF
	[NullableContext(1)]
	public AccessPathPcButton(UUIItem parentItem, int accessPathId)
	{
		this.AccessPathId = accessPathId;
		base.CreateThenShowByResourceIdAsync("UiItem_PcAccessPathButton_Prefab", parentItem, false).Forget();
	}

	// Token: 0x0600FA29 RID: 64041 RVA: 0x00448410 File Offset: 0x00446610
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600FA2A RID: 64042 RVA: 0x00448458 File Offset: 0x00446658
	protected override void OnStart()
	{
		AccessPath? accessPathConfig = ConfigBase<InventoryConfig>.Instance.GetAccessPathConfig(this.AccessPathId);
		if (accessPathConfig == null)
		{
			return;
		}
		UUIText text = base.GetText(0);
		string description = accessPathConfig.Value.Description;
		text.ShowTextNew(description);
	}

	// Token: 0x04007821 RID: 30753
	private readonly int AccessPathId;

	// Token: 0x020083CA RID: 33738
	private enum EChildComponentType
	{
		// Token: 0x0402CADB RID: 183003
		AccessPathText
	}
}
