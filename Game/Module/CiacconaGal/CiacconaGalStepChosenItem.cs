using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EBC RID: 24252
	public class CiacconaGalStepChosenItem : UiPanelBase
	{
		// Token: 0x0603CF51 RID: 249681 RVA: 0x00F7B3E4 File Offset: 0x00F795E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CF52 RID: 249682 RVA: 0x00F7B44D File Offset: 0x00F7964D
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603CF53 RID: 249683 RVA: 0x00F7B460 File Offset: 0x00F79660
		protected override void OnAfterShow()
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0603CF54 RID: 249684 RVA: 0x00F7B490 File Offset: 0x00F79690
		[NullableContext(1)]
		public void Refresh(CiacconaGalChoiceData choiceData)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), choiceData.Content, Array.Empty<object>());
			base.SetTextureByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_PlotReasoningIcon03"), base.GetTexture(1), null, null);
		}

		// Token: 0x04022377 RID: 140151
		[Nullable(2)]
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0200BEAC RID: 48812
		private class EComponentDefine
		{
			// Token: 0x0403AB23 RID: 240419
			public const int TextContent = 0;

			// Token: 0x0403AB24 RID: 240420
			public const int ImageIcon = 1;
		}
	}
}
