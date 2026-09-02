using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200640D RID: 25613
	public class FloatTipsItem : SliderItem
	{
		// Token: 0x060404DC RID: 263388 RVA: 0x0107B4BC File Offset: 0x010796BC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060404DD RID: 263389 RVA: 0x0107B504 File Offset: 0x01079704
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishSequenceEvent), false);
		}

		// Token: 0x060404DE RID: 263390 RVA: 0x0107B52F File Offset: 0x0107972F
		protected override void OnBeforeDestroy()
		{
			if (this.LevelSequencePlayer != null)
			{
				this.LevelSequencePlayer.Clear();
				this.LevelSequencePlayer = null;
			}
		}

		// Token: 0x060404DF RID: 263391 RVA: 0x0107B54B File Offset: 0x0107974B
		[NullableContext(1)]
		private void FinishSequenceEvent(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				base.FinishPlayStart();
				return;
			}
			if (sequenceName == "Close")
			{
				base.FinishPlayEnd();
			}
		}

		// Token: 0x060404E0 RID: 263392 RVA: 0x0107B574 File Offset: 0x01079774
		protected override void PlayStart()
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x060404E1 RID: 263393 RVA: 0x0107B59C File Offset: 0x0107979C
		public override void PlayEnd()
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		}

		// Token: 0x060404E2 RID: 263394 RVA: 0x0107B5C4 File Offset: 0x010797C4
		protected override void OnActiveStatusChange(bool value)
		{
		}

		// Token: 0x060404E3 RID: 263395 RVA: 0x0107B5C8 File Offset: 0x010797C8
		public override UniTask AsyncLoadUiResource()
		{
			FloatTipsItem.<AsyncLoadUiResource>d__10 <AsyncLoadUiResource>d__;
			<AsyncLoadUiResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AsyncLoadUiResource>d__.<>4__this = this;
			<AsyncLoadUiResource>d__.<>1__state = -1;
			<AsyncLoadUiResource>d__.<>t__builder.Start<FloatTipsItem.<AsyncLoadUiResource>d__10>(ref <AsyncLoadUiResource>d__);
			return <AsyncLoadUiResource>d__.<>t__builder.Task;
		}

		// Token: 0x040240AB RID: 147627
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040240AC RID: 147628
		[Nullable(2)]
		private IRoverlikeFloatTextData Data;

		// Token: 0x0200C475 RID: 50293
		private class EFloatTipsItemCom
		{
			// Token: 0x0403C789 RID: 247689
			public const int TxtTips = 0;
		}
	}
}
