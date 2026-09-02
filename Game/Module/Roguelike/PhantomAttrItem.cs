using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005162 RID: 20834
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomAttrItem : GridProxyAbstract<IPhantomAttrItemData>
	{
		// Token: 0x060359DC RID: 219612 RVA: 0x00D77765 File Offset: 0x00D75965
		public void Update(IPhantomAttrItemData data)
		{
			this.AffixEntry = data.AffixEntry;
			this.RoguelikeInfo = data.RoguelikeInfo;
			this.RefreshPanel();
		}

		// Token: 0x060359DD RID: 219613 RVA: 0x00D77788 File Offset: 0x00D75988
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060359DE RID: 219614 RVA: 0x00D778D9 File Offset: 0x00D75AD9
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x060359DF RID: 219615 RVA: 0x00D778EC File Offset: 0x00D75AEC
		private ElementItem CreateElementItem()
		{
			return new ElementItem();
		}

		// Token: 0x060359E0 RID: 219616 RVA: 0x00D778F3 File Offset: 0x00D75AF3
		public override void Refresh(IPhantomAttrItemData data, bool isSelected, int gridIndex)
		{
			this.Update(data);
		}

		// Token: 0x060359E1 RID: 219617 RVA: 0x00D778FC File Offset: 0x00D75AFC
		private void RefreshPanel()
		{
			this.RefreshUnlock();
			this.RefreshAttrText();
			this.RefreshLayout();
			this.RefreshElement();
		}

		// Token: 0x060359E2 RID: 219618 RVA: 0x00D77918 File Offset: 0x00D75B18
		private void RefreshUnlock()
		{
			bool isUnlock = this.RoguelikeInfo.GetIsUnlock(this.AffixEntry);
			base.GetSprite(3).SetUIActive(isUnlock);
			base.GetSprite(4).SetUIActive(!isUnlock);
		}

		// Token: 0x060359E3 RID: 219619 RVA: 0x00D77954 File Offset: 0x00D75B54
		private void RefreshAttrText()
		{
			RogueAffix? rogueAffixConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueAffixConfig(this.AffixEntry.Id.Value);
			if (rogueAffixConfig == null)
			{
				return;
			}
			bool descModel = ModelBase<RoguelikeModel>.Instance.GetDescModel() != EDescModel.SIMPLE;
			UUIText text = base.GetText(0);
			UUIText text2 = base.GetText(7);
			UUIItem uuiitem = text2;
			AffixEntry affixEntry = this.AffixEntry;
			uuiitem.SetColor((affixEntry != null && affixEntry.IsUnlock.GetValueOrDefault()) ? FColor.FromHex("BEFE58FF") : FColor.FromHex("ECE5D8FF"));
			UUIItem uuiitem2 = text;
			AffixEntry affixEntry2 = this.AffixEntry;
			uuiitem2.SetColor((affixEntry2 != null && affixEntry2.IsUnlock.GetValueOrDefault()) ? FColor.FromHex("BEFE58FF") : FColor.FromHex("ECE5D8FF"));
			if (!descModel)
			{
				text.ShowTextNew(rogueAffixConfig.Value.AffixDescSimple);
				text2.ShowTextNew(rogueAffixConfig.Value.AffixDescSimple);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, rogueAffixConfig.Value.AffixDesc, rogueAffixConfig.Value.AffixDescParam());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, rogueAffixConfig.Value.AffixDesc, rogueAffixConfig.Value.AffixDescParam());
		}

		// Token: 0x060359E4 RID: 219620 RVA: 0x00D77A8C File Offset: 0x00D75C8C
		private void RefreshLayout()
		{
			UUIText text = base.GetText(0);
			bool flag = text.GetTextRenderSize().X < text.Width;
			UUIItem parentAsUIItem = base.GetHorizontalLayout(1).GetRootComponent().GetParentAsUIItem();
			UUIItem item = base.GetItem(6);
			UUISizeControlByOther uuisizeControlByOther = base.GetItem(5).GetOwner().GetComponentByClass(UUISizeControlByOther.StaticClass()) as UUISizeControlByOther;
			AUIBaseActor targetActor = (flag ? parentAsUIItem.GetOwner() : item.GetOwner()) as AUIBaseActor;
			uuisizeControlByOther.SetTargetActor(targetActor);
			parentAsUIItem.SetUIActive(flag);
			item.SetUIActive(!flag);
			if (this.ElementLayout == null)
			{
				this.ElementLayout = new GenericLayout<ElementItem, ElementInfo>(base.GetHorizontalLayout(1), new Func<ElementItem>(this.CreateElementItem), null, false, true);
			}
			if (this.AdaptationElementLayout == null)
			{
				this.AdaptationElementLayout = new GenericLayout<ElementItem, ElementInfo>(base.GetHorizontalLayout(8), new Func<ElementItem>(this.CreateElementItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
			}
		}

		// Token: 0x060359E5 RID: 219621 RVA: 0x00D77B84 File Offset: 0x00D75D84
		private void RefreshElement()
		{
			List<ElementInfo> sortElementInfoArrayByCount = this.AffixEntry.GetSortElementInfoArrayByCount(false);
			GenericLayout<ElementItem, ElementInfo> elementLayout = this.ElementLayout;
			if (elementLayout != null)
			{
				elementLayout.RefreshByData(sortElementInfoArrayByCount, null, false);
			}
			GenericLayout<ElementItem, ElementInfo> adaptationElementLayout = this.AdaptationElementLayout;
			if (adaptationElementLayout == null)
			{
				return;
			}
			adaptationElementLayout.RefreshByData(sortElementInfoArrayByCount, null, false);
		}

		// Token: 0x060359E6 RID: 219622 RVA: 0x00D77BC8 File Offset: 0x00D75DC8
		public void PlayComplete()
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Complete", false, null, false);
		}

		// Token: 0x0401ECB1 RID: 126129
		public AffixEntry AffixEntry;

		// Token: 0x0401ECB2 RID: 126130
		private RoguelikeInfo RoguelikeInfo;

		// Token: 0x0401ECB3 RID: 126131
		private GenericLayout<ElementItem, ElementInfo> ElementLayout;

		// Token: 0x0401ECB4 RID: 126132
		private GenericLayout<ElementItem, ElementInfo> AdaptationElementLayout;

		// Token: 0x0401ECB5 RID: 126133
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200B10F RID: 45327
		[NullableContext(0)]
		private class EPhantomAttrItemCom
		{
			// Token: 0x04036EB8 RID: 224952
			public const int AttrText = 0;

			// Token: 0x04036EB9 RID: 224953
			public const int ElementsLayout = 1;

			// Token: 0x04036EBA RID: 224954
			public const int ElementItem = 2;

			// Token: 0x04036EBB RID: 224955
			public const int FinishSprite = 3;

			// Token: 0x04036EBC RID: 224956
			public const int NoSprite = 4;

			// Token: 0x04036EBD RID: 224957
			public const int BlackGroundItem = 5;

			// Token: 0x04036EBE RID: 224958
			public const int AdaptationParentItem = 6;

			// Token: 0x04036EBF RID: 224959
			public const int AdaptationAttrText = 7;

			// Token: 0x04036EC0 RID: 224960
			public const int AdaptationElementsLayout = 8;
		}
	}
}
