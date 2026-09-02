using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Components
{
	// Token: 0x02005AC6 RID: 23238
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoWeaponSmallItemGrid : LoopScrollSmallItemGrid<IKurotatoSmallItemGridData>
	{
		// Token: 0x0603AC0D RID: 240653 RVA: 0x00EE565F File Offset: 0x00EE385F
		public KurotatoWeaponSmallItemGrid(bool needComposeFx = false)
		{
			this.NeedComposeFx = needComposeFx;
		}

		// Token: 0x0603AC0E RID: 240654 RVA: 0x00EE5670 File Offset: 0x00EE3870
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			if (!this.NeedComposeFx)
			{
				return;
			}
			int num = this.ComponentRegisterInfos.FindIndex(([Nullable(new byte[]
			{
				0,
				1
			})] ValueTuple<int, Type> info) => info.Item1 == 11);
			if (num >= 0)
			{
				this.ComponentRegisterInfos[num] = new ValueTuple<int, Type>(11, typeof(UUINiagara));
				return;
			}
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(11, typeof(UUINiagara)));
		}

		// Token: 0x0603AC0F RID: 240655 RVA: 0x00EE56F5 File Offset: 0x00EE38F5
		protected override void OnStart()
		{
			this.GetItemGridExtendToggle().bLockStateOnSelect = true;
		}

		// Token: 0x0603AC10 RID: 240656 RVA: 0x00EE5703 File Offset: 0x00EE3903
		protected override void OnRefresh(IKurotatoSmallItemGridData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			base.GridIndex = gridIndex;
			this.Refresh(data);
		}

		// Token: 0x0603AC11 RID: 240657 RVA: 0x00EE571C File Offset: 0x00EE391C
		public void Refresh(IKurotatoSmallItemGridData data)
		{
			this.Data = data;
			UUINiagara uiNiagara = base.GetUiNiagara(11);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(false);
			}
			if (data.Id == 0)
			{
				PropSmallItemGrid parameters = new PropSmallItemGrid
				{
					Data = data,
					IsQualityHidden = new bool?(true)
				};
				base.Apply<PropSmallItemGrid>(parameters);
				return;
			}
			if (data.Type == EKurotatoCardType.Weapon)
			{
				this.RefreshWeapon(data);
			}
			else
			{
				this.RefreshItem(data);
			}
			if (data.PlayComposeFx.GetValueOrDefault())
			{
				this.PlayComposeFx();
			}
		}

		// Token: 0x0603AC12 RID: 240658 RVA: 0x00EE579C File Offset: 0x00EE399C
		private void RefreshWeapon(IKurotatoSmallItemGridData data)
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
			KurotatoSmallItemGrid parameters = new KurotatoSmallItemGrid
			{
				Id = id,
				Data = data,
				QualityId = new int?(weaponConfigByWeaponId.Value.Quality),
				BottomTextId = weaponConfigByWeaponId.Value.Name,
				CardType = EKurotatoCardType.Weapon,
				IsReceivedVisible = data.IsReceived
			};
			base.Apply<KurotatoSmallItemGrid>(parameters);
			base.SetBottomTextVisible(false);
			base.SetArrowVisible(data.ShowArrow.GetValueOrDefault());
		}

		// Token: 0x0603AC13 RID: 240659 RVA: 0x00EE5868 File Offset: 0x00EE3A68
		private void RefreshItem(IKurotatoSmallItemGridData data)
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
			KurotatoSmallItemGrid parameters = new KurotatoSmallItemGrid
			{
				Id = id,
				Data = data,
				QualityId = new int?(itemConfigByItemId.Value.Quality),
				BottomTextId = itemConfigByItemId.Value.Name,
				CardType = EKurotatoCardType.Item,
				IsReceivedVisible = data.IsReceived,
				RightTopValue = (data.IsShowCount.GetValueOrDefault() ? ("x" + data.Count.ToString()) : null)
			};
			base.Apply<KurotatoSmallItemGrid>(parameters);
			base.SetBottomTextVisible(false);
		}

		// Token: 0x0603AC14 RID: 240660 RVA: 0x00EE5950 File Offset: 0x00EE3B50
		public void BindCallback(Action<IKurotatoSmallItemGridData, EToggleState, int> onSelectedCallback)
		{
			this.OnSelectedCallback = onSelectedCallback;
		}

		// Token: 0x0603AC15 RID: 240661 RVA: 0x00EE5959 File Offset: 0x00EE3B59
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			if (this.OnSelectedCallback != null)
			{
				this.OnSelectedCallback(this.Data, state, base.GridIndex);
			}
		}

		// Token: 0x0603AC16 RID: 240662 RVA: 0x00EE597C File Offset: 0x00EE3B7C
		private void PlayComposeFx()
		{
			if (this.Data == null || this.Data.Type != EKurotatoCardType.Weapon)
			{
				return;
			}
			KurotatoWeapon? weaponConfigByWeaponId = ConfigBase<KurotatoConfig>.Instance.GetWeaponConfigByWeaponId(this.Data.Id);
			if (weaponConfigByWeaponId == null)
			{
				return;
			}
			KurotatoQuality? qualityByQuality = ConfigBase<KurotatoConfig>.Instance.GetQualityByQuality(weaponConfigByWeaponId.Value.Quality);
			if (qualityByQuality == null)
			{
				return;
			}
			UUINiagara uiNiagara = base.GetUiNiagara(11);
			if (uiNiagara == null)
			{
				return;
			}
			uiNiagara.SetUIActive(false);
			FColor color = FColor.FromHex(qualityByQuality.Value.ItemGridNiagaraColor);
			uiNiagara.SetColor(color);
			uiNiagara.SetUIActive(true);
		}

		// Token: 0x04021380 RID: 136064
		[Nullable(2)]
		protected new IKurotatoSmallItemGridData Data;

		// Token: 0x04021381 RID: 136065
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IKurotatoSmallItemGridData, EToggleState, int> OnSelectedCallback;

		// Token: 0x04021382 RID: 136066
		private readonly bool NeedComposeFx;

		// Token: 0x0200BADA RID: 47834
		[NullableContext(0)]
		private enum EKurotatoGridChildComp
		{
			// Token: 0x04039ADB RID: 236251
			ComposeNiagara = 11
		}
	}
}
