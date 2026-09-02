using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02001497 RID: 5271
[NullableContext(2)]
[Nullable(0)]
public class PinballRankData
{
	// Token: 0x0600937C RID: 37756 RVA: 0x0026EE3B File Offset: 0x0026D03B
	public PinballRankData(bool isMyRank)
	{
		this.IsMyRank = isMyRank;
	}

	// Token: 0x0600937D RID: 37757 RVA: 0x0026EE60 File Offset: 0x0026D060
	public static bool IsValidServerRankData(Aki.Protocol.PinballRankData data)
	{
		return data != null && data.TowerLevel > 0;
	}

	// Token: 0x0600937E RID: 37758 RVA: 0x0026EE70 File Offset: 0x0026D070
	public void SetDataByConfig(int towerLevel)
	{
		PinballRank? pinballRankConfigByTower = ConfigBase<PinballConfig>.Instance.GetPinballRankConfigByTower(towerLevel);
		if (pinballRankConfigByTower != null)
		{
			this.TowerLevel = pinballRankConfigByTower.Value.Tower;
			this.CostTime = pinballRankConfigByTower.Value.PassTime;
			this.DisplayThreshold = pinballRankConfigByTower.Value.DisplayThreshold;
			string name;
			if ((name = ConfigMultiTextLang.GetLocalTextNew(pinballRankConfigByTower.Value.PlayerName, null)) == null)
			{
				name = (pinballRankConfigByTower.Value.PlayerName ?? "");
			}
			this.Name = name;
			this.Formation = new List<ValueTuple<int, int>>();
			int roleListLength = pinballRankConfigByTower.Value.RoleListLength;
			for (int i = 0; i < roleListLength; i++)
			{
				string text = pinballRankConfigByTower.Value.RoleList(i);
				if (text != null)
				{
					string[] array = text.Split(':', StringSplitOptions.None);
					if (array.Length >= 2)
					{
						int num;
						int num2;
						this.Formation.Add(new ValueTuple<int, int>(int.TryParse(array[0], out num) ? num : 0, int.TryParse(array[1], out num2) ? num2 : 0));
					}
				}
			}
			this.HasData = true;
		}
	}

	// Token: 0x0600937F RID: 37759 RVA: 0x0026EF98 File Offset: 0x0026D198
	public void SetDataByServerInfo(Aki.Protocol.PinballRankData data)
	{
		if (!global::PinballRankData.IsValidServerRankData(data))
		{
			return;
		}
		this.Name = data.Name;
		this.TowerLevel = data.TowerLevel;
		this.CostTime = data.CostTime;
		this.Formation = new List<ValueTuple<int, int>>();
		foreach (Aki.Protocol.PinballRoleData pinballRoleData in data.Formation)
		{
			this.Formation.Add(new ValueTuple<int, int>(pinballRoleData.ConfigId, pinballRoleData.RoleLevel));
		}
		this.HasData = true;
	}

	// Token: 0x06009380 RID: 37760 RVA: 0x0026F03C File Offset: 0x0026D23C
	public void SetMyRankData(Aki.Protocol.PinballRankData data)
	{
		if (!global::PinballRankData.IsValidServerRankData(data))
		{
			this.Name = ModelBase<FunctionModel>.Instance.GetPlayerName();
			this.TowerLevel = 0;
			this.CostTime = 0;
			this.Formation = new List<ValueTuple<int, int>>();
			this.HasData = false;
			return;
		}
		this.SetDataByServerInfo(data);
	}

	// Token: 0x04004438 RID: 17464
	public int Ranking;

	// Token: 0x04004439 RID: 17465
	[Nullable(1)]
	public string Name = "";

	// Token: 0x0400443A RID: 17466
	public int TowerLevel;

	// Token: 0x0400443B RID: 17467
	public int CostTime;

	// Token: 0x0400443C RID: 17468
	public bool HasData;

	// Token: 0x0400443D RID: 17469
	public int DisplayThreshold;

	// Token: 0x0400443E RID: 17470
	[TupleElementNames(new string[]
	{
		"RoleId",
		"Level"
	})]
	[Nullable(new byte[]
	{
		1,
		0
	})]
	public List<ValueTuple<int, int>> Formation = new List<ValueTuple<int, int>>();

	// Token: 0x0400443F RID: 17471
	public bool IsMyRank;
}
