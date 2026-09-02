using System;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x02006190 RID: 24976
	public class DetectionRecord<T> where T : struct
	{
		// Token: 0x0603F19F RID: 258463 RVA: 0x0102EA67 File Offset: 0x0102CC67
		public DetectionRecord(in T conf, bool isLock, long? refreshTime)
		{
			this.IsLock = isLock;
			this.RefreshTime = refreshTime;
			this.ConfInternal = new T?(conf);
		}

		// Token: 0x17009B10 RID: 39696
		// (get) Token: 0x0603F1A0 RID: 258464 RVA: 0x0102EA9B File Offset: 0x0102CC9B
		public T Conf
		{
			get
			{
				return this.ConfInternal.Value;
			}
		}

		// Token: 0x0402367E RID: 145022
		private readonly T? ConfInternal;

		// Token: 0x0402367F RID: 145023
		public bool IsLock;

		// Token: 0x04023680 RID: 145024
		public long? RefreshTime = new long?(0L);

		// Token: 0x04023681 RID: 145025
		public bool IsTargeting;
	}
}
