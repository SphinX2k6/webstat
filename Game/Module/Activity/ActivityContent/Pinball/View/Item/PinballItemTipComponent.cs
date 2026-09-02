using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x02006612 RID: 26130
	public class PinballItemTipComponent : UiPanelBase, IItemTipsUiProxy
	{
		// Token: 0x060414B1 RID: 267441 RVA: 0x010BF9D4 File Offset: 0x010BDBD4
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

		// Token: 0x060414B2 RID: 267442 RVA: 0x010BFA1C File Offset: 0x010BDC1C
		protected override UniTask OnBeforeStartAsync()
		{
			PinballItemTipComponent.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballItemTipComponent.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060414B3 RID: 267443 RVA: 0x010BFA5F File Offset: 0x010BDC5F
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x060414B4 RID: 267444 RVA: 0x010BFA72 File Offset: 0x010BDC72
		protected override void OnBeforeShow()
		{
			this.PlayStartSequence();
		}

		// Token: 0x060414B5 RID: 267445 RVA: 0x010BFA7C File Offset: 0x010BDC7C
		private void PlayStartSequence()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
		}

		// Token: 0x060414B6 RID: 267446 RVA: 0x010BFAAC File Offset: 0x010BDCAC
		public UniTask PlayCloseSequence()
		{
			PinballItemTipComponent.<PlayCloseSequence>d__8 <PlayCloseSequence>d__;
			<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCloseSequence>d__.<>4__this = this;
			<PlayCloseSequence>d__.<>1__state = -1;
			<PlayCloseSequence>d__.<>t__builder.Start<PinballItemTipComponent.<PlayCloseSequence>d__8>(ref <PlayCloseSequence>d__);
			return <PlayCloseSequence>d__.<>t__builder.Task;
		}

		// Token: 0x060414B7 RID: 267447 RVA: 0x010BFAEF File Offset: 0x010BDCEF
		[NullableContext(1)]
		public void Refresh(ItemTipsData data)
		{
			PinballItemTipsComponentContentComponent content = this.Content;
			if (content == null)
			{
				return;
			}
			content.Refresh(data);
		}

		// Token: 0x04024894 RID: 149652
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04024895 RID: 149653
		[Nullable(2)]
		private PinballItemTipsComponentContentComponent Content;

		// Token: 0x0200C637 RID: 50743
		private enum EPinballItemTipComponent
		{
			// Token: 0x0403D03B RID: 249915
			Item
		}
	}
}
