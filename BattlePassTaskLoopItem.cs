using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200238A RID: 9098
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BattlePassTaskLoopItem : GridProxyAbstract<BattlePassTaskData>
{
	// Token: 0x060116E4 RID: 71396 RVA: 0x004CE16C File Offset: 0x004CC36C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickSkipToBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickTakeRewardBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060116E5 RID: 71397 RVA: 0x004CE2DC File Offset: 0x004CC4DC
	private void OnClickSkipToBtn()
	{
		BattlePassTaskData dataCache = this.DataCache;
		int? num = (dataCache != null) ? dataCache.SkipId : null;
		if (num != null)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnBattlePassSkip, num.Value);
		}
	}

	// Token: 0x060116E6 RID: 71398 RVA: 0x004CE324 File Offset: 0x004CC524
	private void OnClickTakeRewardBtn()
	{
		ControllerBase<BattlePassController>.Instance.TryRequestTaskList(new List<int>
		{
			this.TaskId
		});
	}

	// Token: 0x060116E7 RID: 71399 RVA: 0x004CE341 File Offset: 0x004CC541
	protected override void OnStart()
	{
		this.CommonItemGrid = new CommonItemSmallItemGrid();
		this.CommonItemGrid.Initialize(base.GetItem(5).GetOwner());
	}

	// Token: 0x060116E8 RID: 71400 RVA: 0x004CE365 File Offset: 0x004CC565
	[NullableContext(1)]
	public override void Refresh(BattlePassTaskData data, bool isSelected, int gridIndex)
	{
		this.RefreshAsyncInternal(data).Forget();
	}

	// Token: 0x060116E9 RID: 71401 RVA: 0x004CE374 File Offset: 0x004CC574
	[NullableContext(1)]
	private UniTask RefreshAsyncInternal(BattlePassTaskData data)
	{
		BattlePassTaskLoopItem.<RefreshAsyncInternal>d__11 <RefreshAsyncInternal>d__;
		<RefreshAsyncInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsyncInternal>d__.<>4__this = this;
		<RefreshAsyncInternal>d__.data = data;
		<RefreshAsyncInternal>d__.<>1__state = -1;
		<RefreshAsyncInternal>d__.<>t__builder.Start<BattlePassTaskLoopItem.<RefreshAsyncInternal>d__11>(ref <RefreshAsyncInternal>d__);
		return <RefreshAsyncInternal>d__.<>t__builder.Task;
	}

	// Token: 0x040088DD RID: 35037
	private CommonItemSmallItemGrid CommonItemGrid;

	// Token: 0x040088DE RID: 35038
	private BattlePassTaskLoopItemButton SkipToButtonItem;

	// Token: 0x040088DF RID: 35039
	private BattlePassTaskLoopItemButton RewardButtonItem;

	// Token: 0x040088E0 RID: 35040
	private int TaskId;

	// Token: 0x040088E1 RID: 35041
	private BattlePassTaskData DataCache;

	// Token: 0x020086A3 RID: 34467
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402D8A1 RID: 186529
		TaskDescriptionText,
		// Token: 0x0402D8A2 RID: 186530
		CompleteText,
		// Token: 0x0402D8A3 RID: 186531
		SprDone,
		// Token: 0x0402D8A4 RID: 186532
		RunningTip,
		// Token: 0x0402D8A5 RID: 186533
		SkipToBtn,
		// Token: 0x0402D8A6 RID: 186534
		CommonItem,
		// Token: 0x0402D8A7 RID: 186535
		TakeRewardBtn
	}
}
