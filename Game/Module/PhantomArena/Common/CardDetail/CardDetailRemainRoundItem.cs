using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005589 RID: 21897
	public class CardDetailRemainRoundItem : UiPanelBase
	{
		// Token: 0x06037C69 RID: 228457 RVA: 0x00E22BAC File Offset: 0x00E20DAC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06037C6A RID: 228458 RVA: 0x00E22BE5 File Offset: 0x00E20DE5
		[NullableContext(1)]
		public void Refresh(ICardDetailRemainRoundData data)
		{
		}

		// Token: 0x0200B526 RID: 46374
		private static class EComponentDefine
		{
			// Token: 0x04038130 RID: 229680
			public const int RootItem = 0;

			// Token: 0x04038131 RID: 229681
			public const int RemainRoundText = 1;
		}
	}
}
