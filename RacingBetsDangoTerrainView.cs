using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002738 RID: 10040
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDangoTerrainView : UiViewBase
{
	// Token: 0x06013CDE RID: 81118 RVA: 0x00583268 File Offset: 0x00581468
	public RacingBetsDangoTerrainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013CDF RID: 81119 RVA: 0x00583274 File Offset: 0x00581474
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseButton)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickCloseButton))
		};
	}

	// Token: 0x06013CE0 RID: 81120 RVA: 0x00583338 File Offset: 0x00581538
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsDangoTerrainView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsDangoTerrainView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013CE1 RID: 81121 RVA: 0x0058337B File Offset: 0x0058157B
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x06013CE2 RID: 81122 RVA: 0x00583384 File Offset: 0x00581584
	private RacingBetsDangoTerrainItem DungeonTerrainItemProxyCreate()
	{
		return new RacingBetsDangoTerrainItem();
	}

	// Token: 0x04009A1E RID: 39454
	private GenericLayout<RacingBetsDangoTerrainItem, int> DungeonTerrainLayout;

	// Token: 0x02008AE7 RID: 35559
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ED57 RID: 191831
		public const int CloseButton = 0;

		// Token: 0x0402ED58 RID: 191832
		public const int TerrainLayout = 1;

		// Token: 0x0402ED59 RID: 191833
		public const int TerrainItem = 2;

		// Token: 0x0402ED5A RID: 191834
		public const int MaskButton = 3;

		// Token: 0x0402ED5B RID: 191835
		public const int TitleText = 4;
	}
}
