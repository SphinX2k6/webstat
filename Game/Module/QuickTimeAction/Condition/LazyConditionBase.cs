using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.QuickTimeAction.Condition
{
	// Token: 0x020052C4 RID: 21188
	[NullableContext(1)]
	[Nullable(0)]
	public class LazyConditionBase
	{
		// Token: 0x0603629B RID: 221851 RVA: 0x00DA3F88 File Offset: 0x00DA2188
		public LazyConditionBase(TLazyConditionResultCallback callback)
		{
			if (callback == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HWR, "LazyCondition 缺少回调参数", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.ResultCallback = callback;
		}

		// Token: 0x0603629C RID: 221852 RVA: 0x00DA400F File Offset: 0x00DA220F
		public void SetParam(BaseTagComponent tagComp, BaseAttributeComponent attributeComp)
		{
			this.TagComp = tagComp;
			this.AttributeComp = attributeComp;
		}

		// Token: 0x0603629D RID: 221853 RVA: 0x00DA401F File Offset: 0x00DA221F
		[NullableContext(2)]
		public void SetParamWithEntity(Entity entity = null)
		{
			if (entity != null)
			{
				this.Entity = entity;
				this.TagComp = entity.GetComponent<BaseTagComponent>();
				this.AttributeComp = entity.GetComponent<BaseAttributeComponent>();
			}
		}

		// Token: 0x0603629E RID: 221854 RVA: 0x00DA4044 File Offset: 0x00DA2244
		[NullableContext(2)]
		public void SetCondition(CfgLazyConditionGroup inCondition = null, bool immediatelyCheck = true)
		{
			if (this.ResultCallback == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HWR, "LazyCondition 缺少回调", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.Clear();
			if (inCondition == null)
			{
				return;
			}
			this.ConditionFormula = inCondition.ConditionFormula;
			if (this.ConditionFormula == "" && inCondition.ConditionGroup.Count > 1)
			{
				this.ConditionFormula = "0";
				for (int i = 1; i < inCondition.ConditionGroup.Count; i++)
				{
					this.ConditionFormula = this.ConditionFormula + "||" + i.ToString();
				}
			}
			this.ConditionPayloadId = inCondition.PayloadId;
			foreach (CfgLazyConditionBase item in inCondition.ConditionGroup)
			{
				this.LazyConditionList.Add(item);
			}
			this.ConditionResultList.Clear();
			for (int j = 0; j < this.LazyConditionList.Count; j++)
			{
				this.ConditionResultList.Add(false);
			}
			int k = 0;
			while (k < this.LazyConditionList.Count)
			{
				LazyConditionBase.<>c__DisplayClass16_0 CS$<>8__locals1 = new LazyConditionBase.<>c__DisplayClass16_0();
				CS$<>8__locals1.<>4__this = this;
				CS$<>8__locals1.idx = k;
				CS$<>8__locals1.condition = this.LazyConditionList[k];
				if (CS$<>8__locals1.condition.ConditionType.GetValueOrDefault() != ELazyConditionType.标签检测)
				{
					goto IL_22F;
				}
				if (this.TagComp != null)
				{
					IEnumerable<int> tagIds = ((CfgLazyConditionForTag)CS$<>8__locals1.condition).TagToCheck;
					using (IEnumerator<int> enumerator2 = tagIds.GetEnumerator())
					{
						BaseTagComponent.TTagSwitchedCallback <>9__0;
						while (enumerator2.MoveNext())
						{
							int value = enumerator2.Current;
							BaseTagComponent tagComp = this.TagComp;
							int? tagId2 = new int?(value);
							BaseTagComponent.TTagSwitchedCallback callback;
							if ((callback = <>9__0) == null)
							{
								callback = (<>9__0 = delegate(int tagId, bool tagExists)
								{
									CS$<>8__locals1.<>4__this.ConditionTag(CS$<>8__locals1.idx, (CfgLazyConditionForTag)CS$<>8__locals1.condition, tagIds);
								});
							}
							ITagTask tagTask = tagComp.ListenForTagAddOrRemove(tagId2, callback, null);
							if (tagTask != null)
							{
								this.TagTaskList.Add(tagTask);
							}
						}
						goto IL_515;
					}
					goto IL_22F;
				}
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HWR, "LazyCondition 缺少TagComp", default(ReadOnlySpan<ValueTuple<string, object>>));
				IL_515:
				k++;
				continue;
				IL_22F:
				if (CS$<>8__locals1.condition.ConditionType.GetValueOrDefault() == ELazyConditionType.属性检测)
				{
					CfgLazyConditionForAttribute attributeCondition = (CfgLazyConditionForAttribute)CS$<>8__locals1.condition;
					if (this.AttributeComp == null)
					{
						Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HWR, "LazyCondition 缺少AttributeComp", default(ReadOnlySpan<ValueTuple<string, object>>));
						goto IL_515;
					}
					if (attributeCondition.AttributeId1 == 0)
					{
						Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HWR, "LazyCondition 属性1的id不能配0", default(ReadOnlySpan<ValueTuple<string, object>>));
						goto IL_515;
					}
					Action<EAttributeType, float, float> callback2 = delegate(EAttributeType attribute, float newValue, float oldValue)
					{
						CS$<>8__locals1.<>4__this.ConditionAttribute(CS$<>8__locals1.idx, attributeCondition);
					};
					this.AttributeComp.AddListener((EAttributeType)attributeCondition.AttributeId1, callback2, null);
					this.AttributeListenerHandles.Add(new AttributeListenerHandle(attributeCondition.AttributeId1, callback2));
					if (attributeCondition.AttributeId2 > 0)
					{
						this.AttributeComp.AddListener((EAttributeType)attributeCondition.AttributeId2, callback2, null);
						this.AttributeListenerHandles.Add(new AttributeListenerHandle(attributeCondition.AttributeId2, callback2));
						goto IL_515;
					}
					goto IL_515;
				}
				else if (CS$<>8__locals1.condition.ConditionType.GetValueOrDefault() == ELazyConditionType.输入检测)
				{
					CfgLazyConditionForInput inputCondition = (CfgLazyConditionForInput)CS$<>8__locals1.condition;
					if (string.IsNullOrEmpty(inputCondition.ActionName))
					{
						Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HWR, "LazyCondition 缺少ActionName", default(ReadOnlySpan<ValueTuple<string, object>>));
						goto IL_515;
					}
					TInputHandle<InputDistributeDefine.EActionType> tinputHandle = delegate(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification _)
					{
						CS$<>8__locals1.<>4__this.ConditionInput(CS$<>8__locals1.idx, inputCondition, new InputDistributeDefine.EActionType?(actionType));
					};
					ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit(inputCondition.ActionName, tinputHandle);
					this.InputListenerHandles.Add(new InputListenerHandle(inputCondition.ActionName, tinputHandle));
					goto IL_515;
				}
				else
				{
					if (CS$<>8__locals1.condition.ConditionType.GetValueOrDefault() != ELazyConditionType.事件变化)
					{
						goto IL_515;
					}
					CfgLazyConditionForEntityEvent cfgLazyConditionForEntityEvent = (CfgLazyConditionForEntityEvent)CS$<>8__locals1.condition;
					if (this.Entity == null)
					{
						Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HWR, "LazyCondition 缺少Entity", default(ReadOnlySpan<ValueTuple<string, object>>));
						goto IL_515;
					}
					if (this.EntityEventToIndexMap.ContainsKey(cfgLazyConditionForEntityEvent.EventName))
					{
						goto IL_515;
					}
					this.EntityEventToIndexMap[cfgLazyConditionForEntityEvent.EventName] = CS$<>8__locals1.idx;
					if (cfgLazyConditionForEntityEvent.EventName == ELazyConditionEventName.角色死亡)
					{
						Singleton<EventSystem>.Instance.AddWithTarget(this.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
						goto IL_515;
					}
					if (cfgLazyConditionForEntityEvent.EventName == ELazyConditionEventName.当前技能结束)
					{
						Singleton<EventSystem>.Instance.AddWithTarget<int, int>(this.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd));
						goto IL_515;
					}
					if (cfgLazyConditionForEntityEvent.EventName == ELazyConditionEventName.相机模式变更)
					{
						Singleton<EventSystem>.Instance.Add<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.OnCameraModeChanged));
						goto IL_515;
					}
					goto IL_515;
				}
			}
			if (immediatelyCheck)
			{
				this.ForceCheckOnce();
			}
		}

		// Token: 0x0603629F RID: 221855 RVA: 0x00DA45A4 File Offset: 0x00DA27A4
		public void ForceCheckOnce()
		{
			if (this.ResultCallback != null)
			{
				for (int i = 0; i < this.LazyConditionList.Count; i++)
				{
					CfgLazyConditionBase cfgLazyConditionBase = this.LazyConditionList[i];
					if (cfgLazyConditionBase.ConditionType.GetValueOrDefault() == ELazyConditionType.标签检测)
					{
						this.ConditionTag(i, (CfgLazyConditionForTag)cfgLazyConditionBase, ((CfgLazyConditionForTag)cfgLazyConditionBase).TagToCheck);
					}
					else if (cfgLazyConditionBase.ConditionType.GetValueOrDefault() == ELazyConditionType.属性检测)
					{
						this.ConditionAttribute(i, (CfgLazyConditionForAttribute)cfgLazyConditionBase);
					}
					else if (cfgLazyConditionBase.ConditionType.GetValueOrDefault() == ELazyConditionType.输入检测)
					{
						this.ConditionInput(i, (CfgLazyConditionForInput)cfgLazyConditionBase, null);
					}
				}
				this.ResultCallback(this.CurrentResult, this.ConditionPayloadId);
			}
		}

		// Token: 0x060362A0 RID: 221856 RVA: 0x00DA4664 File Offset: 0x00DA2864
		protected void ConditionTag(int index, CfgLazyConditionForTag condition, IEnumerable<int> tagIds)
		{
			bool flag = condition.AnyTag ? this.TagComp.HasAnyTag(tagIds) : this.TagComp.HasAllTag(tagIds);
			bool value = condition.Reverse ? (!flag) : flag;
			this.ConditionResultList[index] = value;
			this.UpdateResult();
		}

		// Token: 0x060362A1 RID: 221857 RVA: 0x00DA46B8 File Offset: 0x00DA28B8
		protected void ConditionAttribute(int index, CfgLazyConditionForAttribute condition)
		{
			float currentValue = this.AttributeComp.GetCurrentValue((EAttributeType)condition.AttributeId1);
			float num = (condition.AttributeId2 > 0) ? this.AttributeComp.GetCurrentValue((EAttributeType)condition.AttributeId2) : 0f;
			bool flag = SkillBehaviorMisc.Compare(condition.ComparisonLogic, currentValue, (float)condition.Value + num * (float)condition.AttributeRate * 0.0001f, (float)condition.RangeL, (float)condition.RangeR);
			bool value = condition.Reverse ? (!flag) : flag;
			this.ConditionResultList[index] = value;
			this.UpdateResult();
		}

		// Token: 0x060362A2 RID: 221858 RVA: 0x00DA4750 File Offset: 0x00DA2950
		protected void ConditionInput(int index, CfgLazyConditionForInput condition, InputDistributeDefine.EActionType? actionType)
		{
			bool flag = false;
			switch (condition.KeyMatchType)
			{
			case ELazyConditionKeyMatchType.按下按键:
			{
				InputDistributeDefine.EActionType? eactionType = actionType;
				InputDistributeDefine.EActionType eactionType2 = InputDistributeDefine.EActionType.Press;
				flag = (eactionType.GetValueOrDefault() == eactionType2 & eactionType != null);
				break;
			}
			case ELazyConditionKeyMatchType.抬起按键:
				flag = (actionType.GetValueOrDefault() == InputDistributeDefine.EActionType.Release);
				break;
			case ELazyConditionKeyMatchType.已按键:
			{
				InputDistributeModel instance = ModelBase<InputDistributeModel>.Instance;
				flag = (instance != null && instance.IsActionInPress(condition.ActionName));
				break;
			}
			case ELazyConditionKeyMatchType.没按键:
			{
				InputDistributeModel instance2 = ModelBase<InputDistributeModel>.Instance;
				flag = (instance2 == null || !instance2.IsActionInPress(condition.ActionName));
				break;
			}
			}
			bool value = condition.Reverse ? (!flag) : flag;
			this.ConditionResultList[index] = value;
			this.UpdateResult();
		}

		// Token: 0x060362A3 RID: 221859 RVA: 0x00DA4800 File Offset: 0x00DA2A00
		protected void ConditionCheckEvent(int index)
		{
			bool value = true;
			this.ConditionResultList[index] = value;
			this.UpdateResult();
		}

		// Token: 0x060362A4 RID: 221860 RVA: 0x00DA4822 File Offset: 0x00DA2A22
		private void OnRoleDead()
		{
			TLazyConditionResultCallback resultCallback = this.ResultCallback;
			if (resultCallback == null)
			{
				return;
			}
			resultCallback(false, this.ConditionPayloadId);
		}

		// Token: 0x060362A5 RID: 221861 RVA: 0x00DA483C File Offset: 0x00DA2A3C
		private void OnCharSkillEnd(int entityId, int skillId)
		{
			int index;
			if (this.EntityEventToIndexMap.TryGetValue(ELazyConditionEventName.当前技能结束, out index))
			{
				this.ConditionCheckEvent(index);
			}
		}

		// Token: 0x060362A6 RID: 221862 RVA: 0x00DA4860 File Offset: 0x00DA2A60
		private void OnCameraModeChanged(ECustomCameraMode newMode, ECustomCameraMode? oldMode, string cameraName)
		{
			if (cameraName != "MainCamera")
			{
				return;
			}
			int index;
			if (this.EntityEventToIndexMap.TryGetValue(ELazyConditionEventName.相机模式变更, out index))
			{
				this.ConditionCheckEvent(index);
			}
		}

		// Token: 0x060362A7 RID: 221863 RVA: 0x00DA4894 File Offset: 0x00DA2A94
		private bool CalcResult()
		{
			if (string.IsNullOrEmpty(this.ConditionFormula))
			{
				return this.ConditionResultList.Count > 0 && this.ConditionResultList[0];
			}
			if (this.BooleanListSolver == null)
			{
				try
				{
					ILogicalStructure structure = new Parser(this.ConditionFormula).Parse();
					this.BooleanListSolver = new ConditionArray(this.ConditionResultList.ToArray(), structure);
				}
				catch (Exception ex)
				{
					CombatLog instance = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag = CombatLog.EDebugModule.Control;
					BaseTagComponent tagComp = this.TagComp;
					Entity entity = (tagComp != null) ? tagComp.Entity : null;
					string message = "LazyConditionBase 激活条件公式解析异常";
					Exception e = ex;
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("formula", this.ConditionFormula);
					instance.ErrorWithStack(flag, entity, message, e, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return false;
				}
				return this.BooleanListSolver.Evaluate();
			}
			return this.BooleanListSolver.EvaluateByConditions(this.ConditionResultList.ToArray());
		}

		// Token: 0x060362A8 RID: 221864 RVA: 0x00DA4978 File Offset: 0x00DA2B78
		protected void UpdateResult()
		{
			bool flag = this.CalcResult();
			if (this.CurrentResult != flag)
			{
				this.CurrentResult = flag;
				TLazyConditionResultCallback resultCallback = this.ResultCallback;
				if (resultCallback == null)
				{
					return;
				}
				resultCallback(this.CurrentResult, this.ConditionPayloadId);
			}
		}

		// Token: 0x060362A9 RID: 221865 RVA: 0x00DA49B8 File Offset: 0x00DA2BB8
		public void Clear()
		{
			foreach (ITagTask tagTask in this.TagTaskList)
			{
				tagTask.EndTask();
			}
			this.TagTaskList.Clear();
			if (this.AttributeComp != null)
			{
				foreach (AttributeListenerHandle attributeListenerHandle in this.AttributeListenerHandles)
				{
					this.AttributeComp.RemoveListener((EAttributeType)attributeListenerHandle.Id, attributeListenerHandle.Callback);
				}
				this.AttributeListenerHandles.Clear();
			}
			foreach (InputListenerHandle inputListenerHandle in this.InputListenerHandles)
			{
				ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit(inputListenerHandle.ActionName, inputListenerHandle.Callback);
			}
			this.InputListenerHandles.Clear();
			if (this.Entity != null)
			{
				if (Singleton<EventSystem>.Instance.HasWithTarget(this.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(this.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
				}
				if (Singleton<EventSystem>.Instance.HasWithTarget(this.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(this.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd));
				}
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.OnCameraModeChanged)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.OnCameraModeChanged));
			}
			this.EntityEventToIndexMap.Clear();
			this.BooleanListSolver = null;
			this.LazyConditionList.Clear();
			this.ConditionResultList.Clear();
		}

		// Token: 0x0401F1DB RID: 127451
		[Nullable(2)]
		protected BaseTagComponent TagComp;

		// Token: 0x0401F1DC RID: 127452
		[Nullable(2)]
		protected BaseAttributeComponent AttributeComp;

		// Token: 0x0401F1DD RID: 127453
		[Nullable(2)]
		protected Entity Entity;

		// Token: 0x0401F1DE RID: 127454
		private readonly List<ITagTask> TagTaskList = new List<ITagTask>();

		// Token: 0x0401F1DF RID: 127455
		private readonly List<AttributeListenerHandle> AttributeListenerHandles = new List<AttributeListenerHandle>();

		// Token: 0x0401F1E0 RID: 127456
		private readonly List<InputListenerHandle> InputListenerHandles = new List<InputListenerHandle>();

		// Token: 0x0401F1E1 RID: 127457
		private readonly Dictionary<ELazyConditionEventName, int> EntityEventToIndexMap = new Dictionary<ELazyConditionEventName, int>();

		// Token: 0x0401F1E2 RID: 127458
		private readonly List<CfgLazyConditionBase> LazyConditionList = new List<CfgLazyConditionBase>();

		// Token: 0x0401F1E3 RID: 127459
		protected string ConditionFormula = string.Empty;

		// Token: 0x0401F1E4 RID: 127460
		protected int ConditionPayloadId;

		// Token: 0x0401F1E5 RID: 127461
		[Nullable(2)]
		private readonly TLazyConditionResultCallback ResultCallback;

		// Token: 0x0401F1E6 RID: 127462
		protected readonly List<bool> ConditionResultList = new List<bool>();

		// Token: 0x0401F1E7 RID: 127463
		protected bool CurrentResult;

		// Token: 0x0401F1E8 RID: 127464
		[Nullable(2)]
		protected ConditionArray BooleanListSolver;
	}
}
