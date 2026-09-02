using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002542 RID: 9538
[NullableContext(1)]
[Nullable(0)]
public class VisionRecommendView : UiViewBase
{
	// Token: 0x060128F9 RID: 76025 RVA: 0x0051CDD6 File Offset: 0x0051AFD6
	public VisionRecommendView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060128FA RID: 76026 RVA: 0x0051CDE0 File Offset: 0x0051AFE0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickGoFetterGroupDetailViewBtn))
		};
	}

	// Token: 0x060128FB RID: 76027 RVA: 0x0051CECC File Offset: 0x0051B0CC
	protected override void OnStart()
	{
		IVisionRecommendViewOpenParam visionRecommendViewOpenParam = this.OpenParam as IVisionRecommendViewOpenParam;
		if (visionRecommendViewOpenParam == null)
		{
			return;
		}
		this.CurrentSelectRoleId = visionRecommendViewOpenParam.RoleId;
		this.IsFromRoleDev = visionRecommendViewOpenParam.IsFromRoleDev;
		this.OnChangeFetterGroupSuccessCallBack = visionRecommendViewOpenParam.SuccessCallBack;
		this.GetSelectedPlanIdCallBack = visionRecommendViewOpenParam.GetSelectedPlanIdCallBack;
		this.FetterItemLayout = new GenericLayout<FetterItemContent, FetterGroupContentData>(base.GetVerticalLayout(0), new Func<FetterItemContent>(this.InitGridItem), null, false, true);
		this.Layout = new GenericLayout<VisionFetterDescItem, VisionFetterDescData>(base.GetVerticalLayout(4), new Func<VisionFetterDescItem>(this.InitItem), null, false, true);
		this.InitBtnConfirmChange();
		this.InitBtnConfirmBox();
		this.RefreshButtonVisibility();
	}

	// Token: 0x060128FC RID: 76028 RVA: 0x0051CF6D File Offset: 0x0051B16D
	private void InitBtnConfirmChange()
	{
		this.BtnConfirmChange = new ButtonItem(base.GetItem(7));
		this.BtnConfirmChange.SetLocalTextNew("RoleProject_PhantomRecommend_Tips01", Array.Empty<object>());
		this.BtnConfirmChange.SetFunction(new Action<int>(this.OnClickBtnConfirmChange));
	}

	// Token: 0x060128FD RID: 76029 RVA: 0x0051CFAD File Offset: 0x0051B1AD
	private void InitBtnConfirmBox()
	{
		this.BtnConfirmBox = new ButtonItem(base.GetItem(6));
		this.BtnConfirmBox.SetLocalTextNew("PrefabTextItem_PhantomQuickEquip_Text", Array.Empty<object>());
		this.BtnConfirmBox.SetFunction(new Action<int>(this.OnClickConfirmBoxBtn));
	}

	// Token: 0x060128FE RID: 76030 RVA: 0x0051CFF0 File Offset: 0x0051B1F0
	private void RefreshButtonVisibility()
	{
		UUIItem item = base.GetItem(6);
		UUIItem item2 = base.GetItem(7);
		if (this.IsFromRoleDev)
		{
			if (item != null)
			{
				item.SetUIActive(false);
			}
			if (item2 != null)
			{
				item2.SetUIActive(true);
				return;
			}
		}
		else
		{
			if (item != null)
			{
				item.SetUIActive(true);
			}
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
		}
	}

	// Token: 0x060128FF RID: 76031 RVA: 0x0051D03E File Offset: 0x0051B23E
	private VisionFetterDescItem InitItem()
	{
		return new VisionFetterDescItem();
	}

	// Token: 0x06012900 RID: 76032 RVA: 0x0051D045 File Offset: 0x0051B245
	private FetterItemContent InitGridItem()
	{
		return new FetterItemContent();
	}

	// Token: 0x06012901 RID: 76033 RVA: 0x0051D04C File Offset: 0x0051B24C
	private void OnClickConfirmBoxBtn(int _)
	{
		this.TryOneKeyEquip();
	}

	// Token: 0x06012902 RID: 76034 RVA: 0x0051D054 File Offset: 0x0051B254
	private void TryOneKeyEquip()
	{
		List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.CurrentSelectRoleId);
		if (roleFetterRecommendInfo == null || roleFetterRecommendInfo.Count == 0)
		{
			return;
		}
		VisionFetterRecommendInfo recommendInfo = roleFetterRecommendInfo[this.CurrentSelectIndex];
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.CurrentSelectRoleId, true);
		if (roleDataById == null)
		{
			return;
		}
		if (!ModelBase<PhantomBattleModel>.Instance.GetRoleIfEquipVision(roleDataById.GetRoleId()))
		{
			int[] recommendEquipUniqueIdList = ModelBase<VisionRecommendModel>.Instance.GetRecommendEquipUniqueIdList(roleDataById.GetRoleId(), recommendInfo);
			if (recommendEquipUniqueIdList != null)
			{
				ControllerBase<PhantomBattleController>.Instance.SendPhantomAutoPutRequest(roleDataById.GetRoleId(), recommendEquipUniqueIdList.ToList<int>(), null);
				Singleton<UiManager>.Instance.CloseView(EUiViewName.VisionRecommendView, null);
				return;
			}
		}
		else
		{
			this.DoOpenSupplementConfirmBox();
		}
	}

	// Token: 0x06012903 RID: 76035 RVA: 0x0051D0F8 File Offset: 0x0051B2F8
	private void DoOpenSupplementConfirmBox()
	{
		List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.CurrentSelectRoleId);
		if (roleFetterRecommendInfo == null || roleFetterRecommendInfo.Count == 0)
		{
			return;
		}
		VisionFetterRecommendInfo currentSelectRecommendInfo = roleFetterRecommendInfo[this.CurrentSelectIndex];
		RoleDataBase roleInstance = ModelBase<RoleModel>.Instance.GetRoleDataById(this.CurrentSelectRoleId, true);
		if (roleInstance == null)
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomSupplementTips);
		confirmBoxDataNew.FunctionMap.Add(1, delegate
		{
			ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
		});
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			int[] recommendEquipUniqueIdList = ModelBase<VisionRecommendModel>.Instance.GetRecommendEquipUniqueIdList(roleInstance.GetRoleId(), currentSelectRecommendInfo);
			ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
			if (recommendEquipUniqueIdList != null)
			{
				ControllerBase<PhantomBattleController>.Instance.SendPhantomAutoPutRequest(roleInstance.GetRoleId(), recommendEquipUniqueIdList.ToList<int>(), null);
			}
			Singleton<UiManager>.Instance.CloseView(EUiViewName.VisionRecommendView, null);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06012904 RID: 76036 RVA: 0x0051D1B1 File Offset: 0x0051B3B1
	private void OnClickGoFetterGroupDetailViewBtn()
	{
		base.CloseMe(delegate(bool _)
		{
			List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.CurrentSelectRoleId);
			if (roleFetterRecommendInfo == null || roleFetterRecommendInfo.Count == 0)
			{
				return;
			}
			bool showFastFilter = ModelBase<RoleModel>.Instance.IsRoleOwned(this.CurrentSelectRoleId);
			VisionFetterRecommendInfo visionFetterRecommendInfo = roleFetterRecommendInfo[this.CurrentSelectIndex];
			ControllerBase<PhantomBattleController>.Instance.OpenPhantomBattleFetterView(visionFetterRecommendInfo.GetRecommendFetterGroupId(), this.CurrentSelectRoleId, showFastFilter, visionFetterRecommendInfo.BuildFetterList()).Forget();
			Singleton<EventSystem>.Instance.Emit(EEventName.HideVisionTabRole);
		});
	}

	// Token: 0x06012905 RID: 76037 RVA: 0x0051D1C5 File Offset: 0x0051B3C5
	private void OnClickFetterGroupContentItem(FetterGroupContentData data)
	{
		this.CurrentSelectIndex = data.Index;
		this.RefreshFetterLayout();
		this.RefreshViewInfoByCurrentSelectIndex(this.CurrentSelectIndex);
		this.RefreshSelectGroupName();
		this.RefreshBtnConfirmChangeState();
	}

	// Token: 0x06012906 RID: 76038 RVA: 0x0051D1F1 File Offset: 0x0051B3F1
	protected override void OnBeforeShow()
	{
		this.CurrentSelectIndex = 0;
		this.RefreshFetterLayout();
		this.RefreshViewInfoByCurrentSelectIndex(this.CurrentSelectIndex);
		this.RefreshSelectGroupName();
		this.RefreshBtnConfirmChangeState();
		this.RefreshButtonVisibility();
	}

	// Token: 0x06012907 RID: 76039 RVA: 0x0051D220 File Offset: 0x0051B420
	private void RefreshFetterLayout()
	{
		List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.CurrentSelectRoleId);
		if (roleFetterRecommendInfo != null)
		{
			roleFetterRecommendInfo.Sort((VisionFetterRecommendInfo a, VisionFetterRecommendInfo b) => b.GetUsage() - a.GetUsage());
		}
		List<FetterGroupContentData> list = new List<FetterGroupContentData>();
		int num = (roleFetterRecommendInfo != null) ? roleFetterRecommendInfo.Count : 0;
		for (int i = 0; i < num; i++)
		{
			list.Add(new FetterGroupContentData
			{
				Index = i,
				CurrentSelectIndex = this.CurrentSelectIndex,
				VisionFetterRecommendInfo = roleFetterRecommendInfo[i],
				ClickCallBack = new Action<FetterGroupContentData>(this.OnClickFetterGroupContentItem)
			});
		}
		GenericLayout<FetterItemContent, FetterGroupContentData> fetterItemLayout = this.FetterItemLayout;
		if (fetterItemLayout == null)
		{
			return;
		}
		fetterItemLayout.RefreshByData(list, null, false);
	}

	// Token: 0x06012908 RID: 76040 RVA: 0x0051D2E0 File Offset: 0x0051B4E0
	private void RefreshFetterInfoLayout(VisionFetterRecommendInfo data)
	{
		List<VisionFetterDescData> fetterDescByRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetFetterDescByRecommendInfo(data);
		if (fetterDescByRecommendInfo != null)
		{
			GenericLayout<VisionFetterDescItem, VisionFetterDescData> layout = this.Layout;
			if (layout == null)
			{
				return;
			}
			layout.RefreshByData(fetterDescByRecommendInfo, null, false);
		}
	}

	// Token: 0x06012909 RID: 76041 RVA: 0x0051D310 File Offset: 0x0051B510
	private void RefreshViewInfoByCurrentSelectIndex(int selectIndex)
	{
		List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.CurrentSelectRoleId);
		if (roleFetterRecommendInfo == null || roleFetterRecommendInfo.Count == 0)
		{
			return;
		}
		VisionFetterRecommendInfo data = roleFetterRecommendInfo[selectIndex];
		this.RefreshFetterInfoLayout(data);
	}

	// Token: 0x0601290A RID: 76042 RVA: 0x0051D34C File Offset: 0x0051B54C
	private void RefreshSelectGroupName()
	{
		List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.CurrentSelectRoleId);
		if (roleFetterRecommendInfo == null || roleFetterRecommendInfo.Count == 0)
		{
			return;
		}
		VisionFetterRecommendInfo visionFetterRecommendInfo = roleFetterRecommendInfo[this.CurrentSelectIndex];
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(visionFetterRecommendInfo.GetRecommendFetterGroupId());
		base.GetText(2).ShowTextNew(fetterGroupById.FetterGroupName);
	}

	// Token: 0x0601290B RID: 76043 RVA: 0x0051D3A8 File Offset: 0x0051B5A8
	private void RefreshBtnConfirmChangeState()
	{
		if (!this.IsFromRoleDev || this.GetSelectedPlanIdCallBack == null)
		{
			return;
		}
		List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.CurrentSelectRoleId);
		if (roleFetterRecommendInfo == null || roleFetterRecommendInfo.Count == 0)
		{
			return;
		}
		VisionFetterRecommendInfo visionFetterRecommendInfo = roleFetterRecommendInfo[this.CurrentSelectIndex];
		if (this.GetSelectedPlanIdCallBack(this.CurrentSelectRoleId) == visionFetterRecommendInfo.GetPlanId())
		{
			this.BtnConfirmChange.SetLocalTextNew("RoleProject_PhantomRecommend_Tips01", Array.Empty<object>());
			this.BtnConfirmChange.SetEnableClick(false);
			return;
		}
		this.BtnConfirmChange.SetLocalTextNew("RoleProject_PhantomRecommend_Button01", Array.Empty<object>());
		this.BtnConfirmChange.SetEnableClick(true);
	}

	// Token: 0x0601290C RID: 76044 RVA: 0x0051D450 File Offset: 0x0051B650
	private void OnClickBtnConfirmChange(int _)
	{
		if (!this.IsFromRoleDev)
		{
			return;
		}
		List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.CurrentSelectRoleId);
		if (roleFetterRecommendInfo == null || roleFetterRecommendInfo.Count == 0)
		{
			return;
		}
		VisionFetterRecommendInfo visionFetterRecommendInfo = roleFetterRecommendInfo[this.CurrentSelectIndex];
		Action<int, int, int?> onChangeFetterGroupSuccessCallBack = this.OnChangeFetterGroupSuccessCallBack;
		if (onChangeFetterGroupSuccessCallBack != null)
		{
			onChangeFetterGroupSuccessCallBack(this.CurrentSelectRoleId, visionFetterRecommendInfo.GetPlanId(), null);
		}
		base.CloseMe(null);
	}

	// Token: 0x0400909D RID: 37021
	[Nullable(2)]
	private ButtonItem BtnConfirmChange;

	// Token: 0x0400909E RID: 37022
	[Nullable(2)]
	private ButtonItem BtnConfirmBox;

	// Token: 0x0400909F RID: 37023
	private int CurrentSelectIndex;

	// Token: 0x040090A0 RID: 37024
	private int CurrentSelectRoleId;

	// Token: 0x040090A1 RID: 37025
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<FetterItemContent, FetterGroupContentData> FetterItemLayout;

	// Token: 0x040090A2 RID: 37026
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionFetterDescItem, VisionFetterDescData> Layout;

	// Token: 0x040090A3 RID: 37027
	private bool IsFromRoleDev;

	// Token: 0x040090A4 RID: 37028
	[Nullable(2)]
	private Action<int, int, int?> OnChangeFetterGroupSuccessCallBack;

	// Token: 0x040090A5 RID: 37029
	[Nullable(2)]
	private Func<int, int> GetSelectedPlanIdCallBack;

	// Token: 0x0200886B RID: 34923
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E14A RID: 188746
		FetterGroupVerticalLayout,
		// Token: 0x0402E14B RID: 188747
		FetterGroupItem,
		// Token: 0x0402E14C RID: 188748
		SelectFetterGroupName,
		// Token: 0x0402E14D RID: 188749
		GoFetterGroupDetailViewBtn,
		// Token: 0x0402E14E RID: 188750
		FetterGroupContentVerticalLayout,
		// Token: 0x0402E14F RID: 188751
		FetterGroupContentItem,
		// Token: 0x0402E150 RID: 188752
		ConfirmBoxBtn,
		// Token: 0x0402E151 RID: 188753
		BtnConfirmChange
	}
}
