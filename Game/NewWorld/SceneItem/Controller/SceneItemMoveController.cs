using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Controller
{
	// Token: 0x02004878 RID: 18552
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class SceneItemMoveController : ControllerBase<SceneItemMoveController>
	{
		// Token: 0x06030453 RID: 197715 RVA: 0x00BBF53C File Offset: 0x00BBD73C
		public void AddSceneItemMove(Entity entity, List<IVector> points, bool isLoop, ISceneItemMoveMotionType moveMotion, float? stopTime = null)
		{
			SceneItemMoveController.MoveParam moveParam = new SceneItemMoveController.MoveParam();
			moveParam.Points = points;
			moveParam.IsLoop = isLoop;
			moveParam.MoveMotion = moveMotion;
			moveParam.StopTime = stopTime;
			float? acceleration;
			if (moveMotion.Type != EMoveMotion.VariableMotion)
			{
				acceleration = new float?((float)-1);
			}
			else
			{
				IVariableMotion variableMotion = moveMotion as IVariableMotion;
				acceleration = ((variableMotion != null) ? new float?(variableMotion.Acceleration) : null);
			}
			moveParam.Acceleration = acceleration;
			float? maxSpeed;
			if (moveMotion.Type != EMoveMotion.VariableMotion)
			{
				maxSpeed = new float?((float)-1);
			}
			else
			{
				IVariableMotion variableMotion2 = moveMotion as IVariableMotion;
				maxSpeed = ((variableMotion2 != null) ? new float?(variableMotion2.MaxSpeed) : null);
			}
			moveParam.MaxSpeed = maxSpeed;
			SceneItemMoveController.MoveParam moveParam2 = moveParam;
			this.MoveParams[entity] = moveParam2;
			if (!Singleton<EventSystem>.Instance.HasWithTarget<Entity>(entity, EEventName.OnSceneItemMoveBroken, new Action<Entity>(this.OnStopCallback)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<Entity>(entity, EEventName.OnSceneItemMoveBroken, new Action<Entity>(this.OnStopCallback));
			}
			int num = -1;
			if (moveMotion.Type != EMoveMotion.VariableMotion)
			{
				Vector actorLocationProxy = entity.GetComponent<BaseActorComponent>().ActorLocationProxy;
				Vector v = Vector.Create(points[points.Count - 1].X, points[points.Count - 1].Y, points[points.Count - 1].Z);
				if (Vector.Distance(actorLocationProxy, v) < 1E-08)
				{
					if (moveParam2.IsLoop)
					{
						this.MoveToStartPoint(entity, 1);
					}
					return;
				}
				Vector vector = Vector.Create(points[points.Count - 1].X, points[points.Count - 1].Y, points[points.Count - 1].Z);
				vector.SubtractionEqual(Vector.Create(points[0].X, points[0].Y, points[0].Z));
				vector.Normalize(9.99999993922529E-09);
				for (int i = 1; i < points.Count; i++)
				{
					Vector vector2 = Vector.Create(points[i].X, points[i].Y, points[i].Z);
					vector2.SubtractionEqual(actorLocationProxy);
					vector2.Normalize(9.99999993922529E-09);
					if (vector2.DotProduct(vector) > 0.0)
					{
						num = i;
						break;
					}
				}
				if (num == -1)
				{
					return;
				}
			}
			else
			{
				num = 0;
			}
			this.MoveToEndPoint(entity, num);
		}

		// Token: 0x06030454 RID: 197716 RVA: 0x00BBF7A8 File Offset: 0x00BBD9A8
		private void MoveToStartPoint(Entity entity, int spliceNum = 1)
		{
			SceneItemMoveController.MoveParam moveParam;
			if (!this.MoveParams.TryGetValue(entity, out moveParam))
			{
				return;
			}
			SceneItemMoveComponent component = entity.GetComponent<SceneItemMoveComponent>();
			if (component == null)
			{
				return;
			}
			List<IVector> list = new List<IVector>(moveParam.Points);
			list.Reverse();
			if (spliceNum > 0 && spliceNum <= list.Count)
			{
				list.RemoveRange(0, spliceNum);
			}
			ISceneItemMoveMotionType moveMotion = moveParam.MoveMotion;
			if (moveMotion != null && moveMotion.Type == EMoveMotion.VariableMotion)
			{
				using (List<IVector>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IVector vector = enumerator.Current;
						Vector vector2 = Vector.Create(vector.X, vector.Y, vector.Z);
						SceneItemMoveComponent sceneItemMoveComponent = component;
						IVector targetPosData = vector2;
						float moveTime = -1f;
						float valueOrDefault = moveParam.StopTime.GetValueOrDefault();
						IVariableMotion variableMotion = moveParam.MoveMotion as IVariableMotion;
						float maxSpeed = (variableMotion != null) ? variableMotion.MaxSpeed : -1f;
						IVariableMotion variableMotion2 = moveParam.MoveMotion as IVariableMotion;
						sceneItemMoveComponent.AddMoveTarget(new SceneItemMoveComponent.MoveTarget(targetPosData, moveTime, valueOrDefault, maxSpeed, (variableMotion2 != null) ? variableMotion2.Acceleration : -1f));
					}
					goto IL_181;
				}
			}
			foreach (IVector vector3 in list)
			{
				Vector vector4 = Vector.Create(vector3.X, vector3.Y, vector3.Z);
				SceneItemMoveComponent sceneItemMoveComponent2 = component;
				IVector targetPosData2 = vector4;
				IUniformMotion uniformMotion = moveParam.MoveMotion as IUniformMotion;
				sceneItemMoveComponent2.AddMoveTarget(new SceneItemMoveComponent.MoveTarget(targetPosData2, (uniformMotion != null) ? uniformMotion.Time : -1f, moveParam.StopTime.GetValueOrDefault(), -1f, -1f));
			}
			IL_181:
			if (moveParam.IsLoop)
			{
				component.AddStopMoveCallbackWithEntity(new Action<Entity>(this.MoveToEndCallback));
				return;
			}
			component.AddStopMoveCallbackWithEntity(new Action<Entity>(this.OnStopCallback));
		}

		// Token: 0x06030455 RID: 197717 RVA: 0x00BBF980 File Offset: 0x00BBDB80
		private void MoveToEndPoint(Entity entity, int spliceNum = 1)
		{
			SceneItemMoveController.MoveParam moveParam;
			if (!this.MoveParams.TryGetValue(entity, out moveParam))
			{
				return;
			}
			SceneItemMoveComponent component = entity.GetComponent<SceneItemMoveComponent>();
			if (component == null)
			{
				return;
			}
			List<IVector> list = new List<IVector>(moveParam.Points);
			if (spliceNum > 0 && spliceNum <= list.Count)
			{
				list.RemoveRange(0, spliceNum);
			}
			ISceneItemMoveMotionType moveMotion = moveParam.MoveMotion;
			if (moveMotion != null && moveMotion.Type == EMoveMotion.VariableMotion)
			{
				bool flag = spliceNum > 0;
				using (List<IVector>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IVector vector = enumerator.Current;
						Vector vector2 = Vector.Create(vector.X, vector.Y, vector.Z);
						float? stopTime = moveParam.StopTime;
						if (!flag)
						{
							stopTime = new float?(0f);
							flag = true;
						}
						SceneItemMoveComponent sceneItemMoveComponent = component;
						IVector targetPosData = vector2;
						float moveTime = -1f;
						float valueOrDefault = stopTime.GetValueOrDefault();
						IVariableMotion variableMotion = moveParam.MoveMotion as IVariableMotion;
						float maxSpeed = (variableMotion != null) ? variableMotion.MaxSpeed : -1f;
						IVariableMotion variableMotion2 = moveParam.MoveMotion as IVariableMotion;
						sceneItemMoveComponent.AddMoveTarget(new SceneItemMoveComponent.MoveTarget(targetPosData, moveTime, valueOrDefault, maxSpeed, (variableMotion2 != null) ? variableMotion2.Acceleration : -1f));
					}
					goto IL_19A;
				}
			}
			foreach (IVector vector3 in list)
			{
				Vector vector4 = Vector.Create(vector3.X, vector3.Y, vector3.Z);
				SceneItemMoveComponent sceneItemMoveComponent2 = component;
				IVector targetPosData2 = vector4;
				IUniformMotion uniformMotion = moveParam.MoveMotion as IUniformMotion;
				sceneItemMoveComponent2.AddMoveTarget(new SceneItemMoveComponent.MoveTarget(targetPosData2, (uniformMotion != null) ? uniformMotion.Time : -1f, moveParam.StopTime.GetValueOrDefault(), -1f, -1f));
			}
			IL_19A:
			if (moveParam.IsLoop)
			{
				component.AddStopMoveCallbackWithEntity(new Action<Entity>(this.MoveToStartCallback));
				return;
			}
			component.AddStopMoveCallbackWithEntity(new Action<Entity>(this.OnStopCallback));
		}

		// Token: 0x06030456 RID: 197718 RVA: 0x00BBFB70 File Offset: 0x00BBDD70
		private void MoveToStartCallback(Entity entity)
		{
			SceneItemMoveComponent component = entity.GetComponent<SceneItemMoveComponent>();
			if (component == null)
			{
				return;
			}
			component.RemoveStopMoveCallbackWithEntity(new Action<Entity>(this.MoveToStartCallback));
			Singleton<global::Log>.Instance.Info(ELogModule.Event, ELogAuthor.CH, "[LevelEventSceneItemMove] MoveToStartCallback", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.MoveToStartPoint(entity, 1);
		}

		// Token: 0x06030457 RID: 197719 RVA: 0x00BBFBC0 File Offset: 0x00BBDDC0
		private void MoveToEndCallback(Entity entity)
		{
			SceneItemMoveComponent component = entity.GetComponent<SceneItemMoveComponent>();
			if (component == null)
			{
				return;
			}
			component.RemoveStopMoveCallbackWithEntity(new Action<Entity>(this.MoveToEndCallback));
			Singleton<global::Log>.Instance.Info(ELogModule.Event, ELogAuthor.CH, "[LevelEventSceneItemMove] MoveToEndCallback", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.MoveToEndPoint(entity, 1);
		}

		// Token: 0x06030458 RID: 197720 RVA: 0x00BBFC10 File Offset: 0x00BBDE10
		public void OnStopCallback(Entity entity)
		{
			SceneItemMoveComponent component = entity.GetComponent<SceneItemMoveComponent>();
			if (component == null)
			{
				return;
			}
			component.RemoveStopMoveCallbackWithEntity(new Action<Entity>(this.OnStopCallback));
			if (Singleton<EventSystem>.Instance.HasWithTarget<Entity>(entity, EEventName.OnSceneItemMoveBroken, new Action<Entity>(this.OnStopCallback)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<Entity>(entity, EEventName.OnSceneItemMoveBroken, new Action<Entity>(this.OnStopCallback));
			}
			this.MoveParams.Remove(entity);
		}

		// Token: 0x0401BB88 RID: 113544
		private readonly Dictionary<Entity, SceneItemMoveController.MoveParam> MoveParams = new Dictionary<Entity, SceneItemMoveController.MoveParam>();

		// Token: 0x0200A949 RID: 43337
		[NullableContext(0)]
		private class MoveParam
		{
			// Token: 0x0403472D RID: 214829
			[Nullable(1)]
			public List<IVector> Points = new List<IVector>();

			// Token: 0x0403472E RID: 214830
			public bool IsLoop;

			// Token: 0x0403472F RID: 214831
			[Nullable(2)]
			public ISceneItemMoveMotionType MoveMotion;

			// Token: 0x04034730 RID: 214832
			public float? StopTime;

			// Token: 0x04034731 RID: 214833
			public float? Acceleration;

			// Token: 0x04034732 RID: 214834
			public float? MaxSpeed;
		}
	}
}
