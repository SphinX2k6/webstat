using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E49 RID: 20041
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseRewardView : UiTickViewBase
	{
		// Token: 0x06033CC2 RID: 212162 RVA: 0x00CF2C7B File Offset: 0x00CF0E7B
		public TrapDefenseRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033CC3 RID: 212163 RVA: 0x00CF2C84 File Offset: 0x00CF0E84
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033CC4 RID: 212164 RVA: 0x00CF2D94 File Offset: 0x00CF0F94
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseRewardView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseRewardView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033CC5 RID: 212165 RVA: 0x00CF2DD8 File Offset: 0x00CF0FD8
		protected override void OnStart()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelReward.RegisterOnSelectRewardTypeChange(new Action<ETrapDefenseRewardType>(this.OnSelectedTypeChange));
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(delegate
			{
				base.CloseMe(null);
			});
			this.CaptionItem.SetHelpCallBack(delegate
			{
				int helpIdFixedReward = ConfigBase<TrapDefenseConfig>.Instance.GetHelpIdFixedReward();
				ControllerBase<HelpController>.Instance.OpenHelpById(helpIdFixedReward);
			});
			this.SpecialRewardItem.Refresh(ModelBase<TrapDefenseModel>.Instance.RewardData.SpecialRewardData);
			this.LayoutTabs.SelectGridProxy(0, false);
			this.HasStartAnimPlayed = true;
		}

		// Token: 0x06033CC6 RID: 212166 RVA: 0x00CF2E81 File Offset: 0x00CF1081
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseRewardUpdate, new Action(this.OnRewardUpdate));
		}

		// Token: 0x06033CC7 RID: 212167 RVA: 0x00CF2E9F File Offset: 0x00CF109F
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseRewardUpdate, new Action(this.OnRewardUpdate));
		}

		// Token: 0x06033CC8 RID: 212168 RVA: 0x00CF2EC0 File Offset: 0x00CF10C0
		protected override void OnTick(float deltaTime)
		{
			string limitRewardRemainTimeStr = ModelBase<TrapDefenseModel>.Instance.RewardData.GetLimitRewardRemainTimeStr();
			base.GetText(3).SetText(limitRewardRemainTimeStr, true);
		}

		// Token: 0x06033CC9 RID: 212169 RVA: 0x00CF2EEB File Offset: 0x00CF10EB
		protected override void OnBeforeDestroy()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelReward.UnregisterOnSelectRewardTypeChange(new Action<ETrapDefenseRewardType>(this.OnSelectedTypeChange));
			ModelBase<TrapDefenseModel>.Instance.ViewModelReward.Clear();
		}

		// Token: 0x06033CCA RID: 212170 RVA: 0x00CF2F18 File Offset: 0x00CF1118
		private void OnSelectedTypeChange(ETrapDefenseRewardType type)
		{
			if (this.HasStartAnimPlayed)
			{
				this.LayoutRewards.GetGenericLayout().GetUiAnimController().StartTime = 0f;
			}
			this.LayoutRewards.RefreshByData(ModelBase<TrapDefenseModel>.Instance.RewardData.GetRewardListByType(type), null, true);
		}

		// Token: 0x06033CCB RID: 212171 RVA: 0x00CF2F64 File Offset: 0x00CF1164
		private void OnRewardUpdate()
		{
			ETrapDefenseRewardType curSelectRewardType = ModelBase<TrapDefenseModel>.Instance.ViewModelReward.CurSelectRewardType;
			List<TrapDefenseRewardItemData> rewardListByType = ModelBase<TrapDefenseModel>.Instance.RewardData.GetRewardListByType(curSelectRewardType);
			this.LayoutTabs.RefreshByData(ModelBase<TrapDefenseModel>.Instance.ViewModelReward.GetRewardTypeDataList(), null, false);
			this.LayoutRewards.RefreshByData(rewardListByType, null, false);
			this.SpecialRewardItem.Refresh(ModelBase<TrapDefenseModel>.Instance.RewardData.SpecialRewardData);
		}

		// Token: 0x06033CCC RID: 212172 RVA: 0x00CF2FD6 File Offset: 0x00CF11D6
		private void OnClaimReward(TrapDefenseRewardItemData data)
		{
			ModelBase<TrapDefenseModel>.Instance.RewardData.RequestClaimRewardByType(data.Type);
		}

		// Token: 0x0401DF96 RID: 122774
		private GenericLayout<TrapDefenseRewardTabItem, TrapDefenseRewardTabData> LayoutTabs;

		// Token: 0x0401DF97 RID: 122775
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401DF98 RID: 122776
		private GenericScrollViewNew<TrapDefenseRewardItem, TrapDefenseRewardItemData> LayoutRewards;

		// Token: 0x0401DF99 RID: 122777
		private TrapDefenseSpecialRewardItem SpecialRewardItem;

		// Token: 0x0401DF9A RID: 122778
		private bool HasStartAnimPlayed;

		// Token: 0x0200ADDC RID: 44508
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04035FC2 RID: 221122
			public const int ItemCaption = 0;

			// Token: 0x04035FC3 RID: 221123
			public const int LayoutTabs = 1;

			// Token: 0x04035FC4 RID: 221124
			public const int ItemTab = 2;

			// Token: 0x04035FC5 RID: 221125
			public const int TextTime = 3;

			// Token: 0x04035FC6 RID: 221126
			public const int LayoutRewards = 4;

			// Token: 0x04035FC7 RID: 221127
			public const int ItemReward = 5;

			// Token: 0x04035FC8 RID: 221128
			public const int ItemSpecialReward = 6;
		}
	}
}
