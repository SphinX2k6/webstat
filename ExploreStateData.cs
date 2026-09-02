using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001B80 RID: 7040
[NullableContext(1)]
[Nullable(0)]
public class ExploreStateData
{
	// Token: 0x0600CC7F RID: 52351 RVA: 0x00367084 File Offset: 0x00365284
	public void Initialize(int stateId, int countryId)
	{
		this.CountryId = countryId;
		this.StateId = stateId;
		if (stateId != 0)
		{
			this.IsNoneState = false;
			State value = ConfigBase<ExploreProgressConfig>.Instance.GetStateConfigByStateId(stateId).Value;
			this.StateNameKey = value.StateName;
			this.SortIndex = value.SortIndex;
		}
	}

	// Token: 0x0600CC80 RID: 52352 RVA: 0x003670D7 File Offset: 0x003652D7
	public void PushAreaData(ExploreAreaData areaData)
	{
		this.ExploreAreaDataList.Add(areaData);
	}

	// Token: 0x0600CC81 RID: 52353 RVA: 0x003670E5 File Offset: 0x003652E5
	public bool CheckPushAreaData(ExploreAreaData areaData)
	{
		if (areaData.StateId != this.StateId)
		{
			return false;
		}
		this.PushAreaData(areaData);
		return true;
	}

	// Token: 0x0600CC82 RID: 52354 RVA: 0x00367100 File Offset: 0x00365300
	public bool HasCanTakeStageReward()
	{
		using (List<ExploreAreaData>.Enumerator enumerator = this.ExploreAreaDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.HasCanTakeStageReward())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x040061C9 RID: 25033
	public int StateId;

	// Token: 0x040061CA RID: 25034
	public int CountryId;

	// Token: 0x040061CB RID: 25035
	public string StateNameKey = "TowerDefence_lock";

	// Token: 0x040061CC RID: 25036
	public bool IsNoneState = true;

	// Token: 0x040061CD RID: 25037
	public int SortIndex;

	// Token: 0x040061CE RID: 25038
	public readonly List<ExploreAreaData> ExploreAreaDataList = new List<ExploreAreaData>();
}
