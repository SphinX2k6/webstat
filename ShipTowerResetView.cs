using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029CD RID: 10701
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerResetView : UiViewBase
{
	// Token: 0x06015555 RID: 87381 RVA: 0x005E98F6 File Offset: 0x005E7AF6
	public ShipTowerResetView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015556 RID: 87382 RVA: 0x005E9900 File Offset: 0x005E7B00
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.CloseSelf)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickSure))
		};
	}

	// Token: 0x06015557 RID: 87383 RVA: 0x005E99AC File Offset: 0x005E7BAC
	private void InitDataParam()
	{
	}

	// Token: 0x06015558 RID: 87384 RVA: 0x005E99B0 File Offset: 0x005E7BB0
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerResetView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerResetView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015559 RID: 87385 RVA: 0x005E99F4 File Offset: 0x005E7BF4
	protected override void OnBeforeShow()
	{
		ShipTowerResetViewParams shipTowerResetViewParams = this.OpenParam as ShipTowerResetViewParams;
		ShipTowerStageData shipTowerStageData = (shipTowerResetViewParams != null) ? shipTowerResetViewParams.StageData : null;
		if (shipTowerStageData != null)
		{
			this.ResetItem1.UpdateData(shipTowerStageData.TeamDataList[0]);
			this.ResetItem2.UpdateData(shipTowerStageData.TeamDataList[1]);
		}
	}

	// Token: 0x0601555A RID: 87386 RVA: 0x005E9A4C File Offset: 0x005E7C4C
	private void OnClickSure()
	{
		ShipTowerResetViewParams shipTowerResetViewParams = this.OpenParam as ShipTowerResetViewParams;
		ShipTowerStageData shipTowerStageData = (shipTowerResetViewParams != null) ? shipTowerResetViewParams.StageData : null;
		if (shipTowerStageData != null)
		{
			shipTowerStageData.SureResetStage();
		}
		base.CloseMe(null);
	}

	// Token: 0x0400A45E RID: 42078
	private ShipTowerResetItem ResetItem1;

	// Token: 0x0400A45F RID: 42079
	private ShipTowerResetItem ResetItem2;

	// Token: 0x02008D30 RID: 36144
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F7C2 RID: 194498
		public const int ItemReset1 = 0;

		// Token: 0x0402F7C3 RID: 194499
		public const int ItemReset2 = 1;

		// Token: 0x0402F7C4 RID: 194500
		public const int BtnCancel = 2;

		// Token: 0x0402F7C5 RID: 194501
		public const int BtnSure = 3;
	}
}
