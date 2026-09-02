using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002CED RID: 11501
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class WaitEntityTaskController : ControllerBase<WaitEntityTaskController>
{
	// Token: 0x0601730A RID: 94986 RVA: 0x0066D336 File Offset: 0x0066B536
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.OnAddEntity));
		Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		return true;
	}

	// Token: 0x0601730B RID: 94987 RVA: 0x0066D371 File Offset: 0x0066B571
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.OnAddEntity));
		Singleton<EventSystem>.Instance.Remove(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		return true;
	}

	// Token: 0x0601730C RID: 94988 RVA: 0x0066D3AC File Offset: 0x0066B5AC
	private void OnAddEntity(EAddEntityType addType, EntityHandle handle, [Nullable(2)] AActor actor)
	{
		WorldEntity entity = handle.Entity;
		CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
		long? num = (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null;
		int? num2 = (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null;
		ModelBase<WaitEntityTaskModel>.Instance.OnAddEntity(num.GetValueOrDefault(), num2.GetValueOrDefault());
	}

	// Token: 0x0601730D RID: 94989 RVA: 0x0066D418 File Offset: 0x0066B618
	private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		WorldEntity entity = handle.Entity;
		CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
		long? num = (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null;
		int? num2 = (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null;
		ModelBase<WaitEntityTaskModel>.Instance.OnRemoveEntity(num.GetValueOrDefault(), num2.GetValueOrDefault());
	}

	// Token: 0x0601730E RID: 94990 RVA: 0x0066D484 File Offset: 0x0066B684
	public int AddTask(WaitEntityTask task)
	{
		int taskId = this.TaskId;
		this.TaskId = taskId + 1;
		int num = taskId;
		ModelBase<WaitEntityTaskModel>.Instance.AddTask(num, task);
		return num;
	}

	// Token: 0x0601730F RID: 94991 RVA: 0x0066D4B0 File Offset: 0x0066B6B0
	public void RemoveTask(int taskId)
	{
		ModelBase<WaitEntityTaskModel>.Instance.RemoveTask(taskId);
	}

	// Token: 0x0400B270 RID: 45680
	private int TaskId;
}
