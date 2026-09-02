using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A19 RID: 18969
	[NullableContext(1)]
	[Nullable(0)]
	public class ViewHotKeyHandleRoulette : ViewHotKeyHandle
	{
		// Token: 0x06031908 RID: 203016 RVA: 0x00C5A46B File Offset: 0x00C5866B
		public ViewHotKeyHandleRoulette(IOpenAndCloseViewHotKey parameters) : base(parameters)
		{
		}

		// Token: 0x06031909 RID: 203017 RVA: 0x00C5A474 File Offset: 0x00C58674
		public override void Bind()
		{
			this.Init();
			ControllerBase<InputDistributeController>.Instance.BindAction(this.ActionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnRouletteInputAction));
			Singleton<EventSystem>.Instance.Add(EEventName.OnActionKeyChanged, new Action<string>(this.OnActionKeyChanged));
		}

		// Token: 0x0603190A RID: 203018 RVA: 0x00C5A4B4 File Offset: 0x00C586B4
		protected override void UnBind()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction(this.ActionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnRouletteInputAction));
			if (this.NeedAxisFlag)
			{
				ControllerBase<InputDistributeController>.Instance.UnBindAxes(new <>z__ReadOnlyArray<string>(new string[]
				{
					"LookUp",
					"Turn"
				}), new TInputHandle<float>(this.OnRouletteInputAxis));
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActionKeyChanged, new Action<string>(this.OnActionKeyChanged));
		}

		// Token: 0x0603190B RID: 203019 RVA: 0x00C5A532 File Offset: 0x00C58732
		private void OnActionKeyChanged(string actionName)
		{
			if (!string.IsNullOrEmpty(this.ActionName) && this.ActionName == actionName)
			{
				this.SetNeedAxisFlag(this.IsActionCombinationAxisMainKey());
			}
		}

		// Token: 0x0603190C RID: 203020 RVA: 0x00C5A55C File Offset: 0x00C5875C
		private void Init()
		{
			this.AxisDeadZone = ConfigCommonParamById.GetFloatConfig("Roulette_Gamepad_Open_DeadLimit").GetValueOrDefault();
			this.SetNeedAxisFlag(this.IsActionCombinationAxisMainKey());
		}

		// Token: 0x0603190D RID: 203021 RVA: 0x00C5A590 File Offset: 0x00C58790
		private bool IsActionCombinationAxisMainKey()
		{
			if (this.ActionName == null)
			{
				return false;
			}
			InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(this.ActionName);
			if (actionBinding == null)
			{
				return false;
			}
			List<string> list = new List<string>();
			actionBinding.GetGamepadKeyNameList(list);
			return list.Count == 1 && Singleton<InputSettingsManager>.Instance.IsCombinationAxisMainKey(list[0]);
		}

		// Token: 0x0603190E RID: 203022 RVA: 0x00C5A5E8 File Offset: 0x00C587E8
		private void SetNeedAxisFlag(bool flag)
		{
			if (flag == this.NeedAxisFlag)
			{
				return;
			}
			if (flag)
			{
				ControllerBase<InputDistributeController>.Instance.BindAxes(new <>z__ReadOnlyArray<string>(new string[]
				{
					"LookUp",
					"Turn"
				}), new TInputHandle<float>(this.OnRouletteInputAxis));
			}
			else
			{
				ControllerBase<InputDistributeController>.Instance.UnBindAxes(new <>z__ReadOnlyArray<string>(new string[]
				{
					"LookUp",
					"Turn"
				}), new TInputHandle<float>(this.OnRouletteInputAxis));
			}
			this.NeedAxisFlag = flag;
		}

		// Token: 0x0603190F RID: 203023 RVA: 0x00C5A670 File Offset: 0x00C58870
		private void OnRouletteInputAxis(string axisName, float value, InputIdentification inputIdentification)
		{
			if (!this.NeedAxisFlag || !this.ActionFlag)
			{
				return;
			}
			if (value < -this.AxisDeadZone || value > this.AxisDeadZone)
			{
				this.AxisFlag = true;
				base.OnInputAction(this.ActionName, InputDistributeDefine.EActionType.Press, inputIdentification);
				this.AxisFlag = false;
				this.ActionFlag = false;
			}
		}

		// Token: 0x06031910 RID: 203024 RVA: 0x00C5A6C4 File Offset: 0x00C588C4
		private void OnRouletteInputAction(string name, InputDistributeDefine.EActionType value, InputIdentification inputIdentification)
		{
			this.ActionFlag = (value == InputDistributeDefine.EActionType.Press);
			base.OnInputAction(name, value, inputIdentification);
		}

		// Token: 0x06031911 RID: 203025 RVA: 0x00C5A6D9 File Offset: 0x00C588D9
		protected override bool SpecialConditionCheck()
		{
			return !Singleton<Info>.Instance.IsInGamepad() || !this.NeedAxisFlag || this.AxisFlag;
		}

		// Token: 0x06031912 RID: 203026 RVA: 0x00C5A6FC File Offset: 0x00C588FC
		protected override void OnOpenViewImplement()
		{
			RouletteMainViewProxyBase currentRouletteMainViewProxy = ControllerBase<RouletteController>.Instance.GetCurrentRouletteMainViewProxy();
			currentRouletteMainViewProxy.ActionType = (ERouletteActionType)Convert.ToInt32(this.ViewParam[0]);
			ControllerBase<RouletteController>.Instance.OpenRouletteMainView(currentRouletteMainViewProxy);
		}

		// Token: 0x0401CDD5 RID: 118229
		private bool ActionFlag;

		// Token: 0x0401CDD6 RID: 118230
		private bool AxisFlag;

		// Token: 0x0401CDD7 RID: 118231
		private bool NeedAxisFlag;

		// Token: 0x0401CDD8 RID: 118232
		private float AxisDeadZone;
	}
}
