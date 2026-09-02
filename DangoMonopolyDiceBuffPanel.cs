using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012F1 RID: 4849
public class DangoMonopolyDiceBuffPanel : UiPanelBase
{
	// Token: 0x06008341 RID: 33601 RVA: 0x0022ACD4 File Offset: 0x00228ED4
	[NullableContext(1)]
	public UniTask Init(UUIItem parent)
	{
		DangoMonopolyDiceBuffPanel.<Init>d__3 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.parent = parent;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<DangoMonopolyDiceBuffPanel.<Init>d__3>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06008342 RID: 33602 RVA: 0x0022AD1F File Offset: 0x00228F1F
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle))
		};
	}

	// Token: 0x06008343 RID: 33603 RVA: 0x0022AD44 File Offset: 0x00228F44
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyDiceBuffPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyDiceBuffPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008344 RID: 33604 RVA: 0x0022AD88 File Offset: 0x00228F88
	public void UpdateShowType(EDangoMonopolyDiceBuffShowType showType)
	{
		this.SetActive(true);
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (showType == EDangoMonopolyDiceBuffShowType.Double)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06008345 RID: 33605 RVA: 0x0022ADBC File Offset: 0x00228FBC
	[NullableContext(1)]
	public UniTask PlaySequence(string name)
	{
		DangoMonopolyDiceBuffPanel.<PlaySequence>d__7 <PlaySequence>d__;
		<PlaySequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySequence>d__.<>4__this = this;
		<PlaySequence>d__.name = name;
		<PlaySequence>d__.<>1__state = -1;
		<PlaySequence>d__.<>t__builder.Start<DangoMonopolyDiceBuffPanel.<PlaySequence>d__7>(ref <PlaySequence>d__);
		return <PlaySequence>d__.<>t__builder.Task;
	}

	// Token: 0x04003E6A RID: 15978
	[Nullable(2)]
	public LevelSequencePlayer Sequence;

	// Token: 0x04003E6B RID: 15979
	[Nullable(2)]
	public CustomPromise<bool> Promise;

	// Token: 0x02007668 RID: 30312
	private enum EChildType
	{
		// Token: 0x04028CD9 RID: 167129
		ToggleRoot
	}
}
