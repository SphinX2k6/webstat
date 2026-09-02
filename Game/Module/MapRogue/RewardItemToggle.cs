using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200596B RID: 22891
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RewardItemToggle : GridProxyAbstract<MapRogueRewardItemData>
	{
		// Token: 0x0603A020 RID: 237600 RVA: 0x00EADCB8 File Offset: 0x00EABEB8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick))
			};
		}

		// Token: 0x0603A021 RID: 237601 RVA: 0x00EADDA3 File Offset: 0x00EABFA3
		protected override void OnStart()
		{
			this.Toggle = base.GetExtendToggle(0);
			this.Toggle.SetSelfInteractive(!this.IsAllSelect);
			this.Toggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		}

		// Token: 0x0603A022 RID: 237602 RVA: 0x00EADDE2 File Offset: 0x00EABFE2
		protected override void OnBeforeDestroy()
		{
			UUIExtendToggle toggle = this.Toggle;
			if (toggle != null)
			{
				toggle.CanExecuteChange.Unbind();
			}
			this.Toggle = null;
		}

		// Token: 0x0603A023 RID: 237603 RVA: 0x00EADE04 File Offset: 0x00EAC004
		public override void Refresh(MapRogueRewardItemData rewardData, bool isSelected, int gridIndex)
		{
			this.Data = rewardData;
			UUITexture texture = base.GetTexture(7);
			UUITexture texture2 = base.GetTexture(1);
			UUIText text = base.GetText(2);
			UUIText text2 = base.GetText(5);
			int value;
			if (rewardData.IsRole)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(rewardData.ConfigId, true);
				if (roleDataById == null)
				{
					return;
				}
				int roleSkinId = roleDataById.GetRoleSkinId();
				RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId);
				texture2.SetUIActive(false);
				base.SetTextureShowUntilLoaded(roleSkinConfig.Value.FormationRoleCard, texture, null);
				text.SetText(roleDataById.GetName(null), true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "RogueRes_AddRole_Desc", new <>z__ReadOnlySingleElementList<object>(roleDataById.GetName(null)));
				value = roleDataById.GetQualityConfig().Id;
			}
			else
			{
				ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(rewardData.ConfigId);
				if (itemConfigData == null)
				{
					return;
				}
				base.SetItemIcon(texture2, rewardData.ConfigId, null, null);
				texture2.SetUIActive(true);
				texture.SetUIActive(false);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, itemConfigData.Name, Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, itemConfigData.AttributesDescription, Array.Empty<object>());
				value = itemConfigData.QualityId;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "RogueRes_AccuracyNumShow", new <>z__ReadOnlySingleElementList<object>(rewardData.Count));
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("T_RogueItemQualityBg");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			string resourceId = defaultInterpolatedStringHandler.ToStringAndClear();
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureShowUntilLoaded(resourcePath, base.GetTexture(4), null);
			this.SetItemDone(rewardData.IsSelect);
		}

		// Token: 0x0603A024 RID: 237604 RVA: 0x00EADFD4 File Offset: 0x00EAC1D4
		public void SetToggleState(bool bSelectOn, bool bFireEvent = false)
		{
			EToggleState state = bSelectOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleStateForce(state, bFireEvent, false, false);
		}

		// Token: 0x0603A025 RID: 237605 RVA: 0x00EADFF9 File Offset: 0x00EAC1F9
		public void SetItemDone(bool bDone)
		{
			base.GetText(6).SetUIActive(!bDone);
			base.GetItem(3).SetUIActive(bDone);
		}

		// Token: 0x0603A026 RID: 237606 RVA: 0x00EAE018 File Offset: 0x00EAC218
		private bool CanExecuteChange()
		{
			if (this.OnCanExecuteChangeFunc != null)
			{
				Func<bool, MapRogueRewardItemData, bool> onCanExecuteChangeFunc = this.OnCanExecuteChangeFunc;
				UUIExtendToggle toggle = this.Toggle;
				return onCanExecuteChangeFunc(toggle != null && toggle.GetToggleState() == EToggleState.ETT_Checked, this.Data);
			}
			return true;
		}

		// Token: 0x0603A027 RID: 237607 RVA: 0x00EAE04A File Offset: 0x00EAC24A
		private void OnToggleClick(EToggleState state)
		{
			Action<bool, MapRogueRewardItemData> onExtendToggleClicked = this.OnExtendToggleClicked;
			if (onExtendToggleClicked == null)
			{
				return;
			}
			onExtendToggleClicked(state == EToggleState.ETT_Checked, this.Data);
		}

		// Token: 0x0603A028 RID: 237608 RVA: 0x00EAE066 File Offset: 0x00EAC266
		public override object GetKey(MapRogueRewardItemData data, int displayIndex)
		{
			return this.Data.Index;
		}

		// Token: 0x04020E1D RID: 134685
		protected MapRogueRewardItemData Data;

		// Token: 0x04020E1E RID: 134686
		[Nullable(2)]
		protected UUIExtendToggle Toggle;

		// Token: 0x04020E1F RID: 134687
		public bool IsAllSelect;

		// Token: 0x04020E20 RID: 134688
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<bool, MapRogueRewardItemData> OnExtendToggleClicked;

		// Token: 0x04020E21 RID: 134689
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<bool, MapRogueRewardItemData, bool> OnCanExecuteChangeFunc;
	}
}
