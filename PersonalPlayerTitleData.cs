using System;
using System.Collections.Generic;
using CSharpScript.Game.Common;

// Token: 0x0200240C RID: 9228
public class PersonalPlayerTitleData
{
	// Token: 0x06011DD0 RID: 73168 RVA: 0x004E9EA4 File Offset: 0x004E80A4
	public PersonalPlayerTitleData(int playerTitleId, bool isUnLock)
	{
		this.PlayerTitleId = playerTitleId;
		this.IsUnLock = isUnLock;
		Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PlayerTitleRecord, null) ?? new Dictionary<int, bool>();
		if (this.IsUnLock)
		{
			if (!dictionary.ContainsKey(playerTitleId))
			{
				dictionary[playerTitleId] = true;
				LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PlayerTitleRecord, dictionary);
				return;
			}
		}
		else if (dictionary.ContainsKey(playerTitleId))
		{
			dictionary.Remove(playerTitleId);
			LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PlayerTitleRecord, dictionary);
		}
	}

	// Token: 0x06011DD1 RID: 73169 RVA: 0x004E9F14 File Offset: 0x004E8114
	public void SetUnLockProgress(int curProgress, int targetProgress)
	{
		this.CurProgress = new int?(curProgress);
		this.TargetProgress = new int?(targetProgress);
	}

	// Token: 0x06011DD2 RID: 73170 RVA: 0x004E9F2E File Offset: 0x004E812E
	public void UnLock(double unlockTime)
	{
		this.IsUnLock = true;
		this.UnlockTime = new double?(unlockTime);
	}

	// Token: 0x06011DD3 RID: 73171 RVA: 0x004E9F43 File Offset: 0x004E8143
	public void SetStarLevel(int starLevel)
	{
		this.StarLevel = new int?(starLevel);
	}

	// Token: 0x06011DD4 RID: 73172 RVA: 0x004E9F51 File Offset: 0x004E8151
	public void SetUnlockTime(double unlockTime)
	{
		this.UnlockTime = new double?(unlockTime);
	}

	// Token: 0x06011DD5 RID: 73173 RVA: 0x004E9F60 File Offset: 0x004E8160
	public bool GetIsShowRedDot()
	{
		if (!this.IsUnLock)
		{
			return false;
		}
		if (this.IsExpired())
		{
			return false;
		}
		Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PlayerTitleRecord, null) ?? new Dictionary<int, bool>();
		return dictionary.ContainsKey(this.PlayerTitleId) && dictionary[this.PlayerTitleId];
	}

	// Token: 0x06011DD6 RID: 73174 RVA: 0x004E9FAF File Offset: 0x004E81AF
	public bool IsTimeLimitTitle()
	{
		return this.StartTime != null && this.EndTime != null;
	}

	// Token: 0x06011DD7 RID: 73175 RVA: 0x004E9FCB File Offset: 0x004E81CB
	public bool IsExpired()
	{
		return this.IsTimeLimitTitle() && Singleton<TimeUtil>.Instance.GetServerTime() > this.EndTime.Value;
	}

	// Token: 0x06011DD8 RID: 73176 RVA: 0x004E9FEE File Offset: 0x004E81EE
	public bool IsEffective()
	{
		return this.IsUnLock && !this.IsExpired();
	}

	// Token: 0x06011DD9 RID: 73177 RVA: 0x004EA004 File Offset: 0x004E8204
	public int GetRemainingDays()
	{
		if (!this.IsTimeLimitTitle())
		{
			return 0;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = this.EndTime.Value - serverTime;
		if (num <= 0.0)
		{
			return 0;
		}
		return (int)Math.Ceiling(num / (double)Singleton<TimeUtil>.Instance.OneDaySeconds);
	}

	// Token: 0x06011DDA RID: 73178 RVA: 0x004EA056 File Offset: 0x004E8256
	public void SetTimeLimit(double startTime, double endTime)
	{
		this.StartTime = new double?(startTime);
		this.EndTime = new double?(endTime);
	}

	// Token: 0x04008B99 RID: 35737
	public int PlayerTitleId;

	// Token: 0x04008B9A RID: 35738
	public int? StarLevel;

	// Token: 0x04008B9B RID: 35739
	public bool IsUnLock;

	// Token: 0x04008B9C RID: 35740
	public double? UnlockTime;

	// Token: 0x04008B9D RID: 35741
	public int? CurProgress;

	// Token: 0x04008B9E RID: 35742
	public int? TargetProgress;

	// Token: 0x04008B9F RID: 35743
	public double? StartTime;

	// Token: 0x04008BA0 RID: 35744
	public double? EndTime;
}
