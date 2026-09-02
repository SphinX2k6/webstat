using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029B9 RID: 10681
public class ShipTowerGetBuffView : UiViewBase
{
	// Token: 0x060154DF RID: 87263 RVA: 0x005E7BBD File Offset: 0x005E5DBD
	[NullableContext(1)]
	public ShipTowerGetBuffView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060154E0 RID: 87264 RVA: 0x005E7BC8 File Offset: 0x005E5DC8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.CloseSelf))
		};
	}

	// Token: 0x060154E1 RID: 87265 RVA: 0x005E7C30 File Offset: 0x005E5E30
	private void InitDataParam()
	{
	}

	// Token: 0x060154E2 RID: 87266 RVA: 0x005E7C34 File Offset: 0x005E5E34
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerGetBuffView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerGetBuffView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060154E3 RID: 87267 RVA: 0x005E7C78 File Offset: 0x005E5E78
	protected override void OnBeforeShow()
	{
		List<TItem> itemDataList = (this.OpenParam as ShipTowerGetBuffViewParams).ItemDataList;
		GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		if (rewardLayout == null)
		{
			return;
		}
		rewardLayout.RefreshByData(itemDataList, delegate
		{
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardLayout2 = this.RewardLayout;
			if (rewardLayout2 != null && rewardLayout2.IsExpand)
			{
				GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardLayout3 = this.RewardLayout;
				if (rewardLayout3 == null)
				{
					return;
				}
				rewardLayout3.ScrollToLeft(0);
			}
		}, false);
	}

	// Token: 0x060154E4 RID: 87268 RVA: 0x005E7CB4 File Offset: 0x005E5EB4
	protected override void OnBeforeDestroy()
	{
		ShipTowerGetBuffViewParams shipTowerGetBuffViewParams = this.OpenParam as ShipTowerGetBuffViewParams;
		if (shipTowerGetBuffViewParams != null)
		{
			CustomPromise<bool> promise = shipTowerGetBuffViewParams.Promise;
			if (promise == null)
			{
				return;
			}
			promise.SetResult(true);
		}
	}

	// Token: 0x0400A43B RID: 42043
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x02008D11 RID: 36113
	private static class EChildType
	{
		// Token: 0x0402F742 RID: 194370
		public const int ScrollBarReward = 0;

		// Token: 0x0402F743 RID: 194371
		public const int BtnClose = 1;
	}
}
