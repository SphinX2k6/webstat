using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A34 RID: 18996
	public class SceneUiInfo
	{
		// Token: 0x0401CE45 RID: 118341
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<SceneUiView> CreateView;

		// Token: 0x0401CE46 RID: 118342
		[Nullable(1)]
		public string ResourceId = string.Empty;
	}
}
