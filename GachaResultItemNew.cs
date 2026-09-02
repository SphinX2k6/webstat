using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D03 RID: 7427
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GachaResultItemNew : GridProxyAbstract<global::GachaResult>
{
	// Token: 0x0600DA06 RID: 55814 RVA: 0x003A7AFC File Offset: 0x003A5CFC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(11, typeof(UUINiagara))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnPreviewBtnClick))
		};
	}

	// Token: 0x0600DA07 RID: 55815 RVA: 0x003A7C44 File Offset: 0x003A5E44
	protected override UniTask OnBeforeStartAsync()
	{
		GachaResultItemNew.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GachaResultItemNew.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DA08 RID: 55816 RVA: 0x003A7C88 File Offset: 0x003A5E88
	private unsafe void OnPreviewBtnClick()
	{
		InventoryDefine.EItemDataType itemIdType = ConfigBase<GachaConfig>.Instance.GetItemIdType(this.ItemId);
		if (itemIdType == InventoryDefine.EItemDataType.RoleItem)
		{
			RoleController instance = ControllerBase<RoleController>.Instance;
			ERoleAgentType agentType = ERoleAgentType.Preview;
			int trialId = this.TrialId;
			int num = 1;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount<int>(list, num);
			Span<int> span = CollectionsMarshal.AsSpan<int>(list);
			int index = 0;
			*span[index] = this.TrialId;
			instance.OpenRoleMainView(agentType, trialId, list, null, null);
			return;
		}
		if (itemIdType != InventoryDefine.EItemDataType.WeaponItem)
		{
			return;
		}
		if (this.TrialId > 0)
		{
			WeaponTrialData weaponTrialData = new WeaponTrialData();
			weaponTrialData.SetTrialId(this.TrialId, true);
			IWeaponPreviewViewParam param = new WeaponPreviewViewParam
			{
				WeaponDataList = new WeaponDataBase[]
				{
					weaponTrialData
				},
				SelectedIndex = 0
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponPreviewView, param, null);
		}
	}

	// Token: 0x0600DA09 RID: 55817 RVA: 0x003A7D48 File Offset: 0x003A5F48
	public void UpdateQuality(int quality)
	{
		for (int i = 0; i < quality - 1; i++)
		{
			Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(10), base.GetItem(9));
		}
		QualityInfo? qualityConfig = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetQualityConfig(quality);
		if (qualityConfig == null)
		{
			return;
		}
		string gachaQualityTexture = qualityConfig.Value.GachaQualityTexture;
		if (!string.IsNullOrEmpty(gachaQualityTexture))
		{
			this.SetSpriteByPath(gachaQualityTexture, base.GetSprite(1), true, new EUiViewName?(EUiViewName.GachaResultView), null);
		}
		string gachaBgTexture = qualityConfig.Value.GachaBgTexture;
		if (!string.IsNullOrEmpty(gachaBgTexture))
		{
			this.SetSpriteByPath(gachaBgTexture, base.GetSprite(0), true, new EUiViewName?(EUiViewName.GachaResultView), null);
		}
		string text = null;
		if (quality != 4)
		{
			if (quality == 5)
			{
				text = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("NS_Fx_LGUI_GachaResultGold");
			}
		}
		else
		{
			text = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("NS_Fx_LGUI_GachaResultPurple");
		}
		UUINiagara uiNiagara = base.GetUiNiagara(11);
		if (!string.IsNullOrEmpty(text))
		{
			uiNiagara.SetUIActive(true);
			base.SetNiagaraSystemByPath(text, uiNiagara, null);
			return;
		}
		uiNiagara.SetUIActive(false);
	}

	// Token: 0x0600DA0A RID: 55818 RVA: 0x003A7E5C File Offset: 0x003A605C
	public void Update(global::GachaResult data)
	{
		int itemId = data.Proto_GachaReward.ItemId;
		this.ItemId = itemId;
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
		if (itemConfigData == null)
		{
			return;
		}
		GachaTextureInfo? gachaTextureInfo = ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(itemId);
		if (gachaTextureInfo == null)
		{
			return;
		}
		this.TrialId = gachaTextureInfo.Value.TrialId;
		IReadOnlyList<GachaReward> proto_TransformRewards = data.Proto_TransformRewards;
		if (proto_TransformRewards != null && proto_TransformRewards.Count > 0)
		{
			base.GetItem(6).SetUIActive(true);
			GachaReward gachaReward = proto_TransformRewards[0];
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = gachaReward.ItemId,
				QualityId = new int?(0),
				ItemConfigId = new int?(gachaReward.ItemId),
				BottomText = gachaReward.ItemCount.ToString()
			};
			SmallItemGrid convertItem = this.ConvertItem;
			if (convertItem != null)
			{
				convertItem.Apply<PropSmallItemGrid>(parameters);
			}
			SmallItemGrid convertItem2 = this.ConvertItem;
			if (convertItem2 != null)
			{
				convertItem2.SetBottomTextVisible(gachaReward.ItemCount > 1);
			}
		}
		else
		{
			SmallItemGrid convertItem3 = this.ConvertItem;
			if (convertItem3 != null)
			{
				convertItem3.SetUiActive(false);
			}
			base.GetItem(6).SetUIActive(!data.IsNew);
		}
		InventoryDefine.EItemDataType itemIdType = ConfigBase<GachaConfig>.Instance.GetItemIdType(itemId);
		int quality = 0;
		if (itemIdType != InventoryDefine.EItemDataType.RoleItem)
		{
			if (itemIdType != InventoryDefine.EItemDataType.WeaponItem)
			{
			}
			base.GetItem(3).SetUIActive(true);
			WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId);
			if (weaponConfigByItemId != null)
			{
				GachaWeaponTransform? gachaWeaponTransformConfig = ConfigBase<GachaConfig>.Instance.GetGachaWeaponTransformConfig(weaponConfigByItemId.Value.WeaponType);
				if (gachaWeaponTransformConfig != null)
				{
					base.SetTextureByPath(gachaWeaponTransformConfig.Value.WeaponTypeTexture, base.GetTexture(4), null, null);
				}
				quality = itemConfigData.QualityId;
				base.GetItem(5).SetUIActive(data.IsNew);
				base.GetItem(6).SetUIActive(false);
			}
		}
		else
		{
			base.GetItem(3).SetUIActive(true);
			RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(itemId);
			if (roleInfoById != null)
			{
				object obj = ConfigBase<CommonConfig>.Instance.GetElementConfig(roleInfoById.Value.ElementId);
				if (obj != null)
				{
					ElementInfo elementInfo = (ElementInfo)obj;
					UUITexture texture = base.GetTexture(4);
					base.SetTextureByPath(elementInfo.Icon, texture, null, null);
					FColor color = FColor.FromHex(elementInfo.ElementColor);
					texture.SetColor(color);
				}
				quality = roleInfoById.Value.QualityId;
				base.GetItem(5).SetUIActive(data.IsNew);
			}
		}
		this.UpdateQuality(quality);
		base.SetTextureByPath(gachaTextureInfo.Value.GachaResultViewTexture, base.GetTexture(8), new EUiViewName?(EUiViewName.GachaResultView), null);
	}

	// Token: 0x0600DA0B RID: 55819 RVA: 0x003A812E File Offset: 0x003A632E
	public override void Refresh(global::GachaResult data, bool isSelected, int gridIndex)
	{
		this.Update(data);
	}

	// Token: 0x0600DA0C RID: 55820 RVA: 0x003A8137 File Offset: 0x003A6337
	public void RefreshShare()
	{
		base.GetItem(5).SetUIActive(false);
		base.GetItem(6).SetUIActive(false);
	}

	// Token: 0x0400680C RID: 26636
	private int ItemId;

	// Token: 0x0400680D RID: 26637
	private int TrialId;

	// Token: 0x0400680E RID: 26638
	[Nullable(2)]
	private SmallItemGrid ConvertItem;

	// Token: 0x0200806D RID: 32877
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402BAEF RID: 178927
		QualityBgSprite,
		// Token: 0x0402BAF0 RID: 178928
		QualitySprite,
		// Token: 0x0402BAF1 RID: 178929
		PreviewBtn,
		// Token: 0x0402BAF2 RID: 178930
		AttributeRootItem,
		// Token: 0x0402BAF3 RID: 178931
		AttributeTexture,
		// Token: 0x0402BAF4 RID: 178932
		NewItemTips,
		// Token: 0x0402BAF5 RID: 178933
		ConvertRootItem,
		// Token: 0x0402BAF6 RID: 178934
		ConvertItem,
		// Token: 0x0402BAF7 RID: 178935
		ItemTexture,
		// Token: 0x0402BAF8 RID: 178936
		StarRootItem,
		// Token: 0x0402BAF9 RID: 178937
		StarItem,
		// Token: 0x0402BAFA RID: 178938
		QualityNiagara
	}
}
