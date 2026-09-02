using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001337 RID: 4919
[Nullable(new byte[]
{
	0,
	1
})]
public class FightPhotoTaskTargetItem : GridProxyAbstract<string>
{
	// Token: 0x0600864D RID: 34381 RVA: 0x002362B0 File Offset: 0x002344B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600864E RID: 34382 RVA: 0x0023630A File Offset: 0x0023450A
	[NullableContext(1)]
	public override void Refresh(string data, bool isSelected, int gridIndex)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data, Array.Empty<object>());
	}

	// Token: 0x0600864F RID: 34383 RVA: 0x00236323 File Offset: 0x00234523
	public void SetIsFinished(bool isFinished)
	{
		base.GetSprite(1).SetUIActive(isFinished);
		base.GetSprite(0).SetUIActive(!isFinished);
	}

	// Token: 0x020076DC RID: 30428
	private enum EComponents
	{
		// Token: 0x04028F09 RID: 167689
		SpriteUnFinished,
		// Token: 0x04028F0A RID: 167690
		SpriteFinished,
		// Token: 0x04028F0B RID: 167691
		TextGoal
	}
}
