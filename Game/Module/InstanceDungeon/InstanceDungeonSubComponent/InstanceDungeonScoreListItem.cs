using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BF4 RID: 23540
	public class InstanceDungeonScoreListItem : UiPanelBase
	{
		// Token: 0x0603B936 RID: 244022 RVA: 0x00F1A090 File Offset: 0x00F18290
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B937 RID: 244023 RVA: 0x00F1A1E4 File Offset: 0x00F183E4
		[NullableContext(2)]
		public void RefreshItem(InstanceDungeonScoreListItemData data)
		{
			bool flag = data == null || string.IsNullOrEmpty(data.MedalPathId);
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(7);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			if (!flag)
			{
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), data.TitleTextId1, Array.Empty<object>());
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(3), data.TitleTextId2, Array.Empty<object>());
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(5), data.TitleTextId3, Array.Empty<object>());
				UUIText text2 = base.GetText(2);
				if (text2 != null)
				{
					text2.SetText(data.ScoreText1, true);
				}
				UUIText text3 = base.GetText(4);
				if (text3 != null)
				{
					text3.SetText(data.ScoreText2, true);
				}
				UUIText text4 = base.GetText(6);
				if (text4 != null)
				{
					text4.SetText(data.ScoreText3, true);
				}
				base.TrySetTextureByPath(data.MedalPathId, base.GetTexture(8), null, null);
			}
		}

		// Token: 0x0200BC6B RID: 48235
		private enum EComponent
		{
			// Token: 0x0403A18C RID: 237964
			FullRootItem,
			// Token: 0x0403A18D RID: 237965
			TitleText1,
			// Token: 0x0403A18E RID: 237966
			ScoreText1,
			// Token: 0x0403A18F RID: 237967
			TitleText2,
			// Token: 0x0403A190 RID: 237968
			ScoreText2,
			// Token: 0x0403A191 RID: 237969
			TitleText3,
			// Token: 0x0403A192 RID: 237970
			ScoreText3,
			// Token: 0x0403A193 RID: 237971
			EmptyRootItem,
			// Token: 0x0403A194 RID: 237972
			MedalTexture
		}
	}
}
