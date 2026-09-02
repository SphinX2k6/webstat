using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002230 RID: 8752
[NullableContext(1)]
[Nullable(0)]
public class MailDynamicScrollItemNew : UiPanelBase, IDynamicScrollBaseItem<MailData>
{
	// Token: 0x06010870 RID: 67696 RVA: 0x00484D5C File Offset: 0x00482F5C
	public UniTask Init(UUIItem actor)
	{
		MailDynamicScrollItemNew.<Init>d__1 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<MailDynamicScrollItemNew.<Init>d__1>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06010871 RID: 67697 RVA: 0x00484DA8 File Offset: 0x00482FA8
	public FVector2D GetItemSize(MailData data)
	{
		if (this.ItemSizeVector == null)
		{
			this.ItemSizeVector = Vector2D.Create();
		}
		UUIItem rootItem = base.GetRootItem();
		this.ItemSizeVector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
		return this.ItemSizeVector.ToUeVector2D(false);
	}

	// Token: 0x06010872 RID: 67698 RVA: 0x00484DF4 File Offset: 0x00482FF4
	public void ClearItem()
	{
	}

	// Token: 0x040081FD RID: 33277
	[Nullable(2)]
	private Vector2D ItemSizeVector;
}
