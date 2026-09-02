using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Section
{
	// Token: 0x02006F7D RID: 28541
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowData
	{
		// Token: 0x06045120 RID: 282912 RVA: 0x01202DD5 File Offset: 0x01200FD5
		public virtual void Init()
		{
		}

		// Token: 0x06045121 RID: 282913 RVA: 0x01202DD7 File Offset: 0x01200FD7
		protected void Register(TSectionCreator creator)
		{
			this.SectionMap.Add(this.Capacity, creator);
			this.Capacity++;
		}

		// Token: 0x06045122 RID: 282914 RVA: 0x01202DFC File Offset: 0x01200FFC
		[NullableContext(2)]
		public LevelFlowSection GetSection(int index)
		{
			TSectionCreator tsectionCreator;
			if (!this.SectionMap.TryGetValue(index, out tsectionCreator))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 1);
				defaultInterpolatedStringHandler.AppendLiteral("LevelFlowSection index=");
				defaultInterpolatedStringHandler.AppendFormatted<int>(index);
				defaultInterpolatedStringHandler.AppendLiteral(" not registered.");
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return tsectionCreator();
		}

		// Token: 0x06045123 RID: 282915 RVA: 0x01202E6C File Offset: 0x0120106C
		public int GetCapacity()
		{
			return this.Capacity;
		}

		// Token: 0x040268B0 RID: 157872
		private readonly Dictionary<int, TSectionCreator> SectionMap = new Dictionary<int, TSectionCreator>();

		// Token: 0x040268B1 RID: 157873
		private int Capacity;
	}
}
