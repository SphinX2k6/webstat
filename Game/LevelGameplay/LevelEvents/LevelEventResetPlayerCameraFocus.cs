using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BD6 RID: 27606
	public class LevelEventResetPlayerCameraFocus : LevelEventBase, IStaticVariableResetter
	{
		// Token: 0x06044090 RID: 278672 RVA: 0x011A5AF1 File Offset: 0x011A3CF1
		static LevelEventResetPlayerCameraFocus()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LevelEventResetPlayerCameraFocus.CreateStaticDefaultValue), new Action(LevelEventResetPlayerCameraFocus.ResetStaticDefaultValue));
		}

		// Token: 0x06044091 RID: 278673 RVA: 0x011A5B10 File Offset: 0x011A3D10
		public LevelEventResetPlayerCameraFocus(int id) : base(id)
		{
		}

		// Token: 0x06044092 RID: 278674 RVA: 0x011A5B1C File Offset: 0x011A3D1C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Event, ELogAuthor.LJM, "进入恢复相机调整", default(ReadOnlySpan<ValueTuple<string, object>>));
			ResetPlayerCameraFocus resetPlayerCameraFocus = inParams as ResetPlayerCameraFocus;
			if (resetPlayerCameraFocus == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !baseCharacter.IsValid())
			{
				base.FinishExecute(false, false, true);
				return;
			}
			float fadeInTime = resetPlayerCameraFocus.FadeInTime;
			bool canBreakByInput = !resetPlayerCameraFocus.CannotInterrupt.GetValueOrDefault();
			float valueOrDefault = resetPlayerCameraFocus.Duration.GetValueOrDefault();
			EResetPlayerFocusType type = resetPlayerCameraFocus.ResetType.Type;
			if (type != EResetPlayerFocusType.ResetToDefaultDirection)
			{
				if (type == EResetPlayerFocusType.ResetToFixedDirection)
				{
					IResetPlayerFocusToFixedDirection resetPlayerFocusToFixedDirection = resetPlayerCameraFocus.ResetType as IResetPlayerFocusToFixedDirection;
					LevelEventResetPlayerCameraFocus._desRotator.Set(resetPlayerFocusToFixedDirection.Direction.Y.GetValueOrDefault(), resetPlayerFocusToFixedDirection.Direction.Z.GetValueOrDefault(), resetPlayerFocusToFixedDirection.Direction.X.GetValueOrDefault());
					ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.PlayCameraEulerRotatorWithCurve(LevelEventResetPlayerCameraFocus._desRotator, fadeInTime, null, canBreakByInput, valueOrDefault);
				}
			}
			else
			{
				CameraUtility.ResetFocus(fadeInTime, null, canBreakByInput, valueOrDefault);
			}
			if (Global.BaseCharacter != null)
			{
				EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(Global.BaseCharacter.EntityId);
				if (entityById != null)
				{
					WorldEntity entity = entityById.Entity;
					if (entity != null)
					{
						CharacterInputComponent component = entity.GetComponent<CharacterInputComponent>();
						if (component != null)
						{
							component.InterruptAutoMoving("进入相机调整ResetPlayerCameraFocus", true);
						}
					}
				}
			}
			Singleton<global::Log>.Instance.Info(ELogModule.Event, ELogAuthor.LJM, "结束恢复相机调整", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06044093 RID: 278675 RVA: 0x011A5CA2 File Offset: 0x011A3EA2
		public static void CreateStaticDefaultValue()
		{
			LevelEventResetPlayerCameraFocus._desRotator = Rotator.Create();
		}

		// Token: 0x06044094 RID: 278676 RVA: 0x011A5CAE File Offset: 0x011A3EAE
		public static void ResetStaticDefaultValue()
		{
			LevelEventResetPlayerCameraFocus._desRotator = null;
		}

		// Token: 0x04026061 RID: 155745
		[Nullable(2)]
		private static Rotator _desRotator;
	}
}
