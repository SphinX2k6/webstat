using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F1A RID: 24346
	public class FlagChallengeAnimItem : UiPanelBase
	{
		// Token: 0x0603D277 RID: 250487 RVA: 0x00F8A29C File Offset: 0x00F8849C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D278 RID: 250488 RVA: 0x00F8A326 File Offset: 0x00F88526
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEnd), false);
		}

		// Token: 0x0603D279 RID: 250489 RVA: 0x00F8A356 File Offset: 0x00F88556
		[NullableContext(1)]
		private void OnSequenceEnd(string sequenceName)
		{
			base.SetUiActive(false);
		}

		// Token: 0x0603D27A RID: 250490 RVA: 0x00F8A35F File Offset: 0x00F8855F
		public void Clear()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x0603D27B RID: 250491 RVA: 0x00F8A374 File Offset: 0x00F88574
		public void PlayStartShowAnim()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, true);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlaySequencePurely("Start", false, false, null, null, false);
			}
			base.SetUiActive(true);
			this.SetArrowVisible(false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Morale_32_title_41", Array.Empty<object>());
		}

		// Token: 0x0603D27C RID: 250492 RVA: 0x00F8A3E0 File Offset: 0x00F885E0
		public void PlayEndShowAnim()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, true);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlaySequencePurely("StartR", false, false, null, null, false);
			}
			this.SetArrowVisible(false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Morale_32_title_42", Array.Empty<object>());
		}

		// Token: 0x0603D27D RID: 250493 RVA: 0x00F8A448 File Offset: 0x00F88648
		public void PlayLevelUpAnim()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, true);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlayLevelSequenceByName("Start", false, null, false);
			}
			this.SetArrowVisible(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Morale_32_title_40", Array.Empty<object>());
		}

		// Token: 0x0603D27E RID: 250494 RVA: 0x00F8A4AB File Offset: 0x00F886AB
		[NullableContext(1)]
		public void SetText(string text)
		{
			UUIText text2 = base.GetText(2);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(text, true);
		}

		// Token: 0x0603D27F RID: 250495 RVA: 0x00F8A4C0 File Offset: 0x00F886C0
		private void SetArrowVisible(bool visible)
		{
			UUITexture texture = base.GetTexture(0);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(visible);
		}

		// Token: 0x040224B4 RID: 140468
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200BF20 RID: 48928
		private enum EAnimItemComponentType
		{
			// Token: 0x0403AD46 RID: 240966
			ArrowTexture,
			// Token: 0x0403AD47 RID: 240967
			BgSprite,
			// Token: 0x0403AD48 RID: 240968
			DescText
		}
	}
}
