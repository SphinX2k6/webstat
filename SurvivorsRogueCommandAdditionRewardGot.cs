using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002ADF RID: 10975
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCommandAdditionRewardGot : SurvivorsRogueCommandBaseObtain
{
	// Token: 0x06015F33 RID: 89907 RVA: 0x00618B70 File Offset: 0x00616D70
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[AdditionRewardGot] Count: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.GetSurvivorsOption().GoodsDetails.Count);
		defaultInterpolatedStringHandler.AppendLiteral(" ");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06015F34 RID: 89908 RVA: 0x00618BBD File Offset: 0x00616DBD
	public SurvivorsRogueCommandAdditionRewardGot(ESurvivorsRogueCommandType type) : base(type)
	{
	}

	// Token: 0x06015F35 RID: 89909 RVA: 0x00618BC8 File Offset: 0x00616DC8
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

	// Token: 0x06015F36 RID: 89910 RVA: 0x00618CFC File Offset: 0x00616EFC
	private SurvivorsOption GetSurvivorsOption()
	{
		return this.Data.RoleOrWeaponUpView.SurvivorsOption;
	}

	// Token: 0x06015F37 RID: 89911 RVA: 0x00618D10 File Offset: 0x00616F10
	[NullableContext(2)]
	public override ISurvivorsObtainViewInfo GetViewInfo()
	{
		SurvivorsOption survivorsOption = this.GetSurvivorsOption();
		return new SurvivorsObtainViewInfo
		{
			CaptionId = "SurvivorPropObtain_ScreenName",
			TitleId = "SurvivorsItemAcquireAdditionallyTitle",
			ButtonId = "SurvivorsTreasure_ConfirtButton",
			ChooseData = base.GetChooseData(survivorsOption, null),
			GoodsList = survivorsOption.GoodsDetails
		};
	}
}
