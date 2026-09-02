using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001392 RID: 5010
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TaskItemBase<[Nullable(2)] TData> : GridProxyAbstract<TData>
{
	// Token: 0x060089BE RID: 35262 RVA: 0x00243BC7 File Offset: 0x00241DC7
	public TaskItemBase(ActivityMapTravelData activityBaseData)
	{
		this.ActivityBaseData = activityBaseData;
	}

	// Token: 0x060089BF RID: 35263 RVA: 0x00243BD8 File Offset: 0x00241DD8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060089C0 RID: 35264 RVA: 0x00243D08 File Offset: 0x00241F08
	protected override UniTask OnBeforeStartAsync()
	{
		TaskItemBase<TData>.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TaskItemBase<TData>.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060089C1 RID: 35265 RVA: 0x00243D4C File Offset: 0x00241F4C
	protected override void OnStart()
	{
		this.RewardScrollView = new GenericLayout<ActivitySmallItemGrid, IItemGridData>(base.GetHorizontalLayout(2), new Func<ActivitySmallItemGrid>(this.InitItem), null, false, true);
		this.ButtonItem.SetLocalTextNew("MapTravelJump_Text", Array.Empty<object>());
		this.RewardButtonItem.SetLocalTextNew("MapTravelGetReward_Text", Array.Empty<object>());
	}

	// Token: 0x060089C2 RID: 35266 RVA: 0x00243DA4 File Offset: 0x00241FA4
	private ActivitySmallItemGrid InitItem()
	{
		return new ActivitySmallItemGrid();
	}

	// Token: 0x060089C3 RID: 35267 RVA: 0x00243DAB File Offset: 0x00241FAB
	public override void Refresh(TData taskData, bool isSelected, int gridIndex)
	{
		this.TaskData = taskData;
	}

	// Token: 0x060089C4 RID: 35268 RVA: 0x00243DB4 File Offset: 0x00241FB4
	protected virtual void OnClickedButton()
	{
	}

	// Token: 0x060089C5 RID: 35269 RVA: 0x00243DB6 File Offset: 0x00241FB6
	protected virtual void OnClickedRewardButton()
	{
	}

	// Token: 0x0400408D RID: 16525
	protected GenericLayout<ActivitySmallItemGrid, IItemGridData> RewardScrollView;

	// Token: 0x0400408E RID: 16526
	protected ActivityButtonItem ButtonItem;

	// Token: 0x0400408F RID: 16527
	protected ActivityButtonItem RewardButtonItem;

	// Token: 0x04004090 RID: 16528
	protected TData TaskData;

	// Token: 0x04004091 RID: 16529
	protected ActivityMapTravelData ActivityBaseData;
}
