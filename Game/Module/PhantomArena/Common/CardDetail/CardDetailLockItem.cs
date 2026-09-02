using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x0200557B RID: 21883
	public class CardDetailLockItem : UiPanelBase
	{
		// Token: 0x06037C18 RID: 228376 RVA: 0x00E22692 File Offset: 0x00E20892
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06037C19 RID: 228377 RVA: 0x00E226B5 File Offset: 0x00E208B5
		[NullableContext(1)]
		public void Refresh(ICardDetailLockData data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Desc, new <>z__ReadOnlySingleElementList<object>(data.RemainRound));
		}

		// Token: 0x0200B524 RID: 46372
		private static class EComponentDefine
		{
			// Token: 0x04038127 RID: 229671
			public const int LockText = 0;
		}
	}
}
