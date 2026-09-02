using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F77 RID: 24439
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiJoystickData
	{
		// Token: 0x0603D581 RID: 251265 RVA: 0x00F99DED File Offset: 0x00F97FED
		public void Init()
		{
		}

		// Token: 0x0603D582 RID: 251266 RVA: 0x00F99DEF File Offset: 0x00F97FEF
		public void Clear()
		{
			this.ClearTasks();
		}

		// Token: 0x0603D583 RID: 251267 RVA: 0x00F99DF7 File Offset: 0x00F97FF7
		public void OnLeaveLevel()
		{
			this.ClearTasks();
		}

		// Token: 0x0603D584 RID: 251268 RVA: 0x00F99E00 File Offset: 0x00F98000
		public void EnterVehicle(VehiclePassengerInfo info)
		{
			if (!info.IsRolePassenger(true))
			{
				return;
			}
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			Entity vehicleEntity = info.VehicleEntity;
			EntityHandle entityById = instance.GetEntityById((vehicleEntity != null) ? vehicleEntity.Id : 0);
			if (entityById != null && entityById.Valid)
			{
				BaseTagComponent component = entityById.Entity.GetComponent<BaseTagComponent>();
				foreach (string tagName in ConfigCommonParamById.GetStringArrayConfig("VehicleRoundJoystickTriggerTags"))
				{
					int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
					if (component.HasTag(tagIdByName))
					{
						this.ForceRoundJoystickTagSet.Add(tagIdByName);
					}
					ITagTask item = component.ListenForTagAddOrRemove(new int?(tagIdByName), new BaseTagComponent.TTagSwitchedCallback(this.OnEnableRoundJoystick), null);
					this.SwitchJoystickTasks.Add(item);
				}
			}
			this.RefreshMotorMobileButtonLayout(null);
		}

		// Token: 0x0603D585 RID: 251269 RVA: 0x00F99EE0 File Offset: 0x00F980E0
		public void LeaveVehicle(VehiclePassengerInfo info)
		{
			this.ClearTasks();
		}

		// Token: 0x0603D586 RID: 251270 RVA: 0x00F99EE8 File Offset: 0x00F980E8
		private void OnEnableRoundJoystick(int tagId, bool tagExists)
		{
			if (tagExists)
			{
				this.ForceRoundJoystickTagSet.Add(tagId);
			}
			else
			{
				this.ForceRoundJoystickTagSet.Remove(tagId);
			}
			this.RefreshMotorcycleRoundJoystick(null);
		}

		// Token: 0x0603D587 RID: 251271 RVA: 0x00F99F24 File Offset: 0x00F98124
		public void RefreshMotorcycleRoundJoystick(bool? isRoundJoystickButtonLayout = null)
		{
			bool motorMobileButtonLayout = this.GetMotorMobileButtonLayout(isRoundJoystickButtonLayout);
			bool isRoundJoystick = this.ForceRoundJoystickTagSet.Count > 0 || motorMobileButtonLayout;
			ModelBase<BattleUiModel>.Instance.MotorcycleData.SetIsRoundJoystick(isRoundJoystick);
		}

		// Token: 0x0603D588 RID: 251272 RVA: 0x00F99F5C File Offset: 0x00F9815C
		public void RefreshMotorMobileSkillButtonLayout(bool? isRoundJoystickButtonLayout = null)
		{
			bool motorMobileButtonLayout = this.GetMotorMobileButtonLayout(isRoundJoystickButtonLayout);
			ModelBase<BattleUiModel>.Instance.MotorcycleData.SetIsRoundJoystickButtonLayout(motorMobileButtonLayout);
		}

		// Token: 0x0603D589 RID: 251273 RVA: 0x00F99F81 File Offset: 0x00F98181
		public void RefreshMotorMobileButtonLayout(bool? isRoundJoystickButtonLayout = null)
		{
			this.RefreshMotorMobileSkillButtonLayout(isRoundJoystickButtonLayout);
			this.RefreshMotorcycleRoundJoystick(isRoundJoystickButtonLayout);
		}

		// Token: 0x0603D58A RID: 251274 RVA: 0x00F99F94 File Offset: 0x00F98194
		private bool GetMotorMobileButtonLayout(bool? isRoundJoystickButtonLayout = null)
		{
			if (isRoundJoystickButtonLayout != null)
			{
				return isRoundJoystickButtonLayout.Value;
			}
			int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.MotorMobileButtonLayout, true, true);
			int num = 0;
			return currentValue.GetValueOrDefault() == num & currentValue != null;
		}

		// Token: 0x0603D58B RID: 251275 RVA: 0x00F99FD8 File Offset: 0x00F981D8
		private void ClearTasks()
		{
			foreach (ITagTask tagTask in this.SwitchJoystickTasks)
			{
				tagTask.EndTask();
			}
			this.SwitchJoystickTasks.Clear();
			this.ForceRoundJoystickTagSet.Clear();
		}

		// Token: 0x04022728 RID: 141096
		private List<ITagTask> SwitchJoystickTasks = new List<ITagTask>();

		// Token: 0x04022729 RID: 141097
		private HashSet<int> ForceRoundJoystickTagSet = new HashSet<int>();
	}
}
