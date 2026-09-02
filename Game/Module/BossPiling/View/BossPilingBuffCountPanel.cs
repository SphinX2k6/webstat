using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005EF9 RID: 24313
	public class BossPilingBuffCountPanel : UiPanelBase
	{
		// Token: 0x0603D14C RID: 250188 RVA: 0x00F83250 File Offset: 0x00F81450
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D14D RID: 250189 RVA: 0x00F832FB File Offset: 0x00F814FB
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x0603D14E RID: 250190 RVA: 0x00F83310 File Offset: 0x00F81510
		public void Refresh(int oldValue, int newValue, long buffId)
		{
			Buff value = ConfigBuffById.GetConfig(buffId, true).Value;
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetUIActive(newValue < value.StackLimitCount);
			}
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(newValue < value.StackLimitCount);
			}
			if (newValue >= value.StackLimitCount)
			{
				UUIText text2 = base.GetText(1);
				if (text2 == null)
				{
					return;
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(newValue);
				defaultInterpolatedStringHandler.AppendLiteral(" (MAX)");
				text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				return;
			}
			else
			{
				UUIText text3 = base.GetText(1);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
				if (text3 != null)
				{
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(oldValue);
					text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				}
				UUIText text4 = base.GetText(3);
				if (text4 == null)
				{
					return;
				}
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(newValue);
				text4.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				return;
			}
		}

		// Token: 0x0603D14F RID: 250191 RVA: 0x00F833FB File Offset: 0x00F815FB
		public void PlaySequence(float rate)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, new float?(rate), false);
		}

		// Token: 0x0402242E RID: 140334
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200BEF3 RID: 48883
		private enum ECount
		{
			// Token: 0x0403AC4D RID: 240717
			Title,
			// Token: 0x0403AC4E RID: 240718
			TxtOld,
			// Token: 0x0403AC4F RID: 240719
			PanelArrow,
			// Token: 0x0403AC50 RID: 240720
			TxtNew
		}
	}
}
