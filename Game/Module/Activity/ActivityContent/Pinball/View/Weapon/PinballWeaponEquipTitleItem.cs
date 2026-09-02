using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065A8 RID: 26024
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballWeaponEquipTitleItem : SyncGridProxyAbstract<IPinballWeaponEquipTitleItemData>
	{
		// Token: 0x06041042 RID: 266306 RVA: 0x010AE688 File Offset: 0x010AC888
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041043 RID: 266307 RVA: 0x010AE734 File Offset: 0x010AC934
		[NullableContext(1)]
		public override void Refresh(IPinballWeaponEquipTitleItemData data)
		{
			UUIText text = base.GetText(2);
			TableTextArgNew descTextData = data.DescTextData;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, descTextData.TextKey ?? "", descTextData.Params);
			this.SetSpriteByPath(data.TypeIconPath, base.GetSprite(1), false, null, null);
		}

		// Token: 0x0200C59F RID: 50591
		private enum EComponent
		{
			// Token: 0x0403CD29 RID: 249129
			BgSprite,
			// Token: 0x0403CD2A RID: 249130
			TypeIconSprite,
			// Token: 0x0403CD2B RID: 249131
			NameText,
			// Token: 0x0403CD2C RID: 249132
			StateIconSprite
		}
	}
}
