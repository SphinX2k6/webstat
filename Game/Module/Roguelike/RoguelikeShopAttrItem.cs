using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051A2 RID: 20898
	public class RoguelikeShopAttrItem : UiPanelBase
	{
		// Token: 0x06035BED RID: 220141 RVA: 0x00D83554 File Offset: 0x00D81754
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035BEE RID: 220142 RVA: 0x00D835C0 File Offset: 0x00D817C0
		[NullableContext(1)]
		public void Update(AffixEntry data)
		{
			RogueAffix? rogueAffixConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueAffixConfig(data.Id.Value);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), rogueAffixConfig.Value.AffixDesc, Array.Empty<object>());
			base.GetItem(1).SetUIActive(data.IsUnlock.Value);
		}

		// Token: 0x0200B175 RID: 45429
		private class ERoguelikeShopAttrItemDefine
		{
			// Token: 0x04037082 RID: 225410
			public const int TxtAttrDesc = 0;

			// Token: 0x04037083 RID: 225411
			public const int UnlockItem = 1;
		}
	}
}
