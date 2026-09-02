using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002737 RID: 10039
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDangoSkillView : UiViewBase
{
	// Token: 0x06013CD9 RID: 81113 RVA: 0x00583137 File Offset: 0x00581337
	public RacingBetsDangoSkillView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013CDA RID: 81114 RVA: 0x00583140 File Offset: 0x00581340
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

	// Token: 0x06013CDB RID: 81115 RVA: 0x00583204 File Offset: 0x00581404
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsDangoSkillView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsDangoSkillView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013CDC RID: 81116 RVA: 0x00583247 File Offset: 0x00581447
	private void OnClickCloseButton()
	{
		Action closeCallback = this.CloseCallback;
		if (closeCallback != null)
		{
			closeCallback();
		}
		base.CloseMe(null);
	}

	// Token: 0x06013CDD RID: 81117 RVA: 0x00583261 File Offset: 0x00581461
	private RacingBetsDangoSkillItem DangoSkillItemProxyCreate()
	{
		return new RacingBetsDangoSkillItem();
	}

	// Token: 0x04009A1C RID: 39452
	private GenericLayout<RacingBetsDangoSkillItem, RacingBetsDungeonDangoInfo> DangoSkillLayout;

	// Token: 0x04009A1D RID: 39453
	[Nullable(2)]
	private Action CloseCallback;

	// Token: 0x02008AE5 RID: 35557
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ED4E RID: 191822
		public const int CloseButton = 0;

		// Token: 0x0402ED4F RID: 191823
		public const int SkillLayout = 1;

		// Token: 0x0402ED50 RID: 191824
		public const int SkillItem = 2;

		// Token: 0x0402ED51 RID: 191825
		public const int MaskButton = 3;

		// Token: 0x0402ED52 RID: 191826
		public const int TitleText = 4;
	}
}
