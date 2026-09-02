using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritPerform
{
	// Token: 0x02006AAF RID: 27311
	[NullableContext(1)]
	public interface ISunSpiritScenePerform
	{
		// Token: 0x06043878 RID: 276600
		[NullableContext(2)]
		bool GetTransformData(Vector outLocation = null, object outRotation = null, Vector outScale = null);

		// Token: 0x06043879 RID: 276601
		bool GetTransform(Transform outTransform);

		// Token: 0x0604387A RID: 276602
		[NullableContext(2)]
		bool SetTransformData(Vector inLocation = null, object inRotation = null, Vector inScale = null);

		// Token: 0x0604387B RID: 276603
		bool SetTransform(Transform inTransform);
	}
}
