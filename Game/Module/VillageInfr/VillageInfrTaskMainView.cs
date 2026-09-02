using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C1F RID: 19487
	[NullableContext(1)]
	[Nullable(0)]
	public class VillageInfrTaskMainView : UiViewBase
	{
		// Token: 0x06032D25 RID: 208165 RVA: 0x00CBC08E File Offset: 0x00CBA28E
		public VillageInfrTaskMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06032D26 RID: 208166 RVA: 0x00CBC0B0 File Offset: 0x00CBA2B0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
		}

		// Token: 0x06032D27 RID: 208167 RVA: 0x00CBC178 File Offset: 0x00CBA378
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.VillageInfrActivityTaskDataUpdate, new Action(this.OnTaskDataUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.VillageInfrScoreRewardDataUpdate, new Action(this.OnScoreRewardDataUpdate));
		}

		// Token: 0x06032D28 RID: 208168 RVA: 0x00CBC1B2 File Offset: 0x00CBA3B2
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.VillageInfrActivityTaskDataUpdate, new Action(this.OnTaskDataUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.VillageInfrScoreRewardDataUpdate, new Action(this.OnScoreRewardDataUpdate));
		}

		// Token: 0x06032D29 RID: 208169 RVA: 0x00CBC1EC File Offset: 0x00CBA3EC
		protected override UniTask OnBeforeStartAsync()
		{
			VillageInfrTaskMainView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VillageInfrTaskMainView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032D2A RID: 208170 RVA: 0x00CBC230 File Offset: 0x00CBA430
		private UniTask CreateCaption()
		{
			VillageInfrTaskMainView.<CreateCaption>d__8 <CreateCaption>d__;
			<CreateCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaption>d__.<>4__this = this;
			<CreateCaption>d__.<>1__state = -1;
			<CreateCaption>d__.<>t__builder.Start<VillageInfrTaskMainView.<CreateCaption>d__8>(ref <CreateCaption>d__);
			return <CreateCaption>d__.<>t__builder.Task;
		}

		// Token: 0x06032D2B RID: 208171 RVA: 0x00CBC274 File Offset: 0x00CBA474
		private UniTask CreateBottomPanel()
		{
			VillageInfrTaskMainView.<CreateBottomPanel>d__9 <CreateBottomPanel>d__;
			<CreateBottomPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBottomPanel>d__.<>4__this = this;
			<CreateBottomPanel>d__.<>1__state = -1;
			<CreateBottomPanel>d__.<>t__builder.Start<VillageInfrTaskMainView.<CreateBottomPanel>d__9>(ref <CreateBottomPanel>d__);
			return <CreateBottomPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06032D2C RID: 208172 RVA: 0x00CBC2B7 File Offset: 0x00CBA4B7
		private void CreateTaskScroll()
		{
			this.TaskScroll = new GenericScrollViewNew<VillageTaskItem, VillageInfrLimitTaskData>(base.GetScrollViewWithScrollbar(5), delegate()
			{
				VillageTaskItem villageTaskItem = new VillageTaskItem();
				villageTaskItem.SetOnClickConfirm(new Action<VillageInfrLimitTaskData>(this.OnClickConfirm));
				return villageTaskItem;
			}, null, false, null);
		}

		// Token: 0x06032D2D RID: 208173 RVA: 0x00CBC2DA File Offset: 0x00CBA4DA
		protected override void OnStart()
		{
			this.RefreshTaskList();
		}

		// Token: 0x06032D2E RID: 208174 RVA: 0x00CBC2E4 File Offset: 0x00CBA4E4
		private void RefreshTaskList()
		{
			List<VillageInfrLimitTaskData> activityTaskDataList = ModelBase<VillageInfrModel>.Instance.GetActivityTaskDataList();
			this.TaskScroll.RefreshByData(activityTaskDataList, null, true);
		}

		// Token: 0x06032D2F RID: 208175 RVA: 0x00CBC30A File Offset: 0x00CBA50A
		private void RefreshBottomPanel()
		{
			this.BottomPanel.Refresh();
		}

		// Token: 0x06032D30 RID: 208176 RVA: 0x00CBC317 File Offset: 0x00CBA517
		private void OnTaskDataUpdate()
		{
			this.RefreshTaskList();
			this.RefreshBottomPanel();
		}

		// Token: 0x06032D31 RID: 208177 RVA: 0x00CBC325 File Offset: 0x00CBA525
		private void OnScoreRewardDataUpdate()
		{
			this.RefreshTaskList();
			this.RefreshBottomPanel();
		}

		// Token: 0x06032D32 RID: 208178 RVA: 0x00CBC334 File Offset: 0x00CBA534
		private void OnClickConfirm(VillageInfrLimitTaskData data)
		{
			List<int> list = new List<int>();
			foreach (VillageInfrLimitTaskData villageInfrLimitTaskData in ModelBase<VillageInfrModel>.Instance.GetActivityTaskDataList())
			{
				if (villageInfrLimitTaskData.CanReceive())
				{
					list.Add(villageInfrLimitTaskData.ConfigId);
				}
			}
			if (list.Count > 0)
			{
				ControllerBase<VillageInfrController>.Instance.RequestInfrV2TaskReward(list).Forget<bool>();
			}
		}

		// Token: 0x0401D958 RID: 121176
		private readonly PopupCaptionItem CaptionItem = new PopupCaptionItem(null);

		// Token: 0x0401D959 RID: 121177
		private readonly VillageInfrTaskBottomPanel BottomPanel = new VillageInfrTaskBottomPanel();

		// Token: 0x0401D95A RID: 121178
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<VillageTaskItem, VillageInfrLimitTaskData> TaskScroll;
	}
}
