using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005165 RID: 20837
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomInfoPanel : UiPanelBase
	{
		// Token: 0x060359F6 RID: 219638 RVA: 0x00D78254 File Offset: 0x00D76454
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.DetailBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060359F7 RID: 219639 RVA: 0x00D7839F File Offset: 0x00D7659F
		private void DetailBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguePhantomSelectResultView, new RogueSelectResult(this.RogueGainEntry, null, null, false), null);
		}

		// Token: 0x060359F8 RID: 219640 RVA: 0x00D783BF File Offset: 0x00D765BF
		protected override void OnStart()
		{
			this.PhantomEntryItemLayout = new GenericLayout<PhantomEntryItem, AffixEntry>(base.GetVerticalLayout(3), new Func<PhantomEntryItem>(this.CreatePhantomEntryItem), null, false, true);
		}

		// Token: 0x060359F9 RID: 219641 RVA: 0x00D783E2 File Offset: 0x00D765E2
		protected PhantomEntryItem CreatePhantomEntryItem()
		{
			return new PhantomEntryItem();
		}

		// Token: 0x060359FA RID: 219642 RVA: 0x00D783E9 File Offset: 0x00D765E9
		public void Update(RogueGainEntry rogueGainEntry)
		{
			this.RogueGainEntry = rogueGainEntry;
		}

		// Token: 0x060359FB RID: 219643 RVA: 0x00D783F2 File Offset: 0x00D765F2
		public void Refresh()
		{
			this.RefreshPhantom();
			this.RefreshPhantomEntryItemLayout();
		}

		// Token: 0x060359FC RID: 219644 RVA: 0x00D78400 File Offset: 0x00D76600
		[NullableContext(2)]
		public UUIItem GetAttributeItem(int index)
		{
			GenericLayout<PhantomEntryItem, AffixEntry> phantomEntryItemLayout = this.PhantomEntryItemLayout;
			if (phantomEntryItemLayout == null)
			{
				return null;
			}
			return phantomEntryItemLayout.GetItemByIndex(index);
		}

		// Token: 0x060359FD RID: 219645 RVA: 0x00D78414 File Offset: 0x00D76614
		private void RefreshPhantom()
		{
			RoguePokemon? roguePhantomConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguePhantomConfig(this.RogueGainEntry.ConfigId);
			if (roguePhantomConfig == null)
			{
				return;
			}
			base.GetText(2).ShowTextNew(roguePhantomConfig.Value.PokemonName);
			base.SetTextureByPath(roguePhantomConfig.Value.PokemonIcon, base.GetTexture(1), null, null);
			RogueQualityConfig? rogueQualityConfigByQualityId = ConfigBase<RoguelikeConfig>.Instance.GetRogueQualityConfigByQualityId(roguePhantomConfig.Value.Quality);
			if (rogueQualityConfigByQualityId != null)
			{
				base.SetTextureByPath(rogueQualityConfigByQualityId.Value.PhantomBgC, base.GetTexture(0), null, null);
				base.SetTextureByPath(rogueQualityConfigByQualityId.Value.PhantomBgB, base.GetTexture(6), null, null);
			}
		}

		// Token: 0x060359FE RID: 219646 RVA: 0x00D784F3 File Offset: 0x00D766F3
		private void RefreshPhantomEntryItemLayout()
		{
			this.PhantomEntryItemLayout.RefreshByData(this.RogueGainEntry.AffixEntryList ?? new List<AffixEntry>(), null, false);
		}

		// Token: 0x060359FF RID: 219647 RVA: 0x00D78518 File Offset: 0x00D76718
		[NullableContext(2)]
		public void RefreshPhantomEntryItemRefreshPreview(Dictionary<int, int> elementDict = null)
		{
			foreach (PhantomEntryItem phantomEntryItem in this.PhantomEntryItemLayout.GetLayoutItemList())
			{
				phantomEntryItem.RefreshPreview(elementDict);
			}
		}

		// Token: 0x0401ECBC RID: 126140
		private RogueGainEntry RogueGainEntry;

		// Token: 0x0401ECBD RID: 126141
		private GenericLayout<PhantomEntryItem, AffixEntry> PhantomEntryItemLayout;

		// Token: 0x0200B113 RID: 45331
		[NullableContext(0)]
		private class EPhantomInfoPanelCom
		{
			// Token: 0x04036ECD RID: 224973
			public const int QualityHeadTexture = 0;

			// Token: 0x04036ECE RID: 224974
			public const int HeadIconTexture = 1;

			// Token: 0x04036ECF RID: 224975
			public const int PhantomNameText = 2;

			// Token: 0x04036ED0 RID: 224976
			public const int PhantomAttrItemLayout = 3;

			// Token: 0x04036ED1 RID: 224977
			public const int PhantomAttrItem = 4;

			// Token: 0x04036ED2 RID: 224978
			public const int DetailBtn = 5;

			// Token: 0x04036ED3 RID: 224979
			public const int QualityHeadTextureB = 6;
		}
	}
}
