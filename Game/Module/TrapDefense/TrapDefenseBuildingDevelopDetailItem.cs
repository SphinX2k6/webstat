using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E14 RID: 19988
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingDevelopDetailItem : UiPanelBase
	{
		// Token: 0x06033B0A RID: 211722 RVA: 0x00CEAC72 File Offset: 0x00CE8E72
		public TrapDefenseBuildingDevelopDetailItem(bool IsInDungeon, UiViewBase ParentView)
		{
			this.IsInDungeon = IsInDungeon;
			this.ParentView = ParentView;
		}

		// Token: 0x06033B0B RID: 211723 RVA: 0x00CEAC90 File Offset: 0x00CE8E90
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickedCheckBranch));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033B0C RID: 211724 RVA: 0x00CEADBC File Offset: 0x00CE8FBC
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseBuildingDevelopDetailItem.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBuildingDevelopDetailItem.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033B0D RID: 211725 RVA: 0x00CEADFF File Offset: 0x00CE8FFF
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(!this.IsInDungeon);
		}

		// Token: 0x06033B0E RID: 211726 RVA: 0x00CEAE1B File Offset: 0x00CE901B
		protected override void OnBeforeDestroy()
		{
			this.InfoItem = null;
			this.BtnUpgrade = null;
			this.BtnSelect = null;
		}

		// Token: 0x06033B0F RID: 211727 RVA: 0x00CEAE34 File Offset: 0x00CE9034
		public void UpdateDetail(TrapDefenseBuildingDevelopItemData data)
		{
			this.CurData = data;
			this.InfoItem.UpdateDetail(data);
			bool flag = data.GetHasBranch() && data.GetIsUnlock();
			if (!this.IsInDungeon)
			{
				this.CanLevelUp = this.BtnUpgrade.RefreshButton(data);
				UUIItem item = base.GetItem(1);
				if (item != null)
				{
					item.SetUIActive(flag);
				}
				if (flag)
				{
					TrapDefenseBuildingBranchSelectBtnItem btnSelect = this.BtnSelect;
					if (btnSelect != null)
					{
						btnSelect.RefreshButton(data);
					}
				}
			}
			else
			{
				this.CanLevelUp = false;
				ITrapDefenseMachineIdInfo trapDefenseMachineIdInfo = ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(data.Id);
				UUIItem item2 = base.GetItem(1);
				if (item2 != null)
				{
					item2.SetUIActive(flag && trapDefenseMachineIdInfo.Branch > 0);
				}
				if (flag && trapDefenseMachineIdInfo.Branch > 0)
				{
					TrapDefenseBuildingBranchSelectBtnItem btnSelect2 = this.BtnSelect;
					if (btnSelect2 != null)
					{
						btnSelect2.RefreshButton(data);
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseBuildingDevelopDetailUpdate, data);
		}

		// Token: 0x06033B10 RID: 211728 RVA: 0x00CEAF14 File Offset: 0x00CE9114
		private void OnClickedBranchSelect()
		{
			ITrapDefenseSelectBranchData param = new TrapDefenseSelectBranchData
			{
				IsInDungeon = this.IsInDungeon,
				Data = this.CurData
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseBuildingDevelopBranchSelectView, param, null);
		}

		// Token: 0x06033B11 RID: 211729 RVA: 0x00CEAF50 File Offset: 0x00CE9150
		private void OnClickedCheckBranch()
		{
			ITrapDefenseSelectBranchData param = new TrapDefenseSelectBranchData
			{
				IsInDungeon = this.IsInDungeon,
				Data = this.CurData
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseBuildingDevelopPreviewView, param, delegate(bool success, int viewId)
			{
				this.ParentView.AddChildViewById(viewId);
			});
		}

		// Token: 0x06033B12 RID: 211730 RVA: 0x00CEAF97 File Offset: 0x00CE9197
		private void OnClickedUpgrade()
		{
			if (this.CurData == null)
			{
				return;
			}
			if (!this.CanLevelUp)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TrapDefense_Develop_NoEnoughGold", Array.Empty<object>());
				return;
			}
			ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseDevelopLevelUp(this.CurData.Id);
		}

		// Token: 0x0401DEED RID: 122605
		protected TrapDefenseBuildingDevelopDetailInfoItem InfoItem;

		// Token: 0x0401DEEE RID: 122606
		protected TrapDefenseBuildingUpgradeItem BtnUpgrade;

		// Token: 0x0401DEEF RID: 122607
		protected TrapDefenseBuildingBranchSelectBtnItem BtnSelect;

		// Token: 0x0401DEF0 RID: 122608
		protected TrapDefenseBuildingDevelopItemData CurData;

		// Token: 0x0401DEF1 RID: 122609
		protected bool CanLevelUp = true;

		// Token: 0x0401DEF2 RID: 122610
		protected bool IsInDungeon;

		// Token: 0x0401DEF3 RID: 122611
		protected UiViewBase ParentView;

		// Token: 0x0200AD8C RID: 44428
		[NullableContext(0)]
		private class EDefine
		{
			// Token: 0x04035E54 RID: 220756
			public const int BuildingItemInfo = 0;

			// Token: 0x04035E55 RID: 220757
			public const int PanelSelectLayout = 1;

			// Token: 0x04035E56 RID: 220758
			public const int BtnBranchSelect = 2;

			// Token: 0x04035E57 RID: 220759
			public const int PanelBtnLayout = 3;

			// Token: 0x04035E58 RID: 220760
			public const int BtnFuncA1 = 4;

			// Token: 0x04035E59 RID: 220761
			public const int BtnUpgrade = 5;
		}
	}
}
