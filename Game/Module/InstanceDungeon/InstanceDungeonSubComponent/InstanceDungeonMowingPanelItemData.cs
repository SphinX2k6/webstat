using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BEB RID: 23531
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceDungeonMowingPanelItemData
	{
		// Token: 0x170097A5 RID: 38821
		// (get) Token: 0x0603B90A RID: 243978 RVA: 0x00F198D4 File Offset: 0x00F17AD4
		// (set) Token: 0x0603B90B RID: 243979 RVA: 0x00F198DC File Offset: 0x00F17ADC
		public bool ScoreItemActive { get; set; }

		// Token: 0x170097A6 RID: 38822
		// (get) Token: 0x0603B90C RID: 243980 RVA: 0x00F198E5 File Offset: 0x00F17AE5
		// (set) Token: 0x0603B90D RID: 243981 RVA: 0x00F198ED File Offset: 0x00F17AED
		[Nullable(2)]
		public string ScoreText { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170097A7 RID: 38823
		// (get) Token: 0x0603B90E RID: 243982 RVA: 0x00F198F6 File Offset: 0x00F17AF6
		// (set) Token: 0x0603B90F RID: 243983 RVA: 0x00F198FE File Offset: 0x00F17AFE
		public Action LeftBtnClickCallBack { get; set; }

		// Token: 0x170097A8 RID: 38824
		// (get) Token: 0x0603B910 RID: 243984 RVA: 0x00F19907 File Offset: 0x00F17B07
		// (set) Token: 0x0603B911 RID: 243985 RVA: 0x00F1990F File Offset: 0x00F17B0F
		public Action RightBtnClickCallBack { get; set; }
	}
}
