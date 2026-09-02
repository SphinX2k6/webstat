using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006ADA RID: 27354
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class SplineMoveTaskController : ControllerBase<SplineMoveTaskController>
	{
		// Token: 0x06043A01 RID: 276993 RVA: 0x01171C20 File Offset: 0x0116FE20
		protected override void OnTick(float delta)
		{
			foreach (KeyValuePair<long, List<SplineMoveTaskBase>> keyValuePair in this.EntitySplineMoveTasks)
			{
				foreach (SplineMoveTaskBase splineMoveTaskBase in keyValuePair.Value)
				{
					splineMoveTaskBase.TickTask((double)delta);
				}
			}
		}

		// Token: 0x06043A02 RID: 276994 RVA: 0x01171CB0 File Offset: 0x0116FEB0
		protected override bool OnInit()
		{
			if (!Singleton<EventSystem>.Instance.Has(EEventName.ClearWorld, new Action(this.OnClearWorld)))
			{
				Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnClearWorld));
			}
			return true;
		}

		// Token: 0x06043A03 RID: 276995 RVA: 0x01171CEC File Offset: 0x0116FEEC
		protected override bool OnClear()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.ClearWorld, new Action(this.OnClearWorld)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.OnClearWorld));
			}
			return true;
		}

		// Token: 0x06043A04 RID: 276996 RVA: 0x01171D28 File Offset: 0x0116FF28
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SplineMoveTaskBase> GetEntitySplineMoveTasks(long entityId)
		{
			List<SplineMoveTaskBase> result;
			this.EntitySplineMoveTasks.TryGetValue(entityId, out result);
			return result;
		}

		// Token: 0x06043A05 RID: 276997 RVA: 0x01171D48 File Offset: 0x0116FF48
		[NullableContext(2)]
		public SplineMoveTaskBase GetEntityCurSplineMoveTask(long entityId)
		{
			List<SplineMoveTaskBase> list;
			if (this.EntitySplineMoveTasks.TryGetValue(entityId, out list) && list != null && list.Count > 0)
			{
				return list[0];
			}
			return null;
		}

		// Token: 0x06043A06 RID: 276998 RVA: 0x01171D7C File Offset: 0x0116FF7C
		public void EndEntityTasks(long entityId)
		{
			List<SplineMoveTaskBase> entitySplineMoveTasks = this.GetEntitySplineMoveTasks(entityId);
			if (entitySplineMoveTasks == null || entitySplineMoveTasks.Count == 0)
			{
				return;
			}
			foreach (SplineMoveTaskBase splineMoveTaskBase in entitySplineMoveTasks.ToList<SplineMoveTaskBase>())
			{
				splineMoveTaskBase.EndTask(false);
			}
		}

		// Token: 0x06043A07 RID: 276999 RVA: 0x01171DE4 File Offset: 0x0116FFE4
		public bool RegisterTask(SplineMoveTaskBase task)
		{
			if (!task.EntityHandle.Valid)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[SplineMoveTaskController] Task所属实体非valid，不允许注册";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", task.EntityHandle.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			List<SplineMoveTaskBase> list;
			if (!this.EntitySplineMoveTasks.TryGetValue((long)task.EntityHandle.Id, out list) || list == null)
			{
				list = new List<SplineMoveTaskBase>();
				this.EntitySplineMoveTasks[(long)task.EntityHandle.Id] = list;
			}
			else if (list.Contains(task))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelPlay;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[SplineMoveTaskController] Task已注册过，可能存在错误导致重复注册";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", task.EntityHandle.Id);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return true;
			}
			list.Add(task);
			if (task.EntityHandle != null && !Singleton<EventSystem>.Instance.HasWithTarget(task.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(task.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			}
			return true;
		}

		// Token: 0x06043A08 RID: 277000 RVA: 0x01171F0C File Offset: 0x0117010C
		public bool UnregisterTask(SplineMoveTaskBase task)
		{
			List<SplineMoveTaskBase> list;
			if (this.EntitySplineMoveTasks.TryGetValue((long)task.EntityHandle.Id, out list) && list != null)
			{
				int num = list.IndexOf(task);
				if (num != -1)
				{
					list.RemoveAt(num);
				}
			}
			if (task.EntityHandle != null && Singleton<EventSystem>.Instance.HasWithTarget(task.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(task.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			}
			return true;
		}

		// Token: 0x06043A09 RID: 277001 RVA: 0x01171F98 File Offset: 0x01170198
		protected void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelPlay;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[SplineMoveTaskController] 检测到移动实体被销毁，直接结束Task";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", handle.Id);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			List<SplineMoveTaskBase> entitySplineMoveTasks = this.GetEntitySplineMoveTasks((long)handle.Id);
			if (entitySplineMoveTasks == null || entitySplineMoveTasks.Count == 0)
			{
				return;
			}
			foreach (SplineMoveTaskBase splineMoveTaskBase in entitySplineMoveTasks.ToList<SplineMoveTaskBase>())
			{
				splineMoveTaskBase.EndTask(false);
			}
		}

		// Token: 0x06043A0A RID: 277002 RVA: 0x01172034 File Offset: 0x01170234
		protected void OnClearWorld()
		{
			Singleton<Log>.Instance.Warn(ELogModule.LevelPlay, ELogAuthor.ZYL, "[SplineMoveTaskController]检测到世界清理，结束所有Task", default(ReadOnlySpan<ValueTuple<string, object>>));
			List<SplineMoveTaskBase> list = new List<SplineMoveTaskBase>();
			foreach (KeyValuePair<long, List<SplineMoveTaskBase>> keyValuePair in this.EntitySplineMoveTasks)
			{
				List<SplineMoveTaskBase> value = keyValuePair.Value;
				if (value != null && value.Count != 0)
				{
					list.AddRange(value);
				}
			}
			foreach (SplineMoveTaskBase splineMoveTaskBase in list)
			{
				splineMoveTaskBase.EndTask(false);
			}
		}

		// Token: 0x04025C94 RID: 154772
		private readonly Dictionary<long, List<SplineMoveTaskBase>> EntitySplineMoveTasks = new Dictionary<long, List<SplineMoveTaskBase>>();
	}
}
