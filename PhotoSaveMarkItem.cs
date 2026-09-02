using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020025E6 RID: 9702
public class PhotoSaveMarkItem : UiPanelBase
{
	// Token: 0x06012FF5 RID: 77813 RVA: 0x00542318 File Offset: 0x00540518
	protected override void OnRegisterComponent()
	{
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		if (!string.IsNullOrEmpty(this.DateText))
		{
			list.Add(new ValueTuple<int, Type>(3, typeof(UUIText)));
		}
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06012FF6 RID: 77814 RVA: 0x00542398 File Offset: 0x00540598
	protected override void OnStart()
	{
		string logoPathByLanguage = ConfigBase<UiResourceConfig>.Instance.GetLogoPathByLanguage(this.LogoConfigName);
		UUITexture logoTexture = base.GetTexture(0);
		logoTexture.SetUIActive(false);
		base.SetTextureByPath(logoPathByLanguage, base.GetTexture(0), null, delegate(bool _)
		{
			if (logoTexture == null)
			{
				return;
			}
			logoTexture.SetUIActive(true);
			logoTexture.SetSizeFromTexture();
		});
		base.GetText(1).SetText(ModelBase<FunctionModel>.Instance.GetPlayerName() ?? "", true);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "FriendMyUid", new <>z__ReadOnlySingleElementList<object>(ModelBase<FunctionModel>.Instance.PlayerId));
		UUIText text = base.GetText(3);
		if (!string.IsNullOrEmpty(this.DateText) && text != null)
		{
			text.SetText(this.DateText, true);
		}
	}

	// Token: 0x06012FF7 RID: 77815 RVA: 0x00542468 File Offset: 0x00540668
	protected override void OnAfterShow()
	{
		bool global = LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.PhotoAndShareShowPlayerName, true);
		base.SetUiActive(global);
	}

	// Token: 0x04009427 RID: 37927
	[Nullable(2)]
	public string DateText;

	// Token: 0x04009428 RID: 37928
	[Nullable(1)]
	public string LogoConfigName = "PhotoLogo";

	// Token: 0x0200895F RID: 35167
	private enum EChildType
	{
		// Token: 0x0402E5A3 RID: 189859
		LogoTexture,
		// Token: 0x0402E5A4 RID: 189860
		PlayerNameText,
		// Token: 0x0402E5A5 RID: 189861
		PlayerUidText,
		// Token: 0x0402E5A6 RID: 189862
		DateText
	}
}
