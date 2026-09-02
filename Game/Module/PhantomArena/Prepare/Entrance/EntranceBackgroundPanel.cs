using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054C3 RID: 21699
	public class EntranceBackgroundPanel : UiPanelBase
	{
		// Token: 0x06037467 RID: 226407 RVA: 0x00E062E8 File Offset: 0x00E044E8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUITexture))
			};
		}

		// Token: 0x06037468 RID: 226408 RVA: 0x00E06384 File Offset: 0x00E04584
		public void RefreshBg(bool isStart, int level)
		{
			string a = PhantomArenaDefine.positionGymLevel[level - 1];
			if (a == "left")
			{
				this.SetLeft(isStart);
				return;
			}
			if (a == "middle")
			{
				this.SetMiddle(isStart);
				return;
			}
			if (!(a == "right"))
			{
				return;
			}
			this.SetRight(isStart);
		}

		// Token: 0x06037469 RID: 226409 RVA: 0x00E063DC File Offset: 0x00E045DC
		[NullableContext(1)]
		private void SetTextureById(string resourceId, [Nullable(2)] UUITexture icon)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureByPath(resourcePath, icon, null, null);
		}

		// Token: 0x0603746A RID: 226410 RVA: 0x00E06408 File Offset: 0x00E04608
		public void SetLeft(bool isStart)
		{
			UUITexture icon = isStart ? base.GetTexture(3) : base.GetTexture(0);
			UUITexture icon2 = isStart ? base.GetTexture(4) : base.GetTexture(1);
			UUITexture icon3 = isStart ? base.GetTexture(5) : base.GetTexture(2);
			this.SetTextureById("GymTabViewTextureBgLeftColor", icon);
			this.SetTextureById("GymTabViewTextureBgMiddleWhite", icon2);
			this.SetTextureById("GymTabViewTextureBgRightGray", icon3);
		}

		// Token: 0x0603746B RID: 226411 RVA: 0x00E06478 File Offset: 0x00E04678
		public void SetMiddle(bool isStart)
		{
			UUITexture icon = isStart ? base.GetTexture(3) : base.GetTexture(0);
			UUITexture icon2 = isStart ? base.GetTexture(4) : base.GetTexture(1);
			UUITexture icon3 = isStart ? base.GetTexture(5) : base.GetTexture(2);
			this.SetTextureById("GymTabViewTextureBgLeftWhite", icon);
			this.SetTextureById("GymTabViewTextureBgMiddleColor", icon2);
			this.SetTextureById("GymTabViewTextureBgRightGray", icon3);
		}

		// Token: 0x0603746C RID: 226412 RVA: 0x00E064E8 File Offset: 0x00E046E8
		public void SetRight(bool isStart)
		{
			UUITexture icon = isStart ? base.GetTexture(3) : base.GetTexture(0);
			UUITexture icon2 = isStart ? base.GetTexture(4) : base.GetTexture(1);
			UUITexture icon3 = isStart ? base.GetTexture(5) : base.GetTexture(2);
			this.SetTextureById("GymTabViewTextureBgLeftGray", icon);
			this.SetTextureById("GymTabViewTextureBgMiddleWhite", icon2);
			this.SetTextureById("GymTabViewTextureBgRightColor", icon3);
		}

		// Token: 0x0200B42C RID: 46124
		private class EBgComponent
		{
			// Token: 0x04037C30 RID: 228400
			public const int IconLeftA = 0;

			// Token: 0x04037C31 RID: 228401
			public const int IconMiddleA = 1;

			// Token: 0x04037C32 RID: 228402
			public const int IconRightA = 2;

			// Token: 0x04037C33 RID: 228403
			public const int IconLeftB = 3;

			// Token: 0x04037C34 RID: 228404
			public const int IconMiddleB = 4;

			// Token: 0x04037C35 RID: 228405
			public const int IconRightB = 5;
		}
	}
}
