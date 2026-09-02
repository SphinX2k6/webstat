using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C0F RID: 19471
	internal class ChatItem : UiPanelBase
	{
		// Token: 0x06032CC9 RID: 208073 RVA: 0x00CBA334 File Offset: 0x00CB8534
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06032CCA RID: 208074 RVA: 0x00CBA36D File Offset: 0x00CB856D
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06032CCB RID: 208075 RVA: 0x00CBA380 File Offset: 0x00CB8580
		[NullableContext(1)]
		public void Refresh(IVillageInfrChat data)
		{
			base.SetTextureByPath(data.HeadTexture, base.GetTexture(0), null, null);
			base.GetText(1).ShowTextNew(data.Chat);
		}

		// Token: 0x06032CCC RID: 208076 RVA: 0x00CBA3BC File Offset: 0x00CB85BC
		public void SetShow(bool visible, bool needAnimation = true)
		{
			this.RootItem.SetUIActive(visible);
			if (needAnimation)
			{
				LevelSequencePlayer seqPlayer = this.SeqPlayer;
				if (seqPlayer != null)
				{
					seqPlayer.StopCurrentSequence(false, false);
				}
				if (visible)
				{
					LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
					if (seqPlayer2 == null)
					{
						return;
					}
					seqPlayer2.PlayLevelSequenceByName("Start", false, null, false);
					return;
				}
				else
				{
					LevelSequencePlayer seqPlayer3 = this.SeqPlayer;
					if (seqPlayer3 == null)
					{
						return;
					}
					seqPlayer3.PlayLevelSequenceByName("Close", false, null, false);
				}
			}
		}

		// Token: 0x0401D8FA RID: 121082
		[Nullable(2)]
		private LevelSequencePlayer SeqPlayer;
	}
}
