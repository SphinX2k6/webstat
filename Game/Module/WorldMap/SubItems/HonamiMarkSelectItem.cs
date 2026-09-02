using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubItems
{
	// Token: 0x02004BE8 RID: 19432
	public class HonamiMarkSelectItem : GridProxyAbstract<int>
	{
		// Token: 0x06032B50 RID: 207696 RVA: 0x00CB3A08 File Offset: 0x00CB1C08
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032B51 RID: 207697 RVA: 0x00CB3A74 File Offset: 0x00CB1C74
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.HonamiMarkId = data;
			HonamiStoryMapMark? honamiMapMarkById = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiMapMarkById(this.HonamiMarkId);
			if (honamiMapMarkById == null)
			{
				return;
			}
			base.GetText(1).ShowTextNew(honamiMapMarkById.Value.Name);
			this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(honamiMapMarkById.Value.IconResourceId), base.GetSprite(0), true, null, null);
		}

		// Token: 0x0401D849 RID: 120905
		private int HonamiMarkId;
	}
}
