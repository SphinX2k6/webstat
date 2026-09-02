using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006274 RID: 25204
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpPickRoleRewardItem : UiPanelBase
	{
		// Token: 0x0603F7C4 RID: 260036 RVA: 0x01046ADD File Offset: 0x01044CDD
		public TotalTopUpPickRoleRewardItem(ITotalTopUpPickRoleRewardItemData data)
		{
			this.Data = data;
		}

		// Token: 0x0603F7C5 RID: 260037 RVA: 0x01046AEC File Offset: 0x01044CEC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnSelectItem))
			};
		}

		// Token: 0x0603F7C6 RID: 260038 RVA: 0x01046BED File Offset: 0x01044DED
		protected override void OnStart()
		{
			this.RefreshView();
			this.ExtendToggle = base.GetExtendToggle(0);
		}

		// Token: 0x0603F7C7 RID: 260039 RVA: 0x01046C04 File Offset: 0x01044E04
		private void RefreshView()
		{
			if (this.Data == null)
			{
				return;
			}
			bool flag = !this.Data.CanClaim;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			UUIItem item3 = base.GetItem(2);
			if (item3 != null)
			{
				item3.SetUIActive(flag);
			}
			UUIItem item4 = base.GetItem(5);
			if (item4 != null)
			{
				item4.SetUIActive(flag);
			}
			UUITexture texture = base.GetTexture(3);
			UUIItem uuiitem = texture;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			bool flag2 = this.Data.RoleId > 0;
			if (flag2)
			{
				string formationRoleCard = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.Data.RoleId).Value.FormationRoleCard;
				base.SetTextureByPath(formationRoleCard, texture, null, null);
				UUIItem uuiitem2 = texture;
				bool bUseChangeColor2 = flag;
				fcolor = new FColor?(texture.changeColor);
				uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			}
			else
			{
				UUIText text = base.GetText(7);
				if (text != null)
				{
					text.SetText("x" + this.Data.ItemCount.ToString(), true);
				}
			}
			UUITexture texture2 = base.GetTexture(8);
			if (texture2 != null)
			{
				texture2.SetUIActive(!flag2);
			}
			UUITexture texture3 = base.GetTexture(3);
			if (texture3 != null)
			{
				texture3.SetUIActive(flag2);
			}
			UUIText text2 = base.GetText(7);
			if (text2 != null)
			{
				text2.SetUIActive(!flag2);
			}
			UUIItem item5 = base.GetItem(5);
			if (item5 == null)
			{
				return;
			}
			item5.SetUIActive(!this.Data.CanClaim);
		}

		// Token: 0x0603F7C8 RID: 260040 RVA: 0x01046D8D File Offset: 0x01044F8D
		public void SetSelectCallback(Action<ITotalTopUpPickRoleRewardItemData> callback)
		{
			this.OnSelectCallback = callback;
		}

		// Token: 0x0603F7C9 RID: 260041 RVA: 0x01046D98 File Offset: 0x01044F98
		public void SetSelected(bool selected)
		{
			EToggleState state = selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = this.ExtendToggle;
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, false, false, false);
		}

		// Token: 0x0603F7CA RID: 260042 RVA: 0x01046DC2 File Offset: 0x01044FC2
		public void SelectItem()
		{
			this.OnSelectItem(EToggleState.ETT_Checked);
		}

		// Token: 0x0603F7CB RID: 260043 RVA: 0x01046DCB File Offset: 0x01044FCB
		private void OnSelectItem(EToggleState state)
		{
			if (this.OnSelectCallback != null)
			{
				this.OnSelectCallback(this.Data);
			}
		}

		// Token: 0x04023A2B RID: 145963
		private readonly ITotalTopUpPickRoleRewardItemData Data;

		// Token: 0x04023A2C RID: 145964
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<ITotalTopUpPickRoleRewardItemData> OnSelectCallback;

		// Token: 0x04023A2D RID: 145965
		[Nullable(2)]
		private UUIExtendToggle ExtendToggle;

		// Token: 0x0200C35F RID: 50015
		[NullableContext(0)]
		private class EComponentType
		{
			// Token: 0x0403C350 RID: 246608
			public const int RoleItem = 0;

			// Token: 0x0403C351 RID: 246609
			public const int RoleBg = 1;

			// Token: 0x0403C352 RID: 246610
			public const int RoleLockBg = 2;

			// Token: 0x0403C353 RID: 246611
			public const int RoleTex = 3;

			// Token: 0x0403C354 RID: 246612
			public const int NormalItem = 4;

			// Token: 0x0403C355 RID: 246613
			public const int LockItem = 5;

			// Token: 0x0403C356 RID: 246614
			public const int RedDotItem = 6;

			// Token: 0x0403C357 RID: 246615
			public const int TextCount = 7;

			// Token: 0x0403C358 RID: 246616
			public const int TextureProps = 8;
		}
	}
}
