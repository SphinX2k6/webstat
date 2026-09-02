using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02002C4A RID: 11338
[Nullable(new byte[]
{
	0,
	1
})]
public class UiCameraController : UiControllerBase<UiCameraController>
{
	// Token: 0x06016B7B RID: 93051 RVA: 0x0064E99D File Offset: 0x0064CB9D
	protected override bool OnInit()
	{
		UiCameraManager.Initialize();
		return true;
	}

	// Token: 0x06016B7C RID: 93052 RVA: 0x0064E9A5 File Offset: 0x0064CBA5
	protected override bool OnClear()
	{
		UiCameraManager.Clear();
		return true;
	}

	// Token: 0x06016B7D RID: 93053 RVA: 0x0064E9AD File Offset: 0x0064CBAD
	protected override bool OnLeaveLevel()
	{
		UiCameraManager.Clear();
		return true;
	}
}
