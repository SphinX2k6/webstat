using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056F1 RID: 22257
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MovieModeModel : ModelBase<MovieModeModel>
	{
		// Token: 0x06038A38 RID: 231992 RVA: 0x00E57A11 File Offset: 0x00E55C11
		protected override bool OnInit()
		{
			this.InitParameters();
			return true;
		}

		// Token: 0x06038A39 RID: 231993 RVA: 0x00E57A1C File Offset: 0x00E55C1C
		private void InitParameters()
		{
			this.MovieModeHideUiTimeThreshold = ConfigCommonParamById.GetIntConfig("MovieModeHideUiTimeThreshold").GetValueOrDefault(1);
			this.MovieModeHideUiTimeThreshold *= 1000;
		}

		// Token: 0x06038A3A RID: 231994 RVA: 0x00E57A54 File Offset: 0x00E55C54
		public void FreezeUi(string reason)
		{
			this.FreezeReason.Add(reason);
		}

		// Token: 0x06038A3B RID: 231995 RVA: 0x00E57A63 File Offset: 0x00E55C63
		public void UnFreezeUi(string reason)
		{
			this.FreezeReason.Remove(reason);
		}

		// Token: 0x17009112 RID: 37138
		// (get) Token: 0x06038A3C RID: 231996 RVA: 0x00E57A72 File Offset: 0x00E55C72
		public bool IsFreezingUi
		{
			get
			{
				return this.FreezeReason.Count > 0;
			}
		}

		// Token: 0x06038A3D RID: 231997 RVA: 0x00E57A82 File Offset: 0x00E55C82
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x040204DB RID: 132315
		public int MovieModeHideUiTimeThreshold;

		// Token: 0x040204DC RID: 132316
		private readonly HashSet<string> FreezeReason = new HashSet<string>();
	}
}
