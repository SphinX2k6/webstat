using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020019F8 RID: 6648
public class MiniElementReactionItem : UiPanelBase
{
	// Token: 0x0600BE4C RID: 48716 RVA: 0x0032644D File Offset: 0x0032464D
	[NullableContext(1)]
	public MiniElementReactionItem(AActor rootActor)
	{
		base.CreateThenShowByActor(rootActor, null);
	}

	// Token: 0x0600BE4D RID: 48717 RVA: 0x0032645D File Offset: 0x0032465D
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x0600BE4E RID: 48718 RVA: 0x00326498 File Offset: 0x00324698
	public void SetReactionActivated(bool bActivated)
	{
		UUISprite sprite = base.GetSprite(0);
		UUIItem texture = base.GetTexture(1);
		sprite.SetUIActive(!bActivated);
		texture.SetUIActive(bActivated);
	}

	// Token: 0x02007CE3 RID: 31971
	private enum EChildType
	{
		// Token: 0x0402A9B8 RID: 174520
		DeactivateSprite,
		// Token: 0x0402A9B9 RID: 174521
		ReactionTexture
	}
}
