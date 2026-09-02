using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029D0 RID: 10704
public class ShipTowerReviewView : UiViewBase
{
	// Token: 0x17001BDF RID: 7135
	// (get) Token: 0x06015567 RID: 87399 RVA: 0x005E9CFE File Offset: 0x005E7EFE
	[Nullable(2)]
	public new ShipTowerReviewViewParams OpenParam
	{
		[NullableContext(2)]
		get
		{
			return this.OpenParam as ShipTowerReviewViewParams;
		}
	}

	// Token: 0x06015568 RID: 87400 RVA: 0x005E9D0B File Offset: 0x005E7F0B
	[NullableContext(1)]
	public ShipTowerReviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015569 RID: 87401 RVA: 0x005E9D14 File Offset: 0x005E7F14
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.CloseSelf))
		};
	}

	// Token: 0x0601556A RID: 87402 RVA: 0x005E9DBE File Offset: 0x005E7FBE
	private void InitDataParam()
	{
	}

	// Token: 0x0601556B RID: 87403 RVA: 0x005E9DC0 File Offset: 0x005E7FC0
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerReviewView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerReviewView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601556C RID: 87404 RVA: 0x005E9E03 File Offset: 0x005E8003
	protected override void OnBeforeShow()
	{
		this.UpdateData();
	}

	// Token: 0x0601556D RID: 87405 RVA: 0x005E9E0B File Offset: 0x005E800B
	protected override void OnBeforeDestroy()
	{
		ShipTowerReviewViewParams openParam = this.OpenParam;
		if (openParam == null)
		{
			return;
		}
		CustomPromise<bool> promise = openParam.Promise;
		if (promise == null)
		{
			return;
		}
		promise.SetResult(true);
	}

	// Token: 0x0601556E RID: 87406 RVA: 0x005E9E28 File Offset: 0x005E8028
	[NullableContext(1)]
	private ShipTowerReviewItem CreateReviewItem()
	{
		return new ShipTowerReviewItem();
	}

	// Token: 0x0601556F RID: 87407 RVA: 0x005E9E30 File Offset: 0x005E8030
	public void UpdateData()
	{
		List<ShipTowerReviewItemData> reviewList = ModelBase<ShipTowerModel>.Instance.ReviewList;
		LoopScrollView<ShipTowerReviewItem, ShipTowerReviewItemData> reviewLoopView = this.ReviewLoopView;
		if (reviewLoopView != null)
		{
			reviewLoopView.RefreshByData(reviewList, false, null, false);
		}
		bool uiactive = false;
		using (List<ShipTowerReviewItemData>.Enumerator enumerator = reviewList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsQuickPass)
				{
					uiactive = true;
					break;
				}
			}
		}
		UUIText text = base.GetText(4);
		if (text != null)
		{
			text.SetUIActive(uiactive);
		}
		List<int> reviewProgressList = ModelBase<ShipTowerModel>.Instance.ReviewProgressList;
		string textStringId = "GhostShipLastReview_Text";
		UUIText text2 = base.GetText(3);
		if (reviewProgressList.Count >= 2)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, textStringId, new <>z__ReadOnlyArray<object>(new object[]
			{
				reviewProgressList[0],
				reviewProgressList[1]
			}));
		}
	}

	// Token: 0x0400A464 RID: 42084
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<ShipTowerReviewItem, ShipTowerReviewItemData> ReviewLoopView;

	// Token: 0x02008D34 RID: 36148
	private static class EChildType
	{
		// Token: 0x0402F7D4 RID: 194516
		public const int LoopScrollRoot = 0;

		// Token: 0x0402F7D5 RID: 194517
		public const int BtnSure = 1;

		// Token: 0x0402F7D6 RID: 194518
		public const int ItemReview = 2;

		// Token: 0x0402F7D7 RID: 194519
		public const int TextLastReviewProgress = 3;

		// Token: 0x0402F7D8 RID: 194520
		public const int CanQuickPassTipText = 4;
	}
}
