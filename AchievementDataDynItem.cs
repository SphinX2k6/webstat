using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FDA RID: 4058
[NullableContext(1)]
[Nullable(0)]
public class AchievementDataDynItem : UiPanelBase, IDynamicScrollBaseItem<AchievementData>
{
	// Token: 0x06006886 RID: 26758 RVA: 0x001B3BD4 File Offset: 0x001B1DD4
	public UniTask Init(UUIItem actor)
	{
		AchievementDataDynItem.<Init>d__1 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<AchievementDataDynItem.<Init>d__1>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06006887 RID: 26759 RVA: 0x001B3C20 File Offset: 0x001B1E20
	public FVector2D GetItemSize(AchievementData data)
	{
		if (this.ItemSizeVector == null)
		{
			this.ItemSizeVector = Vector2D.Create();
		}
		UUIItem rootItem = base.GetRootItem();
		this.ItemSizeVector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
		return this.ItemSizeVector.ToUeVector2D(false);
	}

	// Token: 0x06006888 RID: 26760 RVA: 0x001B3C6C File Offset: 0x001B1E6C
	public void ClearItem()
	{
	}

	// Token: 0x040031C3 RID: 12739
	[Nullable(2)]
	private Vector2D ItemSizeVector;
}
