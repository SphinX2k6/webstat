using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200638F RID: 25487
	internal class AbyssDangoLikeCountItem : UiPanelBase
	{
		// Token: 0x06040002 RID: 262146 RVA: 0x010673C8 File Offset: 0x010655C8
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

		// Token: 0x06040003 RID: 262147 RVA: 0x01067410 File Offset: 0x01065610
		public void Refresh(int data)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText(data.ToString(), true);
		}

		// Token: 0x0200C3E7 RID: 50151
		private enum ELikeCountItem
		{
			// Token: 0x0403C579 RID: 247161
			LikeCount
		}
	}
}
