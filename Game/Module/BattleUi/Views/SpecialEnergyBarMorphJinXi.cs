using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060C1 RID: 24769
	public class SpecialEnergyBarMorphJinXi : SpecialEnergyBarMorph
	{
		// Token: 0x0603E8E9 RID: 256233 RVA: 0x00FFFC20 File Offset: 0x00FFDE20
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			if (this.NiagaraList.ElementAtOrDefault(0) != null)
			{
				((SpecialEnergyBarPointGraduate)this.BarItem).ReplaceFullEffect(this.NiagaraList[0]);
			}
		}

		// Token: 0x0603E8EA RID: 256234 RVA: 0x00FFFC54 File Offset: 0x00FFDE54
		protected override void OnStart()
		{
			base.OnStart();
			int num = this.Config.SlotNum - 1;
			for (int i = 0; i < num; i++)
			{
				((SpecialEnergyBarPointGraduate)this.BarItem).SetGraduateItemOffset(i, this.Config.ExtraFloatParams[i + 1]);
			}
		}

		// Token: 0x0603E8EB RID: 256235 RVA: 0x00FFFCA5 File Offset: 0x00FFDEA5
		[NullableContext(1)]
		protected override Type GetSpecialEnergyBarClass()
		{
			return typeof(SpecialEnergyBarPointGraduate);
		}
	}
}
