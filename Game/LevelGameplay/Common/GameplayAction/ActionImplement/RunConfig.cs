using System;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction.ActionImplement
{
	// Token: 0x02006F35 RID: 28469
	public class RunConfig : IRunConfig, IMoveConfig
	{
		// Token: 0x1700A451 RID: 42065
		// (get) Token: 0x06044EBF RID: 282303 RVA: 0x011F12A1 File Offset: 0x011EF4A1
		// (set) Token: 0x06044EC0 RID: 282304 RVA: 0x011F12A9 File Offset: 0x011EF4A9
		public float RotateSpeed { get; set; }

		// Token: 0x1700A452 RID: 42066
		// (get) Token: 0x06044EC1 RID: 282305 RVA: 0x011F12B2 File Offset: 0x011EF4B2
		// (set) Token: 0x06044EC2 RID: 282306 RVA: 0x011F12BA File Offset: 0x011EF4BA
		public float MoveSpeed { get; set; }
	}
}
