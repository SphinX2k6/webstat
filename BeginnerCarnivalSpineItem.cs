using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200125C RID: 4700
public class BeginnerCarnivalSpineItem : UiPanelBase
{
	// Token: 0x06007D49 RID: 32073 RVA: 0x002107FF File Offset: 0x0020E9FF
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent))
		};
	}

	// Token: 0x06007D4A RID: 32074 RVA: 0x00210822 File Offset: 0x0020EA22
	[NullableContext(1)]
	public void SetAnimation(int trackIndex, string animationName, bool loop)
	{
		base.GetSpine(0).SetAnimation(trackIndex, animationName, loop);
	}
}
