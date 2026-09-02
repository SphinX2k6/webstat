using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006548 RID: 25928
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RealmBetweenTaskItemBase<[Nullable(2)] TData> : GridProxyAbstract<TData>
	{
		// Token: 0x06040CE6 RID: 265446 RVA: 0x0109E23A File Offset: 0x0109C43A
		public RealmBetweenTaskItemBase(ActivityRealmBetweenData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x06040CE7 RID: 265447 RVA: 0x0109E24C File Offset: 0x0109C44C
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

		// Token: 0x06040CE8 RID: 265448 RVA: 0x0109E314 File Offset: 0x0109C514
		protected override UniTask OnBeforeStartAsync()
		{
			RealmBetweenTaskItemBase<TData>.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RealmBetweenTaskItemBase<TData>.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040CE9 RID: 265449 RVA: 0x0109E358 File Offset: 0x0109C558
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData>(base.GetScrollViewWithScrollbar(2), new Func<ActivitySmallItemGrid>(this.InitItem), null, false, null);
			this.ButtonItem.SetLocalTextNew("RealmBetweenJump_Text", Array.Empty<object>());
			this.RewardButtonItem.SetLocalTextNew("RealmBetweenGetReward_Text", Array.Empty<object>());
		}

		// Token: 0x06040CEA RID: 265450 RVA: 0x0109E3B0 File Offset: 0x0109C5B0
		private ActivitySmallItemGrid InitItem()
		{
			return new ActivitySmallItemGrid();
		}

		// Token: 0x06040CEB RID: 265451 RVA: 0x0109E3B7 File Offset: 0x0109C5B7
		public override void Refresh(TData taskData, bool isSelected, int gridIndex)
		{
			this.TaskData = taskData;
		}

		// Token: 0x06040CEC RID: 265452 RVA: 0x0109E3C0 File Offset: 0x0109C5C0
		protected virtual void OnClickedButton()
		{
		}

		// Token: 0x06040CED RID: 265453 RVA: 0x0109E3C2 File Offset: 0x0109C5C2
		protected virtual void OnClickedRewardButton()
		{
		}

		// Token: 0x040245B0 RID: 148912
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> RewardScrollView;

		// Token: 0x040245B1 RID: 148913
		protected ActivityButtonItem ButtonItem;

		// Token: 0x040245B2 RID: 148914
		protected ActivityButtonItem RewardButtonItem;

		// Token: 0x040245B3 RID: 148915
		protected TData TaskData;

		// Token: 0x040245B4 RID: 148916
		protected ActivityRealmBetweenData ActivityBaseData;
	}
}
