using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012B3 RID: 4787
[NullableContext(1)]
[Nullable(0)]
public class ActivityCorniceMeetingButton : UiPanelBase
{
	// Token: 0x06008079 RID: 32889 RVA: 0x0021F00C File Offset: 0x0021D20C
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

	// Token: 0x0600807A RID: 32890 RVA: 0x0021F0F4 File Offset: 0x0021D2F4
	protected override void OnBeforeShow()
	{
		base.GetText(0).SetText("", true);
		base.GetText(2).SetText("", true);
	}

	// Token: 0x0600807B RID: 32891 RVA: 0x0021F11C File Offset: 0x0021D31C
	public UniTask InitializeAsync(AActor rootActor, Action onClickCall)
	{
		ActivityCorniceMeetingButton.<InitializeAsync>d__4 <InitializeAsync>d__;
		<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeAsync>d__.<>4__this = this;
		<InitializeAsync>d__.rootActor = rootActor;
		<InitializeAsync>d__.onClickCall = onClickCall;
		<InitializeAsync>d__.<>1__state = -1;
		<InitializeAsync>d__.<>t__builder.Start<ActivityCorniceMeetingButton.<InitializeAsync>d__4>(ref <InitializeAsync>d__);
		return <InitializeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600807C RID: 32892 RVA: 0x0021F16F File Offset: 0x0021D36F
	private void OnClickedButton()
	{
		Action onClickEvent = this.OnClickEvent;
		if (onClickEvent == null)
		{
			return;
		}
		onClickEvent();
	}

	// Token: 0x0600807D RID: 32893 RVA: 0x0021F181 File Offset: 0x0021D381
	public void SetFloatText(string textId, params string[] args)
	{
		base.GetText(2).SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), textId, args);
	}

	// Token: 0x0600807E RID: 32894 RVA: 0x0021F1A3 File Offset: 0x0021D3A3
	public void SetBtnText(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), textId, args);
	}

	// Token: 0x04003D51 RID: 15697
	[Nullable(2)]
	private Action OnClickEvent;

	// Token: 0x0200762C RID: 30252
	[NullableContext(0)]
	private class ESimpleButtonChildType
	{
		// Token: 0x04028BC1 RID: 166849
		public const int ButtonText = 0;

		// Token: 0x04028BC2 RID: 166850
		public const int DescriptionItem = 1;

		// Token: 0x04028BC3 RID: 166851
		public const int DescriptionText = 2;

		// Token: 0x04028BC4 RID: 166852
		public const int Button = 3;
	}
}
