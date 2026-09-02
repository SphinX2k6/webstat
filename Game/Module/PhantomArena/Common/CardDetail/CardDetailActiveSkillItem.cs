using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005568 RID: 21864
	public class CardDetailActiveSkillItem : UiPanelBase
	{
		// Token: 0x06037BBA RID: 228282 RVA: 0x00E216D9 File Offset: 0x00E1F8D9
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06037BBB RID: 228283 RVA: 0x00E216FC File Offset: 0x00E1F8FC
		[NullableContext(1)]
		public void Refresh(ICardDetailActiveSkillData data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Desc, data.Params.ToArray());
		}

		// Token: 0x0200B517 RID: 46359
		private static class EComponentDefine
		{
			// Token: 0x040380ED RID: 229613
			public const int DescText = 0;
		}
	}
}
