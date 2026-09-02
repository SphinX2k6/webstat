using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack.View
{
	// Token: 0x02005304 RID: 21252
	public class BattleQuickHackLongPressItem : UiPanelBase
	{
		// Token: 0x06036409 RID: 222217 RVA: 0x00DABF68 File Offset: 0x00DAA168
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603640A RID: 222218 RVA: 0x00DAC0B9 File Offset: 0x00DAA2B9
		protected override void OnBeforeShow()
		{
			this.UpdateProgress();
		}

		// Token: 0x0603640B RID: 222219 RVA: 0x00DAC0C1 File Offset: 0x00DAA2C1
		public void StartLongPress(float longPressTime)
		{
			this.CurrentPressTime = 0f;
			this.MaxLongPressTime = longPressTime;
			this.UpdateProgress();
		}

		// Token: 0x0603640C RID: 222220 RVA: 0x00DAC0DB File Offset: 0x00DAA2DB
		public void StopLongPress()
		{
			this.CurrentPressTime = 0f;
			this.MaxLongPressTime = 0f;
			this.UpdateProgress();
		}

		// Token: 0x0603640D RID: 222221 RVA: 0x00DAC0F9 File Offset: 0x00DAA2F9
		public void Update(float delta)
		{
			if (this.MaxLongPressTime > 0f)
			{
				this.CurrentPressTime += delta;
				this.UpdateProgress();
			}
		}

		// Token: 0x0603640E RID: 222222 RVA: 0x00DAC11C File Offset: 0x00DAA31C
		private void UpdateProgress()
		{
			float fillAmount = (this.MaxLongPressTime <= 0f) ? 0f : ((this.CurrentPressTime >= this.MaxLongPressTime) ? 1f : (this.CurrentPressTime / this.MaxLongPressTime));
			base.GetTexture(0).SetFillAmount(fillAmount);
		}

		// Token: 0x0401F306 RID: 127750
		public float CurrentPressTime;

		// Token: 0x0401F307 RID: 127751
		private float MaxLongPressTime;

		// Token: 0x0200B236 RID: 45622
		private class EComponentType
		{
			// Token: 0x040373DB RID: 226267
			public const int ProgressTextureA = 0;

			// Token: 0x040373DC RID: 226268
			public const int FlagItemA = 1;

			// Token: 0x040373DD RID: 226269
			public const int FlagItemB = 2;

			// Token: 0x040373DE RID: 226270
			public const int FlagNumB = 3;

			// Token: 0x040373DF RID: 226271
			public const int AniFlagSwitch = 4;

			// Token: 0x040373E0 RID: 226272
			public const int BarItemA = 5;

			// Token: 0x040373E1 RID: 226273
			public const int BarItemB = 6;

			// Token: 0x040373E2 RID: 226274
			public const int ProgressTextureB = 7;

			// Token: 0x040373E3 RID: 226275
			public const int FlagBg = 8;
		}
	}
}
