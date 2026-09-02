using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054C1 RID: 21697
	public class EntranceGymRepeatItem : GymItemBase
	{
		// Token: 0x0603743A RID: 226362 RVA: 0x00E05424 File Offset: 0x00E03624
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUITexture)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUISprite)),
				new ValueTuple<int, Type>(9, typeof(UUISprite)),
				new ValueTuple<int, Type>(10, typeof(UUISprite)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(base.OnClickLevel))
			};
		}

		// Token: 0x0603743B RID: 226363 RVA: 0x00E05581 File Offset: 0x00E03781
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			base.GetButton(0).FocusListenerDelegate.Bind(new Action(base.OnFocus));
		}

		// Token: 0x0603743C RID: 226364 RVA: 0x00E055B1 File Offset: 0x00E037B1
		protected override void OnBeforeShow()
		{
			UUIButtonComponent button = base.GetButton(0);
			button.OnPointEnterCallBack.Bind(new Action(base.OnHover));
			button.OnPointExitCallBack.Bind(new Action(base.OnUnHover));
			this.Refresh();
		}

		// Token: 0x0603743D RID: 226365 RVA: 0x00E055F0 File Offset: 0x00E037F0
		public override void Refresh()
		{
			if (this.Level < 0)
			{
				return;
			}
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			bool flag = instance.IsGymLock(this.Level, this.ActivityId) || !instance.IsGymUnlockChecked(this.Level, this.ActivityId);
			PhantomBattleGym? phantomBattleGymConfigByLevel = instance.GetPhantomBattleGymConfigByLevel(this.Level, this.ActivityId);
			base.GetSprite(4).SetUIActive(!flag);
			base.GetTexture(5).SetUIActive(flag);
			base.GetTexture(6).SetUIActive(!flag);
			base.GetSprite(7).SetUIActive(flag);
			base.GetSprite(8).SetUIActive(!flag);
			base.GetSprite(9).SetUIActive(flag);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), (phantomBattleGymConfigByLevel != null) ? phantomBattleGymConfigByLevel.GetValueOrDefault().Name : null, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(11), (phantomBattleGymConfigByLevel != null) ? phantomBattleGymConfigByLevel.GetValueOrDefault().Name : null, Array.Empty<object>());
			this.RefreshRedDot();
		}

		// Token: 0x0603743E RID: 226366 RVA: 0x00E0570E File Offset: 0x00E0390E
		public override void RefreshRedDot()
		{
			base.GetItem(12).SetUIActive(base.GetRedDotState());
		}

		// Token: 0x0200B429 RID: 46121
		private class EComponentRepeat
		{
			// Token: 0x04037C0C RID: 228364
			public const int BtnLevel = 0;

			// Token: 0x04037C0D RID: 228365
			public const int TextName = 1;

			// Token: 0x04037C0E RID: 228366
			public const int LayoutStar = 2;

			// Token: 0x04037C0F RID: 228367
			public const int ItemStar = 3;

			// Token: 0x04037C10 RID: 228368
			public const int SpriteBg = 4;

			// Token: 0x04037C11 RID: 228369
			public const int TextureBgLock = 5;

			// Token: 0x04037C12 RID: 228370
			public const int IconMain = 6;

			// Token: 0x04037C13 RID: 228371
			public const int SpriteLock = 7;

			// Token: 0x04037C14 RID: 228372
			public const int SpriteLight = 8;

			// Token: 0x04037C15 RID: 228373
			public const int SpriteGray = 9;

			// Token: 0x04037C16 RID: 228374
			public const int SpriteRoman = 10;

			// Token: 0x04037C17 RID: 228375
			public const int TextNameLock = 11;

			// Token: 0x04037C18 RID: 228376
			public const int ItemRedDot = 12;
		}
	}
}
