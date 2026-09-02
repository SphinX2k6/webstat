using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B14 RID: 6932
[NullableContext(1)]
[Nullable(0)]
public class ItemTipsAbyssDanngoComponent : TipsBaseSubComponent
{
	// Token: 0x0600C7C5 RID: 51141 RVA: 0x0034DB5C File Offset: 0x0034BD5C
	public ItemTipsAbyssDanngoComponent(UUIItem rootUiItem) : base(rootUiItem)
	{
		base.CreateThenShowByResourceIdAsync("UiItem_TipsChipInfo", rootUiItem, false).Forget();
	}

	// Token: 0x0600C7C6 RID: 51142 RVA: 0x0034DB78 File Offset: 0x0034BD78
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
	}

	// Token: 0x0600C7C7 RID: 51143 RVA: 0x0034DC56 File Offset: 0x0034BE56
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.RefreshFuncState));
	}

	// Token: 0x0600C7C8 RID: 51144 RVA: 0x0034DC74 File Offset: 0x0034BE74
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.RefreshFuncState));
	}

	// Token: 0x0600C7C9 RID: 51145 RVA: 0x0034DC92 File Offset: 0x0034BE92
	private void RefreshFuncState(int incId)
	{
		this.RefreshView(this.CurrentData);
	}

	// Token: 0x0600C7CA RID: 51146 RVA: 0x0034DCA0 File Offset: 0x0034BEA0
	protected override UniTask OnBeforeStartAsync()
	{
		ItemTipsAbyssDanngoComponent.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ItemTipsAbyssDanngoComponent.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C7CB RID: 51147 RVA: 0x0034DCE3 File Offset: 0x0034BEE3
	private void OnConfirmBtnClick(int _)
	{
	}

	// Token: 0x0600C7CC RID: 51148 RVA: 0x0034DCE8 File Offset: 0x0034BEE8
	protected override void OnStart()
	{
		this.AttributeScroller = new GenericLayout<RoleAttributeItem, RoleAttributeSt>(base.GetVerticalLayout(1), new Func<RoleAttributeItem>(this.CreateItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
		this.TagScroller = new GenericLayout<DangoAbyssTagItem, DangoAbyssDefine.DangoAbyssTagData>(base.GetVerticalLayout(3), new Func<DangoAbyssTagItem>(this.CreateTagItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600C7CD RID: 51149 RVA: 0x0034DD57 File Offset: 0x0034BF57
	private DangoAbyssTagItem CreateTagItem()
	{
		return new DangoAbyssTagItem();
	}

	// Token: 0x0600C7CE RID: 51150 RVA: 0x0034DD5E File Offset: 0x0034BF5E
	private RoleAttributeItem CreateItem()
	{
		return new RoleAttributeItem();
	}

	// Token: 0x0600C7CF RID: 51151 RVA: 0x0034DD68 File Offset: 0x0034BF68
	public override void Refresh(ItemTipsData data)
	{
		Action action = delegate()
		{
			this.RefreshView((TipsAbyssDangoData)data);
		};
		if (base.InAsyncLoading())
		{
			this.OperationMap["Refresh"] = action;
			return;
		}
		action();
	}

	// Token: 0x0600C7D0 RID: 51152 RVA: 0x0034DDB4 File Offset: 0x0034BFB4
	private void RefreshView(TipsAbyssDangoData data)
	{
		this.CurrentData = data;
		AttrListScrollData[] pluginShowAttributeList = ModelBase<DangoAbyssModel>.Instance.GetPluginShowAttributeList(data.ConfigId);
		this.RefreshAttribute(pluginShowAttributeList);
		DangoAbyssDefine.DangoAbyssTagData[] pluginShowTagDataList = ModelBase<DangoAbyssModel>.Instance.GetPluginShowTagDataList(data.ConfigId);
		this.RefreshTag(pluginShowTagDataList);
		ItemConfig dangoItemConfig = ModelBase<DangoAbyssModel>.Instance.GetDangoItemConfig(data.ConfigId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), dangoItemConfig.BgDescription, Array.Empty<object>());
		this.RefreshInActiveRedItem(data);
		this.RefreshConfirmBtn(data);
		this.RefreshLockToggle(data);
	}

	// Token: 0x0600C7D1 RID: 51153 RVA: 0x0034DE3C File Offset: 0x0034C03C
	private void RefreshLockToggle(TipsAbyssDangoData data)
	{
		EToggleState state = ModelBase<DangoAbyssModel>.Instance.GetDangoItemLockState(data.IncId) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x0600C7D2 RID: 51154 RVA: 0x0034DE74 File Offset: 0x0034C074
	private void RefreshConfirmBtn(TipsAbyssDangoData data)
	{
		int dangoItemBelongId = ModelBase<DangoAbyssModel>.Instance.GetDangoItemBelongId(data.IncId);
		bool buttonAllowEventBubbleUp = dangoItemBelongId == 0 || data.DangoId == dangoItemBelongId;
		ButtonItem confirmBtnItem = this.ConfirmBtnItem;
		if (confirmBtnItem == null)
		{
			return;
		}
		confirmBtnItem.SetButtonAllowEventBubbleUp(buttonAllowEventBubbleUp);
	}

	// Token: 0x0600C7D3 RID: 51155 RVA: 0x0034DEB4 File Offset: 0x0034C0B4
	private void RefreshInActiveRedItem(TipsAbyssDangoData data)
	{
		int dangoItemBelongId = ModelBase<DangoAbyssModel>.Instance.GetDangoItemBelongId(data.IncId);
		if (dangoItemBelongId != 0)
		{
			bool active = data.DangoId != dangoItemBelongId;
			InActiveRedItem inActiveRedItem = this.InActiveRedItem;
			if (inActiveRedItem != null)
			{
				inActiveRedItem.SetActive(active);
			}
			return;
		}
		InActiveRedItem inActiveRedItem2 = this.InActiveRedItem;
		if (inActiveRedItem2 == null)
		{
			return;
		}
		inActiveRedItem2.SetActive(false);
	}

	// Token: 0x0600C7D4 RID: 51156 RVA: 0x0034DF08 File Offset: 0x0034C108
	private void RefreshAttribute(AttrListScrollData[] data)
	{
		List<RoleAttributeSt> list = new List<RoleAttributeSt>();
		if (data != null)
		{
			foreach (AttrListScrollData data2 in data)
			{
				list.Add(new RoleAttributeSt
				{
					Data = data2,
					NeedCheckBg = false
				});
			}
		}
		this.AttributeScroller.RefreshByData(list, null, false);
	}

	// Token: 0x0600C7D5 RID: 51157 RVA: 0x0034DF5F File Offset: 0x0034C15F
	private void RefreshTag(DangoAbyssDefine.DangoAbyssTagData[] data)
	{
		this.TagScroller.RefreshByData(data.ToList<DangoAbyssDefine.DangoAbyssTagData>(), null, false);
	}

	// Token: 0x04005FA1 RID: 24481
	[Nullable(2)]
	private TipsAbyssDangoData CurrentData;

	// Token: 0x04005FA2 RID: 24482
	[Nullable(2)]
	private InActiveRedItem InActiveRedItem;

	// Token: 0x04005FA3 RID: 24483
	[Nullable(2)]
	private ButtonItem ConfirmBtnItem;

	// Token: 0x04005FA4 RID: 24484
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleAttributeItem, RoleAttributeSt> AttributeScroller;

	// Token: 0x04005FA5 RID: 24485
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<DangoAbyssTagItem, DangoAbyssDefine.DangoAbyssTagData> TagScroller;

	// Token: 0x02007DEF RID: 32239
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402AE52 RID: 175698
		LockToggle,
		// Token: 0x0402AE53 RID: 175699
		BaseAttributeLayout,
		// Token: 0x0402AE54 RID: 175700
		BaseAttributeItem,
		// Token: 0x0402AE55 RID: 175701
		TagPropVertical,
		// Token: 0x0402AE56 RID: 175702
		TagPropItem,
		// Token: 0x0402AE57 RID: 175703
		DescItem,
		// Token: 0x0402AE58 RID: 175704
		DescText,
		// Token: 0x0402AE59 RID: 175705
		ConfirmBtnItem,
		// Token: 0x0402AE5A RID: 175706
		InActiveRedItem
	}
}
