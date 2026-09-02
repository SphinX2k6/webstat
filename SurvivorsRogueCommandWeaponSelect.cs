using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002AF3 RID: 10995
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCommandWeaponSelect : SurvivorsRogueCommandBaseObtain
{
	// Token: 0x06015FC6 RID: 90054 RVA: 0x0061A0EF File Offset: 0x006182EF
	public SurvivorsRogueCommandWeaponSelect(ESurvivorsRogueCommandType type) : base(type)
	{
	}

	// Token: 0x06015FC7 RID: 90055 RVA: 0x0061A0F8 File Offset: 0x006182F8
	protected override void OnUpdate()
	{
		this.CurrentUnlockWeaponIndex = ModelBase<SurvivorsRogueModel>.Instance.GainData.WeaponGainMap.Count;
	}

	// Token: 0x06015FC8 RID: 90056 RVA: 0x0061A114 File Offset: 0x00618314
	protected override void OnBindView()
	{
		if (base.ObtainViewProxy != null)
		{
			base.ObtainViewProxy.OnGoodsSelected = new Action<int, bool>(this.OnGoodsSelected);
			base.ObtainViewProxy.OnSeqStartFinished = new Action(this.OnSeqStartFinished);
		}
	}

	// Token: 0x06015FC9 RID: 90057 RVA: 0x0061A14C File Offset: 0x0061834C
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[WeaponSelect] Count: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.GetSurvivorsOption().GoodsDetails.Count);
		defaultInterpolatedStringHandler.AppendLiteral(" ");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06015FCA RID: 90058 RVA: 0x0061A199 File Offset: 0x00618399
	private SurvivorsOption GetSurvivorsOption()
	{
		return this.Data.WeaponSelectView.SurvivorsOption;
	}

	// Token: 0x06015FCB RID: 90059 RVA: 0x0061A1AB File Offset: 0x006183AB
	private void OnSeqStartFinished()
	{
		SurvivorsRogueGeneralObtainView obtainViewProxy = base.ObtainViewProxy;
		if (obtainViewProxy == null)
		{
			return;
		}
		SurvivorsRogueRoleStatePanel roleStatePanel = obtainViewProxy.GetRoleStatePanel();
		if (roleStatePanel == null)
		{
			return;
		}
		SurvivorsRogueWeaponStateGrid weaponGridByIndex = roleStatePanel.GetWeaponGridByIndex(this.CurrentUnlockWeaponIndex);
		if (weaponGridByIndex == null)
		{
			return;
		}
		weaponGridByIndex.SetSingleAnim(ESurvivorsSequenceName.Unlock.ToString());
	}

	// Token: 0x06015FCC RID: 90060 RVA: 0x0061A1E8 File Offset: 0x006183E8
	private void OnGoodsSelected(int incId, bool bSelected)
	{
		if (!bSelected || base.ObtainViewProxy == null)
		{
			return;
		}
		SurvivorsRogueRoleStatePanel roleStatePanel = base.ObtainViewProxy.GetRoleStatePanel();
		GoodsDetail goodsDetail = this.GetSurvivorsOption().GoodsDetails.FirstOrDefault(delegate(GoodsDetail item)
		{
			Aki.Protocol.SurvivorsGainData survivorsGainData = item.SurvivorsGainData;
			return survivorsGainData != null && survivorsGainData.IncId == incId;
		});
		if (goodsDetail == null)
		{
			return;
		}
		SurvivorsRogueWeaponStateGrid weaponGridByIndex = roleStatePanel.GetWeaponGridByIndex(this.CurrentUnlockWeaponIndex);
		if (weaponGridByIndex == null)
		{
			return;
		}
		int configId = goodsDetail.SurvivorsGainData.ConfigId;
		goodsDetail.SurvivorsGainData.SurvivorsWeapon.Evolves.Add(ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeaponDefaultEvolve(configId).Value.Id);
		SurvivorsWeaponGainData weaponData = new SurvivorsWeaponGainData(goodsDetail.SurvivorsGainData.IncId, configId, goodsDetail.SurvivorsGainData.SurvivorsWeapon, ESurvivorsRogueItemType.Weapon);
		SurvivorsWeaponGridData data = new SurvivorsWeaponGridData
		{
			WeaponData = weaponData,
			IsLock = false,
			IsDisable = false
		};
		weaponGridByIndex.Refresh(data, false, this.CurrentUnlockWeaponIndex);
		weaponGridByIndex.SetSingleAnim(ESurvivorsSequenceName.PreSelect.ToString());
		foreach (SurvivorsWeaponGainData survivorsWeaponGainData in ModelBase<SurvivorsRogueModel>.Instance.GainData.WeaponGainMap.Values)
		{
			if (survivorsWeaponGainData.Data.WeaponBondId == 0)
			{
				SurvivorsRogueWeaponStateGrid weaponGrid = roleStatePanel.GetWeaponGrid(survivorsWeaponGainData.ConfigId);
				if (weaponGrid != null)
				{
					weaponGrid.SetDisConnected();
				}
			}
		}
		int weaponBondOwnedWeaponId = ModelBase<SurvivorsRogueModel>.Instance.GainData.GetWeaponBondOwnedWeaponId(configId);
		if (weaponBondOwnedWeaponId != 0)
		{
			SurvivorsRogueWeaponStateGrid weaponGrid2 = roleStatePanel.GetWeaponGrid(weaponBondOwnedWeaponId);
			int gridIndex = weaponGrid2.GridIndex;
			int distance = Math.Abs(this.CurrentUnlockWeaponIndex - gridIndex) - 1;
			weaponGrid2.SetConnected(false, distance);
			weaponGridByIndex.SetConnected(true, distance);
		}
	}

	// Token: 0x06015FCD RID: 90061 RVA: 0x0061A3B0 File Offset: 0x006185B0
	[NullableContext(2)]
	public override ISurvivorsObtainViewInfo GetViewInfo()
	{
		SurvivorsOption survivorsOption = this.GetSurvivorsOption();
		return new SurvivorsObtainViewInfo
		{
			CaptionId = "SurvivorWeaponSelection_ScreenName",
			TitleId = "SurvivorsNewWeapon_Title",
			ButtonId = "SurvivorsNewWeapon_ConfirtButton",
			ChooseData = base.GetChooseData(survivorsOption, new ESurvivorsObtainMode?(ESurvivorsObtainMode.SingleSelect)),
			GoodsList = survivorsOption.GoodsDetails
		};
	}

	// Token: 0x0400A8D9 RID: 43225
	private int CurrentUnlockWeaponIndex;
}
