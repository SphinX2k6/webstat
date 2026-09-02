using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060D0 RID: 24784
	public class SpecialEnergyBarLuoselaSlotItem : SpecialEnergyBarSlotItem
	{
		// Token: 0x0603E98C RID: 256396 RVA: 0x01004698 File Offset: 0x01002898
		[NullableContext(2)]
		protected new UUINiagara GetUiNiagara(int itemType)
		{
			if (itemType == 3 && this.IsUlt)
			{
				itemType = 9;
			}
			return base.GetUiNiagara(itemType);
		}

		// Token: 0x0603E98D RID: 256397 RVA: 0x010046B1 File Offset: 0x010028B1
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(9, typeof(UUINiagara)));
		}

		// Token: 0x0603E98E RID: 256398 RVA: 0x010046D8 File Offset: 0x010028D8
		public void SetSlotItemUlt(bool ult, bool visible)
		{
			this.IsUlt = ult;
			if (this.State == 1)
			{
				base.GetUiNiagara(3).SetUIActive(!ult && visible);
				base.GetUiNiagara(9).SetUIActive(ult && visible);
				return;
			}
			base.GetUiNiagara(3).SetUIActive(false);
			base.GetUiNiagara(9).SetUIActive(false);
		}

		// Token: 0x0402319D RID: 143773
		private bool IsUlt;

		// Token: 0x0200C217 RID: 49687
		private class ESlotItemChildType
		{
			// Token: 0x0403BCF3 RID: 244979
			public const int FullEffectA = 3;

			// Token: 0x0403BCF4 RID: 244980
			public const int FullEffectB = 9;
		}
	}
}
