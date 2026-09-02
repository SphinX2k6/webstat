using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x020015B2 RID: 5554
public class VersionSignRewardItem : SignRewardItemBase
{
	// Token: 0x06009C78 RID: 40056 RVA: 0x0028FD20 File Offset: 0x0028DF20
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(base.OnClickButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009C79 RID: 40057 RVA: 0x0028FE6C File Offset: 0x0028E06C
	protected override void OnStart()
	{
		this.Grid = new SmallItemGrid();
		this.Grid.Initialize(base.GetItem(4).GetOwner());
		this.Grid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		this.Grid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnRewardItemClicked));
	}

	// Token: 0x06009C7A RID: 40058 RVA: 0x0028FEDC File Offset: 0x0028E0DC
	public override void RefreshByData(OneItemConfig data, SignState state, int index)
	{
		this.Index = index;
		this.ConfigId = data.ItemId;
		this.SetDayText(index + 1);
		bool uiactive = state == SignState.IsReceive;
		bool flag = state == SignState.Unlock;
		this.CanGetReward = flag;
		this.SetStateText(base.GetRewardStateTextId(state));
		base.GetItem(1).SetUIActive(flag);
		base.GetItem(2).SetUIActive(uiactive);
		this.RefreshGrid(data, state);
	}

	// Token: 0x06009C7B RID: 40059 RVA: 0x0028FF46 File Offset: 0x0028E146
	private void SetDayText(int day)
	{
		base.GetText(5).SetText("0" + day.ToString(), true);
	}

	// Token: 0x06009C7C RID: 40060 RVA: 0x0028FF66 File Offset: 0x0028E166
	[NullableContext(1)]
	private void SetStateText(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textId, Array.Empty<object>());
	}

	// Token: 0x06009C7D RID: 40061 RVA: 0x0028FF80 File Offset: 0x0028E180
	private void RefreshGrid(OneItemConfig data, SignState state)
	{
		int count = data.Count;
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(this.ConfigId));
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ConfigId);
		int num = (itemConfigData != null) ? itemConfigData.QualityId : 1;
		bool value = state == SignState.Unlock;
		bool value2 = state == SignState.Lock;
		bool value3 = state == SignState.IsReceive;
		if (itemDataTypeByConfigId != InventoryDefine.EItemDataType.RoleItem)
		{
			if (itemDataTypeByConfigId != InventoryDefine.EItemDataType.PhantomItem)
			{
				PropSmallItemGrid parameters = new PropSmallItemGrid
				{
					Data = data,
					ItemConfigId = new int?(this.ConfigId),
					QualityId = new int?(num),
					BottomText = count.ToString(),
					IsReceivableVisible = new bool?(value),
					IsLockVisible = new bool?(value2),
					IsReceivedVisible = new bool?(value3)
				};
				this.Grid.Apply<PropSmallItemGrid>(parameters);
			}
			else
			{
				PhantomSmallItemGrid parameters2 = new PhantomSmallItemGrid
				{
					Data = data,
					ItemConfigId = new int?(this.ConfigId),
					BottomText = count.ToString(),
					IsReceivableVisible = new bool?(value),
					IsLockVisible = new bool?(value2),
					IsReceivedVisible = new bool?(value3)
				};
				this.Grid.Apply<PhantomSmallItemGrid>(parameters2);
			}
		}
		else
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.ConfigId);
			CharacterSmallItemGrid parameters3 = new CharacterSmallItemGrid
			{
				Data = data,
				ElementId = new int?(roleConfig.Value.ElementId),
				ItemConfigId = new int?(this.ConfigId),
				BottomText = count.ToString(),
				QualityId = new int?(roleConfig.Value.QualityId),
				IsReceivableVisible = new bool?(value),
				IsLockVisible = new bool?(value2),
				IsReceivedVisible = new bool?(value3)
			};
			this.Grid.Apply<CharacterSmallItemGrid>(parameters3);
		}
		UUIItem item = base.GetItem(6);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(num == 5);
	}

	// Token: 0x06009C7E RID: 40062 RVA: 0x00290185 File Offset: 0x0028E385
	[NullableContext(1)]
	private void OnRewardItemClicked(MediumItemGridExtendCallback _)
	{
		if (!this.CanGetReward)
		{
			ActivitySevenDaySignDefine.OpenSignActivityRewardPreviewWhenLocked(this.ConfigId);
			return;
		}
		Action<int> onClickToGet = this.OnClickToGet;
		if (onClickToGet == null)
		{
			return;
		}
		onClickToGet(this.Index);
	}

	// Token: 0x040047FD RID: 18429
	[Nullable(2)]
	private SmallItemGrid Grid;

	// Token: 0x040047FE RID: 18430
	private int ConfigId;

	// Token: 0x02007977 RID: 31095
	private class EVersionSignItemComponents
	{
		// Token: 0x04029B8B RID: 170891
		public const int Button = 0;

		// Token: 0x04029B8C RID: 170892
		public const int PanelReceived = 1;

		// Token: 0x04029B8D RID: 170893
		public const int PanelDone = 2;

		// Token: 0x04029B8E RID: 170894
		public const int TextState = 3;

		// Token: 0x04029B8F RID: 170895
		public const int ItemGrid = 4;

		// Token: 0x04029B90 RID: 170896
		public const int TextIndex = 5;

		// Token: 0x04029B91 RID: 170897
		public const int SpriteLight = 6;
	}
}
