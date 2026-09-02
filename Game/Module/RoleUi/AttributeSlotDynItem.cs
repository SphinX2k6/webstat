using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x02005058 RID: 20568
	[NullableContext(1)]
	[Nullable(0)]
	public class AttributeSlotDynItem : UiPanelBase, IDynamicScrollBaseItem<IAttributeInfo>
	{
		// Token: 0x06034F3F RID: 216895 RVA: 0x00D4753C File Offset: 0x00D4573C
		public FVector2D GetItemSize(IAttributeInfo data)
		{
			if (this.ItemSizeVector == null)
			{
				this.ItemSizeVector = Vector2D.Create();
			}
			UUIItem rootItem = base.GetRootItem();
			this.ItemSizeVector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
			return this.ItemSizeVector.ToUeVector2D(false);
		}

		// Token: 0x06034F40 RID: 216896 RVA: 0x00D47588 File Offset: 0x00D45788
		public UniTask Init(UUIItem actor)
		{
			AttributeSlotDynItem.<Init>d__2 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<AttributeSlotDynItem.<Init>d__2>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06034F41 RID: 216897 RVA: 0x00D475D3 File Offset: 0x00D457D3
		public void ClearItem()
		{
		}

		// Token: 0x0401E846 RID: 124998
		[Nullable(2)]
		private Vector2D ItemSizeVector;
	}
}
