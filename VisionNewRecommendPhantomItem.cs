using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200252D RID: 9517
public class VisionNewRecommendPhantomItem : UiPanelBase
{
	// Token: 0x06012841 RID: 75841 RVA: 0x00519F08 File Offset: 0x00518108
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickPhantomItem))
		};
	}

	// Token: 0x06012842 RID: 75842 RVA: 0x0051A020 File Offset: 0x00518220
	protected override UniTask OnBeforeStartAsync()
	{
		VisionNewRecommendPhantomItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionNewRecommendPhantomItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012843 RID: 75843 RVA: 0x0051A063 File Offset: 0x00518263
	protected override void OnStart()
	{
		base.GetItem(4).SetUIActive(false);
	}

	// Token: 0x06012844 RID: 75844 RVA: 0x0051A072 File Offset: 0x00518272
	public void Reset()
	{
		base.GetItem(0).SetUIActive(false);
	}

	// Token: 0x06012845 RID: 75845 RVA: 0x0051A081 File Offset: 0x00518281
	[NullableContext(1)]
	public void Update(VisionNewRecommendPhantomItemData data)
	{
		this.CurrentData = data;
		base.GetItem(0).SetUIActive(true);
		this.RefreshQualitySprite();
		this.RefreshSuitElement();
		this.RefreshTextureIcon();
		this.RefreshCostText();
		this.RefreshLevelText();
	}

	// Token: 0x06012846 RID: 75846 RVA: 0x0051A0B8 File Offset: 0x005182B8
	private void RefreshQualitySprite()
	{
		PhantomItem? phantomItemById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(this.CurrentData.PhantomId);
		string phantomQualityBgSprite = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityBgSprite(phantomItemById.Value.QualityId);
		this.SetSpriteByPath(phantomQualityBgSprite, base.GetSprite(1), false, null, null);
	}

	// Token: 0x06012847 RID: 75847 RVA: 0x0051A110 File Offset: 0x00518310
	private void RefreshSuitElement()
	{
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(this.CurrentData.FetterGroupId);
		this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupById));
	}

	// Token: 0x06012848 RID: 75848 RVA: 0x0051A144 File Offset: 0x00518344
	private void RefreshTextureIcon()
	{
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.CurrentData.PhantomId);
		base.SetTextureByPath(itemConfigData.IconMiddle, base.GetTexture(2), null, null);
	}

	// Token: 0x06012849 RID: 75849 RVA: 0x0051A184 File Offset: 0x00518384
	private void RefreshCostText()
	{
		base.GetText(7).SetText(this.CurrentData.Cost.ToString(), true);
	}

	// Token: 0x0601284A RID: 75850 RVA: 0x0051A1A3 File Offset: 0x005183A3
	private void RefreshLevelText()
	{
		base.GetText(9).SetText("+" + this.CurrentData.Level.ToString(), true);
	}

	// Token: 0x0601284B RID: 75851 RVA: 0x0051A1D0 File Offset: 0x005183D0
	private void OnClickPhantomItem()
	{
		if (this.CurrentData == null)
		{
			return;
		}
		int phantomId = this.CurrentData.PhantomId;
		int uniqueId = this.CurrentData.UniqueId;
		if (uniqueId > 0)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(uniqueId, phantomId, true, null);
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(phantomId, true, null);
	}

	// Token: 0x0400905A RID: 36954
	[Nullable(2)]
	private VisionNewRecommendPhantomItemData CurrentData;

	// Token: 0x0400905B RID: 36955
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02008854 RID: 34900
	private enum EPhantomItem
	{
		// Token: 0x0402E0C1 RID: 188609
		Item,
		// Token: 0x0402E0C2 RID: 188610
		QualitySprite,
		// Token: 0x0402E0C3 RID: 188611
		TextureIcon,
		// Token: 0x0402E0C4 RID: 188612
		ElementItem,
		// Token: 0x0402E0C5 RID: 188613
		RoleItem,
		// Token: 0x0402E0C6 RID: 188614
		RoleLightSprite,
		// Token: 0x0402E0C7 RID: 188615
		RoleTexture,
		// Token: 0x0402E0C8 RID: 188616
		CostText,
		// Token: 0x0402E0C9 RID: 188617
		Button,
		// Token: 0x0402E0CA RID: 188618
		TextLevel
	}
}
