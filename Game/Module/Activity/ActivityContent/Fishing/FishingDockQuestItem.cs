using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006810 RID: 26640
	public class FishingDockQuestItem : UiPanelBase
	{
		// Token: 0x06042665 RID: 271973 RVA: 0x01105144 File Offset: 0x01103344
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickQuestBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042666 RID: 271974 RVA: 0x0110524D File Offset: 0x0110344D
		protected override void OnStart()
		{
			this.QuestTargetItemLayout = new GenericLayout<FishingDockQuestChildItem, IFishingDockQuestChildItemData>(base.GetVerticalLayout(2), new Func<FishingDockQuestChildItem>(this.InitItem), null, false, true);
		}

		// Token: 0x06042667 RID: 271975 RVA: 0x01105270 File Offset: 0x01103470
		protected override void OnBeforeShow()
		{
			this.RefreshItem();
		}

		// Token: 0x06042668 RID: 271976 RVA: 0x01105278 File Offset: 0x01103478
		public void RefreshItem()
		{
			bool uiactive = false;
			foreach (KeyValuePair<int, EFishingEntrustState> keyValuePair in ModelBase<FishingQuestModel>.Instance.CurrentEntrusts)
			{
				int num;
				EFishingEntrustState efishingEntrustState;
				keyValuePair.Deconstruct(out num, out efishingEntrustState);
				int id = num;
				EFishingEntrustState efishingEntrustState2 = efishingEntrustState;
				FishingEntrust? fishingEntrust = ConfigBase<FishingConfig>.Instance.GetFishingEntrust(id);
				if (fishingEntrust != null)
				{
					if (fishingEntrust.Value.EntrustPool != 3 && efishingEntrustState2 == EFishingEntrustState.Deliverable)
					{
						uiactive = true;
						break;
					}
					AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(fishingEntrust.Value.AccessPath);
					int num2 = int.Parse(((accessPathConfig != null) ? accessPathConfig.GetValueOrDefault().Val3 : null) ?? "0");
					if (accessPathConfig != null && num2 != 0 && ModelBase<FishingModel>.Instance.GetTechNodeCanLevelUp(num2))
					{
						uiactive = true;
						break;
					}
				}
			}
			base.GetItem(4).SetUIActive(uiactive);
			int currentTraceEntrust = ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust;
			FishingEntrust? fishingEntrust2 = ConfigBase<FishingConfig>.Instance.GetFishingEntrust(ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust);
			if (fishingEntrust2 == null)
			{
				return;
			}
			if (fishingEntrust2.Value.EntrustType != 0 && fishingEntrust2.Value.EntrustType != 1)
			{
				if (fishingEntrust2.Value.EntrustType == 2)
				{
					base.GetVerticalLayout(2).RootUIComp.Get().SetUIActive(false);
				}
				return;
			}
			base.GetVerticalLayout(2).RootUIComp.Get().SetUIActive(true);
			Dictionary<int, int> dictionary = fishingEntrust2.Value.EntrustTarget();
			List<IFishingDockQuestChildItemData> list = new List<IFishingDockQuestChildItemData>();
			Dictionary<int, string> dictionary2 = fishingEntrust2.Value.TargetDesText();
			foreach (KeyValuePair<int, int> keyValuePair2 in dictionary)
			{
				int num;
				int num3;
				keyValuePair2.Deconstruct(out num, out num3);
				int num4 = num;
				int maxCount = num3;
				int itemCountByItemId = ModelBase<DockyardModel>.Instance.GetItemCountByItemId(num4);
				string text;
				FishingDockQuestChildItemData item = new FishingDockQuestChildItemData
				{
					MaxCount = maxCount,
					CurrentCount = itemCountByItemId,
					DesText = (dictionary2.TryGetValue(num4, out text) ? text : "")
				};
				list.Add(item);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), fishingEntrust2.Value.Name, Array.Empty<object>());
			GenericLayout<FishingDockQuestChildItem, IFishingDockQuestChildItemData> questTargetItemLayout = this.QuestTargetItemLayout;
			if (questTargetItemLayout == null)
			{
				return;
			}
			questTargetItemLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06042669 RID: 271977 RVA: 0x01105524 File Offset: 0x01103724
		private void OnClickQuestBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingQuestView, null, null);
		}

		// Token: 0x0604266A RID: 271978 RVA: 0x01105537 File Offset: 0x01103737
		[NullableContext(1)]
		private FishingDockQuestChildItem InitItem()
		{
			return new FishingDockQuestChildItem();
		}

		// Token: 0x04024F9E RID: 151454
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<FishingDockQuestChildItem, IFishingDockQuestChildItemData> QuestTargetItemLayout;

		// Token: 0x0200C841 RID: 51265
		private class EComponentDefine
		{
			// Token: 0x0403D9EA RID: 252394
			public const int TitleText = 0;

			// Token: 0x0403D9EB RID: 252395
			public const int QuestBtn = 1;

			// Token: 0x0403D9EC RID: 252396
			public const int QuestLayout = 2;

			// Token: 0x0403D9ED RID: 252397
			public const int QuestItem = 3;

			// Token: 0x0403D9EE RID: 252398
			public const int RedDotItem = 4;
		}
	}
}
