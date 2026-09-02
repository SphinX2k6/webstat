using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.LordGymPanel
{
	// Token: 0x02004BA3 RID: 19363
	public class LordGymDifficultyStateItem : GridProxyAbstract<ELordGymDifficultyState>
	{
		// Token: 0x060328E8 RID: 207080 RVA: 0x00CA7A14 File Offset: 0x00CA5C14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060328E9 RID: 207081 RVA: 0x00CA7A5C File Offset: 0x00CA5C5C
		public override void Refresh(ELordGymDifficultyState state, bool isSelected, int gridIndex)
		{
			string resourceId = "";
			switch (state)
			{
			case ELordGymDifficultyState.Lock:
				resourceId = "T_MapDifficultyLock";
				break;
			case ELordGymDifficultyState.Empty:
				resourceId = "T_MapDifficultyEmpty";
				break;
			case ELordGymDifficultyState.Ticked:
				resourceId = "T_MapDifficultyTick";
				break;
			}
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			string path = (instance != null) ? instance.GetResourcePath(resourceId) : null;
			base.SetTextureByPath(path, base.GetTexture(0), null, null);
		}

		// Token: 0x0200AC80 RID: 44160
		public static class EComponent
		{
			// Token: 0x040359EE RID: 219630
			public const int TexState = 0;
		}
	}
}
