using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02002425 RID: 9253
public class PersonalCardTabView : UiTabViewBase
{
	// Token: 0x06011E5E RID: 73310 RVA: 0x004EC40E File Offset: 0x004EA60E
	protected override void OnStart()
	{
		if (this.PersonalCardComponent == null)
		{
			this.PersonalCardComponent = new PersonalCardComponent(this.RootItem, true, this.ExtraParams as PersonalInfoData);
		}
	}

	// Token: 0x06011E5F RID: 73311 RVA: 0x004EC435 File Offset: 0x004EA635
	protected override void OnBeforeDestroy()
	{
		if (this.PersonalCardComponent != null)
		{
			this.PersonalCardComponent.Destroy(null);
			this.PersonalCardComponent = null;
		}
	}

	// Token: 0x04008C1A RID: 35866
	[Nullable(2)]
	private PersonalCardComponent PersonalCardComponent;
}
