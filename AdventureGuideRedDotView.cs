using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001740 RID: 5952
public class AdventureGuideRedDotView : UiPanelBase
{
	// Token: 0x0600A742 RID: 42818 RVA: 0x002C7002 File Offset: 0x002C5202
	[NullableContext(1)]
	public AdventureGuideRedDotView(AActor rootActor)
	{
		base.CreateThenShowByActor(rootActor, null);
	}

	// Token: 0x0600A743 RID: 42819 RVA: 0x002C7014 File Offset: 0x002C5214
	public void EnableRedDot(ERedDotName type)
	{
		UUIItem rootItem = base.GetRootItem();
		ControllerBase<RedDotController>.Instance.BindRedDot(type, rootItem, null, 0);
		this.Type = type;
	}

	// Token: 0x0600A744 RID: 42820 RVA: 0x002C703D File Offset: 0x002C523D
	protected override void OnBeforeDestroy()
	{
		this.DisableRedDot(this.Type);
	}

	// Token: 0x0600A745 RID: 42821 RVA: 0x002C704B File Offset: 0x002C524B
	public void DisableRedDot(ERedDotName type)
	{
		ControllerBase<RedDotController>.Instance.UnBindRedDot(type);
	}

	// Token: 0x04004EF8 RID: 20216
	private ERedDotName Type;
}
