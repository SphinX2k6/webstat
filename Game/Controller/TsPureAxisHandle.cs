using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Controller
{
	// Token: 0x0200705A RID: 28762
	[NullableContext(2)]
	[Nullable(0)]
	public class TsPureAxisHandle
	{
		// Token: 0x06045A55 RID: 285269 RVA: 0x012332BE File Offset: 0x012314BE
		[NullableContext(1)]
		public void Initialize(TsBasePlayerController playerController)
		{
			this.PlayerController = playerController;
			this.OnInputStat = Stat.Create("TsPureAxisHandle.OnInputAxis", "", "STATGROUP_KuroBattle");
		}

		// Token: 0x06045A56 RID: 285270 RVA: 0x012332E4 File Offset: 0x012314E4
		public void Reset()
		{
			this.PlayerController = null;
			this.AxisName = null;
			this.OnInputAxisCallback = null;
			if (this.OnInputAxisDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.OnInputAxis));
				this.OnInputAxisDelegate = null;
			}
			if (this.OnAlwaysInputAxisDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.OnAlwaysInputAxis));
				this.OnAlwaysInputAxisDelegate = null;
			}
		}

		// Token: 0x06045A57 RID: 285271 RVA: 0x01233348 File Offset: 0x01231548
		[NullableContext(1)]
		public void AddAxisBinding(string axisName, Action<string, float, bool> onInputAxis)
		{
			if (onInputAxis == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Controller;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "添加Axis输入绑定时，回调不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisName", axisName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.AxisName = axisName;
			this.OnInputAxisCallback = onInputAxis;
			if (TsPureAxisHandle.OptimizeTickAxisName.Contains(axisName))
			{
				if (this.OnInputAxisDelegate == null)
				{
					this.OnInputAxisDelegate = global::DelegateUtils.ToManualReleaseDelegate<FAxisBindingDelegate>(new Action<float>(this.OnInputAxis));
				}
				UKuroInputDelegateLibrary.RegisterAxisBinding(FNameUtil.GetDynamicFName(axisName) ?? FName.NAME_None, this.PlayerController, this.OnInputAxisDelegate);
				return;
			}
			if (this.OnAlwaysInputAxisDelegate == null)
			{
				this.OnAlwaysInputAxisDelegate = global::DelegateUtils.ToManualReleaseDelegate<FAxisBindingDelegate>(new Action<float>(this.OnAlwaysInputAxis));
			}
			UKuroInputDelegateLibrary.RegisterAxisBinding(FNameUtil.GetDynamicFName(axisName) ?? FName.NAME_None, this.PlayerController, this.OnAlwaysInputAxisDelegate);
		}

		// Token: 0x06045A58 RID: 285272 RVA: 0x0123343B File Offset: 0x0123163B
		private void OnInputAxis(float value)
		{
			this.OnInputAxisCallback(this.AxisName, value, false);
		}

		// Token: 0x06045A59 RID: 285273 RVA: 0x01233450 File Offset: 0x01231650
		private void OnAlwaysInputAxis(float value)
		{
			this.OnInputAxisCallback(this.AxisName, value, true);
		}

		// Token: 0x04026E11 RID: 159249
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly List<string> OptimizeTickAxisName = new List<string>
		{
			"LookUp",
			"LookUpRate",
			"MoveForward",
			"MoveRight",
			"Turn",
			"Zoom",
			"MouseMove",
			"WheelAxis"
		};

		// Token: 0x04026E12 RID: 159250
		private TsBasePlayerController PlayerController;

		// Token: 0x04026E13 RID: 159251
		private string AxisName;

		// Token: 0x04026E14 RID: 159252
		private Stat OnInputStat;

		// Token: 0x04026E15 RID: 159253
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<string, float, bool> OnInputAxisCallback;

		// Token: 0x04026E16 RID: 159254
		private FAxisBindingDelegate OnInputAxisDelegate;

		// Token: 0x04026E17 RID: 159255
		private FAxisBindingDelegate OnAlwaysInputAxisDelegate;
	}
}
