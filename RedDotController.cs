using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020032CD RID: 13005
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class RedDotController : ControllerBase<RedDotController>
{
	// Token: 0x0601B490 RID: 111760 RVA: 0x008318D4 File Offset: 0x0082FAD4
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0601B491 RID: 111761 RVA: 0x008318D8 File Offset: 0x0082FAD8
	[NullableContext(2)]
	public void BindRedDot(ERedDotName name, UUIItem uiItem = null, Action<bool, int> stateChangeCallback = null, int uId = 0)
	{
		RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(name);
		if (redDot == null)
		{
			return;
		}
		redDot.BindUi(uId, uiItem, stateChangeCallback);
	}

	// Token: 0x0601B492 RID: 111762 RVA: 0x00831900 File Offset: 0x0082FB00
	public void UnBindRedDot(ERedDotName name)
	{
		RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(name);
		if (redDot == null)
		{
			return;
		}
		redDot.UnBindUi();
	}

	// Token: 0x0601B493 RID: 111763 RVA: 0x00831924 File Offset: 0x0082FB24
	public void UnBindRedDotAndClearData(ERedDotName name)
	{
		RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(name);
		if (redDot == null)
		{
			return;
		}
		redDot.UnBindUiAndClearData();
	}

	// Token: 0x0601B494 RID: 111764 RVA: 0x00831948 File Offset: 0x0082FB48
	public void UnBindGivenUi(ERedDotName name, UUIItem uiItem = null, int uId = 0)
	{
		RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(name);
		if (redDot == null)
		{
			return;
		}
		redDot.UnBindGivenUi(uId, uiItem);
	}

	// Token: 0x0601B495 RID: 111765 RVA: 0x00831970 File Offset: 0x0082FB70
	public void UnBindGivenUiAndDeleteData(ERedDotName name, UUIItem uiItem = null, int uId = 0)
	{
		RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(name);
		if (redDot == null)
		{
			return;
		}
		redDot.UnBindGivenUiAndDeleteData(uId, uiItem);
	}
}
