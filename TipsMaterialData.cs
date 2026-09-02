using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

// Token: 0x02001986 RID: 6534
[NullableContext(1)]
[Nullable(0)]
public class TipsMaterialData : ItemTipsData
{
	// Token: 0x0600BBDF RID: 48095 RVA: 0x0031DC9C File Offset: 0x0031BE9C
	public TipsMaterialData(ItemTipsParam data) : base(data)
	{
		this.ItemType = EItemTipsType.Normal;
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ConfigId);
		this.MaterialType = itemConfigData.TypeDescription;
		this.ItemConfigType = itemConfigData.ItemType;
		this.FunctionSpritePath = this.GetItemBuffIconPathByBuffType(new EMediumItemGridBuffType?((EMediumItemGridBuffType)itemConfigData.ItemBuffType));
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ConfigId, this.IncId);
		this.Num = itemCountByConfigId;
		this.TxtEffect = itemConfigData.AttributesDescription;
		this.TxtEffectArgs = itemConfigData.AttributesDescriptionArgs;
		this.TxtDescription = itemConfigData.BgDescription;
		if (itemConfigData.ExpiredConvertItemMap.Count > 0)
		{
			using (Dictionary<int, int>.Enumerator enumerator = itemConfigData.ExpiredConvertItemMap.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<int, int> keyValuePair = enumerator.Current;
					CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(keyValuePair.Key);
					this.ExTxtDescription = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("AutoConvertText_ItemDes", null), new string[]
					{
						keyValuePair.Value.ToString(),
						ConfigMultiTextLang.GetLocalTextNew(itemConfigData2.Name, null)
					});
				}
			}
		}
		CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(this.ConfigId, this.IncId);
		if (commonItemData != null && commonItemData.IsLimitTimeItem())
		{
			long endTime = commonItemData.GetEndTime();
			DateTime dataFromTimeStamp = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp((double)endTime * Singleton<TimeUtil>.Instance.Millisecond);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Text_ItemExpired_text", null);
			this.LimitTimeTxt = StringUtils.Format(localTextNew, new string[]
			{
				dataFromTimeStamp.Month.ToString(),
				dataFromTimeStamp.Day.ToString(),
				dataFromTimeStamp.Hour.ToString() + ":" + dataFromTimeStamp.Minute.ToString()
			});
		}
		this.TryApplyConsoleExtraPayGiftPreview();
	}

	// Token: 0x0600BBE0 RID: 48096 RVA: 0x0031DEA8 File Offset: 0x0031C0A8
	private void TryApplyConsoleExtraPayGiftPreview()
	{
		PayShopModel instance = ModelBase<PayShopModel>.Instance;
		IPreviewPayGiftEntry previewPayGiftEntry = (instance != null) ? instance.TryGetPreviewPayGiftEntry(this.ConfigId) : null;
		if (previewPayGiftEntry == null)
		{
			return;
		}
		if (this.LimitTimeTxt == null && previewPayGiftEntry.EndStampSec > 0L)
		{
			DateTime dataFromTimeStamp = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp((double)previewPayGiftEntry.EndStampSec);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Text_ItemExpired_text", null);
			this.LimitTimeTxt = StringUtils.Format(localTextNew, new string[]
			{
				dataFromTimeStamp.Month.ToString(),
				dataFromTimeStamp.Day.ToString(),
				dataFromTimeStamp.Hour.ToString() + ":" + dataFromTimeStamp.Minute.ToString()
			});
		}
		if (!StringUtils.IsEmpty(previewPayGiftEntry.Title))
		{
			this.Title = previewPayGiftEntry.Title;
		}
		if (!StringUtils.IsEmpty(previewPayGiftEntry.RewardListDesc))
		{
			this.TxtEffect = previewPayGiftEntry.RewardListDesc;
			this.TxtDescription = "";
		}
		this.EffectAutoLocalText = false;
		this.Num = 1;
	}

	// Token: 0x0600BBE1 RID: 48097 RVA: 0x0031DFB0 File Offset: 0x0031C1B0
	[NullableContext(2)]
	private string GetItemBuffIconPathByBuffType(EMediumItemGridBuffType? buffIconType)
	{
		MediumItemGridModel instance = ModelBase<MediumItemGridModel>.Instance;
		if (buffIconType != null)
		{
			switch (buffIconType.GetValueOrDefault())
			{
			case EMediumItemGridBuffType.Attack:
				return instance.AttackBuffSpritePath;
			case EMediumItemGridBuffType.Defense:
				return instance.DefenseBuffSpritePath;
			case EMediumItemGridBuffType.RestoreHealth:
				return instance.RestoreHealthBuffSpritePath;
			case EMediumItemGridBuffType.Recharge:
				return instance.RechargeBuffSpritePath;
			case EMediumItemGridBuffType.Resurrection:
				return instance.ResurrectionBuffSpritePath;
			case EMediumItemGridBuffType.Explore:
				return instance.ExploreBuffSpritePath;
			}
		}
		return null;
	}

	// Token: 0x0600BBE2 RID: 48098 RVA: 0x0031E023 File Offset: 0x0031C223
	protected override bool OnIsShowIconBig()
	{
		return this.ItemConfigType.GetValueOrDefault() == InventoryDefine.EItemType.Phantom || this.ItemConfigType.GetValueOrDefault() == InventoryDefine.EItemType.MotorFrame || this.ItemConfigType.GetValueOrDefault() == InventoryDefine.EItemType.MotorSkin;
	}

	// Token: 0x040058D0 RID: 22736
	public string MaterialType;

	// Token: 0x040058D1 RID: 22737
	[Nullable(2)]
	public string FunctionSpritePath;

	// Token: 0x040058D2 RID: 22738
	public int Num;

	// Token: 0x040058D3 RID: 22739
	public string TxtEffect;

	// Token: 0x040058D4 RID: 22740
	public string[] TxtEffectArgs;

	// Token: 0x040058D5 RID: 22741
	public bool EffectAutoLocalText = true;

	// Token: 0x040058D6 RID: 22742
	public string TxtDescription;

	// Token: 0x040058D7 RID: 22743
	public InventoryDefine.EItemType? ItemConfigType;

	// Token: 0x040058D8 RID: 22744
	[Nullable(2)]
	public string ExTxtDescription;
}
