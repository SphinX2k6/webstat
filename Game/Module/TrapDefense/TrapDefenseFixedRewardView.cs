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
	// Token: 0x02004E0E RID: 19982
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseFixedRewardView : UiViewBase
	{
		// Token: 0x06033AC4 RID: 211652 RVA: 0x00CE9E16 File Offset: 0x00CE8016
		public TrapDefenseFixedRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033AC5 RID: 211653 RVA: 0x00CE9E30 File Offset: 0x00CE8030
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033AC6 RID: 211654 RVA: 0x00CE9EBC File Offset: 0x00CE80BC
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseFixedRewardView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseFixedRewardView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033AC7 RID: 211655 RVA: 0x00CE9EFF File Offset: 0x00CE80FF
		protected override void OnStart()
		{
			this.UpdateData();
		}

		// Token: 0x06033AC8 RID: 211656 RVA: 0x00CE9F07 File Offset: 0x00CE8107
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseRewardUpdate, new Action(this.EventTrapDefenseRewardUpdate));
		}

		// Token: 0x06033AC9 RID: 211657 RVA: 0x00CE9F25 File Offset: 0x00CE8125
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseRewardUpdate, new Action(this.EventTrapDefenseRewardUpdate));
		}

		// Token: 0x06033ACA RID: 211658 RVA: 0x00CE9F43 File Offset: 0x00CE8143
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06033ACB RID: 211659 RVA: 0x00CE9F45 File Offset: 0x00CE8145
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033ACC RID: 211660 RVA: 0x00CE9F48 File Offset: 0x00CE8148
		public void OnBtnHelp()
		{
			int helpIdFixedReward = ConfigBase<TrapDefenseConfig>.Instance.GetHelpIdFixedReward();
			ControllerBase<HelpController>.Instance.OpenHelpById(helpIdFixedReward);
		}

		// Token: 0x06033ACD RID: 211661 RVA: 0x00CE9F6B File Offset: 0x00CE816B
		public void OnBtnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06033ACE RID: 211662 RVA: 0x00CE9F74 File Offset: 0x00CE8174
		public TrapDefenseRewardItem CreateItemReward()
		{
			return new TrapDefenseRewardItem
			{
				OnClaimRewardCallback = new Action<TrapDefenseRewardItemData>(this.OnClaimReward)
			};
		}

		// Token: 0x06033ACF RID: 211663 RVA: 0x00CE9F8D File Offset: 0x00CE818D
		public void UpdateData()
		{
			this.ScrollFixedReward.RefreshByData(this.ViewModel.GetFixedRewardDataList(), null, true);
		}

		// Token: 0x06033AD0 RID: 211664 RVA: 0x00CE9FA7 File Offset: 0x00CE81A7
		public void EventTrapDefenseRewardUpdate()
		{
			this.UpdateData();
		}

		// Token: 0x06033AD1 RID: 211665 RVA: 0x00CE9FAF File Offset: 0x00CE81AF
		private void OnClaimReward(TrapDefenseRewardItemData _)
		{
			ModelBase<TrapDefenseModel>.Instance.RewardData.RequestFixedReward();
		}

		// Token: 0x0401DED8 RID: 122584
		public TrapDefenseFixedRewardViewModel ViewModel = ModelBase<TrapDefenseModel>.Instance.ViewModelFixedReward;

		// Token: 0x0401DED9 RID: 122585
		public PopupCaptionItem PopupCaption;

		// Token: 0x0401DEDA RID: 122586
		public GenericScrollViewNew<TrapDefenseRewardItem, TrapDefenseRewardItemData> ScrollFixedReward;

		// Token: 0x0200AD82 RID: 44418
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035E2E RID: 220718
			public const int ItemCaption = 0;

			// Token: 0x04035E2F RID: 220719
			public const int ScrollReward = 1;

			// Token: 0x04035E30 RID: 220720
			public const int ItemReward = 2;
		}
	}
}
