using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E41 RID: 7745
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GeographyHandBookChildItem : GridProxyAbstract<HandBookCommonItemData>
{
	// Token: 0x0600E545 RID: 58693 RVA: 0x003DF256 File Offset: 0x003DD456
	public GeographyHandBookChildItem(UUIItem uiItem = null)
	{
		if (uiItem != null)
		{
			this.CreateThenShowByActor(uiItem.GetOwner());
		}
	}

	// Token: 0x0600E546 RID: 58694 RVA: 0x003DF270 File Offset: 0x003DD470
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIExtendToggle))
		};
	}

	// Token: 0x0600E547 RID: 58695 RVA: 0x003DF2F6 File Offset: 0x003DD4F6
	protected override void OnStart()
	{
		this.GetTog().SetToggleStateForce(EToggleState.ETT_UnChecked, false, true, false);
	}

	// Token: 0x0600E548 RID: 58696 RVA: 0x003DF308 File Offset: 0x003DD508
	[NullableContext(1)]
	public override void Refresh(HandBookCommonItemData data, bool isSelected, int gridIndex)
	{
		this.HandBookCommonItemData = data;
		GeographyHandBook geographyHandBook = (GeographyHandBook)this.HandBookCommonItemData.Config;
		bool isNew = data.IsNew;
		bool isLock = data.IsLock;
		base.SetTextureByPath(geographyHandBook.Texture, base.GetTexture(0), null, null);
		base.GetText(1).ShowTextNew(geographyHandBook.Name);
		base.GetItem(2).SetUIActive(isNew);
		base.GetTexture(0).SetUIActive(!isLock);
		base.GetItem(3).SetUIActive(isLock);
		this.ClearToggleEvent();
		this.AddToggleEvent();
		UUIExtendToggle tog = this.GetTog();
		if (tog == null)
		{
			return;
		}
		tog.SetEnable(!isLock);
	}

	// Token: 0x0600E549 RID: 58697 RVA: 0x003DF3B6 File Offset: 0x003DD5B6
	private void OnTextureToggleClick(EToggleState state)
	{
		this.ToggleClick();
	}

	// Token: 0x0600E54A RID: 58698 RVA: 0x003DF3C0 File Offset: 0x003DD5C0
	public void ToggleClick()
	{
		GeographyHandBook geographyHandBook = (GeographyHandBook)this.HandBookCommonItemData.Config;
		if (this.HandBookCommonItemData.IsLock)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("CurGeographyHandBookLock", Array.Empty<object>());
			this.SetToggleState(EToggleState.ETT_UnChecked);
			return;
		}
		this.ReadHandBook();
		List<GeographyHandBook> list = ConfigCommon.ToList<GeographyHandBook>(ConfigBase<HandBookConfig>.Instance.GetGeographyHandBookConfigByTabType(geographyHandBook.GeographyTabType));
		list.Sort(new Comparison<GeographyHandBook>(this.SortIndex));
		int count = list.Count;
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		List<string> list5 = new List<string>();
		List<string> list6 = new List<string>();
		List<int> list7 = new List<int>();
		int index = 0;
		for (int i = 0; i < count; i++)
		{
			GeographyHandBook geographyHandBook2 = list[i];
			HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Geography, geographyHandBook2.Id);
			if (handBookInfo != null)
			{
				list2.Add(geographyHandBook2.Texture);
				list6.Add(handBookInfo.CreateTime);
				list3.Add(ConfigMultiTextLang.GetLocalTextNew(geographyHandBook2.Descrtption, null));
				list4.Add(ConfigMultiTextLang.GetLocalTextNew(geographyHandBook2.Name, null));
				list5.Add(ConfigMultiTextLang.GetLocalTextNew(ConfigBase<HandBookConfig>.Instance.GetGeographyTypeConfig(geographyHandBook2.Type).Value.TypeDescription, null));
				list7.Add(geographyHandBook2.Id);
				if (geographyHandBook2.Id == geographyHandBook.Id)
				{
					index = list2.Count - 1;
				}
			}
		}
		HandBookPhotoData handBookPhotoData = new HandBookPhotoData();
		handBookPhotoData.DescrtptionText = list3;
		handBookPhotoData.TypeText = list5;
		handBookPhotoData.NameText = list4;
		handBookPhotoData.HandBookType = EHandBookTabType.Geography;
		handBookPhotoData.Index = index;
		handBookPhotoData.TextureList = list2;
		handBookPhotoData.DateText = list6;
		handBookPhotoData.ConfigId = list7.ToArray();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HandBookPhotoView, handBookPhotoData, null);
	}

	// Token: 0x0600E54B RID: 58699 RVA: 0x003DF5A3 File Offset: 0x003DD7A3
	public HandBookCommonItemData GetData()
	{
		return this.HandBookCommonItemData;
	}

	// Token: 0x0600E54C RID: 58700 RVA: 0x003DF5AB File Offset: 0x003DD7AB
	public void SetNewState(bool isNew)
	{
		base.GetItem(2).SetUIActive(isNew);
	}

	// Token: 0x0600E54D RID: 58701 RVA: 0x003DF5BA File Offset: 0x003DD7BA
	public void SetToggleState(EToggleState state)
	{
		base.GetExtendToggle(4).SetToggleStateForce(state, false, true, false);
		if (state == EToggleState.ETT_Checked)
		{
			this.ReadHandBook();
		}
	}

	// Token: 0x0600E54E RID: 58702 RVA: 0x003DF5D8 File Offset: 0x003DD7D8
	private void ReadHandBook()
	{
		if (this.HandBookCommonItemData.IsNew)
		{
			GeographyHandBook geographyHandBook = (GeographyHandBook)this.HandBookCommonItemData.Config;
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Geography, geographyHandBook.Id);
		}
	}

	// Token: 0x0600E54F RID: 58703 RVA: 0x003DF615 File Offset: 0x003DD815
	private int SortIndex(GeographyHandBook a, GeographyHandBook b)
	{
		if (a.Type == b.Type)
		{
			return a.Id - b.Id;
		}
		return a.Type - b.Type;
	}

	// Token: 0x0600E550 RID: 58704 RVA: 0x003DF646 File Offset: 0x003DD846
	protected override void OnBeforeDestroy()
	{
		this.HandBookCommonItemData = null;
	}

	// Token: 0x0600E551 RID: 58705 RVA: 0x003DF64F File Offset: 0x003DD84F
	public UUIExtendToggle GetTog()
	{
		return base.GetExtendToggle(4);
	}

	// Token: 0x0600E552 RID: 58706 RVA: 0x003DF658 File Offset: 0x003DD858
	public bool GetIsUnlock()
	{
		return this.HandBookCommonItemData != null && !this.HandBookCommonItemData.IsLock;
	}

	// Token: 0x0600E553 RID: 58707 RVA: 0x003DF672 File Offset: 0x003DD872
	private void ClearToggleEvent()
	{
		UUIExtendToggle tog = this.GetTog();
		if (tog != null)
		{
			tog.OnStateChange.Clear();
		}
		if (tog == null)
		{
			return;
		}
		tog.CanExecuteChange.Unbind();
	}

	// Token: 0x0600E554 RID: 58708 RVA: 0x003DF69A File Offset: 0x003DD89A
	private void AddToggleEvent()
	{
		UUIExtendToggle tog = this.GetTog();
		if (tog == null)
		{
			return;
		}
		tog.OnStateChange.Add(new Action<EToggleState>(this.OnTextureToggleClick));
	}

	// Token: 0x04006E5F RID: 28255
	private HandBookCommonItemData HandBookCommonItemData;
}
