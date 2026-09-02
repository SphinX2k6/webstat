using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;

// Token: 0x020012D5 RID: 4821
[NullableContext(1)]
[Nullable(0)]
public class AbyssChallengeData
{
	// Token: 0x060081C6 RID: 33222 RVA: 0x00224DB9 File Offset: 0x00222FB9
	public int GetChallengeId()
	{
		return this.ChallengeId;
	}

	// Token: 0x060081C7 RID: 33223 RVA: 0x00224DC1 File Offset: 0x00222FC1
	public bool GetIfUnlock()
	{
		return this.IfUnlock;
	}

	// Token: 0x060081C8 RID: 33224 RVA: 0x00224DC9 File Offset: 0x00222FC9
	public bool GetCanChallenge()
	{
		return this.CanChallenge;
	}

	// Token: 0x060081C9 RID: 33225 RVA: 0x00224DD1 File Offset: 0x00222FD1
	public bool GetConditionFinishState()
	{
		return this.ConditionFinishState;
	}

	// Token: 0x060081CA RID: 33226 RVA: 0x00224DD9 File Offset: 0x00222FD9
	public long GetUnlockTime()
	{
		return this.UnlockTime;
	}

	// Token: 0x060081CB RID: 33227 RVA: 0x00224DE1 File Offset: 0x00222FE1
	public AbyssInst? GetConfig()
	{
		return ConfigAbyssInstById.GetConfig(this.ChallengeId, true);
	}

	// Token: 0x060081CC RID: 33228 RVA: 0x00224DEF File Offset: 0x00222FEF
	public bool GetOverUnlockTime()
	{
		return Singleton<TimeUtil>.Instance.GetServerTime() >= (double)this.UnlockTime;
	}

	// Token: 0x060081CD RID: 33229 RVA: 0x00224E08 File Offset: 0x00223008
	public string GetLeftTimeText()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double remainTime = Math.Max((double)this.UnlockTime - serverTime, 1.0);
		return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(remainTime).CountDownText ?? "";
	}

	// Token: 0x060081CE RID: 33230 RVA: 0x00224E54 File Offset: 0x00223054
	public TItem[] GetReward()
	{
		List<TItem> list = new List<TItem>();
		int dropPreviewId = this.GetConfig().Value.DropPreviewId;
		if (dropPreviewId > 0)
		{
			foreach (KeyValuePair<int, int> keyValuePair in ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropPreviewId).Value.DropPreview())
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value);
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060081CF RID: 33231 RVA: 0x00224F0C File Offset: 0x0022310C
	public int GetMaxProgress()
	{
		return this.MaxProgress;
	}

	// Token: 0x060081D0 RID: 33232 RVA: 0x00224F14 File Offset: 0x00223114
	public bool GetIfPass()
	{
		return this.IfPass;
	}

	// Token: 0x060081D1 RID: 33233 RVA: 0x00224F1C File Offset: 0x0022311C
	public void Phrase(AbyssChallenge data)
	{
		this.ChallengeId = data.ChallengeId;
		this.IfUnlock = data.Unlock;
		this.CanChallenge = data.CanChallenge;
		this.UnlockTime = data.UnlockTime / 1000L;
		this.ConditionFinishState = data.IsConditionUnlock;
		this.MaxProgress = data.MaxProgress;
		this.IfPass = data.Passed;
	}

	// Token: 0x04003DD1 RID: 15825
	private int ChallengeId;

	// Token: 0x04003DD2 RID: 15826
	private bool IfUnlock;

	// Token: 0x04003DD3 RID: 15827
	private bool CanChallenge;

	// Token: 0x04003DD4 RID: 15828
	private long UnlockTime;

	// Token: 0x04003DD5 RID: 15829
	private bool ConditionFinishState;

	// Token: 0x04003DD6 RID: 15830
	private int MaxProgress;

	// Token: 0x04003DD7 RID: 15831
	private bool IfPass;
}
