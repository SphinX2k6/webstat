using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using UnrealEngine;

// Token: 0x02002C4B RID: 11339
[NullableContext(1)]
[Nullable(0)]
public class UiCameraDebugTool
{
	// Token: 0x06016B7F RID: 93055 RVA: 0x0064E9BD File Offset: 0x0064CBBD
	public void Init()
	{
		this.UiCameraSettingTable = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCompositeDataTable>("/Game/Aki/Data/UiCameraAnimation/DT_UiCameraSetting.DT_UiCameraSetting");
	}

	// Token: 0x06016B80 RID: 93056 RVA: 0x0064E9D4 File Offset: 0x0064CBD4
	public bool GetDtSyncEnabled()
	{
		return this.DtSyncEnabled;
	}

	// Token: 0x06016B81 RID: 93057 RVA: 0x0064E9DC File Offset: 0x0064CBDC
	public void StartDtSync()
	{
		if (this.DtSyncEnabled)
		{
			return;
		}
		UCompositeDataTable uiCameraSettingTable = this.UiCameraSettingTable;
		TArray<UDataTable> tarray = (uiCameraSettingTable != null) ? uiCameraSettingTable.ParentTables : null;
		if (tarray == null)
		{
			return;
		}
		FOnDataTableChanged fonDataTableChanged = global::DelegateUtils.ToManualReleaseDelegate<FOnDataTableChanged>(new Action(this.OnDataTableChange));
		for (int i = 0; i < tarray.Num(); i++)
		{
			UKuroDataTableFunctionLibrary.AddOnDataTableChangedDelegate(tarray.Get(i), GlobalData.World, fonDataTableChanged);
		}
		this.DtSyncEnabled = true;
	}

	// Token: 0x06016B82 RID: 93058 RVA: 0x0064EA48 File Offset: 0x0064CC48
	public void EndDtSync()
	{
		if (!this.DtSyncEnabled)
		{
			return;
		}
		UCompositeDataTable uiCameraSettingTable = this.UiCameraSettingTable;
		TArray<UDataTable> tarray = (uiCameraSettingTable != null) ? uiCameraSettingTable.ParentTables : null;
		if (tarray == null)
		{
			return;
		}
		for (int i = 0; i < tarray.Num(); i++)
		{
			UKuroDataTableFunctionLibrary.RemoveOnDataTableChangedDelegate(tarray.Get(i), GlobalData.World);
		}
		global::DelegateUtils.ToManualReleaseDelegate<FOnDataTableChanged>(new Action(this.OnDataTableChange));
		this.DtSyncEnabled = false;
	}

	// Token: 0x06016B83 RID: 93059 RVA: 0x0064EAB0 File Offset: 0x0064CCB0
	private void OnDataTableChange()
	{
		UiCameraHandleData lastHandleData = Singleton<UiCameraAnimationManager>.Instance.GetLastHandleData();
		if (lastHandleData != null)
		{
			lastHandleData.Refresh();
		}
		Singleton<UiCameraAnimationManager>.Instance.ReactivateCameraHandle(false, false);
	}

	// Token: 0x06016B84 RID: 93060 RVA: 0x0064EAD4 File Offset: 0x0064CCD4
	public void UpdateDebugCameraProps()
	{
		UiCameraHandleData lastHandleData = Singleton<UiCameraAnimationManager>.Instance.GetLastHandleData();
		this.DebugCameraProps["CurrentHandleName"] = (((lastHandleData != null) ? lastHandleData.GetHandleName() : null) ?? string.Empty);
		this.DebugCameraProps["DtSync"] = (this.GetDtSyncEnabled() ? "true" : "false");
		this.DebugCameraProps["ArmLengthSync"] = (this.GetArmLengthSyncEnabled() ? "true" : "false");
	}

	// Token: 0x06016B85 RID: 93061 RVA: 0x0064EB59 File Offset: 0x0064CD59
	public IDictionary<string, string> GetDebugCameraProps()
	{
		return this.DebugCameraProps;
	}

	// Token: 0x06016B86 RID: 93062 RVA: 0x0064EB61 File Offset: 0x0064CD61
	public bool GetArmLengthSyncEnabled()
	{
		return this.ArmLengthSyncEnabled;
	}

	// Token: 0x06016B87 RID: 93063 RVA: 0x0064EB69 File Offset: 0x0064CD69
	public void StartArmLengthSync()
	{
		this.ArmLengthSyncEnabled = true;
	}

	// Token: 0x06016B88 RID: 93064 RVA: 0x0064EB72 File Offset: 0x0064CD72
	public void EndArmLengthSync()
	{
		this.ArmLengthSyncEnabled = false;
	}

	// Token: 0x06016B89 RID: 93065 RVA: 0x0064EB7B File Offset: 0x0064CD7B
	public void ArmLengthSync(float armLength)
	{
		UiCameraManager.Get().GetUiCameraComponent<UiCameraControlRotationComponent>().SetArmLength(armLength);
	}

	// Token: 0x0400AF39 RID: 44857
	[Nullable(2)]
	private UCompositeDataTable UiCameraSettingTable;

	// Token: 0x0400AF3A RID: 44858
	private bool DtSyncEnabled;

	// Token: 0x0400AF3B RID: 44859
	private bool ArmLengthSyncEnabled;

	// Token: 0x0400AF3C RID: 44860
	private readonly Dictionary<string, string> DebugCameraProps = new Dictionary<string, string>();
}
