using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Skin;
using UnrealEngine;

// Token: 0x02002A4C RID: 10828
[NullableContext(1)]
[Nullable(0)]
public class CalabashSkinViewProxy : global::ViewModelBase<ECalabashSkinViewData>
{
	// Token: 0x06015B06 RID: 88838 RVA: 0x00605694 File Offset: 0x00603894
	public CalabashSkinViewProxy()
	{
		List<CalabashSkinData> value = new List<CalabashSkinData>();
		this.DataMap.Add(ECalabashSkinViewData.SkinDataList, value);
		this.DataMap.Add(ECalabashSkinViewData.EquipSkinId, 0);
		this.DataMap.Add(ECalabashSkinViewData.SelectedSkinId, 0);
	}

	// Token: 0x17001C0F RID: 7183
	// (get) Token: 0x06015B07 RID: 88839 RVA: 0x006056DE File Offset: 0x006038DE
	public bool NeedStopRotate
	{
		get
		{
			return this.NeedStopRotateInternal;
		}
	}

	// Token: 0x17001C10 RID: 7184
	// (get) Token: 0x06015B08 RID: 88840 RVA: 0x006056E6 File Offset: 0x006038E6
	public int FailRequestCd
	{
		get
		{
			return this.FailRequestCdInternal;
		}
	}

	// Token: 0x06015B09 RID: 88841 RVA: 0x006056F0 File Offset: 0x006038F0
	public void Init(ISkinViewData viewData)
	{
		this.SkinIdFromSkipInternal = viewData.CalabashSkinId.GetValueOrDefault();
		this.FailRequestCdInternal = ConfigBase<SkinConfig>.Instance.GetCalabashSkinFailRequestCd();
		this.NeedStopRotateInternal = ConfigBase<SkinConfig>.Instance.GetCalabashSkinNeedStopRotate();
		this.InitSkinDataList();
		this.InitGridSelected();
	}

	// Token: 0x06015B0A RID: 88842 RVA: 0x0060573D File Offset: 0x0060393D
	public List<CalabashSkinData> GetSkinDataList()
	{
		return base.GetData(ECalabashSkinViewData.SkinDataList) as List<CalabashSkinData>;
	}

	// Token: 0x06015B0B RID: 88843 RVA: 0x0060574B File Offset: 0x0060394B
	public CalabashSkinData GetSkinDataByIndex(int index)
	{
		return this.GetSkinDataList()[index];
	}

	// Token: 0x06015B0C RID: 88844 RVA: 0x0060575C File Offset: 0x0060395C
	public CalabashSkinData GetSkinDataBySkinId(int skinId)
	{
		int dataIndexBySkinId = this.GetDataIndexBySkinId(skinId);
		return this.GetSkinDataByIndex(dataIndexBySkinId);
	}

	// Token: 0x06015B0D RID: 88845 RVA: 0x00605778 File Offset: 0x00603978
	public void SetEquipSkinId(int skinId, bool notNotify = false)
	{
		this.PrevEquipSkinIdInternal = this.GetEquipSkinId();
		base.SetData(ECalabashSkinViewData.EquipSkinId, skinId, new bool?(notNotify));
	}

	// Token: 0x06015B0E RID: 88846 RVA: 0x00605799 File Offset: 0x00603999
	public int GetEquipSkinId()
	{
		return (int)base.GetData(ECalabashSkinViewData.EquipSkinId);
	}

	// Token: 0x06015B0F RID: 88847 RVA: 0x006057A7 File Offset: 0x006039A7
	public void SetSelectedSkinId(int skinId, bool notNotify = false)
	{
		base.SetData(ECalabashSkinViewData.SelectedSkinId, skinId, new bool?(notNotify));
	}

	// Token: 0x06015B10 RID: 88848 RVA: 0x006057BC File Offset: 0x006039BC
	public int GetSelectedSkinId()
	{
		return (int)base.GetData(ECalabashSkinViewData.SelectedSkinId);
	}

	// Token: 0x06015B11 RID: 88849 RVA: 0x006057CA File Offset: 0x006039CA
	public void SetGetDragItemFunc(Func<UUIDraggableComponent> getDragItemFunc)
	{
		this.GetDragItemFunc = getDragItemFunc;
	}

	// Token: 0x17001C11 RID: 7185
	// (get) Token: 0x06015B12 RID: 88850 RVA: 0x006057D3 File Offset: 0x006039D3
	public int PrevEquipSkinId
	{
		get
		{
			return this.PrevEquipSkinIdInternal;
		}
	}

	// Token: 0x06015B13 RID: 88851 RVA: 0x006057DB File Offset: 0x006039DB
	public UUIDraggableComponent GetDragItem()
	{
		Func<UUIDraggableComponent> getDragItemFunc = this.GetDragItemFunc;
		if (getDragItemFunc == null)
		{
			return null;
		}
		return getDragItemFunc();
	}

	// Token: 0x06015B14 RID: 88852 RVA: 0x006057EE File Offset: 0x006039EE
	private CalabashSkinData CreateCalabashSkinGridData(int skinId)
	{
		return new CalabashSkinData(skinId);
	}

	// Token: 0x06015B15 RID: 88853 RVA: 0x006057F8 File Offset: 0x006039F8
	public int GetDataIndexBySkinId(int skinId)
	{
		int num = this.GetSkinDataList().FindIndex((CalabashSkinData data) => data.SkinId == skinId);
		return (num < 0) ? 0 : num;
	}

	// Token: 0x06015B16 RID: 88854 RVA: 0x00605834 File Offset: 0x00603A34
	public IUiCameraInputComponentData GetCalabashSkinTabCameraInputData()
	{
		SUiRoleCameraSetting? roleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig("葫芦皮肤旋转查看");
		FVectorDouble fvectorDouble = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("TerminalCase").Value, ECollectActorType.UI).D_K2_GetActorLocation();
		return new UiCameraInputComponentData
		{
			DragComponent = this.GetDragItem(),
			CameraSettingConfig = roleCameraConfig.Value,
			SourceLocation = fvectorDouble
		};
	}

	// Token: 0x06015B17 RID: 88855 RVA: 0x0060589C File Offset: 0x00603A9C
	public void InitGridSelected()
	{
		if (this.SkinIdFromSkipInternal != 0)
		{
			this.SetSelectedSkinId(this.SkinIdFromSkipInternal, false);
		}
		else
		{
			this.SetSelectedSkinId(ModelBase<CalabashSkinModel>.Instance.GetCurrentEquipSkinId(), false);
		}
		int currentEquipSkinId = ModelBase<CalabashSkinModel>.Instance.GetCurrentEquipSkinId();
		this.PrevEquipSkinIdInternal = currentEquipSkinId;
		this.SetEquipSkinId(currentEquipSkinId, false);
	}

	// Token: 0x06015B18 RID: 88856 RVA: 0x006058EC File Offset: 0x00603AEC
	public void InitSkinDataList()
	{
		IEnumerable<CalabashSkin> calabashSkinConfigList = ConfigBase<SkinConfig>.Instance.GetCalabashSkinConfigList();
		CalabashSkinData item = this.CreateCalabashSkinGridData(0);
		List<CalabashSkinData> skinDataList = this.GetSkinDataList();
		skinDataList.Add(item);
		foreach (CalabashSkin calabashSkin in calabashSkinConfigList)
		{
			CalabashSkin calabashSkinConfig = ConfigBase<SkinConfig>.Instance.GetCalabashSkinConfig(calabashSkin.Id);
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(calabashSkinConfig.Id, 0) > 0 || calabashSkinConfig.ShowWhenLocked)
			{
				CalabashSkinData item2 = this.CreateCalabashSkinGridData(calabashSkin.Id);
				skinDataList.Add(item2);
			}
		}
		skinDataList.Sort(delegate(CalabashSkinData aSkinData, CalabashSkinData bSkinData)
		{
			if (aSkinData.IsEmptyData != bSkinData.IsEmptyData)
			{
				if (!aSkinData.IsEmptyData)
				{
					return 1;
				}
				return -1;
			}
			else
			{
				bool isLock = aSkinData.GetIsLock();
				bool isLock2 = bSkinData.GetIsLock();
				if (isLock == isLock2)
				{
					return bSkinData.SortIndex - aSkinData.SortIndex;
				}
				if (!isLock)
				{
					return -1;
				}
				return 1;
			}
		});
	}

	// Token: 0x06015B19 RID: 88857 RVA: 0x006059BC File Offset: 0x00603BBC
	public bool CalabashGridItemCanExecuteChange(object parameters, bool _, EToggleState state)
	{
		int skinId = (parameters as CalabashSkinData).SkinId;
		return this.GetSelectedSkinId() != skinId;
	}

	// Token: 0x0400A682 RID: 42626
	private bool NeedStopRotateInternal;

	// Token: 0x0400A683 RID: 42627
	private int FailRequestCdInternal;

	// Token: 0x0400A684 RID: 42628
	private int PrevEquipSkinIdInternal;

	// Token: 0x0400A685 RID: 42629
	private int SkinIdFromSkipInternal;

	// Token: 0x0400A686 RID: 42630
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Func<UUIDraggableComponent> GetDragItemFunc;

	// Token: 0x0400A687 RID: 42631
	public bool NeedLoadModel;
}
