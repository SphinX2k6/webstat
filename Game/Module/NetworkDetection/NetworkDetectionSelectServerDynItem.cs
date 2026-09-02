using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.NetworkDetection
{
	// Token: 0x020056C6 RID: 22214
	[NullableContext(1)]
	[Nullable(0)]
	public class NetworkDetectionSelectServerDynItem : UiPanelBase, IDynamicScrollBaseItem<ILoginServersData>
	{
		// Token: 0x0603889C RID: 231580 RVA: 0x00E529FC File Offset: 0x00E50BFC
		public UniTask Init(UUIItem actor)
		{
			NetworkDetectionSelectServerDynItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<NetworkDetectionSelectServerDynItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603889D RID: 231581 RVA: 0x00E52A48 File Offset: 0x00E50C48
		public FVector2D GetItemSize(ILoginServersData data)
		{
			if (this.ItemSizeVector == null)
			{
				this.ItemSizeVector = Vector2D.Create();
			}
			UUIItem rootItem = base.GetRootItem();
			this.ItemSizeVector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
			return this.ItemSizeVector.ToUeVector2D(false);
		}

		// Token: 0x0603889E RID: 231582 RVA: 0x00E52A94 File Offset: 0x00E50C94
		public AUIBaseActor GetUsingItem()
		{
			return base.GetRootItem().GetOwner() as AUIBaseActor;
		}

		// Token: 0x0603889F RID: 231583 RVA: 0x00E52AA6 File Offset: 0x00E50CA6
		public void ClearItem()
		{
		}

		// Token: 0x04020449 RID: 132169
		[Nullable(2)]
		private Vector2D ItemSizeVector;
	}
}
