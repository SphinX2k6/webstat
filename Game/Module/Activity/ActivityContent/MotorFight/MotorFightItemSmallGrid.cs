using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066D8 RID: 26328
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorFightItemSmallGrid : LoopScrollSmallItemGrid<MotorFightItemData>
	{
		// Token: 0x1700A094 RID: 41108
		// (get) Token: 0x06041BCF RID: 269263 RVA: 0x010DB9BD File Offset: 0x010D9BBD
		public new MotorFightItemData Data
		{
			get
			{
				return this.Data as MotorFightItemData;
			}
		}

		// Token: 0x06041BD0 RID: 269264 RVA: 0x010DB9CC File Offset: 0x010D9BCC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041BD1 RID: 269265 RVA: 0x010DBB38 File Offset: 0x010D9D38
		[NullableContext(1)]
		protected override void OnRefresh(MotorFightItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.SetSpriteByPath(ConfigBase<MotorFightConfig>.Instance.GetMotorFightQuality(data.Quality).Value.SmallGridBg, base.GetSprite(0), false, null, null);
			base.SetTextureByPath(data.Icon, base.GetTexture(1), null, null);
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetText(data.Count.ToString(), true);
			}
			base.SetLeftTopIconVisible(ConfigBase<MotorFightConfig>.Instance.GetMotorFightItemType(data.Type).Value.Icon);
		}

		// Token: 0x06041BD2 RID: 269266 RVA: 0x010DBBEC File Offset: 0x010D9DEC
		private void OnClickToggle(EToggleState _)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(7);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightItemTips, this.Data, null);
		}

		// Token: 0x0200C707 RID: 50951
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D45E RID: 250974
			public const int SpriteQuality = 0;

			// Token: 0x0403D45F RID: 250975
			public const int TextureIcon = 1;

			// Token: 0x0403D460 RID: 250976
			public const int ItemTextPanel = 2;

			// Token: 0x0403D461 RID: 250977
			public const int TextNum = 3;

			// Token: 0x0403D462 RID: 250978
			public const int SpriteBg = 4;

			// Token: 0x0403D463 RID: 250979
			public const int ItemBottomAddPanel = 5;

			// Token: 0x0403D464 RID: 250980
			public const int ItemAddPanel = 6;

			// Token: 0x0403D465 RID: 250981
			public const int ToggleRoot = 7;
		}
	}
}
