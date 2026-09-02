using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;
using UnrealEngine;

// Token: 0x0200347B RID: 13435
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
[TickController(0)]
public class SceneOpacityController : ControllerBase<SceneOpacityController>
{
	// Token: 0x0601C564 RID: 116068 RVA: 0x0087CFB6 File Offset: 0x0087B1B6
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0601C565 RID: 116069 RVA: 0x0087CFB9 File Offset: 0x0087B1B9
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x0601C566 RID: 116070 RVA: 0x0087CFBC File Offset: 0x0087B1BC
	protected override bool OnLeaveLevel()
	{
		return true;
	}

	// Token: 0x0601C567 RID: 116071 RVA: 0x0087CFC0 File Offset: 0x0087B1C0
	protected override void OnTick(float delta)
	{
		SceneOpacityModel instance = ModelBase<SceneOpacityModel>.Instance;
		if (instance == null)
		{
			return;
		}
		Dictionary<UStaticMeshComponent, float> currentOpacityMap = instance.CurrentOpacityMap;
		this.PendingRemoveComponents.Clear();
		foreach (KeyValuePair<UStaticMeshComponent, float> keyValuePair in currentOpacityMap)
		{
			UStaticMeshComponent ustaticMeshComponent;
			float num;
			keyValuePair.Deconstruct(out ustaticMeshComponent, out num);
			UStaticMeshComponent ustaticMeshComponent2 = ustaticMeshComponent;
			float num2 = num;
			if (ustaticMeshComponent2 == null || !ustaticMeshComponent2.IsValid())
			{
				this.PendingRemoveComponents.Add(ustaticMeshComponent2);
			}
			else
			{
				float num3;
				if (instance.IsAffected(ustaticMeshComponent2))
				{
					num3 = Math.Max(0.2f, num2 - 0.001f * delta);
				}
				else
				{
					num3 = Math.Min(1f, num2 + 0.001f * delta);
				}
				if (num3 >= 1f)
				{
					ustaticMeshComponent2.SetKuroOpacity(1f);
					ustaticMeshComponent2.SetUseKuroOpacity(false);
					this.PendingRemoveComponents.Add(ustaticMeshComponent2);
				}
				else
				{
					ustaticMeshComponent2.SetUseKuroOpacity(true);
					ustaticMeshComponent2.SetKuroOpacity(num3);
					currentOpacityMap[ustaticMeshComponent2] = num3;
				}
			}
		}
		foreach (UStaticMeshComponent key in this.PendingRemoveComponents)
		{
			currentOpacityMap.Remove(key);
			instance.OpacityComponentMap.Remove(key);
		}
		this.PendingRemoveComponents.Clear();
		if (currentOpacityMap.Count == 0)
		{
			base.PauseTick();
		}
	}

	// Token: 0x0601C568 RID: 116072 RVA: 0x0087D140 File Offset: 0x0087B340
	public void SetOpacity(UStaticMeshComponent component, int entityId, bool enable)
	{
		if (enable)
		{
			if (ModelBase<SceneOpacityModel>.Instance.OpacityComponentMap.Count == 0)
			{
				base.ResumeTick();
			}
			ModelBase<SceneOpacityModel>.Instance.AddOpacityEntity(component, entityId);
			return;
		}
		ModelBase<SceneOpacityModel>.Instance.RemoveOpacityEntity(component, entityId);
	}

	// Token: 0x0400E3E2 RID: 58338
	private readonly List<UStaticMeshComponent> PendingRemoveComponents = new List<UStaticMeshComponent>();
}
