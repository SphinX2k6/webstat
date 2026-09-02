using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012F7 RID: 4855
public class DangoMonopolyPosition : UiPanelBase
{
	// Token: 0x060083CB RID: 33739 RVA: 0x0022CF48 File Offset: 0x0022B148
	[NullableContext(1)]
	public UniTask Init(UUIItem parent)
	{
		DangoMonopolyPosition.<Init>d__1 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.parent = parent;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<DangoMonopolyPosition.<Init>d__1>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060083CC RID: 33740 RVA: 0x0022CF93 File Offset: 0x0022B193
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x060083CD RID: 33741 RVA: 0x0022CFB6 File Offset: 0x0022B1B6
	public void UpdatePosition(FVector2D vec, bool show = true)
	{
		this.SetActive(show);
		base.GetRootItem().SetAnchorOffset(vec);
	}

	// Token: 0x0200768C RID: 30348
	private enum EChildType
	{
		// Token: 0x04028D92 RID: 167314
		Item
	}
}
