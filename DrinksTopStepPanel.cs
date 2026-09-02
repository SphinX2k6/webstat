using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200102B RID: 4139
[NullableContext(2)]
[Nullable(0)]
public class DrinksTopStepPanel : UiPanelBase
{
	// Token: 0x06006BA3 RID: 27555 RVA: 0x001C353C File Offset: 0x001C173C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x06006BA4 RID: 27556 RVA: 0x001C35D8 File Offset: 0x001C17D8
	protected override UniTask OnBeforeStartAsync()
	{
		DrinksTopStepPanel.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DrinksTopStepPanel.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006BA5 RID: 27557 RVA: 0x001C361C File Offset: 0x001C181C
	public void UpdateStep()
	{
		EDrinksPlayStep curStep = ModelBase<DrinksModel>.Instance.GetCurStep();
		this.RefreshTitle(curStep);
		foreach (DrinksTopStepItem drinksTopStepItem in this.StepItemList)
		{
			drinksTopStepItem.UpdateCurState(curStep);
		}
	}

	// Token: 0x06006BA6 RID: 27558 RVA: 0x001C3680 File Offset: 0x001C1880
	public void UpdateStepItem()
	{
		foreach (DrinksTopStepItem drinksTopStepItem in this.StepItemList)
		{
			drinksTopStepItem.UpdateStepItem();
		}
	}

	// Token: 0x06006BA7 RID: 27559 RVA: 0x001C36D0 File Offset: 0x001C18D0
	protected void RefreshTitle(EDrinksPlayStep step)
	{
		DrinksStepConfig? stepConfig = ConfigBase<DrinksConfig>.Instance.GetStepConfig(step);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), stepConfig.Value.StepTitle, Array.Empty<object>());
	}

	// Token: 0x04003335 RID: 13109
	protected int CurStep;

	// Token: 0x04003336 RID: 13110
	[Nullable(1)]
	protected List<DrinksTopStepItem> StepItemList = new List<DrinksTopStepItem>();

	// Token: 0x04003337 RID: 13111
	protected DrinksTopStepItem StepItem1;

	// Token: 0x04003338 RID: 13112
	protected DrinksTopStepItem StepItem2;

	// Token: 0x04003339 RID: 13113
	protected DrinksTopStepItem StepItem3;

	// Token: 0x0400333A RID: 13114
	protected DrinksTopStepItem StepItem4;

	// Token: 0x0400333B RID: 13115
	protected DrinksTopStepItem StepItem5;

	// Token: 0x0200740C RID: 29708
	[NullableContext(0)]
	private static class EDefine
	{
		// Token: 0x04028228 RID: 164392
		public const int Title = 0;

		// Token: 0x04028229 RID: 164393
		public const int TogStep1 = 1;

		// Token: 0x0402822A RID: 164394
		public const int TogStep2 = 2;

		// Token: 0x0402822B RID: 164395
		public const int TogStep3 = 3;

		// Token: 0x0402822C RID: 164396
		public const int TogStep4 = 4;

		// Token: 0x0402822D RID: 164397
		public const int TogStep5 = 5;
	}
}
