using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Qte.View
{
	// Token: 0x02005348 RID: 21320
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class CommonQteViewBase<[Nullable(0)] TContextType> : CommonQteViewBase where TContextType : CommonQteContextBase
	{
		// Token: 0x0603661B RID: 222747 RVA: 0x00DB59A9 File Offset: 0x00DB3BA9
		protected CommonQteViewBase(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603661C RID: 222748 RVA: 0x00DB59C4 File Offset: 0x00DB3BC4
		protected override void OnRegisterComponent()
		{
			this.IsMobile = Singleton<Info>.Instance.IsInTouch();
		}

		// Token: 0x0603661D RID: 222749 RVA: 0x00DB59D8 File Offset: 0x00DB3BD8
		protected override void OnStart()
		{
			UUIItem floatUnit = Singleton<UiLayer>.Instance.GetFloatUnit(ELayerType.BattleFloat, 2);
			if (floatUnit != null)
			{
				base.SetParentUiItem(floatUnit);
			}
		}

		// Token: 0x0603661E RID: 222750 RVA: 0x00DB5A00 File Offset: 0x00DB3C00
		protected override void OnBeforeDestroy()
		{
			this.UnbindEvents();
			this.UnbindAction();
			if (!this.IsQteEnd)
			{
				TContextType tcontextType = this.CommonQteContext;
				if (tcontextType != null && tcontextType.IsActive())
				{
					ControllerBase<CommonQteController>.Instance.StopQte(this.CommonQteContext.HandleId);
				}
			}
			this.CommonQteContext = default(TContextType);
			this.QteHandle = -1;
			this.QteAction = "";
		}

		// Token: 0x0603661F RID: 222751 RVA: 0x00DB5A74 File Offset: 0x00DB3C74
		protected void BindAction()
		{
			if (this.HasBindAction)
			{
				return;
			}
			this.HasBindAction = true;
			if (!this.IsMobile && this.IsUseBaseAction() && !string.IsNullOrEmpty(this.QteAction))
			{
				ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit(this.QteAction, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
				if (this.QteAction == "幻象1")
				{
					ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputInteract));
				}
			}
			this.OnBindAction();
		}

		// Token: 0x06036620 RID: 222752 RVA: 0x00DB5B00 File Offset: 0x00DB3D00
		protected void UnbindAction()
		{
			if (!this.HasBindAction)
			{
				return;
			}
			this.HasBindAction = false;
			if (!this.IsMobile && this.IsUseBaseAction() && !string.IsNullOrEmpty(this.QteAction))
			{
				ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit(this.QteAction, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
				if (this.QteAction == "幻象1")
				{
					ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputInteract));
				}
			}
			this.OnUnbindAction();
		}

		// Token: 0x06036621 RID: 222753 RVA: 0x00DB5B89 File Offset: 0x00DB3D89
		protected virtual void OnBindAction()
		{
		}

		// Token: 0x06036622 RID: 222754 RVA: 0x00DB5B8B File Offset: 0x00DB3D8B
		protected virtual void OnUnbindAction()
		{
		}

		// Token: 0x06036623 RID: 222755 RVA: 0x00DB5B8D File Offset: 0x00DB3D8D
		protected virtual bool IsUseBaseAction()
		{
			return true;
		}

		// Token: 0x06036624 RID: 222756 RVA: 0x00DB5B90 File Offset: 0x00DB3D90
		protected void OnInputCallback(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (!this.IsValidInput())
			{
				return;
			}
			if (actionType == InputDistributeDefine.EActionType.Press)
			{
				this.OnInputPress();
				return;
			}
			if (actionType == InputDistributeDefine.EActionType.Release)
			{
				this.OnInputRelease();
			}
		}

		// Token: 0x06036625 RID: 222757 RVA: 0x00DB5BB0 File Offset: 0x00DB3DB0
		private void OnInputInteract(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
				bool flag;
				if (instance == null)
				{
					flag = false;
				}
				else
				{
					SkillButtonUiGamepadDataBase gamepadData = instance.GamepadData;
					flag = ((gamepadData != null) ? new bool?(gamepadData.SwitchInteractData.IsSwitchInteractOpen) : null).GetValueOrDefault();
				}
				if (flag)
				{
					SkillButtonUiModel instance2 = ModelBase<SkillButtonUiModel>.Instance;
					bool flag2;
					if (instance2 == null)
					{
						flag2 = false;
					}
					else
					{
						SkillButtonUiGamepadDataBase gamepadData2 = instance2.GamepadData;
						flag2 = (((gamepadData2 != null) ? new EGamepadSwitchInteractState?(gamepadData2.SwitchInteractData.State) : null).GetValueOrDefault() == EGamepadSwitchInteractState.Explore);
					}
					if (flag2 && this.QteAction == "幻象1")
					{
						this.OnInputCallback(this.QteAction, actionType, inputIdentification);
						return;
					}
				}
			}
		}

		// Token: 0x06036626 RID: 222758 RVA: 0x00DB5C62 File Offset: 0x00DB3E62
		protected virtual void OnInputPress()
		{
		}

		// Token: 0x06036627 RID: 222759 RVA: 0x00DB5C64 File Offset: 0x00DB3E64
		protected virtual void OnInputRelease()
		{
		}

		// Token: 0x06036628 RID: 222760 RVA: 0x00DB5C66 File Offset: 0x00DB3E66
		public override void OnInputTest()
		{
			this.OnInputPress();
		}

		// Token: 0x06036629 RID: 222761 RVA: 0x00DB5C6E File Offset: 0x00DB3E6E
		protected override void OnAfterShow()
		{
			base.OnAfterShow();
			this.ResumeQte(false);
		}

		// Token: 0x0603662A RID: 222762 RVA: 0x00DB5C7D File Offset: 0x00DB3E7D
		protected override void OnBeforeHide()
		{
			base.OnBeforeHide();
			this.PauseQte();
		}

		// Token: 0x0603662B RID: 222763 RVA: 0x00DB5C8C File Offset: 0x00DB3E8C
		private void BindEvents()
		{
			if (this.IsBindEvents)
			{
				return;
			}
			this.IsBindEvents = true;
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.DisableCustomInputData, this.ViewInfo.Name);
			ModelBase<BattleUiModel>.Instance.ChildViewData.AddCallback(EBattleUiChild.PanelQTE, new Action(this.OnBattleUiVisibleChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnTriggerUiTimeDilation));
			Singleton<EventSystem>.Instance.Add(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd));
		}

		// Token: 0x0603662C RID: 222764 RVA: 0x00DB5D1C File Offset: 0x00DB3F1C
		private void UnbindEvents()
		{
			if (!this.IsBindEvents)
			{
				return;
			}
			this.IsBindEvents = false;
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.EnableCacheCustomInputData, this.ViewInfo.Name);
			ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveCallback(EBattleUiChild.PanelQTE, new Action(this.OnBattleUiVisibleChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnTriggerUiTimeDilation));
			Singleton<EventSystem>.Instance.Remove(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd));
		}

		// Token: 0x0603662D RID: 222765 RVA: 0x00DB5DAC File Offset: 0x00DB3FAC
		private void OnCommonQteEnd(int? handleId)
		{
			int qteHandle = this.QteHandle;
			int? num = handleId;
			if (!(qteHandle == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			this.HandleQteEnd();
		}

		// Token: 0x0603662E RID: 222766 RVA: 0x00DB5DDC File Offset: 0x00DB3FDC
		private void OnBattleUiVisibleChanged()
		{
			if (this.CommonQteContext == null)
			{
				return;
			}
			EQteSource? source = this.CommonQteContext.Source;
			EQteSource eqteSource = EQteSource.Battle;
			if (!(source.GetValueOrDefault() == eqteSource & source != null))
			{
				return;
			}
			bool childVisible = ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.PanelQTE);
			if (base.GetActive() != childVisible)
			{
				this.SetActive(childVisible);
			}
		}

		// Token: 0x0603662F RID: 222767 RVA: 0x00DB5E41 File Offset: 0x00DB4041
		private void OnTriggerUiTimeDilation()
		{
			if (this.IsQteEnd)
			{
				return;
			}
			if (ControllerBase<CommonQteController>.Instance.IsSelfTriggeringTimeDilationChange())
			{
				return;
			}
			if (Singleton<Time>.Instance.TimeDilation == 0f)
			{
				this.PauseQte();
				return;
			}
			this.ResumeQte(true);
		}

		// Token: 0x06036630 RID: 222768 RVA: 0x00DB5E78 File Offset: 0x00DB4078
		protected void PauseQte()
		{
			if (this.IsQtePause || this.IsQteEnd)
			{
				return;
			}
			this.IsQtePause = true;
			if (this.IsQteActive)
			{
				this.OnQtePause();
			}
		}

		// Token: 0x06036631 RID: 222769 RVA: 0x00DB5EA0 File Offset: 0x00DB40A0
		protected void ResumeQte(bool delay = false)
		{
			if (!this.IsQtePause || this.IsQteEnd)
			{
				return;
			}
			this.IsQtePause = false;
			if (this.IsQteActive)
			{
				if (delay)
				{
					TimerSystem.Instance.Next(delegate(float _)
					{
						UUIItem rootItem = this.RootItem;
						if (rootItem == null || !rootItem.IsValid())
						{
							return;
						}
						this.OnQteResume();
					}, null, null);
					return;
				}
				this.OnQteResume();
			}
		}

		// Token: 0x06036632 RID: 222770 RVA: 0x00DB5EF0 File Offset: 0x00DB40F0
		protected virtual void OnQtePause()
		{
			this.UnbindAction();
			if (this.CommonQteContext != null)
			{
				ControllerBase<CommonQteController>.Instance.PauseQte(this.CommonQteContext.HandleId);
			}
		}

		// Token: 0x06036633 RID: 222771 RVA: 0x00DB5F20 File Offset: 0x00DB4120
		protected virtual void OnQteResume()
		{
			if (this.IsQteActive)
			{
				this.BindAction();
			}
			if (this.CommonQteContext != null)
			{
				ControllerBase<CommonQteController>.Instance.ResumeQte(this.CommonQteContext.HandleId);
			}
			if (!this.IsQtePlayStart)
			{
				this.PlayQteStart();
			}
		}

		// Token: 0x06036634 RID: 222772 RVA: 0x00DB5F70 File Offset: 0x00DB4170
		protected void HandleQteEnd()
		{
			if (this.IsQteEnd)
			{
				return;
			}
			this.IsQteEnd = true;
			this.OnHandleQteEnd();
			this.UnbindAction();
		}

		// Token: 0x06036635 RID: 222773 RVA: 0x00DB5F8E File Offset: 0x00DB418E
		protected virtual void OnHandleQteEnd()
		{
		}

		// Token: 0x06036636 RID: 222774 RVA: 0x00DB5F90 File Offset: 0x00DB4190
		protected bool IsValidInput()
		{
			return this.IsQteInteractive && !this.IsQteEnd && !this.IsQtePause;
		}

		// Token: 0x06036637 RID: 222775 RVA: 0x00DB5FB0 File Offset: 0x00DB41B0
		public override void SetQteContext(CommonQteContextBase context)
		{
			if (!this.IsContextMatched(context))
			{
				return;
			}
			this.QteHandle = context.HandleId;
			this.CommonQteContext = (TContextType)((object)context);
			string action = context.GetAction(null);
			if (!string.IsNullOrEmpty(action))
			{
				this.QteAction = action;
				this.OnRefreshActionUi(action);
			}
			this.LoopDuration = (float)Math.Max(0.0, (double)context.Duration * Singleton<TimeUtil>.Instance.Millisecond);
			this.IsQteInteractive = false;
			this.IsShowBorder = false;
			object uiConfig = context.GetUiConfig();
			if (uiConfig != null)
			{
				this.ApplyBaseUiConfig(uiConfig);
			}
			this.TryApplyQteUiConfig(uiConfig);
			this.TryApplyQteIcon(context);
			this.RefreshUiOffset();
			this.SetQteActive(context);
			this.PlayQteStart();
		}

		// Token: 0x06036638 RID: 222776 RVA: 0x00DB606C File Offset: 0x00DB426C
		private void ApplyBaseUiConfig(object uiConfig)
		{
			Type type = uiConfig.GetType();
			PropertyInfo property = type.GetProperty("InteractiveTiming");
			if (property != null)
			{
				object value = property.GetValue(uiConfig);
				if (value is TEnumAsByte<ECommonQteInteractiveTiming>)
				{
					TEnumAsByte<ECommonQteInteractiveTiming> left = (TEnumAsByte<ECommonQteInteractiveTiming>)value;
					this.IsQteInteractive = (left == ECommonQteInteractiveTiming.始终);
				}
			}
			PropertyInfo property2 = type.GetProperty("IsShowBorder");
			if (property2 != null)
			{
				object value2 = property2.GetValue(uiConfig);
				if (value2 is bool)
				{
					bool isShowBorder = (bool)value2;
					this.IsShowBorder = isShowBorder;
				}
			}
		}

		// Token: 0x06036639 RID: 222777 RVA: 0x00DB60F4 File Offset: 0x00DB42F4
		protected virtual bool IsContextMatched(CommonQteContextBase context)
		{
			return context is TContextType;
		}

		// Token: 0x0603663A RID: 222778 RVA: 0x00DB60FF File Offset: 0x00DB42FF
		protected virtual void OnRefreshActionUi(string action)
		{
		}

		// Token: 0x0603663B RID: 222779 RVA: 0x00DB6101 File Offset: 0x00DB4301
		[NullableContext(2)]
		protected virtual void TryApplyQteUiConfig(object uiConfig)
		{
		}

		// Token: 0x0603663C RID: 222780 RVA: 0x00DB6104 File Offset: 0x00DB4304
		protected virtual void TryApplyQteIcon(CommonQteContextBase context)
		{
			IQteResource resource = context.Resource;
			ULGUITexturePackerSpriteData ulguitexturePackerSpriteData = (resource != null) ? resource.Icon : null;
			if (ulguitexturePackerSpriteData != null)
			{
				this.OnRefreshIcon(ulguitexturePackerSpriteData);
			}
		}

		// Token: 0x0603663D RID: 222781 RVA: 0x00DB612E File Offset: 0x00DB432E
		protected virtual void OnRefreshIcon(ULGUITexturePackerSpriteData sprite)
		{
		}

		// Token: 0x0603663E RID: 222782 RVA: 0x00DB6130 File Offset: 0x00DB4330
		protected void SetQteActive(CommonQteContextBase context)
		{
			this.IsQteActive = true;
			if (context.Source.GetValueOrDefault() == EQteSource.CG)
			{
				UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.VideoView);
				if (viewByName != null)
				{
					UUIItem rootItem = viewByName.GetRootItem();
					if (rootItem != null)
					{
						base.GetRootItem().SetUIParent(rootItem, false);
					}
				}
			}
			else
			{
				EQteSource? source = context.Source;
				EQteSource eqteSource = EQteSource.Battle;
				if (source.GetValueOrDefault() == eqteSource & source != null)
				{
					bool childVisible = ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.PanelQTE);
					if (base.GetActive() != childVisible)
					{
						this.SetActive(childVisible);
					}
					if (!childVisible || Singleton<Time>.Instance.TimeDilation == 0f)
					{
						this.PauseQte();
					}
				}
				else if (context.Source.GetValueOrDefault() == EQteSource.Level && Singleton<Time>.Instance.TimeDilation == 0f)
				{
					this.PauseQte();
				}
			}
			this.BindEvents();
			if (!this.IsQtePause)
			{
				this.BindAction();
			}
		}

		// Token: 0x0603663F RID: 222783 RVA: 0x00DB6220 File Offset: 0x00DB4420
		public unsafe override void PlayQteStart()
		{
			Singleton<Log>.Instance.Info(ELogModule.CommonQte, ELogAuthor.WWJ, "[CommonQteViewBase] PlayQteStart", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (this.IsQtePlayStart || !this.IsQteActive || this.IsQteEnd || this.IsQtePause || this.CommonQteContext == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CommonQte;
				ELogAuthor author = ELogAuthor.WWJ;
				string message = "[CommonQteViewBase] PlayQteStart Failed";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsQtePlayStart", this.IsQtePlayStart);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsQteActive", this.IsQteActive);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("IsQteEnd", this.IsQteEnd);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("IsQtePause", this.IsQtePause);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4);
				string item = "CommonQteContext";
				TContextType tcontextType = this.CommonQteContext;
				ptr = new ValueTuple<string, object>(item, (tcontextType != null) ? new int?(tcontextType.HandleId) : null);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
				return;
			}
			this.IsQtePlayStart = true;
			this.OnPlayQteStart();
			ControllerBase<CommonQteController>.Instance.SetExpiredTimer(this.CommonQteContext);
		}

		// Token: 0x06036640 RID: 222784 RVA: 0x00DB638D File Offset: 0x00DB458D
		protected virtual void OnPlayQteStart()
		{
		}

		// Token: 0x06036641 RID: 222785 RVA: 0x00DB6390 File Offset: 0x00DB4590
		protected override void OnTick(float delta)
		{
			if (!this.IsQteStart || this.IsQteEnd || this.IsQtePause)
			{
				return;
			}
			if (this.CommonQteContext == null || this.CommonQteContext.IsInvalid())
			{
				this.HandleQteEnd();
				return;
			}
			this.CommonQteContext.UpdateTime(delta);
			if (this.CommonQteContext != null)
			{
				this.OnTickQteView(delta);
			}
			CommonQteModel instance = ModelBase<CommonQteModel>.Instance;
			if (instance != null && instance.IsRefreshMode)
			{
				this.RefreshUiOffset();
			}
		}

		// Token: 0x06036642 RID: 222786 RVA: 0x00DB641A File Offset: 0x00DB461A
		protected virtual void OnTickQteView(float delta)
		{
		}

		// Token: 0x06036643 RID: 222787 RVA: 0x00DB641C File Offset: 0x00DB461C
		protected virtual void RefreshUiOffset()
		{
		}

		// Token: 0x0401F460 RID: 128096
		protected bool IsMobile;

		// Token: 0x0401F461 RID: 128097
		protected bool IsQteActive;

		// Token: 0x0401F462 RID: 128098
		protected bool IsQtePlayStart;

		// Token: 0x0401F463 RID: 128099
		protected bool IsQteStart;

		// Token: 0x0401F464 RID: 128100
		protected bool IsQteEnd;

		// Token: 0x0401F465 RID: 128101
		protected bool IsQteInteractive;

		// Token: 0x0401F466 RID: 128102
		protected bool IsQtePause;

		// Token: 0x0401F467 RID: 128103
		protected bool HasBindAction;

		// Token: 0x0401F468 RID: 128104
		protected string QteAction = "";

		// Token: 0x0401F469 RID: 128105
		protected int QteHandle = -1;

		// Token: 0x0401F46A RID: 128106
		[Nullable(2)]
		protected TContextType CommonQteContext;

		// Token: 0x0401F46B RID: 128107
		protected float LoopDuration;

		// Token: 0x0401F46C RID: 128108
		protected bool IsShowBorder;

		// Token: 0x0401F46D RID: 128109
		protected bool IsBindEvents;
	}
}
