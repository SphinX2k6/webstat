using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AF3 RID: 6899
public class DangoAbyssPluginRecoveryResultView : UiViewBase
{
	// Token: 0x0600C6B3 RID: 50867 RVA: 0x00348747 File Offset: 0x00346947
	[NullableContext(1)]
	public DangoAbyssPluginRecoveryResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C6B4 RID: 50868 RVA: 0x00348750 File Offset: 0x00346950
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
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickMask))
		};
	}

	// Token: 0x0600C6B5 RID: 50869 RVA: 0x003487FC File Offset: 0x003469FC
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssPluginRecoveryResultView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssPluginRecoveryResultView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C6B6 RID: 50870 RVA: 0x0034883F File Offset: 0x00346A3F
	[NullableContext(1)]
	private RecoveryRewardItem InitGridItem()
	{
		return new RecoveryRewardItem();
	}

	// Token: 0x0600C6B7 RID: 50871 RVA: 0x00348846 File Offset: 0x00346A46
	private void OnClickMask()
	{
		base.CloseMe(null);
	}

	// Token: 0x04005F31 RID: 24369
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RecoveryRewardItem, DangoAbyssDefine.IRecoveryRewardData> MainRewardLayout;

	// Token: 0x02007DC7 RID: 32199
	private enum EComponent
	{
		// Token: 0x0402AD76 RID: 175478
		ItemPlugin,
		// Token: 0x0402AD77 RID: 175479
		BtnMask,
		// Token: 0x0402AD78 RID: 175480
		MainRewardLayout,
		// Token: 0x0402AD79 RID: 175481
		ItemTips,
		// Token: 0x0402AD7A RID: 175482
		ExtraRewardLayout
	}
}
