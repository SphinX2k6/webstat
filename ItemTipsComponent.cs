using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200197C RID: 6524
public class ItemTipsComponent : UiPanelBase, IItemTipsUiProxy
{
	// Token: 0x0600BB8E RID: 48014 RVA: 0x0031D1BC File Offset: 0x0031B3BC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BB8F RID: 48015 RVA: 0x0031D204 File Offset: 0x0031B404
	protected override UniTask OnBeforeStartAsync()
	{
		ItemTipsComponent.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ItemTipsComponent.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BB90 RID: 48016 RVA: 0x0031D247 File Offset: 0x0031B447
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600BB91 RID: 48017 RVA: 0x0031D25A File Offset: 0x0031B45A
	protected override void OnBeforeShow()
	{
		this.PlayStartSequence();
	}

	// Token: 0x0600BB92 RID: 48018 RVA: 0x0031D264 File Offset: 0x0031B464
	private void PlayStartSequence()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x0600BB93 RID: 48019 RVA: 0x0031D294 File Offset: 0x0031B494
	public UniTask PlayCloseSequence()
	{
		ItemTipsComponent.<PlayCloseSequence>d__7 <PlayCloseSequence>d__;
		<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseSequence>d__.<>4__this = this;
		<PlayCloseSequence>d__.<>1__state = -1;
		<PlayCloseSequence>d__.<>t__builder.Start<ItemTipsComponent.<PlayCloseSequence>d__7>(ref <PlayCloseSequence>d__);
		return <PlayCloseSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600BB94 RID: 48020 RVA: 0x0031D2D7 File Offset: 0x0031B4D7
	[NullableContext(1)]
	public void RefreshTipsComponentByType(ItemTipsData data)
	{
		ItemTipsComponentContentComponent content = this.Content;
		if (content == null)
		{
			return;
		}
		content.RefreshTipsComponentByType(data);
	}

	// Token: 0x0600BB95 RID: 48021 RVA: 0x0031D2EA File Offset: 0x0031B4EA
	[NullableContext(1)]
	public void Refresh(ItemTipsData data)
	{
		ItemTipsComponentContentComponent content = this.Content;
		if (content == null)
		{
			return;
		}
		content.Refresh(data);
	}

	// Token: 0x0600BB96 RID: 48022 RVA: 0x0031D2FD File Offset: 0x0031B4FD
	public void SetTipsNumShow(bool isShow)
	{
		ItemTipsComponentContentComponent content = this.Content;
		if (content == null)
		{
			return;
		}
		content.SetTipsNumShow(isShow);
	}

	// Token: 0x0600BB97 RID: 48023 RVA: 0x0031D310 File Offset: 0x0031B510
	public void SetTipsComponentLockButton(bool isShow)
	{
		ItemTipsComponentContentComponent content = this.Content;
		if (content == null)
		{
			return;
		}
		content.SetTipsComponentLockButton(isShow);
	}

	// Token: 0x04005894 RID: 22676
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04005895 RID: 22677
	[Nullable(2)]
	private ItemTipsComponentContentComponent Content;
}
