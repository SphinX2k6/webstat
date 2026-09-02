using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060CF RID: 24783
	public class SpecialEnergyBarLuoselaPoint : UiPanelBase
	{
		// Token: 0x0603E987 RID: 256391 RVA: 0x0100455C File Offset: 0x0100275C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E988 RID: 256392 RVA: 0x010045E6 File Offset: 0x010027E6
		protected override void OnStart()
		{
			base.OnStart();
			this.TweenAnimPlayer.InitTweenAnim(2, base.GetItem(2), false);
		}

		// Token: 0x0603E989 RID: 256393 RVA: 0x01004604 File Offset: 0x01002804
		public void SetVisible(bool b)
		{
			if (this.IsVisible == b)
			{
				return;
			}
			this.IsVisible = b;
			this.SetActive(b);
			if (b)
			{
				this.TweenAnimPlayer.PlayTweenAnim(2);
				base.GetItem(0).SetUIActive(!this.IsUlt);
				base.GetItem(1).SetUIActive(this.IsUlt);
			}
		}

		// Token: 0x0603E98A RID: 256394 RVA: 0x0100465F File Offset: 0x0100285F
		public void SetUlt(bool b)
		{
			this.IsUlt = b;
			base.GetItem(0).SetUIActive(!b);
			base.GetItem(1).SetUIActive(b);
		}

		// Token: 0x0402319A RID: 143770
		[Nullable(1)]
		private readonly BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();

		// Token: 0x0402319B RID: 143771
		private bool IsVisible;

		// Token: 0x0402319C RID: 143772
		private bool IsUlt;

		// Token: 0x0200C216 RID: 49686
		private class EPointChildType
		{
			// Token: 0x0403BCF0 RID: 244976
			public const int PnlNor = 0;

			// Token: 0x0403BCF1 RID: 244977
			public const int PnlUlt = 1;

			// Token: 0x0403BCF2 RID: 244978
			public const int AniIn = 2;
		}
	}
}
