using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200604E RID: 24654
	public class FishingEntrustNavigationItem : UiPanelBase
	{
		// Token: 0x0603E31F RID: 254751 RVA: 0x00FE1558 File Offset: 0x00FDF758
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			ref ValueTuple<int, Delegate> ptr = ref span2[num];
			int item = 0;
			Action item2;
			if ((item2 = FishingEntrustNavigationItem.<>O.<0>__OnViewButtonClick) == null)
			{
				item2 = (FishingEntrustNavigationItem.<>O.<0>__OnViewButtonClick = new Action(FishingEntrustNavigationItem.OnViewButtonClick));
			}
			ptr = new ValueTuple<int, Delegate>(item, item2);
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603E320 RID: 254752 RVA: 0x00FE15EC File Offset: 0x00FDF7EC
		private static void OnViewButtonClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingQuestView, null, null);
		}

		// Token: 0x0200C111 RID: 49425
		private enum EViewComponent
		{
			// Token: 0x0403B741 RID: 243521
			ViewButton
		}

		// Token: 0x0200C112 RID: 49426
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403B742 RID: 243522
			public static Action <0>__OnViewButtonClick;
		}
	}
}
