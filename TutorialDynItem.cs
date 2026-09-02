using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C1F RID: 11295
[NullableContext(1)]
[Nullable(0)]
public class TutorialDynItem : UiPanelBase, IDynamicScrollBaseItem<TutorialItemData>
{
	// Token: 0x060169C0 RID: 92608 RVA: 0x006463AC File Offset: 0x006445AC
	public UniTask Init(UUIItem actor)
	{
		TutorialDynItem.<Init>d__1 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<TutorialDynItem.<Init>d__1>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060169C1 RID: 92609 RVA: 0x006463F8 File Offset: 0x006445F8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
	}

	// Token: 0x060169C2 RID: 92610 RVA: 0x00646480 File Offset: 0x00644680
	public FVector2D GetItemSize(TutorialItemData data)
	{
		if (this.ItemSizeVector == null)
		{
			this.ItemSizeVector = Vector2D.Create();
		}
		if (data.IsTypeTitle)
		{
			UUIItem item = base.GetItem(0);
			this.ItemSizeVector.Set((double)item.GetWidth(), (double)item.GetHeight());
			return this.ItemSizeVector.ToUeVector2D(false);
		}
		UUIItem rootItem = base.GetRootItem();
		this.ItemSizeVector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
		return this.ItemSizeVector.ToUeVector2D(false);
	}

	// Token: 0x060169C3 RID: 92611 RVA: 0x00646502 File Offset: 0x00644702
	public void ClearItem()
	{
	}

	// Token: 0x0400AE7E RID: 44670
	[Nullable(2)]
	private Vector2D ItemSizeVector;
}
