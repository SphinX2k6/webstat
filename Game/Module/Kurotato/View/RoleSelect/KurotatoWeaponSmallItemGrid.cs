using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.RoleSelect
{
	// Token: 0x02005A8A RID: 23178
	public class KurotatoWeaponSmallItemGrid : LoopScrollSmallItemGrid<int>
	{
		// Token: 0x0603AA55 RID: 240213 RVA: 0x00EDBD94 File Offset: 0x00ED9F94
		protected override void OnRefresh(int id, bool isSelected, int gridIndex)
		{
			if (id == 0)
			{
				PropSmallItemGrid parameters = new PropSmallItemGrid
				{
					Data = id,
					IsQualityHidden = new bool?(true)
				};
				base.SetUseFixedAsync(true);
				base.Apply<PropSmallItemGrid>(parameters);
				return;
			}
			this.ItemId = id;
			KurotatoWeapon? weaponConfigByWeaponId = ConfigBase<KurotatoConfig>.Instance.GetWeaponConfigByWeaponId(this.ItemId);
			if (weaponConfigByWeaponId == null)
			{
				return;
			}
			if (ConfigBase<KurotatoConfig>.Instance.GetQualityByQuality(weaponConfigByWeaponId.Value.Quality) == null)
			{
				return;
			}
			KurotatoSmallItemGrid parameters2 = new KurotatoSmallItemGrid
			{
				Id = this.ItemId,
				Data = id,
				QualityId = new int?(weaponConfigByWeaponId.Value.Quality),
				CardType = EKurotatoCardType.Weapon
			};
			base.SetUseFixedAsync(true);
			base.Apply<KurotatoSmallItemGrid>(parameters2);
		}

		// Token: 0x0603AA56 RID: 240214 RVA: 0x00EDBE66 File Offset: 0x00EDA066
		[NullableContext(1)]
		public void SetToggleClickCallback(Action<int> callback)
		{
			this.ToggleClickCallback = callback;
		}

		// Token: 0x0603AA57 RID: 240215 RVA: 0x00EDBE6F File Offset: 0x00EDA06F
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			this.SetSelected(false, false);
			if (this.ItemId != 0 && state == EToggleState.ETT_Checked)
			{
				Action<int> toggleClickCallback = this.ToggleClickCallback;
				if (toggleClickCallback == null)
				{
					return;
				}
				toggleClickCallback(this.ItemId);
			}
		}

		// Token: 0x040212BC RID: 135868
		private int ItemId;

		// Token: 0x040212BD RID: 135869
		[Nullable(2)]
		private Action<int> ToggleClickCallback;
	}
}
