using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;

// Token: 0x02002679 RID: 9849
[NullableContext(1)]
[Nullable(0)]
public class QuestReviewNodeData
{
	// Token: 0x060136CE RID: 79566 RVA: 0x00569E29 File Offset: 0x00568029
	public QuestReviewNodeData(QuestReviewNode config)
	{
	}

	// Token: 0x17001846 RID: 6214
	// (get) Token: 0x060136CF RID: 79567 RVA: 0x00569E38 File Offset: 0x00568038
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x17001847 RID: 6215
	// (get) Token: 0x060136D0 RID: 79568 RVA: 0x00569E54 File Offset: 0x00568054
	public int PosIndex
	{
		get
		{
			return this.Config.PosIndex;
		}
	}

	// Token: 0x17001848 RID: 6216
	// (get) Token: 0x060136D1 RID: 79569 RVA: 0x00569E70 File Offset: 0x00568070
	public int QuestLine
	{
		get
		{
			return this.Config.QuestLine;
		}
	}

	// Token: 0x17001849 RID: 6217
	// (get) Token: 0x060136D2 RID: 79570 RVA: 0x00569E8C File Offset: 0x0056808C
	public int Successor
	{
		get
		{
			return this.Config.SuccessorNodeId;
		}
	}

	// Token: 0x1700184A RID: 6218
	// (get) Token: 0x060136D3 RID: 79571 RVA: 0x00569EA8 File Offset: 0x005680A8
	public string TitleId
	{
		get
		{
			return this.Config.Title;
		}
	}

	// Token: 0x1700184B RID: 6219
	// (get) Token: 0x060136D4 RID: 79572 RVA: 0x00569EC4 File Offset: 0x005680C4
	public string Desc
	{
		get
		{
			return this.Config.Desc;
		}
	}

	// Token: 0x1700184C RID: 6220
	// (get) Token: 0x060136D5 RID: 79573 RVA: 0x00569EE0 File Offset: 0x005680E0
	public string Brief
	{
		get
		{
			return this.Config.Brief;
		}
	}

	// Token: 0x1700184D RID: 6221
	// (get) Token: 0x060136D6 RID: 79574 RVA: 0x00569EFC File Offset: 0x005680FC
	public string ImageSmall
	{
		get
		{
			return this.ImageGetter(this.Config.ImageSmallMale, this.Config.ImageSmallFemale);
		}
	}

	// Token: 0x1700184E RID: 6222
	// (get) Token: 0x060136D7 RID: 79575 RVA: 0x00569F2C File Offset: 0x0056812C
	public string ImageLarge
	{
		get
		{
			return this.ImageGetter(this.Config.ImageLargeMale, this.Config.ImageLargeFemale);
		}
	}

	// Token: 0x1700184F RID: 6223
	// (get) Token: 0x060136D8 RID: 79576 RVA: 0x00569F5C File Offset: 0x0056815C
	public bool ShowOnceUnlock
	{
		get
		{
			return this.Config.ShowOnceUnlock;
		}
	}

	// Token: 0x17001850 RID: 6224
	// (get) Token: 0x060136D9 RID: 79577 RVA: 0x00569F77 File Offset: 0x00568177
	// (set) Token: 0x060136DA RID: 79578 RVA: 0x00569F7F File Offset: 0x0056817F
	public EQuestReviewNodeState State { get; private set; }

	// Token: 0x17001851 RID: 6225
	// (get) Token: 0x060136DB RID: 79579 RVA: 0x00569F88 File Offset: 0x00568188
	public EQuestReviewNodeLineType LineType
	{
		get
		{
			return EQuestReviewNodeLineType.Solid;
		}
	}

	// Token: 0x17001852 RID: 6226
	// (get) Token: 0x060136DC RID: 79580 RVA: 0x00569F8C File Offset: 0x0056818C
	public bool IsBranching
	{
		get
		{
			QuestReviewNodeData questReviewNodeDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewNodeDataById(this.Successor);
			return questReviewNodeDataById != null && this.QuestLine != questReviewNodeDataById.QuestLine;
		}
	}

	// Token: 0x17001853 RID: 6227
	// (get) Token: 0x060136DD RID: 79581 RVA: 0x00569FC0 File Offset: 0x005681C0
	// (set) Token: 0x060136DE RID: 79582 RVA: 0x00569FC8 File Offset: 0x005681C8
	public int Predecessor { get; set; }

	// Token: 0x17001854 RID: 6228
	// (get) Token: 0x060136DF RID: 79583 RVA: 0x00569FD4 File Offset: 0x005681D4
	// (set) Token: 0x060136E0 RID: 79584 RVA: 0x0056A004 File Offset: 0x00568204
	public bool IsFirstTimeShow
	{
		get
		{
			Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewNodeUnlockAnim, null);
			bool flag;
			return player == null || !player.TryGetValue(this.Id, out flag) || flag;
		}
		set
		{
			Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewNodeUnlockAnim, null);
			if (dictionary == null)
			{
				dictionary = new Dictionary<int, bool>();
			}
			dictionary[this.Id] = value;
			LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewNodeUnlockAnim, dictionary);
		}
	}

	// Token: 0x17001855 RID: 6229
	// (get) Token: 0x060136E1 RID: 79585 RVA: 0x0056A040 File Offset: 0x00568240
	// (set) Token: 0x060136E2 RID: 79586 RVA: 0x0056A070 File Offset: 0x00568270
	public bool HasRedDot
	{
		get
		{
			Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewNodeRedDot, null);
			bool flag;
			return player == null || !player.TryGetValue(this.Id, out flag) || flag;
		}
		set
		{
			Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewNodeRedDot, null);
			if (dictionary == null)
			{
				dictionary = new Dictionary<int, bool>();
			}
			dictionary[this.Id] = value;
			LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewNodeRedDot, dictionary);
		}
	}

	// Token: 0x060136E3 RID: 79587 RVA: 0x0056A0AB File Offset: 0x005682AB
	public void UpdateByServerData(QuestReviewNodeInfo data)
	{
		if (data.FinishCondition)
		{
			this.State = EQuestReviewNodeState.Finished;
			return;
		}
		if (data.InProgressCondition)
		{
			this.State = EQuestReviewNodeState.InProgress;
			return;
		}
		if (data.UnlockCondition)
		{
			this.State = EQuestReviewNodeState.Unlocked;
			return;
		}
		this.State = EQuestReviewNodeState.Locked;
	}

	// Token: 0x060136E4 RID: 79588 RVA: 0x0056A0E4 File Offset: 0x005682E4
	private string ImageGetter(string imageMale, string imageFemale)
	{
		if (string.IsNullOrEmpty(imageMale))
		{
			return imageFemale;
		}
		if (string.IsNullOrEmpty(imageFemale))
		{
			return imageMale;
		}
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		if (playerGender == EPlayerGender.Male)
		{
			return imageMale;
		}
		if (playerGender == EPlayerGender.Female)
		{
			return imageFemale;
		}
		return string.Empty;
	}

	// Token: 0x04009778 RID: 38776
	private readonly QuestReviewNode Config = config;
}
