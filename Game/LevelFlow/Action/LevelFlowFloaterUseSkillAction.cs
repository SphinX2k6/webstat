using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F96 RID: 28566
	public class LevelFlowFloaterUseSkillAction : LevelFlowActionBase
	{
		// Token: 0x060451C4 RID: 283076 RVA: 0x0120712C File Offset: 0x0120532C
		[NullableContext(1)]
		public LevelFlowFloaterUseSkillAction Init(int skillId)
		{
			this.SkillId = skillId;
			return this;
		}

		// Token: 0x060451C5 RID: 283077 RVA: 0x01207138 File Offset: 0x01205338
		protected override void OnExecute()
		{
			Entity entity = Global.BaseCharacter.CharacterActorComponent.Entity;
			CharacterDriveVehicleComponent component = entity.GetComponent<CharacterDriveVehicleComponent>();
			if (component == null || component.VehicleEntity == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(92, 1);
				defaultInterpolatedStringHandler.AppendLiteral("LevelFlowFloaterUseSkillAction OnExecute entityId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(entity.Id);
				defaultInterpolatedStringHandler.AppendLiteral(" not found CharacterDriveVehicleComponent");
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			EntityHandle playerFollowShooter = FollowUtils.GetPlayerFollowShooter(ModelBase<CreatureModel>.Instance.GetPlayerId());
			if (playerFollowShooter == null || playerFollowShooter.Entity == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelFlow;
				ELogAuthor author2 = ELogAuthor.BB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(76, 1);
				defaultInterpolatedStringHandler.AppendLiteral("LevelFlowFloaterUseSkillAction OnExecute entityId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(component.VehicleEntity.Id);
				defaultInterpolatedStringHandler.AppendLiteral(" not found FollowerEntity");
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			BaseSkillComponent component2 = playerFollowShooter.Entity.GetComponent<BaseSkillComponent>();
			if (component2 == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.LevelFlow;
				ELogAuthor author3 = ELogAuthor.BB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(80, 1);
				defaultInterpolatedStringHandler.AppendLiteral("LevelFlowFloaterUseSkillAction OnExecute entityId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(playerFollowShooter.Id);
				defaultInterpolatedStringHandler.AppendLiteral(" not found BaseSkillComponent");
				instance3.Error(module3, author3, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			component2.BeginSkillAsync(this.SkillId, new SkillParam
			{
				Reason = "LevelFlowUseSkillAction"
			});
			base.FinishExecute(true);
		}

		// Token: 0x060451C6 RID: 283078 RVA: 0x012072C8 File Offset: 0x012054C8
		protected unsafe override void LogExecuteInfo()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "执行行为";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionId", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SkillId", this.SkillId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x040268F8 RID: 157944
		private int SkillId;
	}
}
