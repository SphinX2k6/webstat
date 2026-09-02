using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x02002AE8 RID: 10984
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCommandEvolve : SurvivorsRogueCommandBase
{
	// Token: 0x06015F71 RID: 89969 RVA: 0x0061913B File Offset: 0x0061733B
	public SurvivorsRogueCommandEvolve(ESurvivorsRogueCommandType type) : base(type)
	{
	}

	// Token: 0x06015F72 RID: 89970 RVA: 0x00619144 File Offset: 0x00617344
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[Evolve] Count: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.GetEvolveData().Count);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06015F73 RID: 89971 RVA: 0x00619180 File Offset: 0x00617380
	protected override void OnStartExecute()
	{
		base.OpenView(EUiViewName.SurvivorsRogueEvolveView, true);
	}

	// Token: 0x06015F74 RID: 89972 RVA: 0x0061918E File Offset: 0x0061738E
	private IList<Aki.Protocol.SurvivorsGainData> GetEvolveData()
	{
		return this.Data.EvolveView.SurvivorsGainDatas;
	}

	// Token: 0x06015F75 RID: 89973 RVA: 0x006191A0 File Offset: 0x006173A0
	protected override void OnUpdate()
	{
	}

	// Token: 0x06015F76 RID: 89974 RVA: 0x006191A2 File Offset: 0x006173A2
	protected override void Back2Fore()
	{
	}

	// Token: 0x06015F77 RID: 89975 RVA: 0x006191A4 File Offset: 0x006173A4
	protected override void Fore2Back()
	{
	}

	// Token: 0x06015F78 RID: 89976 RVA: 0x006191A6 File Offset: 0x006173A6
	protected override void OnExecute()
	{
	}

	// Token: 0x06015F79 RID: 89977 RVA: 0x006191A8 File Offset: 0x006173A8
	protected override void OnFinish()
	{
		base.RequestCommand(new int[1], null);
	}

	// Token: 0x06015F7A RID: 89978 RVA: 0x006191B7 File Offset: 0x006173B7
	protected override void OnDelete()
	{
	}

	// Token: 0x06015F7B RID: 89979 RVA: 0x006191BC File Offset: 0x006173BC
	public List<SurvivorsEvolveViewInfo> GetViewInfoList()
	{
		List<SurvivorsEvolveViewInfo> list = new List<SurvivorsEvolveViewInfo>();
		IEnumerable<Aki.Protocol.SurvivorsGainData> evolveData = this.GetEvolveData();
		Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
		foreach (Aki.Protocol.SurvivorsGainData survivorsGainData in evolveData)
		{
			SurvivorsEvolveViewInfo survivorsEvolveViewInfo = null;
			string a2 = survivorsGainData.DataCase.ToString();
			if (!(a2 == "Proto_SurvivorsRoleEvolve"))
			{
				if (a2 == "Proto_SurvivorsWeaponEvolve")
				{
					SurvivorsWeaponEvolve survivorsWeaponEvolve = survivorsGainData.SurvivorsWeaponEvolve;
					bool flag = survivorsWeaponEvolve.WeaponBondId > 0;
					survivorsEvolveViewInfo = new SurvivorsEvolveViewInfo
					{
						SourceType = ESurvivorsRogueItemType.Weapon,
						SourceId = survivorsWeaponEvolve.WeaponId,
						TitleId = (flag ? "SurvivorsWeaponEvolution_SuperTitle" : "SurvivorsWeaponEvolution_Title"),
						EvolveId = survivorsGainData.ConfigId,
						BondType = new ESurvivorsRogueItemType?(ESurvivorsRogueItemType.Weapon),
						BondId = new int?(survivorsWeaponEvolve.WeaponBondId)
					};
					List<int> list2;
					if (!dictionary.TryGetValue(survivorsWeaponEvolve.WeaponId, out list2))
					{
						list2 = new List<int>();
						dictionary[survivorsWeaponEvolve.WeaponId] = list2;
					}
					list2.Add(survivorsGainData.ConfigId);
				}
			}
			else
			{
				SurvivorsRoleEvolve survivorsRoleEvolve = survivorsGainData.SurvivorsRoleEvolve;
				survivorsEvolveViewInfo = new SurvivorsEvolveViewInfo
				{
					SourceType = ESurvivorsRogueItemType.Character,
					SourceId = survivorsRoleEvolve.RoleId,
					TitleId = "SurvivorsRoleEvolution_Title",
					EvolveId = survivorsGainData.ConfigId
				};
			}
			if (survivorsEvolveViewInfo != null)
			{
				list.Add(survivorsEvolveViewInfo);
			}
		}
		list.Sort(delegate(SurvivorsEvolveViewInfo a, SurvivorsEvolveViewInfo b)
		{
			if (a.SourceType != b.SourceType)
			{
				return b.SourceType - a.SourceType;
			}
			if (a.SourceId != b.SourceId)
			{
				return a.SourceId - b.SourceId;
			}
			return a.EvolveId - b.EvolveId;
		});
		for (int i = 0; i < list.Count; i++)
		{
			SurvivorsEvolveViewInfo survivorsEvolveViewInfo2 = list[i];
			SurvivorsEvolveViewInfo survivorsEvolveViewInfo3 = (i + 1 < list.Count) ? list[i + 1] : null;
			if (survivorsEvolveViewInfo2.SourceType == ESurvivorsRogueItemType.Weapon)
			{
				if (i != list.Count - 1)
				{
					int sourceId = survivorsEvolveViewInfo2.SourceId;
					int? num = (survivorsEvolveViewInfo3 != null) ? new int?(survivorsEvolveViewInfo3.SourceId) : null;
					if (sourceId == num.GetValueOrDefault() & num != null)
					{
						goto IL_233;
					}
				}
				List<int> list3;
				survivorsEvolveViewInfo2.WeaponEvolveIds = (dictionary.TryGetValue(survivorsEvolveViewInfo2.SourceId, out list3) ? list3.ToArray() : null);
				survivorsEvolveViewInfo2.PlayTween = new bool?(true);
			}
			IL_233:;
		}
		return list;
	}
}
