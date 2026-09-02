using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006337 RID: 25399
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SpringManorRoleGridItem : LoopScrollMediumItemGrid<RoleDataBase>
	{
		// Token: 0x0603FCCB RID: 261323 RVA: 0x0105C18C File Offset: 0x0105A38C
		protected override void OnRefresh(RoleDataBase roleDataBase, bool isSelected, int gridIndex)
		{
			int dataId = roleDataBase.GetDataId();
			if (dataId == this.RoleId)
			{
				return;
			}
			this.RoleId = dataId;
			bool value = roleDataBase.IsTrialRole();
			CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
			{
				Data = roleDataBase,
				ItemConfigId = new int?(dataId),
				SkinId = roleDataBase.GetRoleConfig().SkinId,
				BottomText = roleDataBase.GetName(null),
				IsTrialRoleVisible = new bool?(value),
				IsDisable = new bool?(ModelBase<SpringManorModel>.Instance.IsRoleDead(dataId))
			};
			base.SetUseFixedAsync(true);
			base.Apply<CharacterMediumItemGrid>(parameters);
			EditFormationData getCurrentFormationData = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData;
			int? num = (getCurrentFormationData != null) ? new int?(getCurrentFormationData.GetCurrentRoleConfigId) : null;
			int? num2 = num;
			int num3 = dataId;
			base.SetCurTagIcon(new bool?(num2.GetValueOrDefault() == num3 & num2 != null));
			this.SetToggleState(isSelected, false, true);
		}

		// Token: 0x0603FCCC RID: 261324 RVA: 0x0105C27E File Offset: 0x0105A47E
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleState(false, false, false);
		}

		// Token: 0x0603FCCD RID: 261325 RVA: 0x0105C289 File Offset: 0x0105A489
		public void SetToggleState(bool select, bool fireEvent, bool skipAnim = false)
		{
			UUIExtendToggle itemGridExtendToggle = this.GetItemGridExtendToggle();
			if (itemGridExtendToggle == null)
			{
				return;
			}
			itemGridExtendToggle.SetToggleStateForce(select ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, skipAnim);
		}

		// Token: 0x04023D46 RID: 146758
		private int RoleId;
	}
}
