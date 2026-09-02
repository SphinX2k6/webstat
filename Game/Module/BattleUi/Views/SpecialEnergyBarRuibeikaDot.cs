using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060DE RID: 24798
	public class SpecialEnergyBarRuibeikaDot : UiPanelBase
	{
		// Token: 0x0603EA32 RID: 256562 RVA: 0x01008277 File Offset: 0x01006477
		public SpecialEnergyBarRuibeikaDot(int mode = 0)
		{
			this.Mode = mode;
		}

		// Token: 0x0603EA33 RID: 256563 RVA: 0x01008294 File Offset: 0x01006494
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			if (this.Mode == 1)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
			}
		}

		// Token: 0x0603EA34 RID: 256564 RVA: 0x01008324 File Offset: 0x01006524
		protected override void OnStart()
		{
			base.OnStart();
			this.TweenAnimPlayer.InitTweenAnim(0, base.GetItem(0), false);
			this.TweenAnimPlayer.InitTweenAnim(1, base.GetItem(1), false);
			if (this.Mode == 1)
			{
				this.TweenAnimPlayer.InitTweenAnim(2, base.GetItem(2), false);
			}
		}

		// Token: 0x0603EA35 RID: 256565 RVA: 0x0100837C File Offset: 0x0100657C
		public void SetVisible(bool b, bool gun, bool force = false)
		{
			if (this.IsVisible == b && !force)
			{
				return;
			}
			if (b)
			{
				base.SetUiActive(true);
				if (this.Mode == 1)
				{
					this.TweenAnimPlayer.PlayTweenAnim(gun ? 0 : 2);
				}
				else
				{
					this.TweenAnimPlayer.PlayTweenAnim(0);
				}
			}
			else if (force)
			{
				base.SetUiActive(false);
			}
			else
			{
				this.TweenAnimPlayer.PlayTweenAnim(1);
			}
			this.IsVisible = b;
		}

		// Token: 0x0603EA36 RID: 256566 RVA: 0x010083EA File Offset: 0x010065EA
		public float GetAniUseDuration()
		{
			return this.TweenAnimPlayer.GetDuration(1);
		}

		// Token: 0x0402320C RID: 143884
		[Nullable(1)]
		private readonly BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();

		// Token: 0x0402320D RID: 143885
		public int Mode;

		// Token: 0x0402320E RID: 143886
		public int Index;

		// Token: 0x0402320F RID: 143887
		private bool IsVisible;

		// Token: 0x0200C239 RID: 49721
		private class EDotChildType
		{
			// Token: 0x0403BDCC RID: 245196
			public const int AniBrightG = 0;

			// Token: 0x0403BDCD RID: 245197
			public const int AniUse = 1;

			// Token: 0x0403BDCE RID: 245198
			public const int AniBrightR = 2;
		}
	}
}
