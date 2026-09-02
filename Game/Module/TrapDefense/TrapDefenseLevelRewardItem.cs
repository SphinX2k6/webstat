using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E2F RID: 20015
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseLevelRewardItem : GridProxyAbstract<ITrapDefenseLevelRewardItemData>
	{
		// Token: 0x06033BD8 RID: 211928 RVA: 0x00CEF2B4 File Offset: 0x00CED4B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033BD9 RID: 211929 RVA: 0x00CEF3E4 File Offset: 0x00CED5E4
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseLevelRewardItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseLevelRewardItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033BDA RID: 211930 RVA: 0x00CEF428 File Offset: 0x00CED628
		public override void Refresh(ITrapDefenseLevelRewardItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			switch (data.ItemType)
			{
			case ETrapDefenseLevelRewardItemType.Talent:
				this.UpdateTalent();
				return;
			case ETrapDefenseLevelRewardItemType.Machine:
				this.UpdateMachine();
				return;
			case ETrapDefenseLevelRewardItemType.BdBuff:
				this.UpdateBdBuff();
				return;
			default:
				return;
			}
		}

		// Token: 0x06033BDB RID: 211931 RVA: 0x00CEF46A File Offset: 0x00CED66A
		private void SetTalentShow(bool show)
		{
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(show);
		}

		// Token: 0x06033BDC RID: 211932 RVA: 0x00CEF47E File Offset: 0x00CED67E
		private void SetTitleKey(string key)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(key);
		}

		// Token: 0x06033BDD RID: 211933 RVA: 0x00CEF494 File Offset: 0x00CED694
		public void UpdateTalent()
		{
			this.SetTalentShow(true);
			this.LayoutBdReward.SetActive(false);
			this.LayoutMachineReward.SetActive(false);
			this.SetTitleKey(this.ItemData.TypeNameKey.ToString());
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText(this.ItemData.LevelData.Config.RewardMoneyCount.ToString(), true);
			}
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.ItemData.LevelData.IsPassed);
		}

		// Token: 0x06033BDE RID: 211934 RVA: 0x00CEF528 File Offset: 0x00CED728
		public void UpdateMachine()
		{
			this.LayoutMachineReward.SetActive(true);
			this.SetTalentShow(false);
			this.LayoutBdReward.SetActive(false);
			this.SetTitleKey(this.ItemData.TypeNameKey.ToString());
			this.LayoutMachineReward.RefreshByData(this.ItemData.LevelData.GetRewardShowListMachineData(), null, false);
		}

		// Token: 0x06033BDF RID: 211935 RVA: 0x00CEF588 File Offset: 0x00CED788
		public void UpdateBdBuff()
		{
			this.LayoutBdReward.SetActive(true);
			this.SetTalentShow(false);
			this.LayoutMachineReward.SetActive(false);
			this.SetTitleKey(this.ItemData.TypeNameKey.ToString());
			this.LayoutBdReward.RefreshByData(this.ItemData.LevelData.GetRewardShowListBdBuffData(), null, false);
		}

		// Token: 0x06033BE0 RID: 211936 RVA: 0x00CEF5E7 File Offset: 0x00CED7E7
		public TrapDefenseResultBdUnlockItem CreateItemBdReward()
		{
			return new TrapDefenseResultBdUnlockItem();
		}

		// Token: 0x06033BE1 RID: 211937 RVA: 0x00CEF5EE File Offset: 0x00CED7EE
		public TrapDefenseResultOrganUnlockItem CreateItemMachineReward()
		{
			return new TrapDefenseResultOrganUnlockItem();
		}

		// Token: 0x0401DF35 RID: 122677
		public ITrapDefenseLevelRewardItemData ItemData;

		// Token: 0x0401DF36 RID: 122678
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<ITrapDefenseLevelRewardItemData> ClickCallBack;

		// Token: 0x0401DF37 RID: 122679
		public GenericLayout<TrapDefenseResultOrganUnlockItem, ITrapDefenseResultUnlockInfo> LayoutMachineReward;

		// Token: 0x0401DF38 RID: 122680
		public GenericLayout<TrapDefenseResultBdUnlockItem, ITrapDefenseResultUnlockInfo> LayoutBdReward;

		// Token: 0x0200ADAF RID: 44463
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035EFB RID: 220923
			public const int TextTitle = 0;

			// Token: 0x04035EFC RID: 220924
			public const int ItemTalentRoot = 1;

			// Token: 0x04035EFD RID: 220925
			public const int TextTalent = 2;

			// Token: 0x04035EFE RID: 220926
			public const int LayoutMachineReward = 3;

			// Token: 0x04035EFF RID: 220927
			public const int ItemMachineReward = 4;

			// Token: 0x04035F00 RID: 220928
			public const int LayoutBdReward = 5;

			// Token: 0x04035F01 RID: 220929
			public const int ItemBdReward = 6;

			// Token: 0x04035F02 RID: 220930
			public const int ItemFinish = 7;
		}
	}
}
