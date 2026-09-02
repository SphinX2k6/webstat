using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DB8 RID: 23992
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DreamLinkWorldRunTaskItem : GridProxyAbstract<DreamLinkRunTaskData>
	{
		// Token: 0x0603C67E RID: 247422 RVA: 0x00F55244 File Offset: 0x00F53444
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickGetButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C67F RID: 247423 RVA: 0x00F55418 File Offset: 0x00F53618
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData>(base.GetScrollViewWithScrollbar(6), new Func<ActivitySmallItemGrid>(this.InitGridItem), null, false, null);
			base.GetItem(2).SetUIActive(false);
			this.JumpButton = new ButtonItem(base.GetItem(0));
			this.JumpButton.SetFunction(new Action<int>(this.OnClickJump));
		}

		// Token: 0x0603C680 RID: 247424 RVA: 0x00F5547C File Offset: 0x00F5367C
		private ActivitySmallItemGrid InitGridItem()
		{
			return new ActivitySmallItemGrid();
		}

		// Token: 0x0603C681 RID: 247425 RVA: 0x00F55484 File Offset: 0x00F53684
		public override void Refresh(DreamLinkRunTaskData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.TitleTextId, Array.Empty<object>());
			this.RewardScrollView.RefreshByData(data.GetRewardData(), null, false);
			bool flag = data.Status == EDreamLinkRunTaskState.Lock;
			bool flag2 = data.Status == EDreamLinkRunTaskState.Active;
			bool flag3 = data.Status == EDreamLinkRunTaskState.FinishedAndClaimed;
			bool flag4 = data.Status == EDreamLinkRunTaskState.FinishedAndUnclaimed;
			base.GetItem(4).SetUIActive(flag);
			if (flag)
			{
				base.GetText(5).SetText(data.GetLockTxt(), true);
			}
			base.GetItem(8).SetUIActive(flag3 || flag4);
			if (flag3 || flag4)
			{
				base.GetText(9).SetText(Singleton<TimeUtil>.Instance.GetTimeString((double)Math.Max(data.PlayTime, 0)), true);
			}
			if (flag2)
			{
				this.JumpButton.SetLocalTextNew("WorldRun_Button_State1", Array.Empty<object>());
			}
			else if (flag3)
			{
				this.JumpButton.SetLocalTextNew("WorldRun_Button_State2", Array.Empty<object>());
			}
			this.NeedTick = data.IsTimeLock();
			this.JumpButton.SetActive(flag2 || flag3);
			base.GetButton(1).RootUIComp.Get().SetUIActive(flag4);
			this.RefreshRedDot();
		}

		// Token: 0x0603C682 RID: 247426 RVA: 0x00F555B8 File Offset: 0x00F537B8
		public void RefreshLockText()
		{
			if (this.Data == null || this.Data.Status != EDreamLinkRunTaskState.Lock)
			{
				return;
			}
			if (!this.NeedTick)
			{
				return;
			}
			base.GetText(5).SetText(this.Data.GetLockTxt(), true);
		}

		// Token: 0x0603C683 RID: 247427 RVA: 0x00F555F4 File Offset: 0x00F537F4
		private void RefreshRedDot()
		{
			DreamLinkData currentActivityData = ControllerBase<DreamLinkController>.Instance.GetCurrentActivityData();
			bool flag = this.Data.Status == EDreamLinkRunTaskState.Active;
			bool runRedDotState = currentActivityData.GetRunRedDotState(this.Data.Id);
			if (flag)
			{
				this.JumpButton.SetRedDotVisible(runRedDotState);
			}
		}

		// Token: 0x0603C684 RID: 247428 RVA: 0x00F5563A File Offset: 0x00F5383A
		private void OnClickJump(int _)
		{
			DreamLinkData currentActivityData = ControllerBase<DreamLinkController>.Instance.GetCurrentActivityData();
			if (currentActivityData != null)
			{
				currentActivityData.SaveFirstCheckRedDotState(1, this.Data.Id);
			}
			this.RefreshRedDot();
			this.Data.JumpDelegate();
		}

		// Token: 0x0603C685 RID: 247429 RVA: 0x00F5566E File Offset: 0x00F5386E
		private void OnClickGetButton()
		{
			this.Data.ReceiveDelegate();
		}

		// Token: 0x04021F62 RID: 139106
		[Nullable(2)]
		protected DreamLinkRunTaskData Data;

		// Token: 0x04021F63 RID: 139107
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> RewardScrollView;

		// Token: 0x04021F64 RID: 139108
		[Nullable(2)]
		private ButtonItem JumpButton;

		// Token: 0x04021F65 RID: 139109
		private bool NeedTick;

		// Token: 0x0200BE06 RID: 48646
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403A7FA RID: 239610
			public const int JumpBtn = 0;

			// Token: 0x0403A7FB RID: 239611
			public const int GetBtn = 1;

			// Token: 0x0403A7FC RID: 239612
			public const int PanelDone = 2;

			// Token: 0x0403A7FD RID: 239613
			public const int TxtName = 3;

			// Token: 0x0403A7FE RID: 239614
			public const int PanelLock = 4;

			// Token: 0x0403A7FF RID: 239615
			public const int TxtLock = 5;

			// Token: 0x0403A800 RID: 239616
			public const int RewardScroll = 6;

			// Token: 0x0403A801 RID: 239617
			public const int TxtGoing = 7;

			// Token: 0x0403A802 RID: 239618
			public const int PanelTime = 8;

			// Token: 0x0403A803 RID: 239619
			public const int TxtTime = 9;

			// Token: 0x0403A804 RID: 239620
			public const int RedDot = 10;
		}
	}
}
