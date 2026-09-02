using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BCE RID: 23502
	public class InstanceMatchingConfirm : UiViewBase
	{
		// Token: 0x0603B81E RID: 243742 RVA: 0x00F1606A File Offset: 0x00F1426A
		[NullableContext(1)]
		public InstanceMatchingConfirm(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603B81F RID: 243743 RVA: 0x00F16074 File Offset: 0x00F14274
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnCancel));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnConfirm));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B820 RID: 243744 RVA: 0x00F161A0 File Offset: 0x00F143A0
		protected override void OnStart()
		{
			this.ShowConfirmState(ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingId()).Value.MapName, null));
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				CommonPopViewBase popItem = childPopView.PopItem;
				if (popItem != null)
				{
					popItem.SetMaskResponsibleState(false);
				}
			}
			IUiPopFrameInterface childPopView2 = this.ChildPopView;
			if (childPopView2 == null)
			{
				return;
			}
			CommonPopViewBase popItem2 = childPopView2.PopItem;
			if (popItem2 == null)
			{
				return;
			}
			popItem2.OverrideBackBtnCallBack(delegate
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.MatchConfirmRequest(false);
				ModelBase<InstanceDungeonModel>.Instance.ResetData();
				base.CloseMe(null);
			});
		}

		// Token: 0x0603B821 RID: 243745 RVA: 0x00F16220 File Offset: 0x00F14420
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
		}

		// Token: 0x0603B822 RID: 243746 RVA: 0x00F1623E File Offset: 0x00F1443E
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
		}

		// Token: 0x0603B823 RID: 243747 RVA: 0x00F1625C File Offset: 0x00F1445C
		protected override void OnBeforeDestroy()
		{
			if (this.Timer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.Timer);
			}
			this.Timer = null;
			this.ConfirmTime = 0;
		}

		// Token: 0x0603B824 RID: 243748 RVA: 0x00F16288 File Offset: 0x00F14488
		private void OnMatchingChange()
		{
			switch (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState())
			{
			case EInstanceMatchState.Default:
			case EInstanceMatchState.Matching:
			case EInstanceMatchState.ConfirmToReady:
				base.CloseMe(null);
				break;
			case EInstanceMatchState.MatchConfirm:
				break;
			case EInstanceMatchState.Waiting:
				this.ShowWaitState();
				return;
			default:
				return;
			}
		}

		// Token: 0x0603B825 RID: 243749 RVA: 0x00F162CC File Offset: 0x00F144CC
		private void TimerHandle(float _)
		{
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() != EInstanceMatchState.MatchConfirm && this.Timer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.Timer);
				this.Timer = null;
				return;
			}
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText text = base.GetText(0);
			string textTableId = "MatchingCoolDown";
			TimeUtil instance2 = Singleton<TimeUtil>.Instance;
			int confirmTime = this.ConfirmTime;
			this.ConfirmTime = confirmTime - 1;
			instance.SetLocalText(text, textTableId, new <>z__ReadOnlySingleElementList<object>(instance2.GetCoolDown((double)confirmTime)));
		}

		// Token: 0x0603B826 RID: 243750 RVA: 0x00F16340 File Offset: 0x00F14540
		[NullableContext(1)]
		public void ShowConfirmState(string instanceName)
		{
			this.ConfirmTime = ConfigCommonParamById.GetIntConfig("match_confirm_time_out_seconds").Value;
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText text = base.GetText(0);
			string textTableId = "MatchingCoolDown";
			int confirmTime = this.ConfirmTime;
			this.ConfirmTime = confirmTime - 1;
			instance.SetLocalText(text, textTableId, new <>z__ReadOnlySingleElementList<object>(confirmTime.ToString()));
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "MatchingContext", new <>z__ReadOnlySingleElementList<object>(instanceName));
			UUIText text2 = base.GetText(0);
			if (text2 != null)
			{
				text2.SetUIActive(true);
			}
			base.GetButton(2).GetRootComponent().SetUIActive(true);
			base.GetButton(3).GetRootComponent().SetUIActive(true);
			base.GetItem(4).SetUIActive(false);
			if (this.Timer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.Timer);
				this.Timer = null;
			}
			this.Timer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.TimerHandle), 1000f, 1f, null, null, true);
		}

		// Token: 0x0603B827 RID: 243751 RVA: 0x00F16440 File Offset: 0x00F14640
		public void ShowWaitState()
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			base.GetButton(2).GetRootComponent().SetUIActive(false);
			base.GetButton(3).GetRootComponent().SetUIActive(false);
			base.GetItem(4).SetUIActive(true);
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				childPopView.PopItem.SetMaskResponsibleState(false);
			}
			IUiPopFrameInterface childPopView2 = this.ChildPopView;
			if (childPopView2 == null)
			{
				return;
			}
			childPopView2.PopItem.SetBackBtnShowState(false);
		}

		// Token: 0x0603B828 RID: 243752 RVA: 0x00F164BE File Offset: 0x00F146BE
		private void OnClickBtnCancel()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.MatchConfirmRequest(false);
			ModelBase<InstanceDungeonModel>.Instance.ResetData();
		}

		// Token: 0x0603B829 RID: 243753 RVA: 0x00F164D5 File Offset: 0x00F146D5
		private void OnClickBtnConfirm()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.MatchConfirmRequest(true);
			this.ShowWaitState();
		}

		// Token: 0x04021841 RID: 137281
		private int ConfirmTime;

		// Token: 0x04021842 RID: 137282
		[Nullable(2)]
		private TimerHandle Timer;

		// Token: 0x04021843 RID: 137283
		private const int ONE_SECONDS = 1000;

		// Token: 0x0200BC38 RID: 48184
		private static class EInstanceMatchingConfirmComponent
		{
			// Token: 0x0403A0DC RID: 237788
			public const int TextTips = 0;

			// Token: 0x0403A0DD RID: 237789
			public const int TextContent = 1;

			// Token: 0x0403A0DE RID: 237790
			public const int BtnCancel = 2;

			// Token: 0x0403A0DF RID: 237791
			public const int BtnConfirm = 3;

			// Token: 0x0403A0E0 RID: 237792
			public const int WaitingItem = 4;
		}
	}
}
