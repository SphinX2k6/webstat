using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200681C RID: 26652
	public class FishingHandBookTagItem : GridProxyAbstract<int>
	{
		// Token: 0x060426D0 RID: 272080 RVA: 0x01107D94 File Offset: 0x01105F94
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

		// Token: 0x060426D1 RID: 272081 RVA: 0x01107E00 File Offset: 0x01106000
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			FishingTag? fishingTagConfig = ConfigBase<FishingConfig>.Instance.GetFishingTagConfig(data);
			if (fishingTagConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), fishingTagConfig.Value.Name, Array.Empty<object>());
			FColor color = FColor.FromHex(fishingTagConfig.Value.Color);
			base.GetItem(1).SetColor(color);
		}

		// Token: 0x0200C854 RID: 51284
		private class EComponentDefine
		{
			// Token: 0x0403DA5A RID: 252506
			public const int TagNameText = 0;

			// Token: 0x0403DA5B RID: 252507
			public const int BgItem = 1;
		}
	}
}
