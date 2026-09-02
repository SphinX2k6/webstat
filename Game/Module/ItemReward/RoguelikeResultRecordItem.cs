using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B58 RID: 23384
	internal class RoguelikeResultRecordItem : UiPanelBase
	{
		// Token: 0x0603B28A RID: 242314 RVA: 0x00EF814C File Offset: 0x00EF634C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B28B RID: 242315 RVA: 0x00EF81D6 File Offset: 0x00EF63D6
		[NullableContext(1)]
		public void Refresh(IRoguelikeBossChallengeData data)
		{
			base.GetText(1).SetText(Singleton<TimeUtil>.Instance.GetTimeString((double)data.PassTime), true);
			base.GetItem(2).SetUIActive(data.IsNewRecord);
		}

		// Token: 0x0200BB5E RID: 47966
		private class ERoguelikeResultRecordComponent
		{
			// Token: 0x04039D11 RID: 236817
			public const int TxtTitle = 0;

			// Token: 0x04039D12 RID: 236818
			public const int TxtNum = 1;

			// Token: 0x04039D13 RID: 236819
			public const int NewTagItem = 2;
		}
	}
}
