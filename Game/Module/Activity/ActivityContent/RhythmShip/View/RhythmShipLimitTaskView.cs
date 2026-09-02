using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064EE RID: 25838
	[NullableContext(1)]
	[Nullable(0)]
	public class RhythmShipLimitTaskView : UiTickViewBase
	{
		// Token: 0x06040B49 RID: 265033 RVA: 0x01097910 File Offset: 0x01095B10
		public RhythmShipLimitTaskView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040B4A RID: 265034 RVA: 0x01097924 File Offset: 0x01095B24
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnLookBtnClick))
			};
		}

		// Token: 0x06040B4B RID: 265035 RVA: 0x010979E3 File Offset: 0x01095BE3
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmShipTaskRefresh, new Action(this.OnRhythmShipTaskRefresh));
		}

		// Token: 0x06040B4C RID: 265036 RVA: 0x01097A01 File Offset: 0x01095C01
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmShipTaskRefresh, new Action(this.OnRhythmShipTaskRefresh));
		}

		// Token: 0x06040B4D RID: 265037 RVA: 0x01097A20 File Offset: 0x01095C20
		protected override UniTask OnBeforeStartAsync()
		{
			RhythmShipLimitTaskView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipLimitTaskView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040B4E RID: 265038 RVA: 0x01097A63 File Offset: 0x01095C63
		protected override void OnTick(float delta)
		{
			if (this.RefreshTime > 500f)
			{
				this.RefreshTimeText();
				this.RefreshTime = 0f;
			}
			this.RefreshTime += delta;
		}

		// Token: 0x06040B4F RID: 265039 RVA: 0x01097A91 File Offset: 0x01095C91
		protected override void OnStart()
		{
			this.TitleRemainTimeText = (ConfigBase<TextConfig>.Instance.GetMultiTextByKey("ActivityRemainingTime") ?? "");
			this.RefreshTaskScrollView();
			this.RefreshTimeText();
		}

		// Token: 0x06040B50 RID: 265040 RVA: 0x01097AC0 File Offset: 0x01095CC0
		private void RefreshTaskScrollView()
		{
			List<int> rhythmShipTaskIdByTypeAndActivityId = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipTaskIdByTypeAndActivityId(1, ModelBase<RhythmShipModel>.Instance.ActivityId);
			List<int> data = ModelBase<RhythmShipModel>.Instance.SortTaskItem(rhythmShipTaskIdByTypeAndActivityId, true);
			GenericScrollViewNew<RhythmShipTaskItem, int> taskScrollView = this.TaskScrollView;
			if (taskScrollView == null)
			{
				return;
			}
			taskScrollView.RefreshByData(data, null, true);
		}

		// Token: 0x06040B51 RID: 265041 RVA: 0x01097B04 File Offset: 0x01095D04
		private void RefreshTimeText()
		{
			RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
			if (activityData == null)
			{
				base.CloseMe(null);
				return;
			}
			if (!activityData.CheckIfInLimitTime())
			{
				base.CloseMe(null);
			}
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(activityData.EndRewardTime, this.TitleRemainTimeText);
			base.GetText(3).SetText(remainTimeText ?? "", true);
		}

		// Token: 0x06040B52 RID: 265042 RVA: 0x01097B64 File Offset: 0x01095D64
		private void OnRhythmShipTaskRefresh()
		{
			this.RefreshTaskScrollView();
		}

		// Token: 0x06040B53 RID: 265043 RVA: 0x01097B6C File Offset: 0x01095D6C
		private void OnLookBtnClick()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(80065017, true, null);
		}

		// Token: 0x04024434 RID: 148532
		private const int REFRESH_TIME = 500;

		// Token: 0x04024435 RID: 148533
		private const int REWARD_BUSINESS_CARD_ID = 80065017;

		// Token: 0x04024436 RID: 148534
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024437 RID: 148535
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<RhythmShipTaskItem, int> TaskScrollView;

		// Token: 0x04024438 RID: 148536
		private string TitleRemainTimeText = "";

		// Token: 0x04024439 RID: 148537
		private float RefreshTime;
	}
}
