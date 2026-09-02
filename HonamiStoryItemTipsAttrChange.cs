using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F0F RID: 7951
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryItemTipsAttrChange : UiPanelBase
{
	// Token: 0x0600ED92 RID: 60818 RVA: 0x0040C954 File Offset: 0x0040AB54
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x0600ED93 RID: 60819 RVA: 0x0040C9DA File Offset: 0x0040ABDA
	protected override void OnStart()
	{
		this.AttrLayout = new GenericLayout<HonamiStoryAttrItem, IHonamiStoryAttrData>(base.GetVerticalLayout(0), new Func<HonamiStoryAttrItem>(this.InitAttrItem), base.GetItem(1).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600ED94 RID: 60820 RVA: 0x0040CA0D File Offset: 0x0040AC0D
	private HonamiStoryAttrItem InitAttrItem()
	{
		return new HonamiStoryAttrItem();
	}

	// Token: 0x0600ED95 RID: 60821 RVA: 0x0040CA14 File Offset: 0x0040AC14
	public List<IHonamiStoryAttrData> CombineDataList(HonamiStoryEquipItemData oldData, HonamiStoryEquipItemData newData)
	{
		int[] mainPropList = oldData.GetMainPropList();
		int[] mainPropList2 = newData.GetMainPropList();
		this.PropertyMap.Clear();
		List<IHonamiStoryAttrData> list = new List<IHonamiStoryAttrData>();
		HonamiStoryProp? honamiStoryProp = null;
		foreach (int id in mainPropList)
		{
			honamiStoryProp = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryProp(id);
			if (honamiStoryProp != null)
			{
				PropertyIndexConfig instance = ConfigBase<PropertyIndexConfig>.Instance;
				string text = (instance != null) ? instance.GetPropertyIndexName(honamiStoryProp.Value.PropId) : null;
				PropertyIndexConfig instance2 = ConfigBase<PropertyIndexConfig>.Instance;
				string text2 = (instance2 != null) ? instance2.GetPropertyIndexIcon(honamiStoryProp.Value.PropId) : null;
				HonamiStoryAttrData value = new HonamiStoryAttrData
				{
					Name = (text ?? string.Empty),
					IconPath = (text2 ?? string.Empty),
					OldValue = honamiStoryProp.Value.StandardProperty,
					NewValue = 0,
					IsPercent = honamiStoryProp.Value.ShowPercent
				};
				this.PropertyMap[honamiStoryProp.Value.PropId] = value;
			}
		}
		foreach (int num in mainPropList2)
		{
			honamiStoryProp = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryProp(num);
			if (honamiStoryProp != null)
			{
				int standardProperty = honamiStoryProp.Value.StandardProperty;
				IHonamiStoryAttrData honamiStoryAttrData;
				if (this.PropertyMap.TryGetValue(honamiStoryProp.Value.PropId, out honamiStoryAttrData))
				{
					honamiStoryAttrData.NewValue = standardProperty;
				}
				else
				{
					PropertyIndexConfig instance3 = ConfigBase<PropertyIndexConfig>.Instance;
					string text3 = (instance3 != null) ? instance3.GetPropertyIndexName(honamiStoryProp.Value.PropId) : null;
					PropertyIndexConfig instance4 = ConfigBase<PropertyIndexConfig>.Instance;
					string text4 = (instance4 != null) ? instance4.GetPropertyIndexIcon(honamiStoryProp.Value.PropId) : null;
					HonamiStoryAttrData value2 = new HonamiStoryAttrData
					{
						Name = (text3 ?? string.Empty),
						IconPath = (text4 ?? string.Empty),
						OldValue = 0,
						NewValue = standardProperty,
						IsPercent = honamiStoryProp.Value.ShowPercent
					};
					this.PropertyMap[num] = value2;
				}
			}
		}
		foreach (IHonamiStoryAttrData item in this.PropertyMap.Values)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0600ED96 RID: 60822 RVA: 0x0040CCA8 File Offset: 0x0040AEA8
	public void Refresh(HonamiStoryEquipItemData oldData, HonamiStoryEquipItemData newData, Action callBack)
	{
		List<IHonamiStoryAttrData> data = this.CombineDataList(oldData, newData);
		this.AttrLayout.RefreshByData(data, delegate
		{
			Action callBack2 = callBack;
			if (callBack2 == null)
			{
				return;
			}
			callBack2();
		}, false);
	}

	// Token: 0x0600ED97 RID: 60823 RVA: 0x0040CCE4 File Offset: 0x0040AEE4
	public void AddHotKey(UUIItem hotKeyItem)
	{
		hotKeyItem.SetUIActive(true);
		hotKeyItem.SetUIParent(base.GetItem(2), false);
	}

	// Token: 0x0600ED98 RID: 60824 RVA: 0x0040CCFC File Offset: 0x0040AEFC
	public void SetAutoLocation(UUIItem gridItem)
	{
		global::Vector adaptiveTipsPosition = Singleton<LguiUtil>.Instance.GetAdaptiveTipsPosition(gridItem, this.RootItem, 0f);
		float width = base.GetItem(4).Width;
		adaptiveTipsPosition.X += (double)width;
		adaptiveTipsPosition.Z += (double)(gridItem.Height / 2f);
		UUIItem rootItem = this.RootItem;
		FVector fvector = adaptiveTipsPosition.ToUeVectorOld();
		rootItem.SetUIWorldLocation(fvector);
	}

	// Token: 0x0400721E RID: 29214
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<HonamiStoryAttrItem, IHonamiStoryAttrData> AttrLayout;

	// Token: 0x0400721F RID: 29215
	private readonly Dictionary<int, IHonamiStoryAttrData> PropertyMap = new Dictionary<int, IHonamiStoryAttrData>();

	// Token: 0x0200826F RID: 33391
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402C3BA RID: 181178
		PnlAttrList,
		// Token: 0x0402C3BB RID: 181179
		PnlAttrItem,
		// Token: 0x0402C3BC RID: 181180
		PnlKeyDown,
		// Token: 0x0402C3BD RID: 181181
		PnlKeyUp,
		// Token: 0x0402C3BE RID: 181182
		PnlLocalOffsetX
	}
}
