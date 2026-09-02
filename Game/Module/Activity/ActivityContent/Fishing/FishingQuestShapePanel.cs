using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006822 RID: 26658
	public class FishingQuestShapePanel : UiPanelBase
	{
		// Token: 0x06042772 RID: 272242 RVA: 0x0110D188 File Offset: 0x0110B388
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042773 RID: 272243 RVA: 0x0110D254 File Offset: 0x0110B454
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(1);
			this.GirdWidth = item.Width;
			this.GirdHeight = item.Height;
			this.InitialGirdOffsetX = item.GetAnchorOffsetX();
			this.InitialGirdOffsetY = item.GetAnchorOffsetY();
			item.SetUIActive(false);
		}

		// Token: 0x06042774 RID: 272244 RVA: 0x0110D2A0 File Offset: 0x0110B4A0
		public void RefreshPanel(int itemId, bool isUnlock = true)
		{
			FishingItem? fishingItemConfig = ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(itemId);
			IntArray[] array = ConfigBase<FishingConfig>.Instance.GetFishingShapeConfig(fishingItemConfig.Value.Shap).FillState();
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			for (int i = 0; i < array.Length; i++)
			{
				IntArray intArray = array[i];
				for (int j = 0; j < intArray.ArrayIntLength; j++)
				{
					if (intArray.ArrayInt(j) == 1)
					{
						num = ((num == -1) ? i : Math.Min(num, i));
						num2 = ((num2 == -1) ? i : Math.Max(num2, i));
						num3 = ((num3 == -1) ? j : Math.Min(num3, j));
						num4 = ((num4 == -1) ? j : Math.Max(num4, j));
					}
				}
			}
			List<FishingQuestShapePanelItem> girdList = this.GirdList;
			foreach (FishingQuestShapePanelItem fishingQuestShapePanelItem in girdList)
			{
				fishingQuestShapePanelItem.SetUiActive(false);
			}
			this.RefreshAllGird(array.ToList<IntArray>(), num, num3);
			float width = (float)(num4 - num3 + 1) * this.GirdWidth;
			float height = (float)(num2 - num + 1) * this.GirdHeight;
			UUITexture texture = base.GetTexture(2);
			texture.SetWidth(width);
			texture.SetHeight(height);
			UUIItem item = base.GetItem(0);
			item.SetWidth(width);
			item.SetHeight(height);
			string sprite = fishingItemConfig.Value.Sprite;
			foreach (FishingQuestShapePanelItem fishingQuestShapePanelItem2 in girdList)
			{
				fishingQuestShapePanelItem2.SetGirdSprite(fishingItemConfig.Value.Category, sprite);
			}
			base.SetTextureByPath(fishingItemConfig.Value.Pic, texture, null, null);
			this.SetTextureMaterialActive(isUnlock);
			base.GetItem(3).SetUIActive(!isUnlock);
			base.GetItem(4).useChangeColor = isUnlock;
		}

		// Token: 0x06042775 RID: 272245 RVA: 0x0110D4C8 File Offset: 0x0110B6C8
		private void SetTextureMaterialActive(bool value)
		{
			if (value)
			{
				base.GetTexture(2).SetCustomMaterialScalarParameter(FishingDefine.materialProgressName, 1f);
				return;
			}
			base.GetTexture(2).SetCustomMaterialScalarParameter(FishingDefine.materialProgressName, 0f);
		}

		// Token: 0x06042776 RID: 272246 RVA: 0x0110D4FC File Offset: 0x0110B6FC
		[NullableContext(1)]
		private void RefreshAllGird(List<IntArray> targetList, int minValidRow, int minValidCol)
		{
			int num = 0;
			for (int i = 0; i < targetList.Count; i++)
			{
				IntArray intArray = targetList[i];
				for (int j = 0; j < intArray.ArrayIntLength; j++)
				{
					if (intArray.ArrayInt(j) == 1)
					{
						this.SetShapePanelItem(num++, i - minValidRow, j - minValidCol);
					}
				}
			}
		}

		// Token: 0x06042777 RID: 272247 RVA: 0x0110D554 File Offset: 0x0110B754
		private void SetShapePanelItem(int index, int rowIndex, int columnIndex)
		{
			float anchorOffsetX = this.InitialGirdOffsetX + (float)columnIndex * this.GirdWidth;
			float anchorOffsetY = this.InitialGirdOffsetY - (float)rowIndex * this.GirdHeight;
			FishingQuestShapePanelItem fishingQuestShapePanelItem;
			if (this.GirdList.Count > index)
			{
				fishingQuestShapePanelItem = this.GirdList[index];
				fishingQuestShapePanelItem.SetUiActive(true);
			}
			else
			{
				UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(1), base.GetItem(0));
				fishingQuestShapePanelItem = new FishingQuestShapePanelItem();
				fishingQuestShapePanelItem.CreateThenShowByActorAsync(uuiitem.GetOwner());
				this.GirdList.Add(fishingQuestShapePanelItem);
			}
			fishingQuestShapePanelItem.GetRootItem().SetAnchorOffsetX(anchorOffsetX);
			fishingQuestShapePanelItem.GetRootItem().SetAnchorOffsetY(anchorOffsetY);
		}

		// Token: 0x04024FF6 RID: 151542
		private float GirdWidth;

		// Token: 0x04024FF7 RID: 151543
		private float GirdHeight;

		// Token: 0x04024FF8 RID: 151544
		private float InitialGirdOffsetX;

		// Token: 0x04024FF9 RID: 151545
		private float InitialGirdOffsetY;

		// Token: 0x04024FFA RID: 151546
		[Nullable(1)]
		private readonly List<FishingQuestShapePanelItem> GirdList = new List<FishingQuestShapePanelItem>();

		// Token: 0x0200C85D RID: 51293
		private class EComponentDefine
		{
			// Token: 0x0403DA96 RID: 252566
			public const int GirdListItem = 0;

			// Token: 0x0403DA97 RID: 252567
			public const int GirdItem = 1;

			// Token: 0x0403DA98 RID: 252568
			public const int FishingIconTexture = 2;

			// Token: 0x0403DA99 RID: 252569
			public const int LockItem = 3;

			// Token: 0x0403DA9A RID: 252570
			public const int ColorItem = 4;
		}
	}
}
