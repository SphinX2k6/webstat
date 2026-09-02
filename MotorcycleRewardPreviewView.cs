using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022C5 RID: 8901
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleRewardPreviewView : UiViewBase
{
	// Token: 0x06010D5A RID: 68954 RVA: 0x0049B7C9 File Offset: 0x004999C9
	public MotorcycleRewardPreviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010D5B RID: 68955 RVA: 0x0049B7DD File Offset: 0x004999DD
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06010D5C RID: 68956 RVA: 0x0049B818 File Offset: 0x00499A18
	protected override void OnStart()
	{
		List<TItem> list = this.OpenParam as List<TItem>;
		AUIBaseActor gridActor = base.GetItem(1).GetOwner() as AUIBaseActor;
		this.LoopScrollView = new LoopScrollView<CommonItemSmallItemGrid, TItem>(base.GetLoopScrollViewComponent(0), gridActor, new Func<CommonItemSmallItemGrid>(this.OnGridProxyCreate), false);
		this.RewardDataList = (list ?? new List<TItem>());
	}

	// Token: 0x06010D5D RID: 68957 RVA: 0x0049B873 File Offset: 0x00499A73
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x06010D5E RID: 68958 RVA: 0x0049B87B File Offset: 0x00499A7B
	private void RefreshView()
	{
		this.LoopScrollView.RefreshByData(this.RewardDataList, false, null, false);
	}

	// Token: 0x06010D5F RID: 68959 RVA: 0x0049B891 File Offset: 0x00499A91
	private CommonItemSmallItemGrid OnGridProxyCreate()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x040084BB RID: 33979
	private List<TItem> RewardDataList = new List<TItem>();

	// Token: 0x040084BC RID: 33980
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<CommonItemSmallItemGrid, TItem> LoopScrollView;

	// Token: 0x02008588 RID: 34184
	[NullableContext(0)]
	private class EMotorRewardPreviewComponent
	{
		// Token: 0x0402D2EF RID: 185071
		public const int LoopScrollView = 0;

		// Token: 0x0402D2F0 RID: 185072
		public const int ScrollItem = 1;
	}
}
