using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002795 RID: 10133
[NullableContext(1)]
[Nullable(0)]
public class MultiTeamRoleSelectData
{
	// Token: 0x06013FEA RID: 81898 RVA: 0x0059239C File Offset: 0x0059059C
	public List<RoleDataBase> GetSourceRoleList()
	{
		List<RoleDataBase> list = new List<RoleDataBase>();
		foreach (MultiTeamRoleData multiTeamRoleData in this.MultiTeamRoleDataList)
		{
			list.AddRange(multiTeamRoleData.GetSourceRoleList());
		}
		return list;
	}

	// Token: 0x06013FEB RID: 81899 RVA: 0x005923FC File Offset: 0x005905FC
	public List<MultiTeamRoleData> GetMultiTeamRoleDataList()
	{
		return this.MultiTeamRoleDataList;
	}

	// Token: 0x06013FEC RID: 81900 RVA: 0x00592404 File Offset: 0x00590604
	public static MultiTeamRoleSelectData Phrase(EFilterSortGroupId? useWay, int teamLength, int[] initSelectRoleList, [Nullable(2)] Action backCallBack, [Nullable(new byte[]
	{
		2,
		1
	})] Func<int[], bool> canConfirmFunc, [Nullable(new byte[]
	{
		2,
		1,
		1
	})] Action<int[], int[]> confirmCallBack, [Nullable(2)] Func<int, bool> isNeedRevive, List<MultiTeamRoleData> multiTeamRoleDataList, [Nullable(2)] int[] unRecommendRole = null, string tips = "")
	{
		MultiTeamRoleSelectData multiTeamRoleSelectData = new MultiTeamRoleSelectData();
		multiTeamRoleSelectData.UseWay = useWay;
		multiTeamRoleSelectData.TeamLength = teamLength;
		multiTeamRoleSelectData.InitSelectRoleList.AddRange(initSelectRoleList);
		multiTeamRoleSelectData.BackCallBack = backCallBack;
		multiTeamRoleSelectData.CanConfirmFunc = canConfirmFunc;
		multiTeamRoleSelectData.ConfirmCallBack = confirmCallBack;
		multiTeamRoleSelectData.IsNeedRevive = isNeedRevive;
		multiTeamRoleSelectData.MultiTeamRoleDataList.AddRange(multiTeamRoleDataList);
		if (unRecommendRole != null)
		{
			multiTeamRoleSelectData.UnRecommendRole.AddRange(unRecommendRole);
		}
		multiTeamRoleSelectData.Tips = tips;
		return multiTeamRoleSelectData;
	}

	// Token: 0x06013FED RID: 81901 RVA: 0x00592477 File Offset: 0x00590677
	public void SetMultiTeamTagData(MultiTeamTagDataItem data)
	{
		this.MultiTeamTagData = data;
		this.NeedShowTag = true;
	}

	// Token: 0x04009BB1 RID: 39857
	public EFilterSortGroupId? UseWay;

	// Token: 0x04009BB2 RID: 39858
	[Nullable(2)]
	public Action BackCallBack;

	// Token: 0x04009BB3 RID: 39859
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<int[], bool> CanConfirmFunc;

	// Token: 0x04009BB4 RID: 39860
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<int[], int[]> ConfirmCallBack;

	// Token: 0x04009BB5 RID: 39861
	[Nullable(2)]
	public Func<int, bool> IsNeedRevive;

	// Token: 0x04009BB6 RID: 39862
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<int, int[], bool> IfCanSelectCheck;

	// Token: 0x04009BB7 RID: 39863
	public int TeamLength;

	// Token: 0x04009BB8 RID: 39864
	public List<int> InitSelectRoleList = new List<int>();

	// Token: 0x04009BB9 RID: 39865
	private readonly List<MultiTeamRoleData> MultiTeamRoleDataList = new List<MultiTeamRoleData>();

	// Token: 0x04009BBA RID: 39866
	public List<int> UnRecommendRole = new List<int>();

	// Token: 0x04009BBB RID: 39867
	[Nullable(2)]
	public MultiTeamTagDataItem MultiTeamTagData;

	// Token: 0x04009BBC RID: 39868
	public bool NeedShowTag;

	// Token: 0x04009BBD RID: 39869
	public string Tips = "";
}
