using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using AkiClient.Game.Aki.Data.QuickTimeAction;
using AkiClient.Game.Aki.Data.QuickTimeAction.Customization;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.QuickTimeAction.Condition;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickTimeAction.Context
{
	// Token: 0x020052C0 RID: 21184
	[NullableContext(2)]
	[Nullable(0)]
	public class QtaContextBase : IQtaContext, IUiProhibitRefreshData
	{
		// Token: 0x17008CFA RID: 36090
		// (get) Token: 0x06036258 RID: 221784 RVA: 0x00DA3485 File Offset: 0x00DA1685
		// (set) Token: 0x06036259 RID: 221785 RVA: 0x00DA348D File Offset: 0x00DA168D
		public int HandleId { get; set; } = -1;

		// Token: 0x17008CFB RID: 36091
		// (get) Token: 0x0603625A RID: 221786 RVA: 0x00DA3496 File Offset: 0x00DA1696
		// (set) Token: 0x0603625B RID: 221787 RVA: 0x00DA349E File Offset: 0x00DA169E
		public int QtaId { get; set; }

		// Token: 0x17008CFC RID: 36092
		// (get) Token: 0x0603625C RID: 221788 RVA: 0x00DA34A7 File Offset: 0x00DA16A7
		public EQtaState State
		{
			get
			{
				return this.StateInner;
			}
		}

		// Token: 0x17008CFD RID: 36093
		// (get) Token: 0x0603625D RID: 221789 RVA: 0x00DA34AF File Offset: 0x00DA16AF
		public EQtaResult ResultType
		{
			get
			{
				if (!this.IsEnd())
				{
					return EQtaResult.None;
				}
				return this.ResultTypeInner;
			}
		}

		// Token: 0x17008CFE RID: 36094
		// (get) Token: 0x0603625E RID: 221790 RVA: 0x00DA34C1 File Offset: 0x00DA16C1
		public EQtaResult PendingResultType
		{
			get
			{
				return this.ResultTypeInner;
			}
		}

		// Token: 0x0603625F RID: 221791 RVA: 0x00DA34C9 File Offset: 0x00DA16C9
		public bool IsInvalid()
		{
			return this.StateInner == EQtaState.Invalid;
		}

		// Token: 0x06036260 RID: 221792 RVA: 0x00DA34D4 File Offset: 0x00DA16D4
		public bool IsPending()
		{
			return this.StateInner == EQtaState.Pending;
		}

		// Token: 0x06036261 RID: 221793 RVA: 0x00DA34DF File Offset: 0x00DA16DF
		public bool IsPendingSuccess()
		{
			return this.StateInner == EQtaState.PendingSuccess;
		}

		// Token: 0x06036262 RID: 221794 RVA: 0x00DA34EA File Offset: 0x00DA16EA
		public bool IsEnd()
		{
			return this.StateInner == EQtaState.Ended;
		}

		// Token: 0x06036263 RID: 221795 RVA: 0x00DA34F5 File Offset: 0x00DA16F5
		public bool HasResult()
		{
			return this.ResultTypeInner > EQtaResult.None;
		}

		// Token: 0x06036264 RID: 221796 RVA: 0x00DA3500 File Offset: 0x00DA1700
		public bool IsSuccess()
		{
			return this.IsEnd() && this.ResultTypeInner == EQtaResult.Success;
		}

		// Token: 0x06036265 RID: 221797 RVA: 0x00DA3515 File Offset: 0x00DA1715
		public bool IsFail()
		{
			return this.IsEnd() && this.ResultTypeInner != EQtaResult.Success;
		}

		// Token: 0x06036266 RID: 221798 RVA: 0x00DA3530 File Offset: 0x00DA1730
		public bool IsActive()
		{
			int qtaHandleId = ModelBase<QtaModel>.Instance.GetQtaHandleId();
			return this.HandleId == qtaHandleId;
		}

		// Token: 0x06036267 RID: 221799 RVA: 0x00DA3554 File Offset: 0x00DA1754
		[NullableContext(1)]
		public void SetConfig(SQta config)
		{
			this.Config = config;
			this.QtaPriority = config.Priority;
			if (config.BaseConfig.Duration < 0f)
			{
				this.IsPermanent = true;
			}
			else
			{
				this.Duration = config.BaseConfig.Duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			}
			this.LeastDuration = config.BaseConfig.LeastDuration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			if (config.DeactiveCondition.Contents.Num() > 0)
			{
				this.LazyCondition = new LazyConditionQta(new TLazyConditionResultCallback(this.OnConditionResultCallback));
				LazyConditionBase lazyCondition = this.LazyCondition;
				IQtaExtraParams extraParams = this.ExtraParams;
				Entity paramWithEntity;
				if (extraParams == null)
				{
					paramWithEntity = null;
				}
				else
				{
					EntityHandle entityHandle = extraParams.EntityHandle;
					paramWithEntity = ((entityHandle != null) ? entityHandle.Entity : null);
				}
				lazyCondition.SetParamWithEntity(paramWithEntity);
				this.LazyCondition.SetQtaCondition(config.DeactiveCondition, config, 1, false);
			}
			this.ApplyTagsToEntity(true);
			this.SetUiProhibitRefresh(true);
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			this.OnSetConfig(config);
			this.NeedStopWhenFightInputBlocked = config.StopWhenFightInputBlocked;
			if (this.NeedStopWhenFightInputBlocked)
			{
				Singleton<EventSystem>.Instance.Add<IReadOnlyList<InputDistributeTag>>(EEventName.OnInputDistributeTagChanged, new Action<IReadOnlyList<InputDistributeTag>>(this.OnInputDistributeTagChanged));
			}
		}

		// Token: 0x06036268 RID: 221800 RVA: 0x00DA367F File Offset: 0x00DA187F
		private void OnConditionResultCallback(bool met, int payloadId)
		{
			if (this.IsEnd())
			{
				return;
			}
			if (met && payloadId == 1)
			{
				this.SetQtaResult(EQtaResult.DeactiveConditionMet);
			}
		}

		// Token: 0x06036269 RID: 221801 RVA: 0x00DA3698 File Offset: 0x00DA1898
		private void ApplyTagsToEntity(bool add)
		{
			IQtaExtraParams extraParams = this.ExtraParams;
			BaseTagComponent baseTagComponent;
			if (extraParams == null)
			{
				baseTagComponent = null;
			}
			else
			{
				EntityHandle entityHandle = extraParams.EntityHandle;
				if (entityHandle == null)
				{
					baseTagComponent = null;
				}
				else
				{
					WorldEntity entity = entityHandle.Entity;
					baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
				}
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if (baseTagComponent2 == null)
			{
				return;
			}
			if (this.AppliedTagIds.Count > 0)
			{
				for (int i = this.AppliedTagIds.Count - 1; i >= 0; i--)
				{
					baseTagComponent2.RemoveTag(new int?(this.AppliedTagIds[i]));
				}
				this.AppliedTagIds.Clear();
			}
			if (add)
			{
				if (this.Config == null)
				{
					return;
				}
				TArray<FGameplayTag> gameplayTags = this.Config.BaseConfig.ActiveTags.GameplayTags;
				if (gameplayTags.Num() > 0)
				{
					for (int j = 0; j < gameplayTags.Num(); j++)
					{
						FGameplayTag tag = gameplayTags.Get(j);
						this.AppliedTagIds.Add(tag.TagId());
						baseTagComponent2.AddTag(new int?(tag.TagId()));
					}
				}
			}
		}

		// Token: 0x0603626A RID: 221802 RVA: 0x00DA378C File Offset: 0x00DA198C
		[NullableContext(1)]
		protected virtual void OnSetConfig(SQta config)
		{
		}

		// Token: 0x0603626B RID: 221803 RVA: 0x00DA378E File Offset: 0x00DA198E
		public virtual void OnResourceReady()
		{
		}

		// Token: 0x0603626C RID: 221804 RVA: 0x00DA3790 File Offset: 0x00DA1990
		public virtual void OnQtaReady()
		{
			LazyConditionQta lazyCondition = this.LazyCondition;
			if (lazyCondition != null)
			{
				lazyCondition.ForceCheckOnce();
			}
			if (!this.IsEnd() && this.NeedStopWhenFightInputBlocked && this.HasOtherNotAllowFightInputView())
			{
				this.SetQtaFailWhenFightInputBlocked();
			}
		}

		// Token: 0x0603626D RID: 221805 RVA: 0x00DA37C1 File Offset: 0x00DA19C1
		public SQta GetConfig()
		{
			return this.Config;
		}

		// Token: 0x0603626E RID: 221806 RVA: 0x00DA37CC File Offset: 0x00DA19CC
		public bool IsNoUi()
		{
			SQta config = this.Config;
			SQtaBase sqtaBase = (config != null) ? config.BaseConfig : null;
			return sqtaBase != null && sqtaBase.QtaType == EQtaType.定制型 && sqtaBase.CustomizationConfig.ViewType == EQtaCustomizationViewType.无界面;
		}

		// Token: 0x0603626F RID: 221807 RVA: 0x00DA3824 File Offset: 0x00DA1A24
		public bool IsQtaView()
		{
			SQta config = this.Config;
			SQtaBase sqtaBase = (config != null) ? config.BaseConfig : null;
			return sqtaBase != null && sqtaBase.QtaType == EQtaType.定制型 && (sqtaBase.CustomizationConfig.ViewType == EQtaCustomizationViewType.拍照并收集物品 || sqtaBase.CustomizationConfig.ViewType == EQtaCustomizationViewType.打开指定界面);
		}

		// Token: 0x06036270 RID: 221808 RVA: 0x00DA3893 File Offset: 0x00DA1A93
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> GetActions()
		{
			return this.OnGetActions();
		}

		// Token: 0x06036271 RID: 221809 RVA: 0x00DA389B File Offset: 0x00DA1A9B
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		protected virtual List<string> OnGetActions()
		{
			return null;
		}

		// Token: 0x06036272 RID: 221810 RVA: 0x00DA389E File Offset: 0x00DA1A9E
		public IQtaPromptResource GetPromptResource(EQtaPromptType promptType)
		{
			return ModelBase<QtaModel>.Instance.GetQtaPromptResource(this.QtaId, promptType, false);
		}

		// Token: 0x06036273 RID: 221811 RVA: 0x00DA38B4 File Offset: 0x00DA1AB4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public TArray<SBattleQteAction> GetResultActions(EQtaResult resultType)
		{
			if (this.Config == null)
			{
				return null;
			}
			for (int i = 0; i < this.Config.ResultAction.Num(); i++)
			{
				SQtaResultAction sqtaResultAction = this.Config.ResultAction.Get(i);
				if ((EQtaResult)sqtaResultAction.ResultType == resultType)
				{
					return sqtaResultAction.Actions;
				}
			}
			return null;
		}

		// Token: 0x06036274 RID: 221812 RVA: 0x00DA3914 File Offset: 0x00DA1B14
		public virtual void UpdateTime(float delta)
		{
			if (this.StateInner == EQtaState.PendingSuccess)
			{
				if (this.PassTime > this.LeastDuration)
				{
					this.SetQtaResult(EQtaResult.Success);
				}
				return;
			}
			this.OnUpdateTime(delta);
		}

		// Token: 0x06036275 RID: 221813 RVA: 0x00DA393C File Offset: 0x00DA1B3C
		protected virtual void OnUpdateTime(float delta)
		{
		}

		// Token: 0x06036276 RID: 221814 RVA: 0x00DA393E File Offset: 0x00DA1B3E
		public void QtaResponse(bool press)
		{
			this.OnQtaResponse(press);
		}

		// Token: 0x06036277 RID: 221815 RVA: 0x00DA3947 File Offset: 0x00DA1B47
		protected virtual void OnQtaResponse(bool press)
		{
		}

		// Token: 0x06036278 RID: 221816 RVA: 0x00DA394C File Offset: 0x00DA1B4C
		public void SetQtaResult(EQtaResult qtaResult)
		{
			if (this.IsEnd())
			{
				return;
			}
			if (this.IsStoppingByFightInputBlocked)
			{
				this.StateInner = EQtaState.Ended;
				this.ResultTypeInner = qtaResult;
			}
			else if (this.IsPendingExternalCompletion)
			{
				if (this.StateInner == EQtaState.PendingEnd)
				{
					return;
				}
				this.StateInner = EQtaState.PendingEnd;
				this.ResultTypeInner = qtaResult;
				return;
			}
			else if (qtaResult == EQtaResult.Success && this.PassTime < this.LeastDuration)
			{
				this.StateInner = EQtaState.PendingSuccess;
				this.ResultTypeInner = qtaResult;
				this.OnQtaPendingSuccess();
				return;
			}
			this.StateInner = EQtaState.Ended;
			this.ResultTypeInner = qtaResult;
			this.OnQtaResult(qtaResult);
			TQtaCallback resultCallback = this.ResultCallback;
			if (resultCallback != null)
			{
				resultCallback(this, qtaResult);
			}
			this.ResultCallback = null;
			ControllerBase<QtaController>.Instance.StopQta(this.HandleId, false);
		}

		// Token: 0x06036279 RID: 221817 RVA: 0x00DA3A02 File Offset: 0x00DA1C02
		public void ForceEnd()
		{
			this.StateInner = EQtaState.Ended;
			this.ResultTypeInner = EQtaResult.Fail;
		}

		// Token: 0x0603627A RID: 221818 RVA: 0x00DA3A12 File Offset: 0x00DA1C12
		protected virtual void OnQtaPendingSuccess()
		{
		}

		// Token: 0x0603627B RID: 221819 RVA: 0x00DA3A14 File Offset: 0x00DA1C14
		protected virtual void OnQtaResult(EQtaResult qtaResult)
		{
		}

		// Token: 0x0603627C RID: 221820 RVA: 0x00DA3A16 File Offset: 0x00DA1C16
		protected virtual bool CheckQtaCanEnd()
		{
			return false;
		}

		// Token: 0x0603627D RID: 221821 RVA: 0x00DA3A1C File Offset: 0x00DA1C1C
		public void EnableExternalConditionMet(EQtaExternalReason reason)
		{
			string message = "启用等待外部条件达成";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
			QtaLog.Info(this, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.IsPendingExternalCompletion = true;
		}

		// Token: 0x0603627E RID: 221822 RVA: 0x00DA3A54 File Offset: 0x00DA1C54
		public void OnExternalConditionMet(EQtaExternalReason reason)
		{
			string message = "外部条件已达成";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
			QtaLog.Info(this, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.IsPendingExternalCompletion = false;
			if (this.PendingResultType != EQtaResult.None)
			{
				this.SetQtaResult(this.PendingResultType);
			}
		}

		// Token: 0x0603627F RID: 221823 RVA: 0x00DA3AA0 File Offset: 0x00DA1CA0
		public virtual void OnPreEndQta()
		{
		}

		// Token: 0x06036280 RID: 221824 RVA: 0x00DA3AA2 File Offset: 0x00DA1CA2
		public float GetRemainingTime()
		{
			return Math.Max(0f, this.Duration - this.PassTime);
		}

		// Token: 0x06036281 RID: 221825 RVA: 0x00DA3ABB File Offset: 0x00DA1CBB
		public float GetRemainingTimeProgress()
		{
			if (this.Duration <= 0f)
			{
				return 1f;
			}
			return this.GetRemainingTime() / this.Duration;
		}

		// Token: 0x06036282 RID: 221826 RVA: 0x00DA3ADD File Offset: 0x00DA1CDD
		public virtual float GetProgress()
		{
			return 0f;
		}

		// Token: 0x06036283 RID: 221827 RVA: 0x00DA3AE4 File Offset: 0x00DA1CE4
		private void SetUiProhibitRefresh(bool reg)
		{
			SQta config = this.Config;
			if (config != null && !config.BaseConfig.EnableInputDistributeFilter)
			{
				return;
			}
			if (this.InputDistributeFilterTags.Length == 0)
			{
				List<string> list = new List<string>();
				SQtaInputDistribute inputDistributeFilterConfig = this.Config.BaseConfig.InputDistributeFilterConfig;
				if (inputDistributeFilterConfig.FightInputRoot)
				{
					list.Add("FightInputRoot");
				}
				if (inputDistributeFilterConfig.FightActionInput)
				{
					list.Add("FightInputRoot.FightInput.ActionInput");
				}
				if (inputDistributeFilterConfig.FightAxisInput)
				{
					list.Add("FightInputRoot.FightInput.AxisInput");
				}
				if (inputDistributeFilterConfig.InteractionRoot)
				{
					list.Add("InteractionRoot");
				}
				if (inputDistributeFilterConfig.UiInputRoot)
				{
					list.Add("UiInputRoot");
				}
				this.InputDistributeFilterTags = list.ToArray();
			}
			if (reg)
			{
				Singleton<UiProhibitFightInputCenter>.Instance.RegisterExtraRefreshData(EUiViewName.QtaView, this);
				return;
			}
			Singleton<UiProhibitFightInputCenter>.Instance.UnRegisterExtraRefreshData(EUiViewName.QtaView);
		}

		// Token: 0x06036284 RID: 221828 RVA: 0x00DA3BC7 File Offset: 0x00DA1DC7
		public bool CheckCondition()
		{
			return true;
		}

		// Token: 0x06036285 RID: 221829 RVA: 0x00DA3BCA File Offset: 0x00DA1DCA
		[NullableContext(1)]
		public string[] GetDistributeTags()
		{
			return this.InputDistributeFilterTags;
		}

		// Token: 0x06036286 RID: 221830 RVA: 0x00DA3BD4 File Offset: 0x00DA1DD4
		public void Clear()
		{
			if (Singleton<EventSystem>.Instance.Has<IReadOnlyList<InputDistributeTag>>(EEventName.OnInputDistributeTagChanged, new Action<IReadOnlyList<InputDistributeTag>>(this.OnInputDistributeTagChanged)))
			{
				Singleton<EventSystem>.Instance.Remove<IReadOnlyList<InputDistributeTag>>(EEventName.OnInputDistributeTagChanged, new Action<IReadOnlyList<InputDistributeTag>>(this.OnInputDistributeTagChanged));
			}
			this.SetUiProhibitRefresh(false);
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			if (this.IsPending())
			{
				this.StateInner = EQtaState.Invalid;
			}
			this.ApplyTagsToEntity(false);
			LazyConditionQta lazyCondition = this.LazyCondition;
			if (lazyCondition != null)
			{
				lazyCondition.Clear();
			}
			this.ResultCallback = null;
			this.Resource = null;
			this.UiActor = null;
			this.InputDistributeFilterTags = Array.Empty<string>();
			this.OnClear();
		}

		// Token: 0x06036287 RID: 221831 RVA: 0x00DA3C78 File Offset: 0x00DA1E78
		protected virtual void OnClear()
		{
		}

		// Token: 0x06036288 RID: 221832 RVA: 0x00DA3C7A File Offset: 0x00DA1E7A
		[NullableContext(1)]
		private void OnInputDistributeTagChanged(IReadOnlyList<InputDistributeTag> inputDistributeTags)
		{
			if (this.HasOtherNotAllowFightInputView())
			{
				this.SetQtaFailWhenFightInputBlocked();
			}
		}

		// Token: 0x06036289 RID: 221833 RVA: 0x00DA3C8C File Offset: 0x00DA1E8C
		private bool HasOtherNotAllowFightInputView()
		{
			HashSet<EUiViewName> notAllowFightInputViewNameSet = ModelBase<InputDistributeModel>.Instance.GetNotAllowFightInputViewNameSet();
			if (notAllowFightInputViewNameSet.Contains(EUiViewName.QtaView))
			{
				if (notAllowFightInputViewNameSet.Count > 1)
				{
					return true;
				}
			}
			else if (notAllowFightInputViewNameSet.Count > 0)
			{
				return true;
			}
			return false;
		}

		// Token: 0x0603628A RID: 221834 RVA: 0x00DA3CC8 File Offset: 0x00DA1EC8
		private void SetQtaFailWhenFightInputBlocked()
		{
			if (this.IsStoppingByFightInputBlocked)
			{
				return;
			}
			this.IsStoppingByFightInputBlocked = true;
			TimerSystem.GameplayTimeInstance.Next(delegate(float _)
			{
				if (this.IsActive())
				{
					this.SetQtaResult(EQtaResult.Fail);
				}
			}, null, null);
		}

		// Token: 0x0401F1BD RID: 127421
		public EQtaContextType? Type;

		// Token: 0x0401F1C0 RID: 127424
		public int QtaPriority;

		// Token: 0x0401F1C1 RID: 127425
		public SQta Config;

		// Token: 0x0401F1C2 RID: 127426
		protected EQtaState StateInner;

		// Token: 0x0401F1C3 RID: 127427
		protected EQtaResult ResultTypeInner;

		// Token: 0x0401F1C4 RID: 127428
		public IQtaExtraParams ExtraParams;

		// Token: 0x0401F1C5 RID: 127429
		public TQtaCallback ResultCallback;

		// Token: 0x0401F1C6 RID: 127430
		public EQtaSource? Source;

		// Token: 0x0401F1C7 RID: 127431
		public float Duration;

		// Token: 0x0401F1C8 RID: 127432
		public float LeastDuration;

		// Token: 0x0401F1C9 RID: 127433
		public float PassTime;

		// Token: 0x0401F1CA RID: 127434
		public bool IsPermanent;

		// Token: 0x0401F1CB RID: 127435
		private bool IsPendingExternalCompletion;

		// Token: 0x0401F1CC RID: 127436
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, IQtaPromptResource> Resource;

		// Token: 0x0401F1CD RID: 127437
		public AActor UiActor;

		// Token: 0x0401F1CE RID: 127438
		public EUiViewName? QtaViewName;

		// Token: 0x0401F1CF RID: 127439
		private bool NeedStopWhenFightInputBlocked;

		// Token: 0x0401F1D0 RID: 127440
		private bool IsStoppingByFightInputBlocked;

		// Token: 0x0401F1D1 RID: 127441
		private LazyConditionQta LazyCondition;

		// Token: 0x0401F1D2 RID: 127442
		[Nullable(1)]
		private List<int> AppliedTagIds = new List<int>();

		// Token: 0x0401F1D3 RID: 127443
		[Nullable(1)]
		private string[] InputDistributeFilterTags = Array.Empty<string>();
	}
}
