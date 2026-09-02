using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054C0 RID: 21696
	public class EntranceGymItem : GymItemBase
	{
		// Token: 0x06037433 RID: 226355 RVA: 0x00E0503C File Offset: 0x00E0323C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUISprite)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUISprite)),
				new ValueTuple<int, Type>(9, typeof(UUISprite)),
				new ValueTuple<int, Type>(10, typeof(UUISprite)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(base.OnClickLevel))
			};
		}

		// Token: 0x06037434 RID: 226356 RVA: 0x00E0519C File Offset: 0x00E0339C
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.LayoutStar = new GenericLayout<GymStarItem, GymChallengeData>(base.GetHorizontalLayout(2), new Func<GymStarItem>(this.CreateStarItem), null, false, true);
			base.GetButton(0).SetSelectionState(EUISelectableSelectionState.Normal);
			base.GetButton(0).FocusListenerDelegate.Bind(new Action(base.OnFocus));
		}

		// Token: 0x06037435 RID: 226357 RVA: 0x00E05205 File Offset: 0x00E03405
		[NullableContext(1)]
		private GymStarItem CreateStarItem()
		{
			return new GymStarItem();
		}

		// Token: 0x06037436 RID: 226358 RVA: 0x00E0520C File Offset: 0x00E0340C
		protected override void OnBeforeShow()
		{
			UUIButtonComponent button = base.GetButton(0);
			button.OnPointEnterCallBack.Bind(new Action(base.OnHover));
			button.OnPointExitCallBack.Bind(new Action(base.OnUnHover));
			this.Refresh();
		}

		// Token: 0x06037437 RID: 226359 RVA: 0x00E05248 File Offset: 0x00E03448
		public override void Refresh()
		{
			if (this.Level < 0)
			{
				return;
			}
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			bool flag = instance.IsGymLock(this.Level, this.ActivityId) || !instance.IsGymUnlockChecked(this.Level, this.ActivityId);
			PhantomBattleGym? phantomBattleGymConfigByLevel = instance.GetPhantomBattleGymConfigByLevel(this.Level, this.ActivityId);
			if (phantomBattleGymConfigByLevel == null)
			{
				return;
			}
			base.GetSprite(4).SetUIActive(!flag);
			base.GetSprite(5).SetUIActive(flag);
			this.SetSpriteByPath(phantomBattleGymConfigByLevel.Value.IconBg, base.GetSprite(4), false, null, null);
			base.GetSprite(7).SetUIActive(flag);
			base.GetSprite(8).SetUIActive(!flag);
			base.GetSprite(9).SetUIActive(flag);
			base.GetItem(11).SetUIActive(!flag);
			string path = flag ? phantomBattleGymConfigByLevel.Value.IconLock : phantomBattleGymConfigByLevel.Value.Icon;
			this.SetSpriteByPath(path, base.GetSprite(6), false, null, null);
			this.SetSpriteByPath(phantomBattleGymConfigByLevel.Value.IconRoman, base.GetSprite(10), false, null, null);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), (phantomBattleGymConfigByLevel != null) ? phantomBattleGymConfigByLevel.GetValueOrDefault().Name : null, Array.Empty<object>());
			List<GymChallengeData> challengeStateListByGymLevel = instance.GetChallengeStateListByGymLevel(this.Level, this.ActivityId);
			this.LayoutStar.RefreshByData(challengeStateListByGymLevel, null, false);
			this.LayoutStar.SetActive(!flag);
			this.RefreshRedDot();
		}

		// Token: 0x06037438 RID: 226360 RVA: 0x00E05405 File Offset: 0x00E03605
		public override void RefreshRedDot()
		{
			base.GetItem(12).SetUIActive(base.GetRedDotState());
		}

		// Token: 0x0401FC47 RID: 130119
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<GymStarItem, GymChallengeData> LayoutStar;

		// Token: 0x0200B428 RID: 46120
		private class EComponent
		{
			// Token: 0x04037BFF RID: 228351
			public const int BtnLevel = 0;

			// Token: 0x04037C00 RID: 228352
			public const int TextName = 1;

			// Token: 0x04037C01 RID: 228353
			public const int LayoutStar = 2;

			// Token: 0x04037C02 RID: 228354
			public const int ItemStar = 3;

			// Token: 0x04037C03 RID: 228355
			public const int SpriteBg = 4;

			// Token: 0x04037C04 RID: 228356
			public const int SpriteBgLock = 5;

			// Token: 0x04037C05 RID: 228357
			public const int SpriteIcon = 6;

			// Token: 0x04037C06 RID: 228358
			public const int SpriteLock = 7;

			// Token: 0x04037C07 RID: 228359
			public const int SpriteLight = 8;

			// Token: 0x04037C08 RID: 228360
			public const int SpriteGray = 9;

			// Token: 0x04037C09 RID: 228361
			public const int SpriteRoman = 10;

			// Token: 0x04037C0A RID: 228362
			public const int PanelUnlock = 11;

			// Token: 0x04037C0B RID: 228363
			public const int ItemRedDot = 12;
		}
	}
}
