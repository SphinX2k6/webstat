using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045B9 RID: 17849
	// (Invoke) Token: 0x0602EC76 RID: 191606
	public delegate void TSDKQueryGoodsCallback(string msg, bool needReLogin, [Nullable(new byte[]
	{
		2,
		1
	})] List<IQueryGoodsResponseData> data);
}
