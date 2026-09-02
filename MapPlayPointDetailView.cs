using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B9E RID: 7070
public class MapPlayPointDetailView : UiViewBase
{
	// Token: 0x0600CDAE RID: 52654 RVA: 0x0036CAC8 File Offset: 0x0036ACC8
	[NullableContext(1)]
	public MapPlayPointDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600CDAF RID: 52655 RVA: 0x0036CAD4 File Offset: 0x0036ACD4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CDB0 RID: 52656 RVA: 0x0036CC28 File Offset: 0x0036AE28
	protected override UniTask OnBeforeStartAsync()
	{
		MapPlayPointDetailView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MapPlayPointDetailView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CDB1 RID: 52657 RVA: 0x0036CC6C File Offset: 0x0036AE6C
	protected override void OnBeforeShow()
	{
		MapPlayPointDetailViewParams dataParam = this.DataParam;
		ExploreAreaItemData exploreAreaItemData = (dataParam != null) ? dataParam.ExploreAreaItemData : null;
		if (exploreAreaItemData == null)
		{
			return;
		}
		this.PlayProgressPanel.UpdateData(exploreAreaItemData.PlayProgressDataList, null);
		int playPointTotalCount = exploreAreaItemData.PlayPointTotalCount;
		int playPointCompletedCount = exploreAreaItemData.PlayPointCompletedCount;
		int playPointToBeCompletedCount = exploreAreaItemData.PlayPointToBeCompletedCount;
		int playPointLockedCount = exploreAreaItemData.PlayPointLockedCount;
		base.GetText(1).SetText(playPointTotalCount.ToString(), true);
		base.GetText(2).SetText(playPointCompletedCount.ToString(), true);
		base.GetText(3).SetText(playPointToBeCompletedCount.ToString(), true);
		base.GetText(4).SetText(playPointLockedCount.ToString(), true);
		base.GetText(5).SetText(exploreAreaItemData.GetPlayDetailTitle(), true);
		base.GetText(6).ShowTextNew(exploreAreaItemData.GetNameId());
		bool flag = exploreAreaItemData.HasSpecialPlayPoint();
		base.GetItem(8).SetUIActive(flag);
		if (flag)
		{
			base.GetText(7).ShowTextNew(exploreAreaItemData.SpecialPlayerDesc);
		}
	}

	// Token: 0x04006236 RID: 25142
	[Nullable(2)]
	private MapExplorePlayProgressPanel PlayProgressPanel;

	// Token: 0x04006237 RID: 25143
	[Nullable(2)]
	private MapPlayPointDetailViewParams DataParam;

	// Token: 0x02007E8B RID: 32395
	private enum EChildType
	{
		// Token: 0x0402B1B9 RID: 176569
		ItemProgressPanel,
		// Token: 0x0402B1BA RID: 176570
		TxtProgressTotal,
		// Token: 0x0402B1BB RID: 176571
		TxtCompleted,
		// Token: 0x0402B1BC RID: 176572
		TxtToBeCompleted,
		// Token: 0x0402B1BD RID: 176573
		TxtLocked,
		// Token: 0x0402B1BE RID: 176574
		TxtTitle,
		// Token: 0x0402B1BF RID: 176575
		TxtNormalDesc,
		// Token: 0x0402B1C0 RID: 176576
		TxtSpecialDesc,
		// Token: 0x0402B1C1 RID: 176577
		ItemSpecialRoot
	}
}
