using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001ACF RID: 6863
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssAttributeBaseItem : UiPanelBase, IDynamicScrollBaseItem<DangoAbyssDefine.EquipViewAttributeData>
{
	// Token: 0x0600C58B RID: 50571 RVA: 0x00342E20 File Offset: 0x00341020
	public UniTask Init(UUIItem actor)
	{
		DangoAbyssAttributeBaseItem.<Init>d__0 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<DangoAbyssAttributeBaseItem.<Init>d__0>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600C58C RID: 50572 RVA: 0x00342E6C File Offset: 0x0034106C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x0600C58D RID: 50573 RVA: 0x00342EC8 File Offset: 0x003410C8
	public FVector2D GetItemSize(DangoAbyssDefine.EquipViewAttributeData data)
	{
		if (data.Attribute != null)
		{
			UUIItem item = base.GetItem(1);
			return new FVector2D(item.GetWidth(), item.GetHeight());
		}
		if (data.Tag != null)
		{
			UUIItem item2 = base.GetItem(2);
			return new FVector2D(item2.GetWidth(), item2.GetHeight());
		}
		UUIItem item3 = base.GetItem(0);
		return new FVector2D(item3.GetWidth(), item3.GetHeight());
	}

	// Token: 0x0600C58E RID: 50574 RVA: 0x00342F32 File Offset: 0x00341132
	public void ClearItem()
	{
	}
}
