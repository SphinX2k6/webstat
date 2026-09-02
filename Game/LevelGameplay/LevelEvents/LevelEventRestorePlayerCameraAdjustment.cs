using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Guarantee;
using CSharpScript.Game.Utils;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BD9 RID: 27609
	public class LevelEventRestorePlayerCameraAdjustment : LevelEventBase
	{
		// Token: 0x0604409A RID: 278682 RVA: 0x011A5E08 File Offset: 0x011A4008
		public LevelEventRestorePlayerCameraAdjustment(int id) : base(id)
		{
		}

		// Token: 0x0604409B RID: 278683 RVA: 0x011A5E14 File Offset: 0x011A4014
		[NullableContext(1)]
		public unsafe override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			RestorePlayerCameraAdjustment restorePlayerCameraAdjustment = inParams as RestorePlayerCameraAdjustment;
			if (restorePlayerCameraAdjustment == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			this.Params = restorePlayerCameraAdjustment;
			string text = restorePlayerCameraAdjustment.SubScreenKey ?? "";
			string text2 = StringUtils.IsNothing(text) ? "MainCamera" : text;
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(text2);
			if (separateCameraModel == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "离开相机调整失败，因为非法的副屏相机";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("subScreenKey", text2);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false, false, true);
				return;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter != null && ((restorePlayerCameraAdjustment != null) ? restorePlayerCameraAdjustment.ResetFocus : null) != null)
			{
				float fadeInTime = restorePlayerCameraAdjustment.ResetFocus.FadeInTime;
				CurveBase curve = ConfigCurveUtils.CreateCurveByBaseCurve(restorePlayerCameraAdjustment.ResetFocus.FadeInCurve, null);
				baseCharacter.GetEntityNoBlueprint().GetComponent<CharacterLockOnComponent>().ResetPitch(fadeInTime, curve, true, 0f, text2);
			}
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Event;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "离开相机调整";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("subScreenParam", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("subScreenKey", text2);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			FightCameraLogicComponent logicComponent = separateCameraModel.FightCamera.LogicComponent;
			float? fadeInTime2;
			if (restorePlayerCameraAdjustment == null)
			{
				fadeInTime2 = null;
			}
			else
			{
				IResetFocusConfig resetFocus = restorePlayerCameraAdjustment.ResetFocus;
				fadeInTime2 = ((resetFocus != null) ? new float?(resetFocus.FadeInTime) : null);
			}
			logicComponent.RestoreCameraFromAdjust(fadeInTime2, null, true);
		}

		// Token: 0x0604409C RID: 278684 RVA: 0x011A5F88 File Offset: 0x011A4188
		protected override void OnUpdateGuarantee()
		{
			RestorePlayerCameraAdjustment restorePlayerCameraAdjustment = new RestorePlayerCameraAdjustment();
			RestorePlayerCameraAdjustment @params = this.Params;
			restorePlayerCameraAdjustment.SubScreenKey = (((@params != null) ? @params.SubScreenKey : null) ?? "");
			RestorePlayerCameraAdjustment params2 = restorePlayerCameraAdjustment;
			GuaranteeActionInfo p = new GuaranteeActionInfo
			{
				Name = EGuaranteeAction.RestorePlayerCameraAdjustment,
				Params = params2
			};
			Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, this.Type, this.BaseContext, p, new bool?(true));
		}

		// Token: 0x04026063 RID: 155747
		[Nullable(2)]
		private RestorePlayerCameraAdjustment Params;
	}
}
