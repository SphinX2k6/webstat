using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.QuickTimeAction;
using CSharpScript.Game.Module.QuickTimeAction.Context;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026CA RID: 9930
[NullableContext(1)]
[Nullable(0)]
public class QtaCustomizationLimitedHoldItem : QtaItemBase
{
	// Token: 0x06013972 RID: 80242 RVA: 0x00577940 File Offset: 0x00575B40
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013973 RID: 80243 RVA: 0x00577AB4 File Offset: 0x00575CB4
	protected override UniTask OnBeforeStartAsync()
	{
		QtaCustomizationLimitedHoldItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QtaCustomizationLimitedHoldItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013974 RID: 80244 RVA: 0x00577AF8 File Offset: 0x00575CF8
	protected override void OnStart()
	{
		base.OnStart();
		for (int i = 5; i <= 9; i++)
		{
			base.InitTweenAnim(i);
		}
		base.SetUiActive(false);
	}

	// Token: 0x06013975 RID: 80245 RVA: 0x00577B28 File Offset: 0x00575D28
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		if (!this.IsQtaEnd)
		{
			QtaCustomizationContext qtaContext = this.QtaContext;
			if (qtaContext != null && qtaContext.IsActive())
			{
				ControllerBase<QtaController>.Instance.StopQta(this.QtaContext.HandleId, false);
			}
		}
		this.UnbindAction();
		this.QtaContext = null;
		this.QtaHandle = -1;
		this.QtaActions.Clear();
	}

	// Token: 0x06013976 RID: 80246 RVA: 0x00577B8C File Offset: 0x00575D8C
	protected override UniTask OnShowAsyncImplementImplement()
	{
		QtaCustomizationLimitedHoldItem.<OnShowAsyncImplementImplement>d__10 <OnShowAsyncImplementImplement>d__;
		<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnShowAsyncImplementImplement>d__.<>4__this = this;
		<OnShowAsyncImplementImplement>d__.<>1__state = -1;
		<OnShowAsyncImplementImplement>d__.<>t__builder.Start<QtaCustomizationLimitedHoldItem.<OnShowAsyncImplementImplement>d__10>(ref <OnShowAsyncImplementImplement>d__);
		return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06013977 RID: 80247 RVA: 0x00577BD0 File Offset: 0x00575DD0
	protected override UniTask OnHideAsyncImplementImplement()
	{
		QtaCustomizationLimitedHoldItem.<OnHideAsyncImplementImplement>d__11 <OnHideAsyncImplementImplement>d__;
		<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHideAsyncImplementImplement>d__.<>4__this = this;
		<OnHideAsyncImplementImplement>d__.<>1__state = -1;
		<OnHideAsyncImplementImplement>d__.<>t__builder.Start<QtaCustomizationLimitedHoldItem.<OnHideAsyncImplementImplement>d__11>(ref <OnHideAsyncImplementImplement>d__);
		return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06013978 RID: 80248 RVA: 0x00577C14 File Offset: 0x00575E14
	public override void SetQtaContext(QtaContextBase context)
	{
		QtaCustomizationContext qtaCustomizationContext = context as QtaCustomizationContext;
		if (qtaCustomizationContext == null)
		{
			return;
		}
		this.QtaHandle = context.HandleId;
		this.QtaContext = qtaCustomizationContext;
		this.QtaActions = (context.GetActions() ?? new List<string>());
		bool valid = ((QtaCustomizationLimitedHoldLogic)this.QtaContext.QtaCustomizationLogic).IsWithinRange();
		QtaCustomizationLimitedHoldItemBar bgBarLogic = this.BgBarLogic;
		if (bgBarLogic != null)
		{
			bgBarLogic.SetValid(valid);
		}
		this.RefreshValidState(valid, true);
		base.SetQtaActive(context);
	}

	// Token: 0x06013979 RID: 80249 RVA: 0x00577C8C File Offset: 0x00575E8C
	protected override void OnPlayQtaStart()
	{
		if (!this.IsQtaActive || this.IsQtaEnd || this.IsQtaPause || this.QtaContext == null)
		{
			return;
		}
		this.IsQtaPlayStart = true;
		base.SetUiActive(true);
		this.SetSelfActive(true);
		this.SetActive(true);
		this.BindAction();
		QtaCustomizationLimitedHoldLogic qtaCustomizationLimitedHoldLogic = this.QtaContext.QtaCustomizationLogic as QtaCustomizationLimitedHoldLogic;
		if (qtaCustomizationLimitedHoldLogic != null)
		{
			QtaCustomizationLimitedHoldItemBar bgBarLogic = this.BgBarLogic;
			if (bgBarLogic != null)
			{
				bgBarLogic.SetBgParam(qtaCustomizationLimitedHoldLogic.GetBgValue(0));
			}
			QtaCustomizationLimitedHoldItemBar bgBarLogic2 = this.BgBarLogic;
			if (bgBarLogic2 != null)
			{
				bgBarLogic2.SetBgPercent(qtaCustomizationLimitedHoldLogic.GetBgProgress(0));
			}
		}
		this.QtaContext.UpdateTime(0f);
		ControllerBase<QtaController>.Instance.SetExpiredTimer(this.QtaContext);
		this.OnTick(0f);
	}

	// Token: 0x0601397A RID: 80250 RVA: 0x00577D4C File Offset: 0x00575F4C
	private void RefreshValidState(bool valid, bool isStart = false)
	{
		if (isStart)
		{
			base.GetItem(2).SetUIActive(valid);
			base.GetItem(3).SetUIActive(!valid);
			return;
		}
		this.TweenAnimPlayer.StopTweenAnim((!valid) ? 6 : 7);
		this.TweenAnimPlayer.PlayTweenAnim(valid ? 6 : 7);
	}

	// Token: 0x0601397B RID: 80251 RVA: 0x00577D9E File Offset: 0x00575F9E
	private void SetSelfActive(bool active)
	{
		if (!active)
		{
			base.Destroy(null);
			return;
		}
		if (this.IsQtaEnd)
		{
			return;
		}
		this.IsQtaStart = true;
		this.CanInteractive = true;
	}

	// Token: 0x0601397C RID: 80252 RVA: 0x00577DC4 File Offset: 0x00575FC4
	protected override void RefreshOnBattleUiVisibleChanged()
	{
		QtaCustomizationContext qtaContext = this.QtaContext;
		bool flag;
		if (qtaContext == null)
		{
			flag = true;
		}
		else
		{
			EQtaSource? source = qtaContext.Source;
			EQtaSource eqtaSource = EQtaSource.Battle;
			flag = !(source.GetValueOrDefault() == eqtaSource & source != null);
		}
		if (flag)
		{
			return;
		}
		bool childVisible = ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.PanelQta);
		this.SetActive(childVisible);
	}

	// Token: 0x0601397D RID: 80253 RVA: 0x00577E18 File Offset: 0x00576018
	private void BindAction()
	{
		if (this.HasBindAction)
		{
			return;
		}
		this.HasBindAction = true;
		if (!this.IsMobile)
		{
			foreach (string text in this.QtaActions)
			{
				ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit(text, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
				if (text == "幻象1")
				{
					ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputInteract));
				}
			}
		}
	}

	// Token: 0x0601397E RID: 80254 RVA: 0x00577EBC File Offset: 0x005760BC
	private void UnbindAction()
	{
		if (!this.HasBindAction)
		{
			return;
		}
		this.HasBindAction = false;
		if (!this.IsMobile)
		{
			foreach (string text in this.QtaActions)
			{
				ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit(text, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
				if (text == "幻象1")
				{
					ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputInteract));
				}
			}
		}
	}

	// Token: 0x0601397F RID: 80255 RVA: 0x00577F60 File Offset: 0x00576160
	private void OnInputCallback(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification _)
	{
		if (!base.IsValidInput())
		{
			return;
		}
		this.OnInput(actionType);
	}

	// Token: 0x06013980 RID: 80256 RVA: 0x00577F74 File Offset: 0x00576174
	private void OnInputInteract(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification _)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			GamepadSwitchInteractData gamepadSwitchInteractData;
			if (instance == null)
			{
				gamepadSwitchInteractData = null;
			}
			else
			{
				SkillButtonUiGamepadDataBase gamepadData = instance.GamepadData;
				gamepadSwitchInteractData = ((gamepadData != null) ? gamepadData.SwitchInteractData : null);
			}
			GamepadSwitchInteractData gamepadSwitchInteractData2 = gamepadSwitchInteractData;
			if (gamepadSwitchInteractData2 == null || !gamepadSwitchInteractData2.IsSwitchInteractOpen || gamepadSwitchInteractData2.State != EGamepadSwitchInteractState.Explore || !this.QtaActions.Contains("幻象1"))
			{
				return;
			}
		}
		this.OnInputCallback(actionName, actionType, _);
	}

	// Token: 0x06013981 RID: 80257 RVA: 0x00577FDB File Offset: 0x005761DB
	private void OnInput(InputDistributeDefine.EActionType actionType)
	{
		if (this.QtaContext != null && this.QtaContext.IsActive() && this.QtaContext.IsPending())
		{
			this.QtaContext.QtaResponse(actionType == InputDistributeDefine.EActionType.Press);
		}
	}

	// Token: 0x06013982 RID: 80258 RVA: 0x0057800E File Offset: 0x0057620E
	public override void OnQtaMoment(EQtaMomentName qtaMoment)
	{
		if (qtaMoment == EQtaMomentName.EnterValidRange)
		{
			this.RefreshValidState(true, false);
		}
		else if (qtaMoment == EQtaMomentName.ExitValidRange)
		{
			this.RefreshValidState(false, false);
		}
		QtaCustomizationLimitedHoldItemBar bgBarLogic = this.BgBarLogic;
		if (bgBarLogic == null)
		{
			return;
		}
		bgBarLogic.SetValid(qtaMoment == EQtaMomentName.EnterValidRange);
	}

	// Token: 0x06013983 RID: 80259 RVA: 0x0057803E File Offset: 0x0057623E
	protected override void HandleQtaEnd()
	{
		if (this.IsQtaEnd)
		{
			return;
		}
		this.IsQtaEnd = true;
		this.UnbindAction();
		base.ClearTickTimer();
		this.SetSelfActive(false);
	}

	// Token: 0x06013984 RID: 80260 RVA: 0x00578063 File Offset: 0x00576263
	protected override void OnQtaPause()
	{
		this.UnbindAction();
		if (this.QtaContext != null)
		{
			ControllerBase<QtaController>.Instance.PauseQta(this.QtaContext.HandleId);
		}
	}

	// Token: 0x06013985 RID: 80261 RVA: 0x00578088 File Offset: 0x00576288
	protected override void OnQtaResume()
	{
		if (this.IsQtaPlayStart)
		{
			this.BindAction();
		}
		if (!this.IsQtaPlayStart)
		{
			base.PlayQtaStart();
		}
		if (this.QtaContext != null)
		{
			ControllerBase<QtaController>.Instance.ResumeQta(this.QtaContext.HandleId);
		}
	}

	// Token: 0x06013986 RID: 80262 RVA: 0x005780C4 File Offset: 0x005762C4
	protected override void OnTick(float delta)
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem == null || !rootItem.IsValid())
		{
			this.HandleQtaEnd();
			return;
		}
		if (!this.IsQtaStart || this.IsQtaEnd || this.IsQtaPause)
		{
			return;
		}
		if (this.QtaContext == null || this.QtaContext.IsInvalid())
		{
			this.HandleQtaEnd();
			return;
		}
		this.QtaContext.UpdateTime(delta);
		if (!this.QtaContext.IsInvalid())
		{
			this.TmpRotation.Yaw = this.QtaContext.GetProgress() * 360f;
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIRelativeRotation(this.TmpRotation);
			}
			QtaCustomizationLimitedHoldItemBar bgBarLogic = this.BgBarLogic;
			if (bgBarLogic == null)
			{
				return;
			}
			QtaCustomizationBaseLogic qtaCustomizationLogic = this.QtaContext.QtaCustomizationLogic;
			bgBarLogic.SetBgPercent((qtaCustomizationLogic != null) ? qtaCustomizationLogic.GetBgProgress(0) : 0f);
		}
	}

	// Token: 0x04009883 RID: 39043
	private List<string> QtaActions = new List<string>();

	// Token: 0x04009884 RID: 39044
	private bool HasBindAction;

	// Token: 0x04009885 RID: 39045
	[Nullable(2)]
	private QtaCustomizationContext QtaContext;

	// Token: 0x04009886 RID: 39046
	[Nullable(2)]
	private QtaCustomizationLimitedHoldItemBar BgBarLogic;

	// Token: 0x04009887 RID: 39047
	private FRotator TmpRotation = new FRotator();

	// Token: 0x02008A80 RID: 35456
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402EB7A RID: 191354
		public const int PnlBgBar = 0;

		// Token: 0x0402EB7B RID: 191355
		public const int BgItem = 1;

		// Token: 0x0402EB7C RID: 191356
		public const int Arrow1 = 2;

		// Token: 0x0402EB7D RID: 191357
		public const int Arrow2 = 3;

		// Token: 0x0402EB7E RID: 191358
		public const int PnlArrow = 4;

		// Token: 0x0402EB7F RID: 191359
		public const int AniIn = 5;

		// Token: 0x0402EB80 RID: 191360
		public const int AniToYellow = 6;

		// Token: 0x0402EB81 RID: 191361
		public const int AniToBlue = 7;

		// Token: 0x0402EB82 RID: 191362
		public const int AniSuccessOut = 8;

		// Token: 0x0402EB83 RID: 191363
		public const int AniNormalOut = 9;
	}
}
