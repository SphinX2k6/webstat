using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EE4 RID: 20196
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseSettleRecordPanel : UiPanelBase
	{
		// Token: 0x0603429B RID: 213659 RVA: 0x00D0B354 File Offset: 0x00D09554
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

		// Token: 0x0603429C RID: 213660 RVA: 0x00D0B3DE File Offset: 0x00D095DE
		public void SetTitleById(string textId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, Array.Empty<object>());
		}

		// Token: 0x0603429D RID: 213661 RVA: 0x00D0B3F7 File Offset: 0x00D095F7
		public void SetTitleOnly(string textId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, Array.Empty<object>());
			base.GetText(1).SetUIActive(false);
			base.GetItem(2).SetUIActive(false);
		}

		// Token: 0x0603429E RID: 213662 RVA: 0x00D0B42A File Offset: 0x00D0962A
		public void SetRecord(string record, bool isNewRecord)
		{
			base.GetText(1).SetText(record, true);
			base.GetItem(2).SetUIActive(isNewRecord);
		}

		// Token: 0x0603429F RID: 213663 RVA: 0x00D0B447 File Offset: 0x00D09647
		public void SetRecordRolling(int record, bool isNewRecord)
		{
			base.GetText(1).SetText(record.ToString(), true);
			base.GetItem(2).SetUIActive(isNewRecord);
		}

		// Token: 0x0200AE9D RID: 44701
		[NullableContext(0)]
		private class ERecordComponent
		{
			// Token: 0x0403636B RID: 222059
			public const int TitleTxt = 0;

			// Token: 0x0403636C RID: 222060
			public const int NumTxt = 1;

			// Token: 0x0403636D RID: 222061
			public const int NewRecordItem = 2;
		}
	}
}
