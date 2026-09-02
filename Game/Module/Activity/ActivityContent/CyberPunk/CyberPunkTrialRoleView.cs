using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x0200697E RID: 27006
	[NullableContext(2)]
	[Nullable(0)]
	public class CyberPunkTrialRoleView : UiViewBase
	{
		// Token: 0x06043021 RID: 274465 RVA: 0x0113487D File Offset: 0x01132A7D
		[NullableContext(1)]
		public CyberPunkTrialRoleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043022 RID: 274466 RVA: 0x01134888 File Offset: 0x01132A88
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(USpineSkeletonAnimationComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06043023 RID: 274467 RVA: 0x01134978 File Offset: 0x01132B78
		protected override UniTask OnBeforeStartAsync()
		{
			CyberPunkTrialRoleView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CyberPunkTrialRoleView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043024 RID: 274468 RVA: 0x011349BC File Offset: 0x01132BBC
		protected override void OnStart()
		{
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickClose));
			this.CaptionItem.SetHelpCallBack(new Action(this.OnClickHelp));
			this.CaptionItem.SetHomeBtnShowState(true);
			this.InitData();
			this.RefreshView();
			this.PlaySpineIdle();
		}

		// Token: 0x06043025 RID: 274469 RVA: 0x01134A15 File Offset: 0x01132C15
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnTrialStateChange));
		}

		// Token: 0x06043026 RID: 274470 RVA: 0x01134A4F File Offset: 0x01132C4F
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnTrialStateChange));
		}

		// Token: 0x06043027 RID: 274471 RVA: 0x01134A89 File Offset: 0x01132C89
		protected override void OnBeforeDestroy()
		{
			this.SetTrialRoleState(ERoleTrialFlowState.ActivityOff);
		}

		// Token: 0x06043028 RID: 274472 RVA: 0x01134A94 File Offset: 0x01132C94
		private void SetTrialRoleState(ERoleTrialFlowState state)
		{
			CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
			IReadOnlyList<EdgeRunnerTrial> readOnlyList = (instance != null) ? instance.GetTrialRoleListByCyberPunkActivityId(this.ActivityId) : null;
			if (readOnlyList == null)
			{
				return;
			}
			foreach (EdgeRunnerTrial edgeRunnerTrial in readOnlyList)
			{
				ActivityRoleTrialData activityRoleTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(edgeRunnerTrial.ActivityId) as ActivityRoleTrialData;
				if (activityRoleTrialData != null && (state != ERoleTrialFlowState.ActivityOff || !activityRoleTrialData.IsRoleInstanceOn()))
				{
					activityRoleTrialData.SetRoleTrialState(state);
				}
			}
		}

		// Token: 0x06043029 RID: 274473 RVA: 0x01134B20 File Offset: 0x01132D20
		private void InitData()
		{
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.EdgeRunnerActivity);
			if (currentActivitiesByType != null && currentActivitiesByType.Count > 0)
			{
				this.ActivityData = (currentActivitiesByType[0] as CyberPunkData);
				this.ActivityId = this.ActivityData.Id;
			}
			if (this.ActivityData == null)
			{
				return;
			}
			IReadOnlyList<EdgeRunnerTrial> trialRoleListByCyberPunkActivityId = ConfigBase<CyberPunkConfig>.Instance.GetTrialRoleListByCyberPunkActivityId(this.ActivityId);
			if (trialRoleListByCyberPunkActivityId == null || trialRoleListByCyberPunkActivityId.Count == 0)
			{
				return;
			}
			if (trialRoleListByCyberPunkActivityId.Count > 0)
			{
				CyberPunkTrialRolePanel rolePanel = this.RolePanel1;
				if (rolePanel != null)
				{
					rolePanel.SetData(trialRoleListByCyberPunkActivityId[0].Id, trialRoleListByCyberPunkActivityId[0].ActivityId, this.ActivityId);
				}
			}
			if (trialRoleListByCyberPunkActivityId.Count > 1)
			{
				CyberPunkTrialRolePanel rolePanel2 = this.RolePanel2;
				if (rolePanel2 == null)
				{
					return;
				}
				rolePanel2.SetData(trialRoleListByCyberPunkActivityId[1].Id, trialRoleListByCyberPunkActivityId[1].ActivityId, this.ActivityId);
			}
		}

		// Token: 0x0604302A RID: 274474 RVA: 0x01134C0A File Offset: 0x01132E0A
		private void RefreshView()
		{
			this.SetTrialRoleState(ERoleTrialFlowState.ActivityOn);
			this.RefreshRemainTime();
			CyberPunkTrialRolePanel rolePanel = this.RolePanel1;
			if (rolePanel != null)
			{
				rolePanel.RefreshPanel();
			}
			CyberPunkTrialRolePanel rolePanel2 = this.RolePanel2;
			if (rolePanel2 == null)
			{
				return;
			}
			rolePanel2.RefreshPanel();
		}

		// Token: 0x0604302B RID: 274475 RVA: 0x01134C3C File Offset: 0x01132E3C
		private void RefreshRemainTime()
		{
			if (this.ActivityData == null)
			{
				return;
			}
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.ActivityData, null);
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetUIActive(item);
				if (item)
				{
					text.SetText(item2, true);
				}
			}
		}

		// Token: 0x0604302C RID: 274476 RVA: 0x01134C90 File Offset: 0x01132E90
		private void PlaySpineIdle()
		{
			USpineSkeletonAnimationComponent spine = base.GetSpine(4);
			if (spine != null && spine.IsValid())
			{
				spine.SetAnimation(0, "idle", true);
			}
			USpineSkeletonAnimationComponent spine2 = base.GetSpine(5);
			if (spine2 != null && spine2.IsValid())
			{
				spine2.SetAnimation(0, "idle", true);
			}
		}

		// Token: 0x0604302D RID: 274477 RVA: 0x01134CDF File Offset: 0x01132EDF
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0604302E RID: 274478 RVA: 0x01134CE8 File Offset: 0x01132EE8
		private void OnClickHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(0);
		}

		// Token: 0x0604302F RID: 274479 RVA: 0x01134CF5 File Offset: 0x01132EF5
		[NullableContext(1)]
		private void OnActivityClose(IReadOnlySet<int> closeActivities)
		{
			if (ControllerBase<CyberPunkController>.Instance.CurrentActivityId == this.ActivityId)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x06043030 RID: 274480 RVA: 0x01134D10 File Offset: 0x01132F10
		private void OnTrialStateChange(int activityId)
		{
			if (activityId != this.ActivityId)
			{
				return;
			}
			CyberPunkTrialRolePanel rolePanel = this.RolePanel1;
			if (rolePanel != null)
			{
				rolePanel.RefreshPanel();
			}
			CyberPunkTrialRolePanel rolePanel2 = this.RolePanel2;
			if (rolePanel2 == null)
			{
				return;
			}
			rolePanel2.RefreshPanel();
		}

		// Token: 0x06043031 RID: 274481 RVA: 0x01134D40 File Offset: 0x01132F40
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "BackToBattleViewBtn"))
			{
				return null;
			}
			UActorComponent componentInChildren = ULGUIBPLibrary.GetComponentInChildren(base.GetRootActor(), TsUiHomeHelper.StaticClass(), false);
			AActor aactor = (componentInChildren != null) ? componentInChildren.GetOwner() : null;
			if (aactor == null)
			{
				return null;
			}
			UUIButtonComponent uuibuttonComponent = ULGUIBPLibrary.GetComponentInChildren(aactor, UUIButtonComponent.StaticClass(), false) as UUIButtonComponent;
			UUIItem uuiitem = (uuibuttonComponent != null) ? uuibuttonComponent.GetRootComponent() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x04025520 RID: 152864
		private PopupCaptionItem CaptionItem;

		// Token: 0x04025521 RID: 152865
		private CyberPunkTrialRolePanel RolePanel1;

		// Token: 0x04025522 RID: 152866
		private CyberPunkTrialRolePanel RolePanel2;

		// Token: 0x04025523 RID: 152867
		private CyberPunkData ActivityData;

		// Token: 0x04025524 RID: 152868
		private int ActivityId;

		// Token: 0x0200C92A RID: 51498
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403DE03 RID: 253443
			public const int Caption = 0;

			// Token: 0x0403DE04 RID: 253444
			public const int PnlRole1 = 1;

			// Token: 0x0403DE05 RID: 253445
			public const int PnlRole2 = 2;

			// Token: 0x0403DE06 RID: 253446
			public const int RemainTimeText = 3;

			// Token: 0x0403DE07 RID: 253447
			public const int Spine1 = 4;

			// Token: 0x0403DE08 RID: 253448
			public const int Spine2 = 5;
		}
	}
}
