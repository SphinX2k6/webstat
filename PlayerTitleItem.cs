using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020019FF RID: 6655
public class PlayerTitleItem : UiPanelBase
{
	// Token: 0x0600BE75 RID: 48757 RVA: 0x0032686C File Offset: 0x00324A6C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 17;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(12, new Action<EToggleState>(this.OnBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600BE76 RID: 48758 RVA: 0x00326B0C File Offset: 0x00324D0C
	public void Refresh(int? playerTitleId, int? playerTitleStarLevel, int? sex)
	{
		if (playerTitleId == null || playerTitleId.Value == 0)
		{
			base.SetUiActive(false);
			return;
		}
		base.SetUiActive(true);
		this.PlayerTitleConfig = ConfigBase<InventoryConfig>.Instance.GetPlayerTitleItemConfig(playerTitleId.Value);
		if (this.PlayerTitleConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), this.PlayerTitleConfig.Value.TitleName, Array.Empty<object>());
		string titleBgIcon = this.PlayerTitleConfig.Value.TitleBgIcon;
		if (!string.IsNullOrEmpty(titleBgIcon))
		{
			base.SetTextureByPath(titleBgIcon, base.GetTexture(0), null, null);
		}
		string selectedIcon = this.PlayerTitleConfig.Value.SelectedIcon;
		base.SetTextureByPath(selectedIcon, base.GetTexture(10), null, null);
		int titleStyle = this.PlayerTitleConfig.Value.TitleStyle;
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(16);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(1);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		if (titleStyle == 1)
		{
			int? num = sex;
			int num2 = 0;
			this.RefreshCommonTitle(num.GetValueOrDefault() == num2 & num != null);
		}
		else if (titleStyle == 2)
		{
			this.RefreshStarTitle(playerTitleStarLevel);
		}
		this.RefreshDecorate();
	}

	// Token: 0x0600BE77 RID: 48759 RVA: 0x00326C70 File Offset: 0x00324E70
	public void RefreshCommonTitle(bool isFemale)
	{
		if (!string.IsNullOrEmpty((this.PlayerTitleConfig != null) ? this.PlayerTitleConfig.GetValueOrDefault().TitleIcon : null))
		{
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			this.SetIconAndColor(this.PlayerTitleConfig.Value.TitleIcon, base.GetTexture(8));
		}
		if (!string.IsNullOrEmpty(this.PlayerTitleConfig.Value.RoleHeadIcon))
		{
			UUIItem item2 = base.GetItem(16);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			string path = this.PlayerTitleConfig.Value.RoleHeadIcon;
			if (isFemale)
			{
				path = this.PlayerTitleConfig.Value.FemaleRoleHeadIcon;
			}
			base.SetTextureByPath(path, base.GetTexture(17), null, null);
		}
	}

	// Token: 0x0600BE78 RID: 48760 RVA: 0x00326D48 File Offset: 0x00324F48
	public void RefreshStarTitle(int? playerTitleStarLevel)
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		this.SetIconAndColor(this.PlayerTitleConfig.Value.TitleIcon, base.GetTexture(6));
		this.SetIconAndColor(this.PlayerTitleConfig.Value.StarTitleBgIcon, base.GetTexture(2));
		this.SetIconAndColor(this.PlayerTitleConfig.Value.StarTitleIcon, base.GetTexture(3));
		UUIText text = base.GetText(4);
		int valueOrDefault = playerTitleStarLevel.GetValueOrDefault();
		if (text != null)
		{
			this.PlayerTitleStarLevel = valueOrDefault;
			text.SetText(valueOrDefault.ToString(), true);
			text.SetColor(FColor.FromHex(PersonalDefine.playerTitleQualityToColor[this.PlayerTitleConfig.Value.TitleQuality]));
		}
	}

	// Token: 0x0600BE79 RID: 48761 RVA: 0x00326E18 File Offset: 0x00325018
	public void RefreshDecorate()
	{
		string decorateLeftNiagara = this.PlayerTitleConfig.Value.DecorateLeftNiagara;
		UUINiagara uiNiagara = base.GetUiNiagara(13);
		if (!string.IsNullOrEmpty(decorateLeftNiagara))
		{
			base.SetNiagaraSystemByPath(decorateLeftNiagara, uiNiagara, null);
			uiNiagara.SetUIActive(true);
		}
		else
		{
			uiNiagara.SetUIActive(false);
		}
		string decorateRightNiagara = this.PlayerTitleConfig.Value.DecorateRightNiagara;
		UUINiagara uiNiagara2 = base.GetUiNiagara(14);
		if (!string.IsNullOrEmpty(decorateRightNiagara))
		{
			base.SetNiagaraSystemByPath(decorateRightNiagara, uiNiagara2, null);
			uiNiagara2.SetUIActive(true);
		}
		else
		{
			uiNiagara2.SetUIActive(false);
		}
		string decorateBgNiagara = this.PlayerTitleConfig.Value.DecorateBgNiagara;
		UUINiagara uiNiagara3 = base.GetUiNiagara(15);
		if (!string.IsNullOrEmpty(decorateBgNiagara))
		{
			base.SetNiagaraSystemByPath(decorateBgNiagara, uiNiagara3, null);
			uiNiagara3.SetUIActive(true);
			return;
		}
		uiNiagara3.SetUIActive(false);
	}

	// Token: 0x0600BE7A RID: 48762 RVA: 0x00326EE8 File Offset: 0x003250E8
	[NullableContext(1)]
	private void SetIconAndColor(string iconPath, UUITexture iconItem)
	{
		base.SetTextureByPath(iconPath, iconItem, null, null);
		int titleQuality = this.PlayerTitleConfig.Value.TitleQuality;
		if (iconItem != null)
		{
			iconItem.SetColor(FColor.FromHex(PersonalDefine.playerTitleQualityToColor[titleQuality]));
		}
	}

	// Token: 0x0600BE7B RID: 48763 RVA: 0x00326F34 File Offset: 0x00325134
	public void SetIsPreview(bool isPreview)
	{
		this.IsPreview = isPreview;
	}

	// Token: 0x0600BE7C RID: 48764 RVA: 0x00326F40 File Offset: 0x00325140
	private void OnBtnClick(EToggleState state)
	{
		if (!this.IsPreview)
		{
			UUIItem item = base.GetItem(11);
			string playerTitleInfoString = ModelBase<PersonalModel>.Instance.GetPlayerTitleInfoString(this.PlayerTitleConfig.Value.Id, this.PlayerTitleStarLevel, false);
			string iconInTitleInfo = this.PlayerTitleConfig.Value.IconInTitleInfo;
			if (this.CanShowTip)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PlayerTitleInfoTip, new PlayerTitleInfoTipParams
				{
					ItemForLocation = item,
					PlayerTitleInfoString = playerTitleInfoString,
					PlayerTitleInfoIcon = iconInTitleInfo
				}, delegate(bool isSuccess, int viewId)
				{
					PlayerTitleInfoTip playerTitleInfoTip = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PlayerTitleInfoTip) as PlayerTitleInfoTip;
					if (playerTitleInfoTip != null)
					{
						playerTitleInfoTip.BindCloseCallback(new Action(this.SetToggleState));
					}
				});
			}
			this.CallBack();
		}
	}

	// Token: 0x0600BE7D RID: 48765 RVA: 0x00326FE2 File Offset: 0x003251E2
	private void SetToggleState()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(12);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0400598E RID: 22926
	private PlayerTitle? PlayerTitleConfig;

	// Token: 0x0400598F RID: 22927
	private bool IsPreview;

	// Token: 0x04005990 RID: 22928
	private int PlayerTitleStarLevel;

	// Token: 0x04005991 RID: 22929
	[Nullable(1)]
	public Action CallBack = delegate()
	{
	};

	// Token: 0x04005992 RID: 22930
	public bool CanShowTip = true;

	// Token: 0x02007CE9 RID: 31977
	private class EPlayerTitleDefine
	{
		// Token: 0x0402A9C0 RID: 174528
		public const int TextureBg = 0;

		// Token: 0x0402A9C1 RID: 174529
		public const int PanelStarTitle = 1;

		// Token: 0x0402A9C2 RID: 174530
		public const int TextureStarBg = 2;

		// Token: 0x0402A9C3 RID: 174531
		public const int TextureStarSmallIcon = 3;

		// Token: 0x0402A9C4 RID: 174532
		public const int TxtStarParam = 4;

		// Token: 0x0402A9C5 RID: 174533
		public const int TextureStarIcon = 6;

		// Token: 0x0402A9C6 RID: 174534
		public const int PanelComTitle = 7;

		// Token: 0x0402A9C7 RID: 174535
		public const int TextureComIcon = 8;

		// Token: 0x0402A9C8 RID: 174536
		public const int TxtName = 9;

		// Token: 0x0402A9C9 RID: 174537
		public const int TextureSelected = 10;

		// Token: 0x0402A9CA RID: 174538
		public const int PanelInfoTip = 11;

		// Token: 0x0402A9CB RID: 174539
		public const int ToggleRoot = 12;

		// Token: 0x0402A9CC RID: 174540
		public const int NiagaraDecorateLeft = 13;

		// Token: 0x0402A9CD RID: 174541
		public const int NiagaraDecorateRight = 14;

		// Token: 0x0402A9CE RID: 174542
		public const int NiagaraBg = 15;

		// Token: 0x0402A9CF RID: 174543
		public const int ItemRoleHeadPanel = 16;

		// Token: 0x0402A9D0 RID: 174544
		public const int TextureRoleHead = 17;
	}
}
