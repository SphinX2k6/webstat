using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D7A RID: 7546
[NullableContext(2)]
[Nullable(0)]
public class SpringManorHudButton : UiPanelBase
{
	// Token: 0x0600DDE1 RID: 56801 RVA: 0x003BA7E0 File Offset: 0x003B89E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickedButton))
		};
	}

	// Token: 0x0600DDE2 RID: 56802 RVA: 0x003BA848 File Offset: 0x003B8A48
	protected override UniTask OnBeforeStartAsync()
	{
		SpringManorHudButton.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorHudButton.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DDE3 RID: 56803 RVA: 0x003BA88B File Offset: 0x003B8A8B
	[NullableContext(1)]
	public void SetAction(string actionName)
	{
		this.ActionName = actionName;
	}

	// Token: 0x0600DDE4 RID: 56804 RVA: 0x003BA894 File Offset: 0x003B8A94
	private void OnClickedButton()
	{
		Action clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack();
	}

	// Token: 0x04006A94 RID: 27284
	private InputMultiKeyItem KeyItem;

	// Token: 0x04006A95 RID: 27285
	private string ActionName;

	// Token: 0x04006A96 RID: 27286
	public Action ClickCallBack;

	// Token: 0x020080F3 RID: 33011
	[NullableContext(0)]
	private static class EComp
	{
		// Token: 0x0402BD7E RID: 179582
		public const int Button = 0;

		// Token: 0x0402BD7F RID: 179583
		public const int RedDot = 1;

		// Token: 0x0402BD80 RID: 179584
		public const int KeyRoot = 2;
	}
}
