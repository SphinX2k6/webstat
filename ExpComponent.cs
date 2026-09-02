using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018D0 RID: 6352
[NullableContext(1)]
[Nullable(0)]
public class ExpComponent : UiPanelBase
{
	// Token: 0x0600B6A5 RID: 46757 RVA: 0x003090F7 File Offset: 0x003072F7
	public ExpComponent(UUIItem uiItem, bool IsAddUp = false)
	{
		this.IsAddUp = IsAddUp;
		this.SourceItem = uiItem;
	}

	// Token: 0x0600B6A6 RID: 46758 RVA: 0x00309118 File Offset: 0x00307318
	public void Init()
	{
		base.CreateThenShowByActor(this.SourceItem.GetOwner(), null);
	}

	// Token: 0x0600B6A7 RID: 46759 RVA: 0x0030912C File Offset: 0x0030732C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
	}

	// Token: 0x0600B6A8 RID: 46760 RVA: 0x00309224 File Offset: 0x00307424
	protected override void OnStart()
	{
		base.GetSprite(6).SetFillAmount(0f);
		base.GetSprite(5).SetFillAmount(0f);
		base.GetSprite(7).SetFillAmount(0f);
		this.ExpTweenComponent = new ExpTweenComponent(base.GetSprite(6), base.GetSprite(5), base.GetSprite(7), null, this.ExpTweenFinish);
	}

	// Token: 0x0600B6A9 RID: 46761 RVA: 0x0030928B File Offset: 0x0030748B
	public void SetLevelFormatText(string levelText)
	{
		this.LevelFormatText = levelText;
	}

	// Token: 0x0600B6AA RID: 46762 RVA: 0x00309294 File Offset: 0x00307494
	public void PlayExpTween(SelectableExpData expData)
	{
		int num = 1;
		float arrivedFillAmount = expData.GetArrivedFillAmount();
		int currentLevel = expData.GetCurrentLevel();
		while (currentLevel + num < expData.GetArrivedLevel())
		{
			num++;
		}
		if (num > 2)
		{
			num = 2;
		}
		if (arrivedFillAmount >= 1f)
		{
			num = 1;
		}
		this.ExpTweenComponent.PlayExpTween(num, arrivedFillAmount, 0f, LTweenEase.Linear);
	}

	// Token: 0x0600B6AB RID: 46763 RVA: 0x003092E8 File Offset: 0x003074E8
	public void UpdateInitState(SelectableExpData expData)
	{
		if (!StringUtils.IsEmpty(this.LevelFormatText))
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), this.LevelFormatText, new <>z__ReadOnlySingleElementList<object>(expData.GetCurrentLevel().ToString()));
		}
		else
		{
			base.GetText(0).SetText(expData.GetCurrentLevel().ToString(), true);
		}
		this.ExpTweenComponent.SetCurrentSpriteActive(true);
		this.ExpTweenComponent.SetNextSpriteActive(false);
		this.SetNextLevelActive(false);
		base.GetText(2).SetUIActive(false);
		this.SetMaxItemActive(expData.GetArrivedLevel() == expData.GetCurrentMaxLevel());
		if (expData.GetCurrentLevel() == expData.GetCurrentMaxLevel())
		{
			this.ExpTweenComponent.SetCurrentFillAmount(1f);
			this.ExpTweenComponent.SetAddFillAmount(1f);
			int maxExp = expData.GetMaxExp(expData.GetCurrentLevel() - 1);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "ExpShow", new <>z__ReadOnlyArray<object>(new object[]
			{
				maxExp,
				maxExp
			}));
		}
		else
		{
			int num = expData.StageMaxExp(expData.GetCurrentLevel());
			float num2 = (float)expData.GetCurrentExp() / (float)num;
			this.ExpTweenComponent.SetCurrentFillAmount(num2);
			this.ExpTweenComponent.SetAddFillAmount(num2);
			int maxExp2 = expData.GetMaxExp(expData.GetCurrentLevel());
			int num3 = expData.GetIsAddUp() ? (expData.AddUpMaxExp(expData.GetCurrentLevel() - 1) + expData.GetCurrentExp()) : expData.GetCurrentExp();
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "ExpShow", new <>z__ReadOnlyArray<object>(new object[]
			{
				num3,
				maxExp2
			}));
		}
		this.LastTimePreviewLevel = expData.GetArrivedLevel();
	}

	// Token: 0x0600B6AC RID: 46764 RVA: 0x003094A4 File Offset: 0x003076A4
	public void Update(SelectableExpData expData, bool needPreviewTween = true)
	{
		base.GetText(2).SetText("+" + Math.Floor((double)expData.GetCurrentAddExp()).ToString(), true);
		base.GetText(2).SetUIActive(expData.GetCurrentAddExp() > 0f);
		if (expData.GetIfNext())
		{
			this.UpdateExpWithLevelUp(expData, needPreviewTween);
			return;
		}
		this.UpdateCurrentExp(expData, needPreviewTween);
	}

	// Token: 0x0600B6AD RID: 46765 RVA: 0x0030950E File Offset: 0x0030770E
	private void UpdateExpWithLevelUp(SelectableExpData expData, bool needPreviewTween = true)
	{
		this.SetNextLevel(expData.GetArrivedLevel());
		this.SetMaxItemActive(expData.GetArrivedLevel() == expData.GetCurrentMaxLevel());
		if (needPreviewTween)
		{
			this.PlayPreviewExp(expData);
			return;
		}
		this.UpdateNextExpState(expData.GetArrivedFillAmount());
	}

	// Token: 0x0600B6AE RID: 46766 RVA: 0x00309547 File Offset: 0x00307747
	private void UpdateCurrentExp(SelectableExpData expData, bool needPreviewTween = true)
	{
		this.SetNextLevelActive(false);
		this.SetMaxItemActive(expData.GetArrivedLevel() == expData.GetCurrentMaxLevel());
		if (needPreviewTween)
		{
			this.PlayPreviewExp(expData);
			return;
		}
		this.UpdateCurrentExpState(expData.GetArrivedFillAmount());
	}

	// Token: 0x0600B6AF RID: 46767 RVA: 0x0030957B File Offset: 0x0030777B
	protected void UpdateNextExpState(float fillAmount)
	{
		this.ExpTweenComponent.SetCurrentSpriteActive(false);
		this.ExpTweenComponent.SetAddFillAmount(1f);
		this.ExpTweenComponent.SetNextSpriteActive(true);
		this.ExpTweenComponent.SetNextFillAmount(fillAmount);
	}

	// Token: 0x0600B6B0 RID: 46768 RVA: 0x003095B1 File Offset: 0x003077B1
	protected void SetMaxItemActive(bool bActive)
	{
		base.GetItem(8).SetUIActive(bActive);
	}

	// Token: 0x0600B6B1 RID: 46769 RVA: 0x003095C0 File Offset: 0x003077C0
	private void PlayPreviewExp(SelectableExpData expData)
	{
		this.ExpTweenComponent.PlayPreviewExpTween(expData.GetCurrentLevel(), this.LastTimePreviewLevel, expData.GetArrivedLevel(), expData.GetCurrentMaxLevel(), expData.GetArrivedFillAmount());
		this.LastTimePreviewLevel = expData.GetArrivedLevel();
	}

	// Token: 0x0600B6B2 RID: 46770 RVA: 0x003095F7 File Offset: 0x003077F7
	public void BindPlayCompleteCallBack(Action<bool> callback)
	{
		this.ExpTweenComponent.BindPlayCompleteCallBack(callback);
	}

	// Token: 0x0600B6B3 RID: 46771 RVA: 0x00309605 File Offset: 0x00307805
	protected void UpdateCurrentExpState(float fillAmount)
	{
		this.ExpTweenComponent.SetCurrentSpriteActive(true);
		this.ExpTweenComponent.SetAddFillAmount(fillAmount);
		this.ExpTweenComponent.SetNextSpriteActive(false);
	}

	// Token: 0x0600B6B4 RID: 46772 RVA: 0x0030962B File Offset: 0x0030782B
	private void SetNextLevelActive(bool bActive)
	{
		if (!bActive)
		{
			base.GetText(1).SetText("", true);
		}
		base.GetItem(4).SetUIActive(bActive);
	}

	// Token: 0x0600B6B5 RID: 46773 RVA: 0x00309650 File Offset: 0x00307850
	private void SetNextLevel(int nextLevel)
	{
		this.SetNextLevelActive(true);
		if (!StringUtils.IsEmpty(this.LevelFormatText))
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), this.LevelFormatText, new <>z__ReadOnlySingleElementList<object>(nextLevel.ToString()));
			return;
		}
		base.GetText(1).SetText(nextLevel.ToString(), true);
	}

	// Token: 0x0600B6B6 RID: 46774 RVA: 0x003096A9 File Offset: 0x003078A9
	public void SetLevelItemShowState(bool state)
	{
		this.SetArrowShowState(state);
		this.SetAfterTextShowState(state);
	}

	// Token: 0x0600B6B7 RID: 46775 RVA: 0x003096B9 File Offset: 0x003078B9
	public void SetArrowShowState(bool state)
	{
		base.GetItem(4).SetUIActive(state);
	}

	// Token: 0x0600B6B8 RID: 46776 RVA: 0x003096C8 File Offset: 0x003078C8
	public void SetAfterTextShowState(bool state)
	{
		base.GetText(1).SetUIActive(state);
	}

	// Token: 0x0600B6B9 RID: 46777 RVA: 0x003096D7 File Offset: 0x003078D7
	public void RefreshSingleText(string text)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), text, Array.Empty<object>());
	}

	// Token: 0x0600B6BA RID: 46778 RVA: 0x003096F0 File Offset: 0x003078F0
	protected override void OnBeforeDestroy()
	{
		this.ExpTweenComponent.Destroy();
	}

	// Token: 0x0400560C RID: 22028
	[Nullable(2)]
	protected ExpTweenComponent ExpTweenComponent;

	// Token: 0x0400560D RID: 22029
	private string LevelFormatText = "";

	// Token: 0x0400560E RID: 22030
	[Nullable(2)]
	private readonly UUIItem SourceItem;

	// Token: 0x0400560F RID: 22031
	protected bool IsAddUp;

	// Token: 0x04005610 RID: 22032
	[Nullable(2)]
	private readonly Action ExpTweenFinish;

	// Token: 0x04005611 RID: 22033
	private int LastTimePreviewLevel;

	// Token: 0x02007C4C RID: 31820
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A730 RID: 173872
		CurrentLevelText,
		// Token: 0x0402A731 RID: 173873
		NextLevelText,
		// Token: 0x0402A732 RID: 173874
		AddExpText,
		// Token: 0x0402A733 RID: 173875
		IncreaseExpText,
		// Token: 0x0402A734 RID: 173876
		ArrowItem,
		// Token: 0x0402A735 RID: 173877
		AddExpSprite,
		// Token: 0x0402A736 RID: 173878
		CurrentExpSprite,
		// Token: 0x0402A737 RID: 173879
		AniSprite,
		// Token: 0x0402A738 RID: 173880
		MaxSprite,
		// Token: 0x0402A739 RID: 173881
		LevelItem
	}
}
