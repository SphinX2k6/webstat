using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064AC RID: 25772
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoadBookTaskItemBase<[Nullable(2)] TData> : GridProxyAbstract<TData>
	{
		// Token: 0x060409A2 RID: 264610 RVA: 0x0108F407 File Offset: 0x0108D607
		public RoadBookTaskItemBase(ActivityRoadBookData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x060409A3 RID: 264611 RVA: 0x0108F418 File Offset: 0x0108D618
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
		}

		// Token: 0x060409A4 RID: 264612 RVA: 0x0108F4E0 File Offset: 0x0108D6E0
		protected override UniTask OnBeforeStartAsync()
		{
			RoadBookTaskItemBase<TData>.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoadBookTaskItemBase<TData>.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060409A5 RID: 264613 RVA: 0x0108F524 File Offset: 0x0108D724
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData>(base.GetScrollViewWithScrollbar(2), new Func<ActivitySmallItemGrid>(this.InitItem), null, false, null);
			this.ButtonItem.SetLocalTextNew("MapTravelJump_Text", Array.Empty<object>());
			this.RewardButtonItem.SetLocalTextNew("MapTravelGetReward_Text", Array.Empty<object>());
		}

		// Token: 0x060409A6 RID: 264614 RVA: 0x0108F57C File Offset: 0x0108D77C
		private ActivitySmallItemGrid InitItem()
		{
			return new ActivitySmallItemGrid();
		}

		// Token: 0x060409A7 RID: 264615 RVA: 0x0108F583 File Offset: 0x0108D783
		public override void Refresh(TData taskData, bool isSelected, int gridIndex)
		{
			this.TaskData = taskData;
		}

		// Token: 0x060409A8 RID: 264616 RVA: 0x0108F58C File Offset: 0x0108D78C
		protected virtual void OnClickedButton()
		{
		}

		// Token: 0x060409A9 RID: 264617 RVA: 0x0108F58E File Offset: 0x0108D78E
		protected virtual void OnClickedRewardButton()
		{
		}

		// Token: 0x040242C3 RID: 148163
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> RewardScrollView;

		// Token: 0x040242C4 RID: 148164
		protected ActivityButtonItem ButtonItem;

		// Token: 0x040242C5 RID: 148165
		protected ActivityButtonItem RewardButtonItem;

		// Token: 0x040242C6 RID: 148166
		protected TData TaskData;

		// Token: 0x040242C7 RID: 148167
		protected ActivityRoadBookData ActivityBaseData;
	}
}
