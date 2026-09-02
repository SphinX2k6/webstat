using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Core.Define.TdConfigExtensions
{
	// Token: 0x02007136 RID: 28982
	// (Invoke) Token: 0x060462D9 RID: 287449
	[return: Nullable(new byte[]
	{
		0,
		0,
		1,
		1
	})]
	public delegate OneOf<UniTask<object>, object> TFunction(params object[] args);
}
