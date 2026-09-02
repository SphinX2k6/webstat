using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020021E0 RID: 8672
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class LordGymConfig : ConfigBase<LordGymConfig>
{
	// Token: 0x0601059C RID: 66972 RVA: 0x00477A8A File Offset: 0x00475C8A
	public LordGym? GetLordGymConfig(int lordId)
	{
		return ConfigLordGymById.GetConfig(lordId, true);
	}

	// Token: 0x0601059D RID: 66973 RVA: 0x00477A93 File Offset: 0x00475C93
	public IReadOnlyList<LordGym> GetLordGymAllConfig()
	{
		return ConfigLordGymAll.GetConfigList(true);
	}

	// Token: 0x0601059E RID: 66974 RVA: 0x00477A9B File Offset: 0x00475C9B
	public IReadOnlyList<LordGym> GetLordGymAllConfigByDifficulty(int difficulty)
	{
		return ConfigLordGymByDifficulty.GetConfigList(difficulty, true);
	}

	// Token: 0x0601059F RID: 66975 RVA: 0x00477AA4 File Offset: 0x00475CA4
	public IReadOnlyList<LordGymEntrance> GetLordGymEntranceAllConfig()
	{
		return ConfigLordGymEntranceAll.GetConfigList(true);
	}

	// Token: 0x060105A0 RID: 66976 RVA: 0x00477AAC File Offset: 0x00475CAC
	public LordGymEntrance? GetLordGymEntranceConfig(int lordEntranceId)
	{
		return ConfigLordGymEntranceById.GetConfig(lordEntranceId, true);
	}

	// Token: 0x060105A1 RID: 66977 RVA: 0x00477AB8 File Offset: 0x00475CB8
	public int[] GetLordGymEntranceLordList(int lordEntranceId)
	{
		LordGymEntrance? config = ConfigLordGymEntranceById.GetConfig(lordEntranceId, true);
		if (config != null)
		{
			return config.Value.LordGymList();
		}
		return null;
	}

	// Token: 0x060105A2 RID: 66978 RVA: 0x00477AE8 File Offset: 0x00475CE8
	public string GetLordGymEntranceName(int lordEntranceId)
	{
		LordGymEntrance? config = ConfigLordGymEntranceById.GetConfig(lordEntranceId, true);
		if (config != null)
		{
			return config.Value.EntranceTitle;
		}
		return null;
	}

	// Token: 0x060105A3 RID: 66979 RVA: 0x00477B18 File Offset: 0x00475D18
	public List<LordGymFilterType> GetAllLordGymFilterTypeConfig()
	{
		List<LordGymFilterType> list = ConfigCommon.ToList<LordGymFilterType>(ConfigLordGymFilterTypeAll.GetConfigList(true));
		if (list != null)
		{
			List<LordGymFilterType> list2 = new List<LordGymFilterType>();
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].IsEnable)
				{
					list2.Add(list[i]);
				}
			}
			list2.Sort((LordGymFilterType a, LordGymFilterType b) => a.Id - b.Id);
			return list2;
		}
		return list;
	}
}
