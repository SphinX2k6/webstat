using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using AkiClient.Game.Aki.Data.QuickTimeAction;
using AkiClient.Game.Aki.Data.QuickTimeAction.Customization;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickTimeAction.Context
{
	// Token: 0x020052BA RID: 21178
	[NullableContext(1)]
	[Nullable(0)]
	public class QtaCustomizationNull : QtaCustomizationBaseLogic
	{
		// Token: 0x06036238 RID: 221752 RVA: 0x00DA2B60 File Offset: 0x00DA0D60
		public override void OnSetConfig(QtaCustomizationContext qtaContext, SQta qtaConfig, BP_QtaCustomizationBase_C daConfig)
		{
			if (qtaConfig == null || daConfig == null)
			{
				QtaLog.Error(qtaContext, "占位用Qta初始化：缺少配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<QtaController>.Instance.StopCurrentQta();
				return;
			}
			if (daConfig == null)
			{
				QtaLog.Error(qtaContext, "占位用Qta初始化：配置的DA类型不正确", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<QtaController>.Instance.StopCurrentQta();
				return;
			}
			this.QtaConfig = qtaConfig;
			this.QtaContext = qtaContext;
			this.Actions.Clear();
			for (int i = 0; i < qtaConfig.BaseConfig.InputConfig.Num(); i++)
			{
				SCommonQteButton scommonQteButton = qtaConfig.BaseConfig.InputConfig.Get(i);
				TEnumAsByte<ECommonQteInputAction>? tenumAsByte = (scommonQteButton != null) ? new TEnumAsByte<ECommonQteInputAction>?(scommonQteButton.Action) : null;
				int index = (int)((tenumAsByte != null) ? tenumAsByte.GetValueOrDefault() : 0);
				if (QtaActionNames.Has(index))
				{
					this.Actions.Add(QtaActionNames.Get(index));
				}
			}
		}

		// Token: 0x06036239 RID: 221753 RVA: 0x00DA2C4C File Offset: 0x00DA0E4C
		public override void OnQtaStart()
		{
			this.BindAction();
			if (this.QtaConfig.BaseConfig.Duration > 0f)
			{
				this.TimeoutHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					QtaCustomizationContext qtaContext = this.QtaContext;
					if (qtaContext == null)
					{
						return;
					}
					qtaContext.SetQtaResult(EQtaResult.Timeout);
				}, this.QtaConfig.BaseConfig.Duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, this.QtaConfig.BaseConfig.TimeDilation);
			}
		}

		// Token: 0x0603623A RID: 221754 RVA: 0x00DA2CC4 File Offset: 0x00DA0EC4
		private void BindAction()
		{
			if (this.HasBindAction)
			{
				return;
			}
			this.HasBindAction = true;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				foreach (string actionName in this.Actions)
				{
					ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit(actionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
				}
			}
		}

		// Token: 0x0603623B RID: 221755 RVA: 0x00DA2D44 File Offset: 0x00DA0F44
		private void UnbindAction()
		{
			if (!this.HasBindAction)
			{
				return;
			}
			this.HasBindAction = false;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				foreach (string actionName in this.Actions)
				{
					ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit(actionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
				}
			}
		}

		// Token: 0x0603623C RID: 221756 RVA: 0x00DA2DC4 File Offset: 0x00DA0FC4
		private void OnInputCallback(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification _)
		{
			if (this.QtaContext != null && this.QtaContext.IsActive() && this.QtaContext.IsPending())
			{
				this.QtaContext.QtaResponse(actionType == InputDistributeDefine.EActionType.Press);
			}
		}

		// Token: 0x0603623D RID: 221757 RVA: 0x00DA2DF7 File Offset: 0x00DA0FF7
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override List<string> OnGetActions()
		{
			return this.Actions;
		}

		// Token: 0x0603623E RID: 221758 RVA: 0x00DA2DFF File Offset: 0x00DA0FFF
		public override void OnQtaResponse(bool press = true)
		{
			if (press)
			{
				this.OnResponseStart();
				return;
			}
			this.OnResponseEnd();
		}

		// Token: 0x0603623F RID: 221759 RVA: 0x00DA2E14 File Offset: 0x00DA1014
		private void OnResponseStart()
		{
			if (this.QtaConfig == null || this.QtaContext == null)
			{
				return;
			}
			if (!this.QtaContext.IsPending() && !this.QtaContext.IsPendingSuccess())
			{
				return;
			}
			if (this.QtaContext.IsPending())
			{
				ControllerBase<QtaController>.Instance.PlayEffect(EQtaPromptType.按下提示, this.QtaContext.HandleId);
			}
			this.CheckCanEnd();
		}

		// Token: 0x06036240 RID: 221760 RVA: 0x00DA2E7D File Offset: 0x00DA107D
		private void OnResponseEnd()
		{
			if (this.QtaContext != null)
			{
				ControllerBase<QtaController>.Instance.PlayEffect(EQtaPromptType.抬起提示, this.QtaContext.HandleId);
				this.CheckCanEnd();
			}
		}

		// Token: 0x06036241 RID: 221761 RVA: 0x00DA2EA4 File Offset: 0x00DA10A4
		public override void OnUpdateTime(float delta)
		{
			if (this.QtaContext == null)
			{
				ControllerBase<QtaController>.Instance.StopCurrentQta();
				return;
			}
			this.PassTime += delta;
			if (this.CheckCanEnd())
			{
				return;
			}
			if (!this.QtaContext.IsPermanent && this.PassTime > this.QtaContext.Duration)
			{
				this.QtaContext.SetQtaResult(EQtaResult.Timeout);
			}
		}

		// Token: 0x06036242 RID: 221762 RVA: 0x00DA2F07 File Offset: 0x00DA1107
		public override float GetProgress()
		{
			return 0f;
		}

		// Token: 0x06036243 RID: 221763 RVA: 0x00DA2F0E File Offset: 0x00DA110E
		private bool CheckCanEnd()
		{
			if (this.QtaContext.State != EQtaState.Pending)
			{
				return true;
			}
			if (this.CheckCanEndInner())
			{
				this.QtaContext.SetQtaResult(this.CheckIsValid() ? EQtaResult.Success : EQtaResult.Fail);
				return true;
			}
			return false;
		}

		// Token: 0x06036244 RID: 221764 RVA: 0x00DA2F41 File Offset: 0x00DA1141
		protected override bool CheckIsValid()
		{
			return false;
		}

		// Token: 0x06036245 RID: 221765 RVA: 0x00DA2F44 File Offset: 0x00DA1144
		public override void OnPreEndQta()
		{
			if (this.QtaContext == null)
			{
				return;
			}
			if (this.QtaContext.IsEnd())
			{
				return;
			}
			if (this.QtaContext.HasResult())
			{
				this.QtaContext.SetQtaResult(this.QtaContext.PendingResultType);
				return;
			}
			this.QtaContext.SetQtaResult(EQtaResult.Success);
		}

		// Token: 0x06036246 RID: 221766 RVA: 0x00DA2F98 File Offset: 0x00DA1198
		private bool CheckCanEndInner()
		{
			return false;
		}

		// Token: 0x06036247 RID: 221767 RVA: 0x00DA2F9B File Offset: 0x00DA119B
		public override void OnQtaEnd(bool success = false)
		{
			if (this.TimeoutHandle != null)
			{
				TimerSystem.Instance.Remove(this.TimeoutHandle);
				this.TimeoutHandle = null;
			}
			this.UnbindAction();
		}

		// Token: 0x0401F1A5 RID: 127397
		private readonly List<string> Actions = new List<string>();

		// Token: 0x0401F1A6 RID: 127398
		[Nullable(2)]
		private TimerHandle TimeoutHandle;

		// Token: 0x0401F1A7 RID: 127399
		private bool HasBindAction;
	}
}
