using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006F08 RID: 28424
	[NullableContext(2)]
	[Nullable(0)]
	public class DollGrabMachineMissionPanel : UiPanelBase
	{
		// Token: 0x06044DC8 RID: 282056 RVA: 0x011EB3EC File Offset: 0x011E95EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044DC9 RID: 282057 RVA: 0x011EB478 File Offset: 0x011E9678
		protected override void OnBeforeCreate()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIActive(false);
			}
			if (ControllerBase<DollGrabMachineController>.Instance.IsEndlessMode)
			{
				this.MissionTitle = base.GetText(1);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(this.MissionTitle, "KClaw_Total_Score_Title", Array.Empty<object>());
				this.MissionInfo = base.GetText(2);
				Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnDollGrabMachineEndlessScoreChanged, new Action<int, int>(this.OnDollGrabMachineEndlessScoreChanged));
				Singleton<EventSystem>.Instance.Add(EEventName.OnDollGrabMachineRestart, new Action(this.OnDollGrabMachineRestart));
				return;
			}
			this.MissionTitle = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.MissionTitle, "KClaw_Gameplay_Name", Array.Empty<object>());
			this.MissionInfo = base.GetText(2);
			Singleton<EventSystem>.Instance.Add<int, List<IGrabItemData>>(EEventName.OnDollGrabMachineGrabDoll, new Action<int, List<IGrabItemData>>(this.OnDollGrabMachineGrabDoll));
		}

		// Token: 0x06044DCA RID: 282058 RVA: 0x011EB560 File Offset: 0x011E9760
		protected override void OnBeforeDestroy()
		{
			if (Singleton<EventSystem>.Instance.Has<int, List<IGrabItemData>>(EEventName.OnDollGrabMachineGrabDoll, new Action<int, List<IGrabItemData>>(this.OnDollGrabMachineGrabDoll)))
			{
				Singleton<EventSystem>.Instance.Remove<int, List<IGrabItemData>>(EEventName.OnDollGrabMachineGrabDoll, new Action<int, List<IGrabItemData>>(this.OnDollGrabMachineGrabDoll));
			}
			if (Singleton<EventSystem>.Instance.Has<int, int>(EEventName.OnDollGrabMachineEndlessScoreChanged, new Action<int, int>(this.OnDollGrabMachineEndlessScoreChanged)))
			{
				Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnDollGrabMachineEndlessScoreChanged, new Action<int, int>(this.OnDollGrabMachineEndlessScoreChanged));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnDollGrabMachineRestart, new Action(this.OnDollGrabMachineRestart)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnDollGrabMachineRestart, new Action(this.OnDollGrabMachineRestart));
			}
		}

		// Token: 0x06044DCB RID: 282059 RVA: 0x011EB618 File Offset: 0x011E9818
		public void RefreshPanel()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIActive(true);
			}
			if (!ControllerBase<DollGrabMachineController>.Instance.IsEndlessMode)
			{
				this.OnDollGrabMachineGrabDoll(ControllerBase<DollGrabMachineController>.Instance.LeaveDollCount, new List<IGrabItemData>());
				return;
			}
			IDollGrabInfiniteRewardData endlessRewardData = ControllerBase<DollGrabMachineController>.Instance.EndlessRewardData;
			this.OnDollGrabMachineEndlessScoreChanged((endlessRewardData != null) ? endlessRewardData.CurrentAccumulatedScore : 0, (endlessRewardData != null) ? endlessRewardData.TargetAccumulatedScore : 0);
		}

		// Token: 0x06044DCC RID: 282060 RVA: 0x011EB682 File Offset: 0x011E9882
		[NullableContext(1)]
		private void OnDollGrabMachineGrabDoll(int count, List<IGrabItemData> grabItemDataList)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.MissionInfo, "KClaw_Remaining_Prize_Count", new <>z__ReadOnlySingleElementList<object>(count));
		}

		// Token: 0x06044DCD RID: 282061 RVA: 0x011EB6A4 File Offset: 0x011E98A4
		private void OnDollGrabMachineEndlessScoreChanged(int newScore, int addScore)
		{
			IDollGrabInfiniteRewardData endlessRewardData = ControllerBase<DollGrabMachineController>.Instance.EndlessRewardData;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.MissionInfo, "KClaw_Total_Score_Value", new <>z__ReadOnlyArray<object>(new object[]
			{
				((endlessRewardData != null) ? endlessRewardData.CurrentAccumulatedScore.ToString() : null) ?? "0",
				((endlessRewardData != null) ? endlessRewardData.TargetAccumulatedScore.ToString() : null) ?? "0"
			}));
		}

		// Token: 0x06044DCE RID: 282062 RVA: 0x011EB71C File Offset: 0x011E991C
		private void OnDollGrabMachineRestart()
		{
			IDollGrabInfiniteRewardData endlessRewardData = ControllerBase<DollGrabMachineController>.Instance.EndlessRewardData;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.MissionInfo, "KClaw_Total_Score_Value", new <>z__ReadOnlyArray<object>(new object[]
			{
				((endlessRewardData != null) ? endlessRewardData.CurrentAccumulatedScore.ToString() : null) ?? "0",
				((endlessRewardData != null) ? endlessRewardData.TargetAccumulatedScore.ToString() : null) ?? "0"
			}));
		}

		// Token: 0x040265E5 RID: 157157
		private UUIText MissionTitle;

		// Token: 0x040265E6 RID: 157158
		private UUIText MissionInfo;
	}
}
