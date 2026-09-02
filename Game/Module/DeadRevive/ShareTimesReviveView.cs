using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.DeadRevive
{
	// Token: 0x02005DCE RID: 24014
	public class ShareTimesReviveView : UiViewBase
	{
		// Token: 0x0603C73B RID: 247611 RVA: 0x00F5A4D6 File Offset: 0x00F586D6
		[NullableContext(1)]
		public ShareTimesReviveView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C73C RID: 247612 RVA: 0x00F5A4E0 File Offset: 0x00F586E0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickRevive));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickQuitBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C73D RID: 247613 RVA: 0x00F5A60C File Offset: 0x00F5880C
		private void OnClickRevive()
		{
			if (!this.CanRevive())
			{
				return;
			}
			ControllerBase<DeadReviveController>.Instance.TryReviveCurrentRoleByShare();
		}

		// Token: 0x0603C73E RID: 247614 RVA: 0x00F5A624 File Offset: 0x00F58824
		private void OnClickQuitBtn()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.AbyssExit);
			Action value = delegate()
			{
				int id = ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId;
				if (ControllerBase<GameModeController>.Instance.IsInInstance())
				{
					id = ModelBase<CreatureModel>.Instance.GetInstanceId();
				}
				InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(id);
				if (config != null && config.GetValueOrDefault().InstSubType == 33)
				{
					ControllerBase<DangoAbyssController>.Instance.RequestQuitChallenge();
					return;
				}
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
			};
			confirmBoxDataNew.FunctionMap[2] = value;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603C73F RID: 247615 RVA: 0x00F5A678 File Offset: 0x00F58878
		protected override void OnStart()
		{
			UUIText text = base.GetText(2);
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText uiText = text;
			DeadReviveModel instance2 = ModelBase<DeadReviveModel>.Instance;
			instance.SetLocalTextNew(uiText, ((instance2.ReviveConfig != null) ? instance2.ReviveConfig.GetValueOrDefault().ReviveTitle : null) ?? "", Array.Empty<object>());
			SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
			if (getCurrentTeamItem != null)
			{
				ReviveCooldownData reviveCooldownData = null;
				ModelBase<DeadReviveModel>.Instance.ReviveCooldownCreatureMap.TryGetValue(getCurrentTeamItem.GetCreatureDataId(), out reviveCooldownData);
				this.ReviveWaitSeconds = (float)(0.0010000000474974513 * ((reviveCooldownData != null) ? reviveCooldownData.RemainMilliseconds : 0.0));
			}
		}

		// Token: 0x0603C740 RID: 247616 RVA: 0x00F5A716 File Offset: 0x00F58916
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnShareReviveTimesChange, new Action(this.RefreshReviveView));
			Singleton<EventSystem>.Instance.Add<long, float>(EEventName.OnRoleReviveCooldownChange, new Action<long, float>(this.OnRoleReviveCooldownChange));
		}

		// Token: 0x0603C741 RID: 247617 RVA: 0x00F5A750 File Offset: 0x00F58950
		protected override void OnBeforeShow()
		{
			this.RefreshReviveView();
		}

		// Token: 0x0603C742 RID: 247618 RVA: 0x00F5A758 File Offset: 0x00F58958
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnShareReviveTimesChange, new Action(this.RefreshReviveView));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleReviveCooldownChange, new Action<long, float>(this.OnRoleReviveCooldownChange));
		}

		// Token: 0x0603C743 RID: 247619 RVA: 0x00F5A794 File Offset: 0x00F58994
		private void RefreshReviveView()
		{
			int currentShareReviveTimes = ModelBase<DeadReviveModel>.Instance.CurrentShareReviveTimes;
			int maxShareReviveTimes = ModelBase<DeadReviveModel>.Instance.MaxShareReviveTimes;
			this.ReviveTimes = currentShareReviveTimes;
			UUIText text = base.GetText(3);
			if (currentShareReviveTimes > 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "TuanZiAbyss_RE_NumRemainder", new <>z__ReadOnlyArray<object>(new object[]
				{
					currentShareReviveTimes,
					maxShareReviveTimes
				}));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "TuanZiAbyss_RE_NoNum", Array.Empty<object>());
			}
			UUIText text2 = base.GetText(4);
			bool flag = this.ReviveWaitSeconds > 0f;
			text2.SetUIActive(flag);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "TuanZiAbyss_RE_ReTime", new <>z__ReadOnlySingleElementList<object>(this.ReviveWaitSeconds.ToString("F1")));
			}
			base.GetButton(0).GetRootComponent().SetUIActive(this.CanRevive());
		}

		// Token: 0x0603C744 RID: 247620 RVA: 0x00F5A870 File Offset: 0x00F58A70
		private void OnRoleReviveCooldownChange(long creatureDataId, float remainSeconds)
		{
			SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
			long? num = (getCurrentTeamItem != null) ? new long?(getCurrentTeamItem.GetCreatureDataId()) : null;
			if (!(creatureDataId == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			this.ReviveWaitSeconds = remainSeconds;
			this.RefreshReviveView();
		}

		// Token: 0x0603C745 RID: 247621 RVA: 0x00F5A8C3 File Offset: 0x00F58AC3
		private bool CanRevive()
		{
			return this.ReviveTimes > 0 && this.ReviveWaitSeconds <= 0f;
		}

		// Token: 0x04021FD5 RID: 139221
		private float ReviveWaitSeconds;

		// Token: 0x04021FD6 RID: 139222
		private int ReviveTimes;

		// Token: 0x0200BE1B RID: 48667
		private class EShareTimesReviveViewComponent
		{
			// Token: 0x0403A87E RID: 239742
			public const int ReviveBtn = 0;

			// Token: 0x0403A87F RID: 239743
			public const int QuitButton = 1;

			// Token: 0x0403A880 RID: 239744
			public const int ReviveTitle = 2;

			// Token: 0x0403A881 RID: 239745
			public const int ReviveContent = 3;

			// Token: 0x0403A882 RID: 239746
			public const int ReviveWaitTime = 4;
		}
	}
}
