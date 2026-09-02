using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200165A RID: 5722
public class WheelTowerRecordTeamInfoPanel : UiPanelBase
{
	// Token: 0x0600A072 RID: 41074 RVA: 0x002A01F0 File Offset: 0x0029E3F0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A073 RID: 41075 RVA: 0x002A025C File Offset: 0x0029E45C
	protected override void OnStart()
	{
		this.RoleLayout = new GenericLayout<WheelTowerRecordRoleGridItem, RoleDataWithBranch>(base.GetHorizontalLayout(0), new Func<WheelTowerRecordRoleGridItem>(this.CreateRoleItem), null, false, true);
		this.BuffLayout = new GenericLayout<WheelTowerBuffGridItem, int>(base.GetHorizontalLayout(2), () => new WheelTowerBuffGridItem(), null, false, true);
	}

	// Token: 0x0600A074 RID: 41076 RVA: 0x002A02C0 File Offset: 0x0029E4C0
	public void Refresh()
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		NewTowerClimbingLevelRecord currentLevelRecord = instance.GetCurrentLevelRecord(null);
		int selectedRound = instance.SelectedRound;
		List<RoleDataWithBranch> list = new List<RoleDataWithBranch>();
		foreach (RoleSaveInfo roleSaveInfo in currentLevelRecord.TeamChallengeInfos[selectedRound].RoleSaveInfos)
		{
			list.Add(new RoleDataWithBranch(roleSaveInfo.RoleId, roleSaveInfo.SkillBranchId));
		}
		GenericLayout<WheelTowerRecordRoleGridItem, RoleDataWithBranch> roleLayout = this.RoleLayout;
		if (roleLayout != null)
		{
			roleLayout.RefreshByData(list, null, false);
		}
		GenericLayout<WheelTowerBuffGridItem, int> buffLayout = this.BuffLayout;
		if (buffLayout == null)
		{
			return;
		}
		buffLayout.RefreshByData(instance.GetRoundSelectBuffList(instance.SelectedRound), null, false);
	}

	// Token: 0x0600A075 RID: 41077 RVA: 0x002A0384 File Offset: 0x0029E584
	[NullableContext(1)]
	private WheelTowerRecordRoleGridItem CreateRoleItem()
	{
		return new WheelTowerRecordRoleGridItem();
	}

	// Token: 0x04004A10 RID: 18960
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerRecordRoleGridItem, RoleDataWithBranch> RoleLayout;

	// Token: 0x04004A11 RID: 18961
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<WheelTowerBuffGridItem, int> BuffLayout;
}
