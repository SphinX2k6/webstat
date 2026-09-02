using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069BA RID: 27066
	[NullableContext(1)]
	[Nullable(0)]
	public class BossRushBuffSelectView : UiTabViewBase
	{
		// Token: 0x060431BE RID: 274878 RVA: 0x0113C988 File Offset: 0x0113AB88
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060431BF RID: 274879 RVA: 0x0113CA70 File Offset: 0x0113AC70
		protected override void OnStart()
		{
			this.LoopScrollView = new LoopScrollView<BuffGridItem, BuffGridItemData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<BuffGridItem>(this.CreateLoopItem), false);
			base.GetItem(1).SetUIActive(false);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBossRushBuffViewOpened);
		}

		// Token: 0x060431C0 RID: 274880 RVA: 0x0113CADB File Offset: 0x0113ACDB
		private BuffGridItem CreateLoopItem()
		{
			return new BuffGridItem();
		}

		// Token: 0x060431C1 RID: 274881 RVA: 0x0113CAE4 File Offset: 0x0113ACE4
		private void OnClickConfirmButton()
		{
			List<BossRushBuffInfo> list = new List<BossRushBuffInfo>();
			int num = 1;
			foreach (BuffScrollItemData buffScrollItemData in this.CurrentSelectableBuffData)
			{
				if (buffScrollItemData.Selected)
				{
					BossRushBuffInfo bossRushBuffInfo = new BossRushBuffInfo();
					bossRushBuffInfo.BuffId = buffScrollItemData.BuffId;
					bossRushBuffInfo.ChangeAble = true;
					bossRushBuffInfo.State = buffScrollItemData.State;
					bossRushBuffInfo.Slot = num;
					num++;
					list.Add(bossRushBuffInfo);
				}
			}
			int currentSelectCount = this.GetCurrentSelectCount();
			if (currentSelectCount < this.CurrentTeamInfo.GetBuffMaxCount())
			{
				for (int i = currentSelectCount; i < this.CurrentTeamInfo.GetBuffMaxCount(); i++)
				{
					BossRushBuffInfo bossRushBuffInfo2 = (ModelBase<BossRushModel>.Instance.CurrentSelectBuffTabName == EBuffTabName.Normal) ? this.CurrentTeamInfo.GetIndexPrepareSelectBuff(i) : this.CurrentTeamInfo.GetIndexPrepareSelectScoreBuff(i);
					BossRushBuffInfo bossRushBuffInfo3 = new BossRushBuffInfo();
					bossRushBuffInfo3.BuffId = 0;
					bossRushBuffInfo3.ChangeAble = bossRushBuffInfo2.ChangeAble;
					bossRushBuffInfo3.State = ((bossRushBuffInfo3.BuffId == 0 && bossRushBuffInfo2.State == BossRushBuffSelectionStatus.BuffSelected) ? BossRushBuffSelectionStatus.BuffEmpty : bossRushBuffInfo2.State);
					bossRushBuffInfo3.Slot = num;
					num++;
					list.Add(bossRushBuffInfo3);
				}
			}
			if (ModelBase<BossRushModel>.Instance.CurrentSelectBuffTabName == EBuffTabName.Normal)
			{
				this.CurrentTeamInfo.SetPrepareSelectBuff(list.ToArray());
			}
			else if (ModelBase<BossRushModel>.Instance.CurrentSelectBuffTabName == EBuffTabName.Powerful)
			{
				this.CurrentTeamInfo.SetPrepareSelectScoreBuff(list.ToArray());
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnChangeBossRushBuff);
			Singleton<EventSystem>.Instance.Emit<EUiTabViewName>(EEventName.RequestChangeBossRushView, EUiTabViewName.BossRushLevelDetailView);
		}

		// Token: 0x060431C2 RID: 274882 RVA: 0x0113CC9C File Offset: 0x0113AE9C
		protected override void OnBeforeShow()
		{
			this.TryShowAnimation();
			this.CurrentTeamInfo = ModelBase<BossRushModel>.Instance.CurrentTeamInfo;
			this.CurrentSelectableBuffData = new List<BuffScrollItemData>();
			using (List<BossRushBuffInfo>.Enumerator enumerator = this.CurrentTeamInfo.GetOptionBuff().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BossRushBuffInfo buffData = enumerator.Current;
					BuffScrollItemData buffScrollItemData = new BuffScrollItemData();
					buffScrollItemData.BuffId = buffData.BuffId;
					buffScrollItemData.State = buffData.State;
					buffScrollItemData.Selected = (((ModelBase<BossRushModel>.Instance.CurrentSelectBuffTabName == EBuffTabName.Normal) ? this.CurrentTeamInfo.GetPrepareSelectBuff().FindIndex((BossRushBuffInfo value) => value.BuffId == buffData.BuffId) : this.CurrentTeamInfo.GetPrepareSelectScoreBuff().FindIndex((BossRushBuffInfo value) => value.BuffId == buffData.BuffId)) != -1);
					buffScrollItemData.SelectedAtStart = buffScrollItemData.Selected;
					buffScrollItemData.OnClickToggle = new Action<BuffScrollItemData>(this.OnClickToggle);
					buffScrollItemData.CheckClickAble = new Func<BuffScrollItemData, bool>(this.CheckClickAble);
					this.CurrentSelectableBuffData.Add(buffScrollItemData);
				}
			}
			this.RefreshScrollView(true);
			this.RefreshCountText();
			this.IsBuffMaxCountOne = (this.CurrentTeamInfo.LevelInfo.GetMaxBuffCount() == 1);
		}

		// Token: 0x060431C3 RID: 274883 RVA: 0x0113CDFC File Offset: 0x0113AFFC
		private void TryShowAnimation()
		{
			string sequenceName = "Start";
			if (ModelBase<BossRushModel>.Instance.PlayBackAnimation)
			{
				sequenceName = "ShowView";
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
			}
			ModelBase<BossRushModel>.Instance.PlayBackAnimation = false;
		}

		// Token: 0x060431C4 RID: 274884 RVA: 0x0113CE4C File Offset: 0x0113B04C
		private void OnClickToggle(BuffScrollItemData data)
		{
			if (this.IsBuffMaxCountOne && !data.Selected)
			{
				foreach (BuffScrollItemData buffScrollItemData in this.CurrentSelectableBuffData)
				{
					buffScrollItemData.Selected = false;
				}
			}
			data.Selected = !data.Selected;
			this.RefreshScrollView(false);
			this.RefreshCountText();
		}

		// Token: 0x060431C5 RID: 274885 RVA: 0x0113CECC File Offset: 0x0113B0CC
		private bool CheckClickAble(BuffScrollItemData data)
		{
			if (this.FirstRefresh)
			{
				return true;
			}
			if (data.State != BossRushBuffSelectionStatus.BuffLocked)
			{
				if (data.Selected)
				{
					return true;
				}
				if (this.CheckIfStillCanSelectBuff())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060431C6 RID: 274886 RVA: 0x0113CEF8 File Offset: 0x0113B0F8
		private bool CheckIfStillCanSelectBuff()
		{
			if (this.FirstRefresh)
			{
				return true;
			}
			if (this.IsBuffMaxCountOne || this.CurrentTeamInfo.LevelInfo.GetMaxBuffCount() > this.GetCurrentSelectCount())
			{
				return true;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("BossRushMaxBuffText", Array.Empty<object>());
			return false;
		}

		// Token: 0x060431C7 RID: 274887 RVA: 0x0113CF48 File Offset: 0x0113B148
		private int GetCurrentSelectCount()
		{
			int num = 0;
			using (List<BuffScrollItemData>.Enumerator enumerator = this.CurrentSelectableBuffData.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Selected)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x060431C8 RID: 274888 RVA: 0x0113CFA4 File Offset: 0x0113B1A4
		private void RefreshScrollView(bool needGridAnimation = false)
		{
			if (this.LoopScrollView != null)
			{
				List<BuffGridItemData> list = new List<BuffGridItemData>();
				this.FirstRefresh = true;
				int count = this.CurrentSelectableBuffData.Count;
				for (int i = 0; i < count; i++)
				{
					list.Add(new BuffGridItemData
					{
						BuffScrollItemData1 = this.CurrentSelectableBuffData[i]
					});
				}
				this.LoopScrollView.RefreshByData(list, false, delegate
				{
					this.FirstRefresh = false;
				}, needGridAnimation);
				base.GetLoopScrollViewComponent(0).RootUIComp.Get().SetUIActive(list.Count > 0);
			}
		}

		// Token: 0x060431C9 RID: 274889 RVA: 0x0113D03D File Offset: 0x0113B23D
		protected override void OnBeforeHide()
		{
			LoopScrollView<BuffGridItem, BuffGridItemData> loopScrollView = this.LoopScrollView;
			if (loopScrollView == null)
			{
				return;
			}
			loopScrollView.ClearGridProxies();
		}

		// Token: 0x060431CA RID: 274890 RVA: 0x0113D050 File Offset: 0x0113B250
		private void RefreshCountText()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "BossRushSelectBuffText", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.GetCurrentSelectCount().ToString(),
				this.CurrentTeamInfo.LevelInfo.GetMaxBuffCount().ToString()
			}));
		}

		// Token: 0x04025657 RID: 153175
		[Nullable(2)]
		private BossRushTeamInfo CurrentTeamInfo;

		// Token: 0x04025658 RID: 153176
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<BuffScrollItemData> CurrentSelectableBuffData;

		// Token: 0x04025659 RID: 153177
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<BuffGridItem, BuffGridItemData> LoopScrollView;

		// Token: 0x0402565A RID: 153178
		private bool FirstRefresh = true;

		// Token: 0x0402565B RID: 153179
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0402565C RID: 153180
		private bool IsBuffMaxCountOne;

		// Token: 0x0200C943 RID: 51523
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403DE6A RID: 253546
			public const int LoopScrollView = 0;

			// Token: 0x0403DE6B RID: 253547
			public const int ContentItem = 1;

			// Token: 0x0403DE6C RID: 253548
			public const int SelectCountText = 2;

			// Token: 0x0403DE6D RID: 253549
			public const int ConfirmButton = 3;
		}
	}
}
