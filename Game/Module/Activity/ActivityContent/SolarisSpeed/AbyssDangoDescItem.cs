using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200638D RID: 25485
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class AbyssDangoDescItem : GridProxyAbstract<IAbyssDescData>
	{
		// Token: 0x0603FFF9 RID: 262137 RVA: 0x010670E4 File Offset: 0x010652E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603FFFA RID: 262138 RVA: 0x01067170 File Offset: 0x01065370
		[NullableContext(1)]
		public override void Refresh(IAbyssDescData data, bool isSelected, int gridIndex)
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(base.GridIndex % 2 == 0);
			}
			AbyssSettle? abyssSettleById = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssSettleById(data.Id);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), abyssSettleById.Value.BaseTitle, Array.Empty<object>());
			if (abyssSettleById.Value.IsTotalRatio)
			{
				UUIText text = base.GetText(2);
				if (text == null)
				{
					return;
				}
				text.SetText(data.Count.ToString() + "%", true);
				return;
			}
			else
			{
				UUIText text2 = base.GetText(2);
				if (text2 == null)
				{
					return;
				}
				text2.SetText(data.Count.ToString(), true);
				return;
			}
		}

		// Token: 0x0200C3E4 RID: 50148
		private enum EDescItem
		{
			// Token: 0x0403C56D RID: 247149
			Bg,
			// Token: 0x0403C56E RID: 247150
			Name,
			// Token: 0x0403C56F RID: 247151
			NumText
		}
	}
}
