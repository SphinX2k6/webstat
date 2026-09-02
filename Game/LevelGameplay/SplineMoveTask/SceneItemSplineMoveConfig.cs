using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006AD4 RID: 27348
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemSplineMoveConfig : ISceneItemSplineMoveConfig
	{
		// Token: 0x1700A2BD RID: 41661
		// (get) Token: 0x060439D8 RID: 276952 RVA: 0x01171999 File Offset: 0x0116FB99
		// (set) Token: 0x060439D9 RID: 276953 RVA: 0x011719A1 File Offset: 0x0116FBA1
		public ISceneItemSplineMoveSegmentConfig GlobalConfig { get; set; }

		// Token: 0x1700A2BE RID: 41662
		// (get) Token: 0x060439DA RID: 276954 RVA: 0x011719AA File Offset: 0x0116FBAA
		// (set) Token: 0x060439DB RID: 276955 RVA: 0x011719B2 File Offset: 0x0116FBB2
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ISceneItemSplineMoveSegmentConfig> PointConfigs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700A2BF RID: 41663
		// (get) Token: 0x060439DC RID: 276956 RVA: 0x011719BB File Offset: 0x0116FBBB
		// (set) Token: 0x060439DD RID: 276957 RVA: 0x011719C3 File Offset: 0x0116FBC3
		public ISceneItemSplineMoveRange SplineMoveRange { get; set; }

		// Token: 0x1700A2C0 RID: 41664
		// (get) Token: 0x060439DE RID: 276958 RVA: 0x011719CC File Offset: 0x0116FBCC
		// (set) Token: 0x060439DF RID: 276959 RVA: 0x011719D4 File Offset: 0x0116FBD4
		public int MoveCount { get; set; }

		// Token: 0x1700A2C1 RID: 41665
		// (get) Token: 0x060439E0 RID: 276960 RVA: 0x011719DD File Offset: 0x0116FBDD
		// (set) Token: 0x060439E1 RID: 276961 RVA: 0x011719E5 File Offset: 0x0116FBE5
		public bool IsClosedLoop { get; set; }

		// Token: 0x1700A2C2 RID: 41666
		// (get) Token: 0x060439E2 RID: 276962 RVA: 0x011719EE File Offset: 0x0116FBEE
		// (set) Token: 0x060439E3 RID: 276963 RVA: 0x011719F6 File Offset: 0x0116FBF6
		public bool IsLookDir { get; set; }
	}
}
