using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoleTrial
{
	// Token: 0x02006479 RID: 25721
	[NullableContext(2)]
	[Nullable(0)]
	internal class RoleItem : GridProxyAbstract<int>
	{
		// Token: 0x0604085C RID: 264284 RVA: 0x01089913 File Offset: 0x01087B13
		[NullableContext(1)]
		public RoleItem(ActivityRoleTrialData activityData)
		{
			this.ActivityData = activityData;
		}

		// Token: 0x0604085D RID: 264285 RVA: 0x01089924 File Offset: 0x01087B24
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleCallBackInternal));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604085E RID: 264286 RVA: 0x01089A90 File Offset: 0x01087C90
		protected override void OnStart()
		{
			this.Toggle = base.GetExtendToggle(0);
			if (this.Toggle != null)
			{
				this.Toggle.CanExecuteChange.Unbind();
				this.Toggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChangeInternal));
			}
		}

		// Token: 0x0604085F RID: 264287 RVA: 0x01089AE0 File Offset: 0x01087CE0
		public override void Refresh(int roleId, bool isSelected, int gridIndex)
		{
			this.RoleId = roleId;
			RoleTrialInfo? roleTrialInfoConfigByRoleId = ConfigBase<ActivityRoleTrialConfig>.Instance.GetRoleTrialInfoConfigByRoleId(this.RoleId);
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleTrialInfoConfigByRoleId.Value.TrialRoleId, true);
			RoleTrialRoleConfig? roleTrialRoleConfigByRoleId = ConfigBase<ActivityRoleTrialConfig>.Instance.GetRoleTrialRoleConfigByRoleId(roleTrialInfoConfigByRoleId.Value.RoleId);
			if (!string.IsNullOrEmpty(roleTrialRoleConfigByRoleId.Value.RoleIcon))
			{
				base.SetTextureShowUntilLoaded(roleTrialRoleConfigByRoleId.Value.RoleIcon, base.GetTexture(3), null);
				base.SetTextureShowUntilLoaded(roleTrialRoleConfigByRoleId.Value.RoleIcon, base.GetTexture(5), null);
			}
			this.RefreshQualitySprite(roleDataById.GetRoleConfig().QualityId);
			this.RefreshRedDotAndNew();
		}

		// Token: 0x06040860 RID: 264288 RVA: 0x01089BA8 File Offset: 0x01087DA8
		private void RefreshQualitySprite(int qualityId)
		{
			UUIItem sprite = base.GetSprite(1);
			QualityInfo? qualityConfig = ConfigBase<ItemConfig>.Instance.GetQualityConfig(qualityId);
			sprite.SetColor(FColor.FromHex(((qualityConfig != null) ? qualityConfig.GetValueOrDefault().RoleTrialQualityColor : null) ?? ""));
		}

		// Token: 0x06040861 RID: 264289 RVA: 0x01089BF8 File Offset: 0x01087DF8
		private void RefreshRedDotAndNew()
		{
			ERoleTrialRewardState rewardStateByRoleId = this.ActivityData.GetRewardStateByRoleId(this.RoleId);
			base.GetItem(4).SetUIActive(rewardStateByRoleId == ERoleTrialRewardState.FinishedAndUnClaimed);
			base.GetItem(6).SetUIActive(rewardStateByRoleId == ERoleTrialRewardState.FinishedAndClaimed);
			bool isNewByRoleId = this.ActivityData.GetIsNewByRoleId(this.RoleId);
			base.GetItem(7).SetUIActive(isNewByRoleId && rewardStateByRoleId == ERoleTrialRewardState.InActive);
		}

		// Token: 0x06040862 RID: 264290 RVA: 0x01089C5F File Offset: 0x01087E5F
		public void SetToggleState(bool bSelectOn, bool bFireEvent = false)
		{
			UUIExtendToggle toggle = this.Toggle;
			if (toggle == null)
			{
				return;
			}
			toggle.SetToggleState(bSelectOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent, false, false);
		}

		// Token: 0x06040863 RID: 264291 RVA: 0x01089C7C File Offset: 0x01087E7C
		public bool IsToggleChecked()
		{
			UUIExtendToggle toggle = this.Toggle;
			return toggle != null && toggle.GetToggleState() == EToggleState.ETT_Checked;
		}

		// Token: 0x06040864 RID: 264292 RVA: 0x01089C92 File Offset: 0x01087E92
		public void MarkAsOld()
		{
			base.GetItem(7).SetUIActive(false);
		}

		// Token: 0x06040865 RID: 264293 RVA: 0x01089CA1 File Offset: 0x01087EA1
		private bool CanToggleExecuteChangeInternal()
		{
			return this.CanToggleExecuteChange == null || this.CanToggleExecuteChange(this.RoleId);
		}

		// Token: 0x06040866 RID: 264294 RVA: 0x01089CBE File Offset: 0x01087EBE
		private void ToggleCallBackInternal(EToggleState _)
		{
			if (this.ToggleCallBack != null)
			{
				this.ToggleCallBack(this.RoleId, this.Toggle.GetToggleState() == EToggleState.ETT_Checked);
			}
		}

		// Token: 0x040241C8 RID: 147912
		protected int RoleId;

		// Token: 0x040241C9 RID: 147913
		protected UUIExtendToggle Toggle;

		// Token: 0x040241CA RID: 147914
		public Func<int, bool> CanToggleExecuteChange;

		// Token: 0x040241CB RID: 147915
		public Action<int, bool> ToggleCallBack;

		// Token: 0x040241CC RID: 147916
		private ActivityRoleTrialData ActivityData;

		// Token: 0x0200C4D4 RID: 50388
		[NullableContext(0)]
		private class ERoleComponents
		{
			// Token: 0x0403C986 RID: 248198
			public const int Toggle = 0;

			// Token: 0x0403C987 RID: 248199
			public const int SpriteNormal = 1;

			// Token: 0x0403C988 RID: 248200
			public const int SpriteHold = 2;

			// Token: 0x0403C989 RID: 248201
			public const int RoleIcon = 3;

			// Token: 0x0403C98A RID: 248202
			public const int RedDot = 4;

			// Token: 0x0403C98B RID: 248203
			public const int RoleIconMask = 5;

			// Token: 0x0403C98C RID: 248204
			public const int PanelDone = 6;

			// Token: 0x0403C98D RID: 248205
			public const int PanelNew = 7;
		}
	}
}
