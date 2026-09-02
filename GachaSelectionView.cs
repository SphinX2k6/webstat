using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CEF RID: 7407
[NullableContext(1)]
[Nullable(0)]
public class GachaSelectionView : UiViewBase
{
	// Token: 0x0600D96C RID: 55660 RVA: 0x003A4F1E File Offset: 0x003A311E
	public GachaSelectionView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x1700114E RID: 4430
	// (get) Token: 0x0600D96D RID: 55661 RVA: 0x003A4F28 File Offset: 0x003A3128
	private int CurSelectedPoolId
	{
		get
		{
			int selectedGridIndex = this.SelectionScrollView.GetGenericLayout().GetSelectedGridIndex();
			if (this.SelectionDataList == null || selectedGridIndex < 0 || selectedGridIndex >= this.SelectionDataList.Length)
			{
				return 0;
			}
			return this.SelectionDataList[selectedGridIndex].PoolInfo.Id;
		}
	}

	// Token: 0x0600D96E RID: 55662 RVA: 0x003A4F74 File Offset: 0x003A3174
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnConfirmBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D96F RID: 55663 RVA: 0x003A50BF File Offset: 0x003A32BF
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.GachaSelectionViewRefresh, new Action<ProtoGachaInfo>(this.OnDataChange));
	}

	// Token: 0x0600D970 RID: 55664 RVA: 0x003A50DD File Offset: 0x003A32DD
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GachaSelectionViewRefresh, new Action<ProtoGachaInfo>(this.OnDataChange));
	}

	// Token: 0x0600D971 RID: 55665 RVA: 0x003A50FC File Offset: 0x003A32FC
	private void OnConfirmBtnClick()
	{
		int curSelectedPoolId = this.CurSelectedPoolId;
		this.ReportGachaSelection(curSelectedPoolId);
		ControllerBase<GachaController>.Instance.GachaUsePoolRequest(this.GachaInfo.Id, curSelectedPoolId);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.GachaSelectionView, null);
	}

	// Token: 0x0600D972 RID: 55666 RVA: 0x003A5140 File Offset: 0x003A3340
	private void ReportGachaSelection(int poolId)
	{
		GachaViewInfo? gachaViewInfo = ConfigBase<GachaConfig>.Instance.GetGachaViewInfo(poolId);
		if (gachaViewInfo == null)
		{
			return;
		}
		double poolEndTimeByPoolId = this.GachaInfo.GetPoolEndTimeByPoolId(poolId);
		OnConfirmGachaSelectionLogEvent onConfirmGachaSelectionLogEvent = new OnConfirmGachaSelectionLogEvent();
		onConfirmGachaSelectionLogEvent.i_type = gachaViewInfo.Value.Type;
		onConfirmGachaSelectionLogEvent.i_roleid_id = gachaViewInfo.Value.ShowIdList()[0];
		onConfirmGachaSelectionLogEvent.i_time_left = ((poolEndTimeByPoolId > 0.0) ? ((int)(poolEndTimeByPoolId - Singleton<TimeUtil>.Instance.GetServerTime())) : 0);
		ControllerBase<LogReportController>.Instance.LogReport(onConfirmGachaSelectionLogEvent);
	}

	// Token: 0x0600D973 RID: 55667 RVA: 0x003A51CF File Offset: 0x003A33CF
	private void OnDataChange(ProtoGachaInfo gachaInfo)
	{
		this.GachaInfo = gachaInfo;
		this.RefreshSelection();
	}

	// Token: 0x0600D974 RID: 55668 RVA: 0x003A51E0 File Offset: 0x003A33E0
	protected override UniTask OnBeforeStartAsync()
	{
		GachaSelectionView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GachaSelectionView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D975 RID: 55669 RVA: 0x003A5223 File Offset: 0x003A3423
	private GachaSelectionItem CreateSelectionItem()
	{
		return new GachaSelectionItem
		{
			ToggleCallBack = new Action<int>(this.SelectItemByIndex),
			CanToggleChange = new Func<int, bool>(this.CanToggleChange)
		};
	}

	// Token: 0x0600D976 RID: 55670 RVA: 0x003A524E File Offset: 0x003A344E
	private void SelectItemByIndex(int gridIndex)
	{
		GenericScrollViewNew<GachaSelectionItem, GachaPoolData> selectionScrollView = this.SelectionScrollView;
		if (selectionScrollView != null)
		{
			GenericLayout<GachaSelectionItem, GachaPoolData> genericLayout = selectionScrollView.GetGenericLayout();
			if (genericLayout != null)
			{
				genericLayout.SelectGridProxy(gridIndex, false);
			}
		}
		this.OnItemSelect();
	}

	// Token: 0x0600D977 RID: 55671 RVA: 0x003A5274 File Offset: 0x003A3474
	private bool CanToggleChange(int gridIndex)
	{
		GenericScrollViewNew<GachaSelectionItem, GachaPoolData> selectionScrollView = this.SelectionScrollView;
		int? num;
		if (selectionScrollView == null)
		{
			num = null;
		}
		else
		{
			GenericLayout<GachaSelectionItem, GachaPoolData> genericLayout = selectionScrollView.GetGenericLayout();
			num = ((genericLayout != null) ? new int?(genericLayout.GetSelectedGridIndex()) : null);
		}
		int? num2 = num;
		int? num3 = num2;
		return !(gridIndex == num3.GetValueOrDefault() & num3 != null);
	}

	// Token: 0x0600D978 RID: 55672 RVA: 0x003A52CC File Offset: 0x003A34CC
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private GachaPoolData[] CreateSelectionDataList()
	{
		if (this.GachaInfo == null)
		{
			return null;
		}
		ProtoGachaPoolInfo[] validPoolList = this.GachaInfo.GetValidPoolList();
		if (validPoolList == null)
		{
			return null;
		}
		GachaPoolData[] array = new GachaPoolData[validPoolList.Length];
		for (int i = 0; i < validPoolList.Length; i++)
		{
			GachaPoolData gachaPoolData = new GachaPoolData(this.GachaInfo, validPoolList[i]);
			array[i] = gachaPoolData;
		}
		return array;
	}

	// Token: 0x0600D979 RID: 55673 RVA: 0x003A5320 File Offset: 0x003A3520
	private bool CheckPoolListValid()
	{
		ProtoGachaPoolInfo[] validPoolList = this.GachaInfo.GetValidPoolList();
		return validPoolList != null && this.SelectionDataList != null && validPoolList.Length == this.SelectionDataList.Length;
	}

	// Token: 0x0600D97A RID: 55674 RVA: 0x003A5354 File Offset: 0x003A3554
	private void RefreshSelection()
	{
		GachaSelectionView.<>c__DisplayClass20_0 CS$<>8__locals1 = new GachaSelectionView.<>c__DisplayClass20_0();
		CS$<>8__locals1.<>4__this = this;
		if (this.SelectionScrollView == null)
		{
			return;
		}
		this.SelectionDataList = this.CreateSelectionDataList();
		if (this.SelectionDataList == null)
		{
			return;
		}
		if (this.SelectionDataList.Length == 0)
		{
			return;
		}
		CS$<>8__locals1.lastSelectedPoolId = this.CurSelectedPoolId;
		this.SelectionScrollView.RefreshByData(this.SelectionDataList.ToList<GachaPoolData>(), new Action(CS$<>8__locals1.<RefreshSelection>g__AfterRefreshSelection|0), false);
	}

	// Token: 0x0600D97B RID: 55675 RVA: 0x003A53C8 File Offset: 0x003A35C8
	private void OnItemSelect()
	{
		int selectedGridIndex = this.SelectionScrollView.GetGenericLayout().GetSelectedGridIndex();
		int id = this.SelectionDataList[selectedGridIndex].PoolInfo.Id;
		GachaViewInfo value = ConfigBase<GachaConfig>.Instance.GetGachaViewInfo(id).Value;
		int num = value.ShowIdList()[0];
		int type = value.Type;
		GachaViewTypeInfo? gachaViewTypeConfig = ConfigBase<GachaConfig>.Instance.GetGachaViewTypeConfig(type);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), gachaViewTypeConfig.Value.OptionalTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), gachaViewTypeConfig.Value.OptionalDesc, Array.Empty<object>());
		if (ModelBase<GachaModel>.Instance.IsRolePool((GachaDefine.EGachaViewType)type))
		{
			RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(num);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), roleInfoById.Value.Name, Array.Empty<object>());
			CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
			{
				Data = null,
				ItemConfigId = new int?(num)
			};
			this.CurSelectedItem.Apply<CharacterSmallItemGrid>(parameters);
		}
		else
		{
			WeaponConf? weaponItemConfig = ConfigBase<InventoryConfig>.Instance.GetWeaponItemConfig(num);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), weaponItemConfig.Value.WeaponName, Array.Empty<object>());
			PropSmallItemGrid parameters2 = new PropSmallItemGrid
			{
				Data = null,
				ItemConfigId = new int?(num)
			};
			this.CurSelectedItem.Apply<PropSmallItemGrid>(parameters2);
		}
		bool flag = this.GachaInfo.UsePoolId == id;
		string textStringId = flag ? "Text_GachaOptionalText1_Text" : "Text_GachaOptionalText2_Text";
		UUIButtonComponent button = base.GetButton(5);
		if (button != null)
		{
			button.SetSelfInteractive(!flag);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), textStringId, Array.Empty<object>());
	}

	// Token: 0x040067CB RID: 26571
	[Nullable(2)]
	private ProtoGachaInfo GachaInfo;

	// Token: 0x040067CC RID: 26572
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<GachaSelectionItem, GachaPoolData> SelectionScrollView;

	// Token: 0x040067CD RID: 26573
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GachaPoolData[] SelectionDataList;

	// Token: 0x040067CE RID: 26574
	[Nullable(2)]
	private SmallItemGrid CurSelectedItem;

	// Token: 0x02008057 RID: 32855
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402BA8E RID: 178830
		TitleText,
		// Token: 0x0402BA8F RID: 178831
		TipText,
		// Token: 0x0402BA90 RID: 178832
		SelectionScrollView,
		// Token: 0x0402BA91 RID: 178833
		CurSelectedItem,
		// Token: 0x0402BA92 RID: 178834
		CurSelectedNameText,
		// Token: 0x0402BA93 RID: 178835
		ConfirmBtn,
		// Token: 0x0402BA94 RID: 178836
		SelectionTipText
	}
}
