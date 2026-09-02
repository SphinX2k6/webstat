using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x0200558C RID: 21900
	public class CardDetailTaskDescItem : UiPanelBase
	{
		// Token: 0x06037C75 RID: 228469 RVA: 0x00E22C19 File Offset: 0x00E20E19
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06037C76 RID: 228470 RVA: 0x00E22C3C File Offset: 0x00E20E3C
		[NullableContext(1)]
		public void Refresh(ICardDetailTaskData data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Desc, new <>z__ReadOnlySingleElementList<object>(data.CurrentProgress));
		}

		// Token: 0x0200B527 RID: 46375
		private static class EDescItemComponents
		{
			// Token: 0x04038132 RID: 229682
			public const int DescText = 0;
		}
	}
}
