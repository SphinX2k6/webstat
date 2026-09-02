using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200514E RID: 20814
	public class TipPanel : UiPanelBase
	{
		// Token: 0x0603592E RID: 219438 RVA: 0x00D73800 File Offset: 0x00D71A00
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603592F RID: 219439 RVA: 0x00D7388C File Offset: 0x00D71A8C
		public void UpdateNum(int totalNum)
		{
			base.GetText(1).SetText(totalNum.ToString(), true);
			if (totalNum == 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Roguelike_Yuansu_Empty", Array.Empty<object>());
				return;
			}
			ElementLevel? elementLevelConfigById = ConfigBase<RoguelikeConfig>.Instance.GetElementLevelConfigById(4);
			if (elementLevelConfigById == null)
			{
				base.GetText(2).SetText("", true);
				return;
			}
			List<string> list = new List<string>();
			foreach (long p0Id in elementLevelConfigById.Value.AddBuffsIter())
			{
				Buff? config = ConfigBuffById.GetConfig(p0Id, true);
				if (config != null)
				{
					list.Add(((double)(config.Value.ModifierMagnitude(0) * totalNum) / 100.0).ToString("F1"));
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), elementLevelConfigById.Value.TextId, list.ToArray());
		}

		// Token: 0x0200B0EF RID: 45295
		private class ETipCom
		{
			// Token: 0x04036E1F RID: 224799
			public const int IconSprite = 0;

			// Token: 0x04036E20 RID: 224800
			public const int NumText = 1;

			// Token: 0x04036E21 RID: 224801
			public const int DescText = 2;
		}
	}
}
