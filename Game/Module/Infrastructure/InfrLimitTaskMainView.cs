using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C59 RID: 23641
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrLimitTaskMainView : UiViewBase
	{
		// Token: 0x0603BB9F RID: 244639 RVA: 0x00F2169B File Offset: 0x00F1F89B
		public InfrLimitTaskMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603BBA0 RID: 244640 RVA: 0x00F216B0 File Offset: 0x00F1F8B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BBA1 RID: 244641 RVA: 0x00F217BE File Offset: 0x00F1F9BE
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.InfrastructureActivityTaskDataUpdate, new Action(this.OnInfrastructureActivityTaskDataUpdate));
		}

		// Token: 0x0603BBA2 RID: 244642 RVA: 0x00F217DC File Offset: 0x00F1F9DC
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.InfrastructureActivityTaskDataUpdate, new Action(this.OnInfrastructureActivityTaskDataUpdate));
		}

		// Token: 0x0603BBA3 RID: 244643 RVA: 0x00F217FC File Offset: 0x00F1F9FC
		protected override UniTask OnBeforeStartAsync()
		{
			InfrLimitTaskMainView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InfrLimitTaskMainView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BBA4 RID: 244644 RVA: 0x00F2183F File Offset: 0x00F1FA3F
		private InfrLimitTaskItem CreateTaskItem()
		{
			InfrLimitTaskItem infrLimitTaskItem = new InfrLimitTaskItem();
			infrLimitTaskItem.SetOnClickRewardCb(new Action(this.OnClickGetTaskReward));
			return infrLimitTaskItem;
		}

		// Token: 0x0603BBA5 RID: 244645 RVA: 0x00F21858 File Offset: 0x00F1FA58
		private UniTask CreateTaskScroll()
		{
			InfrLimitTaskMainView.<CreateTaskScroll>d__8 <CreateTaskScroll>d__;
			<CreateTaskScroll>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateTaskScroll>d__.<>4__this = this;
			<CreateTaskScroll>d__.<>1__state = -1;
			<CreateTaskScroll>d__.<>t__builder.Start<InfrLimitTaskMainView.<CreateTaskScroll>d__8>(ref <CreateTaskScroll>d__);
			return <CreateTaskScroll>d__.<>t__builder.Task;
		}

		// Token: 0x0603BBA6 RID: 244646 RVA: 0x00F2189B File Offset: 0x00F1FA9B
		protected override void OnStart()
		{
			this.CaptionItem.SetHelpCallBack(new Action(this.OnClickHelpBtn));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickCloseBtn));
			this.RefreshTime();
		}

		// Token: 0x0603BBA7 RID: 244647 RVA: 0x00F218D4 File Offset: 0x00F1FAD4
		private void RefreshTime()
		{
			InfrastructureActivityData activityData = ModelBase<InfrastructureModel>.Instance.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			CommonDefine.ICountDown activityCountDownData = activityData.GetActivityCountDownData();
			base.GetText(5).SetText(activityCountDownData.CountDownText ?? "", true);
			if (activityData.EndOpenTime <= 0L)
			{
				base.GetItem(6).SetUIActive(false);
			}
		}

		// Token: 0x0603BBA8 RID: 244648 RVA: 0x00F2192C File Offset: 0x00F1FB2C
		private void OnInfrastructureActivityTaskDataUpdate()
		{
			InfrastructureActivityData activityData = ModelBase<InfrastructureModel>.Instance.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			this.TaskScroll.RefreshByData(activityData.GetActivityTaskDataList(), false, null, false);
		}

		// Token: 0x0603BBA9 RID: 244649 RVA: 0x00F2195C File Offset: 0x00F1FB5C
		private void OnClickGetTaskReward()
		{
			InfrastructureActivityData activityData = ModelBase<InfrastructureModel>.Instance.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			List<InfrastructureLimitTaskData> activityTaskDataListByStatus = activityData.GetActivityTaskDataListByStatus(ActivityTaskState.ActivityTaskFinish);
			if (activityTaskDataListByStatus.Count == 0)
			{
				return;
			}
			ControllerBase<InfrastructureController>.Instance.RequestInfrLimitTaskRewardRequest(activityData.Id, activityTaskDataListByStatus.ConvertAll<int>((InfrastructureLimitTaskData task) => task.ConfigId).ToArray()).Forget<bool>();
		}

		// Token: 0x0603BBAA RID: 244650 RVA: 0x00F219C8 File Offset: 0x00F1FBC8
		private void OnClickHelpBtn()
		{
			int helpIdActivity = ConfigBase<InfrastructureConfig>.Instance.GetHelpIdActivity();
			ControllerBase<HelpController>.Instance.OpenHelpById(helpIdActivity);
		}

		// Token: 0x0603BBAB RID: 244651 RVA: 0x00F219EB File Offset: 0x00F1FBEB
		private void OnClickCloseBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x04021931 RID: 137521
		private readonly PopupCaptionItem CaptionItem = new PopupCaptionItem(null);

		// Token: 0x04021932 RID: 137522
		private LoopScrollView<InfrLimitTaskItem, InfrastructureLimitTaskData> TaskScroll;

		// Token: 0x0200BCD7 RID: 48343
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403A2E0 RID: 238304
			public const int CaptionItem = 0;

			// Token: 0x0403A2E1 RID: 238305
			public const int TextTitle = 1;

			// Token: 0x0403A2E2 RID: 238306
			public const int TextDesc = 2;

			// Token: 0x0403A2E3 RID: 238307
			public const int LoopScrollViewReward = 3;

			// Token: 0x0403A2E4 RID: 238308
			public const int PanelReward = 4;

			// Token: 0x0403A2E5 RID: 238309
			public const int TextTime = 5;

			// Token: 0x0403A2E6 RID: 238310
			public const int PanelTime = 6;
		}
	}
}
