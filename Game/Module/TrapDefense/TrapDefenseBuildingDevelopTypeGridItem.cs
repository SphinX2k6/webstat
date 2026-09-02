using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E1A RID: 19994
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseBuildingDevelopTypeGridItem : LoopScrollMediumItemGrid<TrapDefenseBuildingDevelopItemData>
	{
		// Token: 0x06033B32 RID: 211762 RVA: 0x00CEBC1C File Offset: 0x00CE9E1C
		protected override void OnStart()
		{
			base.BindOnExtendTogglePress(new Action<MediumItemGridExtendCallback>(this.OnToggleDown));
			base.BindOnExtendToggleRelease(new Action<MediumItemGridExtendCallback>(this.OnToggleUp));
		}

		// Token: 0x06033B33 RID: 211763 RVA: 0x00CEBC42 File Offset: 0x00CE9E42
		protected override void OnRefresh(TrapDefenseBuildingDevelopItemData data, bool isSelected, int gridIndex)
		{
			this.TrapData = data;
			this.SetSelected(isSelected, true);
			this.UpdateInfo();
		}

		// Token: 0x06033B34 RID: 211764 RVA: 0x00CEBC5C File Offset: 0x00CE9E5C
		public void UpdateInfo()
		{
			string bottomTextId = this.TrapData.GetIsUnlock() ? "TowerDefense_Building_BdLv_Text" : "TowerDefense_Building_BdLock_Text";
			bool flag = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.CheckNeedOrganNew(this.TrapData);
			bool? isReceivedFlagVisible = new bool?(ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.CheckSlotEquipped(this.TrapData));
			ITrapDefenseMachineIdInfo trapDefenseMachineIdInfo = ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(this.TrapData.Id);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ItemQualityNormal");
			bool? isRecommendOrgan = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetIsRecommendOrgan(this.TrapData);
			PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid();
			propMediumItemGrid.Data = this.TrapData;
			propMediumItemGrid.IsRecommendVisible = isRecommendOrgan;
			propMediumItemGrid.BottomTextId = bottomTextId;
			propMediumItemGrid.BottomTextParameter = new object[]
			{
				(this.TrapData != null) ? this.TrapData.GetLevel() : ""
			};
			PropMediumItemGrid propMediumItemGrid2 = propMediumItemGrid;
			TrapDefenseBuildingDevelopItemData trapData = this.TrapData;
			propMediumItemGrid2.IsLockVisible = new bool?(trapData == null || !trapData.GetIsUnlock());
			PropMediumItemGrid propMediumItemGrid3 = propMediumItemGrid;
			bool value;
			if (!this.TrapData.IsInDungeon)
			{
				TrapDefenseBuildingDevelopItemData trapData2 = this.TrapData;
				if (trapData2 != null && trapData2.GetIsUnlock())
				{
					TrapDefenseBuildingDevelopItemData trapData3 = this.TrapData;
					value = (trapData3 != null && trapData3.CheckNeedRedDot());
					goto IL_137;
				}
			}
			value = false;
			IL_137:
			propMediumItemGrid3.IsRedDotVisible = new bool?(value);
			MediumItemGridBase mediumItemGridBase = propMediumItemGrid;
			TrapDefenseBuildingDevelopItemData trapData4 = this.TrapData;
			mediumItemGridBase.IconPath = ((trapData4 != null) ? trapData4.GetIconPath() : null);
			PropMediumItemGrid propMediumItemGrid4 = propMediumItemGrid;
			TrapDefenseBuildingDevelopItemData trapData5 = this.TrapData;
			propMediumItemGrid4.IsDisable = new bool?(trapData5 == null || !trapData5.GetIsUnlock());
			propMediumItemGrid.IsNewVisible = new bool?(isRecommendOrgan == null && flag);
			propMediumItemGrid.IsReceivedFlagVisible = isReceivedFlagVisible;
			propMediumItemGrid.IsBranchUpgrade = ((trapDefenseMachineIdInfo.Branch > 0) ? new bool?(true) : null);
			propMediumItemGrid.QualityIcon = resourcePath;
			PropMediumItemGrid parameters = propMediumItemGrid;
			base.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x06033B35 RID: 211765 RVA: 0x00CEBE3B File Offset: 0x00CEA03B
		public void OnForceSelected()
		{
			if (ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.SetOrganClicked(this.TrapData))
			{
				this.UpdateState();
			}
			this.SetSelected(true, true);
		}

		// Token: 0x06033B36 RID: 211766 RVA: 0x00CEBE62 File Offset: 0x00CEA062
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
			if (ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.SetOrganClicked(this.TrapData))
			{
				this.UpdateState();
			}
			if (fireEvent)
			{
				Action<TrapDefenseBuildingDevelopItemData> onItemClickCallback = this.OnItemClickCallback;
				if (onItemClickCallback == null)
				{
					return;
				}
				onItemClickCallback(this.TrapData);
			}
		}

		// Token: 0x06033B37 RID: 211767 RVA: 0x00CEBEA2 File Offset: 0x00CEA0A2
		protected override bool OnCanExecuteChange()
		{
			return this.CanExecuteChangeCb == null || this.CanExecuteChangeCb(this.TrapData);
		}

		// Token: 0x06033B38 RID: 211768 RVA: 0x00CEBEBF File Offset: 0x00CEA0BF
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x06033B39 RID: 211769 RVA: 0x00CEBEC9 File Offset: 0x00CEA0C9
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033B3A RID: 211770 RVA: 0x00CEBECB File Offset: 0x00CEA0CB
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				IScrollViewDelegate<IGridProxy<TrapDefenseBuildingDevelopItemData>, TrapDefenseBuildingDevelopItemData> scrollViewDelegate = base.ScrollViewDelegate;
				if (scrollViewDelegate == null)
				{
					return;
				}
				scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, true);
			}
		}

		// Token: 0x06033B3B RID: 211771 RVA: 0x00CEBEEE File Offset: 0x00CEA0EE
		private void OnToggleDown(MediumItemGridExtendCallback _)
		{
			Action<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData> onPointDownCb = this.OnPointDownCb;
			if (onPointDownCb == null)
			{
				return;
			}
			onPointDownCb(this, this.TrapData);
		}

		// Token: 0x06033B3C RID: 211772 RVA: 0x00CEBF07 File Offset: 0x00CEA107
		private void OnToggleUp(MediumItemGridExtendCallback _)
		{
			Action<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData> onPointUpCb = this.OnPointUpCb;
			if (onPointUpCb == null)
			{
				return;
			}
			onPointUpCb(this, this.TrapData);
		}

		// Token: 0x06033B3D RID: 211773 RVA: 0x00CEBF20 File Offset: 0x00CEA120
		public void UpdateState()
		{
			this.UpdateInfo();
		}

		// Token: 0x0401DEFE RID: 122622
		private TrapDefenseBuildingDevelopItemData TrapData;

		// Token: 0x0401DEFF RID: 122623
		public Action<TrapDefenseBuildingDevelopItemData> OnItemClickCallback;

		// Token: 0x0401DF00 RID: 122624
		public Func<TrapDefenseBuildingDevelopItemData, bool> CanExecuteChangeCb;

		// Token: 0x0401DF01 RID: 122625
		public Action<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData> OnPointDownCb;

		// Token: 0x0401DF02 RID: 122626
		public Action<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData> OnPointUpCb;
	}
}
