using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb
{
	// Token: 0x020055D3 RID: 21971
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleDetailsFieldItem : UiPanelBase
	{
		// Token: 0x06037F9F RID: 229279 RVA: 0x00E2D92C File Offset: 0x00E2BB2C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClick))
			};
		}

		// Token: 0x06037FA0 RID: 229280 RVA: 0x00E2D993 File Offset: 0x00E2BB93
		private void OnClick()
		{
		}

		// Token: 0x06037FA1 RID: 229281 RVA: 0x00E2D995 File Offset: 0x00E2BB95
		public void Refresh(PhantomArenaFieldData fieldData)
		{
		}

		// Token: 0x06037FA2 RID: 229282 RVA: 0x00E2D997 File Offset: 0x00E2BB97
		public void RegisterProxy(PhantomArenaBattleDetailsViewProxy proxy)
		{
			this.Proxy = proxy;
		}

		// Token: 0x0402001A RID: 131098
		protected PhantomArenaBattleDetailsViewProxy Proxy;

		// Token: 0x0200B5CB RID: 46539
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038405 RID: 230405
			public const int Icon = 0;

			// Token: 0x04038406 RID: 230406
			public const int Button = 1;
		}
	}
}
