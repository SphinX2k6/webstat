using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoleSkinTrial
{
	// Token: 0x0200647C RID: 25724
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class RoleItem : GridProxyAbstract<RoleItemData>
	{
		// Token: 0x06040883 RID: 264323 RVA: 0x0108A858 File Offset: 0x01088A58
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
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
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleCallBackInternal));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040884 RID: 264324 RVA: 0x0108A984 File Offset: 0x01088B84
		protected override void OnStart()
		{
			this.Toggle = base.GetExtendToggle(0);
			if (this.Toggle != null)
			{
				this.Toggle.CanExecuteChange.Unbind();
				this.Toggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChangeInternal));
			}
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnStateChange));
		}

		// Token: 0x06040885 RID: 264325 RVA: 0x0108A9EE File Offset: 0x01088BEE
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnStateChange));
		}

		// Token: 0x06040886 RID: 264326 RVA: 0x0108AA0C File Offset: 0x01088C0C
		private void OnStateChange(int id)
		{
			RoleItemData data = this.Data;
			int? num = (data != null) ? new int?(data.ActivityId) : null;
			if (!(id == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			this.RefreshRedDot(this.Data);
		}

		// Token: 0x06040887 RID: 264327 RVA: 0x0108AA5A File Offset: 0x01088C5A
		private bool CanToggleExecuteChangeInternal()
		{
			return this.CanToggleExecuteChange == null || this.CanToggleExecuteChange(this.RoleId);
		}

		// Token: 0x06040888 RID: 264328 RVA: 0x0108AA77 File Offset: 0x01088C77
		private void ToggleCallBackInternal(EToggleState _)
		{
			if (this.ToggleCallBack != null)
			{
				this.ToggleCallBack(this.Data);
			}
		}

		// Token: 0x06040889 RID: 264329 RVA: 0x0108AA92 File Offset: 0x01088C92
		public override void Refresh(RoleItemData data, bool isSelected, int gridIndex)
		{
			this.RoleId = data.RoleId;
			this.Data = data;
			this.RefreshRoleIcon(this.RoleId);
			this.RefreshQualitySprite(this.RoleId);
			this.RefreshRedDot(data);
			this.RefreshToggleState(data.SelectState);
		}

		// Token: 0x0604088A RID: 264330 RVA: 0x0108AAD2 File Offset: 0x01088CD2
		private void RefreshToggleState(bool selectState)
		{
			base.GetExtendToggle(0).SetToggleState(selectState ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0604088B RID: 264331 RVA: 0x0108AAEC File Offset: 0x01088CEC
		private void RefreshRoleIcon(int roleId)
		{
			RoleSkinTrialInfo value = ConfigBase<RoleSkinTrialConfig>.Instance.GetRoleSkinTrialInfoById(roleId).Value;
			if (!string.IsNullOrEmpty(value.RoleIcon))
			{
				base.SetTextureShowUntilLoaded(value.RoleIcon, base.GetTexture(3), null);
				base.SetTextureShowUntilLoaded(value.RoleIcon, base.GetTexture(5), null);
			}
		}

		// Token: 0x0604088C RID: 264332 RVA: 0x0108AB48 File Offset: 0x01088D48
		private void RefreshQualitySprite(int roleId)
		{
			RoleSkinTrialInfo? roleSkinTrialInfoById = ConfigBase<RoleSkinTrialConfig>.Instance.GetRoleSkinTrialInfoById(roleId);
			int qualityId = ModelBase<RoleModel>.Instance.GetRoleDataById(roleSkinTrialInfoById.Value.TrialRoleId, true).GetRoleConfig().QualityId;
			UUIItem sprite = base.GetSprite(1);
			QualityInfo? qualityConfig = ConfigBase<ItemConfig>.Instance.GetQualityConfig(qualityId);
			sprite.SetColor(FColor.FromHex(((qualityConfig != null) ? qualityConfig.GetValueOrDefault().RoleTrialQualityColor : null) ?? ""));
		}

		// Token: 0x0604088D RID: 264333 RVA: 0x0108ABCC File Offset: 0x01088DCC
		public void RefreshRedDot(RoleItemData data)
		{
			int activityId = data.ActivityId;
			RoleSkinTrialData roleSkinTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as RoleSkinTrialData;
			int selectIdByIndex = roleSkinTrialData.GetSelectIdByIndex(data.Index);
			ChallengeState rewardStateById = roleSkinTrialData.GetRewardStateById(selectIdByIndex);
			base.GetItem(4).SetUIActive(rewardStateById == ChallengeState.WaitTakeReward);
		}

		// Token: 0x040241D9 RID: 147929
		protected int RoleId;

		// Token: 0x040241DA RID: 147930
		private RoleItemData Data;

		// Token: 0x040241DB RID: 147931
		protected UUIExtendToggle Toggle;

		// Token: 0x040241DC RID: 147932
		public Func<int, bool> CanToggleExecuteChange;

		// Token: 0x040241DD RID: 147933
		public Action<RoleItemData> ToggleCallBack;

		// Token: 0x0200C4D8 RID: 50392
		[NullableContext(0)]
		private class ERoleComponents
		{
			// Token: 0x0403C9AB RID: 248235
			public const int Toggle = 0;

			// Token: 0x0403C9AC RID: 248236
			public const int SpriteNormal = 1;

			// Token: 0x0403C9AD RID: 248237
			public const int SpriteHold = 2;

			// Token: 0x0403C9AE RID: 248238
			public const int RoleIcon = 3;

			// Token: 0x0403C9AF RID: 248239
			public const int RedDot = 4;

			// Token: 0x0403C9B0 RID: 248240
			public const int RoleIconMask = 5;
		}
	}
}
