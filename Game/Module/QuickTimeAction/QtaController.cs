using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Qte;
using AkiClient.Game.Aki.Data.QuickTimeAction;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.QuickTimeAction.Context;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickTimeAction
{
	// Token: 0x020052A3 RID: 21155
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class QtaController : ControllerBase<QtaController>
	{
		// Token: 0x060361A9 RID: 221609 RVA: 0x00D9FB3C File Offset: 0x00D9DD3C
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add<int?>(EEventName.CommonQteStart, new Action<int?>(this.OnCommonQteStart));
			Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
			return true;
		}

		// Token: 0x060361AA RID: 221610 RVA: 0x00D9FB77 File Offset: 0x00D9DD77
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.CommonQteStart, new Action<int?>(this.OnCommonQteStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
			return true;
		}

		// Token: 0x060361AB RID: 221611 RVA: 0x00D9FBB2 File Offset: 0x00D9DDB2
		protected override bool OnLeaveLevel()
		{
			this.ClearAll();
			return true;
		}

		// Token: 0x060361AC RID: 221612 RVA: 0x00D9FBBB File Offset: 0x00D9DDBB
		protected override bool OnChangeMode()
		{
			this.ClearAll();
			return true;
		}

		// Token: 0x060361AD RID: 221613 RVA: 0x00D9FBC4 File Offset: 0x00D9DDC4
		private void OnCommonQteStart(int? handleId)
		{
			if (this.IsInQta())
			{
				this.StopCurrentQta();
			}
		}

		// Token: 0x060361AE RID: 221614 RVA: 0x00D9FBD4 File Offset: 0x00D9DDD4
		[NullableContext(2)]
		private void OnTeleportComplete(TeleportContext _)
		{
			if (this.IsInQta())
			{
				QtaContextBase context = this.Context;
				if (context != null && context.IsActive())
				{
					QtaContextBase context2 = this.Context;
					if (context2 != null && context2.IsPending())
					{
						this.SetQtaTimeDilation(this.Context.Config.BaseConfig.TimeDilation);
					}
				}
			}
		}

		// Token: 0x060361AF RID: 221615 RVA: 0x00D9FC2C File Offset: 0x00D9DE2C
		public void RecoverTimeDilationAfterTeleport()
		{
			if (this.IsInQta())
			{
				QtaContextBase context = this.Context;
				if (context != null && context.IsActive())
				{
					QtaContextBase context2 = this.Context;
					if (context2 != null && context2.IsPending())
					{
						this.SetQtaTimeDilation(this.Context.Config.BaseConfig.TimeDilation);
					}
				}
			}
		}

		// Token: 0x060361B0 RID: 221616 RVA: 0x00D9FC84 File Offset: 0x00D9DE84
		private void ClearAll()
		{
			if (this.IsInQta())
			{
				this.ResetQtaTimeDilation();
			}
			this.ClearQta();
		}

		// Token: 0x060361B1 RID: 221617 RVA: 0x00D9FC9C File Offset: 0x00D9DE9C
		[NullableContext(2)]
		public QtaContextBase StartQta(int qtaId, TQtaCallback onResult = null, EQtaSource source = EQtaSource.Battle, IQtaExtraParams extraParams = null)
		{
			string text = null;
			if (this.IsInQta())
			{
				SQta qtaConfig = ModelBase<QtaModel>.Instance.GetQtaConfig(qtaId);
				int num = (qtaConfig != null) ? qtaConfig.Priority : 0;
				QtaContextBase context = this.Context;
				int num2 = (context != null) ? context.QtaPriority : 0;
				if (num > num2 && this.Context != null)
				{
					this.StopCurrentQta();
				}
				else if (num < num2 && this.Context != null)
				{
					text = "当前存在优先级更高的执行中的Qta, 无法开始新的Qta";
				}
				else
				{
					text = "当前存在执行中的Qta, 无法开始新的Qta";
				}
			}
			else if (this.IsPreloadingQta)
			{
				text = "Qta预加载中, 无法开始新的Qta";
			}
			if (!string.IsNullOrEmpty(text))
			{
				QtaLog.Info(this.Context, text, default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				SQta qtaConfig2 = ModelBase<QtaModel>.Instance.GetQtaConfig(qtaId);
				if (qtaConfig2 != null && qtaConfig2.AutonomousOnly)
				{
					CharacterActorComponent characterActorComponent;
					if (extraParams == null)
					{
						characterActorComponent = null;
					}
					else
					{
						EntityHandle entityHandle = extraParams.EntityHandle;
						if (entityHandle == null)
						{
							characterActorComponent = null;
						}
						else
						{
							WorldEntity entity = entityHandle.Entity;
							characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
						}
					}
					CharacterActorComponent characterActorComponent2 = characterActorComponent;
					if (characterActorComponent2 != null && !characterActorComponent2.IsMyRoleAndCtrlByMe())
					{
						QtaContextBase context2 = this.Context;
						string message = "Qta开始失败, 配置了仅主控端可执行";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("qtaId", qtaId);
						QtaLog.Info(context2, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return null;
					}
				}
			}
			BaseSkillComponent baseSkillComponent;
			if (extraParams == null)
			{
				baseSkillComponent = null;
			}
			else
			{
				EntityHandle entityHandle2 = extraParams.EntityHandle;
				if (entityHandle2 == null)
				{
					baseSkillComponent = null;
				}
				else
				{
					WorldEntity entity2 = entityHandle2.Entity;
					baseSkillComponent = ((entity2 != null) ? entity2.GetComponent<BaseSkillComponent>() : null);
				}
			}
			BaseSkillComponent baseSkillComponent2 = baseSkillComponent;
			if (baseSkillComponent2 != null)
			{
				if (extraParams.FromSkill != null)
				{
					int? fromSkill = extraParams.FromSkill;
					int num3 = 0;
					if (!(fromSkill.GetValueOrDefault() == num3 & fromSkill != null))
					{
						goto IL_195;
					}
				}
				Skill currentSkill = baseSkillComponent2.CurrentSkill;
				extraParams.FromSkill = new int?((currentSkill != null) ? currentSkill.SkillId : 0);
			}
			IL_195:
			QtaContextBase qtaContextBase = ModelBase<QtaModel>.Instance.CreateQtaContext(qtaId, onResult, source, extraParams);
			if (qtaContextBase == null)
			{
				return null;
			}
			if (this.StartQtaInternal(qtaContextBase))
			{
				return qtaContextBase;
			}
			return null;
		}

		// Token: 0x060361B2 RID: 221618 RVA: 0x00D9FE60 File Offset: 0x00D9E060
		private unsafe bool StartQtaInternal(QtaContextBase context)
		{
			QtaLog.Info(context, "Qta开始", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<QtaModel>.Instance.SetCurrentQta(context);
			int qtaId = context.QtaId;
			this.IsInQtaInner = true;
			this.Context = context;
			this.QtaPromptPlayer.SetQtaContext(context);
			string itemName = ModelBase<QtaModel>.Instance.GetQtaItemName(qtaId);
			SQta config = context.Config;
			if (config != null)
			{
				if (config.BaseConfig.IsBlockFightInput)
				{
					this.AddFightInputBlock(EUiViewName.QtaView);
				}
				this.QtaPromptPlayer.PlayEffect(EQtaPromptType.Qta开始, context.HandleId);
				this.QtaPromptPlayer.StartUiEffect(config.BaseConfig);
				this.SetQtaTimeDilation(config.BaseConfig.TimeDilation);
			}
			Singleton<InputManager>.Instance.PauseImmersiveMouseMode(EImmersiveMouseModeReason.Qta, true, true, false);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.QtaStart, this.Context.HandleId);
			int num = 1;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount<int>(list, num);
			Span<int> span = CollectionsMarshal.AsSpan<int>(list);
			int index = 0;
			*span[index] = qtaId;
			this.PreloadQtaRes(list, context.HandleId, false).ContinueWith(delegate(bool success)
			{
				bool flag;
				if (this.IsInQtaInner)
				{
					QtaContextBase context2 = this.Context;
					int? num2 = (context2 != null) ? new int?(context2.HandleId) : null;
					int handleId = context.HandleId;
					flag = (num2.GetValueOrDefault() == handleId & num2 != null);
				}
				else
				{
					flag = false;
				}
				bool flag2 = flag;
				if (!flag2)
				{
					QtaContextBase context3 = context;
					string message = "Qta预加载完成后, Qta已结束或已过期";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsInQta", this.IsInQtaInner);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isQtaValid", flag2);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("itemName", itemName ?? string.Empty);
					QtaLog.Info(context3, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					QtaItemBase valueOrDefault = this.QtaItemMap.GetValueOrDefault(qtaId);
					if (valueOrDefault != null && !valueOrDefault.IsDestroyOrDestroying)
					{
						valueOrDefault.Destroy(null);
					}
					this.QtaItemMap.Remove(qtaId);
					ModelBase<QtaModel>.Instance.ClearPreloadCache(new int?(qtaId));
					return;
				}
				if (success)
				{
					QtaItemBase valueOrDefault2 = this.QtaItemMap.GetValueOrDefault(qtaId);
					if (valueOrDefault2 != null)
					{
						context.Resource = ModelBase<QtaModel>.Instance.GetQtaPromptObj(qtaId);
						context.UiActor = valueOrDefault2.GetRootActor();
						context.OnResourceReady();
						valueOrDefault2.SetQtaContext(context);
						valueOrDefault2.PlayQtaStart();
						context.OnQtaReady();
						this.QtaPromptPlayer.PlayEffect(EQtaPromptType.Qta开始, context.HandleId);
						return;
					}
					if (context.IsQtaView())
					{
						context.Resource = ModelBase<QtaModel>.Instance.GetQtaPromptObj(qtaId);
						context.OnResourceReady();
						context.OnQtaReady();
						this.QtaPromptPlayer.PlayEffect(EQtaPromptType.Qta开始, context.HandleId);
						return;
					}
					if (context.IsNoUi())
					{
						context.Resource = ModelBase<QtaModel>.Instance.GetQtaPromptObj(qtaId);
						context.OnResourceReady();
						context.OnQtaReady();
						this.QtaPromptPlayer.PlayEffect(EQtaPromptType.Qta开始, context.HandleId);
						return;
					}
				}
				QtaContextBase context4 = context;
				string message2 = "Qta加载失败, 停止当前Qta";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("ItemName", itemName ?? string.Empty);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Success", success);
				QtaLog.Info(context4, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				this.OnQtaEnd(false);
			});
			return true;
		}

		// Token: 0x060361B3 RID: 221619 RVA: 0x00D9FFD8 File Offset: 0x00D9E1D8
		public void SetExpiredTimer(QtaContextBase context)
		{
			this.RemoveExpiredTimer();
			int currentValue = (int)Math.Floor((double)(context.IsPermanent ? 60000f : (context.Duration + 5000f)));
			this.ExpiredTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				if (context.IsSuccess())
				{
					context.SetQtaResult(EQtaResult.Fail);
					return;
				}
				this.OnQtaEnd(false);
			}, (float)Singleton<MathUtils>.Instance.Clamp(currentValue, 20, 180000), null, null, true, 1f);
		}

		// Token: 0x060361B4 RID: 221620 RVA: 0x00DA0064 File Offset: 0x00D9E264
		public void EnableExternalConditionMet(int qtaHandle, EQtaExternalReason reason)
		{
			QtaContextBase context = this.Context;
			int? num = (context != null) ? new int?(context.HandleId) : null;
			if (!(qtaHandle == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			QtaContextBase context2 = this.Context;
			if (context2 == null)
			{
				return;
			}
			context2.EnableExternalConditionMet(reason);
		}

		// Token: 0x060361B5 RID: 221621 RVA: 0x00DA00B8 File Offset: 0x00D9E2B8
		public void OnExternalConditionMet(int qtaHandle, EQtaExternalReason reason)
		{
			QtaContextBase context = this.Context;
			int? num = (context != null) ? new int?(context.HandleId) : null;
			if (!(qtaHandle == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			QtaContextBase context2 = this.Context;
			if (context2 == null)
			{
				return;
			}
			context2.OnExternalConditionMet(reason);
		}

		// Token: 0x060361B6 RID: 221622 RVA: 0x00DA010B File Offset: 0x00D9E30B
		public int GetCurrentQtaHandleId()
		{
			if (this.Context != null)
			{
				return this.Context.HandleId;
			}
			return -1;
		}

		// Token: 0x060361B7 RID: 221623 RVA: 0x00DA0124 File Offset: 0x00D9E324
		public void ResolveQta(int qtaHandle)
		{
			QtaContextBase context = this.Context;
			int? num = (context != null) ? new int?(context.HandleId) : null;
			if (!(qtaHandle == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			QtaContextBase context2 = this.Context;
			if (context2 != null)
			{
				context2.OnPreEndQta();
			}
			if (this.Context != null)
			{
				this.OnQtaEnd(false);
			}
		}

		// Token: 0x060361B8 RID: 221624 RVA: 0x00DA0188 File Offset: 0x00D9E388
		public void StopQta(int qtaHandle, bool ignoreResultAction = false)
		{
			QtaContextBase context = this.Context;
			int? num = (context != null) ? new int?(context.HandleId) : null;
			if (!(qtaHandle == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			this.OnQtaEnd(ignoreResultAction);
		}

		// Token: 0x060361B9 RID: 221625 RVA: 0x00DA01D1 File Offset: 0x00D9E3D1
		public void StopQtaByResult(EQtaResult result)
		{
			if (this.Context == null)
			{
				return;
			}
			this.Context.SetQtaResult(result);
			this.OnQtaEnd(false);
		}

		// Token: 0x060361BA RID: 221626 RVA: 0x00DA01EF File Offset: 0x00D9E3EF
		public void StopCurrentQta()
		{
			if (this.Context != null)
			{
				this.OnQtaEnd(false);
			}
		}

		// Token: 0x060361BB RID: 221627 RVA: 0x00DA0200 File Offset: 0x00D9E400
		private unsafe void OnQtaEnd(bool ignoreResultAction = false)
		{
			QtaContextBase context = this.Context;
			string message = "Qta结束";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ig", ignoreResultAction);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "state";
			QtaContextBase context2 = this.Context;
			ptr = new ValueTuple<string, object>(item, (context2 != null) ? new EQtaState?(context2.State) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item2 = "result";
			QtaContextBase context3 = this.Context;
			ptr2 = new ValueTuple<string, object>(item2, (context3 != null) ? new EQtaResult?(context3.ResultType) : null);
			ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
			string item3 = "pendingResult";
			QtaContextBase context4 = this.Context;
			ptr3 = new ValueTuple<string, object>(item3, (context4 != null) ? new EQtaResult?(context4.PendingResultType) : null);
			QtaLog.Info(context, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			this.ResetQtaTimeDilation();
			QtaContextBase context5 = this.Context;
			if (context5 != null && context5.QtaViewName != null)
			{
				EUiViewName value = this.Context.QtaViewName.Value;
				if (Singleton<UiManager>.Instance.IsViewShow(value))
				{
					Singleton<UiManager>.Instance.CloseView(value, null);
				}
			}
			QtaContextBase context6 = this.Context;
			SQta sqta = (context6 != null) ? context6.GetConfig() : null;
			if (sqta != null && sqta.HandleFailWhenInvalidStop && this.Context != null && !this.Context.IsEnd())
			{
				this.Context.ForceEnd();
			}
			if (sqta != null && sqta.EndSkillWhenDeactive)
			{
				QtaContextBase context7 = this.Context;
				if (context7 != null && context7.ResultType == EQtaResult.DeactiveConditionMet)
				{
					QtaContextBase context8 = this.Context;
					IQtaExtraParams qtaExtraParams = (context8 != null) ? context8.ExtraParams : null;
					int? num = (qtaExtraParams != null) ? qtaExtraParams.FromSkill : null;
					if (num != null && num.GetValueOrDefault() != 0)
					{
						EntityHandle entityHandle = qtaExtraParams.EntityHandle;
						if (entityHandle != null)
						{
							WorldEntity entity = entityHandle.Entity;
							if (entity != null)
							{
								BaseSkillComponent component = entity.GetComponent<BaseSkillComponent>();
								if (component != null)
								{
									component.EndSkill(qtaExtraParams.FromSkill.Value, "Qta:结束源技能, 原因是失活");
								}
							}
						}
					}
				}
			}
			if (sqta != null && this.Context.IsEnd() && !ignoreResultAction)
			{
				EQtaResult resultType = this.Context.ResultType;
				this.QtaPromptPlayer.PlayEffectByResult(resultType, this.Context.HandleId);
				IQtaExtraParams extraParams = this.Context.ExtraParams;
				SQta config = this.Context.Config;
				if (config != null && config.EndActiveSkill && ((extraParams != null) ? extraParams.FromSkill : null).GetValueOrDefault() != 0)
				{
					EntityHandle entityHandle2 = extraParams.EntityHandle;
					BaseSkillComponent baseSkillComponent;
					if (entityHandle2 == null)
					{
						baseSkillComponent = null;
					}
					else
					{
						WorldEntity entity2 = entityHandle2.Entity;
						baseSkillComponent = ((entity2 != null) ? entity2.GetComponent<BaseSkillComponent>() : null);
					}
					BaseSkillComponent baseSkillComponent2 = baseSkillComponent;
					if (baseSkillComponent2 != null)
					{
						baseSkillComponent2.EndSkill(extraParams.FromSkill.Value, "Qta:结束掉激活Qta时的技能");
					}
				}
				TArray<SBattleQteAction> resultActions = this.Context.GetResultActions(resultType);
				if (resultActions != null)
				{
					bool flag;
					if (extraParams == null)
					{
						flag = (null != null);
					}
					else
					{
						EntityHandle entityHandle3 = extraParams.EntityHandle;
						flag = (((entityHandle3 != null) ? entityHandle3.Entity : null) != null);
					}
					if (flag)
					{
						QtaContextBase context9 = this.Context;
						string message2 = "Qta结束动作";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ret", resultType);
						QtaLog.Info(context9, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
						defaultInterpolatedStringHandler.AppendLiteral("Qta结束时执行的动作 qtaId:");
						QtaContextBase context10 = this.Context;
						defaultInterpolatedStringHandler.AppendFormatted<int?>((context10 != null) ? new int?(context10.QtaId) : null);
						defaultInterpolatedStringHandler.AppendLiteral(" ret:");
						QtaContextBase context11 = this.Context;
						defaultInterpolatedStringHandler.AppendFormatted<EQtaResult?>((context11 != null) ? new EQtaResult?(context11.ResultType) : null);
						string tips = defaultInterpolatedStringHandler.ToStringAndClear();
						BattleQteContext.HandleActionTest(resultActions, extraParams.EntityHandle.Entity, extraParams.MessageId, tips);
					}
				}
			}
			QtaContextBase context12 = this.Context;
			Singleton<InputManager>.Instance.ResumeImmersiveMouseMode(EImmersiveMouseModeReason.Qta);
			ModelBase<QtaModel>.Instance.ClearQtaHandleId(null);
			this.ClearQta();
			Singleton<EventSystem>.Instance.Emit<int?>(EEventName.QtaEnd, (context12 != null) ? new int?(context12.HandleId) : null);
		}

		// Token: 0x060361BC RID: 221628 RVA: 0x00DA0644 File Offset: 0x00D9E844
		public void PauseQta(int handleId)
		{
			if (this.Context == null || handleId != this.Context.HandleId)
			{
				return;
			}
			if (this.ExpiredTimer != null && !this.ExpiredTimer.IsPause())
			{
				this.ExpiredTimer.Pause();
			}
		}

		// Token: 0x060361BD RID: 221629 RVA: 0x00DA0680 File Offset: 0x00D9E880
		public void ResumeQta(int handleId)
		{
			if (this.Context == null || handleId != this.Context.HandleId)
			{
				return;
			}
			if (this.ExpiredTimer != null && this.ExpiredTimer.IsPause())
			{
				this.ExpiredTimer.Resume();
			}
			this.SetQtaTimeDilation(this.Context.Config.BaseConfig.TimeDilation);
			this.ResumeFightInputBlock();
		}

		// Token: 0x060361BE RID: 221630 RVA: 0x00DA06E6 File Offset: 0x00D9E8E6
		public bool IsInQta()
		{
			return this.IsInQtaInner;
		}

		// Token: 0x060361BF RID: 221631 RVA: 0x00DA06EE File Offset: 0x00D9E8EE
		public bool IsPreloading()
		{
			return this.IsPreloadingQta;
		}

		// Token: 0x060361C0 RID: 221632 RVA: 0x00DA06F6 File Offset: 0x00D9E8F6
		public void PlayEffect(EQtaPromptType promptType, int qtaHandle)
		{
			this.QtaPromptPlayer.PlayEffect(promptType, qtaHandle);
		}

		// Token: 0x060361C1 RID: 221633 RVA: 0x00DA0705 File Offset: 0x00D9E905
		public void StopEffect(int qtaHandle)
		{
			this.QtaPromptPlayer.StopEffect(qtaHandle);
		}

		// Token: 0x060361C2 RID: 221634 RVA: 0x00DA0714 File Offset: 0x00D9E914
		public void OnQtaMoment(int handleId, EQtaMomentName moment)
		{
			if (this.Context == null || handleId != this.Context.HandleId)
			{
				return;
			}
			QtaItemBase valueOrDefault = this.QtaItemMap.GetValueOrDefault(this.Context.QtaId);
			if (valueOrDefault != null)
			{
				valueOrDefault.OnQtaMoment(moment);
			}
		}

		// Token: 0x060361C3 RID: 221635 RVA: 0x00DA075C File Offset: 0x00D9E95C
		public void ClearQta()
		{
			this.RemoveFightInputBlock();
			this.RemoveExpiredTimer();
			this.QtaPromptPlayer.RemoveEffect();
			this.IsInQtaInner = false;
			this.IsPreloadingQta = false;
			this.IsSetQtaTimeDilation = false;
			QtaContextBase context = this.Context;
			if (context != null)
			{
				context.Clear();
			}
			this.Context = null;
			this.ClearPreloadQtaRes();
		}

		// Token: 0x060361C4 RID: 221636 RVA: 0x00DA07B3 File Offset: 0x00D9E9B3
		private void RemoveExpiredTimer()
		{
			if (this.ExpiredTimer != null)
			{
				TimerSystem.Instance.Remove(this.ExpiredTimer);
			}
			this.ExpiredTimer = null;
		}

		// Token: 0x060361C5 RID: 221637 RVA: 0x00DA07D8 File Offset: 0x00D9E9D8
		public void SetQtaTimeDilation(float timeDilation)
		{
			if (!this.IsInQta())
			{
				return;
			}
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			if (instance != null && instance.IsMulti)
			{
				return;
			}
			if (timeDilation == 0f)
			{
				return;
			}
			TeleportModel instance2 = ModelBase<TeleportModel>.Instance;
			if (instance2 != null && instance2.IsTeleport)
			{
				return;
			}
			if (Singleton<Time>.Instance.TimeDilation != 0f)
			{
				this.IsSetQtaTimeDilation = true;
				ControllerBase<GameModeController>.Instance.SetTimeDilation(timeDilation, ETimeDilationType.Default);
			}
		}

		// Token: 0x060361C6 RID: 221638 RVA: 0x00DA0843 File Offset: 0x00D9EA43
		public void ResetQtaTimeDilation()
		{
			if (!this.IsSetQtaTimeDilation)
			{
				return;
			}
			this.IsSetQtaTimeDilation = false;
			ControllerBase<GameModeController>.Instance.SetTimeDilation(1f, ETimeDilationType.Default);
		}

		// Token: 0x060361C7 RID: 221639 RVA: 0x00DA0868 File Offset: 0x00D9EA68
		[NullableContext(0)]
		private UniTask<bool> PreloadQtaRes([Nullable(1)] List<int> qtaIdList, int preloadHandle = -1, bool isGroupQta = false)
		{
			QtaController.<PreloadQtaRes>d__41 <PreloadQtaRes>d__;
			<PreloadQtaRes>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PreloadQtaRes>d__.<>4__this = this;
			<PreloadQtaRes>d__.qtaIdList = qtaIdList;
			<PreloadQtaRes>d__.preloadHandle = preloadHandle;
			<PreloadQtaRes>d__.<>1__state = -1;
			<PreloadQtaRes>d__.<>t__builder.Start<QtaController.<PreloadQtaRes>d__41>(ref <PreloadQtaRes>d__);
			return <PreloadQtaRes>d__.<>t__builder.Task;
		}

		// Token: 0x060361C8 RID: 221640 RVA: 0x00DA08BC File Offset: 0x00D9EABC
		public void ClearPreloadQtaRes()
		{
			foreach (QtaItemBase qtaItemBase in this.QtaItemMap.Values)
			{
				if (!qtaItemBase.IsDestroyOrDestroying)
				{
					qtaItemBase.Destroy(null);
				}
			}
			this.QtaItemMap.Clear();
			ModelBase<QtaModel>.Instance.ClearPreloadCache(null);
		}

		// Token: 0x060361C9 RID: 221641 RVA: 0x00DA093C File Offset: 0x00D9EB3C
		private void AddFightInputBlock(EUiViewName viewName)
		{
			if (this.FightInputBlockViewName != null)
			{
				return;
			}
			this.FightInputBlockViewName = new EUiViewName?(viewName);
			InputDistributeModel instance = ModelBase<InputDistributeModel>.Instance;
			if (instance != null)
			{
				instance.PreventIgnoredActionRelease(true, viewName);
			}
			InputDistributeModel instance2 = ModelBase<InputDistributeModel>.Instance;
			if (instance2 != null)
			{
				instance2.AddNotAllowFightInputViewName(viewName);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAddNotAllowFightInputViewName);
		}

		// Token: 0x060361CA RID: 221642 RVA: 0x00DA099C File Offset: 0x00D9EB9C
		private void RemoveFightInputBlock()
		{
			if (this.FightInputBlockViewName == null)
			{
				return;
			}
			InputDistributeModel instance = ModelBase<InputDistributeModel>.Instance;
			if (instance != null)
			{
				instance.PreventIgnoredActionRelease(false, this.FightInputBlockViewName.Value);
			}
			InputDistributeModel instance2 = ModelBase<InputDistributeModel>.Instance;
			if (instance2 != null)
			{
				instance2.RemoveNotAllowFightInputViewName(this.FightInputBlockViewName.Value);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRemoveNotAllowFightInputViewName);
			this.FightInputBlockViewName = null;
		}

		// Token: 0x060361CB RID: 221643 RVA: 0x00DA0A10 File Offset: 0x00D9EC10
		private void ResumeFightInputBlock()
		{
			if (this.FightInputBlockViewName == null)
			{
				return;
			}
			InputDistributeModel instance = ModelBase<InputDistributeModel>.Instance;
			if (instance == null || !instance.HasNotAllowFightInputViewIsOpen(this.FightInputBlockViewName.Value))
			{
				InputDistributeModel instance2 = ModelBase<InputDistributeModel>.Instance;
				if (instance2 != null)
				{
					instance2.AddNotAllowFightInputViewName(this.FightInputBlockViewName.Value);
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.OnAddNotAllowFightInputViewName);
			}
		}

		// Token: 0x060361CC RID: 221644 RVA: 0x00DA0A77 File Offset: 0x00D9EC77
		public QtaController()
		{
			Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
			dictionary["UiItem_CircularLimitedLongPress"] = typeof(QtaCustomizationLimitedHoldItem);
			this.defQtaItemClasses = dictionary;
			this.QtaItemMap = new Dictionary<int, QtaItemBase>();
			this.QtaPromptPlayer = new QtaPromptPlayer();
			base..ctor();
		}

		// Token: 0x0401F148 RID: 127304
		private const int EXTRA_EXPIRED_TIME = 5000;

		// Token: 0x0401F149 RID: 127305
		private const int MAX_EXPIRED_TIME = 60000;

		// Token: 0x0401F14A RID: 127306
		private readonly Dictionary<string, Type> defQtaItemClasses;

		// Token: 0x0401F14B RID: 127307
		[Nullable(2)]
		private QtaContextBase Context;

		// Token: 0x0401F14C RID: 127308
		private bool IsInQtaInner;

		// Token: 0x0401F14D RID: 127309
		[Nullable(2)]
		private TimerHandle ExpiredTimer;

		// Token: 0x0401F14E RID: 127310
		private bool IsPreloadingQta;

		// Token: 0x0401F14F RID: 127311
		private readonly Dictionary<int, QtaItemBase> QtaItemMap;

		// Token: 0x0401F150 RID: 127312
		private EUiViewName? FightInputBlockViewName;

		// Token: 0x0401F151 RID: 127313
		private bool IsSetQtaTimeDilation;

		// Token: 0x0401F152 RID: 127314
		private readonly QtaPromptPlayer QtaPromptPlayer;
	}
}
