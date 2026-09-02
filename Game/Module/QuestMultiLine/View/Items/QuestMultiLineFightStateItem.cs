using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x0200532C RID: 21292
	public class QuestMultiLineFightStateItem : UiPanelBase
	{
		// Token: 0x06036553 RID: 222547 RVA: 0x00DB1CDD File Offset: 0x00DAFEDD
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x06036554 RID: 222548 RVA: 0x00DB1CF0 File Offset: 0x00DAFEF0
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x06036555 RID: 222549 RVA: 0x00DB1D0C File Offset: 0x00DAFF0C
		public UniTask PlayStartAsync()
		{
			QuestMultiLineFightStateItem.<PlayStartAsync>d__3 <PlayStartAsync>d__;
			<PlayStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartAsync>d__.<>4__this = this;
			<PlayStartAsync>d__.<>1__state = -1;
			<PlayStartAsync>d__.<>t__builder.Start<QuestMultiLineFightStateItem.<PlayStartAsync>d__3>(ref <PlayStartAsync>d__);
			return <PlayStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401F3D2 RID: 127954
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;
	}
}
