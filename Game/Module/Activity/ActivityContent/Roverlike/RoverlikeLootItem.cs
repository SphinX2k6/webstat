using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200642B RID: 25643
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeLootItem : RoverlikeMultiUseGridProxyAbstract<RoverlikeLootGainEntry>
	{
		// Token: 0x0604060B RID: 263691 RVA: 0x01080E68 File Offset: 0x0107F068
		public void BindOnItemSelect(Action<RoverlikeLootGainEntry> callback)
		{
			this.OnItemSelect = callback;
		}

		// Token: 0x0604060C RID: 263692 RVA: 0x01080E74 File Offset: 0x0107F074
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTogCommonStateChanged));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604060D RID: 263693 RVA: 0x01080FE0 File Offset: 0x0107F1E0
		public override void Refresh(RoverlikeLootGainEntry data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			RoverRogueLoot? lootConfig = ConfigBase<RoverlikeConfig>.Instance.GetLootConfig(data.ConfigId);
			if (lootConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), lootConfig.Value.Name, Array.Empty<object>());
			base.SetTextureByPath(lootConfig.Value.Icon, base.GetTexture(1), null, null);
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(!data.Unlock);
			}
			UUIItem item2 = base.GetItem(7);
			if (item2 != null)
			{
				item2.SetUIActive(data.Unlock && data.IsEquipped);
			}
			Func<RoverlikeLootGainEntry, bool> getHasRedDot = this.GetHasRedDot;
			bool uiactive = getHasRedDot != null && getHasRedDot(data);
			UUIItem item3 = base.GetItem(5);
			if (item3 != null)
			{
				item3.SetUIActive(uiactive);
			}
			List<bool> list = new List<bool>();
			for (int i = 0; i < lootConfig.Value.MaxLevel; i++)
			{
				list.Add(i < data.LootLv);
			}
			this.StarLayout.RefreshByData(list, null, false);
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0604060E RID: 263694 RVA: 0x01081119 File Offset: 0x0107F319
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x0604060F RID: 263695 RVA: 0x0108112C File Offset: 0x0107F32C
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06040610 RID: 263696 RVA: 0x0108113F File Offset: 0x0107F33F
		private void OnTogCommonStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked && this.CurrentData != null)
			{
				Action<RoverlikeLootGainEntry> onItemSelect = this.OnItemSelect;
				if (onItemSelect == null)
				{
					return;
				}
				onItemSelect(this.CurrentData);
			}
		}

		// Token: 0x06040611 RID: 263697 RVA: 0x01081163 File Offset: 0x0107F363
		protected override void OnStart()
		{
			this.StarLayout = new GenericLayout<RoverlikeLootStarItem, bool>(base.GetHorizontalLayout(2), new Func<RoverlikeLootStarItem>(this.CreateStarItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x06040612 RID: 263698 RVA: 0x01081196 File Offset: 0x0107F396
		private RoverlikeLootStarItem CreateStarItem()
		{
			return new RoverlikeLootStarItem();
		}

		// Token: 0x04024101 RID: 147713
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoverlikeLootStarItem, bool> StarLayout;

		// Token: 0x04024102 RID: 147714
		[Nullable(2)]
		private RoverlikeLootGainEntry CurrentData;

		// Token: 0x04024103 RID: 147715
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<RoverlikeLootGainEntry> OnItemSelect;

		// Token: 0x04024104 RID: 147716
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<RoverlikeLootGainEntry, bool> GetHasRedDot;

		// Token: 0x0200C49A RID: 50330
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C840 RID: 247872
			public const int TogCommon = 0;

			// Token: 0x0403C841 RID: 247873
			public const int TexIcon = 1;

			// Token: 0x0403C842 RID: 247874
			public const int StarLayout = 2;

			// Token: 0x0403C843 RID: 247875
			public const int StarItem = 3;

			// Token: 0x0403C844 RID: 247876
			public const int TxtName = 4;

			// Token: 0x0403C845 RID: 247877
			public const int ItemTagNew = 5;

			// Token: 0x0403C846 RID: 247878
			public const int PnlLock = 6;

			// Token: 0x0403C847 RID: 247879
			public const int PnlEquipment = 7;
		}
	}
}
