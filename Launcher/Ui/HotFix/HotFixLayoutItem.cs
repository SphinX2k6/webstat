using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x0200450A RID: 17674
	public class HotFixLayoutItem : IHotFixLayoutItem
	{
		// Token: 0x0602E91A RID: 190746 RVA: 0x00B08AB5 File Offset: 0x00B06CB5
		[NullableContext(1)]
		public virtual void SetRootActor(AActor actor)
		{
		}

		// Token: 0x0602E91B RID: 190747 RVA: 0x00B08AB7 File Offset: 0x00B06CB7
		[NullableContext(1)]
		public virtual void Refresh(IHotFixLayoutData data)
		{
		}

		// Token: 0x0602E91C RID: 190748 RVA: 0x00B08AB9 File Offset: 0x00B06CB9
		public virtual void SetActive(bool active)
		{
		}

		// Token: 0x0602E91D RID: 190749 RVA: 0x00B08ABB File Offset: 0x00B06CBB
		public virtual void Destroy()
		{
		}
	}
}
