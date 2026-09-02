using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Utils;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FA7 RID: 28583
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelFlowRestorePlayerCameraAdjustment : LevelFlowActionBase
	{
		// Token: 0x06045219 RID: 283161 RVA: 0x0120970F File Offset: 0x0120790F
		[NullableContext(1)]
		public LevelFlowRestorePlayerCameraAdjustment Init(RestorePlayerCameraAdjustment param)
		{
			this.Params = param;
			return this;
		}

		// Token: 0x0604521A RID: 283162 RVA: 0x0120971C File Offset: 0x0120791C
		protected override void OnExecute()
		{
			if (this.Params == null)
			{
				base.FinishExecute(false);
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter != null)
			{
				RestorePlayerCameraAdjustment @params = this.Params;
				if (((@params != null) ? @params.ResetFocus : null) != null)
				{
					float fadeInTime = this.Params.ResetFocus.FadeInTime;
					CurveBase curve = ConfigCurveUtils.CreateCurveByBaseCurve(this.Params.ResetFocus.FadeInCurve, null);
					baseCharacter.GetEntityNoBlueprint().GetComponent<CharacterLockOnComponent>().ResetPitch(fadeInTime, curve, true, 0f, "MainCamera");
				}
			}
			Singleton<global::Log>.Instance.Info(ELogModule.LevelFlow, ELogAuthor.ZWY, "离开相机调整", default(ReadOnlySpan<ValueTuple<string, object>>));
			RestorePlayerCameraAdjustment params2 = this.Params;
			float? num;
			if (params2 == null)
			{
				num = null;
			}
			else
			{
				IResetFocusConfig resetFocus = params2.ResetFocus;
				num = ((resetFocus != null) ? new float?(resetFocus.FadeInTime) : null);
			}
			float? num2 = num;
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.RestoreCameraFromAdjust(num2, null, true);
			if (num2 != null)
			{
				float? num3 = num2;
				float num4 = 0f;
				if (num3.GetValueOrDefault() > num4 & num3 != null)
				{
					this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
					{
						base.FinishExecute(true);
					}, (float)((int)(num2.Value * 1000f)), null, null, true, 1f);
					return;
				}
			}
			base.FinishExecute(true);
		}

		// Token: 0x0604521B RID: 283163 RVA: 0x0120986F File Offset: 0x01207A6F
		protected override void OnComplete(bool isSuccess)
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x04026925 RID: 157989
		private RestorePlayerCameraAdjustment Params;

		// Token: 0x04026926 RID: 157990
		private TimerHandle TimerHandle;
	}
}
