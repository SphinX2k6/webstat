using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Area.Hand
{
	// Token: 0x0200562E RID: 22062
	public class PhantomArenaHandAreaItem : UiPanelBase
	{
		// Token: 0x060383D3 RID: 230355 RVA: 0x00E3DB0C File Offset: 0x00E3BD0C
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
		}

		// Token: 0x060383D4 RID: 230356 RVA: 0x00E3DB1F File Offset: 0x00E3BD1F
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x060383D5 RID: 230357 RVA: 0x00E3DB2C File Offset: 0x00E3BD2C
		public UniTask PlayMoveOutSequence()
		{
			PhantomArenaHandAreaItem.<PlayMoveOutSequence>d__3 <PlayMoveOutSequence>d__;
			<PlayMoveOutSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayMoveOutSequence>d__.<>4__this = this;
			<PlayMoveOutSequence>d__.<>1__state = -1;
			<PlayMoveOutSequence>d__.<>t__builder.Start<PhantomArenaHandAreaItem.<PlayMoveOutSequence>d__3>(ref <PlayMoveOutSequence>d__);
			return <PlayMoveOutSequence>d__.<>t__builder.Task;
		}

		// Token: 0x060383D6 RID: 230358 RVA: 0x00E3DB70 File Offset: 0x00E3BD70
		public UniTask PlayMoveInSequence()
		{
			PhantomArenaHandAreaItem.<PlayMoveInSequence>d__4 <PlayMoveInSequence>d__;
			<PlayMoveInSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayMoveInSequence>d__.<>4__this = this;
			<PlayMoveInSequence>d__.<>1__state = -1;
			<PlayMoveInSequence>d__.<>t__builder.Start<PhantomArenaHandAreaItem.<PlayMoveInSequence>d__4>(ref <PlayMoveInSequence>d__);
			return <PlayMoveInSequence>d__.<>t__builder.Task;
		}

		// Token: 0x040201BA RID: 131514
		[Nullable(1)]
		protected UiSequencePlayer Sequence;
	}
}
