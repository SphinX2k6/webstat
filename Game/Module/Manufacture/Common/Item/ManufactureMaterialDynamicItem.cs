using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common.Item
{
	// Token: 0x020059F6 RID: 23030
	[NullableContext(1)]
	[Nullable(0)]
	public class ManufactureMaterialDynamicItem : UiPanelBase, IDynamicScrollBaseItem<ISingleItemInfo>
	{
		// Token: 0x0603A58A RID: 238986 RVA: 0x00ECB480 File Offset: 0x00EC9680
		public UniTask Init(UUIItem actor)
		{
			ManufactureMaterialDynamicItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<ManufactureMaterialDynamicItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603A58B RID: 238987 RVA: 0x00ECB4CC File Offset: 0x00EC96CC
		public FVector2D GetItemSize(ISingleItemInfo data)
		{
			if (this.ItemSizeVector == null)
			{
				this.ItemSizeVector = new Vector2D();
			}
			UUIItem rootItem = base.GetRootItem();
			this.ItemSizeVector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
			return this.ItemSizeVector.ToUeVector2D(false);
		}

		// Token: 0x0603A58C RID: 238988 RVA: 0x00ECB518 File Offset: 0x00EC9718
		public void ClearItem()
		{
		}

		// Token: 0x040210AE RID: 135342
		[Nullable(2)]
		private Vector2D ItemSizeVector;
	}
}
