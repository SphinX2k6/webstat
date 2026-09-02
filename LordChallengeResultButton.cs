using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020021EF RID: 8687
[NullableContext(1)]
[Nullable(0)]
public class LordChallengeResultButton : UiPanelBase
{
	// Token: 0x0601061F RID: 67103 RVA: 0x0047A340 File Offset: 0x00478540
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickedButton))
		};
	}

	// Token: 0x06010620 RID: 67104 RVA: 0x0047A3D3 File Offset: 0x004785D3
	protected override void OnBeforeShow()
	{
		base.GetText(0).SetText("", true);
		base.GetText(2).SetText("", true);
	}

	// Token: 0x06010621 RID: 67105 RVA: 0x0047A3FC File Offset: 0x004785FC
	public UniTask InitializeAsync(AActor rootActor, Action onClickCall)
	{
		LordChallengeResultButton.<InitializeAsync>d__4 <InitializeAsync>d__;
		<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeAsync>d__.<>4__this = this;
		<InitializeAsync>d__.rootActor = rootActor;
		<InitializeAsync>d__.onClickCall = onClickCall;
		<InitializeAsync>d__.<>1__state = -1;
		<InitializeAsync>d__.<>t__builder.Start<LordChallengeResultButton.<InitializeAsync>d__4>(ref <InitializeAsync>d__);
		return <InitializeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010622 RID: 67106 RVA: 0x0047A44F File Offset: 0x0047864F
	private void OnClickedButton()
	{
		Action onClickEvent = this.OnClickEvent;
		if (onClickEvent == null)
		{
			return;
		}
		onClickEvent();
	}

	// Token: 0x06010623 RID: 67107 RVA: 0x0047A461 File Offset: 0x00478661
	public void SetFloatText(string text)
	{
		base.GetText(2).SetUIActive(true);
		base.GetText(2).SetText(text, true);
	}

	// Token: 0x06010624 RID: 67108 RVA: 0x0047A47E File Offset: 0x0047867E
	public void SetFloatText(string textId, params string[] args)
	{
		base.GetText(2).SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textId, args);
	}

	// Token: 0x06010625 RID: 67109 RVA: 0x0047A4A0 File Offset: 0x004786A0
	public void SetBtnText(string text)
	{
		base.GetText(0).SetText(text, true);
	}

	// Token: 0x04008135 RID: 33077
	[Nullable(2)]
	private Action OnClickEvent;

	// Token: 0x020084B2 RID: 33970
	[NullableContext(0)]
	private class EButtonChildType
	{
		// Token: 0x0402CF4A RID: 184138
		public const int ButtonText = 0;

		// Token: 0x0402CF4B RID: 184139
		public const int DescriptionItem = 1;

		// Token: 0x0402CF4C RID: 184140
		public const int DescriptionText = 2;

		// Token: 0x0402CF4D RID: 184141
		public const int Button = 3;
	}
}
