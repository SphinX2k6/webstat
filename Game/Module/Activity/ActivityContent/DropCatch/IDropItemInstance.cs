using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x0200688B RID: 26763
	[NullableContext(1)]
	public interface IDropItemInstance
	{
		// Token: 0x06042AE0 RID: 273120
		UniTask OnInit(IDropCatchDropItemParams @params);

		// Token: 0x06042AE1 RID: 273121
		void OnTick(float deltaTime);

		// Token: 0x06042AE2 RID: 273122
		IDropCatchBounds GetItemBounds();

		// Token: 0x06042AE3 RID: 273123
		void OnCollision(IRoleInstance role);

		// Token: 0x06042AE4 RID: 273124
		int GetInstanceId();

		// Token: 0x06042AE5 RID: 273125
		int GetItemId();

		// Token: 0x06042AE6 RID: 273126
		void OnRecycle();

		// Token: 0x06042AE7 RID: 273127
		void Destroy();
	}
}
