using System;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02000BC6 RID: 3014
public static class KuroGameBudgetAllocatorInterface
{
	// Token: 0x06003135 RID: 12597 RVA: 0x0001BB10 File Offset: 0x00019D10
	public static void OnObjectUpdate(IntPtr gcHandlePtr, float deltaSeconds, int deltaFrames, float distance)
	{
		IGameBudgetManagedObject gameBudgetManagedObject = GCHandle.FromIntPtr(gcHandlePtr).Target as IGameBudgetManagedObject;
		if (gameBudgetManagedObject != null)
		{
			gameBudgetManagedObject.ScheduledTick(deltaSeconds, deltaFrames, distance);
		}
	}

	// Token: 0x06003136 RID: 12598 RVA: 0x0001BB40 File Offset: 0x00019D40
	public static void OnObjectLateUpdate(IntPtr gcHandlePtr, float deltaSeconds, int deltaFrames, float distance)
	{
		IGameBudgetManagedObject gameBudgetManagedObject = GCHandle.FromIntPtr(gcHandlePtr).Target as IGameBudgetManagedObject;
		if (gameBudgetManagedObject != null)
		{
			gameBudgetManagedObject.ScheduledAfterTick(deltaSeconds, deltaFrames, distance);
		}
	}

	// Token: 0x06003137 RID: 12599 RVA: 0x0001BB70 File Offset: 0x00019D70
	public static void OnObjectEnabledChange(IntPtr gcHandlePtr, bool enable, float distance)
	{
		IGameBudgetManagedObject gameBudgetManagedObject = GCHandle.FromIntPtr(gcHandlePtr).Target as IGameBudgetManagedObject;
		if (gameBudgetManagedObject != null)
		{
			gameBudgetManagedObject.OnEnabledChange(enable, distance);
		}
	}

	// Token: 0x06003138 RID: 12600 RVA: 0x0001BB9C File Offset: 0x00019D9C
	public static void OnObjectWasRecentlyRenderedChange(IntPtr gcHandlePtr, bool wasRecentlyRendered)
	{
		IGameBudgetManagedObject gameBudgetManagedObject = GCHandle.FromIntPtr(gcHandlePtr).Target as IGameBudgetManagedObject;
		if (gameBudgetManagedObject != null)
		{
			gameBudgetManagedObject.OnWasRecentlyRenderedOnScreenChange(wasRecentlyRendered);
		}
	}

	// Token: 0x06003139 RID: 12601 RVA: 0x0001BBC8 File Offset: 0x00019DC8
	public unsafe static void ObjectLocationProxyFunction(IntPtr gcHandlePtr, void* inLocationPtr)
	{
		IGameBudgetManagedObject gameBudgetManagedObject = GCHandle.FromIntPtr(gcHandlePtr).Target as IGameBudgetManagedObject;
		if (gameBudgetManagedObject != null)
		{
			FVectorDouble? fvectorDouble = gameBudgetManagedObject.LocationProxyFunction();
			if (fvectorDouble != null)
			{
				((FVectorDouble*)inLocationPtr)->X = fvectorDouble.Value.X;
				((FVectorDouble*)inLocationPtr)->Y = fvectorDouble.Value.Y;
				((FVectorDouble*)inLocationPtr)->Z = fvectorDouble.Value.Z;
			}
		}
	}

	// Token: 0x0600313A RID: 12602 RVA: 0x0001BC34 File Offset: 0x00019E34
	public unsafe static void OnceTaskIsEmptyFunction(void* inGroupIdPtr, void** inResultPtr)
	{
		IGameBudgetOnceTaskGroup onceTaskGroupById = Singleton<GameBudgetInterfaceController>.Instance.GetOnceTaskGroupById(*(FName*)inGroupIdPtr);
		if (onceTaskGroupById != null)
		{
			*(*(IntPtr*)inResultPtr) = (onceTaskGroupById.IsEmpty() ? 1 : 0);
		}
	}

	// Token: 0x0600313B RID: 12603 RVA: 0x0001BC64 File Offset: 0x00019E64
	public unsafe static void OnceTaskConsumeFunction(void* inGroupIdPtr)
	{
		IGameBudgetOnceTaskGroup onceTaskGroupById = Singleton<GameBudgetInterfaceController>.Instance.GetOnceTaskGroupById(*(FName*)inGroupIdPtr);
		if (onceTaskGroupById != null)
		{
			onceTaskGroupById.Consume();
		}
	}
}
