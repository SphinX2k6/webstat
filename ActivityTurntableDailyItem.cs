using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020015F7 RID: 5623
[Nullable(new byte[]
{
	0,
	1
})]
public class ActivityTurntableDailyItem : GridProxyAbstract<ActivityTaskData>
{
	// Token: 0x06009E81 RID: 40577 RVA: 0x00297A64 File Offset: 0x00295C64
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009E82 RID: 40578 RVA: 0x00297AD0 File Offset: 0x00295CD0
	[NullableContext(1)]
	public override void Refresh(ActivityTaskData data, bool isSelected, int gridIndex)
	{
		base.GetSprite(0).SetUIActive(data.Status == EActivityTaskState.FinishedAndClaimed);
		TurntableTask? turntableTaskByTaskId = ConfigBase<ActivityTurntableConfig>.Instance.GetTurntableTaskByTaskId(data.Id);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), turntableTaskByTaskId.Value.TaskDescription, new <>z__ReadOnlyArray<object>(new object[]
		{
			data.Current.ToString(),
			data.Target.ToString()
		}));
	}

	// Token: 0x020079B8 RID: 31160
	private class EDailyItemComponents
	{
		// Token: 0x04029CBE RID: 171198
		public const int SpriteFinished = 0;

		// Token: 0x04029CBF RID: 171199
		public const int Name = 1;
	}
}
