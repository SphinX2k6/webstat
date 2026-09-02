using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BC5 RID: 23493
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceDungeonMatchingCountDown : UiPanelBase
	{
		// Token: 0x0603B797 RID: 243607 RVA: 0x00F13874 File Offset: 0x00F11A74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickBtnCancel));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B798 RID: 243608 RVA: 0x00F13A08 File Offset: 0x00F11C08
		private void OnClickBtnCancel()
		{
			if ("Close" == this.CurrentAnimation)
			{
				return;
			}
			EInstanceMatchState matchingState = ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState();
			if (matchingState == EInstanceMatchState.Waiting || matchingState == EInstanceMatchState.MatchConfirm)
			{
				return;
			}
			this.PlayAnimation("Close");
			if (this.OnClickBtnCancelMatching != null)
			{
				this.OnClickBtnCancelMatching();
			}
		}

		// Token: 0x0603B799 RID: 243609 RVA: 0x00F13A5C File Offset: 0x00F11C5C
		protected override void OnStart()
		{
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(11);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(12);
			if (item3 != null)
			{
				item3.SetUIActive(true);
			}
			UUIItem item4 = base.GetItem(13);
			if (item4 != null)
			{
				item4.SetUIActive(false);
			}
			UUIItem item5 = base.GetItem(14);
			if (item5 != null)
			{
				item5.SetUIActive(true);
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
			this.RefreshButtonActivity();
		}

		// Token: 0x0603B79A RID: 243610 RVA: 0x00F13B1C File Offset: 0x00F11D1C
		protected void RefreshButtonActivity()
		{
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				base.GetButton(8).RootUIComp.Get().SetUIActive(true);
				return;
			}
			base.GetButton(8).RootUIComp.Get().SetUIActive(ModelBase<OnlineModel>.Instance.GetIsMyTeam());
		}

		// Token: 0x0603B79B RID: 243611 RVA: 0x00F13B74 File Offset: 0x00F11D74
		public void PlayAnimation(string animation)
		{
			if (this.CurrentAnimation == animation)
			{
				return;
			}
			base.SetUiActive(true);
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
			this.LevelSequencePlayer.PlayLevelSequenceByName(animation, false, null, false);
			this.CurrentAnimation = animation;
		}

		// Token: 0x0603B79C RID: 243612 RVA: 0x00F13BC2 File Offset: 0x00F11DC2
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				base.SetUiActive(false);
			}
			else if (sequenceName == "Finish")
			{
				base.SetUiActive(false);
			}
			Action<string> onAfterCloseAnimation = this.OnAfterCloseAnimation;
			if (onAfterCloseAnimation == null)
			{
				return;
			}
			onAfterCloseAnimation(sequenceName);
		}

		// Token: 0x0603B79D RID: 243613 RVA: 0x00F13BFF File Offset: 0x00F11DFF
		protected override void OnBeforeDestroy()
		{
			this.OnClickBtnCancelMatching = null;
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x0603B79E RID: 243614 RVA: 0x00F13C20 File Offset: 0x00F11E20
		public void StartTimer()
		{
			InstanceDungeonEntranceModel instance = ModelBase<InstanceDungeonEntranceModel>.Instance;
			UUIText text = base.GetText(5);
			text.SetText(Singleton<TimeUtil>.Instance.GetTimeString((double)instance.MatchingTime), true);
			text.SetUIActive(true);
			base.GetText(7).ShowTextNew(ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instance.GetMatchingId()).Value.MapName);
			ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchTimer(new Action(this.RefreshMatchingTime));
			if (this.LevelSequencePlayer.GetCurrentSequence() == "AutoLoop")
			{
				this.LevelSequencePlayer.ReplaySequenceByKey("AutoLoop");
			}
			else
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName("AutoLoop", false, null, false);
			}
			this.RefreshButtonActivity();
		}

		// Token: 0x0603B79F RID: 243615 RVA: 0x00F13CE4 File Offset: 0x00F11EE4
		public void BindOnStopTimer(Func<bool> onStopTimer)
		{
			ModelBase<InstanceDungeonEntranceModel>.Instance.OnStopTimer = onStopTimer;
		}

		// Token: 0x0603B7A0 RID: 243616 RVA: 0x00F13CF1 File Offset: 0x00F11EF1
		public void BindOnClickBtnCancelMatching(Action onClickBtnCancelMatching)
		{
			this.OnClickBtnCancelMatching = onClickBtnCancelMatching;
		}

		// Token: 0x0603B7A1 RID: 243617 RVA: 0x00F13CFA File Offset: 0x00F11EFA
		public void BindOnAfterCloseAnimation(Action<string> onAfterCloseAnimation)
		{
			this.OnAfterCloseAnimation = onAfterCloseAnimation;
		}

		// Token: 0x0603B7A2 RID: 243618 RVA: 0x00F13D03 File Offset: 0x00F11F03
		public void BindOnStopHandle(Action onStopHandle)
		{
			ModelBase<InstanceDungeonEntranceModel>.Instance.OnStopHandle = onStopHandle;
		}

		// Token: 0x0603B7A3 RID: 243619 RVA: 0x00F13D10 File Offset: 0x00F11F10
		public void SetMatchingTime(int time)
		{
			ModelBase<InstanceDungeonEntranceModel>.Instance.MatchingTime = time;
		}

		// Token: 0x0603B7A4 RID: 243620 RVA: 0x00F13D20 File Offset: 0x00F11F20
		private void RefreshMatchingTime()
		{
			if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InstanceDungeonEntranceView) && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.OnlineWorldHallView) && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.EditBattleTeamView) && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.DangoAbyssInsSelectView) && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MultiMotorChoseLevelView) && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.TowerDefenseLevelView))
			{
				return;
			}
			UUIText text = base.GetText(5);
			if (text == null)
			{
				return;
			}
			text.SetText(Singleton<TimeUtil>.Instance.GetTimeString((double)ModelBase<InstanceDungeonEntranceModel>.Instance.MatchingTime), true);
		}

		// Token: 0x04021815 RID: 137237
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04021816 RID: 137238
		[Nullable(2)]
		private Action OnClickBtnCancelMatching;

		// Token: 0x04021817 RID: 137239
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<string> OnAfterCloseAnimation;

		// Token: 0x04021818 RID: 137240
		[Nullable(2)]
		private string CurrentAnimation;

		// Token: 0x0200BC2E RID: 48174
		[NullableContext(0)]
		private static class EInstanceDungeonMatchingCountDownComponent
		{
			// Token: 0x0403A0B6 RID: 237750
			public const int OtherButton = 2;

			// Token: 0x0403A0B7 RID: 237751
			public const int TextTime = 5;

			// Token: 0x0403A0B8 RID: 237752
			public const int TextName = 7;

			// Token: 0x0403A0B9 RID: 237753
			public const int BtnCancel = 8;

			// Token: 0x0403A0BA RID: 237754
			public const int RoleItem = 10;

			// Token: 0x0403A0BB RID: 237755
			public const int ProcessItem = 11;

			// Token: 0x0403A0BC RID: 237756
			public const int MatchingItem = 12;

			// Token: 0x0403A0BD RID: 237757
			public const int MatchingDownItem = 13;

			// Token: 0x0403A0BE RID: 237758
			public const int MatchingWaitItem = 14;
		}
	}
}
