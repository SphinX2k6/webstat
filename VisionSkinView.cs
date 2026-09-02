using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002549 RID: 9545
[NullableContext(1)]
[Nullable(0)]
public class VisionSkinView : UiViewBase
{
	// Token: 0x06012928 RID: 76072 RVA: 0x0051D922 File Offset: 0x0051BB22
	public VisionSkinView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012929 RID: 76073 RVA: 0x0051D93C File Offset: 0x0051BB3C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickDefaultBtn)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickUseSkinBtn)),
			new ValueTuple<int, Delegate>(9, new Action(this.OnClickGetTipsBtn))
		};
	}

	// Token: 0x0601292A RID: 76074 RVA: 0x0051DA88 File Offset: 0x0051BC88
	protected override void OnStart()
	{
		this.IsChangeDefaultSkin = false;
		base.GetItem(2).SetUIActive(false);
		this.VisionSkeletalHandle = Singleton<UiSceneManager>.Instance.GetVisionSkeletalHandle();
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnClickBackBtn));
		this.CaptionItem.SetTitleByTextIdAndArgNew("VisionSkinTitleText", Array.Empty<object>());
		this.CaptionItem.SetHelpBtnActive(false);
		this.PhantomLoopScrollView = new LoopScrollView<VisionSkinItem, int>(base.GetLoopScrollViewComponent(6), base.GetItem(7).GetOwner() as AUIBaseActor, new Func<VisionSkinItem>(this.OnCreateItem), false);
		this.CurrentParam = (this.OpenParam as IVisionSkinViewOpenParam);
		IVisionSkinViewOpenParam currentParam = this.CurrentParam;
		if (currentParam != null && currentParam.UniqueId != null)
		{
			this.InitByUniqueId(this.CurrentParam.UniqueId.Value);
			return;
		}
		IVisionSkinViewOpenParam currentParam2 = this.CurrentParam;
		if (((currentParam2 != null) ? currentParam2.ShowItemIdList : null) != null)
		{
			this.InitByItemIdList(this.CurrentParam.ShowItemIdList);
		}
	}

	// Token: 0x0601292B RID: 76075 RVA: 0x0051DBA0 File Offset: 0x0051BDA0
	private void InitByUniqueId(int uniqueId)
	{
		this.CurrentUniqueId = uniqueId;
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		this.CurrentMonsterId = phantomItemDataByUniqueId.GetConfig().MonsterId;
		this.CurrentEquipmentSkin = phantomItemDataByUniqueId.SkinId;
		string monsterName = phantomItemDataByUniqueId.GetSkinConfig().MonsterName;
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(phantomItemDataByUniqueId.GetConfig().MonsterName, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "ChangeDefaultVisionSkinText", new <>z__ReadOnlySingleElementList<object>(localTextNew));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), monsterName, Array.Empty<object>());
	}

	// Token: 0x0601292C RID: 76076 RVA: 0x0051DC40 File Offset: 0x0051BE40
	private void InitByItemIdList(int[] itemIdList)
	{
		PhantomItem? phantomItemById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(itemIdList[0]);
		if (phantomItemById == null)
		{
			return;
		}
		string monsterName = phantomItemById.Value.MonsterName;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), monsterName, Array.Empty<object>());
		UUIItem item = base.GetItem(8);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIButtonComponent button = base.GetButton(1);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		UUIButtonComponent button2 = base.GetButton(4);
		if (button2 == null)
		{
			return;
		}
		button2.RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0601292D RID: 76077 RVA: 0x0051DCDE File Offset: 0x0051BEDE
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnVisionSkinEquip, new Action(this.RefreshItemCurrentEquipment));
	}

	// Token: 0x0601292E RID: 76078 RVA: 0x0051DCFC File Offset: 0x0051BEFC
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionSkinEquip, new Action(this.RefreshItemCurrentEquipment));
	}

	// Token: 0x0601292F RID: 76079 RVA: 0x0051DD1A File Offset: 0x0051BF1A
	protected override void OnBeforeShow()
	{
		if (this.CurrentMonsterId > 0)
		{
			this.ShowByUniqueId(this.CurrentMonsterId);
			return;
		}
		IVisionSkinViewOpenParam currentParam = this.CurrentParam;
		if (((currentParam != null) ? currentParam.ShowItemIdList : null) != null)
		{
			this.ShowByItemIdList(this.CurrentParam.ShowItemIdList);
		}
	}

	// Token: 0x06012930 RID: 76080 RVA: 0x0051DD58 File Offset: 0x0051BF58
	private void ShowByUniqueId(int uniqueId)
	{
		int[] phantomList = ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinListByMonsterId(uniqueId);
		if (phantomList == null)
		{
			return;
		}
		int selectIndex = 0;
		selectIndex = ((this.CurrentEquipmentSkin != 0) ? phantomList.ToList<int>().IndexOf(this.CurrentEquipmentSkin) : 0);
		if (selectIndex == -1)
		{
			selectIndex = 0;
		}
		LoopScrollView<VisionSkinItem, int> phantomLoopScrollView = this.PhantomLoopScrollView;
		if (phantomLoopScrollView != null)
		{
			phantomLoopScrollView.RefreshByData(phantomList.ToList<int>(), false, delegate
			{
				LoopScrollView<VisionSkinItem, int> phantomLoopScrollView2 = this.PhantomLoopScrollView;
				if (phantomLoopScrollView2 != null)
				{
					phantomLoopScrollView2.SelectGridProxy(selectIndex, false);
				}
				VisionSkinView <>4__this = this;
				LoopScrollView<VisionSkinItem, int> phantomLoopScrollView3 = this.PhantomLoopScrollView;
				<>4__this.CurrentPhantom = ((phantomLoopScrollView3 != null) ? phantomLoopScrollView3.UnsafeGetGridProxy(selectIndex, false) : null);
				VisionSkinView <>4__this2 = this;
				VisionSkinItem currentPhantom = this.CurrentPhantom;
				<>4__this2.CurrentToggle = ((currentPhantom != null) ? currentPhantom.GetItemGridExtendToggle() : null);
				VisionSkinItem currentPhantom2 = this.CurrentPhantom;
				if (currentPhantom2 != null)
				{
					currentPhantom2.SetCurrentEquipmentVisible(true);
				}
				this.CurrentItemId = phantomList[selectIndex];
				this.OriginalItemId = this.CurrentItemId;
			}, false);
		}
		this.SetLockShow(false);
		this.SetUseSkinBtnEnable(false);
	}

	// Token: 0x06012931 RID: 76081 RVA: 0x0051DE04 File Offset: 0x0051C004
	private void ShowByItemIdList(int[] configList)
	{
		int selectedIndex = Array.IndexOf<int>(configList, this.CurrentItemId);
		if (selectedIndex < 0)
		{
			selectedIndex = 0;
		}
		LoopScrollView<VisionSkinItem, int> phantomLoopScrollView = this.PhantomLoopScrollView;
		if (phantomLoopScrollView == null)
		{
			return;
		}
		phantomLoopScrollView.RefreshByData(configList.ToList<int>(), false, delegate
		{
			LoopScrollView<VisionSkinItem, int> phantomLoopScrollView2 = this.PhantomLoopScrollView;
			if (phantomLoopScrollView2 != null)
			{
				phantomLoopScrollView2.ScrollToGridIndex(selectedIndex, true);
			}
			LoopScrollView<VisionSkinItem, int> phantomLoopScrollView3 = this.PhantomLoopScrollView;
			if (phantomLoopScrollView3 != null)
			{
				phantomLoopScrollView3.SelectGridProxy(selectedIndex, false);
			}
			LoopScrollView<VisionSkinItem, int> phantomLoopScrollView4 = this.PhantomLoopScrollView;
			UUIExtendToggle uuiextendToggle;
			if (phantomLoopScrollView4 == null)
			{
				uuiextendToggle = null;
			}
			else
			{
				VisionSkinItem visionSkinItem = phantomLoopScrollView4.UnsafeGetGridProxy(selectedIndex, false);
				uuiextendToggle = ((visionSkinItem != null) ? visionSkinItem.GetItemGridExtendToggle() : null);
			}
			UUIExtendToggle toggle = uuiextendToggle;
			this.OnPhantomItemClick(configList[selectedIndex], toggle);
		}, false);
	}

	// Token: 0x06012932 RID: 76082 RVA: 0x0051DE78 File Offset: 0x0051C078
	private void RefreshMesh(int itemId)
	{
		if (this.CurrentItemId == itemId)
		{
			this.PlayMeshEffect();
			return;
		}
		this.CheckAndCreateVisionHandle();
		IVisionSkinViewOpenParam currentParam = this.CurrentParam;
		bool isChangeLocation = ((currentParam != null) ? currentParam.ShowItemIdList : null) != null;
		ControllerBase<PhantomBattleController>.Instance.SetMeshShow(itemId, new Action(this.PlayMeshEffect), this.VisionSkeletalHandle, isChangeLocation);
		this.CurrentItemId = itemId;
	}

	// Token: 0x06012933 RID: 76083 RVA: 0x0051DED8 File Offset: 0x0051C0D8
	private void PlayMeshEffect()
	{
		if (this.VisionSkeletalHandle == null)
		{
			return;
		}
		UiModelBase model = this.VisionSkeletalHandle.Model;
		if (model == null)
		{
			return;
		}
		Singleton<UiModelUtil>.Instance.PlayEffectOnRoot(model, "VisionLevelUpEffect");
		Singleton<UiModelUtil>.Instance.SetRenderingMaterial(model, "VisionStepupController");
	}

	// Token: 0x06012934 RID: 76084 RVA: 0x0051DF1F File Offset: 0x0051C11F
	private void CheckAndCreateVisionHandle()
	{
		if (!Singleton<UiSceneManager>.Instance.HasVisionSkeletalHandle())
		{
			Singleton<UiSceneManager>.Instance.InitVisionSkeletalHandle();
		}
		this.VisionSkeletalHandle = Singleton<UiSceneManager>.Instance.GetVisionSkeletalHandle();
	}

	// Token: 0x06012935 RID: 76085 RVA: 0x0051DF47 File Offset: 0x0051C147
	private void OnClickDefaultBtn()
	{
		this.IsChangeDefaultSkin = !this.IsChangeDefaultSkin;
		base.GetItem(2).SetUIActive(this.IsChangeDefaultSkin);
	}

	// Token: 0x06012936 RID: 76086 RVA: 0x0051DF6C File Offset: 0x0051C16C
	private void OnClickUseSkinBtn()
	{
		PhantomItem? phantomItemById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(this.CurrentItemId);
		ControllerBase<PhantomBattleController>.Instance.PhantomSkinChangeRequest(this.CurrentUniqueId, (phantomItemById != null && phantomItemById.GetValueOrDefault().ParentMonsterId > 0) ? this.CurrentItemId : 0, this.IsChangeDefaultSkin);
		this.PlayMeshEffect();
	}

	// Token: 0x06012937 RID: 76087 RVA: 0x0051DFCF File Offset: 0x0051C1CF
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06012938 RID: 76088 RVA: 0x0051DFD8 File Offset: 0x0051C1D8
	private void OnClickGetTipsBtn()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.CurrentItemId, true, null);
	}

	// Token: 0x06012939 RID: 76089 RVA: 0x0051DFEC File Offset: 0x0051C1EC
	private VisionSkinItem OnCreateItem()
	{
		VisionSkinItem visionSkinItem = new VisionSkinItem();
		visionSkinItem.SetClickToggleEvent(new Action<int, UUIExtendToggle>(this.OnPhantomItemClick));
		visionSkinItem.BindCanToggleExecuteChange(new Func<int, bool>(this.CanToggleChange));
		return visionSkinItem;
	}

	// Token: 0x0601293A RID: 76090 RVA: 0x0051E018 File Offset: 0x0051C218
	private void OnPhantomItemClick(int data, UUIExtendToggle toggle)
	{
		UUIExtendToggle currentToggle = this.CurrentToggle;
		if (currentToggle != null)
		{
			currentToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentToggle = toggle;
		PhantomItem? phantomItemById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(data);
		if (phantomItemById == null)
		{
			return;
		}
		string monsterName = phantomItemById.Value.MonsterName;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), monsterName, Array.Empty<object>());
		this.RefreshMesh(data);
		if (this.OnlyShow)
		{
			return;
		}
		int parentMonsterId = phantomItemById.Value.ParentMonsterId;
		this.SetLockShow(phantomItemById.Value.ParentMonsterId > 0 && !ModelBase<PhantomBattleModel>.Instance.GetSkinIsUnlock(data));
		if (this.CurrentEquipmentSkin != 0)
		{
			this.SetUseSkinBtnEnable(data != this.CurrentEquipmentSkin);
			return;
		}
		int parentMonsterId2 = phantomItemById.Value.ParentMonsterId;
		this.SetUseSkinBtnEnable(phantomItemById.Value.ParentMonsterId > 0);
	}

	// Token: 0x0601293B RID: 76091 RVA: 0x0051E10C File Offset: 0x0051C30C
	private void SetLockShow(bool isLock)
	{
		UUIItem item = base.GetItem(8);
		if (item != null)
		{
			item.SetUIActive(isLock);
		}
		UUIButtonComponent button = base.GetButton(9);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(isLock);
		}
		UUIButtonComponent button2 = base.GetButton(4);
		if (button2 == null)
		{
			return;
		}
		button2.RootUIComp.Get().SetUIActive(!isLock);
	}

	// Token: 0x0601293C RID: 76092 RVA: 0x0051E16F File Offset: 0x0051C36F
	private void SetUseSkinBtnEnable(bool able)
	{
		UUIButtonComponent button = base.GetButton(4);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(able);
	}

	// Token: 0x0601293D RID: 76093 RVA: 0x0051E183 File Offset: 0x0051C383
	private bool CanToggleChange(int currentItemId)
	{
		return this.CurrentItemId != currentItemId;
	}

	// Token: 0x0601293E RID: 76094 RVA: 0x0051E194 File Offset: 0x0051C394
	private void RefreshItemCurrentEquipment()
	{
		if (this.OnlyShow)
		{
			return;
		}
		int[] monsterSkinListByMonsterId = ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinListByMonsterId(this.CurrentMonsterId);
		if (monsterSkinListByMonsterId == null)
		{
			return;
		}
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		this.CurrentEquipmentSkin = phantomItemDataByUniqueId.SkinId;
		int num = (this.CurrentEquipmentSkin != 0) ? monsterSkinListByMonsterId.ToList<int>().IndexOf(this.CurrentEquipmentSkin) : 0;
		if (num == -1)
		{
			num = 0;
		}
		VisionSkinItem currentPhantom = this.CurrentPhantom;
		if (currentPhantom != null)
		{
			currentPhantom.SetCurrentEquipmentVisible(false);
		}
		LoopScrollView<VisionSkinItem, int> phantomLoopScrollView = this.PhantomLoopScrollView;
		this.CurrentPhantom = ((phantomLoopScrollView != null) ? phantomLoopScrollView.UnsafeGetGridProxy(num, false) : null);
		VisionSkinItem currentPhantom2 = this.CurrentPhantom;
		if (currentPhantom2 != null)
		{
			currentPhantom2.SetCurrentEquipmentVisible(true);
		}
		this.SetUseSkinBtnEnable(false);
	}

	// Token: 0x0601293F RID: 76095 RVA: 0x0051E24A File Offset: 0x0051C44A
	protected override void OnAfterDestroy()
	{
		if (this.OnlyShow)
		{
			Singleton<UiSceneManager>.Instance.DestroyVisionSkeletalHandle();
			return;
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.VisionSkinViewClose, this.CurrentItemId != this.OriginalItemId);
	}

	// Token: 0x17001785 RID: 6021
	// (get) Token: 0x06012940 RID: 76096 RVA: 0x0051E280 File Offset: 0x0051C480
	private bool OnlyShow
	{
		get
		{
			IVisionSkinViewOpenParam currentParam = this.CurrentParam;
			return ((currentParam != null) ? currentParam.ShowItemIdList : null) != null;
		}
	}

	// Token: 0x040090B6 RID: 37046
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x040090B7 RID: 37047
	[Nullable(2)]
	private IVisionSkinViewOpenParam CurrentParam;

	// Token: 0x040090B8 RID: 37048
	private int CurrentUniqueId = -1;

	// Token: 0x040090B9 RID: 37049
	private int CurrentMonsterId = -1;

	// Token: 0x040090BA RID: 37050
	private int CurrentItemId;

	// Token: 0x040090BB RID: 37051
	private int OriginalItemId;

	// Token: 0x040090BC RID: 37052
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<VisionSkinItem, int> PhantomLoopScrollView;

	// Token: 0x040090BD RID: 37053
	[Nullable(2)]
	private VisionSkinItem CurrentPhantom;

	// Token: 0x040090BE RID: 37054
	private bool IsChangeDefaultSkin;

	// Token: 0x040090BF RID: 37055
	[Nullable(2)]
	private SkeletalObserverHandle VisionSkeletalHandle;

	// Token: 0x040090C0 RID: 37056
	[Nullable(2)]
	private UUIExtendToggle CurrentToggle;

	// Token: 0x040090C1 RID: 37057
	private int CurrentEquipmentSkin;

	// Token: 0x0200886F RID: 34927
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E15C RID: 188764
		CaptionItem,
		// Token: 0x0402E15D RID: 188765
		DefaultBtn,
		// Token: 0x0402E15E RID: 188766
		DefaultMarkItem,
		// Token: 0x0402E15F RID: 188767
		DefaultText,
		// Token: 0x0402E160 RID: 188768
		UseSkinBtn,
		// Token: 0x0402E161 RID: 188769
		MonsterNameText,
		// Token: 0x0402E162 RID: 188770
		MonsterLoopScrollView,
		// Token: 0x0402E163 RID: 188771
		MonsterItem,
		// Token: 0x0402E164 RID: 188772
		LockItem,
		// Token: 0x0402E165 RID: 188773
		GetTipsBtn
	}
}
