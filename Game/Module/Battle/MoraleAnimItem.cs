using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F36 RID: 24374
	public class MoraleAnimItem : UiPanelBase
	{
		// Token: 0x0603D3C2 RID: 250818 RVA: 0x00F92C40 File Offset: 0x00F90E40
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

		// Token: 0x0603D3C3 RID: 250819 RVA: 0x00F92CCA File Offset: 0x00F90ECA
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

		// Token: 0x0603D3C4 RID: 250820 RVA: 0x00F92CFA File Offset: 0x00F90EFA
		[NullableContext(1)]
		private void OnSequenceEnd(string sequenceName)
		{
			base.SetUiActive(false);
		}

		// Token: 0x0603D3C5 RID: 250821 RVA: 0x00F92D03 File Offset: 0x00F90F03
		public void Clear()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x0603D3C6 RID: 250822 RVA: 0x00F92D18 File Offset: 0x00F90F18
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
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Morale_title_41", Array.Empty<object>());
		}

		// Token: 0x0603D3C7 RID: 250823 RVA: 0x00F92D84 File Offset: 0x00F90F84
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
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Morale_title_42", Array.Empty<object>());
		}

		// Token: 0x0603D3C8 RID: 250824 RVA: 0x00F92DEC File Offset: 0x00F90FEC
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
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Morale_title_40", Array.Empty<object>());
		}

		// Token: 0x0603D3C9 RID: 250825 RVA: 0x00F92E4F File Offset: 0x00F9104F
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

		// Token: 0x0603D3CA RID: 250826 RVA: 0x00F92E64 File Offset: 0x00F91064
		private void SetArrowVisible(bool visible)
		{
			UUITexture texture = base.GetTexture(0);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(visible);
		}

		// Token: 0x04022580 RID: 140672
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200BF5A RID: 48986
		private enum EAnimItemChildType
		{
			// Token: 0x0403AE6B RID: 241259
			ArrowTexture,
			// Token: 0x0403AE6C RID: 241260
			BgSprite,
			// Token: 0x0403AE6D RID: 241261
			DescText
		}
	}
}
