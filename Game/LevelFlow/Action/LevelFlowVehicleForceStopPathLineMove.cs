using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FB2 RID: 28594
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelFlowVehicleForceStopPathLineMove : LevelFlowActionBase
	{
		// Token: 0x06045244 RID: 283204 RVA: 0x0120AB17 File Offset: 0x01208D17
		[NullableContext(1)]
		public LevelFlowVehicleForceStopPathLineMove Init(ETargetVehicle type, int? entityId = null)
		{
			this.Type = new ETargetVehicle?(type);
			this.EntityId = entityId;
			return this;
		}

		// Token: 0x06045245 RID: 283205 RVA: 0x0120AB30 File Offset: 0x01208D30
		protected unsafe override void OnExecute()
		{
			Entity targetVehicleEntity = this.GetTargetVehicleEntity(this.Type.Value, this.EntityId);
			if (targetVehicleEntity == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				string message = "目标实体不存在";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", this.Type);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", this.EntityId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				base.FinishExecute(true);
				return;
			}
			VehicleSplineMoveComponent component = targetVehicleEntity.GetComponent<VehicleSplineMoveComponent>();
			if (component != null)
			{
				component.ForceStopSplineMove();
			}
			base.FinishExecute(true);
		}

		// Token: 0x06045246 RID: 283206 RVA: 0x0120ABE4 File Offset: 0x01208DE4
		private Entity GetTargetVehicleEntity(ETargetVehicle type, int? entityId)
		{
			if (type == ETargetVehicle.Current)
			{
				return this.GetVehicleEntityFromPlayerRole();
			}
			if (type != ETargetVehicle.Appointed)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "不支持的目标类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			if (entityId == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YJX, "目标类型为Appointed时，entityId不能为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(entityId.Value);
			if (entityByPbDataId == null)
			{
				return null;
			}
			return entityByPbDataId.Entity;
		}

		// Token: 0x06045247 RID: 283207 RVA: 0x0120AC74 File Offset: 0x01208E74
		private Entity GetVehicleEntityFromPlayerRole()
		{
			if (Global.BaseCharacter == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YJX, "获取玩家载具失败，找不到全局玩家角色", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			Entity entity = Global.BaseCharacter.CharacterActorComponent.Entity;
			CharacterDriveVehicleComponent characterDriveVehicleComponent = (entity != null) ? entity.GetComponent<CharacterDriveVehicleComponent>() : null;
			if (characterDriveVehicleComponent == null)
			{
				return null;
			}
			return characterDriveVehicleComponent.VehicleEntity;
		}

		// Token: 0x0402693C RID: 158012
		private ETargetVehicle? Type;

		// Token: 0x0402693D RID: 158013
		private int? EntityId;
	}
}
