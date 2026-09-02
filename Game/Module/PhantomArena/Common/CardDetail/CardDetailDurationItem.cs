using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x0200556E RID: 21870
	public class CardDetailDurationItem : UiPanelBase
	{
		// Token: 0x06037BCF RID: 228303 RVA: 0x00E21928 File Offset: 0x00E1FB28
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06037BD0 RID: 228304 RVA: 0x00E21961 File Offset: 0x00E1FB61
		[NullableContext(1)]
		public void Refresh(ICardDetailDurationData data)
		{
			if (!string.IsNullOrEmpty(data.Tips))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Tips, Array.Empty<object>());
			}
			base.GetText(1).SetText(data.DurationDesc, true);
		}

		// Token: 0x0200B519 RID: 46361
		private static class EComponentDefine
		{
			// Token: 0x040380F1 RID: 229617
			public const int TipsText = 0;

			// Token: 0x040380F2 RID: 229618
			public const int DurationText = 1;
		}
	}
}
