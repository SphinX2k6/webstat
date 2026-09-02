using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x020030B8 RID: 12472
[NullableContext(1)]
[Nullable(0)]
public class EntityAddListener
{
	// Token: 0x06019B50 RID: 105296 RVA: 0x0077B0CA File Offset: 0x007792CA
	public void Init(TCbEntityAddCallback callback, TCbEntityAddFilter filter = null)
	{
		if (this.Inited)
		{
			return;
		}
		this.Inited = true;
		this.CbEntityAdd = callback;
		this.CbFilter = filter;
		Singleton<EventSystem>.Instance.Add<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.OnCreateEntity));
	}

	// Token: 0x06019B51 RID: 105297 RVA: 0x0077B106 File Offset: 0x00779306
	private void OnCreateEntity(EAddEntityType addType, EntityHandle handle, [Nullable(2)] AActor actor)
	{
		if (handle == null || !handle.Valid || this.CbEntityAdd == null)
		{
			return;
		}
		if (this.CbFilter != null && !this.CbFilter(handle))
		{
			return;
		}
		this.CbEntityAdd(handle);
	}

	// Token: 0x06019B52 RID: 105298 RVA: 0x0077B13F File Offset: 0x0077933F
	public void Clear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.OnCreateEntity));
		this.CbEntityAdd = null;
		this.CbFilter = null;
		this.Inited = false;
	}

	// Token: 0x06019B53 RID: 105299 RVA: 0x0077B174 File Offset: 0x00779374
	public static TCbDispose ListenMonsterAddOnce(TCbEntityAddCallback callback, int excludeId = 0)
	{
		EntityAddListener listener = new EntityAddListener();
		bool disposed = false;
		listener.Init(delegate(EntityHandle handle)
		{
			if (disposed)
			{
				return;
			}
			if (handle.Id == excludeId)
			{
				return;
			}
			WorldEntity entity = handle.Entity;
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
			if (creatureDataComponent == null || !creatureDataComponent.IsMonster())
			{
				return;
			}
			disposed = true;
			listener.Clear();
			callback(handle);
		}, null);
		return delegate()
		{
			if (disposed)
			{
				return;
			}
			disposed = true;
			listener.Clear();
		};
	}

	// Token: 0x0400CCBF RID: 52415
	private TCbEntityAddCallback CbEntityAdd;

	// Token: 0x0400CCC0 RID: 52416
	private TCbEntityAddFilter CbFilter;

	// Token: 0x0400CCC1 RID: 52417
	private bool Inited;
}
