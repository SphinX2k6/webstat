using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Login
{
	// Token: 0x02005A0B RID: 23051
	[NullableContext(1)]
	[Nullable(0)]
	public class LoginServerDynItem : UiPanelBase, IDynamicScrollBaseItem<ILoginServersData>
	{
		// Token: 0x0603A601 RID: 239105 RVA: 0x00ECD2EC File Offset: 0x00ECB4EC
		public UniTask Init(UUIItem actor)
		{
			LoginServerDynItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<LoginServerDynItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603A602 RID: 239106 RVA: 0x00ECD338 File Offset: 0x00ECB538
		public FVector2D GetItemSize(ILoginServersData data)
		{
			if (this.ItemSizeVector == null)
			{
				this.ItemSizeVector = Vector2D.Create();
			}
			UUIItem rootItem = base.GetRootItem();
			this.ItemSizeVector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
			return this.ItemSizeVector.ToUeVector2D(true);
		}

		// Token: 0x0603A603 RID: 239107 RVA: 0x00ECD384 File Offset: 0x00ECB584
		public AUIBaseActor GetUsingItem()
		{
			return base.GetRootItem().GetOwner() as AUIBaseActor;
		}

		// Token: 0x0603A604 RID: 239108 RVA: 0x00ECD396 File Offset: 0x00ECB596
		public void ClearItem()
		{
		}

		// Token: 0x040210ED RID: 135405
		[Nullable(2)]
		private Vector2D ItemSizeVector;
	}
}
