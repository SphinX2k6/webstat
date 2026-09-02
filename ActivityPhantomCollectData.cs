using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x0200148F RID: 5263
[NullableContext(1)]
[Nullable(0)]
public class ActivityPhantomCollectData : ActivityBaseData
{
	// Token: 0x0600934E RID: 37710 RVA: 0x0026DE17 File Offset: 0x0026C017
	protected override void PhraseEx(ActivityData data)
	{
		if (data.PhantomCollectActivity == null)
		{
			return;
		}
		this.PhantomCollectRewardList = data.PhantomCollectActivity.PhantomCollectRewards.ToArray<PhantomCollectReward>();
	}

	// Token: 0x0600934F RID: 37711 RVA: 0x0026DE38 File Offset: 0x0026C038
	protected override bool GetExDataFinishShowState()
	{
		return !this.PhantomCollectRewardList.Any((PhantomCollectReward reward) => reward.State != SignState.IsReceive);
	}

	// Token: 0x06009350 RID: 37712 RVA: 0x0026DE67 File Offset: 0x0026C067
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public PhantomCollectReward[] GetPhantomCollectRewardList()
	{
		return this.PhantomCollectRewardList ?? new PhantomCollectReward[0];
	}

	// Token: 0x06009351 RID: 37713 RVA: 0x0026DE7C File Offset: 0x0026C07C
	[NullableContext(2)]
	public PhantomCollectReward GetPhantomCollectRewardById(int id)
	{
		PhantomCollectReward[] phantomCollectRewardList = this.PhantomCollectRewardList;
		if (phantomCollectRewardList == null)
		{
			return null;
		}
		return phantomCollectRewardList.FirstOrDefault((PhantomCollectReward reward) => reward.Type == (PhantomCollectRewardType)id);
	}

	// Token: 0x06009352 RID: 37714 RVA: 0x0026DEB4 File Offset: 0x0026C0B4
	public int[] GetCollectPhantomList()
	{
		ActivityPhantomCollectConfig instance = ConfigBase<ActivityPhantomCollectConfig>.Instance;
		Aki.Config.PhantomCollectActivity? phantomCollectActivity = (instance != null) ? instance.GetPhantomCollectConfig(ControllerBase<ActivityPhantomCollectController>.Instance.ActivityId) : null;
		if (phantomCollectActivity == null)
		{
			return new int[0];
		}
		return phantomCollectActivity.Value.Phantoms();
	}

	// Token: 0x06009353 RID: 37715 RVA: 0x0026DF04 File Offset: 0x0026C104
	public override bool GetExDataRedPointShowState()
	{
		bool result = false;
		if (this.PhantomCollectRewardList != null)
		{
			PhantomCollectReward[] phantomCollectRewardList = this.PhantomCollectRewardList;
			for (int i = 0; i < phantomCollectRewardList.Length; i++)
			{
				if (phantomCollectRewardList[i].State == SignState.Unlock)
				{
					result = true;
				}
			}
		}
		return result;
	}

	// Token: 0x06009354 RID: 37716 RVA: 0x0026DF40 File Offset: 0x0026C140
	public int GetCollectPhantomCount()
	{
		int[] collectPhantomList = this.GetCollectPhantomList();
		int num = 0;
		foreach (int monsterId in collectPhantomList)
		{
			if (ModelBase<PhantomBattleModel>.Instance.GetPhantomIsUnlock(monsterId))
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06009355 RID: 37717 RVA: 0x0026DF7C File Offset: 0x0026C17C
	public void UpadatePhantomCollectReward(PhantomCollectReward reward)
	{
		if (this.PhantomCollectRewardList == null)
		{
			return;
		}
		int num = this.PhantomCollectRewardList.ToList<PhantomCollectReward>().FindIndex((PhantomCollectReward item) => item.Type == reward.Type);
		if (num == -1)
		{
			return;
		}
		this.PhantomCollectRewardList[num] = reward;
	}

	// Token: 0x04004423 RID: 17443
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public PhantomCollectReward[] PhantomCollectRewardList;
}
