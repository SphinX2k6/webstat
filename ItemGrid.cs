using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001968 RID: 6504
[NullableContext(1)]
[Nullable(0)]
public class ItemGrid : ItemGridAbstract, IItemGrid
{
	// Token: 0x0600BAC8 RID: 47816 RVA: 0x0031B75C File Offset: 0x0031995C
	[NullableContext(2)]
	public ItemGrid(AActor commonItemActor = null, ItemGridAbstract source = null, EUiViewName? belongView = null) : base(commonItemActor, source, belongView)
	{
	}

	// Token: 0x17000F24 RID: 3876
	// (get) Token: 0x0600BAC9 RID: 47817 RVA: 0x0031B76E File Offset: 0x0031996E
	public bool IsItemGrid { get; } = 1;

	// Token: 0x0600BACA RID: 47818 RVA: 0x0031B778 File Offset: 0x00319978
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUISprite)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUISprite)),
			new ValueTuple<int, Type>(11, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.ClickToggle))
		};
	}

	// Token: 0x0600BACB RID: 47819 RVA: 0x0031B8C0 File Offset: 0x00319AC0
	private void ClickToggle(EToggleState toggleState)
	{
		if (this.ToggleClickCall == null && this.ToggleClickStateCall == null)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(base.GetItemId(), true, null);
			return;
		}
		EToggleState toggleState2 = this.GetClickToggle().ToggleState;
		Action<int, CSharpScript.Game.Module.Inventory.ItemConfig> toggleClickCall = this.ToggleClickCall;
		if (toggleClickCall != null)
		{
			toggleClickCall(base.GetItemId(), base.GetItemConfig());
		}
		Action<EToggleState> toggleClickStateCall = this.ToggleClickStateCall;
		if (toggleClickStateCall == null)
		{
			return;
		}
		toggleClickStateCall(toggleState2);
	}

	// Token: 0x0600BACC RID: 47820 RVA: 0x0031B92A File Offset: 0x00319B2A
	[NullableContext(2)]
	public UUIExtendToggle GetClickToggle()
	{
		return base.GetExtendToggle(4);
	}

	// Token: 0x0600BACD RID: 47821 RVA: 0x0031B933 File Offset: 0x00319B33
	[NullableContext(2)]
	public UUIText GetDownText()
	{
		return base.GetText(2);
	}

	// Token: 0x0600BACE RID: 47822 RVA: 0x0031B93C File Offset: 0x00319B3C
	public void RefreshQualitySprite()
	{
		string backgroundSprite = ConfigQualityInfoById.GetConfig(base.GetItemConfig().QualityId, true).Value.BackgroundSprite;
		this.SetSpriteByPath(backgroundSprite, base.GetSprite(0), false, new EUiViewName?(base.GetBelongView()), null);
	}

	// Token: 0x0600BACF RID: 47823 RVA: 0x0031B986 File Offset: 0x00319B86
	public void RefreshTextureByPath(string path)
	{
		base.SetTextureByPath(path, base.GetTexture(1), new EUiViewName?(base.GetBelongView()), null);
	}

	// Token: 0x0600BAD0 RID: 47824 RVA: 0x0031B9A2 File Offset: 0x00319BA2
	public void RefreshTextureIcon()
	{
		base.SetTextureByPath(base.GetItemConfig().Icon, base.GetTexture(1), new EUiViewName?(base.GetBelongView()), null);
	}

	// Token: 0x0600BAD1 RID: 47825 RVA: 0x0031B9C8 File Offset: 0x00319BC8
	public void RefreshTextDown(bool showState, string text)
	{
		base.GetItem(3).SetUIActive(showState);
		if (showState)
		{
			base.GetText(2).SetText(text, true);
		}
	}

	// Token: 0x0600BAD2 RID: 47826 RVA: 0x0031B9E8 File Offset: 0x00319BE8
	public void RefreshTextDownByTextId(bool showState, string textId, params object[] args)
	{
		base.GetItem(3).SetUIActive(showState);
		if (showState)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textId, args);
		}
	}

	// Token: 0x0600BAD3 RID: 47827 RVA: 0x0031BA0D File Offset: 0x00319C0D
	public void SetToggleClickEvent(Action<int, CSharpScript.Game.Module.Inventory.ItemConfig> call)
	{
		this.ToggleClickCall = call;
	}

	// Token: 0x0600BAD4 RID: 47828 RVA: 0x0031BA16 File Offset: 0x00319C16
	public void RefreshNewItem(bool state)
	{
		base.GetItem(5).SetUIActive(state);
	}

	// Token: 0x0600BAD5 RID: 47829 RVA: 0x0031BA25 File Offset: 0x00319C25
	public void SetToggleClickStateEvent(Action<EToggleState> call)
	{
		this.ToggleClickStateCall = call;
	}

	// Token: 0x0600BAD6 RID: 47830 RVA: 0x0031BA2E File Offset: 0x00319C2E
	public void BindRedPointWithKeyAndId(ERedDotName name, int uid)
	{
		this.ClearCurrentRedDot();
		this.CurrentRedDotEventName = new ERedDotName?(name);
		this.CurrentRedDotUid = uid;
		ControllerBase<RedDotController>.Instance.BindRedDot(name, base.GetItem(6), null, uid);
	}

	// Token: 0x0600BAD7 RID: 47831 RVA: 0x0031BA5D File Offset: 0x00319C5D
	private void ClearCurrentRedDot()
	{
		if (this.CurrentRedDotEventName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.CurrentRedDotEventName.Value, base.GetItem(6), this.CurrentRedDotUid);
		}
	}

	// Token: 0x0600BAD8 RID: 47832 RVA: 0x0031BA8E File Offset: 0x00319C8E
	public void RefreshCdPanel(bool showState, float cdFillAmount, string cdText)
	{
		base.GetItem(7).SetUIActive(showState);
		if (showState)
		{
			base.GetSprite(8).SetFillAmount(cdFillAmount);
			base.GetText(9).SetText(cdText, true);
		}
	}

	// Token: 0x0600BAD9 RID: 47833 RVA: 0x0031BABC File Offset: 0x00319CBC
	public void RefreshDarkSprite(bool showState)
	{
		base.GetSprite(10).SetUIActive(showState);
	}

	// Token: 0x0600BADA RID: 47834 RVA: 0x0031BACC File Offset: 0x00319CCC
	public void RefreshLockSprite(bool showState)
	{
		base.GetSprite(11).SetUIActive(showState);
	}

	// Token: 0x0600BADB RID: 47835 RVA: 0x0031BADC File Offset: 0x00319CDC
	protected override void OnBeforeDestroy()
	{
		this.ClearCurrentRedDot();
	}

	// Token: 0x0400585B RID: 22619
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, CSharpScript.Game.Module.Inventory.ItemConfig> ToggleClickCall;

	// Token: 0x0400585C RID: 22620
	[Nullable(2)]
	private Action<EToggleState> ToggleClickStateCall;

	// Token: 0x0400585D RID: 22621
	private ERedDotName? CurrentRedDotEventName;

	// Token: 0x0400585E RID: 22622
	private int CurrentRedDotUid;

	// Token: 0x02007C86 RID: 31878
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A85B RID: 174171
		SpriteQuality,
		// Token: 0x0402A85C RID: 174172
		TextureIcon,
		// Token: 0x0402A85D RID: 174173
		TextDown,
		// Token: 0x0402A85E RID: 174174
		TextPanel,
		// Token: 0x0402A85F RID: 174175
		ToggleClick,
		// Token: 0x0402A860 RID: 174176
		NewItem,
		// Token: 0x0402A861 RID: 174177
		RedPointItem,
		// Token: 0x0402A862 RID: 174178
		CdPanel,
		// Token: 0x0402A863 RID: 174179
		CdBar,
		// Token: 0x0402A864 RID: 174180
		CdText,
		// Token: 0x0402A865 RID: 174181
		DarkSprite,
		// Token: 0x0402A866 RID: 174182
		LockSprite
	}
}
