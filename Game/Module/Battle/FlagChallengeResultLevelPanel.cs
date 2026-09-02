using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F27 RID: 24359
	public class FlagChallengeResultLevelPanel : UiPanelBase
	{
		// Token: 0x0603D2CB RID: 250571 RVA: 0x00F8BDF8 File Offset: 0x00F89FF8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D2CC RID: 250572 RVA: 0x00F8BEA3 File Offset: 0x00F8A0A3
		[NullableContext(1)]
		public void SetLevelText(string level, string levelDiff, string boxLevel)
		{
			base.GetArtText(0).SetText(level);
			base.GetText(2).SetText(levelDiff, true);
			base.GetText(1).SetText(boxLevel, true);
		}

		// Token: 0x0200BF36 RID: 48950
		private enum EChildComponentType
		{
			// Token: 0x0403ADB4 RID: 241076
			LevelArtText,
			// Token: 0x0403ADB5 RID: 241077
			BoxLevelText,
			// Token: 0x0403ADB6 RID: 241078
			LevelDiffText,
			// Token: 0x0403ADB7 RID: 241079
			ArrowSprite
		}
	}
}
