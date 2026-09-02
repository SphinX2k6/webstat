using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002C09 RID: 11273
public class TowerVariationShareTeamItem : GridProxyAbstract<int>
{
	// Token: 0x060167D0 RID: 92112 RVA: 0x00640320 File Offset: 0x0063E520
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060167D1 RID: 92113 RVA: 0x006403EC File Offset: 0x0063E5EC
	protected override void OnStart()
	{
		this.StarLayout = new GenericLayout<TowerStarsSimpleItem, bool>(base.GetHorizontalLayout(3), new Func<TowerStarsSimpleItem>(this.InitStarItem), null, false, true);
		this.RoleLayout = new GenericLayout<TowerRoleSimpleItem, RoleDataWithBranch>(base.GetHorizontalLayout(4), new Func<TowerRoleSimpleItem>(this.InitRoleItem), null, false, true);
		base.GetExtendToggle(0).ToggleState = EToggleState.ETT_UnDetermined;
	}

	// Token: 0x060167D2 RID: 92114 RVA: 0x00640448 File Offset: 0x0063E648
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.TowerId = data;
		TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(data);
		base.GetText(2).SetText(towerInfo.Value.Floor.ToString(), true);
		TowerFloorInfo floorData = ModelBase<TowerModel>.Instance.GetFloorData(this.TowerId);
		this.Star = ((floorData != null) ? floorData.Star : 0);
		List<bool> list = new List<bool>();
		for (int i = 1; i <= 3; i++)
		{
			list.Add(this.Star >= i);
		}
		this.StarLayout.RefreshByData(list, null, false);
		List<RoleDataWithBranch> list2 = new List<RoleDataWithBranch>();
		if (floorData == null)
		{
			goto IL_F3;
		}
		using (List<TowerRolePb>.Enumerator enumerator = floorData.Formation.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				TowerRolePb towerRolePb = enumerator.Current;
				list2.Add(new RoleDataWithBranch(towerRolePb.RoleId, towerRolePb.SkillBranchId));
			}
			goto IL_F3;
		}
		IL_E6:
		list2.Add(new RoleDataWithBranch(0, 0));
		IL_F3:
		if (list2.Count >= 3)
		{
			this.RoleLayout.RefreshByData(list2, null, false);
			base.GetItem(6).SetUIActive(floorData != null && floorData.IsQuickPass);
			return;
		}
		goto IL_E6;
	}

	// Token: 0x060167D3 RID: 92115 RVA: 0x00640588 File Offset: 0x0063E788
	[NullableContext(1)]
	private TowerStarsSimpleItem InitStarItem()
	{
		return new TowerStarsSimpleItem();
	}

	// Token: 0x060167D4 RID: 92116 RVA: 0x0064058F File Offset: 0x0063E78F
	[NullableContext(1)]
	private TowerRoleSimpleItem InitRoleItem()
	{
		return new TowerRoleSimpleItem();
	}

	// Token: 0x0400ADFD RID: 44541
	private int TowerId = -1;

	// Token: 0x0400ADFE RID: 44542
	private int Star = -1;

	// Token: 0x0400ADFF RID: 44543
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerStarsSimpleItem, bool> StarLayout;

	// Token: 0x0400AE00 RID: 44544
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<TowerRoleSimpleItem, RoleDataWithBranch> RoleLayout;

	// Token: 0x02008F07 RID: 36615
	private enum EChildType
	{
		// Token: 0x040300B4 RID: 196788
		FloorToggle,
		// Token: 0x040300B5 RID: 196789
		BgTexture,
		// Token: 0x040300B6 RID: 196790
		FloorNumberText,
		// Token: 0x040300B7 RID: 196791
		StarRootLayout,
		// Token: 0x040300B8 RID: 196792
		RoleRootLayout,
		// Token: 0x040300B9 RID: 196793
		PnlLevel,
		// Token: 0x040300BA RID: 196794
		QuickPassItem
	}
}
