using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022C1 RID: 8897
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleConditionView : UiViewBase
{
	// Token: 0x06010D17 RID: 68887 RVA: 0x0049A333 File Offset: 0x00498533
	public MotorcycleConditionView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010D18 RID: 68888 RVA: 0x0049A348 File Offset: 0x00498548
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06010D19 RID: 68889 RVA: 0x0049A3B8 File Offset: 0x004985B8
	protected override void OnStart()
	{
		this.ConditionDataList = ((this.OpenParam as List<IMotorLevelConditionData>) ?? new List<IMotorLevelConditionData>());
		this.CreateConditionLayout();
	}

	// Token: 0x06010D1A RID: 68890 RVA: 0x0049A3DC File Offset: 0x004985DC
	protected override void OnBeforeShow()
	{
		this.ConditionLayout.RefreshByData(this.ConditionDataList, false, null, false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "MotorBike_ExpGuide", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "MotorBike_ExpGuide_Title", Array.Empty<object>());
	}

	// Token: 0x06010D1B RID: 68891 RVA: 0x0049A434 File Offset: 0x00498634
	protected void CreateConditionLayout()
	{
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(2);
		UUIItem item = base.GetItem(3);
		this.ConditionLayout = new LoopScrollView<MotorcycleConditionItem, IMotorLevelConditionData>(loopScrollViewComponent, item.GetOwner() as AUIBaseActor, new Func<MotorcycleConditionItem>(this.CreateConditionItem), false);
	}

	// Token: 0x06010D1C RID: 68892 RVA: 0x0049A475 File Offset: 0x00498675
	private MotorcycleConditionItem CreateConditionItem()
	{
		return new MotorcycleConditionItem();
	}

	// Token: 0x04008499 RID: 33945
	private List<IMotorLevelConditionData> ConditionDataList = new List<IMotorLevelConditionData>();

	// Token: 0x0400849A RID: 33946
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleConditionItem, IMotorLevelConditionData> ConditionLayout;

	// Token: 0x0200857D RID: 34173
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402D2B4 RID: 185012
		public const int TxtTitle = 0;

		// Token: 0x0402D2B5 RID: 185013
		public const int TxtTips = 1;

		// Token: 0x0402D2B6 RID: 185014
		public const int ConditionLayout = 2;

		// Token: 0x0402D2B7 RID: 185015
		public const int ConditionItem = 3;
	}
}
