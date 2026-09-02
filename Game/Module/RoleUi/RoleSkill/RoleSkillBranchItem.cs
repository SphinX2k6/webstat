using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleSkill
{
	// Token: 0x02005072 RID: 20594
	public class RoleSkillBranchItem : UiPanelBase
	{
		// Token: 0x06035170 RID: 217456 RVA: 0x00D50834 File Offset: 0x00D4EA34
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnBranchToggleClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBranchHelpButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnCloseTipsButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035171 RID: 217457 RVA: 0x00D50A08 File Offset: 0x00D4EC08
		protected override UniTask OnBeforeStartAsync()
		{
			RoleSkillBranchItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleSkillBranchItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035172 RID: 217458 RVA: 0x00D50A4C File Offset: 0x00D4EC4C
		private UniTask InitBranchTipsItem()
		{
			RoleSkillBranchItem.<InitBranchTipsItem>d__7 <InitBranchTipsItem>d__;
			<InitBranchTipsItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBranchTipsItem>d__.<>4__this = this;
			<InitBranchTipsItem>d__.<>1__state = -1;
			<InitBranchTipsItem>d__.<>t__builder.Start<RoleSkillBranchItem.<InitBranchTipsItem>d__7>(ref <InitBranchTipsItem>d__);
			return <InitBranchTipsItem>d__.<>t__builder.Task;
		}

		// Token: 0x06035173 RID: 217459 RVA: 0x00D50A90 File Offset: 0x00D4EC90
		public bool SetSkillBranchVisible(ESkillBranchInvisibleReason reason, bool visible)
		{
			if (visible)
			{
				this.InvisibleSet.Remove(reason);
			}
			else
			{
				this.InvisibleSet.Add(reason);
			}
			bool flag = this.CanShowSkillBranch();
			base.GetRootItem().SetUIActive(flag);
			return flag;
		}

		// Token: 0x06035174 RID: 217460 RVA: 0x00D50AD0 File Offset: 0x00D4ECD0
		public void SetSkillBranchTipsVisible(bool visible)
		{
			this.RoleSkillBranchTipsItem.SetTipsVisible(visible, true);
			base.GetButton(6).RootUIComp.Get().SetUIActive(visible);
		}

		// Token: 0x06035175 RID: 217461 RVA: 0x00D50B04 File Offset: 0x00D4ED04
		private bool CanShowSkillBranch()
		{
			return this.InvisibleSet.Count == 0;
		}

		// Token: 0x06035176 RID: 217462 RVA: 0x00D50B14 File Offset: 0x00D4ED14
		public void Refresh(int roleId, bool enableSwitchBranch)
		{
			this.RoleId = roleId;
			this.EnableSwitchBranch = enableSwitchBranch;
			bool visible = ModelBase<RoleModel>.Instance.IsRoleHasBranch(this.RoleId);
			if (!this.SetSkillBranchVisible(ESkillBranchInvisibleReason.NotHaveSkillBranch, visible))
			{
				return;
			}
			base.GetSprite(1).SetUIActive(!this.EnableSwitchBranch);
			int roleBranchIdByIndex = ModelBase<RoleModel>.Instance.GetRoleBranchIdByIndex(this.RoleId, 0);
			this.SetSpriteByPath(ConfigBase<RoleConfig>.Instance.GetSkillBranchConfigById(roleBranchIdByIndex).Value.Icon, base.GetSprite(4), false, null, null);
			int roleBranchIdByIndex2 = ModelBase<RoleModel>.Instance.GetRoleBranchIdByIndex(this.RoleId, 1);
			this.SetSpriteByPath(ConfigBase<RoleConfig>.Instance.GetSkillBranchConfigById(roleBranchIdByIndex2).Value.Icon, base.GetSprite(5), false, null, null);
			base.GetItem(7).SetUIActive(this.EnableSwitchBranch);
			base.GetItem(8).SetUIActive(this.EnableSwitchBranch);
			EToggleState etoggleState = (ModelBase<RoleModel>.Instance.GetRoleCurrentBranchIndex(this.RoleId) == 0) ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
			EToggleState state = this.EnableSwitchBranch ? etoggleState : EToggleState.ETT_UnDetermined;
			base.GetExtendToggle(0).SetToggleStateForce(state, false, false, false);
			if (ModelBase<RoleModel>.Instance.IsRoleOwned(this.RoleId))
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "OnShowOwnedRoleSkillBranch");
			}
		}

		// Token: 0x06035177 RID: 217463 RVA: 0x00D50C74 File Offset: 0x00D4EE74
		private void OnBranchToggleClick(EToggleState state)
		{
			int index = (state > EToggleState.ETT_UnChecked) ? 1 : 0;
			int roleBranchIdByIndex = ModelBase<RoleModel>.Instance.GetRoleBranchIdByIndex(this.RoleId, index);
			int roleCurrentBranchId = ModelBase<RoleModel>.Instance.GetRoleCurrentBranchId(this.RoleId);
			if (roleBranchIdByIndex == roleCurrentBranchId)
			{
				return;
			}
			ControllerBase<RoleController>.Instance.RequestRoleSkillBranchModify(this.RoleId, roleBranchIdByIndex);
		}

		// Token: 0x06035178 RID: 217464 RVA: 0x00D50CBF File Offset: 0x00D4EEBF
		private void OnBranchHelpButtonClick()
		{
			if (this.RoleSkillBranchTipsItem.IsTipsVisible)
			{
				this.RoleSkillBranchTipsItem.SetTipsVisible(false, true);
				return;
			}
			this.RoleSkillBranchTipsItem.RefreshView(this.RoleId, this.EnableSwitchBranch);
			this.SetSkillBranchTipsVisible(true);
		}

		// Token: 0x06035179 RID: 217465 RVA: 0x00D50CFA File Offset: 0x00D4EEFA
		private bool CanExecuteChange()
		{
			return ModelBase<RoleModel>.Instance.CheckCanSwitchRoleBranch(true) && ModelBase<RoleModel>.Instance.IsRoleHasBranch(this.RoleId);
		}

		// Token: 0x0603517A RID: 217466 RVA: 0x00D50D1C File Offset: 0x00D4EF1C
		private void OnCloseTipsButtonClick()
		{
			this.RoleSkillBranchTipsItem.SetTipsVisible(false, true);
			base.GetButton(6).RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x0401E922 RID: 125218
		private int RoleId;

		// Token: 0x0401E923 RID: 125219
		private bool EnableSwitchBranch;

		// Token: 0x0401E924 RID: 125220
		[Nullable(2)]
		private RoleSkillBranchTipsItem RoleSkillBranchTipsItem;

		// Token: 0x0401E925 RID: 125221
		[Nullable(1)]
		private HashSet<ESkillBranchInvisibleReason> InvisibleSet = new HashSet<ESkillBranchInvisibleReason>();

		// Token: 0x0200B029 RID: 45097
		private enum EComponent
		{
			// Token: 0x04036A61 RID: 223841
			BranchToggle,
			// Token: 0x04036A62 RID: 223842
			StateSprite,
			// Token: 0x04036A63 RID: 223843
			BranchHelpButton,
			// Token: 0x04036A64 RID: 223844
			BranchTipsSlot,
			// Token: 0x04036A65 RID: 223845
			BranchLeftTagSprite,
			// Token: 0x04036A66 RID: 223846
			BranchRightTagSprite,
			// Token: 0x04036A67 RID: 223847
			CloseTipsButton,
			// Token: 0x04036A68 RID: 223848
			BranchLeftItem,
			// Token: 0x04036A69 RID: 223849
			BranchRightItem
		}
	}
}
