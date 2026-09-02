using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Phantom.Vision.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020019A4 RID: 6564
[NullableContext(1)]
[Nullable(0)]
public class TipsVisionComponent : TipsBaseSubComponent
{
	// Token: 0x0600BC85 RID: 48261 RVA: 0x00320940 File Offset: 0x0031EB40
	public TipsVisionComponent(UUIItem rootUiItem) : base(rootUiItem)
	{
		base.CreateThenShowByResourceIdAsync("UiItem_TipsVision", rootUiItem, false);
	}

	// Token: 0x0600BC86 RID: 48262 RVA: 0x00320958 File Offset: 0x0031EB58
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BC87 RID: 48263 RVA: 0x00320B34 File Offset: 0x0031ED34
	protected override UniTask OnBeforeStartAsync()
	{
		TipsVisionComponent.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TipsVisionComponent.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BC88 RID: 48264 RVA: 0x00320B78 File Offset: 0x0031ED78
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(2);
		this.TipsLockButton = new TipsLockButton(item);
		this.TipsAttributePanel = new GenericLayoutNew<TipsAttributeItem>(base.GetVerticalLayout(3), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<TipsAttributeItem>(this.CreateAttributeItem), null);
		this.Layout = new GenericLayoutNew<global::VisionDetailDescItem>(base.GetVerticalLayout(12), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<global::VisionDetailDescItem>(this.CreateInfoItem), null);
		UUIItem item2 = base.GetItem(5);
		this.TipsGetWayPanel = new TipsGetWayPanel(item2);
	}

	// Token: 0x0600BC89 RID: 48265 RVA: 0x00320BEC File Offset: 0x0031EDEC
	protected override void OnBeforeDestroy()
	{
		if (this.Data != null)
		{
			this.Data = null;
			ModelBase<ItemTipsModel>.Instance.SetCurrentItemTipsData(null);
		}
	}

	// Token: 0x0600BC8A RID: 48266 RVA: 0x00320C08 File Offset: 0x0031EE08
	public override void Refresh(ItemTipsData data)
	{
		TipsVisionData tipsVisionData = (TipsVisionData)data;
		Action action = delegate()
		{
			TipsVisionData data2 = this.Data;
			base.GetText(0).SetText(data2.Cost.ToString(), true);
			base.GetText(1).SetUIActive(data2.UpgradeLevel != null);
			base.GetText(1).SetText(data2.UpgradeLevel, true);
			if (data2.IncId > 0)
			{
				this.TipsLockButton.Refresh(data2.IncId, data2.CanClickLockButton);
				this.TipsLockButton.SetDeprecateToggleVisible(data2.CanDeprecate());
			}
			TipsLockButton tipsLockButton = this.TipsLockButton;
			if (tipsLockButton != null)
			{
				tipsLockButton.SetUiActive(data2.IncId > 0);
			}
			this.TipsAttributePanel.RebuildLayoutByDataNew<ITipsAttributeItemData>(data2.AttributeData, null);
			PhantomBattleData dataBase = data2.VisionDetailInfoComponentData.DataBase;
			if (dataBase != null && dataBase.GetFetterGroupId() > 0)
			{
				this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(dataBase.GetFetterGroupConfig()));
				this.VisionFetterSuitItem.SetUiActive(true);
			}
			else
			{
				this.VisionFetterSuitItem.SetUiActive(false);
			}
			this.DescLayout(data2.VisionDetailInfoComponentData);
			this.RefreshGetWayPanel(data2.GetWayData);
			this.RefreshLimitTimePanel(data2.LimitTimeTxt);
			this.RefreshEquipPanel(data2);
		};
		this.Data = tipsVisionData;
		ModelBase<ItemTipsModel>.Instance.SetCurrentItemTipsData(tipsVisionData);
		if (base.InAsyncLoading())
		{
			this.OperationMap["Refresh"] = action;
			return;
		}
		action();
	}

	// Token: 0x0600BC8B RID: 48267 RVA: 0x00320C5C File Offset: 0x0031EE5C
	private ILayoutItem<global::VisionDetailDescItem> CreateInfoItem(object data, UUIItem uiItem, int index)
	{
		global::VisionDetailDescItem descItem = new global::VisionDetailDescItem(uiItem);
		descItem.Init().ContinueWith(delegate()
		{
			descItem.Update((VisionDetailDesc)data);
			descItem.SetActive(true);
		});
		return new LayoutItem<global::VisionDetailDescItem>
		{
			Key = index,
			Value = descItem
		};
	}

	// Token: 0x0600BC8C RID: 48268 RVA: 0x00320CBC File Offset: 0x0031EEBC
	private ILayoutItem<TipsAttributeItem> CreateAttributeItem(object data, UUIItem uiItem, int index)
	{
		TipsAttributeItem value = new TipsAttributeItem(uiItem, (ITipsAttributeItemData)data);
		return new LayoutItem<TipsAttributeItem>
		{
			Key = index,
			Value = value
		};
	}

	// Token: 0x0600BC8D RID: 48269 RVA: 0x00320CF0 File Offset: 0x0031EEF0
	private void DescLayout(VisionDetailInfoComponentData data)
	{
		this.Layout.RebuildLayoutByDataNew<VisionDetailDesc>(data.DescData, null);
	}

	// Token: 0x0600BC8E RID: 48270 RVA: 0x00320D17 File Offset: 0x0031EF17
	private void RefreshGetWayPanel(IGetWayItemData[] getWayData)
	{
		base.GetItem(5).SetUIActive(getWayData != null && getWayData.Length != 0);
		if (getWayData != null)
		{
			this.TipsGetWayPanel.Refresh(getWayData);
		}
	}

	// Token: 0x0600BC8F RID: 48271 RVA: 0x00320D3F File Offset: 0x0031EF3F
	private void RefreshLimitTimePanel(string limitTimeTxt)
	{
		base.GetItem(6).SetUIActive(limitTimeTxt != null);
		if (!string.IsNullOrEmpty(limitTimeTxt))
		{
			base.GetText(7).ShowTextNew(limitTimeTxt);
		}
	}

	// Token: 0x0600BC90 RID: 48272 RVA: 0x00320D68 File Offset: 0x0031EF68
	private unsafe void RefreshEquipPanel(TipsVisionData data)
	{
		int? equippedId = data.EquippedId;
		bool isEquip = data.IsEquip;
		RoleDataBase roleDataBase = null;
		if (equippedId != null)
		{
			roleDataBase = ModelBase<RoleModel>.Instance.GetRoleDataById(equippedId.Value, true);
			if (roleDataBase == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ItemHint;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "找不到装备角色但是认为被装备中";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("roleId", equippedId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("visionId", data.IncId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("visionConfigId", data.ConfigId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				base.GetItem(8).SetUIActive(false);
				return;
			}
		}
		base.GetItem(8).SetUIActive(isEquip);
		if (roleDataBase == null)
		{
			return;
		}
		RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(roleDataBase.GetRoleSkinId());
		if (isEquip && roleSkinData != null)
		{
			base.SetRoleSkinIcon(roleSkinData.GetRoleSkinConfig().RoleHeadIcon, base.GetTexture(9), roleSkinData.GetItemId(), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "VisionEquipping", new <>z__ReadOnlySingleElementList<object>(roleDataBase.GetName(null)));
		}
	}

	// Token: 0x0600BC91 RID: 48273 RVA: 0x00320EC0 File Offset: 0x0031F0C0
	public override void SetLockButtonShow(bool isShow)
	{
		Action action = delegate()
		{
			this.GetItem(2).SetUIActive(isShow);
		};
		if (base.InAsyncLoading())
		{
			this.OperationMap["SetLockButtonShow"] = action;
			return;
		}
		action();
	}

	// Token: 0x0400592F RID: 22831
	[Nullable(2)]
	private TipsVisionData Data;

	// Token: 0x04005930 RID: 22832
	[Nullable(2)]
	private TipsLockButton TipsLockButton;

	// Token: 0x04005931 RID: 22833
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<TipsAttributeItem> TipsAttributePanel;

	// Token: 0x04005932 RID: 22834
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<global::VisionDetailDescItem> Layout;

	// Token: 0x04005933 RID: 22835
	[Nullable(2)]
	private TipsGetWayPanel TipsGetWayPanel;

	// Token: 0x04005934 RID: 22836
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02007CA8 RID: 31912
	[NullableContext(0)]
	private class ETipsVisionNode
	{
		// Token: 0x0402A8F9 RID: 174329
		public const int CostText = 0;

		// Token: 0x0402A8FA RID: 174330
		public const int TxtUpgrade = 1;

		// Token: 0x0402A8FB RID: 174331
		public const int BtnLock = 2;

		// Token: 0x0402A8FC RID: 174332
		public const int PanelProperty = 3;

		// Token: 0x0402A8FD RID: 174333
		public const int PanelPropertyItem = 4;

		// Token: 0x0402A8FE RID: 174334
		public const int PanelPath = 5;

		// Token: 0x0402A8FF RID: 174335
		public const int PanelLimitTime = 6;

		// Token: 0x0402A900 RID: 174336
		public const int TxtLimitTime = 7;

		// Token: 0x0402A901 RID: 174337
		public const int PanelEquip = 8;

		// Token: 0x0402A902 RID: 174338
		public const int TextureEquipIcon = 9;

		// Token: 0x0402A903 RID: 174339
		public const int TxtEquip = 10;

		// Token: 0x0402A904 RID: 174340
		public const int SuitElementItem = 11;

		// Token: 0x0402A905 RID: 174341
		public const int DetailVerticalScroller = 12;
	}
}
