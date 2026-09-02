using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059EA RID: 23018
	public class StarItem : UiPanelBase
	{
		// Token: 0x0603A505 RID: 238853 RVA: 0x00EC898C File Offset: 0x00EC6B8C
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

		// Token: 0x0603A506 RID: 238854 RVA: 0x00EC89DF File Offset: 0x00EC6BDF
		public void SetState(bool isReached)
		{
			if (isReached)
			{
				base.GetSprite(0).SetUIActive(true);
				return;
			}
			base.GetSprite(0).SetUIActive(false);
		}

		// Token: 0x0200B9B8 RID: 47544
		private class EStarDefine
		{
			// Token: 0x04039630 RID: 235056
			public const int SprStar = 0;
		}
	}
}
