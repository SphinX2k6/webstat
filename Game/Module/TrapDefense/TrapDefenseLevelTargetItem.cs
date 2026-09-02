using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E33 RID: 20019
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseLevelTargetItem : GridProxyAbstract<ITrapDefenseLevelTargetItemData>
	{
		// Token: 0x06033C00 RID: 211968 RVA: 0x00CEFBB8 File Offset: 0x00CEDDB8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033C01 RID: 211969 RVA: 0x00CEFC64 File Offset: 0x00CEDE64
		public override void Refresh(ITrapDefenseLevelTargetItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetText(data.TargetStar.ToString(), true);
			}
			UUITexture texture = base.GetTexture(1);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(data.Info.IconKey.ToString());
			base.SetTextureByPath(resourcePath, texture, null, null);
			UUIText text2 = base.GetText(2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, data.Info.NameKey.ToString(), new <>z__ReadOnlySingleElementList<object>(data.TargetValue));
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(data.IsFinish);
		}

		// Token: 0x0401DF42 RID: 122690
		public ITrapDefenseLevelTargetItemData ItemData;

		// Token: 0x0401DF43 RID: 122691
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<ITrapDefenseLevelTargetItemData> ClickCallBack;

		// Token: 0x0200ADBA RID: 44474
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035F27 RID: 220967
			public const int TextStarNum = 0;

			// Token: 0x04035F28 RID: 220968
			public const int TextureIcon = 1;

			// Token: 0x04035F29 RID: 220969
			public const int TextTargetDesc = 2;

			// Token: 0x04035F2A RID: 220970
			public const int ItemFinish = 3;
		}
	}
}
