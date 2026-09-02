using System;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain;

// Token: 0x020033BE RID: 13246
public class RedDotRoleChange : RedDotBase
{
	// Token: 0x0601B8EA RID: 112874 RVA: 0x0083B8A8 File Offset: 0x00839AA8
	protected override bool OnCheck(int uId = 0)
	{
		bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.DirectTrainMakeRoleChange, false);
		return ActivityDirectTrainHelper.IsProOpen && !player;
	}
}
