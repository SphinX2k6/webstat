using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D16 RID: 11542
[NullableContext(1)]
[Nullable(0)]
public class WeaponRootView : UiViewBase
{
	// Token: 0x060174CE RID: 95438 RVA: 0x00675756 File Offset: 0x00673956
	public WeaponRootView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060174CF RID: 95439 RVA: 0x00675778 File Offset: 0x00673978
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060174D0 RID: 95440 RVA: 0x006757E4 File Offset: 0x006739E4
	protected override void OnBeforeCreate()
	{
		IWeaponRootViewParam weaponRootViewParam = this.OpenParam as IWeaponRootViewParam;
		if (weaponRootViewParam == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Weapon, ELogAuthor.LZK, "进入武器培养界面未传参", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!weaponRootViewParam.IsFromRoleRootView)
		{
			ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.WeaponLevelUpView);
		}
		this.WeaponIncId = weaponRootViewParam.WeaponIncId;
		this.WeaponSkinId = weaponRootViewParam.WeaponSkinId;
		this.WeaponObserver = Singleton<UiSceneManager>.Instance.InitWeaponObserver(false);
		this.WeaponScabbardObserver = Singleton<UiSceneManager>.Instance.InitWeaponScabbardObserver();
	}

	// Token: 0x060174D1 RID: 95441 RVA: 0x0067586C File Offset: 0x00673A6C
	protected override UniTask OnBeforeStartAsync()
	{
		WeaponRootView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeaponRootView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060174D2 RID: 95442 RVA: 0x006758AF File Offset: 0x00673AAF
	protected override void OnHandleLoadScene()
	{
		if (this.WeaponObserver == null)
		{
			this.WeaponObserver = Singleton<UiSceneManager>.Instance.InitWeaponObserver(false);
		}
		if (this.WeaponScabbardObserver == null)
		{
			this.WeaponScabbardObserver = Singleton<UiSceneManager>.Instance.InitWeaponScabbardObserver();
		}
	}

	// Token: 0x060174D3 RID: 95443 RVA: 0x006758E4 File Offset: 0x00673AE4
	protected override void OnBeforeShow()
	{
		Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.WeaponRootView, true);
		this.UpdateDynamicTabComponent();
		if (!Singleton<UiCameraAnimationManager>.Instance.IsPlayingAnimation())
		{
			if (this.IsFirstShowWeapon)
			{
				ControllerBase<WeaponController>.Instance.OnSelectedWeaponChange(ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId), this.WeaponObserver, this.WeaponScabbardObserver, this.WeaponSkinId, false);
				this.IsFirstShowWeapon = false;
			}
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.WeaponRootView, false);
		}
	}

	// Token: 0x060174D4 RID: 95444 RVA: 0x00675969 File Offset: 0x00673B69
	protected override void OnAfterShow()
	{
		ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.WeaponLevelUpView);
	}

	// Token: 0x060174D5 RID: 95445 RVA: 0x00675976 File Offset: 0x00673B76
	private WeaponTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? _)
	{
		return new WeaponTabItem();
	}

	// Token: 0x060174D6 RID: 95446 RVA: 0x00675980 File Offset: 0x00673B80
	private void ToggleCallBack(int index)
	{
		UiDynamicTab data = this.TabDataList[index];
		EUiTabViewName viewName = (EUiTabViewName)data.ChildViewName;
		WeaponTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		this.TabViewComponent.ToggleCallBack(data, viewName, tabItemByIndex, this.WeaponIncId, null);
	}

	// Token: 0x060174D7 RID: 95447 RVA: 0x006759D8 File Offset: 0x00673BD8
	private CommonTabData GetCommonData(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x060174D8 RID: 95448 RVA: 0x00675A10 File Offset: 0x00673C10
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WeaponCanGoBreach, new Action(this.WeaponCanGoBreachEvent));
		Singleton<EventSystem>.Instance.Add<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnCameraFinish));
	}

	// Token: 0x060174D9 RID: 95449 RVA: 0x00675A4A File Offset: 0x00673C4A
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WeaponCanGoBreach, new Action(this.WeaponCanGoBreachEvent));
		Singleton<EventSystem>.Instance.Remove<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnCameraFinish));
	}

	// Token: 0x060174DA RID: 95450 RVA: 0x00675A84 File Offset: 0x00673C84
	private void WeaponCanGoBreachEvent()
	{
		this.UpdateDynamicTabComponent();
	}

	// Token: 0x060174DB RID: 95451 RVA: 0x00675A8C File Offset: 0x00673C8C
	private void OnCameraFinish(UiCameraHandleData handleData)
	{
		if (handleData.ViewName != EUiViewName.WeaponRootView)
		{
			return;
		}
		Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.WeaponRootView, false);
		if (this.WeaponObserver != null && this.WeaponScabbardObserver != null && this.IsFirstShowWeapon)
		{
			ControllerBase<WeaponController>.Instance.OnSelectedWeaponChange(ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId), this.WeaponObserver, this.WeaponScabbardObserver, this.WeaponSkinId, false);
			this.IsFirstShowWeapon = false;
		}
	}

	// Token: 0x060174DC RID: 95452 RVA: 0x00675B12 File Offset: 0x00673D12
	protected override void OnBeforePlayCloseSequence()
	{
		this.ReleaseWeaponObserver();
	}

	// Token: 0x060174DD RID: 95453 RVA: 0x00675B1A File Offset: 0x00673D1A
	protected override void OnHandleReleaseScene()
	{
		this.ReleaseWeaponObserver();
	}

	// Token: 0x060174DE RID: 95454 RVA: 0x00675B24 File Offset: 0x00673D24
	private void ReleaseWeaponObserver()
	{
		if (this.WeaponObserver != null)
		{
			Singleton<UiSceneManager>.Instance.HideObserver(this.WeaponObserver, "ShowHideWeaponEffect");
			Singleton<UiSceneManager>.Instance.DestroyWeaponObserver(this.WeaponObserver);
			this.WeaponObserver = null;
		}
		if (this.WeaponScabbardObserver != null)
		{
			Singleton<UiSceneManager>.Instance.HideObserver(this.WeaponScabbardObserver, "ShowHideWeaponEffect");
			Singleton<UiSceneManager>.Instance.DestroyWeaponScabbardObserver(this.WeaponScabbardObserver);
			this.WeaponScabbardObserver = null;
		}
		this.IsFirstShowWeapon = true;
	}

	// Token: 0x060174DF RID: 95455 RVA: 0x00675BA0 File Offset: 0x00673DA0
	protected override void OnBeforeDestroy()
	{
		this.ReleaseWeaponObserver();
		this.UnBindRedDot();
		IWeaponRootViewParam weaponRootViewParam = this.OpenParam as IWeaponRootViewParam;
		if (weaponRootViewParam != null && weaponRootViewParam.IsFromRoleRootView && Singleton<UiSceneManager>.Instance.HasRoleSystemRoleActor())
		{
			ControllerBase<WeaponController>.Instance.RoleFadeOut(Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor(), "RoleFadeOutCurve");
		}
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		this.TabDataList.Clear();
		if (this.TabViewComponent != null)
		{
			this.TabViewComponent.DestroyTabViewComponent();
			this.TabViewComponent = null;
		}
	}

	// Token: 0x060174E0 RID: 95456 RVA: 0x00675C35 File Offset: 0x00673E35
	private void BackClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x060174E1 RID: 95457 RVA: 0x00675C40 File Offset: 0x00673E40
	protected void UpdateDynamicTabComponent()
	{
		this.TabDataList = this.GetWeaponTabList();
		int lastIndex = this.TabComponent.GetSelectedIndex();
		this.TabComponent.RefreshTabItemByLength(this.TabDataList.Count, delegate
		{
			int index = (lastIndex > 0) ? lastIndex : 0;
			this.TabComponent.SelectToggleByIndex(index, false);
			this.BindRedDot();
		});
	}

	// Token: 0x060174E2 RID: 95458 RVA: 0x00675C9C File Offset: 0x00673E9C
	public List<UiDynamicTab> GetWeaponTabList()
	{
		List<UiDynamicTab> list = new List<UiDynamicTab>();
		List<UiDynamicTab> viewTabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(EUiViewName.WeaponRootView);
		bool flag = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId).CanGoBreach();
		foreach (UiDynamicTab item in viewTabList)
		{
			if ((!(item.ChildViewName == EUiTabViewName.WeaponBreachView) || flag) && (!(item.ChildViewName == EUiTabViewName.WeaponLevelUpView) || !flag))
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x060174E3 RID: 95459 RVA: 0x00675D50 File Offset: 0x00673F50
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 1)
		{
			if (this.TabComponent == null)
			{
				return null;
			}
			if (this.TabComponent.GetTabComponent().GetLayout() == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.JT;
				string message = "角色界面聚焦引导的额外参数配置有误, 找不到Layout";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			int tabId = int.Parse(configParams[0]);
			UUIItem rootItem = this.TabComponent.GetTabItemByIndex(this.TabDataList.FindIndex((UiDynamicTab data) => data.Id == tabId)).GetRootItem();
			if (rootItem != null)
			{
				return new UUIItem[]
				{
					rootItem,
					rootItem
				};
			}
		}
		return null;
	}

	// Token: 0x060174E4 RID: 95460 RVA: 0x00675DFC File Offset: 0x00673FFC
	private void BindRedDot()
	{
		int num = this.TabDataList.FindIndex((UiDynamicTab config) => config.ChildViewName == EUiTabViewName.WeaponResonanceView);
		if (num >= 0)
		{
			WeaponTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(num);
			if (tabItemByIndex != null)
			{
				tabItemByIndex.BindRedDot(ERedDotName.RedDotWeaponResonanceTab, new int?(this.WeaponIncId));
			}
		}
	}

	// Token: 0x060174E5 RID: 95461 RVA: 0x00675E60 File Offset: 0x00674060
	private void UnBindRedDot()
	{
		int num = this.TabDataList.FindIndex((UiDynamicTab config) => config.ChildViewName == EUiTabViewName.WeaponResonanceView);
		if (num >= 0)
		{
			WeaponTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(num);
			if (tabItemByIndex != null)
			{
				tabItemByIndex.UnBindRedDot();
				ControllerBase<RedDotController>.Instance.UnBindRedDotAndClearData(ERedDotName.RedDotWeaponResonanceTab);
			}
		}
	}

	// Token: 0x0400B2EE RID: 45806
	[Nullable(2)]
	protected TabViewComponent<UiDynamicTab> TabViewComponent;

	// Token: 0x0400B2EF RID: 45807
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponentWithCaptionItem<WeaponTabItem> TabComponent;

	// Token: 0x0400B2F0 RID: 45808
	protected List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

	// Token: 0x0400B2F1 RID: 45809
	private bool IsFirstShowWeapon = true;

	// Token: 0x0400B2F2 RID: 45810
	private int WeaponIncId;

	// Token: 0x0400B2F3 RID: 45811
	private int WeaponSkinId = -1;

	// Token: 0x0400B2F4 RID: 45812
	[Nullable(2)]
	private SkeletalObserverHandle WeaponObserver;

	// Token: 0x0400B2F5 RID: 45813
	[Nullable(2)]
	private SkeletalObserverHandle WeaponScabbardObserver;

	// Token: 0x02008FDB RID: 36827
	[NullableContext(0)]
	private enum EWeaponRootViewDefine
	{
		// Token: 0x04030477 RID: 197751
		CaptionList,
		// Token: 0x04030478 RID: 197752
		ViewItem
	}
}
