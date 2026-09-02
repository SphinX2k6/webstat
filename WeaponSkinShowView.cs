using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A6D RID: 10861
[NullableContext(1)]
[Nullable(0)]
public class WeaponSkinShowView : UiTickViewBase
{
	// Token: 0x06015C3C RID: 89148 RVA: 0x0060A32A File Offset: 0x0060852A
	public WeaponSkinShowView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015C3D RID: 89149 RVA: 0x0060A34C File Offset: 0x0060854C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(5, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClickHideToggle))
		};
	}

	// Token: 0x06015C3E RID: 89150 RVA: 0x0060A424 File Offset: 0x00608624
	protected override void OnStart()
	{
		ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.WeaponLevelUpView);
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseView));
		this.CaptionItem.SetHelpBtnActive(false);
		this.CaptionItem.SetTitleLocalText("WeaponSkin_Preview");
		WeaponSkinShowViewData weaponSkinShowViewData = this.OpenParam as WeaponSkinShowViewData;
		List<int> list = ((weaponSkinShowViewData != null) ? weaponSkinShowViewData.SkinIdList : null) ?? new List<int>();
		this.SkinDataList = new List<WeaponSkinData>();
		foreach (int skinId in list)
		{
			WeaponSkinModel instance = ModelBase<WeaponSkinModel>.Instance;
			int valueOrDefault = ((instance != null) ? instance.GetRoleIdBySkinId(skinId) : null).GetValueOrDefault();
			this.SkinDataList.Add(new WeaponSkinData(skinId, valueOrDefault));
		}
		this.SkinScrollView = new LoopScrollView<WeaponSkinPreviewGridItem, WeaponSkinData>(base.GetLoopScrollViewComponent(5), base.GetItem(6).GetOwner() as AUIBaseActor, new Func<WeaponSkinPreviewGridItem>(this.CreateSkinGridItem), false);
	}

	// Token: 0x06015C3F RID: 89151 RVA: 0x0060A54C File Offset: 0x0060874C
	protected override UniTask OnHandlePostLoadSceneAsync(bool isSceneLoad)
	{
		WeaponSkinShowView.<OnHandlePostLoadSceneAsync>d__11 <OnHandlePostLoadSceneAsync>d__;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePostLoadSceneAsync>d__.<>4__this = this;
		<OnHandlePostLoadSceneAsync>d__.<>1__state = -1;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder.Start<WeaponSkinShowView.<OnHandlePostLoadSceneAsync>d__11>(ref <OnHandlePostLoadSceneAsync>d__);
		return <OnHandlePostLoadSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015C40 RID: 89152 RVA: 0x0060A590 File Offset: 0x00608790
	protected override UniTask OnHandlePreReleaseSceneAsync(bool isSceneRelease)
	{
		WeaponSkinShowView.<OnHandlePreReleaseSceneAsync>d__12 <OnHandlePreReleaseSceneAsync>d__;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePreReleaseSceneAsync>d__.isSceneRelease = isSceneRelease;
		<OnHandlePreReleaseSceneAsync>d__.<>1__state = -1;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder.Start<WeaponSkinShowView.<OnHandlePreReleaseSceneAsync>d__12>(ref <OnHandlePreReleaseSceneAsync>d__);
		return <OnHandlePreReleaseSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015C41 RID: 89153 RVA: 0x0060A5D4 File Offset: 0x006087D4
	protected override void OnBeforeDestroy()
	{
		ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.None);
		if (this.WeaponObserver != null)
		{
			Singleton<UiSceneManager>.Instance.DestroyWeaponObserver(this.WeaponObserver);
			this.WeaponObserver = null;
		}
		if (this.WeaponScabbardObserver != null)
		{
			Singleton<UiSceneManager>.Instance.DestroyWeaponScabbardObserver(this.WeaponScabbardObserver);
			this.WeaponScabbardObserver = null;
		}
	}

	// Token: 0x06015C42 RID: 89154 RVA: 0x0060A62A File Offset: 0x0060882A
	private WeaponSkinPreviewGridItem CreateSkinGridItem()
	{
		WeaponSkinPreviewGridItem weaponSkinPreviewGridItem = new WeaponSkinPreviewGridItem();
		weaponSkinPreviewGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnClickSkinGridItem));
		return weaponSkinPreviewGridItem;
	}

	// Token: 0x06015C43 RID: 89155 RVA: 0x0060A644 File Offset: 0x00608844
	private void OnClickSkinGridItem(MediumItemGridExtendCallback parameters)
	{
		WeaponSkinData weaponSkinData = parameters.Data as WeaponSkinData;
		if (weaponSkinData == null)
		{
			return;
		}
		this.SwitchSkin(weaponSkinData.SkinId);
	}

	// Token: 0x06015C44 RID: 89156 RVA: 0x0060A66D File Offset: 0x0060886D
	private void SelectSkinByIndex(int index)
	{
		LoopScrollView<WeaponSkinPreviewGridItem, WeaponSkinData> skinScrollView = this.SkinScrollView;
		if (skinScrollView != null)
		{
			skinScrollView.DeselectCurrentGridProxy(false);
		}
		LoopScrollView<WeaponSkinPreviewGridItem, WeaponSkinData> skinScrollView2 = this.SkinScrollView;
		if (skinScrollView2 != null)
		{
			skinScrollView2.SelectGridProxy(index, true);
		}
		this.SwitchSkin(this.SkinDataList[index].SkinId);
	}

	// Token: 0x06015C45 RID: 89157 RVA: 0x0060A6AB File Offset: 0x006088AB
	private void SwitchSkin(int skinId)
	{
		if (this.CurrentSkinId == skinId)
		{
			return;
		}
		this.CurrentSkinId = skinId;
		this.LoadWeaponModel(skinId);
		this.RefreshText(skinId);
	}

	// Token: 0x06015C46 RID: 89158 RVA: 0x0060A6CC File Offset: 0x006088CC
	private void LoadWeaponModel(int skinId)
	{
		if (this.WeaponObserver == null || this.WeaponScabbardObserver == null)
		{
			return;
		}
		WeaponSkin weaponSkinConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponSkinConfig(skinId);
		this.TrialWeaponData.SetTrialId(weaponSkinConfig.HandBookTrialId, true);
		ControllerBase<WeaponController>.Instance.OnSelectedWeaponChange(this.TrialWeaponData, this.WeaponObserver, this.WeaponScabbardObserver, skinId, false);
	}

	// Token: 0x06015C47 RID: 89159 RVA: 0x0060A728 File Offset: 0x00608928
	private void RefreshText(int skinId)
	{
		WeaponSkin weaponSkinConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponSkinConfig(skinId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), weaponSkinConfig.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), weaponSkinConfig.BgDescription, Array.Empty<object>());
	}

	// Token: 0x06015C48 RID: 89160 RVA: 0x0060A77B File Offset: 0x0060897B
	private void OnClickHideToggle(EToggleState toggleState)
	{
		UUIItem item = base.GetItem(1);
		item.SetUIActive(!item.bIsUIActive);
	}

	// Token: 0x06015C49 RID: 89161 RVA: 0x0060A792 File Offset: 0x00608992
	private void OnCloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400A6E4 RID: 42724
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400A6E5 RID: 42725
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<WeaponSkinPreviewGridItem, WeaponSkinData> SkinScrollView;

	// Token: 0x0400A6E6 RID: 42726
	private List<WeaponSkinData> SkinDataList = new List<WeaponSkinData>();

	// Token: 0x0400A6E7 RID: 42727
	[Nullable(2)]
	private SkeletalObserverHandle WeaponObserver;

	// Token: 0x0400A6E8 RID: 42728
	[Nullable(2)]
	private SkeletalObserverHandle WeaponScabbardObserver;

	// Token: 0x0400A6E9 RID: 42729
	private readonly WeaponTrialData TrialWeaponData = new WeaponTrialData();

	// Token: 0x0400A6EA RID: 42730
	private int CurrentSkinId;

	// Token: 0x02008DED RID: 36333
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402FC17 RID: 195607
		CaptionItem,
		// Token: 0x0402FC18 RID: 195608
		HideRootItem,
		// Token: 0x0402FC19 RID: 195609
		TitleText,
		// Token: 0x0402FC1A RID: 195610
		DescText,
		// Token: 0x0402FC1B RID: 195611
		HideToggle,
		// Token: 0x0402FC1C RID: 195612
		LoopScrollView,
		// Token: 0x0402FC1D RID: 195613
		WeaponSkinItem
	}
}
