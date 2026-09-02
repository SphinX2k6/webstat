using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.Destructible;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FAD RID: 28589
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowSpawnDestructibleActor : LevelFlowActionBase
	{
		// Token: 0x06045232 RID: 283186 RVA: 0x0120A021 File Offset: 0x01208221
		public LevelFlowSpawnDestructibleActor Init(List<int> idList, bool isRelease, int entityId)
		{
			this.DestructibleIdList = idList;
			this.IsRelease = isRelease;
			this.EntityId = entityId;
			return this;
		}

		// Token: 0x06045233 RID: 283187 RVA: 0x0120A03C File Offset: 0x0120823C
		protected override void OnExecute()
		{
			if (this.IsRelease)
			{
				foreach (int key in this.DestructibleIdList)
				{
					LevelFlowResourceManager.ReleaseDestructibleActor(key);
				}
				base.FinishExecute(true);
				return;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.EntityId);
			if (entityById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				string message = "Entity加载超时或已被移除";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", this.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false);
				return;
			}
			BaseActorComponent component = entityById.Entity.GetComponent<BaseActorComponent>();
			if (component == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelFlow;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "Entity没有ActorComponent";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", this.EntityId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false);
				return;
			}
			foreach (int key2 in this.DestructibleIdList)
			{
				DestructibleStruct dataTableRowFromName = DataTableUtil.GetDataTableRowFromName<DestructibleStruct>(EDataTable.DestructibleTable, key2.ToString());
				if (dataTableRowFromName == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "DestructibleId not found in DestructibleTable", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.FinishExecute(false);
					return;
				}
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				FTransformDouble? ftransformDouble = (baseCharacter != null) ? new FTransformDouble?(baseCharacter.D_GetTransform()) : null;
				if (ftransformDouble == null)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.LevelFlow;
					ELogAuthor author3 = ELogAuthor.BB;
					string message3 = "BaseCharacter Transform 为空";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("EntityId", this.EntityId);
					instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					base.FinishExecute(false);
					return;
				}
				FTransformDouble value = ftransformDouble.Value;
				if (dataTableRowFromName.IsRelativePosition)
				{
					FVectorDouble fvectorDouble = value.GetTranslation();
					FVectorDouble position = dataTableRowFromName.Position;
					FVectorDouble fvectorDouble2 = fvectorDouble + position;
					value.SetTranslation(fvectorDouble2);
				}
				else
				{
					FVectorDouble fvectorDouble = dataTableRowFromName.Position;
					value.SetLocation(fvectorDouble);
				}
				ActionSpawnDestructibleActorWithTrackCapability param = new ActionSpawnDestructibleActorWithTrackCapability(new SpawnDestructibleActorWithTrackCapability
				{
					KuroDestructibleAsset = dataTableRowFromName.DestructibleAsset.ToAssetPathName(),
					KuroDestructibleDestructionAsset = dataTableRowFromName.DestructibleDestructionAsset.ToAssetPathName(),
					StartTransform = value,
					TargetToTrack = (component.Owner as APawn),
					TrackSpeed = dataTableRowFromName.TraceSpeed,
					TrackMethod = dataTableRowFromName.TrackMethod,
					TrackPredictionFactor = dataTableRowFromName.TrackPredictionFactor,
					StopTrackTargetDistance = dataTableRowFromName.StopTrackTargetDistance,
					ModelTransform = dataTableRowFromName.ModelTransform,
					RotateParam = new IFauxPhysicsAxisRotateParam
					{
						Type = EFauxPhysicsRotateParam.AxisRotate,
						LocalRotationAxis = new FVector?(dataTableRowFromName.LocalRotationAxis),
						AngularImpulseRadians = new float?(dataTableRowFromName.AngularImpulseRadians)
					},
					DamageAmount = 20,
					HitBuff = new int?(dataTableRowFromName.HitBuff),
					RevertMaxHp = new int?(dataTableRowFromName.RevertMaximumHP)
				});
				LevelFlowResourceManager.LoadDestructibleActor(key2, param);
			}
			base.FinishExecute(true);
		}

		// Token: 0x06045234 RID: 283188 RVA: 0x0120A38C File Offset: 0x0120858C
		protected unsafe override void LogExecuteInfo()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "执行行为";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionId", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", this.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("DestructibleIdList", string.Join<int>(",", this.DestructibleIdList));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x04026931 RID: 158001
		private List<int> DestructibleIdList = new List<int>();

		// Token: 0x04026932 RID: 158002
		private bool IsRelease;

		// Token: 0x04026933 RID: 158003
		private int EntityId;
	}
}
