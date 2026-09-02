using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200141E RID: 5150
[NullableContext(1)]
[Nullable(0)]
public class MoonChasingUnlockRoleView : UiViewBase
{
	// Token: 0x06008EC6 RID: 36550 RVA: 0x00257E93 File Offset: 0x00256093
	public MoonChasingUnlockRoleView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008EC7 RID: 36551 RVA: 0x00257E9C File Offset: 0x0025609C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClose))
		};
	}

	// Token: 0x06008EC8 RID: 36552 RVA: 0x00257F48 File Offset: 0x00256148
	protected override UniTask OnBeforeStartAsync()
	{
		MoonChasingUnlockRoleView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MoonChasingUnlockRoleView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008EC9 RID: 36553 RVA: 0x00257F8C File Offset: 0x0025618C
	private UniTask RefreshSpine(EntrustRole config)
	{
		MoonChasingUnlockRoleView.<RefreshSpine>d__5 <RefreshSpine>d__;
		<RefreshSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshSpine>d__.<>4__this = this;
		<RefreshSpine>d__.config = config;
		<RefreshSpine>d__.<>1__state = -1;
		<RefreshSpine>d__.<>t__builder.Start<MoonChasingUnlockRoleView.<RefreshSpine>d__5>(ref <RefreshSpine>d__);
		return <RefreshSpine>d__.<>t__builder.Task;
	}

	// Token: 0x06008ECA RID: 36554 RVA: 0x00257FD8 File Offset: 0x002561D8
	private UniTask Refresh()
	{
		MoonChasingUnlockRoleView.<Refresh>d__6 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<MoonChasingUnlockRoleView.<Refresh>d__6>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x06008ECB RID: 36555 RVA: 0x0025801C File Offset: 0x0025621C
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		MoonChasingUnlockRoleView.<OnBeforeShowAsyncImplement>d__7 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<MoonChasingUnlockRoleView.<OnBeforeShowAsyncImplement>d__7>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06008ECC RID: 36556 RVA: 0x0025805F File Offset: 0x0025625F
	private CharacterItemWithLine InitCharacterItem()
	{
		return new CharacterItemWithLine();
	}

	// Token: 0x06008ECD RID: 36557 RVA: 0x00258068 File Offset: 0x00256268
	private void OnClose()
	{
		this.RoleId = ModelBase<MoonChasingBusinessModel>.Instance.PopUnlockRoleId();
		if (this.RoleId != null)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.PlaySequencePurely("Switch", false, false);
			}
			this.Refresh().Forget();
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0400427C RID: 17020
	protected CharacterListModule<CharacterItemWithLine> CharacterListModule;

	// Token: 0x0400427D RID: 17021
	protected int? RoleId;

	// Token: 0x0200781E RID: 30750
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04029505 RID: 169221
		public const int RoleSpine = 0;

		// Token: 0x04029506 RID: 169222
		public const int Name = 1;

		// Token: 0x04029507 RID: 169223
		public const int CharacterListItem = 2;

		// Token: 0x04029508 RID: 169224
		public const int CloseBtn = 3;

		// Token: 0x04029509 RID: 169225
		public const int Dialog = 4;
	}
}
