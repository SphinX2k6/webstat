using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B5C RID: 23388
	public class RewardExploreScoreSubTitleItem : UiPanelBase
	{
		// Token: 0x0603B2A0 RID: 242336 RVA: 0x00EF8814 File Offset: 0x00EF6A14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B2A1 RID: 242337 RVA: 0x00EF887D File Offset: 0x00EF6A7D
		[NullableContext(1)]
		public void RefreshText(IRewardExploreScoreBelongHalfAreaItem data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.DescriptionTextId, Array.Empty<object>());
			base.GetText(1).SetText(data.Target, true);
		}

		// Token: 0x0200BB68 RID: 47976
		private class EChildType
		{
			// Token: 0x04039D33 RID: 236851
			public const int DesText = 0;

			// Token: 0x04039D34 RID: 236852
			public const int NumText = 1;
		}
	}
}
