using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.DeadRevive
{
	// Token: 0x02005DCF RID: 24015
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenceReviveView : UiTickViewBase
	{
		// Token: 0x0603C746 RID: 247622 RVA: 0x00F5A8E0 File Offset: 0x00F58AE0
		public TowerDefenceReviveView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C747 RID: 247623 RVA: 0x00F5A8EC File Offset: 0x00F58AEC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickQuitBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C748 RID: 247624 RVA: 0x00F5AA38 File Offset: 0x00F58C38
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenceReviveView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenceReviveView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C749 RID: 247625 RVA: 0x00F5AA7C File Offset: 0x00F58C7C
		protected override void OnBeforeShow()
		{
			base.GetButton(1).RootUIComp.Get().SetUIActive(false);
			base.GetButton(2).RootUIComp.Get().SetUIActive(false);
			base.GetButton(7).RootUIComp.Get().SetUIActive(true);
			base.GetButton(9).RootUIComp.Get().SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
		}

		// Token: 0x0603C74A RID: 247626 RVA: 0x00F5AAFF File Offset: 0x00F58CFF
		protected override void OnStart()
		{
			this.RefreshCountDown();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "TowerDefence_dead2", Array.Empty<object>());
		}

		// Token: 0x0603C74B RID: 247627 RVA: 0x00F5AB24 File Offset: 0x00F58D24
		protected override void OnBeforeDestroy()
		{
			ModelBase<TowerDefenseModel>.Instance.SelfReviveTargetTimestampForUi = null;
			if (this.ConfirmBoxViewIdCache != null)
			{
				ControllerBase<ConfirmBoxController>.Instance.CloseNetWorkConfirmBoxView(this.ConfirmBoxViewIdCache.Value, null);
			}
			this.ConfirmBoxViewIdCache = null;
		}

		// Token: 0x0603C74C RID: 247628 RVA: 0x00F5AB70 File Offset: 0x00F58D70
		protected override void OnTick(float delta)
		{
			this.RefreshCountDown();
		}

		// Token: 0x0603C74D RID: 247629 RVA: 0x00F5AB78 File Offset: 0x00F58D78
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.TowerDefenseOnTowerDefenseBattleEndNotify, new Action(this.HandleOnTowerDefenceBattleEndNotify));
		}

		// Token: 0x0603C74E RID: 247630 RVA: 0x00F5AB96 File Offset: 0x00F58D96
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefenseOnTowerDefenseBattleEndNotify, new Action(this.HandleOnTowerDefenceBattleEndNotify));
		}

		// Token: 0x0603C74F RID: 247631 RVA: 0x00F5ABB4 File Offset: 0x00F58DB4
		private void RefreshCountDown()
		{
			long? selfReviveTargetTimestampForUi = ModelBase<TowerDefenseModel>.Instance.SelfReviveTargetTimestampForUi;
			if (selfReviveTargetTimestampForUi == null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "TowerDefence_dead1", Array.Empty<object>());
				return;
			}
			double serverStopTimeStamp = Singleton<TimeUtil>.Instance.GetServerStopTimeStamp();
			if (serverStopTimeStamp <= (double)selfReviveTargetTimestampForUi.Value)
			{
				UUIText text = base.GetText(0);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(0.5 + Singleton<TimeUtil>.Instance.Millisecond * ((double)selfReviveTargetTimestampForUi.Value - serverStopTimeStamp));
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "ReviveCountdownTime", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText));
				return;
			}
			UUIText text2 = base.GetText(0);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(false);
		}

		// Token: 0x0603C750 RID: 247632 RVA: 0x00F5AC78 File Offset: 0x00F58E78
		private void OnClickQuitBtn()
		{
			if (ModelBase<SceneTeamModel>.Instance.IsAllDid())
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.OnlineQuitInstance);
			confirmBoxDataNew.FunctionMap[1] = new Action(this.CancelCallback);
			confirmBoxDataNew.FunctionMap[2] = new Action(this.ConfirmCallback);
			confirmBoxDataNew.SetCloseFunction(new Action(this.CloseCallback));
			confirmBoxDataNew.FinishOpenFunction = new TOpenViewCallBack(this.FinishOpenCallback);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603C751 RID: 247633 RVA: 0x00F5AD09 File Offset: 0x00F58F09
		private void CancelCallback()
		{
		}

		// Token: 0x0603C752 RID: 247634 RVA: 0x00F5AD0B File Offset: 0x00F58F0B
		private void ConfirmCallback()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
		}

		// Token: 0x0603C753 RID: 247635 RVA: 0x00F5AD1C File Offset: 0x00F58F1C
		private void FinishOpenCallback(bool success, int viewId)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TowerDefenceReviveView) && success)
			{
				this.ConfirmBoxViewIdCache = new int?(viewId);
				return;
			}
			ControllerBase<ConfirmBoxController>.Instance.CloseNetWorkConfirmBoxView(viewId, null);
		}

		// Token: 0x0603C754 RID: 247636 RVA: 0x00F5AD4A File Offset: 0x00F58F4A
		private void CloseCallback()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TowerDefenceReviveView))
			{
				this.ConfirmBoxViewIdCache = null;
			}
		}

		// Token: 0x0603C755 RID: 247637 RVA: 0x00F5AD69 File Offset: 0x00F58F69
		private void HandleOnTowerDefenceBattleEndNotify()
		{
			base.CloseMe(null);
		}

		// Token: 0x04021FD7 RID: 139223
		private const string TIPS_TEXT_ID = "TowerDefence_dead1";

		// Token: 0x04021FD8 RID: 139224
		private const string TIPS_TEXT_ID_NEW = "ReviveCountdownTime";

		// Token: 0x04021FD9 RID: 139225
		private const string TIPS_UNDER_BUTTON_TEXT_ID = "TowerDefence_dead2";

		// Token: 0x04021FDA RID: 139226
		private int? ConfirmBoxViewIdCache;

		// Token: 0x0200BE1D RID: 48669
		[NullableContext(0)]
		private class ETowerDefenceReviveViewComponent
		{
			// Token: 0x0403A885 RID: 239749
			public const int TextTips = 0;

			// Token: 0x0403A886 RID: 239750
			public const int QuitButton = 1;

			// Token: 0x0403A887 RID: 239751
			public const int AgainButton = 2;

			// Token: 0x0403A888 RID: 239752
			public const int TeamPlayerStateItem = 3;

			// Token: 0x0403A889 RID: 239753
			public const int RealQuitBtn = 7;

			// Token: 0x0403A88A RID: 239754
			public const int RealQuitText = 8;

			// Token: 0x0403A88B RID: 239755
			public const int ReviveAtLocationBtn = 9;
		}
	}
}
