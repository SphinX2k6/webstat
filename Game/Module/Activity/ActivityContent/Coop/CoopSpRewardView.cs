using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x020069A3 RID: 27043
	[NullableContext(1)]
	[Nullable(0)]
	public class CoopSpRewardView : UiViewBase
	{
		// Token: 0x06043137 RID: 274743 RVA: 0x0113A6FB File Offset: 0x011388FB
		public CoopSpRewardView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043138 RID: 274744 RVA: 0x0113A704 File Offset: 0x01138904
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick))
			};
		}

		// Token: 0x06043139 RID: 274745 RVA: 0x0113A781 File Offset: 0x01138981
		protected override void OnStart()
		{
			this.ActivityData = (this.OpenParam as CoopActivityData);
			this.RewardLayout = new GenericScrollViewNew<CoopSpRewardItem, CoopSpRewardData>(base.GetScrollViewWithScrollbar(1), new Func<CoopSpRewardItem>(this.CreateRewardItem), null, false, null);
			this.RefreshRewardLayout(true);
		}

		// Token: 0x0604313A RID: 274746 RVA: 0x0113A7BC File Offset: 0x011389BC
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnCoopLevelUpdate, new Action(this.OnDataUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.OnCoopSpUpdate, new Action(this.OnDataUpdate));
		}

		// Token: 0x0604313B RID: 274747 RVA: 0x0113A7F6 File Offset: 0x011389F6
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCoopLevelUpdate, new Action(this.OnDataUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCoopSpUpdate, new Action(this.OnDataUpdate));
		}

		// Token: 0x0604313C RID: 274748 RVA: 0x0113A830 File Offset: 0x01138A30
		private void OnDataUpdate()
		{
			this.RefreshRewardLayout(false);
		}

		// Token: 0x0604313D RID: 274749 RVA: 0x0113A839 File Offset: 0x01138A39
		private void RefreshRewardLayout(bool isPlayAnim = false)
		{
			this.RewardLayout.RefreshByData(this.ActivityData.CoopSpRewardDataList, delegate
			{
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
				if (scrollViewWithScrollbar == null)
				{
					return;
				}
				scrollViewWithScrollbar.SetScrollProgress(0f);
			}, isPlayAnim);
		}

		// Token: 0x0604313E RID: 274750 RVA: 0x0113A85E File Offset: 0x01138A5E
		private CoopSpRewardItem CreateRewardItem()
		{
			return new CoopSpRewardItem
			{
				OnRewardBtnClick = new Action(this.OnRewardBtnClick)
			};
		}

		// Token: 0x0604313F RID: 274751 RVA: 0x0113A877 File Offset: 0x01138A77
		private void OnRewardBtnClick()
		{
			ControllerBase<CoopActivityController>.Instance.RequestCoopSpReward(this.ActivityData);
		}

		// Token: 0x06043140 RID: 274752 RVA: 0x0113A889 File Offset: 0x01138A89
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0402560E RID: 153102
		[Nullable(2)]
		private CoopActivityData ActivityData;

		// Token: 0x0402560F RID: 153103
		private GenericScrollViewNew<CoopSpRewardItem, CoopSpRewardData> RewardLayout;
	}
}
