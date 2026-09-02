using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001583 RID: 5507
[NullableContext(1)]
[Nullable(0)]
public class ActivityParkourButton : UiPanelBase
{
	// Token: 0x06009AB9 RID: 39609 RVA: 0x002887C4 File Offset: 0x002869C4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickedButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009ABA RID: 39610 RVA: 0x002888AC File Offset: 0x00286AAC
	protected override void OnBeforeShow()
	{
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText("", true);
		}
		UUIText text2 = base.GetText(2);
		if (text2 == null)
		{
			return;
		}
		text2.SetText("", true);
	}

	// Token: 0x06009ABB RID: 39611 RVA: 0x002888E0 File Offset: 0x00286AE0
	public UniTask InitializeAsync(AActor rootActor, Action onClickCall)
	{
		ActivityParkourButton.<InitializeAsync>d__4 <InitializeAsync>d__;
		<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeAsync>d__.<>4__this = this;
		<InitializeAsync>d__.rootActor = rootActor;
		<InitializeAsync>d__.onClickCall = onClickCall;
		<InitializeAsync>d__.<>1__state = -1;
		<InitializeAsync>d__.<>t__builder.Start<ActivityParkourButton.<InitializeAsync>d__4>(ref <InitializeAsync>d__);
		return <InitializeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009ABC RID: 39612 RVA: 0x00288933 File Offset: 0x00286B33
	private void OnClickedButton()
	{
		Action onClickEvent = this.OnClickEvent;
		if (onClickEvent == null)
		{
			return;
		}
		onClickEvent();
	}

	// Token: 0x06009ABD RID: 39613 RVA: 0x00288945 File Offset: 0x00286B45
	public void SetFloatText(string textId, params string[] args)
	{
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(true);
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), textId, args);
	}

	// Token: 0x06009ABE RID: 39614 RVA: 0x0028896D File Offset: 0x00286B6D
	public void SetBtnText(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), textId, args);
	}

	// Token: 0x04004748 RID: 18248
	[Nullable(2)]
	private Action OnClickEvent;

	// Token: 0x02007948 RID: 31048
	[NullableContext(0)]
	private class ESimpleButtonChildType
	{
		// Token: 0x04029A9F RID: 170655
		public const int ButtonText = 0;

		// Token: 0x04029AA0 RID: 170656
		public const int DescriptionItem = 1;

		// Token: 0x04029AA1 RID: 170657
		public const int DescriptionText = 2;

		// Token: 0x04029AA2 RID: 170658
		public const int Button = 3;
	}
}
