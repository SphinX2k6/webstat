using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Common.InputView.View
{
	// Token: 0x02005E77 RID: 24183
	// (Invoke) Token: 0x0603CD2C RID: 249132
	public delegate UniTask<ErrorCode> TConfirm([Nullable(1)] string inputText);
}
