using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A2E RID: 18990
	[NullableContext(2)]
	[Nullable(0)]
	public class ViewHotKeyHandle
	{
		// Token: 0x060319F8 RID: 203256 RVA: 0x00C5D064 File Offset: 0x00C5B264
		[NullableContext(1)]
		public ViewHotKeyHandle(IOpenAndCloseViewHotKey parameters)
		{
			this.ConfigId = new int?(parameters.ConfigId);
			this.ActionName = parameters.ActionName;
			this.InputControllerType = parameters.InputControllerType;
			this.DefaultViewName = new EUiViewName?(parameters.ViewName);
			this.ViewParam = parameters.ViewParam;
			this.IsPressTrigger = parameters.IsPressTrigger;
			this.PressStartTime = parameters.PressStartTime;
			this.PressTriggerTime = parameters.PressTriggerTime;
			this.IsReleaseTrigger = parameters.IsReleaseTrigger;
			this.ReleaseInvalidTime = parameters.ReleaseInvalidTime;
			this.IsPressClose = parameters.IsPressClose;
			this.IsReleaseClose = parameters.IsReleaseClose;
			this.OpenViewCallback = parameters.OpenViewCallback;
			this.CloseViewCallback = parameters.CloseViewCallback;
			this.IsAllowOpenViewByShortcutKey = parameters.IsAllowOpenViewByShortcutKey;
			this.IsAllowCloseViewByShortcutKey = parameters.IsAllowCloseViewByShortcutKey;
			this.IsLockShortcutKey = parameters.IsLockShortcutKey;
		}

		// Token: 0x17008474 RID: 33908
		// (get) Token: 0x060319F9 RID: 203257 RVA: 0x00C5D15F File Offset: 0x00C5B35F
		public virtual EUiViewName? ViewName
		{
			get
			{
				return this.DefaultViewName;
			}
		}

		// Token: 0x060319FA RID: 203258 RVA: 0x00C5D167 File Offset: 0x00C5B367
		public void Destroy()
		{
			this.UnBind();
			this.RemovePressTriggerTimer();
			this.OpenViewCallback = null;
			this.CloseViewCallback = null;
			this.IsAllowOpenViewByShortcutKey = null;
			this.IsAllowCloseViewByShortcutKey = null;
		}

		// Token: 0x060319FB RID: 203259 RVA: 0x00C5D191 File Offset: 0x00C5B391
		public virtual void Bind()
		{
			ControllerBase<InputDistributeController>.Instance.BindAction(this.ActionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x060319FC RID: 203260 RVA: 0x00C5D1AF File Offset: 0x00C5B3AF
		protected virtual void UnBind()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction(this.ActionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x060319FD RID: 203261 RVA: 0x00C5D1CD File Offset: 0x00C5B3CD
		[NullableContext(1)]
		protected void OnInputAction(string name, InputDistributeDefine.EActionType value, InputIdentification inputIdentification)
		{
			if (!this.CheckInputControllerType())
			{
				return;
			}
			Func<string, InputDistributeDefine.EActionType, bool> isLockShortcutKey = this.IsLockShortcutKey;
			if (isLockShortcutKey != null && isLockShortcutKey(name, value))
			{
				return;
			}
			if (value == InputDistributeDefine.EActionType.Press)
			{
				this.Press();
				return;
			}
			if (value == InputDistributeDefine.EActionType.Release)
			{
				this.Release();
			}
		}

		// Token: 0x060319FE RID: 203262 RVA: 0x00C5D204 File Offset: 0x00C5B404
		private bool CheckInputControllerType()
		{
			switch (this.InputControllerType)
			{
			case EOpenAndCloseViewInputControllerType.Common:
				return true;
			case EOpenAndCloseViewInputControllerType.Keyboard:
				return Singleton<Info>.Instance.IsInKeyBoard();
			case EOpenAndCloseViewInputControllerType.Gamepad:
				return Singleton<Info>.Instance.IsInGamepad();
			default:
				return false;
			}
		}

		// Token: 0x060319FF RID: 203263 RVA: 0x00C5D245 File Offset: 0x00C5B445
		[NullableContext(1)]
		public void BindOpenViewCallback(Action callback)
		{
			this.OpenViewCallback = callback;
		}

		// Token: 0x06031A00 RID: 203264 RVA: 0x00C5D24E File Offset: 0x00C5B44E
		[NullableContext(1)]
		public void BindCloseViewCallback(Action callback)
		{
			this.CloseViewCallback = callback;
		}

		// Token: 0x06031A01 RID: 203265 RVA: 0x00C5D258 File Offset: 0x00C5B458
		public void Press()
		{
			if (this.ViewName == null)
			{
				return;
			}
			EUiViewName? viewName = this.ViewName;
			if (StringUtils.IsBlank((viewName != null) ? viewName.GetValueOrDefault() : null))
			{
				return;
			}
			this.PressTimeStamp = Singleton<Time>.Instance.WorldTime;
			if (this.IsPressTrigger)
			{
				this.TryPressOpenView();
			}
			if (this.IsPressClose)
			{
				this.TryCloseView();
			}
		}

		// Token: 0x06031A02 RID: 203266 RVA: 0x00C5D2CC File Offset: 0x00C5B4CC
		public void Release()
		{
			this.RemovePressTriggerTimer();
			if (this.IsReleaseTrigger)
			{
				double worldTime = Singleton<Time>.Instance.WorldTime;
				if (this.ReleaseInvalidTime <= 0 || worldTime - this.PressTimeStamp <= (double)this.ReleaseInvalidTime)
				{
					this.TryOpenView();
				}
			}
			if (this.IsReleaseClose)
			{
				this.TryCloseView();
			}
		}

		// Token: 0x06031A03 RID: 203267 RVA: 0x00C5D324 File Offset: 0x00C5B524
		private bool TryPressOpenView()
		{
			if (this.PressTriggerTime <= 0)
			{
				return this.TryOpenView();
			}
			this.RemovePressTriggerTimer();
			this.PressTriggerTimer = TimerSystem.Instance.Delay(new TTimerAction(this.OnPressTriggerTimeFinished), (float)this.PressTriggerTime, null, null, true, 1f);
			return false;
		}

		// Token: 0x06031A04 RID: 203268 RVA: 0x00C5D373 File Offset: 0x00C5B573
		private void OnPressTriggerTimeFinished(float delta)
		{
			this.RemovePressTriggerTimer();
			this.TryOpenView();
		}

		// Token: 0x06031A05 RID: 203269 RVA: 0x00C5D382 File Offset: 0x00C5B582
		private void RemovePressTriggerTimer()
		{
			if (this.PressTriggerTimer != null && TimerSystem.Instance.Has(this.PressTriggerTimer))
			{
				TimerSystem.Instance.Remove(this.PressTriggerTimer);
			}
			this.PressTriggerTimer = null;
		}

		// Token: 0x06031A06 RID: 203270 RVA: 0x00C5D3B8 File Offset: 0x00C5B5B8
		private bool TryOpenView()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(this.ViewName.Value))
			{
				return false;
			}
			if (ModelBase<LoadingModel>.Instance.IsLoading)
			{
				return false;
			}
			if (this.CheckHasInputLimit())
			{
				return false;
			}
			if (this.IsAllowOpenViewByShortcutKey != null && !this.IsAllowOpenViewByShortcutKey())
			{
				return false;
			}
			if (!this.SpecialConditionCheck())
			{
				Singleton<Log>.Instance.Info(ELogModule.InputManager, ELogAuthor.YZY, "特殊情况，不处理分发，在别的模块处理", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}
			if (!this.IsAllowOpenView())
			{
				return false;
			}
			this.OpenView();
			return true;
		}

		// Token: 0x06031A07 RID: 203271 RVA: 0x00C5D448 File Offset: 0x00C5B648
		private bool TryCloseView()
		{
			if (!Singleton<UiManager>.Instance.IsViewOpen(this.ViewName.Value))
			{
				return false;
			}
			if (!Singleton<UiManager>.Instance.IsViewShow(this.ViewName.Value))
			{
				return false;
			}
			if (ModelBase<LoadingModel>.Instance.IsLoading)
			{
				return false;
			}
			if (this.IsAllowCloseViewByShortcutKey != null && !this.IsAllowCloseViewByShortcutKey())
			{
				return false;
			}
			this.CloseView();
			return true;
		}

		// Token: 0x06031A08 RID: 203272 RVA: 0x00C5D4BC File Offset: 0x00C5B6BC
		private void OpenView()
		{
			if (this.ViewName == null)
			{
				return;
			}
			EUiViewName? viewName = this.ViewName;
			if (StringUtils.IsBlank((viewName != null) ? viewName.GetValueOrDefault() : null))
			{
				return;
			}
			if (this.OpenViewCallback != null)
			{
				this.OpenViewCallback();
				return;
			}
			this.OnOpenViewImplement();
		}

		// Token: 0x06031A09 RID: 203273 RVA: 0x00C5D51C File Offset: 0x00C5B71C
		private void CloseView()
		{
			if (this.ViewName == null)
			{
				return;
			}
			EUiViewName? viewName = this.ViewName;
			if (StringUtils.IsBlank((viewName != null) ? viewName.GetValueOrDefault() : null))
			{
				return;
			}
			if (this.CloseViewCallback != null)
			{
				this.CloseViewCallback();
				return;
			}
			Singleton<UiManager>.Instance.CloseView(this.ViewName.Value, null);
		}

		// Token: 0x06031A0A RID: 203274 RVA: 0x00C5D590 File Offset: 0x00C5B790
		private bool IsAllowOpenView()
		{
			InputDistributeModel instance = ModelBase<InputDistributeModel>.Instance;
			HashSet<EUiViewName> hashSet = (instance != null) ? instance.GetNotAllowFightInputViewNameSet() : null;
			return hashSet == null || hashSet.Count == 0 || hashSet.Contains(this.ViewName.Value);
		}

		// Token: 0x06031A0B RID: 203275 RVA: 0x00C5D5D8 File Offset: 0x00C5B7D8
		protected virtual bool CheckHasInputLimit()
		{
			return Singleton<LevelEventLockInputState>.Instance.InputLimitView.Contains(this.ViewName.Value);
		}

		// Token: 0x06031A0C RID: 203276 RVA: 0x00C5D602 File Offset: 0x00C5B802
		protected virtual bool SpecialConditionCheck()
		{
			return true;
		}

		// Token: 0x06031A0D RID: 203277 RVA: 0x00C5D608 File Offset: 0x00C5B808
		protected virtual void OnOpenViewImplement()
		{
			Singleton<UiManager>.Instance.OpenView(this.ViewName.Value, (this.ViewParam.Length != 0) ? this.ViewParam : null, null);
		}

		// Token: 0x0401CE25 RID: 118309
		public int? ConfigId;

		// Token: 0x0401CE26 RID: 118310
		public string ActionName;

		// Token: 0x0401CE27 RID: 118311
		public readonly EOpenAndCloseViewInputControllerType InputControllerType;

		// Token: 0x0401CE28 RID: 118312
		protected readonly EUiViewName? DefaultViewName;

		// Token: 0x0401CE29 RID: 118313
		[Nullable(1)]
		public string[] ViewParam = Array.Empty<string>();

		// Token: 0x0401CE2A RID: 118314
		public bool IsPressTrigger = true;

		// Token: 0x0401CE2B RID: 118315
		public int PressStartTime;

		// Token: 0x0401CE2C RID: 118316
		public int PressTriggerTime;

		// Token: 0x0401CE2D RID: 118317
		public bool IsReleaseTrigger;

		// Token: 0x0401CE2E RID: 118318
		public int ReleaseInvalidTime;

		// Token: 0x0401CE2F RID: 118319
		public bool IsPressClose;

		// Token: 0x0401CE30 RID: 118320
		public bool IsReleaseClose;

		// Token: 0x0401CE31 RID: 118321
		private Action OpenViewCallback;

		// Token: 0x0401CE32 RID: 118322
		private Action CloseViewCallback;

		// Token: 0x0401CE33 RID: 118323
		private Func<bool> IsAllowOpenViewByShortcutKey;

		// Token: 0x0401CE34 RID: 118324
		private Func<bool> IsAllowCloseViewByShortcutKey;

		// Token: 0x0401CE35 RID: 118325
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly Func<string, InputDistributeDefine.EActionType, bool> IsLockShortcutKey;

		// Token: 0x0401CE36 RID: 118326
		private TimerHandle PressTriggerTimer;

		// Token: 0x0401CE37 RID: 118327
		private double PressTimeStamp;
	}
}
