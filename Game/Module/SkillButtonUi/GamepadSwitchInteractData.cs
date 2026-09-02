using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F79 RID: 20345
	[NullableContext(1)]
	[Nullable(0)]
	public class GamepadSwitchInteractData
	{
		// Token: 0x06034790 RID: 214928 RVA: 0x00D2194C File Offset: 0x00D1FB4C
		public void Init(ESkillButtonGamepadDataType gamepadDataType, string exploreActionName)
		{
			this.GamepadDataType = gamepadDataType;
			this.ExploreActionName = exploreActionName;
			this.SwitchTime = ConfigCommonParamById.GetIntConfig("SwitchInteractTime").GetValueOrDefault(500);
		}

		// Token: 0x06034791 RID: 214929 RVA: 0x00D21984 File Offset: 0x00D1FB84
		public void SetInteractExist(bool exist, EGamepadInteractExistReason reason)
		{
			if (exist)
			{
				this.InteractExistReason.Add(reason);
			}
			else
			{
				this.InteractExistReason.Remove(reason);
			}
			this.SetHasInteract(this.InteractExistReason.Count > 0);
		}

		// Token: 0x06034792 RID: 214930 RVA: 0x00D219BC File Offset: 0x00D1FBBC
		public void RefreshSwitchInteractOpen(bool isInit = false)
		{
			bool gamepadOperationPreferences = ModelBase<MenuModel>.Instance.GetGamepadOperationPreferences();
			if (gamepadOperationPreferences != this.IsSwitchInteractOpen)
			{
				this.IsSwitchInteractOpen = gamepadOperationPreferences;
				if (!isInit)
				{
					Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleUiSwitchInteractOpenChanged, gamepadOperationPreferences);
				}
				this.SetHasInteract(this.InteractExistReason.Count > 0);
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			}
		}

		// Token: 0x06034793 RID: 214931 RVA: 0x00D21A18 File Offset: 0x00D1FC18
		public void InputInteractButton(bool bPress)
		{
			if (bPress)
			{
				if (this.IsSwitchInteractOpen && Singleton<Info>.Instance.IsInGamepad() && this.State == EGamepadSwitchInteractState.Explore)
				{
					this.IsPressExplore = true;
					ControllerBase<InputDistributeController>.Instance.InputAction(this.ExploreActionName, true);
					return;
				}
			}
			else if (this.IsPressExplore)
			{
				this.IsPressExplore = false;
				ControllerBase<InputDistributeController>.Instance.InputAction(this.ExploreActionName, false);
			}
		}

		// Token: 0x06034794 RID: 214932 RVA: 0x00D21A80 File Offset: 0x00D1FC80
		private void SetHasInteract(bool value)
		{
			if (!this.IsSwitchInteractOpen)
			{
				this.SetState(EGamepadSwitchInteractState.Interact);
				return;
			}
			if (value)
			{
				EGamepadSwitchInteractState state = this.State;
				if (state != EGamepadSwitchInteractState.Interact && state - EGamepadSwitchInteractState.Switching <= 1)
				{
					this.DestroySwitchTimer();
					this.SetState(EGamepadSwitchInteractState.Interact);
					return;
				}
			}
			else
			{
				EGamepadSwitchInteractState state = this.State;
				if (state != EGamepadSwitchInteractState.Interact)
				{
					int num = state - EGamepadSwitchInteractState.Switching;
					return;
				}
				this.SetState(EGamepadSwitchInteractState.Switching);
				this.DestroySwitchTimer();
				this.SwitchTimer = TimerSystem.Instance.Delay(new TTimerAction(this.OnSwitchFinish), (float)this.SwitchTime, null, null, true, 1f);
			}
		}

		// Token: 0x06034795 RID: 214933 RVA: 0x00D21B07 File Offset: 0x00D1FD07
		private void SetState(EGamepadSwitchInteractState state)
		{
			if (this.State == state)
			{
				return;
			}
			this.State = state;
			Singleton<EventSystem>.Instance.Emit(EEventName.BattleUiSwitchInteractStateChanged);
		}

		// Token: 0x06034796 RID: 214934 RVA: 0x00D21B2A File Offset: 0x00D1FD2A
		private void OnSwitchFinish(float _)
		{
			this.SetState(EGamepadSwitchInteractState.Explore);
			this.SwitchTimer = null;
		}

		// Token: 0x06034797 RID: 214935 RVA: 0x00D21B3A File Offset: 0x00D1FD3A
		private void DestroySwitchTimer()
		{
			if (this.SwitchTimer != null)
			{
				this.SwitchTimer.Remove();
				this.SwitchTimer = null;
			}
		}

		// Token: 0x0401E39C RID: 123804
		public ESkillButtonGamepadDataType GamepadDataType;

		// Token: 0x0401E39D RID: 123805
		public bool IsSwitchInteractOpen;

		// Token: 0x0401E39E RID: 123806
		public EGamepadSwitchInteractState State;

		// Token: 0x0401E39F RID: 123807
		private readonly HashSet<EGamepadInteractExistReason> InteractExistReason = new HashSet<EGamepadInteractExistReason>();

		// Token: 0x0401E3A0 RID: 123808
		public int SwitchTime;

		// Token: 0x0401E3A1 RID: 123809
		[Nullable(2)]
		private TimerHandle SwitchTimer;

		// Token: 0x0401E3A2 RID: 123810
		private bool IsPressExplore;

		// Token: 0x0401E3A3 RID: 123811
		private string ExploreActionName = "幻象1";
	}
}
