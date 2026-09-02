using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Module.InstanceDungeon;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F6D RID: 24429
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiExploreModeData
	{
		// Token: 0x0603D540 RID: 251200 RVA: 0x00F98F88 File Offset: 0x00F97188
		public void Init()
		{
			this.WaitingTime = (float)ConfigCommonParamById.GetIntConfig("ExploreModeWaitTime").Value;
			for (int i = 0; i < BattleUiExploreModeData.ActionNames.Length; i++)
			{
				string key = BattleUiExploreModeData.ActionNames[i];
				this.IsPressingList.Add(false);
				this.ActionNameMap[key] = i;
			}
			bool isAutoSwitchSkillButtonMode = ModelBase<BattleUiModel>.Instance.GetIsAutoSwitchSkillButtonMode();
			this.SetAutoSwitch(isAutoSwitchSkillButtonMode);
		}

		// Token: 0x0603D541 RID: 251201 RVA: 0x00F98FF3 File Offset: 0x00F971F3
		public void OnLeaveLevel()
		{
		}

		// Token: 0x0603D542 RID: 251202 RVA: 0x00F98FF5 File Offset: 0x00F971F5
		public void Clear()
		{
			this.SetAutoSwitch(false);
		}

		// Token: 0x0603D543 RID: 251203 RVA: 0x00F98FFE File Offset: 0x00F971FE
		public IReadOnlyList<string> GetActionNames()
		{
			return BattleUiExploreModeData.ActionNames;
		}

		// Token: 0x0603D544 RID: 251204 RVA: 0x00F99005 File Offset: 0x00F97205
		public bool GetIsInExploreMode()
		{
			return this.IsInExploreMode;
		}

		// Token: 0x0603D545 RID: 251205 RVA: 0x00F99010 File Offset: 0x00F97210
		public void SetAutoSwitch(bool isOpen)
		{
			this.IsAutoSwitch = false;
			if (this.IsAutoSwitch)
			{
				if (this.Timer == null)
				{
					this.Timer = TimerSystem.Instance.Forever(new TTimerAction(this.OnTimer), 1000f, 1f, null, null, true);
					return;
				}
			}
			else
			{
				this.DestroyTimer();
				if (this.IsInExploreMode)
				{
					this.IsInExploreMode = false;
					Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleUiExploreModeChanged, false);
				}
			}
		}

		// Token: 0x0603D546 RID: 251206 RVA: 0x00F99084 File Offset: 0x00F97284
		public void EnterBattleMode()
		{
			if (!this.IsInExploreMode)
			{
				return;
			}
			this.IsInExploreMode = false;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleUiExploreModeChanged, false);
		}

		// Token: 0x0603D547 RID: 251207 RVA: 0x00F990A7 File Offset: 0x00F972A7
		public void DelayExitBattleMode()
		{
			this.OpenExploreModeTime = (float)Singleton<Time>.Instance.WorldTime + this.WaitingTime;
		}

		// Token: 0x0603D548 RID: 251208 RVA: 0x00F990C1 File Offset: 0x00F972C1
		public void UpdateGuidingState(bool isGuiding)
		{
			this.IsGuiding = isGuiding;
			if (isGuiding)
			{
				this.EnterBattleMode();
				return;
			}
			this.DelayExitBattleMode();
		}

		// Token: 0x0603D549 RID: 251209 RVA: 0x00F990DA File Offset: 0x00F972DA
		public void UpdateBossState(bool isBossFight)
		{
			this.IsBossFight = isBossFight;
			if (isBossFight)
			{
				this.EnterBattleMode();
				return;
			}
			this.DelayExitBattleMode();
		}

		// Token: 0x0603D54A RID: 251210 RVA: 0x00F990F4 File Offset: 0x00F972F4
		public void InputAction(string actionName, bool isPress)
		{
			int index;
			if (!this.ActionNameMap.TryGetValue(actionName, out index))
			{
				return;
			}
			this.IsPressingList[index] = isPress;
			if (!isPress && this.IsInExploreMode)
			{
				return;
			}
			this.EnterBattleMode();
			this.DelayExitBattleMode();
		}

		// Token: 0x0603D54B RID: 251211 RVA: 0x00F99138 File Offset: 0x00F97338
		public void BeHit(Entity entity)
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (((curRoleData != null) ? curRoleData.EntityHandle : null) == null || curRoleData.EntityHandle.Entity != entity)
			{
				return;
			}
			this.EnterBattleMode();
			this.DelayExitBattleMode();
		}

		// Token: 0x0603D54C RID: 251212 RVA: 0x00F99179 File Offset: 0x00F97379
		public void UpdateDungeonState()
		{
			this.IsInForbiddenDungeon = this.CheckInForbiddenDungeon();
			if (this.IsInForbiddenDungeon && this.IsInExploreMode)
			{
				this.EnterBattleMode();
			}
		}

		// Token: 0x0603D54D RID: 251213 RVA: 0x00F991A0 File Offset: 0x00F973A0
		private void OnTimer(float _)
		{
			if (!this.IsAutoSwitch || this.IsInExploreMode || this.IsInForbiddenDungeon)
			{
				return;
			}
			if (Singleton<Time>.Instance.WorldTime < (double)this.OpenExploreModeTime)
			{
				return;
			}
			if (this.IsGuiding || this.IsBossFight)
			{
				return;
			}
			using (List<bool>.Enumerator enumerator = this.IsPressingList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current)
					{
						int count = this.IsPressingList.Count;
						for (int i = 0; i < count; i++)
						{
							this.IsPressingList[i] = false;
						}
						this.DelayExitBattleMode();
						return;
					}
				}
			}
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (curRoleData == null || !curRoleData.EntityHandle)
			{
				return;
			}
			if (this.IsAiming(curRoleData))
			{
				return;
			}
			this.IsInExploreMode = true;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleUiExploreModeChanged, true);
		}

		// Token: 0x0603D54E RID: 251214 RVA: 0x00F99298 File Offset: 0x00F97498
		private bool IsAiming(BattleUiRoleData curRoleData)
		{
			return curRoleData.EntityHandle.Entity.GetComponent<CharacterUnifiedStateComponent>().DirectionState == ECharDirectionState.AimDirection;
		}

		// Token: 0x0603D54F RID: 251215 RVA: 0x00F992B4 File Offset: 0x00F974B4
		private bool CheckInForbiddenDungeon()
		{
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			return instanceId != 0 && ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId).Value.InstSubType == 7;
		}

		// Token: 0x0603D550 RID: 251216 RVA: 0x00F992EF File Offset: 0x00F974EF
		private void DestroyTimer()
		{
			if (this.Timer != null)
			{
				TimerSystem.Instance.Remove(this.Timer);
				this.Timer = null;
			}
		}

		// Token: 0x040226EF RID: 141039
		private const int TIMER_INTERVAL = 1000;

		// Token: 0x040226F0 RID: 141040
		[StaticVariableRuleIgnore]
		private static readonly string[] ActionNames = new string[]
		{
			"攻击",
			"技能1",
			"幻象2",
			"瞄准",
			"大招"
		};

		// Token: 0x040226F1 RID: 141041
		private bool IsAutoSwitch = true;

		// Token: 0x040226F2 RID: 141042
		[Nullable(2)]
		private TimerHandle Timer;

		// Token: 0x040226F3 RID: 141043
		private bool IsInExploreMode;

		// Token: 0x040226F4 RID: 141044
		private bool IsInForbiddenDungeon;

		// Token: 0x040226F5 RID: 141045
		private readonly Dictionary<string, int> ActionNameMap = new Dictionary<string, int>();

		// Token: 0x040226F6 RID: 141046
		private readonly List<bool> IsPressingList = new List<bool>();

		// Token: 0x040226F7 RID: 141047
		private float OpenExploreModeTime;

		// Token: 0x040226F8 RID: 141048
		private float WaitingTime = 3000f;

		// Token: 0x040226F9 RID: 141049
		private bool IsGuiding;

		// Token: 0x040226FA RID: 141050
		private bool IsBossFight;
	}
}
