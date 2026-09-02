using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Kurotato.Data;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Components
{
	// Token: 0x02005AC5 RID: 23237
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoWeaponMediumItemGrid : LoopScrollMediumItemGrid<IKurotatoMediumItemGridData>
	{
		// Token: 0x0603AC02 RID: 240642 RVA: 0x00EE5311 File Offset: 0x00EE3511
		protected override void OnStart()
		{
			this.GetItemGridExtendToggle().bLockStateOnSelect = true;
		}

		// Token: 0x0603AC03 RID: 240643 RVA: 0x00EE531F File Offset: 0x00EE351F
		protected override void OnRefresh(IKurotatoMediumItemGridData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.Refresh(data, new bool?(isSelected));
		}

		// Token: 0x0603AC04 RID: 240644 RVA: 0x00EE5338 File Offset: 0x00EE3538
		public void Refresh(IKurotatoMediumItemGridData data, bool? isSelected = null)
		{
			this.Data = data;
			if (data.Type == EKurotatoCardType.Weapon)
			{
				this.RefreshWeapon(data);
			}
			else if (data.Type == EKurotatoCardType.Item)
			{
				this.RefreshItem(data);
			}
			else
			{
				base.Apply<OnlyEmptyItemGrid>(new OnlyEmptyItemGrid());
			}
			if (isSelected != null)
			{
				this.SetSelected(isSelected.Value, true);
			}
		}

		// Token: 0x0603AC05 RID: 240645 RVA: 0x00EE5394 File Offset: 0x00EE3594
		private void RefreshWeapon(IKurotatoMediumItemGridData data)
		{
			int id = data.Id;
			KurotatoWeapon? weaponConfigByWeaponId = ConfigBase<KurotatoConfig>.Instance.GetWeaponConfigByWeaponId(id);
			if (weaponConfigByWeaponId == null)
			{
				return;
			}
			if (ConfigBase<KurotatoConfig>.Instance.GetQualityByQuality(weaponConfigByWeaponId.Value.Quality) == null)
			{
				return;
			}
			KurotatoWeaponData kurotatoWeaponData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetKurotatoWeaponData(id);
			KurotatoMediumItemGrid parameters = new KurotatoMediumItemGrid
			{
				Id = id,
				Data = data,
				QualityId = new int?(weaponConfigByWeaponId.Value.Quality),
				BottomTextId = weaponConfigByWeaponId.Value.Name,
				CardType = EKurotatoCardType.Weapon,
				IsNewVisible = new bool?(this.IsShowNew && kurotatoWeaponData.HasRedDot),
				IsDisable = new bool?(this.IsShowLock && !kurotatoWeaponData.IsUnLock)
			};
			base.Apply<KurotatoMediumItemGrid>(parameters);
		}

		// Token: 0x0603AC06 RID: 240646 RVA: 0x00EE5484 File Offset: 0x00EE3684
		private void RefreshItem(IKurotatoMediumItemGridData data)
		{
			int id = data.Id;
			KurotatoItem? itemConfigByItemId = ConfigBase<KurotatoConfig>.Instance.GetItemConfigByItemId(id);
			if (itemConfigByItemId == null)
			{
				return;
			}
			if (ConfigBase<KurotatoConfig>.Instance.GetQualityByQuality(itemConfigByItemId.Value.Quality) == null)
			{
				return;
			}
			KurotatoItemData kurotatoItemData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetKurotatoItemData(id);
			KurotatoMediumItemGrid kurotatoMediumItemGrid = new KurotatoMediumItemGrid();
			kurotatoMediumItemGrid.Id = id;
			kurotatoMediumItemGrid.Data = data;
			kurotatoMediumItemGrid.QualityId = new int?(itemConfigByItemId.Value.Quality);
			kurotatoMediumItemGrid.BottomTextId = itemConfigByItemId.Value.Name;
			kurotatoMediumItemGrid.CardType = EKurotatoCardType.Item;
			kurotatoMediumItemGrid.IsNewVisible = new bool?(this.IsShowNew && kurotatoItemData.HasRedDot);
			kurotatoMediumItemGrid.IsDisable = new bool?(this.IsShowLock && !kurotatoItemData.IsUnLock);
			string rightTopValue;
			if (!this.IsShowItemCount)
			{
				rightTopValue = null;
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("x");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Count);
				rightTopValue = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			kurotatoMediumItemGrid.RightTopValue = rightTopValue;
			KurotatoMediumItemGrid parameters = kurotatoMediumItemGrid;
			base.Apply<KurotatoMediumItemGrid>(parameters);
		}

		// Token: 0x0603AC07 RID: 240647 RVA: 0x00EE55AE File Offset: 0x00EE37AE
		public void BindCallback(Action<EToggleState> onSelectedCallback)
		{
			this.OnSelectedCallback = onSelectedCallback;
		}

		// Token: 0x0603AC08 RID: 240648 RVA: 0x00EE55B7 File Offset: 0x00EE37B7
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			if (this.OnSelectedCallback != null)
			{
				this.OnSelectedCallback(state);
			}
		}

		// Token: 0x0603AC09 RID: 240649 RVA: 0x00EE55D0 File Offset: 0x00EE37D0
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, true);
			KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
			if (this.Data.Type == EKurotatoCardType.Weapon)
			{
				activityData.GetKurotatoWeaponData(this.Data.Id).ReadRedDot(true);
			}
			else
			{
				activityData.GetKurotatoItemData(this.Data.Id).ReadRedDot(true);
			}
			base.SetNewVisible(new bool?(false));
		}

		// Token: 0x0603AC0A RID: 240650 RVA: 0x00EE5639 File Offset: 0x00EE3839
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, true);
		}

		// Token: 0x0603AC0B RID: 240651 RVA: 0x00EE5643 File Offset: 0x00EE3843
		public override object GetKey(IKurotatoMediumItemGridData data, int gridIndex)
		{
			return data.Id;
		}

		// Token: 0x0402137A RID: 136058
		[Nullable(2)]
		public new IKurotatoMediumItemGridData Data;

		// Token: 0x0402137B RID: 136059
		public new int GridIndex;

		// Token: 0x0402137C RID: 136060
		public bool IsShowItemCount = true;

		// Token: 0x0402137D RID: 136061
		public bool IsShowLock;

		// Token: 0x0402137E RID: 136062
		public bool IsShowNew;

		// Token: 0x0402137F RID: 136063
		[Nullable(2)]
		private Action<EToggleState> OnSelectedCallback;
	}
}
