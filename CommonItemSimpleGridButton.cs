using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001966 RID: 6502
[NullableContext(1)]
[Nullable(0)]
public class CommonItemSimpleGridButton : GridProxyAbstract<TItem>
{
	// Token: 0x17000F23 RID: 3875
	// (get) Token: 0x0600BAAC RID: 47788 RVA: 0x0031AE42 File Offset: 0x00319042
	public int ItemId
	{
		get
		{
			return this.ItemConfigId;
		}
	}

	// Token: 0x0600BAAD RID: 47789 RVA: 0x0031AE4C File Offset: 0x0031904C
	[NullableContext(2)]
	public CommonItemSimpleGridButton(AActor commonItemActor = null)
	{
		if (commonItemActor != null)
		{
			this.CreateThenShowByActor(commonItemActor);
		}
	}

	// Token: 0x0600BAAE RID: 47790 RVA: 0x0031AE9C File Offset: 0x0031909C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.ButtonClick))
		};
	}

	// Token: 0x0600BAAF RID: 47791 RVA: 0x0031AF9D File Offset: 0x0031919D
	protected override void OnStart()
	{
	}

	// Token: 0x0600BAB0 RID: 47792 RVA: 0x0031AF9F File Offset: 0x0031919F
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x0600BAB1 RID: 47793 RVA: 0x0031AFA1 File Offset: 0x003191A1
	private void ButtonClick()
	{
		if (this.ClickCallback == null)
		{
			return;
		}
		this.ClickCallback(this.ItemConfigId);
	}

	// Token: 0x0600BAB2 RID: 47794 RVA: 0x0031AFC0 File Offset: 0x003191C0
	private void UpdateView()
	{
		UUITexture texture = base.GetTexture(1);
		base.SetItemIcon(texture, this.ItemConfigId, this.BelongViewName, null);
		UUISprite sprite = base.GetSprite(0);
		base.SetItemQualityIcon(sprite, this.ItemConfigId, this.BelongViewName, CommonDefine.EQualityIconType.BackgroundSprite, null);
	}

	// Token: 0x0600BAB3 RID: 47795 RVA: 0x0031B008 File Offset: 0x00319208
	public override void Refresh(TItem data, bool isSelect, int gridIndex)
	{
		InventoryDefine.IGetItemData itemData = data.ItemData;
		int count = data.Count;
		this.RefreshItem(itemData.ItemId, count);
	}

	// Token: 0x0600BAB4 RID: 47796 RVA: 0x0031B030 File Offset: 0x00319230
	public void SetQualityActive(bool isShow)
	{
		base.GetSprite(0).SetUIActive(isShow);
	}

	// Token: 0x0600BAB5 RID: 47797 RVA: 0x0031B03F File Offset: 0x0031923F
	public void SetCanReceiveActive(bool isShow)
	{
		base.GetSprite(5).SetUIActive(isShow);
	}

	// Token: 0x0600BAB6 RID: 47798 RVA: 0x0031B04E File Offset: 0x0031924E
	public void SetLockReceiveActive(bool isShow)
	{
		base.GetSprite(6).SetUIActive(isShow);
	}

	// Token: 0x0600BAB7 RID: 47799 RVA: 0x0031B05D File Offset: 0x0031925D
	public void SetReceivedActive(bool isShow)
	{
		base.GetItem(7).SetUIActive(isShow);
	}

	// Token: 0x0600BAB8 RID: 47800 RVA: 0x0031B06C File Offset: 0x0031926C
	public void SetBelongViewName(EUiViewName viewName)
	{
		this.BelongViewName = new EUiViewName?(viewName);
	}

	// Token: 0x0600BAB9 RID: 47801 RVA: 0x0031B07A File Offset: 0x0031927A
	public void RefreshItem(int itemConfigId, int itemCount = 0)
	{
		this.ItemConfigId = itemConfigId;
		this.UpdateView();
		this.SetCount(itemCount);
	}

	// Token: 0x0600BABA RID: 47802 RVA: 0x0031B090 File Offset: 0x00319290
	public void BindClickCallback(Action<int> clickCallback)
	{
		this.ClickCallback = clickCallback;
	}

	// Token: 0x0600BABB RID: 47803 RVA: 0x0031B099 File Offset: 0x00319299
	protected void SetCount(int count = 0)
	{
		if (count == 0)
		{
			this.GetCountItem().SetUIActive(false);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(this.GetCountText(), this.CountTextId, new <>z__ReadOnlySingleElementList<object>(count));
		this.GetCountItem().SetUIActive(true);
	}

	// Token: 0x0600BABC RID: 47804 RVA: 0x0031B0D8 File Offset: 0x003192D8
	[NullableContext(2)]
	protected UUIText GetCountText()
	{
		return base.GetText(2);
	}

	// Token: 0x0600BABD RID: 47805 RVA: 0x0031B0E1 File Offset: 0x003192E1
	[NullableContext(2)]
	protected UUIItem GetCountItem()
	{
		return base.GetItem(3);
	}

	// Token: 0x0600BABE RID: 47806 RVA: 0x0031B0EA File Offset: 0x003192EA
	public void SetCountTextId(string textId)
	{
		this.CountTextId = textId;
	}

	// Token: 0x0600BABF RID: 47807 RVA: 0x0031B0F4 File Offset: 0x003192F4
	public UniTask RefreshItemAsync(int itemConfigId, int itemCount = 0)
	{
		CommonItemSimpleGridButton.<RefreshItemAsync>d__25 <RefreshItemAsync>d__;
		<RefreshItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshItemAsync>d__.<>4__this = this;
		<RefreshItemAsync>d__.itemConfigId = itemConfigId;
		<RefreshItemAsync>d__.itemCount = itemCount;
		<RefreshItemAsync>d__.<>1__state = -1;
		<RefreshItemAsync>d__.<>t__builder.Start<CommonItemSimpleGridButton.<RefreshItemAsync>d__25>(ref <RefreshItemAsync>d__);
		return <RefreshItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BAC0 RID: 47808 RVA: 0x0031B148 File Offset: 0x00319348
	private UniTask UpdateViewAsync()
	{
		CommonItemSimpleGridButton.<UpdateViewAsync>d__26 <UpdateViewAsync>d__;
		<UpdateViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateViewAsync>d__.<>4__this = this;
		<UpdateViewAsync>d__.<>1__state = -1;
		<UpdateViewAsync>d__.<>t__builder.Start<CommonItemSimpleGridButton.<UpdateViewAsync>d__26>(ref <UpdateViewAsync>d__);
		return <UpdateViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04005853 RID: 22611
	private int ItemConfigId;

	// Token: 0x04005854 RID: 22612
	private string CountTextId = "ShowCount";

	// Token: 0x04005855 RID: 22613
	private EUiViewName? BelongViewName;

	// Token: 0x04005856 RID: 22614
	private Action<int> ClickCallback = delegate(int itemConfigId)
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemConfigId, true, null);
	};

	// Token: 0x02007C81 RID: 31873
	[NullableContext(0)]
	private enum EChildComponentType
	{
		// Token: 0x0402A842 RID: 174146
		SpriteQuality,
		// Token: 0x0402A843 RID: 174147
		TextureIcon,
		// Token: 0x0402A844 RID: 174148
		TextCount,
		// Token: 0x0402A845 RID: 174149
		NumItem,
		// Token: 0x0402A846 RID: 174150
		ButtonClick,
		// Token: 0x0402A847 RID: 174151
		CanReceiveSprite,
		// Token: 0x0402A848 RID: 174152
		LockSprite,
		// Token: 0x0402A849 RID: 174153
		ReceivedItem,
		// Token: 0x0402A84A RID: 174154
		AddSprite
	}
}
