using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.Gamepad;
using CSharpScript.Game.Module.Qte.View;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002610 RID: 9744
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class CommonQteController : ControllerBase<CommonQteController>
{
	// Token: 0x170017D8 RID: 6104
	// (get) Token: 0x060131C0 RID: 78272 RVA: 0x0054C257 File Offset: 0x0054A457
	public CommonQteContextBase ContextProp
	{
		get
		{
			return this.Context;
		}
	}

	// Token: 0x060131C1 RID: 78273 RVA: 0x0054C25F File Offset: 0x0054A45F
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		return true;
	}

	// Token: 0x060131C2 RID: 78274 RVA: 0x0054C27E File Offset: 0x0054A47E
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		return true;
	}

	// Token: 0x060131C3 RID: 78275 RVA: 0x0054C29D File Offset: 0x0054A49D
	protected override bool OnLeaveLevel()
	{
		this.ClearAll();
		return true;
	}

	// Token: 0x060131C4 RID: 78276 RVA: 0x0054C2A6 File Offset: 0x0054A4A6
	protected override bool OnChangeMode()
	{
		this.ClearAll();
		return true;
	}

	// Token: 0x060131C5 RID: 78277 RVA: 0x0054C2B0 File Offset: 0x0054A4B0
	private void OnTeleportComplete(TeleportContext _)
	{
		if (this.IsInQte())
		{
			CommonQteContextBase context = this.Context;
			if (context != null && context.IsActive())
			{
				CommonQteContextBase context2 = this.Context;
				if (context2 != null && context2.IsPending())
				{
					this.SetQteTimeDilation(this.Context.Config.BaseConfig.TimeDilation);
				}
			}
		}
	}

	// Token: 0x060131C6 RID: 78278 RVA: 0x0054C308 File Offset: 0x0054A508
	public void RecoverTimeDilationAfterTeleport()
	{
		if (this.IsInQte())
		{
			CommonQteContextBase context = this.Context;
			if (context != null && context.IsActive())
			{
				CommonQteContextBase context2 = this.Context;
				if (context2 != null && context2.IsPending())
				{
					this.SetQteTimeDilation(this.Context.Config.BaseConfig.TimeDilation);
				}
			}
		}
	}

	// Token: 0x060131C7 RID: 78279 RVA: 0x0054C360 File Offset: 0x0054A560
	private void ClearAll()
	{
		if (this.IsInQte())
		{
			this.ResetQteTimeDilation();
		}
		this.ClearQte();
	}

	// Token: 0x060131C8 RID: 78280 RVA: 0x0054C378 File Offset: 0x0054A578
	public CommonQteContextBase StartQte(int qteId, TCommonQteCallback onSuccess = null, TCommonQteCallback onFail = null, EQteSource source = EQteSource.Battle, IQteExtraParams extraParams = null)
	{
		string value = null;
		if (this.IsInQte())
		{
			value = "当前存在执行中的Qte, 无法开始新的Qte";
		}
		else if (this.IsPreloadingQte)
		{
			value = "Qte预加载中, 无法开始新的Qte";
		}
		if (!string.IsNullOrEmpty(value))
		{
			return null;
		}
		CommonQteModel instance = ModelBase<CommonQteModel>.Instance;
		CommonQteContextBase commonQteContextBase = (instance != null) ? instance.CreateQteContext(qteId, onSuccess, onFail, source, extraParams) : null;
		if (commonQteContextBase == null)
		{
			return null;
		}
		if (this.StartQteInternal(commonQteContextBase))
		{
			return commonQteContextBase;
		}
		return null;
	}

	// Token: 0x060131C9 RID: 78281 RVA: 0x0054C3DC File Offset: 0x0054A5DC
	[NullableContext(1)]
	private unsafe bool StartQteInternal(CommonQteContextBase context)
	{
		ModelBase<CommonQteModel>.Instance.SetCurrentCommonQte(context);
		int qteId = context.QteId;
		this.IsInQteInternal = true;
		this.Context = context;
		EUiViewName? viewName = ModelBase<CommonQteModel>.Instance.GetCommonQteViewName(qteId);
		string itemName = null;
		if (viewName == null)
		{
			itemName = ModelBase<CommonQteModel>.Instance.GetCommonQteItemName(qteId);
		}
		this.PreloadQteRes(new <>z__ReadOnlySingleElementList<int>(qteId), context.HandleId, false).ContinueWith(delegate(bool success)
		{
			bool flag;
			if (this.IsInQteInternal)
			{
				CommonQteContextBase context2 = this.Context;
				int? num = (context2 != null) ? new int?(context2.HandleId) : null;
				int handleId = context.HandleId;
				flag = (num.GetValueOrDefault() == handleId & num != null);
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			if (flag2)
			{
				if (success)
				{
					CommonQteViewBase commonQteViewBase;
					if (!string.IsNullOrEmpty(itemName))
					{
						CommonQteItemBase commonQteItemBase;
						if (this.CommonQteItemMap.TryGetValue(qteId, out commonQteItemBase))
						{
							CommonQteContextBase context3 = context;
							CommonQteModel instance = ModelBase<CommonQteModel>.Instance;
							context3.Resource = ((instance != null) ? instance.GetQteResource(qteId, false) : null);
							context.UiActor = commonQteItemBase.GetRootActor();
							commonQteItemBase.SetQteContext(context);
							this.CommonQteItemMap.Remove(qteId);
							return;
						}
					}
					else if (viewName != null && this.CommonQteViewMap.TryGetValue(viewName.Value, out commonQteViewBase) && commonQteViewBase != null)
					{
						context.Resource = ModelBase<CommonQteModel>.Instance.GetQteResource(qteId, false);
						commonQteViewBase.SetQteContext(context);
						this.CommonQteViewMap.Remove(viewName.Value);
						return;
					}
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CommonQte;
				ELogAuthor author = ELogAuthor.WWJ;
				string message = "Qte加载失败, 停止当前Qte";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("HandleId", context.HandleId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("QteId", context.QteId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ViewName", viewName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ItemName", itemName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Success", success);
				instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
				this.OnQteEnd();
				return;
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.CommonQte;
			ELogAuthor author2 = ELogAuthor.WWJ;
			string message2 = "Qte预加载完成后, Qte已结束或已过期";
			<>y__InlineArray8<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray8<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("HandleId", context.HandleId);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
			string item = "CurrentQteHandleId";
			CommonQteContextBase context4 = this.Context;
			ptr = new ValueTuple<string, object>(item, (context4 != null) ? new int?(context4.HandleId) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("QteId", context.QteId);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3);
			string item2 = "CurrentQteId";
			CommonQteContextBase context5 = this.Context;
			ptr2 = new ValueTuple<string, object>(item2, (context5 != null) ? new int?(context5.QteId) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("IsInQte", this.IsInQteInternal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 5) = new ValueTuple<string, object>("IsQteValid", flag2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 6) = new ValueTuple<string, object>("ViewName", viewName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 7) = new ValueTuple<string, object>("ItemName", itemName);
			instance3.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 8));
			if (!string.IsNullOrEmpty(itemName))
			{
				CommonQteItemBase commonQteItemBase2;
				if (this.CommonQteItemMap.TryGetValue(qteId, out commonQteItemBase2))
				{
					CommonQteItemBase commonQteItemBase3 = commonQteItemBase2;
					if (!commonQteItemBase3.IsDestroyOrDestroying)
					{
						commonQteItemBase3.Destroy(null);
					}
				}
				this.CommonQteItemMap.Remove(qteId);
			}
			if (viewName != null)
			{
				Singleton<UiManager>.Instance.CloseView(viewName.Value, null);
				this.CommonQteViewMap.Remove(viewName.Value);
			}
			CommonQteModel instance4 = ModelBase<CommonQteModel>.Instance;
			if (instance4 == null)
			{
				return;
			}
			instance4.ClearPreloadCache(new int?(qteId));
		}).Forget();
		SCommonQte config = context.Config;
		if (config != null)
		{
			if (config.ExtraConfig.IsBlockFightInput)
			{
				this.AddFightInputBlock(EUiViewName.CommonQteView);
			}
			this.PlayQteAudio(config.AudioConfig.AudioEventStart, null);
			this.AddExtraEffect(config.ExtraConfig);
			this.SetQteTimeDilation(config.BaseConfig.TimeDilation);
		}
		if (!this.TempHideCursorQteSet.Contains(qteId))
		{
			Singleton<InputManager>.Instance.PauseImmersiveMouseMode(EImmersiveMouseModeReason.Qte, true, true, false);
		}
		Singleton<EventSystem>.Instance.Emit<int?>(EEventName.CommonQteStart, new int?(this.Context.HandleId));
		return true;
	}

	// Token: 0x060131CA RID: 78282 RVA: 0x0054C548 File Offset: 0x0054A748
	public CommonQteGroupContext StartQteGroup(int qteGroupId, TCommonQteCallback onSuccess = null, TCommonQteCallback onFail = null, EQteSource source = EQteSource.Battle, IQteExtraParams extraParams = null)
	{
		string value = null;
		if (this.IsInQte())
		{
			value = "当前存在执行中的Qte, 无法开始新的Qte";
		}
		else if (this.IsPreloadingQte)
		{
			value = "Qte预加载中, 无法开始新的Qte";
		}
		if (!string.IsNullOrEmpty(value))
		{
			return null;
		}
		CommonQteGroupContext commonQteGroupContext = ModelBase<CommonQteModel>.Instance.CreateQteGroupContext(qteGroupId, onSuccess, onFail, source, extraParams);
		if (commonQteGroupContext == null)
		{
			return null;
		}
		if (this.StartQteGroupInternal(commonQteGroupContext))
		{
			return commonQteGroupContext;
		}
		return null;
	}

	// Token: 0x060131CB RID: 78283 RVA: 0x0054C5A4 File Offset: 0x0054A7A4
	[NullableContext(1)]
	private bool StartQteGroupInternal(CommonQteGroupContext groupContext)
	{
		Dictionary<int, CommonQteContextBase> contextMap = groupContext.ContextMap;
		if (contextMap == null || contextMap.Count == 0)
		{
			return false;
		}
		CommonQteModel instance = ModelBase<CommonQteModel>.Instance;
		if (instance != null)
		{
			instance.SetCurrentCommonQte(groupContext);
		}
		this.IsInQteInternal = true;
		this.Context = groupContext;
		List<int> qteIdList = new List<int>(contextMap.Keys);
		this.PreloadQteRes(qteIdList, groupContext.HandleId, true).ContinueWith(delegate(bool success)
		{
			bool flag = true;
			if (success)
			{
				using (Dictionary<int, CommonQteContextBase>.Enumerator enumerator = contextMap.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<int, CommonQteContextBase> keyValuePair = enumerator.Current;
						int key = keyValuePair.Key;
						CommonQteContextBase value = keyValuePair.Value;
						CommonQteModel instance2 = ModelBase<CommonQteModel>.Instance;
						if (!string.IsNullOrEmpty((instance2 != null) ? instance2.GetCommonQteItemName(key) : null))
						{
							CommonQteItemBase commonQteItemBase;
							if (this.CommonQteItemMap.TryGetValue(key, out commonQteItemBase))
							{
								CommonQteContextBase commonQteContextBase = value;
								CommonQteModel instance3 = ModelBase<CommonQteModel>.Instance;
								commonQteContextBase.Resource = ((instance3 != null) ? instance3.GetQteResource(key, false) : null);
								value.UiActor = commonQteItemBase.GetRootActor();
								commonQteItemBase.SetQteContext(value);
								this.CommonQteItemMap.Remove(key);
							}
							else
							{
								flag = false;
							}
						}
						else
						{
							flag = false;
						}
					}
					goto IL_C9;
				}
			}
			flag = false;
			IL_C9:
			if (!flag)
			{
				this.OnQteEnd();
			}
		}).Forget();
		SCommonQte config = groupContext.GetConfig();
		if (config != null)
		{
			if (config.ExtraConfig.IsBlockFightInput)
			{
				this.AddFightInputBlock(EUiViewName.CommonQteView);
			}
			this.PlayQteAudio(config.AudioConfig.AudioEventStart, null);
			this.AddExtraEffect(config.ExtraConfig);
		}
		this.SetQteTimeDilation(groupContext.GroupConfig.TimeDilation);
		Singleton<InputManager>.Instance.PauseImmersiveMouseMode(EImmersiveMouseModeReason.Qte, true, true, false);
		Singleton<EventSystem>.Instance.Emit<int?>(EEventName.CommonQteStart, new int?(this.Context.HandleId));
		return true;
	}

	// Token: 0x060131CC RID: 78284 RVA: 0x0054C6C0 File Offset: 0x0054A8C0
	[NullableContext(1)]
	public void SetExpiredTimer(CommonQteContextBase context)
	{
		if (context.Source.GetValueOrDefault() == EQteSource.Plot || context.Source.GetValueOrDefault() == EQteSource.CG)
		{
			return;
		}
		this.RemoveExpiredTimer();
		float currentValue = context.IsPermanent ? 60000f : (context.Duration + 5000f);
		this.ExpiredTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			if (!context.IsFail())
			{
				context.QteFail();
				return;
			}
			this.OnQteEnd();
		}, Singleton<MathUtils>.Instance.Clamp(currentValue, 20f, 180000f), null, null, true, 1f);
	}

	// Token: 0x060131CD RID: 78285 RVA: 0x0054C770 File Offset: 0x0054A970
	public void StopQte(int qteHandle)
	{
		CommonQteContextBase context = this.Context;
		int? num = (context != null) ? new int?(context.HandleId) : null;
		if (!(qteHandle == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		this.OnQteEnd();
	}

	// Token: 0x060131CE RID: 78286 RVA: 0x0054C7B8 File Offset: 0x0054A9B8
	public void StopCurrentQte()
	{
		this.OnQteEnd();
	}

	// Token: 0x060131CF RID: 78287 RVA: 0x0054C7C0 File Offset: 0x0054A9C0
	public void WaitQteEnd(int qteHandle)
	{
		CommonQteContextBase context = this.Context;
		int? num = (context != null) ? new int?(context.HandleId) : null;
		if (!(qteHandle == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		this.OnQteWaitEnd();
	}

	// Token: 0x060131D0 RID: 78288 RVA: 0x0054C808 File Offset: 0x0054AA08
	private void OnQteWaitEnd()
	{
		CommonQteContextBase context = this.Context;
		if (((context != null) ? context.Config : null) != null && this.Context.IsPendingSuccess())
		{
			this.PlayQteAudio(this.Context.Config.AudioConfig.AudioEventPendingSuccess, null);
		}
	}

	// Token: 0x060131D1 RID: 78289 RVA: 0x0054C85C File Offset: 0x0054AA5C
	private void OnQteEnd()
	{
		this.ResetQteTimeDilation();
		CommonQteContextBase context = this.Context;
		SCommonQte scommonQte = (context != null) ? context.GetConfig() : null;
		if (scommonQte != null)
		{
			CommonQteContextBase context2 = this.Context;
			if (context2 != null && context2.IsSuccess())
			{
				this.PlayQteAudio(scommonQte.AudioConfig.AudioEventSuccess, null);
			}
			else
			{
				CommonQteContextBase context3 = this.Context;
				if (context3 != null && context3.IsFail())
				{
					this.PlayQteAudio(scommonQte.AudioConfig.AudioEventFail, null);
				}
			}
		}
		if (this.Context == null || !this.TempHideCursorQteSet.Contains(this.Context.QteId))
		{
			Singleton<InputManager>.Instance.ResumeImmersiveMouseMode(EImmersiveMouseModeReason.Qte);
		}
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.CommonQteEnd;
		CommonQteContextBase context4 = this.Context;
		instance.Emit<int?>(name, (context4 != null) ? new int?(context4.HandleId) : null);
		CommonQteModel instance2 = ModelBase<CommonQteModel>.Instance;
		if (instance2 != null)
		{
			instance2.ClearQteHandleId(null);
		}
		CommonQteGroupContext commonQteGroupContext = this.Context as CommonQteGroupContext;
		if (commonQteGroupContext != null)
		{
			Dictionary<int, CommonQteContextBase> contextMap = commonQteGroupContext.ContextMap;
			if (contextMap != null)
			{
				foreach (CommonQteContextBase commonQteContextBase in contextMap.Values)
				{
					Singleton<EventSystem>.Instance.Emit<int?>(EEventName.CommonQteEnd, new int?(commonQteContextBase.HandleId));
					CommonQteModel instance3 = ModelBase<CommonQteModel>.Instance;
					if (instance3 != null)
					{
						instance3.ClearQteHandleId(new int?(commonQteContextBase.HandleId));
					}
				}
			}
		}
		this.ClearQte();
	}

	// Token: 0x060131D2 RID: 78290 RVA: 0x0054C9EC File Offset: 0x0054ABEC
	public void PauseQte(int handleId)
	{
		if (this.Context == null || handleId != this.Context.HandleId)
		{
			return;
		}
		if (this.ExpiredTimer != null && !this.ExpiredTimer.IsPause())
		{
			this.ExpiredTimer.Pause();
		}
		this.ResetQteTimeDilation();
	}

	// Token: 0x060131D3 RID: 78291 RVA: 0x0054CA2C File Offset: 0x0054AC2C
	public void ResumeQte(int handleId)
	{
		if (this.Context == null || handleId != this.Context.HandleId)
		{
			return;
		}
		if (this.ExpiredTimer != null && this.ExpiredTimer.IsPause())
		{
			this.ExpiredTimer.Resume();
		}
		this.SetQteTimeDilation(this.Context.Config.BaseConfig.TimeDilation);
		this.ResumeFightInputBlock();
	}

	// Token: 0x060131D4 RID: 78292 RVA: 0x0054CA92 File Offset: 0x0054AC92
	public bool IsInQte()
	{
		return this.IsInQteInternal;
	}

	// Token: 0x060131D5 RID: 78293 RVA: 0x0054CA9A File Offset: 0x0054AC9A
	public bool IsPreloading()
	{
		return this.IsPreloadingQte;
	}

	// Token: 0x060131D6 RID: 78294 RVA: 0x0054CAA4 File Offset: 0x0054ACA4
	public void ClearQte()
	{
		this.RemoveFightInputBlock();
		this.RemoveExtraEffect();
		this.RemoveExpiredTimer();
		this.IsInQteInternal = false;
		this.IsPreloadingQte = false;
		this.IsSetQteTimeDilation = false;
		CommonQteContextBase context = this.Context;
		if (context != null)
		{
			context.Clear();
		}
		this.Context = null;
		this.ClearPreloadQteRes();
	}

	// Token: 0x060131D7 RID: 78295 RVA: 0x0054CAF6 File Offset: 0x0054ACF6
	private void RemoveExpiredTimer()
	{
		if (this.ExpiredTimer != null)
		{
			TimerSystem.Instance.Remove(this.ExpiredTimer);
		}
		this.ExpiredTimer = null;
	}

	// Token: 0x060131D8 RID: 78296 RVA: 0x0054CB18 File Offset: 0x0054AD18
	public void SetQteTimeDilation(float timeDilation)
	{
		if (!this.IsInQte())
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
			this.SetQteTimeDilationInternal(timeDilation);
		}
	}

	// Token: 0x060131D9 RID: 78297 RVA: 0x0054CB77 File Offset: 0x0054AD77
	public void ResetQteTimeDilation()
	{
		this.SetQteTimeDilationInternal(1f);
	}

	// Token: 0x060131DA RID: 78298 RVA: 0x0054CB84 File Offset: 0x0054AD84
	public bool IsSelfTriggeringTimeDilationChange()
	{
		return this.IsSelfTriggeringTimeDilation;
	}

	// Token: 0x060131DB RID: 78299 RVA: 0x0054CB8C File Offset: 0x0054AD8C
	private void SetQteTimeDilationInternal(float timeDilation)
	{
		bool flag = timeDilation != 1f;
		if (!flag && !this.IsSetQteTimeDilation)
		{
			return;
		}
		if (flag && this.IsSetQteTimeDilation)
		{
			return;
		}
		this.IsSetQteTimeDilation = flag;
		this.IsSelfTriggeringTimeDilation = true;
		ControllerBase<GameModeController>.Instance.SetTimeDilation(timeDilation, ETimeDilationType.CommonQte);
		this.IsSelfTriggeringTimeDilation = false;
	}

	// Token: 0x060131DC RID: 78300 RVA: 0x0054CBE0 File Offset: 0x0054ADE0
	[NullableContext(1)]
	public void AddExtraEffect(SCommonQte_Extra config)
	{
		if (config.HideAllBattleUi)
		{
			this.IsHideAllBattleUi = true;
			ModelBase<BattleUiModel>.Instance.ChildViewData.HideBattleView(EBattleUiVisibleReason.PanelQte, new List<EBattleUiChild>
			{
				EBattleUiChild.PanelQTE
			}, 0);
			return;
		}
		this.IsHideAllBattleUi = false;
		int num = config.HideUIElement.Num();
		if (num > 0)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < num; i++)
			{
				list.Add((int)config.HideUIElement.Get(i));
			}
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.PanelQte, CommonQteController.ConvertToBattleUiChildren(list), false, true, 0);
			this.HideBattleUiChildren = list;
			return;
		}
		this.HideBattleUiChildren = null;
	}

	// Token: 0x060131DD RID: 78301 RVA: 0x0054CC84 File Offset: 0x0054AE84
	public void RemoveExtraEffect()
	{
		if (this.IsHideAllBattleUi)
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.PanelQte, 0);
			this.IsHideAllBattleUi = false;
		}
		else
		{
			List<int> hideBattleUiChildren = this.HideBattleUiChildren;
			if (hideBattleUiChildren != null)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.PanelQte, CommonQteController.ConvertToBattleUiChildren(hideBattleUiChildren), true, true, 0);
				this.HideBattleUiChildren = null;
			}
		}
		this.RemoveScreenEffect();
		this.RemoveCameraShake(true);
	}

	// Token: 0x060131DE RID: 78302 RVA: 0x0054CCEC File Offset: 0x0054AEEC
	private void RemoveScreenEffect()
	{
		if (this.ScreenEffectTimer != null)
		{
			TimerSystem.Instance.Remove(this.ScreenEffectTimer);
			this.ScreenEffectTimer = null;
		}
		if (this.ScreenEffect != null)
		{
			ScreenEffectSystem.GetInstance().EndScreenEffect(this.ScreenEffect);
			this.ScreenEffect = null;
		}
		if (this.ScreenEffectHandle != -1)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.ScreenEffectHandle, "[CommonQteController.RemoveScreenEffect]", true, null);
			this.ScreenEffectHandle = -1;
		}
	}

	// Token: 0x060131DF RID: 78303 RVA: 0x0054CD68 File Offset: 0x0054AF68
	private void RemoveCameraShake(bool immediatly = true)
	{
		if (this.CameraShakeTimer != null)
		{
			TimerSystem.Instance.Remove(this.CameraShakeTimer);
			this.CameraShakeTimer = null;
		}
		if (this.CameraShake != null)
		{
			Global.CharacterCameraManager.StopCameraShake(this.CameraShake, immediatly);
			this.CameraShake = null;
		}
	}

	// Token: 0x060131E0 RID: 78304 RVA: 0x0054CDB8 File Offset: 0x0054AFB8
	public void PlayScreenEffect()
	{
		CommonQteController.<>c__DisplayClass55_0 CS$<>8__locals1 = new CommonQteController.<>c__DisplayClass55_0();
		CS$<>8__locals1.<>4__this = this;
		if (this.Context == null)
		{
			return;
		}
		if (this.IsPlayingScreenEffect())
		{
			return;
		}
		CommonQteController.<>c__DisplayClass55_0 CS$<>8__locals2 = CS$<>8__locals1;
		IQteResource resource = this.Context.Resource;
		CS$<>8__locals2.screenEffect = ((resource != null) ? resource.ScreenEffect1 : null);
		if (CS$<>8__locals1.screenEffect != null)
		{
			this.ScreenEffectType = EQteScreenEffectType.Type1;
			this.ScreenEffect = CS$<>8__locals1.screenEffect;
			ScreenEffectSystem.GetInstance().PlayScreenEffect(CS$<>8__locals1.screenEffect);
			if (CS$<>8__locals1.screenEffect.Loop == 0f)
			{
				float currentValue = (CS$<>8__locals1.screenEffect.Start + CS$<>8__locals1.screenEffect.End) * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
				this.ScreenEffectTimer = TimerSystem.Instance.Delay(delegate(float _)
				{
					ScreenEffectSystem.GetInstance().EndScreenEffect(CS$<>8__locals1.screenEffect);
					CS$<>8__locals1.<>4__this.ScreenEffect = null;
					CS$<>8__locals1.<>4__this.ScreenEffectTimer = null;
				}, Singleton<MathUtils>.Instance.Clamp(currentValue, 20f, 180000f), null, null, true, 1f);
			}
			return;
		}
		IQteResource resource2 = this.Context.Resource;
		EffectModelPostProcess effectModelPostProcess = (resource2 != null) ? resource2.ScreenEffect2 : null;
		if (effectModelPostProcess != null)
		{
			CommonQteModel instance = ModelBase<CommonQteModel>.Instance;
			string text = (instance != null) ? instance.GetQteScreenEffectPath(this.Context.QteId, EQteScreenEffectType.Type2) : null;
			if (!string.IsNullOrEmpty(text))
			{
				this.ScreenEffectType = EQteScreenEffectType.Type2;
				EffectSystem instance2 = Singleton<EffectSystem>.Instance;
				UObject world = GlobalData.World;
				FTransformDouble? ftransformDouble = new FTransformDouble?(Transform.Create().ToUeTransform());
				this.ScreenEffectHandle = instance2.SpawnEffect(world, ftransformDouble, text, "[CommonQteController.PlayScreenEffect]", null, EEffectType.Scene, null, null, null, false, false);
				if (effectModelPostProcess.LoopTime == 0f)
				{
					float currentValue2 = (effectModelPostProcess.StartTime + effectModelPostProcess.EndTime) * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
					this.ScreenEffectTimer = TimerSystem.Instance.Delay(delegate(float _)
					{
						Singleton<EffectSystem>.Instance.StopEffectById(CS$<>8__locals1.<>4__this.ScreenEffectHandle, "[CommonQteController.ScreenEffectTimer]", true, null);
						CS$<>8__locals1.<>4__this.ScreenEffectHandle = -1;
						CS$<>8__locals1.<>4__this.ScreenEffectTimer = null;
					}, Singleton<MathUtils>.Instance.Clamp(currentValue2, 20f, 180000f), null, null, true, 1f);
				}
			}
		}
	}

	// Token: 0x060131E1 RID: 78305 RVA: 0x0054CF84 File Offset: 0x0054B184
	public bool IsPlayingScreenEffect()
	{
		if (this.ScreenEffectType == EQteScreenEffectType.Type1)
		{
			return this.ScreenEffect != null;
		}
		return this.ScreenEffectType == EQteScreenEffectType.Type2 && this.ScreenEffectHandle != -1;
	}

	// Token: 0x060131E2 RID: 78306 RVA: 0x0054CFB0 File Offset: 0x0054B1B0
	public void PlayCameraShake()
	{
		if (this.Context == null)
		{
			return;
		}
		if (this.CameraShake != null)
		{
			return;
		}
		IQteResource resource = this.Context.Resource;
		UClass uclass = (resource != null) ? resource.CameraShake : null;
		if (uclass != null)
		{
			this.CameraShake = Global.CharacterCameraManager.StartMatineeCameraShake(uclass, 1f, ECameraShakePlaySpace.CameraLocal, default(FRotator), 1f);
			if (this.CameraShake != null)
			{
				float currentValue = this.CameraShake.OscillatorTimeRemaining * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
				this.CameraShakeTimer = TimerSystem.Instance.Delay(delegate(float _)
				{
					Global.CharacterCameraManager.StopCameraShake(this.CameraShake, false);
					this.CameraShake = null;
					this.CameraShakeTimer = null;
				}, Singleton<MathUtils>.Instance.Clamp(currentValue, 20f, 180000f), null, null, true, 1f);
			}
		}
	}

	// Token: 0x060131E3 RID: 78307 RVA: 0x0054D070 File Offset: 0x0054B270
	public void PlayGamepadShake()
	{
		if (this.Context == null)
		{
			return;
		}
		IQteResource resource = this.Context.Resource;
		UKuroForceFeedbackEffect ukuroForceFeedbackEffect = (resource != null) ? resource.GamepadShake : null;
		if (ukuroForceFeedbackEffect == null || this.Context.Type == null)
		{
			return;
		}
		ControllerBase<GamepadController>.Instance.TriggerGamepadShakeByQte(this.Context.Type.Value, ukuroForceFeedbackEffect);
	}

	// Token: 0x060131E4 RID: 78308 RVA: 0x0054D0D0 File Offset: 0x0054B2D0
	public void StopGamepadShake()
	{
		if (this.Context == null)
		{
			return;
		}
		IQteResource resource = this.Context.Resource;
		UKuroForceFeedbackEffect ukuroForceFeedbackEffect = (resource != null) ? resource.GamepadShake : null;
		if (ukuroForceFeedbackEffect == null || this.Context.Type == null)
		{
			return;
		}
		ControllerBase<GamepadController>.Instance.StopQteGamepadShake(this.Context.Type.Value, ukuroForceFeedbackEffect);
	}

	// Token: 0x060131E5 RID: 78309 RVA: 0x0054D12F File Offset: 0x0054B32F
	public void PlayExtraEffect(int qteHandle)
	{
		if (this.Context == null || qteHandle != this.Context.HandleId)
		{
			return;
		}
		this.PlayScreenEffect();
		this.PlayCameraShake();
		this.PlayGamepadShake();
	}

	// Token: 0x060131E6 RID: 78310 RVA: 0x0054D15A File Offset: 0x0054B35A
	public void StopExtraEffect(int qteHandle)
	{
		if (this.Context == null || qteHandle != this.Context.HandleId)
		{
			return;
		}
		this.RemoveScreenEffect();
		this.RemoveCameraShake(false);
		this.StopGamepadShake();
	}

	// Token: 0x060131E7 RID: 78311 RVA: 0x0054D188 File Offset: 0x0054B388
	public int PlayQteAudio([Nullable(new byte[]
	{
		2,
		1
	})] TSoftObjectPtr<UAkAudioEvent> audioEvent, AActor actor = null)
	{
		if (audioEvent == null)
		{
			return 0;
		}
		string text = Singleton<AudioSystem>.Instance.parseAudioEventPath(audioEvent.ToAssetPathName());
		if (string.IsNullOrEmpty(text))
		{
			return 0;
		}
		if (actor != null)
		{
			return Singleton<AudioSystem>.Instance.PostEvent(text, actor, null);
		}
		return Singleton<AudioSystem>.Instance.PostEvent(text);
	}

	// Token: 0x060131E8 RID: 78312 RVA: 0x0054D1E0 File Offset: 0x0054B3E0
	public void SeekAudio(Number position, [Nullable(new byte[]
	{
		2,
		1
	})] TSoftObjectPtr<UAkAudioEvent> audioEvent, AActor actor = null, int? handle = null)
	{
		if (audioEvent == null)
		{
			return;
		}
		string text = Singleton<AudioSystem>.Instance.parseAudioEventPath(audioEvent.ToAssetPathName());
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		Singleton<AudioSystem>.Instance.SeekOnEvent(text, position, new SeekOnEventArgs?(new SeekOnEventArgs(actor, handle, null)));
	}

	// Token: 0x060131E9 RID: 78313 RVA: 0x0054D238 File Offset: 0x0054B438
	public void StopQteAudio(int handle, float? blendOutTime = null)
	{
		if (handle == 0)
		{
			return;
		}
		ExecuteActionArgs value = new ExecuteActionArgs(null, null, null);
		if (blendOutTime != null)
		{
			value.TransitionDuration = new int?((int)blendOutTime.Value);
		}
		Singleton<AudioSystem>.Instance.ExecuteAction(handle, EAudioActionType.Stop, new ExecuteActionArgs?(value));
	}

	// Token: 0x060131EA RID: 78314 RVA: 0x0054D294 File Offset: 0x0054B494
	[NullableContext(0)]
	public UniTask<bool> PreloadQteRes([Nullable(1)] IReadOnlyList<int> qteIdList, int preloadHandleId = -1, bool isGroupQte = false)
	{
		CommonQteController.<PreloadQteRes>d__65 <PreloadQteRes>d__;
		<PreloadQteRes>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<PreloadQteRes>d__.<>4__this = this;
		<PreloadQteRes>d__.qteIdList = qteIdList;
		<PreloadQteRes>d__.preloadHandleId = preloadHandleId;
		<PreloadQteRes>d__.isGroupQte = isGroupQte;
		<PreloadQteRes>d__.<>1__state = -1;
		<PreloadQteRes>d__.<>t__builder.Start<CommonQteController.<PreloadQteRes>d__65>(ref <PreloadQteRes>d__);
		return <PreloadQteRes>d__.<>t__builder.Task;
	}

	// Token: 0x060131EB RID: 78315 RVA: 0x0054D2F0 File Offset: 0x0054B4F0
	public void ClearPreloadQteRes()
	{
		foreach (KeyValuePair<EUiViewName, CommonQteViewBase> keyValuePair in this.CommonQteViewMap)
		{
			Singleton<UiManager>.Instance.CloseView(keyValuePair.Key, null);
		}
		this.CommonQteViewMap.Clear();
		foreach (CommonQteItemBase commonQteItemBase in this.CommonQteItemMap.Values)
		{
			if (!commonQteItemBase.IsDestroyOrDestroying)
			{
				commonQteItemBase.Destroy(null);
			}
		}
		this.CommonQteItemMap.Clear();
		ModelBase<CommonQteModel>.Instance.ClearPreloadCache(null);
		Dictionary<int, CommonQteItemBase> commonQteItemMapDebug = this.CommonQteItemMapDebug;
		if (commonQteItemMapDebug != null)
		{
			commonQteItemMapDebug.Clear();
		}
		Dictionary<EUiViewName, CommonQteViewBase> commonQteViewMapDebug = this.CommonQteViewMapDebug;
		if (commonQteViewMapDebug == null)
		{
			return;
		}
		commonQteViewMapDebug.Clear();
	}

	// Token: 0x060131EC RID: 78316 RVA: 0x0054D3E8 File Offset: 0x0054B5E8
	private void AddFightInputBlock(EUiViewName viewName)
	{
		if (this.FightInputBlockViewName != null)
		{
			return;
		}
		this.FightInputBlockViewName = new EUiViewName?(viewName);
		ModelBase<InputDistributeModel>.Instance.AddNotAllowFightInputViewName(viewName);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAddNotAllowFightInputViewName);
	}

	// Token: 0x060131ED RID: 78317 RVA: 0x0054D420 File Offset: 0x0054B620
	private void RemoveFightInputBlock()
	{
		if (this.FightInputBlockViewName == null)
		{
			return;
		}
		ModelBase<InputDistributeModel>.Instance.RemoveNotAllowFightInputViewName(this.FightInputBlockViewName.Value);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRemoveNotAllowFightInputViewName);
		this.FightInputBlockViewName = null;
	}

	// Token: 0x060131EE RID: 78318 RVA: 0x0054D46C File Offset: 0x0054B66C
	private void ResumeFightInputBlock()
	{
		if (this.FightInputBlockViewName == null)
		{
			return;
		}
		if (!ModelBase<InputDistributeModel>.Instance.HasNotAllowFightInputViewIsOpen(this.FightInputBlockViewName.Value))
		{
			ModelBase<InputDistributeModel>.Instance.AddNotAllowFightInputViewName(this.FightInputBlockViewName.Value);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAddNotAllowFightInputViewName);
		}
	}

	// Token: 0x060131EF RID: 78319 RVA: 0x0054D4C4 File Offset: 0x0054B6C4
	[NullableContext(1)]
	private static List<EBattleUiChild> ConvertToBattleUiChildren(List<int> hideBattleUiChildren)
	{
		List<EBattleUiChild> list = new List<EBattleUiChild>(hideBattleUiChildren.Count);
		for (int i = 0; i < hideBattleUiChildren.Count; i++)
		{
			list.Add((EBattleUiChild)hideBattleUiChildren[i]);
		}
		return list;
	}

	// Token: 0x060131F0 RID: 78320 RVA: 0x0054D4FC File Offset: 0x0054B6FC
	private UniTask CloseViewSafe(EUiViewName viewName)
	{
		CommonQteController.<CloseViewSafe>d__71 <CloseViewSafe>d__;
		<CloseViewSafe>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CloseViewSafe>d__.viewName = viewName;
		<CloseViewSafe>d__.<>1__state = -1;
		<CloseViewSafe>d__.<>t__builder.Start<CommonQteController.<CloseViewSafe>d__71>(ref <CloseViewSafe>d__);
		return <CloseViewSafe>d__.<>t__builder.Task;
	}

	// Token: 0x060131F1 RID: 78321 RVA: 0x0054D540 File Offset: 0x0054B740
	[NullableContext(0)]
	private UniTask<int?> OpenViewSafe(EUiViewName viewName)
	{
		CommonQteController.<OpenViewSafe>d__72 <OpenViewSafe>d__;
		<OpenViewSafe>d__.<>t__builder = AsyncUniTaskMethodBuilder<int?>.Create();
		<OpenViewSafe>d__.viewName = viewName;
		<OpenViewSafe>d__.<>1__state = -1;
		<OpenViewSafe>d__.<>t__builder.Start<CommonQteController.<OpenViewSafe>d__72>(ref <OpenViewSafe>d__);
		return <OpenViewSafe>d__.<>t__builder.Task;
	}

	// Token: 0x060131F2 RID: 78322 RVA: 0x0054D584 File Offset: 0x0054B784
	[NullableContext(1)]
	private UniTask CreateItemSafe(CommonQteItemBase item, string itemName)
	{
		CommonQteController.<CreateItemSafe>d__73 <CreateItemSafe>d__;
		<CreateItemSafe>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateItemSafe>d__.item = item;
		<CreateItemSafe>d__.itemName = itemName;
		<CreateItemSafe>d__.<>1__state = -1;
		<CreateItemSafe>d__.<>t__builder.Start<CommonQteController.<CreateItemSafe>d__73>(ref <CreateItemSafe>d__);
		return <CreateItemSafe>d__.<>t__builder.Task;
	}

	// Token: 0x04009523 RID: 38179
	private const int EXTRA_EXPIRED_TIME = 5000;

	// Token: 0x04009524 RID: 38180
	private const int MAX_EXPIRED_TIME = 60000;

	// Token: 0x04009525 RID: 38181
	private CommonQteContextBase Context;

	// Token: 0x04009526 RID: 38182
	private bool IsInQteInternal;

	// Token: 0x04009527 RID: 38183
	private bool IsHideAllBattleUi;

	// Token: 0x04009528 RID: 38184
	private List<int> HideBattleUiChildren;

	// Token: 0x04009529 RID: 38185
	private TimerHandle ExpiredTimer;

	// Token: 0x0400952A RID: 38186
	private bool IsPreloadingQte;

	// Token: 0x0400952B RID: 38187
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly Dictionary<EUiViewName, CommonQteViewBase> CommonQteViewMap = new Dictionary<EUiViewName, CommonQteViewBase>();

	// Token: 0x0400952C RID: 38188
	[Nullable(1)]
	private readonly Dictionary<int, CommonQteItemBase> CommonQteItemMap = new Dictionary<int, CommonQteItemBase>();

	// Token: 0x0400952D RID: 38189
	private EUiViewName? FightInputBlockViewName;

	// Token: 0x0400952E RID: 38190
	private bool IsSetQteTimeDilation;

	// Token: 0x0400952F RID: 38191
	private EQteScreenEffectType ScreenEffectType;

	// Token: 0x04009530 RID: 38192
	private EffectScreenPlayData_C ScreenEffect;

	// Token: 0x04009531 RID: 38193
	private int ScreenEffectHandle = -1;

	// Token: 0x04009532 RID: 38194
	private TimerHandle ScreenEffectTimer;

	// Token: 0x04009533 RID: 38195
	private UMatineeCameraShake CameraShake;

	// Token: 0x04009534 RID: 38196
	private TimerHandle CameraShakeTimer;

	// Token: 0x04009535 RID: 38197
	public Dictionary<EUiViewName, CommonQteViewBase> CommonQteViewMapDebug;

	// Token: 0x04009536 RID: 38198
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, CommonQteItemBase> CommonQteItemMapDebug;

	// Token: 0x04009537 RID: 38199
	private bool IsSelfTriggeringTimeDilation;

	// Token: 0x04009538 RID: 38200
	[Nullable(1)]
	private readonly HashSet<int> TempHideCursorQteSet = new HashSet<int>
	{
		9035003,
		9035004,
		9035011,
		9035012,
		9035013,
		9035017,
		9035018
	};
}
