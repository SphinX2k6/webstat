using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B6D RID: 11117
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueRoleInfoGrid : UiPanelBase
{
	// Token: 0x0601625C RID: 90716 RVA: 0x00625458 File Offset: 0x00623658
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnRoleClick))
		};
	}

	// Token: 0x0601625D RID: 90717 RVA: 0x006254EC File Offset: 0x006236EC
	private void OnBtnRoleClick()
	{
		SurvivorsTabMainViewData param = new SurvivorsTabMainViewData
		{
			SkipTabType = new ETabType?(ETabType.Role)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsTabMainView, param, null);
	}

	// Token: 0x0601625E RID: 90718 RVA: 0x0062551C File Offset: 0x0062371C
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.SetSelectOn(false);
	}

	// Token: 0x0601625F RID: 90719 RVA: 0x00625538 File Offset: 0x00623738
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
		base.SetRoleIcon(roleInfo.Value.RoleHeadIconCircle, base.GetTexture(1), roleId, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "SurvivorsCombat_Lv", new <>z__ReadOnlySingleElementList<object>(lv));
		base.GetText(3).SetUIActive(true);
	}

	// Token: 0x06016260 RID: 90720 RVA: 0x006255F0 File Offset: 0x006237F0
	public void SetSelectOn(bool bUp)
	{
		base.GetItem(2).SetUIActive(bUp);
		if (bUp)
		{
			this.LevelSequencePlayer.PlayOrReplaySequenceByName("PreArm", false, null);
			return;
		}
		this.LevelSequencePlayer.StopSequenceByKey("PreArm", false, true);
	}

	// Token: 0x06016261 RID: 90721 RVA: 0x0062563C File Offset: 0x0062383C
	public void SetLevelUp()
	{
		this.LevelSequencePlayer.StopSequenceByKey("PreArm", false, true);
		this.LevelSequencePlayer.PlayOrReplaySequenceByName("LevelUp", false, null);
	}

	// Token: 0x0400AB2F RID: 43823
	private const string SURVIVORS_LV_KEY = "SurvivorsCombat_Lv";

	// Token: 0x0400AB30 RID: 43824
	private const string SEQ_PRE_SELECT = "PreArm";

	// Token: 0x0400AB31 RID: 43825
	private const string SEQ_LEVEL_UP = "LevelUp";

	// Token: 0x0400AB32 RID: 43826
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;
}
