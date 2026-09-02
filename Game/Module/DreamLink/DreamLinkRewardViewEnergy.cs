using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DAA RID: 23978
	public class DreamLinkRewardViewEnergy : UiViewBase
	{
		// Token: 0x0603C602 RID: 247298 RVA: 0x00F53247 File Offset: 0x00F51447
		[NullableContext(1)]
		public DreamLinkRewardViewEnergy(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603C603 RID: 247299 RVA: 0x00F53250 File Offset: 0x00F51450
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C604 RID: 247300 RVA: 0x00F532DC File Offset: 0x00F514DC
		protected override UniTask OnBeforeStartAsync()
		{
			DreamLinkRewardViewEnergy.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DreamLinkRewardViewEnergy.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C605 RID: 247301 RVA: 0x00F5331F File Offset: 0x00F5151F
		protected override void OnStart()
		{
			this.ActivityDataBase = ControllerBase<DreamLinkController>.Instance.GetCurrentActivityData();
		}

		// Token: 0x0603C606 RID: 247302 RVA: 0x00F53331 File Offset: 0x00F51531
		protected override void OnBeforeShow()
		{
			this.RefreshLayout();
			this.RefreshEnergy();
		}

		// Token: 0x0603C607 RID: 247303 RVA: 0x00F53340 File Offset: 0x00F51540
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.DreamLinkRewardRefresh, new Action(this.OnLayoutRefresh));
		}

		// Token: 0x0603C608 RID: 247304 RVA: 0x00F5335E File Offset: 0x00F5155E
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.DreamLinkRewardRefresh, new Action(this.OnLayoutRefresh));
		}

		// Token: 0x0603C609 RID: 247305 RVA: 0x00F5337C File Offset: 0x00F5157C
		[NullableContext(1)]
		private DreamLinkRewardEnergyItem CreateTaskItem()
		{
			DreamLinkRewardEnergyItem dreamLinkRewardEnergyItem = new DreamLinkRewardEnergyItem();
			dreamLinkRewardEnergyItem.SetBtnClickCallback(delegate
			{
				List<DreamLinkRewardData> energyRewardDataList = this.ActivityDataBase.GetEnergyRewardDataList();
				ControllerBase<DreamLinkController>.Instance.MultiEnergyRewardRequest((from data in energyRewardDataList
				where data.Status == EActivityTaskState.FinishedAndUnclaimed
				select data.Id).ToArray<int>());
			});
			return dreamLinkRewardEnergyItem;
		}

		// Token: 0x0603C60A RID: 247306 RVA: 0x00F53395 File Offset: 0x00F51595
		private void OnLayoutRefresh()
		{
			this.RefreshLayout();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, this.ActivityDataBase.Id);
		}

		// Token: 0x0603C60B RID: 247307 RVA: 0x00F533BC File Offset: 0x00F515BC
		private UniTask RefreshLayout()
		{
			DreamLinkRewardViewEnergy.<RefreshLayout>d__13 <RefreshLayout>d__;
			<RefreshLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshLayout>d__.<>4__this = this;
			<RefreshLayout>d__.<>1__state = -1;
			<RefreshLayout>d__.<>t__builder.Start<DreamLinkRewardViewEnergy.<RefreshLayout>d__13>(ref <RefreshLayout>d__);
			return <RefreshLayout>d__.<>t__builder.Task;
		}

		// Token: 0x0603C60C RID: 247308 RVA: 0x00F53400 File Offset: 0x00F51600
		private void RefreshEnergy()
		{
			int maxEnergy = this.ActivityDataBase.MaxEnergy;
			int energyItemCount = this.ActivityDataBase.GetEnergyItemCount();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "DreamLink_Reward_Ins_Progress", new <>z__ReadOnlyArray<object>(new object[]
			{
				energyItemCount,
				maxEnergy
			}));
		}

		// Token: 0x04021F32 RID: 139058
		[Nullable(2)]
		private DreamLinkData ActivityDataBase;

		// Token: 0x04021F33 RID: 139059
		[Nullable(2)]
		private PopupCaptionItem CaptionComponent;

		// Token: 0x04021F34 RID: 139060
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<DreamLinkRewardEnergyItem, DreamLinkRewardData> TaskLayout;

		// Token: 0x0200BDEA RID: 48618
		private class EComponentDefine
		{
			// Token: 0x0403A78E RID: 239502
			public const int Layout = 0;

			// Token: 0x0403A78F RID: 239503
			public const int CaptionItem = 1;

			// Token: 0x0403A790 RID: 239504
			public const int Text = 2;
		}
	}
}
