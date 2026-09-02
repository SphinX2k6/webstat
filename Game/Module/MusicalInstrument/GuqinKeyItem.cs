using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056D0 RID: 22224
	public class GuqinKeyItem : MusicalInstrumentKeyItem
	{
		// Token: 0x0603892F RID: 231727 RVA: 0x00E5550C File Offset: 0x00E5370C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06038930 RID: 231728 RVA: 0x00E555FC File Offset: 0x00E537FC
		protected override void OnStart()
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.OnPointDownCallBack.Bind(new Action(this.OnPointerDown));
			}
			this.LevelSequencePlayer = new UiSequencePlayer(base.GetButton(0).RootUIComp);
		}

		// Token: 0x06038931 RID: 231729 RVA: 0x00E55648 File Offset: 0x00E53848
		protected override void OnBeforeDestroy()
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.OnPointDownCallBack.Unbind();
		}

		// Token: 0x06038932 RID: 231730 RVA: 0x00E55660 File Offset: 0x00E53860
		public void RefreshMode(EZitherAudioType audioType)
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(audioType == EZitherAudioType.FundamentalTone);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(audioType == EZitherAudioType.OverTone);
		}

		// Token: 0x06038933 RID: 231731 RVA: 0x00E5568D File Offset: 0x00E5388D
		public override void OnQteFocus(bool isFocus)
		{
			UUIItem item = base.GetItem(8);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isFocus);
		}

		// Token: 0x06038934 RID: 231732 RVA: 0x00E556A4 File Offset: 0x00E538A4
		public override void OnQtePerformance(bool success)
		{
			UiSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopPrevSequence(false, true);
			}
			UiSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlayOrReplaySequenceByName(success ? "Right" : "Wrong", false, null);
		}

		// Token: 0x06038935 RID: 231733 RVA: 0x00E556F0 File Offset: 0x00E538F0
		private void OnPointerDown()
		{
			Action<int, int> onPointerDownCallback = this.OnPointerDownCallback;
			if (onPointerDownCallback != null)
			{
				onPointerDownCallback(this.RowIndex, this.ColumnIndex);
			}
			UiSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayOrReplaySequenceByName("Aftermath", false, null);
		}

		// Token: 0x06038936 RID: 231734 RVA: 0x00E55739 File Offset: 0x00E53939
		public void SetInteractive(bool isInteractive)
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(isInteractive);
		}

		// Token: 0x04020473 RID: 132211
		[Nullable(2)]
		private UiSequencePlayer LevelSequencePlayer;

		// Token: 0x0200B753 RID: 46931
		private enum EGuqinKeyItemComponent
		{
			// Token: 0x04038B3C RID: 232252
			Button,
			// Token: 0x04038B3D RID: 232253
			PnlFundamentalTone,
			// Token: 0x04038B3E RID: 232254
			PnlOverTone,
			// Token: 0x04038B3F RID: 232255
			SprPoint,
			// Token: 0x04038B40 RID: 232256
			SprNum,
			// Token: 0x04038B41 RID: 232257
			TextNote,
			// Token: 0x04038B42 RID: 232258
			PnlErrorState,
			// Token: 0x04038B43 RID: 232259
			PnlSuccessState,
			// Token: 0x04038B44 RID: 232260
			PnlQte
		}
	}
}
