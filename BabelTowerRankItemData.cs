using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200123D RID: 4669
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerRankItemData
{
	// Token: 0x06007C61 RID: 31841 RVA: 0x0020B820 File Offset: 0x00209A20
	public void CopyFrom(BabelTowerRankItemData other)
	{
		this.Ranking = other.Ranking;
		this.Name = other.Name;
		this.ShowName = other.ShowName;
		this.HeadId = other.HeadId;
		this.TowerLevel = other.TowerLevel;
		this.PassStar = other.PassStar;
		this.PassTime = other.PassTime;
		this.RoleIdList = new List<int>(other.RoleIdList);
		this.RoleLevelList = new List<int>(other.RoleLevelList);
		this.IsMyRank = other.IsMyRank;
		this.HasData = other.HasData;
		this.TitleId = other.TitleId;
		this.TitleStarLevel = other.TitleStarLevel;
		this.PlayerId = other.PlayerId;
		this.ShowRoleList = other.ShowRoleList;
	}

	// Token: 0x04003B77 RID: 15223
	public int Ranking;

	// Token: 0x04003B78 RID: 15224
	public string Name = "";

	// Token: 0x04003B79 RID: 15225
	public bool ShowName = true;

	// Token: 0x04003B7A RID: 15226
	public int HeadId;

	// Token: 0x04003B7B RID: 15227
	public int TowerLevel;

	// Token: 0x04003B7C RID: 15228
	public int PassStar;

	// Token: 0x04003B7D RID: 15229
	public int PassTime;

	// Token: 0x04003B7E RID: 15230
	public List<int> RoleIdList = new List<int>();

	// Token: 0x04003B7F RID: 15231
	public List<int> RoleLevelList = new List<int>();

	// Token: 0x04003B80 RID: 15232
	public bool IsMyRank;

	// Token: 0x04003B81 RID: 15233
	public bool HasData;

	// Token: 0x04003B82 RID: 15234
	public int TitleId;

	// Token: 0x04003B83 RID: 15235
	public int TitleStarLevel;

	// Token: 0x04003B84 RID: 15236
	public int PlayerId;

	// Token: 0x04003B85 RID: 15237
	public bool ShowRoleList;
}
