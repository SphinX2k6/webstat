using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013DB RID: 5083
public class BusinessTipsBurstView : UiViewBase
{
	// Token: 0x06008C87 RID: 35975 RVA: 0x0024F14B File Offset: 0x0024D34B
	[NullableContext(1)]
	public BusinessTipsBurstView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008C88 RID: 35976 RVA: 0x0024F154 File Offset: 0x0024D354
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture))
		};
	}

	// Token: 0x06008C89 RID: 35977 RVA: 0x0024F178 File Offset: 0x0024D378
	protected override UniTask OnBeforeStartAsync()
	{
		BusinessTipsBurstView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BusinessTipsBurstView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008C8A RID: 35978 RVA: 0x0024F1BB File Offset: 0x0024D3BB
	protected override void OnBeforeShow()
	{
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			ControllerBase<MoonChasingController>.Instance.OpenResultView();
		}, 2000f, null, null, true, 1f);
	}

	// Token: 0x020077B6 RID: 30646
	private static class EComponentDefine
	{
		// Token: 0x04029331 RID: 168753
		public const int RoleTexture = 0;
	}
}
