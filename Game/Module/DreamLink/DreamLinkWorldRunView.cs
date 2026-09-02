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

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DB9 RID: 23993
	[NullableContext(1)]
	[Nullable(0)]
	public class DreamLinkWorldRunView : UiTickViewBase
	{
		// Token: 0x0603C687 RID: 247431 RVA: 0x00F55683 File Offset: 0x00F53883
		public DreamLinkWorldRunView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603C688 RID: 247432 RVA: 0x00F5568C File Offset: 0x00F5388C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(USpineSkeletonAnimationComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C689 RID: 247433 RVA: 0x00F5577C File Offset: 0x00F5397C
		protected override UniTask OnBeforeStartAsync()
		{
			DreamLinkWorldRunView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DreamLinkWorldRunView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C68A RID: 247434 RVA: 0x00F557C0 File Offset: 0x00F539C0
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(1));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseBtnClick));
			this.TaskLayout = new GenericScrollViewNew<DreamLinkWorldRunTaskItem, DreamLinkRunTaskData>(base.GetScrollViewWithScrollbar(0), new Func<DreamLinkWorldRunTaskItem>(this.CreateTaskItem), null, false, null);
			this.RefreshSpine();
		}

		// Token: 0x0603C68B RID: 247435 RVA: 0x00F5581D File Offset: 0x00F53A1D
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x0603C68C RID: 247436 RVA: 0x00F5581F File Offset: 0x00F53A1F
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.DreamLinkRewardRefresh, new Action(this.RefreshTaskLayout));
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x0603C68D RID: 247437 RVA: 0x00F55859 File Offset: 0x00F53A59
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.DreamLinkRewardRefresh, new Action(this.RefreshTaskLayout));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x0603C68E RID: 247438 RVA: 0x00F55894 File Offset: 0x00F53A94
		protected override void OnTick(float delta)
		{
			if (this.TaskLayout == null)
			{
				return;
			}
			foreach (DreamLinkWorldRunTaskItem dreamLinkWorldRunTaskItem in this.TaskLayout.GetScrollItemList())
			{
				dreamLinkWorldRunTaskItem.RefreshLockText();
			}
		}

		// Token: 0x0603C68F RID: 247439 RVA: 0x00F558F4 File Offset: 0x00F53AF4
		private DreamLinkWorldRunTaskItem CreateTaskItem()
		{
			return new DreamLinkWorldRunTaskItem();
		}

		// Token: 0x0603C690 RID: 247440 RVA: 0x00F558FC File Offset: 0x00F53AFC
		private void RefreshSpine()
		{
			base.GetSpine(3).SetAnimation(0, EDreamLinkSpineDefine.Idle.ToString(), true);
			base.GetSpine(4).SetAnimation(0, EDreamLinkSpineDefine.Idle.ToString(), true);
			string animationName = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? EDreamLinkSpineDefine.MainFemale.ToString() : EDreamLinkSpineDefine.MainMale.ToString();
			base.GetSpine(5).SetAnimation(0, animationName, true);
		}

		// Token: 0x0603C691 RID: 247441 RVA: 0x00F55986 File Offset: 0x00F53B86
		private void OnActivitySequenceEmitEvent(string param)
		{
			if ("InturnAnimation" == param)
			{
				this.RefreshTaskLayout();
			}
		}

		// Token: 0x0603C692 RID: 247442 RVA: 0x00F5599B File Offset: 0x00F53B9B
		private void RefreshTaskLayout()
		{
			if (this.ActivityDataBase == null)
			{
				return;
			}
			this.TaskLayout.RefreshByData(this.ActivityDataBase.GetDreamLinkRunTaskDataList(), null, true);
		}

		// Token: 0x0603C693 RID: 247443 RVA: 0x00F559BE File Offset: 0x00F53BBE
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04021F66 RID: 139110
		private const string LAYOUT_ANIMATION_START = "InturnAnimation";

		// Token: 0x04021F67 RID: 139111
		[Nullable(2)]
		private DreamLinkData ActivityDataBase;

		// Token: 0x04021F68 RID: 139112
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04021F69 RID: 139113
		[Nullable(2)]
		private DreamLinkScoreRewardItem RewardItem;

		// Token: 0x04021F6A RID: 139114
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<DreamLinkWorldRunTaskItem, DreamLinkRunTaskData> TaskLayout;

		// Token: 0x0200BE07 RID: 48647
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403A805 RID: 239621
			public const int Layout = 0;

			// Token: 0x0403A806 RID: 239622
			public const int CaptionItem = 1;

			// Token: 0x0403A807 RID: 239623
			public const int ButtonScore = 2;

			// Token: 0x0403A808 RID: 239624
			public const int SpineA = 3;

			// Token: 0x0403A809 RID: 239625
			public const int SpineB = 4;

			// Token: 0x0403A80A RID: 239626
			public const int SpineCharacter = 5;
		}
	}
}
