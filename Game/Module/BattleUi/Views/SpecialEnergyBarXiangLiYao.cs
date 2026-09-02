using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060E8 RID: 24808
	public class SpecialEnergyBarXiangLiYao : SpecialEnergyBarMorph
	{
		// Token: 0x0603EABF RID: 256703 RVA: 0x0100AD74 File Offset: 0x01008F74
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			UNiagaraSystem valueOrDefault = this.NiagaraList.GetValueOrDefault(0);
			if (valueOrDefault != null)
			{
				SpecialEnergyBarSlot specialEnergyBarSlot = this.BarItem as SpecialEnergyBarSlot;
				specialEnergyBarSlot.ReplaceFullEffect(valueOrDefault);
				specialEnergyBarSlot.UpdateFullEffectOffsetBySlotWidth();
			}
		}

		// Token: 0x0603EAC0 RID: 256704 RVA: 0x0100ADAE File Offset: 0x01008FAE
		[NullableContext(1)]
		protected override Type GetSpecialEnergyBarClass()
		{
			return typeof(SpecialEnergyBarSlot);
		}
	}
}
