using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002667 RID: 9831
public class QuestChapterItem : UiPanelBase
{
	// Token: 0x060135CA RID: 79306 RVA: 0x005635B1 File Offset: 0x005617B1
	[NullableContext(1)]
	public void Init(UUIItem uiItem, int inChapterId, int inQuestType, List<int> inQuestList, [Nullable(2)] TQuestItemSelectHandle toggleSelectHandle)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
		uiItem.SetActive(true, false);
		this.ToggleSelectHandle = toggleSelectHandle;
		this.QuestList = new List<QuestItem>();
		this.UpdateItem(inChapterId, inQuestType, inQuestList);
		this.UpdateToggle();
	}

	// Token: 0x060135CB RID: 79307 RVA: 0x005635EC File Offset: 0x005617EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x060135CC RID: 79308 RVA: 0x00563726 File Offset: 0x00561926
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x060135CD RID: 79309 RVA: 0x0056373C File Offset: 0x0056193C
	public void OnTick(float delta)
	{
		if (this.QuestList != null)
		{
			foreach (QuestItem questItem in this.QuestList)
			{
				questItem.OnTick(delta);
			}
		}
	}

	// Token: 0x060135CE RID: 79310 RVA: 0x00563798 File Offset: 0x00561998
	[NullableContext(1)]
	public void UpdateItem(int inChapterId, int inQuestType, List<int> inQuestList)
	{
		this.ChapterId = inChapterId;
		QuestMainType? questMainTypeConfig = ConfigBase<QuestNewConfig>.Instance.GetQuestMainTypeConfig(inQuestType);
		UUITexture texture = base.GetTexture(7);
		if (texture != null)
		{
			texture.SetColor(FColor.FromHex(((questMainTypeConfig != null) ? questMainTypeConfig.GetValueOrDefault().TypeColor : null) ?? ""));
		}
		if (!StringUtils.IsEmpty((questMainTypeConfig != null) ? questMainTypeConfig.GetValueOrDefault().QuestChapterBg : null))
		{
			this.SetSpriteByPath(questMainTypeConfig.Value.QuestChapterBg, base.GetSprite(5), false, null, null);
		}
		int num = 0;
		foreach (int inQuestId in inQuestList)
		{
			QuestItem questItem;
			if (num < this.QuestList.Count)
			{
				questItem = this.QuestList[num];
			}
			else
			{
				UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(2), base.GetItem(2).GetParentAsUIItem());
				questItem = new QuestItem(this.ToggleSelectHandle);
				questItem.SetRootActor(uuiitem.GetOwner(), true);
				this.QuestList.Add(questItem);
			}
			questItem.UpdateItem(inQuestId, inQuestType);
			num++;
		}
		for (int i = 0; i < this.QuestList.Count; i++)
		{
			this.QuestList[i].SetActiveItem(i < inQuestList.Count);
		}
		this.RefreshChapterItem();
	}

	// Token: 0x060135CF RID: 79311 RVA: 0x00563934 File Offset: 0x00561B34
	[NullableContext(2)]
	public QuestItem FindByQuestId(int questId)
	{
		if (this.QuestList == null)
		{
			return null;
		}
		foreach (QuestItem questItem in this.QuestList)
		{
			if (questItem.QuestId == questId)
			{
				return questItem;
			}
		}
		return null;
	}

	// Token: 0x060135D0 RID: 79312 RVA: 0x0056399C File Offset: 0x00561B9C
	private void RefreshChapterItem()
	{
		QuestChapter value = ConfigBase<QuestNewConfig>.Instance.GetChapterConfig(this.ChapterId).Value;
		string newText = ConfigMultiTextLang.GetLocalTextNew(value.ChapterName, null) ?? "";
		base.GetText(0).SetText(newText, true);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(value.ChapterNum, null);
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(value.SectionNum, null);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "QuestChapterText", new <>z__ReadOnlyArray<object>(new object[]
		{
			localTextNew,
			localTextNew2
		}));
	}

	// Token: 0x060135D1 RID: 79313 RVA: 0x00563A2D File Offset: 0x00561C2D
	private void UpdateToggle()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(4);
		extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
	}

	// Token: 0x060135D2 RID: 79314 RVA: 0x00563A57 File Offset: 0x00561C57
	private void OnToggleStateChange(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			base.GetItem(3).SetUIActive(true);
			return;
		}
		base.GetItem(3).SetUIActive(false);
	}

	// Token: 0x060135D3 RID: 79315 RVA: 0x00563A78 File Offset: 0x00561C78
	public void SetSelected(bool isSelected)
	{
		if (isSelected)
		{
			base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_Checked, true, false, false);
		}
		UUISprite sprite = base.GetSprite(6);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(isSelected);
	}

	// Token: 0x04009726 RID: 38694
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<QuestItem> QuestList;

	// Token: 0x04009727 RID: 38695
	private int ChapterId;

	// Token: 0x04009728 RID: 38696
	[Nullable(2)]
	private TQuestItemSelectHandle ToggleSelectHandle;

	// Token: 0x020089F9 RID: 35321
	private class EComponents
	{
		// Token: 0x0402E894 RID: 190612
		public const int TxtTitle = 0;

		// Token: 0x0402E895 RID: 190613
		public const int TxtChapter = 1;

		// Token: 0x0402E896 RID: 190614
		public const int UiItemQuestPrefab = 2;

		// Token: 0x0402E897 RID: 190615
		public const int UiQuestParent = 3;

		// Token: 0x0402E898 RID: 190616
		public const int ToggleItem = 4;

		// Token: 0x0402E899 RID: 190617
		public const int TitleBg = 5;

		// Token: 0x0402E89A RID: 190618
		public const int SelectOutline = 6;

		// Token: 0x0402E89B RID: 190619
		public const int TextureLine = 7;
	}
}
