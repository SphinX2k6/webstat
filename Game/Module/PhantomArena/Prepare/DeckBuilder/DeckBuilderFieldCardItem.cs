using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardDetail;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x02005502 RID: 21762
	[NullableContext(1)]
	[Nullable(0)]
	public class DeckBuilderFieldCardItem : UiPanelBase
	{
		// Token: 0x0603779F RID: 227231 RVA: 0x00E113E0 File Offset: 0x00E0F5E0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUISprite))
			};
		}

		// Token: 0x060377A0 RID: 227232 RVA: 0x00E114D8 File Offset: 0x00E0F6D8
		protected override UniTask OnBeforeStartAsync()
		{
			DeckBuilderFieldCardItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DeckBuilderFieldCardItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060377A1 RID: 227233 RVA: 0x00E1151C File Offset: 0x00E0F71C
		public void RefreshItem(DeckInfo deckInfo, int? needPlayAddAnimCard = null)
		{
			DeckCardSlotInfo fieldCardSlot = deckInfo.GetFieldCardSlot();
			bool flag = fieldCardSlot != null;
			base.GetItem(7).SetUIActive(flag);
			base.GetItem(8).SetUIActive(!flag);
			if (!flag)
			{
				this.IsSkillActivate = false;
			}
			int value = (fieldCardSlot != null) ? fieldCardSlot.Count : 0;
			int fieldCardCountLimit = deckInfo.GetFieldCardCountLimit();
			UUIText text = base.GetText(2);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(fieldCardCountLimit);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			List<int> list = new List<int>();
			if (fieldCardSlot != null)
			{
				list.Add(fieldCardSlot.Element);
			}
			GenericLayout<CardElementItem, ECardElement> fieldElementLayout = this.FieldElementLayout;
			if (fieldElementLayout == null)
			{
				return;
			}
			fieldElementLayout.RefreshByData(list.Cast<ECardElement>().ToList<ECardElement>(), null, false);
		}

		// Token: 0x060377A2 RID: 227234 RVA: 0x00E115DE File Offset: 0x00E0F7DE
		public void RefreshSlotItem(IDeckBuilderCardSlotItemData data)
		{
			DeckBuilderCardSlotItem fieldSlotItem = this.FieldSlotItem;
			if (fieldSlotItem == null)
			{
				return;
			}
			fieldSlotItem.Refresh(data, false, 0);
		}

		// Token: 0x060377A3 RID: 227235 RVA: 0x00E115F4 File Offset: 0x00E0F7F4
		public void RefreshEffectUnlock(ICardDetailConditionOutData data)
		{
			bool flag = data.CurrentProgress >= data.MaxProgress;
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			string textStringId = flag ? "PhantomBattle_1163" : "PhantomBattle_1162";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), textStringId, new <>z__ReadOnlyArray<object>(new object[]
			{
				data.CurrentProgress,
				data.MaxProgress
			}));
			if (!string.IsNullOrEmpty(data.Icon))
			{
				this.SetSpriteByPath(data.Icon, base.GetSprite(10), false, null, null);
			}
			if (flag != this.IsSkillActivate)
			{
				this.OnFieldCardSkillActivated(flag);
				this.IsSkillActivate = flag;
			}
		}

		// Token: 0x060377A4 RID: 227236 RVA: 0x00E116C9 File Offset: 0x00E0F8C9
		protected override void OnBeforeDestroy()
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
		}

		// Token: 0x060377A5 RID: 227237 RVA: 0x00E116E0 File Offset: 0x00E0F8E0
		private void OnFieldCardSkillActivated(bool isActivate)
		{
			string sequenceName = isActivate ? "Activate" : "InActivate";
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
		}

		// Token: 0x060377A6 RID: 227238 RVA: 0x00E11719 File Offset: 0x00E0F919
		private CardElementItem CreateElementItem()
		{
			return new CardElementItem();
		}

		// Token: 0x0401FD53 RID: 130387
		private bool IsSkillActivate;

		// Token: 0x0401FD54 RID: 130388
		[Nullable(2)]
		public DeckBuilderCardSlotItem FieldSlotItem;

		// Token: 0x0401FD55 RID: 130389
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected GenericLayout<CardElementItem, ECardElement> FieldElementLayout;

		// Token: 0x0401FD56 RID: 130390
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401FD57 RID: 130391
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DeckBuilderCardSlotItem> OnEffectBtnClickCallback;

		// Token: 0x0200B479 RID: 46201
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037DE5 RID: 228837
			public const int LayoutElement = 0;

			// Token: 0x04037DE6 RID: 228838
			public const int ItemElement = 1;

			// Token: 0x04037DE7 RID: 228839
			public const int TextNum = 2;

			// Token: 0x04037DE8 RID: 228840
			public const int ItemCardSlot = 3;

			// Token: 0x04037DE9 RID: 228841
			public const int ItemEffect = 4;

			// Token: 0x04037DEA RID: 228842
			public const int ItemActivatePanel = 5;

			// Token: 0x04037DEB RID: 228843
			public const int ItemInactivatePanel = 6;

			// Token: 0x04037DEC RID: 228844
			public const int ItemCardPanel = 7;

			// Token: 0x04037DED RID: 228845
			public const int ItemNonePanel = 8;

			// Token: 0x04037DEE RID: 228846
			public const int TextEffectCondition = 9;

			// Token: 0x04037DEF RID: 228847
			public const int SpriteEffectCondition = 10;
		}
	}
}
