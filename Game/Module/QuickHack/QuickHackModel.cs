using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052EB RID: 21227
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class QuickHackModel : ModelBase<QuickHackModel>
	{
		// Token: 0x0603632D RID: 221997 RVA: 0x00DA86C6 File Offset: 0x00DA68C6
		protected override bool OnChangeMode()
		{
			QuickHackMarkManager markManager = this.MarkManager;
			if (markManager != null)
			{
				markManager.Clear();
			}
			this.MarkManager = null;
			return true;
		}

		// Token: 0x0603632E RID: 221998 RVA: 0x00DA86E1 File Offset: 0x00DA68E1
		protected override bool OnLeaveLevel()
		{
			QuickHackMarkManager markManager = this.MarkManager;
			if (markManager != null)
			{
				markManager.Clear();
			}
			this.MarkManager = null;
			return true;
		}

		// Token: 0x0603632F RID: 221999 RVA: 0x00DA86FC File Offset: 0x00DA68FC
		public void ClearQuickHack()
		{
			if (this.HighlightManagerList != null)
			{
				foreach (QuickHackHighlightManager quickHackHighlightManager in this.HighlightManagerList)
				{
					quickHackHighlightManager.Clear();
				}
				this.HighlightManagerList = null;
			}
			if (this.SkillInstanceMap != null)
			{
				foreach (QuickHackSkillInstance quickHackSkillInstance in this.SkillInstanceMap.Values)
				{
					quickHackSkillInstance.Clear();
				}
				this.SkillInstanceMap = null;
			}
			this.IsQuickHacking = false;
			this.DeviceConfig = null;
			this.CombatMessageId = 0L;
			this.UsedSkillIdList = null;
			QuickHackRamManager ramManager = this.RamManager;
			if (ramManager != null)
			{
				ramManager.Clear();
			}
			this.RamManager = null;
			QuickHackTargetSelector targetSelector = this.TargetSelector;
			if (targetSelector != null)
			{
				targetSelector.Clear();
			}
			this.TargetSelector = null;
			this.TimeScaleManager = null;
			this.ConditionHelper = null;
			this.CloseWhenInteractFinish = true;
			this.InteractFinishGameplayEventTag = null;
			this.OwnerEntityId = 0;
			this.IsInteractFinish = false;
			TimerHandle interactFinishTimer = this.InteractFinishTimer;
			if (interactFinishTimer != null)
			{
				interactFinishTimer.Remove();
			}
			this.InteractFinishTimer = null;
			this.DurationLimitTotalTime = 0.0;
			this.DurationLimitRemainTime = 0.0;
			this.DurationLimitStartTime = 0.0;
			TimerHandle durationLimitTimer = this.DurationLimitTimer;
			if (durationLimitTimer != null)
			{
				durationLimitTimer.Remove();
			}
			this.DurationLimitTimer = null;
			this.CurrentSelectSkill = null;
			this.CurrentLockOnEntityHandle = null;
			this.CurrentSkillList = null;
			this.EntityIdToDisableActorHandleMap = null;
			this.OnCloseQuickHack = null;
			this.PostProcessEffectHandle = 0;
			this.TargetBeenUsedSkillRecordMap = null;
		}

		// Token: 0x06036330 RID: 222000 RVA: 0x00DA88C0 File Offset: 0x00DA6AC0
		public void ClearCameraControl()
		{
			this.IsCameraControlling = false;
			this.CameraControlDeviceId = 0;
			this.CurrentCameraControlIndex = -1;
			this.CameraControlPbDataIdList = null;
			this.CameraControlMaxFov = 0f;
			this.CameraControlMinFov = 0f;
			this.CameraControlDefaultFov = 0f;
			this.CameraControlPitchMin = 0f;
			this.CameraControlPitchMax = 0f;
			this.CameraControlYawMin = 0f;
			this.CameraControlYawMax = 0f;
			this.CameraControlDefaultPitch = 0f;
			this.CameraControlDefaultYaw = 0f;
			this.CameraControlAutoOpenQuickHack = false;
		}

		// Token: 0x0401F282 RID: 127618
		public bool IsQuickHacking;

		// Token: 0x0401F283 RID: 127619
		public QuickHackDevice? DeviceConfig;

		// Token: 0x0401F284 RID: 127620
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, QuickHackSkillInstance> SkillInstanceMap;

		// Token: 0x0401F285 RID: 127621
		public QuickHackRamManager RamManager;

		// Token: 0x0401F286 RID: 127622
		public QuickHackTargetSelector TargetSelector;

		// Token: 0x0401F287 RID: 127623
		public QuickHackSkillConditionHelper ConditionHelper;

		// Token: 0x0401F288 RID: 127624
		public IQuickHackTimeScaleManager TimeScaleManager;

		// Token: 0x0401F289 RID: 127625
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<QuickHackHighlightManager> HighlightManagerList;

		// Token: 0x0401F28A RID: 127626
		public QuickHackMarkManager MarkManager;

		// Token: 0x0401F28B RID: 127627
		public Dictionary<int, int> EntityIdToDisableActorHandleMap;

		// Token: 0x0401F28C RID: 127628
		public long CombatMessageId;

		// Token: 0x0401F28D RID: 127629
		public List<int> UsedSkillIdList;

		// Token: 0x0401F28E RID: 127630
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, HashSet<int>> TargetBeenUsedSkillRecordMap;

		// Token: 0x0401F28F RID: 127631
		public Action OnCloseQuickHack;

		// Token: 0x0401F290 RID: 127632
		public bool CloseWhenInteractFinish = true;

		// Token: 0x0401F291 RID: 127633
		public FGameplayTag? InteractFinishGameplayEventTag;

		// Token: 0x0401F292 RID: 127634
		public int OwnerEntityId;

		// Token: 0x0401F293 RID: 127635
		public bool IsInteractFinish;

		// Token: 0x0401F294 RID: 127636
		public TimerHandle InteractFinishTimer;

		// Token: 0x0401F295 RID: 127637
		public double DurationLimitTotalTime;

		// Token: 0x0401F296 RID: 127638
		public double DurationLimitRemainTime;

		// Token: 0x0401F297 RID: 127639
		public double DurationLimitStartTime;

		// Token: 0x0401F298 RID: 127640
		public TimerHandle DurationLimitTimer;

		// Token: 0x0401F299 RID: 127641
		public EntityHandle CurrentLockOnEntityHandle;

		// Token: 0x0401F29A RID: 127642
		public QuickHackSkillInstance CurrentSelectSkill;

		// Token: 0x0401F29B RID: 127643
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<QuickHackSkillInstance> CurrentSkillList;

		// Token: 0x0401F29C RID: 127644
		public bool IsCameraControlling;

		// Token: 0x0401F29D RID: 127645
		public int CameraControlDeviceId;

		// Token: 0x0401F29E RID: 127646
		public int CurrentCameraControlIndex = -1;

		// Token: 0x0401F29F RID: 127647
		public List<int> CameraControlPbDataIdList;

		// Token: 0x0401F2A0 RID: 127648
		public float CameraControlMaxFov;

		// Token: 0x0401F2A1 RID: 127649
		public float CameraControlMinFov;

		// Token: 0x0401F2A2 RID: 127650
		public float CameraControlDefaultFov;

		// Token: 0x0401F2A3 RID: 127651
		public float CameraControlDefaultPitch;

		// Token: 0x0401F2A4 RID: 127652
		public float CameraControlPitchMin;

		// Token: 0x0401F2A5 RID: 127653
		public float CameraControlPitchMax;

		// Token: 0x0401F2A6 RID: 127654
		public float CameraControlDefaultYaw;

		// Token: 0x0401F2A7 RID: 127655
		public float CameraControlYawMin;

		// Token: 0x0401F2A8 RID: 127656
		public float CameraControlYawMax;

		// Token: 0x0401F2A9 RID: 127657
		public bool CameraControlAutoOpenQuickHack;

		// Token: 0x0401F2AA RID: 127658
		public int PostProcessEffectHandle;
	}
}
