using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001808 RID: 6152
public class VisionRecoveryDirectionalFusionItem : UiPanelBase
{
	// Token: 0x0600AEE8 RID: 44776 RVA: 0x002E9628 File Offset: 0x002E7828
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton))
		};
	}

	// Token: 0x0600AEE9 RID: 44777 RVA: 0x002E96BC File Offset: 0x002E78BC
	public void RefreshItem()
	{
		UUITexture texture = base.GetTexture(2);
		UUIText text = base.GetText(3);
		int directionalFusionTargetFetterGroup = ModelBase<CalabashModel>.Instance.DirectionalFusionTargetFetterGroup;
		if (directionalFusionTargetFetterGroup == 0)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_IconElementAttriNone");
			base.SetTextureByPath(resourcePath, texture, null, null);
			text.SetUIActive(false);
			return;
		}
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(directionalFusionTargetFetterGroup);
		string aimModelElementPath = fetterGroupById.AimModelElementPath;
		if (string.IsNullOrEmpty(aimModelElementPath))
		{
			return;
		}
		text.SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, fetterGroupById.FetterGroupName, Array.Empty<object>());
		base.SetTextureByPath(aimModelElementPath, texture, null, null);
	}

	// Token: 0x0600AEEA RID: 44778 RVA: 0x002E9765 File Offset: 0x002E7965
	private void OnClickButton()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.VisionDirectionalFusionSelectTargetView))
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionDirectionalFusionSelectTargetView, null, null);
	}

	// Token: 0x02007B7E RID: 31614
	private enum EComponent
	{
		// Token: 0x0402A35B RID: 172891
		Button,
		// Token: 0x0402A35C RID: 172892
		BgSprite,
		// Token: 0x0402A35D RID: 172893
		IconTexture,
		// Token: 0x0402A35E RID: 172894
		NameText
	}
}
