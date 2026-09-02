using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.HandBook;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.UiComponent;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E8E RID: 7822
[NullableContext(1)]
[Nullable(0)]
public class HandBookRoleView : UiViewBase
{
	// Token: 0x0600E73B RID: 59195 RVA: 0x003E72B2 File Offset: 0x003E54B2
	public HandBookRoleView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E73C RID: 59196 RVA: 0x003E72C8 File Offset: 0x003E54C8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnDetailClick))
		};
	}

	// Token: 0x0600E73D RID: 59197 RVA: 0x003E73B3 File Offset: 0x003E55B3
	protected override void OnBeforeCreateImplementImplement()
	{
		this.UiSceneRoleActor = Singleton<UiSceneManager>.Instance.InitRoleSystemRoleActor(EUiModelUseWay.RoleInRoleView);
	}

	// Token: 0x0600E73E RID: 59198 RVA: 0x003E73C8 File Offset: 0x003E55C8
	protected override void OnStart()
	{
		this.RoleScrollView = new LoopScrollView<HandBookRoleMediumItemGird, RoleDataBase>(base.GetLoopScrollViewComponent(2), base.GetItem(3).GetOwner() as AUIBaseActor, new Func<HandBookRoleMediumItemGird>(this.OnGridProxyCreate), false);
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(delegate
		{
			base.CloseMe(null);
		});
		this.CaptionItem.SetTitleLocalText("HandBookRoleTitle");
		this.FilterSortEntrance = new FilterSortEntrance<RoleDataBase>(base.GetItem(4), new TUpdateDataListFunction<RoleDataBase>(this.UpdateList));
		List<RoleDataBase> list = new List<RoleDataBase>();
		IReadOnlyList<RoleInfo> roleList = ConfigBase<RoleConfig>.Instance.GetRoleList();
		if (roleList == null)
		{
			return;
		}
		List<RoleInfo> list2 = new List<RoleInfo>();
		foreach (RoleInfo item in roleList)
		{
			if (item.RoleType == 1 && !ModelBase<RoleModel>.Instance.IsMainRole(item.Id) && ModelBase<HandBookModel>.Instance.GetRoleCanShowInHandBook(item.Id))
			{
				list2.Add(item);
			}
		}
		foreach (RoleInfo roleInfo in list2)
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleInfo.Id, true);
			if (roleDataById != null)
			{
				list.Add(roleDataById);
			}
			else
			{
				list.Add(new RoleRobotData(roleInfo.TrialRole));
			}
		}
		list.Add(ModelBase<RoleModel>.Instance.GetCurSelectMainRoleInstance());
		this.FilterSortEntrance.UpdateData(EFilterSortGroupId.RoleHandBook, list, Array.Empty<object>());
		this.InitRole();
		this.RefreshCollectText();
	}

	// Token: 0x0600E73F RID: 59199 RVA: 0x003E7580 File Offset: 0x003E5780
	protected void RefreshCollectText()
	{
		int[] collectProgress = ControllerBase<HandBookController>.Instance.GetCollectProgress(EHandBookTabType.Role);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(7), "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
		{
			collectProgress[0],
			collectProgress[1]
		}));
	}

	// Token: 0x0600E740 RID: 59200 RVA: 0x003E75D1 File Offset: 0x003E57D1
	protected override void OnHandleLoadScene()
	{
		this.InitRole();
	}

	// Token: 0x0600E741 RID: 59201 RVA: 0x003E75D9 File Offset: 0x003E57D9
	protected override void OnBeforeShowImplementImplement()
	{
		UiSceneUtils.SetSceneFloorReflection(true, false);
	}

	// Token: 0x0600E742 RID: 59202 RVA: 0x003E75E2 File Offset: 0x003E57E2
	protected void InitRole()
	{
		UiModelBase model = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor().Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent == null)
		{
			return;
		}
		uiModelActorComponent.SetTransformByTag("RoleCase");
	}

	// Token: 0x0600E743 RID: 59203 RVA: 0x003E7610 File Offset: 0x003E5810
	private void UpdateList(List<RoleDataBase> list, bool isOutSideChange, EFilterSortType OperationType)
	{
		List<RoleDataBase> list2 = new List<RoleDataBase>();
		foreach (RoleDataBase roleDataBase in list)
		{
			if (roleDataBase != null)
			{
				RoleDataBase item = roleDataBase;
				list2.Add(item);
			}
		}
		this.RoleDataList = list2;
		this.RefreshRoleItem(list2);
	}

	// Token: 0x0600E744 RID: 59204 RVA: 0x003E7678 File Offset: 0x003E5878
	private void RefreshRoleItem(List<RoleDataBase> roleList)
	{
		this.RoleScrollView.DeselectCurrentGridProxy(false);
		this.RoleScrollView.RefreshByData(roleList, false, delegate
		{
			int num = 0;
			foreach (RoleDataBase roleDataBase in roleList)
			{
				int dataId = roleDataBase.GetDataId();
				int? curSelectRoleId = this.CurSelectRoleId;
				if (dataId == curSelectRoleId.GetValueOrDefault() & curSelectRoleId != null)
				{
					this.RoleScrollView.ScrollToGridIndex(num, true);
					this.RoleScrollView.SelectGridProxy(num, false);
					return;
				}
				num++;
			}
			if (this.RoleDataList.Count > 0)
			{
				this.SelectGridByRoleData(this.RoleDataList[0], true);
			}
		}, false);
	}

	// Token: 0x0600E745 RID: 59205 RVA: 0x003E76C4 File Offset: 0x003E58C4
	private void SelectGridByRoleData(RoleDataBase roleInstance, bool needScroll = false)
	{
		int num = this.RoleDataList.IndexOf(roleInstance);
		if (num >= 0)
		{
			if (needScroll)
			{
				this.RoleScrollView.ScrollToGridIndex(num, true);
			}
			this.RoleScrollView.SelectGridProxy(num, false);
			this.ChangeRoleByRoleId(roleInstance);
		}
	}

	// Token: 0x0600E746 RID: 59206 RVA: 0x003E7708 File Offset: 0x003E5908
	private void ChangeRoleByRoleId(RoleDataBase roleInstance)
	{
		int dataId = roleInstance.GetDataId();
		int valueOrDefault = this.CurSelectRoleId.GetValueOrDefault();
		int? curSelectRoleId = this.CurSelectRoleId;
		int num = dataId;
		if (curSelectRoleId.GetValueOrDefault() == num & curSelectRoleId != null)
		{
			return;
		}
		this.CurSelectRoleId = new int?(dataId);
		this.SetNameText(roleInstance.GetName(null));
		UUIText text = base.GetText(6);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("HandBookRoleGetDate", null);
		if (dataId < 100000)
		{
			text.SetUIActive(true);
			text.SetText(localTextNew + Singleton<TimeUtil>.Instance.DateFormat4String((double)roleInstance.GetRoleCreateTime()), true);
		}
		else
		{
			text.SetUIActive(false);
		}
		ControllerBase<RoleController>.Instance.OnSelectedRoleChange(this.CurSelectRoleId.Value, roleInstance.GetRoleConfig().SkinId);
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, valueOrDefault > 0, false);
	}

	// Token: 0x0600E747 RID: 59207 RVA: 0x003E77EA File Offset: 0x003E59EA
	private void SetNameText(string nameText)
	{
		base.GetText(1).SetText(nameText, true);
	}

	// Token: 0x0600E748 RID: 59208 RVA: 0x003E77FA File Offset: 0x003E59FA
	private HandBookRoleMediumItemGird OnGridProxyCreate()
	{
		HandBookRoleMediumItemGird handBookRoleMediumItemGird = new HandBookRoleMediumItemGird();
		handBookRoleMediumItemGird.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.ToggleFunction));
		handBookRoleMediumItemGird.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeFunction));
		return handBookRoleMediumItemGird;
	}

	// Token: 0x0600E749 RID: 59209 RVA: 0x003E7828 File Offset: 0x003E5A28
	private void ToggleFunction(MediumItemGridExtendCallback callbackParameter)
	{
		int state = (int)callbackParameter.State;
		RoleDataBase roleInstance = callbackParameter.Data as RoleDataBase;
		if (state == 1)
		{
			this.RoleScrollView.DeselectCurrentGridProxy(false);
			this.SelectGridByRoleData(roleInstance, false);
		}
	}

	// Token: 0x0600E74A RID: 59210 RVA: 0x003E7860 File Offset: 0x003E5A60
	[NullableContext(2)]
	private bool CanExecuteChangeFunction(object data, bool isForceSelected, EToggleState state)
	{
		if (Singleton<UiCameraAnimationManager>.Instance.IsPlayingAnimation() && this.CurSelectRoleId != null && state == EToggleState.ETT_UnChecked)
		{
			return false;
		}
		RoleDataBase roleDataBase = data as RoleDataBase;
		if (state == EToggleState.ETT_Checked)
		{
			int? curSelectRoleId = this.CurSelectRoleId;
			int dataId = roleDataBase.GetDataId();
			return !(curSelectRoleId.GetValueOrDefault() == dataId & curSelectRoleId != null);
		}
		return true;
	}

	// Token: 0x0600E74B RID: 59211 RVA: 0x003E78BB File Offset: 0x003E5ABB
	protected override void OnBeforeDestroy()
	{
		Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.UiSceneRoleActor);
		this.RoleScrollView = null;
	}

	// Token: 0x0600E74C RID: 59212 RVA: 0x003E78D8 File Offset: 0x003E5AD8
	private void OnDetailClick()
	{
		RoleInfo? roleInfo;
		int? num = (ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.CurSelectRoleId.Value) != null) ? new int?(roleInfo.GetValueOrDefault().TrialRole) : null;
		List<int> roleIdList = new List<int>
		{
			num.Value
		};
		ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, 0, roleIdList, null, delegate(bool _, int _)
		{
		});
	}

	// Token: 0x04006F8F RID: 28559
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<HandBookRoleMediumItemGird, RoleDataBase> RoleScrollView;

	// Token: 0x04006F90 RID: 28560
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04006F91 RID: 28561
	[Nullable(2)]
	private TsUiSceneRoleActor UiSceneRoleActor;

	// Token: 0x04006F92 RID: 28562
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<RoleDataBase> FilterSortEntrance;

	// Token: 0x04006F93 RID: 28563
	private int? CurSelectRoleId;

	// Token: 0x04006F94 RID: 28564
	private List<RoleDataBase> RoleDataList = new List<RoleDataBase>();

	// Token: 0x020081D0 RID: 33232
	[NullableContext(0)]
	private class EHandBookRoleViewDefine
	{
		// Token: 0x0402C0B7 RID: 180407
		public const int TitleItem = 0;

		// Token: 0x0402C0B8 RID: 180408
		public const int RoleName = 1;

		// Token: 0x0402C0B9 RID: 180409
		public const int ScrollView = 2;

		// Token: 0x0402C0BA RID: 180410
		public const int ScrollViewItem = 3;

		// Token: 0x0402C0BB RID: 180411
		public const int FilterSortItem = 4;

		// Token: 0x0402C0BC RID: 180412
		public const int DetailBtn = 5;

		// Token: 0x0402C0BD RID: 180413
		public const int DateText = 6;

		// Token: 0x0402C0BE RID: 180414
		public const int CollectCountText = 7;
	}
}
