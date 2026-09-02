using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb
{
	// Token: 0x020055D1 RID: 21969
	public class PhantomArenaBattleDamageView : UiViewBase
	{
		// Token: 0x06037F85 RID: 229253 RVA: 0x00E2D296 File Offset: 0x00E2B496
		[NullableContext(1)]
		public PhantomArenaBattleDamageView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06037F86 RID: 229254 RVA: 0x00E2D2A0 File Offset: 0x00E2B4A0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIArtText)),
				new ValueTuple<int, Type>(1, typeof(UUIArtText)),
				new ValueTuple<int, Type>(2, typeof(UUIArtText))
			};
		}

		// Token: 0x06037F87 RID: 229255 RVA: 0x00E2D2FC File Offset: 0x00E2B4FC
		protected override void OnStart()
		{
			int? num = this.OpenParam as int?;
			if (num != null)
			{
				UUIArtText artText = base.GetArtText(0);
				if (artText != null)
				{
					artText.SetText(num.Value.ToString());
				}
				UUIArtText artText2 = base.GetArtText(1);
				if (artText2 != null)
				{
					artText2.SetText(num.Value.ToString());
				}
				UUIArtText artText3 = base.GetArtText(2);
				if (artText3 == null)
				{
					return;
				}
				artText3.SetText(num.Value.ToString());
			}
		}

		// Token: 0x0200B5C3 RID: 46531
		private class EComponentDefine
		{
			// Token: 0x040383E2 RID: 230370
			public const int ArtText1 = 0;

			// Token: 0x040383E3 RID: 230371
			public const int ArtText2 = 1;

			// Token: 0x040383E4 RID: 230372
			public const int ArtText3 = 2;
		}
	}
}
