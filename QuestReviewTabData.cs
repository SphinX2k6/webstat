using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;

// Token: 0x0200267A RID: 9850
[NullableContext(1)]
[Nullable(0)]
public class QuestReviewTabData
{
	// Token: 0x060136E5 RID: 79589 RVA: 0x0056A120 File Offset: 0x00568320
	public QuestReviewTabData(QuestReviewTab config)
	{
	}

	// Token: 0x17001856 RID: 6230
	// (get) Token: 0x060136E6 RID: 79590 RVA: 0x0056A130 File Offset: 0x00568330
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x17001857 RID: 6231
	// (get) Token: 0x060136E7 RID: 79591 RVA: 0x0056A14C File Offset: 0x0056834C
	public int QuestTree
	{
		get
		{
			return this.Config.QuestTree;
		}
	}

	// Token: 0x17001858 RID: 6232
	// (get) Token: 0x060136E8 RID: 79592 RVA: 0x0056A168 File Offset: 0x00568368
	public string NameId
	{
		get
		{
			return this.Config.TabName;
		}
	}

	// Token: 0x17001859 RID: 6233
	// (get) Token: 0x060136E9 RID: 79593 RVA: 0x0056A183 File Offset: 0x00568383
	public bool IsUnlocked
	{
		get
		{
			return this.IsUnlockedInternal;
		}
	}

	// Token: 0x1700185A RID: 6234
	// (get) Token: 0x060136EA RID: 79594 RVA: 0x0056A18B File Offset: 0x0056838B
	// (set) Token: 0x060136EB RID: 79595 RVA: 0x0056A193 File Offset: 0x00568393
	public bool IsSelected { get; set; }

	// Token: 0x1700185B RID: 6235
	// (get) Token: 0x060136EC RID: 79596 RVA: 0x0056A19C File Offset: 0x0056839C
	// (set) Token: 0x060136ED RID: 79597 RVA: 0x0056A1CC File Offset: 0x005683CC
	public bool IsFirstTimeShow
	{
		get
		{
			Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewTabUnlockAnim, null);
			bool flag;
			return player == null || !player.TryGetValue(this.Id, out flag) || flag;
		}
		set
		{
			Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewTabUnlockAnim, null);
			if (dictionary == null)
			{
				dictionary = new Dictionary<int, bool>();
			}
			dictionary[this.Id] = value;
			LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.QuestReviewTabUnlockAnim, dictionary);
		}
	}

	// Token: 0x060136EE RID: 79598 RVA: 0x0056A207 File Offset: 0x00568407
	public void UpdateByServerData(QuestReviewTabInfo data)
	{
		if (data.UnlockCondition)
		{
			this.IsUnlockedInternal = true;
		}
	}

	// Token: 0x0400977B RID: 38779
	private bool IsUnlockedInternal;

	// Token: 0x0400977C RID: 38780
	private readonly QuestReviewTab Config = config;
}
