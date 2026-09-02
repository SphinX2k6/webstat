using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002814 RID: 10260
[NullableContext(2)]
[Nullable(0)]
public class RoleDevPhantomViewItem : UiPanelBase
{
	// Token: 0x060143FB RID: 82939 RVA: 0x005A2E74 File Offset: 0x005A1074
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickSwitch))
		};
	}

	// Token: 0x060143FC RID: 82940 RVA: 0x005A2FA4 File Offset: 0x005A11A4
	protected override UniTask OnBeforeStartAsync()
	{
		RoleDevPhantomViewItem.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevPhantomViewItem.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060143FD RID: 82941 RVA: 0x005A2FE7 File Offset: 0x005A11E7
	protected override void OnBeforeCreateImplement()
	{
		this.UiViewSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiViewSequence);
	}

	// Token: 0x060143FE RID: 82942 RVA: 0x005A3004 File Offset: 0x005A1204
	private UniTask InitVisionHeadItems()
	{
		RoleDevPhantomViewItem.<InitVisionHeadItems>d__14 <InitVisionHeadItems>d__;
		<InitVisionHeadItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitVisionHeadItems>d__.<>4__this = this;
		<InitVisionHeadItems>d__.<>1__state = -1;
		<InitVisionHeadItems>d__.<>t__builder.Start<RoleDevPhantomViewItem.<InitVisionHeadItems>d__14>(ref <InitVisionHeadItems>d__);
		return <InitVisionHeadItems>d__.<>t__builder.Task;
	}

	// Token: 0x060143FF RID: 82943 RVA: 0x005A3047 File Offset: 0x005A1247
	private void InitPanelSuit()
	{
		this.SuitLayout = new GenericLayout<RoleDevPhantomSuitItem, RoleDevPhantomSuitItemData>(base.GetVerticalLayout(9), new Func<RoleDevPhantomSuitItem>(this.InitSuitLayoutItem), null, false, true);
	}

	// Token: 0x06014400 RID: 82944 RVA: 0x005A306B File Offset: 0x005A126B
	[NullableContext(1)]
	private RoleDevPhantomSuitItem InitSuitLayoutItem()
	{
		return new RoleDevPhantomSuitItem();
	}

	// Token: 0x06014401 RID: 82945 RVA: 0x005A3074 File Offset: 0x005A1274
	[NullableContext(1)]
	public void Refresh(RoleDevPhantomViewItemDataBase data)
	{
		this.Data = data;
		if (ModelBase<RoleModel>.Instance.GetRoleDataById(data.RoleId, true) == null)
		{
			base.GetItem(0).SetUIActive(false);
			this.RefreshSuitList(data.SuitDataList);
			return;
		}
		base.GetItem(0).SetUIActive(true);
		this.RefreshSuitList(data.SuitDataList);
		this.RefreshPhantomItems(data.RoleId);
		this.RefreshDevelopButtons();
		this.SetVisionHeadItems();
	}

	// Token: 0x06014402 RID: 82946 RVA: 0x005A30EC File Offset: 0x005A12EC
	private void SetVisionHeadItems()
	{
		int count = this.RoleVisionItems.Count;
		for (int i = 0; i < count; i++)
		{
			this.RoleVisionItems[i].SetRoleId(this.Data.RoleId);
		}
	}

	// Token: 0x06014403 RID: 82947 RVA: 0x005A3130 File Offset: 0x005A1330
	private void RefreshPhantomItems(int roleId)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		if (roleDataById == null)
		{
			return;
		}
		List<PhantomDataBase> currentViewShowPhantomList = ModelBase<PhantomBattleModel>.Instance.GetCurrentViewShowPhantomList(roleDataById);
		int count = this.RoleVisionItems.Count;
		for (int i = 0; i < count; i++)
		{
			PhantomDataBase data = (currentViewShowPhantomList != null && currentViewShowPhantomList.Count > i) ? currentViewShowPhantomList[i] : null;
			this.RoleVisionItems[i].UpdateItem(data);
		}
	}

	// Token: 0x06014404 RID: 82948 RVA: 0x005A319D File Offset: 0x005A139D
	private void RefreshDevelopButtons()
	{
		base.GetItem(2).SetUIActive(false);
		this.ButtonDevelop.SetFunction(new Action<int>(this.OnClickDevelop));
		this.ButtonDevelop.SetLocalTextNew("RoleProject_Button01", Array.Empty<object>());
	}

	// Token: 0x06014405 RID: 82949 RVA: 0x005A31D8 File Offset: 0x005A13D8
	[NullableContext(1)]
	private void RefreshSuitList(List<RoleDevPhantomSuitItemData> suitDataList)
	{
		if (this.SuitLayout != null)
		{
			this.SuitLayout.RefreshByData(suitDataList, null, false);
		}
	}

	// Token: 0x06014406 RID: 82950 RVA: 0x005A31F0 File Offset: 0x005A13F0
	private void OnClickDevelop(int _)
	{
		ControllerBase<RoleDevController>.Instance.LogRoleDevSubPageClick(this.Data.RoleId, ERoleDevMainPage.Phantom, ERoleDevSubPageButton.PhantomGoToCultivation);
		int num = 0;
		ModelBase<PhantomBattleModel>.Instance.CurrentEquipmentSelectIndex = num;
		int equipByIndex = ControllerBase<PhantomBattleController>.Instance.GetEquipByIndex(this.Data.RoleId, num);
		ModelBase<PhantomBattleModel>.Instance.CurrentSelectUniqueId = equipByIndex;
		PhantomUtil.OpenVisionEquipmentView(this.Data.RoleId, num, null);
	}

	// Token: 0x06014407 RID: 82951 RVA: 0x005A3260 File Offset: 0x005A1460
	private void OnClickSwitch()
	{
		ControllerBase<RoleDevController>.Instance.LogRoleDevSubPageClick(this.Data.RoleId, ERoleDevMainPage.Phantom, ERoleDevSubPageButton.SwitchScheme);
		VisionRecommendViewOpenParam param = new VisionRecommendViewOpenParam
		{
			RoleId = this.Data.RoleId,
			IsFromRoleDev = true,
			SuccessCallBack = new Action<int, int, int?>(this.OnChangeFetterGroupSuccessInternal),
			GetSelectedPlanIdCallBack = new Func<int, int>(this.OnGetSelectedPlanIdInternal)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionNewRecommendView, param, null);
	}

	// Token: 0x06014408 RID: 82952 RVA: 0x005A32D8 File Offset: 0x005A14D8
	private UniTask InitDevelopButtons()
	{
		RoleDevPhantomViewItem.<InitDevelopButtons>d__24 <InitDevelopButtons>d__;
		<InitDevelopButtons>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitDevelopButtons>d__.<>4__this = this;
		<InitDevelopButtons>d__.<>1__state = -1;
		<InitDevelopButtons>d__.<>t__builder.Start<RoleDevPhantomViewItem.<InitDevelopButtons>d__24>(ref <InitDevelopButtons>d__);
		return <InitDevelopButtons>d__.<>t__builder.Task;
	}

	// Token: 0x06014409 RID: 82953 RVA: 0x005A331B File Offset: 0x005A151B
	private void OnChangeFetterGroupSuccessInternal(int roleId, int planId, int? firstVisionMonsterId)
	{
		RoleDevPhantomViewItemDataBase data = this.Data;
		if (data != null)
		{
			RoleDevViewModel roleDevViewModel = data.RoleDevViewModel;
			if (roleDevViewModel != null)
			{
				roleDevViewModel.SetRoleRecommendPlanId(roleId, planId);
			}
		}
		Action<int, int> onChangeFetterGroupSuccessCallBack = this.OnChangeFetterGroupSuccessCallBack;
		if (onChangeFetterGroupSuccessCallBack == null)
		{
			return;
		}
		onChangeFetterGroupSuccessCallBack(roleId, planId);
	}

	// Token: 0x0601440A RID: 82954 RVA: 0x005A3350 File Offset: 0x005A1550
	private int OnGetSelectedPlanIdInternal(int roleId)
	{
		RoleDevPhantomViewItemDataBase data = this.Data;
		int? num;
		if (data == null)
		{
			num = null;
		}
		else
		{
			RoleDevViewModel roleDevViewModel = data.RoleDevViewModel;
			num = ((roleDevViewModel != null) ? new int?(roleDevViewModel.GetRoleRecommendPlanId(roleId)) : null);
		}
		int? num2 = num;
		return num2.GetValueOrDefault();
	}

	// Token: 0x04009D8A RID: 40330
	public Action<int> OnClickToggleCallBack;

	// Token: 0x04009D8B RID: 40331
	public Func<int, bool> CanClickCallBack;

	// Token: 0x04009D8C RID: 40332
	public Action<int> OnDevelopCallBack;

	// Token: 0x04009D8D RID: 40333
	public Action<int> OnPerfectDevelopCallBack;

	// Token: 0x04009D8E RID: 40334
	public Action<int, int> OnChangeFetterGroupSuccessCallBack;

	// Token: 0x04009D8F RID: 40335
	[Nullable(1)]
	private readonly List<RoleDevPhantomHeadItem> RoleVisionItems = new List<RoleDevPhantomHeadItem>();

	// Token: 0x04009D90 RID: 40336
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleDevPhantomSuitItem, RoleDevPhantomSuitItemData> SuitLayout;

	// Token: 0x04009D91 RID: 40337
	private ButtonItem ButtonDevelop;

	// Token: 0x04009D92 RID: 40338
	public UiBehaviorLevelSequence UiViewSequence;

	// Token: 0x04009D93 RID: 40339
	private RoleDevPhantomViewItemDataBase Data;

	// Token: 0x02008B9E RID: 35742
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F0D5 RID: 192725
		PanelPhantomDev,
		// Token: 0x0402F0D6 RID: 192726
		BtnDevelop,
		// Token: 0x0402F0D7 RID: 192727
		BtnPerfectDevelop,
		// Token: 0x0402F0D8 RID: 192728
		SubPhantomCircle1,
		// Token: 0x0402F0D9 RID: 192729
		SubPhantomCircle2,
		// Token: 0x0402F0DA RID: 192730
		SubPhantomCircle3,
		// Token: 0x0402F0DB RID: 192731
		SubPhantomCircle4,
		// Token: 0x0402F0DC RID: 192732
		SubPhantomCircle5,
		// Token: 0x0402F0DD RID: 192733
		BtnSwitch,
		// Token: 0x0402F0DE RID: 192734
		PanelSuitLayout,
		// Token: 0x0402F0DF RID: 192735
		PanelSuit
	}
}
