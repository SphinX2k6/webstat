using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll.View
{
	// Token: 0x02006F62 RID: 28514
	public class BigStuffedDollTipItem : UiPanelBase
	{
		// Token: 0x06045048 RID: 282696 RVA: 0x011F78B8 File Offset: 0x011F5AB8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06045049 RID: 282697 RVA: 0x011F7900 File Offset: 0x011F5B00
		[NullableContext(1)]
		public void ShowTips(string key, int stayTime)
		{
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, key, Array.Empty<object>());
			base.ShowAsync();
			TimerSystem.Instance.Delay(delegate(float _)
			{
				base.HideAsync();
			}, (float)stayTime, null, null, true, 1f);
		}

		// Token: 0x0200CBF8 RID: 52216
		private class EViewComponent
		{
			// Token: 0x0403E8C1 RID: 256193
			public const int TextTip = 0;
		}
	}
}
