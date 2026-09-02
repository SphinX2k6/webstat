using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006819 RID: 26649
	public class FishingHandBookItem : GridProxyAbstract<int>
	{
		// Token: 0x060426B7 RID: 272055 RVA: 0x01107358 File Offset: 0x01105558
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060426B8 RID: 272056 RVA: 0x01107484 File Offset: 0x01105684
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.ItemId = data;
			FishingItem? fishingItemConfig = ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(this.ItemId);
			if (fishingItemConfig == null)
			{
				return;
			}
			IFishingHandBook fishingHandBook;
			bool flag = !ModelBase<FishingModel>.Instance.FishingItemHandBookDataMap.TryGetValue(this.ItemId, out fishingHandBook);
			string text = flag ? ConfigMultiTextLang.GetLocalTextNew("FishingLockItemName", null) : ConfigMultiTextLang.GetLocalTextNew(fishingItemConfig.Value.Name, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Fishing_ArchiveTitle", new <>z__ReadOnlyArray<object>(new object[]
			{
				fishingItemConfig.Value.IllustratedNum.ToString(),
				text
			}));
			base.SetTextureByPath(fishingItemConfig.Value.Icon, base.GetTexture(4), null, null);
			this.SetTextureMaterialActive(!flag);
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			int quality = fishingItemConfig.Value.Quality;
			QualityInfo? qualityInfo;
			string path = (ConfigBase<ItemConfig>.Instance.GetQualityConfig(quality) != null) ? qualityInfo.GetValueOrDefault().BackgroundSprite : null;
			this.SetSpriteByPath(path, base.GetSprite(5), false, null, null);
			bool flag2 = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.FishingHandBookItemRecord, this.ItemId);
			if (!flag)
			{
				base.GetItem(3).SetUIActive(!flag2);
				return;
			}
			base.GetItem(3).SetUIActive(false);
		}

		// Token: 0x060426B9 RID: 272057 RVA: 0x0110760C File Offset: 0x0110580C
		public override void Clear()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.FinishGuideStepByEvent, "FishingHandBookItem");
		}

		// Token: 0x060426BA RID: 272058 RVA: 0x01107623 File Offset: 0x01105823
		private void OnClickToggle(EToggleState toggleState)
		{
			Action<int, UUIExtendToggle, int> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack == null)
			{
				return;
			}
			onClickToggleCallBack(this.ItemId, base.GetExtendToggle(0), base.GridIndex);
		}

		// Token: 0x060426BB RID: 272059 RVA: 0x01107648 File Offset: 0x01105848
		public override void OnSelected(bool fireEvent)
		{
			base.GetItem(3).SetUIActive(false);
			if (!fireEvent)
			{
				return;
			}
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, true, false, false);
		}

		// Token: 0x060426BC RID: 272060 RVA: 0x0110766C File Offset: 0x0110586C
		private void SetTextureMaterialActive(bool value)
		{
			if (value)
			{
				base.GetTexture(4).SetCustomMaterialScalarParameter(FishingDefine.materialProgressName, 1f);
				return;
			}
			base.GetTexture(4).SetCustomMaterialScalarParameter(FishingDefine.materialProgressName, 0f);
		}

		// Token: 0x04024FAC RID: 151468
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, UUIExtendToggle, int> OnClickToggleCallBack;

		// Token: 0x04024FAD RID: 151469
		private int ItemId;

		// Token: 0x0200C84E RID: 51278
		private class EComponentDefine
		{
			// Token: 0x0403DA40 RID: 252480
			public const int Toggle = 0;

			// Token: 0x0403DA41 RID: 252481
			public const int ItemSmallItem = 1;

			// Token: 0x0403DA42 RID: 252482
			public const int NameText = 2;

			// Token: 0x0403DA43 RID: 252483
			public const int NewItem = 3;

			// Token: 0x0403DA44 RID: 252484
			public const int FishItemTexture = 4;

			// Token: 0x0403DA45 RID: 252485
			public const int QualitySprite = 5;
		}
	}
}
