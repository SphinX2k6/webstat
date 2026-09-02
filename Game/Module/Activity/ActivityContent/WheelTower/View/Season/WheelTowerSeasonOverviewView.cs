using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season
{
	// Token: 0x02006242 RID: 25154
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerSeasonOverviewView : UiViewBase
	{
		// Token: 0x0603F6CB RID: 259787 RVA: 0x01042000 File Offset: 0x01040200
		public WheelTowerSeasonOverviewView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603F6CC RID: 259788 RVA: 0x0104200C File Offset: 0x0104020C
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

		// Token: 0x0603F6CD RID: 259789 RVA: 0x01042098 File Offset: 0x01040298
		protected override UniTask OnBeforeStartAsync()
		{
			WheelTowerSeasonOverviewView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerSeasonOverviewView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F6CE RID: 259790 RVA: 0x010420DC File Offset: 0x010402DC
		private UniTask RefreshSeasonScrollAsync()
		{
			WheelTowerSeasonOverviewView.<RefreshSeasonScrollAsync>d__6 <RefreshSeasonScrollAsync>d__;
			<RefreshSeasonScrollAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshSeasonScrollAsync>d__.<>4__this = this;
			<RefreshSeasonScrollAsync>d__.<>1__state = -1;
			<RefreshSeasonScrollAsync>d__.<>t__builder.Start<WheelTowerSeasonOverviewView.<RefreshSeasonScrollAsync>d__6>(ref <RefreshSeasonScrollAsync>d__);
			return <RefreshSeasonScrollAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F6CF RID: 259791 RVA: 0x01042120 File Offset: 0x01040320
		private void SetSelectedSeasonId(int seasonId)
		{
			if (this.CurrentSelectedSeasonId != 0 && this.CurrentSelectedSeasonId != seasonId)
			{
				GenericScrollViewNew<WheelTowerSeasonOverviewItem, int> seasonScroll = this.SeasonScroll;
				if (seasonScroll != null)
				{
					WheelTowerSeasonOverviewItem scrollItemByKey = seasonScroll.GetScrollItemByKey(this.CurrentSelectedSeasonId);
					if (scrollItemByKey != null)
					{
						scrollItemByKey.SetSelected(false);
					}
				}
			}
			GenericScrollViewNew<WheelTowerSeasonOverviewItem, int> seasonScroll2 = this.SeasonScroll;
			if (seasonScroll2 != null)
			{
				WheelTowerSeasonOverviewItem scrollItemByKey2 = seasonScroll2.GetScrollItemByKey(seasonId);
				if (scrollItemByKey2 != null)
				{
					scrollItemByKey2.SetSelected(true);
				}
			}
			this.CurrentSelectedSeasonId = seasonId;
		}

		// Token: 0x0603F6D0 RID: 259792 RVA: 0x01042190 File Offset: 0x01040390
		private WheelTowerSeasonOverviewItem CreateItem()
		{
			WheelTowerSeasonOverviewItem wheelTowerSeasonOverviewItem = new WheelTowerSeasonOverviewItem();
			wheelTowerSeasonOverviewItem.SetClickCallback(new Action<int>(this.OnSeasonItemClick));
			return wheelTowerSeasonOverviewItem;
		}

		// Token: 0x0603F6D1 RID: 259793 RVA: 0x010421AC File Offset: 0x010403AC
		private void OnSeasonItemClick(int seasonId)
		{
			WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
			int num = (activityData != null) ? activityData.SeasonId : 0;
			if (seasonId != num)
			{
				GenericScrollViewNew<WheelTowerSeasonOverviewItem, int> seasonScroll = this.SeasonScroll;
				if (seasonScroll != null)
				{
					WheelTowerSeasonOverviewItem scrollItemByKey = seasonScroll.GetScrollItemByKey(seasonId);
					if (scrollItemByKey != null)
					{
						scrollItemByKey.SetSelected(false);
					}
				}
			}
			GenericScrollViewNew<WheelTowerSeasonOverviewItem, int> seasonScroll2 = this.SeasonScroll;
			if (seasonScroll2 != null)
			{
				WheelTowerSeasonOverviewItem scrollItemByKey2 = seasonScroll2.GetScrollItemByKey(num);
				if (scrollItemByKey2 != null)
				{
					scrollItemByKey2.SetSelected(true);
				}
			}
			ControllerBase<WheelTowerController>.Instance.OpenSeasonMedalView(seasonId, false);
		}

		// Token: 0x0603F6D2 RID: 259794 RVA: 0x01042226 File Offset: 0x01040426
		private void ClickCloseCallback()
		{
			base.CloseMe(null);
		}

		// Token: 0x04023979 RID: 145785
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<WheelTowerSeasonOverviewItem, int> SeasonScroll;

		// Token: 0x0402397A RID: 145786
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0402397B RID: 145787
		private int CurrentSelectedSeasonId;
	}
}
