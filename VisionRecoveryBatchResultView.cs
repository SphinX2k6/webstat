using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001806 RID: 6150
public class VisionRecoveryBatchResultView : UiViewBase
{
	// Token: 0x0600AEC9 RID: 44745 RVA: 0x002E8F40 File Offset: 0x002E7140
	[NullableContext(1)]
	public VisionRecoveryBatchResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600AECA RID: 44746 RVA: 0x002E8F4C File Offset: 0x002E714C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIGridLayout))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickMaskBtn))
		};
	}

	// Token: 0x0600AECB RID: 44747 RVA: 0x002E8FF8 File Offset: 0x002E71F8
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRecoveryBatchResultView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRecoveryBatchResultView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AECC RID: 44748 RVA: 0x002E903B File Offset: 0x002E723B
	[NullableContext(1)]
	private VisionRecoverySlotGridItem InitVisionRecoverySlotGridItem()
	{
		return new VisionRecoverySlotGridItem(new Action<bool, PhantomItemData>(this.OnClickRewardCallback), false);
	}

	// Token: 0x0600AECD RID: 44749 RVA: 0x002E904F File Offset: 0x002E724F
	private void OnClickMaskBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600AECE RID: 44750 RVA: 0x002E9058 File Offset: 0x002E7258
	[NullableContext(2)]
	private void OnClickRewardCallback(bool isAddVision, PhantomItemData data)
	{
		if (data == null)
		{
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(data.GetUniqueId(), data.GetConfigId(), true, null);
	}

	// Token: 0x040052F3 RID: 21235
	private const int CELLS_PER_LINE = 7;

	// Token: 0x040052F4 RID: 21236
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRecoverySlotGridItem, PhantomItemData> MainRewardLayout;

	// Token: 0x040052F5 RID: 21237
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRecoverySlotGridItem, PhantomItemData> ExtraRewardLayout;

	// Token: 0x02007B7A RID: 31610
	private enum EComponent
	{
		// Token: 0x0402A340 RID: 172864
		VisionItem,
		// Token: 0x0402A341 RID: 172865
		MaskBtn,
		// Token: 0x0402A342 RID: 172866
		MainRewardLayout,
		// Token: 0x0402A343 RID: 172867
		TipsItem,
		// Token: 0x0402A344 RID: 172868
		ExtraRewardLayout
	}
}
