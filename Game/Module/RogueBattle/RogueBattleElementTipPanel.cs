using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051C9 RID: 20937
	public class RogueBattleElementTipPanel : UiPanelBase
	{
		// Token: 0x06035D0F RID: 220431 RVA: 0x00D8A098 File Offset: 0x00D88298
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x06035D10 RID: 220432 RVA: 0x00D8A0F4 File Offset: 0x00D882F4
		protected override void OnBeforeShow()
		{
			int totalElementCount = ModelBase<RogueBattleModel>.Instance.GetTotalElementCount();
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(totalElementCount);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			if (totalElementCount == 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Roguelike_Yuansu_Empty", Array.Empty<object>());
				return;
			}
			ResElementLevelGain? elementLevelGain = ConfigBase<RogueBattleConfig>.Instance.GetElementLevelGain(4);
			if (elementLevelGain == null)
			{
				base.GetText(2).SetText(string.Empty, true);
				return;
			}
			int num = 0;
			foreach (long p0Id in elementLevelGain.Value.AddBuffsIter())
			{
				Buff? config = ConfigBuffById.GetConfig(p0Id, true);
				if (config != null)
				{
					num += config.Value.ModifierMagnitude(0) * totalElementCount / 100;
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), elementLevelGain.Value.TextId, new <>z__ReadOnlySingleElementList<object>(num));
		}
	}
}
