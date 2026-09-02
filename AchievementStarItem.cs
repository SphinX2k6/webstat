using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02000FF1 RID: 4081
[NullableContext(1)]
[Nullable(0)]
public class AchievementStarItem : UiPanelBase
{
	// Token: 0x06006971 RID: 26993 RVA: 0x001B78E8 File Offset: 0x001B5AE8
	public AchievementStarItem(int count, AchievementData data, UUIItem uiItem)
	{
		this.StarCount = count;
		this.Data = data;
		this.CreateAndShowTask = new UniTask?(base.CreateThenShowByResourceIdAsync(this.GetStarName(count), uiItem, false).AsAsyncUnitUniTask());
	}

	// Token: 0x06006972 RID: 26994 RVA: 0x001B793C File Offset: 0x001B5B3C
	protected override void OnRegisterComponent()
	{
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>();
		for (int i = 0; i < this.StarCount + 1; i++)
		{
			list.Add(new ValueTuple<int, Type>(i, typeof(UUIItem)));
		}
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006973 RID: 26995 RVA: 0x001B7980 File Offset: 0x001B5B80
	protected override void OnStart()
	{
		for (int i = 0; i < this.StarCount; i++)
		{
			this.StarArray.Add(base.GetItem(i));
		}
		this.RefreshStar(this.Data);
	}

	// Token: 0x06006974 RID: 26996 RVA: 0x001B79BC File Offset: 0x001B5BBC
	protected override void OnBeforeDestroy()
	{
		if (this.StarArray != null)
		{
			this.StarArray.Clear();
			this.StarArray = null;
		}
		if (this.Data != null)
		{
			this.Data = null;
		}
	}

	// Token: 0x06006975 RID: 26997 RVA: 0x001B79E8 File Offset: 0x001B5BE8
	public void RefreshStar(AchievementData data)
	{
		this.StarArray.ForEach(delegate(UUIItem value)
		{
			value.SetUIActive(false);
		});
		if (data.IfSingleAchievement())
		{
			if (data.CanShowStarState())
			{
				for (int i = 0; i < this.StarCount; i++)
				{
					this.StarArray[i].SetUIActive(true);
				}
				return;
			}
		}
		else
		{
			int achievementShowStar = data.GetAchievementShowStar();
			for (int j = 0; j < achievementShowStar; j++)
			{
				this.StarArray[j].SetUIActive(true);
			}
		}
	}

	// Token: 0x06006976 RID: 26998 RVA: 0x001B7A78 File Offset: 0x001B5C78
	private string GetStarName(int count)
	{
		if (count == 1)
		{
			return EAchievementStarEnum.SingleStar.ToString();
		}
		if (count == 2)
		{
			return EAchievementStarEnum.DoubleStar.ToString();
		}
		return EAchievementStarEnum.TripleStar.ToString();
	}

	// Token: 0x04003213 RID: 12819
	private readonly int StarCount;

	// Token: 0x04003214 RID: 12820
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<UUIItem> StarArray = new List<UUIItem>();

	// Token: 0x04003215 RID: 12821
	[Nullable(2)]
	private AchievementData Data;

	// Token: 0x04003216 RID: 12822
	public UniTask? CreateAndShowTask;
}
