using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E76 RID: 7798
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class HandBookQuestChildItem : GridProxyAbstract<HandBookCommonItemData>
{
	// Token: 0x0600E69D RID: 59037 RVA: 0x003E3F70 File Offset: 0x003E2170
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnTextureToggleClick))
		};
	}

	// Token: 0x0600E69E RID: 59038 RVA: 0x003E405C File Offset: 0x003E225C
	[NullableContext(1)]
	public override void Refresh(HandBookCommonItemData data, bool isSelected, int gridIndex)
	{
		base.SetUiActive(false);
		this.HandBookCommonItemData = data;
		this.GirdIndex = gridIndex;
		PhotographHandBook photographHandBook = (PhotographHandBook)this.HandBookCommonItemData.Config;
		bool isNew = data.IsNew;
		bool isLock = data.IsLock;
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		base.SetTextureByPath((playerGender == EPlayerGender.Male) ? photographHandBook.MaleTexture : photographHandBook.FemaleTexture, base.GetTexture(0), null, delegate(bool success)
		{
			base.SetUiActive(true);
		});
		base.GetText(1).ShowTextNew(photographHandBook.Name);
		base.GetItem(2).SetUIActive(isNew);
		base.GetTexture(0).SetUIActive(!isLock);
		UUIExtendToggle tog = this.GetTog();
		if (tog != null)
		{
			tog.SetEnable(!isLock);
		}
		if (string.IsNullOrEmpty(photographHandBook.AreaIcon) && string.IsNullOrEmpty(photographHandBook.AreaNumber))
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
		}
		else
		{
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			this.SetSpriteByPath(photographHandBook.AreaIcon, base.GetSprite(6), false, null, null);
			base.SetTextureByPath(photographHandBook.AreaNumber, base.GetTexture(7), null, null);
		}
		if (!string.IsNullOrEmpty(photographHandBook.RoleName))
		{
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), photographHandBook.RoleName, Array.Empty<object>());
			return;
		}
		UUIText text2 = base.GetText(5);
		if (text2 == null)
		{
			return;
		}
		text2.SetUIActive(false);
	}

	// Token: 0x0600E69F RID: 59039 RVA: 0x003E41F8 File Offset: 0x003E23F8
	private void OnTextureToggleClick(EToggleState toggleState)
	{
		HandBookCommonItemData handBookCommonItemData = this.HandBookCommonItemData;
		PhotographHandBook? photographHandBook = (PhotographHandBook?)((handBookCommonItemData != null) ? handBookCommonItemData.Config : null);
		if (photographHandBook == null)
		{
			return;
		}
		if (photographHandBook.Value.QuestId != 0)
		{
			this.OnPressQuest(photographHandBook.Value.Type);
			return;
		}
		this.OnPressPhoto(photographHandBook.Value.Type);
	}

	// Token: 0x0600E6A0 RID: 59040 RVA: 0x003E4263 File Offset: 0x003E2463
	public HandBookCommonItemData GetData()
	{
		return this.HandBookCommonItemData;
	}

	// Token: 0x0600E6A1 RID: 59041 RVA: 0x003E426B File Offset: 0x003E246B
	public void SetNewState(bool isNew)
	{
		base.GetItem(2).SetUIActive(isNew);
	}

	// Token: 0x0600E6A2 RID: 59042 RVA: 0x003E427A File Offset: 0x003E247A
	public void SetToggleState(EToggleState state)
	{
		base.GetExtendToggle(3).SetToggleStateForce(state, false, true, false);
		if (state == EToggleState.ETT_Checked)
		{
			this.ReadHandBook();
		}
	}

	// Token: 0x0600E6A3 RID: 59043 RVA: 0x003E4298 File Offset: 0x003E2498
	private void ReadHandBook()
	{
		if (this.HandBookCommonItemData.IsNew)
		{
			PhotographHandBook photographHandBook = (PhotographHandBook)this.HandBookCommonItemData.Config;
			int type = photographHandBook.Type;
			PlotType? plotType;
			int? num = (ConfigBase<HandBookConfig>.Instance.GetPlotTypeConfig(type) != null) ? new int?(plotType.GetValueOrDefault().Type) : null;
			if (num != null)
			{
				ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest((EHandBookTabType)num.Value, photographHandBook.Id);
			}
		}
	}

	// Token: 0x0600E6A4 RID: 59044 RVA: 0x003E4323 File Offset: 0x003E2523
	protected override void OnBeforeDestroy()
	{
		this.HandBookCommonItemData = null;
	}

	// Token: 0x0600E6A5 RID: 59045 RVA: 0x003E432C File Offset: 0x003E252C
	public UUIExtendToggle GetTog()
	{
		return base.GetExtendToggle(3);
	}

	// Token: 0x0600E6A6 RID: 59046 RVA: 0x003E4335 File Offset: 0x003E2535
	public bool GetIsUnlock()
	{
		return this.HandBookCommonItemData != null && !this.HandBookCommonItemData.IsLock;
	}

	// Token: 0x0600E6A7 RID: 59047 RVA: 0x003E4350 File Offset: 0x003E2550
	private void OnPressPhoto(int subType)
	{
		this.ReadHandBook();
		List<PhotographHandBook> list = ConfigCommon.ToList<PhotographHandBook>(ConfigBase<HandBookConfig>.Instance.GetPlotHandBookConfigByType(subType));
		if (list != null)
		{
			list.Sort(new Comparison<PhotographHandBook>(this.SortIndex));
		}
		PlotType? plotTypeConfig = ConfigBase<HandBookConfig>.Instance.GetPlotTypeConfig(subType);
		if (plotTypeConfig == null)
		{
			return;
		}
		int num = (list != null) ? list.Count : 0;
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		List<string> list5 = new List<string>();
		List<string> list6 = new List<string>();
		List<int> list7 = new List<int>();
		for (int i = 0; i < num; i++)
		{
			PhotographHandBook photographHandBook = list[i];
			HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Quest, photographHandBook.Id);
			if (handBookInfo != null)
			{
				EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
				list2.Add((playerGender == EPlayerGender.Male) ? photographHandBook.MaleTexture : photographHandBook.FemaleTexture);
				list6.Add(handBookInfo.CreateTime);
				list3.Add(ConfigMultiTextLang.GetLocalTextNew(photographHandBook.Descrtption, null));
				list4.Add(ConfigMultiTextLang.GetLocalTextNew(photographHandBook.Name, null));
				list5.Add(ConfigMultiTextLang.GetLocalTextNew(plotTypeConfig.Value.TypeDescription, null));
				list7.Add(photographHandBook.Id);
			}
		}
		HandBookPhotoData handBookPhotoData = new HandBookPhotoData();
		handBookPhotoData.DescrtptionText = list3;
		handBookPhotoData.TypeText = list5;
		handBookPhotoData.NameText = list4;
		handBookPhotoData.HandBookType = EHandBookTabType.Quest;
		handBookPhotoData.Index = this.GirdIndex;
		handBookPhotoData.TextureList = list2;
		handBookPhotoData.DateText = list6;
		handBookPhotoData.ConfigId = list7.ToArray();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HandBookPhotoView, handBookPhotoData, null);
	}

	// Token: 0x0600E6A8 RID: 59048 RVA: 0x003E4500 File Offset: 0x003E2700
	private void OnPressQuest(int subType)
	{
		this.ReadHandBook();
		HandBookCommonItemData handBookCommonItemData = this.HandBookCommonItemData;
		PhotographHandBook? photographHandBook;
		int? num = ((PhotographHandBook?)((handBookCommonItemData != null) ? handBookCommonItemData.Config : null) != null) ? new int?(photographHandBook.GetValueOrDefault().QuestId) : null;
		List<PhotographHandBook> list = ConfigCommon.ToList<PhotographHandBook>(ConfigBase<HandBookConfig>.Instance.GetPlotHandBookConfigByType(subType));
		if (list != null)
		{
			list.Sort((PhotographHandBook a, PhotographHandBook b) => a.Id - b.Id);
		}
		PlotType? plotTypeConfig = ConfigBase<HandBookConfig>.Instance.GetPlotTypeConfig(subType);
		if (plotTypeConfig == null)
		{
			return;
		}
		int num2 = (list != null) ? list.Count : 0;
		List<int> list2 = new List<int>();
		HandBookQuestViewOpenParam handBookQuestViewOpenParam = new HandBookQuestViewOpenParam();
		for (int i = 0; i < num2; i++)
		{
			PhotographHandBook photographHandBook2 = list[i];
			if (ModelBase<HandBookModel>.Instance.GetHandBookInfo((EHandBookTabType)plotTypeConfig.Value.Type, photographHandBook2.Id) != null)
			{
				list2.Add(photographHandBook2.Id);
				int? num3 = num;
				int questId = photographHandBook2.QuestId;
				if (num3.GetValueOrDefault() == questId & num3 != null)
				{
					handBookQuestViewOpenParam.Index = list2.IndexOf(photographHandBook2.Id);
				}
			}
		}
		handBookQuestViewOpenParam.ConfigIdList = list2.ToArray();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HandBookQuestPlotView, handBookQuestViewOpenParam, null);
	}

	// Token: 0x0600E6A9 RID: 59049 RVA: 0x003E4662 File Offset: 0x003E2862
	private int SortIndex(PhotographHandBook a, PhotographHandBook b)
	{
		return a.Id - b.Id;
	}

	// Token: 0x04006F3B RID: 28475
	private HandBookCommonItemData HandBookCommonItemData;

	// Token: 0x04006F3C RID: 28476
	private int GirdIndex;
}
