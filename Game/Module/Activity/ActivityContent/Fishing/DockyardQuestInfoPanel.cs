using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067CB RID: 26571
	public class DockyardQuestInfoPanel : UiPanelBase, IDockyardLeftTipsInterface
	{
		// Token: 0x1700A116 RID: 41238
		// (get) Token: 0x06042497 RID: 271511 RVA: 0x01100A95 File Offset: 0x010FEC95
		// (set) Token: 0x06042498 RID: 271512 RVA: 0x01100A9D File Offset: 0x010FEC9D
		public bool LockState { get; set; }

		// Token: 0x06042499 RID: 271513 RVA: 0x01100AA8 File Offset: 0x010FECA8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnQuestClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnExitClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604249A RID: 271514 RVA: 0x01100BD4 File Offset: 0x010FEDD4
		protected override void OnStart()
		{
			this.ListLayout = new GenericLayout<QuestInfoItem, IFishingDockQuestChildItemData>(base.GetVerticalLayout(1), new Func<QuestInfoItem>(this.CreateItem), null, false, true);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(delegate(string eventName)
			{
				if (eventName == "Hide")
				{
					this.SetActive(false);
				}
			}, false);
		}

		// Token: 0x0604249B RID: 271515 RVA: 0x01100C2B File Offset: 0x010FEE2B
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FishingRefreshBackpackData, new Action(this.RefreshList));
			this.Refresh();
		}

		// Token: 0x0604249C RID: 271516 RVA: 0x01100C4F File Offset: 0x010FEE4F
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingRefreshBackpackData, new Action(this.RefreshList));
		}

		// Token: 0x0604249D RID: 271517 RVA: 0x01100C6D File Offset: 0x010FEE6D
		[NullableContext(1)]
		private QuestInfoItem CreateItem()
		{
			return new QuestInfoItem();
		}

		// Token: 0x0604249E RID: 271518 RVA: 0x01100C74 File Offset: 0x010FEE74
		public void SetPanelVisible(bool bVisible)
		{
			if (this.LockState)
			{
				return;
			}
			if (bVisible)
			{
				this.LevelSequencePlayer.StopCurrentSequence(true, true);
				this.LevelSequencePlayer.PlaySequencePurely("Show", false, false, null, null, false);
				this.SetActive(true);
				return;
			}
			this.LevelSequencePlayer.StopCurrentSequence(true, true);
			this.LevelSequencePlayer.PlaySequencePurely("Hide", false, false, null, null, false);
		}

		// Token: 0x0604249F RID: 271519 RVA: 0x01100CE9 File Offset: 0x010FEEE9
		public void Refresh()
		{
			this.RefreshList();
		}

		// Token: 0x060424A0 RID: 271520 RVA: 0x01100CF4 File Offset: 0x010FEEF4
		private void RefreshList()
		{
			if (ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust == 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Fishing_NotTraceEntrustInShip", Array.Empty<object>());
				base.GetVerticalLayout(1).RootUIComp.Get().SetUIActive(false);
				return;
			}
			FishingEntrust? fishingEntrust = ConfigBase<FishingConfig>.Instance.GetFishingEntrust(ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust);
			if (fishingEntrust == null)
			{
				return;
			}
			Dictionary<int, int> dictionary = fishingEntrust.Value.EntrustTarget();
			List<IFishingDockQuestChildItemData> list = new List<IFishingDockQuestChildItemData>();
			Dictionary<int, string> dictionary2 = fishingEntrust.Value.TargetDesText();
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int itemCountByItemId = ModelBase<DockyardModel>.Instance.GetItemCountByItemId(keyValuePair.Key);
				string text;
				FishingDockQuestChildItemData item = new FishingDockQuestChildItemData
				{
					MaxCount = keyValuePair.Value,
					CurrentCount = itemCountByItemId,
					DesText = (dictionary2.TryGetValue(keyValuePair.Key, out text) ? text : string.Empty)
				};
				list.Add(item);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), fishingEntrust.Value.Name, Array.Empty<object>());
			this.ListLayout.RefreshByData(list, null, false);
			base.GetVerticalLayout(1).RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x060424A1 RID: 271521 RVA: 0x01100E6C File Offset: 0x010FF06C
		public void SetButtonQuestVisible(bool bVisible)
		{
			base.GetButton(3).RootUIComp.Get().SetUIActive(bVisible);
		}

		// Token: 0x060424A2 RID: 271522 RVA: 0x01100E94 File Offset: 0x010FF094
		public void SetButtonExitVisible(bool bVisible)
		{
			base.GetButton(4).RootUIComp.Get().SetUIActive(bVisible);
		}

		// Token: 0x060424A3 RID: 271523 RVA: 0x01100EBB File Offset: 0x010FF0BB
		private void OnQuestClick()
		{
			ControllerBase<FishingController>.Instance.OpenFishingQuestView();
		}

		// Token: 0x060424A4 RID: 271524 RVA: 0x01100EC7 File Offset: 0x010FF0C7
		private void OnExitClick()
		{
			Action exitFunc = this.ExitFunc;
			if (exitFunc == null)
			{
				return;
			}
			exitFunc();
		}

		// Token: 0x04024E82 RID: 151170
		[Nullable(1)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04024E83 RID: 151171
		[Nullable(1)]
		protected GenericLayout<QuestInfoItem, IFishingDockQuestChildItemData> ListLayout;

		// Token: 0x04024E84 RID: 151172
		[Nullable(2)]
		public Action ExitFunc;

		// Token: 0x0200C812 RID: 51218
		private class EComponentDefine
		{
			// Token: 0x0403D927 RID: 252199
			public const int TxtTitle = 0;

			// Token: 0x0403D928 RID: 252200
			public const int ListLayout = 1;

			// Token: 0x0403D929 RID: 252201
			public const int ListItem = 2;

			// Token: 0x0403D92A RID: 252202
			public const int ButtonQuest = 3;

			// Token: 0x0403D92B RID: 252203
			public const int ButtonExit = 4;
		}
	}
}
