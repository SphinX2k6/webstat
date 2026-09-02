using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200259A RID: 9626
public class PhonographNewMusicView : UiViewBase
{
	// Token: 0x06012C12 RID: 76818 RVA: 0x0052C83F File Offset: 0x0052AA3F
	[NullableContext(1)]
	public PhonographNewMusicView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012C13 RID: 76819 RVA: 0x0052C848 File Offset: 0x0052AA48
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnMask))
		};
	}

	// Token: 0x06012C14 RID: 76820 RVA: 0x0052C8C8 File Offset: 0x0052AAC8
	protected override UniTask OnBeforeStartAsync()
	{
		PhonographNewMusicView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhonographNewMusicView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012C15 RID: 76821 RVA: 0x0052C90B File Offset: 0x0052AB0B
	protected override void OnBeforeDestroy()
	{
		PhonographNewMusicViewOpenParam openData = this.OpenData;
		if (openData == null)
		{
			return;
		}
		Action closeCallback = openData.CloseCallback;
		if (closeCallback == null)
		{
			return;
		}
		closeCallback();
	}

	// Token: 0x06012C16 RID: 76822 RVA: 0x0052C927 File Offset: 0x0052AB27
	[NullableContext(1)]
	protected PhonographNewMusicItem OnCreateItem()
	{
		return new PhonographNewMusicItem();
	}

	// Token: 0x06012C17 RID: 76823 RVA: 0x0052C92E File Offset: 0x0052AB2E
	protected void OnBtnMask()
	{
		base.CloseMe(null);
	}

	// Token: 0x04009274 RID: 37492
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayout<PhonographNewMusicItem, int> GenericLayout;

	// Token: 0x04009275 RID: 37493
	[Nullable(2)]
	private PhonographNewMusicViewOpenParam OpenData;

	// Token: 0x020088E5 RID: 35045
	private static class EPhonographNewMusicViewDefine
	{
		// Token: 0x0402E373 RID: 189299
		public const int BtnMask = 0;

		// Token: 0x0402E374 RID: 189300
		public const int VerticalLayout = 1;

		// Token: 0x0402E375 RID: 189301
		public const int VerticalLayoutItem = 2;
	}
}
