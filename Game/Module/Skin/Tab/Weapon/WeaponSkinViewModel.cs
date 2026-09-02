using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Skin.Tab.Weapon
{
	// Token: 0x02004F66 RID: 20326
	[NullableContext(1)]
	[Nullable(0)]
	public class WeaponSkinViewModel : ViewModelBase<EWeaponSkinTabViewData>
	{
		// Token: 0x17008A3C RID: 35388
		// (get) Token: 0x060346C6 RID: 214726 RVA: 0x00D1DD92 File Offset: 0x00D1BF92
		public int PrevEquipSkinId
		{
			get
			{
				return this.PrevEquipSkinIdInternal;
			}
		}

		// Token: 0x060346C7 RID: 214727 RVA: 0x00D1DD9C File Offset: 0x00D1BF9C
		public WeaponSkinViewModel()
		{
			List<WeaponSkinData> value = new List<WeaponSkinData>();
			this.DataMap[EWeaponSkinTabViewData.SkinDataList] = value;
			this.DataMap[EWeaponSkinTabViewData.IsInShowWeapon] = false;
			this.DataMap[EWeaponSkinTabViewData.EquipSkinId] = null;
			this.DataMap[EWeaponSkinTabViewData.SelectedSkinId] = null;
			this.DataMap[EWeaponSkinTabViewData.WeaponUiVisible] = true;
		}

		// Token: 0x060346C8 RID: 214728 RVA: 0x00D1DE07 File Offset: 0x00D1C007
		public void Init(ISkinViewData viewData)
		{
			this.ViewData = viewData;
			this.InitSkinWeaponGridDataList();
			this.InitSelectedWeaponSkinId();
		}

		// Token: 0x060346C9 RID: 214729 RVA: 0x00D1DE1C File Offset: 0x00D1C01C
		public void SetIsInShowWeapon(bool showWeapon, bool notNotify = false)
		{
			base.SetData(EWeaponSkinTabViewData.IsInShowWeapon, showWeapon, notNotify);
		}

		// Token: 0x060346CA RID: 214730 RVA: 0x00D1DE2C File Offset: 0x00D1C02C
		public bool GetIsInShowWeapon()
		{
			return (bool)base.GetData(EWeaponSkinTabViewData.IsInShowWeapon);
		}

		// Token: 0x060346CB RID: 214731 RVA: 0x00D1DE3A File Offset: 0x00D1C03A
		public void SetEquipSkinId(int equipSkinId, bool notNotify = false)
		{
			base.SetData(EWeaponSkinTabViewData.EquipSkinId, equipSkinId, notNotify);
		}

		// Token: 0x060346CC RID: 214732 RVA: 0x00D1DE4A File Offset: 0x00D1C04A
		public int GetEquipSkinId()
		{
			return (int)base.GetData(EWeaponSkinTabViewData.EquipSkinId);
		}

		// Token: 0x060346CD RID: 214733 RVA: 0x00D1DE58 File Offset: 0x00D1C058
		public void SetSelectedSkinId(int skinId, bool notNotify = false)
		{
			base.SetData(EWeaponSkinTabViewData.SelectedSkinId, skinId, notNotify);
		}

		// Token: 0x060346CE RID: 214734 RVA: 0x00D1DE68 File Offset: 0x00D1C068
		public int GetSelectedSkinId()
		{
			return (int)base.GetData(EWeaponSkinTabViewData.SelectedSkinId);
		}

		// Token: 0x060346CF RID: 214735 RVA: 0x00D1DE76 File Offset: 0x00D1C076
		public List<WeaponSkinData> GetSkinDataList()
		{
			return (List<WeaponSkinData>)base.GetData(EWeaponSkinTabViewData.SkinDataList);
		}

		// Token: 0x060346D0 RID: 214736 RVA: 0x00D1DE84 File Offset: 0x00D1C084
		public void SetWeaponUiVisible(bool visible, bool notNotify = false)
		{
			base.SetData(EWeaponSkinTabViewData.WeaponUiVisible, visible, notNotify);
		}

		// Token: 0x060346D1 RID: 214737 RVA: 0x00D1DE94 File Offset: 0x00D1C094
		public bool GetWeaponUiVisible()
		{
			return (bool)base.GetData(EWeaponSkinTabViewData.WeaponUiVisible);
		}

		// Token: 0x060346D2 RID: 214738 RVA: 0x00D1DEA2 File Offset: 0x00D1C0A2
		public void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.EquipWeaponSkin, new Action<int, int>(this.OnEquipWeaponSkin));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.UninstallWeaponSkin, new Action<int>(this.OnUninstallWeaponSkin));
		}

		// Token: 0x060346D3 RID: 214739 RVA: 0x00D1DEDC File Offset: 0x00D1C0DC
		public void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.EquipWeaponSkin, new Action<int, int>(this.OnEquipWeaponSkin));
			Singleton<EventSystem>.Instance.Remove(EEventName.UninstallWeaponSkin, new Action<int>(this.OnUninstallWeaponSkin));
		}

		// Token: 0x060346D4 RID: 214740 RVA: 0x00D1DF16 File Offset: 0x00D1C116
		private void OnEquipWeaponSkin(int roleId, int skinId)
		{
			if (this.ViewData.RoleId != roleId)
			{
				return;
			}
			this.PrevEquipSkinIdInternal = this.GetEquipSkinId();
			this.SetEquipSkinId(skinId, false);
		}

		// Token: 0x060346D5 RID: 214741 RVA: 0x00D1DF3B File Offset: 0x00D1C13B
		private void OnUninstallWeaponSkin(int roleId)
		{
			if (this.ViewData.RoleId != roleId)
			{
				return;
			}
			this.PrevEquipSkinIdInternal = this.GetEquipSkinId();
			this.SetEquipSkinId(-1, false);
		}

		// Token: 0x060346D6 RID: 214742 RVA: 0x00D1DF60 File Offset: 0x00D1C160
		private void InitSkinWeaponGridDataList()
		{
			int weaponType = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.ViewData.WeaponId).GetWeaponConfig().Value.WeaponType;
			IEnumerable<WeaponSkin> weaponSkinConfigListByType = ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfigListByType(weaponType);
			int roleId = this.ViewData.RoleId;
			WeaponSkinData item = this.CreateWeaponSkinGridData(-1, roleId);
			List<WeaponSkinData> skinDataList = this.GetSkinDataList();
			skinDataList.Add(item);
			foreach (WeaponSkin weaponSkin in weaponSkinConfigListByType)
			{
				if (!weaponSkin.HideInSkinView)
				{
					WeaponSkinData item2 = this.CreateWeaponSkinGridData(weaponSkin.Id, roleId);
					skinDataList.Add(item2);
				}
			}
		}

		// Token: 0x060346D7 RID: 214743 RVA: 0x00D1E024 File Offset: 0x00D1C224
		private WeaponSkinData CreateWeaponSkinGridData(int skinId, int roleId)
		{
			return new WeaponSkinData(skinId, roleId);
		}

		// Token: 0x060346D8 RID: 214744 RVA: 0x00D1E030 File Offset: 0x00D1C230
		public void InitSelectedWeaponSkinId()
		{
			int skinIdByRoleId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(this.ViewData.RoleId);
			this.SetEquipSkinId(skinIdByRoleId, false);
			int dataIndexBySkinId = this.GetDataIndexBySkinId(skinIdByRoleId);
			List<WeaponSkinData> skinDataList = this.GetSkinDataList();
			this.SetSelectedSkinId(skinDataList[dataIndexBySkinId].SkinId, false);
		}

		// Token: 0x060346D9 RID: 214745 RVA: 0x00D1E080 File Offset: 0x00D1C280
		public void RefreshEquipSkinId()
		{
			int skinIdByRoleId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(this.ViewData.RoleId);
			if (this.GetEquipSkinId() != skinIdByRoleId)
			{
				this.SetEquipSkinId(skinIdByRoleId, true);
			}
		}

		// Token: 0x060346DA RID: 214746 RVA: 0x00D1E0B4 File Offset: 0x00D1C2B4
		public int GetDataIndexBySkinId(int skinId)
		{
			int num = this.GetSkinDataList().FindIndex((WeaponSkinData data) => data.SkinId == skinId);
			return (num < 0) ? 0 : num;
		}

		// Token: 0x060346DB RID: 214747 RVA: 0x00D1E0F0 File Offset: 0x00D1C2F0
		public bool GridItemCanExecuteChange(object parameters)
		{
			int skinId = ((WeaponSkinData)parameters).SkinId;
			return this.GetSelectedSkinId() != skinId;
		}

		// Token: 0x0401E348 RID: 123720
		private ISkinViewData ViewData;

		// Token: 0x0401E349 RID: 123721
		private int PrevEquipSkinIdInternal = -1;
	}
}
