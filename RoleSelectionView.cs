using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028FE RID: 10494
[NullableContext(1)]
[Nullable(0)]
public class RoleSelectionView : UiViewBase
{
	// Token: 0x06014D85 RID: 85381 RVA: 0x005C6501 File Offset: 0x005C4701
	public RoleSelectionView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014D86 RID: 85382 RVA: 0x005C6518 File Offset: 0x005C4718
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.BackFunction))
		};
	}

	// Token: 0x06014D87 RID: 85383 RVA: 0x005C65D8 File Offset: 0x005C47D8
	protected override void OnStart()
	{
		this.RoleScrollView = new LoopScrollView<RoleSelectionMediumItemGrid, RoleDataBase>(base.GetLoopScrollViewComponent(3), base.GetItem(4).GetOwner() as AUIBaseActor, new Func<RoleSelectionMediumItemGrid>(this.OnGridProxyCreate), false);
		this.FilterSortEntrance = new FilterSortEntrance<RoleDataBase>(base.GetItem(5), new TUpdateDataListFunction<RoleDataBase>(this.UpdateList));
		this.RoleViewAgent = (this.OpenParam as RoleViewAgent);
		IEnumerable<int> roleIdList = this.RoleViewAgent.GetRoleIdList();
		List<RoleDataBase> list = new List<RoleDataBase>();
		foreach (int id in roleIdList)
		{
			list.Add(ModelBase<RoleModel>.Instance.GetRoleDataById(id, true));
		}
		this.FilterSortEntrance.UpdateData(EFilterSortGroupId.Role, list, Array.Empty<object>());
	}

	// Token: 0x06014D88 RID: 85384 RVA: 0x005C66AC File Offset: 0x005C48AC
	protected override void OnBeforeDestroy()
	{
		ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.RoleDataItem);
		Singleton<EventSystem>.Instance.Emit(EEventName.RoleSelectionListUpdate);
		this.FilterSortEntrance.Destroy(null);
		this.FilterSortEntrance = null;
		this.RoleScrollView.ClearGridProxies();
		this.RoleScrollView = null;
		this.RoleDataList = new List<RoleDataBase>();
	}

	// Token: 0x06014D89 RID: 85385 RVA: 0x005C6708 File Offset: 0x005C4908
	protected override void OnBeforeShow()
	{
		RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
		this.EnterRoleId = new int?(this.RoleViewAgent.GetCurSelectRoleId());
		this.SelectGridByRoleData(curSelectRoleData, true);
	}

	// Token: 0x06014D8A RID: 85386 RVA: 0x005C6740 File Offset: 0x005C4940
	private void BackFunction()
	{
		int? enterRoleId = this.EnterRoleId;
		int? curSelectRoleId = this.CurSelectRoleId;
		if (!(enterRoleId.GetValueOrDefault() == curSelectRoleId.GetValueOrDefault() & enterRoleId != null == (curSelectRoleId != null)))
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleSystemChangeRole, this.CurSelectRoleId.Value);
		}
		base.CloseMe(null);
	}

	// Token: 0x06014D8B RID: 85387 RVA: 0x005C67A0 File Offset: 0x005C49A0
	private RoleSelectionMediumItemGrid OnGridProxyCreate()
	{
		RoleSelectionMediumItemGrid roleSelectionMediumItemGrid = new RoleSelectionMediumItemGrid();
		IRoleSystemUiParams roleSystemUiParams = this.RoleViewAgent.GetRoleSystemUiParams();
		roleSelectionMediumItemGrid.SetNeedShowTrial(roleSystemUiParams.RoleListNeedTrial);
		roleSelectionMediumItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.ToggleFunction));
		roleSelectionMediumItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeFunction));
		return roleSelectionMediumItemGrid;
	}

	// Token: 0x06014D8C RID: 85388 RVA: 0x005C67EE File Offset: 0x005C49EE
	private void UpdateList(List<RoleDataBase> list, bool isOutSideChange, EFilterSortType operationType)
	{
		this.RoleDataList = list;
		this.RefreshRoleItem(this.RoleDataList, isOutSideChange, operationType);
	}

	// Token: 0x06014D8D RID: 85389 RVA: 0x005C6808 File Offset: 0x005C4A08
	private void RefreshRoleItem(List<RoleDataBase> roleList, bool isOutSideChange, EFilterSortType operationType)
	{
		this.RoleScrollView.DeselectCurrentGridProxy(false);
		this.RoleScrollView.ReloadData(roleList, false);
		if (this.CurSelectRoleId == null)
		{
			return;
		}
		if (roleList.Count <= 0)
		{
			return;
		}
		int num = 0;
		if (operationType == EFilterSortType.Filter)
		{
			num = roleList.FindIndex(delegate(RoleDataBase roleDataBase)
			{
				int dataId = roleDataBase.GetDataId();
				int? curSelectRoleId = this.CurSelectRoleId;
				return dataId == curSelectRoleId.GetValueOrDefault() & curSelectRoleId != null;
			});
			num = ((num <= 0) ? 0 : num);
		}
		this.RoleScrollView.ScrollToGridIndex(num, true);
		this.RoleScrollView.SelectGridProxy(num, false);
		this.SelectGridByRoleData(roleList[num], true);
	}

	// Token: 0x06014D8E RID: 85390 RVA: 0x005C688F File Offset: 0x005C4A8F
	private void SetNameText(string nameText)
	{
		base.GetText(2).SetText(nameText, true);
	}

	// Token: 0x06014D8F RID: 85391 RVA: 0x005C68A0 File Offset: 0x005C4AA0
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
		this.RoleViewAgent.SetCurSelectRoleId(this.CurSelectRoleId.Value);
		ControllerBase<RoleController>.Instance.OnSelectedRoleChange(this.CurSelectRoleId.Value, roleInstance.GetRoleSkinId());
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, valueOrDefault > 0, false);
	}

	// Token: 0x06014D90 RID: 85392 RVA: 0x005C6944 File Offset: 0x005C4B44
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

	// Token: 0x06014D91 RID: 85393 RVA: 0x005C697C File Offset: 0x005C4B7C
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

	// Token: 0x06014D92 RID: 85394 RVA: 0x005C69C0 File Offset: 0x005C4BC0
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
			int roleId = roleDataBase.GetRoleId();
			return !(curSelectRoleId.GetValueOrDefault() == roleId & curSelectRoleId != null);
		}
		return true;
	}

	// Token: 0x0400A063 RID: 41059
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<RoleDataBase> FilterSortEntrance;

	// Token: 0x0400A064 RID: 41060
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<RoleSelectionMediumItemGrid, RoleDataBase> RoleScrollView;

	// Token: 0x0400A065 RID: 41061
	[Nullable(2)]
	private RoleViewAgent RoleViewAgent;

	// Token: 0x0400A066 RID: 41062
	private List<RoleDataBase> RoleDataList = new List<RoleDataBase>();

	// Token: 0x0400A067 RID: 41063
	private int? EnterRoleId;

	// Token: 0x0400A068 RID: 41064
	private int? CurSelectRoleId;

	// Token: 0x02008C4E RID: 35918
	[NullableContext(0)]
	private enum ERoleListComponent
	{
		// Token: 0x0402F418 RID: 193560
		CaptionItem,
		// Token: 0x0402F419 RID: 193561
		ButtonBack,
		// Token: 0x0402F41A RID: 193562
		TextName,
		// Token: 0x0402F41B RID: 193563
		ScrollView,
		// Token: 0x0402F41C RID: 193564
		RoleItem,
		// Token: 0x0402F41D RID: 193565
		FilterSortItem
	}
}
