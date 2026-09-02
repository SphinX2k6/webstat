using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020014FF RID: 5375
public class RegressRewardPanelItem : GridProxyAbstract<RegressRewardTuple>
{
	// Token: 0x0600966E RID: 38510 RVA: 0x00275768 File Offset: 0x00273968
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600966F RID: 38511 RVA: 0x002757B0 File Offset: 0x002739B0
	protected override void OnStart()
	{
		AActor owner = base.GetItem(0).GetOwner();
		this.Grid = new CommonItemSmallItemGrid();
		this.Grid.Initialize(owner);
	}

	// Token: 0x06009670 RID: 38512 RVA: 0x002757E1 File Offset: 0x002739E1
	public override void Refresh(RegressRewardTuple data, bool isSelected, int gridIndex)
	{
		this.Grid.RefreshByConfigId(data.Id, new int?(data.Num), null, false, false);
		this.Grid.SetReceivedVisible(data.Received);
	}

	// Token: 0x06009671 RID: 38513 RVA: 0x00275813 File Offset: 0x00273A13
	protected override void OnBeforeDestroy()
	{
		this.Grid = null;
	}

	// Token: 0x040045AF RID: 17839
	[Nullable(2)]
	private CommonItemSmallItemGrid Grid;

	// Token: 0x020078C6 RID: 30918
	private class ERegressRewardPanelItem
	{
		// Token: 0x04029853 RID: 170067
		public const int ButtonItem = 0;
	}
}
