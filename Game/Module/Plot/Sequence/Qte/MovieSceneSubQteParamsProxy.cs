using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.Sequence.Qte
{
	// Token: 0x0200538F RID: 21391
	[NullableContext(2)]
	[Nullable(0)]
	public class MovieSceneSubQteParamsProxy
	{
		// Token: 0x060368D6 RID: 223446 RVA: 0x00DCA265 File Offset: 0x00DC8465
		public MovieSceneSubQteParamsProxy(int subQteId, QteSpineInfoProxy spineInfo)
		{
			this.SubQteId = subQteId;
			this.SpineInfo = spineInfo;
		}

		// Token: 0x0401F6D0 RID: 128720
		public readonly int SubQteId;

		// Token: 0x0401F6D1 RID: 128721
		public readonly QteSpineInfoProxy SpineInfo;
	}
}
