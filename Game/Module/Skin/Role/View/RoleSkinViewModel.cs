using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.Skin.Role.View
{
	// Token: 0x02004F73 RID: 20339
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleSkinViewModel : ViewModelBase<ERoleSkinTabViewData>
	{
		// Token: 0x06034759 RID: 214873 RVA: 0x00D20698 File Offset: 0x00D1E898
		public RoleSkinViewModel()
		{
			int num = 0;
			this.DataMap[ERoleSkinTabViewData.SelectRoleSkinId] = num;
			bool flag = false;
			this.DataMap[ERoleSkinTabViewData.IsWearWeaponSkin] = flag;
		}

		// Token: 0x0603475A RID: 214874 RVA: 0x00D206D4 File Offset: 0x00D1E8D4
		public void Init(ISkinViewData viewData)
		{
			if (this.GetSelectRoleSkinId() <= 0)
			{
				RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(viewData.RoleId);
				this.SetSelectRoleSkinId(roleInstanceById.GetRoleSkinId(), false);
			}
		}

		// Token: 0x0603475B RID: 214875 RVA: 0x00D20708 File Offset: 0x00D1E908
		public void SetSelectRoleSkinId(int selectRoleSkinId, bool notNotify = false)
		{
			base.SetData(ERoleSkinTabViewData.SelectRoleSkinId, selectRoleSkinId, notNotify);
		}

		// Token: 0x0603475C RID: 214876 RVA: 0x00D20718 File Offset: 0x00D1E918
		public int GetSelectRoleSkinId()
		{
			return (int)base.GetData(ERoleSkinTabViewData.SelectRoleSkinId);
		}

		// Token: 0x0603475D RID: 214877 RVA: 0x00D20726 File Offset: 0x00D1E926
		public void SetIsWearWeaponSkin(bool isWearWeaponSkin, bool notNotify = false)
		{
			base.SetData(ERoleSkinTabViewData.IsWearWeaponSkin, isWearWeaponSkin, notNotify);
		}

		// Token: 0x0603475E RID: 214878 RVA: 0x00D20736 File Offset: 0x00D1E936
		public bool GetIsWearWeaponSkin()
		{
			return (bool)base.GetData(ERoleSkinTabViewData.IsWearWeaponSkin);
		}

		// Token: 0x0603475F RID: 214879 RVA: 0x00D20744 File Offset: 0x00D1E944
		public IUiCameraInputComponentData GetRoleTabCameraInputData(UUIDraggableComponent dragItem, TsUiSceneRoleActor roleActor)
		{
			string rowName = this.GetIsWearWeaponSkin() ? ConfigBase<PayShopConfig>.Instance.GetBuySkinDetailWeaponCameraConfigId() : ConfigBase<PayShopConfig>.Instance.GetBuySkinDetailRoleCameraConfigId();
			SUiRoleCameraSetting? roleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig(rowName);
			FVectorDouble fvectorDouble = roleActor.D_K2_GetActorLocation();
			UiRoleDataComponent uiRoleDataComponent;
			if (roleActor == null)
			{
				uiRoleDataComponent = null;
			}
			else
			{
				UiModelBase model = roleActor.Model;
				uiRoleDataComponent = ((model != null) ? model.CheckGetComponent<UiRoleDataComponent>() : null);
			}
			int roleConfigId = uiRoleDataComponent.RoleConfigId;
			string roleBody = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId).Value.RoleBody;
			SUiRoleCameraOffsetSetting? roleCameraOffsetConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraOffsetConfig(roleBody);
			return new UiCameraInputComponentData
			{
				DragComponent = dragItem,
				CameraSettingConfig = roleCameraConfig.Value,
				CameraOffsetConfig = roleCameraOffsetConfig,
				SourceLocation = fvectorDouble
			};
		}
	}
}
