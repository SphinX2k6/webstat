using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C77 RID: 19575
	[NullableContext(2)]
	[Nullable(0)]
	public class OperationParam<T>
	{
		// Token: 0x0603301D RID: 208925 RVA: 0x00CC6752 File Offset: 0x00CC4952
		public OperationParam([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<T> data = null, bool keepContentPosition = false, Action callBack = null, bool playGridAnim = false)
		{
		}

		// Token: 0x0401DAB3 RID: 121523
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlyList<T> Data = data;

		// Token: 0x0401DAB4 RID: 121524
		public bool KeepContentPosition = keepContentPosition;

		// Token: 0x0401DAB5 RID: 121525
		public Action CallBack = callBack;

		// Token: 0x0401DAB6 RID: 121526
		public bool PlayGridAnim = playGridAnim;
	}
}
