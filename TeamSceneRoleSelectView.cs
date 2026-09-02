using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020027A2 RID: 10146
public class TeamSceneRoleSelectView : TeamRoleSelectView, IUiViewResource
{
	// Token: 0x06014089 RID: 82057 RVA: 0x00597BAC File Offset: 0x00595DAC
	[NullableContext(1)]
	public TeamSceneRoleSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601408A RID: 82058 RVA: 0x00597BB5 File Offset: 0x00595DB5
	[NullableContext(1)]
	public string GetExtraResourceId([Nullable(2)] object param = null)
	{
		return "UiView_SelectRole";
	}
}
