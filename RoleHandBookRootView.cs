using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;

// Token: 0x0200278A RID: 10122
public class RoleHandBookRootView : RoleRootView
{
	// Token: 0x06013FA7 RID: 81831 RVA: 0x005918B1 File Offset: 0x0058FAB1
	[NullableContext(1)]
	public RoleHandBookRootView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013FA8 RID: 81832 RVA: 0x005918C1 File Offset: 0x0058FAC1
	protected override bool OnCheckIfNeedScene()
	{
		return this.IsNeedLoadSceneFlag;
	}

	// Token: 0x06013FA9 RID: 81833 RVA: 0x005918CC File Offset: 0x0058FACC
	protected override void OnHandleLoadScene()
	{
		string uiCameraHandleName = DynamicTabCamera.GetUiCameraHandleName(EUiTabViewName.RoleHandBookPreviewView);
		this.RoleRootUiCameraHandleData = Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(uiCameraHandleName, false, false, "1001", false, null, null);
	}

	// Token: 0x06013FAA RID: 81834 RVA: 0x00591907 File Offset: 0x0058FB07
	protected override void OnHandleReleaseScene()
	{
		Singleton<UiCameraAnimationManager>.Instance.PopCameraHandle(this.RoleRootUiCameraHandleData, null);
	}

	// Token: 0x06013FAB RID: 81835 RVA: 0x0059191C File Offset: 0x0058FB1C
	protected override void OnBeforeCreate()
	{
		object openParam = this.OpenParam;
		EUiViewName fromViewName;
		if (openParam is EUiViewName)
		{
			EUiViewName euiViewName = (EUiViewName)openParam;
			fromViewName = euiViewName;
		}
		else
		{
			fromViewName = default(EUiViewName);
		}
		this.FromViewName = fromViewName;
		this.IsNeedLoadSceneFlag = (this.FromViewName.ToString() != EUiViewName.RoleHandBookSelectionView.ToString());
	}

	// Token: 0x06013FAC RID: 81836 RVA: 0x0059197F File Offset: 0x0058FB7F
	protected void InitRoleIdList()
	{
		ConfigCommon.ToList<RoleInfo>(ConfigBase<RoleConfig>.Instance.GetRoleListByType(ERoleType.Common)).Sort((RoleInfo aRoleConfig, RoleInfo bRoleConfig) => aRoleConfig.Id - bRoleConfig.Id);
	}

	// Token: 0x06013FAD RID: 81837 RVA: 0x005919B5 File Offset: 0x0058FBB5
	protected void UpdateSelectRoleInstance()
	{
	}

	// Token: 0x06013FAE RID: 81838 RVA: 0x005919B7 File Offset: 0x0058FBB7
	protected override void OnAfterShow()
	{
		this.TabViewComponent.SetCurrentTabViewState(true);
	}

	// Token: 0x06013FAF RID: 81839 RVA: 0x005919C8 File Offset: 0x0058FBC8
	protected void RebuildTabItem()
	{
		this.TabDataList = ConfigCommon.ToList<UiDynamicTab>(ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(EUiViewName.RoleHandBookRootView));
		int count = this.TabDataList.Count;
		this.TabComponent.RefreshTabItemByLength(count, null);
	}

	// Token: 0x06013FB0 RID: 81840 RVA: 0x00591A10 File Offset: 0x0058FC10
	protected override void OnStart()
	{
		base.InitTabComponent();
		base.GetButton(1).RootUIComp.Get().SetUIActive(false);
		base.GetItem(3).SetUIActive(false);
		if (this.IsNeedLoadSceneFlag)
		{
			this.UpdateSelectRoleInstance();
		}
		this.TabComponent.SelectToggleByIndex(0, true);
		this.LoadFloorEffect();
	}

	// Token: 0x06013FB1 RID: 81841 RVA: 0x00591A6B File Offset: 0x0058FC6B
	protected override void LoadFloorEffect()
	{
		if (!this.IsNeedLoadSceneFlag)
		{
			return;
		}
		base.LoadFloorEffect();
	}

	// Token: 0x06013FB2 RID: 81842 RVA: 0x00591A7C File Offset: 0x0058FC7C
	protected override void OnBeforeDestroy()
	{
		base.ClearData();
	}

	// Token: 0x06013FB3 RID: 81843 RVA: 0x00591A84 File Offset: 0x0058FC84
	protected override void OnAfterHide()
	{
		this.TabViewComponent.SetCurrentTabViewState(false);
	}

	// Token: 0x04009B8F RID: 39823
	private EUiViewName FromViewName;

	// Token: 0x04009B90 RID: 39824
	private bool IsNeedLoadSceneFlag = true;
}
