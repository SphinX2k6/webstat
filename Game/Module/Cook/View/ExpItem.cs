using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E1F RID: 24095
	public class ExpItem : UiPanelBase
	{
		// Token: 0x0603C9F8 RID: 248312 RVA: 0x00F6525E File Offset: 0x00F6345E
		[NullableContext(1)]
		public ExpItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C9F9 RID: 248313 RVA: 0x00F65274 File Offset: 0x00F63474
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C9FA RID: 248314 RVA: 0x00F65320 File Offset: 0x00F63520
		public void SetExpSprite(int last, int sum)
		{
			double num = Singleton<MathUtils>.Instance.GetFloatPointFloor((double)last / (double)sum, 3);
			num = ((num > 1.0) ? 1.0 : num);
			base.GetSprite(0).SetFillAmount((float)num);
		}

		// Token: 0x0603C9FB RID: 248315 RVA: 0x00F65365 File Offset: 0x00F63565
		public void SetAddText(int add)
		{
			base.GetText(1).SetText(add.ToString(), true);
		}

		// Token: 0x0603C9FC RID: 248316 RVA: 0x00F6537B File Offset: 0x00F6357B
		public void SetLastText(int last)
		{
			base.GetText(2).SetText(last.ToString(), true);
		}

		// Token: 0x0603C9FD RID: 248317 RVA: 0x00F65391 File Offset: 0x00F63591
		public void SetSumText(int sum)
		{
			base.GetText(3).SetText(sum.ToString(), true);
		}

		// Token: 0x0200BE53 RID: 48723
		private enum EExpItemDefine
		{
			// Token: 0x0403A98D RID: 240013
			ExpSprite,
			// Token: 0x0403A98E RID: 240014
			AddText,
			// Token: 0x0403A98F RID: 240015
			LastText,
			// Token: 0x0403A990 RID: 240016
			SumText
		}
	}
}
