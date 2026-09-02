using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DA7 RID: 19879
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingSlotData
	{
		// Token: 0x060337D2 RID: 210898 RVA: 0x00CE0B96 File Offset: 0x00CDED96
		public static TrapDefenseBuildingSlotData Create(int index)
		{
			return new TrapDefenseBuildingSlotData(index);
		}

		// Token: 0x060337D3 RID: 210899 RVA: 0x00CE0B9E File Offset: 0x00CDED9E
		private TrapDefenseBuildingSlotData(int index)
		{
			this.Index = index;
		}

		// Token: 0x17008814 RID: 34836
		// (get) Token: 0x060337D4 RID: 210900 RVA: 0x00CE0BAD File Offset: 0x00CDEDAD
		public int Index { get; }

		// Token: 0x060337D5 RID: 210901 RVA: 0x00CE0BB5 File Offset: 0x00CDEDB5
		public int GetIndex()
		{
			return this.Index;
		}

		// Token: 0x060337D6 RID: 210902 RVA: 0x00CE0BBD File Offset: 0x00CDEDBD
		[NullableContext(2)]
		public TrapDefenseBuildingDevelopItemData GetSlotData()
		{
			return this.SlotData;
		}

		// Token: 0x060337D7 RID: 210903 RVA: 0x00CE0BC5 File Offset: 0x00CDEDC5
		[NullableContext(2)]
		public void InitSlotData(TrapDefenseBuildingDevelopItemData data = null)
		{
			this.Dirty = false;
			this.TmpData = null;
			this.SlotData = data;
		}

		// Token: 0x060337D8 RID: 210904 RVA: 0x00CE0BDC File Offset: 0x00CDEDDC
		public bool SetSlotData(TrapDefenseBuildingDevelopItemData data = null, bool fromSlot = false)
		{
			if (!this.CanSetSlot() && data == null && !fromSlot)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TowerDefense_Battle_SlotLock", Array.Empty<object>());
				return false;
			}
			if (data != null && !fromSlot && !this.CheckCanSetData(data))
			{
				return false;
			}
			if (data == null)
			{
				TrapDefenseBuildingDevelopItemData slotData = this.SlotData;
				if ((slotData == null || !slotData.IsBuilding) && !fromSlot && !ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.CheckAuxiliarySlot(false))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TowerDefense_Battle_AuxiliaryNeed", Array.Empty<object>());
					return false;
				}
			}
			this.TmpData = data;
			this.Dirty = true;
			return true;
		}

		// Token: 0x060337D9 RID: 210905 RVA: 0x00CE0C74 File Offset: 0x00CDEE74
		private bool CheckCanSetData(TrapDefenseBuildingDevelopItemData data)
		{
			TrapDefenseBuildingSlotData trapDefenseBuildingSlotData = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.IsSlotData(data);
			if (trapDefenseBuildingSlotData != null)
			{
				trapDefenseBuildingSlotData.SetSlotData(this.SlotData, true);
				return true;
			}
			bool flag = this.SlotData != null && !this.SlotData.IsBuilding;
			if (!data.IsBuilding && !flag)
			{
				if (!ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.CheckAuxiliarySlot(true))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TowerDefense_Battle_AuxiliaryMax", Array.Empty<object>());
					return false;
				}
			}
			else if (data.IsBuilding && flag && !ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.CheckAuxiliarySlot(false))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TowerDefense_Battle_AuxiliaryNeed", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x060337DA RID: 210906 RVA: 0x00CE0D25 File Offset: 0x00CDEF25
		public TrapDefenseBuildingDevelopItemData GetUploadData()
		{
			if (!this.Dirty)
			{
				return this.SlotData;
			}
			return this.TmpData;
		}

		// Token: 0x060337DB RID: 210907 RVA: 0x00CE0D3C File Offset: 0x00CDEF3C
		public void ApplySlotData(bool isSuccess)
		{
			if (this.Dirty && isSuccess)
			{
				this.SlotData = this.TmpData;
			}
			this.TmpData = null;
			this.Dirty = false;
		}

		// Token: 0x060337DC RID: 210908 RVA: 0x00CE0D63 File Offset: 0x00CDEF63
		private bool CanSetSlot()
		{
			return this.SlotData == null || !this.SlotData.GetLockInBattle();
		}

		// Token: 0x0401DD27 RID: 122151
		[Nullable(2)]
		private TrapDefenseBuildingDevelopItemData SlotData;

		// Token: 0x0401DD28 RID: 122152
		[Nullable(2)]
		private TrapDefenseBuildingDevelopItemData TmpData;

		// Token: 0x0401DD29 RID: 122153
		private bool Dirty;
	}
}
