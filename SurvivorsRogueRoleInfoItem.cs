using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B6F RID: 11119
public class SurvivorsRogueRoleInfoItem : UiPanelBase
{
	// Token: 0x06016263 RID: 90723 RVA: 0x00625680 File Offset: 0x00623880
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06016264 RID: 90724 RVA: 0x006256DA File Offset: 0x006238DA
	protected override void OnStart()
	{
	}

	// Token: 0x06016265 RID: 90725 RVA: 0x006256DC File Offset: 0x006238DC
	public void Refresh(int roleId, int lv)
	{
		SurvivorsRole? survivorsRole = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(roleId);
		if (survivorsRole == null)
		{
			return;
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(survivorsRole.Value.TrialRoleId, true);
		RoleInfo? roleInfo = (roleDataById != null) ? new RoleInfo?(roleDataById.GetRoleConfig()) : null;
		if (roleInfo == null)
		{
			return;
		}
		base.SetTextureShowUntilLoaded(roleInfo.Value.FormationRoleCard, base.GetTexture(0), null);
		base.GetText(1).SetText(roleDataById.GetName(null), true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "SurvivorsCombat_Lv", new <>z__ReadOnlySingleElementList<object>(lv));
		base.GetText(2).SetUIActive(true);
	}
}
