using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020030C1 RID: 12481
[NullableContext(1)]
[Nullable(0)]
public class SceneComponentPool<[Nullable(0)] T> where T : USceneComponent
{
	// Token: 0x06019B8A RID: 105354 RVA: 0x0077C4C4 File Offset: 0x0077A6C4
	protected virtual void ActiveComponent(T component)
	{
	}

	// Token: 0x06019B8B RID: 105355 RVA: 0x0077C4C6 File Offset: 0x0077A6C6
	protected virtual void CleanComponent(T component)
	{
	}

	// Token: 0x06019B8C RID: 105356 RVA: 0x0077C4C8 File Offset: 0x0077A6C8
	[NullableContext(2)]
	protected virtual T CreateComponent()
	{
		return default(T);
	}

	// Token: 0x06019B8D RID: 105357 RVA: 0x0077C4E0 File Offset: 0x0077A6E0
	public List<T> GetComponents(int num, bool bIncludeUsed = true, bool bCleanUsed = false)
	{
		int num2 = (num > this.MaxPoolSize) ? this.MaxPoolSize : num;
		int num3 = bIncludeUsed ? 0 : num2;
		List<T> list = new List<T>();
		if (bIncludeUsed)
		{
			int num4 = num2;
			int count = this.UsedPoolInternal.Count;
			if (num2 > count)
			{
				num4 = count;
				num3 = num2 - count;
			}
			else
			{
				int num5 = count - num2;
				for (int i = 0; i < num5; i++)
				{
					T component = this.UsedPoolInternal[this.UsedPoolInternal.Count - 1];
					this.UsedPoolInternal.RemoveAt(this.UsedPoolInternal.Count - 1);
					this.BasePoolPush(component, true);
				}
			}
			for (int j = 0; j < num4; j++)
			{
				this.PoolPushInternal(this.UsedPoolInternal[j], list, false);
				if (bCleanUsed)
				{
					this.CleanComponent(this.UsedPoolInternal[j]);
				}
			}
		}
		if (num3 > 0)
		{
			int num6 = 0;
			int count2 = this.BasePoolInternal.Count;
			if (num3 > count2)
			{
				num6 = num3 - count2;
				num3 = count2;
			}
			for (int k = 0; k < num3; k++)
			{
				T component2 = this.BasePoolInternal[this.BasePoolInternal.Count - 1];
				this.BasePoolInternal.RemoveAt(this.BasePoolInternal.Count - 1);
				this.PoolPushInternal(component2, list, false);
				this.UsedPoolPush(component2, false);
			}
			for (int l = 0; l < num6; l++)
			{
				T t = this.CreateComponent();
				if (t != null)
				{
					this.PoolPushInternal(t, list, false);
					this.UsedPoolPush(t, false);
				}
			}
		}
		foreach (T component3 in list)
		{
			this.ActiveComponent(component3);
		}
		return list;
	}

	// Token: 0x06019B8E RID: 105358 RVA: 0x0077C6B8 File Offset: 0x0077A8B8
	public bool BackComponent(List<T> components)
	{
		bool result = true;
		foreach (T item in components)
		{
			if (this.UsedPoolInternal.Contains(item))
			{
				int index = this.UsedPoolInternal.IndexOf(item);
				this.BasePoolInternal.Add(item);
				this.UsedPoolInternal.RemoveAt(index);
			}
			else
			{
				result = false;
			}
		}
		return result;
	}

	// Token: 0x06019B8F RID: 105359 RVA: 0x0077C73C File Offset: 0x0077A93C
	public void Init(int maxSize, USceneComponent attachComponent, AActor actor, List<T> components, bool bInUsed = false, bool bResetComponent = false)
	{
		if (attachComponent == null || actor == null || maxSize <= 0)
		{
			return;
		}
		this.ActorInternal = actor;
		this.MaxPoolSize = maxSize;
		this.AttachComponentInternal = attachComponent;
		int count = components.Count;
		int num = (maxSize < count) ? maxSize : count;
		for (int i = 0; i < num; i++)
		{
			T t = components[i];
			MeshComponentUtils.RelativeAttachComponentOnSafe(t, this.AttachComponentInternal, "");
			if (!this.PoolPush(t, bInUsed, bResetComponent))
			{
				break;
			}
		}
	}

	// Token: 0x06019B90 RID: 105360 RVA: 0x0077C7B3 File Offset: 0x0077A9B3
	protected bool CheckPoolRange()
	{
		return this.BasePoolInternal.Count + this.UsedPoolInternal.Count < this.MaxPoolSize;
	}

	// Token: 0x06019B91 RID: 105361 RVA: 0x0077C7D4 File Offset: 0x0077A9D4
	protected bool PoolPush(T component, bool bInUsed = false, bool bResetComponent = true)
	{
		if (!this.CheckPoolRange())
		{
			return false;
		}
		if (bInUsed)
		{
			this.BasePoolPush(component, bResetComponent);
		}
		else
		{
			this.UsedPoolPush(component, bResetComponent);
		}
		return true;
	}

	// Token: 0x06019B92 RID: 105362 RVA: 0x0077C7F6 File Offset: 0x0077A9F6
	protected void BasePoolPush(T component, bool bResetComponent = true)
	{
		this.PoolPushInternal(component, this.BasePoolInternal, bResetComponent);
	}

	// Token: 0x06019B93 RID: 105363 RVA: 0x0077C806 File Offset: 0x0077AA06
	protected void UsedPoolPush(T component, bool bResetComponent = false)
	{
		this.PoolPushInternal(component, this.UsedPoolInternal, bResetComponent);
	}

	// Token: 0x06019B94 RID: 105364 RVA: 0x0077C816 File Offset: 0x0077AA16
	protected void PoolPushInternal(T component, List<T> pool, bool bResetComponent = true)
	{
		pool.Add(component);
		if (bResetComponent)
		{
			this.CleanComponent(component);
		}
	}

	// Token: 0x06019B95 RID: 105365 RVA: 0x0077C82C File Offset: 0x0077AA2C
	public void Shrink()
	{
		foreach (T t in this.BasePoolInternal)
		{
			t.K2_DestroyComponent(this.ActorInternal);
		}
		this.BasePoolInternal.Clear();
	}

	// Token: 0x06019B96 RID: 105366 RVA: 0x0077C894 File Offset: 0x0077AA94
	public int GetUsedLength()
	{
		return this.UsedPoolInternal.Count;
	}

	// Token: 0x0400CCEE RID: 52462
	private readonly List<T> BasePoolInternal = new List<T>();

	// Token: 0x0400CCEF RID: 52463
	private readonly List<T> UsedPoolInternal = new List<T>();

	// Token: 0x0400CCF0 RID: 52464
	[Nullable(2)]
	protected USceneComponent AttachComponentInternal;

	// Token: 0x0400CCF1 RID: 52465
	[Nullable(2)]
	protected AActor ActorInternal;

	// Token: 0x0400CCF2 RID: 52466
	protected int MaxPoolSize;
}
