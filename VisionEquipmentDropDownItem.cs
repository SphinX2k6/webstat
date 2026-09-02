using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x020024FA RID: 9466
public class VisionEquipmentDropDownItem : DropDownItemBase<int>
{
	// Token: 0x0601262A RID: 75306 RVA: 0x0050E2EE File Offset: 0x0050C4EE
	[NullableContext(1)]
	public VisionEquipmentDropDownItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x0601262B RID: 75307 RVA: 0x0050E2F8 File Offset: 0x0050C4F8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x0601262C RID: 75308 RVA: 0x0050E389 File Offset: 0x0050C589
	[NullableContext(2)]
	protected override UUIExtendToggle GetDropDownToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x0601262D RID: 75309 RVA: 0x0050E392 File Offset: 0x0050C592
	public void SetRoleId(int id)
	{
		this.CurrentRoleId = id;
	}

	// Token: 0x0601262E RID: 75310 RVA: 0x0050E39C File Offset: 0x0050C59C
	protected override void OnShowDropDownItemBase(int data)
	{
		List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.CurrentRoleId);
		bool uiactive = false;
		if (roleFetterRecommendInfo != null && roleFetterRecommendInfo.Count > 0)
		{
			uiactive = (roleFetterRecommendInfo.Find((VisionFetterRecommendInfo item) => item.GetRecommendFetterGroupId() == data) != null);
		}
		base.GetItem(4).SetUIActive(uiactive);
		this.VisionFetterSuitItem = new VisionFetterSuitItem(base.GetItem(2));
		this.VisionFetterSuitItem.Init();
		int data2 = data;
		List<IPhantomItemData> list;
		string newText;
		if (data > 0)
		{
			list = ModelBase<PhantomBattleModel>.Instance.GetVisionSortUseDataList(data, 0).ToList<IPhantomItemData>();
			newText = (ConfigMultiTextLang.GetLocalTextNew(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data).FetterGroupName, null) ?? "");
		}
		else
		{
			list = ModelBase<PhantomBattleModel>.Instance.GetVisionSortUseDataList(0, 0).ToList<IPhantomItemData>();
			newText = (ConfigMultiTextLang.GetLocalTextNew("Text_FilterTextAllVisionFetter_Text", null) ?? "");
		}
		base.GetText(3).SetText(list.Count.ToString(), true);
		base.GetText(1).SetText(newText, true);
		bool flag = true;
		if (flag)
		{
			PhantomFetterGroup? fetterGroupData = (data2 > 0) ? new PhantomFetterGroup?(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data2)) : null;
			this.VisionFetterSuitItem.Update(fetterGroupData);
		}
		this.VisionFetterSuitItem.SetActive(flag);
	}

	// Token: 0x0601262F RID: 75311 RVA: 0x0050E502 File Offset: 0x0050C702
	protected override void OnBeforeDestroy()
	{
		VisionFetterSuitItem visionFetterSuitItem = this.VisionFetterSuitItem;
		if (visionFetterSuitItem == null)
		{
			return;
		}
		visionFetterSuitItem.Destroy(null);
	}

	// Token: 0x04008F65 RID: 36709
	private int CurrentRoleId;

	// Token: 0x04008F66 RID: 36710
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02008815 RID: 34837
	private enum EComponent
	{
		// Token: 0x0402DF7B RID: 188283
		TogOption,
		// Token: 0x0402DF7C RID: 188284
		TxtOption,
		// Token: 0x0402DF7D RID: 188285
		SuitElementItem,
		// Token: 0x0402DF7E RID: 188286
		CurrentNumText,
		// Token: 0x0402DF7F RID: 188287
		LikeItem
	}
}
