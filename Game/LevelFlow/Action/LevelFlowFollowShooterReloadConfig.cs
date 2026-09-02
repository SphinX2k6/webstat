using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F97 RID: 28567
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowFollowShooterReloadConfig : LevelFlowActionBase
	{
		// Token: 0x060451C8 RID: 283080 RVA: 0x01207369 File Offset: 0x01205569
		public LevelFlowFollowShooterReloadConfig Init(string configPath)
		{
			this.ConfigPath = configPath;
			return this;
		}

		// Token: 0x060451C9 RID: 283081 RVA: 0x01207374 File Offset: 0x01205574
		protected override void OnExecute()
		{
			Entity entity = Global.BaseCharacter.CharacterActorComponent.Entity;
			CharacterDriveVehicleComponent characterDriveVehicleComponent = (entity != null) ? entity.GetComponent<CharacterDriveVehicleComponent>() : null;
			if (characterDriveVehicleComponent == null || characterDriveVehicleComponent.VehicleEntity == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(96, 1);
				defaultInterpolatedStringHandler.AppendLiteral("LevelFlowFollowShooterReloadConfig OnExecute entityId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int?>((entity != null) ? new int?(entity.Id) : null);
				defaultInterpolatedStringHandler.AppendLiteral(" not found CharacterDriveVehicleComponent");
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			EntityHandle playerFollowShooter = FollowUtils.GetPlayerFollowShooter(ModelBase<CreatureModel>.Instance.GetPlayerId());
			FollowShooterComponent followShooterComponent;
			if (playerFollowShooter == null)
			{
				followShooterComponent = null;
			}
			else
			{
				WorldEntity entity2 = playerFollowShooter.Entity;
				followShooterComponent = ((entity2 != null) ? entity2.GetComponent<FollowShooterComponent>() : null);
			}
			FollowShooterComponent followShooterComponent2 = followShooterComponent;
			if (followShooterComponent2 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "LevelFlowFollowShooterReloadConfig: shooterComp is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			followShooterComponent2.AsyncReloadConfig(this.ConfigPath);
			base.FinishExecute(true);
		}

		// Token: 0x060451CA RID: 283082 RVA: 0x01207480 File Offset: 0x01205680
		protected unsafe override void LogExecuteInfo()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "执行行为";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionId", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ConfigPath", this.ConfigPath);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x040268F9 RID: 157945
		private string ConfigPath = string.Empty;
	}
}
