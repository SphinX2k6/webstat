using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x02006915 RID: 26901
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class DropCatchGameplayScoreItem : GridProxyAbstract<IScoreLevelItemData>
	{
		// Token: 0x06042D06 RID: 273670 RVA: 0x01126780 File Offset: 0x01124980
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIArtText)),
				new ValueTuple<int, Type>(1, typeof(UUIArtText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06042D07 RID: 273671 RVA: 0x011267F0 File Offset: 0x011249F0
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
		}

		// Token: 0x06042D08 RID: 273672 RVA: 0x01126804 File Offset: 0x01124A04
		public override void Refresh(IScoreLevelItemData data, bool isSelected, int gridIndex)
		{
			UUIArtText artText = base.GetArtText(0);
			if (artText != null)
			{
				artText.SetText(data.Score.ToString());
			}
			UUIArtText artText2 = base.GetArtText(1);
			if (artText2 != null)
			{
				artText2.SetText(data.Score.ToString());
			}
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(!data.IsFinish);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(data.IsFinish);
			}
			if (data.IsFinish && !this.HasFinished)
			{
				this.HasFinished = true;
				UiSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.PlaySequence("Bright", false, null);
			}
		}

		// Token: 0x06042D09 RID: 273673 RVA: 0x011268B4 File Offset: 0x01124AB4
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.Clear();
		}

		// Token: 0x040253D0 RID: 152528
		private bool HasFinished;

		// Token: 0x040253D1 RID: 152529
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;
	}
}
