using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x0200181C RID: 6172
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionRefineMediumItemGrid : LoopScrollMediumItemGrid<PhantomItemData>
{
	// Token: 0x0600AFC2 RID: 44994 RVA: 0x002EDAE3 File Offset: 0x002EBCE3
	protected override void OnStart()
	{
		base.OnStart();
		this.GetItemGridExtendToggle().FocusListenerDelegate.Bind(new Action(this.ShowItemTips));
	}

	// Token: 0x0600AFC3 RID: 44995 RVA: 0x002EDB07 File Offset: 0x002EBD07
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		this.GetItemGridExtendToggle().FocusListenerDelegate.Unbind();
	}

	// Token: 0x0600AFC4 RID: 44996 RVA: 0x002EDB1F File Offset: 0x002EBD1F
	[NullableContext(1)]
	protected override void OnRefresh(PhantomItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshPrivate(data);
	}

	// Token: 0x0600AFC5 RID: 44997 RVA: 0x002EDB30 File Offset: 0x002EBD30
	[NullableContext(1)]
	private void RefreshPrivate(PhantomItemData data)
	{
		int uniqueId = data.GetUniqueId();
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
		if (phantomBattleData == null)
		{
			return;
		}
		int itemDataType = (int)data.GetItemDataType();
		PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.GetConfigId()),
			IsLockVisible = new bool?(data.GetIsLock()),
			IsDeprecate = new bool?(data.GetIsDeprecated()),
			StarLevel = new int?(data.GetQuality())
		};
		if (itemDataType == 3)
		{
			PropMediumItemGrid propMediumItemGrid2 = propMediumItemGrid;
			Func<EVisionRefineRefineType> getRefineType = this.GetRefineType;
			EVisionRefineRefineType evisionRefineRefineType = (getRefineType != null) ? getRefineType() : EVisionRefineRefineType.Main;
			propMediumItemGrid2.ItemConfigId = new int?(phantomBattleData.GetConfigId(true));
			propMediumItemGrid2.QualityId = new int?(phantomBattleData.GetQuality());
			propMediumItemGrid2.Level = new int?(phantomBattleData.GetCost());
			propMediumItemGrid2.IsLevelTextUseChangeColor = new bool?(true);
			propMediumItemGrid2.BottomTextId = "VisionLevel";
			propMediumItemGrid2.BottomTextParameter = new object[]
			{
				phantomBattleData.GetPhantomLevel()
			};
			propMediumItemGrid2.VisionFetterGroupId = new int?(phantomBattleData.GetFetterGroupId());
			propMediumItemGrid2.IsOmitBottomText = new bool?(true);
			propMediumItemGrid2.IsDisable = new bool?(!phantomBattleData.GetVisionIfCanRefine(evisionRefineRefineType));
			bool flag = false;
			if (this.CheckSelectByView != null)
			{
				flag = this.CheckSelectByView(data);
			}
			if (evisionRefineRefineType != EVisionRefineRefineType.Main && !flag && ControllerBase<PhantomBattleController>.Instance.CheckIsEquip(uniqueId))
			{
				int uniqueId2 = phantomBattleData.GetUniqueId();
				int? equipRole = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(uniqueId2);
				bool value = ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsMain(uniqueId2);
				propMediumItemGrid2.VisionRoleHeadInfo = new VisionRoleHeadInfo
				{
					RoleConfigId = equipRole,
					VisionUniqueId = new int?(uniqueId2)
				};
				propMediumItemGrid2.IsMainVisionVisible = new bool?(value);
			}
			this.SetSelected(flag, true);
			bool value2 = flag && phantomBattleData.GetVisionIfCanRefine(evisionRefineRefineType);
			if (evisionRefineRefineType != EVisionRefineRefineType.Main)
			{
				if (evisionRefineRefineType == EVisionRefineRefineType.Sub)
				{
					propMediumItemGrid2.ReduceButtonInfo = new LongPressButton
					{
						IsVisible = new bool?(false)
					};
					propMediumItemGrid2.IsWarning = new bool?(false);
					propMediumItemGrid2.IsGreenSelected = new bool?(value2);
				}
			}
			else
			{
				propMediumItemGrid2.ReduceButtonInfo = new LongPressButton
				{
					IsVisible = new bool?(value2)
				};
				bool value3 = false;
				if (this.CheckWarningByView != null)
				{
					value3 = this.CheckWarningByView(this.ItemData);
				}
				propMediumItemGrid2.IsWarning = new bool?(value3);
				propMediumItemGrid2.IsGreenSelected = new bool?(false);
			}
		}
		else
		{
			propMediumItemGrid.BottomText = data.GetCount().ToString();
		}
		base.Apply<PropMediumItemGrid>(propMediumItemGrid);
	}

	// Token: 0x0600AFC6 RID: 44998 RVA: 0x002EDDA5 File Offset: 0x002EBFA5
	[NullableContext(1)]
	public void RefreshByView(PhantomItemData data)
	{
		this.RefreshPrivate(data);
	}

	// Token: 0x0600AFC7 RID: 44999 RVA: 0x002EDDB0 File Offset: 0x002EBFB0
	private void ShowItemTips()
	{
		PhantomItemData itemData = this.ItemData;
		if (itemData == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnSelectItemAdd, itemData.GetConfigId(), itemData.GetUniqueId());
	}

	// Token: 0x17000E51 RID: 3665
	// (get) Token: 0x0600AFC8 RID: 45000 RVA: 0x002EDDE4 File Offset: 0x002EBFE4
	private PhantomItemData ItemData
	{
		get
		{
			return this.Data as PhantomItemData;
		}
	}

	// Token: 0x04005350 RID: 21328
	public Func<PhantomItemData, bool> CheckSelectByView;

	// Token: 0x04005351 RID: 21329
	public Func<PhantomItemData, bool> CheckWarningByView;

	// Token: 0x04005352 RID: 21330
	public Func<EVisionRefineRefineType> GetRefineType;
}
