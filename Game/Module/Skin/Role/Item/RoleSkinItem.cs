using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

namespace CSharpScript.Game.Module.Skin.Role.Item
{
	// Token: 0x02004F74 RID: 20340
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleSkinItem : AutoAttachItem<RoleSkinData>, IStaticVariableResetter
	{
		// Token: 0x06034760 RID: 214880 RVA: 0x00D207FC File Offset: 0x00D1E9FC
		static RoleSkinItem()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RoleSkinItem.CreateStaticDefaultValue), new Action(RoleSkinItem.ResetStaticDefaultValue));
		}

		// Token: 0x06034761 RID: 214881 RVA: 0x00D2081B File Offset: 0x00D1EA1B
		public static void CreateStaticDefaultValue()
		{
			RoleSkinItem.OffsetCurve = null;
			RoleSkinItem.ScaleCurve = null;
			RoleSkinItem.AlphaCurve = null;
		}

		// Token: 0x06034762 RID: 214882 RVA: 0x00D2082F File Offset: 0x00D1EA2F
		public static void ResetStaticDefaultValue()
		{
			RoleSkinItem.OffsetCurve = null;
			RoleSkinItem.ScaleCurve = null;
			RoleSkinItem.AlphaCurve = null;
		}

		// Token: 0x06034763 RID: 214883 RVA: 0x00D20844 File Offset: 0x00D1EA44
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUITexture)),
				new ValueTuple<int, Type>(10, typeof(UUITexture)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnSelectedItem))
			};
		}

		// Token: 0x06034764 RID: 214884 RVA: 0x00D209E8 File Offset: 0x00D1EBE8
		[NullableContext(1)]
		protected override void OnRefreshItem(RoleSkinData data)
		{
			base.SetTextureByPath(data.GetBuyPreviewRoleQualityBgPath(), base.GetTexture(1), null, null);
			base.SetTextureByPath(data.GetBuyPreviewRoleCardPath(), base.GetTexture(2), null, null);
			bool flag = data.GetSuitWeaponSkinId() > 0;
			if (flag)
			{
				string suitWeaponPreviewTexturePath = data.GetSuitWeaponPreviewTexturePath();
				base.SetTextureByPath(suitWeaponPreviewTexturePath, base.GetTexture(5), null, null);
				base.GetTexture(5).SetUIActive(true);
				string suitWeaponQualityBgPath = data.GetSuitWeaponQualityBgPath();
				base.SetTextureByPath(suitWeaponQualityBgPath, base.GetTexture(4), null, null);
				base.GetItem(4).SetUIActive(true);
				FColor color = FColor.FromHex(data.GetRoleSkinConfig().SuitWeaponSkinColor);
				base.GetTexture(10).SetColor(color);
			}
			else
			{
				base.GetTexture(5).SetUIActive(false);
				base.GetItem(4).SetUIActive(false);
			}
			base.GetItem(15).SetUIActive(data.GetHasNewFlag());
			base.GetItem(6).SetUIActive(data.IsWear());
			base.GetItem(7).SetUIActive(data.IsLocked());
			this.RefreshEffectItem(flag);
		}

		// Token: 0x06034765 RID: 214885 RVA: 0x00D20B13 File Offset: 0x00D1ED13
		private void RefreshEffectItem(bool hasSuit)
		{
			base.GetItem(14).SetUIActive(hasSuit);
			base.GetItem(13).SetUIActive(hasSuit);
		}

		// Token: 0x06034766 RID: 214886 RVA: 0x00D20B31 File Offset: 0x00D1ED31
		public override void OnSelect()
		{
			this.OnSelectedItem();
			base.GetItem(12).SetUIActive(true);
			base.GetItem(11).SetUIActive(false);
			base.GetItem(15).SetUIActive(false);
		}

		// Token: 0x06034767 RID: 214887 RVA: 0x00D20B63 File Offset: 0x00D1ED63
		protected override void OnUnSelect()
		{
			base.GetItem(12).SetUIActive(false);
			base.GetItem(11).SetUIActive(true);
		}

		// Token: 0x06034768 RID: 214888 RVA: 0x00D20B81 File Offset: 0x00D1ED81
		private void OnSelectedItem()
		{
			Action<int> buttonFunction = this.ButtonFunction;
			if (buttonFunction == null)
			{
				return;
			}
			buttonFunction(this.CurrentShowItemIndex);
		}

		// Token: 0x06034769 RID: 214889 RVA: 0x00D20B9C File Offset: 0x00D1ED9C
		protected override void OnMoveItem()
		{
			float currentMovePercentage = base.GetCurrentMovePercentage();
			this.RefreshScaleByCurve(currentMovePercentage);
			this.RefreshAlphaByCurve(currentMovePercentage);
			this.RefreshOffset(currentMovePercentage);
			this.RefreshHierarchyIndex(currentMovePercentage);
		}

		// Token: 0x0603476A RID: 214890 RVA: 0x00D20BCC File Offset: 0x00D1EDCC
		private void RefreshScaleByCurve(float percentage)
		{
			float floatValue = RoleSkinItem.ScaleCurve.GetFloatValue(percentage);
			FVector uiitemScale = new FVector(floatValue, floatValue, floatValue);
			this.RootItem.SetUIItemScale(uiitemScale);
		}

		// Token: 0x0603476B RID: 214891 RVA: 0x00D20BFC File Offset: 0x00D1EDFC
		private void RefreshAlphaByCurve(float percentage)
		{
			float floatValue = RoleSkinItem.AlphaCurve.GetFloatValue(percentage);
			this.RootItem.SetUIItemAlpha(floatValue);
		}

		// Token: 0x0603476C RID: 214892 RVA: 0x00D20C24 File Offset: 0x00D1EE24
		private void RefreshOffset(float percentage)
		{
			float floatValue = RoleSkinItem.OffsetCurve.GetFloatValue(percentage);
			if (percentage > 0.5f)
			{
				UUIButtonComponent button = base.GetButton(0);
				if (button == null)
				{
					return;
				}
				button.RootUIComp.Get().SetAnchorOffsetX(-1f * floatValue);
				return;
			}
			else
			{
				UUIButtonComponent button2 = base.GetButton(0);
				if (button2 == null)
				{
					return;
				}
				button2.RootUIComp.Get().SetAnchorOffsetX(floatValue);
				return;
			}
		}

		// Token: 0x0603476D RID: 214893 RVA: 0x00D20C8C File Offset: 0x00D1EE8C
		private void RefreshHierarchyIndex(float percentage)
		{
			int num = 2;
			if (percentage <= 0.25f)
			{
				num = 1;
			}
			else if (percentage >= 0.75f)
			{
				num = 1;
			}
			if (this.RootItem.GetHierarchyIndex() != num)
			{
				this.RootItem.SetHierarchyIndex(num);
			}
		}

		// Token: 0x0603476E RID: 214894 RVA: 0x00D20CCB File Offset: 0x00D1EECB
		public RoleSkinItem() : base(null)
		{
		}

		// Token: 0x0401E36F RID: 123759
		public Action<int> ButtonFunction;

		// Token: 0x0401E370 RID: 123760
		public static UCurveFloat OffsetCurve;

		// Token: 0x0401E371 RID: 123761
		public static UCurveFloat ScaleCurve;

		// Token: 0x0401E372 RID: 123762
		public static UCurveFloat AlphaCurve;

		// Token: 0x0401E373 RID: 123763
		private const float INDEXQUARTER = 0.25f;

		// Token: 0x0401E374 RID: 123764
		private const float INDEXHALF = 0.5f;

		// Token: 0x0401E375 RID: 123765
		private const float INDEXTHREEQUARTER = 0.75f;

		// Token: 0x0401E376 RID: 123766
		private const int MAXHIERARCHYINDEX = 2;

		// Token: 0x0401E377 RID: 123767
		private const int MINHIERARCHYINDEX = 1;

		// Token: 0x0200AF91 RID: 44945
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x040367B5 RID: 223157
			Button,
			// Token: 0x040367B6 RID: 223158
			QualityTextureBg,
			// Token: 0x040367B7 RID: 223159
			RoleTexture,
			// Token: 0x040367B8 RID: 223160
			QualityTexture,
			// Token: 0x040367B9 RID: 223161
			WeaponRootItem,
			// Token: 0x040367BA RID: 223162
			WeaponTexture,
			// Token: 0x040367BB RID: 223163
			WearItem,
			// Token: 0x040367BC RID: 223164
			LockItem,
			// Token: 0x040367BD RID: 223165
			MaskLeft,
			// Token: 0x040367BE RID: 223166
			MaskRight,
			// Token: 0x040367BF RID: 223167
			WeaponQualityTexture,
			// Token: 0x040367C0 RID: 223168
			TextureMask,
			// Token: 0x040367C1 RID: 223169
			TextureRoleSelect,
			// Token: 0x040367C2 RID: 223170
			EffectBItem,
			// Token: 0x040367C3 RID: 223171
			EffectAItem,
			// Token: 0x040367C4 RID: 223172
			NewItem
		}
	}
}
