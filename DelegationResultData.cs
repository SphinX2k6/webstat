using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x020013D3 RID: 5075
[NullableContext(1)]
[Nullable(0)]
public class DelegationResultData
{
	// Token: 0x06008C3D RID: 35901 RVA: 0x0024E109 File Offset: 0x0024C309
	public DelegationResultData(int entrustId)
	{
		this.EntrustId = entrustId;
	}

	// Token: 0x06008C3E RID: 35902 RVA: 0x0024E144 File Offset: 0x0024C344
	public void SetRoleResultData(IReadOnlyList<RoleGood> resultList, IReadOnlyList<RoleProperSettle> dataList)
	{
		for (int i = 0; i < dataList.Count; i++)
		{
			RoleProperSettle roleProperSettle = dataList[i];
			List<int> list = new List<int>();
			list.Add(roleProperSettle.PropertyA);
			list.Add(roleProperSettle.PropertyB);
			list.Add(roleProperSettle.PropertyC);
			RoleResultData value = new RoleResultData
			{
				SuccessResult = RoleSettleResult.Normal,
				CharacterValueList = list
			};
			this.RoleResultDataMap[roleProperSettle.RoleId] = value;
		}
		for (int j = 0; j < resultList.Count; j++)
		{
			RoleGood roleGood = resultList[j];
			this.RoleResultDataMap[roleGood.RoleId].SuccessResult = roleGood.Result;
		}
	}

	// Token: 0x06008C3F RID: 35903 RVA: 0x0024E1F8 File Offset: 0x0024C3F8
	public void SaveInvestProperData(IReadOnlyList<RoleProperSettle> dataList)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < dataList.Count; i++)
		{
			RoleProperSettle roleProperSettle = dataList[i];
			num += roleProperSettle.PropertyA;
			num2 += roleProperSettle.PropertyB;
			num3 += roleProperSettle.PropertyC;
		}
		this.RoleInvestDataList.Add(num);
		this.RoleInvestDataList.Add(num2);
		this.RoleInvestDataList.Add(num3);
	}

	// Token: 0x06008C40 RID: 35904 RVA: 0x0024E268 File Offset: 0x0024C468
	public void UseInvestProperData()
	{
		this.ResultCharacterList[0].SetCurrentValue(this.RoleInvestDataList[0]);
		this.ResultCharacterList[1].SetCurrentValue(this.RoleInvestDataList[1]);
		this.ResultCharacterList[2].SetCurrentValue(this.RoleInvestDataList[2]);
	}

	// Token: 0x06008C41 RID: 35905 RVA: 0x0024E2CC File Offset: 0x0024C4CC
	public void SetRoleIdList(List<int> roleIdList)
	{
		this.RoleIdList = roleIdList;
	}

	// Token: 0x06008C42 RID: 35906 RVA: 0x0024E2D5 File Offset: 0x0024C4D5
	public List<int> GetRoleIdList()
	{
		return this.RoleIdList;
	}

	// Token: 0x06008C43 RID: 35907 RVA: 0x0024E2DD File Offset: 0x0024C4DD
	public IRoleResultData GetRoleResultDataById(int roleId)
	{
		return this.RoleResultDataMap[roleId];
	}

	// Token: 0x06008C44 RID: 35908 RVA: 0x0024E2EB File Offset: 0x0024C4EB
	public void SetResultCharacterList(List<CharacterData> dataList)
	{
		this.ResultCharacterList = dataList;
	}

	// Token: 0x06008C45 RID: 35909 RVA: 0x0024E2F4 File Offset: 0x0024C4F4
	public List<CharacterData> GetResultCharacterList()
	{
		return this.ResultCharacterList;
	}

	// Token: 0x06008C46 RID: 35910 RVA: 0x0024E2FC File Offset: 0x0024C4FC
	public void SetEvaluationLevel(int level)
	{
		if (this.EvaluationLevelInternal > level)
		{
			return;
		}
		this.EvaluationLevelInternal = level;
	}

	// Token: 0x17000BD9 RID: 3033
	// (get) Token: 0x06008C47 RID: 35911 RVA: 0x0024E30F File Offset: 0x0024C50F
	public int EvaluationLevel
	{
		get
		{
			return this.EvaluationLevelInternal;
		}
	}

	// Token: 0x06008C48 RID: 35912 RVA: 0x0024E318 File Offset: 0x0024C518
	public string GetRoleDialog()
	{
		EntrustFinishDialog valueOrDefault = ConfigEntrustFinishDialogByEntrustIdAndLevel.GetConfig(this.EntrustId, this.EvaluationLevelInternal, true).GetValueOrDefault();
		int num = ModelBase<MoonChasingModel>.Instance.GetPopularityValue() - this.LastPopularity;
		bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male;
		if (num > 0)
		{
			if (!flag)
			{
				return valueOrDefault.UpDialogGirl;
			}
			return valueOrDefault.UpDialog;
		}
		else
		{
			if (!flag)
			{
				return valueOrDefault.UnchangedDialogGirl;
			}
			return valueOrDefault.UnchangedDialog;
		}
	}

	// Token: 0x04004157 RID: 16727
	public bool IsTriggerEvent;

	// Token: 0x04004158 RID: 16728
	public int TriggerEventRoleId;

	// Token: 0x04004159 RID: 16729
	private int EvaluationLevelInternal;

	// Token: 0x0400415A RID: 16730
	public int Gold;

	// Token: 0x0400415B RID: 16731
	public int BaseGold;

	// Token: 0x0400415C RID: 16732
	public int CostGold;

	// Token: 0x0400415D RID: 16733
	public int OriginGold;

	// Token: 0x0400415E RID: 16734
	public int Wish;

	// Token: 0x0400415F RID: 16735
	public int BaseWish;

	// Token: 0x04004160 RID: 16736
	public int Ratio;

	// Token: 0x04004161 RID: 16737
	public bool IsInvestSuccess;

	// Token: 0x04004162 RID: 16738
	public bool IsBest;

	// Token: 0x04004163 RID: 16739
	private readonly Dictionary<int, IRoleResultData> RoleResultDataMap = new Dictionary<int, IRoleResultData>();

	// Token: 0x04004164 RID: 16740
	private readonly List<int> RoleInvestDataList = new List<int>();

	// Token: 0x04004165 RID: 16741
	private List<int> RoleIdList = new List<int>();

	// Token: 0x04004166 RID: 16742
	private List<CharacterData> ResultCharacterList = new List<CharacterData>();

	// Token: 0x04004167 RID: 16743
	public int LastPopularity;

	// Token: 0x04004168 RID: 16744
	public readonly int EntrustId;
}
