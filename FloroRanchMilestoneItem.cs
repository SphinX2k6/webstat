using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C62 RID: 7266
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchMilestoneItem : UiPanelBase
{
	// Token: 0x0600D40F RID: 54287 RVA: 0x00388D30 File Offset: 0x00386F30
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D410 RID: 54288 RVA: 0x00388DFC File Offset: 0x00386FFC
	protected override void OnStart()
	{
		this.ProgressLayout = new GenericLayout<FloroRanchMilestoneRewardItem, FloroRanchMilestoneData>(base.GetHorizontalLayout(1), new Func<FloroRanchMilestoneRewardItem>(this.ProgressItemProxyCreate), null, false, true);
		this.ProgressBarWidth = base.GetSprite(4).GetWidth();
	}

	// Token: 0x0600D411 RID: 54289 RVA: 0x00388E31 File Offset: 0x00387031
	private FloroRanchMilestoneRewardItem ProgressItemProxyCreate()
	{
		return new FloroRanchMilestoneRewardItem
		{
			OnClickToGet = this.OnClickToGet
		};
	}

	// Token: 0x0600D412 RID: 54290 RVA: 0x00388E44 File Offset: 0x00387044
	public UniTask RefreshProgressItem(float currentProgress, List<FloroRanchMilestoneData> dataList)
	{
		FloroRanchMilestoneItem.<RefreshProgressItem>d__8 <RefreshProgressItem>d__;
		<RefreshProgressItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshProgressItem>d__.<>4__this = this;
		<RefreshProgressItem>d__.currentProgress = currentProgress;
		<RefreshProgressItem>d__.dataList = dataList;
		<RefreshProgressItem>d__.<>1__state = -1;
		<RefreshProgressItem>d__.<>t__builder.Start<FloroRanchMilestoneItem.<RefreshProgressItem>d__8>(ref <RefreshProgressItem>d__);
		return <RefreshProgressItem>d__.<>t__builder.Task;
	}

	// Token: 0x040064DC RID: 25820
	protected GenericLayout<FloroRanchMilestoneRewardItem, FloroRanchMilestoneData> ProgressLayout;

	// Token: 0x040064DD RID: 25821
	protected float ProgressBarWidth;

	// Token: 0x040064DE RID: 25822
	[Nullable(2)]
	public Action OnClickToGet;

	// Token: 0x040064DF RID: 25823
	private const float REWARD_ITEM_WIDTH = 108f;

	// Token: 0x02007F7B RID: 32635
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402B679 RID: 177785
		public const int TxtProgress = 0;

		// Token: 0x0402B67A RID: 177786
		public const int ProgressLayout = 1;

		// Token: 0x0402B67B RID: 177787
		public const int ProgressItem = 2;

		// Token: 0x0402B67C RID: 177788
		public const int DotStart = 3;

		// Token: 0x0402B67D RID: 177789
		public const int BarProgress = 4;
	}
}
