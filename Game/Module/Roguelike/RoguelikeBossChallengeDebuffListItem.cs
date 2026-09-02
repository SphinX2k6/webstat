using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005141 RID: 20801
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeBossChallengeDebuffListItem : UiPanelBase
	{
		// Token: 0x060358B9 RID: 219321 RVA: 0x00D711B4 File Offset: 0x00D6F3B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnTogDescModeChanged));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060358BA RID: 219322 RVA: 0x00D7129C File Offset: 0x00D6F49C
		protected override void OnStart()
		{
			this.DebuffScrollView = new GenericScrollViewNew<RoguelikeBossChallengeDebuffItem, RoguelikeBossChallengeBuffData>(base.GetScrollViewWithScrollbar(1), new Func<RoguelikeBossChallengeDebuffItem>(this.CreateBossDebuffItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, null);
			this.RefreshToggleState();
		}

		// Token: 0x060358BB RID: 219323 RVA: 0x00D712D8 File Offset: 0x00D6F4D8
		public void RefreshDebuffList(List<RoguelikeBossChallengeBuffData> dataList, int currentBossId)
		{
			this.CurrentDataList = dataList;
			this.UpdateDataDescMode();
			GenericScrollViewNew<RoguelikeBossChallengeDebuffItem, RoguelikeBossChallengeBuffData> debuffScrollView = this.DebuffScrollView;
			if (debuffScrollView == null)
			{
				return;
			}
			debuffScrollView.RefreshByData(dataList, delegate
			{
				this.OnDebuffListRefreshed(currentBossId);
			}, false);
		}

		// Token: 0x060358BC RID: 219324 RVA: 0x00D71324 File Offset: 0x00D6F524
		public void RefreshToggleState()
		{
			EToggleState state = (ModelBase<RoguelikeModel>.Instance.GetDescModel() == EDescModel.SIMPLE) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, true, false, false);
		}

		// Token: 0x060358BD RID: 219325 RVA: 0x00D71358 File Offset: 0x00D6F558
		public void OnDescModelChange()
		{
			this.RefreshToggleState();
			this.UpdateDataDescMode();
			GenericScrollViewNew<RoguelikeBossChallengeDebuffItem, RoguelikeBossChallengeBuffData> debuffScrollView = this.DebuffScrollView;
			if (debuffScrollView == null)
			{
				return;
			}
			debuffScrollView.RefreshByData(this.CurrentDataList, null, false);
		}

		// Token: 0x060358BE RID: 219326 RVA: 0x00D7137E File Offset: 0x00D6F57E
		protected override void OnBeforeDestroy()
		{
			this.DebuffScrollView = null;
			this.CurrentDataList = new List<RoguelikeBossChallengeBuffData>();
		}

		// Token: 0x060358BF RID: 219327 RVA: 0x00D71394 File Offset: 0x00D6F594
		private void UpdateDataDescMode()
		{
			EDescModel descModel = ModelBase<RoguelikeModel>.Instance.GetDescModel();
			foreach (RoguelikeBossChallengeBuffData roguelikeBossChallengeBuffData in this.CurrentDataList)
			{
				roguelikeBossChallengeBuffData.DescMode = descModel;
			}
		}

		// Token: 0x060358C0 RID: 219328 RVA: 0x00D713F0 File Offset: 0x00D6F5F0
		private void OnDebuffListRefreshed(int currentBossId)
		{
			if (this.DebuffScrollView == null)
			{
				return;
			}
			this.DebuffScrollView.ScrollToTop(0);
			this.PlayCurrentBossStartSequence(this.DebuffScrollView.GetScrollItemList(), currentBossId);
		}

		// Token: 0x060358C1 RID: 219329 RVA: 0x00D71420 File Offset: 0x00D6F620
		private void PlayCurrentBossStartSequence(List<RoguelikeBossChallengeDebuffItem> itemList, int currentBossId)
		{
			if (currentBossId == 0)
			{
				return;
			}
			foreach (RoguelikeBossChallengeDebuffItem roguelikeBossChallengeDebuffItem in itemList)
			{
				if (roguelikeBossChallengeDebuffItem.IsCurrentBossBuff(currentBossId))
				{
					roguelikeBossChallengeDebuffItem.PlayStartSequence();
				}
			}
		}

		// Token: 0x060358C2 RID: 219330 RVA: 0x00D7147C File Offset: 0x00D6F67C
		private void OnTogDescModeChanged(EToggleState state)
		{
			ModelBase<RoguelikeModel>.Instance.UpdateDescModel(state == EToggleState.ETT_Checked);
		}

		// Token: 0x060358C3 RID: 219331 RVA: 0x00D7148C File Offset: 0x00D6F68C
		private RoguelikeBossChallengeDebuffItem CreateBossDebuffItem()
		{
			return new RoguelikeBossChallengeDebuffItem();
		}

		// Token: 0x060358C4 RID: 219332 RVA: 0x00D71493 File Offset: 0x00D6F693
		[NullableContext(2)]
		public RoguelikeBossChallengeDebuffItem GetUiItemByIndex(int index)
		{
			if (this.DebuffScrollView == null)
			{
				return null;
			}
			GenericLayout<RoguelikeBossChallengeDebuffItem, RoguelikeBossChallengeBuffData> genericLayout = this.DebuffScrollView.GetGenericLayout();
			if (genericLayout != null && genericLayout.IsLock)
			{
				return null;
			}
			return this.DebuffScrollView.GetScrollItemByIndex(index);
		}

		// Token: 0x0401EC36 RID: 126006
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RoguelikeBossChallengeDebuffItem, RoguelikeBossChallengeBuffData> DebuffScrollView;

		// Token: 0x0401EC37 RID: 126007
		private List<RoguelikeBossChallengeBuffData> CurrentDataList = new List<RoguelikeBossChallengeBuffData>();

		// Token: 0x0200B0E0 RID: 45280
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036DE7 RID: 224743
			public const int TxtTitle = 0;

			// Token: 0x04036DE8 RID: 224744
			public const int DebuffItemScroll = 1;

			// Token: 0x04036DE9 RID: 224745
			public const int UiItemBossDebuffItem = 2;

			// Token: 0x04036DEA RID: 224746
			public const int TogDescMode = 3;
		}
	}
}
