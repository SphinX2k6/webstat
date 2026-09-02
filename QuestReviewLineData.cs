using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;

// Token: 0x02002676 RID: 9846
[NullableContext(1)]
[Nullable(0)]
public class QuestReviewLineData
{
	// Token: 0x0601368D RID: 79501 RVA: 0x00569A8B File Offset: 0x00567C8B
	public QuestReviewLineData(QuestReviewLine config)
	{
	}

	// Token: 0x17001821 RID: 6177
	// (get) Token: 0x0601368E RID: 79502 RVA: 0x00569AA4 File Offset: 0x00567CA4
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x17001822 RID: 6178
	// (get) Token: 0x0601368F RID: 79503 RVA: 0x00569AC0 File Offset: 0x00567CC0
	public int DisplayOrder
	{
		get
		{
			return this.Config.DisplayOrder;
		}
	}

	// Token: 0x17001823 RID: 6179
	// (get) Token: 0x06013690 RID: 79504 RVA: 0x00569ADC File Offset: 0x00567CDC
	public int StartNode
	{
		get
		{
			return this.Config.StartNodeId;
		}
	}

	// Token: 0x17001824 RID: 6180
	// (get) Token: 0x06013691 RID: 79505 RVA: 0x00569AF8 File Offset: 0x00567CF8
	public string LineColorHex
	{
		get
		{
			return "#" + this.Config.LineColor;
		}
	}

	// Token: 0x17001825 RID: 6181
	// (get) Token: 0x06013692 RID: 79506 RVA: 0x00569B20 File Offset: 0x00567D20
	public string StarIcon
	{
		get
		{
			return this.Config.StarIcon;
		}
	}

	// Token: 0x17001826 RID: 6182
	// (get) Token: 0x06013693 RID: 79507 RVA: 0x00569B3C File Offset: 0x00567D3C
	public string RoundIcon
	{
		get
		{
			return this.Config.RoundIcon;
		}
	}

	// Token: 0x17001827 RID: 6183
	// (get) Token: 0x06013694 RID: 79508 RVA: 0x00569B58 File Offset: 0x00567D58
	public string ShowSeqName
	{
		get
		{
			return this.Config.ShowSeqName;
		}
	}

	// Token: 0x17001828 RID: 6184
	// (get) Token: 0x06013695 RID: 79509 RVA: 0x00569B74 File Offset: 0x00567D74
	public string DestroySeqName
	{
		get
		{
			return this.Config.DestroySeqName;
		}
	}

	// Token: 0x17001829 RID: 6185
	// (get) Token: 0x06013696 RID: 79510 RVA: 0x00569B90 File Offset: 0x00567D90
	public string NodeFirstActivateSeqName
	{
		get
		{
			string result;
			switch (this.DisplayOrder)
			{
			case 1:
				result = "FristActivate";
				break;
			case 2:
				result = "FristActivate2";
				break;
			case 3:
				result = "FristActivate3";
				break;
			default:
				result = "FristActivate";
				break;
			}
			return result;
		}
	}

	// Token: 0x1700182A RID: 6186
	// (get) Token: 0x06013697 RID: 79511 RVA: 0x00569BD9 File Offset: 0x00567DD9
	// (set) Token: 0x06013698 RID: 79512 RVA: 0x00569BE1 File Offset: 0x00567DE1
	public EQuestReviewLineState State { get; private set; } = EQuestReviewLineState.Show;

	// Token: 0x1700182B RID: 6187
	// (get) Token: 0x06013699 RID: 79513 RVA: 0x00569BEA File Offset: 0x00567DEA
	public bool IsShow
	{
		get
		{
			if (this.Id == 3200)
			{
				return this.HasFused;
			}
			return this.State > EQuestReviewLineState.Hide;
		}
	}

	// Token: 0x1700182C RID: 6188
	// (get) Token: 0x0601369A RID: 79514 RVA: 0x00569C0C File Offset: 0x00567E0C
	// (set) Token: 0x0601369B RID: 79515 RVA: 0x00569C3C File Offset: 0x00567E3C
	public bool IsFirstTimeShow
	{
		get
		{
			bool result = true;
			Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewLineUnlockAnim, null);
			if (player != null)
			{
				player.TryGetValue(this.Id, out result);
			}
			return result;
		}
		set
		{
			Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewLineUnlockAnim, null) ?? new Dictionary<int, bool>();
			dictionary[this.Id] = value;
			LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewLineUnlockAnim, dictionary);
		}
	}

	// Token: 0x1700182D RID: 6189
	// (get) Token: 0x0601369C RID: 79516 RVA: 0x00569C77 File Offset: 0x00567E77
	public bool IsDestroy
	{
		get
		{
			return this.State == EQuestReviewLineState.Destroy;
		}
	}

	// Token: 0x1700182E RID: 6190
	// (get) Token: 0x0601369D RID: 79517 RVA: 0x00569C84 File Offset: 0x00567E84
	// (set) Token: 0x0601369E RID: 79518 RVA: 0x00569CB4 File Offset: 0x00567EB4
	public bool IsFirstTimeDestroy
	{
		get
		{
			bool result = true;
			Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewLineDestroyAnim, null);
			if (player != null)
			{
				player.TryGetValue(this.Id, out result);
			}
			return result;
		}
		set
		{
			Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewLineDestroyAnim, null) ?? new Dictionary<int, bool>();
			dictionary[this.Id] = value;
			LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewLineDestroyAnim, dictionary);
		}
	}

	// Token: 0x1700182F RID: 6191
	// (get) Token: 0x0601369F RID: 79519 RVA: 0x00569CEF File Offset: 0x00567EEF
	public bool IsFusionLine
	{
		get
		{
			return this.DestroySeqName == "Change";
		}
	}

	// Token: 0x17001830 RID: 6192
	// (get) Token: 0x060136A0 RID: 79520 RVA: 0x00569D01 File Offset: 0x00567F01
	// (set) Token: 0x060136A1 RID: 79521 RVA: 0x00569D09 File Offset: 0x00567F09
	public bool IsTempLine { get; set; }

	// Token: 0x17001831 RID: 6193
	// (get) Token: 0x060136A2 RID: 79522 RVA: 0x00569D12 File Offset: 0x00567F12
	// (set) Token: 0x060136A3 RID: 79523 RVA: 0x00569D1F File Offset: 0x00567F1F
	public bool HasFused
	{
		get
		{
			return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.QuestReviewNewLineHasFused, false);
		}
		set
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.QuestReviewNewLineHasFused, value);
		}
	}

	// Token: 0x060136A4 RID: 79524 RVA: 0x00569D2D File Offset: 0x00567F2D
	public void UpdateByServerData(QuestReviewLineInfo data)
	{
		if (data.DestroyCondition)
		{
			this.State = EQuestReviewLineState.Destroy;
			return;
		}
		if (data.ShowCondition)
		{
			this.State = EQuestReviewLineState.Show;
			return;
		}
		this.State = EQuestReviewLineState.Hide;
	}

	// Token: 0x0400976A RID: 38762
	public bool SkipAnim;

	// Token: 0x0400976B RID: 38763
	private readonly QuestReviewLine Config = config;
}
