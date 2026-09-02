using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020013EA RID: 5098
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class HandbookDisplayGrid : GridProxyAbstract<IHandbookGridData>
{
	// Token: 0x06008D52 RID: 36178 RVA: 0x002526FC File Offset: 0x002508FC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnButtonClicked))
		};
	}

	// Token: 0x06008D53 RID: 36179 RVA: 0x002527D4 File Offset: 0x002509D4
	public override void Refresh(IHandbookGridData data, bool isSelected, int gridIndex)
	{
		this.HandBookGridData = data;
		Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(data.Id);
		this.RefreshTexture(buildingById.BuildingTexture, data.IsUnlock);
		this.SetPanelTitleVisible(true);
		if (data.IsUnlock)
		{
			this.SetTitleByTextId(buildingById.Name);
		}
		else
		{
			base.GetText(2).SetText("???", true);
		}
		base.GetItem(4).SetUIActive(data.IsUnlock);
		base.GetItem(5).SetUIActive(!data.IsUnlock);
		base.GetButton(3).RootUIComp.Get().SetUIActive(data.IsUnlock);
		this.MarkId = buildingById.MapMarkId;
	}

	// Token: 0x06008D54 RID: 36180 RVA: 0x00252890 File Offset: 0x00250A90
	private void RefreshTexture(string path, bool isUnlock)
	{
		UUITexture texture = base.GetTexture(0);
		UUITexture textureLock = base.GetTexture(6);
		texture.SetUIActive(false);
		textureLock.SetUIActive(false);
		if (string.IsNullOrEmpty(path))
		{
			return;
		}
		base.SetTextureByPath(path, texture, null, delegate(bool _)
		{
			texture.SetUIActive(true);
		});
		base.SetTextureByPath(path, textureLock, null, delegate(bool _)
		{
			textureLock.SetUIActive(!isUnlock);
		});
	}

	// Token: 0x06008D55 RID: 36181 RVA: 0x00252929 File Offset: 0x00250B29
	private void SetPanelTitleVisible(bool bVisible)
	{
		base.GetItem(1).SetUIActive(bVisible);
	}

	// Token: 0x06008D56 RID: 36182 RVA: 0x00252938 File Offset: 0x00250B38
	private void SetTitleByTextId(string textId)
	{
		base.GetText(2).ShowTextNew(textId);
	}

	// Token: 0x06008D57 RID: 36183 RVA: 0x00252948 File Offset: 0x00250B48
	private void OnButtonClicked()
	{
		if (this.HandBookGridData.IsUnlock)
		{
			if (this.MarkId <= 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.MoonChasing, ELogAuthor.BB, "HandbookDisplayGrid 无效markId", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkId = new int?(this.MarkId),
				MarkType = EMarkType.None
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
			return;
		}
		else
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MoonChasingMainView))
			{
				ControllerBase<MoonChasingController>.Instance.OpenBuildingTipsInfoView(this.HandBookGridData.Id);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Moonfiesta_BuildingUnlock", Array.Empty<object>());
			return;
		}
	}

	// Token: 0x040041D2 RID: 16850
	private int MarkId;

	// Token: 0x040041D3 RID: 16851
	private IHandbookGridData HandBookGridData;

	// Token: 0x020077E0 RID: 30688
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040293FC RID: 168956
		public const int Texture = 0;

		// Token: 0x040293FD RID: 168957
		public const int PanelTitle = 1;

		// Token: 0x040293FE RID: 168958
		public const int TxtTitle = 2;

		// Token: 0x040293FF RID: 168959
		public const int Button = 3;

		// Token: 0x04029400 RID: 168960
		public const int SpriteBg = 4;

		// Token: 0x04029401 RID: 168961
		public const int SpriteLockBg = 5;

		// Token: 0x04029402 RID: 168962
		public const int TextureLock = 6;
	}
}
