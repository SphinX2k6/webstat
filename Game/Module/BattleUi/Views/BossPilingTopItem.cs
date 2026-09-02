using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BossPiling;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006125 RID: 24869
	public class BossPilingTopItem : BattleVisibleChildView
	{
		// Token: 0x0603ED5E RID: 257374 RVA: 0x01019A38 File Offset: 0x01017C38
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickCollection));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603ED5F RID: 257375 RVA: 0x01019ADE File Offset: 0x01017CDE
		protected override void OnStart()
		{
			base.OnStart();
			base.InitChildType(EBattleUiChild.BossPiling);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.TryShow();
		}

		// Token: 0x0603ED60 RID: 257376 RVA: 0x01019B05 File Offset: 0x01017D05
		protected override void OnBeforeDestroy()
		{
			BattleUiControl.OffsetMissionAnchor(-1f);
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
			this.RemoveEvent();
			base.OnBeforeDestroy();
		}

		// Token: 0x0603ED61 RID: 257377 RVA: 0x01019B2F File Offset: 0x01017D2F
		public override void ShowBattleVisibleChildView(bool checkVisible = false)
		{
			if (!this.IsPendingLoaded)
			{
				base.ShowBattleVisibleChildView(checkVisible);
			}
		}

		// Token: 0x0603ED62 RID: 257378 RVA: 0x01019B40 File Offset: 0x01017D40
		protected override UniTask OnShowAsyncImplementImplement()
		{
			BossPilingTopItem.<OnShowAsyncImplementImplement>d__9 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<BossPilingTopItem.<OnShowAsyncImplementImplement>d__9>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603ED63 RID: 257379 RVA: 0x01019B84 File Offset: 0x01017D84
		protected override UniTask OnHideAsyncImplementImplement()
		{
			BossPilingTopItem.<OnHideAsyncImplementImplement>d__10 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<BossPilingTopItem.<OnHideAsyncImplementImplement>d__10>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603ED64 RID: 257380 RVA: 0x01019BC8 File Offset: 0x01017DC8
		private void TryShow()
		{
			if (this.IsPendingLoaded)
			{
				return;
			}
			if (ModelBase<GameModeModel>.Instance.Loading)
			{
				this.IsPendingLoaded = true;
				Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
				return;
			}
			this.ShowInner();
		}

		// Token: 0x0603ED65 RID: 257381 RVA: 0x01019C14 File Offset: 0x01017E14
		private void RemoveEvent()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
			}
		}

		// Token: 0x0603ED66 RID: 257382 RVA: 0x01019C4F File Offset: 0x01017E4F
		private void OnWorldDoneAndCloseLoading()
		{
			this.IsPendingLoaded = false;
			this.SeqStartState = 0;
			this.RemoveEvent();
			this.ShowInner();
		}

		// Token: 0x0603ED67 RID: 257383 RVA: 0x01019C6B File Offset: 0x01017E6B
		private void ShowInner()
		{
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData != null)
			{
				childViewData.SetChildVisible(EBattleUiVisibleReason.Default, EBattleUiChild.BossPiling, true, true, 0);
			}
			this.ShowBattleVisibleChildView(false);
		}

		// Token: 0x0603ED68 RID: 257384 RVA: 0x01019C90 File Offset: 0x01017E90
		public void StartShow()
		{
			if (this.RootItem != null && !this.RootItem.bIsUIActive)
			{
				this.SeqStartState = 0;
			}
			this.TryShow();
		}

		// Token: 0x0603ED69 RID: 257385 RVA: 0x01019CB4 File Offset: 0x01017EB4
		public void EndShow()
		{
			this.SeqEndState = 0;
			base.SetVisible(0, false);
		}

		// Token: 0x0603ED6A RID: 257386 RVA: 0x01019CC8 File Offset: 0x01017EC8
		private void OnClickCollection()
		{
			InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
			if (instanceDungeon == null || !ModelBase<BossPilingModel>.Instance.CheckIsBossPiling())
			{
				return;
			}
			int item = ModelBase<BossPilingModel>.Instance.GetLevelIdAndHalfByInstId(instanceDungeon.Value.Id).Item1;
			BossPilingBuffViewInfo param = new BossPilingBuffViewInfo
			{
				LevelId = item,
				InGame = true
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingBuffView, param, null);
		}

		// Token: 0x04023416 RID: 144406
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04023417 RID: 144407
		private int SeqStartState;

		// Token: 0x04023418 RID: 144408
		private int SeqEndState = 1;

		// Token: 0x04023419 RID: 144409
		[Nullable(2)]
		public UiPanelBase ParentLogic;

		// Token: 0x0402341A RID: 144410
		private bool IsPendingLoaded;

		// Token: 0x0200C2B2 RID: 49842
		private enum EChildType
		{
			// Token: 0x0403C079 RID: 245881
			BtnCollection,
			// Token: 0x0403C07A RID: 245882
			PnlMissionContent
		}
	}
}
