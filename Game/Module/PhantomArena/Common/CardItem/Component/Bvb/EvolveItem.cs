using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component.Bvb
{
	// Token: 0x02005560 RID: 21856
	public class EvolveItem : UiPanelBase
	{
		// Token: 0x06037B5A RID: 228186 RVA: 0x00E2063C File Offset: 0x00E1E83C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem))
			};
		}

		// Token: 0x06037B5B RID: 228187 RVA: 0x00E2065F File Offset: 0x00E1E85F
		protected override void OnStart()
		{
			this.SetEffectActive(false);
		}

		// Token: 0x06037B5C RID: 228188 RVA: 0x00E20668 File Offset: 0x00E1E868
		public override void SetActive(bool value)
		{
			base.SetUiActive(value);
		}

		// Token: 0x06037B5D RID: 228189 RVA: 0x00E20671 File Offset: 0x00E1E871
		public void SetEffectActive(bool value)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(value);
		}

		// Token: 0x0200B4FB RID: 46331
		private static class EEffectItem
		{
			// Token: 0x0403806B RID: 229483
			public const int EffectItem = 0;
		}
	}
}
