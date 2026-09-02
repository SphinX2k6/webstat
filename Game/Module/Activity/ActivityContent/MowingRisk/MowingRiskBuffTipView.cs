using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.GenericPrompt.View;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x020066A5 RID: 26277
	public class MowingRiskBuffTipView : GenericPromptFloatTipsBase
	{
		// Token: 0x060419F7 RID: 268791 RVA: 0x010D38C7 File Offset: 0x010D1AC7
		[NullableContext(1)]
		public MowingRiskBuffTipView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060419F8 RID: 268792 RVA: 0x010D38D0 File Offset: 0x010D1AD0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060419F9 RID: 268793 RVA: 0x010D393C File Offset: 0x010D1B3C
		protected override void OnStart()
		{
			IMowingRiskInBattleBuffData mowingRiskInBattleBuffData = this.OpenParam as IMowingRiskInBattleBuffData;
			base.SetTextureByPath(mowingRiskInBattleBuffData.IconPath, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), mowingRiskInBattleBuffData.TitleTextId, Array.Empty<object>());
		}

		// Token: 0x0200C6C8 RID: 50888
		private class EComponent
		{
			// Token: 0x0403D34D RID: 250701
			public const int IconTexture = 0;

			// Token: 0x0403D34E RID: 250702
			public const int TitleText = 1;
		}
	}
}
