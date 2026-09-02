using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001971 RID: 6513
[NullableContext(2)]
[Nullable(0)]
public class ItemGridVariantSelect : ItemGridAbstract, IItemGrid, IItemGridVariantOne, IItemGridVariantSelect
{
	// Token: 0x0600BB21 RID: 47905 RVA: 0x0031C062 File Offset: 0x0031A262
	public ItemGridVariantSelect(AActor commonItemActor = null, ItemGridAbstract source = null, EUiViewName? belongView = null) : base(commonItemActor, source, belongView)
	{
	}

	// Token: 0x17000F2A RID: 3882
	// (get) Token: 0x0600BB22 RID: 47906 RVA: 0x0031C082 File Offset: 0x0031A282
	public bool IsItemGridVariantOne { get; } = 1;

	// Token: 0x17000F2B RID: 3883
	// (get) Token: 0x0600BB23 RID: 47907 RVA: 0x0031C08A File Offset: 0x0031A28A
	public bool IsItemGrid { get; } = 1;

	// Token: 0x17000F2C RID: 3884
	// (get) Token: 0x0600BB24 RID: 47908 RVA: 0x0031C092 File Offset: 0x0031A292
	public bool IsItemGridVariantSelect { get; } = 1;

	// Token: 0x0600BB25 RID: 47909 RVA: 0x0031C09A File Offset: 0x0031A29A
	public void RefreshItemShowState(bool showState)
	{
		base.GetItem(0).SetUIActive(showState);
	}

	// Token: 0x0600BB26 RID: 47910 RVA: 0x0031C0AC File Offset: 0x0031A2AC
	public void RefreshReduceButtonShowState(bool showState)
	{
		base.GetButton(4).RootUIComp.Get().SetUIActive(showState);
	}

	// Token: 0x0600BB27 RID: 47911 RVA: 0x0031C0D3 File Offset: 0x0031A2D3
	public UUIItem GetFinishSelectItem()
	{
		return base.GetItem(1);
	}

	// Token: 0x0600BB28 RID: 47912 RVA: 0x0031C0DC File Offset: 0x0031A2DC
	public UUIItem GetFinishMiddleItem()
	{
		return base.GetItem(2);
	}

	// Token: 0x0600BB29 RID: 47913 RVA: 0x0031C0E5 File Offset: 0x0031A2E5
	public UUIItem GetControlItem()
	{
		return base.GetItem(3);
	}

	// Token: 0x0600BB2A RID: 47914 RVA: 0x0031C0EE File Offset: 0x0031A2EE
	public UUIButtonComponent GetReduceButton()
	{
		return base.GetButton(4);
	}

	// Token: 0x0600BB2B RID: 47915 RVA: 0x0031C0F7 File Offset: 0x0031A2F7
	public UUIButtonComponent GetAddButton()
	{
		return base.GetButton(5);
	}

	// Token: 0x0600BB2C RID: 47916 RVA: 0x0031C100 File Offset: 0x0031A300
	[NullableContext(1)]
	public void SetAddButtonCallBack(Action call)
	{
		this.OnClickAddButtonCall = call;
	}

	// Token: 0x0600BB2D RID: 47917 RVA: 0x0031C10C File Offset: 0x0031A30C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickAddButton)),
			new ValueTuple<int, Delegate>(4, new Action(delegate()
			{
				Action onClickReduceButtonCall = this.OnClickReduceButtonCall;
				if (onClickReduceButtonCall == null)
				{
					return;
				}
				onClickReduceButtonCall();
			}))
		};
	}

	// Token: 0x0600BB2E RID: 47918 RVA: 0x0031C1E3 File Offset: 0x0031A3E3
	protected override void OnStart()
	{
		this.ItemGridVariantOne = new ItemGridVariantOne(base.GetItem(0).GetOwner(), this, new EUiViewName?(base.GetBelongView()));
		this.RefreshReduceButtonShowState(false);
	}

	// Token: 0x0600BB2F RID: 47919 RVA: 0x0031C20F File Offset: 0x0031A40F
	private void OnClickAddButton()
	{
		Action onClickAddButtonCall = this.OnClickAddButtonCall;
		if (onClickAddButtonCall == null)
		{
			return;
		}
		onClickAddButtonCall();
	}

	// Token: 0x0600BB30 RID: 47920 RVA: 0x0031C221 File Offset: 0x0031A421
	public void RefreshQualitySprite()
	{
		this.ItemGridVariantOne.RefreshQualitySprite();
	}

	// Token: 0x0600BB31 RID: 47921 RVA: 0x0031C22E File Offset: 0x0031A42E
	public void RefreshTextureIcon()
	{
		this.ItemGridVariantOne.RefreshTextureIcon();
	}

	// Token: 0x0600BB32 RID: 47922 RVA: 0x0031C23B File Offset: 0x0031A43B
	[NullableContext(1)]
	public void RefreshTextDown(bool showState, string text)
	{
		this.ItemGridVariantOne.RefreshTextDown(showState, text);
	}

	// Token: 0x0600BB33 RID: 47923 RVA: 0x0031C24A File Offset: 0x0031A44A
	[NullableContext(1)]
	public void RefreshTextDownByTextId(bool showState, string text, params object[] args)
	{
		this.ItemGridVariantOne.RefreshTextDownByTextId(showState, text, args);
	}

	// Token: 0x0600BB34 RID: 47924 RVA: 0x0031C25A File Offset: 0x0031A45A
	[NullableContext(1)]
	public void SetReduceClickEvent(Action call)
	{
		this.OnClickReduceButtonCall = call;
	}

	// Token: 0x0600BB35 RID: 47925 RVA: 0x0031C263 File Offset: 0x0031A463
	[NullableContext(1)]
	public void SetToggleClickEvent(Action<int, ItemConfig> call)
	{
		this.ItemGridVariantOne.SetToggleClickEvent(call);
	}

	// Token: 0x0600BB36 RID: 47926 RVA: 0x0031C271 File Offset: 0x0031A471
	[NullableContext(1)]
	public void SetToggleClickStateEvent(Action<EToggleState> call)
	{
		this.ItemGridVariantOne.SetToggleClickStateEvent(call);
	}

	// Token: 0x0600BB37 RID: 47927 RVA: 0x0031C27F File Offset: 0x0031A47F
	public void BindRedPointWithKeyAndId(ERedDotName name, int uid)
	{
		this.ItemGridVariantOne.BindRedPointWithKeyAndId(name, uid);
	}

	// Token: 0x0600BB38 RID: 47928 RVA: 0x0031C28E File Offset: 0x0031A48E
	[NullableContext(1)]
	public void RefreshCdPanel(bool showState, float cdFillAmount, string cdText)
	{
		this.ItemGridVariantOne.RefreshCdPanel(showState, cdFillAmount, cdText);
	}

	// Token: 0x0600BB39 RID: 47929 RVA: 0x0031C29E File Offset: 0x0031A49E
	public void RefreshDarkSprite(bool showState)
	{
		this.ItemGridVariantOne.RefreshDarkSprite(showState);
	}

	// Token: 0x0600BB3A RID: 47930 RVA: 0x0031C2AC File Offset: 0x0031A4AC
	public void RefreshLockSprite(bool showState)
	{
		this.ItemGridVariantOne.RefreshLockSprite(showState);
	}

	// Token: 0x0600BB3B RID: 47931 RVA: 0x0031C2BA File Offset: 0x0031A4BA
	[NullableContext(1)]
	public void RefreshStar(int[] starNum)
	{
		this.ItemGridVariantOne.RefreshStar(starNum);
	}

	// Token: 0x0600BB3C RID: 47932 RVA: 0x0031C2C8 File Offset: 0x0031A4C8
	public void RefreshRecoverSprite(bool showState)
	{
		this.ItemGridVariantOne.RefreshRecoverSprite(showState);
	}

	// Token: 0x0600BB3D RID: 47933 RVA: 0x0031C2D6 File Offset: 0x0031A4D6
	public void RefreshRightDownLockSprite(bool showState)
	{
		this.ItemGridVariantOne.RefreshRightDownLockSprite(showState);
	}

	// Token: 0x0600BB3E RID: 47934 RVA: 0x0031C2E4 File Offset: 0x0031A4E4
	[NullableContext(1)]
	public void RefreshUpgradePanel(bool showState, string showText)
	{
		this.ItemGridVariantOne.RefreshUpgradePanel(showState, showText);
	}

	// Token: 0x0600BB3F RID: 47935 RVA: 0x0031C2F3 File Offset: 0x0031A4F3
	public UUIExtendToggle GetClickToggle()
	{
		return this.ItemGridVariantOne.GetClickToggle();
	}

	// Token: 0x0600BB40 RID: 47936 RVA: 0x0031C300 File Offset: 0x0031A500
	public UUIText GetDownText()
	{
		return this.ItemGridVariantOne.GetDownText();
	}

	// Token: 0x0600BB41 RID: 47937 RVA: 0x0031C30D File Offset: 0x0031A50D
	public int GetConfigId()
	{
		return base.GetItemId();
	}

	// Token: 0x0600BB42 RID: 47938 RVA: 0x0031C315 File Offset: 0x0031A515
	protected override void OnBeforeDestroy()
	{
		this.ItemGridVariantOne.Destroy(null);
	}

	// Token: 0x04005871 RID: 22641
	private Action OnClickAddButtonCall;

	// Token: 0x04005872 RID: 22642
	private Action OnClickReduceButtonCall;

	// Token: 0x04005873 RID: 22643
	private ItemGridVariantOne ItemGridVariantOne;

	// Token: 0x02007C89 RID: 31881
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A873 RID: 174195
		ItemGridVariantOne,
		// Token: 0x0402A874 RID: 174196
		FinishSelectItem,
		// Token: 0x0402A875 RID: 174197
		FinishMiddleItem,
		// Token: 0x0402A876 RID: 174198
		ControlItem,
		// Token: 0x0402A877 RID: 174199
		ReduceButton,
		// Token: 0x0402A878 RID: 174200
		AddButton
	}
}
