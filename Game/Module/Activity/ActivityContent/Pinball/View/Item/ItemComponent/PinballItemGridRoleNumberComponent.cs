using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent
{
	// Token: 0x02006621 RID: 26145
	public class PinballItemGridRoleNumberComponent : PinballItemGridComponentBase
	{
		// Token: 0x06041537 RID: 267575 RVA: 0x010C156C File Offset: 0x010BF76C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041538 RID: 267576 RVA: 0x010C15B4 File Offset: 0x010BF7B4
		[NullableContext(2)]
		protected override string OnGetResourceId()
		{
			return "UiItem_ItemBaseNum";
		}

		// Token: 0x06041539 RID: 267577 RVA: 0x010C15BC File Offset: 0x010BF7BC
		[NullableContext(1)]
		protected override void OnRefresh(params object[] args)
		{
			int num = (int)args[0];
			if (num <= 0)
			{
				this.SetActive(false);
				return;
			}
			this.SetActive(true);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ComItemNum0" + num.ToString());
			this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
		}

		// Token: 0x0200C64E RID: 50766
		private enum EComponent
		{
			// Token: 0x0403D0A8 RID: 250024
			NumberSprite
		}
	}
}
