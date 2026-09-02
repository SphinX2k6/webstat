using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002BF5 RID: 11253
[NullableContext(1)]
[Nullable(0)]
public class TowerFloorItem : GridProxyAbstract<int>
{
	// Token: 0x0601673E RID: 91966 RVA: 0x0063C6F0 File Offset: 0x0063A8F0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601673F RID: 91967 RVA: 0x0063C83C File Offset: 0x0063AA3C
	protected override void OnStart()
	{
		this.StarLayout = new GenericLayout<TowerStarsSimpleItem, bool>(base.GetHorizontalLayout(3), new Func<TowerStarsSimpleItem>(this.InitStarItem), null, false, true);
		this.RoleLayout = new GenericLayout<TowerRoleSimpleItem, RoleDataWithBranch>(base.GetHorizontalLayout(4), new Func<TowerRoleSimpleItem>(this.InitRoleItem), null, false, true);
		this.SetToggleState(EToggleState.ETT_UnChecked);
	}

	// Token: 0x06016740 RID: 91968 RVA: 0x0063C894 File Offset: 0x0063AA94
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.TowerId = data;
		this.IsLock = !ModelBase<TowerModel>.Instance.GetFloorIsUnlock(this.TowerId);
		TowerConfig value = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(data).Value;
		base.GetText(2).SetText(value.Floor.ToString(), true);
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
			goto IL_10C;
		}
		using (List<TowerRolePb>.Enumerator enumerator = floorData.Formation.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				TowerRolePb towerRolePb = enumerator.Current;
				list2.Add(new RoleDataWithBranch(towerRolePb.RoleId, towerRolePb.SkillBranchId));
			}
			goto IL_10C;
		}
		IL_FF:
		list2.Add(new RoleDataWithBranch(0, 0));
		IL_10C:
		if (list2.Count >= 3)
		{
			this.RoleLayout.RefreshByData(list2, null, false);
			base.SetTextureByPath(value.ItemBgPath, base.GetTexture(1), null, null);
			if (this.IsLock)
			{
				base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
			}
			else
			{
				base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			if (ModelBase<TowerModel>.Instance.DefaultFloor == data)
			{
				this.SetToggleState(EToggleState.ETT_Checked);
			}
			base.GetItem(6).SetUIActive(floorData != null && floorData.IsQuickPass);
			return;
		}
		goto IL_FF;
	}

	// Token: 0x06016741 RID: 91969 RVA: 0x0063CA4C File Offset: 0x0063AC4C
	public void BindOnClickToggle(Action<int, bool> onClickToggle)
	{
		this.OnClickToggleHandle = onClickToggle;
	}

	// Token: 0x06016742 RID: 91970 RVA: 0x0063CA55 File Offset: 0x0063AC55
	private void OnClickToggle(EToggleState state)
	{
		if (this.OnClickToggleHandle != null && state == EToggleState.ETT_Checked)
		{
			this.OnClickToggleHandle(this.TowerId, this.IsLock);
		}
	}

	// Token: 0x06016743 RID: 91971 RVA: 0x0063CA7A File Offset: 0x0063AC7A
	protected override void OnBeforeDestroy()
	{
		this.OnClickToggleHandle = null;
		this.StarLayout = null;
		this.RoleLayout = null;
	}

	// Token: 0x06016744 RID: 91972 RVA: 0x0063CA91 File Offset: 0x0063AC91
	private TowerStarsSimpleItem InitStarItem()
	{
		return new TowerStarsSimpleItem();
	}

	// Token: 0x06016745 RID: 91973 RVA: 0x0063CA98 File Offset: 0x0063AC98
	private TowerRoleSimpleItem InitRoleItem()
	{
		return new TowerRoleSimpleItem();
	}

	// Token: 0x06016746 RID: 91974 RVA: 0x0063CA9F File Offset: 0x0063AC9F
	public void SetToggleState(EToggleState state)
	{
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x0400ADD0 RID: 44496
	[Nullable(2)]
	private Action<int, bool> OnClickToggleHandle;

	// Token: 0x0400ADD1 RID: 44497
	private int TowerId = -1;

	// Token: 0x0400ADD2 RID: 44498
	private bool IsLock;

	// Token: 0x0400ADD3 RID: 44499
	private int Star = -1;

	// Token: 0x0400ADD4 RID: 44500
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerStarsSimpleItem, bool> StarLayout;

	// Token: 0x0400ADD5 RID: 44501
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<TowerRoleSimpleItem, RoleDataWithBranch> RoleLayout;

	// Token: 0x02008EEB RID: 36587
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0403001A RID: 196634
		FloorToggle,
		// Token: 0x0403001B RID: 196635
		BgTexture,
		// Token: 0x0403001C RID: 196636
		FloorNumberText,
		// Token: 0x0403001D RID: 196637
		StarRootLayout,
		// Token: 0x0403001E RID: 196638
		RoleRootLayout,
		// Token: 0x0403001F RID: 196639
		LockToggle,
		// Token: 0x04030020 RID: 196640
		QuickPassItem
	}
}
