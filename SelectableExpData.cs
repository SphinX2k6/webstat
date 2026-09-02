using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001A05 RID: 6661
[NullableContext(1)]
[Nullable(0)]
public class SelectableExpData
{
	// Token: 0x0600BEC9 RID: 48841 RVA: 0x0032802C File Offset: 0x0032622C
	public static SelectableExpData PhraseData(CommonIntensifyPropExpData source)
	{
		SelectableExpData selectableExpData = new SelectableExpData();
		if (source.MaxExpFunction != null)
		{
			selectableExpData.SetMaxExpFunction(source.MaxExpFunction);
		}
		selectableExpData.UpdateComponent(source.CurrentLevel, source.CurrentMaxLevel, source.CurrentExp, null, false);
		selectableExpData.UpdateExp(0);
		return selectableExpData;
	}

	// Token: 0x0600BECA RID: 48842 RVA: 0x00328080 File Offset: 0x00326280
	public void UpdateComponent(int currentLevel, int currentMaxLevel, int currentExp, int? limitLevel = null, bool addUp = false)
	{
		this.ArrivedLevel = currentLevel;
		this.CurrentLevel = currentLevel;
		this.CurrentMaxLevel = currentMaxLevel;
		this.CurrentExp = currentExp;
		this.LimitLevel = limitLevel;
		this.IsAddUp = addUp;
		if (this.CurrentLevel == this.CurrentMaxLevel)
		{
			this.CurrentMaxExp = this.StageMaxExp(this.CurrentLevel - 1);
			return;
		}
		this.CurrentMaxExp = this.StageMaxExp(this.CurrentLevel);
	}

	// Token: 0x0600BECB RID: 48843 RVA: 0x003280EE File Offset: 0x003262EE
	public bool UpdateExp(int newAddExp)
	{
		if (this.IsInMax() && newAddExp > this.FrontExp)
		{
			return false;
		}
		this.ForceUpdateExp(newAddExp);
		return true;
	}

	// Token: 0x0600BECC RID: 48844 RVA: 0x0032810C File Offset: 0x0032630C
	private void ForceUpdateExp(int newAddExp)
	{
		this.FrontExp = newAddExp;
		this.CurrentAddExp = newAddExp;
		this.IfNext = (this.CurrentExp + newAddExp >= this.CurrentMaxExp);
		if (this.IfNext)
		{
			int newAddExp2 = this.CurrentExp + newAddExp - this.CurrentMaxExp;
			this.UpdateNextExp(newAddExp2, this.CurrentLevel + 1);
			return;
		}
		float fillAmount = (float)(this.CurrentExp + newAddExp) / (float)this.CurrentMaxExp;
		this.UpdateCurrentExp(newAddExp, this.CurrentLevel, fillAmount);
	}

	// Token: 0x0600BECD RID: 48845 RVA: 0x00328188 File Offset: 0x00326388
	protected void UpdateNextExp(int newAddExp, int level)
	{
		if (level >= this.CurrentMaxLevel)
		{
			this.UpdateCurrentExp(newAddExp, level, 1f);
			return;
		}
		int num;
		if (!this.MaxExpCacheMap.TryGetValue(level, out num))
		{
			num = this.GetMaxExpFunction(level);
			this.MaxExpCacheMap[level] = num;
		}
		if (newAddExp >= num)
		{
			this.UpdateNextExp(newAddExp - num, level + 1);
			return;
		}
		float fillAmount = (float)newAddExp / (float)num;
		this.UpdateCurrentExp(newAddExp, level, fillAmount);
	}

	// Token: 0x0600BECE RID: 48846 RVA: 0x003281F6 File Offset: 0x003263F6
	protected void UpdateCurrentExp(int newAddExp, int nextLevel, float fillAmount)
	{
		this.ArrivedExp = newAddExp;
		this.ArrivedFillAmount = fillAmount;
		this.ArrivedLevel = nextLevel;
	}

	// Token: 0x0600BECF RID: 48847 RVA: 0x00328210 File Offset: 0x00326410
	public int StageMaxExp(int level)
	{
		if (this.GetMaxExpFunction == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.LevelExperienceComponent, ELogAuthor.XXJ, "Unregistered SetMaxExpFunction CallBack", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0;
		}
		int num;
		if (!this.MaxExpCacheMap.TryGetValue(level, out num))
		{
			num = this.GetMaxExpFunction(level);
			this.MaxExpCacheMap[level] = num;
		}
		return num;
	}

	// Token: 0x0600BED0 RID: 48848 RVA: 0x0032826E File Offset: 0x0032646E
	public int GetMaxExp(int level)
	{
		if (this.IsAddUp)
		{
			return this.AddUpMaxExp(level);
		}
		return this.StageMaxExp(level);
	}

	// Token: 0x0600BED1 RID: 48849 RVA: 0x00328288 File Offset: 0x00326488
	public int AddUpMaxExp(int level)
	{
		int num = 0;
		for (int i = 1; i <= level; i++)
		{
			num += this.StageMaxExp(i);
		}
		return num;
	}

	// Token: 0x0600BED2 RID: 48850 RVA: 0x003282AE File Offset: 0x003264AE
	public bool IsInMax()
	{
		return this.ArrivedLevel == this.CurrentMaxLevel;
	}

	// Token: 0x0600BED3 RID: 48851 RVA: 0x003282C0 File Offset: 0x003264C0
	public int GetOverExp()
	{
		int expDistanceToMax = this.GetExpDistanceToMax();
		int num = this.CurrentAddExp - expDistanceToMax;
		if (num > 0)
		{
			return num;
		}
		return 0;
	}

	// Token: 0x0600BED4 RID: 48852 RVA: 0x003282E4 File Offset: 0x003264E4
	public bool GetIsAddUp()
	{
		return this.IsAddUp;
	}

	// Token: 0x0600BED5 RID: 48853 RVA: 0x003282EC File Offset: 0x003264EC
	public void SetMaxExpFunction(Func<int, int> getMaxExpFunction)
	{
		this.GetMaxExpFunction = getMaxExpFunction;
	}

	// Token: 0x0600BED6 RID: 48854 RVA: 0x003282F5 File Offset: 0x003264F5
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x0600BED7 RID: 48855 RVA: 0x003282FD File Offset: 0x003264FD
	public int GetExpDistanceToMax()
	{
		return this.GetExpDistanceToLevel(this.CurrentMaxLevel);
	}

	// Token: 0x0600BED8 RID: 48856 RVA: 0x0032830C File Offset: 0x0032650C
	public int GetExpDistanceToLevel(int targetLevel)
	{
		if (targetLevel <= this.CurrentLevel)
		{
			return 0;
		}
		int num = Math.Min(targetLevel, this.CurrentMaxLevel);
		int num2 = 0;
		for (int i = 0; i <= num - 1; i++)
		{
			num2 += this.StageMaxExp(i);
		}
		int num3 = 0;
		for (int j = 0; j <= this.CurrentLevel - 1; j++)
		{
			num3 += this.StageMaxExp(j);
		}
		return num2 - num3 - this.CurrentExp;
	}

	// Token: 0x0600BED9 RID: 48857 RVA: 0x00328379 File Offset: 0x00326579
	public int GetCurrentExp()
	{
		return this.CurrentExp;
	}

	// Token: 0x0600BEDA RID: 48858 RVA: 0x00328381 File Offset: 0x00326581
	public int GetCurrentMaxLevel()
	{
		return this.CurrentMaxLevel;
	}

	// Token: 0x0600BEDB RID: 48859 RVA: 0x00328389 File Offset: 0x00326589
	public int GetLimitLevel()
	{
		return this.LimitLevel.Value;
	}

	// Token: 0x0600BEDC RID: 48860 RVA: 0x00328396 File Offset: 0x00326596
	public int GetArrivedAddExp()
	{
		return this.ArrivedExp;
	}

	// Token: 0x0600BEDD RID: 48861 RVA: 0x0032839E File Offset: 0x0032659E
	public float GetCurrentAddExp()
	{
		return (float)this.CurrentAddExp;
	}

	// Token: 0x0600BEDE RID: 48862 RVA: 0x003283A7 File Offset: 0x003265A7
	public int GetArrivedLevel()
	{
		return this.ArrivedLevel;
	}

	// Token: 0x0600BEDF RID: 48863 RVA: 0x003283AF File Offset: 0x003265AF
	public float GetArrivedFillAmount()
	{
		return this.ArrivedFillAmount;
	}

	// Token: 0x0600BEE0 RID: 48864 RVA: 0x003283B7 File Offset: 0x003265B7
	public bool GetIfNext()
	{
		return this.IfNext;
	}

	// Token: 0x040059B2 RID: 22962
	protected int ArrivedLevel;

	// Token: 0x040059B3 RID: 22963
	protected int ArrivedExp;

	// Token: 0x040059B4 RID: 22964
	protected float ArrivedFillAmount;

	// Token: 0x040059B5 RID: 22965
	protected int CurrentMaxExp;

	// Token: 0x040059B6 RID: 22966
	protected int CurrentLevel;

	// Token: 0x040059B7 RID: 22967
	protected int CurrentExp;

	// Token: 0x040059B8 RID: 22968
	protected int CurrentMaxLevel;

	// Token: 0x040059B9 RID: 22969
	protected int? LimitLevel = new int?(0);

	// Token: 0x040059BA RID: 22970
	protected int FrontExp;

	// Token: 0x040059BB RID: 22971
	private bool IfNext;

	// Token: 0x040059BC RID: 22972
	private int CurrentAddExp;

	// Token: 0x040059BD RID: 22973
	protected Dictionary<int, int> MaxExpCacheMap = new Dictionary<int, int>();

	// Token: 0x040059BE RID: 22974
	[Nullable(2)]
	protected Func<int, int> GetMaxExpFunction;

	// Token: 0x040059BF RID: 22975
	private bool IsAddUp;
}
