using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060FA RID: 24826
	public class SpecialEnergyBarMorphPlayUse : SpecialEnergyBarMorph
	{
		// Token: 0x0603EBA7 RID: 256935 RVA: 0x0100F550 File Offset: 0x0100D750
		[NullableContext(1)]
		protected override Type GetSpecialEnergyBarClass()
		{
			return typeof(SpecialEnergyBarSlotPlayUse);
		}
	}
}
