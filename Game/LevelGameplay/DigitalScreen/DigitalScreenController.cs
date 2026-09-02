using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DigitalScreen
{
	// Token: 0x02006F1F RID: 28447
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class DigitalScreenController : UiControllerBase<DigitalScreenController>
	{
		// Token: 0x06044E5C RID: 282204 RVA: 0x011EEDD4 File Offset: 0x011ECFD4
		public UniTask<bool> OpenDigitalScreenById(int index, [Nullable(2)] object param = null, bool isPlot = false)
		{
			DigitalScreenController.<OpenDigitalScreenById>d__0 <OpenDigitalScreenById>d__;
			<OpenDigitalScreenById>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenDigitalScreenById>d__.index = index;
			<OpenDigitalScreenById>d__.param = param;
			<OpenDigitalScreenById>d__.isPlot = isPlot;
			<OpenDigitalScreenById>d__.<>1__state = -1;
			<OpenDigitalScreenById>d__.<>t__builder.Start<DigitalScreenController.<OpenDigitalScreenById>d__0>(ref <OpenDigitalScreenById>d__);
			return <OpenDigitalScreenById>d__.<>t__builder.Task;
		}
	}
}
