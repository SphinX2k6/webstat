using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EA7 RID: 7847
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PlotHandBookChildItem : GridProxyAbstract<HandBookCommonItemData>
{
	// Token: 0x0600E814 RID: 59412 RVA: 0x003EBCF1 File Offset: 0x003E9EF1
	public PlotHandBookChildItem(UUIItem uiItem = null)
	{
		if (uiItem != null)
		{
			this.CreateThenShowByActor(uiItem.GetOwner());
		}
	}

	// Token: 0x0600E815 RID: 59413 RVA: 0x003EBD08 File Offset: 0x003E9F08
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
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClickTextureToggle))
		};
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E816 RID: 59414 RVA: 0x003EBDD0 File Offset: 0x003E9FD0
	[NullableContext(1)]
	public override void Refresh(HandBookCommonItemData data, bool isSelected, int gridIndex)
	{
		this.HandBookCommonItemData = data;
		this.GirdIndex = gridIndex;
		PhotographHandBook photographHandBook = (PhotographHandBook)this.HandBookCommonItemData.Config;
		bool isNew = data.IsNew;
		bool isLock = data.IsLock;
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		base.SetTextureByPath((playerGender == EPlayerGender.Male) ? photographHandBook.MaleTexture : photographHandBook.FemaleTexture, base.GetTexture(0), null, null);
		base.GetText(1).ShowTextNew(photographHandBook.Name);
		base.GetItem(2).SetUIActive(isNew);
		base.GetItem(3).SetUIActive(isLock);
		base.GetTexture(0).SetUIActive(!isLock);
		UUIExtendToggle tog = this.GetTog();
		if (tog == null)
		{
			return;
		}
		tog.SetEnable(!isLock);
	}

	// Token: 0x0600E817 RID: 59415 RVA: 0x003EBE94 File Offset: 0x003EA094
	private void OnClickTextureToggle(EToggleState state)
	{
		PhotographHandBook photographHandBook = (PhotographHandBook)this.HandBookCommonItemData.Config;
		if (!this.HandBookCommonItemData.IsLock)
		{
			if (this.HandBookCommonItemData.IsNew)
			{
				ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Quest, photographHandBook.Id);
			}
			int type = photographHandBook.Type;
			List<PhotographHandBook> list = ConfigCommon.ToList<PhotographHandBook>(ConfigBase<HandBookConfig>.Instance.GetPlotHandBookConfigByType(type));
			list.Sort(new Comparison<PhotographHandBook>(this.SortIndex));
			PlotType? plotTypeConfig = ConfigBase<HandBookConfig>.Instance.GetPlotTypeConfig(type);
			int count = list.Count;
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			List<string> list4 = new List<string>();
			List<string> list5 = new List<string>();
			List<string> list6 = new List<string>();
			List<int> list7 = new List<int>();
			for (int i = 0; i < count; i++)
			{
				PhotographHandBook photographHandBook2 = list[i];
				HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Quest, photographHandBook2.Id);
				if (handBookInfo != null)
				{
					EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
					list2.Add((playerGender == EPlayerGender.Male) ? photographHandBook2.MaleTexture : photographHandBook2.FemaleTexture);
					list6.Add(handBookInfo.CreateTime);
					string localTextNew = ConfigMultiTextLang.GetLocalTextNew(photographHandBook2.Descrtption, null);
					if (localTextNew != null)
					{
						list3.Add(localTextNew);
					}
					string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(photographHandBook2.Name, null);
					if (localTextNew2 != null)
					{
						list4.Add(localTextNew2);
					}
					if (plotTypeConfig != null)
					{
						string localTextNew3 = ConfigMultiTextLang.GetLocalTextNew(plotTypeConfig.Value.TypeDescription, null);
						if (localTextNew3 != null)
						{
							list5.Add(localTextNew3);
						}
					}
					list7.Add(photographHandBook2.Id);
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
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("CurPlotHandBookLock", Array.Empty<object>());
		UUIExtendToggle tog = this.GetTog();
		if (tog == null)
		{
			return;
		}
		tog.SetToggleStateForce(EToggleState.ETT_UnChecked, false, true, false);
	}

	// Token: 0x0600E818 RID: 59416 RVA: 0x003EC0C0 File Offset: 0x003EA2C0
	protected void OnHandBookRead(EHandBookTabType type, int id)
	{
		if (type != EHandBookTabType.Quest)
		{
			return;
		}
		HandBookCommonItemData handBookCommonItemData = this.HandBookCommonItemData;
		PhotographHandBook? photographHandBook = ((handBookCommonItemData != null) ? handBookCommonItemData.Config : null) as PhotographHandBook?;
		int? num = (photographHandBook != null) ? new int?(photographHandBook.GetValueOrDefault().Id) : null;
		if (!(id == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600E819 RID: 59417 RVA: 0x003EC13F File Offset: 0x003EA33F
	private int SortIndex(PhotographHandBook a, PhotographHandBook b)
	{
		return a.Id - b.Id;
	}

	// Token: 0x0600E81A RID: 59418 RVA: 0x003EC150 File Offset: 0x003EA350
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
		this.HandBookCommonItemData = null;
		this.GirdIndex = 0;
	}

	// Token: 0x0600E81B RID: 59419 RVA: 0x003EC17C File Offset: 0x003EA37C
	public UUIExtendToggle GetTog()
	{
		return base.GetExtendToggle(4);
	}

	// Token: 0x0600E81C RID: 59420 RVA: 0x003EC185 File Offset: 0x003EA385
	public HandBookCommonItemData GetData()
	{
		return this.HandBookCommonItemData;
	}

	// Token: 0x0600E81D RID: 59421 RVA: 0x003EC18D File Offset: 0x003EA38D
	public bool GetIsUnlock()
	{
		return this.HandBookCommonItemData != null && !this.HandBookCommonItemData.IsLock;
	}

	// Token: 0x04006FDF RID: 28639
	private HandBookCommonItemData HandBookCommonItemData;

	// Token: 0x04006FE0 RID: 28640
	private int GirdIndex;

	// Token: 0x020081E8 RID: 33256
	[NullableContext(0)]
	private class EGeographyHandBookChildItemDefine
	{
		// Token: 0x0402C133 RID: 180531
		public const int Texture = 0;

		// Token: 0x0402C134 RID: 180532
		public const int NameText = 1;

		// Token: 0x0402C135 RID: 180533
		public const int NewItem = 2;

		// Token: 0x0402C136 RID: 180534
		public const int GrayItem = 3;

		// Token: 0x0402C137 RID: 180535
		public const int TextureToggle = 4;
	}
}
