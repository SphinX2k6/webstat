using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002BFD RID: 11261
public class TowerResetItem : GridProxyAbstract<int>
{
	// Token: 0x0601678F RID: 92047 RVA: 0x0063EF60 File Offset: 0x0063D160
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06016790 RID: 92048 RVA: 0x0063EFEC File Offset: 0x0063D1EC
	protected override void OnStart()
	{
		this.CurrentCostItem = new TowerCostItem();
		this.CurrentCostItem.CreateThenShowByActorAsync(base.GetItem(1).GetOwner(), null, false);
		this.ChangeToCostItem = new TowerCostItem();
		this.ChangeToCostItem.CreateThenShowByActorAsync(base.GetItem(2).GetOwner(), null, false);
	}

	// Token: 0x06016791 RID: 92049 RVA: 0x0063F044 File Offset: 0x0063D244
	public override void Refresh(int roleId, bool isSelected, int gridIndex)
	{
		base.SetRoleIcon(ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.RoleHeadIcon, base.GetTexture(0), roleId, null, null);
		TowerFloorInfo floorData = ModelBase<TowerModel>.Instance.GetFloorData(ModelBase<TowerModel>.Instance.CurrentSelectFloor);
		int roleRemainCost = ModelBase<TowerModel>.Instance.GetRoleRemainCost(roleId, floorData.Difficulties);
		this.CurrentCostItem.Update(roleRemainCost);
		this.ChangeToCostItem.Update(roleRemainCost + floorData.Cost);
	}

	// Token: 0x0400ADF0 RID: 44528
	[Nullable(2)]
	private TowerCostItem CurrentCostItem;

	// Token: 0x0400ADF1 RID: 44529
	[Nullable(2)]
	private TowerCostItem ChangeToCostItem;

	// Token: 0x02008EF7 RID: 36599
	private enum EChildType
	{
		// Token: 0x04030079 RID: 196729
		RoleTexture,
		// Token: 0x0403007A RID: 196730
		CurrentCostItem,
		// Token: 0x0403007B RID: 196731
		ChangeToCostItem
	}
}
