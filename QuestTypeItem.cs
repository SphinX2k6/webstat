using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200266B RID: 9835
[NullableContext(2)]
[Nullable(0)]
public class QuestTypeItem : UiPanelBase
{
	// Token: 0x060135FD RID: 79357 RVA: 0x00564D74 File Offset: 0x00562F74
	[NullableContext(1)]
	public void Init(UUIItem uiItem, int inQuestType, TQuestItemSelectHandle selectedHandle)
	{
		this.QuestType = inQuestType;
		this.ToggleSelectHandle = selectedHandle;
		uiItem.SetUIActive(true);
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x060135FE RID: 79358 RVA: 0x00564D98 File Offset: 0x00562F98
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.HandleTypeButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060135FF RID: 79359 RVA: 0x00564F04 File Offset: 0x00563104
	protected override void OnStart()
	{
		base.GetItem(4).SetUIActive(true);
		QuestMainType? questMainTypeConfig = ConfigBase<QuestNewConfig>.Instance.GetQuestMainTypeConfig(this.QuestType);
		if (!StringUtils.IsEmpty((questMainTypeConfig != null) ? questMainTypeConfig.GetValueOrDefault().TypeColor : null))
		{
			base.GetSprite(7).SetColor(FColor.FromHex(((questMainTypeConfig != null) ? questMainTypeConfig.GetValueOrDefault().TypeColor : null) ?? ""));
		}
		base.GetText(2).SetText(ConfigBase<QuestNewConfig>.Instance.GetQuestMainTypeName(this.QuestType), true);
		string questTypeTitleIcon = questMainTypeConfig.Value.QuestTypeTitleIcon;
		if (questTypeTitleIcon == null || questTypeTitleIcon.Length != 0)
		{
			UUISprite sprite = base.GetSprite(3);
			this.SetSpriteByPath(questTypeTitleIcon, sprite, false, null, null);
		}
		this.QuestList = new List<QuestItem>();
		this.ChapterList = new List<QuestChapterItem>();
		this.UpdateList();
	}

	// Token: 0x06013600 RID: 79360 RVA: 0x00564FFC File Offset: 0x005631FC
	public void OnTick(float delta)
	{
		if (this.ChapterList != null)
		{
			foreach (QuestChapterItem questChapterItem in this.ChapterList)
			{
				questChapterItem.OnTick(delta);
			}
		}
		if (this.QuestList != null)
		{
			foreach (QuestItem questItem in this.QuestList)
			{
				questItem.OnTick(delta);
			}
		}
	}

	// Token: 0x06013601 RID: 79361 RVA: 0x005650A0 File Offset: 0x005632A0
	public void UpdateList()
	{
		this.GetQuestItems();
		List<QuestItemData> questItemList = this.QuestItemList;
		List<IQuestChapterData> questChapterItemList = this.QuestChapterItemList;
		int num = 0;
		foreach (IQuestChapterData questChapterData in questChapterItemList)
		{
			if (num < this.ChapterList.Count)
			{
				QuestChapterItem questChapterItem = this.ChapterList[num];
				questChapterItem.UpdateItem(questChapterData.ChapterId, questChapterData.QuestType, questChapterData.QuestList);
			}
			else
			{
				UUIItem uiItem = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(6), base.GetItem(1));
				QuestChapterItem questChapterItem = new QuestChapterItem();
				questChapterItem.Init(uiItem, questChapterData.ChapterId, questChapterData.QuestType, questChapterData.QuestList, this.ToggleSelectHandle);
				this.ChapterList.Add(questChapterItem);
			}
			num++;
		}
		for (int i = 0; i < this.ChapterList.Count; i++)
		{
			this.ChapterList[i].SetActive(i < questChapterItemList.Count);
		}
		num = 0;
		foreach (QuestItemData questItemData in questItemList)
		{
			QuestItem questItem;
			if (num < this.QuestList.Count)
			{
				questItem = this.QuestList[num];
			}
			else
			{
				UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(5), base.GetItem(1));
				questItem = new QuestItem(this.ToggleSelectHandle);
				questItem.SetRootActor(uuiitem.GetOwner(), true);
				this.QuestList.Add(questItem);
			}
			questItem.UpdateItem(questItemData.QuestId, questItemData.QuestType);
			num++;
		}
		for (int j = 0; j < this.QuestList.Count; j++)
		{
			this.QuestList[j].SetActiveItem(j < questItemList.Count);
		}
	}

	// Token: 0x06013602 RID: 79362 RVA: 0x005652C0 File Offset: 0x005634C0
	public void UpdateItem(int questId)
	{
		QuestItem questItem = this.QuestList.Find((QuestItem value) => value.QuestId == questId);
		if (questItem == null)
		{
			foreach (QuestChapterItem questChapterItem in this.ChapterList)
			{
				QuestItem questItem2 = questChapterItem.FindByQuestId(questId);
				if (questItem2 != null)
				{
					questItem = questItem2;
					break;
				}
			}
		}
		if (questItem == null)
		{
			return;
		}
		questItem.UpdateItem(questItem.QuestId, questItem.QuestType);
	}

	// Token: 0x06013603 RID: 79363 RVA: 0x0056535C File Offset: 0x0056355C
	public void UpdateAllItem()
	{
		foreach (QuestChapterItem questChapterItem in this.ChapterList)
		{
			foreach (QuestItem questItem in (questChapterItem.QuestList ?? new List<QuestItem>()))
			{
				questItem.UpdateItem(questItem.QuestId, questItem.QuestType);
			}
		}
	}

	// Token: 0x06013604 RID: 79364 RVA: 0x005653FC File Offset: 0x005635FC
	public void OnSelect(int? inQuestId)
	{
		int num;
		if (inQuestId == null || inQuestId.Value == 0)
		{
			QuestItem defaultItem = this.GetDefaultItem();
			num = ((defaultItem != null) ? defaultItem.QuestId : 0);
		}
		else
		{
			num = inQuestId.Value;
		}
		foreach (QuestItem questItem in this.QuestList)
		{
			questItem.SetSelected(questItem.QuestId == num);
			questItem.SetNotAllowNoneSelect();
		}
		foreach (QuestChapterItem questChapterItem in this.ChapterList)
		{
			bool selected = false;
			foreach (QuestItem questItem2 in questChapterItem.QuestList)
			{
				questItem2.SetSelected(questItem2.QuestId == num);
				questItem2.SetNotAllowNoneSelect();
				if (questItem2.QuestId == num)
				{
					selected = true;
				}
			}
			questChapterItem.SetSelected(selected);
		}
	}

	// Token: 0x06013605 RID: 79365 RVA: 0x0056552C File Offset: 0x0056372C
	public QuestItem GetDefaultItem()
	{
		if (this.QuestList.Count == 0 && this.ChapterList.Count == 0)
		{
			return null;
		}
		if (this.ChapterList.Count != 0)
		{
			return this.ChapterList[0].QuestList[0];
		}
		return this.QuestList[0];
	}

	// Token: 0x06013606 RID: 79366 RVA: 0x00565586 File Offset: 0x00563786
	public bool IsQuestEmpty()
	{
		List<QuestItemData> questItemList = this.QuestItemList;
		if (questItemList != null && questItemList.Count == 0)
		{
			List<QuestChapterItem> chapterList = this.ChapterList;
			return chapterList != null && chapterList.Count == 0;
		}
		return false;
	}

	// Token: 0x06013607 RID: 79367 RVA: 0x005655B8 File Offset: 0x005637B8
	public void UpdateListTrackState()
	{
		foreach (QuestItem questItem in this.QuestList)
		{
			questItem.UpdateTrackIconActive();
			global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(questItem.QuestId);
			if (quest != null)
			{
				questItem.UpdateFunctionIcon(quest);
			}
		}
		foreach (QuestChapterItem questChapterItem in this.ChapterList)
		{
			foreach (QuestItem questItem2 in questChapterItem.QuestList)
			{
				questItem2.UpdateTrackIconActive();
				global::Quest quest2 = ModelBase<QuestNewModel>.Instance.GetQuest(questItem2.QuestId);
				if (quest2 != null)
				{
					questItem2.UpdateFunctionIcon(quest2);
				}
			}
		}
	}

	// Token: 0x06013608 RID: 79368 RVA: 0x005656C4 File Offset: 0x005638C4
	public QuestItem GetQuestItem(int questId)
	{
		Predicate<QuestItem> <>9__1;
		foreach (QuestChapterItem questChapterItem in this.ChapterList)
		{
			List<QuestItem> questList = questChapterItem.QuestList;
			Predicate<QuestItem> match;
			if ((match = <>9__1) == null)
			{
				match = (<>9__1 = ((QuestItem value) => value.QuestId == questId));
			}
			QuestItem questItem = questList.Find(match);
			if (questItem != null)
			{
				return questItem;
			}
		}
		return this.QuestList.Find((QuestItem value) => value.QuestId == questId);
	}

	// Token: 0x06013609 RID: 79369 RVA: 0x00565768 File Offset: 0x00563968
	private void GetQuestItems()
	{
		this.QuestItemList = new List<QuestItemData>();
		this.QuestChapterItemList = new List<IQuestChapterData>();
		foreach (QuestType questType in ConfigBase<QuestNewConfig>.Instance.GetQuesTypesByMainType(this.QuestType))
		{
			List<global::Quest> questsByType = ModelBase<QuestNewModel>.Instance.GetQuestsByType(questType.Id);
			if (questsByType.Count != 0)
			{
				questsByType.Sort(new Comparison<global::Quest>(ModelBase<QuestNewModel>.Instance.SortQuestInView));
				foreach (global::Quest quest in questsByType)
				{
					if (quest.CanShowInUiPanel())
					{
						int? chapterId = quest.ChapterId;
						if (chapterId != null && chapterId.GetValueOrDefault() != 0)
						{
							this.PushChapterItemList(quest.ChapterId.Value, (int)quest.Type, quest.Id);
						}
						else
						{
							this.QuestItemList.Add(new QuestItemData(quest.Id, (int)quest.Type));
						}
					}
				}
			}
		}
	}

	// Token: 0x0601360A RID: 79370 RVA: 0x005658A8 File Offset: 0x00563AA8
	private void PushChapterItemList(int chapterId, int questType, int questId)
	{
		foreach (IQuestChapterData questChapterData in this.QuestChapterItemList)
		{
			if (questChapterData.ChapterId == chapterId)
			{
				questChapterData.QuestList.Add(questId);
				return;
			}
		}
		this.QuestChapterItemList.Add(new QuestChapterData
		{
			ChapterId = chapterId,
			QuestType = questType,
			QuestList = new List<int>
			{
				questId
			}
		});
	}

	// Token: 0x0601360B RID: 79371 RVA: 0x0056593C File Offset: 0x00563B3C
	private void HandleTypeButton()
	{
		UUIItem item = base.GetItem(1);
		item.SetUIActive(!item.bIsUIActive);
	}

	// Token: 0x04009734 RID: 38708
	private TQuestItemSelectHandle ToggleSelectHandle;

	// Token: 0x04009735 RID: 38709
	public int QuestType;

	// Token: 0x04009736 RID: 38710
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<QuestItem> QuestList;

	// Token: 0x04009737 RID: 38711
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<QuestChapterItem> ChapterList;

	// Token: 0x04009738 RID: 38712
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<QuestItemData> QuestItemList;

	// Token: 0x04009739 RID: 38713
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<IQuestChapterData> QuestChapterItemList;

	// Token: 0x020089FE RID: 35326
	[NullableContext(0)]
	private class EQuestListItemComponent
	{
		// Token: 0x0402E8B7 RID: 190647
		public const int TypeButton = 0;

		// Token: 0x0402E8B8 RID: 190648
		public const int PanelQuestList = 1;

		// Token: 0x0402E8B9 RID: 190649
		public const int ListItemName = 2;

		// Token: 0x0402E8BA RID: 190650
		public const int TypeIcon = 3;

		// Token: 0x0402E8BB RID: 190651
		public const int TitleNode = 4;

		// Token: 0x0402E8BC RID: 190652
		public const int QuestItem = 5;

		// Token: 0x0402E8BD RID: 190653
		public const int ChapterItem = 6;

		// Token: 0x0402E8BE RID: 190654
		public const int TitleBg = 7;
	}
}
