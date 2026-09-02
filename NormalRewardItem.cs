using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015B1 RID: 5553
public class NormalRewardItem : SignRewardItemBase
{
	// Token: 0x06009C6F RID: 40047 RVA: 0x0028F828 File Offset: 0x0028DA28
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(base.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009C70 RID: 40048 RVA: 0x0028F9B8 File Offset: 0x0028DBB8
	protected override UniTask OnBeforeStartAsync()
	{
		NormalRewardItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<NormalRewardItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009C71 RID: 40049 RVA: 0x0028F9FB File Offset: 0x0028DBFB
	protected override void OnBeforeDestroy()
	{
		if (this.CommonSmallItemGridInner != null)
		{
			base.AddChild(this.CommonSmallItemGridInner);
		}
	}

	// Token: 0x06009C72 RID: 40050 RVA: 0x0028FA11 File Offset: 0x0028DC11
	public void SetDayText(int day)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "DayNum", new <>z__ReadOnlySingleElementList<object>(day));
	}

	// Token: 0x06009C73 RID: 40051 RVA: 0x0028FA34 File Offset: 0x0028DC34
	[NullableContext(1)]
	public void SetStateText(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textId, Array.Empty<object>());
	}

	// Token: 0x06009C74 RID: 40052 RVA: 0x0028FA50 File Offset: 0x0028DC50
	public override void RefreshByData(OneItemConfig data, SignState state, int index)
	{
		this.Index = index;
		this.ConfigId = data.ItemId;
		this.SetDayText(index + 1);
		this.SetStateText(base.GetRewardStateTextId(state));
		bool uiactive = state == SignState.IsReceive;
		bool flag = state == SignState.Unlock;
		this.CanGetReward = flag;
		UUIText text = base.GetText(2);
		if (text != null)
		{
			UUIItem uuiitem = text;
			bool bUseChangeColor = state == SignState.Lock;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}
		base.GetItem(4).SetUIActive(uiactive);
		base.GetSprite(5).SetUIActive(flag);
		base.GetSprite(6).SetUIActive(flag);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(flag ? "SP_NewSignInSmallItemBg_Reward" : "SP_NewSignInSmallItemBg_Normal");
		this.SetSpriteByPath(resourcePath, base.GetSprite(7), false, null, null);
		base.GetItem(8).SetUIActive(flag);
		this.RefreshGrid(data, state);
	}

	// Token: 0x06009C75 RID: 40053 RVA: 0x0028FB2C File Offset: 0x0028DD2C
	private void RefreshGrid(OneItemConfig data, SignState state)
	{
		int count = data.Count;
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(this.ConfigId));
		bool value = state == SignState.Unlock;
		bool value2 = state == SignState.Lock;
		bool value3 = state == SignState.IsReceive;
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleItem)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.ConfigId);
			CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
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
			this.CommonSmallItemGridInner.Apply<CharacterSmallItemGrid>(parameters);
			return;
		}
		if (itemDataTypeByConfigId != InventoryDefine.EItemDataType.PhantomItem)
		{
			PropSmallItemGrid parameters2 = new PropSmallItemGrid
			{
				Data = data,
				ItemConfigId = new int?(this.ConfigId),
				BottomText = count.ToString(),
				IsReceivableVisible = new bool?(value),
				IsLockVisible = new bool?(value2),
				IsReceivedVisible = new bool?(value3)
			};
			this.CommonSmallItemGridInner.Apply<PropSmallItemGrid>(parameters2);
			return;
		}
		PhantomSmallItemGrid parameters3 = new PhantomSmallItemGrid
		{
			Data = data,
			ItemConfigId = new int?(this.ConfigId),
			BottomText = count.ToString(),
			IsReceivableVisible = new bool?(value),
			IsLockVisible = new bool?(value2),
			IsReceivedVisible = new bool?(value3)
		};
		this.CommonSmallItemGridInner.Apply<PhantomSmallItemGrid>(parameters3);
	}

	// Token: 0x06009C76 RID: 40054 RVA: 0x0028FCEA File Offset: 0x0028DEEA
	[NullableContext(1)]
	private void OnExtendToggleClicked(MediumItemGridExtendCallback callback)
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

	// Token: 0x040047FB RID: 18427
	[Nullable(2)]
	private SmallItemGrid CommonSmallItemGridInner;

	// Token: 0x040047FC RID: 18428
	private int ConfigId;

	// Token: 0x02007974 RID: 31092
	private class ENormalRewardItemComponents
	{
		// Token: 0x04029B7C RID: 170876
		public const int CommonItemGridSmall = 0;

		// Token: 0x04029B7D RID: 170877
		public const int TxtDay = 1;

		// Token: 0x04029B7E RID: 170878
		public const int TxtReward = 2;

		// Token: 0x04029B7F RID: 170879
		public const int Toggle = 3;

		// Token: 0x04029B80 RID: 170880
		public const int PnlReward = 4;

		// Token: 0x04029B81 RID: 170881
		public const int SprFrame = 5;

		// Token: 0x04029B82 RID: 170882
		public const int SprBgDesc = 6;

		// Token: 0x04029B83 RID: 170883
		public const int SpriteBg = 7;

		// Token: 0x04029B84 RID: 170884
		public const int RewardEffect = 8;
	}
}
