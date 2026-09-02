using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060AF RID: 24751
	public class SpecialEnergyBarBuLanTeStarItem : UiPanelBase
	{
		// Token: 0x0603E7EF RID: 255983 RVA: 0x00FF9C7C File Offset: 0x00FF7E7C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E7F0 RID: 255984 RVA: 0x00FF9D06 File Offset: 0x00FF7F06
		public void SetIsEmpty(bool isEmpty)
		{
			UUITexture texture = base.GetTexture(0);
			if (texture != null)
			{
				texture.SetUIActive(isEmpty);
			}
			UUITexture texture2 = base.GetTexture(1);
			if (texture2 == null)
			{
				return;
			}
			texture2.SetUIActive(!isEmpty);
		}

		// Token: 0x0603E7F1 RID: 255985 RVA: 0x00FF9D30 File Offset: 0x00FF7F30
		public void SetStarEnable(bool isEnable)
		{
			UUITexture texture = base.GetTexture(2);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(isEnable);
		}

		// Token: 0x0200C1D1 RID: 49617
		private enum EChildType
		{
			// Token: 0x0403BAE4 RID: 244452
			StarBgTexture1,
			// Token: 0x0403BAE5 RID: 244453
			StarBgTexture2,
			// Token: 0x0403BAE6 RID: 244454
			StarTexture
		}
	}
}
