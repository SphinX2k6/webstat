using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

// Token: 0x02001C87 RID: 7303
[NullableContext(2)]
[Nullable(0)]
public class MemoryDetailAttachItem : AutoAttachItem<int?>
{
	// Token: 0x0600D591 RID: 54673 RVA: 0x0038F5A9 File Offset: 0x0038D7A9
	public MemoryDetailAttachItem(AActor actor) : base(actor)
	{
	}

	// Token: 0x0600D592 RID: 54674 RVA: 0x0038F5B4 File Offset: 0x0038D7B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D593 RID: 54675 RVA: 0x0038F6C2 File Offset: 0x0038D8C2
	protected override UUIExtendToggle GetSelectToggle()
	{
		return base.GetExtendToggle(5);
	}

	// Token: 0x0600D594 RID: 54676 RVA: 0x0038F6CB File Offset: 0x0038D8CB
	protected override void OnSelectToggleClick()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFragmentTopicClick, this.CurrentId);
	}

	// Token: 0x0600D595 RID: 54677 RVA: 0x0038F6E3 File Offset: 0x0038D8E3
	private void TryInitLevelSequencePlayer()
	{
		if (this.LevelSequencePlayer == null)
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}
	}

	// Token: 0x0600D596 RID: 54678 RVA: 0x0038F700 File Offset: 0x0038D900
	protected override void OnRefreshItem(int? id)
	{
		this.TryInitLevelSequencePlayer();
		this.UnBindRedDot();
		this.CurrentId = id.GetValueOrDefault(-1);
		if (id == null)
		{
			this.CurrentData = null;
		}
		else
		{
			PhotoMemoryTopic? photoMemoryTopicById = ConfigBase<FragmentMemoryConfig>.Instance.GetPhotoMemoryTopicById(id.Value);
			this.CurrentData = photoMemoryTopicById;
		}
		this.RefreshFinishItem();
		this.RefreshDescText();
		this.RefreshNameText();
		this.RefreshSprite();
		this.BindRedDot(id);
	}

	// Token: 0x0600D597 RID: 54679 RVA: 0x0038F778 File Offset: 0x0038D978
	private void BindRedDot(int? id)
	{
		if (id != null)
		{
			this.RedDotName = new ERedDotName?(ERedDotName.FragmentMemoryTopic);
			if (this.RedDotName != null)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName.Value, base.GetItem(6), null, id.Value);
			}
			return;
		}
		UUIItem item = base.GetItem(6);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600D598 RID: 54680 RVA: 0x0038F7E4 File Offset: 0x0038D9E4
	private void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(6), (this.CurrentData != null) ? this.CurrentData.GetValueOrDefault().Id : -1);
			this.RedDotName = null;
		}
	}

	// Token: 0x0600D599 RID: 54681 RVA: 0x0038F848 File Offset: 0x0038DA48
	private void RefreshSprite()
	{
		if (this.CurrentId == -1)
		{
			this.SetSpriteByPath(ConfigBase<FragmentMemoryConfig>.Instance.GetTopicNotOpenTexturePath(), base.GetSprite(0), false, null, null);
			this.SetSpriteByPath(ConfigBase<FragmentMemoryConfig>.Instance.GetTopicNotOpenTextureLightPath(), base.GetSprite(1), false, null, null);
			return;
		}
		if (this.CurrentData != null)
		{
			this.SetSpriteByPath(this.CurrentData.Value.BgResource, base.GetSprite(0), false, null, null);
			this.SetSpriteByPath(this.CurrentData.Value.BgResourceLight, base.GetSprite(1), false, null, null);
		}
	}

	// Token: 0x0600D59A RID: 54682 RVA: 0x0038F908 File Offset: 0x0038DB08
	private void RefreshNameText()
	{
		if (this.CurrentId == -1 || this.CurrentData == null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "FragmentMemoryNotOpen", Array.Empty<object>());
			return;
		}
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew(this.CurrentData.Value.Title);
	}

	// Token: 0x0600D59B RID: 54683 RVA: 0x0038F96C File Offset: 0x0038DB6C
	private void RefreshDescText()
	{
		if (this.CurrentId == -1 || this.CurrentData == null)
		{
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetText("", true);
			return;
		}
		else
		{
			IReadOnlyList<PhotoMemoryCollect> photoMemoryCollectConfigListByTopicId = ConfigBase<FragmentMemoryConfig>.Instance.GetPhotoMemoryCollectConfigListByTopicId(this.CurrentData.Value.Id);
			if (photoMemoryCollectConfigListByTopicId == null)
			{
				return;
			}
			int num = 0;
			foreach (PhotoMemoryCollect photoMemoryCollect in photoMemoryCollectConfigListByTopicId)
			{
				FragmentMemoryCollectData collectDataById = ModelBase<FragmentMemoryModel>.Instance.GetCollectDataById(photoMemoryCollect.Id);
				if (collectDataById != null && collectDataById.GetIfUnlock())
				{
					num++;
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "FragmentMemoryCollectProgress", new <>z__ReadOnlyArray<object>(new object[]
			{
				num.ToString(),
				photoMemoryCollectConfigListByTopicId.Count.ToString()
			}));
			return;
		}
	}

	// Token: 0x0600D59C RID: 54684 RVA: 0x0038FA64 File Offset: 0x0038DC64
	private void RefreshFinishItem()
	{
		if (this.CurrentData == null)
		{
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			FragmentMemoryTopicData topicDataById = ModelBase<FragmentMemoryModel>.Instance.GetTopicDataById(this.CurrentData.Value.Id);
			bool uiactive = false;
			if (topicDataById != null && topicDataById.GetAllCollectState())
			{
				uiactive = true;
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(uiactive);
			return;
		}
	}

	// Token: 0x0600D59D RID: 54685 RVA: 0x0038FAD0 File Offset: 0x0038DCD0
	public override void OnSelect()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 != null)
		{
			levelSequencePlayer2.PlaySequencePurely("Select", false, false, null, null, false);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFragmentTopicSelect, this.CurrentId);
		this.CurrentSelectState = true;
	}

	// Token: 0x0600D59E RID: 54686 RVA: 0x0038FB30 File Offset: 0x0038DD30
	protected override void OnUnSelect()
	{
		if (this.CurrentSelectState)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlaySequencePurely("Unselect", false, false, null, null, false);
			}
		}
		this.CurrentSelectState = false;
	}

	// Token: 0x0600D59F RID: 54687 RVA: 0x0038FB82 File Offset: 0x0038DD82
	protected override void OnBeforeDestroy()
	{
		this.UnBindRedDot();
	}

	// Token: 0x0600D5A0 RID: 54688 RVA: 0x0038FB8A File Offset: 0x0038DD8A
	protected override void OnMoveItem()
	{
	}

	// Token: 0x04006555 RID: 25941
	private PhotoMemoryTopic? CurrentData;

	// Token: 0x04006556 RID: 25942
	private int CurrentId;

	// Token: 0x04006557 RID: 25943
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04006558 RID: 25944
	private bool CurrentSelectState;

	// Token: 0x04006559 RID: 25945
	private ERedDotName? RedDotName;

	// Token: 0x02007FD1 RID: 32721
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B7FE RID: 178174
		public const int MemorySprite = 0;

		// Token: 0x0402B7FF RID: 178175
		public const int MemorySpriteLight = 1;

		// Token: 0x0402B800 RID: 178176
		public const int NameText = 2;

		// Token: 0x0402B801 RID: 178177
		public const int DescText = 3;

		// Token: 0x0402B802 RID: 178178
		public const int FinishItem = 4;

		// Token: 0x0402B803 RID: 178179
		public const int Toggle = 5;

		// Token: 0x0402B804 RID: 178180
		public const int RedDot = 6;
	}
}
