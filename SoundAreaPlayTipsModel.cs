using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;

// Token: 0x02002A84 RID: 10884
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class SoundAreaPlayTipsModel : ModelBase<SoundAreaPlayTipsModel>
{
	// Token: 0x06015C99 RID: 89241 RVA: 0x0060B2E7 File Offset: 0x006094E7
	protected override bool OnLeaveLevel()
	{
		this.CurrentLevelShowInfoIdCountMap.Clear();
		return true;
	}

	// Token: 0x06015C9A RID: 89242 RVA: 0x0060B2F8 File Offset: 0x006094F8
	private int GetInfoIdCountType(int infoId)
	{
		SoundAreaPlayInfo? config = ConfigSoundAreaPlayInfoById.GetConfig(infoId, true);
		if (config == null)
		{
			return 0;
		}
		return config.GetValueOrDefault().MaxCountType;
	}

	// Token: 0x06015C9B RID: 89243 RVA: 0x0060B328 File Offset: 0x00609528
	public void AddShowInfoIdCount(int infoId)
	{
		int infoIdCountType = this.GetInfoIdCountType(infoId);
		if (infoIdCountType == 0)
		{
			Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.SilentTips, null) ?? new Dictionary<int, int>();
			int num;
			dictionary.TryGetValue(infoId, out num);
			num++;
			dictionary[infoId] = num;
			LocalStorage.SetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.SilentTips, dictionary);
			return;
		}
		if (infoIdCountType == 1)
		{
			int num2;
			this.CurrentLevelShowInfoIdCountMap.TryGetValue(infoId, out num2);
			num2++;
			this.CurrentLevelShowInfoIdCountMap[infoId] = num2;
		}
	}

	// Token: 0x06015C9C RID: 89244 RVA: 0x0060B398 File Offset: 0x00609598
	public int GetInfoIdShowCount(int infoId)
	{
		SoundAreaPlayInfo? config = ConfigSoundAreaPlayInfoById.GetConfig(infoId, true);
		int infoIdCountType = this.GetInfoIdCountType(infoId);
		if (config != null && config.GetValueOrDefault().MaxCount > 0)
		{
			if (infoIdCountType == 0)
			{
				int result;
				(LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.SilentTips, null) ?? new Dictionary<int, int>()).TryGetValue(infoId, out result);
				return result;
			}
			if (infoIdCountType == 1)
			{
				int result2;
				this.CurrentLevelShowInfoIdCountMap.TryGetValue(infoId, out result2);
				return result2;
			}
		}
		return 0;
	}

	// Token: 0x06015C9D RID: 89245 RVA: 0x0060B40C File Offset: 0x0060960C
	public bool CheckInfoIdCanShow(int infoId)
	{
		SoundAreaPlayInfo? config = ConfigSoundAreaPlayInfoById.GetConfig(infoId, true);
		return config == null || config.GetValueOrDefault().MaxCount <= 0 || this.GetInfoIdShowCount(infoId) < config.Value.MaxCount;
	}

	// Token: 0x0400A73C RID: 42812
	private readonly Dictionary<int, int> CurrentLevelShowInfoIdCountMap = new Dictionary<int, int>();
}
