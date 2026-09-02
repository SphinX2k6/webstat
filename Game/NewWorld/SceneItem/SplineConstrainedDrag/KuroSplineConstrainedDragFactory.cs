using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface;

namespace CSharpScript.Game.NewWorld.SceneItem.SplineConstrainedDrag
{
	// Token: 0x02004820 RID: 18464
	public class KuroSplineConstrainedDragFactory
	{
		// Token: 0x060300C7 RID: 196807 RVA: 0x00BA4FAC File Offset: 0x00BA31AC
		[NullableContext(1)]
		public static TsKuroSplineConstrainedDragImpl Create(IKuroSplineConstrainedDragParam param)
		{
			return new TsKuroSplineConstrainedDragImpl(param);
		}
	}
}
