using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B48 RID: 11080
internal class RoleItemComponent : UiPanelBase
{
	// Token: 0x06016184 RID: 90500 RVA: 0x00621B08 File Offset: 0x0061FD08
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickRoleIcon))
		};
	}

	// Token: 0x06016185 RID: 90501 RVA: 0x00621BB4 File Offset: 0x0061FDB4
	private void OnClickRoleIcon()
	{
		SurvivorsRogueCharacterCard param = SurvivorsRogueCardDataFactory.CreateGeneralCharacter(this.CachedSurvivorRoleId);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsCardTips, param, null);
	}

	// Token: 0x06016186 RID: 90502 RVA: 0x00621BDE File Offset: 0x0061FDDE
	protected override void OnStart()
	{
	}

	// Token: 0x06016187 RID: 90503 RVA: 0x00621BE0 File Offset: 0x0061FDE0
	public void Refresh(int survivorRoleId)
	{
		this.CachedSurvivorRoleId = survivorRoleId;
		int trialRoleId = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(survivorRoleId).Value.TrialRoleId;
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(trialRoleId).Value;
		string roleHeadIconCircle = value.RoleHeadIconCircle;
		base.SetTextureShowUntilLoaded(roleHeadIconCircle, base.GetTexture(1), null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), value.Name, Array.Empty<object>());
	}

	// Token: 0x0400AA58 RID: 43608
	private int CachedSurvivorRoleId = -1;
}
