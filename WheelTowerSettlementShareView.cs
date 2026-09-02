using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016FD RID: 5885
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerSettlementShareView : UiPanelBase
{
	// Token: 0x0600A30D RID: 41741 RVA: 0x002B0C44 File Offset: 0x002AEE44
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A30E RID: 41742 RVA: 0x002B0D74 File Offset: 0x002AEF74
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerSettlementShareView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerSettlementShareView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A30F RID: 41743 RVA: 0x002B0DB7 File Offset: 0x002AEFB7
	private WheelTowerSettlementRoleItem CreateRoleItem()
	{
		return new WheelTowerSettlementRoleItem();
	}

	// Token: 0x0600A310 RID: 41744 RVA: 0x002B0DC0 File Offset: 0x002AEFC0
	protected override void OnStart()
	{
		IWheelTowerSettlementViewData wheelTowerSettlementViewData = this.OpenParam as IWheelTowerSettlementViewData;
		ValueTuple<int, int> bossRoundAndWave = this.GetBossRoundAndWave(wheelTowerSettlementViewData.BossInfoList);
		int item = bossRoundAndWave.Item1;
		int num = bossRoundAndWave.Item2 % wheelTowerSettlementViewData.MaxBossWaveNum;
		int curBossWave = (num != 0) ? num : wheelTowerSettlementViewData.MaxBossWaveNum;
		EScoreLevel totalScoreLevel = ModelBase<WheelTowerModel>.Instance.GetTotalScoreLevel(wheelTowerSettlementViewData.TotalScore, null, null);
		WheelTowerModeSettlementTitleItem modeTitleItem = this.ModeTitleItem;
		if (modeTitleItem != null)
		{
			modeTitleItem.Refresh(wheelTowerSettlementViewData.EndlessMode);
		}
		WheelTowerSettlementRoundPanel roundPanel = this.RoundPanel;
		if (roundPanel != null)
		{
			roundPanel.RefreshRoundScore(wheelTowerSettlementViewData.CurrentScore);
		}
		WheelTowerSettlementScorePanel scorePanel = this.ScorePanel;
		if (scorePanel != null)
		{
			scorePanel.RefreshTotalScore(wheelTowerSettlementViewData.TotalScore);
		}
		WheelTowerSettlementScorePanel scorePanel2 = this.ScorePanel;
		if (scorePanel2 != null)
		{
			scorePanel2.RefreshScoreLevel((int)totalScoreLevel);
		}
		WheelTowerSettlementScorePanel scorePanel3 = this.ScorePanel;
		if (scorePanel3 != null)
		{
			scorePanel3.RefreshRoundWave(wheelTowerSettlementViewData.EndlessMode, item, curBossWave, wheelTowerSettlementViewData.MaxBossWaveNum);
		}
		WheelTowerSettlementBossResultPanel bossResultPanel = this.BossResultPanel;
		if (bossResultPanel != null)
		{
			bossResultPanel.Refresh(wheelTowerSettlementViewData.BossInfoList);
		}
		GenericLayout<WheelTowerSettlementRoleItem, RoleDataWithBranch> roleLayout = this.RoleLayout;
		if (roleLayout != null)
		{
			roleLayout.RefreshByData(wheelTowerSettlementViewData.RoleList, null, false);
		}
		base.SetTextureByPath(ConfigGaChaShareById.GetConfig(wheelTowerSettlementViewData.RoleList[0].RoleId, true).Value.SharePic, base.GetTexture(7), null, null);
		WheelTowerSettlementBossResultPanel bossResultPanel2 = this.BossResultPanel;
		if (bossResultPanel2 == null)
		{
			return;
		}
		bossResultPanel2.SetBossScrollEnable(false);
	}

	// Token: 0x0600A311 RID: 41745 RVA: 0x002B0F28 File Offset: 0x002AF128
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"bossRound",
		"product"
	})]
	private ValueTuple<int, int> GetBossRoundAndWave([Nullable(1)] List<IBossItemData> bossInfoList)
	{
		int num = 1;
		int item = 0;
		foreach (IBossItemData bossItemData in bossInfoList)
		{
			if (bossItemData.BossInfo.Round > num)
			{
				num = bossItemData.BossInfo.Round;
			}
			item = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(bossItemData.BossInfo.WaveConfigId).Value.Wave;
		}
		return new ValueTuple<int, int>(num, item);
	}

	// Token: 0x04004D81 RID: 19841
	private WheelTowerModeSettlementTitleItem ModeTitleItem;

	// Token: 0x04004D82 RID: 19842
	private WheelTowerSettlementRoundPanel RoundPanel;

	// Token: 0x04004D83 RID: 19843
	private WheelTowerSettlementScorePanel ScorePanel;

	// Token: 0x04004D84 RID: 19844
	private WheelTowerSettlementBossResultPanel BossResultPanel;

	// Token: 0x04004D85 RID: 19845
	private GenericLayout<WheelTowerSettlementRoleItem, RoleDataWithBranch> RoleLayout;

	// Token: 0x02007A49 RID: 31305
	[NullableContext(0)]
	private enum EComp
	{
		// Token: 0x04029ED9 RID: 171737
		BgModeTitle,
		// Token: 0x04029EDA RID: 171738
		BgRoundPoints,
		// Token: 0x04029EDB RID: 171739
		BgScore,
		// Token: 0x04029EDC RID: 171740
		BgBattleBoss,
		// Token: 0x04029EDD RID: 171741
		RoleLayout,
		// Token: 0x04029EDE RID: 171742
		RoleItem,
		// Token: 0x04029EDF RID: 171743
		SeasonTexture,
		// Token: 0x04029EE0 RID: 171744
		CharacterBg
	}
}
