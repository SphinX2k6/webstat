using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;

// Token: 0x02002675 RID: 9845
[NullableContext(1)]
[Nullable(0)]
public class QuestReviewEntryData
{
	// Token: 0x06013683 RID: 79491 RVA: 0x005699D2 File Offset: 0x00567BD2
	public QuestReviewEntryData(QuestReviewEntry config)
	{
	}

	// Token: 0x1700181A RID: 6170
	// (get) Token: 0x06013684 RID: 79492 RVA: 0x005699E1 File Offset: 0x00567BE1
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x1700181B RID: 6171
	// (get) Token: 0x06013685 RID: 79493 RVA: 0x005699EE File Offset: 0x00567BEE
	public IReadOnlyList<int> Tabs
	{
		get
		{
			return this.Config.QuestTabs();
		}
	}

	// Token: 0x1700181C RID: 6172
	// (get) Token: 0x06013686 RID: 79494 RVA: 0x005699FB File Offset: 0x00567BFB
	public int TargetTab
	{
		get
		{
			return this.Config.TargetTab;
		}
	}

	// Token: 0x1700181D RID: 6173
	// (get) Token: 0x06013687 RID: 79495 RVA: 0x00569A08 File Offset: 0x00567C08
	public IReadOnlyList<int> RelatedQuestId
	{
		get
		{
			return this.Config.RelatedQuest();
		}
	}

	// Token: 0x1700181E RID: 6174
	// (get) Token: 0x06013688 RID: 79496 RVA: 0x00569A15 File Offset: 0x00567C15
	public bool ShouldShow
	{
		get
		{
			return this.ShouldShowInternal;
		}
	}

	// Token: 0x1700181F RID: 6175
	// (get) Token: 0x06013689 RID: 79497 RVA: 0x00569A1D File Offset: 0x00567C1D
	public float TimerDurationMs
	{
		get
		{
			return (float)(this.Config.TimerDuration * Singleton<TimeUtil>.Instance.InverseMillisecond);
		}
	}

	// Token: 0x17001820 RID: 6176
	// (get) Token: 0x0601368A RID: 79498 RVA: 0x00569A38 File Offset: 0x00567C38
	// (set) Token: 0x0601368B RID: 79499 RVA: 0x00569A61 File Offset: 0x00567C61
	public bool IsFirstEntry
	{
		get
		{
			return LocalStorage.GetPlayer<bool?>(ELocalStoragePlayerKey.QuestReviewMainViewEntryAnim, null).GetValueOrDefault(true);
		}
		set
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.QuestReviewMainViewEntryAnim, value);
		}
	}

	// Token: 0x0601368C RID: 79500 RVA: 0x00569A6F File Offset: 0x00567C6F
	public void UpdateByServerData(QuestReviewEntryInfo data)
	{
		this.ShouldShowInternal = (data.ShowCondition && !data.HideCondition);
	}

	// Token: 0x04009768 RID: 38760
	private bool ShouldShowInternal;

	// Token: 0x04009769 RID: 38761
	private QuestReviewEntry Config = config;
}
