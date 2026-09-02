using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B5E RID: 11102
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsTalentUnlockView : UiViewBase
{
	// Token: 0x0601621A RID: 90650 RVA: 0x0062464C File Offset: 0x0062284C
	public SurvivorsTalentUnlockView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601621B RID: 90651 RVA: 0x00624658 File Offset: 0x00622858
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseBtn))
		};
	}

	// Token: 0x0601621C RID: 90652 RVA: 0x00624704 File Offset: 0x00622904
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsTalentUnlockView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsTalentUnlockView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601621D RID: 90653 RVA: 0x00624747 File Offset: 0x00622947
	private SurvivorsTalentTreeMediumItemGrid InitItemGrid()
	{
		return new SurvivorsTalentTreeMediumItemGrid();
	}

	// Token: 0x0601621E RID: 90654 RVA: 0x0062474E File Offset: 0x0062294E
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400AAEB RID: 43755
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<SurvivorsTalentTreeMediumItemGrid, int> ItemLayout;
}
