using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046F8 RID: 18168
	[NullableContext(1)]
	[Nullable(0)]
	public class FrequencyMonitor
	{
		// Token: 0x0602F3DF RID: 193503 RVA: 0x00B33CA6 File Offset: 0x00B31EA6
		public FrequencyMonitor(int time, int count, string msg, [Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] params ValueTuple<string, object>[] parameters)
		{
			this.Time = time;
			this.Count = count;
			this.Msg = msg;
			this.Params = parameters;
		}

		// Token: 0x0602F3E0 RID: 193504 RVA: 0x00B33CD8 File Offset: 0x00B31ED8
		public unsafe void Execute()
		{
			if (!Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				return;
			}
			this.ExecuteTimes.Push(Singleton<global::Time>.Instance.NowSeconds);
			while (!this.ExecuteTimes.Empty && Singleton<global::Time>.Instance.NowSeconds - this.ExecuteTimes.Front > (double)this.Time)
			{
				this.ExecuteTimes.Pop();
			}
			if (this.ExecuteTimes.Size > this.Count)
			{
				ValueTuple<string, object>[] @params = this.Params;
				int i = 0;
				ValueTuple<string, object>[] array = new ValueTuple<string, object>[5 + @params.Length];
				ReadOnlySpan<ValueTuple<string, object>> readOnlySpan = new ReadOnlySpan<ValueTuple<string, object>>(@params);
				readOnlySpan.CopyTo(new Span<ValueTuple<string, object>>(array).Slice(i, readOnlySpan.Length));
				i += readOnlySpan.Length;
				array[i] = new ValueTuple<string, object>("msg", this.Msg);
				i++;
				array[i] = new ValueTuple<string, object>("检查时间", this.Time);
				i++;
				array[i] = new ValueTuple<string, object>("检查次数", this.Count);
				i++;
				array[i] = new ValueTuple<string, object>("当前次数", this.ExecuteTimes.Size);
				i++;
				array[i] = new ValueTuple<string, object>("联机", ModelBase<GameModeModel>.Instance.IsMulti);
				ReadOnlySpan<ValueTuple<string, object>> readOnlySpan2 = new ReadOnlySpan<ValueTuple<string, object>>(array);
				Singleton<Log>.Instance.Warn(ELogModule.FrequencyMonitor, ELogAuthor.WCL, "业务逻辑执行频率过高", readOnlySpan2);
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				readOnlySpan = readOnlySpan2;
				for (i = 0; i < readOnlySpan.Length; i++)
				{
					ValueTuple<string, object> valueTuple = *readOnlySpan[i];
					string item = valueTuple.Item1;
					object item2 = valueTuple.Item2;
					dictionary[item] = item2;
				}
				string data = Json.Encode(dictionary, null);
				ControllerBase<CombatDebugController>.Instance.DataReport("FREQUENCY_MONITOR", data);
			}
		}

		// Token: 0x0401AEA7 RID: 110247
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})]
		private readonly ValueTuple<string, object>[] Params;

		// Token: 0x0401AEA8 RID: 110248
		private readonly Queue<double> ExecuteTimes = new Queue<double>(4);

		// Token: 0x0401AEA9 RID: 110249
		private readonly int Time;

		// Token: 0x0401AEAA RID: 110250
		private readonly int Count;

		// Token: 0x0401AEAB RID: 110251
		private readonly string Msg;
	}
}
