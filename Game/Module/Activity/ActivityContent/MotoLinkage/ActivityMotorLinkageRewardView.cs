using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage
{
	// Token: 0x02006710 RID: 26384
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityMotorLinkageRewardView : UiViewBase
	{
		// Token: 0x06041D3F RID: 269631 RVA: 0x010E3C54 File Offset: 0x010E1E54
		public ActivityMotorLinkageRewardView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06041D40 RID: 269632 RVA: 0x010E3C70 File Offset: 0x010E1E70
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickRight)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickLeft))
			};
		}

		// Token: 0x06041D41 RID: 269633 RVA: 0x010E3D8C File Offset: 0x010E1F8C
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityMotorLinkageRewardView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityMotorLinkageRewardView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041D42 RID: 269634 RVA: 0x010E3DD0 File Offset: 0x010E1FD0
		protected override void OnStart()
		{
			PopupCaptionItem caption = this.Caption;
			if (caption != null)
			{
				caption.SetCloseCallBack(delegate
				{
					base.CloseMe(null);
				});
			}
			foreach (KeyValuePair<int, MotorLinkageBackgroundItem> keyValuePair in this.BackgroundItemMap)
			{
				AUIBaseActor auibaseActor = keyValuePair.Value.GetRootActor() as AUIBaseActor;
				if (auibaseActor != null)
				{
					auibaseActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnSequencePlayEvent));
				}
			}
		}

		// Token: 0x06041D43 RID: 269635 RVA: 0x010E3E68 File Offset: 0x010E2068
		protected override void OnBeforeShow()
		{
			int num = this.SelectedIpId;
			if (num == -1)
			{
				object openParam = this.OpenParam;
				if (openParam is int)
				{
					int num2 = (int)openParam;
					num = num2;
				}
				else
				{
					num = this.IndexToIp(0);
				}
			}
			this.RefreshByIpId(num, false);
		}

		// Token: 0x06041D44 RID: 269636 RVA: 0x010E3EAA File Offset: 0x010E20AA
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
		}

		// Token: 0x06041D45 RID: 269637 RVA: 0x010E3EC8 File Offset: 0x010E20C8
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
		}

		// Token: 0x06041D46 RID: 269638 RVA: 0x010E3EE8 File Offset: 0x010E20E8
		private void OnSequencePlayEvent(string seqName, string eventName)
		{
			if (seqName != "Switch" || eventName != "Switch")
			{
				return;
			}
			MotorLinkageBackgroundItem motorLinkageBackgroundItem;
			if (!this.BackgroundItemMap.TryGetValue(this.SelectedIpId, out motorLinkageBackgroundItem))
			{
				return;
			}
			motorLinkageBackgroundItem.RefreshTexture();
		}

		// Token: 0x06041D47 RID: 269639 RVA: 0x010E3F2C File Offset: 0x010E212C
		private void OnRefreshRedDot(int activityId)
		{
			ActivityMotorLinkageController instance = ControllerBase<ActivityMotorLinkageController>.Instance;
			int? num = (instance != null) ? new int?(instance.ActivityId) : null;
			if (!(activityId == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			this.RefreshByIpId(this.SelectedIpId, true);
		}

		// Token: 0x06041D48 RID: 269640 RVA: 0x010E3F7A File Offset: 0x010E217A
		private void OnClickLeft()
		{
			this.RefreshByIpId(this.GetLeftIpId(), false);
		}

		// Token: 0x06041D49 RID: 269641 RVA: 0x010E3F89 File Offset: 0x010E2189
		private void OnClickRight()
		{
			this.RefreshByIpId(this.GetRightIpId(), false);
		}

		// Token: 0x06041D4A RID: 269642 RVA: 0x010E3F98 File Offset: 0x010E2198
		private void RefreshByIpId(int ipId, bool skipAnim = false)
		{
			this.RefreshBackground(ipId, skipAnim);
			this.SelectedIpId = ipId;
			this.RefreshIpProgress(ipId);
			this.RefreshQuestListByIpId(ipId, !skipAnim);
			this.RefreshArrowRedPoint();
			this.RefreshTitle();
		}

		// Token: 0x06041D4B RID: 269643 RVA: 0x010E3FC8 File Offset: 0x010E21C8
		private void RefreshTitle()
		{
			MotorLinkageIp ipConfig = ConfigBase<ActivityMotorLinkageConfig>.Instance.GetIpConfig(this.SelectedIpId);
			PopupCaptionItem caption = this.Caption;
			if (caption == null)
			{
				return;
			}
			caption.SetTitleLocalText(ipConfig.IpName);
		}

		// Token: 0x06041D4C RID: 269644 RVA: 0x010E4000 File Offset: 0x010E2200
		private void RefreshArrowRedPoint()
		{
			ActivityMotorLinkageData activityData = ControllerBase<ActivityMotorLinkageController>.Instance.ActivityData;
			int leftIpId = this.GetLeftIpId();
			bool uiactive = activityData.IpHasAnyRewardCanReceive(leftIpId);
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			int rightIpId = this.GetRightIpId();
			bool uiactive2 = activityData.IpHasAnyRewardCanReceive(rightIpId);
			UUIItem item2 = base.GetItem(7);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(uiactive2);
		}

		// Token: 0x06041D4D RID: 269645 RVA: 0x010E405C File Offset: 0x010E225C
		private void RefreshBackground(int ipId, bool skipAnim = false)
		{
			MotorLinkageBackgroundItem motorLinkageBackgroundItem;
			this.BackgroundItemMap.TryGetValue(this.SelectedIpId, out motorLinkageBackgroundItem);
			if (ipId == this.SelectedIpId)
			{
				if (motorLinkageBackgroundItem != null)
				{
					motorLinkageBackgroundItem.Refresh(skipAnim);
				}
				return;
			}
			if (motorLinkageBackgroundItem != null)
			{
				motorLinkageBackgroundItem.Hide(null);
			}
			MotorLinkageBackgroundItem motorLinkageBackgroundItem2;
			if (this.BackgroundItemMap.TryGetValue(ipId, out motorLinkageBackgroundItem2) && motorLinkageBackgroundItem2 != null)
			{
				motorLinkageBackgroundItem2.Show(null);
			}
		}

		// Token: 0x06041D4E RID: 269646 RVA: 0x010E40B8 File Offset: 0x010E22B8
		private void RefreshIpProgress(int ipId)
		{
			ActivityMotorLinkageData activityData = ControllerBase<ActivityMotorLinkageController>.Instance.ActivityData;
			int ipCurrentProgress = activityData.GetIpCurrentProgress(ipId);
			int ipTotalProgress = activityData.GetIpTotalProgress(ipId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "MotorLinkage_IP_Progress", new <>z__ReadOnlyArray<object>(new object[]
			{
				ipCurrentProgress,
				ipTotalProgress
			}));
		}

		// Token: 0x06041D4F RID: 269647 RVA: 0x010E4114 File Offset: 0x010E2314
		private void RefreshQuestListByIpId(int ipId, bool playAnim = true)
		{
			List<int> sortedQuestList = ControllerBase<ActivityMotorLinkageController>.Instance.ActivityData.GetSortedQuestList(ipId);
			GenericScrollViewNew<MotorQuestItem, int> questScrollView = this.QuestScrollView;
			if (questScrollView == null)
			{
				return;
			}
			questScrollView.RefreshByData(sortedQuestList, null, playAnim);
		}

		// Token: 0x06041D50 RID: 269648 RVA: 0x010E4145 File Offset: 0x010E2345
		private MotorQuestItem QuestItemProxyCreate()
		{
			return new MotorQuestItem();
		}

		// Token: 0x06041D51 RID: 269649 RVA: 0x010E414C File Offset: 0x010E234C
		private int GetLeftIpId()
		{
			int num = this.IpToIndex(this.SelectedIpId);
			int count = this.GetSortedIpList().Count;
			int num2 = num - 1;
			if (num2 < 0)
			{
				num2 += count;
			}
			return this.IndexToIp(num2);
		}

		// Token: 0x06041D52 RID: 269650 RVA: 0x010E4184 File Offset: 0x010E2384
		private int GetRightIpId()
		{
			int num = this.IpToIndex(this.SelectedIpId);
			int count = this.GetSortedIpList().Count;
			int num2 = num + 1;
			if (num2 >= count)
			{
				num2 -= count;
			}
			return this.IndexToIp(num2);
		}

		// Token: 0x06041D53 RID: 269651 RVA: 0x010E41BC File Offset: 0x010E23BC
		private int IpToIndex(int ipId)
		{
			return this.GetSortedIpList().FindIndex((int id) => id == ipId);
		}

		// Token: 0x06041D54 RID: 269652 RVA: 0x010E41ED File Offset: 0x010E23ED
		private int IndexToIp(int index)
		{
			return this.GetSortedIpList()[index];
		}

		// Token: 0x06041D55 RID: 269653 RVA: 0x010E41FB File Offset: 0x010E23FB
		private List<int> GetSortedIpList()
		{
			return ControllerBase<ActivityMotorLinkageController>.Instance.ActivityData.GetSortedIpList();
		}

		// Token: 0x04024BC6 RID: 150470
		[Nullable(2)]
		private PopupCaptionItem Caption;

		// Token: 0x04024BC7 RID: 150471
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<MotorQuestItem, int> QuestScrollView;

		// Token: 0x04024BC8 RID: 150472
		private int SelectedIpId = -1;

		// Token: 0x04024BC9 RID: 150473
		private readonly Dictionary<int, MotorLinkageBackgroundItem> BackgroundItemMap = new Dictionary<int, MotorLinkageBackgroundItem>();
	}
}
