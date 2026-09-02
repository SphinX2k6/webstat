using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020016BB RID: 5819
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerShareTeamItem : GridProxyAbstract<TeamChallengeInfo>
{
	// Token: 0x0600A1B9 RID: 41401 RVA: 0x002A86D0 File Offset: 0x002A68D0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
	}

	// Token: 0x0600A1BA RID: 41402 RVA: 0x002A8756 File Offset: 0x002A6956
	protected override void OnStart()
	{
		this.RoleIconLayout = new GenericLayout<WheelTowerRoleItem, RoleDataWithBranch>(base.GetHorizontalLayout(1), new Func<WheelTowerRoleItem>(this.CreateRoleItem), null, false, true);
	}

	// Token: 0x0600A1BB RID: 41403 RVA: 0x002A877C File Offset: 0x002A697C
	public override void Refresh(TeamChallengeInfo data, bool isSelected, int gridIndex)
	{
		string icon = ConfigBase<WheelTowerConfig>.Instance.GetBuffConfigById(data.BuffIds[0]).Value.Icon;
		base.SetTextureByPath(icon, base.GetTexture(3), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "Share_NewTowerTotal_1004", new <>z__ReadOnlySingleElementList<object>(data.TeamScore));
		List<RoleDataWithBranch> list = (from info in data.RoleSaveInfos
		select new RoleDataWithBranch(info.RoleId, info.SkillBranchId)).ToList<RoleDataWithBranch>();
		int teamMaxRoleCount = ModelBase<WheelTowerModel>.Instance.GetTeamMaxRoleCount();
		while (list.Count < teamMaxRoleCount)
		{
			list.Add(new RoleDataWithBranch(0, 0));
		}
		GenericLayout<WheelTowerRoleItem, RoleDataWithBranch> roleIconLayout = this.RoleIconLayout;
		if (roleIconLayout == null)
		{
			return;
		}
		roleIconLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0600A1BC RID: 41404 RVA: 0x002A8856 File Offset: 0x002A6A56
	private WheelTowerRoleItem CreateRoleItem()
	{
		return new WheelTowerRoleItem
		{
			IsOnlyShowIcon = true,
			CanClick = false
		};
	}

	// Token: 0x04004BAF RID: 19375
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerRoleItem, RoleDataWithBranch> RoleIconLayout;

	// Token: 0x02007A0F RID: 31247
	[NullableContext(0)]
	private enum EComp
	{
		// Token: 0x04029E1A RID: 171546
		PnlItem,
		// Token: 0x04029E1B RID: 171547
		LayoutRole,
		// Token: 0x04029E1C RID: 171548
		ItemRole,
		// Token: 0x04029E1D RID: 171549
		TextureSkillIcon,
		// Token: 0x04029E1E RID: 171550
		SkillEmpty,
		// Token: 0x04029E1F RID: 171551
		TextScore
	}
}
