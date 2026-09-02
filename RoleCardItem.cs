using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B09 RID: 11017
public class RoleCardItem : UiPanelBase
{
	// Token: 0x0601604F RID: 90191 RVA: 0x0061C090 File Offset: 0x0061A290
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06016050 RID: 90192 RVA: 0x0061C0EC File Offset: 0x0061A2EC
	public void RefreshBySurvivorRoleId(int survivorRoleId)
	{
		int trialRoleId = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(survivorRoleId).Value.TrialRoleId;
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(trialRoleId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), roleConfig.Value.Name ?? "", Array.Empty<object>());
		base.SetTextureShowUntilLoaded(roleConfig.Value.FormationRoleCard, base.GetTexture(0), null);
	}

	// Token: 0x06016051 RID: 90193 RVA: 0x0061C16E File Offset: 0x0061A36E
	public void SetLevel(int level)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "SurvivorsCombat_Lv", new <>z__ReadOnlySingleElementList<object>(level));
	}

	// Token: 0x02008E55 RID: 36437
	private static class ERoleCard
	{
		// Token: 0x0402FDEA RID: 196074
		public const int TexIcon = 0;

		// Token: 0x0402FDEB RID: 196075
		public const int TxtName = 1;

		// Token: 0x0402FDEC RID: 196076
		public const int TxtLv = 2;
	}
}
