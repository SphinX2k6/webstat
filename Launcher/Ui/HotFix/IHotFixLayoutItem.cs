using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004509 RID: 17673
	[NullableContext(1)]
	public interface IHotFixLayoutItem
	{
		// Token: 0x0602E916 RID: 190742
		void SetRootActor(AActor actor);

		// Token: 0x0602E917 RID: 190743
		void Refresh(IHotFixLayoutData data);

		// Token: 0x0602E918 RID: 190744
		void SetActive(bool active);

		// Token: 0x0602E919 RID: 190745
		void Destroy();
	}
}
