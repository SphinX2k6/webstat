using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064E4 RID: 25828
	[NullableContext(2)]
	[Nullable(0)]
	internal class RhythmShipChoseRoleItem : GridProxyAbstract<int>
	{
		// Token: 0x06040B1F RID: 264991 RVA: 0x01096690 File Offset: 0x01094890
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(9, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickToggle))
			};
		}

		// Token: 0x06040B20 RID: 264992 RVA: 0x01096792 File Offset: 0x01094992
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmShipRedDotRefresh, new Action<List<int>, List<int>, List<int>>(this.OnRhythmShipRedDotRefresh));
		}

		// Token: 0x06040B21 RID: 264993 RVA: 0x010967B0 File Offset: 0x010949B0
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmShipRedDotRefresh, new Action<List<int>, List<int>, List<int>>(this.OnRhythmShipRedDotRefresh));
		}

		// Token: 0x06040B22 RID: 264994 RVA: 0x010967D0 File Offset: 0x010949D0
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			this.RoleId = data;
			RhythmRole? rhythmRoleById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmRoleById(this.RoleId);
			if (rhythmRoleById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rhythmRoleById.Value.RoleNameText, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), rhythmRoleById.Value.RoleDesText, Array.Empty<object>());
			base.SetTextureByPath(rhythmRoleById.Value.RoleHeadTexture, base.GetTexture(0), null, null);
			if (!string.IsNullOrEmpty(rhythmRoleById.Value.SkillIcon))
			{
				base.GetItem(1).SetUIActive(true);
				base.SetTextureByPath(rhythmRoleById.Value.SkillIcon, base.GetTexture(2), null, null);
			}
			else
			{
				base.GetItem(1).SetUIActive(false);
			}
			this.IsUnLock = activityData.RoleUnlockList.Contains(this.RoleId);
			base.GetItem(5).SetUIActive(!this.IsUnLock);
			this.HaveRedDotItem = ModelBase<RhythmShipModel>.Instance.GetRoleRedDotActive(this.RoleId);
			base.GetItem(9).SetUIActive(this.HaveRedDotItem);
		}

		// Token: 0x06040B23 RID: 264995 RVA: 0x0109692B File Offset: 0x01094B2B
		public void SetCurrentLevelSelectState(bool isSelected)
		{
			base.GetItem(7).SetUIActive(isSelected);
			base.GetExtendToggle(6).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, true, false, false);
		}

		// Token: 0x06040B24 RID: 264996 RVA: 0x01096954 File Offset: 0x01094B54
		private void OnClickToggle(EToggleState state)
		{
			if (this.IsUnLock)
			{
				Action<int, UUIExtendToggle> onClickToggleCallBack = this.OnClickToggleCallBack;
				if (onClickToggleCallBack != null)
				{
					onClickToggleCallBack(this.RoleId, base.GetExtendToggle(6));
				}
				if (this.IsUnLock && this.HaveRedDotItem)
				{
					ControllerBase<RhythmShipController>.Instance.RhythmSetRedDotRequest(null, null, new List<int>
					{
						this.RoleId
					});
				}
				return;
			}
			RhythmRole? rhythmRoleById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmRoleById(this.RoleId);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(((rhythmRoleById != null) ? rhythmRoleById.GetValueOrDefault().LockTips : null) ?? "RhythmShipRoleLockTips", Array.Empty<object>());
			Action<int, UUIExtendToggle> onClickToggleCallBack2 = this.OnClickToggleCallBack;
			if (onClickToggleCallBack2 == null)
			{
				return;
			}
			onClickToggleCallBack2(0, base.GetExtendToggle(6));
		}

		// Token: 0x06040B25 RID: 264997 RVA: 0x01096A11 File Offset: 0x01094C11
		private void OnRhythmShipRedDotRefresh(List<int> planet, List<int> subLevel, List<int> role)
		{
			if (role == null || !role.Contains(this.RoleId))
			{
				return;
			}
			this.HaveRedDotItem = false;
			base.GetItem(9).SetUIActive(false);
		}

		// Token: 0x040243FF RID: 148479
		public int RoleId;

		// Token: 0x04024400 RID: 148480
		private bool IsUnLock;

		// Token: 0x04024401 RID: 148481
		private bool HaveRedDotItem;

		// Token: 0x04024402 RID: 148482
		public Action<int, UUIExtendToggle> OnClickToggleCallBack;
	}
}
