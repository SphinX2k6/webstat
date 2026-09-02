using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200627B RID: 25211
	public abstract class TotalTopUpPreviewSubViewBase : TotalTopUpPreviewSubView
	{
		// Token: 0x0603F7DD RID: 260061 RVA: 0x010474B0 File Offset: 0x010456B0
		protected override void OnStart()
		{
			UUIItem rootItem = this.RootItem;
			this.LevelSequencePlayer = new LevelSequencePlayer(rootItem);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x04023A44 RID: 145988
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;
	}
}
