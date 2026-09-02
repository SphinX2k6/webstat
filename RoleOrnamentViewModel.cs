using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using UnrealEngine;

// Token: 0x02002A65 RID: 10853
[NullableContext(1)]
[Nullable(0)]
public class RoleOrnamentViewModel : CSharpScript.Game.Module.Skin.ViewModelBase<ERoleOrnamentTabViewData>
{
	// Token: 0x17001C2B RID: 7211
	// (get) Token: 0x06015BFC RID: 89084 RVA: 0x00609299 File Offset: 0x00607499
	public ISkinViewData ViewData
	{
		get
		{
			return this.ViewDataInternal;
		}
	}

	// Token: 0x06015BFD RID: 89085 RVA: 0x006092A1 File Offset: 0x006074A1
	public RoleOrnamentViewModel()
	{
		this.DataMap[ERoleOrnamentTabViewData.SelectedOrnamentId] = 0;
		this.DataMap[ERoleOrnamentTabViewData.SelectedSkinId] = 0;
		this.DataMap[ERoleOrnamentTabViewData.PreSelectedOrnamentId] = 0;
	}

	// Token: 0x06015BFE RID: 89086 RVA: 0x006092DF File Offset: 0x006074DF
	public void Init(ISkinViewData viewData)
	{
		this.ViewDataInternal = viewData;
	}

	// Token: 0x06015BFF RID: 89087 RVA: 0x006092E8 File Offset: 0x006074E8
	public void SetSelectedOrnamentId(int ornamentId, bool notNotify = false)
	{
		base.SetData(ERoleOrnamentTabViewData.SelectedOrnamentId, ornamentId, notNotify);
	}

	// Token: 0x06015C00 RID: 89088 RVA: 0x006092F8 File Offset: 0x006074F8
	public int GetSelectedOrnamentId()
	{
		return (int)base.GetData(ERoleOrnamentTabViewData.SelectedOrnamentId);
	}

	// Token: 0x06015C01 RID: 89089 RVA: 0x00609306 File Offset: 0x00607506
	public void SetSelectedSkinId(int skinId, bool notNotify = false)
	{
		base.SetData(ERoleOrnamentTabViewData.SelectedSkinId, skinId, notNotify);
	}

	// Token: 0x06015C02 RID: 89090 RVA: 0x00609316 File Offset: 0x00607516
	public int GetSelectedSkinId()
	{
		return (int)base.GetData(ERoleOrnamentTabViewData.SelectedSkinId);
	}

	// Token: 0x06015C03 RID: 89091 RVA: 0x00609324 File Offset: 0x00607524
	public void SetPreSelectedOrnamentId(int ornamentId, bool notNotify = false)
	{
		base.SetData(ERoleOrnamentTabViewData.PreSelectedOrnamentId, ornamentId, notNotify);
	}

	// Token: 0x06015C04 RID: 89092 RVA: 0x00609334 File Offset: 0x00607534
	public int GetPreSelectedOrnamentId()
	{
		object data = base.GetData(ERoleOrnamentTabViewData.PreSelectedOrnamentId);
		if (data == null)
		{
			return 0;
		}
		return (int)data;
	}

	// Token: 0x06015C05 RID: 89093 RVA: 0x00609354 File Offset: 0x00607554
	public IUiCameraInputComponentData GetOrnamentTabCameraInputData(UUIDraggableComponent dragItem, TsUiSceneRoleActor roleActor, bool isHidingUi)
	{
		int selectedOrnamentId = this.GetSelectedOrnamentId();
		Ornament value = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(selectedOrnamentId).Value;
		string text = isHidingUi ? value.HideUiCameraConfig : value.UiCameraConfig;
		if (string.IsNullOrEmpty(text))
		{
			text = ConfigBase<PayShopConfig>.Instance.GetBuySkinDetailRoleCameraConfigId();
		}
		string text2 = isHidingUi ? value.HideUiCameraOffsetConfig : value.UiCameraOffsetConfig;
		SUiRoleCameraSetting value2 = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig(text).Value;
		SUiRoleCameraOffsetSetting? cameraOffsetConfig = null;
		if (!string.IsNullOrEmpty(text2))
		{
			SUiRoleCameraOffsetSetting? roleCameraOffsetConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraOffsetConfig(text2);
			if (roleCameraOffsetConfig != null)
			{
				cameraOffsetConfig = new SUiRoleCameraOffsetSetting?(roleCameraOffsetConfig.Value);
			}
		}
		FVectorDouble fvectorDouble = roleActor.D_K2_GetActorLocation();
		return new UiCameraInputComponentData
		{
			DragComponent = dragItem,
			CameraSettingConfig = value2,
			CameraOffsetConfig = cameraOffsetConfig,
			SourceLocation = fvectorDouble
		};
	}

	// Token: 0x06015C06 RID: 89094 RVA: 0x00609434 File Offset: 0x00607634
	public int GetDefaultSkinId(int roleId)
	{
		List<RoleSkinData> roleSkinDataList = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataList(roleId);
		RoleOrnamentModel instance = ModelBase<RoleOrnamentModel>.Instance;
		for (int i = 0; i < roleSkinDataList.Count; i++)
		{
			RoleSkinData roleSkinData = roleSkinDataList[i];
			if (roleSkinData.IsWear() && instance.GetSkinAllOrnaments(roleSkinData.GetItemId(), null).Count > 0)
			{
				return roleSkinData.GetItemId();
			}
		}
		for (int j = 0; j < roleSkinDataList.Count; j++)
		{
			RoleSkinData roleSkinData2 = roleSkinDataList[j];
			if (instance.GetSkinAllOrnaments(roleSkinData2.GetItemId(), null).Count > 0)
			{
				return roleSkinData2.GetItemId();
			}
		}
		return roleSkinDataList[0].GetItemId();
	}

	// Token: 0x06015C07 RID: 89095 RVA: 0x006094EB File Offset: 0x006076EB
	public int GetDefaultOrnamentId(int skinId)
	{
		return ModelBase<RoleOrnamentModel>.Instance.GetSkinAllOrnaments(skinId, new bool?(true))[0];
	}

	// Token: 0x0400A6D7 RID: 42711
	private ISkinViewData ViewDataInternal;
}
