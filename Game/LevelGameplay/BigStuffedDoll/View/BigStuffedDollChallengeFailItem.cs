using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll.View
{
	// Token: 0x02006F5F RID: 28511
	public class BigStuffedDollChallengeFailItem : UiPanelBase
	{
		// Token: 0x06045030 RID: 282672 RVA: 0x011F7124 File Offset: 0x011F5324
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

		// Token: 0x06045031 RID: 282673 RVA: 0x011F716C File Offset: 0x011F536C
		protected override void OnStart()
		{
			base.OnStart();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		}

		// Token: 0x06045032 RID: 282674 RVA: 0x011F719D File Offset: 0x011F539D
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x06045033 RID: 282675 RVA: 0x011F71B8 File Offset: 0x011F53B8
		[NullableContext(1)]
		public void ShowTip(string key)
		{
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, key, Array.Empty<object>());
			base.ShowAsync();
			this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x06045034 RID: 282676 RVA: 0x011F7200 File Offset: 0x011F5400
		[NullableContext(1)]
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
				return;
			}
			if (!(sequenceName == "Close"))
			{
				return;
			}
			base.HideAsync();
			ModelBase<BigStuffedDollModel>.Instance.SetGameStage(EGameStage.Destroy);
		}

		// Token: 0x040267DE RID: 157662
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200CBF6 RID: 52214
		private class EViewComponent
		{
			// Token: 0x0403E8BC RID: 256188
			public const int TextTip = 0;
		}
	}
}
