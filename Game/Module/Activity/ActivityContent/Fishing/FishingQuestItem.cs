using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006820 RID: 26656
	public class FishingQuestItem : GridProxyAbstract<int>
	{
		// Token: 0x06042758 RID: 272216 RVA: 0x0110C398 File Offset: 0x0110A598
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042759 RID: 272217 RVA: 0x0110C4A6 File Offset: 0x0110A6A6
		protected override void OnStart()
		{
			this.TaskLayout = new GenericLayout<FishingQuestItemChildItem, int>(base.GetVerticalLayout(1), new Func<FishingQuestItemChildItem>(this.InitItem), null, false, true);
		}

		// Token: 0x0604275A RID: 272218 RVA: 0x0110C4CC File Offset: 0x0110A6CC
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			FishingEntrustPool fishingEntrustPoolById = ConfigBase<FishingConfig>.Instance.GetFishingEntrustPoolById(data);
			this.SetSpriteByPath(fishingEntrustPoolById.TitleSprite, base.GetSprite(3), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), fishingEntrustPoolById.TitleName, Array.Empty<object>());
			this.TaskList = ModelBase<FishingQuestModel>.Instance.GetEntrustsByPoolType(data);
			this.TaskList.Sort(delegate(int a, int b)
			{
				FishingEntrust? fishingEntrust = ConfigBase<FishingConfig>.Instance.GetFishingEntrust(a);
				FishingEntrust? fishingEntrust2 = ConfigBase<FishingConfig>.Instance.GetFishingEntrust(b);
				if (fishingEntrust == null && fishingEntrust2 == null)
				{
					return 0;
				}
				if (fishingEntrust == null)
				{
					return 1;
				}
				if (fishingEntrust2 == null)
				{
					return -1;
				}
				return fishingEntrust2.Value.Star - fishingEntrust.Value.Star;
			});
			if (data == 4)
			{
				int techNodeCurrentLevel = ModelBase<FishingModel>.Instance.GetTechNodeCurrentLevel(ModelBase<FishingModel>.Instance.FishingSlotCountTech);
				int techNodeMaxLevel = ModelBase<FishingModel>.Instance.GetTechNodeMaxLevel(ModelBase<FishingModel>.Instance.FishingSlotCountTech);
				if (techNodeCurrentLevel < techNodeMaxLevel)
				{
					this.TaskList.Add(-1);
				}
			}
			this.TaskLayout.RefreshByData(this.TaskList, delegate
			{
				if (this.ScrollToHandle < 0)
				{
					return;
				}
				FishingQuestItemChildItem layoutItemByIndex = this.TaskLayout.GetLayoutItemByIndex(this.ScrollToHandle);
				if (layoutItemByIndex != null)
				{
					layoutItemByIndex.SelectToggle();
				}
				this.ScrollToHandle = -1;
			}, false);
			base.GetItem(6).SetColor(FColor.FromHex(FishingDefine.fishingQuestPoolColorText[data]));
		}

		// Token: 0x0604275B RID: 272219 RVA: 0x0110C5D4 File Offset: 0x0110A7D4
		public void SelectFirstItem(int target = 0)
		{
			FishingQuestItemChildItem layoutItemByIndex = this.TaskLayout.GetLayoutItemByIndex(target);
			if (layoutItemByIndex == null)
			{
				this.ScrollToHandle = target;
				return;
			}
			layoutItemByIndex.SelectToggle();
		}

		// Token: 0x0604275C RID: 272220 RVA: 0x0110C5FF File Offset: 0x0110A7FF
		public int HaveTargetTask(int target)
		{
			return this.TaskList.IndexOf(target);
		}

		// Token: 0x0604275D RID: 272221 RVA: 0x0110C60D File Offset: 0x0110A80D
		[NullableContext(1)]
		private FishingQuestItemChildItem InitItem()
		{
			return new FishingQuestItemChildItem
			{
				OnClickTaskCallBack = this.OnClickTaskCallBack
			};
		}

		// Token: 0x0604275E RID: 272222 RVA: 0x0110C620 File Offset: 0x0110A820
		public void RefreshChildItemStateAbout()
		{
			GenericLayout<FishingQuestItemChildItem, int> taskLayout = this.TaskLayout;
			List<FishingQuestItemChildItem> list = (taskLayout != null) ? taskLayout.GetLayoutItemList() : null;
			if (list == null)
			{
				return;
			}
			foreach (FishingQuestItemChildItem fishingQuestItemChildItem in list)
			{
				fishingQuestItemChildItem.RefreshItem();
			}
		}

		// Token: 0x04024FEF RID: 151535
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<int, UUIExtendToggle, Action> OnClickTaskCallBack;

		// Token: 0x04024FF0 RID: 151536
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<FishingQuestItemChildItem, int> TaskLayout;

		// Token: 0x04024FF1 RID: 151537
		private int ScrollToHandle = -1;

		// Token: 0x04024FF2 RID: 151538
		[Nullable(1)]
		private List<int> TaskList = new List<int>();

		// Token: 0x0200C85A RID: 51290
		private class EComponentDefine
		{
			// Token: 0x0403DA7C RID: 252540
			public const int RootItem = 0;

			// Token: 0x0403DA7D RID: 252541
			public const int TaskLayout = 1;

			// Token: 0x0403DA7E RID: 252542
			public const int TitleText = 2;

			// Token: 0x0403DA7F RID: 252543
			public const int TitleSprite = 3;

			// Token: 0x0403DA80 RID: 252544
			public const int TitleItem = 4;

			// Token: 0x0403DA81 RID: 252545
			public const int TaskItem = 5;

			// Token: 0x0403DA82 RID: 252546
			public const int TitleBgItem = 6;
		}
	}
}
