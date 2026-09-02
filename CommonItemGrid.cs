using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020018A3 RID: 6307
public class CommonItemGrid : GridProxyAbstract<TItem>
{
	// Token: 0x0600B52A RID: 46378 RVA: 0x00303D36 File Offset: 0x00301F36
	[NullableContext(2)]
	public CommonItemGrid(AActor commonItemActor = null)
	{
		if (commonItemActor != null)
		{
			this.CreateThenShowByActor(commonItemActor);
		}
	}

	// Token: 0x0600B52B RID: 46379 RVA: 0x00303D70 File Offset: 0x00301F70
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUITexture)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick))
		};
	}

	// Token: 0x0600B52C RID: 46380 RVA: 0x00303EE4 File Offset: 0x003020E4
	protected override void OnStart()
	{
		this.InitView();
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.CloseItemTips, new Action<int, int>(this.OnCloseItemTips));
	}

	// Token: 0x0600B52D RID: 46381 RVA: 0x00303F08 File Offset: 0x00302108
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseItemTips, new Action<int, int>(this.OnCloseItemTips));
	}

	// Token: 0x0600B52E RID: 46382 RVA: 0x00303F26 File Offset: 0x00302126
	private void OnCloseItemTips(int itemId, int i)
	{
		if (itemId != this.ItemConfigId)
		{
			return;
		}
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600B52F RID: 46383 RVA: 0x00303F43 File Offset: 0x00302143
	private void ToggleClick(EToggleState state)
	{
		if (this.ClickCallback == null)
		{
			return;
		}
		if (state == EToggleState.ETT_Checked)
		{
			this.ClickCallback(this.ItemConfigId);
		}
	}

	// Token: 0x0600B530 RID: 46384 RVA: 0x00303F63 File Offset: 0x00302163
	private void InitView()
	{
		this.SetEmpty(false);
		this.SetLock(false);
		this.SetRoleHead(null);
		this.SetLevel(0);
	}

	// Token: 0x0600B531 RID: 46385 RVA: 0x00303F81 File Offset: 0x00302181
	private void UpdateView()
	{
		base.SetItemIcon(base.GetTexture(3), this.ItemConfigId, this.BelongViewName, null);
		base.SetItemQualityIcon(base.GetSprite(4), this.ItemConfigId, this.BelongViewName, CommonDefine.EQualityIconType.BackgroundSprite, null);
	}

	// Token: 0x0600B532 RID: 46386 RVA: 0x00303FB8 File Offset: 0x003021B8
	public override void Refresh(TItem data, bool isSelect, int gridIndex)
	{
		InventoryDefine.IGetItemData itemData = data.ItemData;
		int count = data.Count;
		this.RefreshItem(itemData.ItemId, count);
	}

	// Token: 0x0600B533 RID: 46387 RVA: 0x00303FE0 File Offset: 0x003021E0
	public void SetQualityActive(bool isShow)
	{
		base.GetSprite(4).SetUIActive(isShow);
	}

	// Token: 0x0600B534 RID: 46388 RVA: 0x00303FEF File Offset: 0x003021EF
	public void SetBelongViewName(EUiViewName viewName)
	{
		this.BelongViewName = new EUiViewName?(viewName);
	}

	// Token: 0x0600B535 RID: 46389 RVA: 0x00303FFD File Offset: 0x003021FD
	public void RefreshItem(int itemConfigId, int itemCount = 0)
	{
		this.ItemConfigId = itemConfigId;
		this.UpdateView();
		this.SetCount(itemCount);
	}

	// Token: 0x0600B536 RID: 46390 RVA: 0x00304013 File Offset: 0x00302213
	[NullableContext(1)]
	public void BindClickCallback(Action<int> clickCallback)
	{
		this.ClickCallback = clickCallback;
	}

	// Token: 0x0600B537 RID: 46391 RVA: 0x0030401C File Offset: 0x0030221C
	private void SetCount(int count = 0)
	{
		if (count == 0)
		{
			base.GetItem(12).SetUIActive(false);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(10), "ShowCount", new <>z__ReadOnlySingleElementList<object>(count));
		base.GetItem(12).SetUIActive(true);
	}

	// Token: 0x0600B538 RID: 46392 RVA: 0x0030406C File Offset: 0x0030226C
	[NullableContext(2)]
	public void SetRoleHead(string texturePath = null)
	{
		UUITexture texture = base.GetTexture(6);
		UUISprite sprite = base.GetSprite(7);
		if (!StringUtils.IsEmpty(texturePath))
		{
			texture.SetUIActive(true);
			sprite.SetUIActive(true);
			base.SetTextureByPath(texturePath, texture, null, null);
			return;
		}
		texture.SetUIActive(false);
		sprite.SetUIActive(false);
	}

	// Token: 0x0600B539 RID: 46393 RVA: 0x003040C0 File Offset: 0x003022C0
	private void SetLevel(int level = 0)
	{
		if (level == 0)
		{
			base.GetItem(9).SetUIActive(false);
			return;
		}
		base.GetText(8).SetText(level.ToString("F0"), true);
		base.GetItem(9).SetUIActive(true);
	}

	// Token: 0x0600B53A RID: 46394 RVA: 0x003040FB File Offset: 0x003022FB
	public void SetMask(bool value)
	{
		base.GetTexture(11).SetUIActive(value);
	}

	// Token: 0x0600B53B RID: 46395 RVA: 0x0030410B File Offset: 0x0030230B
	public void SetEmpty(bool value)
	{
		base.GetItem(2).SetUIActive(value);
		base.GetItem(1).SetUIActive(!value);
	}

	// Token: 0x0600B53C RID: 46396 RVA: 0x0030412A File Offset: 0x0030232A
	public void SetLock(bool value)
	{
		base.GetItem(5).SetUIActive(value);
	}

	// Token: 0x0600B53D RID: 46397 RVA: 0x00304139 File Offset: 0x00302339
	public void SetReceived(bool value)
	{
		base.GetItem(13).SetUIActive(value);
	}

	// Token: 0x0600B53E RID: 46398 RVA: 0x00304149 File Offset: 0x00302349
	public void SetCountTextVisible(bool value)
	{
		base.GetItem(12).SetUIActive(value);
	}

	// Token: 0x0600B53F RID: 46399 RVA: 0x0030415C File Offset: 0x0030235C
	public UniTask RefreshItemAsync(int itemConfigId, int itemCount = 0)
	{
		CommonItemGrid.<RefreshItemAsync>d__25 <RefreshItemAsync>d__;
		<RefreshItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshItemAsync>d__.<>4__this = this;
		<RefreshItemAsync>d__.itemConfigId = itemConfigId;
		<RefreshItemAsync>d__.itemCount = itemCount;
		<RefreshItemAsync>d__.<>1__state = -1;
		<RefreshItemAsync>d__.<>t__builder.Start<CommonItemGrid.<RefreshItemAsync>d__25>(ref <RefreshItemAsync>d__);
		return <RefreshItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B540 RID: 46400 RVA: 0x003041B0 File Offset: 0x003023B0
	private UniTask UpdateViewAsync()
	{
		CommonItemGrid.<UpdateViewAsync>d__26 <UpdateViewAsync>d__;
		<UpdateViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateViewAsync>d__.<>4__this = this;
		<UpdateViewAsync>d__.<>1__state = -1;
		<UpdateViewAsync>d__.<>t__builder.Start<CommonItemGrid.<UpdateViewAsync>d__26>(ref <UpdateViewAsync>d__);
		return <UpdateViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0400558E RID: 21902
	private int ItemConfigId;

	// Token: 0x0400558F RID: 21903
	private EUiViewName? BelongViewName;

	// Token: 0x04005590 RID: 21904
	[Nullable(1)]
	private Action<int> ClickCallback = delegate(int itemConfigId)
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemConfigId, true, null);
	};

	// Token: 0x02007C2A RID: 31786
	private enum EChildComponentType
	{
		// Token: 0x0402A687 RID: 173703
		ToggleClick,
		// Token: 0x0402A688 RID: 173704
		PanelItem,
		// Token: 0x0402A689 RID: 173705
		PanelEmpty,
		// Token: 0x0402A68A RID: 173706
		TextureIcon,
		// Token: 0x0402A68B RID: 173707
		SpriteQuality,
		// Token: 0x0402A68C RID: 173708
		PanelLock,
		// Token: 0x0402A68D RID: 173709
		TextureRole,
		// Token: 0x0402A68E RID: 173710
		SpriteRoleBg,
		// Token: 0x0402A68F RID: 173711
		TextLevel,
		// Token: 0x0402A690 RID: 173712
		PanelLevel,
		// Token: 0x0402A691 RID: 173713
		TextCount,
		// Token: 0x0402A692 RID: 173714
		TextureMask,
		// Token: 0x0402A693 RID: 173715
		PanelCount,
		// Token: 0x0402A694 RID: 173716
		ReceivedItem
	}
}
