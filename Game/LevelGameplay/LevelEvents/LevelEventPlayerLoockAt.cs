using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BC2 RID: 27586
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventPlayerLoockAt : LevelEventBase
	{
		// Token: 0x06044050 RID: 278608 RVA: 0x011A3257 File Offset: 0x011A1457
		public LevelEventPlayerLoockAt(int id) : base(id)
		{
		}

		// Token: 0x06044051 RID: 278609 RVA: 0x011A3260 File Offset: 0x011A1460
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			PlayerLookAt playerLookAt = inParams as PlayerLookAt;
			if (playerLookAt == null)
			{
				return;
			}
			float? x = playerLookAt.Pos.X;
			float? y = playerLookAt.Pos.Y;
			float? z = playerLookAt.Pos.Z;
			bool? cameraMove = playerLookAt.CameraMove;
			Vector vector = Vector.Create((double)x.GetValueOrDefault(), (double)y.GetValueOrDefault(), (double)z.GetValueOrDefault());
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return;
			}
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			vector.Subtraction(characterActorComponent.ActorLocationProxy, LevelEventPlayerLoockAt.tmpVector);
			Singleton<MathUtils>.Instance.LookRotationUpFirst(LevelEventPlayerLoockAt.tmpVector, characterActorComponent.ActorUpProxy, LevelEventPlayerLoockAt.tmpQuat);
			if (LevelEventPlayerLoockAt.tmpQuat.IsNearZero(1E-06f))
			{
				return;
			}
			LevelEventPlayerLoockAt.tmpQuat.Rotator(LevelEventPlayerLoockAt.tmpRotator);
			if (!playerLookAt.PlayAnimation.GetValueOrDefault())
			{
				characterActorComponent.SetActorRotation(LevelEventPlayerLoockAt.tmpRotator.ToUeRotator(), "LevelEventPlayerLoockAt", false);
			}
			characterActorComponent.SetInputRotator(LevelEventPlayerLoockAt.tmpRotator);
			if (cameraMove.GetValueOrDefault())
			{
				CameraBlueprintFunctionLibrary.SetCameraRotation(LevelEventPlayerLoockAt.tmpRotator.ToUeRotator());
			}
		}

		// Token: 0x06044052 RID: 278610 RVA: 0x011A3376 File Offset: 0x011A1576
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x0402604C RID: 155724
		[StaticVariableRuleIgnore]
		private static readonly Vector tmpVector = Vector.Create();

		// Token: 0x0402604D RID: 155725
		[StaticVariableRuleIgnore]
		private static readonly Quat tmpQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x0402604E RID: 155726
		[StaticVariableRuleIgnore]
		private static readonly Rotator tmpRotator = Rotator.Create();
	}
}
