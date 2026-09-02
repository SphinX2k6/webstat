using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Opponent
{
	// Token: 0x020055F6 RID: 22006
	[NullableContext(1)]
	[Nullable(0)]
	public class OpponentHandCardItem : UiPanelBase
	{
		// Token: 0x06038115 RID: 229653 RVA: 0x00E342C2 File Offset: 0x00E324C2
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem))
			};
		}

		// Token: 0x06038116 RID: 229654 RVA: 0x00E342E8 File Offset: 0x00E324E8
		protected override void OnStart()
		{
			this.CardSequence = new UiSequencePlayer(this.RootItem);
			this.TweenLogic = new PhantomArenaCardTweenLogic();
			this.TweenLogic.Init(base.GetItem(0));
			base.GetItem(0).SetAlpha(0f);
		}

		// Token: 0x06038117 RID: 229655 RVA: 0x00E34334 File Offset: 0x00E32534
		protected override void OnBeforeDestroy()
		{
			this.TweenLogic.Destroy();
			this.CardSequence.Clear();
		}

		// Token: 0x06038118 RID: 229656 RVA: 0x00E3434C File Offset: 0x00E3254C
		public void SetAreaItem(OpponentArea areaItem)
		{
			this.AreaItem = areaItem;
		}

		// Token: 0x06038119 RID: 229657 RVA: 0x00E34358 File Offset: 0x00E32558
		public UniTask PlayStartTimeLocationTween(UUIItem fromItem, int delayTime)
		{
			OpponentHandCardItem.<PlayStartTimeLocationTween>d__8 <PlayStartTimeLocationTween>d__;
			<PlayStartTimeLocationTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartTimeLocationTween>d__.<>4__this = this;
			<PlayStartTimeLocationTween>d__.fromItem = fromItem;
			<PlayStartTimeLocationTween>d__.delayTime = delayTime;
			<PlayStartTimeLocationTween>d__.<>1__state = -1;
			<PlayStartTimeLocationTween>d__.<>t__builder.Start<OpponentHandCardItem.<PlayStartTimeLocationTween>d__8>(ref <PlayStartTimeLocationTween>d__);
			return <PlayStartTimeLocationTween>d__.<>t__builder.Task;
		}

		// Token: 0x0603811A RID: 229658 RVA: 0x00E343AC File Offset: 0x00E325AC
		public UniTask PlayEndTimeLocationTween(UUIItem toItem, int delayTime)
		{
			OpponentHandCardItem.<PlayEndTimeLocationTween>d__9 <PlayEndTimeLocationTween>d__;
			<PlayEndTimeLocationTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayEndTimeLocationTween>d__.<>4__this = this;
			<PlayEndTimeLocationTween>d__.toItem = toItem;
			<PlayEndTimeLocationTween>d__.delayTime = delayTime;
			<PlayEndTimeLocationTween>d__.<>1__state = -1;
			<PlayEndTimeLocationTween>d__.<>t__builder.Start<OpponentHandCardItem.<PlayEndTimeLocationTween>d__9>(ref <PlayEndTimeLocationTween>d__);
			return <PlayEndTimeLocationTween>d__.<>t__builder.Task;
		}

		// Token: 0x0603811B RID: 229659 RVA: 0x00E34400 File Offset: 0x00E32600
		public UniTask PlayAddCardTween(UUIItem fromItem)
		{
			OpponentHandCardItem.<PlayAddCardTween>d__10 <PlayAddCardTween>d__;
			<PlayAddCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAddCardTween>d__.<>4__this = this;
			<PlayAddCardTween>d__.fromItem = fromItem;
			<PlayAddCardTween>d__.<>1__state = -1;
			<PlayAddCardTween>d__.<>t__builder.Start<OpponentHandCardItem.<PlayAddCardTween>d__10>(ref <PlayAddCardTween>d__);
			return <PlayAddCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x0603811C RID: 229660 RVA: 0x00E3444C File Offset: 0x00E3264C
		public UniTask PlayBackToLibraryTween(UUIItem toItem)
		{
			OpponentHandCardItem.<PlayBackToLibraryTween>d__11 <PlayBackToLibraryTween>d__;
			<PlayBackToLibraryTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayBackToLibraryTween>d__.<>4__this = this;
			<PlayBackToLibraryTween>d__.toItem = toItem;
			<PlayBackToLibraryTween>d__.<>1__state = -1;
			<PlayBackToLibraryTween>d__.<>t__builder.Start<OpponentHandCardItem.<PlayBackToLibraryTween>d__11>(ref <PlayBackToLibraryTween>d__);
			return <PlayBackToLibraryTween>d__.<>t__builder.Task;
		}

		// Token: 0x0603811D RID: 229661 RVA: 0x00E34498 File Offset: 0x00E32698
		public UniTask PlayBackToRecycleTween(UUIItem toItem)
		{
			OpponentHandCardItem.<PlayBackToRecycleTween>d__12 <PlayBackToRecycleTween>d__;
			<PlayBackToRecycleTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayBackToRecycleTween>d__.<>4__this = this;
			<PlayBackToRecycleTween>d__.toItem = toItem;
			<PlayBackToRecycleTween>d__.<>1__state = -1;
			<PlayBackToRecycleTween>d__.<>t__builder.Start<OpponentHandCardItem.<PlayBackToRecycleTween>d__12>(ref <PlayBackToRecycleTween>d__);
			return <PlayBackToRecycleTween>d__.<>t__builder.Task;
		}

		// Token: 0x0603811E RID: 229662 RVA: 0x00E344E3 File Offset: 0x00E326E3
		public void PlaySequence(string sequenceName, bool isReverse = false)
		{
			this.CardSequence.StopPrevSequence(false, true);
			this.CardSequence.PlaySequencePurely(sequenceName, false, isReverse);
		}

		// Token: 0x0603811F RID: 229663 RVA: 0x00E34500 File Offset: 0x00E32700
		public UniTask DissolveByLibrary()
		{
			OpponentHandCardItem.<DissolveByLibrary>d__14 <DissolveByLibrary>d__;
			<DissolveByLibrary>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DissolveByLibrary>d__.<>4__this = this;
			<DissolveByLibrary>d__.<>1__state = -1;
			<DissolveByLibrary>d__.<>t__builder.Start<OpponentHandCardItem.<DissolveByLibrary>d__14>(ref <DissolveByLibrary>d__);
			return <DissolveByLibrary>d__.<>t__builder.Task;
		}

		// Token: 0x06038120 RID: 229664 RVA: 0x00E34544 File Offset: 0x00E32744
		public UniTask PlayRemoveSequence()
		{
			OpponentHandCardItem.<PlayRemoveSequence>d__15 <PlayRemoveSequence>d__;
			<PlayRemoveSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayRemoveSequence>d__.<>4__this = this;
			<PlayRemoveSequence>d__.<>1__state = -1;
			<PlayRemoveSequence>d__.<>t__builder.Start<OpponentHandCardItem.<PlayRemoveSequence>d__15>(ref <PlayRemoveSequence>d__);
			return <PlayRemoveSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06038121 RID: 229665 RVA: 0x00E34588 File Offset: 0x00E32788
		public UniTask PlayMoveInSequence()
		{
			OpponentHandCardItem.<PlayMoveInSequence>d__16 <PlayMoveInSequence>d__;
			<PlayMoveInSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayMoveInSequence>d__.<>4__this = this;
			<PlayMoveInSequence>d__.<>1__state = -1;
			<PlayMoveInSequence>d__.<>t__builder.Start<OpponentHandCardItem.<PlayMoveInSequence>d__16>(ref <PlayMoveInSequence>d__);
			return <PlayMoveInSequence>d__.<>t__builder.Task;
		}

		// Token: 0x040200E1 RID: 131297
		protected PhantomArenaCardTweenLogic TweenLogic;

		// Token: 0x040200E2 RID: 131298
		protected UiSequencePlayer CardSequence;

		// Token: 0x040200E3 RID: 131299
		protected OpponentArea AreaItem;

		// Token: 0x0200B643 RID: 46659
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038649 RID: 230985
			public const int CardItem = 0;
		}
	}
}
