using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200130E RID: 4878
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyViewBase : UiTickViewBase
{
	// Token: 0x060084B5 RID: 33973 RVA: 0x00230225 File Offset: 0x0022E425
	public DangoMonopolyViewBase(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060084B6 RID: 33974 RVA: 0x0023022E File Offset: 0x0022E42E
	protected override void OnBeforeCreate()
	{
		this.UpdateActivityData();
	}

	// Token: 0x060084B7 RID: 33975 RVA: 0x00230237 File Offset: 0x0022E437
	protected bool UpdateActivityData()
	{
		this.ActivityData = ControllerBase<ActivityDangoMonopolyController>.Instance.GetData();
		return this.ActivityData != null;
	}

	// Token: 0x04003EF0 RID: 16112
	protected ActivityDangoMonopolyData ActivityData;
}
