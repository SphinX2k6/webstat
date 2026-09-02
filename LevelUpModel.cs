using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020020C8 RID: 8392
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class LevelUpModel : ModelBase<LevelUpModel>
{
	// Token: 0x06010088 RID: 65672 RVA: 0x00467218 File Offset: 0x00465418
	public void SetExpChange(int currentLevel, int currentExp, int lastExp, int maxExp, int differenceExp)
	{
		ILevelUpViewViedData data = new LevelUpViewViedData
		{
			AddExp = true,
			PreLevel = currentLevel,
			PreExp = lastExp,
			CurLevel = currentLevel,
			CurExp = currentExp
		};
		this.TryOpenLevelUpView(data);
	}

	// Token: 0x06010089 RID: 65673 RVA: 0x00467258 File Offset: 0x00465458
	public void SetLevelUp(int lastLevel, int currentLevel, int currentExp, int lastExp, int addExp, int currentMaxExp, int lastMaxExp, int differenceExp)
	{
		ILevelUpViewViedData data = new LevelUpViewViedData
		{
			AddExp = (differenceExp > 0),
			PreLevel = lastLevel,
			PreExp = lastExp,
			CurLevel = currentLevel,
			CurExp = currentExp
		};
		this.TryOpenLevelUpView(data);
	}

	// Token: 0x0601008A RID: 65674 RVA: 0x0046729C File Offset: 0x0046549C
	public void SetShowLevelOnly(int currentLevel)
	{
		int valueOrDefault = ModelBase<FunctionModel>.Instance.GetPlayerExp().GetValueOrDefault();
		ILevelUpViewViedData data = new LevelUpViewViedData
		{
			AddExp = false,
			PreLevel = currentLevel,
			PreExp = valueOrDefault,
			CurLevel = currentLevel,
			CurExp = valueOrDefault
		};
		this.TryOpenLevelUpView(data);
	}

	// Token: 0x0601008B RID: 65675 RVA: 0x004672EC File Offset: 0x004654EC
	private void RefreshCacheData(ILevelUpViewViedData data)
	{
		if (this.CacheData == null)
		{
			return;
		}
		if (data.AddExp)
		{
			this.CacheData.AddExp = data.AddExp;
		}
		if (data.PreLevel < this.CacheData.PreLevel)
		{
			this.CacheData.PreLevel = data.PreLevel;
			this.CacheData.PreExp = data.PreExp;
		}
		else if (data.PreLevel == this.CacheData.PreLevel && data.PreExp <= this.CacheData.PreExp)
		{
			this.CacheData.PreExp = data.PreExp;
		}
		if (data.CurLevel > this.CacheData.CurLevel)
		{
			this.CacheData.CurLevel = data.CurLevel;
			this.CacheData.CurExp = data.CurExp;
			return;
		}
		if (data.CurLevel == this.CacheData.CurLevel && data.CurExp >= this.CacheData.CurExp)
		{
			this.CacheData.CurExp = data.CurExp;
		}
	}

	// Token: 0x0601008C RID: 65676 RVA: 0x004673F8 File Offset: 0x004655F8
	private void TryOpenLevelUpView(ILevelUpViewViedData data)
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.LevelUpView) && this.CacheData != null)
		{
			this.RefreshCacheData(data);
			return;
		}
		this.CacheData = data;
		if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.LevelUpView) == null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.LevelUpView, this.CacheData, null);
		}
	}

	// Token: 0x0601008D RID: 65677 RVA: 0x00467454 File Offset: 0x00465654
	public ILevelUpViewViedData GetCacheData()
	{
		return this.CacheData;
	}

	// Token: 0x0601008E RID: 65678 RVA: 0x0046745C File Offset: 0x0046565C
	public void ClearCacheData()
	{
		this.CacheData = null;
	}

	// Token: 0x04007AEB RID: 31467
	public bool CanBreakTipsShowFlag = true;

	// Token: 0x04007AEC RID: 31468
	[Nullable(2)]
	private ILevelUpViewViedData CacheData;
}
