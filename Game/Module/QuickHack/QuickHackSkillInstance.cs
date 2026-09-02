using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052EC RID: 21228
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackSkillInstance
	{
		// Token: 0x06036332 RID: 222002 RVA: 0x00DA896C File Offset: 0x00DA6B6C
		public void Init(QuickHackSkill config)
		{
			this.Config = new QuickHackSkill?(config);
			int usageCount = config.UsageCount;
			if (usageCount > 0)
			{
				this.UsageCount = usageCount;
				this.AddCondition(EQuickHackSkillCondition.CheckUsageCountEnough, null, 0);
			}
			EQuickHackTargetType targetType = (EQuickHackTargetType)config.TargetType;
			if (targetType == EQuickHackTargetType.SceneItem)
			{
				this.AddCondition(EQuickHackSkillCondition.CheckAnySceneItemCanHack, null, 0);
			}
			this.AddCondition(EQuickHackSkillCondition.CheckTargetTypeMatch, null, 0);
			this.AddCondition(EQuickHackSkillCondition.CheckRamEnough, null, 0);
			string extraConditionType = config.ExtraConditionType;
			if (!StringUtils.IsBlank(extraConditionType))
			{
				this.AddCondition((EQuickHackSkillCondition)Enum.Parse(typeof(EQuickHackSkillCondition), extraConditionType), config.ExtraConditionParamsIter(), config.ExtraConditionParamsLength);
			}
			List<EQuickHackSkillCondition> targetExtraConditions = ModelBase<QuickHackModel>.Instance.ConditionHelper.GetTargetExtraConditions(targetType);
			if (targetExtraConditions != null)
			{
				foreach (EQuickHackSkillCondition key in targetExtraConditions)
				{
					QuickHackConditionInfo item;
					if (this.ConditionMap.TryGetValue(key, out item))
					{
						this.TargetConditionInfos.Add(item);
					}
				}
			}
		}

		// Token: 0x06036333 RID: 222003 RVA: 0x00DA8A70 File Offset: 0x00DA6C70
		private void AddCondition(EQuickHackSkillCondition type, [Nullable(new byte[]
		{
			2,
			1
		})] IEnumerable<string> extraParams = null, int paramsLength = 0)
		{
			if (this.ConditionMap.ContainsKey(type))
			{
				return;
			}
			QuickHackConditionInfo quickHackConditionInfo = new QuickHackConditionInfo(type, extraParams, paramsLength);
			this.ConditionMap[type] = quickHackConditionInfo;
			this.ConditionInfos.Add(quickHackConditionInfo);
		}

		// Token: 0x06036334 RID: 222004 RVA: 0x00DA8AAE File Offset: 0x00DA6CAE
		public void Clear()
		{
			this.OnCheckSkillCanUseSet.Clear();
			this.UnRegisterSkillCanUseListener();
		}

		// Token: 0x06036335 RID: 222005 RVA: 0x00DA8AC1 File Offset: 0x00DA6CC1
		public void RegisterSkillCanUseListener()
		{
			if (this.IsRegisterConditionListener)
			{
				return;
			}
			this.IsRegisterConditionListener = true;
			this.CheckSkillCanUse();
			ModelBase<QuickHackModel>.Instance.ConditionHelper.RegisterConditionsListener(this.ConditionMap.Keys, new GenericEventHandler(this.OnReceiveConditionEvent));
		}

		// Token: 0x06036336 RID: 222006 RVA: 0x00DA8AFF File Offset: 0x00DA6CFF
		public void UnRegisterSkillCanUseListener()
		{
			if (!this.IsRegisterConditionListener)
			{
				return;
			}
			this.IsRegisterConditionListener = false;
			ModelBase<QuickHackModel>.Instance.ConditionHelper.UnRegisterConditionsListener(this.ConditionMap.Keys, new GenericEventHandler(this.OnReceiveConditionEvent));
		}

		// Token: 0x06036337 RID: 222007 RVA: 0x00DA8B37 File Offset: 0x00DA6D37
		public QuickHackSkill GetConfig()
		{
			return this.Config.Value;
		}

		// Token: 0x06036338 RID: 222008 RVA: 0x00DA8B44 File Offset: 0x00DA6D44
		public int GetUsageCount()
		{
			return this.UsageCount;
		}

		// Token: 0x06036339 RID: 222009 RVA: 0x00DA8B4C File Offset: 0x00DA6D4C
		public void ReduceUsageCount()
		{
			if (this.UsageCount > 0)
			{
				this.UsageCount--;
				this.CheckSkillCanUse();
			}
		}

		// Token: 0x0603633A RID: 222010 RVA: 0x00DA8B6B File Offset: 0x00DA6D6B
		public QuickHackSkillConditionResult GetSkillCanUseInfo()
		{
			return this.CanUseResult;
		}

		// Token: 0x0603633B RID: 222011 RVA: 0x00DA8B74 File Offset: 0x00DA6D74
		public bool CheckTargetExtraConditions(EntityHandle target)
		{
			if (this.TargetConditionInfos.Count <= 0)
			{
				return true;
			}
			if (this.TargetArray != null)
			{
				this.TargetArray.Clear();
			}
			else
			{
				this.TargetArray = new List<EntityHandle>();
			}
			this.TargetArray.Add(target);
			return ModelBase<QuickHackModel>.Instance.ConditionHelper.CheckConditions(this.TargetConditionInfos, this, new EQuickHackTargetType?((EQuickHackTargetType)this.Config.Value.TargetType), this.TargetArray).IsSuccess;
		}

		// Token: 0x0603633C RID: 222012 RVA: 0x00DA8BF8 File Offset: 0x00DA6DF8
		public void CheckSkillCanUse()
		{
			QuickHackModel instance = ModelBase<QuickHackModel>.Instance;
			QuickHackTargetSelector targetSelector = instance.TargetSelector;
			IQuickHackLockTargetInfo quickHackLockTargetInfo = (targetSelector != null) ? targetSelector.GetLockTargetInfo() : null;
			this.CanUseResult = instance.ConditionHelper.CheckConditions(this.ConditionInfos, this, (quickHackLockTargetInfo != null) ? quickHackLockTargetInfo.HackType : null, (quickHackLockTargetInfo != null) ? quickHackLockTargetInfo.Targets : null);
			foreach (Action<QuickHackSkillConditionResult> action in this.OnCheckSkillCanUseSet)
			{
				action(this.CanUseResult);
			}
		}

		// Token: 0x0603633D RID: 222013 RVA: 0x00DA8CA0 File Offset: 0x00DA6EA0
		private void OnReceiveConditionEvent(params object[] args)
		{
			this.CheckSkillCanUse();
		}

		// Token: 0x0603633E RID: 222014 RVA: 0x00DA8CA8 File Offset: 0x00DA6EA8
		public void RegisterOnCheckSkillCanUse(Action<QuickHackSkillConditionResult> onCheckSkillCanUse)
		{
			this.OnCheckSkillCanUseSet.Add(onCheckSkillCanUse);
		}

		// Token: 0x0603633F RID: 222015 RVA: 0x00DA8CB7 File Offset: 0x00DA6EB7
		public void UnRegisterOnCheckSkillCanUse(Action<QuickHackSkillConditionResult> onCheckSkillCanUse)
		{
			this.OnCheckSkillCanUseSet.Remove(onCheckSkillCanUse);
		}

		// Token: 0x0401F2AB RID: 127659
		private QuickHackSkill? Config;

		// Token: 0x0401F2AC RID: 127660
		private readonly Dictionary<EQuickHackSkillCondition, QuickHackConditionInfo> ConditionMap = new Dictionary<EQuickHackSkillCondition, QuickHackConditionInfo>();

		// Token: 0x0401F2AD RID: 127661
		private readonly List<QuickHackConditionInfo> ConditionInfos = new List<QuickHackConditionInfo>();

		// Token: 0x0401F2AE RID: 127662
		private readonly List<QuickHackConditionInfo> TargetConditionInfos = new List<QuickHackConditionInfo>();

		// Token: 0x0401F2AF RID: 127663
		private int UsageCount = -1;

		// Token: 0x0401F2B0 RID: 127664
		[Nullable(2)]
		private QuickHackSkillConditionResult CanUseResult;

		// Token: 0x0401F2B1 RID: 127665
		private readonly HashSet<Action<QuickHackSkillConditionResult>> OnCheckSkillCanUseSet = new HashSet<Action<QuickHackSkillConditionResult>>();

		// Token: 0x0401F2B2 RID: 127666
		private bool IsRegisterConditionListener;

		// Token: 0x0401F2B3 RID: 127667
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<EntityHandle> TargetArray;
	}
}
