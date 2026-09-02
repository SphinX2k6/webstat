using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200146C RID: 5228
public class ActivityNewPlayerSupportEntranceItem : UiPanelBase
{
	// Token: 0x06009245 RID: 37445 RVA: 0x0026969C File Offset: 0x0026789C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnEntranceBtnClick))
		};
	}

	// Token: 0x06009246 RID: 37446 RVA: 0x00269719 File Offset: 0x00267919
	protected override void OnBeforeDestroy()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(2), 0);
			this.RedDotName = null;
		}
	}

	// Token: 0x06009247 RID: 37447 RVA: 0x00269751 File Offset: 0x00267951
	[NullableContext(1)]
	public void SetEntranceFunc(Action func)
	{
		this.EntranceFunc = func;
	}

	// Token: 0x06009248 RID: 37448 RVA: 0x0026975A File Offset: 0x0026795A
	public void BindRedDot(ERedDotName redDotName)
	{
		this.RedDotName = new ERedDotName?(redDotName);
		ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, base.GetItem(2), null, 0);
	}

	// Token: 0x06009249 RID: 37449 RVA: 0x0026977C File Offset: 0x0026797C
	private void OnEntranceBtnClick()
	{
		Action entranceFunc = this.EntranceFunc;
		if (entranceFunc == null)
		{
			return;
		}
		entranceFunc();
	}

	// Token: 0x040043BD RID: 17341
	[Nullable(2)]
	private Action EntranceFunc;

	// Token: 0x040043BE RID: 17342
	private ERedDotName? RedDotName;

	// Token: 0x0200786F RID: 30831
	private static class EEntranceComponentType
	{
		// Token: 0x040296B5 RID: 169653
		public const int EntranceBtn = 0;

		// Token: 0x040296B6 RID: 169654
		public const int EntranceText = 1;

		// Token: 0x040296B7 RID: 169655
		public const int RedDotItem = 2;
	}
}
