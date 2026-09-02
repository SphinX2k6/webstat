using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E16 RID: 24086
	public class StarItem : UiPanelBase
	{
		// Token: 0x0603C9A4 RID: 248228 RVA: 0x00F638CC File Offset: 0x00F61ACC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603C9A5 RID: 248229 RVA: 0x00F6391F File Offset: 0x00F61B1F
		public void SetState(bool isReached)
		{
			if (isReached)
			{
				base.GetSprite(0).SetUIActive(true);
				return;
			}
			base.GetSprite(0).SetUIActive(false);
		}

		// Token: 0x0200BE4D RID: 48717
		private enum EStarDefine
		{
			// Token: 0x0403A967 RID: 239975
			SprStar
		}
	}
}
