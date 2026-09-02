using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020010A0 RID: 4256
[NullableContext(1)]
[Nullable(0)]
public class FurniturePresetView : UiViewBase
{
	// Token: 0x06006EF6 RID: 28406 RVA: 0x001CDDE9 File Offset: 0x001CBFE9
	public FurniturePresetView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06006EF7 RID: 28407 RVA: 0x001CDDF4 File Offset: 0x001CBFF4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickCloseButton))
		};
	}

	// Token: 0x06006EF8 RID: 28408 RVA: 0x001CDE74 File Offset: 0x001CC074
	protected override UniTask OnBeforeStartAsync()
	{
		FurniturePresetView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FurniturePresetView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006EF9 RID: 28409 RVA: 0x001CDEB7 File Offset: 0x001CC0B7
	private void OnClickApplyButton(FurnitureAreaData areaData)
	{
		this.ApplyFurniturePresetAsync();
	}

	// Token: 0x06006EFA RID: 28410 RVA: 0x001CDEC0 File Offset: 0x001CC0C0
	private UniTask ApplyFurniturePresetAsync()
	{
		FurniturePresetView.<ApplyFurniturePresetAsync>d__6 <ApplyFurniturePresetAsync>d__;
		<ApplyFurniturePresetAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ApplyFurniturePresetAsync>d__.<>4__this = this;
		<ApplyFurniturePresetAsync>d__.<>1__state = -1;
		<ApplyFurniturePresetAsync>d__.<>t__builder.Start<FurniturePresetView.<ApplyFurniturePresetAsync>d__6>(ref <ApplyFurniturePresetAsync>d__);
		return <ApplyFurniturePresetAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006EFB RID: 28411 RVA: 0x001CDF03 File Offset: 0x001CC103
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x04003502 RID: 13570
	[Nullable(2)]
	private FurniturePresetItem FurniturePresetItem;

	// Token: 0x04003503 RID: 13571
	private bool IsApplying;
}
