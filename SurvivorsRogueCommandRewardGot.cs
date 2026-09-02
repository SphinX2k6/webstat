using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002AEE RID: 10990
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCommandRewardGot : SurvivorsRogueCommandBaseObtain
{
	// Token: 0x06015FA7 RID: 90023 RVA: 0x00619C2B File Offset: 0x00617E2B
	public SurvivorsRogueCommandRewardGot(ESurvivorsRogueCommandType type) : base(type)
	{
	}

	// Token: 0x06015FA8 RID: 90024 RVA: 0x00619C34 File Offset: 0x00617E34
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[RewardGot] Count: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.GetSurvivorsOption().GoodsDetails.Count);
		defaultInterpolatedStringHandler.AppendLiteral(" ");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06015FA9 RID: 90025 RVA: 0x00619C84 File Offset: 0x00617E84
	protected override void OnBindView()
	{
		if (base.ObtainViewProxy == null)
		{
			return;
		}
		bool selectOn = false;
		HashSet<int> hashSet = new HashSet<int>();
		foreach (GoodsDetail goodsDetail in this.GetSurvivorsOption().GoodsDetails)
		{
			Aki.Protocol.SurvivorsGainData survivorsGainData = goodsDetail.SurvivorsGainData;
			if (survivorsGainData != null)
			{
				string a = survivorsGainData.DataCase.ToString();
				if (!(a == "Proto_SurvivorsRoleLv"))
				{
					if (a == "Proto_SurvivorsWeaponLv")
					{
						int weaponId = survivorsGainData.SurvivorsWeaponLv.WeaponId;
						hashSet.Add(weaponId);
					}
				}
				else
				{
					selectOn = true;
				}
			}
		}
		SurvivorsRogueRoleStatePanel roleStatePanel = base.ObtainViewProxy.GetRoleStatePanel();
		if (roleStatePanel != null)
		{
			SurvivorsRogueRoleInfoGrid roleGrid = roleStatePanel.RoleGrid;
			if (roleGrid != null)
			{
				roleGrid.SetSelectOn(selectOn);
			}
		}
		foreach (int weaponId2 in hashSet)
		{
			SurvivorsRogueRoleStatePanel roleStatePanel2 = base.ObtainViewProxy.GetRoleStatePanel();
			if (roleStatePanel2 != null)
			{
				SurvivorsRogueWeaponStateGrid weaponGrid = roleStatePanel2.GetWeaponGrid(weaponId2);
				if (weaponGrid != null)
				{
					weaponGrid.SetSelectOn(true);
				}
			}
		}
	}

	// Token: 0x06015FAA RID: 90026 RVA: 0x00619DB8 File Offset: 0x00617FB8
	private SurvivorsOption GetSurvivorsOption()
	{
		return this.Data.TokenAwardView.SurvivorsOption;
	}

	// Token: 0x06015FAB RID: 90027 RVA: 0x00619DCC File Offset: 0x00617FCC
	[NullableContext(2)]
	public override ISurvivorsObtainViewInfo GetViewInfo()
	{
		SurvivorsOption survivorsOption = this.GetSurvivorsOption();
		return new SurvivorsObtainViewInfo
		{
			CaptionId = "SurvivorTreasure_ScreenName",
			TitleId = "SurvivorsTreasure_Title",
			ButtonId = "SurvivorsTreasure_ConfirtButton",
			ChooseData = base.GetChooseData(survivorsOption, null),
			GoodsList = survivorsOption.GoodsDetails
		};
	}
}
