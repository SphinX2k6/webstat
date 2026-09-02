using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.KeySetting;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200208C RID: 8332
[NullableContext(1)]
[Nullable(0)]
public class CommonKeySettingRowKeyItem : UiPanelBase, IKeySettingItem
{
	// Token: 0x0600FE36 RID: 65078 RVA: 0x0045BE1F File Offset: 0x0045A01F
	public CommonKeySettingRowKeyItem()
	{
		this.Proxy = new KeySettingItemProxy(this);
	}

	// Token: 0x0600FE37 RID: 65079 RVA: 0x0045BE34 File Offset: 0x0045A034
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent))
		};
	}

	// Token: 0x0600FE38 RID: 65080 RVA: 0x0045BF29 File Offset: 0x0045A129
	protected override void OnStart()
	{
		this.Proxy.OnStart();
	}

	// Token: 0x0600FE39 RID: 65081 RVA: 0x0045BF36 File Offset: 0x0045A136
	protected override void OnBeforeDestroy()
	{
		this.Proxy.OnBeforeDestroy();
	}

	// Token: 0x0600FE3A RID: 65082 RVA: 0x0045BF43 File Offset: 0x0045A143
	public void Refresh(KeySettingRowData data, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		this.Proxy.Refresh(data, inputControllerType);
	}

	// Token: 0x0600FE3B RID: 65083 RVA: 0x0045BF52 File Offset: 0x0045A152
	public void SetDetailItemVisible(bool visible)
	{
		this.Proxy.SetDetailItemVisible(visible);
	}

	// Token: 0x0600FE3C RID: 65084 RVA: 0x0045BF60 File Offset: 0x0045A160
	public UUIText GetTitleUiText()
	{
		return base.GetText(0);
	}

	// Token: 0x0600FE3D RID: 65085 RVA: 0x0045BF69 File Offset: 0x0045A169
	public UUIExtendToggle GetKeySetToggle()
	{
		return base.GetExtendToggle(1);
	}

	// Token: 0x0600FE3E RID: 65086 RVA: 0x0045BF72 File Offset: 0x0045A172
	public UUIText GetKeyNameUiText()
	{
		return base.GetText(2);
	}

	// Token: 0x0600FE3F RID: 65087 RVA: 0x0045BF7B File Offset: 0x0045A17B
	public UUIItem GetCursorItem()
	{
		return base.GetItem(8);
	}

	// Token: 0x0600FE40 RID: 65088 RVA: 0x0045BF84 File Offset: 0x0045A184
	public UUIItem GetDetailUiItem()
	{
		return base.GetItem(3);
	}

	// Token: 0x0600FE41 RID: 65089 RVA: 0x0045BF8D File Offset: 0x0045A18D
	public UUIText GetDetailUiText()
	{
		return base.GetText(4);
	}

	// Token: 0x0600FE42 RID: 65090 RVA: 0x0045BF96 File Offset: 0x0045A196
	public UUISprite GetDetailSprite()
	{
		return base.GetSprite(5);
	}

	// Token: 0x0600FE43 RID: 65091 RVA: 0x0045BF9F File Offset: 0x0045A19F
	public UUISprite GetLockSprite()
	{
		return base.GetSprite(6);
	}

	// Token: 0x0600FE44 RID: 65092 RVA: 0x0045BFA8 File Offset: 0x0045A1A8
	public UUISprite GetSelectSprite()
	{
		return base.GetSprite(7);
	}

	// Token: 0x0600FE45 RID: 65093 RVA: 0x0045BFB1 File Offset: 0x0045A1B1
	public UUIButtonComponent GetCancelButton()
	{
		return base.GetButton(9);
	}

	// Token: 0x040079DB RID: 31195
	private readonly KeySettingItemProxy Proxy;

	// Token: 0x0200841B RID: 33819
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402CC58 RID: 183384
		public const int TitleText = 0;

		// Token: 0x0402CC59 RID: 183385
		public const int KeySetToggle = 1;

		// Token: 0x0402CC5A RID: 183386
		public const int KeyNameText = 2;

		// Token: 0x0402CC5B RID: 183387
		public const int DetailItem = 3;

		// Token: 0x0402CC5C RID: 183388
		public const int DetailText = 4;

		// Token: 0x0402CC5D RID: 183389
		public const int DetailArrowSprite = 5;

		// Token: 0x0402CC5E RID: 183390
		public const int LockSprite = 6;

		// Token: 0x0402CC5F RID: 183391
		public const int SelectedSprite = 7;

		// Token: 0x0402CC60 RID: 183392
		public const int CursorItem = 8;

		// Token: 0x0402CC61 RID: 183393
		public const int DisableButton = 9;
	}
}
