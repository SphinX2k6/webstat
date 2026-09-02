using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B43 RID: 11075
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsHandbookView : UiViewBase
{
	// Token: 0x0601615C RID: 90460 RVA: 0x00620B79 File Offset: 0x0061ED79
	public SurvivorsHandbookView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601615D RID: 90461 RVA: 0x00620B94 File Offset: 0x0061ED94
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0601615E RID: 90462 RVA: 0x00620BD0 File Offset: 0x0061EDD0
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsHandbookView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsHandbookView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601615F RID: 90463 RVA: 0x00620C14 File Offset: 0x0061EE14
	protected override void OnBeforeShow()
	{
		if (this.IsFirstShow)
		{
			this.InitUiSceneRoleActor();
			ISurvivorsHandbookViewOpenParams survivorsHandbookViewOpenParams = this.OpenParam as ISurvivorsHandbookViewOpenParams;
			int num = 0;
			if (survivorsHandbookViewOpenParams != null)
			{
				ESurvivorsRogueItemType selectTabType = survivorsHandbookViewOpenParams.SelectTabType;
				EUiTabViewName? viewName = this.GetTabViewName(selectTabType);
				if (viewName != null)
				{
					num = this.TabDataList.FindIndex(delegate(UiDynamicTab data)
					{
						string childViewName = data.ChildViewName;
						EUiTabViewName? viewName = viewName;
						return childViewName == ((viewName != null) ? viewName.GetValueOrDefault() : null);
					});
					if (num == -1)
					{
						num = 0;
					}
				}
				this.DefaultSelectId = survivorsHandbookViewOpenParams.SelectCfgId;
			}
			TabComponentWithCaptionItem<CommonTabItem> captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SelectToggleByIndex(num, true);
			}
			this.IsFirstShow = false;
		}
		ControllerBase<SurvivorsActivityController>.Instance.CheckIsActivityClose();
	}

	// Token: 0x06016160 RID: 90464 RVA: 0x00620CB8 File Offset: 0x0061EEB8
	private void InitUiSceneRoleActor()
	{
		UiModelBase model = this.TsUiSceneRoleActor.Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent != null)
		{
			uiModelActorComponent.SetTransformByTag("RoleCase");
		}
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, false, false);
	}

	// Token: 0x06016161 RID: 90465 RVA: 0x00620CF0 File Offset: 0x0061EEF0
	private UniTask InitHandbookTab()
	{
		SurvivorsHandbookView.<InitHandbookTab>d__11 <InitHandbookTab>d__;
		<InitHandbookTab>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitHandbookTab>d__.<>4__this = this;
		<InitHandbookTab>d__.<>1__state = -1;
		<InitHandbookTab>d__.<>t__builder.Start<SurvivorsHandbookView.<InitHandbookTab>d__11>(ref <InitHandbookTab>d__);
		return <InitHandbookTab>d__.<>t__builder.Task;
	}

	// Token: 0x06016162 RID: 90466 RVA: 0x00620D33 File Offset: 0x0061EF33
	private void InitTabViewComponent()
	{
		this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(0), EKeyMode.Default);
	}

	// Token: 0x06016163 RID: 90467 RVA: 0x00620D48 File Offset: 0x0061EF48
	private CommonTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x06016164 RID: 90468 RVA: 0x00620D50 File Offset: 0x0061EF50
	private void ToggleCallBack(int index)
	{
		UiDynamicTab data = this.TabDataList[index];
		EUiTabViewName viewName = (EUiTabViewName)data.ChildViewName;
		CommonTabItem tabItemByIndex = this.CaptionItem.GetTabItemByIndex(index);
		TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
		if (tabViewComponent != null)
		{
			tabViewComponent.ToggleCallBack(data, viewName, tabItemByIndex, this.DefaultSelectId, null);
		}
		if (this.DefaultSelectId != null)
		{
			this.DefaultSelectId = null;
		}
	}

	// Token: 0x06016165 RID: 90469 RVA: 0x00620DC8 File Offset: 0x0061EFC8
	private CommonTabData GetCommonData(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x06016166 RID: 90470 RVA: 0x00620E00 File Offset: 0x0061F000
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06016167 RID: 90471 RVA: 0x00620E0C File Offset: 0x0061F00C
	protected override void OnBeforeDestroy()
	{
		ModelBase<SurvivorsRogueModel>.Instance.SaveCacheHandbookClickedMap();
		if (this.TsUiSceneRoleActor != null)
		{
			Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.TsUiSceneRoleActor);
			this.TsUiSceneRoleActor = null;
		}
		if (this.CaptionItem != null)
		{
			this.CaptionItem.Destroy(null);
			this.CaptionItem = null;
		}
	}

	// Token: 0x06016168 RID: 90472 RVA: 0x00620E5E File Offset: 0x0061F05E
	protected override void OnAfterDestroy()
	{
		if (this.TsUiSceneRoleActor != null)
		{
			Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.TsUiSceneRoleActor);
			this.TsUiSceneRoleActor = null;
		}
	}

	// Token: 0x06016169 RID: 90473 RVA: 0x00620E80 File Offset: 0x0061F080
	private EUiTabViewName? GetTabViewName(ESurvivorsRogueItemType type)
	{
		switch (type)
		{
		case ESurvivorsRogueItemType.Normal:
			return new EUiTabViewName?(EUiTabViewName.SurvivorsItemTabView);
		case ESurvivorsRogueItemType.Weapon:
			return new EUiTabViewName?(EUiTabViewName.SurvivorsWeaponTabView);
		case ESurvivorsRogueItemType.Character:
			return new EUiTabViewName?(EUiTabViewName.SurvivorsRoleTabView);
		default:
			return null;
		}
	}

	// Token: 0x0400AA1A RID: 43546
	[Nullable(2)]
	private TsUiSceneRoleActor TsUiSceneRoleActor;

	// Token: 0x0400AA1B RID: 43547
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithCaptionItem<CommonTabItem> CaptionItem;

	// Token: 0x0400AA1C RID: 43548
	private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

	// Token: 0x0400AA1D RID: 43549
	[Nullable(2)]
	private TabViewComponent<UiDynamicTab> TabViewComponent;

	// Token: 0x0400AA1E RID: 43550
	private int? DefaultSelectId;

	// Token: 0x0400AA1F RID: 43551
	private bool IsFirstShow = true;
}
