using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004802 RID: 18434
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemMovementSyncComponent : BaseMovementSyncComponent
	{
		// Token: 0x0602FED8 RID: 196312 RVA: 0x00B92C30 File Offset: 0x00B90E30
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			base.OnInitData(args);
			CreateEntityData p = args.GetP1<CreateEntityData>();
			SceneItemComponentPb sceneItemComponentPb;
			if (p == null)
			{
				sceneItemComponentPb = null;
			}
			else
			{
				Dictionary<string, EntityComponentPb> componentDataMap = p.ComponentDataMap;
				if (componentDataMap == null)
				{
					sceneItemComponentPb = null;
				}
				else
				{
					EntityComponentPb valueOrDefault = componentDataMap.GetValueOrDefault("SceneItemComponentPb");
					sceneItemComponentPb = ((valueOrDefault != null) ? valueOrDefault.SceneItemComponentPb : null);
				}
			}
			SceneItemComponentPb sceneItemComponentPb2 = sceneItemComponentPb;
			if (sceneItemComponentPb2 != null)
			{
				this.ModifyBlackboardFromRemote(sceneItemComponentPb2.BlackBoards, false);
			}
			return true;
		}

		// Token: 0x0602FED9 RID: 196313 RVA: 0x00B92C88 File Offset: 0x00B90E88
		protected override bool OnStart()
		{
			base.OnStart();
			CreatureDataComponent creatureDataComp = this.CreatureDataComp;
			this.SetAutonomousId(new int?((creatureDataComp != null) ? creatureDataComp.AutonomousId : 0));
			CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
			SceneItemComponentPb sceneItemComponentPb;
			if (creatureDataComp2 == null)
			{
				sceneItemComponentPb = null;
			}
			else
			{
				Dictionary<string, EntityComponentPb> componentDataMap = creatureDataComp2.ComponentDataMap;
				if (componentDataMap == null)
				{
					sceneItemComponentPb = null;
				}
				else
				{
					EntityComponentPb valueOrDefault = componentDataMap.GetValueOrDefault("SceneItemComponentPb");
					sceneItemComponentPb = ((valueOrDefault != null) ? valueOrDefault.SceneItemComponentPb : null);
				}
			}
			SceneItemComponentPb sceneItemComponentPb2 = sceneItemComponentPb;
			if (sceneItemComponentPb2 != null)
			{
				this.ModifyBlackboardFromRemote(sceneItemComponentPb2.BlackBoards, false);
			}
			return true;
		}

		// Token: 0x0602FEDA RID: 196314 RVA: 0x00B92CFC File Offset: 0x00B90EFC
		public void SetAutonomousId(int? playerId)
		{
			int valueOrDefault = playerId.GetValueOrDefault();
			int moveAutonomousId = this.MoveAutonomousId;
			this.MoveAutonomousId = valueOrDefault;
			bool flag = valueOrDefault != 0;
			int playerId2 = ModelBase<CreatureModel>.Instance.GetPlayerId();
			bool flag2 = playerId2 == moveAutonomousId;
			bool flag3 = flag && playerId2 == valueOrDefault;
			BaseActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.SetAutonomous(this.ActorComp.IsAutonomousProxy, new bool?(flag3));
			}
			base.SetEnableMovementSync(flag, "SceneItemManipulatableComponent.SetAutonomousId");
			if (flag2 != flag3)
			{
				Singleton<EventSystem>.Instance.EmitWithTarget<bool>(base.Entity, EEventName.OnSceneItemSwitchMoveControl, flag3);
			}
		}

		// Token: 0x0602FEDB RID: 196315 RVA: 0x00B92D8A File Offset: 0x00B90F8A
		public int GetAutonomousId()
		{
			return this.MoveAutonomousId;
		}

		// Token: 0x0602FEDC RID: 196316 RVA: 0x00B92D92 File Offset: 0x00B90F92
		public bool HasMoveController()
		{
			return this.MoveAutonomousId != 0;
		}

		// Token: 0x0602FEDD RID: 196317 RVA: 0x00B92D9D File Offset: 0x00B90F9D
		public bool HasMoveAuthority()
		{
			BaseActorComponent actorComp = this.ActorComp;
			return actorComp != null && actorComp.IsMoveAutonomousProxy;
		}

		// Token: 0x0602FEDE RID: 196318 RVA: 0x00B92DB0 File Offset: 0x00B90FB0
		[NullableContext(2)]
		private void SetBlackboardInner(SceneItemBBKey key, SceneItemMovementSyncComponent.TBlackboardValue? value, bool fromRemote, string reason = null)
		{
			this.Blackboards[key] = value;
			this.StateEvents.Emit<SceneItemMovementSyncComponent.TBlackboardValue?, bool, string>(key, value, fromRemote, reason ?? "");
		}

		// Token: 0x0602FEDF RID: 196319 RVA: 0x00B92DD9 File Offset: 0x00B90FD9
		public void ListenBlackboard(SceneItemBBKey key, Action<SceneItemMovementSyncComponent.TBlackboardValue?, bool, string> callback)
		{
			this.StateEvents.Add(key, callback);
		}

		// Token: 0x0602FEE0 RID: 196320 RVA: 0x00B92DE9 File Offset: 0x00B90FE9
		public void RemoveBlackboardListener(SceneItemBBKey key, Action<SceneItemMovementSyncComponent.TBlackboardValue?, bool, string> callback)
		{
			this.StateEvents.Remove(key, callback);
		}

		// Token: 0x0602FEE1 RID: 196321 RVA: 0x00B92DFC File Offset: 0x00B90FFC
		public void ModifyBlackboardFromRemote(IList<SceneItemBlackboardParam> blackboards, bool isFullUpdate = false)
		{
			if (isFullUpdate)
			{
				foreach (SceneItemBBKey key in new List<SceneItemBBKey>(this.Blackboards.Keys))
				{
					this.SetBlackboardInner(key, null, true, "ModifyStateFromRemote");
				}
				this.Blackboards.Clear();
				return;
			}
			foreach (SceneItemBlackboardParam sceneItemBlackboardParam in blackboards)
			{
				SceneItemBlackboardParam.ValueOneofCase valueCase = sceneItemBlackboardParam.ValueCase;
				SceneItemBBKey key2 = sceneItemBlackboardParam.Key;
				SceneItemMovementSyncComponent.TBlackboardValue? value = null;
				switch (valueCase)
				{
				case SceneItemBlackboardParam.ValueOneofCase.IntValue:
					value = new SceneItemMovementSyncComponent.TBlackboardValue?(sceneItemBlackboardParam.IntValue);
					break;
				case SceneItemBlackboardParam.ValueOneofCase.IntValues:
				{
					IntArrayBlackboard intValues = sceneItemBlackboardParam.IntValues;
					if (((intValues != null) ? intValues.Values : null) != null)
					{
						value = new SceneItemMovementSyncComponent.TBlackboardValue?(sceneItemBlackboardParam.IntValues.Values.ToArray<int>());
					}
					break;
				}
				case SceneItemBlackboardParam.ValueOneofCase.LongValue:
					if (sceneItemBlackboardParam.LongValue != 0L)
					{
						value = new SceneItemMovementSyncComponent.TBlackboardValue?(sceneItemBlackboardParam.LongValue);
					}
					break;
				case SceneItemBlackboardParam.ValueOneofCase.LongValues:
				{
					LongArrayBlackboard longValues = sceneItemBlackboardParam.LongValues;
					if (((longValues != null) ? longValues.Values : null) != null)
					{
						value = new SceneItemMovementSyncComponent.TBlackboardValue?(sceneItemBlackboardParam.LongValues.Values.ToArray<long>());
					}
					break;
				}
				case SceneItemBlackboardParam.ValueOneofCase.BooleanValue:
					value = new SceneItemMovementSyncComponent.TBlackboardValue?(sceneItemBlackboardParam.BooleanValue);
					break;
				case SceneItemBlackboardParam.ValueOneofCase.StringValue:
					value = new SceneItemMovementSyncComponent.TBlackboardValue?(sceneItemBlackboardParam.StringValue);
					break;
				case SceneItemBlackboardParam.ValueOneofCase.FloatValue:
					value = new SceneItemMovementSyncComponent.TBlackboardValue?(sceneItemBlackboardParam.FloatValue);
					break;
				case SceneItemBlackboardParam.ValueOneofCase.FloatValues:
				{
					FloatArrayBlackboard floatValues = sceneItemBlackboardParam.FloatValues;
					if (((floatValues != null) ? floatValues.Values : null) != null)
					{
						value = new SceneItemMovementSyncComponent.TBlackboardValue?(sceneItemBlackboardParam.FloatValues.Values.ToArray<float>());
					}
					break;
				}
				case SceneItemBlackboardParam.ValueOneofCase.VectorValue:
					if (sceneItemBlackboardParam.VectorValue != null)
					{
						value = new SceneItemMovementSyncComponent.TBlackboardValue?(global::Vector.Create(sceneItemBlackboardParam.VectorValue));
					}
					break;
				case SceneItemBlackboardParam.ValueOneofCase.RotatorValue:
					if (sceneItemBlackboardParam.RotatorValue != null)
					{
						value = new SceneItemMovementSyncComponent.TBlackboardValue?(global::Rotator.Create(sceneItemBlackboardParam.RotatorValue));
					}
					break;
				}
				this.SetBlackboardInner(key2, value, true, "ModifyStateFromRemote");
			}
		}

		// Token: 0x0602FEE2 RID: 196322 RVA: 0x00B9309C File Offset: 0x00B9129C
		public SceneItemMovementSyncComponent.TBlackboardValue? GetBlackboard(SceneItemBBKey key)
		{
			SceneItemMovementSyncComponent.TBlackboardValue? result;
			if (this.Blackboards.TryGetValue(key, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0602FEE3 RID: 196323 RVA: 0x00B930C4 File Offset: 0x00B912C4
		[NullableContext(2)]
		public unsafe bool ModifyBlackboard(SceneItemBBKey key, SceneItemMovementSyncComponent.TBlackboardValue value, string reason = null)
		{
			if (!this.HasMoveAuthority())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Level;
				ELogAuthor author = ELogAuthor.ZQR;
				string message = "[ModifyState] 尝试设置状态但没有移动控制权";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "creatureId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new long?(creatureDataComp.GetCreatureDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
				string item2 = "pbDataId";
				CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
				ptr2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("stateType", key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("stateId", value);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("reason", reason);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
				return false;
			}
			this.SetBlackboardInner(key, new SceneItemMovementSyncComponent.TBlackboardValue?(value), false, reason);
			UpdateSceneItemBlackboardRequest updateSceneItemBlackboardRequest = UpdateSceneItemBlackboardRequest.Create();
			UpdateSceneItemBlackboardRequest updateSceneItemBlackboardRequest2 = updateSceneItemBlackboardRequest;
			CreatureDataComponent creatureDataComp3 = this.CreatureDataComp;
			updateSceneItemBlackboardRequest2.EntityId = ((creatureDataComp3 != null) ? creatureDataComp3.GetCreatureDataId() : 0L);
			SceneItemBlackboardParam sceneItemBlackboardParam = SceneItemBlackboardParam.Create();
			sceneItemBlackboardParam.Key = key;
			if (key == SceneItemBBKey.ManipulatableState)
			{
				sceneItemBlackboardParam.IntValue = value.IntValue;
				updateSceneItemBlackboardRequest.Params.Add(sceneItemBlackboardParam);
				Singleton<Net>.Instance.Call<UpdateSceneItemBlackboardResponse>(ERequestMessageId.UpdateSceneItemBlackboardRequest, updateSceneItemBlackboardRequest, null, 0);
				this.CollectSampleAndSend(true);
				return true;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Level;
			ELogAuthor author2 = ELogAuthor.ZQR;
			string message2 = "[ModifyState] 未知的黑板值字段";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray6<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
			string item3 = "creatureId";
			CreatureDataComponent creatureDataComp4 = this.CreatureDataComp;
			ptr3 = new ValueTuple<string, object>(item3, (creatureDataComp4 != null) ? new long?(creatureDataComp4.GetCreatureDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("entityId", base.Entity.Id);
			ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2);
			string item4 = "pbDataId";
			CreatureDataComponent creatureDataComp5 = this.CreatureDataComp;
			ptr4 = new ValueTuple<string, object>(item4, (creatureDataComp5 != null) ? new int?(creatureDataComp5.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("stateType", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("stateId", value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 5) = new ValueTuple<string, object>("reason", reason);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 6));
			return false;
		}

		// Token: 0x0602FEE4 RID: 196324 RVA: 0x00B93380 File Offset: 0x00B91580
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemMovementSyncComponent sceneItemMovementSyncComponent = (SceneItemMovementSyncComponent)componentTemplate;
			if (base.CanResetComponentProperty("MoveAutonomousId"))
			{
				this.MoveAutonomousId = sceneItemMovementSyncComponent.MoveAutonomousId;
			}
			return (!base.CanResetComponentProperty("Blackboards") || sceneItemMovementSyncComponent.Blackboards == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<SceneItemBBKey, SceneItemMovementSyncComponent.TBlackboardValue?>>(this.Blackboards), "Blackboards")) && (!base.CanResetComponentProperty("StateEvents") || sceneItemMovementSyncComponent.StateEvents == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Event<SceneItemBBKey, Action<SceneItemMovementSyncComponent.TBlackboardValue?, bool, string>>>(this.StateEvents), "StateEvents"));
		}

		// Token: 0x0401B832 RID: 112690
		private const int INVALID_ID = 0;

		// Token: 0x0401B833 RID: 112691
		private int MoveAutonomousId;

		// Token: 0x0401B834 RID: 112692
		private readonly Dictionary<SceneItemBBKey, SceneItemMovementSyncComponent.TBlackboardValue?> Blackboards = new Dictionary<SceneItemBBKey, SceneItemMovementSyncComponent.TBlackboardValue?>();

		// Token: 0x0401B835 RID: 112693
		private readonly Event<SceneItemBBKey, Action<SceneItemMovementSyncComponent.TBlackboardValue?, bool, string>> StateEvents = new Event<SceneItemBBKey, Action<SceneItemMovementSyncComponent.TBlackboardValue?, bool, string>>();

		// Token: 0x0200A8DE RID: 43230
		// (Invoke) Token: 0x0604B03A RID: 307258
		[NullableContext(0)]
		public delegate void TStateEventCallback(SceneItemMovementSyncComponent.TBlackboardValue? value, bool fromRemote, string reason);

		// Token: 0x0200A8DF RID: 43231
		[Nullable(0)]
		public struct TBlackboardValue
		{
			// Token: 0x1700A91D RID: 43293
			// (get) Token: 0x0604B03D RID: 307261 RVA: 0x0146B4F0 File Offset: 0x014696F0
			// (set) Token: 0x0604B03E RID: 307262 RVA: 0x0146B4F8 File Offset: 0x014696F8
			public SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType ValueType { readonly get; private set; }

			// Token: 0x0604B03F RID: 307263 RVA: 0x0146B504 File Offset: 0x01469704
			public TBlackboardValue()
			{
				this.IntValueInternal = 0;
				this.IntArrayValueInternal = null;
				this.FloatValueInternal = 0f;
				this.FloatArrayValueInternal = null;
				this.LongValueInternal = 0L;
				this.LongArrayValueInternal = null;
				this.RotatorValueInternal = null;
				this.RotatorArrayValueInternal = null;
				this.StringValueInternal = null;
				this.StringArrayValueInternal = null;
				this.VectorValueInternal = null;
				this.VectorArrayValueInternal = null;
				this.BoolValueInternal = false;
				this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.None;
			}

			// Token: 0x1700A91E RID: 43294
			// (get) Token: 0x0604B040 RID: 307264 RVA: 0x0146B578 File Offset: 0x01469778
			// (set) Token: 0x0604B041 RID: 307265 RVA: 0x0146B5C4 File Offset: 0x014697C4
			public int IntValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.Int)
					{
						return this.IntValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not Int, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.Int;
					this.IntValueInternal = value;
				}
			}

			// Token: 0x1700A91F RID: 43295
			// (get) Token: 0x0604B042 RID: 307266 RVA: 0x0146B5D4 File Offset: 0x014697D4
			// (set) Token: 0x0604B043 RID: 307267 RVA: 0x0146B620 File Offset: 0x01469820
			public int[] IntArrayValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.IntArray)
					{
						return this.IntArrayValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not IntArray, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.IntArray;
					this.IntArrayValueInternal = value;
				}
			}

			// Token: 0x1700A920 RID: 43296
			// (get) Token: 0x0604B044 RID: 307268 RVA: 0x0146B630 File Offset: 0x01469830
			// (set) Token: 0x0604B045 RID: 307269 RVA: 0x0146B67C File Offset: 0x0146987C
			public float FloatValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.Float)
					{
						return this.FloatValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not Float, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.Float;
					this.FloatValueInternal = value;
				}
			}

			// Token: 0x1700A921 RID: 43297
			// (get) Token: 0x0604B046 RID: 307270 RVA: 0x0146B68C File Offset: 0x0146988C
			// (set) Token: 0x0604B047 RID: 307271 RVA: 0x0146B6D8 File Offset: 0x014698D8
			public float[] FloatArrayValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.FloatArray)
					{
						return this.FloatArrayValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not FloatArray, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.FloatArray;
					this.FloatArrayValueInternal = value;
				}
			}

			// Token: 0x1700A922 RID: 43298
			// (get) Token: 0x0604B048 RID: 307272 RVA: 0x0146B6E8 File Offset: 0x014698E8
			// (set) Token: 0x0604B049 RID: 307273 RVA: 0x0146B734 File Offset: 0x01469934
			public long LongValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.Long)
					{
						return this.LongValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not Long, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.Long;
					this.LongValueInternal = value;
				}
			}

			// Token: 0x1700A923 RID: 43299
			// (get) Token: 0x0604B04A RID: 307274 RVA: 0x0146B744 File Offset: 0x01469944
			// (set) Token: 0x0604B04B RID: 307275 RVA: 0x0146B790 File Offset: 0x01469990
			public long[] LongArrayValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.LongArray)
					{
						return this.LongArrayValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not LongArray, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.LongArray;
					this.LongArrayValueInternal = value;
				}
			}

			// Token: 0x1700A924 RID: 43300
			// (get) Token: 0x0604B04C RID: 307276 RVA: 0x0146B7A0 File Offset: 0x014699A0
			// (set) Token: 0x0604B04D RID: 307277 RVA: 0x0146B7EC File Offset: 0x014699EC
			public global::Rotator RotatorValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.Rotator)
					{
						return this.RotatorValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not Rotator, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.Rotator;
					this.RotatorValueInternal = value;
				}
			}

			// Token: 0x1700A925 RID: 43301
			// (get) Token: 0x0604B04E RID: 307278 RVA: 0x0146B7FC File Offset: 0x014699FC
			// (set) Token: 0x0604B04F RID: 307279 RVA: 0x0146B848 File Offset: 0x01469A48
			public global::Rotator[] RotatorArrayValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.RotatorArray)
					{
						return this.RotatorArrayValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not RotatorArray, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.RotatorArray;
					this.RotatorArrayValueInternal = value;
				}
			}

			// Token: 0x1700A926 RID: 43302
			// (get) Token: 0x0604B050 RID: 307280 RVA: 0x0146B858 File Offset: 0x01469A58
			// (set) Token: 0x0604B051 RID: 307281 RVA: 0x0146B8A5 File Offset: 0x01469AA5
			public string StringValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.String)
					{
						return this.StringValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not String, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.String;
					this.StringValueInternal = value;
				}
			}

			// Token: 0x1700A927 RID: 43303
			// (get) Token: 0x0604B052 RID: 307282 RVA: 0x0146B8B8 File Offset: 0x01469AB8
			// (set) Token: 0x0604B053 RID: 307283 RVA: 0x0146B905 File Offset: 0x01469B05
			public string[] StringArrayValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.StringArray)
					{
						return this.StringArrayValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not StringArray, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.StringArray;
					this.StringArrayValueInternal = value;
				}
			}

			// Token: 0x1700A928 RID: 43304
			// (get) Token: 0x0604B054 RID: 307284 RVA: 0x0146B918 File Offset: 0x01469B18
			// (set) Token: 0x0604B055 RID: 307285 RVA: 0x0146B965 File Offset: 0x01469B65
			public global::Vector VectorValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.Vector)
					{
						return this.VectorValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not Vector, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.Vector;
					this.VectorValueInternal = value;
				}
			}

			// Token: 0x1700A929 RID: 43305
			// (get) Token: 0x0604B056 RID: 307286 RVA: 0x0146B978 File Offset: 0x01469B78
			// (set) Token: 0x0604B057 RID: 307287 RVA: 0x0146B9C5 File Offset: 0x01469BC5
			public global::Vector[] VectorArrayValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.VectorArray)
					{
						return this.VectorArrayValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not VectorArray, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.VectorArray;
					this.VectorArrayValueInternal = value;
				}
			}

			// Token: 0x1700A92A RID: 43306
			// (get) Token: 0x0604B058 RID: 307288 RVA: 0x0146B9D8 File Offset: 0x01469BD8
			// (set) Token: 0x0604B059 RID: 307289 RVA: 0x0146BA25 File Offset: 0x01469C25
			public bool BoolValue
			{
				get
				{
					if (this.ValueType == SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.Bool)
					{
						return this.BoolValueInternal;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Value is not Bool, current is ");
					defaultInterpolatedStringHandler.AppendFormatted<SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType>(this.ValueType);
					throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				set
				{
					this.ValueType = SceneItemMovementSyncComponent.TBlackboardValue.EBlackboardValueType.Bool;
					this.BoolValueInternal = value;
				}
			}

			// Token: 0x0604B05A RID: 307290 RVA: 0x0146BA38 File Offset: 0x01469C38
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(int value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					IntValue = value
				};
			}

			// Token: 0x0604B05B RID: 307291 RVA: 0x0146BA58 File Offset: 0x01469C58
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(int[] value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					IntArrayValue = value
				};
			}

			// Token: 0x0604B05C RID: 307292 RVA: 0x0146BA78 File Offset: 0x01469C78
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(float value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					FloatValue = value
				};
			}

			// Token: 0x0604B05D RID: 307293 RVA: 0x0146BA98 File Offset: 0x01469C98
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(float[] value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					FloatArrayValue = value
				};
			}

			// Token: 0x0604B05E RID: 307294 RVA: 0x0146BAB8 File Offset: 0x01469CB8
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(long value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					LongValue = value
				};
			}

			// Token: 0x0604B05F RID: 307295 RVA: 0x0146BAD8 File Offset: 0x01469CD8
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(long[] value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					LongArrayValue = value
				};
			}

			// Token: 0x0604B060 RID: 307296 RVA: 0x0146BAF8 File Offset: 0x01469CF8
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(global::Rotator value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					RotatorValue = value
				};
			}

			// Token: 0x0604B061 RID: 307297 RVA: 0x0146BB18 File Offset: 0x01469D18
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(global::Rotator[] value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					RotatorArrayValue = value
				};
			}

			// Token: 0x0604B062 RID: 307298 RVA: 0x0146BB38 File Offset: 0x01469D38
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(string value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					StringValue = value
				};
			}

			// Token: 0x0604B063 RID: 307299 RVA: 0x0146BB58 File Offset: 0x01469D58
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(string[] value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					StringArrayValue = value
				};
			}

			// Token: 0x0604B064 RID: 307300 RVA: 0x0146BB78 File Offset: 0x01469D78
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(global::Vector value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					VectorValue = value
				};
			}

			// Token: 0x0604B065 RID: 307301 RVA: 0x0146BB98 File Offset: 0x01469D98
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(global::Vector[] value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					VectorArrayValue = value
				};
			}

			// Token: 0x0604B066 RID: 307302 RVA: 0x0146BBB8 File Offset: 0x01469DB8
			public static implicit operator SceneItemMovementSyncComponent.TBlackboardValue(bool value)
			{
				return new SceneItemMovementSyncComponent.TBlackboardValue
				{
					BoolValue = value
				};
			}

			// Token: 0x040345FE RID: 214526
			private int IntValueInternal;

			// Token: 0x040345FF RID: 214527
			[Nullable(2)]
			private int[] IntArrayValueInternal;

			// Token: 0x04034600 RID: 214528
			private float FloatValueInternal;

			// Token: 0x04034601 RID: 214529
			[Nullable(2)]
			private float[] FloatArrayValueInternal;

			// Token: 0x04034602 RID: 214530
			private long LongValueInternal;

			// Token: 0x04034603 RID: 214531
			[Nullable(2)]
			private long[] LongArrayValueInternal;

			// Token: 0x04034604 RID: 214532
			[Nullable(2)]
			private global::Rotator RotatorValueInternal;

			// Token: 0x04034605 RID: 214533
			[Nullable(new byte[]
			{
				2,
				1
			})]
			private global::Rotator[] RotatorArrayValueInternal;

			// Token: 0x04034606 RID: 214534
			[Nullable(2)]
			private string StringValueInternal;

			// Token: 0x04034607 RID: 214535
			[Nullable(new byte[]
			{
				2,
				1
			})]
			private string[] StringArrayValueInternal;

			// Token: 0x04034608 RID: 214536
			[Nullable(2)]
			private global::Vector VectorValueInternal;

			// Token: 0x04034609 RID: 214537
			[Nullable(new byte[]
			{
				2,
				1
			})]
			private global::Vector[] VectorArrayValueInternal;

			// Token: 0x0403460A RID: 214538
			private bool BoolValueInternal;

			// Token: 0x0200CEB0 RID: 52912
			[NullableContext(0)]
			public enum EBlackboardValueType
			{
				// Token: 0x0403FB2E RID: 260910
				None,
				// Token: 0x0403FB2F RID: 260911
				Int,
				// Token: 0x0403FB30 RID: 260912
				IntArray,
				// Token: 0x0403FB31 RID: 260913
				Float,
				// Token: 0x0403FB32 RID: 260914
				FloatArray,
				// Token: 0x0403FB33 RID: 260915
				Long,
				// Token: 0x0403FB34 RID: 260916
				LongArray,
				// Token: 0x0403FB35 RID: 260917
				Rotator,
				// Token: 0x0403FB36 RID: 260918
				RotatorArray,
				// Token: 0x0403FB37 RID: 260919
				String,
				// Token: 0x0403FB38 RID: 260920
				StringArray,
				// Token: 0x0403FB39 RID: 260921
				Vector,
				// Token: 0x0403FB3A RID: 260922
				VectorArray,
				// Token: 0x0403FB3B RID: 260923
				Bool
			}
		}
	}
}
