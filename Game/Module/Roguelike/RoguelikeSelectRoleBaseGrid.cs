using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005198 RID: 20888
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeSelectRoleBaseGrid : UiPanelBase, IDynamicScrollBaseItem<RoguelikeSelectRoleData>
	{
		// Token: 0x06035BA8 RID: 220072 RVA: 0x00D80E20 File Offset: 0x00D7F020
		public FVector2D GetItemSize(RoguelikeSelectRoleData data)
		{
			if (this.ItemSizeVector == null)
			{
				this.ItemSizeVector = Vector2D.Create();
			}
			UUIItem rootItem = base.GetRootItem();
			this.ItemSizeVector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
			return this.ItemSizeVector.ToUeVector2D(false);
		}

		// Token: 0x06035BA9 RID: 220073 RVA: 0x00D80E6C File Offset: 0x00D7F06C
		public UniTask Init(UUIItem actor)
		{
			RoguelikeSelectRoleBaseGrid.<Init>d__2 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<RoguelikeSelectRoleBaseGrid.<Init>d__2>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06035BAA RID: 220074 RVA: 0x00D80EB7 File Offset: 0x00D7F0B7
		public void ClearItem()
		{
		}

		// Token: 0x0401ED54 RID: 126292
		private Vector2D ItemSizeVector;
	}
}
