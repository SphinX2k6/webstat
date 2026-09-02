using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002C86 RID: 11398
public class UiModelInputDataComponent : UiModelComponentBase
{
	// Token: 0x06016DDD RID: 93661 RVA: 0x006583F7 File Offset: 0x006565F7
	public float GetAxisInput(ERotateAxis axis)
	{
		return this.AxisInputMap.GetValueOrDefault(axis, 0f);
	}

	// Token: 0x06016DDE RID: 93662 RVA: 0x0065840A File Offset: 0x0065660A
	public void UpdateAxisInput(ERotateAxis axis, float inputValue)
	{
		this.AxisInputMap[axis] = inputValue;
	}

	// Token: 0x0400B070 RID: 45168
	[Nullable(1)]
	private readonly Dictionary<ERotateAxis, float> AxisInputMap = new Dictionary<ERotateAxis, float>
	{
		{
			ERotateAxis.Pitch,
			0f
		},
		{
			ERotateAxis.Yaw,
			0f
		},
		{
			ERotateAxis.Roll,
			0f
		}
	};
}
